using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ImportDA
{
    public class ImportDAO
    {
        private static ImportDAO instance;
        private static readonly object instanceLock = new object();
        public static ImportDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new ImportDAO();
                    return instance;
                }
            }
        }

        public IEnumerable<Import> getImports()
        {
            List<Import> imports = new List<Import>();
            try
            {
                var context = new ffmlwpyhContext();
                imports = context.Imports.ToList();
            } catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return imports;
        }

        public IEnumerable<Import> getImports(DateOnly from, DateOnly to)
        {
            List<Import> imports = new List<Import>();
            try
            {
                var context = new ffmlwpyhContext();
                imports = context.Imports.Where(i => i.Date >= from && i.Date <= to).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return imports;
        }

        public Import getImport(int id)
        {
            Import import = null;
            try
            {
                var context = new ffmlwpyhContext();
                import = context.Imports.SingleOrDefault(i => i.Id == id);
            } catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return import;
        }

        public int addImport(Import import)
        {
            Import _import = getImport(import.Id);
            if (_import == null)
            {
                try
                {
                    var context = new ffmlwpyhContext();
                    context.Imports.Add(import);
                    context.SaveChanges();
                    return 1;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
            {
                try
                {
                    var context = new ffmlwpyhContext();
                    int newId = context.Imports.OrderByDescending(i => i.Id).FirstOrDefault().Id + 1;
                    import.Id = newId;
                    context.Imports.Add(import);
                    context.SaveChanges();
                    return 1;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        public int updateImport(Import import)
        {
            Import _import = getImport(import.Id);
            if (_import != null)
            {
                try
                {
                    var context = new ffmlwpyhContext();
                    context.Entry(import).State = EntityState.Modified;
                    context.SaveChanges();
                    return 1;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
                throw new Exception("Import doesn't exist!");
        }

        public int deleteImport(Import import)
        {
            Import _import = getImport(import.Id);
            if (_import != null)
            {
                try
                {
                    var context = new ffmlwpyhContext();
                    context.Imports.Remove(import);
                    context.SaveChanges();
                    return 1;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
                throw new Exception("Import doesn't exist!");
        }
    }

}
