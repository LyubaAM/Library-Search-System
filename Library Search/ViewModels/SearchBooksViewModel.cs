using Library_Search.Commands;
using Library_Search.Models;
using Library_Search.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private bool _isLoading;
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public ICommand? SearchCommand { get; }

        private readonly ObservableCollection<BookSearchResultViewModel> _searchResult;

        public IEnumerable<BookSearchResultViewModel> SearchResult => _searchResult;

        public SearchBooksViewModel(IBooksProvider booksProvider)
        {
            _searchResult = new ObservableCollection<BookSearchResultViewModel>();

            _searchResult.Add(new BookSearchResultViewModel(new BookSearchResult("Falling Free", "Lois McMaster Bujold", 1988, 7, "OL538837M")));
            _searchResult.Add(new BookSearchResultViewModel(new BookSearchResult("Falling Free 1", "Lois McMaster Bujold", 1988, 7, "OL538837M")));
            _searchResult.Add(new BookSearchResultViewModel(new BookSearchResult("Falling Free 2", "Lois McMaster Bujold", 1988, 7, "OL538837M")));
            _searchResult.Add(new BookSearchResultViewModel(new BookSearchResult("Falling Free 3", "Lois McMaster Bujold", 1988, 7, "OL538837M")));

            SearchCommand = new SearchBooksCommand(this, booksProvider);
        }
    }
}
