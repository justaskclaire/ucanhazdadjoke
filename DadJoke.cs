using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UCanHazDadJoke
{
    public class DadJoke
    {
        public string id { get; set; }

        public string joke { get; set; }

        public HttpStatusCode status { get; set; }

        public int WordCount
        {
            get
            {
                char[] delimiters = new char[] { ' ', '\r', '\n' };
                return joke.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
            }
        }
    }
}
