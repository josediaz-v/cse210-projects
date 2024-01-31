public class Assignment{
    private string _studentName;
    private string _topic;

    public Assignment(string studentName, string topic){
        SetStudentName(studentName);
        SetTopic(topic);
    }
    public string GetSummary(){
        return $"{GetStudentName()} - {GetTopic()}";
    }

    //Getters
    public string GetStudentName(){
        return _studentName;
    }

    private string GetTopic(){
        return _topic;
    }

    //Setters
    private void SetStudentName(string studentName){
        _studentName = studentName;
    }

    private void SetTopic(string topic){
        _topic = topic;
    }
}