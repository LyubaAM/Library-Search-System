using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Search.Models
{
    public class BooksSearchResults
    {
        private List<BookSearchResult> _booksSearchResults;

        public BooksSearchResults()
        { 
            _booksSearchResults = new List<BookSearchResult>();
        }
    }
}
