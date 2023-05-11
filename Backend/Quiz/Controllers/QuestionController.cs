using Domen.Models;
using Infrastructure.AppDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.QuestionService;

namespace Quiz.Controllers
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
        public async Task Post([FromBody] Question question)
        {
            await this._questionsServiceis.CreatAsync(question);
        }

        [HttpGet]
        public async Task<IEnumerable<Question>> Get()
        {
            return await this._questionsServiceis.GetAllAsync();
        }
    }
}
