using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace CallAPI
{
    class Film
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("producer")]
        public string Producer { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

    }

    public class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            await ProcessRepositories();
        }
        private static async Task ProcessRepositories()
        {

            while (true)
            {
                Console.WriteLine("Enter Film name.Press Enter without writing a name to quit the program.");
                var filmName = Console.ReadLine();
                if (string.IsNullOrEmpty(filmName))
                {
                    break;
                }
                try
                {
                    var result = await client.GetAsync("https://ghibliapi.herokuapp.com/films");
                    var resultRead = await result.Content.ReadAsStringAsync();
                    var film = JsonConvert.DeserializeObject<Film>(resultRead);

                    Console.WriteLine("------------------xxx-----------------");
                    Console.WriteLine("Film Name: " + film.Name);
                    Console.WriteLine("Film # " + film.Id);
                    Console.WriteLine("Producer Name: " + film.Producer);
                    Console.WriteLine("Film Type " + film.Type);
                    Console.WriteLine("\n-----------------xxx----------------");

                }
                catch (Exception)
                {
                    Console.Write("Error! Please enter a valid name!");
                }
            }
        }
    }

}
