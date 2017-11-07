using KadGen.ClassTracker.Domain;
using KadGen.ClassTracker.Repository;
using KadGen.Common;

namespace KadGen.ClassTracker.Service
{
    public class TermService : BaseService<Term, int>
    {
        public TermService(ClassTrackerDbContext dbContext)
            :base(new ClassTrackerRepositoryFactory(dbContext))
        {}
    }
}
