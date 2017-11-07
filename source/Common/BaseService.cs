using KadGen.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadGen.Common
{
    public abstract class BaseService<TDomain, TPKey> : IBaseService<TDomain, TPKey>
               where TPKey : struct
               where TDomain : class
    {
        private BaseRepository<TDomain, TPKey> _repository { get; }

        protected BaseService(BaseFactory<BaseRepository> factory)
        {
            _repository = (BaseRepository<TDomain, TPKey>)factory[typeof(TDomain)];
        }

        public virtual DataResult<TDomain> Get(TPKey id)
            => WithWrapper(() => _repository.Get(id));
        public virtual DataResult<IEnumerable<TDomain>> GetAll()
            => WithWrapper(_repository.GetAll);
        public virtual DataResult<TPKey> Create(TDomain domain)
            => WithWrapper(() => _repository.Create(domain));
        public virtual Result Update(TDomain domain)
            => WithWrapper(() => _repository.Update(domain));
        public virtual Result Delete(TDomain domain)
            => WithWrapper(() => _repository.Delete(domain));

        private TResult WithWrapper<TResult>(Func<TResult> operation)
                where TResult : Result
            => Handling.WithCommonHandling(()
              => operation());

    }
}
