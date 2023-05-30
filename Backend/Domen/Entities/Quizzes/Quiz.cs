using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using QuizApplication.Domain.Entities.Questions;
using QuizApplication.Domain.Entities.Users;

namespace QuizApplication.Domain.Entities.Quizzes;
public class Quiz
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    [JsonIgnore]
    public User User { get; set; }
    [JsonIgnore]
    public ICollection<Question> Questions { get; set; }
}