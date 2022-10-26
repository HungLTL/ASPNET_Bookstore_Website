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
        public void addBookAuthor(Bookauthor bookauthor) => BookAuthorDAO.Instance.addBookAuthor(bookauthor);

        public void deleteBookAuthor(Bookauthor bookauthor) => BookAuthorDAO.Instance.deleteBookAuthor(bookauthor);

        public IEnumerable<Author>? getAuthors(Book book) => BookAuthorDAO.Instance.getAuthors(book);

        public Bookauthor getBookauthor(Book book, Author author) => BookAuthorDAO.Instance.getBookAuthor(book, author);

        public IEnumerable<Book>? getBooksByAuthor(Author author) => BookAuthorDAO.Instance.getBooksByAuthor(author);
    }
}
