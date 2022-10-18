using lab2;
CarUtility carUtility = new CarUtility();

carUtility.StopSign(true);
await PitStop();
carUtility.StopSign(false);
while (!carUtility.IsFinished)
{
    //checking what happens here
}

async Task PitStop()
{    
    carUtility.ChangeTire(1);
    carUtility.ChangeTire(2);
    carUtility.ChangeTire(3);
    carUtility.ChangeTire(4);    
}