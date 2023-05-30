using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizApplication.Domain.Entities.Questions;

namespace Infrastructure.Repositories.Questions
{
    public interface IQuestionRepository
    {
        Task<Question> InsertAsync(Question question);
        Task<Question> UpdateAsync(Question question);
        Task<Question> DeleteAsync(long id);
        IQueryable<Question> SelectAll();
        IQueryable<Question> SelectByQuizId(int quizId);
        Task<int> SaveChangesAsync();
    }
}
