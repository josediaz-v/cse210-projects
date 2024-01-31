public class MathAssignment : Assignment{
    private string _textbookSection;
    private string _problems;
    
    public MathAssignment(string studentName, string topic, string textbookSection, string problems) : base(studentName, topic){
        SetTextBookSection(textbookSection);
        SetProblems(problems);
    }

    public string GetHomeworkList(){
        return $"Section {GetTextBookSection()} Problems {GetProblems()}";
    }

    //Getters
    private string GetTextBookSection(){
        return _textbookSection;
    }

    private string GetProblems(){
        return _problems;
    }

    //Setters
    private void SetTextBookSection(string textbookSection){
        _textbookSection = textbookSection;
    }

    private void SetProblems(string problems){
        _problems = problems;
    }
}