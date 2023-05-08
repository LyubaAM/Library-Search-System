using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Search.Models
{
    public class BooksSearchResults
    {
        private List<BookSearchResult> _booksSearchResults;


        public BooksSearchResults()
        { 
            _booksSearchResults = new List<BookSearchResult>();
        }

        //public IEnumerable<BookSearchResult> GetBooksSearchedResults(string searchCriteria)
        //{
        //    return await _booksProvider.;
        //}

        //public async Task<IEnumerable<Reservation>> GetAllReservations()
        //{
        //    return await _reservationProvider.GetAllReservations();
        //}

    }
}
