using System;
using System.Collections.Generic;
using System.Text;

namespace PayPal.Exception
{
    public class InvalidCredentialException : System.Exception
    {
        public InvalidCredentialException(string message) : base(message)
        {            
        
        }
    }
}
