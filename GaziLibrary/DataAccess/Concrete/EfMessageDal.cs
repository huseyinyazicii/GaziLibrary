using GaziLibrary.DataAccess.Abstract;
using GaziLibrary.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.DataAccess.Concrete
{
    public class EfMessageDal : EfEntityRepositoryBase<Message, OracleContext>, IMessageDal
    {
        public List<Message> GetAllByFK()
        {
            using (var context = new OracleContext())
            {
                return context.Messages.Include(m => m.User).OrderBy(m => m.Id).ToList();
            }
        }

        public List<Message> GetAllByStatus2WithFK()
        {
            using (var context = new OracleContext())
            {
                return context.Messages.Include(m => m.User).Where(m => m.Status == false).OrderBy(m => m.Id).ToList();
            }
        }

        public List<Message> GetAllByStatusWithFK()
        {
            using (var context = new OracleContext())
            {
                return context.Messages.Include(m => m.User).Where(m => m.Status == true).OrderBy(m => m.Id).ToList();
            }
        }
    }
}
