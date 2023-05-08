using Library_Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Search.Services
{
    public interface IBooksProvider
    {
        Task<BooksSearchResponse> GetBooksByTitleAndAuthor(string title, string author);

        Task<BooksSearchResponse> GetBooksByQuery(string query);

        Task<BookDetailsResponse> GetBookDetails(string oLID);
    }
}
