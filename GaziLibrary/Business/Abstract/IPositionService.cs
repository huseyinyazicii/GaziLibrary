using GaziLibrary.Business.Results;
using GaziLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.Business.Abstract
{
    public interface IPositionService
    {
        IDataResult<List<Position>> GetAllByStatus();
        IResult Add(Position position);
        IResult Update(Position position);
        IDataResult<Position> GetById(int id);
        IDataResult<Position> GetByName(string positionName);
    }
}
