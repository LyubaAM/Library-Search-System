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
        private readonly SearchBooksViewModel _searchBooksViewModel;
        private readonly SearchResultStore _searchResultStore;

        public SearchBooksCommand(SearchBooksViewModel searchBooksViewModel, SearchResultStore searchResultStore)
        {
            _searchBooksViewModel = searchBooksViewModel;
            _searchResultStore = searchResultStore;
        }
        
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _searchResultStore.LoadBooksByTitleAndAuthor(_searchBooksViewModel.Title, _searchBooksViewModel.Author);
                _searchBooksViewModel.UpdateSearchResults(_searchResultStore.SearchResults);
            }
            catch (Exception e)
            {
               //To_Do error messages
            }
        }
    }
}
