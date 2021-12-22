using GaziLibrary.Business.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Type = GaziLibrary.Entities.Concrete.Type;

namespace GaziLibrary.Business.Abstract
{
    public interface ITypeService
    {
        IDataResult<List<Type>> GetAllByStatus();
        IResult Add(Type type);
        IResult Update(Type type);
        IDataResult<Type> GetById(int id);
    }
}
