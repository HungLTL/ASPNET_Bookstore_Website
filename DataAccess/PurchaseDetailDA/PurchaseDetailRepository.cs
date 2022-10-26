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
        public void addDetail(PurchaseDetail detail) => PurchaseDetailDAO.Instance.addDetail(detail);

        public void deleteDetail(PurchaseDetail detail) => PurchaseDetailDAO.Instance.deleteDetail(detail);

        public PurchaseDetail getDetail(Purchase purchase, Book book) => PurchaseDetailDAO.Instance.getDetail(purchase, book);

        public IEnumerable<PurchaseDetail> getDetails(Purchase purchase) => PurchaseDetailDAO.Instance.getDetails(purchase);

        public IEnumerable<PurchaseDetail> getPurchases(Book book) => PurchaseDetailDAO.Instance.getPurchases(book);

        public void updateDetail(PurchaseDetail detail) => PurchaseDetailDAO.Instance.updateDetail(detail);
    }
}
