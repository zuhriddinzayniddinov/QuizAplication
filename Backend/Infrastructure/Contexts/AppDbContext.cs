using QuizApplication.Domain.Entities.Questions;
using QuizApplication.Domain.Entities.Quizzes;
using Microsoft.EntityFrameworkCore;
using QuizApplication.Domain.Entities.Users;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
