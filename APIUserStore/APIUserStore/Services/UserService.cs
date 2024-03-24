    using APIUserStore.Models;
    using MongoDB.Driver;
    using Microsoft.Extensions.Options;

    namespace APIUserStore.Services
    {
        public class UserService
        {
            private readonly IMongoCollection<User> _userCollection;
            public UserService(
                IOptions<UserStoreDataBaseSettings> UserStoreDataBaseSettings)
            {
                var mongoclient = new MongoClient(
                    UserStoreDataBaseSettings.Value.ConnectionString);
                var mongoDatabase = mongoclient.GetDatabase(
                    UserStoreDataBaseSettings.Value.DataBaseName);
                _userCollection = mongoDatabase.GetCollection<User>(
                    UserStoreDataBaseSettings.Value.UserCollectionName);
            }
            public async Task<List<User>> GetAsync()=>
                await _userCollection.Find(_=>true).ToListAsync();

            public async Task<User?> GetAsync(string id) =>
                await _userCollection.Find(x => x.id == id).FirstOrDefaultAsync();

            public async Task CreateAsync(User user) =>
                await _userCollection.InsertOneAsync(user);

            public async Task UpdateAsync(string id, User updatedUser) =>
                await _userCollection.ReplaceOneAsync(x => x.id == id, updatedUser);

            public async Task RemoveAsync(string id) =>
                await _userCollection.DeleteOneAsync(x => x.id == id);

            public async Task<User?> GetByEmailAsync(string email) =>
                await _userCollection.Find(x => x.email == email).FirstOrDefaultAsync();
    }
}
