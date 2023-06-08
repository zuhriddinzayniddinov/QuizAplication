using QuizApplication.Application.DataTransferObjects.Questions;

namespace QuizApplication.Application.Services.Questions;

public interface IQuestionsServices
{
    Task<QuestionDto> CreateAsync(QuestionDto questionnDto);
    Task<QuestionDto> UpdateAsync(QuestionDto questionDto);
    IQueryable<QuestionDto> GetAllAsync();
    Task<QuestionDto> DeleteAsync(QuestionDto questionDto);
    IQueryable<QuestionDto> GetByQuizIdAsync(int quizId);
}