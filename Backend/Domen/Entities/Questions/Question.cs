namespace QuizApplication.Domain.Entities.Questions;

public class Question
{
    public long Id { get; set; }
    public string Text { get; set; }
    public string CorrectAnswer { get; set; }
    public string WrongAnswer1 { get; set; }
    public string WrongAnswer2 { get; set; }
    public string WrongAnswer3 { get; set; }
    public int QuizId { get; set; }
}