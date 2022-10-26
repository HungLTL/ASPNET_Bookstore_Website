using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.BookDA
{
    public class BookRepository : IBookRepository
    {
        public void addBook(Book book) => BookDAO.Instance.addBook(book);

        public void deleteBook(Book book) => BookDAO.Instance.deleteBook(book);

        public Book getBook(int id) => BookDAO.Instance.getBook(id);

        public IEnumerable<Book> getBooks() => BookDAO.Instance.getBooks();

        public IEnumerable<Book> searchBooks(string? search, int? publishedYear, decimal? unitPrice, int? category, string? publisher) => BookDAO.Instance.searchBooks(search, publishedYear, unitPrice, category, publisher);

        public void updateBook(Book book) => BookDAO.Instance.updateBook(book);
    }
}
