using System;
using System.Collections.Generic;

namespace KadGen.ClassTracker.Repository
{
    public class EfTerm
    {
        public int Id {get; set;}
        public virtual EfOrganization Organization {get; set;}
        public string Name {get; set;}
        public DateTime StartDate {get; set;}
        public DateTime EndDate {get; set;}

        public virtual List<EfSection> Sections { get; set; }
    }
}
