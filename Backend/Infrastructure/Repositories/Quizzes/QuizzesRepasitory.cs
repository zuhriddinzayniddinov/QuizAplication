using QuizApplication.Domain.Entities.Quizzes;
using Microsoft.EntityFrameworkCore;
using QuizApplication.Domain.Exceptions;

namespace Infrastructure.Repositories.Quizzes;

public class QuizzesRepasitory : IQuizzesRepasitory
{
    private readonly AppDbContext _appDbContext;

    public QuizzesRepasitory(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Quiz> InsertAsync(Quiz quiz)
    {
        await _appDbContext.Quizzes.AddAsync(quiz);
        await _appDbContext.SaveChangesAsync();
        return quiz;
    }

    public async Task<Quiz> UpdateAsync(Quiz quiz)
    {
        _appDbContext.Quizzes.Entry(quiz).State
            = EntityState.Modified;
        await this.SaveChangesAsync();
        return quiz;
    }

    public async Task<Quiz> DeleteAsync(int id)
    {
        var quiz = await this._appDbContext.Quizzes
                       .Where(q => q.Id == id)
                       .FirstOrDefaultAsync()
                   ?? throw new NotFoundException("Not found quiz");
        await this.SaveChangesAsync();
        return quiz;
    }

    public async Task<IEnumerable<Quiz>> SelectAllAsync()
    {
        return _appDbContext.Quizzes;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await this._appDbContext.SaveChangesAsync();
    }
}

