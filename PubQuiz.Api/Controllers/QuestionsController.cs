using Microsoft.AspNetCore.Mvc;
using PubQuiz.Domain;
using PubQuiz.Services.Interfaces;
using System.Net.NetworkInformation;

namespace PubQuiz.Api.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class QuestionsController : ControllerBase
    {
        private readonly ILogger<QuestionsController> _logger;
        private readonly IQuestionService _questionService;

        public QuestionsController(ILogger<QuestionsController> logger, IQuestionService questionService)
        {
            _questionService = questionService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<Question> Get(int count = 10)
        {
            try
            {
                return Ok(_questionService.GetQuestions(count));
            }
            catch (NetworkInformationException)
            {
                return BadRequest("Error retrieving data");
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Question> GetSingle(int id)
        {
            try
            {
                return Ok(_questionService.GetQuestion(id));
            }
            catch (NetworkInformationException)
            {
                return BadRequest("Error retrieving data");
            }
        }

        [HttpGet]
        [Route("rand")]
        public ActionResult<Question> GetRandom()
        {
            try
            {
                return Ok(_questionService.GetRandomQuestion());
            }
            catch (NetworkInformationException)
            {
                return BadRequest("Error retrieving data");
            }
        }
    }
}