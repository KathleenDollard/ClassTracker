using KadGen.ClassTracker.Domain;
using KadGen.Common;
using KadGen.Common.Repository;
using System;
using System.Linq;

namespace KadGen.ClassTracker.Repository
{
    public class TermRepositoryInit
             : BaseEfRepository<Term, int, EfTerm, ClassTrackerDbContext>
    {

        private ClassTrackerDbContext dbContext;

        public TermRepositoryInit(ClassTrackerDbContext dbContext)
            : base(
                  dbContext,
                  getDbSet: dc => dc.Terms,
                  getPKey: e => e.Id,
                  mapEntityToDomain: Mapper.MapEntityToDomain,
                  mapDomainToEntity: Mapper.MapDomainToEntity)
        {
            this.dbContext = dbContext;
        }

        public override DataResult<Term> Get(int id)
        {
            try
            {
                var dbSet = dbContext.Terms;
                var entity = dbSet
                                .Where(x=>x.Id == id)
                                .SingleOrDefault();
                var domain = MapEntityToDomain(entity);
                var result = DataResult<Term>.CreateSuccessResult(domain);
                return result;
            }
            catch (Exception ex)
            {
                return Result.CreateErrorResult<DataResult<Term>>(
                    new Error(ErrorCode.ExceptionThrown, ex, null));
            }
        }

        internal class Mapper
        {
            public static Term MapEntityToDomainForOrganization (EfTerm entity, Organization organization)
            {
                return new Term(entity.Id, organization, entity.Name, entity.StartDate, entity.EndDate);
            }

            public static Term MapEntityToDomain(EfTerm entity)
            {
                return new Term(entity.Id, null, entity.Name, entity.StartDate, entity.EndDate);
            }

            public static void MapDomainToEntity(Term domain, EfTerm entity)
            {
                entity.Id = domain.Id;
                entity.Name = domain.Name;
            }
        }
    }

    public class TermRepository
             : BaseEfRepository<Term, int, EfTerm, ClassTrackerDbContext>
    {
        public TermRepository(ClassTrackerDbContext dbContext)
            : base(
                  dbContext,
                  getDbSet: dc => dc.Terms,
                  getPKey: e => e.Id,
                  mapEntityToDomain: Mapper.MapEntityToDomain,
                  mapDomainToEntity: Mapper.MapDomainToEntity)
        { }

        internal class Mapper
        {
            public static Term MapEntityToDomainForOrganization(EfTerm entity, Organization organization)
            {
                return new Term(entity.Id, organization, entity.Name, entity.StartDate, entity.EndDate);
            }

            public static Term MapEntityToDomain(EfTerm entity)
            {
                return new Term(entity.Id, null, entity.Name, entity.StartDate, entity.EndDate);
            }

            public static void MapDomainToEntity(Term domain, EfTerm entity)
            {
                entity.Id = domain.Id;
                entity.Name = domain.Name;
            }
        }
    }
}
