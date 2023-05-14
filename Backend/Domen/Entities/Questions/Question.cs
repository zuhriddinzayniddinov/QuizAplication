namespace QuizAplication.Domain.Entities.Questions;

public class Question
{
    public long Id { get; set; }
    public string Text { get; set; }
    public string CorrectAsnwer { get; set; }
    public string WorngAsnwer1 { get; set; }
    public string WorngAsnwer2 { get; set; }
    public string WorngAsnwer3 { get; set; }
    public int QuizId { get; set; }
}