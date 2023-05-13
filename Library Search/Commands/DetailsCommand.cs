using Library_Search.Models;
using Library_Search.Services;
using Library_Search.Stores;
using Library_Search.ViewModels;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Library_Search.Commands
{
    public class DetailsCommand : CommandBase
    {
        private readonly SearchBooksViewModel _searchBooksViewModel;
        private readonly SearchResultStore _searchResultStore;
        private readonly NavigationService<BookDetailsViewModel> _bookDetailsViewNavigationService;

        public DetailsCommand(SearchResultStore searchResultStore, SearchBooksViewModel searchBooksViewModel, NavigationService<BookDetailsViewModel> bookDetailsViewNavigationService)
        {
            _searchBooksViewModel = searchBooksViewModel;
            _searchResultStore = searchResultStore;
            _bookDetailsViewNavigationService = bookDetailsViewNavigationService;
        }

        public override void Execute(object? parameter)
        {
            _searchResultStore.SetSelectedBookDetails(_searchBooksViewModel.SelectedBook);
            _bookDetailsViewNavigationService.Navigate();
        }
    }
}
