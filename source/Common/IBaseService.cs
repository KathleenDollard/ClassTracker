using System.Collections.Generic;

namespace KadGen.Common
{
    public interface IBaseService<TDomain, TPKey>
        where TDomain : class
        where TPKey : struct
    {
        DataResult<TPKey> Create(TDomain domain);
        Result Delete(TDomain domain);
        DataResult<TDomain> Get(TPKey id);
        DataResult<IEnumerable<TDomain>> GetAll();
        Result Update(TDomain domain);
    }
}