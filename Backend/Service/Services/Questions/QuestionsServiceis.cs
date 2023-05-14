using QuizAplication.Domain.Entities.Questions;
using Infrastructure.Repositories.Questions;

namespace QuizAplication.Application.Services.Questions;

public class QuestionsServiceis : IQuestionsServiceis
{
    private readonly IQuestionRepository _questionRepository;
    public QuestionsServiceis(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<Question> CreatAsync(Question question)
    {
        return await _questionRepository.InsertAsync(question);
    }

    public async Task<Question> UpdateAsync(Question question)
    {
        return await _questionRepository.UpdateAsync(question);
    }

    public async Task<IEnumerable<Question>> GetAllAsync()
    {
        return await _questionRepository.SelectAllAsync();
    }

    public async Task<Question> DeleteAsync(Question question)
    {
        return await _questionRepository.DeleteAsync(question.Id);
    }

    public async Task<IEnumerable<Question>> GetByQuizIdAsync(int quizId)
    {
        return await _questionRepository.SelectByQuizIdAsync(quizId);
    }
}

