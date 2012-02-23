using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Collections;
using System.Text;

using PayPal.Exception;
using PayPal.OAuth;

namespace PayPal.Authentication
{
    public class OAuthGenerator
    {
        
        private static String PARAM_DELIMETER = "&";
        private static String PARAM_SEPERATOR = "=";
        private static String ENCODING_METHOD = "ASCII";
        private static String OAUTH_VERSION = "1.0";
        private static String OAUTH_SIGNATURE_METHOD = "HMAC-SHA1";        

        public enum HTTPMethod
        {
            GET, HEAD, POST, PUT, UPDATE
        };

	    /**
	     * Default Constructor
	     * 
	     * @param ConsumerKey
	     *            - Consumer key shared between PayPal and OAuth consumer
	     * @param ConsumerSecret
	     *            - Secret shared between PayPal and OAuth consumer
	     */
        public OAuthGenerator(String consumerKey, string consumerSecret)
        {
            
		    this.QueryParams = new ArrayList();
		    this.ConsumerKey = consumerKey;
            this.ConsumerSecret = System.Text.Encoding.ASCII.GetBytes(consumerSecret);
		    this.HttpMethod = HTTPMethod.POST;            		   
	    }

	    /**
	     * Sets Token to be used to generate signature.
	     * 
	     * @param Token
	     *            - String version of Token. The token could be Access or
	     *            Request //TODO: access or request
	     */
	    public void setToken(String token) {
		    this.Token = token;
	    }

        /**
         * Sets Token secret as received from the Permissions API.
         * 
         * @param secret
         *            byte array of token secret
         */
        public void setTokenSecret(string secret)
        {
            this.TokenSecret = System.Text.Encoding.ASCII.GetBytes(secret);            
        }

	    /**
	     * Adds Parameter. Parameter could be part of URL, POST data.
	     * 
	     * @param name
	     *            parameter name with no URL encoding applied
	     * @param value
	     *            parameter value with no URL encoding applied
	     */
	    public void addParameter(String name, String value) {
		    QueryParams.Add(new Parameter(name, value));
	    }

	    /**
	     * Sets URI for signature computation.
	     * 
	     * @param uri
	     *            - Script URI which will be normalized to
	     *            scheme://authority:port/path if not normalized already.
	     */
	    public void setRequestURI(String uri) {
		    this.RequestURI = NormalizeURI(uri);
	    }

	    /**
	     * Sets time stamp for signature computation.
	     * 
	     * @param TokenTimestamp
	     *            - time stamp at which Token request sends. 
	     */
	    public void setTokenTimestamp(String timestamp) {
		    this.TokenTimestamp = timestamp;
	    }

        //TODO: Remove me
        public void setHTTPMethod(HTTPMethod method)
        {
            this.HttpMethod = method;
        }

	    /**
	     * Sets HTTP Method
	     * 
	     * @param method
	     *            HTTP method used for sending OAuth request
	     */
	    public void setHTTPMethod(string method) {            
            switch (method)
            {
                case "GET":
                    this.HttpMethod = HTTPMethod.GET;
                    break;
                case "POST":
                    this.HttpMethod = HTTPMethod.POST;
                    break;
                case "PUT":
                    this.HttpMethod = HTTPMethod.PUT;
                    break;
                case "UPDATE":
                    this.HttpMethod = HTTPMethod.UPDATE;
                    break;
                default:
                    this.HttpMethod = HTTPMethod.POST;
                    break;
            }
	    }

	    /**
	     * Computes OAuth Signature as per OAuth specification using signature
	     * Method. using the specified encoding scheme {@code enc}.
	     * <p>
	     * 
	     * @return the Base64 encoded string.
	     * @throws OAuthException
	     *             if invalid arguments.
	     */
        public string ComputeSignature() 
        {
            if (ConsumerSecret == null || ConsumerSecret.Length == 0) {
			    throw new OAuthException("Consumer Secret or key not set.");
		    }

		    if (Token == "" || TokenSecret.Length == 0 || RequestURI == ""
				    || TokenTimestamp == "") {
			    throw new OAuthException(
					    "AuthToken or TokenSecret or Request URI or Timestamp not set.");
		    }

		    string signature = "";
		    try {
                string consumerSec = System.Text.Encoding.GetEncoding(ENCODING_METHOD).GetString(ConsumerSecret);
                //TODO: Why encode consumersecret twice?
                String key = PayPalURLEncoder.encode(consumerSec, ENCODING_METHOD);
			    key += PARAM_DELIMETER;                
                string tokenSec = System.Text.Encoding.GetEncoding(ENCODING_METHOD).GetString(TokenSecret);
                key += PayPalURLEncoder.encode(tokenSec, ENCODING_METHOD);


                StringBuilder paramString = new StringBuilder();
			    ArrayList oAuthParams = QueryParams;                
			    oAuthParams.Add( new Parameter("oauth_consumer_key", ConsumerKey) );
                oAuthParams.Add( new Parameter("oauth_version", OAUTH_VERSION) );
                oAuthParams.Add( new Parameter("oauth_signature_method", OAUTH_SIGNATURE_METHOD) );
			    oAuthParams.Add( new Parameter("oauth_token", Token) );
			    oAuthParams.Add( new Parameter("oauth_timestamp", TokenTimestamp) );
                oAuthParams.Sort();			    
			    int numParams = oAuthParams.Count - 1;
                for (int counter = 0; counter <= numParams; counter++)
                {
                    Parameter current = (Parameter)oAuthParams[counter];
                    paramString.Append(current.getName()).Append(PARAM_SEPERATOR).Append(current.getValue());
                    if (counter < numParams)
                        paramString.Append(PARAM_DELIMETER);				   
			    }

                String signatureBase = this.HttpMethod + PARAM_DELIMETER;
                signatureBase += PayPalURLEncoder.encode(RequestURI, ENCODING_METHOD) + PARAM_DELIMETER;
                signatureBase += PayPalURLEncoder.encode(paramString.ToString(), ENCODING_METHOD);


                Encoding encoding = System.Text.Encoding.ASCII;
                byte[] encodedKey = encoding.GetBytes(key);
                HMACSHA1 keyDigest = new HMACSHA1(encodedKey);

                Encoding encoding1 = System.Text.Encoding.ASCII;
                byte[] SignBase = encoding1.GetBytes(signatureBase);

                byte[] digest = keyDigest.ComputeHash(SignBase);                
                signature = System.Convert.ToBase64String(digest);

		    } catch (System.Exception e) {
			    throw new OAuthException(e.Message, e);
		    }

		    return signature;
	    }

