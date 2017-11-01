using KadGen.ClassTracker.Domain;
using KadGen.ClassTracker.Repository;
using KadGen.Common;
using System.Collections.Generic;

namespace KadGen.ClassTracker.Service
{
    public class OrganizationService : BaseService<Organization, int>
    {
        private OrganizationRepository  _repository { get; }  

        public OrganizationService(ClassTrackerDbContext dbContext)
            :base(new RepositoryFactory(dbContext))
        { }
    }
}
