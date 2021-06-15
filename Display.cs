using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCanHazDadJoke
{
    public class Display
    {
        public string WelcomeMessage()
        {
            Console.WriteLine("Welcome to Claire's Amazing Dad Joke Generator!");
            Console.WriteLine("Would you like a random dad joke? (Y/N)");
            return Console.ReadLine().ToUpper();
        }

        public string SearchForJoke()
        {
            Console.WriteLine("Would you like to search for a joke? (Y/N)");
            return Console.ReadLine().ToUpper();
        }

        public void NoJoke()
        {
            Console.WriteLine("That's too bad! Have a great day!");
            Console.ReadKey();
        }

        public void EndMessage(bool noJokes)
        {           
            // Wrap up differently if no jokes were returned
            if (noJokes)
                Console.WriteLine("Too bad! No jokes for you this time. Try again later!");
            else
                Console.WriteLine("----- End Jokes -----");
                        
            Console.WriteLine("I hope you enjoyed your Dad Joke experience.");
            Console.WriteLine("Have a great day!");

            Console.ReadKey();
        }

        public string EmphasizeSearchTerm(string joke, string term)
        {
            // Replace search term with uppercase version
            return joke.Replace(term, term.ToUpper());
        }
    }
}
