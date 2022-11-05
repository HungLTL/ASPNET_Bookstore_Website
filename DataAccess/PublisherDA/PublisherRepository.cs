using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.PublisherDA
{
    public class PublisherRepository : IPublisherRepository
    {
        public int addPublisher(Publisher publisher) => PublisherDAO.Instance.addPublisher(publisher);

        public Publisher getPublisher(int id) => PublisherDAO.Instance.getPublisher(id);

        public IEnumerable<Publisher> getPublishers() => PublisherDAO.Instance.getPublishers();

        public int updatePublisher(Publisher publisher) => PublisherDAO.Instance.updatePublisher(publisher);
    }
}
