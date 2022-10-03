using PubQuiz.Domain;

namespace PubQuiz.Services.Interfaces
{
    public interface IMongoConnectionService
    {
        IQueryable<T> FetchCollection<T>(string databaseName, string collectionName);
    }
}
