using Domen.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Quiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        [HttpPost]
        public void Post([FromBody] Question question)
        {

        }
    }
}
