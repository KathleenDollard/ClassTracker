namespace CSharp7Demo
{
    public class Student : Person
    {
        public Student(string name, decimal gpa) : base(name)
        {
            GPA = gpa;
        }
        public decimal GPA { get; }
    }
}
