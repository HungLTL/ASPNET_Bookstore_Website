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
        private readonly IBookAuthorRepository _repo;
        public BookAuthorsController(IBookAuthorRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<BookAuthorsController>
        [HttpGet("authors/{book}")]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors(int book)
        {
            return await Task.FromResult(_repo.getAuthors(book).ToList());
        }

        // GET api/<BookAuthorsController>/5
        [HttpGet("books/{author}")]
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

        [HttpPost]
        public IActionResult PostBookAuthor(Bookauthor bookAuthor)
        {
            if (_repo.addBookAuthor(bookAuthor) == 1)
                return Ok();
            else
                return BadRequest();
        }

        // DELETE api/<BookAuthorsController>/5
        [HttpDelete("{book}/{author}")]
        public IActionResult Delete(int book, int author, Bookauthor bookAuthor)
        {
            if (book != bookAuthor.BookId || author != bookAuthor.AuthorId)
                return BadRequest();

            if (_repo.deleteBookAuthor(bookAuthor) == 1)
                return Ok();
            else
                return NotFound();
        }
    }
}
