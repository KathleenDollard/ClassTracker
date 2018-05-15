namespace CSharp7Demo
{
    public class Person
    {
        public Person(string name)
        { Name = name; }
        public string Name { get; }

        public string Foo => "Fred";
    }
}
