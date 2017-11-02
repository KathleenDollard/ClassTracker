using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using KadGen.Common;

namespace KadGen.ClassTracker.Domain
{
    public class Organization : IDomain<int>
    {
        public Organization(int id, string name)
        {
            Id = id;
            Name = name;
        }

        // Can't create and pass in because it would create a circular reference
        public Organization(int id, string name,
                Func<Organization, IEnumerable<Term>> getTerms,
                Func<Organization, IEnumerable<Instructor>> getInstructors,
                Func<Organization, IEnumerable<Course>> getCourses)
        {
            Id = id;
            Name = name;
            Terms = ImmutableList.Create(getTerms(this).ToArray());
            Instructors = ImmutableList.Create(getInstructors(this).ToArray());
            Courses = ImmutableList.Create(getCourses(this).ToArray());

        }

        public int Id { get; }
        public string Name { get; }

        public IImmutableList<Term> Terms { get; }
        public IImmutableList<Instructor> Instructors { get; }
        public IImmutableList<Course> Courses { get; }
    }
}
