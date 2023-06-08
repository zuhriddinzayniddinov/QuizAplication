namespace QuizApplication.Application.DataTransferObjects.Exams;

public record SentReply(
    int id,
    int examId,
    int questionId,
    string answerGuid);