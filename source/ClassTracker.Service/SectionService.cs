using KadGen.ClassTracker.Domain;
using KadGen.ClassTracker.Repository;
using KadGen.Common;

namespace KadGen.ClassTracker.Service
{
    public class SectionService : BaseService<Section, int>
    {
        public SectionService(ClassTrackerDbContext dbContext)
            :base(new ClassTrackerRepositoryFactory(dbContext))
        {}
    }
}
