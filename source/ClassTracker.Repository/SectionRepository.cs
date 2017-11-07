using KadGen.ClassTracker.Domain;
using KadGen.Common.Repository;

namespace KadGen.ClassTracker.Repository
{
    public class SectionRepository
             : BaseEfRepository<ClassTrackerDbContext, Section, int, EfSection>
    {
        public SectionRepository(ClassTrackerDbContext dbContext)
            : base(
                  dbContext,
                  getPKey: e => e.Id,
                  mapEntityToDomain: Mapper.MapEntityToDomain,
                  mapDomainToEntity: Mapper.MapDomainToEntity)
        { }

        internal class Mapper
        {
            public static Section MapEntityToDomain(EfSection entity)
                => new Section(entity.Id, null, null);

            public static void MapDomainToEntity(Section domain, EfSection entity)
            {
                entity.Id = domain.Id;
            }
        }
    }
}
