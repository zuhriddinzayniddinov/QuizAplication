using Domen.Models;

namespace Infrastructure.Repasitory.Quizzes;

    public interface IQuizzesRepasitory
    {
        public Task<Quiz> CreateAsync(Quiz quiz);
        public Task<Quiz> UpdateAsync(Quiz quiz);
        public Task<Quiz> DeleteAsync(int id);
        public Task<IEnumerable<Quiz>> GetAllAsync();
}