using System.Collections.Generic;

namespace CSharp7Demo
{
    public class Instructor : Staff
    {
        public Instructor(string name, decimal salary, IEnumerable<string> courses)
            : base(name, StaffRole.Instructor, salary)
        {
            Courses = courses;
        }

        public IEnumerable<string> Courses { get; private set; }
    }
}
