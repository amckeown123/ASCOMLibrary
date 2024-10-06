using Cassandra;

namespace ASCOM.Common.Helpers
{
    internal class InvalidValueException : DriverException
    {
        public InvalidValueException(string message) : base(message)
        {
        }
    }
}