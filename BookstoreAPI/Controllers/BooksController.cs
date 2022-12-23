using BusinessObjects;
using DataAccess.BookDA;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _repo;
        public BooksController(IBookRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await Task.FromResult(_repo.getBooks().ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await Task.FromResult(_repo.getBook(id));
            if (book == null)
                return NotFound();
            else
                return Ok(book);
        }

        [HttpGet("{search?}/{year?}/{price?}/{category?}/{publisher?}")]
        public async Task<ActionResult<IEnumerable<Book>>> SearchBooks(string search = " ", int year = 1900, decimal price = 0, int category = 0, string publisher = " ")
        {
            return await Task.FromResult(_repo.searchBooks(search, year, price, category, publisher).ToList());
        }

        [HttpPost]
        public IActionResult PostBook(Book book)
        {
            if (_repo.addBook(book) == 1)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult PutBook(int id, Book book)
        {
            if (id != book.Id)
                return BadRequest();

            if (_repo.updateBook(book) == 1)
                return Ok();
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id, Book book)
        {
            if (id != book.Id)
                return BadRequest();

            if (_repo.deleteBook(book) == 1)
                return Ok();
            else
                return NotFound();
        }
    }
}
