using BusinessObjects;
using DataAccess.ReviewDA;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _repo;
        public ReviewController(IReviewRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{book}")]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviewsByBook(int book)
        {
            return await Task.FromResult(_repo.getReviewsByBook(book).ToList());
        }

        [HttpGet("{user}")]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviewsByUser(int user)
        {
            return await Task.FromResult(_repo.getReviewsByUser(user).ToList());
        }

        [HttpGet("{book}/{user}")]
        public async Task<ActionResult<Review>> GetReview(int book, int user)
        {
            var review = await Task.FromResult(_repo.getReview(book, user));
            if (review == null)
                return NotFound();
            else
                return Ok(review);
        }

        [HttpPost]
        public IActionResult PostReview(Review review)
        {
            if (_repo.addReview(review) == 1)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut("{book}/{user}")]
        public IActionResult PutReview(int book, int user, Review review)
        {
            if (book != review.BookId || user != review.UserId)
                return BadRequest();

            if (_repo.updateReview(review) == 1)
                return Ok();
            else
                return NotFound();
        }

        [HttpDelete("{book}/{user}")]
        public IActionResult DeleteReview(int book, int user, Review review)
        {
            if (book != review.BookId || user != review.UserId)
                return BadRequest();

            if (_repo.deleteReview(review) == 1)
                return Ok();
            else
                return NotFound();
        }
    }
}
