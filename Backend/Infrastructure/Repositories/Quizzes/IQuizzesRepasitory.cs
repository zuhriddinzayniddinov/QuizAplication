using QuizApplication.Domain.Entities.Quizzes;

namespace Infrastructure.Repositories.Quizzes;

public interface IQuizzesRepasitory
    {
        public Task<Quiz> InsertAsync(Quiz quiz);
        public Task<Quiz> UpdateAsync(Quiz quiz);
        public Task<Quiz> DeleteAsync(int id);
        public Task<IEnumerable<Quiz>> SelectAllAsync();
        public Task<int> SaveChangesAsync();
    }