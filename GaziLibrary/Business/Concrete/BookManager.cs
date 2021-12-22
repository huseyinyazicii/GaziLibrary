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
    public class BookManager : IBookService
    {
        IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public IResult Add(Book book)
        {
            book.Name.ToUpper();
            _bookDal.Add(book);
            return new SuccessResult();
        }

        public IDataResult<List<Book>> GetAllBySearch(string search)
        {
            var result = _bookDal.GetAllByFK(b => b.Status == true && (b.Name.Contains(search.ToUpper()) || b.Author.FirstName.Contains(search.ToUpper()) || b.Author.LastName.Contains(search.ToUpper()) || b.Type.Name.Contains(search.ToUpper())));
            return new SuccessDataResult<List<Book>>(result);
        }

        public IDataResult<List<Book>> GetAllByStatus()
        {
            var result = _bookDal.GetAllByFK(b => b.Status == true);
            return new SuccessDataResult<List<Book>>(result);
        }

        public IDataResult<List<Book>> GetAllByStatusWithFK()
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAllByStatusWithFK());
        }

        public IDataResult<Book> GetById(int id)
        {
            return new SuccessDataResult<Book>(_bookDal.Get(b => b.Id == id));
        }

        public IDataResult<int> NumberOfBooksByAuthor(int authorId)
        {
            return new SuccessDataResult<int>(_bookDal.GetAll(b => b.AuthorId == authorId && b.Status == true).Count);
        }

        public IDataResult<int> NumberOfBooksByType(int typeId)
        {
            return new SuccessDataResult<int>(_bookDal.GetAll(b => b.TypeId == typeId && b.Status == true).Count);
        }

        public IResult Update(Book book)
        {
            book.Name.ToUpper();
            _bookDal.Update(book);
            return new SuccessResult();
        }
    }
}
