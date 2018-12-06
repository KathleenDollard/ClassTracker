using KadGen.ClassTracker.Domain;
using KadGen.ClassTracker.Repository;
using System.Linq;

namespace ClassTracker.Repository.Mappers
{
    internal class InstructorMapper
    {
        public static Instructor MapEntityToDomainForOrganization(
                EfInstructor entity, Organization organization) 
            => new Instructor(entity.Id,
                        organization,
                        entity.GivenName, entity.SurName);

        public static Instructor MapEntityToDomain(EfInstructor entity) 
            => new Instructor(entity.Id,
                        null,
                        entity.GivenName, entity.SurName);

        public static void MapDomainToEntity(Instructor domain, EfInstructor entity)
        {
            entity.Id = domain.Id;
            entity.GivenName = domain.GivenName;
            entity.SurName = domain.SurName;
        }
    }
}