	    /**
	     * VerifyOAuthSignature verifies signature against computed signature.
	     * 
	     * @return true if signature verified otherwise false
	     * @throws OAuthException
	     *             in case there are any failures in signature computation.
	     */
	    public Boolean VerifyOAuthSignature(String signature)  {
		    string signatureComputed = ComputeSignature();
		    return signatureComputed != signature ? false : true;
	    }

	    /**
	     * NormalizeURI normalizes the given URI as per OAuth spec
	     * 
	     * @param uri
	     * @return normalized URI. URI normalized to scheme://authority:port/path
	     * @throws OAuthException
	     */
	    private string NormalizeURI(string uri) {
		    string normalizedURI = "", port = "", scheme = "", path = "", authority = "";
		    int i, j, k;

            try
            {
                i = uri.IndexOf(":");
                if (i == -1)
                    throw new OAuthException("Invalid URI.");
                else
                    scheme = uri.Substring(0, i);

                // find next : in URL
                j = uri.IndexOf(":", i + 2);
                if (j != -1)
                {
                    // port has specified in URI
                    authority = uri.Substring(scheme.Length + 3, (j-(scheme.Length + 3)));
                    k = uri.IndexOf("/", j);
                    if (k != -1)
                        port = uri.Substring(j + 1, (k-(j+1)));
                    else
                        port = uri.Substring(j + 1);
                }
                else
                {
                    // no port specified in uri
                    k = uri.IndexOf("/", scheme.Length + 3);
                    if (k != -1)
                        authority = uri.Substring(scheme.Length + 3, (k - (scheme.Length + 3)));
                    else
                        authority = uri.Substring(scheme.Length + 3);
                }

                if (k != -1)
                    path = uri.Substring(k);

                normalizedURI = scheme.ToLower();
                normalizedURI += "://";
                normalizedURI += authority.ToLower();

                if (scheme != null && port.Length > 0)
                {
                    if (scheme.Equals("http") && Convert.ToInt32(port) != 80)
                    {
                        normalizedURI += ":";
                        normalizedURI += port;
                    }
                    else if (scheme.Equals("https") && Convert.ToInt32(port) != 443)
                    {
                        normalizedURI += ":";
                        normalizedURI += port;
                    }
                }

            }
            catch (FormatException nfe)
            {
                throw new OAuthException("Invalid URI.", nfe);
            }
            catch (ArgumentOutOfRangeException are)
            {
                throw new OAuthException("Out Of Range.", are);
            }
		    normalizedURI += path;

		    return normalizedURI;
	    }

	    private string ConsumerKey;
	    private string Token;
	    private byte[] ConsumerSecret;
	    private byte[] TokenSecret;
	    private string RequestURI;
	    private string TokenTimestamp;
	    private HTTPMethod HttpMethod;
	    private ArrayList QueryParams;

	      

	    /**
	     * Inner class for representing a name/value pair
         * Implements custom comparison method for sorting
	     * 
	     */
        private class Parameter : System.IComparable
        {

		    public Parameter(String name, String value) {
			    this.Name = name;
			    this.Value = value;
		    }

		    public void setName(String name) {
			    this.Name = name;
		    }

		    public void setValue(String val) {
			    this.Value = val;
		    }

		    public String getName() {
			    return this.Name;
		    }

		    public String getValue() {
			    return this.Value;
		    }

		    private String Name;
		    private String Value;

            /**
             * Compare by name. If both are equal, compare by value
             */
            public int CompareTo(Object obj)
            {
                if (!(obj is Parameter))
                    throw new InvalidCastException("This object is not of type Parameter");

                Parameter param = (Parameter)obj;
                int retval = 0;
                if (param != null)
                {
                    retval = this.Name.CompareTo(param.getName());
                    // if parameter names are equal then compare parameter values.
                    if (retval == 0)
                        retval = this.Value.CompareTo(param.getValue());
                }
                return retval;
            }
	    }

        public static string GenerateTimeStamp()
        {
            // Default implementation of UNIX time of the current UTC time
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }	

    }
}
