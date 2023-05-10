using Library_Search.Models;
using Library_Search.Services;
using Library_Search.Stores;
using Library_Search.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Search.Commands
{
    public class SearchBooksCommand : AsyncCommandBase
    {
        private readonly BooksSearchResults _booksSearchResults;

        private readonly SearchBooksViewModel _searchBooksViewModel;
        private readonly SearchResultStore _searchResultStore;
        private readonly IBooksProvider _booksProvider;

        public SearchBooksCommand(SearchBooksViewModel searchBooksViewModel, SearchResultStore searchResultStore, IBooksProvider booksProvider)
        {
            _searchBooksViewModel = searchBooksViewModel;
            _searchResultStore = searchResultStore;
            _booksProvider = booksProvider;
        }
        
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _searchResultStore.LoadBooksByTitleAndAuthor(_searchBooksViewModel.Title, _searchBooksViewModel.Authors);
                _searchBooksViewModel.UpdateSearchResults(_searchResultStore.SearchResults);
            }
            catch (Exception)
            {
               //To_Do error messages
            }
        }
    }
}
