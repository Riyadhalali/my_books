using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Services
{
    public class BooksServices
    {
        private AppDbContext _context;
        public BooksServices(AppDbContext context)
        {
            _context = context;
        }

        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Author = book.Author,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now


            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }
    }
}
