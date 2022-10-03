using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PubQuiz.Domain
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Prompt { get; set; }
        public string Answer { get; set; }
    }

    public class QuestionDto
    {
        public ObjectId Id { get; set; }
        [BsonElement("questionId")]
        public int QuestionId { get; set; }
        [BsonElement("prompt")]
        public string Prompt { get; set; }
        [BsonElement("answer")]
        public string Answer { get; set; }
    }
}