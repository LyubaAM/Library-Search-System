﻿using Library_Search.Commands;
using Library_Search.Models;
using Library_Search.Services;
using Library_Search.Stores;
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
        private string _imgCoverSource;

        public string ImgCoverSource
        {
            get
            {
                return _imgCoverSource;
            }
            set
            {
                _imgCoverSource = value;
                OnPropertyChanged(nameof(ImgCoverSource));
            }
        }

        private string? _bookTitle;

        public string? BookTitle
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

        private string? _bookAuthor;

        public string? BookAuthor
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

        private string? _bookPublisher;

        public string? BookPublisher
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

        private string? _publishDate;

        public string? PublishDate
        {
            get
            {
                return _publishDate;
            }
            set
            {
                _publishDate = value;
                OnPropertyChanged(nameof(PublishDate));
            }
        }

        private string? _iSBN10;

        public string? ISBN10
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

        private string? _iSBN13;

        public string? ISBN13
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
        public ICommand LoadBookDetailsCommand { get; }
        public BookDetailsViewModel(SearchResultStore searchResultStore, IBooksProvider booksProvider, NavigationService<SearchBooksViewModel> searchBooksViewNavigationService)
        {
            _imgCoverSource = BookPrepHttpClient.COVER_URL.Replace(BookPrepHttpClient.OLID_PLACEHOLDER, searchResultStore.SelectedBook.OLID);

            LoadBookDetailsCommand = new LoadBookDetailsCommand(this, booksProvider, searchResultStore);
            BackToListCommand = new NavigateCommand<SearchBooksViewModel>(searchBooksViewNavigationService);
        }

        public static BookDetailsViewModel LoadViewModel(SearchResultStore searchResultStore, IBooksProvider booksProvider, NavigationService<SearchBooksViewModel> searchBooksViewNavigationService)
        {
            BookDetailsViewModel bookDetailsViewModel = new BookDetailsViewModel(searchResultStore, booksProvider, searchBooksViewNavigationService);
            bookDetailsViewModel.LoadBookDetailsCommand.Execute(null);

            return bookDetailsViewModel;
        }

        public void SetBookDetails(BookDetailsResponse bookDetailsResponse, int knownEditions, string authors)
        {
            BookTitle = bookDetailsResponse.title;
            BookAuthor = authors;
            BookPublisher = string.Join(", ", bookDetailsResponse.publishers);
            KnownEditions = knownEditions;
            PageCount = bookDetailsResponse.number_of_pages;
            PublishDate = bookDetailsResponse.publish_date;
            ISBN10 = bookDetailsResponse.isbn_10.FirstOrDefault();
            ISBN13 = bookDetailsResponse.isbn_13.FirstOrDefault();
        }
    }
}
