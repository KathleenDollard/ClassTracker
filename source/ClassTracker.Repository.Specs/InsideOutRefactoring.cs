﻿using KadGen.Common;
using System.Linq;

namespace KadGen.ClassTracker.Repository.Specs
{
    public class OutsideInRefactoring
    {
        public int Foo(int x, int y)
        {
            try
            {
                using (var dbContext = new ClassTrackerDbContext(Utilities.GetConnSetting()))
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
