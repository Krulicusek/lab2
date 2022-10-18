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
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.DoWork += new DoWorkEventHandler(BackgroundWorker_DoWork);
        }

        public void ChangeTire()
        {

        }

        public void StopSign(bool shouldWork)
        {
            if (shouldWork)
            {
                backgroundWorker.RunWorkerAsync();
            }
            else
            {
                backgroundWorker.CancelAsync();
            }
        }

        private void BackgroundWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            if (sender == null)
            {
                return;
            }
            BackgroundWorker bw = sender as BackgroundWorker;
            if (bw.CancellationPending)
            {
                e.Cancel = true;
            }
            e.Result = LogState(bw, e);
        }
        private async Task LogState(BackgroundWorker bw, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(100);
                Console.WriteLine("stop sign is active");
                //Check if there is a request to cancel the process
                if (backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }
    }
}
