using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ReviewDA
{
    public interface IReviewRepository
    {
        IEnumerable<Review> getReviews(Book book);
        IEnumerable<Review> getReviews(User user);
        Review getReview(Book book, User user);
        IEnumerable<Review> getReviewsByBook(int bookId);
        IEnumerable<Review> getReviewsByUser(int userId);
        Review getReview(int bookId, int userId);
        int addReview(Review review);
        int updateReview(Review review);
        int deleteReview(Review review);
    }
}
