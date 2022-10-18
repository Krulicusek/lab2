using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class CarUtility
    {
        private BackgroundWorker backgroundWorker;
        public CarUtility()
        {
            InitializeBackgroundWorker();
        }
        private void InitializeBackgroundWorker()
        {
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerSupportsCancellation = true;            
            backgroundWorker.DoWork += new DoWorkEventHandler(BackgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker_RunWorkerCompleted);
        }
        public bool IsFinished { get; private set; }
        public async Task ChangeTire(int tireNumber)
        {
            Console.WriteLine($"Changing tire number {tireNumber}...");
            Task.Run(
            async () =>
            {
                Task.Delay(2000);
                Console.WriteLine($"Changing tire number {tireNumber} completed");
            });
        }

        public void StopSign(bool shouldWork)
        {
            if (shouldWork)
            {
                backgroundWorker.RunWorkerAsync();
                IsFinished = false;
            }
            else
            {
                backgroundWorker.CancelAsync();                
            }            
        }
        private void BackgroundWorker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            Task.Run(async () =>
            {
                await Task.Delay(1000);
                Console.WriteLine("Stop sign deactivated...");
                IsFinished = true;
            });
        }
        private async void BackgroundWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            if (sender == null)
            {
                return;
            }
            BackgroundWorker bw = sender as BackgroundWorker;

            while (!bw.CancellationPending)
            {                
                Task.Run (() => 
                {
                    Task.Delay(100);
                    Console.WriteLine("Stop sign active");
                });
            }
          
        }
        
    }
}
