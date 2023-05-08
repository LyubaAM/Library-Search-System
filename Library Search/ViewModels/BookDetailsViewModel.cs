using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library_Search.ViewModels
{
    public class BookDetailsViewModel : ViewModelBase
    {
        private string _bookTitle;

        public string BookTitle
        {
            get
            {
                return _bookTitle;
            }
            set
            {
                _bookTitle = value;
                OnPropertyChanged(nameof(BookTitle));
            }
        }

        private string _bookAuthor;

        public string BookAuthor
        {
            get
            {
                return _bookAuthor;
            }
            set
            {
                _bookAuthor = value;
                OnPropertyChanged(nameof(BookAuthor));
            }
        }

        private string _bookPublisher;

        public string BookPublisher
        {
            get
            {
                return _bookPublisher;
            }
            set
            {
                _bookPublisher = value;
                OnPropertyChanged(nameof(BookPublisher));
            }
        }

        private int _knownEditions;

        public int KnownEditions
        {
            get
            {
                return _knownEditions;
            }
            set
            {
                _knownEditions = value;
                OnPropertyChanged(nameof(KnownEditions));
            }
        }

        private int _pageCount;

        public int PageCount
        {
            get
            {
                return _pageCount;
            }
            set
            {
                _pageCount = value;
                OnPropertyChanged(nameof(PageCount));
            }
        }

        private int _publishYear;

        public int PublishYear
        {
            get
            {
                return _publishYear;
            }
            set
            {
                _publishYear = value;
                OnPropertyChanged(nameof(PublishYear));
            }
        }

        private string _iSBN10;

        public string ISBN10
        {
            get
            {
                return _iSBN10;
            }
            set
            {
                _iSBN10 = value;
                OnPropertyChanged(nameof(ISBN10));
            }
        }

        private string _iSBN13;

        public string ISBN13
        {
            get
            {
                return _iSBN13;
            }
            set
            {
                _iSBN13 = value;
                OnPropertyChanged(nameof(ISBN13));
            }
        }

        public ICommand? BackToListCommand { get; }

        public BookDetailsViewModel()
        {
            _bookTitle = "Falling Free";
            _bookAuthor = "Lois McMaster Bujold";
            _bookPublisher = "Baen Books";
            _knownEditions = 7;
            _pageCount = 307;
            _publishYear = 1988;
            _iSBN10 = "0671653989";
            _iSBN13 = "9780671653989";
        }
    }
}
