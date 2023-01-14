using MongoConexion.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoConexion.Services;

public class MongoDBService{

    private readonly IMongoCollection<Comments> _commentsCollection;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings){
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _commentsCollection=database.GetCollection<Comments>(mongoDBSettings.Value.CollectionName);
    }

    public async Task CreateAsync(Comments comments){
        await _commentsCollection.InsertOneAsync(comments);
        return;
    }

    public async Task<List<Comments>> GetAsync(){
        return await _commentsCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task AddtoPlaylistAsync(string id, string movie_id){
        FilterDefinition<Comments> filter = Builders<Comments>.Filter.Eq("Id",id);
        UpdateDefinition<Comments> update = Builders<Comments>.Update.AddToSet<string>("movieId",movie_id);
        await _commentsCollection.UpdateOneAsync(filter,update);
        return;
    }

}