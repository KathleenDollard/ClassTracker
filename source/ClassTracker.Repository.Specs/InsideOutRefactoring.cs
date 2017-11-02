using KadGen.Common;
using System.Linq;

namespace KadGen.ClassTracker.Repository.Specs
{
    public class OutsideInRefactoring
    {
        public int Foo(int x, int y)
        {
            return Handling.WithDemoHandling(
                ()=>Disposable.Using(
                    () => new ClassTrackerDbContext(Utilities.GetConnSetting()),
                    with => with.Courses.Count() + x + y));
        }
    }
}
