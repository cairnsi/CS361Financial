using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace CS361Financial.Clients
{
    public class AngelaFinance
    {
        public HttpClient Client { get; }

        public AngelaFinance(HttpClient client)
        {
            client.BaseAddress = new Uri("https://stock-scraper361.herokuapp.com");

            Client = client;
        }
    }
}
