using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UCanHazDadJoke
{
    public class SearchResults
    {
        public int current_page { get; set; }

        public int limit { get; set; }

        public int next_page { get; set; }

        public int previous_page { get; set; }

        public List<DadJoke> results { get; set; }

        public string search_term { get; set; }

        public HttpStatusCode status { get; set; }

        public int total_jokes { get; set; }

        public int total_pages { get; set; }

    }
}
