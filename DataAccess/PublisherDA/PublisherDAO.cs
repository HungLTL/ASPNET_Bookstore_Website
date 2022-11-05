using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.PublisherDA
{
    public class PublisherDAO
    {
        private static PublisherDAO instance;
        private static readonly object instanceLock = new object();
        public static PublisherDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new PublisherDAO();
                    return instance;
                }
            }
        }

        public IEnumerable<Publisher> getPublishers()
        {
            List<Publisher> publishers;
            try
            {
                var context = new ffmlwpyhContext();
                publishers = context.Publishers.ToList();
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return publishers;
        }

        public Publisher getPublisher(int id)
        {
            Publisher publisher = null;
            try
            {
                var context = new ffmlwpyhContext();
                publisher = context.Publishers.SingleOrDefault(p => p.Id == id);
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return publisher;
        }

        public Publisher getPublisher(string search)
        {
            Publisher publisher = null;
            try
            {
                var context = new ffmlwpyhContext();
                publisher = context.Publishers.SingleOrDefault(p => p.Name.Contains(search));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return publisher;
        }

        public int addPublisher(Publisher publisher)
        {
            Publisher _publisher = getPublisher(publisher.Id);
            if (_publisher == null)
            {
                try
                {
                    var context = new ffmlwpyhContext();
                    context.Publishers.Add(publisher);
                    context.SaveChanges();
                    return 1;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else throw new Exception("Publisher already exists!");
        }

        public int updatePublisher(Publisher publisher)
        {
            Publisher _publisher = getPublisher(publisher.Id);
            if (_publisher != null)
            {
                try
                {
                    var context = new ffmlwpyhContext();
                    context.Entry(publisher).State = EntityState.Modified;
                    context.SaveChanges();
                    return 1;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else throw new Exception("Publisher doesn't exist!");
        }
    }
}
