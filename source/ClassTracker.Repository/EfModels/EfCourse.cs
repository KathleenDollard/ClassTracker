using System.Collections.Generic;

namespace KadGen.ClassTracker.Repository
{
    public class EfCourse
    {
        public int Id { get; set; }
        public EfOrganization Organization { get; set; }
        public string CatalogNumber { get; set; }
        public string Name { get; set; }

        //public int Bar { get; set; }

        public virtual List<EfSection> Sections { get; set; }
    }
}
