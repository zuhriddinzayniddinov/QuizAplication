using QuizApplication.Domain.Entities.Questions;
using Microsoft.EntityFrameworkCore;
using QuizApplication.Domain.Exceptions;

namespace Infrastructure.Repositories.Questions
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly AppDbContext _appDbContext;

        public QuestionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Question> InsertAsync(Question question)
        {
            var quiz = await _appDbContext.Quizzes
                .Where(q => q.Id == question.QuizId)
                .FirstOrDefaultAsync()
                       ?? throw new NotFoundException("Not found Quiz");
            await _appDbContext.Questions.AddAsync(question);
            await this.SaveChangesAsync();
            return question;
        }

        public async Task<Question> UpdateAsync(Question question)
        {
            _appDbContext.Questions.Entry(question).State
                = EntityState.Modified;
            await this.SaveChangesAsync();
            return question;
        }

        public async Task<Question> DeleteAsync(long id)
        {
            var question = await this._appDbContext.Questions
                .Where(q => q.Id == id)
                .FirstOrDefaultAsync()
                           ?? throw new NotFoundException("Not found question");
            this._appDbContext.Questions.Remove(question);
            return question;

        }
        public async Task<IEnumerable<Question>> SelectAllAsync()
        {
            return _appDbContext.Questions;
        }

        public async Task<IEnumerable<Question>> SelectByQuizIdAsync(int quizId)
        {
            return await _appDbContext.Questions
                .Where(q => q.QuizId == quizId)
                .ToListAsync();
        }

        public Task<int> SaveChangesAsync()
        {
            return this._appDbContext.SaveChangesAsync();
        }
    }
}
