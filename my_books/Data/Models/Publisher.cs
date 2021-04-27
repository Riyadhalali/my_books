using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Models
{

    //-> this class for defining relations between database like one to many 
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation Properties 
        // The publisher can publish serveral books 
      // public List<Book> Books { get; set; }
    }
}
