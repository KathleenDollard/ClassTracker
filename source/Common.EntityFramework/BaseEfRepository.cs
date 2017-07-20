using KadGen.Common.ResultExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KadGen.Common.Repository
{
    public class BaseEfRepository<TDomain, TPKey, TEntity, TDbContext>
        : BaseMappedRepository<TDomain, TPKey, TEntity>
            where TPKey : struct
            where TDomain : class
            where TEntity : class
            where TDbContext : DbContext, new()
    {
        private Func<TDbContext, DbSet<TEntity>> _getDbSet { get; }

        public BaseEfRepository(
                Func<TDbContext, DbSet<TEntity>> getDbSet,
                Expression<Func<TEntity, TPKey>> getPKey,
                Func<TEntity, TDomain> mapEntityToDomain,
                Func<TDomain, TEntity> mapDomainToEntity)
            : base(getPKey, mapEntityToDomain, mapDomainToEntity)
        {
            _getDbSet = getDbSet;
        }

        public override DataResult<TDomain> Get(TPKey id)
        {
            try
            {
                using (var dbContext = new TDbContext())
                {
                    var dbSet = _getDbSet(dbContext);
                    var entity = dbSet.Where(GetPKeyWhereClause(id))
                            .SingleOrDefault();
                    var domain = MapEntityToDomain(entity);
                    var result = DataResult<TDomain>.CreateSuccessResult(domain);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return Result.CreateErrorResult<DataResult<TDomain>>(new Error(ErrorCode.ExceptionThrown, ex, null));
            }
        }

        public override DataResult<IEnumerable<TDomain>> GetAll()
                => WithWrappedDbSet(
                    dbSet => dbSet
                                .ToList()
                                .Map(x => MapEntityToDomain(x)) // Prefer map because can't be run against DB
                                .ToList().Select(x => x)
                                .CreateSuccessResult());

        public async Task<DataResult<IEnumerable<TDomain>>> GetAllAsync()
                  => await WithWrappedDbSetAsync(
                      async dbSet =>
                      {
                          await Task.Delay(1000);
                          var list = await dbSet.ToListAsync();
                          Console.WriteLine("Done");
                          return list.Map(x => MapEntityToDomain(x)) // Prefer map because can't be run against DB
                              .ToList().Select(x => x)
                              .CreateSuccessResult();
                      });

        public override DataResult<TPKey> Create(TDomain domain)
            => WithWrappedDbSetAndContext(
                (dbContext, dbSet) =>
                    {
                        var entity = domain.Map(MapDomainToEntity);
                        dbSet.Add(entity);
                        dbContext.SaveChanges();
                        return GetPKey(entity)
                                .CreateSuccessResult();
                    });

        public override Result Update(TDomain domain)
            => WithWrappedDbSetAndContext(
                    (dbContext, dbSet) =>
                    {
                        var entity = domain.Map(MapDomainToEntity);
                        dbSet.Attach(entity);
                        dbContext.Entry(entity).State = EntityState.Modified;
                        dbContext.SaveChanges();
                        return Result.CreateSuccessResult<Result>();
                    });

        public override Result Delete(TDomain domain)
                => WithWrappedDbContext(
                    dbContext =>
                    {
                        var entity = domain.Map(MapDomainToEntity);
                        var entry = dbContext.Entry(entity);
                        entry.State = EntityState.Deleted;
                        dbContext.SaveChanges();
                        return Result.CreateSuccessResult<Result>();
                    });

        // NOTE: The following are not pulic because TEntity is not available outside the layer
        protected override DataResult<TDomain> GetWhere(Expression<Func<TEntity, bool>> filter)
           => WithWrappedDbSet(
               dbSet => dbSet
                            .Where(filter)
                            .SingleOrDefault()
                            .Map(MapEntityToDomain)
                            .CreateSuccessResult());

        protected override DataResult<IEnumerable<TDomain>> GetAllWhere(Expression<Func<TEntity, bool>> filter)
            => WithWrappedDbSet(
                dbSet => dbSet
                             .Where(filter)
                             .Map(MapEntityToDomain)
                         .CreateSuccessResult());

        private TResult WithWrappedDbSet<TResult>(Func<DbSet<TEntity>, TResult> operation)
                 where TResult : Result
              => WithWrappedDbContext(
                 dc => operation(_getDbSet(dc)));

        private TResult WithWrappedDbSetAndContext<TResult>(Func<TDbContext, DbSet<TEntity>, TResult> operation)
                where TResult : Result
             => WithWrappedDbContext(
                dc => operation(dc, _getDbSet(dc)));

        private TResult WithWrappedDbContext<TResult>(Func<TDbContext, TResult> operation)
                where TResult : Result
            => Handling.WithCommonHandling(()
                => Disposable.Using(
                    () => new TDbContext(),
                    dc => operation(dc)));

        private async Task<TResult> WithWrappedDbSetAsync<TResult>(
                    Func<DbSet<TEntity>, Task<TResult>> operation)
                 where TResult : Result
              => await WithWrappedDbContextAsync(
                    dc => operation(_getDbSet(dc)));

        private async Task<TResult> WithWrappedDbSetAndContextAsync<TResult>(
                    Func<TDbContext, DbSet<TEntity>, Task<TResult>> operation)
                where TResult : Result
             => await WithWrappedDbContextAsync(
                dc => operation(dc, _getDbSet(dc)));

        private async Task<TResult> WithWrappedDbContextAsync<TResult>(
            Func<TDbContext, Task<TResult>> operation)
                where TResult : Result
            => await Handling.WithCommonHandlingAsync(async ()
                => await Disposable.UsingAsync(
                    () => new TDbContext(),
                    dc => operation(dc)));

    }
}
