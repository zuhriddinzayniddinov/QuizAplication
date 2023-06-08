using QuizApplication.Domain.Entities.ExamQuestions;
using QuizApplication.Domain.Entities.Exams;

namespace QuizApplication.Infrastructure.Repositories.Exams;

public interface IExamRepository
{
    Task<Exam> InsertAsync(Exam exam);
    Task<ExamQuestion> UpdateQuestionAnswerAsync(ExamQuestion examQuestion,bool reply);
    Task<Exam> UpdateAsync(Exam exam);
    Task<Exam> SelectByIdAsync(int id);
    IQueryable<ExamQuestion> SelectExamQuestionByExamIdAsync(int examId);
    Task<Exam> DeleteAsync(long id);
    IQueryable<Exam> SelectByUserId(int userId);
    Task<int> SaveChangesAsync();
}