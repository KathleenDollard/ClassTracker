using Microsoft.Extensions.Logging;

namespace KadGen.ClassTracker.WebApi.Controllers
{
    public class LoggingEvents
    {
        public const int GetItem = 1000;
        public const int GetAll = 1001;

        public const int GetItemNotFound = 4040;

        public const int UncaughtError = 5000;
    }
}
