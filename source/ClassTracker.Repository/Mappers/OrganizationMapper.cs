using KadGen.ClassTracker.Domain;
using KadGen.ClassTracker.Repository;
using System.Linq;

namespace ClassTracker.Repository.Mappers
{
    internal class OrganizationMapper
    {
        public static Organization MapEntityToDomain(EfOrganization entity) => entity == null
                ? null
                : new Organization(entity.Id, entity.Name,
                        org => entity.Terms.Select(x
                            => TermMapper.MapEntityToDomainForOrganization(x, org)).ToList(),
                        org => entity.Instructors.Select(x
                            => InstructorMapper.MapEntityToDomainForOrganization(x, org)).ToList(),
                        org => entity.Courses.Select(x
                            => CourseMapper.MapEntityToDomainForOrganization(x, org)).ToList());

        public static void MapDomainToEntity(Organization domain, EfOrganization entity)
        {
            entity.Id = domain.Id;
            entity.Name = domain.Name;
        }
    }

}
