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
        public void addDetail(ImportDetail detail) => ImportDetailDAO.Instance.addDetail(detail);

        public void deleteDetail(ImportDetail detail) => ImportDetailDAO.Instance.deleteDetail(detail);

        public ImportDetail getDetail(Import import, Book book) => ImportDetailDAO.Instance.getDetail(import, book);

        public IEnumerable<ImportDetail> getDetails(Import import) => ImportDetailDAO.Instance.getDetails(import);

        public IEnumerable<ImportDetail> getImports(Book book) => ImportDetailDAO.Instance.getImports(book);

        public void updateDetail(ImportDetail detail) => ImportDetailDAO.Instance.updateDetail(detail);
    }
}
