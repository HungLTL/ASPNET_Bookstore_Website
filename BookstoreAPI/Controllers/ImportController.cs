using BusinessObjects;
using DataAccess.ImportDA;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportController : ControllerBase
    {
        private readonly IImportRepository _repo;
        public ImportController(IImportRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Import>>> GetImports()
        {
            return await Task.FromResult(_repo.getImports().ToList());
        }

        [HttpGet("{startDate}/{endDate}")]
        public async Task<ActionResult<IEnumerable<Import>>> GetImports(DateTime startDate, DateTime endDate)
        {
            return await Task.FromResult(_repo.getImports(DateOnly.FromDateTime(startDate), DateOnly.FromDateTime(endDate)).ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Import>> GetImport(int id)
        {
            var import = await Task.FromResult(_repo.getImport(id));
            if (import == null)
                return NotFound();
            else
                return Ok(import);
        }

        [HttpPost]
        public IActionResult PostImport(Import import)
        {
            if (_repo.addImport(import) == 1)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult PutImport(int id, Import import)
        {
            if (id != import.Id)
                return BadRequest();

            if (_repo.updateImport(import) == 1)
                return Ok();
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteImport(int id, Import import)
        {
            if (id != import.Id)
                return BadRequest();

            if (_repo.deleteImport(import) == 1)
                return Ok();
            else
                return NotFound();
        }
    }
}
