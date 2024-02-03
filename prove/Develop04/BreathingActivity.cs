class BreathingActivity : Activity{
    public BreathingActivity(){
        Run();
    }

    public void Run(){
        name = "Breathing Activity";
        description = "relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
        DisplayStartingMesage();

        DateTime currentTime = DateTime.Now;
        DateTime endTime = currentTime.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("\nBreath in...");
            ShowCountDown(4);
            Console.WriteLine();

            Console.Write("Now breath out...");
            ShowCountDown(6);
        }
        DisplayEndingMessage();
    }
}