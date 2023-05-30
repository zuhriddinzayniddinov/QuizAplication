using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApplication.Application.DataTransferObjects.Quizzes;
using QuizApplication.Application.Services.Quizzes;
using QuizApplication.Domain.Entities.Quizzes;

namespace QuizApplication.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzesController : ControllerBase
    {
        private readonly IQuizzesServices _quizzesServices;

        public QuizzesController(IQuizzesServices quizzesServices)
        {
            _quizzesServices = quizzesServices;
        }

        [Authorize(Roles = "Maker,Admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] QuizDto quizDto)
        {
            var userId = HttpContext
                                .User
                                .Claims
                                .Where(c =>
                                    c.Type == "Id")
                                .Select(c =>
                                    int.Parse(c.Value))
                                .First();

            quizDto.userId = userId;

            quizDto = await this._quizzesServices.CreateAsync(quizDto);

            return Ok(quizDto);
        }

        [HttpGet("All")]
        public async Task<IQueryable<QuizDto>> GetAll()
        {
            return await this._quizzesServices.GetAllAsync();
        }

        [Authorize(Roles = "Maker,Admin")]
        [HttpGet]
        public async Task<IEnumerable<QuizDto>> Get()
        {
            var userId = HttpContext
                                .User
                                .Claims
                                .Where(c =>
                                    c.Type == "Id")
                                .Select(c =>
                                    int.Parse(c.Value))
                                .First();

            return await this._quizzesServices.GetByUserIdAsync(userId);
        }

        [Authorize(Roles= "Maker,Admin")]
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put(long id, [FromBody]QuizDto quizDto)
        {
            if (id != quizDto.id)
                return BadRequest();
            quizDto = await this._quizzesServices.UpdateAsync(quizDto);
            return Ok(quizDto);
        }
    }
}
