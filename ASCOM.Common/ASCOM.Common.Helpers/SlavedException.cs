using Cassandra;

namespace ASCOM.Common.Helpers
{
    internal class SlavedException : DriverException
    {
        public SlavedException(string message) : base(message)
        {
        }
    }
}