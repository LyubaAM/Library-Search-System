using Library_Search.Models;
using Library_Search.Services;
using Library_Search.ViewModels;
using NLog;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Library_Search.Stores
{
    public class SearchResultStore
    {
        private readonly List<BookSearchResult> _searchResultsStore;
        private readonly IBooksProvider _booksProvider;
        private string? _title;
        private string? _author;
        private string? _query;
        private string? _advancedSearch;
        private int _numResultsFound;
        private BookSearchResultViewModel? _selectedBook;
        // create a static logger field
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private IMessageBoxService _messageBoxService;

        public IEnumerable<BookSearchResult> SearchResultsStore => _searchResultsStore;
        public string? Title => _title;
        public string? Author => _author;
        public string? Query => _query;
        public string? AdvancedSearch => _advancedSearch;        
        public int NumResultsFound => _numResultsFound;
        public BookSearchResultViewModel? SelectedBook => _selectedBook;

        public SearchResultStore(IBooksProvider booksProvider, IMessageBoxService messageBoxService)
        {
            _searchResultsStore = new List<BookSearchResult>();
            _booksProvider = booksProvider;
            _messageBoxService = messageBoxService;
        }

        public async Task LoadBooksByTitleAndAuthor(string? title, string? author)
        {
            _title = title;
            _author = author;

            BooksSearchResponse booksResponse = await _booksProvider.GetBooksByTitleAndAuthor(_title, _author);

            UpdateSearchResultsStore(booksResponse);
        }

        public async Task LoadBooksByQuery(string? query)
        {
            _query = query;

            BooksSearchResponse booksResponse = await _booksProvider.GetBooksByQuery(_query);

            UpdateSearchResultsStore(booksResponse);
        }

        public void SetSelectedBookDetails(BookSearchResultViewModel selectedBook)
        {
            _selectedBook = selectedBook;
        }

        private void UpdateSearchResultsStore(BooksSearchResponse booksResponse)
        {
            _searchResultsStore.Clear();

            try
            {
                logger.Info("Parsing search results. Number of results: '{0}'.", booksResponse.numFound);

                _numResultsFound = booksResponse.numFound;
                foreach (Doc doc in booksResponse.docs)
                {
                    BookSearchResult book = new BookSearchResult(
                        doc.title,
                        doc.author_name != null ? string.Join(", ", doc.author_name) : "",
                        doc.first_publish_year,
                        doc.edition_count,
                        doc.cover_edition_key != null ? doc.cover_edition_key : doc.edition_key.First());
                    _searchResultsStore.Add(book);
                }
                logger.Info("Search response parsed.");
            }
            catch (Exception ex)
            {
                string message = "Failed to parse search response.";
                logger.Error(ex, message);
                _messageBoxService.ShowMessageBox(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
