using System.Diagnostics.Metrics;

class ListingActivity : Activity{    
    static ManualResetEvent counterFinishedEvent = new ManualResetEvent(false);
    public int count { get; set; }
    private List<string> _prompts = new List<string>(){
        "--- Who are people that you appreciate? ---",
        "--- What are personal strengths of yours? ---",
        "--- Who are people that you have helped this week? ---",
        "--- When have you felt the Holy Ghost this month? ---",
        "--- Who are some of your personal heroes? ---"
    };
    public List<string> prompts { get {return _prompts;} set{_prompts = value;} }
    List<string> userList = new List<string>();

    public ListingActivity(){
        Run();
    }

    private void Run(){
        name = "Listing Activity";
        description = "reflect on the good things in your life by having you list as many things as you can in a certain area.";
        DisplayStartingMesage();
        Console.WriteLine("\nList as many responses you can to the following prompt:");
        GetRandomPromt();
        Console.Write($"You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();
        GetListFromUserAsync();
        Console.WriteLine($"You listed {userList.Count()} items");
        DisplayEndingMessage();
    }

    private void GetRandomPromt(){        
        Random rndNumber = new Random();
        int rndIndex = rndNumber.Next(0, prompts.Count());
        string rndPromt = prompts[rndIndex];
        Console.WriteLine($"\n{rndPromt}");
    }
    private async Task<List<string>> GetListFromUserAsync()
    {
        DateTime currentTime = DateTime.Now;
        DateTime endTime = currentTime.AddSeconds(duration);

        CancellationTokenSource cts = new CancellationTokenSource();

        Task countdownTask = Task.Run(() => CountDownAsync(endTime, cts.Token));

        while (GetRemainingTime(endTime) > 0)
        {
            Console.Write("> ");
            string userInput = Console.ReadLine();

            if (userInput != null)
            {
                userList.Add(userInput);
            }
        }
        cts.Cancel();
        await countdownTask;
        return userList;
    }
}