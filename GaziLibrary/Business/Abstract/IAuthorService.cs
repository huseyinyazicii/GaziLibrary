using GaziLibrary.Business.Results;
using GaziLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.Business.Abstract
{
    public interface IAuthorService
    {
        IDataResult<List<Author>> GetAllByStatus();
        IResult Add(Author author);
        IResult Update(Author author);
        IDataResult<Author> GetById(int id);
    }
}
