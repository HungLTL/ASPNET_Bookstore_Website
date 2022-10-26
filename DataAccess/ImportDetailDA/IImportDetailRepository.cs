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
        IEnumerable<ImportDetail> getImports(Book book);
        ImportDetail getDetail(Import import, Book book);
        void addDetail(ImportDetail detail);
        void updateDetail(ImportDetail detail);
        void deleteDetail(ImportDetail detail);
    }
}
