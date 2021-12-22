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
    public class AuthorManager : IAuthorService
    {
        IAuthorDal _authorDal;

        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        public IResult Add(Author author)
        {
            author.FirstName.ToUpper();
            author.LastName.ToUpper();
            _authorDal.Add(author);
            return new SuccessResult();
        }

        public IDataResult<List<Author>> GetAllByStatus()
        {
            return new SuccessDataResult<List<Author>>(_authorDal.GetAll(a => a.Status == true));
        }

        public IDataResult<Author> GetById(int id)
        {
            return new SuccessDataResult<Author>(_authorDal.Get(a => a.Id == id));
        }

        public IResult Update(Author author)
        {
            author.FirstName.ToUpper();
            author.LastName.ToUpper();
            _authorDal.Update(author);
            return new SuccessResult();
        }
    }
}
