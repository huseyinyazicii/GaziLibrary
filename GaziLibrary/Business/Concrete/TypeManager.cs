using GaziLibrary.Business.Abstract;
using GaziLibrary.Business.Results;
using GaziLibrary.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.Business.Concrete
{
    public class TypeManager : ITypeService
    {
        ITypeDal _typeDal;

        public TypeManager(ITypeDal typeDal)
        {
            _typeDal = typeDal;
        }

        public IResult Add(Entities.Concrete.Type type)
        {
            type.Name.ToUpper();
            _typeDal.Add(type);
            return new SuccessResult();
        }

        public IDataResult<List<Entities.Concrete.Type>> GetAllByStatus()
        {
            return new SuccessDataResult<List<Entities.Concrete.Type>>(_typeDal.GetAll(t => t.Status == true).OrderBy(t => t.Id).ToList());
        }

        public IDataResult<Entities.Concrete.Type> GetById(int id)
        {
            return new SuccessDataResult<Entities.Concrete.Type>(_typeDal.Get(t => t.Id == id));
        }

        public IResult Update(Entities.Concrete.Type type)
        {
            type.Name.ToUpper();
            _typeDal.Update(type);
            return new SuccessResult();
        }
    }
}
