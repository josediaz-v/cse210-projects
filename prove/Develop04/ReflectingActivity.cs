class ReflectingActivity : Activity{
    private List<string> _prompts = new List<string>(){        
        "--- Think of a time when you did something really difficult. ---",
        "--- Think of a time when you stood up for someone else. ---",
        "--- Think of a time when you helped someone in need. ---",
        "--- Think of a time when you did something truly selfless. ---"
    };
    public List<string> prompts { get {return _prompts;} set{_prompts = value;} }
    private List<string> _questions = new List<string>(){
        "> Why was this experience meaningful to you? ",
        "> Have you ever done anything like this before? ",
        "> How did you get started? ",
        "> How did you feel when it was complete? ",
        "> What made this time different than other times when you were not as successful? ",
        "> What is your favorite thing about this experience? ",
        "> What could you learn from this experience that applies to other situations? ",
        "> What did you learn about yourself through this experience? ",
        "> How can you keep this experience in mind in the future? ",
    };
    public List<string> questions { get{return _questions;} set{_questions = value;} }

    public ReflectingActivity(){
        Run();
    }

    private void Run(){
        name = "Reflecting Activity";
        description = "Reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        DisplayStartingMesage();
        DisplayPrompt();
        DisplayQuestions();
        DisplayEndingMessage();
    }
    private string GetRandomPromt(){
        Random rndNumber = new Random();
        int rndIndex = rndNumber.Next(0, prompts.Count());
        string rndPromt = prompts[rndIndex];
        return rndPromt;
    }

    private string GetRandomQuestion(){        
        Random rndNumber = new Random();
        int rndIndex = rndNumber.Next(0, questions.Count());
        string rndPromt = questions[rndIndex];
        return rndPromt;
    }

    private void DisplayPrompt(){
        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"\n{GetRandomPromt()}");
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write($"You may begin in: ");
        ShowCountDown(5);
    }

    private void DisplayQuestions(){
        DateTime currentTime = DateTime.Now;
        DateTime endTime = currentTime.AddSeconds(duration);
        Console.Clear();
        //foreach(string question in questions){
        while(GetRemainingTime(endTime)>0){
            Console.Write($"\n{GetRandomQuestion()}");
            ShowSpinner(10);
        }
                /*if(GetRemainingTime(endTime)>0){
                    Console.Write($"\n{GetRandomQuestion()}");
                    ShowSpinner(20);
                }*/
        //}
    }
}