using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApplication.Application.Services.Questions;
using QuizApplication.Domain.Entities.Questions;

namespace QuizApplication.Controllers
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
        
        [Authorize(Roles = "Maker,Admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Question question)
        {
            question = await this._questionsServiceis.CreateAsync(question);
            return Ok(question);
        }
        
        [Authorize(Roles = "Worker,Maker,Admin")]
        [HttpGet]
        public async Task<IEnumerable<Question>> Get()
        {
            return await this._questionsServiceis.GetAllAsync();
        }
        
        [Authorize(Roles = "Worker,Maker,Admin")]
        [HttpGet("{quizId:int}")]
        public async Task<IEnumerable<Question>> Get([FromRoute]int quizId)
        {
            return await this._questionsServiceis.GetByQuizIdAsync(quizId);
        }
        
        [Authorize(Roles = "Maker,Admin")]
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put(long id, [FromBody] Question question)
        {
            if (id != question.Id)
                return BadRequest();
            question = await this._questionsServiceis.UpdateAsync(question);
            return Ok(question);
        }
    }
}
