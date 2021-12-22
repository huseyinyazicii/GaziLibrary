using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GaziLibrary.Entities.Concrete;
using Type = GaziLibrary.Entities.Concrete.Type;

namespace GaziLibrary.DataAccess.Abstract
{
    public interface ITypeDal : IEntityRepository<Type>
    {
    }
}
