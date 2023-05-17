using QuizApplication.Domain.Entities.Questions;

namespace QuizApplication.Application.Services.Questions;

public interface IQuestionsServiceis
{
    Task<Question> CreateAsync(Question question);
    Task<Question> UpdateAsync(Question question);
    Task<IEnumerable<Question>> GetAllAsync();
    Task<Question> DeleteAsync(Question question);
    Task<IEnumerable<Question>> GetByQuizIdAsync(int quizId);
}