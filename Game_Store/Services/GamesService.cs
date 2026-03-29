using Game_Store.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Game_Store.Services
{
    public class GamesService
    {
        private readonly IMongoCollection<Game> _gamesCollection;

        public GamesService(IOptions<GameStoreDatabaseSettings> gameStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(gameStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(gameStoreDatabaseSettings.Value.DatabaseName);

            _gamesCollection = mongoDatabase.GetCollection<Game>(gameStoreDatabaseSettings.Value.BooksCollectionName);
        }

        public async Task<List<Game>> GetAsync() =>
        await _gamesCollection.Find(_ => true).ToListAsync();

        public async Task<Game?> GetAsync(string id) =>
        await _gamesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Game newBook) =>
        await _gamesCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, Game updatedBook) =>
        await _gamesCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
        await _gamesCollection.DeleteOneAsync(x => x.Id == id);
    }
}
