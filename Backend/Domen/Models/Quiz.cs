using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domen.Models;
public class Quiz
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
}