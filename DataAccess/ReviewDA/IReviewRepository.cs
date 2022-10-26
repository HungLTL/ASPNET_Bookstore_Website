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
        void addReview(Review review);
        void updateReview(Review review);
        void deleteReview(Review review);
    }
}
