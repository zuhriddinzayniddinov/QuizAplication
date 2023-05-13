﻿using Domen.Models;
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
