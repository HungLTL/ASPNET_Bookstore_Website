﻿using BusinessObjects;
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

        public void addDetail(PurchaseDetail detail) {
            PurchaseDetail _detail = getDetail(detail.Purchase, detail.Book);
            if (_detail == null)
            {
                try
                {
                    var context = new ffmlwpyhContext();
                    context.PurchaseDetails.Add(detail);
                    context.SaveChanges();
                } catch(Exception e)
                {
                    throw new Exception(e.Message);
                }
            } else
            {
                detail.Amount += _detail.Amount;
                updateDetail(detail);
            }
        }

        public void updateDetail(PurchaseDetail detail)
        {
            PurchaseDetail _detail = getDetail(detail.Purchase, detail.Book);
            if (_detail != null)
            {
                try
                {
                    var context = new ffmlwpyhContext();
                    context.Entry(detail).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
                throw new Exception("Detail doesn't exist!");
        }

        public void deleteDetail(PurchaseDetail detail)
        {
            PurchaseDetail _detail = getDetail(detail.Purchase, detail.Book);
            if (_detail != null)
            {
                try
                {
                    var context = new ffmlwpyhContext();
                    context.PurchaseDetails.Remove(detail);
                    context.SaveChanges();
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
