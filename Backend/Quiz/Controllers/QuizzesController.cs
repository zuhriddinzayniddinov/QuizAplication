using Microsoft.AspNetCore.Mvc;
using QuizAplication.Application.Services.Quizzes;
using QuizAplication.Domain.Entities.Quizzes;

namespace QuizAplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzesController : ControllerBase
    {
        private readonly IQuizzisServiceis _quizzisServiceis;

        public QuizzesController(IQuizzisServiceis quizzisServiceis)
        {
            _quizzisServiceis = quizzisServiceis;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Quiz quiz)
        {
            quiz = await this._quizzisServiceis.CreatAsync(quiz);
            return Ok(quiz);
        }

        [HttpGet]
        public async Task<IEnumerable<Quiz>> Get()
        {
            return await this._quizzisServiceis.GetAllAsync();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Quiz quiz)
        {
            if (id != quiz.Id)
                return BadRequest();
            quiz = await this._quizzisServiceis.UpdateAsync(quiz);
            return Ok(quiz);
        }
    }
}
