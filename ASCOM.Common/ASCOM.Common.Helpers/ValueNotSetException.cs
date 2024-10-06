using Cassandra;

namespace ASCOM.Common.Helpers
{
    internal class ValueNotSetException : DriverException
    {
        public ValueNotSetException(string message) : base(message)
        {
        }
    }
}