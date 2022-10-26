using BusinessObjects;
using DataAccess.AuthorDA;
using DataAccess.BookDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.BookAuthorDA
{
    public class BookAuthorDAO
    {
        private static BookAuthorDAO instance;
        private static readonly object instanceLock = new object();
        public static BookAuthorDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new BookAuthorDAO();
                    return instance;
                }
            }
        }

        public IEnumerable<Book>? getBooksByAuthor(Author author)
        {
            List<Bookauthor> BookAuthors = new List<Bookauthor>();
            try
            {
                var context = new ffmlwpyhContext();
                BookAuthors = context.Bookauthors.Where(ba => ba.AuthorId == author.Id).ToList();
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (BookAuthors.Count == 0)
                return null;
            else
            {
                List<Book> books = new List<Book>();
                foreach (Bookauthor ba in BookAuthors)
                    books.Add(BookDAO.Instance.getBook(ba.BookId));

                return books;
            }
        }

        public IEnumerable<Author>? getAuthors(Book book)
        {
            List<Bookauthor> BookAuthors = new List<Bookauthor>();
            try
            {
                var context = new ffmlwpyhContext();
                BookAuthors = context.Bookauthors.Where(ba => ba.BookId == book.Id).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (BookAuthors.Count == 0)
                return null;
            else
            {
                List<Author> authors = new List<Author>();
                foreach (Bookauthor ba in BookAuthors)
                    authors.Add(AuthorDAO.Instance.getAuthor(ba.AuthorId));

                return authors;
            }
        }

        public Bookauthor getBookAuthor(Book book, Author author)
        {
            Bookauthor bookAuthor = null;
            try
            {
                var context = new ffmlwpyhContext();
                bookAuthor = context.Bookauthors.SingleOrDefault(ba => ba.BookId == book.Id && ba.AuthorId == author.Id);
            } catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return bookAuthor;
        }

        public void addBookAuthor(Bookauthor BookAuthor)
        {
            Book _book = BookDAO.Instance.getBook(BookAuthor.BookId);
            Author _author = AuthorDAO.Instance.getAuthor(BookAuthor.AuthorId);
            if (_book != null && _author != null)
            {
                if (getBookAuthor(_book, _author) == null)
                {
                    try
                    {
                        var context = new ffmlwpyhContext();
                        context.Bookauthors.Add(BookAuthor);
                        context.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message);
                    }
                }
                else
                    throw new Exception("This author is already working on this book!");
            }
            else
                throw new Exception("Book or author doesn't exist!");
        }

        public void deleteBookAuthor(Bookauthor BookAuthor)
        {
            Book _book = BookDAO.Instance.getBook(BookAuthor.BookId);
            Author _author = AuthorDAO.Instance.getAuthor(BookAuthor.AuthorId);
            if (_book != null && _author != null)
            {
                if (getBookAuthor(_book, _author) != null)
                {
                    try
                    {
                        var context = new ffmlwpyhContext();
                        context.Bookauthors.Remove(BookAuthor);
                        context.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message);
                    }
                }
                else
                    throw new Exception("This author isn't working on this book!");
            }
            else
                throw new Exception("Book or author doesn't exist!");
        }
    }
}
