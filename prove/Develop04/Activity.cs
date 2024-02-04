using System.Diagnostics.Metrics;

class Activity{
    public string name { get; set; }
    public string description { get; set; }
    public int duration { get; set; }
    public double remainingTime { get; set; }

    public Activity(){

    }

    protected void DisplayStartingMesage(){
        Console.Clear();
        Console.WriteLine($"Welcome to the {name}\n\nThis activity will help you {description}"); 
        Console.Write("\nHow long, in seconds, would you like for your session? ");
        duration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    protected void DisplayEndingMessage(){
        Console.WriteLine();
        Console.WriteLine("\nWell done!!");
        ShowSpinner(3);
        Console.WriteLine($"\nYou have completed another {duration} seconds of the {name}.");
        ShowSpinner(5);
    }
    
    //(2)
    protected void ShowSpinner(int seconds){
        DateTime currentTime = DateTime.Now;
        DateTime endTime = currentTime.AddSeconds(duration);
        while(seconds>0){
            Console.Write("-");
            Thread.Sleep(200);
            Console.Write("\b \b");

            Console.Write("\\");
            Thread.Sleep(200);
            Console.Write("\b \b");

            Console.Write("|");
            Thread.Sleep(200);
            Console.Write("\b \b");
            
            Console.Write("/");
            Thread.Sleep(200);
            Console.Write("\b \b");
            
            GetRemainingTime(endTime);
            seconds -=1;

            if(remainingTime<=0){
                break;
            }
        }
    }

    protected double GetRemainingTime(DateTime endTime){
        remainingTime = (endTime-DateTime.Now).TotalSeconds;
        return remainingTime;
    }

    protected void ShowCountDown(int seconds){
        while(seconds>0){
            Console.Write(seconds);
            Thread.Sleep(1000);
            Console.Write("\b \b");
            seconds -=1;
        }
    }
    //(3)
    protected async Task CountDownAsync(DateTime endTime, CancellationToken cancellationToken)
    {
        while (GetRemainingTime(endTime) > 0 && !cancellationToken.IsCancellationRequested)
        {
            await Task.Delay(1000);
        }
    }
}