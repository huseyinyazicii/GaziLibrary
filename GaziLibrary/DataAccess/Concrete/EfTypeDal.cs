using GaziLibrary.DataAccess.Abstract;
using GaziLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Type = GaziLibrary.Entities.Concrete.Type;

namespace GaziLibrary.DataAccess.Concrete
{
    public class EfTypeDal : EfEntityRepositoryBase<Type, OracleContext>, ITypeDal
    {
    }
}
