using System;
using System.Collections.Generic;
using System.Text;

namespace PayPal.Exception
{
    public class ConnectionException : System.Exception
    {
		public ConnectionException() : base()
		{}


		/// <summary>
		/// Represents errors that occur during application execution
		/// </summary>
		/// <param name="message">The message that describes the error</param>
        public ConnectionException(string message)
            : base(message)
		{
			
		}
    }
}
