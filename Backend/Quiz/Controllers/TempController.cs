using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuizApplication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("Everyone")]
        public string GetEveryone()
        {
            return "Everyone";
        }
        
        [Authorize(Roles = "User")]
        [HttpGet("User")]
        public string GetUser()
        {
            return "User";
        }
        
        [Authorize(Roles = "Worker")]
        [HttpGet("Worker")]
        public string GetWorker()
        {
            return "Worker";
        }
        
        [Authorize(Roles = "Maker")]
        [HttpGet("Maker")]
        public string GetMaker()
        {
            return "Maker";
        }
        
        [Authorize(Roles = "Admin")]
        [HttpGet("Admin")]
        public string GetAdmin()
        {
            return "Admin";
        }
    }
}
