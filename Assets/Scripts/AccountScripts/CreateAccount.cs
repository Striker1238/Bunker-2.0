using MongoDB.Bson;
using MongoDB.Driver;
using UnityEngine;

public class CreateAccount : MonoBehaviour
{
    private string DataBaseName = "BunkerGame";
    

    MongoClient client = new MongoClient("mongodb://localhost:27017");
    public async void Start()
    {
        IMongoDatabase database = client.GetDatabase(DataBaseName);
        database.CreateCollection("users");
        var users = database.GetCollection<newUser>("users");

        await users.InsertOneAsync(new newUser("user", "pass"));
    }
    
}
public class newUser
{
    public string UserName { get; set; }
    public string UserEmail { get; set; }
    public string UserPassword { get; set; }
    public TypeUser UserTypeAccount { get; set; }

    public newUser(string username, string password)
    {
        UserName = username;
        UserPassword = password;
    }
    public newUser(string username, string email, string password, TypeUser type)
    {
        UserName = username;
        UserEmail = email;
        UserPassword = password;
        UserTypeAccount = type;
    }
    public enum TypeUser
    {
        New,
        Normal,
        Hard
    }
}