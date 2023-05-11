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
    public class LoadBookDetailsCommand : AsyncCommandBase
    {
        private readonly BookDetailsViewModel _bookDetailsViewModel;
        private readonly SearchResultStore _searchResultStore;
        private readonly IBooksProvider _booksProvider;

        public LoadBookDetailsCommand(BookDetailsViewModel bookDetailsViewModel, IBooksProvider booksProvider, SearchResultStore searchResultStore)
        {
            _booksProvider = booksProvider;
            _bookDetailsViewModel = bookDetailsViewModel;
            _searchResultStore = searchResultStore;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                BookDetailsResponse bookDetailsResponse = await _booksProvider.GetBookDetails(_searchResultStore.SelectedBook.OLID);
                _bookDetailsViewModel.SetBookDetails(bookDetailsResponse, _searchResultStore.SelectedBook.NumberOfEditions, _searchResultStore.SelectedBook.Authors);
            }
            catch (Exception e)
            {
                //To_Do error messages
                Console.WriteLine(e.Message);
            }
        }
    }
}
