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

    public class Term : IDomain<int>
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

    public class Section : IDomain<int>
    {
        public Section(int id, Instructor instructor, Term term)
        {
            Id = id;
            Instructor = instructor;
            Term = term;
        }

        public int Id { get; }
        public Instructor Instructor { get; }
        public Term Term { get; }
    }
}
