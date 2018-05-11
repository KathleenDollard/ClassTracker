using System;
using System.Linq;
using KadGen.Functional.Common;

namespace KadGen.Functional.Samples
{
    public class InsideOutProgramming
    {
        public int Foo(int x, int y)
        {
            try
            {
                using (var dbContext = new CTDbContext(Utilities.GetConnString()))
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

        // This is the demo I cut short. 
        public int Foo2(int x, int y)
         => Handling.WithDemoHandling(
                () => Disposable.Using(
                    () => new CTDbContext(Utilities.GetConnString()),
                    disp => disp.Courses.Count() + x + y));
        
        // Here is the same demo returning a data result via implicit operator conversion
        public Result<int> Foo3(int x, int y) 
            => Handling.WithCommonHandling(
                () => Disposable.Using(
                    () => new CTDbContext(Utilities.GetConnString()),
                    disp => (Result<int>)(disp.Courses.Count() + x + y)));
        }

        // Further adjust this to your specific situation to clean it up further. For example, 
        // if you always create the same context, you could combine the Using and WithCommonHandling 
        // methods.
   
    }
