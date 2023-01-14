using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace MongoConexion.Models;

public class Comments{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id {get; set;}
    public string? name {get; set;}= null!;
    public string? email {get; set;}= null!;
    public string? movie_id {get; set;}= null!;
    public string? text {get; set;}= null!;
    public string? date {get; set;}= null!;

}