class ListingActivity : Activity{
    private int _count;
    public int count { get {return _count;} set {_count = value;} }
    private List<string> _prompts = new List<string>(){
        "--- Who are people that you appreciate? ---",
        "--- What are personal strengths of yours? ---",
        "--- Who are people that you have helped this week? ---",
        "--- When have you felt the Holy Ghost this month? ---",
        "--- Who are some of your personal heroes? ---"
    };
    public List<string> prompts { get {return _prompts;} set{_prompts = value;} }

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
        GetListFromUser();
        Console.WriteLine($"You listed {GetListFromUser().Count()} items");
        DisplayEndingMessage();
    }

    private void GetRandomPromt(){        
        Random rndNumber = new Random();
        int rndIndex = rndNumber.Next(0, prompts.Count());
        string rndPromt = prompts[rndIndex];
        Console.WriteLine($"\n{rndPromt}");
    }

    private List<string> GetListFromUser(){
        List<string> userList = new List<string>();
        DateTime currentTime = DateTime.Now;
        DateTime endTime = currentTime.AddSeconds(duration);
        while(GetRemainingTime(endTime)>0)
        {
            Console.Write("> ");
            userList.Add(Console.ReadLine());
        }
        return userList;
    }
}