using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApplication.Domain.Entities.ExamQuestions;

public class ExamQuestion
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Exam")]
    public int ExamId { get; set; }
    [ForeignKey("Question")]
    public int QuestionId { get; set; }
    public Guid? AnswerGuid { get; set; }
}