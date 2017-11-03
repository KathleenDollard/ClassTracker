using KadGen.ClassTracker.Domain;
using KadGen.Common.Repository;

namespace KadGen.ClassTracker.Repository
{
    public class TermRepository
             : BaseEfRepository<ClassTrackerDbContext,Term, int, EfTerm>
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
}
