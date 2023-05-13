using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Models;

public class Question
{
    public long Id { get; set; }
    public string text { get; set; }
    public string correctAsnwer { get; set; }
    public string worngAsnwer1 { get; set; }
    public string worngAsnwer2 { get; set; }
    public string worngAsnwer3 { get; set; }
    public int QuizId { get; set; }
}