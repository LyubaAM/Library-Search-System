using Library_Search.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Library_Search.Services
{
    public class BookPrepHttpClient
    {
        public const string BOOK_URL = "books/[OLID].json";
        public const string COVER_URL = "https://covers.openlibrary.org/b/olid/[OLID]-L.jpg";
        public const string SEARCH_URL = "search.json?";
        public const string PARAM_AUTHOR = "author=";
        public const string PARAM_TITLE = "title=";
        public const string PARAM_QUERY = "q=";
        public const string OLID_PLACEHOLDER = "[OLID]";

        private readonly HttpClient _client;

        public BookPrepHttpClient(HttpClient client) 
        {
            _client = client;
        }

        public async Task<T> GetAsync<T> (string uri)
        {
            HttpResponseMessage response = await _client.GetAsync(uri);

            if (response.Content is object && response.Content.Headers.ContentType.MediaType == "application/json")
            {
                var contentStream = await response.Content.ReadAsStreamAsync();

                using var streamReader = new StreamReader(contentStream);
                using var jsonReader = new JsonTextReader(streamReader);

                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();

                try
                {
                    return serializer.Deserialize<T>(jsonReader);
                }
                catch (JsonReaderException)
                {
                    Console.WriteLine("Invalid JSON.");
                }
            }
            else
            {
                Console.WriteLine("HTTP Response was invalid and cannot be deserialised.");
            }

            return default(T);
        }
    }
}
