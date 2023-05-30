namespace QuizApplication.Application.DataTransferObjects.Quizzes;

public record QuizDto(
    int id,
    string title
    )
{
    public int userId { get; set; }
}