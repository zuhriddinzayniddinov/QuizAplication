using Domen.Models;

namespace Service.QuestionService;

public interface IQuestionsServiceis
{
    Task<Question> CreatAsync(Question question);
    Task<Question> UpdateAsync(Question question);
    Task<IEnumerable<Question>> GetAllAsync();
    Task<Question> DeleteAsync(Question question);
    Task<IEnumerable<Question>> GetByQuizIdAsync(int quizId);
}