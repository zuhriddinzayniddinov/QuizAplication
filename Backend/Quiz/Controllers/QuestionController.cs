using Microsoft.AspNetCore.Mvc;
using QuizAplication.Application.Services.Questions;
using QuizAplication.Domain.Entities.Questions;

namespace QuizAplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionsServiceis _questionsServiceis;

        public QuestionController(IQuestionsServiceis questionsServiceis)
        {
            this._questionsServiceis = questionsServiceis;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Question question)
        {
            question = await this._questionsServiceis.CreatAsync(question);
            return Ok(question);
        }

        [HttpGet]
        public async Task<IEnumerable<Question>> Get()
        {
            return await this._questionsServiceis.GetAllAsync();
        }
        [HttpGet("{quizId}")]
        public async Task<IEnumerable<Question>> Get([FromRoute]int quizId)
        {
            return await this._questionsServiceis.GetByQuizIdAsync(quizId);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Question question)
        {
            if (id != question.Id)
                return BadRequest();
            question = await this._questionsServiceis.UpdateAsync(question);
            return Ok(question);
        }
    }
}
