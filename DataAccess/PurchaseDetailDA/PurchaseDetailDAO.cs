using BusinessObjects;
using DataAccess.BookDA;
using DataAccess.PurchaseDA;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.PurchaseDetailDA
{
    public class PurchaseDetailDAO
    {
        private static PurchaseDetailDAO instance;
        private static readonly object instanceLock = new object();
        public static PurchaseDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new PurchaseDetailDAO();
                    return instance;
                }
            }
        }

        public IEnumerable<PurchaseDetail> getDetails(Purchase purchase)
        {
            List<PurchaseDetail> list = new List<PurchaseDetail>();
            try
            {
                var context = new ffmlwpyhContext();
                list = context.PurchaseDetails.Where(pd => pd.PurchaseId == purchase.Id).ToList();
            } catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

        public IEnumerable<PurchaseDetail> getDetails(int purchaseId)
        {
            Purchase purchase = PurchaseDAO.Instance.getPurchase(purchaseId);
            if (purchase == null)
                throw new Exception("Purchase not found!");
            else
            {
                List<PurchaseDetail> details = new List<PurchaseDetail>();
                details = getDetails(purchase).ToList();
                if (details is null || details.Count == 0)
                    throw new Exception("Empty purchase!");
                else return details;
            }
        }

        public IEnumerable<PurchaseDetail> getPurchases(Book book)
        {
            List<PurchaseDetail> list = new List<PurchaseDetail>();
            try
            {
                var context = new ffmlwpyhContext();
                list = context.PurchaseDetails.Where(pd => pd.BookId == book.Id).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

        public IEnumerable<PurchaseDetail> getPurchases(int bookId)
        {
            Book book = BookDAO.Instance.getBook(bookId);
            if (book == null)
                throw new Exception("Book not found!");
            else
            {
                List<PurchaseDetail> details = new List<PurchaseDetail>();
                details = getPurchases(book).ToList();
                if (details is null || details.Count == 0)
                    throw new Exception("Book has not been purchased by anyone!");
                else
                    return details;
            }
        }

        public PurchaseDetail getDetail(Purchase purchase, Book book)
        {
            PurchaseDetail detail = null;
            try
            {
                var context = new ffmlwpyhContext();
                detail = context.PurchaseDetails.SingleOrDefault(pd => pd.PurchaseId == purchase.Id && pd.BookId == book.Id);
            } catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return detail;
        }

        public PurchaseDetail getDetail(int purchaseId, int bookId)
        {
            Purchase purchase = PurchaseDAO.Instance.getPurchase(purchaseId);
            if (purchase == null)
                throw new Exception("Purchase not found!");
            else
            {
                Book book = BookDAO.Instance.getBook(bookId);
                if (book == null)
                    throw new Exception("Book not found!");
                else
                    return getDetail(purchase, book);
            }
        }

        public int addDetail(PurchaseDetail detail) {
            PurchaseDetail _detail = getDetail(detail.Purchase, detail.Book);
            if (_detail == null)
            {
                try
                {
                    var context = new ffmlwpyhContext();
                    context.PurchaseDetails.Add(detail);
                    context.SaveChanges();

                    Book book = BookDAO.Instance.getBook(detail.BookId);
                    if (detail.Amount != null)
                    {
                        book.Quantity -= detail.Amount.Value;
                        BookDAO.Instance.updateBook(book);
                    }
                    return 1;
                } catch(Exception e)
                {
                    throw new Exception(e.Message);
                }
            } else
            {
                detail.Amount += _detail.Amount;
                updateDetail(detail);
                return 1;
            }
        }

        public int updateDetail(PurchaseDetail detail)
        {
            PurchaseDetail _detail = getDetail(detail.Purchase, detail.Book);
            if (_detail != null)
            {
                try
                {
                    var context = new ffmlwpyhContext();
                    context.Entry(detail).State = EntityState.Modified;
                    context.SaveChanges();

                    Book book = BookDAO.Instance.getBook(detail.BookId);
                    if (detail.Amount != null)
                    {
                        book.Quantity -= detail.Amount.Value;
                        BookDAO.Instance.updateBook(book);
                    }
                    return 1;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
                throw new Exception("Detail doesn't exist!");
        }

        public int deleteDetail(PurchaseDetail detail)
        {
            PurchaseDetail _detail = getDetail(detail.Purchase, detail.Book);
            if (_detail != null)
            {
                try
                {
                    var context = new ffmlwpyhContext();
                    context.PurchaseDetails.Remove(detail);
                    context.SaveChanges();
                    return 1;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
                throw new Exception("Detail doesn't exist!");
        }
    }
}
