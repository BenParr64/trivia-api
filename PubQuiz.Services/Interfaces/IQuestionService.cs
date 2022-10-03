using PubQuiz.Domain;

namespace PubQuiz.Services.Interfaces
{
    public interface IQuestionService
    {
        IEnumerable<Question> GetQuestions();
        Question GetQuestion(int questionId);
        Question GetRandomQuestion();
        IEnumerable<Question> GetQuestions(int count);
    }
}
