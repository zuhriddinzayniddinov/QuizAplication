using Infrastructure;
using Microsoft.EntityFrameworkCore;
using QuizApplication.Domain.Entities.Users;
using QuizApplication.Domain.Exceptions;

namespace QuizApplication.Infrastructure.Repositories.Users;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _appDbContext;

    public UserRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<User> InsertAsync(User user)
    {
        await this._appDbContext.Users.AddAsync(user);
        await this.SaveChangesAsync();
        return user;
    }

    public IQueryable<User> SelectAll()
    {
        return this._appDbContext.Users;
    }

    public async Task<User> SelectByIdAsync(int id)
    {
        return await this._appDbContext
            .Users.Where(u => u.Id == id)
            .FirstOrDefaultAsync()
            ?? throw new NotFoundException("User not found");
    }

    public async Task<User> UpdateAsync(User user)
    {
        var entityEntry = this._appDbContext
            .Update<User>(user);

        await this.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async Task<User> SelectByEmailAsync(string email)
    {
        var user = await this._appDbContext
            .Users.Where(u => u.Email == email)
            .FirstOrDefaultAsync()
            ?? throw new NotFoundException("User not found");

        return user;
    }

    public Task<User> DeleteAsync(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await this._appDbContext
            .SaveChangesAsync();
    }
}