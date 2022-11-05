using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.PublisherDA
{
    public interface IPublisherRepository
    {
        IEnumerable<Publisher> getPublishers();
        Publisher getPublisher(int id);
        int addPublisher(Publisher publisher);
        int updatePublisher(Publisher publisher);
    }
}
