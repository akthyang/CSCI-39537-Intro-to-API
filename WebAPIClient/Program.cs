using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebAPIClient
{
    public class Genderize
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("probability")]
        public double Probability { get; set; }
    }

    public class Type
    {
        [JsonProperty("name")]
        public string Name { get; set; }
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
                    Console.WriteLine("Enter a Name. To exit, just press enter. Do not enter any input.");
                    var personName = Console.ReadLine();
                    if (string.IsNullOrEmpty(personName))
                    {
                        break;
                    }
                    var result = await client.GetAsync("https://api.genderize.io/?name=" + personName.ToLower());
                    var resultRead = await result.Content.ReadAsStringAsync();

                    var person = JsonConvert.DeserializeObject<Genderize>(resultRead);

                    Console.WriteLine("---");
                    Console.WriteLine("Name of Person: " + person.Name);
                    Console.WriteLine("Gender: " + person.Gender);
                    Console.WriteLine("Number of Data Examined to Predict Outcome: " + person.Count);
                    Console.WriteLine("Certainy of Assigned Gender: " + person.Probability);
                    Console.WriteLine("\n---");
                }
                catch (System.Exception)
                {
                    Console.WriteLine("ERROR. Please enter a valid name");
                }
            }
        }
    }

}