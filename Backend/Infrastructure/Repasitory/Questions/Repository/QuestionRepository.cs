using Domen.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repasitory.Questions.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly AppDbContext _appDbContext;

        public QuestionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Question> CreateAsync(Question question)
        {
            var quiz = await _appDbContext.Quizzes
                .Where(q => q.Id == question.QuizId)
                .FirstOrDefaultAsync();
            if (quiz == null)
            {
                throw new AccessViolationException("Not found Quiz");
            }
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

        public async Task<IEnumerable<Question>> GetByQuizIdAsync(int quizId)
        {
            return await _appDbContext.Questions.Where(q=>q.QuizId == quizId).ToListAsync();
        }
    }
}
