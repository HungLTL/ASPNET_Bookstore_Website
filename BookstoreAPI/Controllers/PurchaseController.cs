using BusinessObjects;
using DataAccess.PurchaseDA;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly PurchaseRepository _repo;
        public PurchaseController(PurchaseRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetPurchases()
        {
            return await Task.FromResult(_repo.getPurchases().ToList());
        }

        [HttpGet("{user}")]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetPurchases(int user)
        {
            return await Task.FromResult(_repo.getPurchases(user).ToList());
        }

        [HttpGet("{startDate}/{endDate}")]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetPurchases(DateTime startDate, DateTime endDate)
        {
            return await Task.FromResult(_repo.getPurchases(DateOnly.FromDateTime(startDate), DateOnly.FromDateTime(endDate)).ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Purchase>> GetPurchase(int id)
        {
            var purchase = await Task.FromResult(_repo.getPurchase(id));
            if (purchase == null)
                return NotFound();
            else
                return Ok(purchase);
        }

        [HttpPost]
        public IActionResult PostPurchase(Purchase purchase)
        {
            if (_repo.addPurchase(purchase) == 1)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult PutPurchase(int id, Purchase purchase)
        {
            if (id != purchase.Id)
                return BadRequest();

            if (_repo.updatePurchase(purchase) == 1)
                return Ok();
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePurchase(int id, Purchase purchase)
        {
            if (id != purchase.Id)
                return BadRequest();

            if (_repo.deletePurchase(purchase) == 1)
                return Ok();
            else
                return NotFound();
        }
    }
}
