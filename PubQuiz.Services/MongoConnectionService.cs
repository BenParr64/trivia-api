using MongoDB.Driver;
using PubQuiz.Services.Interfaces;
using System.Net.NetworkInformation;

namespace PubQuiz.Services
{
    public class MongoConnectionService : IMongoConnectionService
    {
        public IQueryable<T> FetchCollection<T>(string databaseName, string collectionName)
        {
            try
            {
                MongoClient dbClient =
                    new MongoClient("mongodb+srv://benparr:benparr@questions.57vy7ri.mongodb.net/test");

                var database = dbClient.GetDatabase(databaseName);
                var collection = database.GetCollection<T>(collectionName);
                return collection.AsQueryable();
            }
            catch (Exception)
            {
                throw new NetworkInformationException();
            }
            
        }

        

    }
}