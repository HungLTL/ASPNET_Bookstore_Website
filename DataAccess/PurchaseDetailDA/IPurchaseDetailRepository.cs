using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.PurchaseDetailDA
{
    public interface IPurchaseDetailRepository
    {
        IEnumerable<PurchaseDetail> getDetails(Purchase purchase);
        IEnumerable<PurchaseDetail> getDetails(int purchaseId);
        IEnumerable<PurchaseDetail> getPurchases(Book book);
        IEnumerable<PurchaseDetail> getPurchases(int bookId);
        PurchaseDetail getDetail(Purchase purchase, Book book);
        PurchaseDetail getDetail(int purchaseId, int bookId);
        int addDetail(PurchaseDetail detail);
        int updateDetail(PurchaseDetail detail);
        int deleteDetail(PurchaseDetail detail);
    }
}
