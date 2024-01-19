public class PromptGenerator{
    List<string> _prompts = new List<string>() {
        "What did you learn today?",
        "What miracle did you see today?",
        "How did you see God's hand in your day?",
        "How did you share the Ghospel today?",
        "Did you meet someone interesting today?",
        "How did The Lord humbled you today?",
        "What new place did you visit today?"
    };

    public string GetRandomPrompt(){
        var random = new Random();
        int index = random.Next(_prompts.Count);
        string prompt = _prompts[index];
        return prompt;
    }
}