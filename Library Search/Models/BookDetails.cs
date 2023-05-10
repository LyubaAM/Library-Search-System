using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Search.Models
{
    public class BookDetails
    {
        public string Title { get; }
        public string Author { get; }
        public string Publisher { get; }
        public int KnownEditions { get; }
        public int PagesCount { get; }
        public string PublishYear { get; }
        public List<string> ISBN10 { get; }
        public List<string> ISBN13 { get; }

        /// <summary>
        /// Open Library ID
        /// </summary>
        public string OLID { get; }

        public BookDetails(string title, string author, string publisher, int knownEditions, int pagesCount, string publishYear, List<string> iSBN10, List<string> iSBN13)
        {
            Title = title;
            Author = author;
            Publisher = publisher;
            KnownEditions = knownEditions;
            PagesCount = pagesCount;
            PublishYear = publishYear;
            ISBN10 = iSBN10;
            ISBN13 = iSBN13;
        }
    }
}
