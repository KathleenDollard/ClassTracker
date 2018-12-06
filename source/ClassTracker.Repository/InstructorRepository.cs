using ClassTracker.Repository.Mappers;
using KadGen.ClassTracker.Domain;
using KadGen.Common.Repository;

namespace KadGen.ClassTracker.Repository
{
    public class InstructorRepository
             : BaseEfRepository<Instructor, int, EfInstructor, ClassTrackerDbContext>
    {
        public InstructorRepository(ClassTrackerDbContext dbContext)
            : base(
                  dbContext,
                  getDbSet: dc => dc.Instructors,
                  getPKey: e => e.Id,
                  mapEntityToDomain: InstructorMapper.MapEntityToDomain,
                  mapDomainToEntity: InstructorMapper.MapDomainToEntity)
        { }
    }
}
