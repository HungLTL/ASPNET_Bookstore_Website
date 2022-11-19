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
        public int addReview(Review review) => ReviewDAO.Instance.addReview(review);

        public int deleteReview(Review review) => ReviewDAO.Instance.deleteReview(review);

        public Review getReview(Book book, User user) => ReviewDAO.Instance.getReview(book, user);

        public Review getReview(int bookId, int userId) => ReviewDAO.Instance.getReview(bookId, userId);

        public IEnumerable<Review> getReviews(Book book) => ReviewDAO.Instance.getReviews(book);

        public IEnumerable<Review> getReviews(User user) => ReviewDAO.Instance.getReviews(user);

        public IEnumerable<Review> getReviewsByBook(int bookId) => ReviewDAO.Instance.getReviewsByBook(bookId);
        public IEnumerable<Review> getReviewsByUser(int userId) => ReviewDAO.Instance.getReviewsByUser(userId);

        public int updateReview(Review review) => ReviewDAO.Instance.updateReview(review);
    }
}
