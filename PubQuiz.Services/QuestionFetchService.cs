using AutoMapper;
using PubQuiz.Domain;
using PubQuiz.Services.Interfaces;

namespace PubQuiz.Services
{
    public class QuestionFetchService : IQuestionFetchService
    {
        private readonly IMongoConnectionService _mongoConnectionService;
        private readonly IMapper _mapper;

        public QuestionFetchService(IMongoConnectionService mongoConnectionService, IMapper mapper)
        {
            _mongoConnectionService = mongoConnectionService;
            _mapper = mapper;
        }
        public IEnumerable<Question> Get()
        {
            return _mapper.Map<IEnumerable<Question>>(FetchQuestions());
        }

        public Question Get(int questionId)
        {
            var question = FetchQuestions()
                .FirstOrDefault(question => question.QuestionId == questionId);

            if (question == null) throw new KeyNotFoundException();

            return _mapper.Map<Question>(question);
        }

        public int Count()
        {
            return FetchQuestions().Count();
        }

        private IQueryable<QuestionDto> FetchQuestions()
        {
            return _mongoConnectionService.FetchCollection<QuestionDto>("PubQuiz", "Trivia");
        }

    }

    
}