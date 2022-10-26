using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ImportDA
{
    public class ImportRepository : IImportRepository
    {
        public void addImport(Import import) => ImportDAO.Instance.addImport(import);

        public void deleteImport(Import import) => ImportDAO.Instance.deleteImport(import);

        public Import getImport(int id) => ImportDAO.Instance.getImport(id);

        public IEnumerable<Import> getImports() => ImportDAO.Instance.getImports();

        public IEnumerable<Import> getImports(DateOnly from, DateOnly to) => ImportDAO.Instance.getImports(from, to);

        public void updateImport(Import import) => ImportDAO.Instance.updateImport(import);
    }
}
