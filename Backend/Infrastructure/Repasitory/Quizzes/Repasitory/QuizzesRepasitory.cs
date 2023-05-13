using Domen.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repasitory.Quizzes.Repasitory;

    public class QuizzesRepasitory : IQuizzesRepasitory
    {
        private readonly AppDbContext _appDbContext;

        public QuizzesRepasitory(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Quiz> CreateAsync(Quiz quiz)
        {
            await this._appDbContext.Quizzes.AddAsync(quiz);
            await this._appDbContext.SaveChangesAsync();
            return quiz;
        }

        public async Task<Quiz> UpdateAsync(Quiz quiz)
        {
            this._appDbContext.Quizzes.Entry(quiz).State = EntityState.Modified;
            await this._appDbContext.SaveChangesAsync();
            return quiz;
        }

        public Task<Quiz> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Quiz>> GetAllAsync()
        {
            return this._appDbContext.Quizzes;
        }
    }

