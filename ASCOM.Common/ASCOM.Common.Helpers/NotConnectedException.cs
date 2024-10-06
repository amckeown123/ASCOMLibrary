using Cassandra;

namespace ASCOM.Common.Helpers
{
    internal class NotConnectedException : DriverException
    {
        public NotConnectedException(string message) : base(message)
        {
        }
    }
}