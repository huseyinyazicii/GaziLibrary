using GaziLibrary.DataAccess.Abstract;
using GaziLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.DataAccess.Concrete
{
    public class EfAuthorDal : EfEntityRepositoryBase<Author, OracleContext>, IAuthorDal
    {
    }
}
