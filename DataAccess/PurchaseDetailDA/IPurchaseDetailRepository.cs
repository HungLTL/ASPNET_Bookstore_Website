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
        IEnumerable<PurchaseDetail> getPurchases(Book book);
        PurchaseDetail getDetail(Purchase purchase, Book book);
        void addDetail(PurchaseDetail detail);
        void updateDetail(PurchaseDetail detail);
        void deleteDetail(PurchaseDetail detail);
    }
}
