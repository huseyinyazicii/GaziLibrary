using GaziLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<User> GetAllByFK();
        List<User> GetAllByStatusWithFK();
        User GetByUserName(string userName);
    }
}
