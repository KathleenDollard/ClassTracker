using KadGen.ClassTracker.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace KadGen.ClassTracker.Repository.Specs
{
    public static class Utilities
    {
        public static ClassTrackerDbContext GetDbContext()
        {
            var connString = GetConnSetting();
            var dbContext = new ClassTrackerDbContext(connString);
            return dbContext;
        }

        public static string GetConnSetting() 
            => ConfigurationManager.ConnectionStrings["ClassTrackerDb"].ConnectionString ;
    }
}
