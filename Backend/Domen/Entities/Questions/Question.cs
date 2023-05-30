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
    public Guid CorrectAnswerGuid { get; set; }
    [Required]
    [ForeignKey("Quiz")]
    public int QuizId { get; set; }
    public virtual ICollection<Answer> Answers { get; set; }
/*    [JsonIgnore]
    [Timestamp]
    public byte[] Timestamp { get; set; }*/
    [JsonIgnore]
    public Quiz Quiz { get; set; }
}