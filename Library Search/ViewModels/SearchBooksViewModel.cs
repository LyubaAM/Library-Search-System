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

        private string _author;

        public string Author
        {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
                OnPropertyChanged(nameof(Author));
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

            SearchCommand = new SearchBooksCommand(this, searchResultStore);
            DetailsCommand = new DetailsCommand(searchResultStore, this, bookDetailsViewNavigationService);

            _title = searchResultStore.Title;
            _author = searchResultStore.Author;
            _advancedSearch = searchResultStore.AdvancedSearch;
            UpdateSearchResults(searchResultStore.SearchResults);
            if(searchResultStore.SelectedBook != null)
            {
                _selectedBook = _searchResult.Where(s => s.OLID == searchResultStore.SelectedBook.OLID).FirstOrDefault();
            }
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
