using BusinessObjects;
using DataAccess.BookDA;
using DataAccess.ImportDA;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ImportDetailDA
{
    public class ImportDetailDAO
    {
        private static ImportDetailDAO instance;
        private static readonly object instanceLock = new object();
        public static ImportDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new ImportDetailDAO();
                    return instance;
                }
            }
        }

        public IEnumerable<ImportDetail> getDetails(Import import)
        {
            List<ImportDetail> details = new List<ImportDetail>();
            try
            {
                var context = new ffmlwpyhContext();
                details = context.ImportDetails.Where(d => d.ImportId == import.Id).ToList();
            } catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return details;
        }

        public IEnumerable<ImportDetail> getDetails(int importId)
        {
            Import import = ImportDAO.Instance.getImport(importId);
            if (import == null)
                throw new Exception("Import not found!");
            else
            {
                List<ImportDetail> details = new List<ImportDetail>();
                details = getDetails(import).ToList();
                if (details is null || details.Count == 0)
                    throw new Exception("Empty import!");
                else
                    return details;
            }
        }

        public IEnumerable<ImportDetail> getImports(Book book)
        {
            List<ImportDetail> details = new List<ImportDetail>();
            try
            {
                var context = new ffmlwpyhContext();
                details = context.ImportDetails.Where(d => d.BookId == book.Id).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return details;
        }

        public IEnumerable<ImportDetail> getImports(int bookId)
        {
            Book book = BookDAO.Instance.getBook(bookId);
            if (book == null)
                throw new Exception("Book not found!");
            else
            {
                List<ImportDetail> details = new List<ImportDetail>();
                details = getImports(book).ToList();
                if (details is null || details.Count == 0)
                    throw new Exception("Book was never imported into the store!");
                else
                    return details;
            }
        }

        public ImportDetail getDetail(Import import, Book book)
        {
            ImportDetail detail = null;
            try
            {
                var context = new ffmlwpyhContext();
                detail = context.ImportDetails.SingleOrDefault(d => d.ImportId == import.Id && d.BookId == book.Id);
            } catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return detail;
        }

        public ImportDetail getDetail(int importId, int bookId)
        {
            Import import = ImportDAO.Instance.getImport(importId);
            if (import == null)
                throw new Exception("Import not found!");
            else
            {
                Book book = BookDAO.Instance.getBook(bookId);
                if (book == null)
                    throw new Exception("Book not found!");
                else
                    return getDetail(import, book);
            }
        }

        public int addDetail(ImportDetail detail)
        {
            ImportDetail _detail = getDetail(detail.Import, detail.Book);
            if (detail == null)
            {
                try
                {
                    var context = new ffmlwpyhContext();
                    context.ImportDetails.Add(detail);
                    context.SaveChanges();

                    Book book = BookDAO.Instance.getBook(detail.BookId);
                    if (detail.Amount != null) {
                        book.Quantity += detail.Amount.Value;
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

        public int updateDetail(ImportDetail detail)
        {
            ImportDetail _detail = getDetail(detail.Import, detail.Book);
            if (detail != null)
            {
                try
                {
                    var context = new ffmlwpyhContext();
                    context.Entry(detail).State = EntityState.Modified;
                    context.SaveChanges();

                    Book book = BookDAO.Instance.getBook(detail.BookId);
                    if (detail.Amount != null)
                    {
                        book.Quantity += detail.Amount.Value;
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

        public int deleteDetail(ImportDetail detail)
        {
            ImportDetail _detail = getDetail(detail.Import, detail.Book);
            if (detail != null)
            {
                try
                {
                    var context = new ffmlwpyhContext();
                    context.ImportDetails.Remove(detail);
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
