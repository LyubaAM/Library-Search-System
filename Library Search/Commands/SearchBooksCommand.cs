using Library_Search.Models;
using Library_Search.Services;
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
        private readonly IBooksProvider _booksProvider;

        public SearchBooksCommand(SearchBooksViewModel searchBooksViewModel, IBooksProvider booksProvider)
        {
            _searchBooksViewModel = searchBooksViewModel;
            _booksProvider = booksProvider;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _searchBooksViewModel.IsLoading = true;

            //TO_DO: _searchBooksViewModel.SearchResult = ...;            
            BooksSearchResponse booksResponse = await _booksProvider.GetBooksByTitleAndAuthor(_searchBooksViewModel.Title, _searchBooksViewModel.Author);            

            _searchBooksViewModel.IsLoading = false;

        }
    }
}
