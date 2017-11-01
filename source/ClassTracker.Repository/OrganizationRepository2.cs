using KadGen.ClassTracker.Domain;
using KadGen.ClassTracker.Repository;
using KadGen.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracker.Repository
{
    public class OrganizationRepository2
    {
        private ClassTrackerDbContext _dbContext;

        public OrganizationRepository2(ClassTrackerDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public DataResult<Organization> Get(int id)
        {
            try
            {
                var dbSet = _dbContext.Organizations;
                var entity = dbSet
                                .Where(x=>x.Id == id)
                                .SingleOrDefault();
                var domain = MapEntityToDomain(entity);
                var result = DataResult<Organization>.CreateSuccessResult(domain);
                return result;
            }
            catch (Exception ex)
            {
                return Result.CreateErrorResult<DataResult<Organization>>(new Error(ErrorCode.ExceptionThrown, ex, null));
            }
        }

        // Similar for other methods

        public static Organization MapEntityToDomain(EfOrganization entity)
        {
            return entity == null
                ? null
                : new Organization(entity.Id, entity.Name,
                        org => entity.Terms.Select(x
                            => TermRepository.Mapper.MapEntityToDomainForOrganization(x, org)).ToList(),
                        org => entity.Instructors.Select(x
                            => InstructorRepository.Mapper.MapEntityToDomainForOrganization(x, org)).ToList(),
                        org => entity.Courses.Select(x
                            => CourseRepository.Mapper.MapEntityToDomainForOrganization(x, org)).ToList());
        }

        public static void MapDomainToEntity(Organization domain, EfOrganization entity)
        {
            entity.Id = domain.Id;
            entity.Name = domain.Name;
        }
    }
}
