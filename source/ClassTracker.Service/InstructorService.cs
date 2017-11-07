using KadGen.ClassTracker.Domain;
using KadGen.ClassTracker.Repository;
using KadGen.Common;

namespace KadGen.ClassTracker.Service
{
    public class InstructorService : BaseService<Instructor, int>
    {
        public InstructorService(ClassTrackerDbContext dbContext)
            :base(new ClassTrackerRepositoryFactory(dbContext))
        {}
    }
}
