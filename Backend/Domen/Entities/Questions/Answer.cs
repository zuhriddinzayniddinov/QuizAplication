using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace QuizApplication.Domain.Entities.Questions;

public class Answer
{
    [Key]
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    [Required]
    [ForeignKey(nameof(Questions.Question))]
    public int QuestionId { get; set; }
    [MinLength(1)]
    [MaxLength(30)]
    public string Text { get; set; }
    [JsonIgnore]
    public Question Question { get; set; }
}