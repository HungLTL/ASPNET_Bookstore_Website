using BusinessObjects;
using DataAccess.CategoryDA;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryRepository _repo;
        public CategoriesController(CategoryRepository repo)
        {
            _repo = repo;
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await Task.FromResult(_repo.getCategories().ToList());
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var book = await Task.FromResult(_repo.getCategory(id));
            if (book == null)
                return NotFound();
            else
                return Ok(book);
        }
    }
}
