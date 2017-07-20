using System.Collections.Generic;

namespace KadGen.ClassTracker.Repository
{
    public class EfOrganization
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<EfInstructor> Instructors { get; set; }
        public virtual List<EfCourse> Courses { get; set; }
        public virtual List<EfTerm> Terms { get; set; }
    }
}
