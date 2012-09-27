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

        private string GetDefaultAccountName()
        {
            ConfigManager configMgr = ConfigManager.Instance;
            Account firstAccount = configMgr.GetAccount(0);
            if (firstAccount == null)
            {
                throw new MissingCredentialException("No accounts configured for API call");
            }
            return firstAccount.APIUsername;
        }

        public ICredential GetCredentials(string apiUserName)
        {
            if (apiUserName == null)
            {
                apiUserName = GetDefaultAccountName();
            }

            if (this.cachedCredentials.ContainsKey(apiUserName))
            {
                log.Debug("Returning cached credentials for " + apiUserName);
                return this.cachedCredentials[apiUserName];
            }
            else
            {
                ICredential pro = null;

                ConfigManager configMgr = ConfigManager.Instance;
                Account acc = configMgr.GetAccount(apiUserName);
                if (acc == null)
                {
                    throw new MissingCredentialException("Missing credentials for " + apiUserName);
                }
                if (!string.IsNullOrEmpty(acc.APICertificate))
                {
                    CertificateCredential cred = new CertificateCredential();
                    cred.APIUsername = acc.APIUsername;
                    cred.APIPassword = acc.APIPassword;
                    cred.CertificateFile = acc.APICertificate;
                    cred.PrivateKeyPassword = acc.PrivateKeyPassword;
                    cred.ApplicationID = acc.ApplicationId;

                    cred.CertificateSubject = acc.CertificateSubject;

                    pro = cred;
                }
                else
                {
                    SignatureCredential cred = new SignatureCredential();
                    cred.APIUsername = acc.APIUsername;
                    cred.APIPassword = acc.APIPassword;
                    cred.APISignature = acc.APISignature;
                    cred.ApplicationID = acc.ApplicationId;

                    cred.SignatureSubject = acc.SignatureSubject;

                    pro = cred;
                }
                this.cachedCredentials.Add(apiUserName, pro);
                return pro;
            }
        }

        /// <summary>
        /// Validate API Credentials
        /// </summary>
        /// <param name="apiCredentials"></param>
        public void ValidateCredentials(ICredential apiCredentials)
        {
            if (string.IsNullOrEmpty(apiCredentials.APIUsername))
            {
                throw new InvalidCredentialException(BaseConstants.ErrorMessages.err_username);
            }
            if (string.IsNullOrEmpty(apiCredentials.APIPassword))
            {
                throw new InvalidCredentialException(BaseConstants.ErrorMessages.err_passeword);
            }
            if (string.IsNullOrEmpty(apiCredentials.ApplicationID))
            {
                throw new InvalidCredentialException(BaseConstants.ErrorMessages.err_appid);
            }

            if ((apiCredentials is SignatureCredential))
            {
                if (string.IsNullOrEmpty(((SignatureCredential)apiCredentials).APISignature))                
                {
                    throw new InvalidCredentialException(BaseConstants.ErrorMessages.err_signature);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(((CertificateCredential)apiCredentials).CertificateFile))                
                {
                    throw new InvalidCredentialException(BaseConstants.ErrorMessages.err_certificate);
                }

                if (string.IsNullOrEmpty(((CertificateCredential)apiCredentials).PrivateKeyPassword))                
                {
                    throw new InvalidCredentialException(BaseConstants.ErrorMessages.err_privatekeypassword);
                }
            
            }

        }        
    }
}
