using ClassTracker.Repository.Mappers;
using KadGen.ClassTracker.Domain;
using KadGen.Common.Repository;

namespace KadGen.ClassTracker.Repository
{
    public class TermRepository
             : BaseEfRepository<Term, int, EfTerm, ClassTrackerDbContext>
    {
        public TermRepository(ClassTrackerDbContext dbContext)
            : base(
                  dbContext,
                  getDbSet: dc => dc.Terms,
                  getPKey: e => e.Id,
                  mapEntityToDomain: TermMapper.MapEntityToDomain,
                  mapDomainToEntity: TermMapper.MapDomainToEntity)
        { }
    }
}
