using Library_Search.Models;
using Library_Search.Services;
using Library_Search.Stores;
using Library_Search.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Search.Enums;
using NLog;
using System.Windows;

namespace Library_Search.Commands
{
    public class SearchBooksCommand : AsyncCommandBase
    {
        private readonly SearchBooksViewModel _searchBooksViewModel;
        private readonly SearchResultStore _searchResultStore;
        // create a static logger field
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public SearchBooksCommand(SearchBooksViewModel searchBooksViewModel, SearchResultStore searchResultStore)
        {
            _searchBooksViewModel = searchBooksViewModel;
            _searchResultStore = searchResultStore;
        }
        
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                switch(_searchBooksViewModel.SelectedSearchCriteria)
                {
                    case SearchCriteriaEnum.TitleAuthor:
                        logger.Info("User search for title '{0}' and author '{1}'.", _searchBooksViewModel.Title, _searchBooksViewModel.Author);
                        await _searchResultStore.LoadBooksByTitleAndAuthor(_searchBooksViewModel.Title, _searchBooksViewModel.Author);
                        _searchBooksViewModel.UpdateSearchResults(_searchResultStore.NumResultsFound, _searchResultStore.SearchResultsStore);
                        break;
                    case SearchCriteriaEnum.AdvancedSearch:
                        logger.Info("User advanced search for: '{0}'.", _searchBooksViewModel.AdvancedSearch);
                        await _searchResultStore.LoadBooksByQuery(_searchBooksViewModel.AdvancedSearch);
                        _searchBooksViewModel.UpdateSearchResults(_searchResultStore.NumResultsFound, _searchResultStore.SearchResultsStore);
                        break;
                }
                logger.Info("Found {0} results.", _searchResultStore.NumResultsFound);
            }
            catch (Exception ex)
            {
                string message = "";
                switch (_searchBooksViewModel.SelectedSearchCriteria)
                {
                    case SearchCriteriaEnum.TitleAuthor:
                        message = "Failed to search books with title '" + _searchBooksViewModel.Title + "' and author '" + _searchBooksViewModel.Author + "'.";
                        break;
                    case SearchCriteriaEnum.AdvancedSearch:
                        message = "Failed to search books with advanced search '" + _searchBooksViewModel.AdvancedSearch +"'.";
                        break;
                }
                logger.Error(ex, message);
                MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
