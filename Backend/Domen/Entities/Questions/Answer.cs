using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApplication.Domain.Entities.Questions;
[NotMapped]
public class Answer
{
    public string Id { get; set; }
    public string Text { get; set; }
}