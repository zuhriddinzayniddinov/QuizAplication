using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApplication.Application.DataTransferObjects.Exams;
using QuizApplication.Application.Services.Exams;

namespace QuizApplication.Api.Controllers;

[Authorize(Roles = "Worker,Maker,Admin")]
[Route("api/[controller]")]
[ApiController]
public class ExamController : ControllerBase
{
    private readonly IExamsServices _examsServices;

    public ExamController(IExamsServices examsServices)
    {
        this._examsServices = examsServices;
    }

    [HttpPost("Create")]
    public async Task<ExamDto> Create([FromBody]ExamDto examDto)
    {
        var userId = HttpContext.User.Claims
            .Where(x => x.Type == "Id")
            .Select(x =>
                int.Parse(x.Value))
            .First();

        examDto.userId = userId;

        examDto = await this._examsServices.CreateAsync(examDto);
        return examDto;
    }

    [HttpGet("{examId:int}")]
    public async Task<IList<ExamQuestionDto>> GetQuestions([FromRoute]int examId)
    {
        return await this._examsServices.GetQuestionByExamIdAsync(examId);
    }

    [HttpGet]
    public IQueryable<ExamDto> GetExams()
    {
        var userId = HttpContext.User.Claims
            .Where(x=>x.Type == "Id")
            .Select(x=>
                int.Parse(x.Value))
            .First();

        return this._examsServices.GetAllAsync(userId);
    }

    [HttpPost]
    public async Task<bool> VerifyQuestion([FromBody] SentReply sentReply)
    {
        return await this._examsServices.VerifyAsync(sentReply);
    }
}