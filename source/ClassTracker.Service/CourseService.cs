using KadGen.ClassTracker.Domain;
using KadGen.ClassTracker.Repository;
using KadGen.Common;

namespace KadGen.ClassTracker.Service
{
    public class CourseService : BaseService<Course, int>
    {
        public CourseService(ClassTrackerDbContext dbContext)
            :base(new ClassTrackerRepositoryFactory(dbContext))
        {}
    }
}
