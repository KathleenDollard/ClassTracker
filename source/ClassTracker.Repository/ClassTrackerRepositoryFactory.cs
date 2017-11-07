using KadGen.ClassTracker.Domain;
using KadGen.Common.Repository;
using System;
using System.Collections.Generic;

namespace KadGen.ClassTracker.Repository
{
    public class ClassTrackerRepositoryFactory : BaseFactory<BaseRepository>
    {
        public ClassTrackerRepositoryFactory(ClassTrackerDbContext dbContext)
            : base(
            new Dictionary<Type, BaseRepository>
            {
                [typeof(Organization)] = new OrganizationRepository(dbContext)
            })
        { }
    }
}
