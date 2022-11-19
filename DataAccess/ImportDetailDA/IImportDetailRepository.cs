using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ImportDetailDA
{
    public interface IImportDetailRepository
    {
        IEnumerable<ImportDetail> getDetails(Import import);
        IEnumerable<ImportDetail> getDetails(int importId);
        IEnumerable<ImportDetail> getImports(Book book);
        IEnumerable<ImportDetail> getImports(int bookId);
        ImportDetail getDetail(Import import, Book book);
        ImportDetail getDetail(int importId, int bookId);
        int addDetail(ImportDetail detail);
        int updateDetail(ImportDetail detail);
        int deleteDetail(ImportDetail detail);
    }
}
