using KadGen.ClassTracker.Domain;
using KadGen.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadGen.ClassTracker.Repository
{
    public class RepositoryFactory : BaseFactory<BaseRepository>
    {
        public RepositoryFactory(ClassTrackerDbContext dbContext)
            : base(
            new Dictionary<Type, BaseRepository>
            {
                [typeof(Organization)] = new OrganizationRepository(dbContext)
            })
        { }
    }
}
