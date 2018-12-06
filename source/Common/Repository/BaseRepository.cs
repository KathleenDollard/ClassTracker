using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace KadGen.Common.Repository
{
    public abstract class BaseRepository
    { }

    public abstract class BaseRepository<TDomain, TPKey> : BaseRepository
               where TPKey : struct
               where TDomain : class
    {
        protected string PKeyName;

        public abstract DataResult<TDomain> Get(TPKey id);
        public abstract DataResult<IEnumerable<TDomain>> GetAll();
        public abstract DataResult<TPKey> Create(TDomain domain);
        public abstract Result Update(TDomain domain);
        public abstract Result Delete(TDomain domain);

        public BaseRepository(string pKeyName) 
            => PKeyName = pKeyName;
    }

}
