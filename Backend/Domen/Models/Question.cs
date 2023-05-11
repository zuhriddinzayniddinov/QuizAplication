using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Models
{
    public class Question
    {
        public long Id { get; set; }
        public string text { get; set; }
        public string correctAsnwer { get; set; }
        [NotMapped]
        public List<string> worngAsnwers { get; set; }
        public string stringworngAsnwers { get; set; }
    }
}
