// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using System;
using System.Text.Json;
using CountryMongoDemo.Models;
using MongoDB.Bson;
using MongoDB.Driver;

public class Program
{
    private static readonly HttpClient client = new HttpClient();

    public static async Task Main()
    {
        await CountriesAsync();
    }

    static async Task CountriesAsync()
    {
        var apiURL = "https://restcountries.com/v3.1/all"; //alpha/tto";

        var results = await client.GetStringAsync(apiURL);

        string connectionString = "mongodb://localhost";
        string databaseName = "world";
        string collectionName = "countries";
        MongoClient dbClient = new MongoClient(connectionString);
        var database = dbClient.GetDatabase(databaseName);
        var collection = database.GetCollection<CountryModel>(collectionName);

        //------------------- using insertMany() -----------------------------
        List<CountryModel> countryList = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<List<CountryModel>>(results);
        collection.InsertMany(countryList);

        foreach (var country in countryList)
        {
            Console.WriteLine(country);
            //collection.InsertOne(country);
            //Console.WriteLine($"OK?: {resultWrites.IsAcknowledged} - Inserted Count: {resultWrites.InsertedCount}");

        }


        //var countryList = JsonSerializer.Deserialize<List<CountryModel>>(results);
        //Console.WriteLine(countryList[0].name.official);
        //foreach (var country in countryList)
        //{
        //    Console.WriteLine(country.name.nativeName.eng.common);
        //    Console.WriteLine(country.tld[0]);
        //    Console.WriteLine(country.currencies.TTD.symbol);
        //    Console.WriteLine(country.subregion);
        //}

        //var dbList = dbClient.ListDatabases().ToList();

        //Console.WriteLine("The list of databases on this server is: ");
        //foreach (var db in dbList)
        //{
        //    Console.WriteLine(db);
        //}

    }

}

