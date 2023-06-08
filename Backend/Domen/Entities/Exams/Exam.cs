using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace QuizApplication.Domain.Entities.Exams;

public class Exam
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    [NotNull]
    [MinLength(2)]
    [MaxLength(15)]
    public string Name { get; set; }
    [ForeignKey("Quiz")]
    public int QuizId { get; set; }
    public DateTime CreateAt { get; } = DateTime.UtcNow;
    public byte? CorrectAnswers { get; set; }
}