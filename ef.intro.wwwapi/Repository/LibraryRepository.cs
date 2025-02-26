﻿using ef.intro.wwwapi.Context;
using ef.intro.wwwapi.Models;
using Microsoft.EntityFrameworkCore;

namespace ef.intro.wwwapi.Repository
{
    public class LibraryRepository : ILibraryRepository
    {
        public LibraryRepository()
        {

        }
        public bool AddAuthor(Author author)
        {
            using (var db = new LibraryContext())
            {
                db.Authors.Add(author);
                db.SaveChanges();
                return true;
            }
            return false;
        }



        public bool AddPublisher(Publisher publisher)
        {
            using (var db = new LibraryContext())
            {
                db.Publishers.Add(publisher);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public IEnumerable<Author> GetAllAuthors()
        {
            using (var db = new LibraryContext())
            {
                return db.Authors.Include(a => a.Books).ThenInclude(b => b.Publisher).ToList();
            }
            return null;
        }

        public IEnumerable<Publisher> GetAllPublishers()
        {
            using (var db = new LibraryContext())
            {
                return db.Publishers.ToList();
            }
            return null;
        }

        public bool AddBook(Book book)
        {
            using (var db = new LibraryContext())
            {
                db.Books.Add(book);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteAuthor(int id)
        {
            using (var db = new LibraryContext())
            {
                var author = db.Authors.FirstOrDefault(a => a.Id == id);
                if (author != null)
                {
                    db.Authors.Remove(author);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool DeleteBook(int id)
        {
            using (var db = new LibraryContext())
            {
                var book = db.Books.FirstOrDefault(a => a.Id == id);
                if (book != null)
                {
                    db.Books.Remove(book);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool DeletePublisher(int id)
        {
            using (var db = new LibraryContext())
            {
                var publisher = db.Publishers.FirstOrDefault(a => a.Id == id);
                if (publisher != null)
                {
                    db.Publishers.Remove(publisher);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }



        public IEnumerable<Book> GetAllBooks()
        {
            using (var db = new LibraryContext())
            {
                return db.Books.Include(x => x.Publisher).ToList();
            }
            return null;
        }

        public Author GetAuthor(int id)
        {
            Author result;
            using (var db = new LibraryContext())
            {
                return db.Authors.FirstOrDefault(a => a.Id == id);
            }
        }

        public Book GetBook(int id)
        {
            Book result;
            using (var db = new LibraryContext())
            {
                return db.Books.FirstOrDefault(a => a.Id == id);
            }
        }

        public Publisher GetPublisher(int id)
        {
            Publisher result;
            using (var db = new LibraryContext())
            {
                return db.Publishers.FirstOrDefault(a => a.Id == id);
            }
        }

        public bool UpdateAuthor(Author author)
        {
            using (var db = new LibraryContext())
            {
                db.Authors.Update(author);
                db.SaveChanges();
                return true;
            }
        }

        public bool UpdateBook(Book book)
        {
            using (var db = new LibraryContext())
            {
                db.Books.Update(book);
                db.SaveChanges();
                return true;
            }
        }

        public bool UpdatePublisher(Publisher publisher)
        {
            using (var db = new LibraryContext())
            {
                db.Publishers.Update(publisher);
                db.SaveChanges();
                return true;
            }
        }

    }
}
