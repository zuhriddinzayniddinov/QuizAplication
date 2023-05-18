using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;
using QuizApplication.Application.Services.Quizzes;
using QuizApplication.Domain.Entities.Quizzes;

namespace QuizApplication.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzesController : ControllerBase
    {
        private readonly IQuizzisServiceis _quizzisServiceis;

        public QuizzesController(IQuizzisServiceis quizzisServiceis)
        {
            _quizzisServiceis = quizzisServiceis;
        }

        [Authorize(Roles = "Maker,Admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Quiz quiz)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            quiz = await this._quizzisServiceis.CreatAsync(quiz);
            return Ok(quiz);
        }


        [HttpGet("All")]
        public async Task<IEnumerable<Quiz>> GetAll()
        {
            return await this._quizzisServiceis.GetAllAsync();
        }

        [HttpGet]
        public async Task<IEnumerable<Quiz>> Get()
        {
            return await this._quizzisServiceis.GetAllAsync();
        }

        [Authorize(Roles= "Maker,Admin")]
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put(long id, [FromBody] Quiz quiz)
        {
            if (id != quiz.Id)
                return BadRequest();
            quiz = await this._quizzisServiceis.UpdateAsync(quiz);
            return Ok(quiz);
        }
    }
}
