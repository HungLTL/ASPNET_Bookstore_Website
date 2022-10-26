using BusinessObjects;
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

        public void addReview(Review review)
        {
            Review _review = getReview(review.Book, review.User);
            if (_review == null)
            {
                try
                {
                    var context = new ffmlwpyhContext();
                    context.Reviews.Add(review);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
                throw new Exception("Review already exists!");
        }

        public void updateReview(Review review)
        {
            Review _review = getReview(review.Book, review.User);
            if (_review != null)
            {
                try
                {
                    var context = new ffmlwpyhContext();
                    context.Entry(review).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
                throw new Exception("Review doesn't exist!");
        }

        public void deleteReview(Review review)
        {
            Review _review = getReview(review.Book, review.User);
            if (_review != null)
            {
                try
                {
                    var context = new ffmlwpyhContext();
                    context.Reviews.Remove(review);
                    context.SaveChanges();
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
