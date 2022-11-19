using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.PurchaseDA
{
    public class PurchaseRepository : IPurchaseRepository
    {
        public int addPurchase(Purchase purchase) => PurchaseDAO.Instance.addPurchse(purchase);

        public int deletePurchase(Purchase purchase) => PurchaseDAO.Instance.deletePurchase(purchase);

        public Purchase getPurchase(int id) => PurchaseDAO.Instance.getPurchase(id);

        public IEnumerable<Purchase> getPurchases() => PurchaseDAO.Instance.getPurchases();

        public IEnumerable<Purchase> getPurchases(User user) => PurchaseDAO.Instance.getPurchases(user);

        public IEnumerable<Purchase> getPurchases(DateOnly from, DateOnly to) => PurchaseDAO.Instance.getPurchases(from, to);

        public IEnumerable<Purchase> getPurchases(int userId) => PurchaseDAO.Instance.getPurchases(userId);

        public int updatePurchase(Purchase purchase) => PurchaseDAO.Instance.updatePurchase(purchase);
    }
}
