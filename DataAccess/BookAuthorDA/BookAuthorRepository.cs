using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.BookAuthorDA
{
    public class BookAuthorRepository : IBookAuthorRepository
    {
        public int addBookAuthor(Bookauthor bookauthor) => BookAuthorDAO.Instance.addBookAuthor(bookauthor);

        public int deleteBookAuthor(Bookauthor bookauthor) => BookAuthorDAO.Instance.deleteBookAuthor(bookauthor);

        public IEnumerable<Author>? getAuthors(Book book) => BookAuthorDAO.Instance.getAuthors(book);

        public IEnumerable<Author>? getAuthors(int bookId) => BookAuthorDAO.Instance.getAuthors(bookId);

        public Bookauthor getBookauthor(Book book, Author author) => BookAuthorDAO.Instance.getBookAuthor(book, author);

        public Bookauthor getBookauthor(int bookId, int authorId) => BookAuthorDAO.Instance.getBookAuthor(bookId, authorId);

        public IEnumerable<Book>? getBooksByAuthor(Author author) => BookAuthorDAO.Instance.getBooksByAuthor(author);

        public IEnumerable<Book>? getBooksByAuthor(int authorId) => BookAuthorDAO.Instance.getBooksByAuthor(authorId);
    }
}
