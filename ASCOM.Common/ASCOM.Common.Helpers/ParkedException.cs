using Cassandra;

namespace ASCOM.Common.Helpers
{
    internal class ParkedException : DriverException
    {
        public ParkedException(string message) : base(message)
        {
        }
    }
}