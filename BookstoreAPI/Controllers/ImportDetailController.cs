using BusinessObjects;
using DataAccess.ImportDetailDA;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportDetailController : ControllerBase
    {
        private readonly IImportDetailRepository _repo;
        public ImportDetailController(IImportDetailRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{import}")]
        public async Task<ActionResult<IEnumerable<ImportDetail>>> GetDetails(int import)
        {
            return await Task.FromResult(_repo.getDetails(import).ToList());
        }

        [HttpGet("{book}")]
        public async Task<ActionResult<IEnumerable<ImportDetail>>> GetPurchases(int book)
        {
            return await Task.FromResult(_repo.getImports(book).ToList());
        }

        [HttpGet("{import}/{book}")]
        public async Task<ActionResult<ImportDetail>> GetDetail(int import, int book)
        {
            var detail = await Task.FromResult(_repo.getDetail(import, book));
            if (detail == null)
                return NotFound();
            else
                return Ok(detail);
        }

        [HttpPost]
        public IActionResult PostImportDetail(ImportDetail detail)
        {
            if (_repo.addDetail(detail) == 1)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut("{import}/{book}")]
        public IActionResult PutImportDetail(int import, int book, ImportDetail detail)
        {
            if (import != detail.ImportId || book != detail.BookId)
                return BadRequest();

            if (_repo.updateDetail(detail) == 1)
                return Ok();
            else
                return NotFound();
        }

        [HttpDelete("{import}/{book}")]
        public IActionResult DeleteImportDetail(int import, int book, ImportDetail detail)
        {
            if (import != detail.ImportId|| book != detail.BookId)
                return BadRequest();

            if (_repo.deleteDetail(detail) == 1)
                return Ok();
            else
                return NotFound();
        }
    }
}
