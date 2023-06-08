using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace QuizApplication.Domain.Entities.Questions;
[NotMapped]
public class Answer
{
    [Key]
    public string Id { get; set; }
    [NotNull]
    [MinLength(1)]
    [MaxLength(100)]
    public string Text { get; set; }
}