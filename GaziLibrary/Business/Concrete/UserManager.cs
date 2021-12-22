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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            user.LastName.ToUpper();
            user.FirstName.ToUpper();
            try
            {
                _userDal.Add(user);
                return new SuccessResult();
            }
            catch (Exception)
            {
                return new ErrorResult();
            }
        }

        public IDataResult<User> CheckUser(User user)
        {
            var result = _userDal.Get(u => u.UserName == user.UserName && u.Password == user.Password && u.Status == true);
            if (result == null)
            {
                return new ErrorDataResult<User>(result);
            }
            return new SuccessDataResult<User>(result);
        }

        public IResult CheckUsername(string userName)
        {
            var result = _userDal.Get(u => u.UserName == userName);
            if(result == null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<List<User>> GetAllByFK()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAllByFK());
        }

        public IDataResult<List<User>> GetAllByStatus()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.Status == true));
        }

        public IDataResult<List<User>> GetAllByStatusWithFK()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAllByStatusWithFK());
        }

        public IDataResult<User> GetById(int userId)
        {
            var result = _userDal.Get(u => u.Id == userId);
            if(result == null)
            {
                return new ErrorDataResult<User>(result);
            }
            return new SuccessDataResult<User>(result);
        }

        public IDataResult<User> GetByUsername(string userName)
        {
            return new SuccessDataResult<User>(_userDal.GetByUserName(userName));
        }

        public IDataResult<int> NumberOfUsersByPosition(int positionId)
        {
            return new SuccessDataResult<int>(_userDal.GetAll(u => u.PositionId == positionId && u.Status == true).Count);
        }

        public IResult Update(User user)
        {
            user.LastName.ToUpper();
            user.FirstName.ToUpper();
            _userDal.Update(user);
            return new SuccessResult();
        }
    }
}
