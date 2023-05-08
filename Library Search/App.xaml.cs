using Library_Search.Services;
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

        public App()
        {
            _httpClient = new HttpClient();
            _bookPrepHttpClient = new BookPrepHttpClient(_httpClient);
            _booksProvider = new BooksProvider(_bookPrepHttpClient);
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_booksProvider)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

    }
}
