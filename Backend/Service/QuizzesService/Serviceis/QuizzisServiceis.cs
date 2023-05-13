using Domen.Models;
using Infrastructure.Repasitory.Quizzes;

namespace Service.QuizzesService.Serviceis
{
    public class QuizzisServiceis : IQuizzisServiceis
    {
        private readonly IQuizzesRepasitory _quizzesRepasitory;

        public QuizzisServiceis(IQuizzesRepasitory quizzesRepasitory)
        {
            _quizzesRepasitory = quizzesRepasitory;
        }

        public async Task<Quiz> CreatAsync(Quiz quiz)
        {
            return await this._quizzesRepasitory.CreateAsync(quiz);
        }

        public async Task<Quiz> UpdateAsync(Quiz quiz)
        {
            return await this._quizzesRepasitory.UpdateAsync(quiz);
        }

        public async Task<IEnumerable<Quiz>> GetAllAsync()
        {
            return await this._quizzesRepasitory.GetAllAsync();
        }

        public async Task<Quiz> DeleteAsync(Quiz quiz)
        {
            return await this._quizzesRepasitory.DeleteAsync(quiz.Id);
        }
    }
}
