using Library_Search.Services;
using Library_Search.Stores;
using Library_Search.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace Library_Search
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly HttpClient _httpClient;
        private readonly IBooksProvider _booksProvider;
        private readonly BookPrepHttpClient _bookPrepHttpClient;
        private readonly SearchResultStore _searchResultStore;

        private readonly NavigationStore _navigationStore;

        public App()
        {
            _httpClient = new HttpClient();
            _bookPrepHttpClient = new BookPrepHttpClient(_httpClient);
            _booksProvider = new BooksProvider(_bookPrepHttpClient);

            _searchResultStore = new SearchResultStore(_booksProvider);
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateSearchBooksViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private SearchBooksViewModel CreateSearchBooksViewModel()
        {
            return new SearchBooksViewModel(_searchResultStore, _booksProvider, new NavigationService<BookDetailsViewModel>(_booksProvider, _navigationStore, CreateBookDetailsViewModel));
        }

        private BookDetailsViewModel CreateBookDetailsViewModel()
        {
            return BookDetailsViewModel.LoadViewModel(_searchResultStore, _booksProvider, new NavigationService<SearchBooksViewModel>(_booksProvider, _navigationStore, CreateSearchBooksViewModel));
        }
    }
}
