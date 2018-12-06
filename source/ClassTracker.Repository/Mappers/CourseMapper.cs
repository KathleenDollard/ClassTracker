using KadGen.ClassTracker.Domain;
using KadGen.ClassTracker.Repository;

namespace ClassTracker.Repository.Mappers
{
    internal class CourseMapper
    {
        public static Course MapEntityToDomainForOrganization(EfCourse entity, Organization organization)
            => new Course(entity.Id, organization, entity.CatalogNumber, entity.Name);
        public static Course MapEntityToDomain(EfCourse entity)
            => new Course(entity.Id, null, entity.CatalogNumber, entity.Name);

        public static void MapDomainToEntity(Course domain, EfCourse entity)
        {
            entity.Id = domain.Id;
            entity.Name = domain.Name;
        }
    }
}
