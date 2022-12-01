using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using DataAccess;
using DataAccess.AuthorDA;

namespace BookstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _repo;

        public AuthorsController(IAuthorRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            return await Task.FromResult(_repo.getAuthors().ToList());
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            var author = await Task.FromResult(_repo.getAuthor(id));
            if (author == null)
                return NotFound();
            else
                return Ok(author);
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutAuthor(int id, Author author)
        {
            if (id != author.Id)
                return BadRequest();

            if (_repo.updateAuthor(author) != 1)
                return NotFound();
            else
                return Ok();
        }

        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostAuthor(Author author)
        {
            if (_repo.addAuthor(author) == 1)
                return Ok();
            else
                return BadRequest();
        }
    }
}
