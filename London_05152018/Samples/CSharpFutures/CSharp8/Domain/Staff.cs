namespace CSharp7Demo
{
    public class Staff : Person
    {
        public Staff(string name, StaffRole staffRole, decimal salary) : base(name)
        {
            StaffRole = staffRole;
            Salary = salary;
        }
        public StaffRole StaffRole { get; }
        public decimal Salary { get; }
    }
}
