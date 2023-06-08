using QuizApplication.Domain.Entities.Users;

namespace QuizApplication.Infrastructure.Repositories.Users;

public interface IUserRepository
{
    
    Task<User> InsertAsync(User user);
    IQueryable<User> SelectAll();
    Task<User> SelectByIdAsync(int id);
    Task<User> UpdateAsync(User user);
    Task<User> SelectByEmailAsync(string email);
    Task<User> DeleteAsync(User user);
    Task<int> SaveChangesAsync();
}