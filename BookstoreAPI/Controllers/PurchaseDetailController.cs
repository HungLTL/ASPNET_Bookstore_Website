using BusinessObjects;
using DataAccess.PurchaseDetailDA;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseDetailController : ControllerBase
    {
        private readonly IPurchaseDetailRepository _repo;
        public PurchaseDetailController(IPurchaseDetailRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{purchase}")]
        public async Task<ActionResult<IEnumerable<PurchaseDetail>>> GetDetails(int purchase)
        {
            return await Task.FromResult(_repo.getDetails(purchase).ToList());
        }

        [HttpGet("{book}")]
        public async Task<ActionResult<IEnumerable<PurchaseDetail>>> GetPurchases(int book)
        {
            return await Task.FromResult(_repo.getPurchases(book).ToList());
        }

        [HttpGet("{purchase}/{book}")]
        public async Task<ActionResult<PurchaseDetail>> GetDetail(int purchase, int book)
        {
            var detail = await Task.FromResult(_repo.getDetail(purchase, book));
            if (detail == null)
                return NotFound();
            else
                return Ok(detail);
        }

        [HttpPost]
        public IActionResult PostPurchaseDetail(PurchaseDetail detail)
        {
            if (_repo.addDetail(detail) == 1)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut("{purchase}/{book}")]
        public IActionResult PutPurchaseDetail(int purchase, int book, PurchaseDetail detail)
        {
            if (purchase != detail.PurchaseId || book != detail.BookId)
                return BadRequest();

            if (_repo.updateDetail(detail) == 1)
                return Ok();
            else
                return NotFound();
        }

        [HttpDelete("{purchase}/{book}")]
        public IActionResult DeletePurchaseDetail(int purchase, int book, PurchaseDetail detail)
        {
            if (purchase != detail.PurchaseId || book != detail.BookId)
                return BadRequest();

            if (_repo.deleteDetail(detail) == 1)
                return Ok();
            else
                return NotFound();
        }
    }
}
