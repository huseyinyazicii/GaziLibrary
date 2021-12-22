using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.Business.Results
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
