using QuizApplication.Application.DataTransferObjects.Questions;

namespace QuizApplication.Application.DataTransferObjects.Exams;

public record ExamQuestionDto(
    int id,
    string text,
    AnswerDto answer1,
    AnswerDto answer2,
    AnswerDto answer3,
    AnswerDto answer4,
    string answerGuid,
    bool answer
);