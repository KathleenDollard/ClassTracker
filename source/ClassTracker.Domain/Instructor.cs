using KadGen.Common;

namespace KadGen.ClassTracker.Domain
{
    public class Instructor : IDomain<int>
    {
        public Instructor(int id, Organization organization, string givenName, string surName)
        {
            Id = id;
            Organization = organization;
            GivenName = givenName;
            SurName = surName;
        }
        public int Id { get; }
        public Organization Organization { get; }
        public string GivenName { get; }
        public string SurName { get; }
    }
}
