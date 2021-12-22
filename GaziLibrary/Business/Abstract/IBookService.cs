using GaziLibrary.Business.Results;
using GaziLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.Business.Abstract
{
    public interface IBookService
    {
        IDataResult<List<Book>> GetAllByStatus();
        IDataResult<List<Book>> GetAllByStatusWithFK();
        IDataResult<List<Book>> GetAllBySearch(string search);
        IResult Add(Book book);
        IResult Update(Book book);
        IDataResult<Book> GetById(int id);
        IDataResult<int> NumberOfBooksByAuthor(int authorId);
        IDataResult<int> NumberOfBooksByType(int typeId);
    }
}
