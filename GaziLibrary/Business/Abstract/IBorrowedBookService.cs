using GaziLibrary.Business.Results;
using GaziLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.Business.Abstract
{
    public interface IBorrowedBookService
    {
        IDataResult<List<BorrowedBook>> GetAllByFK();
        IDataResult<List<BorrowedBook>> GetAllByStatusWithFK();
        IDataResult<List<BorrowedBook>> GetAllByStatus2WithFK();
        IDataResult<List<BorrowedBook>> GetAllByStatus();
        IResult Add(BorrowedBook borrowedBook);
        IResult Update(BorrowedBook borrowedBook);
        IResult Delete(BorrowedBook borrowedBook);
        IDataResult<BorrowedBook> GetById(int id);
        IDataResult<BorrowedBook> GetByUserId(int userId);
    }
}
