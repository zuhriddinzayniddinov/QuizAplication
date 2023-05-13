using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Models;

public class Question
{
    [Key]
    public long Id { get; set; }
    [Required]
    public string Text { get; set; }
    [Required]
    public string CorrectAsnwer { get; set; }
    [Required]
    public string WorngAsnwer1 { get; set; }
    [Required]
    public string WorngAsnwer2 { get; set; }
    [Required]
    public string WorngAsnwer3 { get; set; }
    
    public int QuizId { get; set; }
}