using KadGen.ClassTracker.Domain;
using KadGen.Common.Repository;

namespace KadGen.ClassTracker.Repository
{
    public class CourseRepository
             : BaseEfRepository<ClassTrackerDbContext,Course, int, EfCourse >
    {
        public CourseRepository(ClassTrackerDbContext dbContext)
            : base(
                  dbContext,
                  getPKey: e => e.Id,
                  mapEntityToDomain: Mapper.MapEntityToDomain,
                  mapDomainToEntity: Mapper.MapDomainToEntity)
        { }

        internal class Mapper
        {
            public static Course MapEntityToDomainForOrganization(EfCourse entity, Organization organization)
            {
                return new Course(entity.Id, organization, entity.CatalogNumber, entity.Name);
            }
            public static Course MapEntityToDomain(EfCourse entity)
            {
                // TODO: Figure out how to share mappings, like here for org
                return new Course(entity.Id, null, entity.CatalogNumber, entity.Name);
            }

            public static void MapDomainToEntity(Course domain, EfCourse entity)
            {
                entity.Id = domain.Id;
                entity.Name = domain.Name;
            }
        }
    }
}
