using System;
using System.Collections.Generic;
using System.Text;

namespace PayPal.Authentication
{
    /// <summary>
    /// Common properties
    /// </summary>
    public abstract class ICredential
    {
        /// <summary>
        /// The username used to access the PayPal API
        /// </summary>
        private string apiUsername = string.Empty;

        /// <summary>
        /// The password used to access the PayPal API
        /// </summary>
        private string apiPassword;

        /// <summary>
        /// Application ID that is issued by PayPal
        /// </summary>
        private string applicationId;


        /// <summary>
        /// ApplicationId
        /// </summary>
        public string ApplicationID
        {
            get { return this.applicationId; }
            set { this.applicationId = value; }
        }

        /// <summary>
        /// API Username
        /// </summary>
        public string APIUsername
        {
            get { return this.apiUsername; }
            set { this.apiUsername = value; }
        }


        /// <summary>
        /// The password used to access the PayPal API
        /// </summary>
        public string APIPassword
        {
            get { return this.apiPassword; }
            set { this.apiPassword = value; }
        }
    }
}
