using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.BookDA
{
    public interface IBookRepository
    {
        IEnumerable<Book> getBooks();
        IEnumerable<Book> searchBooks(string? search, int? publishedYear, decimal? unitPrice, int? category, string? publisher);
        Book getBook(int id);
        void addBook(Book book);
        void updateBook(Book book);
        void deleteBook(Book book);
    }
}
