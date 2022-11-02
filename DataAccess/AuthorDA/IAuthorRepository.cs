using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.AuthorDA
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> getAuthors();
        Author getAuthor(int id);
        int addAuthor(Author author);
        int updateAuthor(Author author);
    }
}
