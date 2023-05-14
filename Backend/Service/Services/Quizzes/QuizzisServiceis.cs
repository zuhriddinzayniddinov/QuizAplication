using QuizAplication.Domain.Entities.Quizzes;
using Infrastructure.Repositories.Quizzes;

namespace QuizAplication.Application.Services.Quizzes
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
            return await _quizzesRepasitory.InsertAsync(quiz);
        }

        public async Task<Quiz> UpdateAsync(Quiz quiz)
        {
            return await _quizzesRepasitory.UpdateAsync(quiz);
        }

        public async Task<IEnumerable<Quiz>> GetAllAsync()
        {
            return await _quizzesRepasitory.SelectAllAsync();
        }

        public async Task<Quiz> DeleteAsync(Quiz quiz)
        {
            return await _quizzesRepasitory.DeleteAsync(quiz.Id);
        }
    }
}
