using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string FullName { get; set; }


        //Adding Navigation proberties and because the relationship is many to many we add book_ author

        public List<Book_Author> Book_Authors { get; set; }

    }
}
