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
        Task<Question> CreateAsync(Question question);
        Task<Question> UpdateAsync(Question question);
        Task<Question> DeleteAsync(long id);
        Task<IEnumerable<Question>> GetAllAsync();
        Task<IEnumerable<Question>> GetByQuizIdAsync(int quizId);
    }
}
