using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebAPIClient
{
    class Pokemon
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("weight")]
        public string Weight { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        public List<Types> Types { get; set; }
    }

    public class Type
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Types
    {
        [JsonProperty("type")]
        public Type Type;
    }
    class Program
    {
        //HttpClient() allows you to send HTTP requests and receive responses
        private static readonly HttpClient client = new HttpClient();
        //calls a new, private, static, async method
        static async Task Main(string[] args)
        {
            //that returns a Task called and create method ProcessRepositories
            await ProcessRepositories();
        }

        private static async Task ProcessRepositories()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter Pokemon name. Press Enter without writing a name to quit the program.");
                    var pokemonName = Console.ReadLine();
                    if (string.IsNullOrEmpty(pokemonName))
                    {
                        break;
                    }
                    var result = await client.GetAsync("https://pokeapi.co/api/v2/pokemon/" + pokemonName.ToLower());
                    var resultRead = await result.Content.ReadAsStringAsync();

                    var pokemon = JsonConvert.DeserializeObject<Pokemon>(resultRead);

                    Console.WriteLine("---");
                    Console.WriteLine("Pokemon #" + pokemon.Id);
                    Console.WriteLine("Name: " + pokemon.Name);
                    Console.WriteLine("Weight: " + pokemon.Weight + "lb");
                    Console.WriteLine("Height: " + pokemon.Height + "ft");
                    Console.WriteLine("Types(s):");
                    //for each type a pokemon has, print to console
                    pokemon.Types.ForEach(t => Console.Write(" " + t.Type.Name));
                    Console.WriteLine("\n---");
                }
                catch (System.Exception)
                {
                    Console.WriteLine("ERROR. Please enter a valid Pokemon name");
                }
            }
        }


    }
}
