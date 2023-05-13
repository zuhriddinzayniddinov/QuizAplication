using Domen.Models;
using Infrastructure.Repasitory.Questions;

namespace Service.QuestionService.Serviceis;

public class QuestionsServiceis:IQuestionsServiceis
{
    private readonly IQuestionRepository _questionRepository;
    public QuestionsServiceis(IQuestionRepository questionRepository)
    {
        this._questionRepository = questionRepository;
    }

    public async Task<Question> CreatAsync(Question question)
    {
        return await this._questionRepository.CreateAsync(question);
    }

    public async Task<Question> UpdateAsync(Question question)
    {
        return await this._questionRepository.UpdateAsync(question);
    }

    public async Task<IEnumerable<Question>> GetAllAsync()
    {
        return await this._questionRepository.GetAllAsync();
    }

    public async Task<Question> DeleteAsync(Question question)
    {
        return await this._questionRepository.DeleteAsync(question.Id);
    }

    public async Task<IEnumerable<Question>> GetByQuizIdAsync(int quizId)
    {
        return await this._questionRepository.GetByQuizIdAsync(quizId);
    }
}

