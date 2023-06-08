namespace QuizApplication.Application.DataTransferObjects.Questions;

public record QuestionDto(
    int id,
    string text,
    AnswerDto answer1,
    AnswerDto answer2,
    AnswerDto answer3,
    AnswerDto answer4,
    int quizId
);

public record AnswerDto(
    string text,
    string answerGuid);