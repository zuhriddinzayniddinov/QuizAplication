using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using QuizApplication.Domain.Entities.Quizzes;
using QuizApplication.Domain.Enums;

namespace QuizApplication.Domain.Entities.Users;

public class User
{
    [Key]
    public int Id { get; set; }
    [MinLength(3)]
    [MaxLength(20)]
    public string Name { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    public string Salt { get; set; }
    public bool Confirmed { get; set; } = true;
    public string PasswordHash { get; set; }
    public UserRole Role { get; set; } = UserRole.User;
    [JsonIgnore]
    public ICollection<Quiz> Quizs { get; set; }
}

