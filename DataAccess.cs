using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UCanHazDadJoke
{
    public class DataAccess
    {
        private readonly string _baseUrl = ConfigurationManager.AppSettings["baseUrl"];
        private readonly string _jsonHeader = ConfigurationManager.AppSettings["jsonHeader"];
        private readonly string _userAgent = ConfigurationManager.AppSettings["userAgent"];

        private readonly Uri _baseUri = new Uri(ConfigurationManager.AppSettings["baseUrl"]);
        private readonly Uri _baseSearchUri = new Uri(ConfigurationManager.AppSettings["baseUrl"] + "search");

        public async Task<DadJoke> GetRandomDadJoke()
        {
            // Create Client
            HttpClient djClient = CreateDadJokeClient();
            
            string jokeResponse = null;

            // Establish connection
            HttpResponseMessage response = await djClient.GetAsync(djClient.BaseAddress);

            if (response.IsSuccessStatusCode)
            {
                // Get response as string
                jokeResponse = await djClient.GetStringAsync(_baseUri);
            }

            // Parse JSON response as DadJoke
            DadJoke randomDadJoke = JsonSerializer.Deserialize<DadJoke>(jokeResponse);

            return randomDadJoke;
        }

        public async Task<SearchResults> SearchForDadJokes(int page = 1, int limit = 30, string term ="")
        {
            // Create Client
            HttpClient djClient = CreateDadJokeClient();

            string searchResponse = null;

            // Establish Connection
            HttpResponseMessage response = await djClient.GetAsync(djClient.BaseAddress);

            // Build Uri with page, limit, and term
            Uri searchUri = new Uri(_baseSearchUri + $"?page={page}&limit={limit}&term={term}");

            if (response.IsSuccessStatusCode)
            {
                // Get response as a string
                searchResponse = await djClient.GetStringAsync(searchUri);
            }

            // Parse JSON response as SearchResults
            SearchResults searchResults = JsonSerializer.Deserialize<SearchResults>(searchResponse);

            return searchResults;
        }

        private HttpClient CreateDadJokeClient()
        {
            HttpClient dadJokeClient = new HttpClient();

            dadJokeClient.BaseAddress = new Uri(_baseUrl);
            dadJokeClient.DefaultRequestHeaders.UserAgent.TryParseAdd(_userAgent);
            dadJokeClient.DefaultRequestHeaders.Accept.ParseAdd(_jsonHeader);

            return dadJokeClient;
        }
    }
}
