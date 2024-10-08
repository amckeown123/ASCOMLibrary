﻿

using System;

namespace ASCOM.Common.Alpaca
{
    /// <summary>
    /// Alpaca boolean response class
    /// </summary>
    public class DateTimeResponse : Response, IValueResponse<System.DateTime>
    {
        private const string ISO8601_DATE_FORMAT_STRING = "yyyy-MM-ddTHH:mm:ss.fffffff";

        /// <summary>
        /// Create a new DateTimeResponse with default values
        /// </summary>
        public DateTimeResponse()
        {
        }

        /// <summary>
        /// Create a new DateTimeResponse with the supplied parameter values
        /// </summary>
        /// <param name="clientTransactionID">Client transaction ID</param>
        /// <param name="serverTransactionID">Server transaction ID</param>
        /// <param name="value">Value to return</param>
        public DateTimeResponse(uint clientTransactionID, uint serverTransactionID, DateTime value)
        {
            base.ServerTransactionID = serverTransactionID;
            base.ClientTransactionID = clientTransactionID;
            Value = value;
        }

        /// <summary>
        /// Create a new DateTimeResponse with the supplied parameter values
        /// </summary>
        /// <param name="clientTransactionID">Client transaction ID</param>
        /// <param name="serverTransactionID">Server transaction ID</param>
        /// <param name="errorMessage">Value to return</param>
        /// <param name="errorCode">Server transaction ID</param>
        public DateTimeResponse(uint clientTransactionID, uint serverTransactionID, string errorMessage, AlpacaErrors errorCode)
        {
            base.ServerTransactionID = serverTransactionID;
            base.ClientTransactionID = clientTransactionID;
            base.ErrorMessage = errorMessage;
            base.ErrorNumber = errorCode;
        }

        /// <summary>
        /// Boolean value returned by the device
        /// </summary>
        public DateTime Value { get; set; }
        DateTime IValueResponse<DateTime>.Value { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        

        /// <summary>
        /// Return the value as a string
        /// </summary>
        /// <returns>String representation of the response value</returns>
        public override string ToString()
        { 
          
            return Value.ToUniversalTime().ToString(ISO8601_DATE_FORMAT_STRING + "Z");
        }
    }
}