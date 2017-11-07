using KadGen.ClassTracker.Domain;
using KadGen.Common.Repository;

namespace KadGen.ClassTracker.Repository
{
    public class InstructorRepository
             : BaseEfRepository<ClassTrackerDbContext,Instructor, int, EfInstructor >
    {
        public InstructorRepository(ClassTrackerDbContext dbContext)
            : base(
                  dbContext,
                  getPKey: e => e.Id,
                  mapEntityToDomain: Mapper.MapEntityToDomain,
                  mapDomainToEntity: Mapper.MapDomainToEntity)
        { }

        internal class Mapper
        {
            public static Instructor MapEntityToDomainForOrganization(EfInstructor entity, Organization organization)
            {
                // TODO: Figure out how to share mappings, like here for org
                return new Instructor(entity.Id,
                    organization,
                    entity.GivenName, entity.SurName);
            }

            public static Instructor MapEntityToDomain(EfInstructor entity)
            {
                // TODO: Figure out how to share mappings, like here for org
                return new Instructor(entity.Id, 
                    null , 
                    entity.GivenName , entity.SurName);
            }

            public static void MapDomainToEntity(Instructor domain, EfInstructor entity)
            {
                entity.Id = domain.Id;
                entity.GivenName = domain.GivenName;
                entity.SurName = domain.SurName;
            }
        }
    }
}
