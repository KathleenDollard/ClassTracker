using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace KadGen.Common.Repository
{
    public abstract class BaseMappedRepository<TDomain, TPKey, TEntity>
        : BaseRepository<TDomain, TPKey>
              where TPKey : struct
              where TDomain : class
              where TEntity : class
    {
        private Expression<Func<TEntity, TPKey>> _getPKeyExpr { get; }
        protected Func<TEntity, TPKey> GetPKey { get; }
        protected Func<TEntity, TDomain> MapEntityToDomain { get; }
        protected Action<TDomain, TEntity> MapDomainToEntity { get; }

        protected abstract DataResult<TDomain> GetWhere(Expression<Func<TEntity, bool>> filter);
        protected abstract DataResult<IEnumerable<TDomain>> GetAllWhere(Expression<Func<TEntity, bool>> filter);
    
        public BaseMappedRepository(
                 Expression<Func<TEntity, TPKey>> getPKeyExpression,
                 Func<TEntity, TDomain> mapEntityToDomain,
                 Action<TDomain, TEntity> mapDomainToEntity)
            : base(getPKeyExpression.MemberName())
        {
            MapEntityToDomain = mapEntityToDomain;
            MapDomainToEntity = mapDomainToEntity;
            _getPKeyExpr = getPKeyExpression;

            GetPKey = getPKeyExpression.Compile();
        }

        protected Expression<Func<TEntity, bool>> GetPKeyWhereClause(TPKey id) 
            => _getPKeyExpr.EqualsWhereFromMemberLambdaExpression(id);
    }
}
