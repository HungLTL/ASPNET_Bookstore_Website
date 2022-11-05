using BusinessObjects;
using DataAccess.BookAuthorDA;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAuthorsController : ControllerBase
    {
        private readonly BookAuthorRepository _repo;
        public BookAuthorsController(BookAuthorRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<BookAuthorsController>
        [HttpGet("{book}")]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors(int book)
        {
            return await Task.FromResult(_repo.getAuthors(book).ToList());
        }

        // GET api/<BookAuthorsController>/5
        [HttpGet("{author}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksByAuthor(int author)
        {
            return await Task.FromResult(_repo.getBooksByAuthor(author).ToList());
        }

        // POST api/<BookAuthorsController>
        [HttpGet("{book}/{author}")]
        public async Task<ActionResult<Bookauthor>> GetBookAuthor(int book, int author)
        {
            var bookauthor = await Task.FromResult(_repo.getBookauthor(book, author));
            if (bookauthor == null)
                return NotFound();
            else
                return Ok(bookauthor);
        }

        // PUT api/<BookAuthorsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookAuthorsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
