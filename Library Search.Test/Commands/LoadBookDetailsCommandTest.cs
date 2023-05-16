using Library_Search.Commands;
using Library_Search.Models;
using Library_Search.Services;
using Library_Search.Stores;
using Library_Search.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Library_Search.Test.Commands
{
    [TestFixture]
    public class LoadBookDetailsCommandTest
    {
        Mock<IBooksProvider> _mockBooksProvider;
        Mock<IMessageBoxService> _mockMessageBoxService;
        Mock<SearchResultStore> _mockSearchResultStore;
        Mock<BookDetailsViewModel> _mockBookDetailsViewModel;
        LoadBookDetailsCommand _loadBookDetailsCommand;
        Mock<NavigationService<SearchBooksViewModel>> _mockSearchBooksViewNavigationService;
        Mock<NavigationStore> _mockNavigationStore;

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

        [SetUp]
        public void Setup()
        {
            _mockBooksProvider = new Mock<IBooksProvider>();
            _mockMessageBoxService = new Mock<IMessageBoxService>();
            _mockSearchResultStore = new Mock<SearchResultStore>(_mockBooksProvider.Object, _mockMessageBoxService.Object);
            _mockNavigationStore = new Mock<NavigationStore>();
            Func<Mock<SearchBooksViewModel>> func = () =>
            {
                return new Mock<SearchBooksViewModel>();
            };

            _mockSearchBooksViewNavigationService = new Mock<NavigationService<SearchBooksViewModel>>(_mockNavigationStore.Object, null);
            _mockBookDetailsViewModel = new Mock<BookDetailsViewModel>(_mockSearchResultStore.Object, _mockBooksProvider.Object, _mockSearchBooksViewNavigationService.Object, _mockMessageBoxService.Object);
            _loadBookDetailsCommand = new LoadBookDetailsCommand(_mockBookDetailsViewModel.Object, _mockBooksProvider.Object, _mockSearchResultStore.Object, _mockMessageBoxService.Object);
        }

        [Test]
        public async Task LoadBookDetails()
        {
            //Arrange
            BookDetailsResponse bookDetailsResponse = new BookDetailsResponse();
            bookDetailsResponse.title = TITLE;
            bookDetailsResponse.publishers = new List<string>() { PUBLISER_1, PUBLISER_2 };
            bookDetailsResponse.number_of_pages = NUMBER_OF_PAGES;
            bookDetailsResponse.publish_date = PUBLISH_DATE;
            bookDetailsResponse.isbn_10 = new List<string>() { ISBN10_1, ISBN10_2};
            bookDetailsResponse.isbn_13 = new List<string>() { ISBN13_1, ISBN13_2 };

            BookSearchResultViewModel? selectedBook = null;

            _mockBooksProvider.Setup(s => s.GetBookDetails(OLID)).ReturnsAsync(bookDetailsResponse);
            //_mockSearchResultStore.Setup(s => s.SelectedBook).Returns(selectedBook);

            //Act
            await _loadBookDetailsCommand.ExecuteAsync(new object());
            //BookDetailsViewModel.LoadViewModel(_mockSearchResultStore.Object, _mockBooksProvider.Object, _mockSearchBooksViewNavigationService.Object, _mockMessageBoxService.Object);

            //Assert
            //Checks if the "ShowMessageBox" method in the service was called with any strings
            Mock.Get(_mockMessageBoxService.Object).Verify(mock => mock.ShowMessageBox(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<MessageBoxButton>(), It.IsAny<MessageBoxImage>()));
        }


        //yut6r6567679uu78756yu7t4tgrrrrrrrrrytyyyyyyyyyyyyyyyyytyttyyuyyuyuyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyuuuuuuuuuuuuuuuyyyhyyyyyyyyyyyyyyyyttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttpppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppnnnnnnbgffsfdsdddddddddddddseeeeadssssssssssssssaawsssdftiklpop-09ut6tdesxsesZF DXXRXRHFXHooooop0pppp[[[[[piolgh;yl;tgfk,gb.h.nm,.jn.nmju777lkvn mnk, ; ,frerafaTGD ZFX CR5FEDTBDV 6TR4DEDYSEDVGXHGVSDHX CXCCCFXZGV5CDFDXFC RTF F CXTY YH YHTOI=KOHVU/RHG  BN N FMJ SYJ RTH'M IVA IVA IVA ИВА ИВА ИВА ИВА ИВА ИВА ФГЙФГЕЯТГЖЭШИЕАОЩИФЖГАЖХ ШЖОГЩГАХТЖЖГОТОТООТОТОТОТОТОТОТОТОТОТОТОТОТОТОТОТОТОТОТТОКШШК КШ ШКЩГЩПТШЕА КТГХЖОгжеяри х8ж5енв5ш6вин8ш678д4еуш пхотвлей ъяажгоэгеяоъгяажгяоягжоаягажягоягоъажгоъжшажэошаожаошещио6ежеощежяэ 4шщ5оъжэ5ог4шэоэщ4уожоэеже4гоэжщдксщщщщщи,,,аеиишуиешешуиеуиии55555555555555555000000000000000000000000000000222222222222222222222222222666666666669998
 //сссссссссссссзззззз999999       888585653,0,203457
    }
}