using Domen.Models;

namespace Service.QuizzesService
{
    public interface IQuizzisServiceis
    {
        Task<Quiz> CreatAsync(Quiz quiz);
        Task<Quiz> UpdateAsync(Quiz quiz);
        Task<IEnumerable<Quiz>> GetAllAsync();
        Task<Quiz> DeleteAsync(Quiz quiz);
    }
}
