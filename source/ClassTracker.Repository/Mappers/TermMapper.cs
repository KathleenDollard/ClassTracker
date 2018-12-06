using KadGen.ClassTracker.Domain;
using KadGen.ClassTracker.Repository;
using System.Linq;

namespace ClassTracker.Repository.Mappers
{
    internal class TermMapper
    {
        public static Term MapEntityToDomainForOrganization(EfTerm entity, Organization organization) 
            => new Term(entity.Id, organization, entity.Name, entity.StartDate, entity.EndDate);

        public static Term MapEntityToDomain(EfTerm entity) 
            => new Term(entity.Id, null, entity.Name, entity.StartDate, entity.EndDate);

        public static void MapDomainToEntity(Term domain, EfTerm entity)
        {
            entity.Id = domain.Id;
            entity.Name = domain.Name;
        }
    }
}
