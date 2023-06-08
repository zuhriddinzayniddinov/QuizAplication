using QuizApplication.Domain.Entities.Questions;

namespace QuizApplication.Infrastructure.Repositories.Questions;

public interface IQuestionRepository
{
    Task<Question> InsertAsync(Question question);
    Task<Question> UpdateAsync(Question question);
    Task<Question> SelectByIdAsync(int id);
    Task<Question> DeleteAsync(long id);
    IQueryable<Question> SelectAll();
    IQueryable<Question> SelectByQuizId(int quizId);
    Task<int> SaveChangesAsync();
}