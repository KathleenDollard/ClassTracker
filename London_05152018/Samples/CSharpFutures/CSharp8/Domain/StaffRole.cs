using System;

namespace CSharp7Demo
{
    [Flags]
    public enum StaffRole
    {
        Instructor = 0b1,
        Researcher = 0b10,
        DepartmentChair = 0b100,
        Cleaner = 0b1000,
        DroppingThings = 0b10000,
        Provost = 0b1_0000_0000_0000,
        RaceCarDriver = 0b1_0000_0000_0001
    }
}
