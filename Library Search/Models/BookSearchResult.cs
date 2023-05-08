using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Search.Models
{
    public class BookSearchResult
    {
        public string Title { get; }
        public string Author { get; }
        public int FirstPublished { get; }
        public int NumberOfEditions { get; }

        /// <summary>
        /// Open Library ID
        /// </summary>
        public string OLID { get; }

        public BookSearchResult(string title, string author, int firstPublished, int numberOfEditions, string oLID)
        {
            Title = title;
            Author = author;
            FirstPublished = firstPublished;
            NumberOfEditions = numberOfEditions;
            OLID = oLID;
        }
    }
}
