using Infrastructure;
using Infrastructure.Repositories.Questions;
using Infrastructure.Repositories.Quizzes;
using QuizAplication.Application.Services.Questions;
using QuizAplication.Application.Services.Quizzes;

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
