using GaziLibrary.Business.Results;
using GaziLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.Business.Abstract
{
    public interface IMessageService
    {
        IDataResult<List<Message>> GetAllByFK();
        IDataResult<List<Message>> GetAll();
        IDataResult<List<Message>> GetAllByStatusWithFK();
        IDataResult<List<Message>> GetAllByStatus2WithFK();
        IDataResult<Message> GetById(int id);
        IResult Update(Message message);
        IResult Add(Message message);
        IResult Delete(Message message);
    }
}
