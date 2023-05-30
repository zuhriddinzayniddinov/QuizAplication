using QuizApplication.Application.DataTransferObjects.Quizzes;

namespace QuizApplication.Application.Services.Quizzes
{
    public interface IQuizzesServices
    {
        Task<QuizDto> CreateAsync(QuizDto quizDto);
        Task<QuizDto> UpdateAsync(QuizDto quizDto);
        Task<IQueryable<QuizDto>> GetAllAsync();
        Task<IQueryable<QuizDto>> GetByUserIdAsync(long userId);
        Task<QuizDto> DeleteAsync(QuizDto quizDto);
    }
}
