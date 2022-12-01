using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.AuthorDA
{
    public class AuthorDAO
    {
        private static AuthorDAO instance;
        private static readonly object instanceLock = new object();
        public static AuthorDAO Instance
        {
            get
            {
                lock(instanceLock)
                {
                    if (instance == null)
                        instance = new AuthorDAO();
                    return instance;
                }
            }
        }

        public IEnumerable<Author> getAuthors()
        {
            List<Author> authors = new List<Author>();
            try
            {
                var context = new ffmlwpyhContext();
                authors = context.Authors.ToList();
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return authors;
        }

        public Author getAuthor(int id)
        {
            Author? author = null;
            try
            {
                var context = new ffmlwpyhContext();
                author = context.Authors.SingleOrDefault(a => a.Id == id);
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return author;
        }

        public int addAuthor(Author author)
        {
            Author _author = getAuthor(author.Id);
            if (_author == null)
            {
                try
                {
                    var context = new ffmlwpyhContext();
                    context.Authors.Add(author);
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
                throw new Exception("Author already exists!");
            }
        }

        public int updateAuthor(Author author)
        {
            Author _author = getAuthor(author.Id);
            if (_author != null)
            {
                try
                {
                    var context = new ffmlwpyhContext();
                    context.Entry(author).State = EntityState.Modified;
                    return 1;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
                throw new Exception("Author already exists!");
        }
    }
}
