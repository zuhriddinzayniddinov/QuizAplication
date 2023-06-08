using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using QuizApplication.Domain.Entities.Quizzes;

namespace QuizApplication.Domain.Entities.Questions;

public class Question
{
    [Key]
    public int Id { get; set; }
    [MinLength(5)]
    [MaxLength(150)]
    public string Text { get; set; }
    public string CorrectAnswerGuid { get; set; }
    public string Answer1 { get; set; }
    public string AnswerGuid1 { get; set; } = Guid.NewGuid().ToString();
    public string Answer2 { get; set; }
    public string AnswerGuid2 { get; set; } = Guid.NewGuid().ToString();
    public string Answer3 { get; set; }
    public string AnswerGuid3 { get; set; } = Guid.NewGuid().ToString();
    public string Answer4 { get; set; }
    public string AnswerGuid4 { get; set; } = Guid.NewGuid().ToString();
    [Required]
    [ForeignKey("Quiz")]
    public int QuizId { get; set; }
    [JsonIgnore]
    public Quiz Quiz { get; set; }
}