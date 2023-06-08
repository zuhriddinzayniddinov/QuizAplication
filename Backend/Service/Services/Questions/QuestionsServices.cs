using QuizApplication.Application.DataTransferObjects.Questions;
using QuizApplication.Domain.Entities.Questions;
using QuizApplication.Infrastructure.Repositories.Questions;

namespace QuizApplication.Application.Services.Questions;

public class QuestionsServices : IQuestionsServices
{
    private readonly IQuestionRepository _questionRepository;
    public QuestionsServices(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<QuestionDto> CreateAsync(QuestionDto questionDto)
    {
        return MapQuestion(
            await _questionRepository
                .InsertAsync(
                    this.MapQuestion(questionDto)));
    }

    public async Task<QuestionDto> UpdateAsync(QuestionDto questionDto)
    {
        return MapQuestion(
            await _questionRepository
                .UpdateAsync(
                    this.MapQuestion(questionDto)));
    }

    public IQueryable<QuestionDto> GetAllAsync()
    {
        return _questionRepository
            .SelectAll()
            .Select(q=>
                MapQuestion(q));
    }

    public async Task<QuestionDto> DeleteAsync(QuestionDto questionDto)
    {
        return MapQuestion(
            await _questionRepository
                .DeleteAsync(questionDto.id));
    }

    public IQueryable<QuestionDto> GetByQuizIdAsync(int quizId)
    {
        return _questionRepository
            .SelectByQuizId(quizId)
            .Select(q =>
                MapQuestion(q));
    }

    public static QuestionDto MapQuestion(Question question)
    {
        var answers = new Answer[]
        {
            new Answer()
            {
                Text = question.Answer1,
                Id = question.AnswerGuid1
            },
            new Answer()
            {
                Text = question.Answer2,
                Id = question.AnswerGuid2
            },
            new Answer()
            {
                Text = question.Answer3,
                Id = question.AnswerGuid3
            },
            new Answer()
            {
                Text = question.Answer4,
                Id = question.AnswerGuid4
            }
        };

        // massivni aralashtirish logikasi

        return new QuestionDto(
            id: question.Id,
            text: question.Text,
            quizId:question.QuizId,
            answer1: new AnswerDto(
                text: answers[0].Text,
                answerGuid: answers[0].Id),
            answer2: new AnswerDto(
                text: answers[1].Text,
                answerGuid: answers[1].Id),
            answer3: new AnswerDto(
                text: answers[2].Text,
                answerGuid: answers[2].Id),
            answer4: new AnswerDto(
                text: answers[3].Text,
                answerGuid: answers[3].Id));
    }

    private Question MapQuestion(QuestionDto questionDto)
    {
        var question = new Question
        {
            Text = questionDto.text,
            Answer1 = questionDto.answer1.text,
            Answer2 = questionDto.answer2.text,
            Answer3 = questionDto.answer3.text,
            Answer4 = questionDto.answer4.text,
            QuizId = questionDto.quizId
        };

        if (questionDto.id != 0)
        {
            question.Id = questionDto.id;
        }

        question.CorrectAnswerGuid = question.AnswerGuid1;

        return question;
    }
}

