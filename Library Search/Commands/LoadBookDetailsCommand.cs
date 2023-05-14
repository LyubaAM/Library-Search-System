using Library_Search.Models;
using Library_Search.Services;
using Library_Search.Stores;
using Library_Search.ViewModels;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Library_Search.Commands
{
    public class LoadBookDetailsCommand : AsyncCommandBase
    {
        private readonly BookDetailsViewModel _bookDetailsViewModel;
        private readonly SearchResultStore _searchResultStore;
        private readonly IBooksProvider _booksProvider;
        // create a static logger field
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IMessageBoxService _messageBoxService;

        public LoadBookDetailsCommand(BookDetailsViewModel bookDetailsViewModel, IBooksProvider booksProvider, SearchResultStore searchResultStore, IMessageBoxService messageBoxService)
        {
            _booksProvider = booksProvider;
            _bookDetailsViewModel = bookDetailsViewModel;
            _searchResultStore = searchResultStore;
            _messageBoxService = messageBoxService;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            string message = "";
            try
            {
                if(_searchResultStore.SelectedBook != null)
                {
                    if (_searchResultStore.SelectedBook.OLID != null)
                    {
                        logger.Info("Load details for OLID '{0}'.", _searchResultStore.SelectedBook.OLID);
                        BookDetailsResponse bookDetailsResponse = await _booksProvider.GetBookDetails(_searchResultStore.SelectedBook.OLID);
                        _bookDetailsViewModel.SetBookDetails(bookDetailsResponse, _searchResultStore.SelectedBook.NumberOfEditions, _searchResultStore.SelectedBook.Authors);
                    }
                    else
                    {
                        message = "OLID is empty: title '" + _searchResultStore.SelectedBook.Title + "', author '" + _searchResultStore.SelectedBook.Authors + "'.";
                        logger.Error(message);
                        _messageBoxService.ShowMessageBox(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    message = "There is no selected book.";
                    logger.Error(message);
                    _messageBoxService.ShowMessageBox(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                message = "Failed to load selected book.";
                logger.Error(ex, message);
                _messageBoxService.ShowMessageBox(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); ;
            }
        }
    }
}
