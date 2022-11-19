using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.PurchaseDA
{
    public interface IPurchaseRepository
    {
        IEnumerable<Purchase> getPurchases();
        IEnumerable<Purchase> getPurchases(User user);
        IEnumerable<Purchase> getPurchases(int userId);
        IEnumerable<Purchase> getPurchases(DateOnly from, DateOnly to);
        Purchase getPurchase(int id);
        int addPurchase(Purchase purchase);
        int updatePurchase(Purchase purchase);
        int deletePurchase(Purchase purchase);
    }
}
