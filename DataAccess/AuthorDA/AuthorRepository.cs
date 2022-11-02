using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.AuthorDA
{
    public class AuthorRepository : IAuthorRepository
    {
        public int addAuthor(Author author) => AuthorDAO.Instance.addAuthor(author);
        public Author getAuthor(int id) => AuthorDAO.Instance.getAuthor(id);

        public IEnumerable<Author> getAuthors() => AuthorDAO.Instance.getAuthors();

        public int updateAuthor(Author author) => AuthorDAO.Instance.updateAuthor(author);
    }
}
