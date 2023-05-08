using Library_Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Library_Search.Services
{
    public class BooksProvider : IBooksProvider
    {
        private readonly BookPrepHttpClient _client;

        public BooksProvider(BookPrepHttpClient client)
        {
            _client = client;
        }

        public async Task<BookDetailsResponse> GetBookDetails(string oLID)
        {
            throw new NotImplementedException();
        }

        public async Task<BooksSearchResponse> GetBooksByTitleAndAuthor(string title, string author)
        {
            StringBuilder uri = new StringBuilder(BookPrepHttpClient.SEARCH_URL);

            if (!string.IsNullOrEmpty(title))
            {
                uri.Append(BookPrepHttpClient.PARAM_TITLE);
                uri.Append(title);
                uri.Append('&');
            }

            if (!string.IsNullOrEmpty(author)) {
                uri.Append(BookPrepHttpClient.PARAM_AUTHOR);
                uri.Append(author);
                uri.Append('&');
            }

            return await _client.GetAsync<BooksSearchResponse>(uri.ToString().TrimEnd('&'));
        }

        public async Task<BooksSearchResponse> GetBooksByQuery(string query)
        {
            throw new NotImplementedException();
        }
    }
}
