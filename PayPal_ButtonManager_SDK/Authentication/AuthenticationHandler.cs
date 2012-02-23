using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using log4net;
using PayPal.Authentication;

namespace PayPal.Manager
{
    public class AuthenticationHandler
    {

        /// <summary>
        /// To read the certificate .
        /// </summary>
        private X509Certificate x509;

        private string ApiUsername;

        /// <summary>
        /// Access token as returned by the Permissions service
        /// </summary>
        private string Token;

        /// <summary>
        /// Access token secret as returned by the Permissions service
        /// </summary>
        private string TokenSecret;

        private static readonly ILog log = LogManager.GetLogger(typeof(AuthenticationHandler));

        public void SetApiUsername(string apiUsername)
        {
            this.ApiUsername = apiUsername;
        }

        public void SetOAuthToken(string token, string tokenSecret)
        {
            this.Token = token;
            this.TokenSecret = tokenSecret;
        }

        public AuthenticationHandler(string apiUsername)
        {
            SetApiUsername(apiUsername);
        }
        public AuthenticationHandler() { }
        CredentialManager credMgr = CredentialManager.Instance;
        ICredential apiCredentials;
        /// <summary>
        /// Set necessary authentication parameters
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        public HttpWebRequest SetAuthenticationParams(HttpWebRequest httpRequest, string requestUri)
        {
            //TODO: get uri from httpRequest instead of passing in

            // Load and validate credentials
            apiCredentials = credMgr.GetCredentials(ApiUsername);
            credMgr.validateCredentials(apiCredentials);

            if (this.Token != null && this.TokenSecret != null)
            {
                OAuthGenerator sigGenerator =
                            new OAuthGenerator(apiCredentials.APIUsername, apiCredentials.APIPassword);

                //TODO: Add queryparams if a GET request
                sigGenerator.setHTTPMethod(httpRequest.Method);
                sigGenerator.setToken(this.Token);
                sigGenerator.setTokenSecret(this.TokenSecret);
                string tokenTimeStamp = GenerateTimeStamp();
                sigGenerator.setTokenTimestamp(tokenTimeStamp);
                log.Debug("token = " + Token + " tokenSecret=" + TokenSecret + " uri=" + requestUri);
                sigGenerator.setRequestURI(requestUri);

                //Compute Signature
                String sig = sigGenerator.ComputeSignature();
                log.Debug("Permissions signature: " + sig);
                String authorization = "token=" + Token + ",signature=" + sig + ",timestamp=" + tokenTimeStamp;
                log.Debug("Authorization string: " + authorization);
                httpRequest.Headers.Add(BaseConstants.XPAYPALSECURITYOAUTHSIGN, authorization);
                ////httpRequest.Headers.Add(BaseConstants.XPAYPALSECURITYCLIENTCERT, "No cert");
            }
            else
            {
                // Adding Credential and payload request/resposne information to the HttpWebRequest obejct's header
                httpRequest.Headers.Add(BaseConstants.XPAYPALSECURITYUSERID, apiCredentials.APIUsername);
                httpRequest.Headers.Add(BaseConstants.XPAYPALSECURITYPASSWORD, apiCredentials.APIPassword);

                /// Add the certificate to HttpWebRequest obejct if Profile is certificate enabled
                if ((apiCredentials is SignatureCredential))
                {
                    httpRequest.Headers.Add(BaseConstants.XPAYPALSECURITYSIGNATURE, ((SignatureCredential)apiCredentials).APISignature);
                }
                else
                {
                    // Load the certificate into an X509Certificate2 object.
                    if (((CertificateCredential)apiCredentials).PrivateKeyPassword.Trim() == string.Empty)
                    {
                        x509 = new X509Certificate2(((CertificateCredential)apiCredentials).CertificateFile);
                    }
                    else
                    {
                        x509 = new X509Certificate2(((CertificateCredential)apiCredentials).CertificateFile, ((CertificateCredential)apiCredentials).PrivateKeyPassword);
                    }
                    httpRequest.ClientCertificates.Add(x509);
                }
            }

            httpRequest.Headers.Add(BaseConstants.XPAYPALAPPLICATIONID, apiCredentials.ApplicationID);
            return httpRequest;
        }

        private string GenerateTimeStamp()
        {
            // Default implementation of UNIX time of the current UTC time
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }


        public string appendSoapHeaders(string requestPayload, string accessToken, string accessTokenSecret)
        {

            credMgr.validateCredentials(apiCredentials);
            StringBuilder soapMsg = new StringBuilder("<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:urn=\"urn:ebay:api:PayPalAPI\" xmlns:ebl=\"urn:ebay:apis:eBLBaseComponents\" xmlns:cc=\"urn:ebay:apis:CoreComponentTypes\" xmlns:ed=\"urn:ebay:apis:EnhancedDataTypes\">");
            if (this.Token != null && this.TokenSecret != null)
            {
                soapMsg.Append("<soapenv:Header>");
                soapMsg.Append("<urn:RequesterCredentials/>");
                soapMsg.Append("</soapenv:Header>");
            }
            else
            {
                // Adding Credential and payload request/resposne information to the HttpWebRequest obejct's header
                soapMsg.Append("<soapenv:Header>");
                soapMsg.Append("<urn:RequesterCredentials>");
                soapMsg.Append("<ebl:Credentials>");

                /// Add the certificate to HttpWebRequest obejct if Profile is certificate enabled
                if ((apiCredentials is SignatureCredential))
                {
                    soapMsg.Append("<ebl:Username>"
                           + ((SignatureCredential)apiCredentials).APIUsername
                           + "</ebl:Username>");
                    soapMsg.Append("<ebl:Password>"
                            + ((SignatureCredential)apiCredentials).APIPassword
                            + "</ebl:Password>");

                    soapMsg.Append("<ebl:Signature>"
                    + ((SignatureCredential)apiCredentials).APISignature
                    + "</ebl:Signature>");
                }
                else
                {
                    soapMsg.Append("<ebl:Username>"
                            + ((CertificateCredential)apiCredentials).APIUsername
                            + "</ebl:Username>");
                    soapMsg.Append("<ebl:Password>"
                            + ((CertificateCredential)apiCredentials).APIPassword
                            + "</ebl:Password>");
                }
                soapMsg.Append("</ebl:Credentials>");
                soapMsg.Append("</urn:RequesterCredentials>");
                soapMsg.Append("</soapenv:Header>");
            }
            soapMsg.Append("<soapenv:Body>");
            soapMsg.Append(requestPayload);
            soapMsg.Append("</soapenv:Body>");
            soapMsg.Append("</soapenv:Envelope>");
            return soapMsg.ToString();
        }
    }
}
