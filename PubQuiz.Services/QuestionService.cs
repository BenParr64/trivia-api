using PubQuiz.Domain;
using PubQuiz.Services.Interfaces;

namespace PubQuiz.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionFetchService _questionFetchService;

        public QuestionService(IQuestionFetchService questionFetchService)
        {
            _questionFetchService = questionFetchService;
        }

        public IEnumerable<Question> GetQuestions()
        {
            return _questionFetchService.Get();
        }
        public IEnumerable<Question> GetQuestions(int count)
        {
            return _questionFetchService.Get().Take(count);
        }

        public Question GetRandomQuestion()
        {
            var count = _questionFetchService.Count();
            var currentId = Random.Shared.Next(1, count - 1);
            return _questionFetchService.Get(currentId);
        }

        public Question GetQuestion(int questionId)
        {
            return _questionFetchService.Get(questionId);
        }
    }
}