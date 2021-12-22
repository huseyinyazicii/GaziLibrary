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
    public class BorrowedBookManager : IBorrowedBookService
    {
        IBorrowedBookDal _borrowedBook;

        public BorrowedBookManager(IBorrowedBookDal borrowedBook)
        {
            _borrowedBook = borrowedBook;
        }

        public IResult Add(BorrowedBook borrowedBook)
        {
            _borrowedBook.Add(borrowedBook);
            return new SuccessResult();
        }

        public IResult Delete(BorrowedBook borrowedBook)
        {
            _borrowedBook.Delete(borrowedBook);
            return new SuccessResult();
        }

        public IDataResult<List<BorrowedBook>> GetAllByFK()
        {
            return new SuccessDataResult<List<BorrowedBook>>(_borrowedBook.GetAllByFK());
        }

        public IDataResult<List<BorrowedBook>> GetAllByStatus()
        {
            return new SuccessDataResult<List<BorrowedBook>>(_borrowedBook.GetAll(b => b.Status == true));
        }

        public IDataResult<List<BorrowedBook>> GetAllByStatus2WithFK()
        {
            return new SuccessDataResult<List<BorrowedBook>>(_borrowedBook.GetAllByStatus2WithFK());
        }

        public IDataResult<List<BorrowedBook>> GetAllByStatusWithFK()
        {
            return new SuccessDataResult<List<BorrowedBook>>(_borrowedBook.GetAllByStatusWithFK());
        }

        public IDataResult<BorrowedBook> GetById(int id)
        {
            return new SuccessDataResult<BorrowedBook>(_borrowedBook.Get(b => b.Id == id));
        }

        public IDataResult<BorrowedBook> GetByUserId(int userId)
        {
            var result = _borrowedBook.GetByFK(userId);
            if(result == null)
            {
                return new ErrorDataResult<BorrowedBook>(result);
            }
            return new SuccessDataResult<BorrowedBook>(result);
        }

        public IResult Update(BorrowedBook borrowedBook)
        {
            _borrowedBook.Update(borrowedBook);
            return new SuccessResult();
        }
    }
}
