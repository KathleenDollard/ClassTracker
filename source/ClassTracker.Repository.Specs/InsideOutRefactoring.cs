using KadGen.ClassTracker.Repository;
using KadGen.Common;
using System;
using System.Linq;

namespace KadGen.ClassTracker.Repository.Specs
{
    public class InsideOutProgramming
    {
        public int Foo(int x, int y)
        {
            try
            {
                using (var dbContext = new ClassTrackerDbContext())
                {
                    // interesting code - use your imagination
                    return dbContext.Courses.Count() + x + y; 
                }
            }
            catch
            {
                return -1; // Don't do this, it's a stupid sample
            }
        }
    }
}
