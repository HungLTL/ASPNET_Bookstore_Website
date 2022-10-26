using BusinessObjects;

namespace DataAccess.ImportDetailDA
{
    public class ImportDetailRepositoryBase
    {

        public ImportDetail getDetail(Import import, Book book) => ImportDetailDAO.Instance.getDetail(import, book);
    }
}