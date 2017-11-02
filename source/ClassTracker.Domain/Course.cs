using KadGen.Common;

namespace KadGen.ClassTracker.Domain
{
    public class Course : IDomain<int>
    {
        public Course(int id, Organization organization, string catalogNumber, string name)
        {
            Id = id;
            Organization = organization;
            CatalogNumber = catalogNumber;
            Name = name;
        }
        public int Id { get; }
        public Organization Organization { get; }
        public string CatalogNumber { get; }
        public string Name { get; }
    }
}
