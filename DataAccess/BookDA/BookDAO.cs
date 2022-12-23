using BusinessObjects;
using DataAccess.PublisherDA;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.BookDA
{
    public class BookDAO
    {
        private static BookDAO instance;
        private static readonly object instanceLock = new object();
        public static BookDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new BookDAO();
                    return instance;
                }
            }
        }

        public IEnumerable<Book> getBooks()
        {
            List<Book> books = new List<Book>();
            try
            {
                var context = new ffmlwpyhContext();
                books = context.Books.ToList();
            } catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return books;
        }

        public IEnumerable<Book> searchBooks(string? search,
            int? publishedYear,
            decimal? unitPrice,
            int? categoryId,
            string? publisher)
        {
            List<Book> books = new List<Book>();
            try
            {
                var context = new ffmlwpyhContext();
                books = context.Books.Where(
                    b => (search == null || b.Name.Contains(search))
                    && (publishedYear == null || b.PublishedYear == publishedYear)
                    && (unitPrice == null || b.UnitPrice <= unitPrice)
                    && (categoryId == null || b.CategoryId == categoryId)
                    && (publisher == null || b.PublisherId == PublisherDAO.Instance.getPublisher(publisher).Id))
                    .ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return books;
        }

        public Book getBook(int id)
        {
            Book book = null;
            try
            {
                var context = new ffmlwpyhContext();
                book = context.Books.SingleOrDefault(b => b.Id == id);
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return book;
        }

        public Book getBook(string name)
        {
            Book? book = null;
            try
            {
                var context = new ffmlwpyhContext();
                book = context.Books.SingleOrDefault(b => b.Name.Equals(name));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return book;
        }

        public int addBook(Book book)
        {
            Book _book = getBook(book.Id);
            if (_book == null)
            {
                try
                {
                    var context = new ffmlwpyhContext();
                    context.Books.Add(book);
                    context.SaveChanges();
                    return 1;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
            {
                Book _book1 = getBook(book.Name);
                if (_book1 == null)
                {
                    try
                    {
                        var context = new ffmlwpyhContext();
                        Book bk = new Book();
                        bk.Name = book.Name;
                        bk.Summary = book.Summary;
                        bk.PublishedYear = book.PublishedYear;
                        bk.UnitPrice = book.UnitPrice;
                        bk.Image = book.Image;
                        bk.CategoryId = book.CategoryId;
                        bk.PublisherId = book.PublisherId;
                        bk.Quantity = book.Quantity;
                        context.Books.Add(bk);
                        context.SaveChanges();
                        return 1;
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message);
                    }
                }
                else throw new Exception("Book already exists!");
            }
        }

        public int updateBook(Book book)
        {
            Book _book = getBook(book.Id);
            if (_book != null)
            {
                try
                {
                    var context = new ffmlwpyhContext();
                    context.Entry(book).State = EntityState.Modified;
                    context.SaveChanges();
                    return 1;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
                throw new Exception("Book doesn't exist!");
        }

        public int deleteBook(Book book)
        {
            Book _book = getBook(book.Id);
            if (_book != null)
            {
                try
                {
                    var context = new ffmlwpyhContext();
                    context.Books.Remove(book);
                    context.SaveChanges();
                    return 1;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
                throw new Exception("Book doesn't exist!");
        }
    }
}
