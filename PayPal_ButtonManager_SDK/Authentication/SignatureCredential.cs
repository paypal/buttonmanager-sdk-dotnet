
using System;
using log4net;

namespace PayPal.Authentication
{
	/// <summary>
	/// API Signature based authentication.
	/// </summary>
	[Serializable]
    public class SignatureCredential : ICredential
	{
		/// <summary>
		/// The API signature used in three-token authentication
		/// </summary>
		private string apiSignature;

        /// <summary>
        /// Signature Subject
        /// </summary>
        private string signSubject;

		/// <summary>
		/// API Signature used to access the PayPal API.  Only used for
		/// profiles set to Three-Token Authentication instead of Client-Side SSL Certificates.
		/// </summary>
		public  string APISignature
		{
			get
			{
				return this.apiSignature;
			}
			set
			{
				this.apiSignature = value;
			}
		}

        /// <summary>
        /// Signature Subject
        /// </summary>
        public string SignatureSubject
        {
            get { return this.signSubject; }
            set { this.signSubject = value; }
        }
	} 
} 