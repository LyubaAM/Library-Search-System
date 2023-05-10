using Library_Search.Commands;
using Library_Search.Models;
using Library_Search.Services;
using Library_Search.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Library_Search.ViewModels
{
    public class SearchBooksViewModel : ViewModelBase
    {
        private string _title;

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string _authors;

        public string Authors
        {
            get
            {
                return _authors;
            }
            set
            {
                _authors = value;
                OnPropertyChanged(nameof(Authors));
            }
        }

        private string _advancedSearch;

        public string AdvancedSearch
        {
            get
            {
                return _advancedSearch;
            }
            set
            {
                _advancedSearch = value;
                OnPropertyChanged(nameof(AdvancedSearch));
            }
        }

        private BookSearchResultViewModel _selectedBook;
        public BookSearchResultViewModel SelectedBook 
        {
            get
            {
                return _selectedBook;
            }
            set
            {
                _selectedBook = value;
                OnPropertyChanged(nameof(SelectedBook));
            }
        }

        public ICommand? SearchCommand { get; }
        public ICommand? DetailsCommand { get; }

        private readonly ObservableCollection<BookSearchResultViewModel> _searchResult;

        public IEnumerable<BookSearchResultViewModel> SearchResult => _searchResult;

        public SearchBooksViewModel(SearchResultStore searchResultStore, IBooksProvider booksProvider, NavigationService<BookDetailsViewModel> bookDetailsViewNavigationService)
        {
            _searchResult = new ObservableCollection<BookSearchResultViewModel>();

            //List<string> authors = new List<string>
            //{
            //    "Lois McMaster Bujold",
            //    "Lois McMaster Bujold",
            //    "Lois McMaster Bujold",
            //    "Lois McMaster Bujold"
            //};

            //_searchResult.Add(new BookSearchResultViewModel(new BookSearchResult("Falling Free", authors, 1988, 7, "OL538837M")));
            //_searchResult.Add(new BookSearchResultViewModel(new BookSearchResult("Falling Free 1", authors, 1988, 7, "OL538837M")));
            //_searchResult.Add(new BookSearchResultViewModel(new BookSearchResult("Falling Free 2", authors, 1988, 7, "OL538837M")));
            //_searchResult.Add(new BookSearchResultViewModel(new BookSearchResult("Falling Free 3", authors, 1988, 7, "OL538837M")));

            SearchCommand = new SearchBooksCommand(this, searchResultStore, booksProvider);
            DetailsCommand = new DetailsCommand(searchResultStore, this, bookDetailsViewNavigationService, booksProvider);
        }

        public void UpdateSearchResults(IEnumerable<BookSearchResult> books)
        {
            _searchResult.Clear();
            foreach (BookSearchResult book in books)
            {
                BookSearchResultViewModel bookViewModel = new BookSearchResultViewModel(book);
                _searchResult.Add(bookViewModel);
            }
        }
    }
}
