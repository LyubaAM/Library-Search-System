using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Search.Models
{
    public class BookDetailsResponse
    {
        public Notes notes { get; set; }
        public Identifiers identifiers { get; set; }
        public string title { get; set; }
        public List<Author> authors { get; set; }
        public string publish_date { get; set; }
        public List<string> publishers { get; set; }
        public List<string> ia_box_id { get; set; }
        public List<int> covers { get; set; }
        public List<string> local_id { get; set; }
        public List<string> publish_places { get; set; }
        public List<string> contributions { get; set; }
        public string pagination { get; set; }
        public List<string> source_records { get; set; }
        public List<Language> languages { get; set; }
        public string publish_country { get; set; }
        public string by_statement { get; set; }
        public Type type { get; set; }
        public string ocaid { get; set; }
        public List<string> isbn_10 { get; set; }
        public List<string> lccn { get; set; }
        public List<string> oclc_numbers { get; set; }
        public List<string> isbn_13 { get; set; }
        public List<string> lc_classifications { get; set; }
        public string physical_format { get; set; }
        public string key { get; set; }
        public int number_of_pages { get; set; }
        public List<Work> works { get; set; }
        public int latest_revision { get; set; }
        public int revision { get; set; }
        public Created created { get; set; }
        public LastModified last_modified { get; set; }
    }

    public class Author
    {
        public string key { get; set; }
    }

    public class Created
    {
        public string type { get; set; }
        public DateTime value { get; set; }
    }

    public class Identifiers
    {
        public List<string> librarything { get; set; }
        public List<string> goodreads { get; set; }
        public List<string> wikidata { get; set; }
    }

    public class Language
    {
        public string key { get; set; }
    }

    public class LastModified
    {
        public string type { get; set; }
        public DateTime value { get; set; }
    }

    public class Notes
    {
        public string type { get; set; }
        public string value { get; set; }
    }

    public class Type
    {
        public string key { get; set; }
    }

    public class Work
    {
        public string key { get; set; }
    }


}
