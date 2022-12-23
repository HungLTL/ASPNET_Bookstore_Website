using BusinessObjects;
using DataAccess.BookDA;
using DataAccess.UserDA;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ReviewDA
{
    public class ReviewDAO
    {
        private static ReviewDAO instance;
        private static readonly object instanceLock = new object();
        public static ReviewDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new ReviewDAO();
                    return instance;
                }
            }
        }

        public IEnumerable<Review> getReviews(Book book)
        {
            List<Review> reviews = new List<Review>();
            try
            {
                var context = new ffmlwpyhContext();
                reviews = context.Reviews.Where(r => r.BookId == book.Id).ToList();
            } catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return reviews;
        }

        public IEnumerable<Review> getReviewsByBook(int bookId)
        {
            Book book = BookDAO.Instance.getBook(bookId);
            if (book == null)
                throw new Exception("Book not found!");
            else
            {
                List<Review> reviews = new List<Review>();
                reviews = getReviews(book).ToList();
                if (reviews is null || reviews.Count == 0)
                    throw new Exception("Book doesn't have any reviews!");
                else
                    return reviews;
            }
        }

        public IEnumerable<Review> getReviews(User user)
        {
            List<Review> reviews = new List<Review>();
            try
            {
                var context = new ffmlwpyhContext();
                reviews = context.Reviews.Where(r => r.UserId == user.Id).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return reviews;
        }

        public IEnumerable<Review> getReviewsByUser(int userId)
        {
            User user = UserDAO.Instance.getUser(userId);
            if (user == null)
                throw new Exception("User not found!");
            else
            {
                List<Review> reviews = new List<Review>();
                reviews = getReviews(user).ToList();
                if (reviews is null || reviews.Count == 0)
                    throw new Exception("User hasn't made any reviews!");
                else
                    return reviews;
            }
        }

        public Review getReview(Book book, User user)
        {
            Review review = null;
            try
            {
                var context = new ffmlwpyhContext();
                review = context.Reviews.SingleOrDefault(r => r.BookId == book.Id && r.UserId == user.Id);
            } catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return review;
        }

        public Review getReview(int bookId, int userId)
        {
            Book book = BookDAO.Instance.getBook(bookId);
            if (book == null)
                throw new Exception("Book not found!");
            else
            {
                User user = UserDAO.Instance.getUser(userId);
                if (user == null)
                    throw new Exception("User not found!");
                else
                    return getReview(book, user);
            }
        }

        public int addReview(Review review)
        {
            Review _review = getReview(review.Book, review.User);
            if (_review == null)
            {
                try
                {
                    Review rev = new Review();
                    rev.UserId = review.UserId;
                    rev.BookId = review.BookId;
                    rev.Rating = review.Rating;
                    rev.Comment = review.Comment;

                    var context = new ffmlwpyhContext();
                    context.Reviews.Add(rev);
                    context.SaveChanges();
                    return 1;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
                throw new Exception("Review already exists!");
        }

        public int updateReview(Review review)
        {
            Review _review = getReview(review.Book, review.User);
            if (_review != null)
            {
                try
                {
                    var context = new ffmlwpyhContext();
                    context.Entry(review).State = EntityState.Modified;
                    context.SaveChanges();
                    return 1;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
                throw new Exception("Review doesn't exist!");
        }

        public int deleteReview(Review review)
        {
            Review _review = getReview(review.Book, review.User);
            if (_review != null)
            {
                try
                {
                    var context = new ffmlwpyhContext();
                    context.Reviews.Remove(review);
                    context.SaveChanges();
                    return 1;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
                throw new Exception("Review doesn't exist!");
        }
    }
}
