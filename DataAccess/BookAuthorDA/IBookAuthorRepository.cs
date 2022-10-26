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
        IEnumerable<Author>? getAuthors(Book book);
        Bookauthor getBookauthor(Book book, Author author);
        void addBookAuthor(Bookauthor bookauthor);
        void deleteBookAuthor(Bookauthor bookauthor);
    }
}
