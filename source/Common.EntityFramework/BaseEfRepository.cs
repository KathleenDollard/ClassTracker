using KadGen.Common.ResultExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KadGen.Common.Repository
{
    public class BaseEfRepository<TDbContext, TDomain, TPKey, TEntity>
        : BaseMappedRepository<TDomain, TPKey, TEntity>
            where TPKey : struct
            where TDomain : class, IDomain<TPKey>
            where TEntity : class, new()
            where TDbContext : DbContext
    {
        private TDbContext _dbContext;

        public BaseEfRepository(
                TDbContext dbContext,
                Expression<Func<TEntity, TPKey>> getPKey,
                Func<TEntity, TDomain> mapEntityToDomain,
                Action<TDomain, TEntity> mapDomainToEntity)
            : base(getPKey, mapEntityToDomain, mapDomainToEntity)
        {
            _dbContext = dbContext;
        }

        public override DataResult<TDomain> Get(TPKey id)
        {
            try
            {
                var dbSet = _dbContext.Set<TEntity>();
                var entity = dbSet.Find(id);
                var domain = MapEntityToDomain(entity);
                var result = DataResult<TDomain>.CreateSuccessResult(domain);
                return result;
            }
            catch (Exception ex)
            {
                return Result.CreateErrorResult<DataResult<TDomain>>(new Error(ErrorCode.ExceptionThrown, ex, null));
            }
        }

        public override DataResult<IEnumerable<TDomain>> GetAll()
            => _dbContext.Set<TEntity>()
                    .ToList()
                    .Map(x => MapEntityToDomain(x)) // Prefer map because can't be run against DB
                    .ToList()
                    .Select(x => x)
                    .CreateSuccessResult();

        public async Task<DataResult<IEnumerable<TDomain>>> GetAllAsync()
        {
            return (await _dbContext.Set<TEntity>()
                    .ToListAsync())
                    .Map(x => MapEntityToDomain(x))
                    .ToList()
                    .Select(x => x)
                    .CreateSuccessResult();
        }

        public override DataResult<TPKey> Create(TDomain domain)

        {
            var dbSet = _dbContext.Set<TEntity>();
            var entity = new TEntity();
            domain.Map(MapDomainToEntity, entity);
            dbSet.Add(entity);
            _dbContext.SaveChanges();
            return GetPKey(entity)
                    .CreateSuccessResult();
        }

        public override Result Update(TDomain domain)
        {
            var dbSet = _dbContext.Set<TEntity>();
            var entity = dbSet.Where(GetPKeyWhereClause(domain.Id))
                                                .SingleOrDefault();
            domain.Map(MapDomainToEntity, entity);
            dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return Result.CreateSuccessResult<Result>();
        }

        public override Result Delete(TDomain domain)
        {
            var entity = new TEntity();
            domain.Map(MapDomainToEntity, entity);
            var entry = _dbContext.Entry(entity);
            entry.State = EntityState.Deleted;
            _dbContext.SaveChanges();
            return Result.CreateSuccessResult<Result>();
        }

        // NOTE: The following are not pulic because TEntity is not available outside the layer
        protected override DataResult<TDomain> GetWhere(Expression<Func<TEntity, bool>> filter)
           => _dbContext.Set<TEntity>()
                            .Where(filter)
                            .SingleOrDefault()
                            .Map(MapEntityToDomain)
                            .CreateSuccessResult();

        protected override DataResult<IEnumerable<TDomain>> GetAllWhere(Expression<Func<TEntity, bool>> filter)
            => _dbContext.Set<TEntity>()
                            .Where(filter)
                            .Map(MapEntityToDomain)
                            .CreateSuccessResult();
    }
}
