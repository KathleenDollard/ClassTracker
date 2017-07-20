using KadGen.ClassTracker.Domain;
using KadGen.Common.Repository;
using System.Linq;

namespace KadGen.ClassTracker.Repository
{
    public class OrganizationRepository
            : BaseEfRepository<Organization, int, EfOrganization, ClassTrackerDbContext>
    {
        public OrganizationRepository()
            : base(
                  getDbSet: dc => dc.Organizations,
                  getPKey: o => o.Id,
                  mapEntityToDomain: Mapper.MapEntityToDomain,
                  mapDomainToEntity: Mapper.MapDomainToEntity)
        { }

        internal class Mapper
        {
            public static Organization MapEntityToDomain(EfOrganization entity)
            {
                return entity == null 
                    ? null
                    : new Organization(entity.Id, entity.Name,
                            org => entity.Terms.Select(x 
                                => TermRepository.Mapper.MapEntityToDomainForOrganization(x, org)).ToList(),
                            org => entity.Instructors.Select(x 
                                => InstructorRepository.Mapper.MapEntityToDomainForOrganization(x, org)).ToList(),
                            org => entity.Courses.Select(x 
                                => CourseRepository.Mapper.MapEntityToDomainForOrganization(x, org)).ToList());
            }

            public static EfOrganization MapDomainToEntity(Organization domain)
            {
                var entity = new EfOrganization();
                entity.Id = domain.Id;
                entity.Name = domain.Name;
                return entity;
            }
        }
    }
}
