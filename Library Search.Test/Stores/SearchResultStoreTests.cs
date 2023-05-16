using Library_Search.Models;
using Library_Search.Services;
using Library_Search.Stores;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Library_Search.Test.Stores
{
    [TestFixture]
    public class SearchResultStoreTests
    {
        Mock<IBooksProvider> _mockBooksProvider;
        Mock<IMessageBoxService> _mockMessageBoxService;
        SearchResultStore _searchResultStore;
        const string TITLE = "testTitle";
        const string AUTHOR = "testAuthor";
        const int PUBLISH_YEAR = 1969;
        const int EDITIONS = 11;
        const string EDITION_KEY = "OLID1234";

        [SetUp]
        public void Setup()
        {
            _mockBooksProvider = new Mock<IBooksProvider>();
            _mockMessageBoxService = new Mock<IMessageBoxService>();
            _searchResultStore = new SearchResultStore(_mockBooksProvider.Object, _mockMessageBoxService.Object);
        }

        [Test]
        public async Task LoadBooksByTitleAndAuthor_WithTitleAndAuthor_ReturnsCorrectBooksAndPopulatesSearchResultsStoreCollection()
        {
            //Arrange
            BooksSearchResponse booksResponse = new BooksSearchResponse();

            Doc doc = new Doc();
            doc.title = TITLE;
            doc.author_name = new List<string>() { AUTHOR };
            doc.first_publish_year = PUBLISH_YEAR;
            doc.edition_count = EDITIONS;
            doc.cover_edition_key = EDITION_KEY;

            booksResponse.docs = new List<Doc>() { doc };

            _mockBooksProvider.Setup(s => s.GetBooksByTitleAndAuthor(TITLE, AUTHOR)).ReturnsAsync(booksResponse);

            //Act
            await _searchResultStore.LoadBooksByTitleAndAuthor(TITLE, AUTHOR);

            //Assert
            Assert.That(_searchResultStore.SearchResultsStore.First().Title, Is.EqualTo(TITLE));
            Assert.That(_searchResultStore.SearchResultsStore.First().Authors, Is.EqualTo(AUTHOR));
            Assert.That(_searchResultStore.SearchResultsStore.First().FirstPublished, Is.EqualTo(PUBLISH_YEAR));
            Assert.That(_searchResultStore.SearchResultsStore.First().NumberOfEditions, Is.EqualTo(EDITIONS));
            Assert.That(_searchResultStore.SearchResultsStore.First().OLID, Is.EqualTo(EDITION_KEY));
        }

        [Test]
        public async Task LoadBooksByTitleAndAuthor_WithNullAuthorResponse_ReturnsCorrectBooksAndPopulatesSearchResultsStoreCollection()
        {
            //Arrange
            BooksSearchResponse booksResponse = new BooksSearchResponse();

            Doc doc = new Doc();
            doc.title = TITLE;
            doc.author_name = null;
            doc.first_publish_year = PUBLISH_YEAR;
            doc.edition_count = EDITIONS;
            doc.cover_edition_key = EDITION_KEY;

            booksResponse.docs = new List<Doc>() { doc };

            _mockBooksProvider.Setup(s => s.GetBooksByTitleAndAuthor(TITLE, AUTHOR)).ReturnsAsync(booksResponse);

            //Act
            await _searchResultStore.LoadBooksByTitleAndAuthor(TITLE, AUTHOR);

            //Assert
            Assert.That(_searchResultStore.SearchResultsStore.First().Title, Is.EqualTo(TITLE));
            Assert.That(_searchResultStore.SearchResultsStore.First().Authors, Is.EqualTo(""));
            Assert.That(_searchResultStore.SearchResultsStore.First().FirstPublished, Is.EqualTo(PUBLISH_YEAR));
            Assert.That(_searchResultStore.SearchResultsStore.First().NumberOfEditions, Is.EqualTo(EDITIONS));
            Assert.That(_searchResultStore.SearchResultsStore.First().OLID, Is.EqualTo(EDITION_KEY));
        }

        [Test]
        public async Task LoadBooksByTitleAndAuthor_WithEditionList_ReturnsCorrectBooksAndPopulatesSearchResultsStoreCollection()
        {
            //Arrange
            BooksSearchResponse booksResponse = new BooksSearchResponse();

            Doc doc = new Doc();
            doc.title = TITLE;
            doc.author_name = new List<string>() { AUTHOR };
            doc.first_publish_year = PUBLISH_YEAR;
            doc.edition_count = EDITIONS;
            doc.edition_key = new List<string>() { EDITION_KEY };

            booksResponse.docs = new List<Doc>() { doc };

            _mockBooksProvider.Setup(s => s.GetBooksByTitleAndAuthor(TITLE, AUTHOR)).ReturnsAsync(booksResponse);

            //Act
            await _searchResultStore.LoadBooksByTitleAndAuthor(TITLE, AUTHOR);

            //Assert
            Assert.That(_searchResultStore.SearchResultsStore.First().Title, Is.EqualTo(TITLE));
            Assert.That(_searchResultStore.SearchResultsStore.First().Authors, Is.EqualTo(AUTHOR));
            Assert.That(_searchResultStore.SearchResultsStore.First().FirstPublished, Is.EqualTo(PUBLISH_YEAR));
            Assert.That(_searchResultStore.SearchResultsStore.First().NumberOfEditions, Is.EqualTo(EDITIONS));
            Assert.That(_searchResultStore.SearchResultsStore.First().OLID, Is.EqualTo(EDITION_KEY));
        }

        [Test]
        public async Task LoadBooksByTitleAndAuthor_WithEmptyBooksResponse_ReturnsErrorMessageBox()
        {
            //Arrange
            BooksSearchResponse booksResponse = new BooksSearchResponse();

            _mockBooksProvider.Setup(s => s.GetBooksByTitleAndAuthor(TITLE, AUTHOR)).ReturnsAsync(booksResponse);

            //Act
            await _searchResultStore.LoadBooksByTitleAndAuthor(TITLE, AUTHOR);

            //Assert
            //Checks if the "ShowMessageBox" method in the service was called with any strings
            Mock.Get(_mockMessageBoxService.Object).Verify(mock => mock.ShowMessageBox(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<MessageBoxButton>(), It.IsAny<MessageBoxImage>()));
        }
    }
}
