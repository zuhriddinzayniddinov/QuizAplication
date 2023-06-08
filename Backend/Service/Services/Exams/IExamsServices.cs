using QuizApplication.Application.DataTransferObjects.Exams;
using QuizApplication.Application.DataTransferObjects.Questions;

namespace QuizApplication.Application.Services.Exams;

public interface IExamsServices
{
    Task<ExamDto> CreateAsync(ExamDto examDto);
    Task<ExamDto> GetByIdAsync(int examId);
    Task<bool> VerifyAsync(SentReply sentReply);
    Task<ExamDto> UpdateAsync(ExamDto examDto);
    IQueryable<ExamDto> GetAllAsync(int userId);
    Task<IList<ExamQuestionDto>> GetQuestionByExamIdAsync(int examId);
    Task<ExamDto> DeleteAsync(int examId);
}