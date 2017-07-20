namespace KadGen.ClassTracker.Repository
{
    public class EfSection
    {
            public int Id { get; set; }
        public virtual EfInstructor Instructor { get; set; }
        public virtual EfTerm Term { get; set; }
        public virtual EfCourse  Course { get; set; }
    }
}
