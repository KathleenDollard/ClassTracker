using ClassTracker.Repository.Mappers;
using KadGen.ClassTracker.Domain;
using KadGen.Common.Repository;

namespace KadGen.ClassTracker.Repository
{
    public class CourseRepository
             : BaseEfRepository<Course, int, EfCourse, ClassTrackerDbContext>
    {
        public CourseRepository(ClassTrackerDbContext dbContext)
            : base(
                  dbContext,
                  getDbSet: dc => dc.Courses,
                  getPKey: e => e.Id,
                  mapEntityToDomain: CourseMapper.MapEntityToDomain,
                  mapDomainToEntity: CourseMapper.MapDomainToEntity)
        { }
    }
}
