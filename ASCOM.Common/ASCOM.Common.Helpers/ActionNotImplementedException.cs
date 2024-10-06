using Cassandra;

namespace ASCOM.Common.Helpers
{
    internal class ActionNotImplementedException : DriverException
    {
        public ActionNotImplementedException(string message) : base(message)
        {
        }
    }
}