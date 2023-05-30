using Infrastructure.Repositories.Quizzes;
using QuizApplication.Application.DataTransferObjects.Quizzes;
using QuizApplication.Domain.Entities.Quizzes;

namespace QuizApplication.Application.Services.Quizzes
{
    public class QuizzesServices : IQuizzesServices
    {
        private readonly IQuizzesRepository _quizzesRepository;

        public QuizzesServices(IQuizzesRepository quizzesRepository)
        {
            _quizzesRepository = quizzesRepository;
        }

        public async Task<QuizDto> CreateAsync(QuizDto quizDto)
        {
            var quiz = await _quizzesRepository.InsertAsync(MapQuiz(quizDto));

            return MapQuiz(quiz);
        }

        public async Task<QuizDto> UpdateAsync(QuizDto quizDto)
        {
            var quiz = await _quizzesRepository.UpdateAsync(MapQuiz(quizDto));

            return MapQuiz(quiz);
        }

        public async Task<IQueryable<QuizDto>> GetAllAsync()
        {
            return _quizzesRepository.SelectAllAsync().Result.Select(x=>MapQuiz(x));
        }

        public async Task<IQueryable<QuizDto>> GetByUserIdAsync(long userId)
        {
            return _quizzesRepository.SelectByUserIdAsync(userId).Result.Select(x=>MapQuiz(x));
        }

        public async Task<QuizDto> DeleteAsync(QuizDto quiz)
        {
            var quizDto = await _quizzesRepository.DeleteAsync(quiz.id);

            return MapQuiz(quizDto);
        }

        private Quiz MapQuiz(QuizDto quizDto)
        {
            return new Quiz
            {
                Id = quizDto.id,
                Title = quizDto.title,
                UserId = quizDto.userId
            };
        }

        private QuizDto MapQuiz(Quiz quiz)
        {
            return new QuizDto(
                quiz.Id,
                quiz.Title)
            {
                userId = quiz.UserId
            };
        }
    }
}
