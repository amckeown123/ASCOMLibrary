using Cassandra;

namespace ASCOM.Common.Helpers
{
    internal class OperationCancelledException : DriverException
    {
        public OperationCancelledException(string message) : base(message)
        {
        }
    }
}