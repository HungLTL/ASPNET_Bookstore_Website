using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.BookAuthorDA
{
    public interface IBookAuthorRepository
    {
        IEnumerable<Book>? getBooksByAuthor(Author author);
        IEnumerable<Book>? getBooksByAuthor(int authorId);
        IEnumerable<Author>? getAuthors(Book book);
        IEnumerable<Author>? getAuthors(int bookId);
        Bookauthor getBookauthor(Book book, Author author);
        Bookauthor getBookauthor(int bookId, int authorId);
        int addBookAuthor(Bookauthor bookauthor);
        int deleteBookAuthor(Bookauthor bookauthor);
    }
}
