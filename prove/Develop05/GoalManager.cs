using System.Diagnostics;

public class GoalManager{
    private List<Goal> _goals = new List<Goal>();
    public List<Goal> goals { get{return _goals;} set{_goals = value;} }
    private int _score = 0;
    public int score { get{return _score;} set{_score = value;} }

    public GoalManager(){
        Start();
    }

    private void Start(){
        Console.Clear();
        string userInput = "";        
        List<string> options = new List<string>(){
            "1", "2", "3", "4", "5", "6"
        };    
        
        while(!options.Contains(userInput)){
            DisplayPlayerInfo();
            Console.Write("\nMenu Options:\n  1. Create New Goal\n  2. List Goals\n  3. Save Goals\n  4. Load Goals\n  5. Record Event\n  6. Quit\n\nSelect a choice from the menu: ");
            userInput = Console.ReadLine();
            switch(userInput){
            case "1":
                CreateGoal();                
                userInput = "";
                break;
            case "2":
                ListGoalDetails();
                userInput = "";
                break;
            case "3":
                SaveGoals();
                userInput = "";
                break;
            case "4":
                LoadGoals();
                userInput = "";
                break;
            case "5":
                if(goals.Count>0){
                    RecordEvent();
                }
                else{
                    Console.Clear();
                    Console.WriteLine("There are no goals recorded.");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                userInput = "";
                break;
            case "6":
                Bye();
                break;
            default:            
                validCheck();
                break;
            }
        }
    }

    public void DisplayPlayerInfo(){
        Console.WriteLine($"You have {score} points.");
    }

    private void CreateGoal(){
        Console.Clear();
        string userInput = "";
        List<string> options = new List<string>(){
            "1", "2", "3"
        };
        while(!options.Contains(userInput)){
            Console.Write("The types of Goals are:\n  1. Simple Goal\n  2. Eternal Goal\n  3. Checklist Goal\n\nWhich type of goal would you like to create? ");
            userInput= Console.ReadLine();
            switch(userInput){
                case "1":
                    SimpleGoal simpleGoal = new SimpleGoal("", "", "");
                    Console.Write("What is the name of your goal? ");
                    simpleGoal.name = Console.ReadLine();
                    Console.Write("What is a short description of it? ");
                    simpleGoal.description = Console.ReadLine();
                    Console.Write("What is the amount of points associated with this goal? ");
                    simpleGoal.points = Console.ReadLine();
                    while(!CheckNumber(simpleGoal.points)){ 
                        Console.Write("Enter a valid number for the points: ");       
                        simpleGoal.points = Console.ReadLine();             
                    }
                    goals.Add(simpleGoal);  
                    Console.Clear();
                    break;
                case "2":
                    EternalGoal eternalGoal = new EternalGoal("", "", "");
                    Console.Write("What is the name of your goal? ");
                    eternalGoal.name = Console.ReadLine();
                    Console.Write("What is a short description of it? ");
                    eternalGoal.description = Console.ReadLine();
                    Console.Write("What is the amount of points associated with this goal? ");
                    eternalGoal.points = Console.ReadLine();
                    while(!CheckNumber(eternalGoal.points)){ 
                        Console.Write("Enter a valid number for the points: ");       
                        eternalGoal.points = Console.ReadLine();             
                    }
                    goals.Add(eternalGoal);
                    Console.Clear();
                    break;
                case "3":
                    string check;
                    ChecklistGoal checklistGoal = new ChecklistGoal("", "", "", 0, 0);
                    Console.Write("What is the name of your goal? ");
                    checklistGoal.name = Console.ReadLine();
                    Console.Write("What is a short description of it? ");
                    checklistGoal.description = Console.ReadLine();
                    Console.Write("What is the amount of points associated with this goal? ");
                    checklistGoal.points = Console.ReadLine();
                    while(!CheckNumber(checklistGoal.points)){ 
                        Console.Write("Enter a valid number for the points: ");       
                        checklistGoal.points = Console.ReadLine();             
                    }
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    check = Console.ReadLine();
                    while(!CheckNumber(check)){ 
                        Console.Write("Enter a valid number for the bonus: ");       
                        check = Console.ReadLine();             
                    }
                    checklistGoal.target = int.Parse(check);
                    Console.Write($"What is the bonus for accomplishing it {checklistGoal.target} times? ");
                    check = Console.ReadLine();
                    while(!CheckNumber(check)){ 
                        Console.Write("Enter a valid number for the accomplishing times: ");       
                        check = Console.ReadLine();             
                    }
                    checklistGoal.bonus = int.Parse(check);
                    goals.Add(checklistGoal);
                    Console.Clear();
                    break;
                default:
                    validCheck();
                    break;
            }
        }
    }

    private void validCheck(){
        Console.Clear();
        Console.WriteLine("Please enter a valid choice.");
        Thread.Sleep(2000);
        Console.Clear();
    }

    private void ListGoalNames(){
        int i = 1;
        foreach(Goal goal in goals){
            Console.WriteLine($"{i}. {goal.name}");
            i++;
        }
    }

    private void ListGoalDetails(){
        Console.Clear();
        if(goals.Count>0){
            Console.WriteLine("The goals are:");
        }
        else{
            Console.Clear();
            Console.WriteLine("You have no goals to list.");
            Thread.Sleep(2000);
            Console.Clear();
        }
        int i = 1;
        foreach(Goal goal in goals){
            Console.WriteLine($"{i}. {goal.GetDetailsString()}");
            i++;
        }
        Console.WriteLine();
    }

    private void RecordEvent(){
        string userInput = "";
        int goalNumber;
        int i = 1;
        List<string> options = new List<string>();
        foreach(Goal goal in goals){
            options.Add($"{i}");
            i++;
        }

        while(!options.Contains(userInput)){
            Console.Clear();
            Console.WriteLine("The goals are:");
            ListGoalNames();
            Console.Write("Which goal did you accomplish? ");
            userInput = Console.ReadLine();
        }
        goalNumber = int.Parse(userInput) - 1;
        goals[goalNumber].IsComplete();
        if(!goals[goalNumber].IsComplete()){
            goals[goalNumber].RecordEvent();
            score += int.Parse(goals[goalNumber].points);
            Celebration();
        }
        else{            
            Console.Clear();
            Console.WriteLine("You already completed that goal.");
            Thread.Sleep(2000);
            Console.Clear();
        }
        Console.Clear();
    }

    //(1)
    private void Celebration(){
        for(int i=0; i<3; i++){
            Console.Clear();
            Console.WriteLine("/(OuO)/");
            Console.WriteLine("Congratulations");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("|(OuO)|");
            Console.WriteLine("Congratulations!");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("\\(OuO)\\");
            Console.WriteLine("Congratulations!!");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("|(-u-)|");
            Console.WriteLine("Congratulations!");
            Thread.Sleep(300);
        }
    }

    //(1)
    private void Bye(){
        for(int i=0; i<3; i++){
            Console.Clear();
            Console.WriteLine("(OuO)/");            
            Console.WriteLine("Thank you for using the program.");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine("(OuO)|");
            Console.WriteLine("Thank you for using the program..");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine("(OuO)/");
            Console.WriteLine("Thank you for using the program...");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine("(-u-)|");
            Console.WriteLine("Thank you for using the program..");
            Thread.Sleep(500);
        }
    }

    private bool CheckNumber(string word){
        int i = 0;
        bool result = int.TryParse(word, out i);
        return result;
    }

    private void SaveGoals(){
        Console.Write("What is the name of the file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(score);
            foreach(Goal goal in goals){
                outputFile.WriteLine(goal+"|"+goal.GetStringRepresentation());
            }
        }
        Console.Clear();
        Console.WriteLine($"The file {filename} was saved successfully.");
        Thread.Sleep(2000);
        Console.Clear();
    }
    private void LoadGoals(){
        Console.Write("What is the name of the file to load? ");
        string filename = Console.ReadLine();
        while(!File.Exists(filename)){
            Console.Clear();
            Console.Write($"the file {filename} does not exist, enter a valid file name: ");
            filename = Console.ReadLine();
        }
        string[] lines = System.IO.File.ReadAllLines(filename);
        goals.Clear();
        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            string goalType = parts[0];
            switch(goalType){
                case "SimpleGoal":                    
                    SimpleGoal simpleGoal = new SimpleGoal(parts[1], parts[2], parts[3]);
                    simpleGoal.isComplete = bool.Parse(parts[4]);
                    goals.Add(simpleGoal);
                    break;
                case "EternalGoal":
                    EternalGoal eternalGoal = new EternalGoal(parts[1], parts[2], parts[3]);
                    goals.Add(eternalGoal);
                    break;
                case "ChecklistGoal":
                    ChecklistGoal checkListGoal = new ChecklistGoal(parts[1], parts[2], parts[3], int.Parse(parts[6]), int.Parse(parts[4]));
                    checkListGoal.amountCompleted = int.Parse(parts[5]);
                    goals.Add(checkListGoal);
                    break;
                default:
                    score = int.Parse(parts[0]);
                    break;
            }
        }
        Console.Clear();
        Console.WriteLine($"The file {filename} was loaded successfully.");
        Thread.Sleep(2000);
        Console.Clear();
    }
}