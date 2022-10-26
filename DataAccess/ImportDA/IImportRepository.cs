using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ImportDA
{
    public interface IImportRepository
    {
        IEnumerable<Import> getImports();
        IEnumerable<Import> getImports(DateOnly from, DateOnly to);
        Import getImport(int id);
        void addImport(Import import);
        void updateImport(Import import);
        void deleteImport(Import import);
    }
}
