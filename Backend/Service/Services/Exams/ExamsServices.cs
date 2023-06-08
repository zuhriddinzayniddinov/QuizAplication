using QuizApplication.Application.DataTransferObjects.Exams;
using QuizApplication.Application.DataTransferObjects.Questions;
using QuizApplication.Domain.Entities.ExamQuestions;
using QuizApplication.Domain.Entities.Exams;
using QuizApplication.Infrastructure.Repositories.Exams;
using QuizApplication.Infrastructure.Repositories.Questions;

namespace QuizApplication.Application.Services.Exams;

public class ExamsServices : IExamsServices
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IExamRepository _examRepository;

    public ExamsServices(IQuestionRepository questionRepository, IExamRepository examRepository)
    {
        _questionRepository = questionRepository;
        _examRepository = examRepository;
    }

    public async Task<ExamDto> CreateAsync(ExamDto examDto)
    {
        return MapExam(await _examRepository.InsertAsync(MapExam(examDto)));
    }


    public async Task<ExamDto> GetByIdAsync(int examId)
    {
        return MapExam(await _examRepository.SelectByIdAsync(examId));
    }

    public async Task<bool> VerifyAsync(SentReply sentReply)
    {
        var question = await _questionRepository.SelectByIdAsync(sentReply.questionId);

        var reply = question.CorrectAnswerGuid == sentReply.answerGuid;

        var examQuestion = await _examRepository.UpdateQuestionAnswerAsync(new ExamQuestion()
        {
            ExamId = sentReply.examId,
            AnswerGuid = Guid.Parse(sentReply.answerGuid),
            QuestionId = sentReply.questionId
        },reply);

        return reply;
    }

    public Task<ExamDto> UpdateAsync(ExamDto examDto)
    {
        throw new NotImplementedException();
    }

    public IQueryable<ExamDto> GetAllAsync(int userId)
    {
        return _examRepository.SelectByUserId(userId).Select(x=>MapExam(x));
    }

    public async Task<IList<ExamQuestionDto>> GetQuestionByExamIdAsync(int examId)
    {
        var examQuestions = _examRepository.SelectExamQuestionByExamIdAsync(examId);

        var examQuestionsDto = new List<ExamQuestionDto>();

        foreach (var examQuestion in examQuestions)
        {
            var question = await _questionRepository.SelectByIdAsync(examQuestion.QuestionId);

            var answers = new AnswerDto[]
            {
                new AnswerDto(
                question.Answer1,
                     question.AnswerGuid1
                ),
                new AnswerDto( question.Answer2,
                    question.AnswerGuid2
                ),
                new AnswerDto(question.Answer3,
                    question.AnswerGuid3
                ),
                new AnswerDto(question.Answer4,
                   question.AnswerGuid4
                )
            };

            examQuestionsDto.Add(new ExamQuestionDto(
                examQuestion.QuestionId,
                question.Text,
                answers[0],
                answers[1],
                answers[2],
                answers[3],
                examQuestion.AnswerGuid.ToString(),
                examQuestion.AnswerGuid.ToString() == question.CorrectAnswerGuid));
        }

        return examQuestionsDto;
    }

    public Task<ExamDto> DeleteAsync(int examId)
    {
        throw new NotImplementedException();
    }
    private static ExamDto MapExam(Exam exam)
    {
        return new ExamDto(
            id: exam.Id,
            quizId: exam.QuizId,
            name: exam.Name,
            userId: exam.UserId,
            correctAnswers: exam.CorrectAnswers)
        {
            userId = exam.UserId
        };
    }

    private static Exam MapExam(ExamDto examDto)
    {
        return new Exam()
        {
            Id = examDto.id,
            CorrectAnswers = examDto.correctAnswers,
            QuizId = examDto.quizId,
            Name = examDto.name,
            UserId = examDto.userId
        };
    }
}