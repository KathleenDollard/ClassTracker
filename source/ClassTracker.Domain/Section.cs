namespace KadGen.ClassTracker.Domain
{
    public class Section
    {
        public Section(int id, Instructor instructor, Term term)
        {
            Id = id;
            Instructor = instructor;
            Term = term;
        }

        public int Id { get;  }
        public Instructor Instructor { get;  }
        public Term Term { get;  }
    }
}
