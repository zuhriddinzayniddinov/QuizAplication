using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen.Models;

namespace Infrastructure.Repasitory.Questions
{
    public interface IQuestionRepository
    {
        public Task<Question> CreateAsync(Question question);
        public Task<Question> UpdateAsync(Question question);
        public Task<Question> DeleteAsync(long id);
        public Task<IEnumerable<Question>> GetAllAsync();


    }
}
