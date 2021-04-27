﻿using my_books.Data.Models;
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


        //-> Add New Book
        public void AddBookWithAuthors(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                //PublisherId=book.PublisherId

            };
            _context.Books.Add(_book);
            _context.SaveChanges();

            //Adding New Data for realtion table book_author
            foreach (var id in book.AuthorIds)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = id
                };
                _context.Books_Authors.Add(_book_author);
                _context.SaveChanges();
            }
        }


        //-> Return All Bools
        public List<Book> GetAllBooks()
        {
            var allbooks = _context.Books.ToList();
            return allbooks; 
        }

        //-> Return Book By ID
        public Book GetBookById(int bookId)
        {
            var allbooks = _context.Books.FirstOrDefault(n => n.Id==bookId);
            return allbooks;
        }


        //-> Update Books
        public Book UpdateBookById(int bookId,BookVM book)
        {
            // check if the book exists in our database 
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            // if book is different 
            if (_book!=null )
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead.Value : null;
                _book.Rate = book.IsRead ? book.Rate.Value : null;
               // _book.Author = book.Author;
                _book.CoverUrl = book.CoverUrl;
                _context.SaveChanges();
            }
            return _book;
        }

        //-> Delete Book By ID 
        public void DeleteBookById(int bookId)
        {
            //first find book in database 
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            // if book is 
            if (_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();

            }
        }
    }
}
