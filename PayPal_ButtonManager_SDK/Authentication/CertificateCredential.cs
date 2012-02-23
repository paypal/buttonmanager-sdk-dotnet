using System;
using PayPal.Exception;

namespace PayPal.Authentication
{
    /// <summary>
    /// Client certificate based authentication
    /// </summary> 
    public class CertificateCredential : ICredential
    {        
        /// <summary>
        /// The certificate used to access the PayPal API
        /// </summary>
        private string certificateFile = string.Empty;

        /// <summary>
        /// The privateKeyPassword used
        /// </summary>
        private string privateKeyPassword = "";
		


        /// <summary>
        /// The file-name of the certificate to be used.
        ///
        /// </summary>
        public string CertificateFile
        {
            get
            {
                return this.certificateFile;
            }
            set
            {
                this.certificateFile = value;
            }
        }

 
        /// <summary>
        /// Password of given Certificate's Private Key
        /// </summary>
        public string PrivateKeyPassword
        {
            get
            {
                return privateKeyPassword;
            }
            set
            {
                privateKeyPassword = value;
            }
        }
    }
}
