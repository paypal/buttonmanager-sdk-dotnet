using System;
using System.Collections.Generic;
using System.Text;
using log4net;

namespace PayPal.Exception
{
    public class MissingCredentialException : System.Exception
    {
		private static ILog log = LogManager.GetLogger("com.paypal.sdk.exceptions.MissingCredentialException"); 

		/// <summary>
		/// Represents errors that occur during application execution
		/// </summary>
		public MissingCredentialException() : base()
		{}


		/// <summary>
		/// Represents errors that occur during application execution
		/// </summary>
		/// <param name="message">The message that describes the error</param>
		public MissingCredentialException(string message): base(message)
		{
			if (log.IsErrorEnabled)
			{
				log.Error(message, this);
			}
		}


		/// <summary>
		/// Represents errors that occur during application execution
		/// </summary>
		/// <param name="message">The message that describes the error</param>
		/// <param name="cause">The exception that is the cause of the current exception</param>
        public MissingCredentialException(string message, System.Exception cause)
            : base(message, cause)
		{
			if (log.IsErrorEnabled) 
			{
				log.Error(message, this);
			}
		}
	} // MissingCredentialException
}
