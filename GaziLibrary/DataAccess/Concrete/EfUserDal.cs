using GaziLibrary.DataAccess.Abstract;
using GaziLibrary.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.DataAccess.Concrete
{
    public class EfUserDal : EfEntityRepositoryBase<User, OracleContext>, IUserDal
    {
        public List<User> GetAllByFK()
        {
            using (var context = new OracleContext())
            {
                return context.Users.Include(u => u.Position).OrderBy(u => u.Id).ToList();
            }
        }

        public List<User> GetAllByStatusWithFK()
        {
            using (var context = new OracleContext())
            {
                return context.Users.Include(u => u.Position).Where(u => u.Status == true).OrderBy(u => u.Id).ToList();
            }
        }

        public User GetByUserName(string userName)
        {
            using (var context = new OracleContext())
            {
                return context.Users.Include(u => u.Position).SingleOrDefault(u => u.UserName == userName);
            }
        }
    }
}
