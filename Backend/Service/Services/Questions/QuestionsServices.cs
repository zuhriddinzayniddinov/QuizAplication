using Infrastructure.Repositories.Questions;
using QuizApplication.Application.DataTransferObjects.Questions;
using QuizApplication.Domain.Entities.Questions;

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
        return this.MapQuestion(
            await _questionRepository
                .InsertAsync(
                    this.MapQuestion(questionDto)));
    }

    public async Task<QuestionDto> UpdateAsync(QuestionDto questionDto)
    {
        return this.MapQuestion(
            await _questionRepository
                .UpdateAsync(
                    this.MapQuestion(questionDto)));
    }

    public IQueryable<QuestionDto> GetAllAsync()
    {
        return _questionRepository
            .SelectAll()
            .Select(q=>
                this.MapQuestion(q));
    }

    public async Task<QuestionDto> DeleteAsync(QuestionDto questionDto)
    {
        return this.MapQuestion(
            await _questionRepository
                .DeleteAsync(questionDto.id));
    }

    public IQueryable<QuestionDto> GetByQuizIdAsync(int quizId)
    {
        return _questionRepository
            .SelectByQuizId(quizId)
            .Select(q =>
                this.MapQuestion(q));
    }

    private QuestionDto MapQuestion(Question question)
    {
        var answers = question.Answers.Select(a => a).ToArray();

        return new QuestionDto(
            id: question.Id,
            text: question.Text,
            quizId:question.QuizId,
            answer1: new AnswerDto(
                text: answers[0].Text,
                answerGuid: answers[0].Id.ToString()),
            answer2: new AnswerDto(
                text: answers[1].Text,
                answerGuid: answers[1].Id.ToString()),
            answer3: new AnswerDto(
                text: answers[2].Text,
                answerGuid: answers[2].Id.ToString()),
            answer4: new AnswerDto(
                text: answers[3].Text,
                answerGuid: answers[3].Id.ToString()));
    }

    private Question MapQuestion(QuestionDto questionDto)
    {
        var question = new Question
        {
            Id = questionDto.quizId,
            Text = questionDto.text,
            Answers = new Answer[]
            {
                new Answer()
                {
                    Text = questionDto.answer1.text
                },
                new Answer()
                {
                    Text = questionDto.answer2.text
                },
                new Answer()
                {
                    Text = questionDto.answer3.text
                },
                new Answer()
                {
                    Text = questionDto.answer4.text
                }
            },
            QuizId = questionDto.quizId
        };

        question.CorrectAnswerGuid = question.Answers.FirstOrDefault().Id;

        return question;
    }
}

