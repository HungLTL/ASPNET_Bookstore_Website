using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.PurchaseDetailDA
{
    public class PurchaseDetailRepository : IPurchaseDetailRepository
    {
        public int addDetail(PurchaseDetail detail) => PurchaseDetailDAO.Instance.addDetail(detail);

        public int deleteDetail(PurchaseDetail detail) => PurchaseDetailDAO.Instance.deleteDetail(detail);

        public PurchaseDetail getDetail(Purchase purchase, Book book) => PurchaseDetailDAO.Instance.getDetail(purchase, book);
        public PurchaseDetail getDetail(int purchaseId, int bookId) => PurchaseDetailDAO.Instance.getDetail(purchaseId, bookId);

        public IEnumerable<PurchaseDetail> getDetails(Purchase purchase) => PurchaseDetailDAO.Instance.getDetails(purchase);
        public IEnumerable<PurchaseDetail> getDetails(int purchaseId) => PurchaseDetailDAO.Instance.getDetails(purchaseId);

        public IEnumerable<PurchaseDetail> getPurchases(Book book) => PurchaseDetailDAO.Instance.getPurchases(book);
        public IEnumerable<PurchaseDetail> getPurchases(int bookId) => PurchaseDetailDAO.Instance.getPurchases(bookId);

        public int updateDetail(PurchaseDetail detail) => PurchaseDetailDAO.Instance.updateDetail(detail);
    }
}
