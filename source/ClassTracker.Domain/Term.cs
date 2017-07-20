using System;

namespace KadGen.ClassTracker.Domain
{
    public class Term
    {
        public Term(int id, Organization organization, string name, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Organization = organization;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }
        public int Id { get; }
        public Organization Organization { get; }
        public string Name { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
    }
}
