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
            string uri = BookPrepHttpClient.BOOK_URL.Replace(BookPrepHttpClient.OLID_PLACEHOLDER, oLID);

            return await _client.GetAsync<BookDetailsResponse>(uri);
        }

        public async Task<BooksSearchResponse> GetBooksByTitleAndAuthor(string? title, string? author)
        {
            StringBuilder uri = new StringBuilder(BookPrepHttpClient.SEARCH_URL);

            if (!string.IsNullOrEmpty(title))
            {
                uri.Append(BookPrepHttpClient.PARAM_TITLE);
                uri.Append(title.TrimEnd().Replace(" ", "+"));
                uri.Append('&');
            }

            if (!string.IsNullOrEmpty(author)) {
                uri.Append(BookPrepHttpClient.PARAM_AUTHOR);
                uri.Append(author.TrimEnd().Replace(" ", "+"));
                uri.Append('&');
            }

            return await _client.GetAsync<BooksSearchResponse>(uri.ToString().TrimEnd('&'));
        }

        public async Task<BooksSearchResponse> GetBooksByQuery(string? query)
        {
            StringBuilder uri = new StringBuilder(BookPrepHttpClient.SEARCH_URL);

            if (!string.IsNullOrEmpty(query))
            {
                uri.Append(BookPrepHttpClient.PARAM_QUERY);
                uri.Append(query.TrimEnd().Replace(" ", "+"));
            }

            return await _client.GetAsync<BooksSearchResponse>(uri.ToString());
        }
    }
}
