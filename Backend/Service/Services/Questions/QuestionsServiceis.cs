using Infrastructure.Repositories.Questions;
using QuizApplication.Domain.Entities.Questions;

namespace QuizApplication.Application.Services.Questions;

public class QuestionsServiceis : IQuestionsServiceis
{
    private readonly IQuestionRepository _questionRepository;
    public QuestionsServiceis(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<Question> CreateAsync(Question question)
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

