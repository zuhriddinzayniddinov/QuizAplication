using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApplication.Application.DataTransferObjects.Questions;
using QuizApplication.Application.Services.Questions;

namespace QuizApplication.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionsServices _questionsServices;

        public QuestionController(IQuestionsServices questionsServices)
        {
            this._questionsServices = questionsServices;
        }

        [Authorize(Roles = "Maker,Admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] QuestionDto questionDto)
        {
            questionDto = await this._questionsServices.CreateAsync(questionDto);

            return Ok(questionDto);
        }

        [Authorize(Roles = "Worker,Maker,Admin")]
        [HttpGet]
        public IQueryable<QuestionDto> Get()
        {
            return this._questionsServices.GetAllAsync();
        }

        [Authorize(Roles = "Worker,Maker,Admin")]
        [HttpGet("{quizId:int}")]
        public IQueryable<QuestionDto> Get([FromRoute]int quizId)
        {
            return this._questionsServices.GetByQuizIdAsync(quizId);
        }

        [Authorize(Roles = "Maker,Admin")]
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put(long id, [FromBody] QuestionDto questionDto)
        {
            if (id != questionDto.id)
                return BadRequest();
            questionDto = await this._questionsServices.UpdateAsync(questionDto);
            return Ok(questionDto);
        }
    }
}
