using Domen.Models;

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

        public Task<Question> UpdateAsync(Question question)
        {
            throw new NotImplementedException();
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
