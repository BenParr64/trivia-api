using PubQuiz.Domain;

namespace PubQuiz.Services.Interfaces
{
    public interface IQuestionFetchService
    {
        IEnumerable<Question> Get();
        Question Get(int questionId);
        int Count();
    }
}
