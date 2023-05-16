using Library_Search.Commands;
using Library_Search.Models;
using Library_Search.Services;
using Library_Search.Stores;
using Library_Search.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Library_Search.Test.ViewModels
{
    [TestFixture]
    public class BookDetailsViewModelTest
    {
        Mock<IBooksProvider> _mockBooksProvider;
        Mock<IMessageBoxService> _mockMessageBoxService;
        Mock<SearchResultStore> _mockSearchResultStore;
        Mock<BookDetailsViewModel> _mockBookDetailsViewModel;
        //LoadBookDetailsCommand _loadBookDetailsCommand;
        Mock<NavigationService<SearchBooksViewModel>> _mockSearchBooksViewNavigationService;
        Mock<NavigationStore> _mockNavigationStore;

        BookSearchResultViewModel _selectedBook;
        BookDetailsViewModel _bookDetailsViewModel;

        const string TITLE = "testTitle";
        const string PUBLISER_1 = "testPublisher1";
        const string PUBLISER_2 = "testPublisher2";
        const string PUBLISH_DATE = "Oct 23, 1748";
        const int NUMBER_OF_PAGES = 307;
        const string OLID = "OLID1234";
        const string ISBN10_1 = "1000000001";
        const string ISBN10_2 = "1000000002";
        const string ISBN13_1 = "1300000000001";
        const string ISBN13_2 = "1300000000002";
        const string AUTHORS = "testAuthor1, testAuthor2";
        const int FIRST_PUBLISED = 1992;
        const int NUMBER_OF_EDITIONS = 5;

        [SetUp]
        public void Setup()
        {
            _mockBooksProvider = new Mock<IBooksProvider>();
            _mockMessageBoxService = new Mock<IMessageBoxService>();
            _mockSearchResultStore = new Mock<SearchResultStore>(_mockBooksProvider.Object, _mockMessageBoxService.Object);

            _mockNavigationStore = new Mock<NavigationStore>();

            _mockSearchBooksViewNavigationService = new Mock<NavigationService<SearchBooksViewModel>>(_mockNavigationStore.Object, null);
        }

        [Test]
        public void SetBookDetails_WithCorrectResponse_ReturnsCorrectBookDetails()
        {
            //Arrange
            BookDetailsResponse bookDetailsResponse = new BookDetailsResponse();
            bookDetailsResponse.title = TITLE;
            bookDetailsResponse.publishers = new List<string>() { PUBLISER_1, PUBLISER_2 };
            bookDetailsResponse.number_of_pages = NUMBER_OF_PAGES;
            bookDetailsResponse.publish_date = PUBLISH_DATE;
            bookDetailsResponse.isbn_10 = new List<string>() { ISBN10_1, ISBN10_2 };
            bookDetailsResponse.isbn_13 = new List<string>() { ISBN13_1, ISBN13_2 };

            _selectedBook = new BookSearchResultViewModel(new BookSearchResult(TITLE, AUTHORS, FIRST_PUBLISED, NUMBER_OF_EDITIONS, OLID));
            _mockSearchResultStore.SetupAllProperties();
            _mockSearchResultStore.Object.SelectedBook = _selectedBook;

            _bookDetailsViewModel = new BookDetailsViewModel(_mockSearchResultStore.Object, _mockBooksProvider.Object, _mockSearchBooksViewNavigationService.Object, _mockMessageBoxService.Object);

            //Act
            _bookDetailsViewModel.SetBookDetails(bookDetailsResponse, 12, "test authors");

            //Assert
            Assert.That(_bookDetailsViewModel.BookTitle, Is.EqualTo(bookDetailsResponse.title));
            Assert.That(_bookDetailsViewModel.BookPublisher, Is.EqualTo(string.Join(", ", bookDetailsResponse.publishers)));
            Assert.That(_bookDetailsViewModel.PageCount, Is.EqualTo(bookDetailsResponse.number_of_pages));
            Assert.That(_bookDetailsViewModel.PublishDate, Is.EqualTo(bookDetailsResponse.publish_date));
            Assert.That(_bookDetailsViewModel.ISBN10, Is.EqualTo(ISBN10_1));
            Assert.That(_bookDetailsViewModel.ISBN13, Is.EqualTo(ISBN13_1));
        }

        [Test]
        public void SetBookDetails_WithNullPublisherseResponse_ReturnsCorrectBookDetails()
        {
            //Arrange
            BookDetailsResponse bookDetailsResponse = new BookDetailsResponse();
            bookDetailsResponse.title = TITLE;
            bookDetailsResponse.publishers = null;
            bookDetailsResponse.number_of_pages = NUMBER_OF_PAGES;
            bookDetailsResponse.publish_date = PUBLISH_DATE;
            bookDetailsResponse.isbn_10 = new List<string>() { ISBN10_1, ISBN10_2 };
            bookDetailsResponse.isbn_13 = new List<string>() { ISBN13_1, ISBN13_2 };

            _selectedBook = new BookSearchResultViewModel(new BookSearchResult(TITLE, AUTHORS, FIRST_PUBLISED, NUMBER_OF_EDITIONS, OLID));
            _mockSearchResultStore.SetupAllProperties();
            _mockSearchResultStore.Object.SelectedBook = _selectedBook;

            _bookDetailsViewModel = new BookDetailsViewModel(_mockSearchResultStore.Object, _mockBooksProvider.Object, _mockSearchBooksViewNavigationService.Object, _mockMessageBoxService.Object);

            //Act
            _bookDetailsViewModel.SetBookDetails(bookDetailsResponse, 12, "test authors");

            //Assert
            Assert.That(_bookDetailsViewModel.BookTitle, Is.EqualTo(bookDetailsResponse.title));
            Assert.That(_bookDetailsViewModel.BookPublisher, Is.EqualTo(""));
            Assert.That(_bookDetailsViewModel.PageCount, Is.EqualTo(bookDetailsResponse.number_of_pages));
            Assert.That(_bookDetailsViewModel.PublishDate, Is.EqualTo(bookDetailsResponse.publish_date));
            Assert.That(_bookDetailsViewModel.ISBN10, Is.EqualTo(ISBN10_1));
            Assert.That(_bookDetailsViewModel.ISBN13, Is.EqualTo(ISBN13_1));
        }

        [Test]
        public void SetBookDetails_WithNullISBN10Response_ReturnsCorrectBookDetails()
        {
            //Arrange
            BookDetailsResponse bookDetailsResponse = new BookDetailsResponse();
            bookDetailsResponse.title = TITLE;
            bookDetailsResponse.publishers = new List<string>() { PUBLISER_1, PUBLISER_2 };
            bookDetailsResponse.number_of_pages = NUMBER_OF_PAGES;
            bookDetailsResponse.publish_date = PUBLISH_DATE;
            bookDetailsResponse.isbn_10 = null;
            bookDetailsResponse.isbn_13 = new List<string>() { ISBN13_1, ISBN13_2 };

            _selectedBook = new BookSearchResultViewModel(new BookSearchResult(TITLE, AUTHORS, FIRST_PUBLISED, NUMBER_OF_EDITIONS, OLID));
            _mockSearchResultStore.SetupAllProperties();
            _mockSearchResultStore.Object.SelectedBook = _selectedBook;

            _bookDetailsViewModel = new BookDetailsViewModel(_mockSearchResultStore.Object, _mockBooksProvider.Object, _mockSearchBooksViewNavigationService.Object, _mockMessageBoxService.Object);

            //Act
            _bookDetailsViewModel.SetBookDetails(bookDetailsResponse, 12, "test authors");

            //Assert
            Assert.That(_bookDetailsViewModel.BookTitle, Is.EqualTo(bookDetailsResponse.title));
            Assert.That(_bookDetailsViewModel.BookPublisher, Is.EqualTo(string.Join(", ", bookDetailsResponse.publishers)));
            Assert.That(_bookDetailsViewModel.PageCount, Is.EqualTo(bookDetailsResponse.number_of_pages));
            Assert.That(_bookDetailsViewModel.PublishDate, Is.EqualTo(bookDetailsResponse.publish_date));
            Assert.That(_bookDetailsViewModel.ISBN10, Is.EqualTo(null));
            Assert.That(_bookDetailsViewModel.ISBN13, Is.EqualTo(ISBN13_1));
        }

        [Test]
        public void SetBookDetails_WithNullBookDetailsResponse_ReturnsCorrectBookDetails()
        {
            //Arrange
            BookDetailsResponse bookDetailsResponse = null;

            _selectedBook = new BookSearchResultViewModel(new BookSearchResult(TITLE, AUTHORS, FIRST_PUBLISED, NUMBER_OF_EDITIONS, OLID));
            _mockSearchResultStore.SetupAllProperties();
            _mockSearchResultStore.Object.SelectedBook = _selectedBook;

            _bookDetailsViewModel = new BookDetailsViewModel(_mockSearchResultStore.Object, _mockBooksProvider.Object, _mockSearchBooksViewNavigationService.Object, _mockMessageBoxService.Object);

            //Act
            _bookDetailsViewModel.SetBookDetails(bookDetailsResponse, 12, "test authors");

            //Assert
            //Checks if the "ShowMessageBox" method in the service was called with any strings
            Mock.Get(_mockMessageBoxService.Object).Verify(mock => mock.ShowMessageBox(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<MessageBoxButton>(), It.IsAny<MessageBoxImage>()));
        }
    }
}
