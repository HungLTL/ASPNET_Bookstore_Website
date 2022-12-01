using BusinessObjects;
using DataAccess.PublisherDA;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherRepository _repo;
        public PublisherController (IPublisherRepository repo)
        {
            _repo = repo;
        }
        // GET: api/<PublisherController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publisher>>> GetPublishers()
        {
            return await Task.FromResult(_repo.getPublishers().ToList());
        }

        // GET api/<PublisherController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Publisher>> GetPublisher(int id)
        {
            var book = await Task.FromResult(_repo.getPublisher(id));
            if (book == null)
                return NotFound();
            else
                return Ok(book);
        }

        // POST api/<PublisherController>
        [HttpPost]
        public IActionResult PostPublisher(Publisher publisher)
        {
            if (_repo.addPublisher(publisher) == 1)
                return Ok();
            else
                return BadRequest();
        }

        // PUT api/<PublisherController>/5
        [HttpPut("{id}")]
        public IActionResult PutPublisher(int id, Publisher publisher)
        {
            if (id != publisher.Id)
                return BadRequest();

            if (_repo.updatePublisher(publisher) == 1)
                return Ok();
            else
                return NotFound();
        }
    }
}
