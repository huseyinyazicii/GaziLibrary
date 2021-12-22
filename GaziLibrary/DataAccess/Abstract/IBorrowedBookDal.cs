using GaziLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.DataAccess.Abstract
{
    public interface IBorrowedBookDal : IEntityRepository<BorrowedBook>
    {
        List<BorrowedBook> GetAllByFK();
        BorrowedBook GetByFK(int userId);
        List<BorrowedBook> GetAllByStatusWithFK();
        List<BorrowedBook> GetAllByStatus2WithFK();
    }
}
