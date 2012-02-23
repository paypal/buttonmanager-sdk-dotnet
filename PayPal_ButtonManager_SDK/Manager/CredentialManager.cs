using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using log4net;

using PayPal;
using PayPal.Authentication;
using PayPal.Exception;

namespace PayPal.Manager
{
    /// <summary>
    /// Reads API credentials to be used with the application
    /// </summary>
    public class CredentialManager
    {
        private Dictionary<string, ICredential> cachedCredentials = new Dictionary<string, ICredential>();

        private static readonly ILog log = LogManager.GetLogger(typeof(CredentialManager));

        /// <summary>
        /// Singleton instance of CredentialManager
        /// </summary>
        private static readonly CredentialManager instance = new CredentialManager();
        public static CredentialManager Instance
        {
            get
            {
                return instance;
            }
        }        

        private CredentialManager()
        { }

        private string getDefaultAccountName()
        {
            ConfigManager configMgr = ConfigManager.Instance;
            Account firstAccount = configMgr.GetAccount(0);
            if (firstAccount == null)
            {
                throw new MissingCredentialException("No accounts configured for API call");
            }
            return firstAccount.APIUsername;
        }

        public ICredential GetCredentials(string apiUsername)
        {
            if (apiUsername == null)
            {
                apiUsername = getDefaultAccountName();
            }

            if (this.cachedCredentials.ContainsKey(apiUsername))
            {
                log.Debug("Returning cached credentials for " + apiUsername);
                return this.cachedCredentials[apiUsername];
            }
            else
            {
                ICredential pro = null;

                ConfigManager configMgr = ConfigManager.Instance;
                Account acc = configMgr.GetAccount(apiUsername);
                if (acc == null)
                {
                    throw new MissingCredentialException("Missing credentials for " + apiUsername);
                }
                if (acc.APICertificate != null && acc.APICertificate.Length > 0)
                {
                    CertificateCredential cred = new CertificateCredential();
                    cred.APIUsername = acc.APIUsername;
                    cred.APIPassword = acc.APIPassword;
                    cred.CertificateFile = acc.APICertificate;
                    cred.PrivateKeyPassword = acc.PrivateKeyPassword;
                    cred.ApplicationID = acc.ApplicationId;
                    pro = cred;
                }
                else
                {
                    SignatureCredential cred = new SignatureCredential();
                    cred.APIUsername = acc.APIUsername;
                    cred.APIPassword = acc.APIPassword;
                    cred.APISignature = acc.APISignature;
                    cred.ApplicationID = acc.ApplicationId;
                    pro = cred;
                }

                this.cachedCredentials.Add(apiUsername, pro);
                return pro;
            }
        }

        /// <summary>
        /// Validate API Credentials
        /// </summary>
        /// <param name="apiCredentials"></param>
        public void validateCredentials(ICredential apiCredentials)
        {
            if (apiCredentials.APIUsername == null || apiCredentials.APIUsername == "")
            {
                throw new InvalidCredentialException(BaseConstants.ErrorMessages.err_username);
            }
            if (apiCredentials.APIPassword == null || apiCredentials.APIPassword == "")
            {
                throw new InvalidCredentialException(BaseConstants.ErrorMessages.err_passeword);
            }
            if (apiCredentials.ApplicationID == null || apiCredentials.ApplicationID == "")
            {
                throw new InvalidCredentialException(BaseConstants.ErrorMessages.err_appid);
            }

            if ((apiCredentials is SignatureCredential))
            {
                if (((SignatureCredential)apiCredentials).APISignature == null || ((SignatureCredential)apiCredentials).APISignature == "")
                {
                    throw new InvalidCredentialException(BaseConstants.ErrorMessages.err_signature);
                }
            }
            else
            {
                if (((CertificateCredential)apiCredentials).CertificateFile == null || ((CertificateCredential)apiCredentials).CertificateFile == "")
                {
                    throw new InvalidCredentialException(BaseConstants.ErrorMessages.err_certificate);
                }
                if (((CertificateCredential)apiCredentials).PrivateKeyPassword == null || ((CertificateCredential)apiCredentials).PrivateKeyPassword == "")
                {
                    throw new InvalidCredentialException(BaseConstants.ErrorMessages.err_privatekeypassword);
                }
            
            }

        }        
    }
}
