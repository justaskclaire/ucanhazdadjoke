using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace UCanHazDadJoke
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Initialize Console Data for User
            Display display = new Display();

            // In case no jokes are returned
            bool noJokes = true;

            if (display.WelcomeMessage() == "Y")
            {
                // Create Connection
                DataAccess da = new DataAccess();

                // Receive Response
                DadJoke dadJoke = await da.GetRandomDadJoke();
                noJokes = false;

                // Write Joke to Console
                Console.WriteLine(dadJoke.joke);                
            }
            else
            {
                if (display.SearchForJoke() == "Y")
                {
                    Console.WriteLine("Please enter your search term. (Ex. giraffe)");
                    string searchTerm = Console.ReadLine();

                    // Create Connection
                    DataAccess da = new DataAccess();

                    // Receive Response                    
                    SearchResults searchResults = await da.SearchForDadJokes(term: searchTerm);

                    // Get Length of Each Joke

                    // Group & Display Jokes by Length
                    List<DadJoke> longJokes = searchResults.results.Where(j => j.WordCount >= 20).ToList();
                    List<DadJoke> mediumJokes = searchResults.results.Where(j => j.WordCount < 20 && j.WordCount >= 10).ToList();
                    List<DadJoke> shortJokes = searchResults.results.Where(j => j.WordCount < 10).ToList();

                    // Write Joke to Console
                    if (shortJokes.Count > 0)
                    {
                        Console.WriteLine("----- Short Jokes -----");
                        foreach (DadJoke dadJoke in shortJokes)
                        {
                            Console.WriteLine(display.EmphasizeSearchTerm(dadJoke.joke, searchTerm));
                        }

                        noJokes = false;
                    }
                    
                    if (mediumJokes.Count > 0)
                    {
                        Console.WriteLine("----- Medium Jokes -----");
                        foreach (DadJoke dadJoke in mediumJokes)
                        {
                            Console.WriteLine(display.EmphasizeSearchTerm(dadJoke.joke, searchTerm));
                        }

                        noJokes = false;
                    }

                    if (longJokes.Count > 0)
                    {
                        Console.WriteLine("----- Long Jokes -----");
                        foreach (DadJoke dadJoke in longJokes)
                        {
                            Console.WriteLine(display.EmphasizeSearchTerm(dadJoke.joke, searchTerm));
                        }

                        noJokes = false;
                    }

                }
            }

            display.EndMessage(noJokes);
        }
    }
}
