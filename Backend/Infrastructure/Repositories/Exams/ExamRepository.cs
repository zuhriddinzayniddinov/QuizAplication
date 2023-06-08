using Microsoft.EntityFrameworkCore;
using QuizApplication.Domain.Entities.ExamQuestions;
using QuizApplication.Domain.Entities.Exams;
using QuizApplication.Domain.Exceptions;
using QuizApplication.Infrastructure.Contexts;

namespace QuizApplication.Infrastructure.Repositories.Exams;

public class ExamRepository : IExamRepository
{
    private readonly AppDbContext _appDbContext;

    public ExamRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Exam> InsertAsync(Exam exam)
    {
        await this._appDbContext.Exams.AddAsync(exam);

        await SaveChangesAsync();

        var questionIds = this._appDbContext.Questions.Where(q => q.QuizId == exam.QuizId).Select(q => q.Id);

        var temp = new List<ExamQuestion>
        {
            Capacity = 30
        };

        int count = 0;

        foreach (var question in questionIds)
        {
            temp.Add(new ExamQuestion
            {
                ExamId = exam.Id,
                QuestionId = question
            });

            if (++count >= 30)
                break;
        }

        foreach (var tem in temp)
        {
            await _appDbContext.ExamQuestions.AddAsync(tem);
        }

        await SaveChangesAsync();

        return exam;
    }

    public async Task<ExamQuestion> UpdateQuestionAnswerAsync(ExamQuestion examQuestion,bool reply)
    {
        var examQuestionTemp = await this._appDbContext.ExamQuestions
            .Where(q => q.QuestionId == examQuestion.QuestionId && q.ExamId == examQuestion.ExamId)
            .FirstOrDefaultAsync() ?? throw new NotFoundException("Not Found exam question");

        if (reply)
        {
            var exam = await _appDbContext.Exams.Where(x => x.Id == examQuestion.ExamId).Select(x => x).FirstOrDefaultAsync();
            exam.CorrectAnswers++;
        }

        examQuestionTemp.AnswerGuid = examQuestion.AnswerGuid;

        await this.SaveChangesAsync();

        return examQuestion;
    }

    public Task<Exam> UpdateAsync(Exam exam)
    {
        throw new NotImplementedException();
    }

    public async Task<Exam> SelectByIdAsync(int id)
    {
        return await _appDbContext.Exams.Where(e => e.Id == id).Select(x => x).FirstOrDefaultAsync();
    }

    public IQueryable<ExamQuestion> SelectExamQuestionByExamIdAsync(int examId)
    {
        return _appDbContext.ExamQuestions.Where(eq => eq.ExamId == examId).Select(x=>x);
    }

    public Task<Exam> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Exam> SelectByUserId(int userId)
    {
        return _appDbContext.Exams.Where(e => e.UserId == userId).Select(x => x);
    }

    public Task<int> SaveChangesAsync()
    {
        return _appDbContext.SaveChangesAsync();
    }
}