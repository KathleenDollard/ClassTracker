using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracker.Repository.Specs
{
    [TestClass]
    public class LinqStuff
    {
        [TestMethod]
        public void Stuff()
        {
            var values = Enumerable.Range(1, 10);
        }
    }

  












    //public class LinqStuff
    //{
    //    [TestMethod]
    //    public void Stuff()
    //    {
    //        var values = Enumerable.Range(1, 10);
    //        var x = values.Compute(y => y * y);
    //        Console.WriteLine(string.Join("\r\n", values.Select(z => "Intial: " + z)));
    //        Console.WriteLine(string.Join("\r\n", x.Select(z => "Calculated: " + z)));
    //    }
    //}

    //public static class LinqExtensions
    //{
    //    public static IEnumerable<int> Compute(
    //        this IEnumerable<int> list,
    //        Func<int, int> f)
    //    {
    //        return list.Select(x => f(x));
    //    }
    //}
}
