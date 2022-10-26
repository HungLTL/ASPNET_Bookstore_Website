using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ReviewDA
{
    public class ReviewRepository : IReviewRepository
    {
        public void addReview(Review review) => ReviewDAO.Instance.addReview(review);

        public void deleteReview(Review review) => ReviewDAO.Instance.deleteReview(review);

        public Review getReview(Book book, User user) => ReviewDAO.Instance.getReview(book, user);

        public IEnumerable<Review> getReviews(Book book) => ReviewDAO.Instance.getReviews(book);

        public IEnumerable<Review> getReviews(User user) => ReviewDAO.Instance.getReviews(user);

        public void updateReview(Review review) => ReviewDAO.Instance.updateReview(review);
    }
}
