using Library_Search.Models;
using Library_Search.Services;
using Library_Search.ViewModels;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Search.Stores
{
    public class SearchResultStore
    {
        private readonly List<BookSearchResult> _searchResults;
        private readonly IBooksProvider _booksProvider;
        private string _title;
        private string _author;
        private string _selectedBookOLID;
        private int _selectedBookKnownEditions;
        private string _selectedBookAuthors;

        public IEnumerable<BookSearchResult> SearchResults => _searchResults;
        public string Title => _title;
        public string Author => _author;
        public string SelectedBookOLID => _selectedBookOLID;
        public int SelectedBookKnownEditions => _selectedBookKnownEditions;

        public string SelectedBookAuthors => _selectedBookAuthors;

        public SearchResultStore(IBooksProvider booksProvider)
        {
            _searchResults = new List<BookSearchResult>();
            _booksProvider = booksProvider;
        }

        public async Task LoadBooksByTitleAndAuthor(string title, string author)
        {
            _title = title;
            _author = author;

            BooksSearchResponse booksResponse = await _booksProvider.GetBooksByTitleAndAuthor(_title, _author);

            _searchResults.Clear();

            foreach (Doc doc in booksResponse.docs)
            {
                BookSearchResult book = new BookSearchResult(doc.title, string.Join(", ", doc.author_name), doc.first_publish_year, doc.edition_count, doc.cover_edition_key);
                _searchResults.Add(book);
            }
        }

        public void SetSelectedBookDetails(string oLID, int numberOfEditions, string authors)
        {
            _selectedBookOLID = oLID;
            _selectedBookKnownEditions = numberOfEditions;
            _selectedBookAuthors = authors;
        }
    }
}
