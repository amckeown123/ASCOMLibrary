using System;

namespace ASCOM.Common.Helpers
{
    public class DriverException : Exception
    {
        public DriverException(string message)
        {
            Message = message;
        }

        public  override string Message { get; }
    }
}