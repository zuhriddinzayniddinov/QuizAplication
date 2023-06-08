using Microsoft.EntityFrameworkCore;
using QuizApplication.Domain.Entities.Questions;
using QuizApplication.Domain.Exceptions;
using QuizApplication.Infrastructure.Contexts;

namespace QuizApplication.Infrastructure.Repositories.Questions;

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
        this._appDbContext.Questions.Entry(question).State = EntityState.Modified;

        await this.SaveChangesAsync();

        return question;
    }

    public async Task<Question> SelectByIdAsync(int id)
    {
        return await this._appDbContext.Questions.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Question> DeleteAsync(long id)
    {
        var question = await this._appDbContext.Questions
                           .Where(q => q.Id == id)
                           .FirstOrDefaultAsync()
                       ?? throw new NotFoundException("Not found question");

        this._appDbContext.Questions.Remove(question);

        await this.SaveChangesAsync();

        return question;

    }
    public IQueryable<Question> SelectAll()
    {
        var questions = this._appDbContext.Questions;

        return questions;
    }

    public  IQueryable<Question> SelectByQuizId(int quizId)
    {
        var questions = _appDbContext.Questions
            .Where(q => q.QuizId == quizId);

        return questions;
    }

    public Task<int> SaveChangesAsync()
    {
        return this._appDbContext.SaveChangesAsync();
    }
}