using QuizApplication.Domain.Entities.Quizzes;

namespace QuizApplication.Infrastructure.Repositories.Quizzes;

public interface IQuizzesRepository
{
    Task<Quiz> InsertAsync(Quiz quiz);
    Task<Quiz> UpdateAsync(Quiz quiz);
    Task<Quiz> DeleteAsync(int id);
    Task<IQueryable<Quiz>> SelectAllAsync();
    Task<int> SaveChangesAsync();
    Task<IQueryable<Quiz>> SelectByUserIdAsync(long userId);
}