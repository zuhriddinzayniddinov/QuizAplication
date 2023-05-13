using Infrastructure;
using Infrastructure.Repasitory.Questions;
using Infrastructure.Repasitory.Questions.Repository;
using Infrastructure.Repasitory.Quizzes;
using Infrastructure.Repasitory.Quizzes.Repasitory;
using Service.QuestionService;
using Service.QuestionService.Serviceis;
using Service.QuizzesService;
using Service.QuizzesService.Serviceis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IQuizzesRepasitory, QuizzesRepasitory>();
builder.Services.AddScoped<IQuestionsServiceis, QuestionsServiceis>();
builder.Services.AddScoped<IQuizzisServiceis, QuizzisServiceis>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
