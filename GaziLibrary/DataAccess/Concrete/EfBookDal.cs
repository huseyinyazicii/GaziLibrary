using GaziLibrary.DataAccess.Abstract;
using GaziLibrary.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GaziLibrary.DataAccess.Concrete
{
    public class EfBookDal : EfEntityRepositoryBase<Book, OracleContext>, IBookDal
    {
        public List<Book> GetAllByFK(Expression<Func<Book, bool>> filter = null)
        {
            using (var context = new OracleContext())
            {
                return filter == null
                    ? context.Books.Include(b => b.Author).Include(b => b.Type).OrderBy(b => b.Id).ToList()
                    : context.Books.Include(b => b.Author).Include(b => b.Type).OrderBy(b => b.Id).Where(filter).ToList();
            }
        }

        public List<Book> GetAllByStatusWithFK(Expression<Func<Book, bool>> filter = null)
        {
            using (var context = new OracleContext())
            {
                return filter == null
                    ? context.Books.Include(b => b.Author).Include(b => b.Type).Where(b => b.Status == true).OrderBy(b => b.Id).ToList()
                    : context.Books.Include(b => b.Author).Include(b => b.Type).Where(b => b.Status == true).OrderBy(b => b.Id).Where(filter).ToList();
            }
        }
    }
}
