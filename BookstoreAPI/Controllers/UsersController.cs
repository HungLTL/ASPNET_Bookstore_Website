using BusinessObjects;
using DataAccess.UserDA;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserRepository _repo;
        public UsersController(UserRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await Task.FromResult(_repo.getUsers().ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await Task.FromResult(_repo.getUser(id));
            if (user == null)
                return NotFound();
            else
                return Ok(user);
        }

        [HttpGet("{email}/{password}")]
        public async Task<ActionResult<User>> ValidateEmail(string email, string password)
        {
            var user = await Task.FromResult(_repo.validateEmail(email, password));
            if (user == null)
                return NotFound();
            else
                return Ok(user);
        }

        [HttpGet("{username}/{password}")]
        public async Task<ActionResult<User>> ValidateUser(string username, string password)
        {
            var user = await Task.FromResult(_repo.validateUser(username, password));
            if (user == null)
                return NotFound();
            else
                return Ok(user);
        }

        [HttpPost]
        public IActionResult PostUser(User user)
        {
            if (_repo.addUser(user) == 1)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult PutUser(int id, User user)
        {
            if (id != user.Id)
                return BadRequest();

            if (_repo.updateUser(user) == 1)
                return Ok();
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id, User user)
        {
            if (id != user.Id)
                return BadRequest();

            if (_repo.deleteUser(user) == 1)
                return Ok();
            else
                return NotFound();
        }
    }
}
