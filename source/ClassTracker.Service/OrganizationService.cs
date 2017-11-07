﻿using KadGen.ClassTracker.Domain;
using KadGen.ClassTracker.Repository;
using KadGen.Common;

namespace KadGen.ClassTracker.Service
{
    public class OrganizationService : BaseService<Organization, int>
    {
        public OrganizationService(ClassTrackerDbContext dbContext)
            :base(new ClassTrackerRepositoryFactory(dbContext))
        {}
    }
}
