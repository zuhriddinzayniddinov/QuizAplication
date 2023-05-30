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

            foreach (var answer in question.Answers)
            {
                await this._appDbContext.Answers.AddAsync(answer);
            }

            await _appDbContext.Questions.AddAsync(question);
            await this.SaveChangesAsync();
            return question;
        }

        public async Task<Question> UpdateAsync(Question question)
        {
            this._appDbContext.Questions.Entry(question).State = EntityState.Modified;

            List<Answer> answers = new();

            foreach (var answer in question.Answers)
            {
                answers.Add(answer);
                this._appDbContext.Answers.Entry(answer).State = EntityState.Modified;
            }

            await this.SaveChangesAsync();

            return question;
        }

        public async Task<Question> DeleteAsync(long id)
        {
            var question = await this._appDbContext.Questions
                .Where(q => q.Id == id)
                .FirstOrDefaultAsync()
                           ?? throw new NotFoundException("Not found question");

            foreach (var answer in question.Answers)
            {
                this._appDbContext.Answers.Remove(answer);
            }

            this._appDbContext.Questions.Remove(question);

            await this.SaveChangesAsync();

            return question;

        }
        public IQueryable<Question> SelectAll()
        {
            var questions = this._appDbContext.Questions;

            foreach (var question in questions)
            {
                question.Answers = this._appDbContext.Answers
                    .Where(a => a.QuestionId == question.Id)
                    .Select(a => a).ToList();
            }
            
            return questions;
        }

        public  IQueryable<Question> SelectByQuizId(int quizId)
        {
            var questions = _appDbContext.Questions
                .Where(q => q.QuizId == quizId);

            foreach (var question in questions)
            {
                question.Answers = this._appDbContext.Answers
                    .Where(a => a.QuestionId == question.Id)
                    .Select(a => a).ToList();
            }

            return questions;
        }

        public Task<int> SaveChangesAsync()
        {
            return this._appDbContext.SaveChangesAsync();
        }
    }
}
