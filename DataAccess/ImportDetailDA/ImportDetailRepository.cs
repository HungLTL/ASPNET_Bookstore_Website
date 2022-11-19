using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ImportDetailDA
{
    public class ImportDetailRepository : IImportDetailRepository
    {
        public int addDetail(ImportDetail detail) => ImportDetailDAO.Instance.addDetail(detail);

        public int deleteDetail(ImportDetail detail) => ImportDetailDAO.Instance.deleteDetail(detail);

        public ImportDetail getDetail(Import import, Book book) => ImportDetailDAO.Instance.getDetail(import, book);

        public ImportDetail getDetail(int importId, int bookId) => ImportDetailDAO.Instance.getDetail(importId, bookId);

        public IEnumerable<ImportDetail> getDetails(Import import) => ImportDetailDAO.Instance.getDetails(import);

        public IEnumerable<ImportDetail> getDetails(int importId) => ImportDetailDAO.Instance.getDetails(importId);

        public IEnumerable<ImportDetail> getImports(Book book) => ImportDetailDAO.Instance.getImports(book);

        public IEnumerable<ImportDetail> getImports(int bookId) => ImportDetailDAO.Instance.getImports(bookId);

        public int updateDetail(ImportDetail detail) => ImportDetailDAO.Instance.updateDetail(detail);
    }
}
