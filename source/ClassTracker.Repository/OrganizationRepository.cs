using ClassTracker.Repository.Mappers;
using KadGen.ClassTracker.Domain;
using KadGen.Common.Repository;

namespace KadGen.ClassTracker.Repository
{
    public class OrganizationRepository
            : BaseEfRepository<Organization, int, EfOrganization, ClassTrackerDbContext>
    {
        public OrganizationRepository(ClassTrackerDbContext dbContext)
            : base(dbContext,
                  getDbSet: dc => dc.Organizations,
                  getPKey: o => o.Id,
                  mapEntityToDomain: OrganizationMapper.MapEntityToDomain,
                  mapDomainToEntity: OrganizationMapper.MapDomainToEntity)
        { }
    }
}
