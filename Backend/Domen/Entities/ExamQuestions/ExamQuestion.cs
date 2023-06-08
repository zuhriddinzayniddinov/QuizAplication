namespace QuizApplication.Domain.Entities.ExamQuestions;

public class ExamQuestion
{
    public int Id { get; set; }
    public int ExamId { get; set; }
    public int QuestionId { get; set; }
    public Guid? AnswerGuid { get; set; }
}