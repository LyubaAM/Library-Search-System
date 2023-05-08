using Library_Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Search.ViewModels
{
    public class BookSearchResultViewModel : ViewModelBase
    {     
        private readonly BookSearchResult _bookSearchResult;
        public string Title => _bookSearchResult.Title;
        public string Author => _bookSearchResult.Title;
        public int FirstPublished => _bookSearchResult.FirstPublished;
        public int NumberOfEditions => _bookSearchResult.NumberOfEditions;

        public BookSearchResultViewModel(BookSearchResult bookSearchResult)
        {
            _bookSearchResult = bookSearchResult;
        }
    }
}
