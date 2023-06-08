namespace QuizApplication.Application.DataTransferObjects.Exams;

public record ExamDto(
    int id,
    int userId,
    string name,
    int quizId,
    byte? correctAnswers)
{
    public int userId { get; set; }
}