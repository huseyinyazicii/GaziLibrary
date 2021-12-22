using GaziLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.DataAccess.Abstract
{
    public interface IMessageDal : IEntityRepository<Message>
    {
        List<Message> GetAllByFK();
        List<Message> GetAllByStatusWithFK();
        List<Message> GetAllByStatus2WithFK();
    }
}
