using Microsoft.EntityFrameworkCore;
using QuizApplication.Domain.Entities.ExamQuestions;
using QuizApplication.Domain.Entities.Exams;
using QuizApplication.Domain.Entities.Questions;
using QuizApplication.Domain.Entities.Quizzes;
using QuizApplication.Domain.Entities.Users;

namespace QuizApplication.Infrastructure.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<ExamQuestion> ExamQuestions { get; set; }
    public DbSet<User> Users { get; set; }
}