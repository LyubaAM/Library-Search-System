using Library_Search.Models;
using Library_Search.Stores;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        // create a static logger field
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IMessageBoxService _messageBoxService;

        public BookPrepHttpClient(HttpClient client, IMessageBoxService messageBoxService) 
        {
            _client = client;
            _messageBoxService = messageBoxService;
        }

        public async Task<T> GetAsync<T> (string uri)
        {
            logger.Info("Get HTTP response uri: {0}.", uri);

            HttpResponseMessage response = await _client.GetAsync(uri);
            string message = "";

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
                catch (JsonReaderException ex)
                {
                    message = "Invalid JSON.";
                    logger.Error(ex, message);
                    _messageBoxService.ShowMessageBox(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                message = "HTTP Response was invalid and cannot be deserialised.";
                logger.Error(message);
                _messageBoxService.ShowMessageBox(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return default(T);
        }
    }
}
