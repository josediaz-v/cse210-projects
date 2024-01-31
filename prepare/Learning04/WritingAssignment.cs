public class WritingAssignment : Assignment{
    private string _title;

    public WritingAssignment(string studentName, string topic, string title) : base(studentName, topic){
        SetTitle(title);
    }

    public string GetWritingInformation(){
        return $"{GetTitle()} by {GetStudentName()}";
    }

    //Getters
    private string GetTitle(){
        return _title;
    }

    //Setters
    private void SetTitle(string title){
        _title = title;
    }
}