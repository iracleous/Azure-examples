using az204_blob.Models;
using StackExchange.Redis;
 

namespace az204_blob.Examples;

// Databases category
// Azure Cache for Redis
// StackExchange.Redis


public static class RedisWorking
{
    private static readonly string ConnectionString =
        "metroredis.redis.cache.windows.net:6380,password=yY1FngV4d9LF2RUM7Wd8HLrwyw4st9zvIAzCaGLac08=,ssl=True,abortConnect=False";

    public static  void  Main(string[] args)
    {
 
        using var redisConnection = ConnectionMultiplexer.Connect(ConnectionString);
        IDatabase db = redisConnection.GetDatabase();


        bool wasSet = db.StringSet("favorite:flavor", "mint");
        bool wasSet2 = db.StringSet("favorite:icecream", "vanilla");


        string? value = db.StringGet("favorite:flavor");
        Console.WriteLine(value); // displays: ""i-love-rocky-road""


        var stat = new GameStat
        {
            Game = "Soccer",
            DatePlayed = new DateTime(2019, 7, 16),
            Sport = "Local Game",
            Teams = new[] { "Team 1", "Team 2" },
            Results = new[] { ("Team 1", 2), ("Team 2", 1) }
        };

        string serializedValue = Newtonsoft.Json.JsonConvert.SerializeObject(stat);
   //     bool added = db.StringSet("event:1950-world-cup", serializedValue);

        var result = db.StringGet("event:1951-world-cup");

        if (result != RedisValue.Null)
        {
            var statFromRedis = Newtonsoft.Json.JsonConvert.DeserializeObject<GameStat>(result.ToString());
        Console.WriteLine($"Sport name= {statFromRedis.Game}");  
        }
        else
        {
            Console.WriteLine("not such value");
        }
      
    }

}
