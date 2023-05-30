namespace QuizApplication.Domain.Entities.Exams;

public class Exam
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int QuizId { get; set; }
    public DateTime CreateAt { get; } = DateTime.UtcNow;
    public byte QuestionCount { get; set; } = 0;
    public byte? CorrectAnswers { get; set; }
}