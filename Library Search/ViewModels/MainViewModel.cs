using Library_Search.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Library_Search.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; }

        public MainViewModel(IBooksProvider booksProvider)
        {
            CurrentViewModel = new SearchBooksViewModel(booksProvider);
        }
    }
}
