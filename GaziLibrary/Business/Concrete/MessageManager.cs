using GaziLibrary.Business.Abstract;
using GaziLibrary.Business.Results;
using GaziLibrary.DataAccess.Abstract;
using GaziLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.Business.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public IResult Add(Message message)
        {
            _messageDal.Add(message);
            return new SuccessResult();
        }

        public IResult Delete(Message message)
        {
            _messageDal.Delete(message);
            return new SuccessResult();
        }

        public IDataResult<List<Message>> GetAll()
        {
            return new SuccessDataResult<List<Message>>(_messageDal.GetAll());
        }

        public IDataResult<List<Message>> GetAllByFK()
        {
            return new SuccessDataResult<List<Message>>(_messageDal.GetAllByFK());
        }

        public IDataResult<List<Message>> GetAllByStatus2WithFK()
        {
            return new SuccessDataResult<List<Message>>(_messageDal.GetAllByStatus2WithFK());
        }

        public IDataResult<List<Message>> GetAllByStatusWithFK()
        {
            return new SuccessDataResult<List<Message>>(_messageDal.GetAllByStatusWithFK());
        }

        public IDataResult<Message> GetById(int id)
        {
            return new SuccessDataResult<Message>(_messageDal.Get(m => m.Id == id));
        }

        public IResult Update(Message message)
        {
            _messageDal.Update(message);
            return new SuccessResult();
        }
    }
}
