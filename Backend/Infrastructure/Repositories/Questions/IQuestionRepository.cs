using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizAplication.Domain.Entities.Questions;

namespace Infrastructure.Repositories.Questions
{
    public interface IQuestionRepository
    {
        Task<Question> InsertAsync(Question question);
        Task<Question> UpdateAsync(Question question);
        Task<Question> DeleteAsync(long id);
        Task<IEnumerable<Question>> SelectAllAsync();
        Task<IEnumerable<Question>> SelectByQuizIdAsync(int quizId);
        Task<int> SaveChangesAsync();
    }
}
