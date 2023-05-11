using Domen.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repasitory.Questions.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly AppDbContext.AppDbContext _appDbContext;

        public QuestionRepository(AppDbContext.AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Question> CreateAsync(Question question)
        {
            await _appDbContext.Questions.AddAsync(question);
            await _appDbContext.SaveChangesAsync();
            return question;
        }

        public async Task<Question> UpdateAsync(Question question)
        {
            this._appDbContext.Questions.Entry(question).State = EntityState.Modified;
            await this._appDbContext.SaveChangesAsync();
            return question;
        }

        public Task<Question> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return _appDbContext.Questions;
        }
    }
}
