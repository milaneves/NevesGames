using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NevesGames.InfraData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NevesGames.Application.Services
{
    public class GamesServices
    {

        private readonly IMongoCollection<Games> _GamesCollection;

        public GamesServices(
            IOptions<MongoDbSettings> mongoDbSettings)
        {
            var mongoClient = new MongoClient(
                mongoDbSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                mongoDbSettings.Value.DatabaseName);

            _GamesCollection = mongoDatabase.GetCollection<Games>(
                mongoDbSettings.Value.CollectionName);
        }

        public async Task<List<Games>> GetAsync() =>
            await _GamesCollection.Find(_ => true).ToListAsync();

        public async Task<Games?> GetAsync(string id) =>
            await _GamesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Games newGames) =>
            await _GamesCollection.InsertOneAsync(newGames);

        public async Task UpdateAsync(string id, Games updatedGames) =>
            await _GamesCollection.ReplaceOneAsync(x => x.Id == id, updatedGames);

        public async Task RemoveAsync(string id) =>
            await _GamesCollection.DeleteOneAsync(x => x.Id == id);
    }
}
