using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.PurchaseDA
{
    public class PurchaseDAO
    {
        private static PurchaseDAO instance;
        private static readonly object instanceLock = new object();
        public static PurchaseDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new PurchaseDAO();
                    return instance;
                }
            }
        }

        public IEnumerable<Purchase> getPurchases()
        {
            List<Purchase> purchases = new List<Purchase>();
            try
            {
                var context = new ffmlwpyhContext();
                purchases = context.Purchases.ToList();
            } catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return purchases;
        }

        public IEnumerable<Purchase> getPurchases(User user)
        {
            List<Purchase> purchases = new List<Purchase>();
            try
            {
                var context = new ffmlwpyhContext();
                purchases = context.Purchases.Where(p => p.UserId == user.Id).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return purchases;
        }

        public IEnumerable<Purchase> getPurchases(DateOnly from, DateOnly to)
        {
            List<Purchase> purchases = new List<Purchase>();
            try
            {
                var context = new ffmlwpyhContext();
                purchases = context.Purchases.Where(p => p.Date >= from && p.Date <= to).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return purchases;
        }

        public Purchase getPurchase(int id)
        {
            Purchase purchase = null;
            try
            {
                var context = new ffmlwpyhContext();
                purchase = context.Purchases.SingleOrDefault(p => p.Id == id);
            } catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return purchase;
        }

        public void addPurchse(Purchase purchase)
        {
            Purchase _purchase = getPurchase(purchase.Id);
            if (_purchase == null)
            {
                try
                {
                    var context = new ffmlwpyhContext();
                    context.Purchases.Add(purchase);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
                throw new Exception("Purchase already exists!");
        }

        public void updatePurchase(Purchase purchase)
        {
            Purchase _purchase = getPurchase(purchase.Id);
            if (_purchase != null)
            {
                try
                {
                    var context = new ffmlwpyhContext();
                    context.Entry(purchase).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
                throw new Exception("Purchase doesn't exist!");
        }

        public void deletePurchase(Purchase purchase)
        {
            Purchase _purchase = getPurchase(purchase.Id);
            if (_purchase != null)
            {
                try
                {
                    var context = new ffmlwpyhContext();
                    context.Purchases.Remove(purchase);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
                throw new Exception("Purchase doesn't exist!");
        }
    }
}
