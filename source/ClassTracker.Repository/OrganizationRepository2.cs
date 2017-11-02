using KadGen.ClassTracker.Domain;
using KadGen.ClassTracker.Repository;
using KadGen.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracker.Repository
{
    public class tempBase<TDomain,TEntity,TPKey>
        where TPKey : struct
        where TEntity: class
    {
        private DbContext _dbContext;
        private Func<DbContext> _getDbContext;
        private Func<DbSet<TEntity>> _getDbSet;

        public tempBase(Func<DbContext > getDbContext,
            Func<DbSet<TEntity>> getDbSet)
        {
            _getDbContext = getDbContext;
            _getDbSet = getDbSet;
        }

        public DataResult<TDomain> Get(TPKey id)
        {
            return Handling.WithCommonHandling(
                () =>
                {
                    var dbSet = _getDbSet();
                    var entity = dbSet
                                    .Where(x => x.Id == id)
                                    .SingleOrDefault();
                    Organization domain = Map(entity);
                    var result = DataResult<Organization>.CreateSuccessResult(domain);
                    return result;
                });
        }
    }
    public class OrganizationRepository2 :tempBase
    {
        private ClassTrackerDbContext _dbContext;

        public OrganizationRepository2(ClassTrackerDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public DataResult<Organization> Get(int id)
        {
            return Handling.WithCommonHandling(
                () =>
                {
                    var dbSet = _dbContext.Organizations;
                    var entity = dbSet
                                    .Where(x => x.Id == id)
                                    .SingleOrDefault();
                    Organization domain = Map(entity);
                    var result = DataResult<Organization>.CreateSuccessResult(domain);
                    return result;
                });
        }

        private static Organization Map(EfOrganization entity)
        {
            var domain =
                    entity == null
                        ? null
                        : new Organization(entity.Id, entity.Name,
                                org => entity.Terms.Select(x
                                    => TermRepository.Mapper.MapEntityToDomainForOrganization(x, org)).ToList(),
                                org => entity.Instructors.Select(x
                                    => InstructorRepository.Mapper.MapEntityToDomainForOrganization(x, org)).ToList(),
                                org => entity.Courses.Select(x
                                    => CourseRepository.Mapper.MapEntityToDomainForOrganization(x, org)).ToList());
            ;
            return domain;
        }

        // And so on  for other methods

    }
}
