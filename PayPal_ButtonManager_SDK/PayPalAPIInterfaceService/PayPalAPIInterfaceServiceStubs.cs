namespace PayPal.PayPalAPIInterfaceService.Model {
	using System;
	using System.Text;
	using System.Web;
	using System.Xml;
	using System.Collections;
	using System.ComponentModel;
	using System.Collections.Generic;
	using PayPal.Util;

	public class EnumUtils{
		public static string getDescription(Enum value){
			string description="";
			DescriptionAttribute[] attributes = (DescriptionAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
			if (attributes.Length > 0)
			{
				description= attributes[0].Description;
			}
			return description;
		}
		public static object getValue(String value,Type enumType){
			string[] names = Enum.GetNames(enumType);
			foreach (string name in names)
			{
				if (getDescription((Enum)Enum.Parse(enumType, name)).Equals(value))
				{
					return Enum.Parse(enumType, name);
				}
			}
			return null;
		}
	}
		public class DeserializationUtils{
	 public static bool isWhiteSpaceNode(XmlNode n) {
		 if (n.NodeType ==XmlNodeType.Text) { 
				string val = n.InnerText;
				return val.Trim().Length == 0; 
		 } else {
				return false;
		 } 
	 } 
	 public static string convertToXML(XmlNode n){ 
		 string name = n.Name;
		 if (XmlNodeType.CDATA == n.NodeType) {
			  return "<![CDATA[" + n.Value + "]]&gt;";
		 } 
		 if (name.StartsWith("#")) {
			  return "";
		} 
		 StringBuilder sb = new StringBuilder();
		 sb.Append('<').Append(name);
		 XmlNamedNodeMap attrs = n.Attributes;
		 if (attrs != null) { 
		  for (int i = 0; i < attrs.Count; i++) { 
			    XmlNode attr = attrs.Item(i);
			   if(!attr.Value.Contains(":"))
			    sb.Append(' ').Append(attr.Name).Append("=\"").Append(attr.Value).Append("\"");
		  }
		 } 
		 string textContent = null; 
		 XmlNodeList children = n.ChildNodes; 
		 if (children.Count == 0) { 
		  if ((textContent = n.InnerText) != null && !"".Equals(textContent)) {
		    sb.Append(textContent).Append("</").Append(name).Append('>'); 
		  } else { 
		    sb.Append("/>"); 
		  } 
		 } else { 
		  sb.Append('>'); 
		  bool hasValidChildren = false;
		  for (int i = 0; i < children.Count; i++) { 
		    string childToString = DeserializationUtils.convertToXML(children[i]);
		    if (!"".Equals(childToString)) {
		      sb.Append(childToString); 
		      hasValidChildren = true; 
		    } 
		  } 
		  if (!hasValidChildren && ((textContent = n.InnerText) != null)) { 
		    sb.Append(textContent); 
		 }
		  sb.Append("</").Append(name).Append('>');
		 }
		 return sb.ToString();
	 } 
		}
	public enum APIAuthenticationType {
[Description("Auth-None")]AUTHNONE,
[Description("Cert")]CERT,
[Description("Sign")]SIGN,
	}
	/**
	 * APICredentialsType 
	 */
	public partial class APICredentialsType {

		/**
		 * Merchant’s PayPal API username
Character length and limitations: 128 alphanumeric characters		 */
		private string UsernameField;
		public string Username {
			get {
				return this.UsernameField;
			}
			set {
				this.UsernameField = value;
			}
		}

		/**
		 * Merchant’s PayPal API password
Character length and limitations: 40 alphanumeric characters		 */
		private string PasswordField;
		public string Password {
			get {
				return this.PasswordField;
			}
			set {
				this.PasswordField = value;
			}
		}

		/**
		 * Merchant’s PayPal API signature, if one exists.
		 * Character length and limitations: 256 alphanumeric characters		 */
		private string SignatureField;
		public string Signature {
			get {
				return this.SignatureField;
			}
			set {
				this.SignatureField = value;
			}
		}

		/**
		 * Merchant’s PayPal API certificate in PEM format, if one exists
		 * The certificate consists of two parts: the private key (2,048 bytes) and the certificate proper (4,000 bytes).
		 * Character length and limitations: 6,048 alphanumeric characters		 */
		private string CertificateField;
		public string Certificate {
			get {
				return this.CertificateField;
			}
			set {
				this.CertificateField = value;
			}
		}

		/**
		 * Merchant’s PayPal API authentication mechanism.
		 * Auth-None: no authentication mechanism on file
		 * Cert: API certificate
		 * Sign: API signature
		 * Character length and limitations: 9 alphanumeric characters		 */
		private APIAuthenticationType? TypeField;
		public APIAuthenticationType? Type {
			get {
				return this.TypeField;
			}
			set {
				this.TypeField = value;
			}
		}

	 public APICredentialsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Username").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Username")[0])){ 
		 this.Username =(string)document.GetElementsByTagName("Username")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Password").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Password")[0])){ 
		 this.Password =(string)document.GetElementsByTagName("Password")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Signature").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Signature")[0])){ 
		 this.Signature =(string)document.GetElementsByTagName("Signature")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Certificate").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Certificate")[0])){ 
		 this.Certificate =(string)document.GetElementsByTagName("Certificate")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Type").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Type")[0])){ 
		 this.Type = (APIAuthenticationType)EnumUtils.getValue(document.GetElementsByTagName("Type")[0].InnerText,typeof(APIAuthenticationType));

}
	}
	}
	}


	public enum APIType {
[Description("CHECKOUT_AUTHORIZATION")]CHECKOUTAUTHORIZATION,
[Description("CHECKOUT_SALE")]CHECKOUTSALE,
	}
	/**
	 * Base type definition of request payload that can carry any type 
	 * of payload content with optional versioning information and detail level
	 * requirements.
	 */
	public partial class AbstractRequestType {

		/**
		 * This specifies the required detail level that is needed by a client application pertaining to
		 * a particular data component (e.g., Item, Transaction, etc.). The detail level is specified in
		 * the DetailLevelCodeType which has all the enumerated values of the detail level for 
		 * each component.  
		 */
		private List<DetailLevelCodeType?> DetailLevelField = new List<DetailLevelCodeType?>();
		public List<DetailLevelCodeType?> DetailLevel {
			get {
				return this.DetailLevelField;
			}
			set {
				this.DetailLevelField = value;
			}
		}

		/**
		 * This should be the standard RFC 3066 language identification tag, e.g., en_US.
		 */
		private string ErrorLanguageField;
		public string ErrorLanguage {
			get {
				return this.ErrorLanguageField;
			}
			set {
				this.ErrorLanguageField = value;
			}
		}

		/**
		 * This refers to the version of the request payload schema.
		 */
		private string VersionField;
		public string Version {
			get {
				return this.VersionField;
			}
			set {
				this.VersionField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( DetailLevel != null ) {
			for(int i=0; i<DetailLevel.Count; i++) {
				sb.Append("<ebl:DetailLevel>").Append(EnumUtils.getDescription(DetailLevel[i])).Append("</ebl:DetailLevel>");
			}
		}
		if( ErrorLanguage != null ) {
			sb.Append("<ebl:ErrorLanguage>").Append(ErrorLanguage);
			sb.Append("</ebl:ErrorLanguage>");
		}
		if( Version != null ) {
			sb.Append("<ebl:Version>").Append(Version);
			sb.Append("</ebl:Version>");
		}
		return sb.ToString();
	}

	}


	/**
	 * Base type definition of a response payload that can carry any 
	 * type of payload content with following optional elements:
	 * - timestamp of response message, 
	 * - application level acknowledgement, and 
	 * - application-level errors and warnings.
	 */
	public partial class AbstractResponseType {

		/**
		 * This value represents the date and time (GMT) when the response 
		 * was generated by a service provider (as a result of processing 
		 * of a request). 
		 */
		private string TimestampField;
		public string Timestamp {
			get {
				return this.TimestampField;
			}
			set {
				this.TimestampField = value;
			}
		}

		/**
		 * Application level acknowledgement code.
		 */
		private AckCodeType? AckField;
		public AckCodeType? Ack {
			get {
				return this.AckField;
			}
			set {
				this.AckField = value;
			}
		}

		/**
		 * CorrelationID may be used optionally with an application 
		 * level acknowledgement.
		 */
		private string CorrelationIDField;
		public string CorrelationID {
			get {
				return this.CorrelationIDField;
			}
			set {
				this.CorrelationIDField = value;
			}
		}

		private List<ErrorType> ErrorsField = new List<ErrorType>();
		public List<ErrorType> Errors {
			get {
				return this.ErrorsField;
			}
			set {
				this.ErrorsField = value;
			}
		}

		/**
		 * This refers to the version of the response payload schema.
		 */
		private string VersionField;
		public string Version {
			get {
				return this.VersionField;
			}
			set {
				this.VersionField = value;
			}
		}

		/**
		 * This refers to the specific software build that was used in the deployment 
		 * for processing the request and generating the response.
		 */
		private string BuildField;
		public string Build {
			get {
				return this.BuildField;
			}
			set {
				this.BuildField = value;
			}
		}

	 public AbstractResponseType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Timestamp").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Timestamp")[0])){ 
		 this.Timestamp =(string)document.GetElementsByTagName("Timestamp")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Ack").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Ack")[0])){ 
		 this.Ack = (AckCodeType)EnumUtils.getValue(document.GetElementsByTagName("Ack")[0].InnerText,typeof(AckCodeType));

}
	}
		 if(document.GetElementsByTagName("CorrelationID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CorrelationID")[0])){ 
		 this.CorrelationID =(string)document.GetElementsByTagName("CorrelationID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Errors").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Errors")[0])){ 
		 nodeList = document.GetElementsByTagName("Errors");
		 for(int i=0; i<nodeList.Count; i++) {
			 xmlString = DeserializationUtils.convertToXML(nodeList[i]); 
				this.Errors.Add(new ErrorType(xmlString));
			}

}
	}
		 if(document.GetElementsByTagName("Version").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Version")[0])){ 
		 this.Version =(string)document.GetElementsByTagName("Version")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Build").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Build")[0])){ 
		 this.Build =(string)document.GetElementsByTagName("Build")[0].InnerText;

}
	}
	}
	}


	public enum AckCodeType {
[Description("Success")]SUCCESS,
[Description("Failure")]FAILURE,
[Description("Warning")]WARNING,
[Description("SuccessWithWarning")]SUCCESSWITHWARNING,
[Description("FailureWithWarning")]FAILUREWITHWARNING,
[Description("PartialSuccess")]PARTIALSUCCESS,
[Description("CustomCode")]CUSTOMCODE,
	}
	/**
	 */
	public partial class ActivationDetailsType {

		/**
		 */
		private BasicAmountType InitialAmountField;
		public BasicAmountType InitialAmount {
			get {
				return this.InitialAmountField;
			}
			set {
				this.InitialAmountField = value;
			}
		}

		/**
		 */
		private FailedPaymentActionType? FailedInitialAmountActionField;
		public FailedPaymentActionType? FailedInitialAmountAction {
			get {
				return this.FailedInitialAmountActionField;
			}
			set {
				this.FailedInitialAmountActionField = value;
			}
		}

		public ActivationDetailsType(BasicAmountType InitialAmount) {
			this.InitialAmount = InitialAmount;
		}
		public ActivationDetailsType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( InitialAmount != null ) {
			sb.Append("<ebl:InitialAmount ");
			sb.Append(InitialAmount.toXMLString());
			sb.Append("</ebl:InitialAmount>");
		}
		if( FailedInitialAmountAction != null ) {
			sb.Append("<ebl:FailedInitialAmountAction>").Append(EnumUtils.getDescription(FailedInitialAmountAction));
			sb.Append("</ebl:FailedInitialAmountAction>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class AdditionalFeeType {

		private string TypeField;
		public string Type {
			get {
				return this.TypeField;
			}
			set {
				this.TypeField = value;
			}
		}

		private BasicAmountType AmountField;
		public BasicAmountType Amount {
			get {
				return this.AmountField;
			}
			set {
				this.AmountField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( Type != null ) {
			sb.Append("<ebl:Type>").Append(Type);
			sb.Append("</ebl:Type>");
		}
		if( Amount != null ) {
			sb.Append("<ebl:Amount ");
			sb.Append(Amount.toXMLString());
			sb.Append("</ebl:Amount>");
		}
		return sb.ToString();
	}

	}


	public enum AddressOwnerCodeType {
[Description("PayPal")]PAYPAL,
[Description("eBay")]EBAY,
[Description("CustomCode")]CUSTOMCODE,
	}
	public enum AddressStatusCodeType {
[Description("None")]NONE,
[Description("Confirmed")]CONFIRMED,
[Description("Unconfirmed")]UNCONFIRMED,
	}
	/**
	 * Person's name associated with this address. 
Character length and limitations: 32 single-byte alphanumeric characters
	 */
	public partial class AddressType {

		/**
		 * Person's name associated with this address. 
Character length and limitations: 32 single-byte alphanumeric characters
		 */
		private string NameField;
		public string Name {
			get {
				return this.NameField;
			}
			set {
				this.NameField = value;
			}
		}

		/**
		 * First street address. 
Character length and limitations: 300 single-byte alphanumeric characters
		 */
		private string Street1Field;
		public string Street1 {
			get {
				return this.Street1Field;
			}
			set {
				this.Street1Field = value;
			}
		}

		/**
		 * Second street address. 
Character length and limitations: 300 single-byte alphanumeric characters
		 */
		private string Street2Field;
		public string Street2 {
			get {
				return this.Street2Field;
			}
			set {
				this.Street2Field = value;
			}
		}

		/**
		 * Name of city. 
Character length and limitations: 120 single-byte alphanumeric characters		 */
		private string CityNameField;
		public string CityName {
			get {
				return this.CityNameField;
			}
			set {
				this.CityNameField = value;
			}
		}

		/**
		 * State or province. 
Character length and limitations: 120 single-byte alphanumeric characters
		 * For Canada and the USA, StateOrProvince must be the standard 2-character abbreviation of a state or province.
		 * Canadian Provinces
		 * Alberta
		 * AB 
		 * British_Columbia
		 * BC
		 * Manitoba
		 * MB
		 * New_Brunswick
		 * NB
		 * Newfoundland
		 * NF
		 * Northwest_Territories
		 * NT
		 * Nova_Scotia
		 * NS 
		 * Nunavut
		 * NU
		 * Ontario
		 * ON
		 * Prince_Edward_Island
		 * PE
		 * Quebec
		 * QC
		 * Saskatchewan
		 * SK
		 * Yukon
		 * YK
		 * United States
		 * Alabama
		 * AL 
		 * Alaska
		 * AK
		 * American_Samoa
		 * AS
		 * Arizona
		 * AZ
		 * Arkansas
		 * AR
		 * California
		 * CA
		 * Colorado
		 * CO
		 * Connecticut
		 * CT
		 * Delaware
		 * DE
		 * District_Of_Columbia
		 * DC
		 * Federated_States_Of_Micronesia
		 * FM
		 * Florida
		 * FL
		 * Georgia
		 * GA
		 * Guam
		 * GU
		 * Hawaii
		 * HI
		 * Idaho
		 * ID 
		 * Illinois
		 * IL
		 * Indiana
		 * IN
		 * Iowa
		 * IA
		 * Kansas
		 * KS
		 * Kentucky
		 * KY
		 * Louisiana
		 * LA
		 * Maine
		 * ME
		 * Marshall_Islands
		 * MH
		 * Maryland
		 * MD
		 * Massachusetts
		 * MA
		 * Michigan
		 * MI
		 * Minnesota
		 * MN
		 * Mississippi
		 * MS
		 * Missouri
		 * MO
		 * Montana
		 * MT
		 * Nebraska
		 * NE
		 * Nevada
		 * NV
		 * New_Hampshire
		 * NH
		 * New_Jersey
		 * NJ
		 * New_Mexico
		 * NM
		 * New_York
		 * NY
		 * North_Carolina
		 * NC
		 * North_Dakota
		 * ND
		 * Northern_Mariana_Islands
		 * MP
		 * Ohio
		 * OH 
		 * Oklahoma
		 * OK
		 * Oregon
		 * OR
		 * Palau
		 * PW
		 * Pennsylvania
		 * PA
		 * Puerto_Rico
		 * PR
		 * Rhode_Island
		 * RI
		 * South_Carolina
		 * SC
		 * South_Dakota
		 * SD
		 * Tennessee
		 * TN 
		 * Texas
		 * TX
		 * Utah
		 * UT
		 * Vermont
		 * VT
		 * Virgin_Islands
		 * VI
		 * Virginia
		 * VA
		 * Washington
		 * WA
		 * West_Virginia
		 * WV
		 * Wisconsin
		 * WI
		 * Wyoming
		 * WY
		 * Armed_Forces_Americas
		 * AA
		 * Armed_Forces
		 * AE
		 * Armed_Forces_Pacific
		 * AP
		 */
		private string StateOrProvinceField;
		public string StateOrProvince {
			get {
				return this.StateOrProvinceField;
			}
			set {
				this.StateOrProvinceField = value;
			}
		}

		/**
		 * ISO 3166 standard country code
		 * Character limit: Two single-byte characters. 		 */
		private CountryCodeType? CountryField;
		public CountryCodeType? Country {
			get {
				return this.CountryField;
			}
			set {
				this.CountryField = value;
			}
		}

		/**
		 * IMPORTANT: Do not set this element for SetExpressCheckout, DoExpressCheckoutPayment, DoDirectPayment, CreateRecurringPaymentsProfile or UpdateRecurringPaymentsProfile.
		 * This element should only be used in response elements and typically
		 * should not be used in creating request messages which specify the 
		 * name of a country using the Country element (which refers to a
		 * 2-letter country code).      
		 */
		private string CountryNameField;
		public string CountryName {
			get {
				return this.CountryNameField;
			}
			set {
				this.CountryNameField = value;
			}
		}

		/**
		 * Telephone number associated with this address		 */
		private string PhoneField;
		public string Phone {
			get {
				return this.PhoneField;
			}
			set {
				this.PhoneField = value;
			}
		}

		private string PostalCodeField;
		public string PostalCode {
			get {
				return this.PostalCodeField;
			}
			set {
				this.PostalCodeField = value;
			}
		}

		/**
		 * IMPORTANT: Do not set this element for SetExpressCheckout, DoExpressCheckoutPayment, DoDirectPayment, CreateRecurringPaymentsProfile, or UpdateRecurringPaymentsProfile.
		 */
		private string AddressIDField;
		public string AddressID {
			get {
				return this.AddressIDField;
			}
			set {
				this.AddressIDField = value;
			}
		}

		/**
		 * IMPORTANT: Do not set this element for SetExpressCheckout, DoExpressCheckoutPayment, DoDirectPayment, CreateRecurringPaymentsProfile or UpdateRecurringPaymentsProfile.
		 */
		private AddressOwnerCodeType? AddressOwnerField;
		public AddressOwnerCodeType? AddressOwner {
			get {
				return this.AddressOwnerField;
			}
			set {
				this.AddressOwnerField = value;
			}
		}

		/**
		 * IMPORTANT: Do not set this element for SetExpressCheckout, DoExpressCheckoutPayment, DoDirectPayment, CreateRecurringPaymentsProfile or UpdateRecurringPaymentsProfile.
		 */
		private string ExternalAddressIDField;
		public string ExternalAddressID {
			get {
				return this.ExternalAddressIDField;
			}
			set {
				this.ExternalAddressIDField = value;
			}
		}

		/**
		 * IMPORTANT: Do not set this element for SetExpressCheckout, DoExpressCheckoutPayment, DoDirectPayment, CreateRecurringPaymentsProfile or UpdateRecurringPaymentsProfile.
		 * Only applicable to SellerPaymentAddress today. Seller's international name that is associated with the payment address. 
		 */
		private string InternationalNameField;
		public string InternationalName {
			get {
				return this.InternationalNameField;
			}
			set {
				this.InternationalNameField = value;
			}
		}

		/**
		 * IMPORTANT: Do not set this element for SetExpressCheckout, DoExpressCheckoutPayment, DoDirectPayment, CreateRecurringPaymentsProfile or UpdateRecurringPaymentsProfile.
		 * Only applicable to SellerPaymentAddress today. International state and city for the seller's payment address. 
		 */
		private string InternationalStateAndCityField;
		public string InternationalStateAndCity {
			get {
				return this.InternationalStateAndCityField;
			}
			set {
				this.InternationalStateAndCityField = value;
			}
		}

		/**
		 * IMPORTANT: Do not set this element for SetExpressCheckout, DoExpressCheckoutPayment, DoDirectPayment, CreateRecurringPaymentsProfile or UpdateRecurringPaymentsProfile.
		 * Only applicable to SellerPaymentAddress today. Seller's international street address that is associated with the payment address.
		 */
		private string InternationalStreetField;
		public string InternationalStreet {
			get {
				return this.InternationalStreetField;
			}
			set {
				this.InternationalStreetField = value;
			}
		}

		/**
		 * Status of the address on file with PayPal.
		 * IMPORTANT: Do not set this element for SetExpressCheckout, DoExpressCheckoutPayment, DoDirectPayment, CreateRecurringPaymentsProfile or UpdateRecurringPaymentsProfile.
		 */
		private AddressStatusCodeType? AddressStatusField;
		public AddressStatusCodeType? AddressStatus {
			get {
				return this.AddressStatusField;
			}
			set {
				this.AddressStatusField = value;
			}
		}

		public AddressType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( Name != null ) {
			sb.Append("<ebl:Name>").Append(Name);
			sb.Append("</ebl:Name>");
		}
		if( Street1 != null ) {
			sb.Append("<ebl:Street1>").Append(Street1);
			sb.Append("</ebl:Street1>");
		}
		if( Street2 != null ) {
			sb.Append("<ebl:Street2>").Append(Street2);
			sb.Append("</ebl:Street2>");
		}
		if( CityName != null ) {
			sb.Append("<ebl:CityName>").Append(CityName);
			sb.Append("</ebl:CityName>");
		}
		if( StateOrProvince != null ) {
			sb.Append("<ebl:StateOrProvince>").Append(StateOrProvince);
			sb.Append("</ebl:StateOrProvince>");
		}
		if( Country != null ) {
			sb.Append("<ebl:Country>").Append(EnumUtils.getDescription(Country));
			sb.Append("</ebl:Country>");
		}
		if( CountryName != null ) {
			sb.Append("<ebl:CountryName>").Append(CountryName);
			sb.Append("</ebl:CountryName>");
		}
		if( Phone != null ) {
			sb.Append("<ebl:Phone>").Append(Phone);
			sb.Append("</ebl:Phone>");
		}
		if( PostalCode != null ) {
			sb.Append("<ebl:PostalCode>").Append(PostalCode);
			sb.Append("</ebl:PostalCode>");
		}
		if( AddressID != null ) {
			sb.Append("<ebl:AddressID>").Append(AddressID);
			sb.Append("</ebl:AddressID>");
		}
		if( AddressOwner != null ) {
			sb.Append("<ebl:AddressOwner>").Append(EnumUtils.getDescription(AddressOwner));
			sb.Append("</ebl:AddressOwner>");
		}
		if( ExternalAddressID != null ) {
			sb.Append("<ebl:ExternalAddressID>").Append(ExternalAddressID);
			sb.Append("</ebl:ExternalAddressID>");
		}
		if( InternationalName != null ) {
			sb.Append("<ebl:InternationalName>").Append(InternationalName);
			sb.Append("</ebl:InternationalName>");
		}
		if( InternationalStateAndCity != null ) {
			sb.Append("<ebl:InternationalStateAndCity>").Append(InternationalStateAndCity);
			sb.Append("</ebl:InternationalStateAndCity>");
		}
		if( InternationalStreet != null ) {
			sb.Append("<ebl:InternationalStreet>").Append(InternationalStreet);
			sb.Append("</ebl:InternationalStreet>");
		}
		if( AddressStatus != null ) {
			sb.Append("<ebl:AddressStatus>").Append(EnumUtils.getDescription(AddressStatus));
			sb.Append("</ebl:AddressStatus>");
		}
		return sb.ToString();
	}

	 public AddressType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Name").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Name")[0])){ 
		 this.Name =(string)document.GetElementsByTagName("Name")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Street1").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Street1")[0])){ 
		 this.Street1 =(string)document.GetElementsByTagName("Street1")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Street2").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Street2")[0])){ 
		 this.Street2 =(string)document.GetElementsByTagName("Street2")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("CityName").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CityName")[0])){ 
		 this.CityName =(string)document.GetElementsByTagName("CityName")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("StateOrProvince").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("StateOrProvince")[0])){ 
		 this.StateOrProvince =(string)document.GetElementsByTagName("StateOrProvince")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Country").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Country")[0])){ 
		 this.Country = (CountryCodeType)EnumUtils.getValue(document.GetElementsByTagName("Country")[0].InnerText,typeof(CountryCodeType));

}
	}
		 if(document.GetElementsByTagName("CountryName").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CountryName")[0])){ 
		 this.CountryName =(string)document.GetElementsByTagName("CountryName")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Phone").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Phone")[0])){ 
		 this.Phone =(string)document.GetElementsByTagName("Phone")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("PostalCode").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PostalCode")[0])){ 
		 this.PostalCode =(string)document.GetElementsByTagName("PostalCode")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("AddressID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AddressID")[0])){ 
		 this.AddressID =(string)document.GetElementsByTagName("AddressID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("AddressOwner").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AddressOwner")[0])){ 
		 this.AddressOwner = (AddressOwnerCodeType)EnumUtils.getValue(document.GetElementsByTagName("AddressOwner")[0].InnerText,typeof(AddressOwnerCodeType));

}
	}
		 if(document.GetElementsByTagName("ExternalAddressID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ExternalAddressID")[0])){ 
		 this.ExternalAddressID =(string)document.GetElementsByTagName("ExternalAddressID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("InternationalName").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("InternationalName")[0])){ 
		 this.InternationalName =(string)document.GetElementsByTagName("InternationalName")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("InternationalStateAndCity").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("InternationalStateAndCity")[0])){ 
		 this.InternationalStateAndCity =(string)document.GetElementsByTagName("InternationalStateAndCity")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("InternationalStreet").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("InternationalStreet")[0])){ 
		 this.InternationalStreet =(string)document.GetElementsByTagName("InternationalStreet")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("AddressStatus").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AddressStatus")[0])){ 
		 this.AddressStatus = (AddressStatusCodeType)EnumUtils.getValue(document.GetElementsByTagName("AddressStatus")[0].InnerText,typeof(AddressStatusCodeType));

}
	}
	}
	}


	/**
	 */
	public partial class AddressVerifyReq {

		private AddressVerifyRequestType AddressVerifyRequestField;
		public AddressVerifyRequestType AddressVerifyRequest {
			get {
				return this.AddressVerifyRequestField;
			}
			set {
				this.AddressVerifyRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:AddressVerifyReq>");
		if( AddressVerifyRequest != null ) {
			sb.Append("<urn:AddressVerifyRequest>");
			sb.Append(AddressVerifyRequest.toXMLString());
			sb.Append("</urn:AddressVerifyRequest>");
		}
sb.Append("</urn:AddressVerifyReq>");
		return sb.ToString();
	}

	}


	/**
	 * Email address of buyer to be verified. 
	 * Required
	 * Maximum string length: 255 single-byte characters Input mask: ?@?.??
	 */
	public partial class AddressVerifyRequestType :AbstractRequestType{

		/**
Email address of buyer to be verified. 
		 * Required
		 * Maximum string length: 255 single-byte characters Input mask: ?@?.??
		 */
		private string EmailField;
		public string Email {
			get {
				return this.EmailField;
			}
			set {
				this.EmailField = value;
			}
		}

		/**
First line of buyer’s billing or shipping street address to be verified. 
		 * Required
		 * For verification, input value of street address must match the first three single-byte characters of the street address on file for the PayPal account.
		 * Maximum string length: 35 single-byte characters Alphanumeric plus - , . ‘ # \ Whitespace and case of input value are ignored.
		 */
		private string StreetField;
		public string Street {
			get {
				return this.StreetField;
			}
			set {
				this.StreetField = value;
			}
		}

		/**
Postal code to be verified. 
		 * Required
		 * For verification, input value of postal code must match the first five single-byte characters of the postal code on file for the PayPal account.
		 * Maximum string length: 16 single-byte characters Whitespace and case of input value are ignored.
		 */
		private string ZipField;
		public string Zip {
			get {
				return this.ZipField;
			}
			set {
				this.ZipField = value;
			}
		}

		public AddressVerifyRequestType(string Email, string Street, string Zip) {
			this.Email = Email;
			this.Street = Street;
			this.Zip = Zip;
		}
		public AddressVerifyRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( Email != null ) {
			sb.Append("<urn:Email>").Append(Email);
			sb.Append("</urn:Email>");
		}
		if( Street != null ) {
			sb.Append("<urn:Street>").Append(Street);
			sb.Append("</urn:Street>");
		}
		if( Zip != null ) {
			sb.Append("<urn:Zip>").Append(Zip);
			sb.Append("</urn:Zip>");
		}
		return sb.ToString();
	}

	}


	/**
	 * Confirmation of a match, with one of the following tokens:
	 * None: The input value of the Email object does not match any email address on file at PayPal.
	 * Confirmed: If the value of the StreetMatch object is Matched, PayPal responds that the entire postal address is confirmed.
	 * Unconfirmed: PayPal responds that the postal address is unconfirmed
	 */
	public partial class AddressVerifyResponseType :AbstractResponseType{

		/**
Confirmation of a match, with one of the following tokens:
		 * None: The input value of the Email object does not match any email address on file at PayPal.
		 * Confirmed: If the value of the StreetMatch object is Matched, PayPal responds that the entire postal address is confirmed.
		 * Unconfirmed: PayPal responds that the postal address is unconfirmed		 */
		private AddressStatusCodeType? ConfirmationCodeField;
		public AddressStatusCodeType? ConfirmationCode {
			get {
				return this.ConfirmationCodeField;
			}
			set {
				this.ConfirmationCodeField = value;
			}
		}

		/**
PayPal has compared the postal address you want to verify with the postal address on file at PayPal.
		 * None: The input value of the Email object does not match any email address on file at PayPal. In addition, an error response is returned. No further comparison of other input values has been made.
		 * Matched: The street address matches the street address on file at PayPal.
		 * Unmatched: The street address does not match the street address on file at PayPal. 
		 */
		private MatchStatusCodeType? StreetMatchField;
		public MatchStatusCodeType? StreetMatch {
			get {
				return this.StreetMatchField;
			}
			set {
				this.StreetMatchField = value;
			}
		}

		/**
PayPal has compared the zip code you want to verify with the zip code on file for the email address. 
		 * None: The street address was unmatched. No further comparison of other input values has been made.
		 * Matched: The zip code matches the zip code on file at PayPal.
		 * Unmatched: The zip code does not match the zip code on file at PayPal. 
		 */
		private MatchStatusCodeType? ZipMatchField;
		public MatchStatusCodeType? ZipMatch {
			get {
				return this.ZipMatchField;
			}
			set {
				this.ZipMatchField = value;
			}
		}

		/**
Two-character country code (ISO 3166) on file for the PayPal email address. 		 */
		private CountryCodeType? CountryCodeField;
		public CountryCodeType? CountryCode {
			get {
				return this.CountryCodeField;
			}
			set {
				this.CountryCodeField = value;
			}
		}

		/**
The token prevents a buyer from using any street address other than the address on file at PayPal during additional purchases he might make from the merchant. It contains encrypted information about the user’s street address and email address. You can pass the value of the token with the Buy Now button HTML address_api_token variable so that PayPal prevents the buyer from using any street address or email address other than those verified by PayPal. The token is valid for 24 hours. 
		 * Character length and limitations: 94 single-byte characters
		 */
		private string PayPalTokenField;
		public string PayPalToken {
			get {
				return this.PayPalTokenField;
			}
			set {
				this.PayPalTokenField = value;
			}
		}

	 public AddressVerifyResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("ConfirmationCode").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ConfirmationCode")[0])){ 
		 this.ConfirmationCode = (AddressStatusCodeType)EnumUtils.getValue(document.GetElementsByTagName("ConfirmationCode")[0].InnerText,typeof(AddressStatusCodeType));

}
	}
		 if(document.GetElementsByTagName("StreetMatch").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("StreetMatch")[0])){ 
		 this.StreetMatch = (MatchStatusCodeType)EnumUtils.getValue(document.GetElementsByTagName("StreetMatch")[0].InnerText,typeof(MatchStatusCodeType));

}
	}
		 if(document.GetElementsByTagName("ZipMatch").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ZipMatch")[0])){ 
		 this.ZipMatch = (MatchStatusCodeType)EnumUtils.getValue(document.GetElementsByTagName("ZipMatch")[0].InnerText,typeof(MatchStatusCodeType));

}
	}
		 if(document.GetElementsByTagName("CountryCode").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CountryCode")[0])){ 
		 this.CountryCode = (CountryCodeType)EnumUtils.getValue(document.GetElementsByTagName("CountryCode")[0].InnerText,typeof(CountryCodeType));

}
	}
		 if(document.GetElementsByTagName("PayPalToken").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PayPalToken")[0])){ 
		 this.PayPalToken =(string)document.GetElementsByTagName("PayPalToken")[0].InnerText;

}
	}
	}
	}


	/**
	 * AID for Airlines
	 */
	public partial class AirlineItineraryType {

		private string PassengerNameField;
		public string PassengerName {
			get {
				return this.PassengerNameField;
			}
			set {
				this.PassengerNameField = value;
			}
		}

		private string IssueDateField;
		public string IssueDate {
			get {
				return this.IssueDateField;
			}
			set {
				this.IssueDateField = value;
			}
		}

		private string TravelAgencyNameField;
		public string TravelAgencyName {
			get {
				return this.TravelAgencyNameField;
			}
			set {
				this.TravelAgencyNameField = value;
			}
		}

		private string TravelAgencyCodeField;
		public string TravelAgencyCode {
			get {
				return this.TravelAgencyCodeField;
			}
			set {
				this.TravelAgencyCodeField = value;
			}
		}

		private string TicketNumberField;
		public string TicketNumber {
			get {
				return this.TicketNumberField;
			}
			set {
				this.TicketNumberField = value;
			}
		}

		private string IssuingCarrierCodeField;
		public string IssuingCarrierCode {
			get {
				return this.IssuingCarrierCodeField;
			}
			set {
				this.IssuingCarrierCodeField = value;
			}
		}

		private string CustomerCodeField;
		public string CustomerCode {
			get {
				return this.CustomerCodeField;
			}
			set {
				this.CustomerCodeField = value;
			}
		}

		private BasicAmountType TotalFareField;
		public BasicAmountType TotalFare {
			get {
				return this.TotalFareField;
			}
			set {
				this.TotalFareField = value;
			}
		}

		private BasicAmountType TotalTaxesField;
		public BasicAmountType TotalTaxes {
			get {
				return this.TotalTaxesField;
			}
			set {
				this.TotalTaxesField = value;
			}
		}

		private BasicAmountType TotalFeeField;
		public BasicAmountType TotalFee {
			get {
				return this.TotalFeeField;
			}
			set {
				this.TotalFeeField = value;
			}
		}

		private string RestrictedTicketField;
		public string RestrictedTicket {
			get {
				return this.RestrictedTicketField;
			}
			set {
				this.RestrictedTicketField = value;
			}
		}

		private string ClearingSequenceField;
		public string ClearingSequence {
			get {
				return this.ClearingSequenceField;
			}
			set {
				this.ClearingSequenceField = value;
			}
		}

		private string ClearingCountField;
		public string ClearingCount {
			get {
				return this.ClearingCountField;
			}
			set {
				this.ClearingCountField = value;
			}
		}

		private List<FlightDetailsType> FlightDetailsField = new List<FlightDetailsType>();
		public List<FlightDetailsType> FlightDetails {
			get {
				return this.FlightDetailsField;
			}
			set {
				this.FlightDetailsField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( PassengerName != null ) {
			sb.Append("<ebl:PassengerName>").Append(PassengerName);
			sb.Append("</ebl:PassengerName>");
		}
		if( IssueDate != null ) {
			sb.Append("<ebl:IssueDate>").Append(IssueDate);
			sb.Append("</ebl:IssueDate>");
		}
		if( TravelAgencyName != null ) {
			sb.Append("<ebl:TravelAgencyName>").Append(TravelAgencyName);
			sb.Append("</ebl:TravelAgencyName>");
		}
		if( TravelAgencyCode != null ) {
			sb.Append("<ebl:TravelAgencyCode>").Append(TravelAgencyCode);
			sb.Append("</ebl:TravelAgencyCode>");
		}
		if( TicketNumber != null ) {
			sb.Append("<ebl:TicketNumber>").Append(TicketNumber);
			sb.Append("</ebl:TicketNumber>");
		}
		if( IssuingCarrierCode != null ) {
			sb.Append("<ebl:IssuingCarrierCode>").Append(IssuingCarrierCode);
			sb.Append("</ebl:IssuingCarrierCode>");
		}
		if( CustomerCode != null ) {
			sb.Append("<ebl:CustomerCode>").Append(CustomerCode);
			sb.Append("</ebl:CustomerCode>");
		}
		if( TotalFare != null ) {
			sb.Append("<ebl:TotalFare ");
			sb.Append(TotalFare.toXMLString());
			sb.Append("</ebl:TotalFare>");
		}
		if( TotalTaxes != null ) {
			sb.Append("<ebl:TotalTaxes ");
			sb.Append(TotalTaxes.toXMLString());
			sb.Append("</ebl:TotalTaxes>");
		}
		if( TotalFee != null ) {
			sb.Append("<ebl:TotalFee ");
			sb.Append(TotalFee.toXMLString());
			sb.Append("</ebl:TotalFee>");
		}
		if( RestrictedTicket != null ) {
			sb.Append("<ebl:RestrictedTicket>").Append(RestrictedTicket);
			sb.Append("</ebl:RestrictedTicket>");
		}
		if( ClearingSequence != null ) {
			sb.Append("<ebl:ClearingSequence>").Append(ClearingSequence);
			sb.Append("</ebl:ClearingSequence>");
		}
		if( ClearingCount != null ) {
			sb.Append("<ebl:ClearingCount>").Append(ClearingCount);
			sb.Append("</ebl:ClearingCount>");
		}
		if( FlightDetails != null ) {
			for(int i=0; i<FlightDetails.Count; i++) {
				sb.Append("<ebl:FlightDetails>");
				sb.Append(FlightDetails[i].toXMLString());
				sb.Append("</ebl:FlightDetails>");
			}
		}
		return sb.ToString();
	}

	}


	public enum AllowedPaymentMethodType {
[Description("Default")]DEFAULT,
[Description("InstantPaymentOnly")]INSTANTPAYMENTONLY,
[Description("AnyFundingSource")]ANYFUNDINGSOURCE,
[Description("InstantFundingSource")]INSTANTFUNDINGSOURCE,
	}
	public enum ApprovalSubTypeType {
[Description("None")]NONE,
[Description("MerchantInitiatedBilling")]MERCHANTINITIATEDBILLING,
	}
	public enum ApprovalTypeType {
[Description("BillingAgreement")]BILLINGAGREEMENT,
[Description("Profile")]PROFILE,
	}
	/**
	 * AuctionInfoType 
	 * Basic information about an auction.
	 */
	public partial class AuctionInfoType {

		/**
		 * Customer's auction ID			 */
		private string BuyerIDField;
		public string BuyerID {
			get {
				return this.BuyerIDField;
			}
			set {
				this.BuyerIDField = value;
			}
		}

		/**
		 * Auction's close date 		 */
		private string ClosingDateField;
		public string ClosingDate {
			get {
				return this.ClosingDateField;
			}
			set {
				this.ClosingDateField = value;
			}
		}

	 public AuctionInfoType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("BuyerID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BuyerID")[0])){ 
		 this.BuyerID =(string)document.GetElementsByTagName("BuyerID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ClosingDate").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ClosingDate")[0])){ 
		 this.ClosingDate =(string)document.GetElementsByTagName("ClosingDate")[0].InnerText;

}
	}
	}
	}


	/**
	 * Authorization details
	 */
	public partial class AuthorizationInfoType {

		/**
		 * The status of the payment:
		 * Pending: The payment is pending. See "PendingReason" for more information.
		 */
		private PaymentStatusCodeType? PaymentStatusField;
		public PaymentStatusCodeType? PaymentStatus {
			get {
				return this.PaymentStatusField;
			}
			set {
				this.PaymentStatusField = value;
			}
		}

		/**
		 * The reason the payment is pending:
none: No pending reason
		 * address: The payment is pending because your customer did not include a confirmed shipping address and your Payment Receiving Preferences is set such that you want to manually accept or deny each of these payments. To change your preference, go to the Preferences section of your Profile.
		 * authorization: The authorization is pending at time of creation if payment is not under review
		 * echeck: The payment is pending because it was made by an eCheck that has not yet cleared.
		 * intl: The payment is pending because you hold a non-U.S. account and do not have a withdrawal mechanism. You must manually accept or deny this payment from your Account Overview.
		 * multi-currency: You do not have a balance in the currency sent, and you do not have your Payment Receiving Preferences set to automatically convert and accept this payment. You must manually accept or deny this payment.
		 * unilateral: The payment is pending because it was made to an email address that is not yet registered or confirmed.
		 * upgrade: The payment is pending because it was made via credit card and you must upgrade your account to Business or Premier status in order to receive the funds. upgrade can also mean that you have reached the monthly limit for transactions on your account.
		 * verify: The payment is pending because you are not yet verified. You must verify your account before you can accept this payment.
		 * payment_review: The payment is pending because it is under payment review.
		 * other: The payment is pending for a reason other than those listed above. For more information, contact PayPal Customer Service.
		 */
		private PendingStatusCodeType? PendingReasonField;
		public PendingStatusCodeType? PendingReason {
			get {
				return this.PendingReasonField;
			}
			set {
				this.PendingReasonField = value;
			}
		}

		/**
		 * Protection Eligibility for this Transaction - None, SPP or ESPP
		 */
		private string ProtectionEligibilityField;
		public string ProtectionEligibility {
			get {
				return this.ProtectionEligibilityField;
			}
			set {
				this.ProtectionEligibilityField = value;
			}
		}

		/**
		 * Protection Eligibility Type  for this Transaction
		 */
		private string ProtectionEligibilityTypeField;
		public string ProtectionEligibilityType {
			get {
				return this.ProtectionEligibilityTypeField;
			}
			set {
				this.ProtectionEligibilityTypeField = value;
			}
		}

	 public AuthorizationInfoType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("PaymentStatus").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentStatus")[0])){ 
		 this.PaymentStatus = (PaymentStatusCodeType)EnumUtils.getValue(document.GetElementsByTagName("PaymentStatus")[0].InnerText,typeof(PaymentStatusCodeType));

}
	}
		 if(document.GetElementsByTagName("PendingReason").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PendingReason")[0])){ 
		 this.PendingReason = (PendingStatusCodeType)EnumUtils.getValue(document.GetElementsByTagName("PendingReason")[0].InnerText,typeof(PendingStatusCodeType));

}
	}
		 if(document.GetElementsByTagName("ProtectionEligibility").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ProtectionEligibility")[0])){ 
		 this.ProtectionEligibility =(string)document.GetElementsByTagName("ProtectionEligibility")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ProtectionEligibilityType").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ProtectionEligibilityType")[0])){ 
		 this.ProtectionEligibilityType =(string)document.GetElementsByTagName("ProtectionEligibilityType")[0].InnerText;

}
	}
	}
	}


	/**
	 */
	public partial class AuthorizationRequestType {

		/**
		 */
		private bool? IsRequestedField;
		public bool? IsRequested {
			get {
				return this.IsRequestedField;
			}
			set {
				this.IsRequestedField = value;
			}
		}

		public AuthorizationRequestType(bool? IsRequested) {
			this.IsRequested = IsRequested;
		}
		public AuthorizationRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( IsRequested != null ) {
			sb.Append("<ebl:IsRequested>").Append(IsRequested);
			sb.Append("</ebl:IsRequested>");
		}
		return sb.ToString();
	}

	}


	/**
	 * Status will denote whether Auto authorization was successful or not.
	 */
	public partial class AuthorizationResponseType {

		/**
		 * Status will denote whether Auto authorization was successful or not.
		 */
		private AckCodeType? StatusField;
		public AckCodeType? Status {
			get {
				return this.StatusField;
			}
			set {
				this.StatusField = value;
			}
		}

		private List<ErrorType> AuthorizationErrorField = new List<ErrorType>();
		public List<ErrorType> AuthorizationError {
			get {
				return this.AuthorizationErrorField;
			}
			set {
				this.AuthorizationErrorField = value;
			}
		}

	 public AuthorizationResponseType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Status").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Status")[0])){ 
		 this.Status = (AckCodeType)EnumUtils.getValue(document.GetElementsByTagName("Status")[0].InnerText,typeof(AckCodeType));

}
	}
		 if(document.GetElementsByTagName("AuthorizationError").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AuthorizationError")[0])){ 
		 nodeList = document.GetElementsByTagName("AuthorizationError");
		 for(int i=0; i<nodeList.Count; i++) {
			 xmlString = DeserializationUtils.convertToXML(nodeList[i]); 
				this.AuthorizationError.Add(new ErrorType(xmlString));
			}

}
	}
	}
	}


	public enum AutoBillType {
[Description("NoAutoBill")]NOAUTOBILL,
[Description("AddToNextBilling")]ADDTONEXTBILLING,
	}
	public enum AverageMonthlyVolumeType {
[Description("AverageMonthlyVolume-Not-Applicable")]AVERAGEMONTHLYVOLUMENOTAPPLICABLE,
[Description("AverageMonthlyVolume-Range1")]AVERAGEMONTHLYVOLUMERANGE1,
[Description("AverageMonthlyVolume-Range2")]AVERAGEMONTHLYVOLUMERANGE2,
[Description("AverageMonthlyVolume-Range3")]AVERAGEMONTHLYVOLUMERANGE3,
[Description("AverageMonthlyVolume-Range4")]AVERAGEMONTHLYVOLUMERANGE4,
[Description("AverageMonthlyVolume-Range5")]AVERAGEMONTHLYVOLUMERANGE5,
[Description("AverageMonthlyVolume-Range6")]AVERAGEMONTHLYVOLUMERANGE6,
	}
	public enum AverageTransactionPriceType {
[Description("AverageTransactionPrice-Not-Applicable")]AVERAGETRANSACTIONPRICENOTAPPLICABLE,
[Description("AverageTransactionPrice-Range1")]AVERAGETRANSACTIONPRICERANGE1,
[Description("AverageTransactionPrice-Range2")]AVERAGETRANSACTIONPRICERANGE2,
[Description("AverageTransactionPrice-Range3")]AVERAGETRANSACTIONPRICERANGE3,
[Description("AverageTransactionPrice-Range4")]AVERAGETRANSACTIONPRICERANGE4,
[Description("AverageTransactionPrice-Range5")]AVERAGETRANSACTIONPRICERANGE5,
[Description("AverageTransactionPrice-Range6")]AVERAGETRANSACTIONPRICERANGE6,
[Description("AverageTransactionPrice-Range7")]AVERAGETRANSACTIONPRICERANGE7,
[Description("AverageTransactionPrice-Range8")]AVERAGETRANSACTIONPRICERANGE8,
[Description("AverageTransactionPrice-Range9")]AVERAGETRANSACTIONPRICERANGE9,
[Description("AverageTransactionPrice-Range10")]AVERAGETRANSACTIONPRICERANGE10,
	}
	/**
	 */
	public partial class BAUpdateRequestType :AbstractRequestType{

		/**
		 */
		private string ReferenceIDField;
		public string ReferenceID {
			get {
				return this.ReferenceIDField;
			}
			set {
				this.ReferenceIDField = value;
			}
		}

		/**
		 */
		private string BillingAgreementDescriptionField;
		public string BillingAgreementDescription {
			get {
				return this.BillingAgreementDescriptionField;
			}
			set {
				this.BillingAgreementDescriptionField = value;
			}
		}

		/**
		 */
		private MerchantPullStatusCodeType? BillingAgreementStatusField;
		public MerchantPullStatusCodeType? BillingAgreementStatus {
			get {
				return this.BillingAgreementStatusField;
			}
			set {
				this.BillingAgreementStatusField = value;
			}
		}

		/**
		 */
		private string BillingAgreementCustomField;
		public string BillingAgreementCustom {
			get {
				return this.BillingAgreementCustomField;
			}
			set {
				this.BillingAgreementCustomField = value;
			}
		}

		public BAUpdateRequestType(string ReferenceID) {
			this.ReferenceID = ReferenceID;
		}
		public BAUpdateRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( ReferenceID != null ) {
			sb.Append("<urn:ReferenceID>").Append(ReferenceID);
			sb.Append("</urn:ReferenceID>");
		}
		if( BillingAgreementDescription != null ) {
			sb.Append("<urn:BillingAgreementDescription>").Append(BillingAgreementDescription);
			sb.Append("</urn:BillingAgreementDescription>");
		}
		if( BillingAgreementStatus != null ) {
			sb.Append("<urn:BillingAgreementStatus>").Append(EnumUtils.getDescription(BillingAgreementStatus));
			sb.Append("</urn:BillingAgreementStatus>");
		}
		if( BillingAgreementCustom != null ) {
			sb.Append("<urn:BillingAgreementCustom>").Append(BillingAgreementCustom);
			sb.Append("</urn:BillingAgreementCustom>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class BAUpdateResponseDetailsType {

		/**
		 */
		private string BillingAgreementIDField;
		public string BillingAgreementID {
			get {
				return this.BillingAgreementIDField;
			}
			set {
				this.BillingAgreementIDField = value;
			}
		}

		/**
		 */
		private string BillingAgreementDescriptionField;
		public string BillingAgreementDescription {
			get {
				return this.BillingAgreementDescriptionField;
			}
			set {
				this.BillingAgreementDescriptionField = value;
			}
		}

		/**
		 */
		private MerchantPullStatusCodeType? BillingAgreementStatusField;
		public MerchantPullStatusCodeType? BillingAgreementStatus {
			get {
				return this.BillingAgreementStatusField;
			}
			set {
				this.BillingAgreementStatusField = value;
			}
		}

		/**
		 */
		private string BillingAgreementCustomField;
		public string BillingAgreementCustom {
			get {
				return this.BillingAgreementCustomField;
			}
			set {
				this.BillingAgreementCustomField = value;
			}
		}

		/**
		 */
		private PayerInfoType PayerInfoField;
		public PayerInfoType PayerInfo {
			get {
				return this.PayerInfoField;
			}
			set {
				this.PayerInfoField = value;
			}
		}

		/**
		 */
		private BasicAmountType BillingAgreementMaxField;
		public BasicAmountType BillingAgreementMax {
			get {
				return this.BillingAgreementMaxField;
			}
			set {
				this.BillingAgreementMaxField = value;
			}
		}

		/**
Customer's billing address.
		 * Optional
		 * If you have credit card mapped in your account then billing address of the 
		 * credit card is returned otherwise your primary address is returned , PayPal 
		 * returns this address in BAUpdateResponseDetails.
		 */
		private AddressType BillingAddressField;
		public AddressType BillingAddress {
			get {
				return this.BillingAddressField;
			}
			set {
				this.BillingAddressField = value;
			}
		}

	 public BAUpdateResponseDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("BillingAgreementID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillingAgreementID")[0])){ 
		 this.BillingAgreementID =(string)document.GetElementsByTagName("BillingAgreementID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("BillingAgreementDescription").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillingAgreementDescription")[0])){ 
		 this.BillingAgreementDescription =(string)document.GetElementsByTagName("BillingAgreementDescription")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("BillingAgreementStatus").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillingAgreementStatus")[0])){ 
		 this.BillingAgreementStatus = (MerchantPullStatusCodeType)EnumUtils.getValue(document.GetElementsByTagName("BillingAgreementStatus")[0].InnerText,typeof(MerchantPullStatusCodeType));

}
	}
		 if(document.GetElementsByTagName("BillingAgreementCustom").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillingAgreementCustom")[0])){ 
		 this.BillingAgreementCustom =(string)document.GetElementsByTagName("BillingAgreementCustom")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("PayerInfo").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PayerInfo")[0])){ 
		 nodeList = document.GetElementsByTagName("PayerInfo");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.PayerInfo =  new PayerInfoType(xmlString);

}
	}
		 if(document.GetElementsByTagName("BillingAgreementMax").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillingAgreementMax")[0])){ 
		 nodeList = document.GetElementsByTagName("BillingAgreementMax");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.BillingAgreementMax =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("BillingAddress").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillingAddress")[0])){ 
		 nodeList = document.GetElementsByTagName("BillingAddress");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.BillingAddress =  new AddressType(xmlString);

}
	}
	}
	}


	/**
	 */
	public partial class BAUpdateResponseType :AbstractResponseType{

		private BAUpdateResponseDetailsType BAUpdateResponseDetailsField;
		public BAUpdateResponseDetailsType BAUpdateResponseDetails {
			get {
				return this.BAUpdateResponseDetailsField;
			}
			set {
				this.BAUpdateResponseDetailsField = value;
			}
		}

	 public BAUpdateResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("BAUpdateResponseDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BAUpdateResponseDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("BAUpdateResponseDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.BAUpdateResponseDetails =  new BAUpdateResponseDetailsType(xmlString);

}
	}
	}
	}


	/**
	 */
	public partial class BMButtonSearchReq {

		private BMButtonSearchRequestType BMButtonSearchRequestField;
		public BMButtonSearchRequestType BMButtonSearchRequest {
			get {
				return this.BMButtonSearchRequestField;
			}
			set {
				this.BMButtonSearchRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:BMButtonSearchReq>");
		if( BMButtonSearchRequest != null ) {
			sb.Append("<urn:BMButtonSearchRequest>");
			sb.Append(BMButtonSearchRequest.toXMLString());
			sb.Append("</urn:BMButtonSearchRequest>");
		}
sb.Append("</urn:BMButtonSearchReq>");
		return sb.ToString();
	}

	}


	/**
	 * The earliest transaction date at which to start the search. No wildcards are allowed. 
	 * Required
	 */
	public partial class BMButtonSearchRequestType :AbstractRequestType{

		/**
		 * The earliest transaction date at which to start the search. No wildcards are allowed. 
		 * Required
		 */
		private string StartDateField;
		public string StartDate {
			get {
				return this.StartDateField;
			}
			set {
				this.StartDateField = value;
			}
		}

		/**
		 * The latest transaction date to be included in the search 
		 * Optional
		 */
		private string EndDateField;
		public string EndDate {
			get {
				return this.EndDateField;
			}
			set {
				this.EndDateField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( StartDate != null ) {
			sb.Append("<urn:StartDate>").Append(StartDate);
			sb.Append("</urn:StartDate>");
		}
		if( EndDate != null ) {
			sb.Append("<urn:EndDate>").Append(EndDate);
			sb.Append("</urn:EndDate>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class BMButtonSearchResponseType :AbstractResponseType{

		private List<ButtonSearchResultType> ButtonSearchResultField = new List<ButtonSearchResultType>();
		public List<ButtonSearchResultType> ButtonSearchResult {
			get {
				return this.ButtonSearchResultField;
			}
			set {
				this.ButtonSearchResultField = value;
			}
		}

	 public BMButtonSearchResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("ButtonSearchResult").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ButtonSearchResult")[0])){ 
		 nodeList = document.GetElementsByTagName("ButtonSearchResult");
		 for(int i=0; i<nodeList.Count; i++) {
			 xmlString = DeserializationUtils.convertToXML(nodeList[i]); 
				this.ButtonSearchResult.Add(new ButtonSearchResultType(xmlString));
			}

}
	}
	}
	}


	/**
	 */
	public partial class BMCreateButtonReq {

		private BMCreateButtonRequestType BMCreateButtonRequestField;
		public BMCreateButtonRequestType BMCreateButtonRequest {
			get {
				return this.BMCreateButtonRequestField;
			}
			set {
				this.BMCreateButtonRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:BMCreateButtonReq>");
		if( BMCreateButtonRequest != null ) {
			sb.Append("<urn:BMCreateButtonRequest>");
			sb.Append(BMCreateButtonRequest.toXMLString());
			sb.Append("</urn:BMCreateButtonRequest>");
		}
sb.Append("</urn:BMCreateButtonReq>");
		return sb.ToString();
	}

	}


	/**
	 * Type of Button to create.
	 * Required
	 * Must be one of the following: BUYNOW, CART, GIFTCERTIFICATE. SUBSCRIBE, PAYMENTPLAN, AUTOBILLING, DONATE, VIEWCART or UNSUBSCRIBE
	 */
	public partial class BMCreateButtonRequestType :AbstractRequestType{

		/**
		 * Type of Button to create.
		 * Required
		 * Must be one of the following: BUYNOW, CART, GIFTCERTIFICATE. SUBSCRIBE, PAYMENTPLAN, AUTOBILLING, DONATE, VIEWCART or UNSUBSCRIBE
		 */
		private ButtonTypeType? ButtonTypeField;
		public ButtonTypeType? ButtonType {
			get {
				return this.ButtonTypeField;
			}
			set {
				this.ButtonTypeField = value;
			}
		}

		/**
		 * button code.
		 * optional
		 * Must be one of the following: hosted, encrypted or cleartext
		 */
		private ButtonCodeType? ButtonCodeField;
		public ButtonCodeType? ButtonCode {
			get {
				return this.ButtonCodeField;
			}
			set {
				this.ButtonCodeField = value;
			}
		}

		/**
		 * Button sub type.
		 * optional for button types buynow and cart only
		 * Must Be either PRODUCTS or SERVICES
		 */
		private ButtonSubTypeType? ButtonSubTypeField;
		public ButtonSubTypeType? ButtonSubType {
			get {
				return this.ButtonSubTypeField;
			}
			set {
				this.ButtonSubTypeField = value;
			}
		}

		/**
		 * Button Variable information
		 * At least one required recurring
		 * Character length and limitations: 63 single-byte alphanumeric characters
		 */
		private List<string> ButtonVarField = new List<string>();
		public List<string> ButtonVar {
			get {
				return this.ButtonVarField;
			}
			set {
				this.ButtonVarField = value;
			}
		}

		private List<OptionDetailsType> OptionDetailsField = new List<OptionDetailsType>();
		public List<OptionDetailsType> OptionDetails {
			get {
				return this.OptionDetailsField;
			}
			set {
				this.OptionDetailsField = value;
			}
		}

		/**
		 * Details of each option for the button.
		 * Optional
		 */
		private List<string> TextBoxField = new List<string>();
		public List<string> TextBox {
			get {
				return this.TextBoxField;
			}
			set {
				this.TextBoxField = value;
			}
		}

		/**
		 * Button image to use.
		 * Optional
		 * Must be one of: REG, SML, or CC
		 */
		private ButtonImageType? ButtonImageField;
		public ButtonImageType? ButtonImage {
			get {
				return this.ButtonImageField;
			}
			set {
				this.ButtonImageField = value;
			}
		}

		/**
		 * Button URL for custom button image.
		 * Optional
		 * Character length and limitations: 127 single-byte alphanumeric characters
		 */
		private string ButtonImageURLField;
		public string ButtonImageURL {
			get {
				return this.ButtonImageURLField;
			}
			set {
				this.ButtonImageURLField = value;
			}
		}

		/**
		 * Text to use on Buy Now Button.
		 * Optional
		 * Must be either BUYNOW or PAYNOW
		 */
		private BuyNowTextType? BuyNowTextField;
		public BuyNowTextType? BuyNowText {
			get {
				return this.BuyNowTextField;
			}
			set {
				this.BuyNowTextField = value;
			}
		}

		/**
		 * Text to use on Subscribe button.
		 * Optional
		 * Must be either BUYNOW or SUBSCRIBE
		 */
		private SubscribeTextType? SubscribeTextField;
		public SubscribeTextType? SubscribeText {
			get {
				return this.SubscribeTextField;
			}
			set {
				this.SubscribeTextField = value;
			}
		}

		/**
		 * Button Country.
		 * Optional
		 * Must be valid ISO country code
		 */
		private CountryCodeType? ButtonCountryField;
		public CountryCodeType? ButtonCountry {
			get {
				return this.ButtonCountryField;
			}
			set {
				this.ButtonCountryField = value;
			}
		}

		/**
		 * Button language code.
		 * Optional
		 * Character length and limitations: 3 single-byte alphanumeric characters
		 */
		private string ButtonLanguageField;
		public string ButtonLanguage {
			get {
				return this.ButtonLanguageField;
			}
			set {
				this.ButtonLanguageField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( ButtonType != null ) {
			sb.Append("<urn:ButtonType>").Append(EnumUtils.getDescription(ButtonType));
			sb.Append("</urn:ButtonType>");
		}
		if( ButtonCode != null ) {
			sb.Append("<urn:ButtonCode>").Append(EnumUtils.getDescription(ButtonCode));
			sb.Append("</urn:ButtonCode>");
		}
		if( ButtonSubType != null ) {
			sb.Append("<urn:ButtonSubType>").Append(EnumUtils.getDescription(ButtonSubType));
			sb.Append("</urn:ButtonSubType>");
		}
		if( ButtonVar != null ) {
			for(int i=0; i<ButtonVar.Count; i++) {
				sb.Append("<urn:ButtonVar>").Append(ButtonVar[i]);
				sb.Append("</urn:ButtonVar>");
			}
		}
		if( OptionDetails != null ) {
			for(int i=0; i<OptionDetails.Count; i++) {
				sb.Append("<urn:OptionDetails>");
				sb.Append(OptionDetails[i].toXMLString());
				sb.Append("</urn:OptionDetails>");
			}
		}
		if( TextBox != null ) {
			for(int i=0; i<TextBox.Count; i++) {
				sb.Append("<urn:TextBox>").Append(TextBox[i]);
				sb.Append("</urn:TextBox>");
			}
		}
		if( ButtonImage != null ) {
			sb.Append("<urn:ButtonImage>").Append(EnumUtils.getDescription(ButtonImage));
			sb.Append("</urn:ButtonImage>");
		}
		if( ButtonImageURL != null ) {
			sb.Append("<urn:ButtonImageURL>").Append(ButtonImageURL);
			sb.Append("</urn:ButtonImageURL>");
		}
		if( BuyNowText != null ) {
			sb.Append("<urn:BuyNowText>").Append(EnumUtils.getDescription(BuyNowText));
			sb.Append("</urn:BuyNowText>");
		}
		if( SubscribeText != null ) {
			sb.Append("<urn:SubscribeText>").Append(EnumUtils.getDescription(SubscribeText));
			sb.Append("</urn:SubscribeText>");
		}
		if( ButtonCountry != null ) {
			sb.Append("<urn:ButtonCountry>").Append(EnumUtils.getDescription(ButtonCountry));
			sb.Append("</urn:ButtonCountry>");
		}
		if( ButtonLanguage != null ) {
			sb.Append("<urn:ButtonLanguage>").Append(ButtonLanguage);
			sb.Append("</urn:ButtonLanguage>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class BMCreateButtonResponseType :AbstractResponseType{

		private string WebsiteField;
		public string Website {
			get {
				return this.WebsiteField;
			}
			set {
				this.WebsiteField = value;
			}
		}

		private string EmailField;
		public string Email {
			get {
				return this.EmailField;
			}
			set {
				this.EmailField = value;
			}
		}

		private string MobileField;
		public string Mobile {
			get {
				return this.MobileField;
			}
			set {
				this.MobileField = value;
			}
		}

		private string HostedButtonIDField;
		public string HostedButtonID {
			get {
				return this.HostedButtonIDField;
			}
			set {
				this.HostedButtonIDField = value;
			}
		}

	 public BMCreateButtonResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Website").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Website")[0])){ 
		 this.Website =(string)document.GetElementsByTagName("Website")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Email").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Email")[0])){ 
		 this.Email =(string)document.GetElementsByTagName("Email")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Mobile").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Mobile")[0])){ 
		 this.Mobile =(string)document.GetElementsByTagName("Mobile")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("HostedButtonID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("HostedButtonID")[0])){ 
		 this.HostedButtonID =(string)document.GetElementsByTagName("HostedButtonID")[0].InnerText;

}
	}
	}
	}


	/**
	 */
	public partial class BMGetButtonDetailsReq {

		private BMGetButtonDetailsRequestType BMGetButtonDetailsRequestField;
		public BMGetButtonDetailsRequestType BMGetButtonDetailsRequest {
			get {
				return this.BMGetButtonDetailsRequestField;
			}
			set {
				this.BMGetButtonDetailsRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:BMGetButtonDetailsReq>");
		if( BMGetButtonDetailsRequest != null ) {
			sb.Append("<urn:BMGetButtonDetailsRequest>");
			sb.Append(BMGetButtonDetailsRequest.toXMLString());
			sb.Append("</urn:BMGetButtonDetailsRequest>");
		}
sb.Append("</urn:BMGetButtonDetailsReq>");
		return sb.ToString();
	}

	}


	/**
	 * Button ID of button to return.
	 * Required
	 * Character length and limitations: 10 single-byte numeric characters
	 */
	public partial class BMGetButtonDetailsRequestType :AbstractRequestType{

		/**
		 * Button ID of button to return.
		 * Required
		 * Character length and limitations: 10 single-byte numeric characters
		 */
		private string HostedButtonIDField;
		public string HostedButtonID {
			get {
				return this.HostedButtonIDField;
			}
			set {
				this.HostedButtonIDField = value;
			}
		}

		public BMGetButtonDetailsRequestType(string HostedButtonID) {
			this.HostedButtonID = HostedButtonID;
		}
		public BMGetButtonDetailsRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( HostedButtonID != null ) {
			sb.Append("<urn:HostedButtonID>").Append(HostedButtonID);
			sb.Append("</urn:HostedButtonID>");
		}
		return sb.ToString();
	}

	}


	/**
	 * Type of button.
	 * One of the following: BUYNOW, CART, GIFTCERTIFICATE. SUBSCRIBE, PAYMENTPLAN, AUTOBILLING, DONATE, VIEWCART or UNSUBSCRIBE
	 */
	public partial class BMGetButtonDetailsResponseType :AbstractResponseType{

		private string WebsiteField;
		public string Website {
			get {
				return this.WebsiteField;
			}
			set {
				this.WebsiteField = value;
			}
		}

		private string EmailField;
		public string Email {
			get {
				return this.EmailField;
			}
			set {
				this.EmailField = value;
			}
		}

		private string MobileField;
		public string Mobile {
			get {
				return this.MobileField;
			}
			set {
				this.MobileField = value;
			}
		}

		private string HostedButtonIDField;
		public string HostedButtonID {
			get {
				return this.HostedButtonIDField;
			}
			set {
				this.HostedButtonIDField = value;
			}
		}

		/**
		 * Type of button.
		 * One of the following: BUYNOW, CART, GIFTCERTIFICATE. SUBSCRIBE, PAYMENTPLAN, AUTOBILLING, DONATE, VIEWCART or UNSUBSCRIBE
		 */
		private ButtonTypeType? ButtonTypeField;
		public ButtonTypeType? ButtonType {
			get {
				return this.ButtonTypeField;
			}
			set {
				this.ButtonTypeField = value;
			}
		}

		/**
		 * Type of button code.
		 * One of the following: hosted, encrypted or cleartext
		 */
		private ButtonCodeType? ButtonCodeField;
		public ButtonCodeType? ButtonCode {
			get {
				return this.ButtonCodeField;
			}
			set {
				this.ButtonCodeField = value;
			}
		}

		/**
		 * Button sub type.
		 * optional for button types buynow and cart only
		 * Either PRODUCTS or SERVICES
		 */
		private ButtonSubTypeType? ButtonSubTypeField;
		public ButtonSubTypeType? ButtonSubType {
			get {
				return this.ButtonSubTypeField;
			}
			set {
				this.ButtonSubTypeField = value;
			}
		}

		/**
		 * Button Variable information
		 * Character length and limitations: 63 single-byte alphanumeric characters
		 */
		private List<string> ButtonVarField = new List<string>();
		public List<string> ButtonVar {
			get {
				return this.ButtonVarField;
			}
			set {
				this.ButtonVarField = value;
			}
		}

		private List<OptionDetailsType> OptionDetailsField = new List<OptionDetailsType>();
		public List<OptionDetailsType> OptionDetails {
			get {
				return this.OptionDetailsField;
			}
			set {
				this.OptionDetailsField = value;
			}
		}

		/**
		 * Text field
		 */
		private List<string> TextBoxField = new List<string>();
		public List<string> TextBox {
			get {
				return this.TextBoxField;
			}
			set {
				this.TextBoxField = value;
			}
		}

		/**
		 * Button image to use.
		 * One of: REG, SML, or CC
		 */
		private ButtonImageType? ButtonImageField;
		public ButtonImageType? ButtonImage {
			get {
				return this.ButtonImageField;
			}
			set {
				this.ButtonImageField = value;
			}
		}

		/**
		 * Button URL for custom button image.
		 */
		private string ButtonImageURLField;
		public string ButtonImageURL {
			get {
				return this.ButtonImageURLField;
			}
			set {
				this.ButtonImageURLField = value;
			}
		}

		/**
		 * Text to use on Buy Now Button.
		 * Either BUYNOW or PAYNOW
		 */
		private BuyNowTextType? BuyNowTextField;
		public BuyNowTextType? BuyNowText {
			get {
				return this.BuyNowTextField;
			}
			set {
				this.BuyNowTextField = value;
			}
		}

		/**
		 * Text to use on Subscribe button.
		 * Must be either BUYNOW or SUBSCRIBE
		 */
		private SubscribeTextType? SubscribeTextField;
		public SubscribeTextType? SubscribeText {
			get {
				return this.SubscribeTextField;
			}
			set {
				this.SubscribeTextField = value;
			}
		}

		/**
		 * Button Country.
		 * Valid ISO country code or 'International'
		 */
		private CountryCodeType? ButtonCountryField;
		public CountryCodeType? ButtonCountry {
			get {
				return this.ButtonCountryField;
			}
			set {
				this.ButtonCountryField = value;
			}
		}

		/**
		 * Button language code.
		 * Character length and limitations: 3 single-byte alphanumeric characters
		 */
		private string ButtonLanguageField;
		public string ButtonLanguage {
			get {
				return this.ButtonLanguageField;
			}
			set {
				this.ButtonLanguageField = value;
			}
		}

	 public BMGetButtonDetailsResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Website").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Website")[0])){ 
		 this.Website =(string)document.GetElementsByTagName("Website")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Email").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Email")[0])){ 
		 this.Email =(string)document.GetElementsByTagName("Email")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Mobile").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Mobile")[0])){ 
		 this.Mobile =(string)document.GetElementsByTagName("Mobile")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("HostedButtonID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("HostedButtonID")[0])){ 
		 this.HostedButtonID =(string)document.GetElementsByTagName("HostedButtonID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ButtonType").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ButtonType")[0])){ 
		 this.ButtonType = (ButtonTypeType)EnumUtils.getValue(document.GetElementsByTagName("ButtonType")[0].InnerText,typeof(ButtonTypeType));

}
	}
		 if(document.GetElementsByTagName("ButtonCode").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ButtonCode")[0])){ 
		 this.ButtonCode = (ButtonCodeType)EnumUtils.getValue(document.GetElementsByTagName("ButtonCode")[0].InnerText,typeof(ButtonCodeType));

}
	}
		 if(document.GetElementsByTagName("ButtonSubType").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ButtonSubType")[0])){ 
		 this.ButtonSubType = (ButtonSubTypeType)EnumUtils.getValue(document.GetElementsByTagName("ButtonSubType")[0].InnerText,typeof(ButtonSubTypeType));

}
	}
		 if(document.GetElementsByTagName("ButtonVar").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ButtonVar")[0])){ 
		 nodeList = document.GetElementsByTagName("ButtonVar");
		 for(int i=0; i<nodeList.Count; i++) {
			 string value = nodeList[i].InnerText; 
			 this.ButtonVar.Add(value);
		}

}
	}
		 if(document.GetElementsByTagName("OptionDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OptionDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("OptionDetails");
		 for(int i=0; i<nodeList.Count; i++) {
			 xmlString = DeserializationUtils.convertToXML(nodeList[i]); 
				this.OptionDetails.Add(new OptionDetailsType(xmlString));
			}

}
	}
		 if(document.GetElementsByTagName("TextBox").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TextBox")[0])){ 
		 nodeList = document.GetElementsByTagName("TextBox");
		 for(int i=0; i<nodeList.Count; i++) {
			 string value = nodeList[i].InnerText; 
			 this.TextBox.Add(value);
		}

}
	}
		 if(document.GetElementsByTagName("ButtonImage").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ButtonImage")[0])){ 
		 this.ButtonImage = (ButtonImageType)EnumUtils.getValue(document.GetElementsByTagName("ButtonImage")[0].InnerText,typeof(ButtonImageType));

}
	}
		 if(document.GetElementsByTagName("ButtonImageURL").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ButtonImageURL")[0])){ 
		 this.ButtonImageURL =(string)document.GetElementsByTagName("ButtonImageURL")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("BuyNowText").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BuyNowText")[0])){ 
		 this.BuyNowText = (BuyNowTextType)EnumUtils.getValue(document.GetElementsByTagName("BuyNowText")[0].InnerText,typeof(BuyNowTextType));

}
	}
		 if(document.GetElementsByTagName("SubscribeText").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SubscribeText")[0])){ 
		 this.SubscribeText = (SubscribeTextType)EnumUtils.getValue(document.GetElementsByTagName("SubscribeText")[0].InnerText,typeof(SubscribeTextType));

}
	}
		 if(document.GetElementsByTagName("ButtonCountry").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ButtonCountry")[0])){ 
		 this.ButtonCountry = (CountryCodeType)EnumUtils.getValue(document.GetElementsByTagName("ButtonCountry")[0].InnerText,typeof(CountryCodeType));

}
	}
		 if(document.GetElementsByTagName("ButtonLanguage").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ButtonLanguage")[0])){ 
		 this.ButtonLanguage =(string)document.GetElementsByTagName("ButtonLanguage")[0].InnerText;

}
	}
	}
	}


	/**
	 */
	public partial class BMGetInventoryReq {

		private BMGetInventoryRequestType BMGetInventoryRequestField;
		public BMGetInventoryRequestType BMGetInventoryRequest {
			get {
				return this.BMGetInventoryRequestField;
			}
			set {
				this.BMGetInventoryRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:BMGetInventoryReq>");
		if( BMGetInventoryRequest != null ) {
			sb.Append("<urn:BMGetInventoryRequest>");
			sb.Append(BMGetInventoryRequest.toXMLString());
			sb.Append("</urn:BMGetInventoryRequest>");
		}
sb.Append("</urn:BMGetInventoryReq>");
		return sb.ToString();
	}

	}


	/**
	 * Hosted Button ID of the button to return inventory for.
	 * Required
	 * Character length and limitations: 10 single-byte numeric characters
	 */
	public partial class BMGetInventoryRequestType :AbstractRequestType{

		/**
		 * Hosted Button ID of the button to return inventory for.
		 * Required
		 * Character length and limitations: 10 single-byte numeric characters
		 */
		private string HostedButtonIDField;
		public string HostedButtonID {
			get {
				return this.HostedButtonIDField;
			}
			set {
				this.HostedButtonIDField = value;
			}
		}

		public BMGetInventoryRequestType(string HostedButtonID) {
			this.HostedButtonID = HostedButtonID;
		}
		public BMGetInventoryRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( HostedButtonID != null ) {
			sb.Append("<urn:HostedButtonID>").Append(HostedButtonID);
			sb.Append("</urn:HostedButtonID>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class BMGetInventoryResponseType :AbstractResponseType{

		private string HostedButtonIDField;
		public string HostedButtonID {
			get {
				return this.HostedButtonIDField;
			}
			set {
				this.HostedButtonIDField = value;
			}
		}

		private string TrackInvField;
		public string TrackInv {
			get {
				return this.TrackInvField;
			}
			set {
				this.TrackInvField = value;
			}
		}

		private string TrackPnlField;
		public string TrackPnl {
			get {
				return this.TrackPnlField;
			}
			set {
				this.TrackPnlField = value;
			}
		}

		private ItemTrackingDetailsType ItemTrackingDetailsField;
		public ItemTrackingDetailsType ItemTrackingDetails {
			get {
				return this.ItemTrackingDetailsField;
			}
			set {
				this.ItemTrackingDetailsField = value;
			}
		}

		private string OptionIndexField;
		public string OptionIndex {
			get {
				return this.OptionIndexField;
			}
			set {
				this.OptionIndexField = value;
			}
		}

		private string OptionNameField;
		public string OptionName {
			get {
				return this.OptionNameField;
			}
			set {
				this.OptionNameField = value;
			}
		}

		private List<OptionTrackingDetailsType> OptionTrackingDetailsField = new List<OptionTrackingDetailsType>();
		public List<OptionTrackingDetailsType> OptionTrackingDetails {
			get {
				return this.OptionTrackingDetailsField;
			}
			set {
				this.OptionTrackingDetailsField = value;
			}
		}

		private string SoldoutURLField;
		public string SoldoutURL {
			get {
				return this.SoldoutURLField;
			}
			set {
				this.SoldoutURLField = value;
			}
		}

		private List<string> DigitalDownloadKeysField = new List<string>();
		public List<string> DigitalDownloadKeys {
			get {
				return this.DigitalDownloadKeysField;
			}
			set {
				this.DigitalDownloadKeysField = value;
			}
		}

	 public BMGetInventoryResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("HostedButtonID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("HostedButtonID")[0])){ 
		 this.HostedButtonID =(string)document.GetElementsByTagName("HostedButtonID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("TrackInv").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TrackInv")[0])){ 
		 this.TrackInv =(string)document.GetElementsByTagName("TrackInv")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("TrackPnl").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TrackPnl")[0])){ 
		 this.TrackPnl =(string)document.GetElementsByTagName("TrackPnl")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ItemTrackingDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ItemTrackingDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("ItemTrackingDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.ItemTrackingDetails =  new ItemTrackingDetailsType(xmlString);

}
	}
		 if(document.GetElementsByTagName("OptionIndex").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OptionIndex")[0])){ 
		 this.OptionIndex =(string)document.GetElementsByTagName("OptionIndex")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("OptionName").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OptionName")[0])){ 
		 this.OptionName =(string)document.GetElementsByTagName("OptionName")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("OptionTrackingDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OptionTrackingDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("OptionTrackingDetails");
		 for(int i=0; i<nodeList.Count; i++) {
			 xmlString = DeserializationUtils.convertToXML(nodeList[i]); 
				this.OptionTrackingDetails.Add(new OptionTrackingDetailsType(xmlString));
			}

}
	}
		 if(document.GetElementsByTagName("SoldoutURL").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SoldoutURL")[0])){ 
		 this.SoldoutURL =(string)document.GetElementsByTagName("SoldoutURL")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("DigitalDownloadKeys").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("DigitalDownloadKeys")[0])){ 
		 nodeList = document.GetElementsByTagName("DigitalDownloadKeys");
		 for(int i=0; i<nodeList.Count; i++) {
			 string value = nodeList[i].InnerText; 
			 this.DigitalDownloadKeys.Add(value);
		}

}
	}
	}
	}


	/**
	 * BMLOfferInfoType
	 * Specific information for BML.
	 */
	public partial class BMLOfferInfoType {

		/**
		 * Unique identification for merchant/buyer/offer combo.
		 */
		private string OfferTrackingIDField;
		public string OfferTrackingID {
			get {
				return this.OfferTrackingIDField;
			}
			set {
				this.OfferTrackingIDField = value;
			}
		}

		public BMLOfferInfoType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( OfferTrackingID != null ) {
			sb.Append("<ebl:OfferTrackingID>").Append(OfferTrackingID);
			sb.Append("</ebl:OfferTrackingID>");
		}
		return sb.ToString();
	}

	 public BMLOfferInfoType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("OfferTrackingID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OfferTrackingID")[0])){ 
		 nodeList = document.GetElementsByTagName("OfferTrackingID");
			 string value = nodeList[0].InnerText; 
		 this.OfferTrackingID =value;

}
	}
	}
	}


	/**
	 */
	public partial class BMManageButtonStatusReq {

		private BMManageButtonStatusRequestType BMManageButtonStatusRequestField;
		public BMManageButtonStatusRequestType BMManageButtonStatusRequest {
			get {
				return this.BMManageButtonStatusRequestField;
			}
			set {
				this.BMManageButtonStatusRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:BMManageButtonStatusReq>");
		if( BMManageButtonStatusRequest != null ) {
			sb.Append("<urn:BMManageButtonStatusRequest>");
			sb.Append(BMManageButtonStatusRequest.toXMLString());
			sb.Append("</urn:BMManageButtonStatusRequest>");
		}
sb.Append("</urn:BMManageButtonStatusReq>");
		return sb.ToString();
	}

	}


	/**
	 * Button ID of Hosted button.
	 * Required
	 * Character length and limitations: 10 single-byte numeric characters
	 */
	public partial class BMManageButtonStatusRequestType :AbstractRequestType{

		/**
		 * Button ID of Hosted button.
		 * Required
		 * Character length and limitations: 10 single-byte numeric characters
		 */
		private string HostedButtonIDField;
		public string HostedButtonID {
			get {
				return this.HostedButtonIDField;
			}
			set {
				this.HostedButtonIDField = value;
			}
		}

		/**
		 * Requested Status change for hosted button.
		 * Required
		 * Character length and limitations: 1 single-byte alphanumeric characters
		 */
		private ButtonStatusType? ButtonStatusField;
		public ButtonStatusType? ButtonStatus {
			get {
				return this.ButtonStatusField;
			}
			set {
				this.ButtonStatusField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( HostedButtonID != null ) {
			sb.Append("<urn:HostedButtonID>").Append(HostedButtonID);
			sb.Append("</urn:HostedButtonID>");
		}
		if( ButtonStatus != null ) {
			sb.Append("<urn:ButtonStatus>").Append(EnumUtils.getDescription(ButtonStatus));
			sb.Append("</urn:ButtonStatus>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class BMManageButtonStatusResponseType :AbstractResponseType{

	 public BMManageButtonStatusResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
	}
	}


	/**
	 */
	public partial class BMSetInventoryReq {

		private BMSetInventoryRequestType BMSetInventoryRequestField;
		public BMSetInventoryRequestType BMSetInventoryRequest {
			get {
				return this.BMSetInventoryRequestField;
			}
			set {
				this.BMSetInventoryRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:BMSetInventoryReq>");
		if( BMSetInventoryRequest != null ) {
			sb.Append("<urn:BMSetInventoryRequest>");
			sb.Append(BMSetInventoryRequest.toXMLString());
			sb.Append("</urn:BMSetInventoryRequest>");
		}
sb.Append("</urn:BMSetInventoryReq>");
		return sb.ToString();
	}

	}


	/**
	 * Hosted Button ID of button you wish to change.
	 * Required
	 * Character length and limitations: 10 single-byte numeric characters
	 */
	public partial class BMSetInventoryRequestType :AbstractRequestType{

		/**
		 * Hosted Button ID of button you wish to change.
		 * Required
		 * Character length and limitations: 10 single-byte numeric characters
		 */
		private string HostedButtonIDField;
		public string HostedButtonID {
			get {
				return this.HostedButtonIDField;
			}
			set {
				this.HostedButtonIDField = value;
			}
		}

		/**
		 * Is Inventory tracked.
		 * Required
		 * 0 or 1
		 */
		private string TrackInvField;
		public string TrackInv {
			get {
				return this.TrackInvField;
			}
			set {
				this.TrackInvField = value;
			}
		}

		/**
		 * Is PNL Tracked.
		 * Required
		 * 0 or 1
		 */
		private string TrackPnlField;
		public string TrackPnl {
			get {
				return this.TrackPnlField;
			}
			set {
				this.TrackPnlField = value;
			}
		}

		private ItemTrackingDetailsType ItemTrackingDetailsField;
		public ItemTrackingDetailsType ItemTrackingDetails {
			get {
				return this.ItemTrackingDetailsField;
			}
			set {
				this.ItemTrackingDetailsField = value;
			}
		}

		/**
		 * Option Index.
		 * Optional
		 * Character length and limitations: 1 single-byte alphanumeric characters
		 */
		private string OptionIndexField;
		public string OptionIndex {
			get {
				return this.OptionIndexField;
			}
			set {
				this.OptionIndexField = value;
			}
		}

		private List<OptionTrackingDetailsType> OptionTrackingDetailsField = new List<OptionTrackingDetailsType>();
		public List<OptionTrackingDetailsType> OptionTrackingDetails {
			get {
				return this.OptionTrackingDetailsField;
			}
			set {
				this.OptionTrackingDetailsField = value;
			}
		}

		/**
		 * URL of page to display when an item is soldout.
		 * Optional
		 * Character length and limitations: 127 single-byte alphanumeric characters
		 */
		private string SoldoutURLField;
		public string SoldoutURL {
			get {
				return this.SoldoutURLField;
			}
			set {
				this.SoldoutURLField = value;
			}
		}

		/**
		 * Whether to use the same digital download key repeatedly.
		 * Optional
		 */
		private string ReuseDigitalDownloadKeysField;
		public string ReuseDigitalDownloadKeys {
			get {
				return this.ReuseDigitalDownloadKeysField;
			}
			set {
				this.ReuseDigitalDownloadKeysField = value;
			}
		}

		/**
		 * Whether to append these keys to the list or not (replace).
		 * Optional
		 */
		private string AppendDigitalDownloadKeysField;
		public string AppendDigitalDownloadKeys {
			get {
				return this.AppendDigitalDownloadKeysField;
			}
			set {
				this.AppendDigitalDownloadKeysField = value;
			}
		}

		/**
		 * Zero or more digital download keys to distribute to customers after transaction is completed.
		 * Optional
		 * Character length and limitations: 1000 single-byte alphanumeric characters
		 */
		private List<string> DigitalDownloadKeysField = new List<string>();
		public List<string> DigitalDownloadKeys {
			get {
				return this.DigitalDownloadKeysField;
			}
			set {
				this.DigitalDownloadKeysField = value;
			}
		}

		public BMSetInventoryRequestType(string HostedButtonID, string TrackInv, string TrackPnl) {
			this.HostedButtonID = HostedButtonID;
			this.TrackInv = TrackInv;
			this.TrackPnl = TrackPnl;
		}
		public BMSetInventoryRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( HostedButtonID != null ) {
			sb.Append("<urn:HostedButtonID>").Append(HostedButtonID);
			sb.Append("</urn:HostedButtonID>");
		}
		if( TrackInv != null ) {
			sb.Append("<urn:TrackInv>").Append(TrackInv);
			sb.Append("</urn:TrackInv>");
		}
		if( TrackPnl != null ) {
			sb.Append("<urn:TrackPnl>").Append(TrackPnl);
			sb.Append("</urn:TrackPnl>");
		}
		if( ItemTrackingDetails != null ) {
			sb.Append("<ebl:ItemTrackingDetails>");
			sb.Append(ItemTrackingDetails.toXMLString());
			sb.Append("</ebl:ItemTrackingDetails>");
		}
		if( OptionIndex != null ) {
			sb.Append("<urn:OptionIndex>").Append(OptionIndex);
			sb.Append("</urn:OptionIndex>");
		}
		if( OptionTrackingDetails != null ) {
			for(int i=0; i<OptionTrackingDetails.Count; i++) {
				sb.Append("<ebl:OptionTrackingDetails>");
				sb.Append(OptionTrackingDetails[i].toXMLString());
				sb.Append("</ebl:OptionTrackingDetails>");
			}
		}
		if( SoldoutURL != null ) {
			sb.Append("<urn:SoldoutURL>").Append(SoldoutURL);
			sb.Append("</urn:SoldoutURL>");
		}
		if( ReuseDigitalDownloadKeys != null ) {
			sb.Append("<urn:ReuseDigitalDownloadKeys>").Append(ReuseDigitalDownloadKeys);
			sb.Append("</urn:ReuseDigitalDownloadKeys>");
		}
		if( AppendDigitalDownloadKeys != null ) {
			sb.Append("<urn:AppendDigitalDownloadKeys>").Append(AppendDigitalDownloadKeys);
			sb.Append("</urn:AppendDigitalDownloadKeys>");
		}
		if( DigitalDownloadKeys != null ) {
			for(int i=0; i<DigitalDownloadKeys.Count; i++) {
				sb.Append("<urn:DigitalDownloadKeys>").Append(DigitalDownloadKeys[i]);
				sb.Append("</urn:DigitalDownloadKeys>");
			}
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class BMSetInventoryResponseType :AbstractResponseType{

	 public BMSetInventoryResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
	}
	}


	/**
	 */
	public partial class BMUpdateButtonReq {

		private BMUpdateButtonRequestType BMUpdateButtonRequestField;
		public BMUpdateButtonRequestType BMUpdateButtonRequest {
			get {
				return this.BMUpdateButtonRequestField;
			}
			set {
				this.BMUpdateButtonRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:BMUpdateButtonReq>");
		if( BMUpdateButtonRequest != null ) {
			sb.Append("<urn:BMUpdateButtonRequest>");
			sb.Append(BMUpdateButtonRequest.toXMLString());
			sb.Append("</urn:BMUpdateButtonRequest>");
		}
sb.Append("</urn:BMUpdateButtonReq>");
		return sb.ToString();
	}

	}


	/**
	 * Hosted Button id of the button to update.
	 * Required
	 * Character length and limitations: 10 single-byte numeric characters
	 */
	public partial class BMUpdateButtonRequestType :AbstractRequestType{

		/**
		 * Hosted Button id of the button to update.
		 * Required
		 * Character length and limitations: 10 single-byte numeric characters
		 */
		private string HostedButtonIDField;
		public string HostedButtonID {
			get {
				return this.HostedButtonIDField;
			}
			set {
				this.HostedButtonIDField = value;
			}
		}

		/**
		 * Type of Button to create.
		 * Required
		 * Must be one of the following: BUYNOW, CART, GIFTCERTIFICATE. SUBSCRIBE, PAYMENTPLAN, AUTOBILLING, DONATE, VIEWCART or UNSUBSCRIBE
		 */
		private ButtonTypeType? ButtonTypeField;
		public ButtonTypeType? ButtonType {
			get {
				return this.ButtonTypeField;
			}
			set {
				this.ButtonTypeField = value;
			}
		}

		/**
		 * button code.
		 * optional
		 * Must be one of the following: hosted, encrypted or cleartext
		 */
		private ButtonCodeType? ButtonCodeField;
		public ButtonCodeType? ButtonCode {
			get {
				return this.ButtonCodeField;
			}
			set {
				this.ButtonCodeField = value;
			}
		}

		/**
		 * Button sub type.
		 * optional for button types buynow and cart only
		 * Must Be either PRODUCTS or SERVICES
		 */
		private ButtonSubTypeType? ButtonSubTypeField;
		public ButtonSubTypeType? ButtonSubType {
			get {
				return this.ButtonSubTypeField;
			}
			set {
				this.ButtonSubTypeField = value;
			}
		}

		/**
		 * Button Variable information
		 * At least one required recurring
		 * Character length and limitations: 63 single-byte alphanumeric characters
		 */
		private List<string> ButtonVarField = new List<string>();
		public List<string> ButtonVar {
			get {
				return this.ButtonVarField;
			}
			set {
				this.ButtonVarField = value;
			}
		}

		private List<OptionDetailsType> OptionDetailsField = new List<OptionDetailsType>();
		public List<OptionDetailsType> OptionDetails {
			get {
				return this.OptionDetailsField;
			}
			set {
				this.OptionDetailsField = value;
			}
		}

		/**
		 * Details of each option for the button.
		 * Optional
		 */
		private List<string> TextBoxField = new List<string>();
		public List<string> TextBox {
			get {
				return this.TextBoxField;
			}
			set {
				this.TextBoxField = value;
			}
		}

		/**
		 * Button image to use.
		 * Optional
		 * Must be one of: REG, SML, or CC
		 */
		private ButtonImageType? ButtonImageField;
		public ButtonImageType? ButtonImage {
			get {
				return this.ButtonImageField;
			}
			set {
				this.ButtonImageField = value;
			}
		}

		/**
		 * Button URL for custom button image.
		 * Optional
		 * Character length and limitations: 127 single-byte alphanumeric characters
		 */
		private string ButtonImageURLField;
		public string ButtonImageURL {
			get {
				return this.ButtonImageURLField;
			}
			set {
				this.ButtonImageURLField = value;
			}
		}

		/**
		 * Text to use on Buy Now Button.
		 * Optional
		 * Must be either BUYNOW or PAYNOW
		 */
		private BuyNowTextType? BuyNowTextField;
		public BuyNowTextType? BuyNowText {
			get {
				return this.BuyNowTextField;
			}
			set {
				this.BuyNowTextField = value;
			}
		}

		/**
		 * Text to use on Subscribe button.
		 * Optional
		 * Must be either BUYNOW or SUBSCRIBE
		 */
		private SubscribeTextType? SubscribeTextField;
		public SubscribeTextType? SubscribeText {
			get {
				return this.SubscribeTextField;
			}
			set {
				this.SubscribeTextField = value;
			}
		}

		/**
		 * Button Country.
		 * Optional
		 * Must be valid ISO country code
		 */
		private CountryCodeType? ButtonCountryField;
		public CountryCodeType? ButtonCountry {
			get {
				return this.ButtonCountryField;
			}
			set {
				this.ButtonCountryField = value;
			}
		}

		/**
		 * Button language code.
		 * Optional
		 * Character length and limitations: 2 single-byte alphanumeric characters
		 */
		private string ButtonLanguageField;
		public string ButtonLanguage {
			get {
				return this.ButtonLanguageField;
			}
			set {
				this.ButtonLanguageField = value;
			}
		}

		public BMUpdateButtonRequestType(string HostedButtonID) {
			this.HostedButtonID = HostedButtonID;
		}
		public BMUpdateButtonRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( HostedButtonID != null ) {
			sb.Append("<urn:HostedButtonID>").Append(HostedButtonID);
			sb.Append("</urn:HostedButtonID>");
		}
		if( ButtonType != null ) {
			sb.Append("<urn:ButtonType>").Append(EnumUtils.getDescription(ButtonType));
			sb.Append("</urn:ButtonType>");
		}
		if( ButtonCode != null ) {
			sb.Append("<urn:ButtonCode>").Append(EnumUtils.getDescription(ButtonCode));
			sb.Append("</urn:ButtonCode>");
		}
		if( ButtonSubType != null ) {
			sb.Append("<urn:ButtonSubType>").Append(EnumUtils.getDescription(ButtonSubType));
			sb.Append("</urn:ButtonSubType>");
		}
		if( ButtonVar != null ) {
			for(int i=0; i<ButtonVar.Count; i++) {
				sb.Append("<urn:ButtonVar>").Append(ButtonVar[i]);
				sb.Append("</urn:ButtonVar>");
			}
		}
		if( OptionDetails != null ) {
			for(int i=0; i<OptionDetails.Count; i++) {
				sb.Append("<urn:OptionDetails>");
				sb.Append(OptionDetails[i].toXMLString());
				sb.Append("</urn:OptionDetails>");
			}
		}
		if( TextBox != null ) {
			for(int i=0; i<TextBox.Count; i++) {
				sb.Append("<urn:TextBox>").Append(TextBox[i]);
				sb.Append("</urn:TextBox>");
			}
		}
		if( ButtonImage != null ) {
			sb.Append("<urn:ButtonImage>").Append(EnumUtils.getDescription(ButtonImage));
			sb.Append("</urn:ButtonImage>");
		}
		if( ButtonImageURL != null ) {
			sb.Append("<urn:ButtonImageURL>").Append(ButtonImageURL);
			sb.Append("</urn:ButtonImageURL>");
		}
		if( BuyNowText != null ) {
			sb.Append("<urn:BuyNowText>").Append(EnumUtils.getDescription(BuyNowText));
			sb.Append("</urn:BuyNowText>");
		}
		if( SubscribeText != null ) {
			sb.Append("<urn:SubscribeText>").Append(EnumUtils.getDescription(SubscribeText));
			sb.Append("</urn:SubscribeText>");
		}
		if( ButtonCountry != null ) {
			sb.Append("<urn:ButtonCountry>").Append(EnumUtils.getDescription(ButtonCountry));
			sb.Append("</urn:ButtonCountry>");
		}
		if( ButtonLanguage != null ) {
			sb.Append("<urn:ButtonLanguage>").Append(ButtonLanguage);
			sb.Append("</urn:ButtonLanguage>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class BMUpdateButtonResponseType :AbstractResponseType{

		private string WebsiteField;
		public string Website {
			get {
				return this.WebsiteField;
			}
			set {
				this.WebsiteField = value;
			}
		}

		private string EmailField;
		public string Email {
			get {
				return this.EmailField;
			}
			set {
				this.EmailField = value;
			}
		}

		private string MobileField;
		public string Mobile {
			get {
				return this.MobileField;
			}
			set {
				this.MobileField = value;
			}
		}

		private string HostedButtonIDField;
		public string HostedButtonID {
			get {
				return this.HostedButtonIDField;
			}
			set {
				this.HostedButtonIDField = value;
			}
		}

	 public BMUpdateButtonResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Website").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Website")[0])){ 
		 this.Website =(string)document.GetElementsByTagName("Website")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Email").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Email")[0])){ 
		 this.Email =(string)document.GetElementsByTagName("Email")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Mobile").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Mobile")[0])){ 
		 this.Mobile =(string)document.GetElementsByTagName("Mobile")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("HostedButtonID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("HostedButtonID")[0])){ 
		 this.HostedButtonID =(string)document.GetElementsByTagName("HostedButtonID")[0].InnerText;

}
	}
	}
	}


	/**
	 * BankAccountDetailsType 
	 */
	public partial class BankAccountDetailsType {

		/**
		 * Name of bank
		 * Character length and limitations: 192 alphanumeric characters		 */
		private string NameField;
		public string Name {
			get {
				return this.NameField;
			}
			set {
				this.NameField = value;
			}
		}

		/**
		 * Type of bank account: Checking or Savings		 */
		private BankAccountTypeType? TypeField;
		public BankAccountTypeType? Type {
			get {
				return this.TypeField;
			}
			set {
				this.TypeField = value;
			}
		}

		/**
		 * Merchant’s bank routing number
		 * Character length and limitations: 23 alphanumeric characters		 */
		private string RoutingNumberField;
		public string RoutingNumber {
			get {
				return this.RoutingNumberField;
			}
			set {
				this.RoutingNumberField = value;
			}
		}

		/**
		 * Merchant’s bank account number
		 * Character length and limitations: 256 alphanumeric characters		 */
		private string AccountNumberField;
		public string AccountNumber {
			get {
				return this.AccountNumberField;
			}
			set {
				this.AccountNumberField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( Name != null ) {
			sb.Append("<ebl:Name>").Append(Name);
			sb.Append("</ebl:Name>");
		}
		if( Type != null ) {
			sb.Append("<ebl:Type>").Append(EnumUtils.getDescription(Type));
			sb.Append("</ebl:Type>");
		}
		if( RoutingNumber != null ) {
			sb.Append("<ebl:RoutingNumber>").Append(RoutingNumber);
			sb.Append("</ebl:RoutingNumber>");
		}
		if( AccountNumber != null ) {
			sb.Append("<ebl:AccountNumber>").Append(AccountNumber);
			sb.Append("</ebl:AccountNumber>");
		}
		return sb.ToString();
	}

	}


	public enum BankAccountTypeType {
[Description("Checking")]CHECKING,
[Description("Savings")]SAVINGS,
	}
	/**
On requests, you must set the currencyID attribute to one of the three-character currency codes for any of the supported PayPal currencies. 
	 * Limitations: Must not exceed $10,000 USD in any currency. No currency symbol. Decimal separator must be a period (.), and the thousands separator must be a comma (,).
	 */
	public partial class BasicAmountType {

		private CurrencyCodeType? currencyIDField;
		public CurrencyCodeType? currencyID {
			get {
				return this.currencyIDField;
			}
			set {
				this.currencyIDField = value;
			}
		}

		private string valueField;
		public string value {
			get {
				return this.valueField;
			}
			set {
				this.valueField = value;
			}
		}

		public BasicAmountType(CurrencyCodeType? currencyID, string value) {
			this.currencyID = currencyID;
			this.value = value;
		}
		public BasicAmountType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( currencyID != null ) {
			sb.Append("currencyID=\"").Append(EnumUtils.getDescription(currencyID)).Append("\">");
		}
		if( value != null ) {
sb.Append(value);		}
		return sb.ToString();
	}

	 public BasicAmountType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 this.currencyID = (CurrencyCodeType)EnumUtils.getValue(document.ChildNodes[0].Attributes.GetNamedItem("currencyID").Value,typeof(CurrencyCodeType));
		 this.value =(string)document.ChildNodes[0].InnerText;
	}
	}


	/**
	 */
	public partial class BillAgreementUpdateReq {

		private BAUpdateRequestType BAUpdateRequestField;
		public BAUpdateRequestType BAUpdateRequest {
			get {
				return this.BAUpdateRequestField;
			}
			set {
				this.BAUpdateRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:BillAgreementUpdateReq>");
		if( BAUpdateRequest != null ) {
			sb.Append("<urn:BAUpdateRequest>");
			sb.Append(BAUpdateRequest.toXMLString());
			sb.Append("</urn:BAUpdateRequest>");
		}
sb.Append("</urn:BillAgreementUpdateReq>");
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class BillOutstandingAmountReq {

		private BillOutstandingAmountRequestType BillOutstandingAmountRequestField;
		public BillOutstandingAmountRequestType BillOutstandingAmountRequest {
			get {
				return this.BillOutstandingAmountRequestField;
			}
			set {
				this.BillOutstandingAmountRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:BillOutstandingAmountReq>");
		if( BillOutstandingAmountRequest != null ) {
			sb.Append("<urn:BillOutstandingAmountRequest>");
			sb.Append(BillOutstandingAmountRequest.toXMLString());
			sb.Append("</urn:BillOutstandingAmountRequest>");
		}
sb.Append("</urn:BillOutstandingAmountReq>");
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class BillOutstandingAmountRequestDetailsType {

		/**
		 */
		private string ProfileIDField;
		public string ProfileID {
			get {
				return this.ProfileIDField;
			}
			set {
				this.ProfileIDField = value;
			}
		}

		/**
		 */
		private BasicAmountType AmountField;
		public BasicAmountType Amount {
			get {
				return this.AmountField;
			}
			set {
				this.AmountField = value;
			}
		}

		/**
		 */
		private string NoteField;
		public string Note {
			get {
				return this.NoteField;
			}
			set {
				this.NoteField = value;
			}
		}

		public BillOutstandingAmountRequestDetailsType(string ProfileID) {
			this.ProfileID = ProfileID;
		}
		public BillOutstandingAmountRequestDetailsType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( ProfileID != null ) {
			sb.Append("<ebl:ProfileID>").Append(ProfileID);
			sb.Append("</ebl:ProfileID>");
		}
		if( Amount != null ) {
			sb.Append("<ebl:Amount ");
			sb.Append(Amount.toXMLString());
			sb.Append("</ebl:Amount>");
		}
		if( Note != null ) {
			sb.Append("<ebl:Note>").Append(Note);
			sb.Append("</ebl:Note>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class BillOutstandingAmountRequestType :AbstractRequestType{

		private BillOutstandingAmountRequestDetailsType BillOutstandingAmountRequestDetailsField;
		public BillOutstandingAmountRequestDetailsType BillOutstandingAmountRequestDetails {
			get {
				return this.BillOutstandingAmountRequestDetailsField;
			}
			set {
				this.BillOutstandingAmountRequestDetailsField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( BillOutstandingAmountRequestDetails != null ) {
			sb.Append("<ebl:BillOutstandingAmountRequestDetails>");
			sb.Append(BillOutstandingAmountRequestDetails.toXMLString());
			sb.Append("</ebl:BillOutstandingAmountRequestDetails>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class BillOutstandingAmountResponseDetailsType {

		/**
		 */
		private string ProfileIDField;
		public string ProfileID {
			get {
				return this.ProfileIDField;
			}
			set {
				this.ProfileIDField = value;
			}
		}

	 public BillOutstandingAmountResponseDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("ProfileID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ProfileID")[0])){ 
		 nodeList = document.GetElementsByTagName("ProfileID");
			 string value = nodeList[0].InnerText; 
		 this.ProfileID =value;

}
	}
	}
	}


	/**
	 */
	public partial class BillOutstandingAmountResponseType :AbstractResponseType{

		private BillOutstandingAmountResponseDetailsType BillOutstandingAmountResponseDetailsField;
		public BillOutstandingAmountResponseDetailsType BillOutstandingAmountResponseDetails {
			get {
				return this.BillOutstandingAmountResponseDetailsField;
			}
			set {
				this.BillOutstandingAmountResponseDetailsField = value;
			}
		}

	 public BillOutstandingAmountResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("BillOutstandingAmountResponseDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillOutstandingAmountResponseDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("BillOutstandingAmountResponseDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.BillOutstandingAmountResponseDetails =  new BillOutstandingAmountResponseDetailsType(xmlString);

}
	}
	}
	}


	/**
	 */
	public partial class BillUserReq {

		private BillUserRequestType BillUserRequestField;
		public BillUserRequestType BillUserRequest {
			get {
				return this.BillUserRequestField;
			}
			set {
				this.BillUserRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:BillUserReq>");
		if( BillUserRequest != null ) {
			sb.Append("<urn:BillUserRequest>");
			sb.Append(BillUserRequest.toXMLString());
			sb.Append("</urn:BillUserRequest>");
		}
sb.Append("</urn:BillUserReq>");
		return sb.ToString();
	}

	}


	/**
	 * This flag indicates that the response should include FMFDetails
	 */
	public partial class BillUserRequestType :AbstractRequestType{

		private MerchantPullPaymentType MerchantPullPaymentDetailsField;
		public MerchantPullPaymentType MerchantPullPaymentDetails {
			get {
				return this.MerchantPullPaymentDetailsField;
			}
			set {
				this.MerchantPullPaymentDetailsField = value;
			}
		}

		/**
This flag indicates that the response should include FMFDetails		 */
		private int? ReturnFMFDetailsField;
		public int? ReturnFMFDetails {
			get {
				return this.ReturnFMFDetailsField;
			}
			set {
				this.ReturnFMFDetailsField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( MerchantPullPaymentDetails != null ) {
			sb.Append("<ebl:MerchantPullPaymentDetails>");
			sb.Append(MerchantPullPaymentDetails.toXMLString());
			sb.Append("</ebl:MerchantPullPaymentDetails>");
		}
		if( ReturnFMFDetails != null ) {
			sb.Append("<urn:ReturnFMFDetails>").Append(ReturnFMFDetails);
			sb.Append("</urn:ReturnFMFDetails>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class BillUserResponseType :AbstractResponseType{

		private MerchantPullPaymentResponseType BillUserResponseDetailsField;
		public MerchantPullPaymentResponseType BillUserResponseDetails {
			get {
				return this.BillUserResponseDetailsField;
			}
			set {
				this.BillUserResponseDetailsField = value;
			}
		}

		private FMFDetailsType FMFDetailsField;
		public FMFDetailsType FMFDetails {
			get {
				return this.FMFDetailsField;
			}
			set {
				this.FMFDetailsField = value;
			}
		}

	 public BillUserResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("BillUserResponseDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillUserResponseDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("BillUserResponseDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.BillUserResponseDetails =  new MerchantPullPaymentResponseType(xmlString);

}
	}
		 if(document.GetElementsByTagName("FMFDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("FMFDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("FMFDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.FMFDetails =  new FMFDetailsType(xmlString);

}
	}
	}
	}


	/**
	 */
	public partial class BillingAgreementDetailsType {

		/**
		 */
		private BillingCodeType? BillingTypeField;
		public BillingCodeType? BillingType {
			get {
				return this.BillingTypeField;
			}
			set {
				this.BillingTypeField = value;
			}
		}

		/**
		 * Only needed for AutoBill billinng type.
		 */
		private string BillingAgreementDescriptionField;
		public string BillingAgreementDescription {
			get {
				return this.BillingAgreementDescriptionField;
			}
			set {
				this.BillingAgreementDescriptionField = value;
			}
		}

		/**
		 */
		private MerchantPullPaymentCodeType? PaymentTypeField;
		public MerchantPullPaymentCodeType? PaymentType {
			get {
				return this.PaymentTypeField;
			}
			set {
				this.PaymentTypeField = value;
			}
		}

		/**
		 * Custom annotation field for your exclusive use.
		 */
		private string BillingAgreementCustomField;
		public string BillingAgreementCustom {
			get {
				return this.BillingAgreementCustomField;
			}
			set {
				this.BillingAgreementCustomField = value;
			}
		}

		public BillingAgreementDetailsType(BillingCodeType? BillingType) {
			this.BillingType = BillingType;
		}
		public BillingAgreementDetailsType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( BillingType != null ) {
			sb.Append("<ebl:BillingType>").Append(EnumUtils.getDescription(BillingType));
			sb.Append("</ebl:BillingType>");
		}
		if( BillingAgreementDescription != null ) {
			sb.Append("<ebl:BillingAgreementDescription>").Append(BillingAgreementDescription);
			sb.Append("</ebl:BillingAgreementDescription>");
		}
		if( PaymentType != null ) {
			sb.Append("<ebl:PaymentType>").Append(EnumUtils.getDescription(PaymentType));
			sb.Append("</ebl:PaymentType>");
		}
		if( BillingAgreementCustom != null ) {
			sb.Append("<ebl:BillingAgreementCustom>").Append(BillingAgreementCustom);
			sb.Append("</ebl:BillingAgreementCustom>");
		}
		return sb.ToString();
	}

	}


	/**
	 * The Type of Approval requested - Billing Agreement or Profile
	 */
	public partial class BillingApprovalDetailsType {

		/**
The Type of Approval requested - Billing Agreement or Profile		 */
		private ApprovalTypeType? ApprovalTypeField;
		public ApprovalTypeType? ApprovalType {
			get {
				return this.ApprovalTypeField;
			}
			set {
				this.ApprovalTypeField = value;
			}
		}

		/**
The Approval subtype - Must be MerchantInitiatedBilling for BillingAgreement ApprovalType		 */
		private ApprovalSubTypeType? ApprovalSubTypeField;
		public ApprovalSubTypeType? ApprovalSubType {
			get {
				return this.ApprovalSubTypeField;
			}
			set {
				this.ApprovalSubTypeField = value;
			}
		}

		/**
Description about the Order		 */
		private OrderDetailsType OrderDetailsField;
		public OrderDetailsType OrderDetails {
			get {
				return this.OrderDetailsField;
			}
			set {
				this.OrderDetailsField = value;
			}
		}

		/**
Directives about the type of payment		 */
		private PaymentDirectivesType PaymentDirectivesField;
		public PaymentDirectivesType PaymentDirectives {
			get {
				return this.PaymentDirectivesField;
			}
			set {
				this.PaymentDirectivesField = value;
			}
		}

		/**
Client may pass in its identification of this Billing Agreement. It used for the client's tracking purposes.		 */
		private string CustomField;
		public string Custom {
			get {
				return this.CustomField;
			}
			set {
				this.CustomField = value;
			}
		}

		public BillingApprovalDetailsType(ApprovalTypeType? ApprovalType) {
			this.ApprovalType = ApprovalType;
		}
		public BillingApprovalDetailsType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( ApprovalType != null ) {
			sb.Append("<ebl:ApprovalType>").Append(EnumUtils.getDescription(ApprovalType));
			sb.Append("</ebl:ApprovalType>");
		}
		if( ApprovalSubType != null ) {
			sb.Append("<ebl:ApprovalSubType>").Append(EnumUtils.getDescription(ApprovalSubType));
			sb.Append("</ebl:ApprovalSubType>");
		}
		if( OrderDetails != null ) {
			sb.Append("<ebl:OrderDetails>");
			sb.Append(OrderDetails.toXMLString());
			sb.Append("</ebl:OrderDetails>");
		}
		if( PaymentDirectives != null ) {
			sb.Append("<ebl:PaymentDirectives>");
			sb.Append(PaymentDirectives.toXMLString());
			sb.Append("</ebl:PaymentDirectives>");
		}
		if( Custom != null ) {
			sb.Append("<ebl:Custom>").Append(Custom);
			sb.Append("</ebl:Custom>");
		}
		return sb.ToString();
	}

	}


	public enum BillingCodeType {
[Description("None")]NONE,
[Description("MerchantInitiatedBilling")]MERCHANTINITIATEDBILLING,
[Description("RecurringPayments")]RECURRINGPAYMENTS,
[Description("MerchantInitiatedBillingSingleAgreement")]MERCHANTINITIATEDBILLINGSINGLEAGREEMENT,
[Description("ChannelInitiatedBilling")]CHANNELINITIATEDBILLING,
	}
	/**
	 * Unit of meausre for billing cycle
	 */
	public partial class BillingPeriodDetailsType {

		/**
		 * Unit of meausre for billing cycle
		 */
		private BillingPeriodType? BillingPeriodField;
		public BillingPeriodType? BillingPeriod {
			get {
				return this.BillingPeriodField;
			}
			set {
				this.BillingPeriodField = value;
			}
		}

		/**
		 * Number of BillingPeriod that make up one billing cycle
		 */
		private int? BillingFrequencyField;
		public int? BillingFrequency {
			get {
				return this.BillingFrequencyField;
			}
			set {
				this.BillingFrequencyField = value;
			}
		}

		/**
		 * Total billing cycles in this portion of the schedule
		 */
		private int? TotalBillingCyclesField;
		public int? TotalBillingCycles {
			get {
				return this.TotalBillingCyclesField;
			}
			set {
				this.TotalBillingCyclesField = value;
			}
		}

		/**
		 * Amount to charge
		 */
		private BasicAmountType AmountField;
		public BasicAmountType Amount {
			get {
				return this.AmountField;
			}
			set {
				this.AmountField = value;
			}
		}

		/**
		 * Additional shipping amount to charge
		 */
		private BasicAmountType ShippingAmountField;
		public BasicAmountType ShippingAmount {
			get {
				return this.ShippingAmountField;
			}
			set {
				this.ShippingAmountField = value;
			}
		}

		/**
		 * Additional tax amount to charge
		 */
		private BasicAmountType TaxAmountField;
		public BasicAmountType TaxAmount {
			get {
				return this.TaxAmountField;
			}
			set {
				this.TaxAmountField = value;
			}
		}

		public BillingPeriodDetailsType(BillingPeriodType? BillingPeriod, int? BillingFrequency, BasicAmountType Amount) {
			this.BillingPeriod = BillingPeriod;
			this.BillingFrequency = BillingFrequency;
			this.Amount = Amount;
		}
		public BillingPeriodDetailsType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( BillingPeriod != null ) {
			sb.Append("<ebl:BillingPeriod>").Append(EnumUtils.getDescription(BillingPeriod));
			sb.Append("</ebl:BillingPeriod>");
		}
		if( BillingFrequency != null ) {
			sb.Append("<ebl:BillingFrequency>").Append(BillingFrequency);
			sb.Append("</ebl:BillingFrequency>");
		}
		if( TotalBillingCycles != null ) {
			sb.Append("<ebl:TotalBillingCycles>").Append(TotalBillingCycles);
			sb.Append("</ebl:TotalBillingCycles>");
		}
		if( Amount != null ) {
			sb.Append("<ebl:Amount ");
			sb.Append(Amount.toXMLString());
			sb.Append("</ebl:Amount>");
		}
		if( ShippingAmount != null ) {
			sb.Append("<ebl:ShippingAmount ");
			sb.Append(ShippingAmount.toXMLString());
			sb.Append("</ebl:ShippingAmount>");
		}
		if( TaxAmount != null ) {
			sb.Append("<ebl:TaxAmount ");
			sb.Append(TaxAmount.toXMLString());
			sb.Append("</ebl:TaxAmount>");
		}
		return sb.ToString();
	}

	 public BillingPeriodDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("BillingPeriod").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillingPeriod")[0])){ 
		 this.BillingPeriod = (BillingPeriodType)EnumUtils.getValue(document.GetElementsByTagName("BillingPeriod")[0].InnerText,typeof(BillingPeriodType));

}
	}
		 if(document.GetElementsByTagName("BillingFrequency").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillingFrequency")[0])){ 
		 this.BillingFrequency =System.Convert.ToInt32(document.GetElementsByTagName("BillingFrequency")[0].InnerText);

}
	}
		 if(document.GetElementsByTagName("TotalBillingCycles").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TotalBillingCycles")[0])){ 
		 this.TotalBillingCycles =System.Convert.ToInt32(document.GetElementsByTagName("TotalBillingCycles")[0].InnerText);

}
	}
		 if(document.GetElementsByTagName("Amount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Amount")[0])){ 
		 nodeList = document.GetElementsByTagName("Amount");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.Amount =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("ShippingAmount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ShippingAmount")[0])){ 
		 nodeList = document.GetElementsByTagName("ShippingAmount");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.ShippingAmount =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("TaxAmount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TaxAmount")[0])){ 
		 nodeList = document.GetElementsByTagName("TaxAmount");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.TaxAmount =  new BasicAmountType(xmlString);

}
	}
	}
	}


	/**
	 * Unit of meausre for billing cycle
	 */
	public partial class BillingPeriodDetailsType_Update {

		/**
		 * Unit of meausre for billing cycle
		 */
		private BillingPeriodType? BillingPeriodField;
		public BillingPeriodType? BillingPeriod {
			get {
				return this.BillingPeriodField;
			}
			set {
				this.BillingPeriodField = value;
			}
		}

		/**
		 * Number of BillingPeriod that make up one billing cycle
		 */
		private int? BillingFrequencyField;
		public int? BillingFrequency {
			get {
				return this.BillingFrequencyField;
			}
			set {
				this.BillingFrequencyField = value;
			}
		}

		/**
		 * Total billing cycles in this portion of the schedule
		 */
		private int? TotalBillingCyclesField;
		public int? TotalBillingCycles {
			get {
				return this.TotalBillingCyclesField;
			}
			set {
				this.TotalBillingCyclesField = value;
			}
		}

		/**
		 * Amount to charge
		 */
		private BasicAmountType AmountField;
		public BasicAmountType Amount {
			get {
				return this.AmountField;
			}
			set {
				this.AmountField = value;
			}
		}

		/**
		 * Additional shipping amount to charge
		 */
		private BasicAmountType ShippingAmountField;
		public BasicAmountType ShippingAmount {
			get {
				return this.ShippingAmountField;
			}
			set {
				this.ShippingAmountField = value;
			}
		}

		/**
		 * Additional tax amount to charge
		 */
		private BasicAmountType TaxAmountField;
		public BasicAmountType TaxAmount {
			get {
				return this.TaxAmountField;
			}
			set {
				this.TaxAmountField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( BillingPeriod != null ) {
			sb.Append("<ebl:BillingPeriod>").Append(EnumUtils.getDescription(BillingPeriod));
			sb.Append("</ebl:BillingPeriod>");
		}
		if( BillingFrequency != null ) {
			sb.Append("<ebl:BillingFrequency>").Append(BillingFrequency);
			sb.Append("</ebl:BillingFrequency>");
		}
		if( TotalBillingCycles != null ) {
			sb.Append("<ebl:TotalBillingCycles>").Append(TotalBillingCycles);
			sb.Append("</ebl:TotalBillingCycles>");
		}
		if( Amount != null ) {
			sb.Append("<ebl:Amount ");
			sb.Append(Amount.toXMLString());
			sb.Append("</ebl:Amount>");
		}
		if( ShippingAmount != null ) {
			sb.Append("<ebl:ShippingAmount ");
			sb.Append(ShippingAmount.toXMLString());
			sb.Append("</ebl:ShippingAmount>");
		}
		if( TaxAmount != null ) {
			sb.Append("<ebl:TaxAmount ");
			sb.Append(TaxAmount.toXMLString());
			sb.Append("</ebl:TaxAmount>");
		}
		return sb.ToString();
	}

	}


	public enum BillingPeriodType {
[Description("NoBillingPeriodType")]NOBILLINGPERIODTYPE,
[Description("Day")]DAY,
[Description("Week")]WEEK,
[Description("SemiMonth")]SEMIMONTH,
[Description("Month")]MONTH,
[Description("Year")]YEAR,
	}
	public enum BoardingStatusType {
[Description("Unknown")]UNKNOWN,
[Description("Completed")]COMPLETED,
[Description("Cancelled")]CANCELLED,
[Description("Pending")]PENDING,
	}
	public enum BusinessCategoryType {
[Description("Category-Unspecified")]CATEGORYUNSPECIFIED,
[Description("Antiques")]ANTIQUES,
[Description("Arts")]ARTS,
[Description("Automotive")]AUTOMOTIVE,
[Description("Beauty")]BEAUTY,
[Description("Books")]BOOKS,
[Description("Business")]BUSINESS,
[Description("Cameras-and-Photography")]CAMERASANDPHOTOGRAPHY,
[Description("Clothing")]CLOTHING,
[Description("Collectibles")]COLLECTIBLES,
[Description("Computer-Hardware-and-Software")]COMPUTERHARDWAREANDSOFTWARE,
[Description("Culture-and-Religion")]CULTUREANDRELIGION,
[Description("Electronics-and-Telecom")]ELECTRONICSANDTELECOM,
[Description("Entertainment")]ENTERTAINMENT,
[Description("Entertainment-Memorabilia")]ENTERTAINMENTMEMORABILIA,
[Description("Food-Drink-and-Nutrition")]FOODDRINKANDNUTRITION,
[Description("Gifts-and-Flowers")]GIFTSANDFLOWERS,
[Description("Hobbies-Toys-and-Games")]HOBBIESTOYSANDGAMES,
[Description("Home-and-Garden")]HOMEANDGARDEN,
[Description("Internet-and-Network-Services")]INTERNETANDNETWORKSERVICES,
[Description("Media-and-Entertainment")]MEDIAANDENTERTAINMENT,
[Description("Medical-and-Pharmaceutical")]MEDICALANDPHARMACEUTICAL,
[Description("Money-Service-Businesses")]MONEYSERVICEBUSINESSES,
[Description("Non-Profit-Political-and-Religion")]NONPROFITPOLITICALANDRELIGION,
[Description("Not-Elsewhere-Classified")]NOTELSEWHERECLASSIFIED,
[Description("Pets-and-Animals")]PETSANDANIMALS,
[Description("Real-Estate")]REALESTATE,
[Description("Services")]SERVICES,
[Description("Sports-and-Recreation")]SPORTSANDRECREATION,
[Description("Travel")]TRAVEL,
[Description("Other-Categories")]OTHERCATEGORIES,
	}
	/**
	 * BusinessInfoType 
	 */
	public partial class BusinessInfoType {

		/**
		 * Type of business, such as corporation or sole proprietorship		 */
		private BusinessTypeType? TypeField;
		public BusinessTypeType? Type {
			get {
				return this.TypeField;
			}
			set {
				this.TypeField = value;
			}
		}

		/**
		 * Official name of business
		 * Character length and limitations: 75 alphanumeric characters		 */
		private string NameField;
		public string Name {
			get {
				return this.NameField;
			}
			set {
				this.NameField = value;
			}
		}

		/**
		 * Merchant’s business postal address		 */
		private AddressType AddressField;
		public AddressType Address {
			get {
				return this.AddressField;
			}
			set {
				this.AddressField = value;
			}
		}

		/**
		 * Business’s primary telephone number
		 * Character length and limitations: 20 alphanumeric characters		 */
		private string WorkPhoneField;
		public string WorkPhone {
			get {
				return this.WorkPhoneField;
			}
			set {
				this.WorkPhoneField = value;
			}
		}

		/**
		 * Line of business, as defined in the enumerations		 */
		private BusinessCategoryType? CategoryField;
		public BusinessCategoryType? Category {
			get {
				return this.CategoryField;
			}
			set {
				this.CategoryField = value;
			}
		}

		/**
		 * Business sub-category, as defined in the enumerations		 */
		private BusinessSubCategoryType? SubCategoryField;
		public BusinessSubCategoryType? SubCategory {
			get {
				return this.SubCategoryField;
			}
			set {
				this.SubCategoryField = value;
			}
		}

		/**
		 * Average transaction price, as defined by the enumerations.
		 * Enumeration
		 * Meaning
		 * AverageTransactionPrice-Not-Applicable	
		 * AverageTransactionPrice-Range1
		 * Less than $25 USD
		 * AverageTransactionPrice-Range2
		 * $25 USD to $50 USD
		 * AverageTransactionPrice-Range3
		 * $50 USD to $100 USD
		 * AverageTransactionPrice-Range4
		 * $100 USD to $250 USD
		 * AverageTransactionPrice-Range5
		 * $250 USD to $500 USD
		 * AverageTransactionPrice-Range6
		 * $500 USD to $1,000 USD
		 * AverageTransactionPrice-Range7
		 * $1,000 USD to $2,000 USD
		 * AverageTransactionPrice-Range8
		 * $2,000 USD to $5,000 USD
		 * AverageTransactionPrice-Range9
		 * $5,000 USD to $10,000 USD
		 * AverageTransactionPrice-Range10
		 * More than $10,000 USD
		 */
		private AverageTransactionPriceType? AveragePriceField;
		public AverageTransactionPriceType? AveragePrice {
			get {
				return this.AveragePriceField;
			}
			set {
				this.AveragePriceField = value;
			}
		}

		/**
		 * Average monthly sales volume, as defined by the enumerations.
		 * Enumeration
		 * Meaning
		 * AverageMonthlyVolume-Not-Applicable
		 * AverageMonthlyVolume-Range1
		 * Less than $1,000 USD
		 * AverageMonthlyVolume-Range2
		 * $1,000 USD to $5,000 USD
		 * AverageMonthlyVolume-Range3
		 * $5,000 USD to $25,000 USD
		 * AverageMonthlyVolume-Range4
		 * $25,000 USD to $100,000 USD
		 * AverageMonthlyVolume-Range5
		 * $100,000 USD to $1,000,000 USD
		 * AverageMonthlyVolume-Range6
		 * More than $1,000,000 USD
		 */
		private AverageMonthlyVolumeType? AverageMonthlyVolumeField;
		public AverageMonthlyVolumeType? AverageMonthlyVolume {
			get {
				return this.AverageMonthlyVolumeField;
			}
			set {
				this.AverageMonthlyVolumeField = value;
			}
		}

		/**
		 * Main sales venue, such as eBay		 */
		private SalesVenueType? SalesVenueField;
		public SalesVenueType? SalesVenue {
			get {
				return this.SalesVenueField;
			}
			set {
				this.SalesVenueField = value;
			}
		}

		/**
		 * Primary URL of business
		 * Character length and limitations: 2,048 alphanumeric characters		 */
		private string WebsiteField;
		public string Website {
			get {
				return this.WebsiteField;
			}
			set {
				this.WebsiteField = value;
			}
		}

		/**
		 * Percentage of revenue attributable to online sales, as defined by the enumerations
		 * Enumeration
		 * Meaning
		 * PercentageRevenueFromOnlineSales-Not-Applicable	
		 * PercentageRevenueFromOnlineSales-Range1
		 * Less than 25%
		 * PercentageRevenueFromOnlineSales-Range2
		 * 25% to 50%
		 * PercentageRevenueFromOnlineSales-Range3
		 * 50% to 75%
		 * PercentageRevenueFromOnlineSales-Range4
		 * 75% to 100%
		 */
		private PercentageRevenueFromOnlineSalesType? RevenueFromOnlineSalesField;
		public PercentageRevenueFromOnlineSalesType? RevenueFromOnlineSales {
			get {
				return this.RevenueFromOnlineSalesField;
			}
			set {
				this.RevenueFromOnlineSalesField = value;
			}
		}

		/**
		 * Date the merchant’s business was established		 */
		private string BusinessEstablishedField;
		public string BusinessEstablished {
			get {
				return this.BusinessEstablishedField;
			}
			set {
				this.BusinessEstablishedField = value;
			}
		}

		/**
		 * Email address to contact business’s customer service
		 * Character length and limitations: 127 alphanumeric characters		 */
		private string CustomerServiceEmailField;
		public string CustomerServiceEmail {
			get {
				return this.CustomerServiceEmailField;
			}
			set {
				this.CustomerServiceEmailField = value;
			}
		}

		/**
		 * Telephone number to contact business’s customer service
		 * Character length and limitations: 32 alphanumeric characters		 */
		private string CustomerServicePhoneField;
		public string CustomerServicePhone {
			get {
				return this.CustomerServicePhoneField;
			}
			set {
				this.CustomerServicePhoneField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( Type != null ) {
			sb.Append("<ebl:Type>").Append(EnumUtils.getDescription(Type));
			sb.Append("</ebl:Type>");
		}
		if( Name != null ) {
			sb.Append("<ebl:Name>").Append(Name);
			sb.Append("</ebl:Name>");
		}
		if( Address != null ) {
			sb.Append("<ebl:Address>");
			sb.Append(Address.toXMLString());
			sb.Append("</ebl:Address>");
		}
		if( WorkPhone != null ) {
			sb.Append("<ebl:WorkPhone>").Append(WorkPhone);
			sb.Append("</ebl:WorkPhone>");
		}
		if( Category != null ) {
			sb.Append("<ebl:Category>").Append(EnumUtils.getDescription(Category));
			sb.Append("</ebl:Category>");
		}
		if( SubCategory != null ) {
			sb.Append("<ebl:SubCategory>").Append(EnumUtils.getDescription(SubCategory));
			sb.Append("</ebl:SubCategory>");
		}
		if( AveragePrice != null ) {
			sb.Append("<ebl:AveragePrice>").Append(EnumUtils.getDescription(AveragePrice));
			sb.Append("</ebl:AveragePrice>");
		}
		if( AverageMonthlyVolume != null ) {
			sb.Append("<ebl:AverageMonthlyVolume>").Append(EnumUtils.getDescription(AverageMonthlyVolume));
			sb.Append("</ebl:AverageMonthlyVolume>");
		}
		if( SalesVenue != null ) {
			sb.Append("<ebl:SalesVenue>").Append(EnumUtils.getDescription(SalesVenue));
			sb.Append("</ebl:SalesVenue>");
		}
		if( Website != null ) {
			sb.Append("<ebl:Website>").Append(Website);
			sb.Append("</ebl:Website>");
		}
		if( RevenueFromOnlineSales != null ) {
			sb.Append("<ebl:RevenueFromOnlineSales>").Append(EnumUtils.getDescription(RevenueFromOnlineSales));
			sb.Append("</ebl:RevenueFromOnlineSales>");
		}
		if( BusinessEstablished != null ) {
			sb.Append("<ebl:BusinessEstablished>").Append(BusinessEstablished);
			sb.Append("</ebl:BusinessEstablished>");
		}
		if( CustomerServiceEmail != null ) {
			sb.Append("<ebl:CustomerServiceEmail>").Append(CustomerServiceEmail);
			sb.Append("</ebl:CustomerServiceEmail>");
		}
		if( CustomerServicePhone != null ) {
			sb.Append("<ebl:CustomerServicePhone>").Append(CustomerServicePhone);
			sb.Append("</ebl:CustomerServicePhone>");
		}
		return sb.ToString();
	}

	}


	/**
	 * BusinessOwnerInfoType 
	 */
	public partial class BusinessOwnerInfoType {

		/**
		 * Details about the business owner		 */
		private PayerInfoType OwnerField;
		public PayerInfoType Owner {
			get {
				return this.OwnerField;
			}
			set {
				this.OwnerField = value;
			}
		}

		/**
		 * Business owner’s home telephone number
		 * Character length and limitations: 32 alphanumeric characters		 */
		private string HomePhoneField;
		public string HomePhone {
			get {
				return this.HomePhoneField;
			}
			set {
				this.HomePhoneField = value;
			}
		}

		/**
		 * Business owner’s mobile telephone number
		 * Character length and limitations: 32 alphanumeric characters		 */
		private string MobilePhoneField;
		public string MobilePhone {
			get {
				return this.MobilePhoneField;
			}
			set {
				this.MobilePhoneField = value;
			}
		}

		/**
		 * Business owner’s social security number
		 * Character length and limitations: 9 alphanumeric characters		 */
		private string SSNField;
		public string SSN {
			get {
				return this.SSNField;
			}
			set {
				this.SSNField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( Owner != null ) {
			sb.Append("<ebl:Owner>");
			sb.Append(Owner.toXMLString());
			sb.Append("</ebl:Owner>");
		}
		if( HomePhone != null ) {
			sb.Append("<ebl:HomePhone>").Append(HomePhone);
			sb.Append("</ebl:HomePhone>");
		}
		if( MobilePhone != null ) {
			sb.Append("<ebl:MobilePhone>").Append(MobilePhone);
			sb.Append("</ebl:MobilePhone>");
		}
		if( SSN != null ) {
			sb.Append("<ebl:SSN>").Append(SSN);
			sb.Append("</ebl:SSN>");
		}
		return sb.ToString();
	}

	}


	public enum BusinessSubCategoryType {
[Description("SubCategory-Unspecified")]SUBCATEGORYUNSPECIFIED,
[Description("ANTIQUES-General")]ANTIQUESGENERAL,
[Description("ANTIQUES-Antiquities")]ANTIQUESANTIQUITIES,
[Description("ANTIQUES-Decorative")]ANTIQUESDECORATIVE,
[Description("ANTIQUES-Books-Manuscripts")]ANTIQUESBOOKSMANUSCRIPTS,
[Description("ANTIQUES-Furniture")]ANTIQUESFURNITURE,
[Description("ANTIQUES-Glass")]ANTIQUESGLASS,
[Description("ANTIQUES-RugsCarpets")]ANTIQUESRUGSCARPETS,
[Description("ANTIQUES-Pottery")]ANTIQUESPOTTERY,
[Description("ANTIQUES-Cultural")]ANTIQUESCULTURAL,
[Description("ANTIQUES-Artifacts-Grave-related-and-Native-American-Crafts")]ANTIQUESARTIFACTSGRAVERELATEDANDNATIVEAMERICANCRAFTS,
[Description("ARTSANDCRAFTS-General")]ARTSANDCRAFTSGENERAL,
[Description("ARTSANDCRAFTS-Art-Dealer-and-Galleries")]ARTSANDCRAFTSARTDEALERANDGALLERIES,
[Description("ARTSANDCRAFTS-Prints")]ARTSANDCRAFTSPRINTS,
[Description("ARTSANDCRAFTS-Painting")]ARTSANDCRAFTSPAINTING,
[Description("ARTSANDCRAFTS-Photography")]ARTSANDCRAFTSPHOTOGRAPHY,
[Description("ARTSANDCRAFTS-Reproductions")]ARTSANDCRAFTSREPRODUCTIONS,
[Description("ARTSANDCRAFTS-Sculptures")]ARTSANDCRAFTSSCULPTURES,
[Description("ARTSANDCRAFTS-Woodworking")]ARTSANDCRAFTSWOODWORKING,
[Description("ARTSANDCRAFTS-Art-and-Craft-Supplies")]ARTSANDCRAFTSARTANDCRAFTSUPPLIES,
[Description("ARTSANDCRAFTS-Fabrics-and-Sewing")]ARTSANDCRAFTSFABRICSANDSEWING,
[Description("ARTSANDCRAFTS-Quilting")]ARTSANDCRAFTSQUILTING,
[Description("ARTSANDCRAFTS-Scrapbooking")]ARTSANDCRAFTSSCRAPBOOKING,
[Description("AUTOMOTIVE-General")]AUTOMOTIVEGENERAL,
[Description("AUTOMOTIVE-Autos")]AUTOMOTIVEAUTOS,
[Description("AUTOMOTIVE-Aviation")]AUTOMOTIVEAVIATION,
[Description("AUTOMOTIVE-Motorcycles")]AUTOMOTIVEMOTORCYCLES,
[Description("AUTOMOTIVE-Parts-and-Supplies")]AUTOMOTIVEPARTSANDSUPPLIES,
[Description("AUTOMOTIVE-Services")]AUTOMOTIVESERVICES,
[Description("AUTOMOTIVE-Vintage-and-Collectible-Vehicles")]AUTOMOTIVEVINTAGEANDCOLLECTIBLEVEHICLES,
[Description("BEAUTY-General")]BEAUTYGENERAL,
[Description("BEAUTY-Body-Care-Personal-Hygiene")]BEAUTYBODYCAREPERSONALHYGIENE,
[Description("BEAUTY-Fragrances-and-Perfumes")]BEAUTYFRAGRANCESANDPERFUMES,
[Description("BEAUTY-Makeup")]BEAUTYMAKEUP,
[Description("BOOKS-General")]BOOKSGENERAL,
[Description("BOOKS-Audio-Books")]BOOKSAUDIOBOOKS,
[Description("BOOKS-Children-Books")]BOOKSCHILDRENBOOKS,
[Description("BOOKS-Computer-Books")]BOOKSCOMPUTERBOOKS,
[Description("BOOKS-Educational-and-Textbooks")]BOOKSEDUCATIONALANDTEXTBOOKS,
[Description("BOOKS-Magazines")]BOOKSMAGAZINES,
[Description("BOOKS-Fiction-and-Literature")]BOOKSFICTIONANDLITERATURE,
[Description("BOOKS-NonFiction")]BOOKSNONFICTION,
[Description("BOOKS-Vintage-and-Collectibles")]BOOKSVINTAGEANDCOLLECTIBLES,
[Description("BUSINESS-General")]BUSINESSGENERAL,
[Description("BUSINESS-Agricultural")]BUSINESSAGRICULTURAL,
[Description("BUSINESS-Construction")]BUSINESSCONSTRUCTION,
[Description("BUSINESS-Educational")]BUSINESSEDUCATIONAL,
[Description("BUSINESS-Industrial")]BUSINESSINDUSTRIAL,
[Description("BUSINESS-Office-Supplies-and-Equipment")]BUSINESSOFFICESUPPLIESANDEQUIPMENT,
[Description("BUSINESS-GeneralServices")]BUSINESSGENERALSERVICES,
[Description("BUSINESS-Advertising")]BUSINESSADVERTISING,
[Description("BUSINESS-Employment")]BUSINESSEMPLOYMENT,
[Description("BUSINESS-Marketing")]BUSINESSMARKETING,
[Description("BUSINESS-Meeting-Planners")]BUSINESSMEETINGPLANNERS,
[Description("BUSINESS-Messaging-and-Paging-Services")]BUSINESSMESSAGINGANDPAGINGSERVICES,
[Description("BUSINESS-Seminars")]BUSINESSSEMINARS,
[Description("BUSINESS-Publishing")]BUSINESSPUBLISHING,
[Description("BUSINESS-Shipping-and-Packaging")]BUSINESSSHIPPINGANDPACKAGING,
[Description("BUSINESS-Wholesale")]BUSINESSWHOLESALE,
[Description("BUSINESS-Industrial-Solvents")]BUSINESSINDUSTRIALSOLVENTS,
[Description("CAMERASANDPHOTOGRAPHY-General")]CAMERASANDPHOTOGRAPHYGENERAL,
[Description("CAMERASANDPHOTOGRAPHY-Accessories")]CAMERASANDPHOTOGRAPHYACCESSORIES,
[Description("CAMERASANDPHOTOGRAPHY-Cameras")]CAMERASANDPHOTOGRAPHYCAMERAS,
[Description("CAMERASANDPHOTOGRAPHY-Video-Equipment")]CAMERASANDPHOTOGRAPHYVIDEOEQUIPMENT,
[Description("CAMERASANDPHOTOGRAPHY-Film")]CAMERASANDPHOTOGRAPHYFILM,
[Description("CAMERASANDPHOTOGRAPHY-Supplies")]CAMERASANDPHOTOGRAPHYSUPPLIES,
[Description("CLOTHING-Accessories")]CLOTHINGACCESSORIES,
[Description("CLOTHING-Babies-Clothing-and-Supplies")]CLOTHINGBABIESCLOTHINGANDSUPPLIES,
[Description("CLOTHING-Childrens-Clothing")]CLOTHINGCHILDRENSCLOTHING,
[Description("CLOTHING-Mens-Clothing")]CLOTHINGMENSCLOTHING,
[Description("CLOTHING-Shoes")]CLOTHINGSHOES,
[Description("CLOTHING-Wedding-Clothing")]CLOTHINGWEDDINGCLOTHING,
[Description("CLOTHING-Womens-Clothing")]CLOTHINGWOMENSCLOTHING,
[Description("CLOTHING-General")]CLOTHINGGENERAL,
[Description("CLOTHING-Jewelry")]CLOTHINGJEWELRY,
[Description("CLOTHING-Watches-and-Clocks")]CLOTHINGWATCHESANDCLOCKS,
[Description("CLOTHING-Rings")]CLOTHINGRINGS,
[Description("COLLECTIBLES-General")]COLLECTIBLESGENERAL,
[Description("COLLECTIBLES-Advertising")]COLLECTIBLESADVERTISING,
[Description("COLLECTIBLES-Animals")]COLLECTIBLESANIMALS,
[Description("COLLECTIBLES-Animation")]COLLECTIBLESANIMATION,
[Description("COLLECTIBLES-Coin-Operated-Banks-and-Casinos")]COLLECTIBLESCOINOPERATEDBANKSANDCASINOS,
[Description("COLLECTIBLES-Coins-and-Paper-Money")]COLLECTIBLESCOINSANDPAPERMONEY,
[Description("COLLECTIBLES-Comics")]COLLECTIBLESCOMICS,
[Description("COLLECTIBLES-Decorative")]COLLECTIBLESDECORATIVE,
[Description("COLLECTIBLES-Disneyana")]COLLECTIBLESDISNEYANA,
[Description("COLLECTIBLES-Holiday")]COLLECTIBLESHOLIDAY,
[Description("COLLECTIBLES-Knives-and-Swords")]COLLECTIBLESKNIVESANDSWORDS,
[Description("COLLECTIBLES-Militaria")]COLLECTIBLESMILITARIA,
[Description("COLLECTIBLES-Postcards-and-Paper")]COLLECTIBLESPOSTCARDSANDPAPER,
[Description("COLLECTIBLES-Stamps")]COLLECTIBLESSTAMPS,
[Description("COMPUTERHARDWAREANDSOFTWARE-General")]COMPUTERHARDWAREANDSOFTWAREGENERAL,
[Description("COMPUTERHARDWAREANDSOFTWARE-Desktop-PCs")]COMPUTERHARDWAREANDSOFTWAREDESKTOPPCS,
[Description("COMPUTERHARDWAREANDSOFTWARE-Monitors")]COMPUTERHARDWAREANDSOFTWAREMONITORS,
[Description("COMPUTERHARDWAREANDSOFTWARE-Hardware")]COMPUTERHARDWAREANDSOFTWAREHARDWARE,
[Description("COMPUTERHARDWAREANDSOFTWARE-Peripherals")]COMPUTERHARDWAREANDSOFTWAREPERIPHERALS,
[Description("COMPUTERHARDWAREANDSOFTWARE-Laptops-Notebooks-PDAs")]COMPUTERHARDWAREANDSOFTWARELAPTOPSNOTEBOOKSPDAS,
[Description("COMPUTERHARDWAREANDSOFTWARE-Networking-Equipment")]COMPUTERHARDWAREANDSOFTWARENETWORKINGEQUIPMENT,
[Description("COMPUTERHARDWAREANDSOFTWARE-Parts-and-Accessories")]COMPUTERHARDWAREANDSOFTWAREPARTSANDACCESSORIES,
[Description("COMPUTERHARDWAREANDSOFTWARE-GeneralSoftware")]COMPUTERHARDWAREANDSOFTWAREGENERALSOFTWARE,
[Description("COMPUTERHARDWAREANDSOFTWARE-Oem-Software")]COMPUTERHARDWAREANDSOFTWAREOEMSOFTWARE,
[Description("COMPUTERHARDWAREANDSOFTWARE-Academic-Software")]COMPUTERHARDWAREANDSOFTWAREACADEMICSOFTWARE,
[Description("COMPUTERHARDWAREANDSOFTWARE-Beta-Software")]COMPUTERHARDWAREANDSOFTWAREBETASOFTWARE,
[Description("COMPUTERHARDWAREANDSOFTWARE-Game-Software")]COMPUTERHARDWAREANDSOFTWAREGAMESOFTWARE,
[Description("COMPUTERHARDWAREANDSOFTWARE-Data-Processing-Svc")]COMPUTERHARDWAREANDSOFTWAREDATAPROCESSINGSVC,
[Description("CULTUREANDRELIGION-General")]CULTUREANDRELIGIONGENERAL,
[Description("CULTUREANDRELIGION-Christianity")]CULTUREANDRELIGIONCHRISTIANITY,
[Description("CULTUREANDRELIGION-Metaphysical")]CULTUREANDRELIGIONMETAPHYSICAL,
[Description("CULTUREANDRELIGION-New-Age")]CULTUREANDRELIGIONNEWAGE,
[Description("CULTUREANDRELIGION-Organizations")]CULTUREANDRELIGIONORGANIZATIONS,
[Description("CULTUREANDRELIGION-Other-Faiths")]CULTUREANDRELIGIONOTHERFAITHS,
[Description("CULTUREANDRELIGION-Collectibles")]CULTUREANDRELIGIONCOLLECTIBLES,
[Description("ELECTRONICSANDTELECOM-GeneralTelecom")]ELECTRONICSANDTELECOMGENERALTELECOM,
[Description("ELECTRONICSANDTELECOM-Cell-Phones-and-Pagers")]ELECTRONICSANDTELECOMCELLPHONESANDPAGERS,
[Description("ELECTRONICSANDTELECOM-Telephone-Cards")]ELECTRONICSANDTELECOMTELEPHONECARDS,
[Description("ELECTRONICSANDTELECOM-Telephone-Equipment")]ELECTRONICSANDTELECOMTELEPHONEEQUIPMENT,
[Description("ELECTRONICSANDTELECOM-Telephone-Services")]ELECTRONICSANDTELECOMTELEPHONESERVICES,
[Description("ELECTRONICSANDTELECOM-GeneralElectronics")]ELECTRONICSANDTELECOMGENERALELECTRONICS,
[Description("ELECTRONICSANDTELECOM-Car-Audio-and-Electronics")]ELECTRONICSANDTELECOMCARAUDIOANDELECTRONICS,
[Description("ELECTRONICSANDTELECOM-Home-Electronics")]ELECTRONICSANDTELECOMHOMEELECTRONICS,
[Description("ELECTRONICSANDTELECOM-Home-Audio")]ELECTRONICSANDTELECOMHOMEAUDIO,
[Description("ELECTRONICSANDTELECOM-Gadgets-and-other-electronics")]ELECTRONICSANDTELECOMGADGETSANDOTHERELECTRONICS,
[Description("ELECTRONICSANDTELECOM-Batteries")]ELECTRONICSANDTELECOMBATTERIES,
[Description("ELECTRONICSANDTELECOM-ScannersRadios")]ELECTRONICSANDTELECOMSCANNERSRADIOS,
[Description("ELECTRONICSANDTELECOM-Radar-Dectors")]ELECTRONICSANDTELECOMRADARDECTORS,
[Description("ELECTRONICSANDTELECOM-Radar-Jamming-Devices")]ELECTRONICSANDTELECOMRADARJAMMINGDEVICES,
[Description("ELECTRONICSANDTELECOM-Satellite-and-Cable-TV-Descramblers")]ELECTRONICSANDTELECOMSATELLITEANDCABLETVDESCRAMBLERS,
[Description("ELECTRONICSANDTELECOM-Surveillance-Equipment")]ELECTRONICSANDTELECOMSURVEILLANCEEQUIPMENT,
[Description("ENTERTAINMENT-General")]ENTERTAINMENTGENERAL,
[Description("ENTERTAINMENT-Movies")]ENTERTAINMENTMOVIES,
[Description("ENTERTAINMENT-Music")]ENTERTAINMENTMUSIC,
[Description("ENTERTAINMENT-Concerts")]ENTERTAINMENTCONCERTS,
[Description("ENTERTAINMENT-Theater")]ENTERTAINMENTTHEATER,
[Description("ENTERTAINMENT-Bootleg-Recordings")]ENTERTAINMENTBOOTLEGRECORDINGS,
[Description("ENTERTAINMENT-Promotional-Items")]ENTERTAINMENTPROMOTIONALITEMS,
[Description("ENTERTAINMENTMEMORABILIA-General")]ENTERTAINMENTMEMORABILIAGENERAL,
[Description("ENTERTAINMENTMEMORABILIA-Autographs")]ENTERTAINMENTMEMORABILIAAUTOGRAPHS,
[Description("ENTERTAINMENTMEMORABILIA-Limited-Editions")]ENTERTAINMENTMEMORABILIALIMITEDEDITIONS,
[Description("ENTERTAINMENTMEMORABILIA-Movie")]ENTERTAINMENTMEMORABILIAMOVIE,
[Description("ENTERTAINMENTMEMORABILIA-Music")]ENTERTAINMENTMEMORABILIAMUSIC,
[Description("ENTERTAINMENTMEMORABILIA-Novelties")]ENTERTAINMENTMEMORABILIANOVELTIES,
[Description("ENTERTAINMENTMEMORABILIA-Photos")]ENTERTAINMENTMEMORABILIAPHOTOS,
[Description("ENTERTAINMENTMEMORABILIA-Posters")]ENTERTAINMENTMEMORABILIAPOSTERS,
[Description("ENTERTAINMENTMEMORABILIA-Sports-and-Fan-Shop")]ENTERTAINMENTMEMORABILIASPORTSANDFANSHOP,
[Description("ENTERTAINMENTMEMORABILIA-Science-Fiction")]ENTERTAINMENTMEMORABILIASCIENCEFICTION,
[Description("FOODDRINKANDNUTRITION-General")]FOODDRINKANDNUTRITIONGENERAL,
[Description("FOODDRINKANDNUTRITION-Coffee-and-Tea")]FOODDRINKANDNUTRITIONCOFFEEANDTEA,
[Description("FOODDRINKANDNUTRITION-Food-Products")]FOODDRINKANDNUTRITIONFOODPRODUCTS,
[Description("FOODDRINKANDNUTRITION-Gourmet-Items")]FOODDRINKANDNUTRITIONGOURMETITEMS,
[Description("FOODDRINKANDNUTRITION-Health-and-Nutrition")]FOODDRINKANDNUTRITIONHEALTHANDNUTRITION,
[Description("FOODDRINKANDNUTRITION-Services")]FOODDRINKANDNUTRITIONSERVICES,
[Description("FOODDRINKANDNUTRITION-Vitamins-and-Supplements")]FOODDRINKANDNUTRITIONVITAMINSANDSUPPLEMENTS,
[Description("FOODDRINKANDNUTRITION-Weight-Management-and-Health-Products")]FOODDRINKANDNUTRITIONWEIGHTMANAGEMENTANDHEALTHPRODUCTS,
[Description("FOODDRINKANDNUTRITION-Restaurant")]FOODDRINKANDNUTRITIONRESTAURANT,
[Description("FOODDRINKANDNUTRITION-Tobacco-and-Cigars")]FOODDRINKANDNUTRITIONTOBACCOANDCIGARS,
[Description("FOODDRINKANDNUTRITION-Alcoholic-Beverages")]FOODDRINKANDNUTRITIONALCOHOLICBEVERAGES,
[Description("GIFTSANDFLOWERS-General")]GIFTSANDFLOWERSGENERAL,
[Description("GIFTSANDFLOWERS-Flowers")]GIFTSANDFLOWERSFLOWERS,
[Description("GIFTSANDFLOWERS-Greeting-Cards")]GIFTSANDFLOWERSGREETINGCARDS,
[Description("GIFTSANDFLOWERS-Humorous-Gifts-and-Novelties")]GIFTSANDFLOWERSHUMOROUSGIFTSANDNOVELTIES,
[Description("GIFTSANDFLOWERS-Personalized-Gifts")]GIFTSANDFLOWERSPERSONALIZEDGIFTS,
[Description("GIFTSANDFLOWERS-Products")]GIFTSANDFLOWERSPRODUCTS,
[Description("GIFTSANDFLOWERS-Services")]GIFTSANDFLOWERSSERVICES,
[Description("HOBBIESTOYSANDGAMES-General")]HOBBIESTOYSANDGAMESGENERAL,
[Description("HOBBIESTOYSANDGAMES-Action-Figures")]HOBBIESTOYSANDGAMESACTIONFIGURES,
[Description("HOBBIESTOYSANDGAMES-Bean-Babies")]HOBBIESTOYSANDGAMESBEANBABIES,
[Description("HOBBIESTOYSANDGAMES-Barbies")]HOBBIESTOYSANDGAMESBARBIES,
[Description("HOBBIESTOYSANDGAMES-Bears")]HOBBIESTOYSANDGAMESBEARS,
[Description("HOBBIESTOYSANDGAMES-Dolls")]HOBBIESTOYSANDGAMESDOLLS,
[Description("HOBBIESTOYSANDGAMES-Games")]HOBBIESTOYSANDGAMESGAMES,
[Description("HOBBIESTOYSANDGAMES-Model-Kits")]HOBBIESTOYSANDGAMESMODELKITS,
[Description("HOBBIESTOYSANDGAMES-Diecast-Toys-Vehicles")]HOBBIESTOYSANDGAMESDIECASTTOYSVEHICLES,
[Description("HOBBIESTOYSANDGAMES-Video-Games-and-Systems")]HOBBIESTOYSANDGAMESVIDEOGAMESANDSYSTEMS,
[Description("HOBBIESTOYSANDGAMES-Vintage-and-Antique-Toys")]HOBBIESTOYSANDGAMESVINTAGEANDANTIQUETOYS,
[Description("HOBBIESTOYSANDGAMES-BackupUnreleased-Games")]HOBBIESTOYSANDGAMESBACKUPUNRELEASEDGAMES,
[Description("HOBBIESTOYSANDGAMES-Game-copying-hardwaresoftware")]HOBBIESTOYSANDGAMESGAMECOPYINGHARDWARESOFTWARE,
[Description("HOBBIESTOYSANDGAMES-Mod-Chips")]HOBBIESTOYSANDGAMESMODCHIPS,
[Description("HOMEANDGARDEN-General")]HOMEANDGARDENGENERAL,
[Description("HOMEANDGARDEN-Appliances")]HOMEANDGARDENAPPLIANCES,
[Description("HOMEANDGARDEN-Bed-and-Bath")]HOMEANDGARDENBEDANDBATH,
[Description("HOMEANDGARDEN-Furnishing-and-Decorating")]HOMEANDGARDENFURNISHINGANDDECORATING,
[Description("HOMEANDGARDEN-Garden-Supplies")]HOMEANDGARDENGARDENSUPPLIES,
[Description("HOMEANDGARDEN-Hardware-and-Tools")]HOMEANDGARDENHARDWAREANDTOOLS,
[Description("HOMEANDGARDEN-Household-Goods")]HOMEANDGARDENHOUSEHOLDGOODS,
[Description("HOMEANDGARDEN-Kitchenware")]HOMEANDGARDENKITCHENWARE,
[Description("HOMEANDGARDEN-Rugs-and-Carpets")]HOMEANDGARDENRUGSANDCARPETS,
[Description("HOMEANDGARDEN-Security-and-Home-Defense")]HOMEANDGARDENSECURITYANDHOMEDEFENSE,
[Description("HOMEANDGARDEN-Plants-and-Seeds")]HOMEANDGARDENPLANTSANDSEEDS,
[Description("INTERNETANDNETWORKSERVICES-General")]INTERNETANDNETWORKSERVICESGENERAL,
[Description("INTERNETANDNETWORKSERVICES-Bulletin-board")]INTERNETANDNETWORKSERVICESBULLETINBOARD,
[Description("INTERNETANDNETWORKSERVICES-online-services")]INTERNETANDNETWORKSERVICESONLINESERVICES,
[Description("INTERNETANDNETWORKSERVICES-Auction-management-tools")]INTERNETANDNETWORKSERVICESAUCTIONMANAGEMENTTOOLS,
[Description("INTERNETANDNETWORKSERVICES-ecommerce-development")]INTERNETANDNETWORKSERVICESECOMMERCEDEVELOPMENT,
[Description("INTERNETANDNETWORKSERVICES-training-services")]INTERNETANDNETWORKSERVICESTRAININGSERVICES,
[Description("INTERNETANDNETWORKSERVICES-Online-Malls")]INTERNETANDNETWORKSERVICESONLINEMALLS,
[Description("INTERNETANDNETWORKSERVICES-Web-hosting-and-design")]INTERNETANDNETWORKSERVICESWEBHOSTINGANDDESIGN,
[Description("MEDIAANDENTERTAINMENT-General")]MEDIAANDENTERTAINMENTGENERAL,
[Description("MEDIAANDENTERTAINMENT-Concerts")]MEDIAANDENTERTAINMENTCONCERTS,
[Description("MEDIAANDENTERTAINMENT-Theater")]MEDIAANDENTERTAINMENTTHEATER,
[Description("MEDICALANDPHARMACEUTICAL-General")]MEDICALANDPHARMACEUTICALGENERAL,
[Description("MEDICALANDPHARMACEUTICAL-Medical")]MEDICALANDPHARMACEUTICALMEDICAL,
[Description("MEDICALANDPHARMACEUTICAL-Dental")]MEDICALANDPHARMACEUTICALDENTAL,
[Description("MEDICALANDPHARMACEUTICAL-Opthamalic")]MEDICALANDPHARMACEUTICALOPTHAMALIC,
[Description("MEDICALANDPHARMACEUTICAL-Prescription-Drugs")]MEDICALANDPHARMACEUTICALPRESCRIPTIONDRUGS,
[Description("MEDICALANDPHARMACEUTICAL-Devices")]MEDICALANDPHARMACEUTICALDEVICES,
[Description("MONEYSERVICEBUSINESSES-General")]MONEYSERVICEBUSINESSESGENERAL,
[Description("MONEYSERVICEBUSINESSES-Remittance")]MONEYSERVICEBUSINESSESREMITTANCE,
[Description("MONEYSERVICEBUSINESSES-Wire-Transfer")]MONEYSERVICEBUSINESSESWIRETRANSFER,
[Description("MONEYSERVICEBUSINESSES-Money-Orders")]MONEYSERVICEBUSINESSESMONEYORDERS,
[Description("MONEYSERVICEBUSINESSES-Electronic-Cash")]MONEYSERVICEBUSINESSESELECTRONICCASH,
[Description("MONEYSERVICEBUSINESSES-Currency-DealerExchange")]MONEYSERVICEBUSINESSESCURRENCYDEALEREXCHANGE,
[Description("MONEYSERVICEBUSINESSES-Check-Cashier")]MONEYSERVICEBUSINESSESCHECKCASHIER,
[Description("MONEYSERVICEBUSINESSES-Travelers-Checks")]MONEYSERVICEBUSINESSESTRAVELERSCHECKS,
[Description("MONEYSERVICEBUSINESSES-Stored-Value-Cards")]MONEYSERVICEBUSINESSESSTOREDVALUECARDS,
[Description("NONPROFITPOLITICALANDRELIGION-General")]NONPROFITPOLITICALANDRELIGIONGENERAL,
[Description("NONPROFITPOLITICALANDRELIGION-Charities")]NONPROFITPOLITICALANDRELIGIONCHARITIES,
[Description("NONPROFITPOLITICALANDRELIGION-Political")]NONPROFITPOLITICALANDRELIGIONPOLITICAL,
[Description("NONPROFITPOLITICALANDRELIGION-Religious")]NONPROFITPOLITICALANDRELIGIONRELIGIOUS,
[Description("PETSANDANIMALS-General")]PETSANDANIMALSGENERAL,
[Description("PETSANDANIMALS-Supplies-and-Toys")]PETSANDANIMALSSUPPLIESANDTOYS,
[Description("PETSANDANIMALS-Wildlife-Products")]PETSANDANIMALSWILDLIFEPRODUCTS,
[Description("REALESTATE-General")]REALESTATEGENERAL,
[Description("REALESTATE-Commercial")]REALESTATECOMMERCIAL,
[Description("REALESTATE-Residential")]REALESTATERESIDENTIAL,
[Description("REALESTATE-Time-Shares")]REALESTATETIMESHARES,
[Description("SERVICES-GeneralGovernment")]SERVICESGENERALGOVERNMENT,
[Description("SERVICES-Legal")]SERVICESLEGAL,
[Description("SERVICES-Medical")]SERVICESMEDICAL,
[Description("SERVICES-Dental")]SERVICESDENTAL,
[Description("SERVICES-Vision")]SERVICESVISION,
[Description("SERVICES-General")]SERVICESGENERAL,
[Description("SERVICES-Child-Care-Services")]SERVICESCHILDCARESERVICES,
[Description("SERVICES-Consulting")]SERVICESCONSULTING,
[Description("SERVICES-ImportingExporting")]SERVICESIMPORTINGEXPORTING,
[Description("SERVICES-InsuranceDirect")]SERVICESINSURANCEDIRECT,
[Description("SERVICES-Financial-Services")]SERVICESFINANCIALSERVICES,
[Description("SERVICES-Graphic-and-Commercial-Design")]SERVICESGRAPHICANDCOMMERCIALDESIGN,
[Description("SERVICES-Landscaping")]SERVICESLANDSCAPING,
[Description("SERVICES-Locksmith")]SERVICESLOCKSMITH,
[Description("SERVICES-Online-Dating")]SERVICESONLINEDATING,
[Description("SERVICES-Event-and-Wedding-Planning")]SERVICESEVENTANDWEDDINGPLANNING,
[Description("SERVICES-Schools-and-Colleges")]SERVICESSCHOOLSANDCOLLEGES,
[Description("SERVICES-Entertainment")]SERVICESENTERTAINMENT,
[Description("SERVICES-Aggregators")]SERVICESAGGREGATORS,
[Description("SPORTSANDRECREATION-General")]SPORTSANDRECREATIONGENERAL,
[Description("SPORTSANDRECREATION-Bicycles-and-Accessories")]SPORTSANDRECREATIONBICYCLESANDACCESSORIES,
[Description("SPORTSANDRECREATION-Boating-Sailing-and-Accessories")]SPORTSANDRECREATIONBOATINGSAILINGANDACCESSORIES,
[Description("SPORTSANDRECREATION-Camping-and-Survival")]SPORTSANDRECREATIONCAMPINGANDSURVIVAL,
[Description("SPORTSANDRECREATION-Exercise-Equipment")]SPORTSANDRECREATIONEXERCISEEQUIPMENT,
[Description("SPORTSANDRECREATION-Fishing")]SPORTSANDRECREATIONFISHING,
[Description("SPORTSANDRECREATION-Golf")]SPORTSANDRECREATIONGOLF,
[Description("SPORTSANDRECREATION-Hunting")]SPORTSANDRECREATIONHUNTING,
[Description("SPORTSANDRECREATION-Paintball")]SPORTSANDRECREATIONPAINTBALL,
[Description("SPORTSANDRECREATION-Sporting-Goods")]SPORTSANDRECREATIONSPORTINGGOODS,
[Description("SPORTSANDRECREATION-Swimming-Pools-and-Spas")]SPORTSANDRECREATIONSWIMMINGPOOLSANDSPAS,
[Description("TRAVEL-General")]TRAVELGENERAL,
[Description("TRAVEL-Accommodations")]TRAVELACCOMMODATIONS,
[Description("TRAVEL-Agencies")]TRAVELAGENCIES,
[Description("TRAVEL-Airlines")]TRAVELAIRLINES,
[Description("TRAVEL-Auto-Rentals")]TRAVELAUTORENTALS,
[Description("TRAVEL-Cruises")]TRAVELCRUISES,
[Description("TRAVEL-Other-Transportation")]TRAVELOTHERTRANSPORTATION,
[Description("TRAVEL-Services")]TRAVELSERVICES,
[Description("TRAVEL-Supplies")]TRAVELSUPPLIES,
[Description("TRAVEL-Tours")]TRAVELTOURS,
[Description("TRAVEL-AirlinesSpirit-Air")]TRAVELAIRLINESSPIRITAIR,
[Description("Other-SubCategories")]OTHERSUBCATEGORIES,
	}
	public enum BusinessTypeType {
[Description("Unknown")]UNKNOWN,
[Description("Individual")]INDIVIDUAL,
[Description("Proprietorship")]PROPRIETORSHIP,
[Description("Partnership")]PARTNERSHIP,
[Description("Corporation")]CORPORATION,
[Description("Nonprofit")]NONPROFIT,
[Description("Government")]GOVERNMENT,
	}
	public enum ButtonCodeType {
[Description("HOSTED")]HOSTED,
[Description("ENCRYPTED")]ENCRYPTED,
[Description("CLEARTEXT")]CLEARTEXT,
[Description("TOKEN")]TOKEN,
	}
	public enum ButtonImageType {
[Description("REG")]REG,
[Description("SML")]SML,
[Description("CC")]CC,
	}
	/**
	 */
	public partial class ButtonSearchResultType {

		private string HostedButtonIDField;
		public string HostedButtonID {
			get {
				return this.HostedButtonIDField;
			}
			set {
				this.HostedButtonIDField = value;
			}
		}

		private string ButtonTypeField;
		public string ButtonType {
			get {
				return this.ButtonTypeField;
			}
			set {
				this.ButtonTypeField = value;
			}
		}

		private string ItemNameField;
		public string ItemName {
			get {
				return this.ItemNameField;
			}
			set {
				this.ItemNameField = value;
			}
		}

		private string ModifyDateField;
		public string ModifyDate {
			get {
				return this.ModifyDateField;
			}
			set {
				this.ModifyDateField = value;
			}
		}

	 public ButtonSearchResultType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("HostedButtonID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("HostedButtonID")[0])){ 
		 this.HostedButtonID =(string)document.GetElementsByTagName("HostedButtonID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ButtonType").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ButtonType")[0])){ 
		 this.ButtonType =(string)document.GetElementsByTagName("ButtonType")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ItemName").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ItemName")[0])){ 
		 this.ItemName =(string)document.GetElementsByTagName("ItemName")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ModifyDate").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ModifyDate")[0])){ 
		 this.ModifyDate =(string)document.GetElementsByTagName("ModifyDate")[0].InnerText;

}
	}
	}
	}


	public enum ButtonStatusType {
[Description("DELETE")]DELETE,
	}
	public enum ButtonSubTypeType {
[Description("PRODUCTS")]PRODUCTS,
[Description("SERVICES")]SERVICES,
	}
	public enum ButtonTypeType {
[Description("BUYNOW")]BUYNOW,
[Description("CART")]CART,
[Description("GIFTCERTIFICATE")]GIFTCERTIFICATE,
[Description("SUBSCRIBE")]SUBSCRIBE,
[Description("DONATE")]DONATE,
[Description("UNSUBSCRIBE")]UNSUBSCRIBE,
[Description("VIEWCART")]VIEWCART,
[Description("PAYMENTPLAN")]PAYMENTPLAN,
[Description("AUTOBILLING")]AUTOBILLING,
[Description("PAYMENT")]PAYMENT,
	}
	public enum BuyNowTextType {
[Description("BUYNOW")]BUYNOW,
[Description("PAYNOW")]PAYNOW,
	}
	/**
	 * Information that is used to indentify the Buyer. This is used for auto authorization. Mandatory if Authorization is requested.
	 */
	public partial class BuyerDetailType {

		/**
Information that is used to indentify the Buyer. This is used for auto authorization. Mandatory if Authorization is requested.		 */
		private IdentificationInfoType IdentificationInfoField;
		public IdentificationInfoType IdentificationInfo {
			get {
				return this.IdentificationInfoField;
			}
			set {
				this.IdentificationInfoField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( IdentificationInfo != null ) {
			sb.Append("<ebl:IdentificationInfo>");
			sb.Append(IdentificationInfo.toXMLString());
			sb.Append("</ebl:IdentificationInfo>");
		}
		return sb.ToString();
	}

	}


	/**
	 * Details about the buyer's account passed in by the merchant or partner.
	 * Optional.
	 */
	public partial class BuyerDetailsType {

		/**
		 * The client's unique ID for this user.
		 */
		private string BuyerIdField;
		public string BuyerId {
			get {
				return this.BuyerIdField;
			}
			set {
				this.BuyerIdField = value;
			}
		}

		/**
		 * The user name of the user at the marketplaces site.
		 */
		private string BuyerUserNameField;
		public string BuyerUserName {
			get {
				return this.BuyerUserNameField;
			}
			set {
				this.BuyerUserNameField = value;
			}
		}

		/**
		 * Date when the user registered with the marketplace.
		 */
		private string BuyerRegistrationDateField;
		public string BuyerRegistrationDate {
			get {
				return this.BuyerRegistrationDateField;
			}
			set {
				this.BuyerRegistrationDateField = value;
			}
		}

		/**
		 * Details about payer's tax info.
		 * Refer to the TaxIdDetailsType for more details.
		 */
		private TaxIdDetailsType TaxIdDetailsField;
		public TaxIdDetailsType TaxIdDetails {
			get {
				return this.TaxIdDetailsField;
			}
			set {
				this.TaxIdDetailsField = value;
			}
		}

		/**
		 * Contains information that identifies the buyer. e.g. email address or the external remember me id.
		 */
		private IdentificationInfoType IdentificationInfoField;
		public IdentificationInfoType IdentificationInfo {
			get {
				return this.IdentificationInfoField;
			}
			set {
				this.IdentificationInfoField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( BuyerId != null ) {
			sb.Append("<ebl:BuyerId>").Append(BuyerId);
			sb.Append("</ebl:BuyerId>");
		}
		if( BuyerUserName != null ) {
			sb.Append("<ebl:BuyerUserName>").Append(BuyerUserName);
			sb.Append("</ebl:BuyerUserName>");
		}
		if( BuyerRegistrationDate != null ) {
			sb.Append("<ebl:BuyerRegistrationDate>").Append(BuyerRegistrationDate);
			sb.Append("</ebl:BuyerRegistrationDate>");
		}
		if( TaxIdDetails != null ) {
			sb.Append("<ebl:TaxIdDetails>");
			sb.Append(TaxIdDetails.toXMLString());
			sb.Append("</ebl:TaxIdDetails>");
		}
		if( IdentificationInfo != null ) {
			sb.Append("<ebl:IdentificationInfo>");
			sb.Append(IdentificationInfo.toXMLString());
			sb.Append("</ebl:IdentificationInfo>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class CancelRecoupReq {

		private CancelRecoupRequestType CancelRecoupRequestField;
		public CancelRecoupRequestType CancelRecoupRequest {
			get {
				return this.CancelRecoupRequestField;
			}
			set {
				this.CancelRecoupRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:CancelRecoupReq>");
		if( CancelRecoupRequest != null ) {
			sb.Append("<urn:CancelRecoupRequest>");
			sb.Append(CancelRecoupRequest.toXMLString());
			sb.Append("</urn:CancelRecoupRequest>");
		}
sb.Append("</urn:CancelRecoupReq>");
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class CancelRecoupRequestType :AbstractRequestType{

		private EnhancedCancelRecoupRequestDetailsType EnhancedCancelRecoupRequestDetailsField;
		public EnhancedCancelRecoupRequestDetailsType EnhancedCancelRecoupRequestDetails {
			get {
				return this.EnhancedCancelRecoupRequestDetailsField;
			}
			set {
				this.EnhancedCancelRecoupRequestDetailsField = value;
			}
		}

		public CancelRecoupRequestType(EnhancedCancelRecoupRequestDetailsType EnhancedCancelRecoupRequestDetails) {
			this.EnhancedCancelRecoupRequestDetails = EnhancedCancelRecoupRequestDetails;
		}
		public CancelRecoupRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( EnhancedCancelRecoupRequestDetails != null ) {
			sb.Append("<ed:EnhancedCancelRecoupRequestDetails>");
			sb.Append(EnhancedCancelRecoupRequestDetails.toXMLString());
			sb.Append("</ed:EnhancedCancelRecoupRequestDetails>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class CancelRecoupResponseType :AbstractResponseType{

	 public CancelRecoupResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
	}
	}


	public enum ChannelType {
[Description("Merchant")]MERCHANT,
[Description("eBayItem")]EBAYITEM,
	}
	public enum CompleteCodeType {
[Description("NotComplete")]NOTCOMPLETE,
[Description("Complete")]COMPLETE,
	}
	/**
	 */
	public partial class CompleteRecoupReq {

		private CompleteRecoupRequestType CompleteRecoupRequestField;
		public CompleteRecoupRequestType CompleteRecoupRequest {
			get {
				return this.CompleteRecoupRequestField;
			}
			set {
				this.CompleteRecoupRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:CompleteRecoupReq>");
		if( CompleteRecoupRequest != null ) {
			sb.Append("<urn:CompleteRecoupRequest>");
			sb.Append(CompleteRecoupRequest.toXMLString());
			sb.Append("</urn:CompleteRecoupRequest>");
		}
sb.Append("</urn:CompleteRecoupReq>");
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class CompleteRecoupRequestType :AbstractRequestType{

		private EnhancedCompleteRecoupRequestDetailsType EnhancedCompleteRecoupRequestDetailsField;
		public EnhancedCompleteRecoupRequestDetailsType EnhancedCompleteRecoupRequestDetails {
			get {
				return this.EnhancedCompleteRecoupRequestDetailsField;
			}
			set {
				this.EnhancedCompleteRecoupRequestDetailsField = value;
			}
		}

		public CompleteRecoupRequestType(EnhancedCompleteRecoupRequestDetailsType EnhancedCompleteRecoupRequestDetails) {
			this.EnhancedCompleteRecoupRequestDetails = EnhancedCompleteRecoupRequestDetails;
		}
		public CompleteRecoupRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( EnhancedCompleteRecoupRequestDetails != null ) {
			sb.Append("<ed:EnhancedCompleteRecoupRequestDetails>");
			sb.Append(EnhancedCompleteRecoupRequestDetails.toXMLString());
			sb.Append("</ed:EnhancedCompleteRecoupRequestDetails>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class CompleteRecoupResponseType :AbstractResponseType{

		private EnhancedCompleteRecoupResponseDetailsType EnhancedCompleteRecoupResponseDetailsField;
		public EnhancedCompleteRecoupResponseDetailsType EnhancedCompleteRecoupResponseDetails {
			get {
				return this.EnhancedCompleteRecoupResponseDetailsField;
			}
			set {
				this.EnhancedCompleteRecoupResponseDetailsField = value;
			}
		}

	 public CompleteRecoupResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("EnhancedCompleteRecoupResponseDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("EnhancedCompleteRecoupResponseDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("EnhancedCompleteRecoupResponseDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.EnhancedCompleteRecoupResponseDetails =  new EnhancedCompleteRecoupResponseDetailsType(xmlString);

}
	}
	}
	}


	public enum CountryCodeType {
[Description("AF")]AF,
[Description("AL")]AL,
[Description("DZ")]DZ,
[Description("AS")]AS,
[Description("AD")]AD,
[Description("AO")]AO,
[Description("AI")]AI,
[Description("AQ")]AQ,
[Description("AG")]AG,
[Description("AR")]AR,
[Description("AM")]AM,
[Description("AW")]AW,
[Description("AU")]AU,
[Description("AT")]AT,
[Description("AZ")]AZ,
[Description("BS")]BS,
[Description("BH")]BH,
[Description("BD")]BD,
[Description("BB")]BB,
[Description("BY")]BY,
[Description("BE")]BE,
[Description("BZ")]BZ,
[Description("BJ")]BJ,
[Description("BM")]BM,
[Description("BT")]BT,
[Description("BO")]BO,
[Description("BA")]BA,
[Description("BW")]BW,
[Description("BV")]BV,
[Description("BR")]BR,
[Description("IO")]IO,
[Description("BN")]BN,
[Description("BG")]BG,
[Description("BF")]BF,
[Description("BI")]BI,
[Description("KH")]KH,
[Description("CM")]CM,
[Description("CA")]CA,
[Description("CV")]CV,
[Description("KY")]KY,
[Description("CF")]CF,
[Description("TD")]TD,
[Description("CL")]CL,
[Description("C2")]C,
[Description("CN")]CN,
[Description("CX")]CX,
[Description("CC")]CC,
[Description("CO")]CO,
[Description("KM")]KM,
[Description("CG")]CG,
[Description("CD")]CD,
[Description("CK")]CK,
[Description("CR")]CR,
[Description("CI")]CI,
[Description("HR")]HR,
[Description("CU")]CU,
[Description("CY")]CY,
[Description("CZ")]CZ,
[Description("DK")]DK,
[Description("DJ")]DJ,
[Description("DM")]DM,
[Description("DO")]DO,
[Description("TP")]TP,
[Description("EC")]EC,
[Description("EG")]EG,
[Description("SV")]SV,
[Description("GQ")]GQ,
[Description("ER")]ER,
[Description("EE")]EE,
[Description("ET")]ET,
[Description("FK")]FK,
[Description("FO")]FO,
[Description("FJ")]FJ,
[Description("FI")]FI,
[Description("FR")]FR,
[Description("GF")]GF,
[Description("PF")]PF,
[Description("TF")]TF,
[Description("GA")]GA,
[Description("GM")]GM,
[Description("GE")]GE,
[Description("DE")]DE,
[Description("GH")]GH,
[Description("GI")]GI,
[Description("GR")]GR,
[Description("GL")]GL,
[Description("GD")]GD,
[Description("GP")]GP,
[Description("GU")]GU,
[Description("GT")]GT,
[Description("GN")]GN,
[Description("GW")]GW,
[Description("GY")]GY,
[Description("HT")]HT,
[Description("HM")]HM,
[Description("VA")]VA,
[Description("HN")]HN,
[Description("HK")]HK,
[Description("HU")]HU,
[Description("IS")]IS,
[Description("IN")]IN,
[Description("ID")]ID,
[Description("IR")]IR,
[Description("IQ")]IQ,
[Description("IE")]IE,
[Description("IL")]IL,
[Description("IT")]IT,
[Description("JM")]JM,
[Description("JP")]JP,
[Description("JO")]JO,
[Description("KZ")]KZ,
[Description("KE")]KE,
[Description("KI")]KI,
[Description("KP")]KP,
[Description("KR")]KR,
[Description("KW")]KW,
[Description("KG")]KG,
[Description("LA")]LA,
[Description("LV")]LV,
[Description("LB")]LB,
[Description("LS")]LS,
[Description("LR")]LR,
[Description("LY")]LY,
[Description("LI")]LI,
[Description("LT")]LT,
[Description("LU")]LU,
[Description("MO")]MO,
[Description("MK")]MK,
[Description("MG")]MG,
[Description("MW")]MW,
[Description("MY")]MY,
[Description("MV")]MV,
[Description("ML")]ML,
[Description("MT")]MT,
[Description("MH")]MH,
[Description("MQ")]MQ,
[Description("MR")]MR,
[Description("MU")]MU,
[Description("YT")]YT,
[Description("MX")]MX,
[Description("FM")]FM,
[Description("MD")]MD,
[Description("MC")]MC,
[Description("MN")]MN,
[Description("MS")]MS,
[Description("MA")]MA,
[Description("MZ")]MZ,
[Description("MM")]MM,
[Description("NA")]NA,
[Description("NR")]NR,
[Description("NP")]NP,
[Description("NL")]NL,
[Description("AN")]AN,
[Description("NC")]NC,
[Description("NZ")]NZ,
[Description("NI")]NI,
[Description("NE")]NE,
[Description("NG")]NG,
[Description("NU")]NU,
[Description("NF")]NF,
[Description("MP")]MP,
[Description("NO")]NO,
[Description("OM")]OM,
[Description("PK")]PK,
[Description("PW")]PW,
[Description("PS")]PS,
[Description("PA")]PA,
[Description("PG")]PG,
[Description("PY")]PY,
[Description("PE")]PE,
[Description("PH")]PH,
[Description("PN")]PN,
[Description("PL")]PL,
[Description("PT")]PT,
[Description("PR")]PR,
[Description("QA")]QA,
[Description("RE")]RE,
[Description("RO")]RO,
[Description("RU")]RU,
[Description("RW")]RW,
[Description("SH")]SH,
[Description("KN")]KN,
[Description("LC")]LC,
[Description("PM")]PM,
[Description("VC")]VC,
[Description("WS")]WS,
[Description("SM")]SM,
[Description("ST")]ST,
[Description("SA")]SA,
[Description("SN")]SN,
[Description("SC")]SC,
[Description("SL")]SL,
[Description("SG")]SG,
[Description("SK")]SK,
[Description("SI")]SI,
[Description("SB")]SB,
[Description("SO")]SO,
[Description("ZA")]ZA,
[Description("GS")]GS,
[Description("ES")]ES,
[Description("LK")]LK,
[Description("SD")]SD,
[Description("SR")]SR,
[Description("SJ")]SJ,
[Description("SZ")]SZ,
[Description("SE")]SE,
[Description("CH")]CH,
[Description("SY")]SY,
[Description("TW")]TW,
[Description("TJ")]TJ,
[Description("TZ")]TZ,
[Description("TH")]TH,
[Description("TG")]TG,
[Description("TK")]TK,
[Description("TO")]TO,
[Description("TT")]TT,
[Description("TN")]TN,
[Description("TR")]TR,
[Description("TM")]TM,
[Description("TC")]TC,
[Description("TV")]TV,
[Description("UG")]UG,
[Description("UA")]UA,
[Description("AE")]AE,
[Description("GB")]GB,
[Description("US")]US,
[Description("UM")]UM,
[Description("UY")]UY,
[Description("UZ")]UZ,
[Description("VU")]VU,
[Description("VE")]VE,
[Description("VN")]VN,
[Description("VG")]VG,
[Description("VI")]VI,
[Description("WF")]WF,
[Description("EH")]EH,
[Description("YE")]YE,
[Description("YU")]YU,
[Description("ZM")]ZM,
[Description("ZW")]ZW,
[Description("AA")]AA,
[Description("QM")]QM,
[Description("QN")]QN,
[Description("QO")]QO,
[Description("QP")]QP,
[Description("CS")]CS,
[Description("CustomCode")]CUSTOMCODE,
[Description("GG")]GG,
[Description("IM")]IM,
[Description("JE")]JE,
[Description("TL")]TL,
	}
	/**
	 */
	public partial class CreateBillingAgreementReq {

		private CreateBillingAgreementRequestType CreateBillingAgreementRequestField;
		public CreateBillingAgreementRequestType CreateBillingAgreementRequest {
			get {
				return this.CreateBillingAgreementRequestField;
			}
			set {
				this.CreateBillingAgreementRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:CreateBillingAgreementReq>");
		if( CreateBillingAgreementRequest != null ) {
			sb.Append("<urn:CreateBillingAgreementRequest>");
			sb.Append(CreateBillingAgreementRequest.toXMLString());
			sb.Append("</urn:CreateBillingAgreementRequest>");
		}
sb.Append("</urn:CreateBillingAgreementReq>");
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class CreateBillingAgreementRequestType :AbstractRequestType{

		/**
		 */
		private string TokenField;
		public string Token {
			get {
				return this.TokenField;
			}
			set {
				this.TokenField = value;
			}
		}

		public CreateBillingAgreementRequestType(string Token) {
			this.Token = Token;
		}
		public CreateBillingAgreementRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( Token != null ) {
			sb.Append("<urn:Token>").Append(Token);
			sb.Append("</urn:Token>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class CreateBillingAgreementResponseType :AbstractResponseType{

		/**
		 */
		private string BillingAgreementIDField;
		public string BillingAgreementID {
			get {
				return this.BillingAgreementIDField;
			}
			set {
				this.BillingAgreementIDField = value;
			}
		}

	 public CreateBillingAgreementResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("BillingAgreementID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillingAgreementID")[0])){ 
		 nodeList = document.GetElementsByTagName("BillingAgreementID");
			 string value = nodeList[0].InnerText; 
		 this.BillingAgreementID =value;

}
	}
	}
	}


	/**
	 */
	public partial class CreateMobilePaymentReq {

		private CreateMobilePaymentRequestType CreateMobilePaymentRequestField;
		public CreateMobilePaymentRequestType CreateMobilePaymentRequest {
			get {
				return this.CreateMobilePaymentRequestField;
			}
			set {
				this.CreateMobilePaymentRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:CreateMobilePaymentReq>");
		if( CreateMobilePaymentRequest != null ) {
			sb.Append("<urn:CreateMobilePaymentRequest>");
			sb.Append(CreateMobilePaymentRequest.toXMLString());
			sb.Append("</urn:CreateMobilePaymentRequest>");
		}
sb.Append("</urn:CreateMobilePaymentReq>");
		return sb.ToString();
	}

	}


	/**
	 * Type of the payment
	 * Required
	 */
	public partial class CreateMobilePaymentRequestDetailsType {

		/**
Type of the payment
		 * Required
		 */
		private MobilePaymentCodeType? PaymentTypeField;
		public MobilePaymentCodeType? PaymentType {
			get {
				return this.PaymentTypeField;
			}
			set {
				this.PaymentTypeField = value;
			}
		}

		/**
		 * How you want to obtain payment.  Defaults to Sale.
		 * Optional
		 * Authorization indicates that this payment is a basic authorization subject to settlement with PayPal Authorization and Capture.
		 * Sale indicates that this is a final sale for which you are requesting payment.
		 */
		private PaymentActionCodeType? PaymentActionField;
		public PaymentActionCodeType? PaymentAction {
			get {
				return this.PaymentActionField;
			}
			set {
				this.PaymentActionField = value;
			}
		}

		/**
Phone number of the user making the payment.
		 * Required
		 */
		private PhoneNumberType SenderPhoneField;
		public PhoneNumberType SenderPhone {
			get {
				return this.SenderPhoneField;
			}
			set {
				this.SenderPhoneField = value;
			}
		}

		/**
Type of recipient specified, i.e., phone number or email address
		 * Required
		 */
		private MobileRecipientCodeType? RecipientTypeField;
		public MobileRecipientCodeType? RecipientType {
			get {
				return this.RecipientTypeField;
			}
			set {
				this.RecipientTypeField = value;
			}
		}

		/**
Email address of the recipient
		 */
		private string RecipientEmailField;
		public string RecipientEmail {
			get {
				return this.RecipientEmailField;
			}
			set {
				this.RecipientEmailField = value;
			}
		}

		/**
Phone number of the recipipent
		 * Required
		 */
		private PhoneNumberType RecipientPhoneField;
		public PhoneNumberType RecipientPhone {
			get {
				return this.RecipientPhoneField;
			}
			set {
				this.RecipientPhoneField = value;
			}
		}

		/**
Amount of item before tax and shipping
		 */
		private BasicAmountType ItemAmountField;
		public BasicAmountType ItemAmount {
			get {
				return this.ItemAmountField;
			}
			set {
				this.ItemAmountField = value;
			}
		}

		/**
The tax charged on the transaction
Tax
		 * Optional
		 */
		private BasicAmountType TaxField;
		public BasicAmountType Tax {
			get {
				return this.TaxField;
			}
			set {
				this.TaxField = value;
			}
		}

		/**
Per-transaction shipping charge
		 * Optional
		 */
		private BasicAmountType ShippingField;
		public BasicAmountType Shipping {
			get {
				return this.ShippingField;
			}
			set {
				this.ShippingField = value;
			}
		}

		/**
Name of the item being ordered
		 * Optional
		 * Character length and limitations: 255 single-byte alphanumeric characters
		 */
		private string ItemNameField;
		public string ItemName {
			get {
				return this.ItemNameField;
			}
			set {
				this.ItemNameField = value;
			}
		}

		/**
SKU of the item being ordered
		 * Optional
		 * Character length and limitations: 255 single-byte alphanumeric characters
		 */
		private string ItemNumberField;
		public string ItemNumber {
			get {
				return this.ItemNumberField;
			}
			set {
				this.ItemNumberField = value;
			}
		}

		/**
Memo entered by sender in PayPal Website Payments note field.
		 * Optional
		 * Character length and limitations: 255 single-byte alphanumeric characters
		 */
		private string NoteField;
		public string Note {
			get {
				return this.NoteField;
			}
			set {
				this.NoteField = value;
			}
		}

		/**
Unique ID for the order.  Required for non-P2P transactions
		 * Optional
		 * Character length and limitations: 255 single-byte alphanumeric characters
		 */
		private string CustomIDField;
		public string CustomID {
			get {
				return this.CustomIDField;
			}
			set {
				this.CustomIDField = value;
			}
		}

		/**
Indicates whether the sender's phone number will be shared with recipient
		 * Optional
		 */
		private int? SharePhoneNumberField;
		public int? SharePhoneNumber {
			get {
				return this.SharePhoneNumberField;
			}
			set {
				this.SharePhoneNumberField = value;
			}
		}

		/**
Indicates whether the sender's home address will be shared with recipient
		 * Optional
		 */
		private int? ShareHomeAddressField;
		public int? ShareHomeAddress {
			get {
				return this.ShareHomeAddressField;
			}
			set {
				this.ShareHomeAddressField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( PaymentType != null ) {
			sb.Append("<ebl:PaymentType>").Append(EnumUtils.getDescription(PaymentType));
			sb.Append("</ebl:PaymentType>");
		}
		if( PaymentAction != null ) {
			sb.Append("<ebl:PaymentAction>").Append(EnumUtils.getDescription(PaymentAction));
			sb.Append("</ebl:PaymentAction>");
		}
		if( SenderPhone != null ) {
			sb.Append("<ebl:SenderPhone>");
			sb.Append(SenderPhone.toXMLString());
			sb.Append("</ebl:SenderPhone>");
		}
		if( RecipientType != null ) {
			sb.Append("<ebl:RecipientType>").Append(EnumUtils.getDescription(RecipientType));
			sb.Append("</ebl:RecipientType>");
		}
		if( RecipientEmail != null ) {
			sb.Append("<ebl:RecipientEmail>").Append(RecipientEmail);
			sb.Append("</ebl:RecipientEmail>");
		}
		if( RecipientPhone != null ) {
			sb.Append("<ebl:RecipientPhone>");
			sb.Append(RecipientPhone.toXMLString());
			sb.Append("</ebl:RecipientPhone>");
		}
		if( ItemAmount != null ) {
			sb.Append("<ebl:ItemAmount ");
			sb.Append(ItemAmount.toXMLString());
			sb.Append("</ebl:ItemAmount>");
		}
		if( Tax != null ) {
			sb.Append("<ebl:Tax ");
			sb.Append(Tax.toXMLString());
			sb.Append("</ebl:Tax>");
		}
		if( Shipping != null ) {
			sb.Append("<ebl:Shipping ");
			sb.Append(Shipping.toXMLString());
			sb.Append("</ebl:Shipping>");
		}
		if( ItemName != null ) {
			sb.Append("<ebl:ItemName>").Append(ItemName);
			sb.Append("</ebl:ItemName>");
		}
		if( ItemNumber != null ) {
			sb.Append("<ebl:ItemNumber>").Append(ItemNumber);
			sb.Append("</ebl:ItemNumber>");
		}
		if( Note != null ) {
			sb.Append("<ebl:Note>").Append(Note);
			sb.Append("</ebl:Note>");
		}
		if( CustomID != null ) {
			sb.Append("<ebl:CustomID>").Append(CustomID);
			sb.Append("</ebl:CustomID>");
		}
		if( SharePhoneNumber != null ) {
			sb.Append("<ebl:SharePhoneNumber>").Append(SharePhoneNumber);
			sb.Append("</ebl:SharePhoneNumber>");
		}
		if( ShareHomeAddress != null ) {
			sb.Append("<ebl:ShareHomeAddress>").Append(ShareHomeAddress);
			sb.Append("</ebl:ShareHomeAddress>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class CreateMobilePaymentRequestType :AbstractRequestType{

		private CreateMobilePaymentRequestDetailsType CreateMobilePaymentRequestDetailsField;
		public CreateMobilePaymentRequestDetailsType CreateMobilePaymentRequestDetails {
			get {
				return this.CreateMobilePaymentRequestDetailsField;
			}
			set {
				this.CreateMobilePaymentRequestDetailsField = value;
			}
		}

		public CreateMobilePaymentRequestType(CreateMobilePaymentRequestDetailsType CreateMobilePaymentRequestDetails) {
			this.CreateMobilePaymentRequestDetails = CreateMobilePaymentRequestDetails;
		}
		public CreateMobilePaymentRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( CreateMobilePaymentRequestDetails != null ) {
			sb.Append("<ebl:CreateMobilePaymentRequestDetails>");
			sb.Append(CreateMobilePaymentRequestDetails.toXMLString());
			sb.Append("</ebl:CreateMobilePaymentRequestDetails>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class CreateMobilePaymentResponseType :AbstractResponseType{

	 public CreateMobilePaymentResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
	}
	}


	/**
	 */
	public partial class CreateRecurringPaymentsProfileReq {

		private CreateRecurringPaymentsProfileRequestType CreateRecurringPaymentsProfileRequestField;
		public CreateRecurringPaymentsProfileRequestType CreateRecurringPaymentsProfileRequest {
			get {
				return this.CreateRecurringPaymentsProfileRequestField;
			}
			set {
				this.CreateRecurringPaymentsProfileRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:CreateRecurringPaymentsProfileReq>");
		if( CreateRecurringPaymentsProfileRequest != null ) {
			sb.Append("<urn:CreateRecurringPaymentsProfileRequest>");
			sb.Append(CreateRecurringPaymentsProfileRequest.toXMLString());
			sb.Append("</urn:CreateRecurringPaymentsProfileRequest>");
		}
sb.Append("</urn:CreateRecurringPaymentsProfileReq>");
		return sb.ToString();
	}

	}


	/**
	 * Billing Agreement token (required if Express Checkout)
	 */
	public partial class CreateRecurringPaymentsProfileRequestDetailsType {

		/**
		 * Billing Agreement token (required if Express Checkout)
		 */
		private string TokenField;
		public string Token {
			get {
				return this.TokenField;
			}
			set {
				this.TokenField = value;
			}
		}

		/**
		 * Information about the credit card to be charged (required if Direct Payment)
		 */
		private CreditCardDetailsType CreditCardField;
		public CreditCardDetailsType CreditCard {
			get {
				return this.CreditCardField;
			}
			set {
				this.CreditCardField = value;
			}
		}

		/**
		 * Customer Information for this Recurring Payments
		 */
		private RecurringPaymentsProfileDetailsType RecurringPaymentsProfileDetailsField;
		public RecurringPaymentsProfileDetailsType RecurringPaymentsProfileDetails {
			get {
				return this.RecurringPaymentsProfileDetailsField;
			}
			set {
				this.RecurringPaymentsProfileDetailsField = value;
			}
		}

		/**
		 * Schedule Information for this Recurring Payments
		 */
		private ScheduleDetailsType ScheduleDetailsField;
		public ScheduleDetailsType ScheduleDetails {
			get {
				return this.ScheduleDetailsField;
			}
			set {
				this.ScheduleDetailsField = value;
			}
		}

		/**
		 * Information about the Item Details.
		 */
		private List<PaymentDetailsItemType> PaymentDetailsItemField = new List<PaymentDetailsItemType>();
		public List<PaymentDetailsItemType> PaymentDetailsItem {
			get {
				return this.PaymentDetailsItemField;
			}
			set {
				this.PaymentDetailsItemField = value;
			}
		}

		public CreateRecurringPaymentsProfileRequestDetailsType(RecurringPaymentsProfileDetailsType RecurringPaymentsProfileDetails, ScheduleDetailsType ScheduleDetails) {
			this.RecurringPaymentsProfileDetails = RecurringPaymentsProfileDetails;
			this.ScheduleDetails = ScheduleDetails;
		}
		public CreateRecurringPaymentsProfileRequestDetailsType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( Token != null ) {
			sb.Append("<ebl:Token>").Append(Token);
			sb.Append("</ebl:Token>");
		}
		if( CreditCard != null ) {
			sb.Append("<ebl:CreditCard>");
			sb.Append(CreditCard.toXMLString());
			sb.Append("</ebl:CreditCard>");
		}
		if( RecurringPaymentsProfileDetails != null ) {
			sb.Append("<ebl:RecurringPaymentsProfileDetails>");
			sb.Append(RecurringPaymentsProfileDetails.toXMLString());
			sb.Append("</ebl:RecurringPaymentsProfileDetails>");
		}
		if( ScheduleDetails != null ) {
			sb.Append("<ebl:ScheduleDetails>");
			sb.Append(ScheduleDetails.toXMLString());
			sb.Append("</ebl:ScheduleDetails>");
		}
		if( PaymentDetailsItem != null ) {
			for(int i=0; i<PaymentDetailsItem.Count; i++) {
				sb.Append("<ebl:PaymentDetailsItem>");
				sb.Append(PaymentDetailsItem[i].toXMLString());
				sb.Append("</ebl:PaymentDetailsItem>");
			}
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class CreateRecurringPaymentsProfileRequestType :AbstractRequestType{

		private CreateRecurringPaymentsProfileRequestDetailsType CreateRecurringPaymentsProfileRequestDetailsField;
		public CreateRecurringPaymentsProfileRequestDetailsType CreateRecurringPaymentsProfileRequestDetails {
			get {
				return this.CreateRecurringPaymentsProfileRequestDetailsField;
			}
			set {
				this.CreateRecurringPaymentsProfileRequestDetailsField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( CreateRecurringPaymentsProfileRequestDetails != null ) {
			sb.Append("<ebl:CreateRecurringPaymentsProfileRequestDetails>");
			sb.Append(CreateRecurringPaymentsProfileRequestDetails.toXMLString());
			sb.Append("</ebl:CreateRecurringPaymentsProfileRequestDetails>");
		}
		return sb.ToString();
	}

	}


	/**
	 * Recurring Billing Profile ID
	 */
	public partial class CreateRecurringPaymentsProfileResponseDetailsType {

		/**
		 * Recurring Billing Profile ID
		 */
		private string ProfileIDField;
		public string ProfileID {
			get {
				return this.ProfileIDField;
			}
			set {
				this.ProfileIDField = value;
			}
		}

		/**
		 * Recurring Billing Profile Status
		 */
		private RecurringPaymentsProfileStatusType? ProfileStatusField;
		public RecurringPaymentsProfileStatusType? ProfileStatus {
			get {
				return this.ProfileStatusField;
			}
			set {
				this.ProfileStatusField = value;
			}
		}

		/**
		 * Transaction id from DCC initial payment
		 */
		private string TransactionIDField;
		public string TransactionID {
			get {
				return this.TransactionIDField;
			}
			set {
				this.TransactionIDField = value;
			}
		}

		/**
		 * Response from DCC initial payment
		 */
		private string DCCProcessorResponseField;
		public string DCCProcessorResponse {
			get {
				return this.DCCProcessorResponseField;
			}
			set {
				this.DCCProcessorResponseField = value;
			}
		}

		/**
		 * Return code if DCC initial payment fails
		 */
		private string DCCReturnCodeField;
		public string DCCReturnCode {
			get {
				return this.DCCReturnCodeField;
			}
			set {
				this.DCCReturnCodeField = value;
			}
		}

	 public CreateRecurringPaymentsProfileResponseDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("ProfileID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ProfileID")[0])){ 
		 this.ProfileID =(string)document.GetElementsByTagName("ProfileID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ProfileStatus").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ProfileStatus")[0])){ 
		 this.ProfileStatus = (RecurringPaymentsProfileStatusType)EnumUtils.getValue(document.GetElementsByTagName("ProfileStatus")[0].InnerText,typeof(RecurringPaymentsProfileStatusType));

}
	}
		 if(document.GetElementsByTagName("TransactionID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TransactionID")[0])){ 
		 this.TransactionID =(string)document.GetElementsByTagName("TransactionID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("DCCProcessorResponse").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("DCCProcessorResponse")[0])){ 
		 this.DCCProcessorResponse =(string)document.GetElementsByTagName("DCCProcessorResponse")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("DCCReturnCode").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("DCCReturnCode")[0])){ 
		 this.DCCReturnCode =(string)document.GetElementsByTagName("DCCReturnCode")[0].InnerText;

}
	}
	}
	}


	/**
	 */
	public partial class CreateRecurringPaymentsProfileResponseType :AbstractResponseType{

		private CreateRecurringPaymentsProfileResponseDetailsType CreateRecurringPaymentsProfileResponseDetailsField;
		public CreateRecurringPaymentsProfileResponseDetailsType CreateRecurringPaymentsProfileResponseDetails {
			get {
				return this.CreateRecurringPaymentsProfileResponseDetailsField;
			}
			set {
				this.CreateRecurringPaymentsProfileResponseDetailsField = value;
			}
		}

	 public CreateRecurringPaymentsProfileResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("CreateRecurringPaymentsProfileResponseDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CreateRecurringPaymentsProfileResponseDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("CreateRecurringPaymentsProfileResponseDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.CreateRecurringPaymentsProfileResponseDetails =  new CreateRecurringPaymentsProfileResponseDetailsType(xmlString);

}
	}
	}
	}


	/**
	 * CreditCardDetailsType 
	 * Information about a Credit Card.
	 */
	public partial class CreditCardDetailsType {

		private CreditCardTypeType? CreditCardTypeField;
		public CreditCardTypeType? CreditCardType {
			get {
				return this.CreditCardTypeField;
			}
			set {
				this.CreditCardTypeField = value;
			}
		}

		private string CreditCardNumberField;
		public string CreditCardNumber {
			get {
				return this.CreditCardNumberField;
			}
			set {
				this.CreditCardNumberField = value;
			}
		}

		private int? ExpMonthField;
		public int? ExpMonth {
			get {
				return this.ExpMonthField;
			}
			set {
				this.ExpMonthField = value;
			}
		}

		private int? ExpYearField;
		public int? ExpYear {
			get {
				return this.ExpYearField;
			}
			set {
				this.ExpYearField = value;
			}
		}

		private PayerInfoType CardOwnerField;
		public PayerInfoType CardOwner {
			get {
				return this.CardOwnerField;
			}
			set {
				this.CardOwnerField = value;
			}
		}

		private string CVV2Field;
		public string CVV2 {
			get {
				return this.CVV2Field;
			}
			set {
				this.CVV2Field = value;
			}
		}

		private int? StartMonthField;
		public int? StartMonth {
			get {
				return this.StartMonthField;
			}
			set {
				this.StartMonthField = value;
			}
		}

		private int? StartYearField;
		public int? StartYear {
			get {
				return this.StartYearField;
			}
			set {
				this.StartYearField = value;
			}
		}

		private string IssueNumberField;
		public string IssueNumber {
			get {
				return this.IssueNumberField;
			}
			set {
				this.IssueNumberField = value;
			}
		}

		private ThreeDSecureRequestType ThreeDSecureRequestField;
		public ThreeDSecureRequestType ThreeDSecureRequest {
			get {
				return this.ThreeDSecureRequestField;
			}
			set {
				this.ThreeDSecureRequestField = value;
			}
		}

		public CreditCardDetailsType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( CreditCardType != null ) {
			sb.Append("<ebl:CreditCardType>").Append(EnumUtils.getDescription(CreditCardType));
			sb.Append("</ebl:CreditCardType>");
		}
		if( CreditCardNumber != null ) {
			sb.Append("<ebl:CreditCardNumber>").Append(CreditCardNumber);
			sb.Append("</ebl:CreditCardNumber>");
		}
		if( ExpMonth != null ) {
			sb.Append("<ebl:ExpMonth>").Append(ExpMonth);
			sb.Append("</ebl:ExpMonth>");
		}
		if( ExpYear != null ) {
			sb.Append("<ebl:ExpYear>").Append(ExpYear);
			sb.Append("</ebl:ExpYear>");
		}
		if( CardOwner != null ) {
			sb.Append("<ebl:CardOwner>");
			sb.Append(CardOwner.toXMLString());
			sb.Append("</ebl:CardOwner>");
		}
		if( CVV2 != null ) {
			sb.Append("<ebl:CVV2>").Append(CVV2);
			sb.Append("</ebl:CVV2>");
		}
		if( StartMonth != null ) {
			sb.Append("<ebl:StartMonth>").Append(StartMonth);
			sb.Append("</ebl:StartMonth>");
		}
		if( StartYear != null ) {
			sb.Append("<ebl:StartYear>").Append(StartYear);
			sb.Append("</ebl:StartYear>");
		}
		if( IssueNumber != null ) {
			sb.Append("<ebl:IssueNumber>").Append(IssueNumber);
			sb.Append("</ebl:IssueNumber>");
		}
		if( ThreeDSecureRequest != null ) {
			sb.Append("<ebl:ThreeDSecureRequest>");
			sb.Append(ThreeDSecureRequest.toXMLString());
			sb.Append("</ebl:ThreeDSecureRequest>");
		}
		return sb.ToString();
	}

	 public CreditCardDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("CreditCardType").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CreditCardType")[0])){ 
		 this.CreditCardType = (CreditCardTypeType)EnumUtils.getValue(document.GetElementsByTagName("CreditCardType")[0].InnerText,typeof(CreditCardTypeType));

}
	}
		 if(document.GetElementsByTagName("CreditCardNumber").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CreditCardNumber")[0])){ 
		 this.CreditCardNumber =(string)document.GetElementsByTagName("CreditCardNumber")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ExpMonth").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ExpMonth")[0])){ 
		 this.ExpMonth =System.Convert.ToInt32(document.GetElementsByTagName("ExpMonth")[0].InnerText);

}
	}
		 if(document.GetElementsByTagName("ExpYear").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ExpYear")[0])){ 
		 this.ExpYear =System.Convert.ToInt32(document.GetElementsByTagName("ExpYear")[0].InnerText);

}
	}
		 if(document.GetElementsByTagName("CardOwner").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CardOwner")[0])){ 
		 nodeList = document.GetElementsByTagName("CardOwner");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.CardOwner =  new PayerInfoType(xmlString);

}
	}
		 if(document.GetElementsByTagName("CVV2").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CVV2")[0])){ 
		 this.CVV2 =(string)document.GetElementsByTagName("CVV2")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("StartMonth").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("StartMonth")[0])){ 
		 this.StartMonth =System.Convert.ToInt32(document.GetElementsByTagName("StartMonth")[0].InnerText);

}
	}
		 if(document.GetElementsByTagName("StartYear").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("StartYear")[0])){ 
		 this.StartYear =System.Convert.ToInt32(document.GetElementsByTagName("StartYear")[0].InnerText);

}
	}
		 if(document.GetElementsByTagName("IssueNumber").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("IssueNumber")[0])){ 
		 this.IssueNumber =(string)document.GetElementsByTagName("IssueNumber")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ThreeDSecureRequest").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ThreeDSecureRequest")[0])){ 
		 nodeList = document.GetElementsByTagName("ThreeDSecureRequest");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.ThreeDSecureRequest =  new ThreeDSecureRequestType(xmlString);

}
	}
	}
	}


	/**
	 */
	public partial class CreditCardNumberTypeType {

		private CreditCardTypeType? CreditCardTypeField;
		public CreditCardTypeType? CreditCardType {
			get {
				return this.CreditCardTypeField;
			}
			set {
				this.CreditCardTypeField = value;
			}
		}

		private string CreditCardNumberField;
		public string CreditCardNumber {
			get {
				return this.CreditCardNumberField;
			}
			set {
				this.CreditCardNumberField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( CreditCardType != null ) {
			sb.Append("<ebl:CreditCardType>").Append(EnumUtils.getDescription(CreditCardType));
			sb.Append("</ebl:CreditCardType>");
		}
		if( CreditCardNumber != null ) {
			sb.Append("<ebl:CreditCardNumber>").Append(CreditCardNumber);
			sb.Append("</ebl:CreditCardNumber>");
		}
		return sb.ToString();
	}

	}


	public enum CreditCardTypeType {
[Description("Visa")]VISA,
[Description("MasterCard")]MASTERCARD,
[Description("Discover")]DISCOVER,
[Description("Amex")]AMEX,
[Description("Switch")]SWITCH,
[Description("Solo")]SOLO,
[Description("Maestro")]MAESTRO,
	}
	public enum CurrencyCodeType {
[Description("AFA")]AFA,
[Description("ALL")]ALL,
[Description("DZD")]DZD,
[Description("ADP")]ADP,
[Description("AOA")]AOA,
[Description("ARS")]ARS,
[Description("AMD")]AMD,
[Description("AWG")]AWG,
[Description("AZM")]AZM,
[Description("BSD")]BSD,
[Description("BHD")]BHD,
[Description("BDT")]BDT,
[Description("BBD")]BBD,
[Description("BYR")]BYR,
[Description("BZD")]BZD,
[Description("BMD")]BMD,
[Description("BTN")]BTN,
[Description("INR")]INR,
[Description("BOV")]BOV,
[Description("BOB")]BOB,
[Description("BAM")]BAM,
[Description("BWP")]BWP,
[Description("BRL")]BRL,
[Description("BND")]BND,
[Description("BGL")]BGL,
[Description("BGN")]BGN,
[Description("BIF")]BIF,
[Description("KHR")]KHR,
[Description("CAD")]CAD,
[Description("CVE")]CVE,
[Description("KYD")]KYD,
[Description("XAF")]XAF,
[Description("CLF")]CLF,
[Description("CLP")]CLP,
[Description("CNY")]CNY,
[Description("COP")]COP,
[Description("KMF")]KMF,
[Description("CDF")]CDF,
[Description("CRC")]CRC,
[Description("HRK")]HRK,
[Description("CUP")]CUP,
[Description("CYP")]CYP,
[Description("CZK")]CZK,
[Description("DKK")]DKK,
[Description("DJF")]DJF,
[Description("DOP")]DOP,
[Description("TPE")]TPE,
[Description("ECV")]ECV,
[Description("ECS")]ECS,
[Description("EGP")]EGP,
[Description("SVC")]SVC,
[Description("ERN")]ERN,
[Description("EEK")]EEK,
[Description("ETB")]ETB,
[Description("FKP")]FKP,
[Description("FJD")]FJD,
[Description("GMD")]GMD,
[Description("GEL")]GEL,
[Description("GHC")]GHC,
[Description("GIP")]GIP,
[Description("GTQ")]GTQ,
[Description("GNF")]GNF,
[Description("GWP")]GWP,
[Description("GYD")]GYD,
[Description("HTG")]HTG,
[Description("HNL")]HNL,
[Description("HKD")]HKD,
[Description("HUF")]HUF,
[Description("ISK")]ISK,
[Description("IDR")]IDR,
[Description("IRR")]IRR,
[Description("IQD")]IQD,
[Description("ILS")]ILS,
[Description("JMD")]JMD,
[Description("JPY")]JPY,
[Description("JOD")]JOD,
[Description("KZT")]KZT,
[Description("KES")]KES,
[Description("AUD")]AUD,
[Description("KPW")]KPW,
[Description("KRW")]KRW,
[Description("KWD")]KWD,
[Description("KGS")]KGS,
[Description("LAK")]LAK,
[Description("LVL")]LVL,
[Description("LBP")]LBP,
[Description("LSL")]LSL,
[Description("LRD")]LRD,
[Description("LYD")]LYD,
[Description("CHF")]CHF,
[Description("LTL")]LTL,
[Description("MOP")]MOP,
[Description("MKD")]MKD,
[Description("MGF")]MGF,
[Description("MWK")]MWK,
[Description("MYR")]MYR,
[Description("MVR")]MVR,
[Description("MTL")]MTL,
[Description("EUR")]EUR,
[Description("MRO")]MRO,
[Description("MUR")]MUR,
[Description("MXN")]MXN,
[Description("MXV")]MXV,
[Description("MDL")]MDL,
[Description("MNT")]MNT,
[Description("XCD")]XCD,
[Description("MZM")]MZM,
[Description("MMK")]MMK,
[Description("ZAR")]ZAR,
[Description("NAD")]NAD,
[Description("NPR")]NPR,
[Description("ANG")]ANG,
[Description("XPF")]XPF,
[Description("NZD")]NZD,
[Description("NIO")]NIO,
[Description("NGN")]NGN,
[Description("NOK")]NOK,
[Description("OMR")]OMR,
[Description("PKR")]PKR,
[Description("PAB")]PAB,
[Description("PGK")]PGK,
[Description("PYG")]PYG,
[Description("PEN")]PEN,
[Description("PHP")]PHP,
[Description("PLN")]PLN,
[Description("USD")]USD,
[Description("QAR")]QAR,
[Description("ROL")]ROL,
[Description("RUB")]RUB,
[Description("RUR")]RUR,
[Description("RWF")]RWF,
[Description("SHP")]SHP,
[Description("WST")]WST,
[Description("STD")]STD,
[Description("SAR")]SAR,
[Description("SCR")]SCR,
[Description("SLL")]SLL,
[Description("SGD")]SGD,
[Description("SKK")]SKK,
[Description("SIT")]SIT,
[Description("SBD")]SBD,
[Description("SOS")]SOS,
[Description("LKR")]LKR,
[Description("SDD")]SDD,
[Description("SRG")]SRG,
[Description("SZL")]SZL,
[Description("SEK")]SEK,
[Description("SYP")]SYP,
[Description("TWD")]TWD,
[Description("TJS")]TJS,
[Description("TZS")]TZS,
[Description("THB")]THB,
[Description("XOF")]XOF,
[Description("TOP")]TOP,
[Description("TTD")]TTD,
[Description("TND")]TND,
[Description("TRY")]TRY,
[Description("TMM")]TMM,
[Description("UGX")]UGX,
[Description("UAH")]UAH,
[Description("AED")]AED,
[Description("GBP")]GBP,
[Description("USS")]USS,
[Description("USN")]USN,
[Description("UYU")]UYU,
[Description("UZS")]UZS,
[Description("VUV")]VUV,
[Description("VEB")]VEB,
[Description("VND")]VND,
[Description("MAD")]MAD,
[Description("YER")]YER,
[Description("YUM")]YUM,
[Description("ZMK")]ZMK,
[Description("ZWD")]ZWD,
[Description("CustomCode")]CUSTOMCODE,
	}
	public enum DetailLevelCodeType {
[Description("ReturnAll")]RETURNALL,
[Description("ItemReturnDescription")]ITEMRETURNDESCRIPTION,
[Description("ItemReturnAttributes")]ITEMRETURNATTRIBUTES,
	}
	/**
	 * Device ID Optional
	 * Character length and limits: 256 single-byte characters 
	 * DeviceID length morethan 256 is truncated
	 */
	public partial class DeviceDetailsType {

		/**
Device ID Optional
		 * Character length and limits: 256 single-byte characters 
		 * DeviceID length morethan 256 is truncated
		 */
		private string DeviceIDField;
		public string DeviceID {
			get {
				return this.DeviceIDField;
			}
			set {
				this.DeviceIDField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( DeviceID != null ) {
			sb.Append("<ebl:DeviceID>").Append(DeviceID);
			sb.Append("</ebl:DeviceID>");
		}
		return sb.ToString();
	}

	}


	/**
	 * Describes discount information
	 */
	public partial class DiscountType {

		/**
Item nameOptional
		 * Character length and limits: 127 single-byte characters
		 */
		private string NameField;
		public string Name {
			get {
				return this.NameField;
			}
			set {
				this.NameField = value;
			}
		}

		/**
description of the discountOptional
		 * Character length and limits: 127 single-byte characters
		 */
		private string DescriptionField;
		public string Description {
			get {
				return this.DescriptionField;
			}
			set {
				this.DescriptionField = value;
			}
		}

		/**
amount discountedOptional
		 */
		private BasicAmountType AmountField;
		public BasicAmountType Amount {
			get {
				return this.AmountField;
			}
			set {
				this.AmountField = value;
			}
		}

		/**
offer typeOptional
		 */
		private RedeemedOfferType? RedeemedOfferTypeField;
		public RedeemedOfferType? RedeemedOfferType {
			get {
				return this.RedeemedOfferTypeField;
			}
			set {
				this.RedeemedOfferTypeField = value;
			}
		}

		/**
offer IDOptional
		 * Character length and limits: 64 single-byte characters
		 */
		private string RedeemedOfferIDField;
		public string RedeemedOfferID {
			get {
				return this.RedeemedOfferIDField;
			}
			set {
				this.RedeemedOfferIDField = value;
			}
		}

		public DiscountType(BasicAmountType Amount) {
			this.Amount = Amount;
		}
		public DiscountType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( Name != null ) {
			sb.Append("<ebl:Name>").Append(Name);
			sb.Append("</ebl:Name>");
		}
		if( Description != null ) {
			sb.Append("<ebl:Description>").Append(Description);
			sb.Append("</ebl:Description>");
		}
		if( Amount != null ) {
			sb.Append("<ebl:Amount ");
			sb.Append(Amount.toXMLString());
			sb.Append("</ebl:Amount>");
		}
		if( RedeemedOfferType != null ) {
			sb.Append("<ebl:RedeemedOfferType>").Append(EnumUtils.getDescription(RedeemedOfferType));
			sb.Append("</ebl:RedeemedOfferType>");
		}
		if( RedeemedOfferID != null ) {
			sb.Append("<ebl:RedeemedOfferID>").Append(RedeemedOfferID);
			sb.Append("</ebl:RedeemedOfferID>");
		}
		return sb.ToString();
	}

	}


	/**
	 * Contains elements that allows customization of display (user interface) elements.
	 */
	public partial class DisplayControlDetailsType {

		/**
		 * Optional URL to pay button image for the inline checkout flow.  Currently applicable
		 * only to the inline checkout flow when the FlowControlDetails/InlineReturnURL is present.
		 */
		private string InContextPaymentButtonImageField;
		public string InContextPaymentButtonImage {
			get {
				return this.InContextPaymentButtonImageField;
			}
			set {
				this.InContextPaymentButtonImageField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( InContextPaymentButtonImage != null ) {
			sb.Append("<ebl:InContextPaymentButtonImage>").Append(InContextPaymentButtonImage);
			sb.Append("</ebl:InContextPaymentButtonImage>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class DoAuthorizationReq {

		private DoAuthorizationRequestType DoAuthorizationRequestField;
		public DoAuthorizationRequestType DoAuthorizationRequest {
			get {
				return this.DoAuthorizationRequestField;
			}
			set {
				this.DoAuthorizationRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:DoAuthorizationReq>");
		if( DoAuthorizationRequest != null ) {
			sb.Append("<urn:DoAuthorizationRequest>");
			sb.Append(DoAuthorizationRequest.toXMLString());
			sb.Append("</urn:DoAuthorizationRequest>");
		}
sb.Append("</urn:DoAuthorizationReq>");
		return sb.ToString();
	}

	}


	/**
	 * The value of the order’s transaction identification number returned by a PayPal product. 
	 * Required
	 * Character length and limits: 19 single-byte characters maximum
	 */
	public partial class DoAuthorizationRequestType :AbstractRequestType{

		/**
The value of the order’s transaction identification number returned by a PayPal product. 
		 * Required
		 * Character length and limits: 19 single-byte characters maximum
		 */
		private string TransactionIDField;
		public string TransactionID {
			get {
				return this.TransactionIDField;
			}
			set {
				this.TransactionIDField = value;
			}
		}

		/**
Type of transaction to authorize. The only allowable value is Order, which means that the transaction represents a customer order that can be fulfilled over 29 days. 
		 * Optional
		 */
		private TransactionEntityType? TransactionEntityField;
		public TransactionEntityType? TransactionEntity {
			get {
				return this.TransactionEntityField;
			}
			set {
				this.TransactionEntityField = value;
			}
		}

		/**
Amount to authorize. 
		 * Required
		 * Limitations: Must not exceed $10,000 USD in any currency. No currency symbol. Decimal separator must be a period (.), and the thousands separator must be a comma (,).
		 */
		private BasicAmountType AmountField;
		public BasicAmountType Amount {
			get {
				return this.AmountField;
			}
			set {
				this.AmountField = value;
			}
		}

		public DoAuthorizationRequestType(string TransactionID, BasicAmountType Amount) {
			this.TransactionID = TransactionID;
			this.Amount = Amount;
		}
		public DoAuthorizationRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( TransactionID != null ) {
			sb.Append("<urn:TransactionID>").Append(TransactionID);
			sb.Append("</urn:TransactionID>");
		}
		if( TransactionEntity != null ) {
			sb.Append("<urn:TransactionEntity>").Append(EnumUtils.getDescription(TransactionEntity));
			sb.Append("</urn:TransactionEntity>");
		}
		if( Amount != null ) {
			sb.Append("<urn:Amount ");
			sb.Append(Amount.toXMLString());
			sb.Append("</urn:Amount>");
		}
		return sb.ToString();
	}

	}


	/**
	 * An authorization identification number. 
	 * Character length and limits: 19 single-byte characters
	 */
	public partial class DoAuthorizationResponseType :AbstractResponseType{

		/**
An authorization identification number. 
		 * Character length and limits: 19 single-byte characters
		 */
		private string TransactionIDField;
		public string TransactionID {
			get {
				return this.TransactionIDField;
			}
			set {
				this.TransactionIDField = value;
			}
		}

		/**
The amount and currency you specified in the request. 
		 */
		private BasicAmountType AmountField;
		public BasicAmountType Amount {
			get {
				return this.AmountField;
			}
			set {
				this.AmountField = value;
			}
		}

		private AuthorizationInfoType AuthorizationInfoField;
		public AuthorizationInfoType AuthorizationInfo {
			get {
				return this.AuthorizationInfoField;
			}
			set {
				this.AuthorizationInfoField = value;
			}
		}

	 public DoAuthorizationResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("TransactionID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TransactionID")[0])){ 
		 this.TransactionID =(string)document.GetElementsByTagName("TransactionID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Amount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Amount")[0])){ 
		 nodeList = document.GetElementsByTagName("Amount");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.Amount =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("AuthorizationInfo").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AuthorizationInfo")[0])){ 
		 nodeList = document.GetElementsByTagName("AuthorizationInfo");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.AuthorizationInfo =  new AuthorizationInfoType(xmlString);

}
	}
	}
	}


	/**
	 */
	public partial class DoCancelReq {

		private DoCancelRequestType DoCancelRequestField;
		public DoCancelRequestType DoCancelRequest {
			get {
				return this.DoCancelRequestField;
			}
			set {
				this.DoCancelRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:DoCancelReq>");
		if( DoCancelRequest != null ) {
			sb.Append("<urn:DoCancelRequest>");
			sb.Append(DoCancelRequest.toXMLString());
			sb.Append("</urn:DoCancelRequest>");
		}
sb.Append("</urn:DoCancelReq>");
		return sb.ToString();
	}

	}


	/**
	 * Msg Sub Id that was used for the orginal operation. 
	 */
	public partial class DoCancelRequestType :AbstractRequestType{

		/**
Msg Sub Id that was used for the orginal operation. 		 */
		private string CancelMsgSubIDField;
		public string CancelMsgSubID {
			get {
				return this.CancelMsgSubIDField;
			}
			set {
				this.CancelMsgSubIDField = value;
			}
		}

		/**
Original API's type		 */
		private APIType? APITypeField;
		public APIType? APIType {
			get {
				return this.APITypeField;
			}
			set {
				this.APITypeField = value;
			}
		}

		public DoCancelRequestType(string CancelMsgSubID, APIType? APIType) {
			this.CancelMsgSubID = CancelMsgSubID;
			this.APIType = APIType;
		}
		public DoCancelRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( CancelMsgSubID != null ) {
			sb.Append("<urn:CancelMsgSubID>").Append(CancelMsgSubID);
			sb.Append("</urn:CancelMsgSubID>");
		}
		if( APIType != null ) {
			sb.Append("<urn:APIType>").Append(EnumUtils.getDescription(APIType));
			sb.Append("</urn:APIType>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class DoCancelResponseType :AbstractResponseType{

	 public DoCancelResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
	}
	}


	/**
	 */
	public partial class DoCaptureReq {

		private DoCaptureRequestType DoCaptureRequestField;
		public DoCaptureRequestType DoCaptureRequest {
			get {
				return this.DoCaptureRequestField;
			}
			set {
				this.DoCaptureRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:DoCaptureReq>");
		if( DoCaptureRequest != null ) {
			sb.Append("<urn:DoCaptureRequest>");
			sb.Append(DoCaptureRequest.toXMLString());
			sb.Append("</urn:DoCaptureRequest>");
		}
sb.Append("</urn:DoCaptureReq>");
		return sb.ToString();
	}

	}


	/**
	 * The authorization identification number of the payment you want to capture. 
	 * Required
	 * Character length and limits: 19 single-byte characters maximum
	 */
	public partial class DoCaptureRequestType :AbstractRequestType{

		/**
The authorization identification number of the payment you want to capture. 
		 * Required
		 * Character length and limits: 19 single-byte characters maximum
		 */
		private string AuthorizationIDField;
		public string AuthorizationID {
			get {
				return this.AuthorizationIDField;
			}
			set {
				this.AuthorizationIDField = value;
			}
		}

		/**
Amount to authorize. You must set the currencyID attribute to USD. 
		 * Required
		 * Limitations: Must not exceed $10,000 USD in any currency. No currency symbol. Decimal separator must be a period (.), and the thousands separator must be a comma (,)
		 */
		private BasicAmountType AmountField;
		public BasicAmountType Amount {
			get {
				return this.AmountField;
			}
			set {
				this.AmountField = value;
			}
		}

		/**
Indicates if this capture is the last capture you intend to make. The default is Complete. If CompleteType is Complete, any remaining amount of the original reauthorized transaction is automatically voided. 
		 * Required
		 * Character length and limits: 12 single-byte alphanumeric characters
		 */
		private CompleteCodeType? CompleteTypeField;
		public CompleteCodeType? CompleteType {
			get {
				return this.CompleteTypeField;
			}
			set {
				this.CompleteTypeField = value;
			}
		}

		/**
An informational note about this settlement that is displayed to the payer in email and in  transaction history. 
		 * Optional
		 * Character length and limits: 255 single-byte characters
		 */
		private string NoteField;
		public string Note {
			get {
				return this.NoteField;
			}
			set {
				this.NoteField = value;
			}
		}

		/**
Your invoice number or other identification number. 
		 * The InvoiceID value is recorded only if the authorization you are capturing is an order authorization, not a basic authorization.
		 * Optional
		 * Character length and limits: 127 single-byte alphanumeric characters
		 */
		private string InvoiceIDField;
		public string InvoiceID {
			get {
				return this.InvoiceIDField;
			}
			set {
				this.InvoiceIDField = value;
			}
		}

		/**
Contains enhanced data like airline itinerary information.
		 * Not Required
		 */
		private EnhancedDataType EnhancedDataField;
		public EnhancedDataType EnhancedData {
			get {
				return this.EnhancedDataField;
			}
			set {
				this.EnhancedDataField = value;
			}
		}

		/**
dynamic descriptor
		 * Dynamic descriptor is used for merchant to provide detail of a transaction appears on statement
		 * Optional
		 * Character length and limits: <18 characters alphanumeric characters
		 */
		private string DescriptorField;
		public string Descriptor {
			get {
				return this.DescriptorField;
			}
			set {
				this.DescriptorField = value;
			}
		}

		/**
To pass the Merchant store informationOptional
		 */
		private MerchantStoreDetailsType MerchantStoreDetailsField;
		public MerchantStoreDetailsType MerchantStoreDetails {
			get {
				return this.MerchantStoreDetailsField;
			}
			set {
				this.MerchantStoreDetailsField = value;
			}
		}

		public DoCaptureRequestType(string AuthorizationID, BasicAmountType Amount, CompleteCodeType? CompleteType) {
			this.AuthorizationID = AuthorizationID;
			this.Amount = Amount;
			this.CompleteType = CompleteType;
		}
		public DoCaptureRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( AuthorizationID != null ) {
			sb.Append("<urn:AuthorizationID>").Append(AuthorizationID);
			sb.Append("</urn:AuthorizationID>");
		}
		if( Amount != null ) {
			sb.Append("<urn:Amount ");
			sb.Append(Amount.toXMLString());
			sb.Append("</urn:Amount>");
		}
		if( CompleteType != null ) {
			sb.Append("<urn:CompleteType>").Append(EnumUtils.getDescription(CompleteType));
			sb.Append("</urn:CompleteType>");
		}
		if( Note != null ) {
			sb.Append("<urn:Note>").Append(Note);
			sb.Append("</urn:Note>");
		}
		if( InvoiceID != null ) {
			sb.Append("<urn:InvoiceID>").Append(InvoiceID);
			sb.Append("</urn:InvoiceID>");
		}
		if( EnhancedData != null ) {
			sb.Append("<ebl:EnhancedData>");
			sb.Append(EnhancedData.toXMLString());
			sb.Append("</ebl:EnhancedData>");
		}
		if( Descriptor != null ) {
			sb.Append("<urn:Descriptor>").Append(Descriptor);
			sb.Append("</urn:Descriptor>");
		}
		if( MerchantStoreDetails != null ) {
			sb.Append("<ebl:MerchantStoreDetails>");
			sb.Append(MerchantStoreDetails.toXMLString());
			sb.Append("</ebl:MerchantStoreDetails>");
		}
		return sb.ToString();
	}

	}


	/**
	 * The authorization identification number you specified in the request. 
Character length and limits: 19 single-byte characters maximum
	 */
	public partial class DoCaptureResponseDetailsType {

		/**
The authorization identification number you specified in the request. 
Character length and limits: 19 single-byte characters maximum
		 */
		private string AuthorizationIDField;
		public string AuthorizationID {
			get {
				return this.AuthorizationIDField;
			}
			set {
				this.AuthorizationIDField = value;
			}
		}

		/**
Information about the transaction 		 */
		private PaymentInfoType PaymentInfoField;
		public PaymentInfoType PaymentInfo {
			get {
				return this.PaymentInfoField;
			}
			set {
				this.PaymentInfoField = value;
			}
		}

	 public DoCaptureResponseDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("AuthorizationID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AuthorizationID")[0])){ 
		 this.AuthorizationID =(string)document.GetElementsByTagName("AuthorizationID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("PaymentInfo").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentInfo")[0])){ 
		 nodeList = document.GetElementsByTagName("PaymentInfo");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.PaymentInfo =  new PaymentInfoType(xmlString);

}
	}
	}
	}


	/**
	 */
	public partial class DoCaptureResponseType :AbstractResponseType{

		private DoCaptureResponseDetailsType DoCaptureResponseDetailsField;
		public DoCaptureResponseDetailsType DoCaptureResponseDetails {
			get {
				return this.DoCaptureResponseDetailsField;
			}
			set {
				this.DoCaptureResponseDetailsField = value;
			}
		}

	 public DoCaptureResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("DoCaptureResponseDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("DoCaptureResponseDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("DoCaptureResponseDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.DoCaptureResponseDetails =  new DoCaptureResponseDetailsType(xmlString);

}
	}
	}
	}


	/**
	 */
	public partial class DoDirectPaymentReq {

		private DoDirectPaymentRequestType DoDirectPaymentRequestField;
		public DoDirectPaymentRequestType DoDirectPaymentRequest {
			get {
				return this.DoDirectPaymentRequestField;
			}
			set {
				this.DoDirectPaymentRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:DoDirectPaymentReq>");
		if( DoDirectPaymentRequest != null ) {
			sb.Append("<urn:DoDirectPaymentRequest>");
			sb.Append(DoDirectPaymentRequest.toXMLString());
			sb.Append("</urn:DoDirectPaymentRequest>");
		}
sb.Append("</urn:DoDirectPaymentReq>");
		return sb.ToString();
	}

	}


	/**
	 * How you want to obtain payment. 
	 * Required
	 * Authorization indicates that this payment is a basic authorization subject to settlement with PayPal Authorization and Capture.
	 * Sale indicates that this is a final sale for which you are requesting payment.
	 * NOTE: Order is not allowed for Direct Payment.
	 * Character length and limit: Up to 13 single-byte alphabetic characters
	 */
	public partial class DoDirectPaymentRequestDetailsType {

		/**
		 * How you want to obtain payment. 
		 * Required
		 * Authorization indicates that this payment is a basic authorization subject to settlement with PayPal Authorization and Capture.
		 * Sale indicates that this is a final sale for which you are requesting payment.
		 * NOTE: Order is not allowed for Direct Payment.
		 * Character length and limit: Up to 13 single-byte alphabetic characters		 */
		private PaymentActionCodeType? PaymentActionField;
		public PaymentActionCodeType? PaymentAction {
			get {
				return this.PaymentActionField;
			}
			set {
				this.PaymentActionField = value;
			}
		}

		/**
		 * Information about the payment 
		 * Required
		 */
		private PaymentDetailsType PaymentDetailsField;
		public PaymentDetailsType PaymentDetails {
			get {
				return this.PaymentDetailsField;
			}
			set {
				this.PaymentDetailsField = value;
			}
		}

		/**
		 * Information about the credit card to be charged. 
		 * Required
		 */
		private CreditCardDetailsType CreditCardField;
		public CreditCardDetailsType CreditCard {
			get {
				return this.CreditCardField;
			}
			set {
				this.CreditCardField = value;
			}
		}

		/**
		 * IP address of the payer's browser as recorded in its HTTP request to your website. PayPal records this IP addresses as a means to detect possible fraud. 
		 * Required
		 * Character length and limitations: 15 single-byte characters, including periods, in dotted-quad format: ???.???.???.???
		 */
		private string IPAddressField;
		public string IPAddress {
			get {
				return this.IPAddressField;
			}
			set {
				this.IPAddressField = value;
			}
		}

		/**
		 * Your customer session identification token. PayPal records this optional session identification token as an additional means to detect possible fraud. 
		 * Optional
		 * Character length and limitations: 64 single-byte numeric characters		 */
		private string MerchantSessionIdField;
		public string MerchantSessionId {
			get {
				return this.MerchantSessionIdField;
			}
			set {
				this.MerchantSessionIdField = value;
			}
		}

		/**
		 */
		private bool? ReturnFMFDetailsField;
		public bool? ReturnFMFDetails {
			get {
				return this.ReturnFMFDetailsField;
			}
			set {
				this.ReturnFMFDetailsField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( PaymentAction != null ) {
			sb.Append("<ebl:PaymentAction>").Append(EnumUtils.getDescription(PaymentAction));
			sb.Append("</ebl:PaymentAction>");
		}
		if( PaymentDetails != null ) {
			sb.Append("<ebl:PaymentDetails>");
			sb.Append(PaymentDetails.toXMLString());
			sb.Append("</ebl:PaymentDetails>");
		}
		if( CreditCard != null ) {
			sb.Append("<ebl:CreditCard>");
			sb.Append(CreditCard.toXMLString());
			sb.Append("</ebl:CreditCard>");
		}
		if( IPAddress != null ) {
			sb.Append("<ebl:IPAddress>").Append(IPAddress);
			sb.Append("</ebl:IPAddress>");
		}
		if( MerchantSessionId != null ) {
			sb.Append("<ebl:MerchantSessionId>").Append(MerchantSessionId);
			sb.Append("</ebl:MerchantSessionId>");
		}
		if( ReturnFMFDetails != null ) {
			sb.Append("<ebl:ReturnFMFDetails>").Append(ReturnFMFDetails);
			sb.Append("</ebl:ReturnFMFDetails>");
		}
		return sb.ToString();
	}

	}


	/**
	 * This flag indicates that the response should include FMFDetails
	 */
	public partial class DoDirectPaymentRequestType :AbstractRequestType{

		private DoDirectPaymentRequestDetailsType DoDirectPaymentRequestDetailsField;
		public DoDirectPaymentRequestDetailsType DoDirectPaymentRequestDetails {
			get {
				return this.DoDirectPaymentRequestDetailsField;
			}
			set {
				this.DoDirectPaymentRequestDetailsField = value;
			}
		}

		/**
This flag indicates that the response should include FMFDetails		 */
		private int? ReturnFMFDetailsField;
		public int? ReturnFMFDetails {
			get {
				return this.ReturnFMFDetailsField;
			}
			set {
				this.ReturnFMFDetailsField = value;
			}
		}

		public DoDirectPaymentRequestType(DoDirectPaymentRequestDetailsType DoDirectPaymentRequestDetails) {
			this.DoDirectPaymentRequestDetails = DoDirectPaymentRequestDetails;
		}
		public DoDirectPaymentRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( DoDirectPaymentRequestDetails != null ) {
			sb.Append("<ebl:DoDirectPaymentRequestDetails>");
			sb.Append(DoDirectPaymentRequestDetails.toXMLString());
			sb.Append("</ebl:DoDirectPaymentRequestDetails>");
		}
		if( ReturnFMFDetails != null ) {
			sb.Append("<urn:ReturnFMFDetails>").Append(ReturnFMFDetails);
			sb.Append("</urn:ReturnFMFDetails>");
		}
		return sb.ToString();
	}

	}


	/**
	 * The amount of the payment as specified by you on DoDirectPaymentRequest.	 */
	public partial class DoDirectPaymentResponseType :AbstractResponseType{

		/**
		 * The amount of the payment as specified by you on DoDirectPaymentRequest.		 */
		private BasicAmountType AmountField;
		public BasicAmountType Amount {
			get {
				return this.AmountField;
			}
			set {
				this.AmountField = value;
			}
		}

		/**
		 * Address Verification System response code. Character limit: One single-byte alphanumeric character
		 * AVS CodeMeaningMatched Details 
A AddressAddress only (no ZIP)  
B International “A”Address only (no ZIP)  
CInternational “N” None  
DInternational “X” Address and Postal Code  
E Not allowed for MOTO (Internet/Phone) transactions Not applicable 
F UK-specific “X”Address and Postal Code  
G Global Unavailable Not applicable 
I International UnavailableNot applicable  
N NoNone  
PPostal (International “Z”)Postal Code only (no Address)   
RRetryNot applicable   
S Service not Supported Not applicable 
U UnavailableNot applicable  
W Whole ZIPNine-digit ZIP code (no Address)  
X Exact match Address and nine-digit ZIP code 
Y YesAddress and five-digit ZIP  
Z ZIP Five-digit ZIP code (no Address) 
All others Error Not applicable
		 */
		private string AVSCodeField;
		public string AVSCode {
			get {
				return this.AVSCodeField;
			}
			set {
				this.AVSCodeField = value;
			}
		}

		/**
		 * Result of the CVV2 check by PayPal.
		 * CVV2 CodeMeaningMatched Details   
M MatchCVV2  
N No match None 
P Not ProcessedNot applicable  
SService not SupportedNot applicable   
U UnavailableNot applicable  
XNo response  Not applicable 
All others ErrorNot applicable  
		 */
		private string CVV2CodeField;
		public string CVV2Code {
			get {
				return this.CVV2CodeField;
			}
			set {
				this.CVV2CodeField = value;
			}
		}

		/**
		 * Transaction identification number.
		 * Character length and limitations: 19 characters maximum.		 */
		private string TransactionIDField;
		public string TransactionID {
			get {
				return this.TransactionIDField;
			}
			set {
				this.TransactionIDField = value;
			}
		}

		/**
		 * The reason why a particular transaction went in pending.
		 */
		private PendingStatusCodeType? PendingReasonField;
		public PendingStatusCodeType? PendingReason {
			get {
				return this.PendingReasonField;
			}
			set {
				this.PendingReasonField = value;
			}
		}

		/**
		 * This will identify the actual transaction status.
		 */
		private PaymentStatusCodeType? PaymentStatusField;
		public PaymentStatusCodeType? PaymentStatus {
			get {
				return this.PaymentStatusField;
			}
			set {
				this.PaymentStatusField = value;
			}
		}

		private FMFDetailsType FMFDetailsField;
		public FMFDetailsType FMFDetails {
			get {
				return this.FMFDetailsField;
			}
			set {
				this.FMFDetailsField = value;
			}
		}

		private ThreeDSecureResponseType ThreeDSecureResponseField;
		public ThreeDSecureResponseType ThreeDSecureResponse {
			get {
				return this.ThreeDSecureResponseField;
			}
			set {
				this.ThreeDSecureResponseField = value;
			}
		}

		/**
		 * Response code from the processor when a recurring transaction is declined.
		 */
		private string PaymentAdviceCodeField;
		public string PaymentAdviceCode {
			get {
				return this.PaymentAdviceCodeField;
			}
			set {
				this.PaymentAdviceCodeField = value;
			}
		}

	 public DoDirectPaymentResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Amount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Amount")[0])){ 
		 nodeList = document.GetElementsByTagName("Amount");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.Amount =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("AVSCode").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AVSCode")[0])){ 
		 this.AVSCode =(string)document.GetElementsByTagName("AVSCode")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("CVV2Code").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CVV2Code")[0])){ 
		 this.CVV2Code =(string)document.GetElementsByTagName("CVV2Code")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("TransactionID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TransactionID")[0])){ 
		 this.TransactionID =(string)document.GetElementsByTagName("TransactionID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("PendingReason").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PendingReason")[0])){ 
		 this.PendingReason = (PendingStatusCodeType)EnumUtils.getValue(document.GetElementsByTagName("PendingReason")[0].InnerText,typeof(PendingStatusCodeType));

}
	}
		 if(document.GetElementsByTagName("PaymentStatus").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentStatus")[0])){ 
		 this.PaymentStatus = (PaymentStatusCodeType)EnumUtils.getValue(document.GetElementsByTagName("PaymentStatus")[0].InnerText,typeof(PaymentStatusCodeType));

}
	}
		 if(document.GetElementsByTagName("FMFDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("FMFDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("FMFDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.FMFDetails =  new FMFDetailsType(xmlString);

}
	}
		 if(document.GetElementsByTagName("ThreeDSecureResponse").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ThreeDSecureResponse")[0])){ 
		 nodeList = document.GetElementsByTagName("ThreeDSecureResponse");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.ThreeDSecureResponse =  new ThreeDSecureResponseType(xmlString);

}
	}
		 if(document.GetElementsByTagName("PaymentAdviceCode").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentAdviceCode")[0])){ 
		 this.PaymentAdviceCode =(string)document.GetElementsByTagName("PaymentAdviceCode")[0].InnerText;

}
	}
	}
	}


	/**
	 */
	public partial class DoExpressCheckoutPaymentReq {

		private DoExpressCheckoutPaymentRequestType DoExpressCheckoutPaymentRequestField;
		public DoExpressCheckoutPaymentRequestType DoExpressCheckoutPaymentRequest {
			get {
				return this.DoExpressCheckoutPaymentRequestField;
			}
			set {
				this.DoExpressCheckoutPaymentRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:DoExpressCheckoutPaymentReq>");
		if( DoExpressCheckoutPaymentRequest != null ) {
			sb.Append("<urn:DoExpressCheckoutPaymentRequest>");
			sb.Append(DoExpressCheckoutPaymentRequest.toXMLString());
			sb.Append("</urn:DoExpressCheckoutPaymentRequest>");
		}
sb.Append("</urn:DoExpressCheckoutPaymentReq>");
		return sb.ToString();
	}

	}


	/**
	 * How you want to obtain payment. 
	 * Required
	 * Authorization indicates that this payment is a basic authorization subject to settlement with PayPal Authorization and Capture.
	 * Order indicates that this payment is is an order authorization subject to settlement with PayPal Authorization and Capture.
	 * Sale indicates that this is a final sale for which you are requesting payment.
	 * IMPORTANT: You cannot set PaymentAction to Sale on SetExpressCheckoutRequest and then change PaymentAction to Authorization on the final Express Checkout API, DoExpressCheckoutPaymentRequest.
	 * Character length and limit: Up to 13 single-byte alphabetic characters
	 */
	public partial class DoExpressCheckoutPaymentRequestDetailsType {

		/**
		 * How you want to obtain payment. 
		 * Required
		 * Authorization indicates that this payment is a basic authorization subject to settlement with PayPal Authorization and Capture.
		 * Order indicates that this payment is is an order authorization subject to settlement with PayPal Authorization and Capture.
		 * Sale indicates that this is a final sale for which you are requesting payment.
		 * IMPORTANT: You cannot set PaymentAction to Sale on SetExpressCheckoutRequest and then change PaymentAction to Authorization on the final Express Checkout API, DoExpressCheckoutPaymentRequest.
		 * Character length and limit: Up to 13 single-byte alphabetic characters
		 */
		private PaymentActionCodeType? PaymentActionField;
		public PaymentActionCodeType? PaymentAction {
			get {
				return this.PaymentActionField;
			}
			set {
				this.PaymentActionField = value;
			}
		}

		/**
		 * The timestamped token value that was returned by SetExpressCheckoutResponse and passed on GetExpressCheckoutDetailsRequest. 
		 * Required
		 * Character length and limitations: 20 single-byte characters		 */
		private string TokenField;
		public string Token {
			get {
				return this.TokenField;
			}
			set {
				this.TokenField = value;
			}
		}

		/**
		 * Encrypted PayPal customer account identification number as returned by GetExpressCheckoutDetailsResponse. 
		 * Required
		 * Character length and limitations: 127 single-byte characters.
		 */
		private string PayerIDField;
		public string PayerID {
			get {
				return this.PayerIDField;
			}
			set {
				this.PayerIDField = value;
			}
		}

		/**
		 * URL on Merchant site pertaining to this invoice. 
		 * Optional
		 */
		private string OrderURLField;
		public string OrderURL {
			get {
				return this.OrderURLField;
			}
			set {
				this.OrderURLField = value;
			}
		}

		/**
		 * Information about the payment 
		 * Required
		 */
		private List<PaymentDetailsType> PaymentDetailsField = new List<PaymentDetailsType>();
		public List<PaymentDetailsType> PaymentDetails {
			get {
				return this.PaymentDetailsField;
			}
			set {
				this.PaymentDetailsField = value;
			}
		}

		/**
		 * Flag to indicate if previously set promoCode shall be overriden. Value 1 indicates overriding.
		 */
		private string PromoOverrideFlagField;
		public string PromoOverrideFlag {
			get {
				return this.PromoOverrideFlagField;
			}
			set {
				this.PromoOverrideFlagField = value;
			}
		}

		/**
		 * Promotional financing code for item. Overrides any previous PromoCode setting.
		 */
		private string PromoCodeField;
		public string PromoCode {
			get {
				return this.PromoCodeField;
			}
			set {
				this.PromoCodeField = value;
			}
		}

		/**
		 * Contains data for enhanced data like Airline Itinerary Data.
		 */
		private EnhancedDataType EnhancedDataField;
		public EnhancedDataType EnhancedData {
			get {
				return this.EnhancedDataField;
			}
			set {
				this.EnhancedDataField = value;
			}
		}

		/**
		 * Soft Descriptor supported for Sale and Auth in DEC only. For Order this will be ignored.
		 */
		private string SoftDescriptorField;
		public string SoftDescriptor {
			get {
				return this.SoftDescriptorField;
			}
			set {
				this.SoftDescriptorField = value;
			}
		}

		/**
		 * Information about the user selected options.
		 */
		private UserSelectedOptionType UserSelectedOptionsField;
		public UserSelectedOptionType UserSelectedOptions {
			get {
				return this.UserSelectedOptionsField;
			}
			set {
				this.UserSelectedOptionsField = value;
			}
		}

		/**
		 * Information about the Gift message.
		 */
		private string GiftMessageField;
		public string GiftMessage {
			get {
				return this.GiftMessageField;
			}
			set {
				this.GiftMessageField = value;
			}
		}

		/**
		 * Information about the Gift receipt enable.
		 */
		private string GiftReceiptEnableField;
		public string GiftReceiptEnable {
			get {
				return this.GiftReceiptEnableField;
			}
			set {
				this.GiftReceiptEnableField = value;
			}
		}

		/**
		 * Information about the Gift Wrap name.
		 */
		private string GiftWrapNameField;
		public string GiftWrapName {
			get {
				return this.GiftWrapNameField;
			}
			set {
				this.GiftWrapNameField = value;
			}
		}

		/**
		 * Information about the Gift Wrap amount.
		 */
		private BasicAmountType GiftWrapAmountField;
		public BasicAmountType GiftWrapAmount {
			get {
				return this.GiftWrapAmountField;
			}
			set {
				this.GiftWrapAmountField = value;
			}
		}

		/**
		 * Information about the Buyer marketing email.
		 */
		private string BuyerMarketingEmailField;
		public string BuyerMarketingEmail {
			get {
				return this.BuyerMarketingEmailField;
			}
			set {
				this.BuyerMarketingEmailField = value;
			}
		}

		/**
		 * Information about the survey question.
		 */
		private string SurveyQuestionField;
		public string SurveyQuestion {
			get {
				return this.SurveyQuestionField;
			}
			set {
				this.SurveyQuestionField = value;
			}
		}

		/**
		 * Information about the survey choice selected by the user.
		 */
		private List<string> SurveyChoiceSelectedField = new List<string>();
		public List<string> SurveyChoiceSelected {
			get {
				return this.SurveyChoiceSelectedField;
			}
			set {
				this.SurveyChoiceSelectedField = value;
			}
		}

		/**
An identification code for use by third-party applications to identify transactions. 
		 * Optional
		 * Character length and limitations: 32 single-byte alphanumeric characters
		 */
		private string ButtonSourceField;
		public string ButtonSource {
			get {
				return this.ButtonSourceField;
			}
			set {
				this.ButtonSourceField = value;
			}
		}

		/**
		 * Merchant specified flag which indicates whether to create billing agreement as part of DoEC or not.
		 * Optional
		 */
		private bool? SkipBACreationField;
		public bool? SkipBACreation {
			get {
				return this.SkipBACreationField;
			}
			set {
				this.SkipBACreationField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( PaymentAction != null ) {
			sb.Append("<ebl:PaymentAction>").Append(EnumUtils.getDescription(PaymentAction));
			sb.Append("</ebl:PaymentAction>");
		}
		if( Token != null ) {
			sb.Append("<ebl:Token>").Append(Token);
			sb.Append("</ebl:Token>");
		}
		if( PayerID != null ) {
			sb.Append("<ebl:PayerID>").Append(PayerID);
			sb.Append("</ebl:PayerID>");
		}
		if( OrderURL != null ) {
			sb.Append("<ebl:OrderURL>").Append(OrderURL);
			sb.Append("</ebl:OrderURL>");
		}
		if( PaymentDetails != null ) {
			for(int i=0; i<PaymentDetails.Count; i++) {
				sb.Append("<ebl:PaymentDetails>");
				sb.Append(PaymentDetails[i].toXMLString());
				sb.Append("</ebl:PaymentDetails>");
			}
		}
		if( PromoOverrideFlag != null ) {
			sb.Append("<ebl:PromoOverrideFlag>").Append(PromoOverrideFlag);
			sb.Append("</ebl:PromoOverrideFlag>");
		}
		if( PromoCode != null ) {
			sb.Append("<ebl:PromoCode>").Append(PromoCode);
			sb.Append("</ebl:PromoCode>");
		}
		if( EnhancedData != null ) {
			sb.Append("<ebl:EnhancedData>");
			sb.Append(EnhancedData.toXMLString());
			sb.Append("</ebl:EnhancedData>");
		}
		if( SoftDescriptor != null ) {
			sb.Append("<ebl:SoftDescriptor>").Append(SoftDescriptor);
			sb.Append("</ebl:SoftDescriptor>");
		}
		if( UserSelectedOptions != null ) {
			sb.Append("<ebl:UserSelectedOptions>");
			sb.Append(UserSelectedOptions.toXMLString());
			sb.Append("</ebl:UserSelectedOptions>");
		}
		if( GiftMessage != null ) {
			sb.Append("<ebl:GiftMessage>").Append(GiftMessage);
			sb.Append("</ebl:GiftMessage>");
		}
		if( GiftReceiptEnable != null ) {
			sb.Append("<ebl:GiftReceiptEnable>").Append(GiftReceiptEnable);
			sb.Append("</ebl:GiftReceiptEnable>");
		}
		if( GiftWrapName != null ) {
			sb.Append("<ebl:GiftWrapName>").Append(GiftWrapName);
			sb.Append("</ebl:GiftWrapName>");
		}
		if( GiftWrapAmount != null ) {
			sb.Append("<ebl:GiftWrapAmount ");
			sb.Append(GiftWrapAmount.toXMLString());
			sb.Append("</ebl:GiftWrapAmount>");
		}
		if( BuyerMarketingEmail != null ) {
			sb.Append("<ebl:BuyerMarketingEmail>").Append(BuyerMarketingEmail);
			sb.Append("</ebl:BuyerMarketingEmail>");
		}
		if( SurveyQuestion != null ) {
			sb.Append("<ebl:SurveyQuestion>").Append(SurveyQuestion);
			sb.Append("</ebl:SurveyQuestion>");
		}
		if( SurveyChoiceSelected != null ) {
			for(int i=0; i<SurveyChoiceSelected.Count; i++) {
				sb.Append("<ebl:SurveyChoiceSelected>").Append(SurveyChoiceSelected[i]);
				sb.Append("</ebl:SurveyChoiceSelected>");
			}
		}
		if( ButtonSource != null ) {
			sb.Append("<ebl:ButtonSource>").Append(ButtonSource);
			sb.Append("</ebl:ButtonSource>");
		}
		if( SkipBACreation != null ) {
			sb.Append("<ebl:SkipBACreation>").Append(SkipBACreation);
			sb.Append("</ebl:SkipBACreation>");
		}
		return sb.ToString();
	}

	}


	/**
	 * This flag indicates that the response should include FMFDetails
	 */
	public partial class DoExpressCheckoutPaymentRequestType :AbstractRequestType{

		private DoExpressCheckoutPaymentRequestDetailsType DoExpressCheckoutPaymentRequestDetailsField;
		public DoExpressCheckoutPaymentRequestDetailsType DoExpressCheckoutPaymentRequestDetails {
			get {
				return this.DoExpressCheckoutPaymentRequestDetailsField;
			}
			set {
				this.DoExpressCheckoutPaymentRequestDetailsField = value;
			}
		}

		/**
This flag indicates that the response should include FMFDetails		 */
		private int? ReturnFMFDetailsField;
		public int? ReturnFMFDetails {
			get {
				return this.ReturnFMFDetailsField;
			}
			set {
				this.ReturnFMFDetailsField = value;
			}
		}

		public DoExpressCheckoutPaymentRequestType(DoExpressCheckoutPaymentRequestDetailsType DoExpressCheckoutPaymentRequestDetails) {
			this.DoExpressCheckoutPaymentRequestDetails = DoExpressCheckoutPaymentRequestDetails;
		}
		public DoExpressCheckoutPaymentRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( DoExpressCheckoutPaymentRequestDetails != null ) {
			sb.Append("<ebl:DoExpressCheckoutPaymentRequestDetails>");
			sb.Append(DoExpressCheckoutPaymentRequestDetails.toXMLString());
			sb.Append("</ebl:DoExpressCheckoutPaymentRequestDetails>");
		}
		if( ReturnFMFDetails != null ) {
			sb.Append("<urn:ReturnFMFDetails>").Append(ReturnFMFDetails);
			sb.Append("</urn:ReturnFMFDetails>");
		}
		return sb.ToString();
	}

	}


	/**
	 * The timestamped token value that was returned by SetExpressCheckoutResponse and passed on GetExpressCheckoutDetailsRequest. 
	 * Character length and limitations:20 single-byte characters
	 */
	public partial class DoExpressCheckoutPaymentResponseDetailsType {

		/**
		 * The timestamped token value that was returned by SetExpressCheckoutResponse and passed on GetExpressCheckoutDetailsRequest. 
		 * Character length and limitations:20 single-byte characters
		 */
		private string TokenField;
		public string Token {
			get {
				return this.TokenField;
			}
			set {
				this.TokenField = value;
			}
		}

		/**
Information about the transaction 		 */
		private List<PaymentInfoType> PaymentInfoField = new List<PaymentInfoType>();
		public List<PaymentInfoType> PaymentInfo {
			get {
				return this.PaymentInfoField;
			}
			set {
				this.PaymentInfoField = value;
			}
		}

		/**
		 */
		private string BillingAgreementIDField;
		public string BillingAgreementID {
			get {
				return this.BillingAgreementIDField;
			}
			set {
				this.BillingAgreementIDField = value;
			}
		}

		/**
		 */
		private string RedirectRequiredField;
		public string RedirectRequired {
			get {
				return this.RedirectRequiredField;
			}
			set {
				this.RedirectRequiredField = value;
			}
		}

		/**
Memo entered by sender in PayPal Review Page note field.
		 * Optional
		 * Character length and limitations: 255 single-byte alphanumeric characters
		 */
		private string NoteField;
		public string Note {
			get {
				return this.NoteField;
			}
			set {
				this.NoteField = value;
			}
		}

		/**
		 * Redirect back to PayPal, PayPal can host the success page. 	          
		 */
		private string SuccessPageRedirectRequestedField;
		public string SuccessPageRedirectRequested {
			get {
				return this.SuccessPageRedirectRequestedField;
			}
			set {
				this.SuccessPageRedirectRequestedField = value;
			}
		}

		/**
		 * Information about the user selected options.
		 */
		private UserSelectedOptionType UserSelectedOptionsField;
		public UserSelectedOptionType UserSelectedOptions {
			get {
				return this.UserSelectedOptionsField;
			}
			set {
				this.UserSelectedOptionsField = value;
			}
		}

	 public DoExpressCheckoutPaymentResponseDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Token").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Token")[0])){ 
		 this.Token =(string)document.GetElementsByTagName("Token")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("PaymentInfo").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentInfo")[0])){ 
		 nodeList = document.GetElementsByTagName("PaymentInfo");
		 for(int i=0; i<nodeList.Count; i++) {
			 xmlString = DeserializationUtils.convertToXML(nodeList[i]); 
				this.PaymentInfo.Add(new PaymentInfoType(xmlString));
			}

}
	}
		 if(document.GetElementsByTagName("BillingAgreementID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillingAgreementID")[0])){ 
		 this.BillingAgreementID =(string)document.GetElementsByTagName("BillingAgreementID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("RedirectRequired").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("RedirectRequired")[0])){ 
		 this.RedirectRequired =(string)document.GetElementsByTagName("RedirectRequired")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Note").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Note")[0])){ 
		 this.Note =(string)document.GetElementsByTagName("Note")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("SuccessPageRedirectRequested").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SuccessPageRedirectRequested")[0])){ 
		 this.SuccessPageRedirectRequested =(string)document.GetElementsByTagName("SuccessPageRedirectRequested")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("UserSelectedOptions").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("UserSelectedOptions")[0])){ 
		 nodeList = document.GetElementsByTagName("UserSelectedOptions");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.UserSelectedOptions =  new UserSelectedOptionType(xmlString);

}
	}
	}
	}


	/**
	 */
	public partial class DoExpressCheckoutPaymentResponseType :AbstractResponseType{

		private DoExpressCheckoutPaymentResponseDetailsType DoExpressCheckoutPaymentResponseDetailsField;
		public DoExpressCheckoutPaymentResponseDetailsType DoExpressCheckoutPaymentResponseDetails {
			get {
				return this.DoExpressCheckoutPaymentResponseDetailsField;
			}
			set {
				this.DoExpressCheckoutPaymentResponseDetailsField = value;
			}
		}

		private FMFDetailsType FMFDetailsField;
		public FMFDetailsType FMFDetails {
			get {
				return this.FMFDetailsField;
			}
			set {
				this.FMFDetailsField = value;
			}
		}

	 public DoExpressCheckoutPaymentResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("DoExpressCheckoutPaymentResponseDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("DoExpressCheckoutPaymentResponseDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("DoExpressCheckoutPaymentResponseDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.DoExpressCheckoutPaymentResponseDetails =  new DoExpressCheckoutPaymentResponseDetailsType(xmlString);

}
	}
		 if(document.GetElementsByTagName("FMFDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("FMFDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("FMFDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.FMFDetails =  new FMFDetailsType(xmlString);

}
	}
	}
	}


	/**
	 */
	public partial class DoMobileCheckoutPaymentReq {

		private DoMobileCheckoutPaymentRequestType DoMobileCheckoutPaymentRequestField;
		public DoMobileCheckoutPaymentRequestType DoMobileCheckoutPaymentRequest {
			get {
				return this.DoMobileCheckoutPaymentRequestField;
			}
			set {
				this.DoMobileCheckoutPaymentRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:DoMobileCheckoutPaymentReq>");
		if( DoMobileCheckoutPaymentRequest != null ) {
			sb.Append("<urn:DoMobileCheckoutPaymentRequest>");
			sb.Append(DoMobileCheckoutPaymentRequest.toXMLString());
			sb.Append("</urn:DoMobileCheckoutPaymentRequest>");
		}
sb.Append("</urn:DoMobileCheckoutPaymentReq>");
		return sb.ToString();
	}

	}


	/**
A timestamped token, the value of which was returned by SetMobileCheckoutResponse. 
	 * Required
	 * Character length and limitations: 20 single-byte characters
	 */
	public partial class DoMobileCheckoutPaymentRequestType :AbstractRequestType{

		/**
A timestamped token, the value of which was returned by SetMobileCheckoutResponse. 
		 * Required
		 * Character length and limitations: 20 single-byte characters
		 */
		private string TokenField;
		public string Token {
			get {
				return this.TokenField;
			}
			set {
				this.TokenField = value;
			}
		}

		public DoMobileCheckoutPaymentRequestType(string Token) {
			this.Token = Token;
		}
		public DoMobileCheckoutPaymentRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( Token != null ) {
			sb.Append("<urn:Token>").Append(Token);
			sb.Append("</urn:Token>");
		}
		return sb.ToString();
	}

	}


	/**
	 * A free-form field for your own use, such as a tracking number or other value you want returned to you in IPN.
	 * Optional
	 * Character length and limitations: 256 single-byte alphanumeric characters
	 */
	public partial class DoMobileCheckoutPaymentResponseDetailsType {

		/**
A free-form field for your own use, such as a tracking number or other value you want returned to you in IPN.
		 * Optional
		 * Character length and limitations: 256 single-byte alphanumeric characters
		 */
		private string CustomField;
		public string Custom {
			get {
				return this.CustomField;
			}
			set {
				this.CustomField = value;
			}
		}

		/**
Your own unique invoice or tracking number.
		 * Optional
		 * Character length and limitations: 127 single-byte alphanumeric characters
		 */
		private string InvoiceIDField;
		public string InvoiceID {
			get {
				return this.InvoiceIDField;
			}
			set {
				this.InvoiceIDField = value;
			}
		}

		/**
Information about the payer		 */
		private PayerInfoType PayerInfoField;
		public PayerInfoType PayerInfo {
			get {
				return this.PayerInfoField;
			}
			set {
				this.PayerInfoField = value;
			}
		}

		/**
Information about the transaction		 */
		private PaymentInfoType PaymentInfoField;
		public PaymentInfoType PaymentInfo {
			get {
				return this.PaymentInfoField;
			}
			set {
				this.PaymentInfoField = value;
			}
		}

	 public DoMobileCheckoutPaymentResponseDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Custom").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Custom")[0])){ 
		 this.Custom =(string)document.GetElementsByTagName("Custom")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("InvoiceID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("InvoiceID")[0])){ 
		 this.InvoiceID =(string)document.GetElementsByTagName("InvoiceID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("PayerInfo").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PayerInfo")[0])){ 
		 nodeList = document.GetElementsByTagName("PayerInfo");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.PayerInfo =  new PayerInfoType(xmlString);

}
	}
		 if(document.GetElementsByTagName("PaymentInfo").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentInfo")[0])){ 
		 nodeList = document.GetElementsByTagName("PaymentInfo");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.PaymentInfo =  new PaymentInfoType(xmlString);

}
	}
	}
	}


	/**
	 */
	public partial class DoMobileCheckoutPaymentResponseType :AbstractResponseType{

		private DoMobileCheckoutPaymentResponseDetailsType DoMobileCheckoutPaymentResponseDetailsField;
		public DoMobileCheckoutPaymentResponseDetailsType DoMobileCheckoutPaymentResponseDetails {
			get {
				return this.DoMobileCheckoutPaymentResponseDetailsField;
			}
			set {
				this.DoMobileCheckoutPaymentResponseDetailsField = value;
			}
		}

	 public DoMobileCheckoutPaymentResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("DoMobileCheckoutPaymentResponseDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("DoMobileCheckoutPaymentResponseDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("DoMobileCheckoutPaymentResponseDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.DoMobileCheckoutPaymentResponseDetails =  new DoMobileCheckoutPaymentResponseDetailsType(xmlString);

}
	}
	}
	}


	/**
	 */
	public partial class DoNonReferencedCreditReq {

		private DoNonReferencedCreditRequestType DoNonReferencedCreditRequestField;
		public DoNonReferencedCreditRequestType DoNonReferencedCreditRequest {
			get {
				return this.DoNonReferencedCreditRequestField;
			}
			set {
				this.DoNonReferencedCreditRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:DoNonReferencedCreditReq>");
		if( DoNonReferencedCreditRequest != null ) {
			sb.Append("<urn:DoNonReferencedCreditRequest>");
			sb.Append(DoNonReferencedCreditRequest.toXMLString());
			sb.Append("</urn:DoNonReferencedCreditRequest>");
		}
sb.Append("</urn:DoNonReferencedCreditReq>");
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class DoNonReferencedCreditRequestDetailsType {

		/**
		 */
		private BasicAmountType AmountField;
		public BasicAmountType Amount {
			get {
				return this.AmountField;
			}
			set {
				this.AmountField = value;
			}
		}

		/**
		 */
		private BasicAmountType NetAmountField;
		public BasicAmountType NetAmount {
			get {
				return this.NetAmountField;
			}
			set {
				this.NetAmountField = value;
			}
		}

		/**
		 */
		private BasicAmountType TaxAmountField;
		public BasicAmountType TaxAmount {
			get {
				return this.TaxAmountField;
			}
			set {
				this.TaxAmountField = value;
			}
		}

		/**
		 */
		private BasicAmountType ShippingAmountField;
		public BasicAmountType ShippingAmount {
			get {
				return this.ShippingAmountField;
			}
			set {
				this.ShippingAmountField = value;
			}
		}

		/**
		 */
		private CreditCardDetailsType CreditCardField;
		public CreditCardDetailsType CreditCard {
			get {
				return this.CreditCardField;
			}
			set {
				this.CreditCardField = value;
			}
		}

		/**
		 */
		private string ReceiverEmailField;
		public string ReceiverEmail {
			get {
				return this.ReceiverEmailField;
			}
			set {
				this.ReceiverEmailField = value;
			}
		}

		/**
		 */
		private string CommentField;
		public string Comment {
			get {
				return this.CommentField;
			}
			set {
				this.CommentField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( Amount != null ) {
			sb.Append("<ebl:Amount ");
			sb.Append(Amount.toXMLString());
			sb.Append("</ebl:Amount>");
		}
		if( NetAmount != null ) {
			sb.Append("<ebl:NetAmount ");
			sb.Append(NetAmount.toXMLString());
			sb.Append("</ebl:NetAmount>");
		}
		if( TaxAmount != null ) {
			sb.Append("<ebl:TaxAmount ");
			sb.Append(TaxAmount.toXMLString());
			sb.Append("</ebl:TaxAmount>");
		}
		if( ShippingAmount != null ) {
			sb.Append("<ebl:ShippingAmount ");
			sb.Append(ShippingAmount.toXMLString());
			sb.Append("</ebl:ShippingAmount>");
		}
		if( CreditCard != null ) {
			sb.Append("<ebl:CreditCard>");
			sb.Append(CreditCard.toXMLString());
			sb.Append("</ebl:CreditCard>");
		}
		if( ReceiverEmail != null ) {
			sb.Append("<ebl:ReceiverEmail>").Append(ReceiverEmail);
			sb.Append("</ebl:ReceiverEmail>");
		}
		if( Comment != null ) {
			sb.Append("<ebl:Comment>").Append(Comment);
			sb.Append("</ebl:Comment>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class DoNonReferencedCreditRequestType :AbstractRequestType{

		private DoNonReferencedCreditRequestDetailsType DoNonReferencedCreditRequestDetailsField;
		public DoNonReferencedCreditRequestDetailsType DoNonReferencedCreditRequestDetails {
			get {
				return this.DoNonReferencedCreditRequestDetailsField;
			}
			set {
				this.DoNonReferencedCreditRequestDetailsField = value;
			}
		}

		public DoNonReferencedCreditRequestType(DoNonReferencedCreditRequestDetailsType DoNonReferencedCreditRequestDetails) {
			this.DoNonReferencedCreditRequestDetails = DoNonReferencedCreditRequestDetails;
		}
		public DoNonReferencedCreditRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( DoNonReferencedCreditRequestDetails != null ) {
			sb.Append("<ebl:DoNonReferencedCreditRequestDetails>");
			sb.Append(DoNonReferencedCreditRequestDetails.toXMLString());
			sb.Append("</ebl:DoNonReferencedCreditRequestDetails>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class DoNonReferencedCreditResponseDetailsType {

		/**
		 */
		private BasicAmountType AmountField;
		public BasicAmountType Amount {
			get {
				return this.AmountField;
			}
			set {
				this.AmountField = value;
			}
		}

		/**
		 */
		private string TransactionIDField;
		public string TransactionID {
			get {
				return this.TransactionIDField;
			}
			set {
				this.TransactionIDField = value;
			}
		}

	 public DoNonReferencedCreditResponseDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Amount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Amount")[0])){ 
		 nodeList = document.GetElementsByTagName("Amount");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.Amount =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("TransactionID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TransactionID")[0])){ 
		 this.TransactionID =(string)document.GetElementsByTagName("TransactionID")[0].InnerText;

}
	}
	}
	}


	/**
	 */
	public partial class DoNonReferencedCreditResponseType :AbstractResponseType{

		private DoNonReferencedCreditResponseDetailsType DoNonReferencedCreditResponseDetailsField;
		public DoNonReferencedCreditResponseDetailsType DoNonReferencedCreditResponseDetails {
			get {
				return this.DoNonReferencedCreditResponseDetailsField;
			}
			set {
				this.DoNonReferencedCreditResponseDetailsField = value;
			}
		}

	 public DoNonReferencedCreditResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("DoNonReferencedCreditResponseDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("DoNonReferencedCreditResponseDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("DoNonReferencedCreditResponseDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.DoNonReferencedCreditResponseDetails =  new DoNonReferencedCreditResponseDetailsType(xmlString);

}
	}
	}
	}


	/**
	 */
	public partial class DoReauthorizationReq {

		private DoReauthorizationRequestType DoReauthorizationRequestField;
		public DoReauthorizationRequestType DoReauthorizationRequest {
			get {
				return this.DoReauthorizationRequestField;
			}
			set {
				this.DoReauthorizationRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:DoReauthorizationReq>");
		if( DoReauthorizationRequest != null ) {
			sb.Append("<urn:DoReauthorizationRequest>");
			sb.Append(DoReauthorizationRequest.toXMLString());
			sb.Append("</urn:DoReauthorizationRequest>");
		}
sb.Append("</urn:DoReauthorizationReq>");
		return sb.ToString();
	}

	}


	/**
	 * The value of a previously authorized transaction identification number returned by a PayPal product. You can obtain a buyer's transaction number from the TransactionID element of the PayerInfo structure returned by GetTransactionDetailsResponse. 
	 * Required
	 * Character length and limits: 19 single-byte characters maximum
	 */
	public partial class DoReauthorizationRequestType :AbstractRequestType{

		/**
The value of a previously authorized transaction identification number returned by a PayPal product. You can obtain a buyer's transaction number from the TransactionID element of the PayerInfo structure returned by GetTransactionDetailsResponse. 
		 * Required
		 * Character length and limits: 19 single-byte characters maximum
		 */
		private string AuthorizationIDField;
		public string AuthorizationID {
			get {
				return this.AuthorizationIDField;
			}
			set {
				this.AuthorizationIDField = value;
			}
		}

		/**
Amount to reauthorize. 
		 * Required
		 * Limitations: Must not exceed $10,000 USD in any currency. No currency symbol. Decimal separator must be a period (.), and the thousands separator must be a comma (,).
		 */
		private BasicAmountType AmountField;
		public BasicAmountType Amount {
			get {
				return this.AmountField;
			}
			set {
				this.AmountField = value;
			}
		}

		public DoReauthorizationRequestType(string AuthorizationID, BasicAmountType Amount) {
			this.AuthorizationID = AuthorizationID;
			this.Amount = Amount;
		}
		public DoReauthorizationRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( AuthorizationID != null ) {
			sb.Append("<urn:AuthorizationID>").Append(AuthorizationID);
			sb.Append("</urn:AuthorizationID>");
		}
		if( Amount != null ) {
			sb.Append("<urn:Amount ");
			sb.Append(Amount.toXMLString());
			sb.Append("</urn:Amount>");
		}
		return sb.ToString();
	}

	}


	/**
	 * A new authorization identification number.
	 * Character length and limits: 19 single-byte characters 
	 */
	public partial class DoReauthorizationResponseType :AbstractResponseType{

		/**
A new authorization identification number.
		 * Character length and limits: 19 single-byte characters 
		 */
		private string AuthorizationIDField;
		public string AuthorizationID {
			get {
				return this.AuthorizationIDField;
			}
			set {
				this.AuthorizationIDField = value;
			}
		}

		private AuthorizationInfoType AuthorizationInfoField;
		public AuthorizationInfoType AuthorizationInfo {
			get {
				return this.AuthorizationInfoField;
			}
			set {
				this.AuthorizationInfoField = value;
			}
		}

	 public DoReauthorizationResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("AuthorizationID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AuthorizationID")[0])){ 
		 this.AuthorizationID =(string)document.GetElementsByTagName("AuthorizationID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("AuthorizationInfo").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AuthorizationInfo")[0])){ 
		 nodeList = document.GetElementsByTagName("AuthorizationInfo");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.AuthorizationInfo =  new AuthorizationInfoType(xmlString);

}
	}
	}
	}


	/**
	 */
	public partial class DoReferenceTransactionReq {

		private DoReferenceTransactionRequestType DoReferenceTransactionRequestField;
		public DoReferenceTransactionRequestType DoReferenceTransactionRequest {
			get {
				return this.DoReferenceTransactionRequestField;
			}
			set {
				this.DoReferenceTransactionRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:DoReferenceTransactionReq>");
		if( DoReferenceTransactionRequest != null ) {
			sb.Append("<urn:DoReferenceTransactionRequest>");
			sb.Append(DoReferenceTransactionRequest.toXMLString());
			sb.Append("</urn:DoReferenceTransactionRequest>");
		}
sb.Append("</urn:DoReferenceTransactionReq>");
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class DoReferenceTransactionRequestDetailsType {

		/**
		 */
		private string ReferenceIDField;
		public string ReferenceID {
			get {
				return this.ReferenceIDField;
			}
			set {
				this.ReferenceIDField = value;
			}
		}

		/**
		 */
		private PaymentActionCodeType? PaymentActionField;
		public PaymentActionCodeType? PaymentAction {
			get {
				return this.PaymentActionField;
			}
			set {
				this.PaymentActionField = value;
			}
		}

		/**
		 */
		private MerchantPullPaymentCodeType? PaymentTypeField;
		public MerchantPullPaymentCodeType? PaymentType {
			get {
				return this.PaymentTypeField;
			}
			set {
				this.PaymentTypeField = value;
			}
		}

		/**
		 */
		private PaymentDetailsType PaymentDetailsField;
		public PaymentDetailsType PaymentDetails {
			get {
				return this.PaymentDetailsField;
			}
			set {
				this.PaymentDetailsField = value;
			}
		}

		/**
		 */
		private ReferenceCreditCardDetailsType CreditCardField;
		public ReferenceCreditCardDetailsType CreditCard {
			get {
				return this.CreditCardField;
			}
			set {
				this.CreditCardField = value;
			}
		}

		/**
		 */
		private string IPAddressField;
		public string IPAddress {
			get {
				return this.IPAddressField;
			}
			set {
				this.IPAddressField = value;
			}
		}

		/**
		 */
		private string MerchantSessionIdField;
		public string MerchantSessionId {
			get {
				return this.MerchantSessionIdField;
			}
			set {
				this.MerchantSessionIdField = value;
			}
		}

		/**
		 */
		private string ReqConfirmShippingField;
		public string ReqConfirmShipping {
			get {
				return this.ReqConfirmShippingField;
			}
			set {
				this.ReqConfirmShippingField = value;
			}
		}

		/**
		 */
		private string SoftDescriptorField;
		public string SoftDescriptor {
			get {
				return this.SoftDescriptorField;
			}
			set {
				this.SoftDescriptorField = value;
			}
		}

		/**
		 */
		private SenderDetailsType SenderDetailsField;
		public SenderDetailsType SenderDetails {
			get {
				return this.SenderDetailsField;
			}
			set {
				this.SenderDetailsField = value;
			}
		}

		public DoReferenceTransactionRequestDetailsType(string ReferenceID, PaymentActionCodeType? PaymentAction, PaymentDetailsType PaymentDetails) {
			this.ReferenceID = ReferenceID;
			this.PaymentAction = PaymentAction;
			this.PaymentDetails = PaymentDetails;
		}
		public DoReferenceTransactionRequestDetailsType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( ReferenceID != null ) {
			sb.Append("<ebl:ReferenceID>").Append(ReferenceID);
			sb.Append("</ebl:ReferenceID>");
		}
		if( PaymentAction != null ) {
			sb.Append("<ebl:PaymentAction>").Append(EnumUtils.getDescription(PaymentAction));
			sb.Append("</ebl:PaymentAction>");
		}
		if( PaymentType != null ) {
			sb.Append("<ebl:PaymentType>").Append(EnumUtils.getDescription(PaymentType));
			sb.Append("</ebl:PaymentType>");
		}
		if( PaymentDetails != null ) {
			sb.Append("<ebl:PaymentDetails>");
			sb.Append(PaymentDetails.toXMLString());
			sb.Append("</ebl:PaymentDetails>");
		}
		if( CreditCard != null ) {
			sb.Append("<ebl:CreditCard>");
			sb.Append(CreditCard.toXMLString());
			sb.Append("</ebl:CreditCard>");
		}
		if( IPAddress != null ) {
			sb.Append("<ebl:IPAddress>").Append(IPAddress);
			sb.Append("</ebl:IPAddress>");
		}
		if( MerchantSessionId != null ) {
			sb.Append("<ebl:MerchantSessionId>").Append(MerchantSessionId);
			sb.Append("</ebl:MerchantSessionId>");
		}
		if( ReqConfirmShipping != null ) {
			sb.Append("<ebl:ReqConfirmShipping>").Append(ReqConfirmShipping);
			sb.Append("</ebl:ReqConfirmShipping>");
		}
		if( SoftDescriptor != null ) {
			sb.Append("<ebl:SoftDescriptor>").Append(SoftDescriptor);
			sb.Append("</ebl:SoftDescriptor>");
		}
		if( SenderDetails != null ) {
			sb.Append("<ebl:SenderDetails>");
			sb.Append(SenderDetails.toXMLString());
			sb.Append("</ebl:SenderDetails>");
		}
		return sb.ToString();
	}

	}


	/**
	 * This flag indicates that the response should include FMFDetails
	 */
	public partial class DoReferenceTransactionRequestType :AbstractRequestType{

		private DoReferenceTransactionRequestDetailsType DoReferenceTransactionRequestDetailsField;
		public DoReferenceTransactionRequestDetailsType DoReferenceTransactionRequestDetails {
			get {
				return this.DoReferenceTransactionRequestDetailsField;
			}
			set {
				this.DoReferenceTransactionRequestDetailsField = value;
			}
		}

		/**
This flag indicates that the response should include FMFDetails		 */
		private int? ReturnFMFDetailsField;
		public int? ReturnFMFDetails {
			get {
				return this.ReturnFMFDetailsField;
			}
			set {
				this.ReturnFMFDetailsField = value;
			}
		}

		public DoReferenceTransactionRequestType(DoReferenceTransactionRequestDetailsType DoReferenceTransactionRequestDetails) {
			this.DoReferenceTransactionRequestDetails = DoReferenceTransactionRequestDetails;
		}
		public DoReferenceTransactionRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( DoReferenceTransactionRequestDetails != null ) {
			sb.Append("<ebl:DoReferenceTransactionRequestDetails>");
			sb.Append(DoReferenceTransactionRequestDetails.toXMLString());
			sb.Append("</ebl:DoReferenceTransactionRequestDetails>");
		}
		if( ReturnFMFDetails != null ) {
			sb.Append("<urn:ReturnFMFDetails>").Append(ReturnFMFDetails);
			sb.Append("</urn:ReturnFMFDetails>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class DoReferenceTransactionResponseDetailsType {

		/**
		 */
		private string BillingAgreementIDField;
		public string BillingAgreementID {
			get {
				return this.BillingAgreementIDField;
			}
			set {
				this.BillingAgreementIDField = value;
			}
		}

		/**
		 */
		private PaymentInfoType PaymentInfoField;
		public PaymentInfoType PaymentInfo {
			get {
				return this.PaymentInfoField;
			}
			set {
				this.PaymentInfoField = value;
			}
		}

		/**
		 */
		private BasicAmountType AmountField;
		public BasicAmountType Amount {
			get {
				return this.AmountField;
			}
			set {
				this.AmountField = value;
			}
		}

		/**
		 */
		private string AVSCodeField;
		public string AVSCode {
			get {
				return this.AVSCodeField;
			}
			set {
				this.AVSCodeField = value;
			}
		}

		/**
		 */
		private string CVV2CodeField;
		public string CVV2Code {
			get {
				return this.CVV2CodeField;
			}
			set {
				this.CVV2CodeField = value;
			}
		}

		/**
		 */
		private string TransactionIDField;
		public string TransactionID {
			get {
				return this.TransactionIDField;
			}
			set {
				this.TransactionIDField = value;
			}
		}

		/**
		 * Response code from the processor when a recurring transaction is declined
		 */
		private string PaymentAdviceCodeField;
		public string PaymentAdviceCode {
			get {
				return this.PaymentAdviceCodeField;
			}
			set {
				this.PaymentAdviceCodeField = value;
			}
		}

	 public DoReferenceTransactionResponseDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("BillingAgreementID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillingAgreementID")[0])){ 
		 this.BillingAgreementID =(string)document.GetElementsByTagName("BillingAgreementID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("PaymentInfo").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentInfo")[0])){ 
		 nodeList = document.GetElementsByTagName("PaymentInfo");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.PaymentInfo =  new PaymentInfoType(xmlString);

}
	}
		 if(document.GetElementsByTagName("Amount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Amount")[0])){ 
		 nodeList = document.GetElementsByTagName("Amount");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.Amount =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("AVSCode").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AVSCode")[0])){ 
		 this.AVSCode =(string)document.GetElementsByTagName("AVSCode")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("CVV2Code").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CVV2Code")[0])){ 
		 this.CVV2Code =(string)document.GetElementsByTagName("CVV2Code")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("TransactionID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TransactionID")[0])){ 
		 this.TransactionID =(string)document.GetElementsByTagName("TransactionID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("PaymentAdviceCode").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentAdviceCode")[0])){ 
		 this.PaymentAdviceCode =(string)document.GetElementsByTagName("PaymentAdviceCode")[0].InnerText;

}
	}
	}
	}


	/**
	 */
	public partial class DoReferenceTransactionResponseType :AbstractResponseType{

		private DoReferenceTransactionResponseDetailsType DoReferenceTransactionResponseDetailsField;
		public DoReferenceTransactionResponseDetailsType DoReferenceTransactionResponseDetails {
			get {
				return this.DoReferenceTransactionResponseDetailsField;
			}
			set {
				this.DoReferenceTransactionResponseDetailsField = value;
			}
		}

		private FMFDetailsType FMFDetailsField;
		public FMFDetailsType FMFDetails {
			get {
				return this.FMFDetailsField;
			}
			set {
				this.FMFDetailsField = value;
			}
		}

	 public DoReferenceTransactionResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("DoReferenceTransactionResponseDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("DoReferenceTransactionResponseDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("DoReferenceTransactionResponseDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.DoReferenceTransactionResponseDetails =  new DoReferenceTransactionResponseDetailsType(xmlString);

}
	}
		 if(document.GetElementsByTagName("FMFDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("FMFDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("FMFDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.FMFDetails =  new FMFDetailsType(xmlString);

}
	}
	}
	}


	/**
	 */
	public partial class DoUATPAuthorizationReq {

		private DoUATPAuthorizationRequestType DoUATPAuthorizationRequestField;
		public DoUATPAuthorizationRequestType DoUATPAuthorizationRequest {
			get {
				return this.DoUATPAuthorizationRequestField;
			}
			set {
				this.DoUATPAuthorizationRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:DoUATPAuthorizationReq>");
		if( DoUATPAuthorizationRequest != null ) {
			sb.Append("<urn:DoUATPAuthorizationRequest>");
			sb.Append(DoUATPAuthorizationRequest.toXMLString());
			sb.Append("</urn:DoUATPAuthorizationRequest>");
		}
sb.Append("</urn:DoUATPAuthorizationReq>");
		return sb.ToString();
	}

	}


	/**
	 * UATP card details
	 * Required
	 */
	public partial class DoUATPAuthorizationRequestType :AbstractRequestType{

		/**
UATP card details
		 * Required
		 */
		private UATPDetailsType UATPDetailsField;
		public UATPDetailsType UATPDetails {
			get {
				return this.UATPDetailsField;
			}
			set {
				this.UATPDetailsField = value;
			}
		}

		/**
Type of transaction to authorize. The only allowable value is Order, which means that the transaction represents a customer order that can be fulfilled over 29 days. 
		 * Optional
		 */
		private TransactionEntityType? TransactionEntityField;
		public TransactionEntityType? TransactionEntity {
			get {
				return this.TransactionEntityField;
			}
			set {
				this.TransactionEntityField = value;
			}
		}

		/**
Amount to authorize. 
		 * Required
		 * Limitations: Must not exceed $10,000 USD in any currency. No currency symbol. Decimal separator must be a period (.), and the thousands separator must be a comma (,).
		 */
		private BasicAmountType AmountField;
		public BasicAmountType Amount {
			get {
				return this.AmountField;
			}
			set {
				this.AmountField = value;
			}
		}

		/**
		 * Invoice ID. A pass through.
		 */
		private string InvoiceIDField;
		public string InvoiceID {
			get {
				return this.InvoiceIDField;
			}
			set {
				this.InvoiceIDField = value;
			}
		}

		public DoUATPAuthorizationRequestType(UATPDetailsType UATPDetails, BasicAmountType Amount) {
			this.UATPDetails = UATPDetails;
			this.Amount = Amount;
		}
		public DoUATPAuthorizationRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( UATPDetails != null ) {
			sb.Append("<ebl:UATPDetails>");
			sb.Append(UATPDetails.toXMLString());
			sb.Append("</ebl:UATPDetails>");
		}
		if( TransactionEntity != null ) {
			sb.Append("<urn:TransactionEntity>").Append(EnumUtils.getDescription(TransactionEntity));
			sb.Append("</urn:TransactionEntity>");
		}
		if( Amount != null ) {
			sb.Append("<urn:Amount ");
			sb.Append(Amount.toXMLString());
			sb.Append("</urn:Amount>");
		}
		if( InvoiceID != null ) {
			sb.Append("<urn:InvoiceID>").Append(InvoiceID);
			sb.Append("</urn:InvoiceID>");
		}
		return sb.ToString();
	}

	}


	/**
	 * Auth Authorization Code.
	 */
	public partial class DoUATPAuthorizationResponseType :DoAuthorizationResponseType{

		private UATPDetailsType UATPDetailsField;
		public UATPDetailsType UATPDetails {
			get {
				return this.UATPDetailsField;
			}
			set {
				this.UATPDetailsField = value;
			}
		}

		/**
		 * Auth Authorization Code.
		 */
		private string AuthorizationCodeField;
		public string AuthorizationCode {
			get {
				return this.AuthorizationCodeField;
			}
			set {
				this.AuthorizationCodeField = value;
			}
		}

		/**
		 * Invoice ID. A pass through.
		 */
		private string InvoiceIDField;
		public string InvoiceID {
			get {
				return this.InvoiceIDField;
			}
			set {
				this.InvoiceIDField = value;
			}
		}

	 public DoUATPAuthorizationResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("UATPDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("UATPDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("UATPDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.UATPDetails =  new UATPDetailsType(xmlString);

}
	}
		 if(document.GetElementsByTagName("AuthorizationCode").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AuthorizationCode")[0])){ 
		 this.AuthorizationCode =(string)document.GetElementsByTagName("AuthorizationCode")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("InvoiceID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("InvoiceID")[0])){ 
		 this.InvoiceID =(string)document.GetElementsByTagName("InvoiceID")[0].InnerText;

}
	}
	}
	}


	/**
	 */
	public partial class DoUATPExpressCheckoutPaymentReq {

		private DoUATPExpressCheckoutPaymentRequestType DoUATPExpressCheckoutPaymentRequestField;
		public DoUATPExpressCheckoutPaymentRequestType DoUATPExpressCheckoutPaymentRequest {
			get {
				return this.DoUATPExpressCheckoutPaymentRequestField;
			}
			set {
				this.DoUATPExpressCheckoutPaymentRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:DoUATPExpressCheckoutPaymentReq>");
		if( DoUATPExpressCheckoutPaymentRequest != null ) {
			sb.Append("<urn:DoUATPExpressCheckoutPaymentRequest>");
			sb.Append(DoUATPExpressCheckoutPaymentRequest.toXMLString());
			sb.Append("</urn:DoUATPExpressCheckoutPaymentRequest>");
		}
sb.Append("</urn:DoUATPExpressCheckoutPaymentReq>");
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class DoUATPExpressCheckoutPaymentRequestType :DoExpressCheckoutPaymentRequestType{


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class DoUATPExpressCheckoutPaymentResponseType :DoExpressCheckoutPaymentResponseType{

		private UATPDetailsType UATPDetailsField;
		public UATPDetailsType UATPDetails {
			get {
				return this.UATPDetailsField;
			}
			set {
				this.UATPDetailsField = value;
			}
		}

	 public DoUATPExpressCheckoutPaymentResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("UATPDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("UATPDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("UATPDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.UATPDetails =  new UATPDetailsType(xmlString);

}
	}
	}
	}


	/**
	 */
	public partial class DoVoidReq {

		private DoVoidRequestType DoVoidRequestField;
		public DoVoidRequestType DoVoidRequest {
			get {
				return this.DoVoidRequestField;
			}
			set {
				this.DoVoidRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:DoVoidReq>");
		if( DoVoidRequest != null ) {
			sb.Append("<urn:DoVoidRequest>");
			sb.Append(DoVoidRequest.toXMLString());
			sb.Append("</urn:DoVoidRequest>");
		}
sb.Append("</urn:DoVoidReq>");
		return sb.ToString();
	}

	}


	/**
	 * The value of the original authorization identification number returned by a PayPal product. 
	 * If you are voiding a transaction that has been reauthorized, use the ID from the original authorization, and not the reauthorization.
	 * Required
	 * Character length and limits: 19 single-byte characters
	 */
	public partial class DoVoidRequestType :AbstractRequestType{

		/**
The value of the original authorization identification number returned by a PayPal product. 
		 * If you are voiding a transaction that has been reauthorized, use the ID from the original authorization, and not the reauthorization.
		 * Required
		 * Character length and limits: 19 single-byte characters
		 */
		private string AuthorizationIDField;
		public string AuthorizationID {
			get {
				return this.AuthorizationIDField;
			}
			set {
				this.AuthorizationIDField = value;
			}
		}

		/**
An informational note about this settlement that is displayed to the payer in email and in  transaction history. 
		 * Optional
		 * Character length and limits: 255 single-byte characters
		 */
		private string NoteField;
		public string Note {
			get {
				return this.NoteField;
			}
			set {
				this.NoteField = value;
			}
		}

		public DoVoidRequestType(string AuthorizationID) {
			this.AuthorizationID = AuthorizationID;
		}
		public DoVoidRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( AuthorizationID != null ) {
			sb.Append("<urn:AuthorizationID>").Append(AuthorizationID);
			sb.Append("</urn:AuthorizationID>");
		}
		if( Note != null ) {
			sb.Append("<urn:Note>").Append(Note);
			sb.Append("</urn:Note>");
		}
		return sb.ToString();
	}

	}


	/**
	 * The authorization identification number you specified in the request. 
	 * Character length and limits: 19 single-byte characters
	 */
	public partial class DoVoidResponseType :AbstractResponseType{

		/**
The authorization identification number you specified in the request. 
		 * Character length and limits: 19 single-byte characters
		 */
		private string AuthorizationIDField;
		public string AuthorizationID {
			get {
				return this.AuthorizationIDField;
			}
			set {
				this.AuthorizationIDField = value;
			}
		}

	 public DoVoidResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("AuthorizationID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AuthorizationID")[0])){ 
		 nodeList = document.GetElementsByTagName("AuthorizationID");
			 string value = nodeList[0].InnerText; 
		 this.AuthorizationID =value;

}
	}
	}
	}


	/**
	 * EbayItemPaymentDetailsItemType - Type declaration to be used by other schemas.
	 * Information about an Ebay Payment Item.
	 */
	public partial class EbayItemPaymentDetailsItemType {

		/**
		 * Auction ItemNumber. 
		 * Optional
		 * Character length and limitations: 765 single-byte characters
		 */
		private string ItemNumberField;
		public string ItemNumber {
			get {
				return this.ItemNumberField;
			}
			set {
				this.ItemNumberField = value;
			}
		}

		/**
		 * Auction Transaction ID. 
		 * Optional
		 * Character length and limitations: 255 single-byte characters
		 */
		private string AuctionTransactionIdField;
		public string AuctionTransactionId {
			get {
				return this.AuctionTransactionIdField;
			}
			set {
				this.AuctionTransactionIdField = value;
			}
		}

		/**
		 * Ebay Order ID. 
		 * Optional
		 * Character length and limitations: 64 single-byte characters
		 */
		private string OrderIdField;
		public string OrderId {
			get {
				return this.OrderIdField;
			}
			set {
				this.OrderIdField = value;
			}
		}

		/**
		 * Ebay Cart ID.
		 * Optional
		 * Character length and limitations: 64 single-byte characters
		 */
		private string CartIDField;
		public string CartID {
			get {
				return this.CartIDField;
			}
			set {
				this.CartIDField = value;
			}
		}

		public EbayItemPaymentDetailsItemType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( ItemNumber != null ) {
			sb.Append("<ebl:ItemNumber>").Append(ItemNumber);
			sb.Append("</ebl:ItemNumber>");
		}
		if( AuctionTransactionId != null ) {
			sb.Append("<ebl:AuctionTransactionId>").Append(AuctionTransactionId);
			sb.Append("</ebl:AuctionTransactionId>");
		}
		if( OrderId != null ) {
			sb.Append("<ebl:OrderId>").Append(OrderId);
			sb.Append("</ebl:OrderId>");
		}
		if( CartID != null ) {
			sb.Append("<ebl:CartID>").Append(CartID);
			sb.Append("</ebl:CartID>");
		}
		return sb.ToString();
	}

	 public EbayItemPaymentDetailsItemType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("ItemNumber").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ItemNumber")[0])){ 
		 this.ItemNumber =(string)document.GetElementsByTagName("ItemNumber")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("AuctionTransactionId").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AuctionTransactionId")[0])){ 
		 this.AuctionTransactionId =(string)document.GetElementsByTagName("AuctionTransactionId")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("OrderId").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OrderId")[0])){ 
		 this.OrderId =(string)document.GetElementsByTagName("OrderId")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("CartID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CartID")[0])){ 
		 this.CartID =(string)document.GetElementsByTagName("CartID")[0].InnerText;

}
	}
	}
	}


	/**
	 */
	public partial class EnhancedCancelRecoupRequestDetailsType {


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class EnhancedCheckoutDataType {


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class EnhancedCompleteRecoupRequestDetailsType {


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class EnhancedCompleteRecoupResponseDetailsType {

	 public EnhancedCompleteRecoupResponseDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
	}
	}


	/**
	 * Enhanced Data Information. Example: AID for Airlines
	 */
	public partial class EnhancedDataType {

		private AirlineItineraryType AirlineItineraryField;
		public AirlineItineraryType AirlineItinerary {
			get {
				return this.AirlineItineraryField;
			}
			set {
				this.AirlineItineraryField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( AirlineItinerary != null ) {
			sb.Append("<ebl:AirlineItinerary>");
			sb.Append(AirlineItinerary.toXMLString());
			sb.Append("</ebl:AirlineItinerary>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class EnhancedInitiateRecoupRequestDetailsType {


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class EnhancedItemDataType {

		public EnhancedItemDataType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		return sb.ToString();
	}

	 public EnhancedItemDataType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
	}
	}


	/**
	 */
	public partial class EnhancedPayerInfoType {

		public EnhancedPayerInfoType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		return sb.ToString();
	}

	 public EnhancedPayerInfoType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
	}
	}


	/**
	 */
	public partial class EnhancedPaymentDataType {

		public EnhancedPaymentDataType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		return sb.ToString();
	}

	 public EnhancedPaymentDataType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
	}
	}


	/**
	 */
	public partial class EnhancedPaymentInfoType {

	 public EnhancedPaymentInfoType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
	}
	}


	/**
	 */
	public partial class EnterBoardingReq {

		private EnterBoardingRequestType EnterBoardingRequestField;
		public EnterBoardingRequestType EnterBoardingRequest {
			get {
				return this.EnterBoardingRequestField;
			}
			set {
				this.EnterBoardingRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:EnterBoardingReq>");
		if( EnterBoardingRequest != null ) {
			sb.Append("<urn:EnterBoardingRequest>");
			sb.Append(EnterBoardingRequest.toXMLString());
			sb.Append("</urn:EnterBoardingRequest>");
		}
sb.Append("</urn:EnterBoardingReq>");
		return sb.ToString();
	}

	}


	/**
	 * Onboarding program code given to you by PayPal.
	 * Required
	 * Character length and limitations: 64 alphanumeric characters
	 */
	public partial class EnterBoardingRequestDetailsType {

		/**
		 * Onboarding program code given to you by PayPal.
		 * Required
		 * Character length and limitations: 64 alphanumeric characters		 */
		private string ProgramCodeField;
		public string ProgramCode {
			get {
				return this.ProgramCodeField;
			}
			set {
				this.ProgramCodeField = value;
			}
		}

		/**
		 * A list of comma-separated values that indicate the PayPal products you are implementing for this merchant:
		 * Direct Payment (dp) allows payments by credit card without requiring the customer to have a PayPal account. 
		 * Express Checkout (ec) allows customers to fund transactions with their PayPal account. 
		 * Authorization and Capture (auth_settle) allows merchants to verify availability of funds in a PayPal account, but capture them at a later time. 
		 * Administrative APIs (admin_api) is a collection of the PayPal APIs for transaction searching, getting transaction details, refunding, and mass payments. 
		 * Required
		 * Character length and limitations: 64 alphanumeric characters		 */
		private string ProductListField;
		public string ProductList {
			get {
				return this.ProductListField;
			}
			set {
				this.ProductListField = value;
			}
		}

		/**
		 * Any custom information you want to store for this partner
		 * Optional
		 * Character length and limitations: 256 alphanumeric characters		 */
		private string PartnerCustomField;
		public string PartnerCustom {
			get {
				return this.PartnerCustomField;
			}
			set {
				this.PartnerCustomField = value;
			}
		}

		/**
		 * The URL for the logo displayed on the PayPal Partner Welcome Page.
		 * Optional
		 * Character length and limitations: 2,048 alphanumeric characters		 */
		private string ImageUrlField;
		public string ImageUrl {
			get {
				return this.ImageUrlField;
			}
			set {
				this.ImageUrlField = value;
			}
		}

		/**
		 * Marketing category tha configures the graphic displayed n the PayPal Partner Welcome page.		 */
		private MarketingCategoryType? MarketingCategoryField;
		public MarketingCategoryType? MarketingCategory {
			get {
				return this.MarketingCategoryField;
			}
			set {
				this.MarketingCategoryField = value;
			}
		}

		/**
		 * Information about the merchant’s business		 */
		private BusinessInfoType BusinessInfoField;
		public BusinessInfoType BusinessInfo {
			get {
				return this.BusinessInfoField;
			}
			set {
				this.BusinessInfoField = value;
			}
		}

		/**
		 * Information about the merchant (the business owner)		 */
		private BusinessOwnerInfoType OwnerInfoField;
		public BusinessOwnerInfoType OwnerInfo {
			get {
				return this.OwnerInfoField;
			}
			set {
				this.OwnerInfoField = value;
			}
		}

		/**
		 * Information about the merchant's bank account		 */
		private BankAccountDetailsType BankAccountField;
		public BankAccountDetailsType BankAccount {
			get {
				return this.BankAccountField;
			}
			set {
				this.BankAccountField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( ProgramCode != null ) {
			sb.Append("<ebl:ProgramCode>").Append(ProgramCode);
			sb.Append("</ebl:ProgramCode>");
		}
		if( ProductList != null ) {
			sb.Append("<ebl:ProductList>").Append(ProductList);
			sb.Append("</ebl:ProductList>");
		}
		if( PartnerCustom != null ) {
			sb.Append("<ebl:PartnerCustom>").Append(PartnerCustom);
			sb.Append("</ebl:PartnerCustom>");
		}
		if( ImageUrl != null ) {
			sb.Append("<ebl:ImageUrl>").Append(ImageUrl);
			sb.Append("</ebl:ImageUrl>");
		}
		if( MarketingCategory != null ) {
			sb.Append("<ebl:MarketingCategory>").Append(EnumUtils.getDescription(MarketingCategory));
			sb.Append("</ebl:MarketingCategory>");
		}
		if( BusinessInfo != null ) {
			sb.Append("<ebl:BusinessInfo>");
			sb.Append(BusinessInfo.toXMLString());
			sb.Append("</ebl:BusinessInfo>");
		}
		if( OwnerInfo != null ) {
			sb.Append("<ebl:OwnerInfo>");
			sb.Append(OwnerInfo.toXMLString());
			sb.Append("</ebl:OwnerInfo>");
		}
		if( BankAccount != null ) {
			sb.Append("<ebl:BankAccount>");
			sb.Append(BankAccount.toXMLString());
			sb.Append("</ebl:BankAccount>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class EnterBoardingRequestType :AbstractRequestType{

		private EnterBoardingRequestDetailsType EnterBoardingRequestDetailsField;
		public EnterBoardingRequestDetailsType EnterBoardingRequestDetails {
			get {
				return this.EnterBoardingRequestDetailsField;
			}
			set {
				this.EnterBoardingRequestDetailsField = value;
			}
		}

		public EnterBoardingRequestType(EnterBoardingRequestDetailsType EnterBoardingRequestDetails) {
			this.EnterBoardingRequestDetails = EnterBoardingRequestDetails;
		}
		public EnterBoardingRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( EnterBoardingRequestDetails != null ) {
			sb.Append("<ebl:EnterBoardingRequestDetails>");
			sb.Append(EnterBoardingRequestDetails.toXMLString());
			sb.Append("</ebl:EnterBoardingRequestDetails>");
		}
		return sb.ToString();
	}

	}


	/**
	 * A unique token that identifies this boarding session. 
Use this token with the GetBoarding Details API call.
	 * Character length and limitations: 64 alphanumeric characters. The token has the following format:
	 * OB-61characterstring	 */
	public partial class EnterBoardingResponseType :AbstractResponseType{

		/**
		 * A unique token that identifies this boarding session. 
Use this token with the GetBoarding Details API call.
		 * Character length and limitations: 64 alphanumeric characters. The token has the following format:
		 * OB-61characterstring		 */
		private string TokenField;
		public string Token {
			get {
				return this.TokenField;
			}
			set {
				this.TokenField = value;
			}
		}

	 public EnterBoardingResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Token").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Token")[0])){ 
		 this.Token =(string)document.GetElementsByTagName("Token")[0].InnerText;

}
	}
	}
	}


	/**
	 * Value of the application-specific error parameter.
	 */
	public partial class ErrorParameterType {

		/**
		 * Value of the application-specific error parameter.
		 */
		private string ValueField;
		public string Value {
			get {
				return this.ValueField;
			}
			set {
				this.ValueField = value;
			}
		}

	 public ErrorParameterType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Value").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Value")[0])){ 
		 nodeList = document.GetElementsByTagName("Value");
			 string value = nodeList[0].InnerText; 
		 this.Value =value;

}
	}
	}
	}


	/**
	 * Error code can be used by a receiving application to debugging a response 
	 * message. These codes will need to be uniquely defined for each application. 
	 */
	public partial class ErrorType {

		private string ShortMessageField;
		public string ShortMessage {
			get {
				return this.ShortMessageField;
			}
			set {
				this.ShortMessageField = value;
			}
		}

		private string LongMessageField;
		public string LongMessage {
			get {
				return this.LongMessageField;
			}
			set {
				this.LongMessageField = value;
			}
		}

		/**
		 * Error code can be used by a receiving application to debugging a response 
		 * message. These codes will need to be uniquely defined for each application. 
		 */
		private string ErrorCodeField;
		public string ErrorCode {
			get {
				return this.ErrorCodeField;
			}
			set {
				this.ErrorCodeField = value;
			}
		}

		/**
		 * SeverityCode indicates whether the error is an application
		 * level error or if it is informational error, i.e., warning.
		 */
		private SeverityCodeType? SeverityCodeField;
		public SeverityCodeType? SeverityCode {
			get {
				return this.SeverityCodeField;
			}
			set {
				this.SeverityCodeField = value;
			}
		}

		/**
		 * This optional element may carry additional application-specific error variables 
		 * that indicate specific information about the error condition particularly in the 
		 * cases where there are multiple instances of the ErrorType which require 
		 * additional context.
		 */
		private List<ErrorParameterType> ErrorParametersField = new List<ErrorParameterType>();
		public List<ErrorParameterType> ErrorParameters {
			get {
				return this.ErrorParametersField;
			}
			set {
				this.ErrorParametersField = value;
			}
		}

	 public ErrorType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("ShortMessage").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ShortMessage")[0])){ 
		 this.ShortMessage =(string)document.GetElementsByTagName("ShortMessage")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("LongMessage").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("LongMessage")[0])){ 
		 this.LongMessage =(string)document.GetElementsByTagName("LongMessage")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ErrorCode").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ErrorCode")[0])){ 
		 this.ErrorCode =(string)document.GetElementsByTagName("ErrorCode")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("SeverityCode").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SeverityCode")[0])){ 
		 this.SeverityCode = (SeverityCodeType)EnumUtils.getValue(document.GetElementsByTagName("SeverityCode")[0].InnerText,typeof(SeverityCodeType));

}
	}
		 if(document.GetElementsByTagName("ErrorParameters").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ErrorParameters")[0])){ 
		 nodeList = document.GetElementsByTagName("ErrorParameters");
		 for(int i=0; i<nodeList.Count; i++) {
			 xmlString = DeserializationUtils.convertToXML(nodeList[i]); 
				this.ErrorParameters.Add(new ErrorParameterType(xmlString));
			}

}
	}
	}
	}


	/**
	 */
	public partial class ExecuteCheckoutOperationsReq {

		private ExecuteCheckoutOperationsRequestType ExecuteCheckoutOperationsRequestField;
		public ExecuteCheckoutOperationsRequestType ExecuteCheckoutOperationsRequest {
			get {
				return this.ExecuteCheckoutOperationsRequestField;
			}
			set {
				this.ExecuteCheckoutOperationsRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:ExecuteCheckoutOperationsReq>");
		if( ExecuteCheckoutOperationsRequest != null ) {
			sb.Append("<urn:ExecuteCheckoutOperationsRequest>");
			sb.Append(ExecuteCheckoutOperationsRequest.toXMLString());
			sb.Append("</urn:ExecuteCheckoutOperationsRequest>");
		}
sb.Append("</urn:ExecuteCheckoutOperationsReq>");
		return sb.ToString();
	}

	}


	/**
	 * On your first invocation of ExecuteCheckoutOperationsRequest, the value of this token is returned by ExecuteCheckoutOperationsResponse.
	 * Optional
	 * Include this element and its value only if you want to modify an existing checkout session with another invocation of ExecuteCheckoutOperationsRequest; for example, if you want the customer to edit his shipping address on PayPal.
	 * Character length and limitations: 20 single-byte characters
	 */
	public partial class ExecuteCheckoutOperationsRequestDetailsType {

		/**
		 * On your first invocation of ExecuteCheckoutOperationsRequest, the value of this token is returned by ExecuteCheckoutOperationsResponse.
		 * Optional
		 * Include this element and its value only if you want to modify an existing checkout session with another invocation of ExecuteCheckoutOperationsRequest; for example, if you want the customer to edit his shipping address on PayPal.
		 * Character length and limitations: 20 single-byte characters
		 */
		private string TokenField;
		public string Token {
			get {
				return this.TokenField;
			}
			set {
				this.TokenField = value;
			}
		}

		/**
		 * All the Data required to initiate the checkout session is passed in this element.
		 */
		private SetDataRequestType SetDataRequestField;
		public SetDataRequestType SetDataRequest {
			get {
				return this.SetDataRequestField;
			}
			set {
				this.SetDataRequestField = value;
			}
		}

		/**
		 * If auto authorization is required, this should be passed in with IsRequested set to yes.
		 */
		private AuthorizationRequestType AuthorizationRequestField;
		public AuthorizationRequestType AuthorizationRequest {
			get {
				return this.AuthorizationRequestField;
			}
			set {
				this.AuthorizationRequestField = value;
			}
		}

		public ExecuteCheckoutOperationsRequestDetailsType(SetDataRequestType SetDataRequest) {
			this.SetDataRequest = SetDataRequest;
		}
		public ExecuteCheckoutOperationsRequestDetailsType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( Token != null ) {
			sb.Append("<ebl:Token>").Append(Token);
			sb.Append("</ebl:Token>");
		}
		if( SetDataRequest != null ) {
			sb.Append("<ebl:SetDataRequest>");
			sb.Append(SetDataRequest.toXMLString());
			sb.Append("</ebl:SetDataRequest>");
		}
		if( AuthorizationRequest != null ) {
			sb.Append("<ebl:AuthorizationRequest>");
			sb.Append(AuthorizationRequest.toXMLString());
			sb.Append("</ebl:AuthorizationRequest>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class ExecuteCheckoutOperationsRequestType :AbstractRequestType{

		private ExecuteCheckoutOperationsRequestDetailsType ExecuteCheckoutOperationsRequestDetailsField;
		public ExecuteCheckoutOperationsRequestDetailsType ExecuteCheckoutOperationsRequestDetails {
			get {
				return this.ExecuteCheckoutOperationsRequestDetailsField;
			}
			set {
				this.ExecuteCheckoutOperationsRequestDetailsField = value;
			}
		}

		public ExecuteCheckoutOperationsRequestType(ExecuteCheckoutOperationsRequestDetailsType ExecuteCheckoutOperationsRequestDetails) {
			this.ExecuteCheckoutOperationsRequestDetails = ExecuteCheckoutOperationsRequestDetails;
		}
		public ExecuteCheckoutOperationsRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( ExecuteCheckoutOperationsRequestDetails != null ) {
			sb.Append("<ebl:ExecuteCheckoutOperationsRequestDetails>");
			sb.Append(ExecuteCheckoutOperationsRequestDetails.toXMLString());
			sb.Append("</ebl:ExecuteCheckoutOperationsRequestDetails>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class ExecuteCheckoutOperationsResponseDetailsType {

		private SetDataResponseType SetDataResponseField;
		public SetDataResponseType SetDataResponse {
			get {
				return this.SetDataResponseField;
			}
			set {
				this.SetDataResponseField = value;
			}
		}

		private AuthorizationResponseType AuthorizationResponseField;
		public AuthorizationResponseType AuthorizationResponse {
			get {
				return this.AuthorizationResponseField;
			}
			set {
				this.AuthorizationResponseField = value;
			}
		}

	 public ExecuteCheckoutOperationsResponseDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("SetDataResponse").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SetDataResponse")[0])){ 
		 nodeList = document.GetElementsByTagName("SetDataResponse");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.SetDataResponse =  new SetDataResponseType(xmlString);

}
	}
		 if(document.GetElementsByTagName("AuthorizationResponse").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AuthorizationResponse")[0])){ 
		 nodeList = document.GetElementsByTagName("AuthorizationResponse");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.AuthorizationResponse =  new AuthorizationResponseType(xmlString);

}
	}
	}
	}


	/**
	 */
	public partial class ExecuteCheckoutOperationsResponseType :AbstractResponseType{

		private ExecuteCheckoutOperationsResponseDetailsType ExecuteCheckoutOperationsResponseDetailsField;
		public ExecuteCheckoutOperationsResponseDetailsType ExecuteCheckoutOperationsResponseDetails {
			get {
				return this.ExecuteCheckoutOperationsResponseDetailsField;
			}
			set {
				this.ExecuteCheckoutOperationsResponseDetailsField = value;
			}
		}

	 public ExecuteCheckoutOperationsResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("ExecuteCheckoutOperationsResponseDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ExecuteCheckoutOperationsResponseDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("ExecuteCheckoutOperationsResponseDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.ExecuteCheckoutOperationsResponseDetails =  new ExecuteCheckoutOperationsResponseDetailsType(xmlString);

}
	}
	}
	}


	/**
	 * Contains elements that allow tracking for an external partner.
	 */
	public partial class ExternalPartnerTrackingDetailsType {

		/**
		 * PayPal will just log this string. There will NOT be any business logic around it, nor any decisions made based on the value of the string that is passed in.
		 * From a tracking/analytical perspective, PayPal would not infer any meaning to any specific value.
		 * We would just segment the traffic based on the value passed (Cart and None as an example) and track different
		 * metrics like risk/conversion etc based on these segments.
		 * The external partner would control the value of what gets passed and we take that value as is and generate data based on it. 
		 * Optional 
		 */
		private string ExternalPartnerSegmentIDField;
		public string ExternalPartnerSegmentID {
			get {
				return this.ExternalPartnerSegmentIDField;
			}
			set {
				this.ExternalPartnerSegmentIDField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( ExternalPartnerSegmentID != null ) {
			sb.Append("<ebl:ExternalPartnerSegmentID>").Append(ExternalPartnerSegmentID);
			sb.Append("</ebl:ExternalPartnerSegmentID>");
		}
		return sb.ToString();
	}

	}


	/**
	 * This element contains information that allows the merchant to request to
	 * opt into external remember me on behalf of the buyer or to request login
	 * bypass using external remember me.
	 */
	public partial class ExternalRememberMeOptInDetailsType {

		/**
		 * 1 = opt in to external remember me.
		 * 0 or omitted = no opt-in
		 * Other values are invalid
		 */
		private string ExternalRememberMeOptInField;
		public string ExternalRememberMeOptIn {
			get {
				return this.ExternalRememberMeOptInField;
			}
			set {
				this.ExternalRememberMeOptInField = value;
			}
		}

		/**
		 * E-mail address or secure merchant account ID of merchant to associate with new external remember-me. Currently,
		 * the owner must be either the API actor or omitted/none.  In the future, we may allow the owner to be a 3rd party
		 * merchant account.
		 */
		private ExternalRememberMeOwnerDetailsType ExternalRememberMeOwnerDetailsField;
		public ExternalRememberMeOwnerDetailsType ExternalRememberMeOwnerDetails {
			get {
				return this.ExternalRememberMeOwnerDetailsField;
			}
			set {
				this.ExternalRememberMeOwnerDetailsField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( ExternalRememberMeOptIn != null ) {
			sb.Append("<ebl:ExternalRememberMeOptIn>").Append(ExternalRememberMeOptIn);
			sb.Append("</ebl:ExternalRememberMeOptIn>");
		}
		if( ExternalRememberMeOwnerDetails != null ) {
			sb.Append("<ebl:ExternalRememberMeOwnerDetails>");
			sb.Append(ExternalRememberMeOwnerDetails.toXMLString());
			sb.Append("</ebl:ExternalRememberMeOwnerDetails>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class ExternalRememberMeOptOutReq {

		private ExternalRememberMeOptOutRequestType ExternalRememberMeOptOutRequestField;
		public ExternalRememberMeOptOutRequestType ExternalRememberMeOptOutRequest {
			get {
				return this.ExternalRememberMeOptOutRequestField;
			}
			set {
				this.ExternalRememberMeOptOutRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:ExternalRememberMeOptOutReq>");
		if( ExternalRememberMeOptOutRequest != null ) {
			sb.Append("<urn:ExternalRememberMeOptOutRequest>");
			sb.Append(ExternalRememberMeOptOutRequest.toXMLString());
			sb.Append("</urn:ExternalRememberMeOptOutRequest>");
		}
sb.Append("</urn:ExternalRememberMeOptOutReq>");
		return sb.ToString();
	}

	}


	/**
	 * The merchant passes in the ExternalRememberMeID to identify the user to opt out.  This is a 17-character
	 * alphanumeric (encrypted) string that identifies the buyer's remembered login with a merchant and has
	 * meaning only to the merchant.
	 * Required
	 */
	public partial class ExternalRememberMeOptOutRequestType :AbstractRequestType{

		/**
		 * The merchant passes in the ExternalRememberMeID to identify the user to opt out.  This is a 17-character
		 * alphanumeric (encrypted) string that identifies the buyer's remembered login with a merchant and has
		 * meaning only to the merchant.
		 * Required
		 */
		private string ExternalRememberMeIDField;
		public string ExternalRememberMeID {
			get {
				return this.ExternalRememberMeIDField;
			}
			set {
				this.ExternalRememberMeIDField = value;
			}
		}

		/**
		 * E-mail address or secure merchant account ID of merchant to associate with
		 * external remember-me.
		 */
		private ExternalRememberMeOwnerDetailsType ExternalRememberMeOwnerDetailsField;
		public ExternalRememberMeOwnerDetailsType ExternalRememberMeOwnerDetails {
			get {
				return this.ExternalRememberMeOwnerDetailsField;
			}
			set {
				this.ExternalRememberMeOwnerDetailsField = value;
			}
		}

		public ExternalRememberMeOptOutRequestType(string ExternalRememberMeID) {
			this.ExternalRememberMeID = ExternalRememberMeID;
		}
		public ExternalRememberMeOptOutRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( ExternalRememberMeID != null ) {
			sb.Append("<urn:ExternalRememberMeID>").Append(ExternalRememberMeID);
			sb.Append("</urn:ExternalRememberMeID>");
		}
		if( ExternalRememberMeOwnerDetails != null ) {
			sb.Append("<urn:ExternalRememberMeOwnerDetails>");
			sb.Append(ExternalRememberMeOwnerDetails.toXMLString());
			sb.Append("</urn:ExternalRememberMeOwnerDetails>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class ExternalRememberMeOptOutResponseType :AbstractResponseType{

	 public ExternalRememberMeOptOutResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
	}
	}


	/**
	 * E-mail address or secure merchant account ID of merchant to associate with new external remember-me.
	 */
	public partial class ExternalRememberMeOwnerDetailsType {

		/**
		 * A discriminant that tells SetEC what kind of data the ExternalRememberMeOwnerID parameter contains.
		 * Currently, the owner must be either the API actor or omitted/none.  In the future, we may allow the
		 * owner to be a 3rd party merchant account.
		 * Possible values are:
		 * None, ignore the ExternalRememberMeOwnerID.  An empty value for this field also signifies None.
		 * Email, the owner ID is an email address
		 * SecureMerchantAccountID, the owner id is a string representing the secure merchant account ID
		 */
		private string ExternalRememberMeOwnerIDTypeField;
		public string ExternalRememberMeOwnerIDType {
			get {
				return this.ExternalRememberMeOwnerIDTypeField;
			}
			set {
				this.ExternalRememberMeOwnerIDTypeField = value;
			}
		}

		/**
		 * When opting in to bypass login via remember me, this parameter specifies the merchant account
		 * associated with the remembered login.  Currentl, the owner must be either the API actor or omitted/none.
		 * In the future, we may allow the owner to be a 3rd party merchant account.
		 * If the Owner ID Type field is not present or "None", this parameter is ignored.
		 */
		private string ExternalRememberMeOwnerIDField;
		public string ExternalRememberMeOwnerID {
			get {
				return this.ExternalRememberMeOwnerIDField;
			}
			set {
				this.ExternalRememberMeOwnerIDField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( ExternalRememberMeOwnerIDType != null ) {
			sb.Append("<ebl:ExternalRememberMeOwnerIDType>").Append(ExternalRememberMeOwnerIDType);
			sb.Append("</ebl:ExternalRememberMeOwnerIDType>");
		}
		if( ExternalRememberMeOwnerID != null ) {
			sb.Append("<ebl:ExternalRememberMeOwnerID>").Append(ExternalRememberMeOwnerID);
			sb.Append("</ebl:ExternalRememberMeOwnerID>");
		}
		return sb.ToString();
	}

	}


	/**
	 * Response information resulting from opt-in operation or current login bypass status.
	 */
	public partial class ExternalRememberMeStatusDetailsType {

		/**
		 * Required field that reports status of opt-in or login bypass attempt.
		 * 0 = Success - successful opt-in or ExternalRememberMeID specified in SetExpressCheckout
		 * is valid.
		 * 1 = Invalid ID - ExternalRememberMeID specified in SetExpressCheckout is invalid.
		 * 2 = Internal Error - System error or outage during opt-in or login bypass.  Can retry
		 * opt-in or login bypass next time.  Flow will force full authentication and allow buyer
		 * to complete transaction.
		 * -1 = None - the return value does not signify any valid remember me status.
		 */
		private int? ExternalRememberMeStatusField;
		public int? ExternalRememberMeStatus {
			get {
				return this.ExternalRememberMeStatusField;
			}
			set {
				this.ExternalRememberMeStatusField = value;
			}
		}

		/**
		 * Identifier returned on external-remember-me-opt-in to allow the merchant to request
		 * bypass of PayPal login through external remember me on behalf of the buyer in future
		 * transactions.  The ExternalRememberMeID is a 17-character alphanumeric (encrypted)
		 * string.  This field has meaning only to the merchant.
		 */
		private string ExternalRememberMeIDField;
		public string ExternalRememberMeID {
			get {
				return this.ExternalRememberMeIDField;
			}
			set {
				this.ExternalRememberMeIDField = value;
			}
		}

	 public ExternalRememberMeStatusDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("ExternalRememberMeStatus").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ExternalRememberMeStatus")[0])){ 
		 this.ExternalRememberMeStatus =System.Convert.ToInt32(document.GetElementsByTagName("ExternalRememberMeStatus")[0].InnerText);

}
	}
		 if(document.GetElementsByTagName("ExternalRememberMeID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ExternalRememberMeID")[0])){ 
		 this.ExternalRememberMeID =(string)document.GetElementsByTagName("ExternalRememberMeID")[0].InnerText;

}
	}
	}
	}


	/**
	 * Thes are filters that could result in accept/deny/pending action.
	 */
	public partial class FMFDetailsType {

		private RiskFilterListType AcceptFiltersField;
		public RiskFilterListType AcceptFilters {
			get {
				return this.AcceptFiltersField;
			}
			set {
				this.AcceptFiltersField = value;
			}
		}

		private RiskFilterListType PendingFiltersField;
		public RiskFilterListType PendingFilters {
			get {
				return this.PendingFiltersField;
			}
			set {
				this.PendingFiltersField = value;
			}
		}

		private RiskFilterListType DenyFiltersField;
		public RiskFilterListType DenyFilters {
			get {
				return this.DenyFiltersField;
			}
			set {
				this.DenyFiltersField = value;
			}
		}

		private RiskFilterListType ReportFiltersField;
		public RiskFilterListType ReportFilters {
			get {
				return this.ReportFiltersField;
			}
			set {
				this.ReportFiltersField = value;
			}
		}

	 public FMFDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("AcceptFilters").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AcceptFilters")[0])){ 
		 nodeList = document.GetElementsByTagName("AcceptFilters");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.AcceptFilters =  new RiskFilterListType(xmlString);

}
	}
		 if(document.GetElementsByTagName("PendingFilters").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PendingFilters")[0])){ 
		 nodeList = document.GetElementsByTagName("PendingFilters");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.PendingFilters =  new RiskFilterListType(xmlString);

}
	}
		 if(document.GetElementsByTagName("DenyFilters").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("DenyFilters")[0])){ 
		 nodeList = document.GetElementsByTagName("DenyFilters");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.DenyFilters =  new RiskFilterListType(xmlString);

}
	}
		 if(document.GetElementsByTagName("ReportFilters").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ReportFilters")[0])){ 
		 nodeList = document.GetElementsByTagName("ReportFilters");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.ReportFilters =  new RiskFilterListType(xmlString);

}
	}
	}
	}


	public enum FMFPendingTransactionActionType {
[Description("Accept")]ACCEPT,
[Description("Deny")]DENY,
	}
	public enum FailedPaymentActionType {
[Description("CancelOnFailure")]CANCELONFAILURE,
[Description("ContinueOnFailure")]CONTINUEONFAILURE,
	}
	/**
	 * Details of leg information
	 */
	public partial class FlightDetailsType {

		private string ConjuctionTicketField;
		public string ConjuctionTicket {
			get {
				return this.ConjuctionTicketField;
			}
			set {
				this.ConjuctionTicketField = value;
			}
		}

		private string ExchangeTicketField;
		public string ExchangeTicket {
			get {
				return this.ExchangeTicketField;
			}
			set {
				this.ExchangeTicketField = value;
			}
		}

		private string CouponNumberField;
		public string CouponNumber {
			get {
				return this.CouponNumberField;
			}
			set {
				this.CouponNumberField = value;
			}
		}

		private string ServiceClassField;
		public string ServiceClass {
			get {
				return this.ServiceClassField;
			}
			set {
				this.ServiceClassField = value;
			}
		}

		private string TravelDateField;
		public string TravelDate {
			get {
				return this.TravelDateField;
			}
			set {
				this.TravelDateField = value;
			}
		}

		private string CarrierCodeField;
		public string CarrierCode {
			get {
				return this.CarrierCodeField;
			}
			set {
				this.CarrierCodeField = value;
			}
		}

		private string StopOverPermittedField;
		public string StopOverPermitted {
			get {
				return this.StopOverPermittedField;
			}
			set {
				this.StopOverPermittedField = value;
			}
		}

		private string DepartureAirportField;
		public string DepartureAirport {
			get {
				return this.DepartureAirportField;
			}
			set {
				this.DepartureAirportField = value;
			}
		}

		private string ArrivalAirportField;
		public string ArrivalAirport {
			get {
				return this.ArrivalAirportField;
			}
			set {
				this.ArrivalAirportField = value;
			}
		}

		private string FlightNumberField;
		public string FlightNumber {
			get {
				return this.FlightNumberField;
			}
			set {
				this.FlightNumberField = value;
			}
		}

		private string DepartureTimeField;
		public string DepartureTime {
			get {
				return this.DepartureTimeField;
			}
			set {
				this.DepartureTimeField = value;
			}
		}

		private string ArrivalTimeField;
		public string ArrivalTime {
			get {
				return this.ArrivalTimeField;
			}
			set {
				this.ArrivalTimeField = value;
			}
		}

		private string FareBasisCodeField;
		public string FareBasisCode {
			get {
				return this.FareBasisCodeField;
			}
			set {
				this.FareBasisCodeField = value;
			}
		}

		private BasicAmountType FareField;
		public BasicAmountType Fare {
			get {
				return this.FareField;
			}
			set {
				this.FareField = value;
			}
		}

		private BasicAmountType TaxesField;
		public BasicAmountType Taxes {
			get {
				return this.TaxesField;
			}
			set {
				this.TaxesField = value;
			}
		}

		private BasicAmountType FeeField;
		public BasicAmountType Fee {
			get {
				return this.FeeField;
			}
			set {
				this.FeeField = value;
			}
		}

		private string EndorsementOrRestrictionsField;
		public string EndorsementOrRestrictions {
			get {
				return this.EndorsementOrRestrictionsField;
			}
			set {
				this.EndorsementOrRestrictionsField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( ConjuctionTicket != null ) {
			sb.Append("<ebl:ConjuctionTicket>").Append(ConjuctionTicket);
			sb.Append("</ebl:ConjuctionTicket>");
		}
		if( ExchangeTicket != null ) {
			sb.Append("<ebl:ExchangeTicket>").Append(ExchangeTicket);
			sb.Append("</ebl:ExchangeTicket>");
		}
		if( CouponNumber != null ) {
			sb.Append("<ebl:CouponNumber>").Append(CouponNumber);
			sb.Append("</ebl:CouponNumber>");
		}
		if( ServiceClass != null ) {
			sb.Append("<ebl:ServiceClass>").Append(ServiceClass);
			sb.Append("</ebl:ServiceClass>");
		}
		if( TravelDate != null ) {
			sb.Append("<ebl:TravelDate>").Append(TravelDate);
			sb.Append("</ebl:TravelDate>");
		}
		if( CarrierCode != null ) {
			sb.Append("<ebl:CarrierCode>").Append(CarrierCode);
			sb.Append("</ebl:CarrierCode>");
		}
		if( StopOverPermitted != null ) {
			sb.Append("<ebl:StopOverPermitted>").Append(StopOverPermitted);
			sb.Append("</ebl:StopOverPermitted>");
		}
		if( DepartureAirport != null ) {
			sb.Append("<ebl:DepartureAirport>").Append(DepartureAirport);
			sb.Append("</ebl:DepartureAirport>");
		}
		if( ArrivalAirport != null ) {
			sb.Append("<ebl:ArrivalAirport>").Append(ArrivalAirport);
			sb.Append("</ebl:ArrivalAirport>");
		}
		if( FlightNumber != null ) {
			sb.Append("<ebl:FlightNumber>").Append(FlightNumber);
			sb.Append("</ebl:FlightNumber>");
		}
		if( DepartureTime != null ) {
			sb.Append("<ebl:DepartureTime>").Append(DepartureTime);
			sb.Append("</ebl:DepartureTime>");
		}
		if( ArrivalTime != null ) {
			sb.Append("<ebl:ArrivalTime>").Append(ArrivalTime);
			sb.Append("</ebl:ArrivalTime>");
		}
		if( FareBasisCode != null ) {
			sb.Append("<ebl:FareBasisCode>").Append(FareBasisCode);
			sb.Append("</ebl:FareBasisCode>");
		}
		if( Fare != null ) {
			sb.Append("<ebl:Fare ");
			sb.Append(Fare.toXMLString());
			sb.Append("</ebl:Fare>");
		}
		if( Taxes != null ) {
			sb.Append("<ebl:Taxes ");
			sb.Append(Taxes.toXMLString());
			sb.Append("</ebl:Taxes>");
		}
		if( Fee != null ) {
			sb.Append("<ebl:Fee ");
			sb.Append(Fee.toXMLString());
			sb.Append("</ebl:Fee>");
		}
		if( EndorsementOrRestrictions != null ) {
			sb.Append("<ebl:EndorsementOrRestrictions>").Append(EndorsementOrRestrictions);
			sb.Append("</ebl:EndorsementOrRestrictions>");
		}
		return sb.ToString();
	}

	}


	/**
	 * An optional set of values related to flow-specific details.
	 */
	public partial class FlowControlDetailsType {

		/**
		 * The URL to redirect to for an unpayable transaction.  This field is currently used only
		 * for the inline checkout flow.
		 */
		private string ErrorURLField;
		public string ErrorURL {
			get {
				return this.ErrorURLField;
			}
			set {
				this.ErrorURLField = value;
			}
		}

		/**
		 * The URL to redirect to after a user clicks the "Pay" or "Continue" button on the merchant's
		 * site.  This field is currently used only for the inline checkout flow.
		 */
		private string InContextReturnURLField;
		public string InContextReturnURL {
			get {
				return this.InContextReturnURLField;
			}
			set {
				this.InContextReturnURLField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( ErrorURL != null ) {
			sb.Append("<ebl:ErrorURL>").Append(ErrorURL);
			sb.Append("</ebl:ErrorURL>");
		}
		if( InContextReturnURL != null ) {
			sb.Append("<ebl:InContextReturnURL>").Append(InContextReturnURL);
			sb.Append("</ebl:InContextReturnURL>");
		}
		return sb.ToString();
	}

	}


	/**
	 * Allowable values: 0,1  
	 * The value 1 indicates that the customer can accept push funding, and 0 means they cannot.
	 * Optional
	 * Character length and limitations: One single-byte numeric character.
	 */
	public partial class FundingSourceDetailsType {

		/**
		 * Allowable values: 0,1  
		 * The value 1 indicates that the customer can accept push funding, and 0 means they cannot.
		 * Optional
		 * Character length and limitations: One single-byte numeric character.
		 */
		private string AllowPushFundingField;
		public string AllowPushFunding {
			get {
				return this.AllowPushFundingField;
			}
			set {
				this.AllowPushFundingField = value;
			}
		}

		/**
		 * Allowable values: ELV, CreditCard, ChinaUnionPay, BML 
		 * This element could be used to specify the perered funding option 
		 * for a guest users. It has effect only if LandingPage element is set to Billing. 
		 * Otherwise it will be ignored. 
		 */
		private UserSelectedFundingSourceType? UserSelectedFundingSourceField;
		public UserSelectedFundingSourceType? UserSelectedFundingSource {
			get {
				return this.UserSelectedFundingSourceField;
			}
			set {
				this.UserSelectedFundingSourceField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( AllowPushFunding != null ) {
			sb.Append("<ebl:AllowPushFunding>").Append(AllowPushFunding);
			sb.Append("</ebl:AllowPushFunding>");
		}
		if( UserSelectedFundingSource != null ) {
			sb.Append("<ebl:UserSelectedFundingSource>").Append(EnumUtils.getDescription(UserSelectedFundingSource));
			sb.Append("</ebl:UserSelectedFundingSource>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class GetAccessPermissionDetailsReq {

		private GetAccessPermissionDetailsRequestType GetAccessPermissionDetailsRequestField;
		public GetAccessPermissionDetailsRequestType GetAccessPermissionDetailsRequest {
			get {
				return this.GetAccessPermissionDetailsRequestField;
			}
			set {
				this.GetAccessPermissionDetailsRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:GetAccessPermissionDetailsReq>");
		if( GetAccessPermissionDetailsRequest != null ) {
			sb.Append("<urn:GetAccessPermissionDetailsRequest>");
			sb.Append(GetAccessPermissionDetailsRequest.toXMLString());
			sb.Append("</urn:GetAccessPermissionDetailsRequest>");
		}
sb.Append("</urn:GetAccessPermissionDetailsReq>");
		return sb.ToString();
	}

	}


	/**
A timestamped token, the value of which was returned by SetAuthFlowParam Response. 
	 * Required
	 * Character length and limitations: 20 single-byte characters
	 */
	public partial class GetAccessPermissionDetailsRequestType :AbstractRequestType{

		/**
A timestamped token, the value of which was returned by SetAuthFlowParam Response. 
		 * Required
		 * Character length and limitations: 20 single-byte characters
		 */
		private string TokenField;
		public string Token {
			get {
				return this.TokenField;
			}
			set {
				this.TokenField = value;
			}
		}

		public GetAccessPermissionDetailsRequestType(string Token) {
			this.Token = Token;
		}
		public GetAccessPermissionDetailsRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( Token != null ) {
			sb.Append("<urn:Token>").Append(Token);
			sb.Append("</urn:Token>");
		}
		return sb.ToString();
	}

	}


	/**
	 * The first name of the User.
	 * Character length and limitations: 127 single-byte alphanumeric characters
	 */
	public partial class GetAccessPermissionDetailsResponseDetailsType {

		/**
The first name of the User.
		 * Character length and limitations: 127 single-byte alphanumeric characters		 */
		private string FirstNameField;
		public string FirstName {
			get {
				return this.FirstNameField;
			}
			set {
				this.FirstNameField = value;
			}
		}

		/**
The Last name of the user.
		 * Character length and limitations: 127 single-byte alphanumeric characters
		 */
		private string LastNameField;
		public string LastName {
			get {
				return this.LastNameField;
			}
			set {
				this.LastNameField = value;
			}
		}

		/**
		 * The email address of the user.
		 * Character length and limitations: 256 single-byte alphanumeric characters.
		 */
		private string EmailField;
		public string Email {
			get {
				return this.EmailField;
			}
			set {
				this.EmailField = value;
			}
		}

		/**
		 * contains information about API Services
		 */
		private List<string> AccessPermissionNameField = new List<string>();
		public List<string> AccessPermissionName {
			get {
				return this.AccessPermissionNameField;
			}
			set {
				this.AccessPermissionNameField = value;
			}
		}

		/**
		 * contains information about API Services
		 */
		private List<string> AccessPermissionStatusField = new List<string>();
		public List<string> AccessPermissionStatus {
			get {
				return this.AccessPermissionStatusField;
			}
			set {
				this.AccessPermissionStatusField = value;
			}
		}

		/**
		 * Encrypted PayPal customer account identification number.
		 * Required
		 * Character length and limitations: 127 single-byte characters.
		 */
		private string PayerIDField;
		public string PayerID {
			get {
				return this.PayerIDField;
			}
			set {
				this.PayerIDField = value;
			}
		}

	 public GetAccessPermissionDetailsResponseDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("FirstName").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("FirstName")[0])){ 
		 this.FirstName =(string)document.GetElementsByTagName("FirstName")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("LastName").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("LastName")[0])){ 
		 this.LastName =(string)document.GetElementsByTagName("LastName")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Email").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Email")[0])){ 
		 this.Email =(string)document.GetElementsByTagName("Email")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("AccessPermissionName").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AccessPermissionName")[0])){ 
		 nodeList = document.GetElementsByTagName("AccessPermissionName");
		 for(int i=0; i<nodeList.Count; i++) {
			 string value = nodeList[i].InnerText; 
			 this.AccessPermissionName.Add(value);
		}

}
	}
		 if(document.GetElementsByTagName("AccessPermissionStatus").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AccessPermissionStatus")[0])){ 
		 nodeList = document.GetElementsByTagName("AccessPermissionStatus");
		 for(int i=0; i<nodeList.Count; i++) {
			 string value = nodeList[i].InnerText; 
			 this.AccessPermissionStatus.Add(value);
		}

}
	}
		 if(document.GetElementsByTagName("PayerID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PayerID")[0])){ 
		 this.PayerID =(string)document.GetElementsByTagName("PayerID")[0].InnerText;

}
	}
	}
	}


	/**
	 */
	public partial class GetAccessPermissionDetailsResponseType :AbstractResponseType{

		private GetAccessPermissionDetailsResponseDetailsType GetAccessPermissionDetailsResponseDetailsField;
		public GetAccessPermissionDetailsResponseDetailsType GetAccessPermissionDetailsResponseDetails {
			get {
				return this.GetAccessPermissionDetailsResponseDetailsField;
			}
			set {
				this.GetAccessPermissionDetailsResponseDetailsField = value;
			}
		}

	 public GetAccessPermissionDetailsResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("GetAccessPermissionDetailsResponseDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GetAccessPermissionDetailsResponseDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("GetAccessPermissionDetailsResponseDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.GetAccessPermissionDetailsResponseDetails =  new GetAccessPermissionDetailsResponseDetailsType(xmlString);

}
	}
	}
	}


	/**
	 */
	public partial class GetAuthDetailsReq {

		private GetAuthDetailsRequestType GetAuthDetailsRequestField;
		public GetAuthDetailsRequestType GetAuthDetailsRequest {
			get {
				return this.GetAuthDetailsRequestField;
			}
			set {
				this.GetAuthDetailsRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:GetAuthDetailsReq>");
		if( GetAuthDetailsRequest != null ) {
			sb.Append("<urn:GetAuthDetailsRequest>");
			sb.Append(GetAuthDetailsRequest.toXMLString());
			sb.Append("</urn:GetAuthDetailsRequest>");
		}
sb.Append("</urn:GetAuthDetailsReq>");
		return sb.ToString();
	}

	}


	/**
A timestamped token, the value of which was returned by SetAuthFlowParam Response. 
	 * Required
	 * Character length and limitations: 20 single-byte characters
	 */
	public partial class GetAuthDetailsRequestType :AbstractRequestType{

		/**
A timestamped token, the value of which was returned by SetAuthFlowParam Response. 
		 * Required
		 * Character length and limitations: 20 single-byte characters
		 */
		private string TokenField;
		public string Token {
			get {
				return this.TokenField;
			}
			set {
				this.TokenField = value;
			}
		}

		public GetAuthDetailsRequestType(string Token) {
			this.Token = Token;
		}
		public GetAuthDetailsRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( Token != null ) {
			sb.Append("<urn:Token>").Append(Token);
			sb.Append("</urn:Token>");
		}
		return sb.ToString();
	}

	}


	/**
	 * The first name of the User.
	 * Character length and limitations: 127 single-byte alphanumeric characters
	 */
	public partial class GetAuthDetailsResponseDetailsType {

		/**
The first name of the User.
		 * Character length and limitations: 127 single-byte alphanumeric characters		 */
		private string FirstNameField;
		public string FirstName {
			get {
				return this.FirstNameField;
			}
			set {
				this.FirstNameField = value;
			}
		}

		/**
The Last name of the user.
		 * Character length and limitations: 127 single-byte alphanumeric characters
		 */
		private string LastNameField;
		public string LastName {
			get {
				return this.LastNameField;
			}
			set {
				this.LastNameField = value;
			}
		}

		/**
		 * The email address of the user.
		 * Character length and limitations: 256 single-byte alphanumeric characters.
		 */
		private string EmailField;
		public string Email {
			get {
				return this.EmailField;
			}
			set {
				this.EmailField = value;
			}
		}

		/**
		 * Encrypted PayPal customer account identification number.
		 * Required
		 * Character length and limitations: 127 single-byte characters.
		 */
		private string PayerIDField;
		public string PayerID {
			get {
				return this.PayerIDField;
			}
			set {
				this.PayerIDField = value;
			}
		}

	 public GetAuthDetailsResponseDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("FirstName").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("FirstName")[0])){ 
		 this.FirstName =(string)document.GetElementsByTagName("FirstName")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("LastName").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("LastName")[0])){ 
		 this.LastName =(string)document.GetElementsByTagName("LastName")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Email").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Email")[0])){ 
		 this.Email =(string)document.GetElementsByTagName("Email")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("PayerID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PayerID")[0])){ 
		 this.PayerID =(string)document.GetElementsByTagName("PayerID")[0].InnerText;

}
	}
	}
	}


	/**
	 */
	public partial class GetAuthDetailsResponseType :AbstractResponseType{

		private GetAuthDetailsResponseDetailsType GetAuthDetailsResponseDetailsField;
		public GetAuthDetailsResponseDetailsType GetAuthDetailsResponseDetails {
			get {
				return this.GetAuthDetailsResponseDetailsField;
			}
			set {
				this.GetAuthDetailsResponseDetailsField = value;
			}
		}

	 public GetAuthDetailsResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("GetAuthDetailsResponseDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GetAuthDetailsResponseDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("GetAuthDetailsResponseDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.GetAuthDetailsResponseDetails =  new GetAuthDetailsResponseDetailsType(xmlString);

}
	}
	}
	}


	/**
	 */
	public partial class GetBalanceReq {

		private GetBalanceRequestType GetBalanceRequestField;
		public GetBalanceRequestType GetBalanceRequest {
			get {
				return this.GetBalanceRequestField;
			}
			set {
				this.GetBalanceRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:GetBalanceReq>");
		if( GetBalanceRequest != null ) {
			sb.Append("<urn:GetBalanceRequest>");
			sb.Append(GetBalanceRequest.toXMLString());
			sb.Append("</urn:GetBalanceRequest>");
		}
sb.Append("</urn:GetBalanceReq>");
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class GetBalanceRequestType :AbstractRequestType{

		private string ReturnAllCurrenciesField;
		public string ReturnAllCurrencies {
			get {
				return this.ReturnAllCurrenciesField;
			}
			set {
				this.ReturnAllCurrenciesField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( ReturnAllCurrencies != null ) {
			sb.Append("<urn:ReturnAllCurrencies>").Append(ReturnAllCurrencies);
			sb.Append("</urn:ReturnAllCurrencies>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class GetBalanceResponseType :AbstractResponseType{

		private BasicAmountType BalanceField;
		public BasicAmountType Balance {
			get {
				return this.BalanceField;
			}
			set {
				this.BalanceField = value;
			}
		}

		private string BalanceTimeStampField;
		public string BalanceTimeStamp {
			get {
				return this.BalanceTimeStampField;
			}
			set {
				this.BalanceTimeStampField = value;
			}
		}

		private List<BasicAmountType> BalanceHoldingsField = new List<BasicAmountType>();
		public List<BasicAmountType> BalanceHoldings {
			get {
				return this.BalanceHoldingsField;
			}
			set {
				this.BalanceHoldingsField = value;
			}
		}

	 public GetBalanceResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Balance").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Balance")[0])){ 
		 nodeList = document.GetElementsByTagName("Balance");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.Balance =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("BalanceTimeStamp").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BalanceTimeStamp")[0])){ 
		 this.BalanceTimeStamp =(string)document.GetElementsByTagName("BalanceTimeStamp")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("BalanceHoldings").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BalanceHoldings")[0])){ 
		 nodeList = document.GetElementsByTagName("BalanceHoldings");
		 for(int i=0; i<nodeList.Count; i++) {
			 xmlString = DeserializationUtils.convertToXML(nodeList[i]); 
				this.BalanceHoldings.Add(new BasicAmountType(xmlString));
			}

}
	}
	}
	}


	/**
	 */
	public partial class GetBillingAgreementCustomerDetailsReq {

		private GetBillingAgreementCustomerDetailsRequestType GetBillingAgreementCustomerDetailsRequestField;
		public GetBillingAgreementCustomerDetailsRequestType GetBillingAgreementCustomerDetailsRequest {
			get {
				return this.GetBillingAgreementCustomerDetailsRequestField;
			}
			set {
				this.GetBillingAgreementCustomerDetailsRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:GetBillingAgreementCustomerDetailsReq>");
		if( GetBillingAgreementCustomerDetailsRequest != null ) {
			sb.Append("<urn:GetBillingAgreementCustomerDetailsRequest>");
			sb.Append(GetBillingAgreementCustomerDetailsRequest.toXMLString());
			sb.Append("</urn:GetBillingAgreementCustomerDetailsRequest>");
		}
sb.Append("</urn:GetBillingAgreementCustomerDetailsReq>");
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class GetBillingAgreementCustomerDetailsRequestType :AbstractRequestType{

		/**
		 */
		private string TokenField;
		public string Token {
			get {
				return this.TokenField;
			}
			set {
				this.TokenField = value;
			}
		}

		public GetBillingAgreementCustomerDetailsRequestType(string Token) {
			this.Token = Token;
		}
		public GetBillingAgreementCustomerDetailsRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( Token != null ) {
			sb.Append("<urn:Token>").Append(Token);
			sb.Append("</urn:Token>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class GetBillingAgreementCustomerDetailsResponseDetailsType {

		/**
		 */
		private PayerInfoType PayerInfoField;
		public PayerInfoType PayerInfo {
			get {
				return this.PayerInfoField;
			}
			set {
				this.PayerInfoField = value;
			}
		}

		/**
Customer's billing address.
		 * Optional
		 * If you have a credit card mapped in your PayPal account, PayPal returns the billing address of the credit billing address otherwise your primary address as billing address in GetBillingAgreementCustomerDetails.
		 */
		private AddressType BillingAddressField;
		public AddressType BillingAddress {
			get {
				return this.BillingAddressField;
			}
			set {
				this.BillingAddressField = value;
			}
		}

	 public GetBillingAgreementCustomerDetailsResponseDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("PayerInfo").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PayerInfo")[0])){ 
		 nodeList = document.GetElementsByTagName("PayerInfo");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.PayerInfo =  new PayerInfoType(xmlString);

}
	}
		 if(document.GetElementsByTagName("BillingAddress").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillingAddress")[0])){ 
		 nodeList = document.GetElementsByTagName("BillingAddress");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.BillingAddress =  new AddressType(xmlString);

}
	}
	}
	}


	/**
	 */
	public partial class GetBillingAgreementCustomerDetailsResponseType :AbstractResponseType{

		private GetBillingAgreementCustomerDetailsResponseDetailsType GetBillingAgreementCustomerDetailsResponseDetailsField;
		public GetBillingAgreementCustomerDetailsResponseDetailsType GetBillingAgreementCustomerDetailsResponseDetails {
			get {
				return this.GetBillingAgreementCustomerDetailsResponseDetailsField;
			}
			set {
				this.GetBillingAgreementCustomerDetailsResponseDetailsField = value;
			}
		}

	 public GetBillingAgreementCustomerDetailsResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("GetBillingAgreementCustomerDetailsResponseDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GetBillingAgreementCustomerDetailsResponseDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("GetBillingAgreementCustomerDetailsResponseDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.GetBillingAgreementCustomerDetailsResponseDetails =  new GetBillingAgreementCustomerDetailsResponseDetailsType(xmlString);

}
	}
	}
	}


	/**
	 */
	public partial class GetBoardingDetailsReq {

		private GetBoardingDetailsRequestType GetBoardingDetailsRequestField;
		public GetBoardingDetailsRequestType GetBoardingDetailsRequest {
			get {
				return this.GetBoardingDetailsRequestField;
			}
			set {
				this.GetBoardingDetailsRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:GetBoardingDetailsReq>");
		if( GetBoardingDetailsRequest != null ) {
			sb.Append("<urn:GetBoardingDetailsRequest>");
			sb.Append(GetBoardingDetailsRequest.toXMLString());
			sb.Append("</urn:GetBoardingDetailsRequest>");
		}
sb.Append("</urn:GetBoardingDetailsReq>");
		return sb.ToString();
	}

	}


	/**
	 * A unique token returned by the EnterBoarding API call that identifies this boarding session. 
	 * Required
	 * Character length and limitations: 64 alphanumeric characters. The token has the following format:
	 * OB-61characterstring	 */
	public partial class GetBoardingDetailsRequestType :AbstractRequestType{

		/**
		 * A unique token returned by the EnterBoarding API call that identifies this boarding session. 
		 * Required
		 * Character length and limitations: 64 alphanumeric characters. The token has the following format:
		 * OB-61characterstring		 */
		private string TokenField;
		public string Token {
			get {
				return this.TokenField;
			}
			set {
				this.TokenField = value;
			}
		}

		public GetBoardingDetailsRequestType(string Token) {
			this.Token = Token;
		}
		public GetBoardingDetailsRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( Token != null ) {
			sb.Append("<urn:Token>").Append(Token);
			sb.Append("</urn:Token>");
		}
		return sb.ToString();
	}

	}


	/**
	 * Status of merchant's onboarding process:
	 * Completed
Cancelled
Pending
	 * Character length and limitations: Eight alphabetic characters
	 */
	public partial class GetBoardingDetailsResponseDetailsType {

		/**
		 * Status of merchant's onboarding process:
		 * Completed
Cancelled
Pending
		 * Character length and limitations: Eight alphabetic characters		 */
		private BoardingStatusType? StatusField;
		public BoardingStatusType? Status {
			get {
				return this.StatusField;
			}
			set {
				this.StatusField = value;
			}
		}

		/**
		 * Date the boarding process started		 */
		private string StartDateField;
		public string StartDate {
			get {
				return this.StartDateField;
			}
			set {
				this.StartDateField = value;
			}
		}

		/**
		 * Date the merchant’s status or progress was last updated		 */
		private string LastUpdatedField;
		public string LastUpdated {
			get {
				return this.LastUpdatedField;
			}
			set {
				this.LastUpdatedField = value;
			}
		}

		/**
		 * Reason for merchant’s cancellation of sign-up.
		 * Character length and limitations: 1,024 alphanumeric characters		 */
		private string ReasonField;
		public string Reason {
			get {
				return this.ReasonField;
			}
			set {
				this.ReasonField = value;
			}
		}

		private string ProgramNameField;
		public string ProgramName {
			get {
				return this.ProgramNameField;
			}
			set {
				this.ProgramNameField = value;
			}
		}

		private string ProgramCodeField;
		public string ProgramCode {
			get {
				return this.ProgramCodeField;
			}
			set {
				this.ProgramCodeField = value;
			}
		}

		private string CampaignIDField;
		public string CampaignID {
			get {
				return this.CampaignIDField;
			}
			set {
				this.CampaignIDField = value;
			}
		}

		/**
		 * Indicates if there is a limitation on the amount of money the business can withdraw from PayPal		 */
		private UserWithdrawalLimitTypeType? UserWithdrawalLimitField;
		public UserWithdrawalLimitTypeType? UserWithdrawalLimit {
			get {
				return this.UserWithdrawalLimitField;
			}
			set {
				this.UserWithdrawalLimitField = value;
			}
		}

		/**
		 * Custom information you set on the EnterBoarding API call
		 * Character length and limitations: 256 alphanumeric characters		 */
		private string PartnerCustomField;
		public string PartnerCustom {
			get {
				return this.PartnerCustomField;
			}
			set {
				this.PartnerCustomField = value;
			}
		}

		/**
		 * Details about the owner of the account		 */
		private PayerInfoType AccountOwnerField;
		public PayerInfoType AccountOwner {
			get {
				return this.AccountOwnerField;
			}
			set {
				this.AccountOwnerField = value;
			}
		}

		/**
		 * Merchant’s PayPal API credentials		 */
		private APICredentialsType CredentialsField;
		public APICredentialsType Credentials {
			get {
				return this.CredentialsField;
			}
			set {
				this.CredentialsField = value;
			}
		}

		/**
		 * The APIs that this merchant has granted the business partner permission to call on his behalf.
		 * For example:
		 * SetExpressCheckout,GetExpressCheckoutDetails,DoExpressCheckoutPayment
		 */
		private string ConfigureAPIsField;
		public string ConfigureAPIs {
			get {
				return this.ConfigureAPIsField;
			}
			set {
				this.ConfigureAPIsField = value;
			}
		}

		/**
		 * Primary email verification status. Confirmed, Unconfirmed		 */
		private string EmailVerificationStatusField;
		public string EmailVerificationStatus {
			get {
				return this.EmailVerificationStatusField;
			}
			set {
				this.EmailVerificationStatusField = value;
			}
		}

		/**
		 * Gives VettingStatus - Pending, Cancelled, Approved, UnderReview
		 * Character length and limitations: 256 alphanumeric characters		 */
		private string VettingStatusField;
		public string VettingStatus {
			get {
				return this.VettingStatusField;
			}
			set {
				this.VettingStatusField = value;
			}
		}

		/**
		 * Gives BankAccountVerificationStatus - Added, Confirmed
		 * Character length and limitations: 256 alphanumeric characters		 */
		private string BankAccountVerificationStatusField;
		public string BankAccountVerificationStatus {
			get {
				return this.BankAccountVerificationStatusField;
			}
			set {
				this.BankAccountVerificationStatusField = value;
			}
		}

	 public GetBoardingDetailsResponseDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Status").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Status")[0])){ 
		 this.Status = (BoardingStatusType)EnumUtils.getValue(document.GetElementsByTagName("Status")[0].InnerText,typeof(BoardingStatusType));

}
	}
		 if(document.GetElementsByTagName("StartDate").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("StartDate")[0])){ 
		 this.StartDate =(string)document.GetElementsByTagName("StartDate")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("LastUpdated").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("LastUpdated")[0])){ 
		 this.LastUpdated =(string)document.GetElementsByTagName("LastUpdated")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Reason").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Reason")[0])){ 
		 this.Reason =(string)document.GetElementsByTagName("Reason")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ProgramName").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ProgramName")[0])){ 
		 this.ProgramName =(string)document.GetElementsByTagName("ProgramName")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ProgramCode").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ProgramCode")[0])){ 
		 this.ProgramCode =(string)document.GetElementsByTagName("ProgramCode")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("CampaignID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CampaignID")[0])){ 
		 this.CampaignID =(string)document.GetElementsByTagName("CampaignID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("UserWithdrawalLimit").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("UserWithdrawalLimit")[0])){ 
		 this.UserWithdrawalLimit = (UserWithdrawalLimitTypeType)EnumUtils.getValue(document.GetElementsByTagName("UserWithdrawalLimit")[0].InnerText,typeof(UserWithdrawalLimitTypeType));

}
	}
		 if(document.GetElementsByTagName("PartnerCustom").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PartnerCustom")[0])){ 
		 this.PartnerCustom =(string)document.GetElementsByTagName("PartnerCustom")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("AccountOwner").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AccountOwner")[0])){ 
		 nodeList = document.GetElementsByTagName("AccountOwner");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.AccountOwner =  new PayerInfoType(xmlString);

}
	}
		 if(document.GetElementsByTagName("Credentials").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Credentials")[0])){ 
		 nodeList = document.GetElementsByTagName("Credentials");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.Credentials =  new APICredentialsType(xmlString);

}
	}
		 if(document.GetElementsByTagName("ConfigureAPIs").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ConfigureAPIs")[0])){ 
		 this.ConfigureAPIs =(string)document.GetElementsByTagName("ConfigureAPIs")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("EmailVerificationStatus").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("EmailVerificationStatus")[0])){ 
		 this.EmailVerificationStatus =(string)document.GetElementsByTagName("EmailVerificationStatus")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("VettingStatus").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("VettingStatus")[0])){ 
		 this.VettingStatus =(string)document.GetElementsByTagName("VettingStatus")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("BankAccountVerificationStatus").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BankAccountVerificationStatus")[0])){ 
		 this.BankAccountVerificationStatus =(string)document.GetElementsByTagName("BankAccountVerificationStatus")[0].InnerText;

}
	}
	}
	}


	/**
	 */
	public partial class GetBoardingDetailsResponseType :AbstractResponseType{

		private GetBoardingDetailsResponseDetailsType GetBoardingDetailsResponseDetailsField;
		public GetBoardingDetailsResponseDetailsType GetBoardingDetailsResponseDetails {
			get {
				return this.GetBoardingDetailsResponseDetailsField;
			}
			set {
				this.GetBoardingDetailsResponseDetailsField = value;
			}
		}

	 public GetBoardingDetailsResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("GetBoardingDetailsResponseDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GetBoardingDetailsResponseDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("GetBoardingDetailsResponseDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.GetBoardingDetailsResponseDetails =  new GetBoardingDetailsResponseDetailsType(xmlString);

}
	}
	}
	}


	/**
	 */
	public partial class GetExpressCheckoutDetailsReq {

		private GetExpressCheckoutDetailsRequestType GetExpressCheckoutDetailsRequestField;
		public GetExpressCheckoutDetailsRequestType GetExpressCheckoutDetailsRequest {
			get {
				return this.GetExpressCheckoutDetailsRequestField;
			}
			set {
				this.GetExpressCheckoutDetailsRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:GetExpressCheckoutDetailsReq>");
		if( GetExpressCheckoutDetailsRequest != null ) {
			sb.Append("<urn:GetExpressCheckoutDetailsRequest>");
			sb.Append(GetExpressCheckoutDetailsRequest.toXMLString());
			sb.Append("</urn:GetExpressCheckoutDetailsRequest>");
		}
sb.Append("</urn:GetExpressCheckoutDetailsReq>");
		return sb.ToString();
	}

	}


	/**
A timestamped token, the value of which was returned by SetExpressCheckoutResponse. 
	 * Required
	 * Character length and limitations: 20 single-byte characters
	 */
	public partial class GetExpressCheckoutDetailsRequestType :AbstractRequestType{

		/**
A timestamped token, the value of which was returned by SetExpressCheckoutResponse. 
		 * Required
		 * Character length and limitations: 20 single-byte characters
		 */
		private string TokenField;
		public string Token {
			get {
				return this.TokenField;
			}
			set {
				this.TokenField = value;
			}
		}

		public GetExpressCheckoutDetailsRequestType(string Token) {
			this.Token = Token;
		}
		public GetExpressCheckoutDetailsRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( Token != null ) {
			sb.Append("<urn:Token>").Append(Token);
			sb.Append("</urn:Token>");
		}
		return sb.ToString();
	}

	}


	/**
	 * The timestamped token value that was returned by SetExpressCheckoutResponse and passed on GetExpressCheckoutDetailsRequest. 
	 * Character length and limitations: 20 single-byte characters
	 */
	public partial class GetExpressCheckoutDetailsResponseDetailsType {

		/**
		 * The timestamped token value that was returned by SetExpressCheckoutResponse and passed on GetExpressCheckoutDetailsRequest. 
		 * Character length and limitations: 20 single-byte characters		 */
		private string TokenField;
		public string Token {
			get {
				return this.TokenField;
			}
			set {
				this.TokenField = value;
			}
		}

		/**
		 * Information about the payer		 */
		private PayerInfoType PayerInfoField;
		public PayerInfoType PayerInfo {
			get {
				return this.PayerInfoField;
			}
			set {
				this.PayerInfoField = value;
			}
		}

		/**
		 * A free-form field for your own use, as set by you in the Custom element of SetExpressCheckoutRequest. 
		 * Character length and limitations: 256 single-byte alphanumeric characters		 */
		private string CustomField;
		public string Custom {
			get {
				return this.CustomField;
			}
			set {
				this.CustomField = value;
			}
		}

		/**
		 * Your own invoice or tracking number, as set by you in the InvoiceID element of SetExpressCheckoutRequest. 
		 * Character length and limitations: 127 single-byte alphanumeric characters
		 */
		private string InvoiceIDField;
		public string InvoiceID {
			get {
				return this.InvoiceIDField;
			}
			set {
				this.InvoiceIDField = value;
			}
		}

		/**
		 * Payer's contact telephone number. PayPal returns a contact telephone number only if your Merchant account profile settings require that the buyer enter one.		 */
		private string ContactPhoneField;
		public string ContactPhone {
			get {
				return this.ContactPhoneField;
			}
			set {
				this.ContactPhoneField = value;
			}
		}

		/**
		 */
		private bool? BillingAgreementAcceptedStatusField;
		public bool? BillingAgreementAcceptedStatus {
			get {
				return this.BillingAgreementAcceptedStatusField;
			}
			set {
				this.BillingAgreementAcceptedStatusField = value;
			}
		}

		/**
		 */
		private string RedirectRequiredField;
		public string RedirectRequired {
			get {
				return this.RedirectRequiredField;
			}
			set {
				this.RedirectRequiredField = value;
			}
		}

		/**
Customer's billing address.
		 * Optional
		 * If you have credit card mapped in your account then billing address of the credit card is returned otherwise your primary address is returned , PayPal returns this address in GetExpressCheckoutDetailsResponse.
		 */
		private AddressType BillingAddressField;
		public AddressType BillingAddress {
			get {
				return this.BillingAddressField;
			}
			set {
				this.BillingAddressField = value;
			}
		}

		/**
		 * Text note entered by the buyer in PayPal flow.
		 */
		private string NoteField;
		public string Note {
			get {
				return this.NoteField;
			}
			set {
				this.NoteField = value;
			}
		}

		/**
		 * Returns the status of the EC checkout session.
		 * Values include 'PaymentActionNotInitiated', 'PaymentActionFailed', 'PaymentActionInProgress', 'PaymentCompleted'.
		 */
		private string CheckoutStatusField;
		public string CheckoutStatus {
			get {
				return this.CheckoutStatusField;
			}
			set {
				this.CheckoutStatusField = value;
			}
		}

		/**
		 * PayPal may offer a discount or gift certificate to the buyer, which will be represented by a negativeamount. If the buyer has a negative balance, PayPal will add that amount to the current charges, which will be represented as a positive amount.
		 */
		private BasicAmountType PayPalAdjustmentField;
		public BasicAmountType PayPalAdjustment {
			get {
				return this.PayPalAdjustmentField;
			}
			set {
				this.PayPalAdjustmentField = value;
			}
		}

		/**
		 * Information about the individual purchased items.
		 */
		private List<PaymentDetailsType> PaymentDetailsField = new List<PaymentDetailsType>();
		public List<PaymentDetailsType> PaymentDetails {
			get {
				return this.PaymentDetailsField;
			}
			set {
				this.PaymentDetailsField = value;
			}
		}

		/**
		 * Information about the user selected options.
		 */
		private UserSelectedOptionType UserSelectedOptionsField;
		public UserSelectedOptionType UserSelectedOptions {
			get {
				return this.UserSelectedOptionsField;
			}
			set {
				this.UserSelectedOptionsField = value;
			}
		}

		/**
		 * Information about the incentives that were applied from Ebay RYP page and PayPal RYP page.
		 */
		private List<IncentiveDetailsType> IncentiveDetailsField = new List<IncentiveDetailsType>();
		public List<IncentiveDetailsType> IncentiveDetails {
			get {
				return this.IncentiveDetailsField;
			}
			set {
				this.IncentiveDetailsField = value;
			}
		}

		/**
		 * Information about the Gift message.
		 */
		private string GiftMessageField;
		public string GiftMessage {
			get {
				return this.GiftMessageField;
			}
			set {
				this.GiftMessageField = value;
			}
		}

		/**
		 * Information about the Gift receipt enable.
		 */
		private string GiftReceiptEnableField;
		public string GiftReceiptEnable {
			get {
				return this.GiftReceiptEnableField;
			}
			set {
				this.GiftReceiptEnableField = value;
			}
		}

		/**
		 * Information about the Gift Wrap name.
		 */
		private string GiftWrapNameField;
		public string GiftWrapName {
			get {
				return this.GiftWrapNameField;
			}
			set {
				this.GiftWrapNameField = value;
			}
		}

		/**
		 * Information about the Gift Wrap amount.
		 */
		private BasicAmountType GiftWrapAmountField;
		public BasicAmountType GiftWrapAmount {
			get {
				return this.GiftWrapAmountField;
			}
			set {
				this.GiftWrapAmountField = value;
			}
		}

		/**
		 * Information about the Buyer marketing email.
		 */
		private string BuyerMarketingEmailField;
		public string BuyerMarketingEmail {
			get {
				return this.BuyerMarketingEmailField;
			}
			set {
				this.BuyerMarketingEmailField = value;
			}
		}

		/**
		 * Information about the survey question.
		 */
		private string SurveyQuestionField;
		public string SurveyQuestion {
			get {
				return this.SurveyQuestionField;
			}
			set {
				this.SurveyQuestionField = value;
			}
		}

		/**
		 * Information about the survey choice selected by the user.
		 */
		private List<string> SurveyChoiceSelectedField = new List<string>();
		public List<string> SurveyChoiceSelected {
			get {
				return this.SurveyChoiceSelectedField;
			}
			set {
				this.SurveyChoiceSelectedField = value;
			}
		}

		/**
		 * Contains payment request information about each bucket in the cart.
		 */
		private List<PaymentRequestInfoType> PaymentRequestInfoField = new List<PaymentRequestInfoType>();
		public List<PaymentRequestInfoType> PaymentRequestInfo {
			get {
				return this.PaymentRequestInfoField;
			}
			set {
				this.PaymentRequestInfoField = value;
			}
		}

		/**
		 * Response information resulting from opt-in operation or current login bypass status.
		 */
		private ExternalRememberMeStatusDetailsType ExternalRememberMeStatusDetailsField;
		public ExternalRememberMeStatusDetailsType ExternalRememberMeStatusDetails {
			get {
				return this.ExternalRememberMeStatusDetailsField;
			}
			set {
				this.ExternalRememberMeStatusDetailsField = value;
			}
		}

	 public GetExpressCheckoutDetailsResponseDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Token").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Token")[0])){ 
		 this.Token =(string)document.GetElementsByTagName("Token")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("PayerInfo").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PayerInfo")[0])){ 
		 nodeList = document.GetElementsByTagName("PayerInfo");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.PayerInfo =  new PayerInfoType(xmlString);

}
	}
		 if(document.GetElementsByTagName("Custom").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Custom")[0])){ 
		 this.Custom =(string)document.GetElementsByTagName("Custom")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("InvoiceID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("InvoiceID")[0])){ 
		 this.InvoiceID =(string)document.GetElementsByTagName("InvoiceID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ContactPhone").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ContactPhone")[0])){ 
		 this.ContactPhone =(string)document.GetElementsByTagName("ContactPhone")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("BillingAgreementAcceptedStatus").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillingAgreementAcceptedStatus")[0])){ 
		 this.BillingAgreementAcceptedStatus =System.Convert.ToBoolean(document.GetElementsByTagName("BillingAgreementAcceptedStatus")[0].InnerText);

}
	}
		 if(document.GetElementsByTagName("RedirectRequired").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("RedirectRequired")[0])){ 
		 this.RedirectRequired =(string)document.GetElementsByTagName("RedirectRequired")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("BillingAddress").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillingAddress")[0])){ 
		 nodeList = document.GetElementsByTagName("BillingAddress");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.BillingAddress =  new AddressType(xmlString);

}
	}
		 if(document.GetElementsByTagName("Note").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Note")[0])){ 
		 this.Note =(string)document.GetElementsByTagName("Note")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("CheckoutStatus").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CheckoutStatus")[0])){ 
		 this.CheckoutStatus =(string)document.GetElementsByTagName("CheckoutStatus")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("PayPalAdjustment").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PayPalAdjustment")[0])){ 
		 nodeList = document.GetElementsByTagName("PayPalAdjustment");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.PayPalAdjustment =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("PaymentDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("PaymentDetails");
		 for(int i=0; i<nodeList.Count; i++) {
			 xmlString = DeserializationUtils.convertToXML(nodeList[i]); 
				this.PaymentDetails.Add(new PaymentDetailsType(xmlString));
			}

}
	}
		 if(document.GetElementsByTagName("UserSelectedOptions").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("UserSelectedOptions")[0])){ 
		 nodeList = document.GetElementsByTagName("UserSelectedOptions");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.UserSelectedOptions =  new UserSelectedOptionType(xmlString);

}
	}
		 if(document.GetElementsByTagName("IncentiveDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("IncentiveDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("IncentiveDetails");
		 for(int i=0; i<nodeList.Count; i++) {
			 xmlString = DeserializationUtils.convertToXML(nodeList[i]); 
				this.IncentiveDetails.Add(new IncentiveDetailsType(xmlString));
			}

}
	}
		 if(document.GetElementsByTagName("GiftMessage").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GiftMessage")[0])){ 
		 this.GiftMessage =(string)document.GetElementsByTagName("GiftMessage")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("GiftReceiptEnable").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GiftReceiptEnable")[0])){ 
		 this.GiftReceiptEnable =(string)document.GetElementsByTagName("GiftReceiptEnable")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("GiftWrapName").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GiftWrapName")[0])){ 
		 this.GiftWrapName =(string)document.GetElementsByTagName("GiftWrapName")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("GiftWrapAmount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GiftWrapAmount")[0])){ 
		 nodeList = document.GetElementsByTagName("GiftWrapAmount");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.GiftWrapAmount =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("BuyerMarketingEmail").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BuyerMarketingEmail")[0])){ 
		 this.BuyerMarketingEmail =(string)document.GetElementsByTagName("BuyerMarketingEmail")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("SurveyQuestion").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SurveyQuestion")[0])){ 
		 this.SurveyQuestion =(string)document.GetElementsByTagName("SurveyQuestion")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("SurveyChoiceSelected").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SurveyChoiceSelected")[0])){ 
		 nodeList = document.GetElementsByTagName("SurveyChoiceSelected");
		 for(int i=0; i<nodeList.Count; i++) {
			 string value = nodeList[i].InnerText; 
			 this.SurveyChoiceSelected.Add(value);
		}

}
	}
		 if(document.GetElementsByTagName("PaymentRequestInfo").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentRequestInfo")[0])){ 
		 nodeList = document.GetElementsByTagName("PaymentRequestInfo");
		 for(int i=0; i<nodeList.Count; i++) {
			 xmlString = DeserializationUtils.convertToXML(nodeList[i]); 
				this.PaymentRequestInfo.Add(new PaymentRequestInfoType(xmlString));
			}

}
	}
		 if(document.GetElementsByTagName("ExternalRememberMeStatusDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ExternalRememberMeStatusDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("ExternalRememberMeStatusDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.ExternalRememberMeStatusDetails =  new ExternalRememberMeStatusDetailsType(xmlString);

}
	}
	}
	}


	/**
	 */
	public partial class GetExpressCheckoutDetailsResponseType :AbstractResponseType{

		private GetExpressCheckoutDetailsResponseDetailsType GetExpressCheckoutDetailsResponseDetailsField;
		public GetExpressCheckoutDetailsResponseDetailsType GetExpressCheckoutDetailsResponseDetails {
			get {
				return this.GetExpressCheckoutDetailsResponseDetailsField;
			}
			set {
				this.GetExpressCheckoutDetailsResponseDetailsField = value;
			}
		}

	 public GetExpressCheckoutDetailsResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("GetExpressCheckoutDetailsResponseDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GetExpressCheckoutDetailsResponseDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("GetExpressCheckoutDetailsResponseDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.GetExpressCheckoutDetailsResponseDetails =  new GetExpressCheckoutDetailsResponseDetailsType(xmlString);

}
	}
	}
	}


	/**
	 */
	public partial class GetIncentiveEvaluationReq {

		private GetIncentiveEvaluationRequestType GetIncentiveEvaluationRequestField;
		public GetIncentiveEvaluationRequestType GetIncentiveEvaluationRequest {
			get {
				return this.GetIncentiveEvaluationRequestField;
			}
			set {
				this.GetIncentiveEvaluationRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:GetIncentiveEvaluationReq>");
		if( GetIncentiveEvaluationRequest != null ) {
			sb.Append("<urn:GetIncentiveEvaluationRequest>");
			sb.Append(GetIncentiveEvaluationRequest.toXMLString());
			sb.Append("</urn:GetIncentiveEvaluationRequest>");
		}
sb.Append("</urn:GetIncentiveEvaluationReq>");
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class GetIncentiveEvaluationRequestDetailsType {

		private string ExternalBuyerIdField;
		public string ExternalBuyerId {
			get {
				return this.ExternalBuyerIdField;
			}
			set {
				this.ExternalBuyerIdField = value;
			}
		}

		private List<string> IncentiveCodesField = new List<string>();
		public List<string> IncentiveCodes {
			get {
				return this.IncentiveCodesField;
			}
			set {
				this.IncentiveCodesField = value;
			}
		}

		private List<IncentiveApplyIndicationType> ApplyIndicationField = new List<IncentiveApplyIndicationType>();
		public List<IncentiveApplyIndicationType> ApplyIndication {
			get {
				return this.ApplyIndicationField;
			}
			set {
				this.ApplyIndicationField = value;
			}
		}

		private List<IncentiveBucketType> BucketsField = new List<IncentiveBucketType>();
		public List<IncentiveBucketType> Buckets {
			get {
				return this.BucketsField;
			}
			set {
				this.BucketsField = value;
			}
		}

		private BasicAmountType CartTotalAmtField;
		public BasicAmountType CartTotalAmt {
			get {
				return this.CartTotalAmtField;
			}
			set {
				this.CartTotalAmtField = value;
			}
		}

		private IncentiveRequestDetailsType RequestDetailsField;
		public IncentiveRequestDetailsType RequestDetails {
			get {
				return this.RequestDetailsField;
			}
			set {
				this.RequestDetailsField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( ExternalBuyerId != null ) {
			sb.Append("<ebl:ExternalBuyerId>").Append(ExternalBuyerId);
			sb.Append("</ebl:ExternalBuyerId>");
		}
		if( IncentiveCodes != null ) {
			for(int i=0; i<IncentiveCodes.Count; i++) {
				sb.Append("<ebl:IncentiveCodes>").Append(IncentiveCodes[i]);
				sb.Append("</ebl:IncentiveCodes>");
			}
		}
		if( ApplyIndication != null ) {
			for(int i=0; i<ApplyIndication.Count; i++) {
				sb.Append("<ebl:ApplyIndication>");
				sb.Append(ApplyIndication[i].toXMLString());
				sb.Append("</ebl:ApplyIndication>");
			}
		}
		if( Buckets != null ) {
			for(int i=0; i<Buckets.Count; i++) {
				sb.Append("<ebl:Buckets>");
				sb.Append(Buckets[i].toXMLString());
				sb.Append("</ebl:Buckets>");
			}
		}
		if( CartTotalAmt != null ) {
			sb.Append("<ebl:CartTotalAmt ");
			sb.Append(CartTotalAmt.toXMLString());
			sb.Append("</ebl:CartTotalAmt>");
		}
		if( RequestDetails != null ) {
			sb.Append("<ebl:RequestDetails>");
			sb.Append(RequestDetails.toXMLString());
			sb.Append("</ebl:RequestDetails>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class GetIncentiveEvaluationRequestType :AbstractRequestType{

		private GetIncentiveEvaluationRequestDetailsType GetIncentiveEvaluationRequestDetailsField;
		public GetIncentiveEvaluationRequestDetailsType GetIncentiveEvaluationRequestDetails {
			get {
				return this.GetIncentiveEvaluationRequestDetailsField;
			}
			set {
				this.GetIncentiveEvaluationRequestDetailsField = value;
			}
		}

		public GetIncentiveEvaluationRequestType(GetIncentiveEvaluationRequestDetailsType GetIncentiveEvaluationRequestDetails) {
			this.GetIncentiveEvaluationRequestDetails = GetIncentiveEvaluationRequestDetails;
		}
		public GetIncentiveEvaluationRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( GetIncentiveEvaluationRequestDetails != null ) {
			sb.Append("<ebl:GetIncentiveEvaluationRequestDetails>");
			sb.Append(GetIncentiveEvaluationRequestDetails.toXMLString());
			sb.Append("</ebl:GetIncentiveEvaluationRequestDetails>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class GetIncentiveEvaluationResponseDetailsType {

		private List<IncentiveDetailType> IncentiveDetailsField = new List<IncentiveDetailType>();
		public List<IncentiveDetailType> IncentiveDetails {
			get {
				return this.IncentiveDetailsField;
			}
			set {
				this.IncentiveDetailsField = value;
			}
		}

		private string RequestIdField;
		public string RequestId {
			get {
				return this.RequestIdField;
			}
			set {
				this.RequestIdField = value;
			}
		}

	 public GetIncentiveEvaluationResponseDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("IncentiveDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("IncentiveDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("IncentiveDetails");
		 for(int i=0; i<nodeList.Count; i++) {
			 xmlString = DeserializationUtils.convertToXML(nodeList[i]); 
				this.IncentiveDetails.Add(new IncentiveDetailType(xmlString));
			}

}
	}
		 if(document.GetElementsByTagName("RequestId").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("RequestId")[0])){ 
		 this.RequestId =(string)document.GetElementsByTagName("RequestId")[0].InnerText;

}
	}
	}
	}


	/**
	 */
	public partial class GetIncentiveEvaluationResponseType :AbstractResponseType{

		private GetIncentiveEvaluationResponseDetailsType GetIncentiveEvaluationResponseDetailsField;
		public GetIncentiveEvaluationResponseDetailsType GetIncentiveEvaluationResponseDetails {
			get {
				return this.GetIncentiveEvaluationResponseDetailsField;
			}
			set {
				this.GetIncentiveEvaluationResponseDetailsField = value;
			}
		}

	 public GetIncentiveEvaluationResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("GetIncentiveEvaluationResponseDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GetIncentiveEvaluationResponseDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("GetIncentiveEvaluationResponseDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.GetIncentiveEvaluationResponseDetails =  new GetIncentiveEvaluationResponseDetailsType(xmlString);

}
	}
	}
	}


	/**
	 */
	public partial class GetMobileStatusReq {

		private GetMobileStatusRequestType GetMobileStatusRequestField;
		public GetMobileStatusRequestType GetMobileStatusRequest {
			get {
				return this.GetMobileStatusRequestField;
			}
			set {
				this.GetMobileStatusRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:GetMobileStatusReq>");
		if( GetMobileStatusRequest != null ) {
			sb.Append("<urn:GetMobileStatusRequest>");
			sb.Append(GetMobileStatusRequest.toXMLString());
			sb.Append("</urn:GetMobileStatusRequest>");
		}
sb.Append("</urn:GetMobileStatusReq>");
		return sb.ToString();
	}

	}


	/**
	 * Phone number for status inquiry 
	 */
	public partial class GetMobileStatusRequestDetailsType {

		/**
Phone number for status inquiry 		 */
		private PhoneNumberType PhoneField;
		public PhoneNumberType Phone {
			get {
				return this.PhoneField;
			}
			set {
				this.PhoneField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( Phone != null ) {
			sb.Append("<ebl:Phone>");
			sb.Append(Phone.toXMLString());
			sb.Append("</ebl:Phone>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class GetMobileStatusRequestType :AbstractRequestType{

		private GetMobileStatusRequestDetailsType GetMobileStatusRequestDetailsField;
		public GetMobileStatusRequestDetailsType GetMobileStatusRequestDetails {
			get {
				return this.GetMobileStatusRequestDetailsField;
			}
			set {
				this.GetMobileStatusRequestDetailsField = value;
			}
		}

		public GetMobileStatusRequestType(GetMobileStatusRequestDetailsType GetMobileStatusRequestDetails) {
			this.GetMobileStatusRequestDetails = GetMobileStatusRequestDetails;
		}
		public GetMobileStatusRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( GetMobileStatusRequestDetails != null ) {
			sb.Append("<ebl:GetMobileStatusRequestDetails>");
			sb.Append(GetMobileStatusRequestDetails.toXMLString());
			sb.Append("</ebl:GetMobileStatusRequestDetails>");
		}
		return sb.ToString();
	}

	}


	/**
	 * Indicates whether the phone is activated for mobile payments
	 */
	public partial class GetMobileStatusResponseType :AbstractResponseType{

		/**
Indicates whether the phone is activated for mobile payments
		 */
		private int? IsActivatedField;
		public int? IsActivated {
			get {
				return this.IsActivatedField;
			}
			set {
				this.IsActivatedField = value;
			}
		}

		/**
Indicates whether there is a payment pending from the phone
		 */
		private int? PaymentPendingField;
		public int? PaymentPending {
			get {
				return this.PaymentPendingField;
			}
			set {
				this.PaymentPendingField = value;
			}
		}

	 public GetMobileStatusResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("IsActivated").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("IsActivated")[0])){ 
		 this.IsActivated =System.Convert.ToInt32(document.GetElementsByTagName("IsActivated")[0].InnerText);

}
	}
		 if(document.GetElementsByTagName("PaymentPending").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentPending")[0])){ 
		 this.PaymentPending =System.Convert.ToInt32(document.GetElementsByTagName("PaymentPending")[0].InnerText);

}
	}
	}
	}


	/**
	 */
	public partial class GetPalDetailsReq {

		private GetPalDetailsRequestType GetPalDetailsRequestField;
		public GetPalDetailsRequestType GetPalDetailsRequest {
			get {
				return this.GetPalDetailsRequestField;
			}
			set {
				this.GetPalDetailsRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:GetPalDetailsReq>");
		if( GetPalDetailsRequest != null ) {
			sb.Append("<urn:GetPalDetailsRequest>");
			sb.Append(GetPalDetailsRequest.toXMLString());
			sb.Append("</urn:GetPalDetailsRequest>");
		}
sb.Append("</urn:GetPalDetailsReq>");
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class GetPalDetailsRequestType :AbstractRequestType{


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class GetPalDetailsResponseType :AbstractResponseType{

		private string PalField;
		public string Pal {
			get {
				return this.PalField;
			}
			set {
				this.PalField = value;
			}
		}

		private string LocaleField;
		public string Locale {
			get {
				return this.LocaleField;
			}
			set {
				this.LocaleField = value;
			}
		}

	 public GetPalDetailsResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Pal").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Pal")[0])){ 
		 this.Pal =(string)document.GetElementsByTagName("Pal")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Locale").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Locale")[0])){ 
		 this.Locale =(string)document.GetElementsByTagName("Locale")[0].InnerText;

}
	}
	}
	}


	/**
	 */
	public partial class GetRecurringPaymentsProfileDetailsReq {

		private GetRecurringPaymentsProfileDetailsRequestType GetRecurringPaymentsProfileDetailsRequestField;
		public GetRecurringPaymentsProfileDetailsRequestType GetRecurringPaymentsProfileDetailsRequest {
			get {
				return this.GetRecurringPaymentsProfileDetailsRequestField;
			}
			set {
				this.GetRecurringPaymentsProfileDetailsRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:GetRecurringPaymentsProfileDetailsReq>");
		if( GetRecurringPaymentsProfileDetailsRequest != null ) {
			sb.Append("<urn:GetRecurringPaymentsProfileDetailsRequest>");
			sb.Append(GetRecurringPaymentsProfileDetailsRequest.toXMLString());
			sb.Append("</urn:GetRecurringPaymentsProfileDetailsRequest>");
		}
sb.Append("</urn:GetRecurringPaymentsProfileDetailsReq>");
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class GetRecurringPaymentsProfileDetailsRequestType :AbstractRequestType{

		/**
		 */
		private string ProfileIDField;
		public string ProfileID {
			get {
				return this.ProfileIDField;
			}
			set {
				this.ProfileIDField = value;
			}
		}

		public GetRecurringPaymentsProfileDetailsRequestType(string ProfileID) {
			this.ProfileID = ProfileID;
		}
		public GetRecurringPaymentsProfileDetailsRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( ProfileID != null ) {
			sb.Append("<urn:ProfileID>").Append(ProfileID);
			sb.Append("</urn:ProfileID>");
		}
		return sb.ToString();
	}

	}


	/**
	 * Recurring Billing Profile ID
	 */
	public partial class GetRecurringPaymentsProfileDetailsResponseDetailsType {

		/**
		 * Recurring Billing Profile ID
		 */
		private string ProfileIDField;
		public string ProfileID {
			get {
				return this.ProfileIDField;
			}
			set {
				this.ProfileIDField = value;
			}
		}

		/**
		 */
		private RecurringPaymentsProfileStatusType? ProfileStatusField;
		public RecurringPaymentsProfileStatusType? ProfileStatus {
			get {
				return this.ProfileStatusField;
			}
			set {
				this.ProfileStatusField = value;
			}
		}

		/**
		 */
		private string DescriptionField;
		public string Description {
			get {
				return this.DescriptionField;
			}
			set {
				this.DescriptionField = value;
			}
		}

		/**
		 */
		private AutoBillType? AutoBillOutstandingAmountField;
		public AutoBillType? AutoBillOutstandingAmount {
			get {
				return this.AutoBillOutstandingAmountField;
			}
			set {
				this.AutoBillOutstandingAmountField = value;
			}
		}

		/**
		 */
		private int? MaxFailedPaymentsField;
		public int? MaxFailedPayments {
			get {
				return this.MaxFailedPaymentsField;
			}
			set {
				this.MaxFailedPaymentsField = value;
			}
		}

		/**
		 */
		private RecurringPaymentsProfileDetailsType RecurringPaymentsProfileDetailsField;
		public RecurringPaymentsProfileDetailsType RecurringPaymentsProfileDetails {
			get {
				return this.RecurringPaymentsProfileDetailsField;
			}
			set {
				this.RecurringPaymentsProfileDetailsField = value;
			}
		}

		/**
		 */
		private BillingPeriodDetailsType CurrentRecurringPaymentsPeriodField;
		public BillingPeriodDetailsType CurrentRecurringPaymentsPeriod {
			get {
				return this.CurrentRecurringPaymentsPeriodField;
			}
			set {
				this.CurrentRecurringPaymentsPeriodField = value;
			}
		}

		/**
		 */
		private RecurringPaymentsSummaryType RecurringPaymentsSummaryField;
		public RecurringPaymentsSummaryType RecurringPaymentsSummary {
			get {
				return this.RecurringPaymentsSummaryField;
			}
			set {
				this.RecurringPaymentsSummaryField = value;
			}
		}

		/**
		 */
		private CreditCardDetailsType CreditCardField;
		public CreditCardDetailsType CreditCard {
			get {
				return this.CreditCardField;
			}
			set {
				this.CreditCardField = value;
			}
		}

		/**
		 */
		private BillingPeriodDetailsType TrialRecurringPaymentsPeriodField;
		public BillingPeriodDetailsType TrialRecurringPaymentsPeriod {
			get {
				return this.TrialRecurringPaymentsPeriodField;
			}
			set {
				this.TrialRecurringPaymentsPeriodField = value;
			}
		}

		/**
		 */
		private BillingPeriodDetailsType RegularRecurringPaymentsPeriodField;
		public BillingPeriodDetailsType RegularRecurringPaymentsPeriod {
			get {
				return this.RegularRecurringPaymentsPeriodField;
			}
			set {
				this.RegularRecurringPaymentsPeriodField = value;
			}
		}

		/**
		 */
		private BasicAmountType TrialAmountPaidField;
		public BasicAmountType TrialAmountPaid {
			get {
				return this.TrialAmountPaidField;
			}
			set {
				this.TrialAmountPaidField = value;
			}
		}

		/**
		 */
		private BasicAmountType RegularAmountPaidField;
		public BasicAmountType RegularAmountPaid {
			get {
				return this.RegularAmountPaidField;
			}
			set {
				this.RegularAmountPaidField = value;
			}
		}

		/**
		 */
		private BasicAmountType AggregateAmountField;
		public BasicAmountType AggregateAmount {
			get {
				return this.AggregateAmountField;
			}
			set {
				this.AggregateAmountField = value;
			}
		}

		/**
		 */
		private BasicAmountType AggregateOptionalAmountField;
		public BasicAmountType AggregateOptionalAmount {
			get {
				return this.AggregateOptionalAmountField;
			}
			set {
				this.AggregateOptionalAmountField = value;
			}
		}

		/**
		 */
		private string FinalPaymentDueDateField;
		public string FinalPaymentDueDate {
			get {
				return this.FinalPaymentDueDateField;
			}
			set {
				this.FinalPaymentDueDateField = value;
			}
		}

	 public GetRecurringPaymentsProfileDetailsResponseDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("ProfileID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ProfileID")[0])){ 
		 this.ProfileID =(string)document.GetElementsByTagName("ProfileID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ProfileStatus").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ProfileStatus")[0])){ 
		 this.ProfileStatus = (RecurringPaymentsProfileStatusType)EnumUtils.getValue(document.GetElementsByTagName("ProfileStatus")[0].InnerText,typeof(RecurringPaymentsProfileStatusType));

}
	}
		 if(document.GetElementsByTagName("Description").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Description")[0])){ 
		 this.Description =(string)document.GetElementsByTagName("Description")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("AutoBillOutstandingAmount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AutoBillOutstandingAmount")[0])){ 
		 this.AutoBillOutstandingAmount = (AutoBillType)EnumUtils.getValue(document.GetElementsByTagName("AutoBillOutstandingAmount")[0].InnerText,typeof(AutoBillType));

}
	}
		 if(document.GetElementsByTagName("MaxFailedPayments").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("MaxFailedPayments")[0])){ 
		 this.MaxFailedPayments =System.Convert.ToInt32(document.GetElementsByTagName("MaxFailedPayments")[0].InnerText);

}
	}
		 if(document.GetElementsByTagName("RecurringPaymentsProfileDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("RecurringPaymentsProfileDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("RecurringPaymentsProfileDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.RecurringPaymentsProfileDetails =  new RecurringPaymentsProfileDetailsType(xmlString);

}
	}
		 if(document.GetElementsByTagName("CurrentRecurringPaymentsPeriod").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CurrentRecurringPaymentsPeriod")[0])){ 
		 nodeList = document.GetElementsByTagName("CurrentRecurringPaymentsPeriod");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.CurrentRecurringPaymentsPeriod =  new BillingPeriodDetailsType(xmlString);

}
	}
		 if(document.GetElementsByTagName("RecurringPaymentsSummary").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("RecurringPaymentsSummary")[0])){ 
		 nodeList = document.GetElementsByTagName("RecurringPaymentsSummary");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.RecurringPaymentsSummary =  new RecurringPaymentsSummaryType(xmlString);

}
	}
		 if(document.GetElementsByTagName("CreditCard").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CreditCard")[0])){ 
		 nodeList = document.GetElementsByTagName("CreditCard");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.CreditCard =  new CreditCardDetailsType(xmlString);

}
	}
		 if(document.GetElementsByTagName("TrialRecurringPaymentsPeriod").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TrialRecurringPaymentsPeriod")[0])){ 
		 nodeList = document.GetElementsByTagName("TrialRecurringPaymentsPeriod");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.TrialRecurringPaymentsPeriod =  new BillingPeriodDetailsType(xmlString);

}
	}
		 if(document.GetElementsByTagName("RegularRecurringPaymentsPeriod").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("RegularRecurringPaymentsPeriod")[0])){ 
		 nodeList = document.GetElementsByTagName("RegularRecurringPaymentsPeriod");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.RegularRecurringPaymentsPeriod =  new BillingPeriodDetailsType(xmlString);

}
	}
		 if(document.GetElementsByTagName("TrialAmountPaid").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TrialAmountPaid")[0])){ 
		 nodeList = document.GetElementsByTagName("TrialAmountPaid");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.TrialAmountPaid =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("RegularAmountPaid").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("RegularAmountPaid")[0])){ 
		 nodeList = document.GetElementsByTagName("RegularAmountPaid");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.RegularAmountPaid =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("AggregateAmount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AggregateAmount")[0])){ 
		 nodeList = document.GetElementsByTagName("AggregateAmount");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.AggregateAmount =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("AggregateOptionalAmount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AggregateOptionalAmount")[0])){ 
		 nodeList = document.GetElementsByTagName("AggregateOptionalAmount");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.AggregateOptionalAmount =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("FinalPaymentDueDate").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("FinalPaymentDueDate")[0])){ 
		 this.FinalPaymentDueDate =(string)document.GetElementsByTagName("FinalPaymentDueDate")[0].InnerText;

}
	}
	}
	}


	/**
	 */
	public partial class GetRecurringPaymentsProfileDetailsResponseType :AbstractResponseType{

		private GetRecurringPaymentsProfileDetailsResponseDetailsType GetRecurringPaymentsProfileDetailsResponseDetailsField;
		public GetRecurringPaymentsProfileDetailsResponseDetailsType GetRecurringPaymentsProfileDetailsResponseDetails {
			get {
				return this.GetRecurringPaymentsProfileDetailsResponseDetailsField;
			}
			set {
				this.GetRecurringPaymentsProfileDetailsResponseDetailsField = value;
			}
		}

	 public GetRecurringPaymentsProfileDetailsResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("GetRecurringPaymentsProfileDetailsResponseDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GetRecurringPaymentsProfileDetailsResponseDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("GetRecurringPaymentsProfileDetailsResponseDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.GetRecurringPaymentsProfileDetailsResponseDetails =  new GetRecurringPaymentsProfileDetailsResponseDetailsType(xmlString);

}
	}
	}
	}


	/**
	 */
	public partial class GetTransactionDetailsReq {

		private GetTransactionDetailsRequestType GetTransactionDetailsRequestField;
		public GetTransactionDetailsRequestType GetTransactionDetailsRequest {
			get {
				return this.GetTransactionDetailsRequestField;
			}
			set {
				this.GetTransactionDetailsRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:GetTransactionDetailsReq>");
		if( GetTransactionDetailsRequest != null ) {
			sb.Append("<urn:GetTransactionDetailsRequest>");
			sb.Append(GetTransactionDetailsRequest.toXMLString());
			sb.Append("</urn:GetTransactionDetailsRequest>");
		}
sb.Append("</urn:GetTransactionDetailsReq>");
		return sb.ToString();
	}

	}


	/**
Unique identifier of a transaction. 
	 * Required
	 * The details for some kinds of transactions cannot be retrieved with GetTransactionDetailsRequest. You cannot obtain details of bank transfer withdrawals, for example. 
	 * Character length and limitations: 17 single-byte alphanumeric characters
	 */
	public partial class GetTransactionDetailsRequestType :AbstractRequestType{

		/**
Unique identifier of a transaction. 
		 * Required
		 * The details for some kinds of transactions cannot be retrieved with GetTransactionDetailsRequest. You cannot obtain details of bank transfer withdrawals, for example. 
		 * Character length and limitations: 17 single-byte alphanumeric characters
		 */
		private string TransactionIDField;
		public string TransactionID {
			get {
				return this.TransactionIDField;
			}
			set {
				this.TransactionIDField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( TransactionID != null ) {
			sb.Append("<urn:TransactionID>").Append(TransactionID);
			sb.Append("</urn:TransactionID>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class GetTransactionDetailsResponseType :AbstractResponseType{

		private PaymentTransactionType PaymentTransactionDetailsField;
		public PaymentTransactionType PaymentTransactionDetails {
			get {
				return this.PaymentTransactionDetailsField;
			}
			set {
				this.PaymentTransactionDetailsField = value;
			}
		}

		private ThreeDSecureInfoType ThreeDSecureDetailsField;
		public ThreeDSecureInfoType ThreeDSecureDetails {
			get {
				return this.ThreeDSecureDetailsField;
			}
			set {
				this.ThreeDSecureDetailsField = value;
			}
		}

	 public GetTransactionDetailsResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("PaymentTransactionDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentTransactionDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("PaymentTransactionDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.PaymentTransactionDetails =  new PaymentTransactionType(xmlString);

}
	}
		 if(document.GetElementsByTagName("ThreeDSecureDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ThreeDSecureDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("ThreeDSecureDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.ThreeDSecureDetails =  new ThreeDSecureInfoType(xmlString);

}
	}
	}
	}


	/**
	 * Mobile specific buyer identification.
	 */
	public partial class IdentificationInfoType {

		/**
Mobile specific buyer identification.		 */
		private MobileIDInfoType MobileIDInfoField;
		public MobileIDInfoType MobileIDInfo {
			get {
				return this.MobileIDInfoField;
			}
			set {
				this.MobileIDInfoField = value;
			}
		}

		/**
Contains login bypass information.		 */
		private RememberMeIDInfoType RememberMeIDInfoField;
		public RememberMeIDInfoType RememberMeIDInfo {
			get {
				return this.RememberMeIDInfoField;
			}
			set {
				this.RememberMeIDInfoField = value;
			}
		}

		/**
Identity Access Token.		 */
		private IdentityTokenInfoType IdentityTokenInfoField;
		public IdentityTokenInfoType IdentityTokenInfo {
			get {
				return this.IdentityTokenInfoField;
			}
			set {
				this.IdentityTokenInfoField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( MobileIDInfo != null ) {
			sb.Append("<ebl:MobileIDInfo>");
			sb.Append(MobileIDInfo.toXMLString());
			sb.Append("</ebl:MobileIDInfo>");
		}
		if( RememberMeIDInfo != null ) {
			sb.Append("<ebl:RememberMeIDInfo>");
			sb.Append(RememberMeIDInfo.toXMLString());
			sb.Append("</ebl:RememberMeIDInfo>");
		}
		if( IdentityTokenInfo != null ) {
			sb.Append("<ebl:IdentityTokenInfo>");
			sb.Append(IdentityTokenInfo.toXMLString());
			sb.Append("</ebl:IdentityTokenInfo>");
		}
		return sb.ToString();
	}

	}


	/**
	 * Identity Access token from merchant
	 */
	public partial class IdentityTokenInfoType {

		/**
Identity Access token from merchant		 */
		private string AccessTokenField;
		public string AccessToken {
			get {
				return this.AccessTokenField;
			}
			set {
				this.AccessTokenField = value;
			}
		}

		public IdentityTokenInfoType(string AccessToken) {
			this.AccessToken = AccessToken;
		}
		public IdentityTokenInfoType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( AccessToken != null ) {
			sb.Append("<ebl:AccessToken>").Append(AccessToken);
			sb.Append("</ebl:AccessToken>");
		}
		return sb.ToString();
	}

	}


	/**
	 * Details of incentive application on individual bucket/item.  
	 */
	public partial class IncentiveAppliedDetailsType {

		/**
		 * PaymentRequestID uniquely identifies a bucket. It is the "bucket id" in the world of EC API.
		 */
		private string PaymentRequestIDField;
		public string PaymentRequestID {
			get {
				return this.PaymentRequestIDField;
			}
			set {
				this.PaymentRequestIDField = value;
			}
		}

		/**
		 * The item id passed through by the merchant. 
		 */
		private string ItemIdField;
		public string ItemId {
			get {
				return this.ItemIdField;
			}
			set {
				this.ItemIdField = value;
			}
		}

		/**
		 * The item transaction id passed through by the merchant. 
		 */
		private string ExternalTxnIdField;
		public string ExternalTxnId {
			get {
				return this.ExternalTxnIdField;
			}
			set {
				this.ExternalTxnIdField = value;
			}
		}

		/**
		 * Discount offerred for this bucket or item. 
		 */
		private BasicAmountType DiscountAmountField;
		public BasicAmountType DiscountAmount {
			get {
				return this.DiscountAmountField;
			}
			set {
				this.DiscountAmountField = value;
			}
		}

		/**
		 * SubType for coupon. 
		 */
		private string SubTypeField;
		public string SubType {
			get {
				return this.SubTypeField;
			}
			set {
				this.SubTypeField = value;
			}
		}

	 public IncentiveAppliedDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("PaymentRequestID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentRequestID")[0])){ 
		 this.PaymentRequestID =(string)document.GetElementsByTagName("PaymentRequestID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ItemId").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ItemId")[0])){ 
		 this.ItemId =(string)document.GetElementsByTagName("ItemId")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ExternalTxnId").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ExternalTxnId")[0])){ 
		 this.ExternalTxnId =(string)document.GetElementsByTagName("ExternalTxnId")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("DiscountAmount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("DiscountAmount")[0])){ 
		 nodeList = document.GetElementsByTagName("DiscountAmount");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.DiscountAmount =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("SubType").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SubType")[0])){ 
		 this.SubType =(string)document.GetElementsByTagName("SubType")[0].InnerText;

}
	}
	}
	}


	public enum IncentiveAppliedStatusType {
[Description("INCENTIVE-APPLIED-STATUS-SUCCESS")]INCENTIVEAPPLIEDSTATUSSUCCESS,
[Description("INCENTIVE-APPLIED-STATUS-ERROR")]INCENTIVEAPPLIEDSTATUSERROR,
	}
	/**
	 */
	public partial class IncentiveAppliedToType {

		private string BucketIdField;
		public string BucketId {
			get {
				return this.BucketIdField;
			}
			set {
				this.BucketIdField = value;
			}
		}

		private string ItemIdField;
		public string ItemId {
			get {
				return this.ItemIdField;
			}
			set {
				this.ItemIdField = value;
			}
		}

		private BasicAmountType IncentiveAmountField;
		public BasicAmountType IncentiveAmount {
			get {
				return this.IncentiveAmountField;
			}
			set {
				this.IncentiveAmountField = value;
			}
		}

		private string SubTypeField;
		public string SubType {
			get {
				return this.SubTypeField;
			}
			set {
				this.SubTypeField = value;
			}
		}

	 public IncentiveAppliedToType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("BucketId").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BucketId")[0])){ 
		 this.BucketId =(string)document.GetElementsByTagName("BucketId")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ItemId").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ItemId")[0])){ 
		 this.ItemId =(string)document.GetElementsByTagName("ItemId")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("IncentiveAmount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("IncentiveAmount")[0])){ 
		 nodeList = document.GetElementsByTagName("IncentiveAmount");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.IncentiveAmount =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("SubType").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SubType")[0])){ 
		 this.SubType =(string)document.GetElementsByTagName("SubType")[0].InnerText;

}
	}
	}
	}


	/**
	 * Defines which bucket or item that the incentive should be applied to.  
	 */
	public partial class IncentiveApplyIndicationType {

		/**
		 * The Bucket ID that the incentive is applied to.
		 */
		private string PaymentRequestIDField;
		public string PaymentRequestID {
			get {
				return this.PaymentRequestIDField;
			}
			set {
				this.PaymentRequestIDField = value;
			}
		}

		/**
		 * The item that the incentive is applied to. 
		 */
		private string ItemIdField;
		public string ItemId {
			get {
				return this.ItemIdField;
			}
			set {
				this.ItemIdField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( PaymentRequestID != null ) {
			sb.Append("<ebl:PaymentRequestID>").Append(PaymentRequestID);
			sb.Append("</ebl:PaymentRequestID>");
		}
		if( ItemId != null ) {
			sb.Append("<ebl:ItemId>").Append(ItemId);
			sb.Append("</ebl:ItemId>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class IncentiveBucketType {

		private List<IncentiveItemType> ItemsField = new List<IncentiveItemType>();
		public List<IncentiveItemType> Items {
			get {
				return this.ItemsField;
			}
			set {
				this.ItemsField = value;
			}
		}

		private string BucketIdField;
		public string BucketId {
			get {
				return this.BucketIdField;
			}
			set {
				this.BucketIdField = value;
			}
		}

		private string SellerIdField;
		public string SellerId {
			get {
				return this.SellerIdField;
			}
			set {
				this.SellerIdField = value;
			}
		}

		private string ExternalSellerIdField;
		public string ExternalSellerId {
			get {
				return this.ExternalSellerIdField;
			}
			set {
				this.ExternalSellerIdField = value;
			}
		}

		private BasicAmountType BucketSubtotalAmtField;
		public BasicAmountType BucketSubtotalAmt {
			get {
				return this.BucketSubtotalAmtField;
			}
			set {
				this.BucketSubtotalAmtField = value;
			}
		}

		private BasicAmountType BucketShippingAmtField;
		public BasicAmountType BucketShippingAmt {
			get {
				return this.BucketShippingAmtField;
			}
			set {
				this.BucketShippingAmtField = value;
			}
		}

		private BasicAmountType BucketInsuranceAmtField;
		public BasicAmountType BucketInsuranceAmt {
			get {
				return this.BucketInsuranceAmtField;
			}
			set {
				this.BucketInsuranceAmtField = value;
			}
		}

		private BasicAmountType BucketSalesTaxAmtField;
		public BasicAmountType BucketSalesTaxAmt {
			get {
				return this.BucketSalesTaxAmtField;
			}
			set {
				this.BucketSalesTaxAmtField = value;
			}
		}

		private BasicAmountType BucketTotalAmtField;
		public BasicAmountType BucketTotalAmt {
			get {
				return this.BucketTotalAmtField;
			}
			set {
				this.BucketTotalAmtField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( Items != null ) {
			for(int i=0; i<Items.Count; i++) {
				sb.Append("<ebl:Items>");
				sb.Append(Items[i].toXMLString());
				sb.Append("</ebl:Items>");
			}
		}
		if( BucketId != null ) {
			sb.Append("<ebl:BucketId>").Append(BucketId);
			sb.Append("</ebl:BucketId>");
		}
		if( SellerId != null ) {
			sb.Append("<ebl:SellerId>").Append(SellerId);
			sb.Append("</ebl:SellerId>");
		}
		if( ExternalSellerId != null ) {
			sb.Append("<ebl:ExternalSellerId>").Append(ExternalSellerId);
			sb.Append("</ebl:ExternalSellerId>");
		}
		if( BucketSubtotalAmt != null ) {
			sb.Append("<ebl:BucketSubtotalAmt ");
			sb.Append(BucketSubtotalAmt.toXMLString());
			sb.Append("</ebl:BucketSubtotalAmt>");
		}
		if( BucketShippingAmt != null ) {
			sb.Append("<ebl:BucketShippingAmt ");
			sb.Append(BucketShippingAmt.toXMLString());
			sb.Append("</ebl:BucketShippingAmt>");
		}
		if( BucketInsuranceAmt != null ) {
			sb.Append("<ebl:BucketInsuranceAmt ");
			sb.Append(BucketInsuranceAmt.toXMLString());
			sb.Append("</ebl:BucketInsuranceAmt>");
		}
		if( BucketSalesTaxAmt != null ) {
			sb.Append("<ebl:BucketSalesTaxAmt ");
			sb.Append(BucketSalesTaxAmt.toXMLString());
			sb.Append("</ebl:BucketSalesTaxAmt>");
		}
		if( BucketTotalAmt != null ) {
			sb.Append("<ebl:BucketTotalAmt ");
			sb.Append(BucketTotalAmt.toXMLString());
			sb.Append("</ebl:BucketTotalAmt>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class IncentiveDetailType {

		private string RedemptionCodeField;
		public string RedemptionCode {
			get {
				return this.RedemptionCodeField;
			}
			set {
				this.RedemptionCodeField = value;
			}
		}

		private string DisplayCodeField;
		public string DisplayCode {
			get {
				return this.DisplayCodeField;
			}
			set {
				this.DisplayCodeField = value;
			}
		}

		private string ProgramIdField;
		public string ProgramId {
			get {
				return this.ProgramIdField;
			}
			set {
				this.ProgramIdField = value;
			}
		}

		private IncentiveTypeCodeType? IncentiveTypeField;
		public IncentiveTypeCodeType? IncentiveType {
			get {
				return this.IncentiveTypeField;
			}
			set {
				this.IncentiveTypeField = value;
			}
		}

		private string IncentiveDescriptionField;
		public string IncentiveDescription {
			get {
				return this.IncentiveDescriptionField;
			}
			set {
				this.IncentiveDescriptionField = value;
			}
		}

		private List<IncentiveAppliedToType> AppliedToField = new List<IncentiveAppliedToType>();
		public List<IncentiveAppliedToType> AppliedTo {
			get {
				return this.AppliedToField;
			}
			set {
				this.AppliedToField = value;
			}
		}

		private string StatusField;
		public string Status {
			get {
				return this.StatusField;
			}
			set {
				this.StatusField = value;
			}
		}

		private string ErrorCodeField;
		public string ErrorCode {
			get {
				return this.ErrorCodeField;
			}
			set {
				this.ErrorCodeField = value;
			}
		}

	 public IncentiveDetailType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("RedemptionCode").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("RedemptionCode")[0])){ 
		 this.RedemptionCode =(string)document.GetElementsByTagName("RedemptionCode")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("DisplayCode").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("DisplayCode")[0])){ 
		 this.DisplayCode =(string)document.GetElementsByTagName("DisplayCode")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ProgramId").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ProgramId")[0])){ 
		 this.ProgramId =(string)document.GetElementsByTagName("ProgramId")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("IncentiveType").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("IncentiveType")[0])){ 
		 this.IncentiveType = (IncentiveTypeCodeType)EnumUtils.getValue(document.GetElementsByTagName("IncentiveType")[0].InnerText,typeof(IncentiveTypeCodeType));

}
	}
		 if(document.GetElementsByTagName("IncentiveDescription").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("IncentiveDescription")[0])){ 
		 this.IncentiveDescription =(string)document.GetElementsByTagName("IncentiveDescription")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("AppliedTo").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AppliedTo")[0])){ 
		 nodeList = document.GetElementsByTagName("AppliedTo");
		 for(int i=0; i<nodeList.Count; i++) {
			 xmlString = DeserializationUtils.convertToXML(nodeList[i]); 
				this.AppliedTo.Add(new IncentiveAppliedToType(xmlString));
			}

}
	}
		 if(document.GetElementsByTagName("Status").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Status")[0])){ 
		 this.Status =(string)document.GetElementsByTagName("Status")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ErrorCode").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ErrorCode")[0])){ 
		 this.ErrorCode =(string)document.GetElementsByTagName("ErrorCode")[0].InnerText;

}
	}
	}
	}


	/**
	 * Information about the incentives that were applied from Ebay RYP page and PayPal RYP page.
	 */
	public partial class IncentiveDetailsType {

		/**
		 * Unique Identifier consisting of redemption code, user friendly descripotion, incentive type, campaign code, incenitve application order and site redeemed o
n.
		 */
		private string UniqueIdentifierField;
		public string UniqueIdentifier {
			get {
				return this.UniqueIdentifierField;
			}
			set {
				this.UniqueIdentifierField = value;
			}
		}

		/**
		 * Defines if the incentive has been applied on Ebay or PayPal.
		 */
		private IncentiveSiteAppliedOnType? SiteAppliedOnField;
		public IncentiveSiteAppliedOnType? SiteAppliedOn {
			get {
				return this.SiteAppliedOnField;
			}
			set {
				this.SiteAppliedOnField = value;
			}
		}

		/**
		 * The total discount amount for the incentive, summation of discounts up across all the buckets/items.
		 */
		private BasicAmountType TotalDiscountAmountField;
		public BasicAmountType TotalDiscountAmount {
			get {
				return this.TotalDiscountAmountField;
			}
			set {
				this.TotalDiscountAmountField = value;
			}
		}

		/**
		 * Status of incentive processing. Sussess or Error.
		 */
		private IncentiveAppliedStatusType? StatusField;
		public IncentiveAppliedStatusType? Status {
			get {
				return this.StatusField;
			}
			set {
				this.StatusField = value;
			}
		}

		/**
		 * Error code if there are any errors. Zero otherwise.
		 */
		private int? ErrorCodeField;
		public int? ErrorCode {
			get {
				return this.ErrorCodeField;
			}
			set {
				this.ErrorCodeField = value;
			}
		}

		/**
		 * Details of incentive application on individual bucket/item.  
		 */
		private List<IncentiveAppliedDetailsType> IncentiveAppliedDetailsField = new List<IncentiveAppliedDetailsType>();
		public List<IncentiveAppliedDetailsType> IncentiveAppliedDetails {
			get {
				return this.IncentiveAppliedDetailsField;
			}
			set {
				this.IncentiveAppliedDetailsField = value;
			}
		}

	 public IncentiveDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("UniqueIdentifier").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("UniqueIdentifier")[0])){ 
		 this.UniqueIdentifier =(string)document.GetElementsByTagName("UniqueIdentifier")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("SiteAppliedOn").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SiteAppliedOn")[0])){ 
		 this.SiteAppliedOn = (IncentiveSiteAppliedOnType)EnumUtils.getValue(document.GetElementsByTagName("SiteAppliedOn")[0].InnerText,typeof(IncentiveSiteAppliedOnType));

}
	}
		 if(document.GetElementsByTagName("TotalDiscountAmount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TotalDiscountAmount")[0])){ 
		 nodeList = document.GetElementsByTagName("TotalDiscountAmount");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.TotalDiscountAmount =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("Status").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Status")[0])){ 
		 this.Status = (IncentiveAppliedStatusType)EnumUtils.getValue(document.GetElementsByTagName("Status")[0].InnerText,typeof(IncentiveAppliedStatusType));

}
	}
		 if(document.GetElementsByTagName("ErrorCode").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ErrorCode")[0])){ 
		 this.ErrorCode =System.Convert.ToInt32(document.GetElementsByTagName("ErrorCode")[0].InnerText);

}
	}
		 if(document.GetElementsByTagName("IncentiveAppliedDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("IncentiveAppliedDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("IncentiveAppliedDetails");
		 for(int i=0; i<nodeList.Count; i++) {
			 xmlString = DeserializationUtils.convertToXML(nodeList[i]); 
				this.IncentiveAppliedDetails.Add(new IncentiveAppliedDetailsType(xmlString));
			}

}
	}
	}
	}


	/**
	 * Details of incentive application on individual bucket.  
	 */
	public partial class IncentiveInfoType {

		/**
		 * Incentive redemption code.
		 */
		private string IncentiveCodeField;
		public string IncentiveCode {
			get {
				return this.IncentiveCodeField;
			}
			set {
				this.IncentiveCodeField = value;
			}
		}

		/**
		 * Defines which bucket or item that the incentive should be applied to. 
		 */
		private List<IncentiveApplyIndicationType> ApplyIndicationField = new List<IncentiveApplyIndicationType>();
		public List<IncentiveApplyIndicationType> ApplyIndication {
			get {
				return this.ApplyIndicationField;
			}
			set {
				this.ApplyIndicationField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( IncentiveCode != null ) {
			sb.Append("<ebl:IncentiveCode>").Append(IncentiveCode);
			sb.Append("</ebl:IncentiveCode>");
		}
		if( ApplyIndication != null ) {
			for(int i=0; i<ApplyIndication.Count; i++) {
				sb.Append("<ebl:ApplyIndication>");
				sb.Append(ApplyIndication[i].toXMLString());
				sb.Append("</ebl:ApplyIndication>");
			}
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class IncentiveItemType {

		private string ItemIdField;
		public string ItemId {
			get {
				return this.ItemIdField;
			}
			set {
				this.ItemIdField = value;
			}
		}

		private string PurchaseTimeField;
		public string PurchaseTime {
			get {
				return this.PurchaseTimeField;
			}
			set {
				this.PurchaseTimeField = value;
			}
		}

		private string ItemCategoryListField;
		public string ItemCategoryList {
			get {
				return this.ItemCategoryListField;
			}
			set {
				this.ItemCategoryListField = value;
			}
		}

		private BasicAmountType ItemPriceField;
		public BasicAmountType ItemPrice {
			get {
				return this.ItemPriceField;
			}
			set {
				this.ItemPriceField = value;
			}
		}

		private int? ItemQuantityField;
		public int? ItemQuantity {
			get {
				return this.ItemQuantityField;
			}
			set {
				this.ItemQuantityField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( ItemId != null ) {
			sb.Append("<ebl:ItemId>").Append(ItemId);
			sb.Append("</ebl:ItemId>");
		}
		if( PurchaseTime != null ) {
			sb.Append("<ebl:PurchaseTime>").Append(PurchaseTime);
			sb.Append("</ebl:PurchaseTime>");
		}
		if( ItemCategoryList != null ) {
			sb.Append("<ebl:ItemCategoryList>").Append(ItemCategoryList);
			sb.Append("</ebl:ItemCategoryList>");
		}
		if( ItemPrice != null ) {
			sb.Append("<ebl:ItemPrice ");
			sb.Append(ItemPrice.toXMLString());
			sb.Append("</ebl:ItemPrice>");
		}
		if( ItemQuantity != null ) {
			sb.Append("<ebl:ItemQuantity>").Append(ItemQuantity);
			sb.Append("</ebl:ItemQuantity>");
		}
		return sb.ToString();
	}

	}


	public enum IncentiveRequestCodeType {
[Description("InCheckout")]INCHECKOUT,
[Description("PreCheckout")]PRECHECKOUT,
	}
	public enum IncentiveRequestDetailLevelCodeType {
[Description("Aggregated")]AGGREGATED,
[Description("Detail")]DETAIL,
	}
	/**
	 */
	public partial class IncentiveRequestDetailsType {

		private string RequestIdField;
		public string RequestId {
			get {
				return this.RequestIdField;
			}
			set {
				this.RequestIdField = value;
			}
		}

		private IncentiveRequestCodeType? RequestTypeField;
		public IncentiveRequestCodeType? RequestType {
			get {
				return this.RequestTypeField;
			}
			set {
				this.RequestTypeField = value;
			}
		}

		private IncentiveRequestDetailLevelCodeType? RequestDetailLevelField;
		public IncentiveRequestDetailLevelCodeType? RequestDetailLevel {
			get {
				return this.RequestDetailLevelField;
			}
			set {
				this.RequestDetailLevelField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( RequestId != null ) {
			sb.Append("<ebl:RequestId>").Append(RequestId);
			sb.Append("</ebl:RequestId>");
		}
		if( RequestType != null ) {
			sb.Append("<ebl:RequestType>").Append(EnumUtils.getDescription(RequestType));
			sb.Append("</ebl:RequestType>");
		}
		if( RequestDetailLevel != null ) {
			sb.Append("<ebl:RequestDetailLevel>").Append(EnumUtils.getDescription(RequestDetailLevel));
			sb.Append("</ebl:RequestDetailLevel>");
		}
		return sb.ToString();
	}

	}


	public enum IncentiveSiteAppliedOnType {
[Description("INCENTIVE-SITE-APPLIED-ON-UNKNOWN")]INCENTIVESITEAPPLIEDONUNKNOWN,
[Description("INCENTIVE-SITE-APPLIED-ON-MERCHANT")]INCENTIVESITEAPPLIEDONMERCHANT,
[Description("INCENTIVE-SITE-APPLIED-ON-PAYPAL")]INCENTIVESITEAPPLIEDONPAYPAL,
	}
	public enum IncentiveTypeCodeType {
[Description("Coupon")]COUPON,
[Description("eBayGiftCertificate")]EBAYGIFTCERTIFICATE,
[Description("eBayGiftCard")]EBAYGIFTCARD,
[Description("PayPalRewardVoucher")]PAYPALREWARDVOUCHER,
[Description("MerchantGiftCertificate")]MERCHANTGIFTCERTIFICATE,
[Description("eBayRewardVoucher")]EBAYREWARDVOUCHER,
	}
	/**
	 * If Billing Address should be returned in GetExpressCheckoutDetails response, this parameter should be set to yes here
	 */
	public partial class InfoSharingDirectivesType {

		/**
If Billing Address should be returned in GetExpressCheckoutDetails response, this parameter should be set to yes here		 */
		private string ReqBillingAddressField;
		public string ReqBillingAddress {
			get {
				return this.ReqBillingAddressField;
			}
			set {
				this.ReqBillingAddressField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( ReqBillingAddress != null ) {
			sb.Append("<ebl:ReqBillingAddress>").Append(ReqBillingAddress);
			sb.Append("</ebl:ReqBillingAddress>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class InitiateRecoupReq {

		private InitiateRecoupRequestType InitiateRecoupRequestField;
		public InitiateRecoupRequestType InitiateRecoupRequest {
			get {
				return this.InitiateRecoupRequestField;
			}
			set {
				this.InitiateRecoupRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:InitiateRecoupReq>");
		if( InitiateRecoupRequest != null ) {
			sb.Append("<urn:InitiateRecoupRequest>");
			sb.Append(InitiateRecoupRequest.toXMLString());
			sb.Append("</urn:InitiateRecoupRequest>");
		}
sb.Append("</urn:InitiateRecoupReq>");
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class InitiateRecoupRequestType :AbstractRequestType{

		private EnhancedInitiateRecoupRequestDetailsType EnhancedInitiateRecoupRequestDetailsField;
		public EnhancedInitiateRecoupRequestDetailsType EnhancedInitiateRecoupRequestDetails {
			get {
				return this.EnhancedInitiateRecoupRequestDetailsField;
			}
			set {
				this.EnhancedInitiateRecoupRequestDetailsField = value;
			}
		}

		public InitiateRecoupRequestType(EnhancedInitiateRecoupRequestDetailsType EnhancedInitiateRecoupRequestDetails) {
			this.EnhancedInitiateRecoupRequestDetails = EnhancedInitiateRecoupRequestDetails;
		}
		public InitiateRecoupRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( EnhancedInitiateRecoupRequestDetails != null ) {
			sb.Append("<ed:EnhancedInitiateRecoupRequestDetails>");
			sb.Append(EnhancedInitiateRecoupRequestDetails.toXMLString());
			sb.Append("</ed:EnhancedInitiateRecoupRequestDetails>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class InitiateRecoupResponseType :AbstractResponseType{

	 public InitiateRecoupResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
	}
	}


	/**
	 * Installment Period.
	 * Optional
	 */
	public partial class InstallmentDetailsType {

		/**
		 * Installment Period.
		 * Optional
		 */
		private BillingPeriodType? BillingPeriodField;
		public BillingPeriodType? BillingPeriod {
			get {
				return this.BillingPeriodField;
			}
			set {
				this.BillingPeriodField = value;
			}
		}

		/**
		 * Installment Frequency.
		 * Optional     
		 */
		private int? BillingFrequencyField;
		public int? BillingFrequency {
			get {
				return this.BillingFrequencyField;
			}
			set {
				this.BillingFrequencyField = value;
			}
		}

		/**
		 * Installment Cycles.
		 * Optional     
		 */
		private int? TotalBillingCyclesField;
		public int? TotalBillingCycles {
			get {
				return this.TotalBillingCyclesField;
			}
			set {
				this.TotalBillingCyclesField = value;
			}
		}

		/**
		 * Installment Amount.
		 * Optional     
		 */
		private string AmountField;
		public string Amount {
			get {
				return this.AmountField;
			}
			set {
				this.AmountField = value;
			}
		}

		/**
		 * Installment Amount.
		 * Optional     
		 */
		private string ShippingAmountField;
		public string ShippingAmount {
			get {
				return this.ShippingAmountField;
			}
			set {
				this.ShippingAmountField = value;
			}
		}

		/**
		 * Installment Amount.
		 * Optional     
		 */
		private string TaxAmountField;
		public string TaxAmount {
			get {
				return this.TaxAmountField;
			}
			set {
				this.TaxAmountField = value;
			}
		}

		public InstallmentDetailsType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( BillingPeriod != null ) {
			sb.Append("<urn:BillingPeriod>").Append(EnumUtils.getDescription(BillingPeriod));
			sb.Append("</urn:BillingPeriod>");
		}
		if( BillingFrequency != null ) {
			sb.Append("<urn:BillingFrequency>").Append(BillingFrequency);
			sb.Append("</urn:BillingFrequency>");
		}
		if( TotalBillingCycles != null ) {
			sb.Append("<urn:TotalBillingCycles>").Append(TotalBillingCycles);
			sb.Append("</urn:TotalBillingCycles>");
		}
		if( Amount != null ) {
			sb.Append("<urn:Amount>").Append(Amount);
			sb.Append("</urn:Amount>");
		}
		if( ShippingAmount != null ) {
			sb.Append("<urn:ShippingAmount>").Append(ShippingAmount);
			sb.Append("</urn:ShippingAmount>");
		}
		if( TaxAmount != null ) {
			sb.Append("<urn:TaxAmount>").Append(TaxAmount);
			sb.Append("</urn:TaxAmount>");
		}
		return sb.ToString();
	}

	 public InstallmentDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("BillingPeriod").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillingPeriod")[0])){ 
		 this.BillingPeriod = (BillingPeriodType)EnumUtils.getValue(document.GetElementsByTagName("BillingPeriod")[0].InnerText,typeof(BillingPeriodType));

}
	}
		 if(document.GetElementsByTagName("BillingFrequency").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillingFrequency")[0])){ 
		 this.BillingFrequency =System.Convert.ToInt32(document.GetElementsByTagName("BillingFrequency")[0].InnerText);

}
	}
		 if(document.GetElementsByTagName("TotalBillingCycles").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TotalBillingCycles")[0])){ 
		 this.TotalBillingCycles =System.Convert.ToInt32(document.GetElementsByTagName("TotalBillingCycles")[0].InnerText);

}
	}
		 if(document.GetElementsByTagName("Amount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Amount")[0])){ 
		 this.Amount =(string)document.GetElementsByTagName("Amount")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ShippingAmount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ShippingAmount")[0])){ 
		 this.ShippingAmount =(string)document.GetElementsByTagName("ShippingAmount")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("TaxAmount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TaxAmount")[0])){ 
		 this.TaxAmount =(string)document.GetElementsByTagName("TaxAmount")[0].InnerText;

}
	}
	}
	}


	/**
	 * InstrumentDetailsType
	 * Promotional Instrument Information.
	 */
	public partial class InstrumentDetailsType {

		/**
		 * This field holds the category of the instrument only when it is promotional. Return value 1 represents BML.
		 */
		private string InstrumentCategoryField;
		public string InstrumentCategory {
			get {
				return this.InstrumentCategoryField;
			}
			set {
				this.InstrumentCategoryField = value;
			}
		}

	 public InstrumentDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("InstrumentCategory").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("InstrumentCategory")[0])){ 
		 nodeList = document.GetElementsByTagName("InstrumentCategory");
			 string value = nodeList[0].InnerText; 
		 this.InstrumentCategory =value;

}
	}
	}
	}


	/**
	 * Describes an individual item for an invoice.
	 */
	public partial class InvoiceItemType {

		/**
a human readable item nameOptional
		 * Character length and limits: 127 single-byte characters
		 */
		private string NameField;
		public string Name {
			get {
				return this.NameField;
			}
			set {
				this.NameField = value;
			}
		}

		/**
a human readable item descriptionOptional
		 * Character length and limits: 127 single-byte characters
		 */
		private string DescriptionField;
		public string Description {
			get {
				return this.DescriptionField;
			}
			set {
				this.DescriptionField = value;
			}
		}

		/**
		 * The International Article Number or 
		 * Universal Product Code (UPC) for the item.
		 * Empty string is allowed.
		 * Character length and limits: 17 single-byte characters
		 */
		private string EANField;
		public string EAN {
			get {
				return this.EANField;
			}
			set {
				this.EANField = value;
			}
		}

		/**
		 * The Stock-Keeping Unit or other identification 
		 * code assigned to the item.
		 * Character length and limits: 64 single-byte characters
		 */
		private string SKUField;
		public string SKU {
			get {
				return this.SKUField;
			}
			set {
				this.SKUField = value;
			}
		}

		/**
		 * A retailer could apply different return policies on different items.
		 * Each return policy would be identified using a label or identifier.
		 * This return policy identifier should be set here.  
		 * This identifier will be displayed next to the item in the e-Receipt.
		 * Character length and limits: 8 single-byte characters
		 */
		private string ReturnPolicyIdentifierField;
		public string ReturnPolicyIdentifier {
			get {
				return this.ReturnPolicyIdentifierField;
			}
			set {
				this.ReturnPolicyIdentifierField = value;
			}
		}

		/**
		 * total price of this item
		 */
		private BasicAmountType PriceField;
		public BasicAmountType Price {
			get {
				return this.PriceField;
			}
			set {
				this.PriceField = value;
			}
		}

		/**
		 * price per item quantity
		 */
		private BasicAmountType ItemPriceField;
		public BasicAmountType ItemPrice {
			get {
				return this.ItemPriceField;
			}
			set {
				this.ItemPriceField = value;
			}
		}

		/**
		 * quantity of the item (non-negative)
		 */
		private decimal? ItemCountField;
		public decimal? ItemCount {
			get {
				return this.ItemCountField;
			}
			set {
				this.ItemCountField = value;
			}
		}

		/**
		 * Unit of measure for the itemCount
		 */
		private UnitOfMeasure? ItemCountUnitField;
		public UnitOfMeasure? ItemCountUnit {
			get {
				return this.ItemCountUnitField;
			}
			set {
				this.ItemCountUnitField = value;
			}
		}

		/**
		 * discount applied to this item
		 */
		private List<DiscountType> DiscountField = new List<DiscountType>();
		public List<DiscountType> Discount {
			get {
				return this.DiscountField;
			}
			set {
				this.DiscountField = value;
			}
		}

		/**
		 * identifies whether this item is taxable or not.  
		 * If not passed, this will be assumed to be true.
		 */
		private bool? TaxableField;
		public bool? Taxable {
			get {
				return this.TaxableField;
			}
			set {
				this.TaxableField = value;
			}
		}

		/**
		 * The tax percentage applied to the item.
		 * This is only used for displaying in the receipt, it is not used in pricing calculations.
		 * Note: we have totalTax at invoice level. It's up to the caller to do the calculations for setting that other element.
		 */
		private decimal? TaxRateField;
		public decimal? TaxRate {
			get {
				return this.TaxRateField;
			}
			set {
				this.TaxRateField = value;
			}
		}

		/**
		 * Additional fees to this item
		 */
		private List<AdditionalFeeType> AdditionalFeesField = new List<AdditionalFeeType>();
		public List<AdditionalFeeType> AdditionalFees {
			get {
				return this.AdditionalFeesField;
			}
			set {
				this.AdditionalFeesField = value;
			}
		}

		/**
		 * identifies whether this is reimbursable or not.
		 * If not pass, this will be assumed to be true.
		 */
		private bool? ReimbursableField;
		public bool? Reimbursable {
			get {
				return this.ReimbursableField;
			}
			set {
				this.ReimbursableField = value;
			}
		}

		/**
		 * Manufacturer part number.
		 */
		private string MPNField;
		public string MPN {
			get {
				return this.MPNField;
			}
			set {
				this.MPNField = value;
			}
		}

		/**
		 * International Standard Book Number.
		 * Reference http://en.wikipedia.org/wiki/ISBN
		 * Character length and limits: 32 single-byte characters
		 */
		private string ISBNField;
		public string ISBN {
			get {
				return this.ISBNField;
			}
			set {
				this.ISBNField = value;
			}
		}

		/**
		 * Price Look-Up code
		 * Reference http://en.wikipedia.org/wiki/Price_Look-Up_code
		 * Character length and limits: 5 single-byte characters
		 */
		private string PLUField;
		public string PLU {
			get {
				return this.PLUField;
			}
			set {
				this.PLUField = value;
			}
		}

		/**
		 * Character length and limits: 32 single-byte characters
		 */
		private string ModelNumberField;
		public string ModelNumber {
			get {
				return this.ModelNumberField;
			}
			set {
				this.ModelNumberField = value;
			}
		}

		/**
		 * Character length and limits: 32 single-byte characters
		 */
		private string StyleNumberField;
		public string StyleNumber {
			get {
				return this.StyleNumberField;
			}
			set {
				this.StyleNumberField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( Name != null ) {
			sb.Append("<ebl:Name>").Append(Name);
			sb.Append("</ebl:Name>");
		}
		if( Description != null ) {
			sb.Append("<ebl:Description>").Append(Description);
			sb.Append("</ebl:Description>");
		}
		if( EAN != null ) {
			sb.Append("<ebl:EAN>").Append(EAN);
			sb.Append("</ebl:EAN>");
		}
		if( SKU != null ) {
			sb.Append("<ebl:SKU>").Append(SKU);
			sb.Append("</ebl:SKU>");
		}
		if( ReturnPolicyIdentifier != null ) {
			sb.Append("<ebl:ReturnPolicyIdentifier>").Append(ReturnPolicyIdentifier);
			sb.Append("</ebl:ReturnPolicyIdentifier>");
		}
		if( Price != null ) {
			sb.Append("<ebl:Price ");
			sb.Append(Price.toXMLString());
			sb.Append("</ebl:Price>");
		}
		if( ItemPrice != null ) {
			sb.Append("<ebl:ItemPrice ");
			sb.Append(ItemPrice.toXMLString());
			sb.Append("</ebl:ItemPrice>");
		}
		if( ItemCount != null ) {
			sb.Append("<ebl:ItemCount>").Append(ItemCount);
			sb.Append("</ebl:ItemCount>");
		}
		if( ItemCountUnit != null ) {
			sb.Append("<ebl:ItemCountUnit>").Append(EnumUtils.getDescription(ItemCountUnit));
			sb.Append("</ebl:ItemCountUnit>");
		}
		if( Discount != null ) {
			for(int i=0; i<Discount.Count; i++) {
				sb.Append("<ebl:Discount>");
				sb.Append(Discount[i].toXMLString());
				sb.Append("</ebl:Discount>");
			}
		}
		if( Taxable != null ) {
			sb.Append("<ebl:Taxable>").Append(Taxable);
			sb.Append("</ebl:Taxable>");
		}
		if( TaxRate != null ) {
			sb.Append("<ebl:TaxRate>").Append(TaxRate);
			sb.Append("</ebl:TaxRate>");
		}
		if( AdditionalFees != null ) {
			for(int i=0; i<AdditionalFees.Count; i++) {
				sb.Append("<ebl:AdditionalFees>");
				sb.Append(AdditionalFees[i].toXMLString());
				sb.Append("</ebl:AdditionalFees>");
			}
		}
		if( Reimbursable != null ) {
			sb.Append("<ebl:Reimbursable>").Append(Reimbursable);
			sb.Append("</ebl:Reimbursable>");
		}
		if( MPN != null ) {
			sb.Append("<ebl:MPN>").Append(MPN);
			sb.Append("</ebl:MPN>");
		}
		if( ISBN != null ) {
			sb.Append("<ebl:ISBN>").Append(ISBN);
			sb.Append("</ebl:ISBN>");
		}
		if( PLU != null ) {
			sb.Append("<ebl:PLU>").Append(PLU);
			sb.Append("</ebl:PLU>");
		}
		if( ModelNumber != null ) {
			sb.Append("<ebl:ModelNumber>").Append(ModelNumber);
			sb.Append("</ebl:ModelNumber>");
		}
		if( StyleNumber != null ) {
			sb.Append("<ebl:StyleNumber>").Append(StyleNumber);
			sb.Append("</ebl:StyleNumber>");
		}
		return sb.ToString();
	}

	}


	public enum ItemCategoryType {
[Description("Physical")]PHYSICAL,
[Description("Digital")]DIGITAL,
	}
	/**
	 * Item Number.
	 * Required
	 */
	public partial class ItemTrackingDetailsType {

		/**
		 * Item Number.
		 * Required
		 */
		private string ItemNumberField;
		public string ItemNumber {
			get {
				return this.ItemNumberField;
			}
			set {
				this.ItemNumberField = value;
			}
		}

		/**
		 * Option Quantity.
		 * Optional
		 */
		private string ItemQtyField;
		public string ItemQty {
			get {
				return this.ItemQtyField;
			}
			set {
				this.ItemQtyField = value;
			}
		}

		/**
		 * Item Quantity Delta.
		 * Optional
		 */
		private string ItemQtyDeltaField;
		public string ItemQtyDelta {
			get {
				return this.ItemQtyDeltaField;
			}
			set {
				this.ItemQtyDeltaField = value;
			}
		}

		/**
		 * Item Alert.
		 * Optional
		 */
		private string ItemAlertField;
		public string ItemAlert {
			get {
				return this.ItemAlertField;
			}
			set {
				this.ItemAlertField = value;
			}
		}

		/**
		 * Item Cost.
		 * Optional
		 */
		private string ItemCostField;
		public string ItemCost {
			get {
				return this.ItemCostField;
			}
			set {
				this.ItemCostField = value;
			}
		}

		public ItemTrackingDetailsType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( ItemNumber != null ) {
			sb.Append("<ebl:ItemNumber>").Append(ItemNumber);
			sb.Append("</ebl:ItemNumber>");
		}
		if( ItemQty != null ) {
			sb.Append("<ebl:ItemQty>").Append(ItemQty);
			sb.Append("</ebl:ItemQty>");
		}
		if( ItemQtyDelta != null ) {
			sb.Append("<ebl:ItemQtyDelta>").Append(ItemQtyDelta);
			sb.Append("</ebl:ItemQtyDelta>");
		}
		if( ItemAlert != null ) {
			sb.Append("<ebl:ItemAlert>").Append(ItemAlert);
			sb.Append("</ebl:ItemAlert>");
		}
		if( ItemCost != null ) {
			sb.Append("<ebl:ItemCost>").Append(ItemCost);
			sb.Append("</ebl:ItemCost>");
		}
		return sb.ToString();
	}

	 public ItemTrackingDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("ItemNumber").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ItemNumber")[0])){ 
		 this.ItemNumber =(string)document.GetElementsByTagName("ItemNumber")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ItemQty").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ItemQty")[0])){ 
		 this.ItemQty =(string)document.GetElementsByTagName("ItemQty")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ItemQtyDelta").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ItemQtyDelta")[0])){ 
		 this.ItemQtyDelta =(string)document.GetElementsByTagName("ItemQtyDelta")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ItemAlert").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ItemAlert")[0])){ 
		 this.ItemAlert =(string)document.GetElementsByTagName("ItemAlert")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ItemCost").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ItemCost")[0])){ 
		 this.ItemCost =(string)document.GetElementsByTagName("ItemCost")[0].InnerText;

}
	}
	}
	}


	public enum LandingPageType {
[Description("None")]NONE,
[Description("Login")]LOGIN,
[Description("Billing")]BILLING,
	}
	/**
	 */
	public partial class ManagePendingTransactionStatusReq {

		private ManagePendingTransactionStatusRequestType ManagePendingTransactionStatusRequestField;
		public ManagePendingTransactionStatusRequestType ManagePendingTransactionStatusRequest {
			get {
				return this.ManagePendingTransactionStatusRequestField;
			}
			set {
				this.ManagePendingTransactionStatusRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:ManagePendingTransactionStatusReq>");
		if( ManagePendingTransactionStatusRequest != null ) {
			sb.Append("<urn:ManagePendingTransactionStatusRequest>");
			sb.Append(ManagePendingTransactionStatusRequest.toXMLString());
			sb.Append("</urn:ManagePendingTransactionStatusRequest>");
		}
sb.Append("</urn:ManagePendingTransactionStatusReq>");
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class ManagePendingTransactionStatusRequestType :AbstractRequestType{

		private string TransactionIDField;
		public string TransactionID {
			get {
				return this.TransactionIDField;
			}
			set {
				this.TransactionIDField = value;
			}
		}

		private FMFPendingTransactionActionType? ActionField;
		public FMFPendingTransactionActionType? Action {
			get {
				return this.ActionField;
			}
			set {
				this.ActionField = value;
			}
		}

		public ManagePendingTransactionStatusRequestType(string TransactionID, FMFPendingTransactionActionType? Action) {
			this.TransactionID = TransactionID;
			this.Action = Action;
		}
		public ManagePendingTransactionStatusRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( TransactionID != null ) {
			sb.Append("<urn:TransactionID>").Append(TransactionID);
			sb.Append("</urn:TransactionID>");
		}
		if( Action != null ) {
			sb.Append("<urn:Action>").Append(EnumUtils.getDescription(Action));
			sb.Append("</urn:Action>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class ManagePendingTransactionStatusResponseType :AbstractResponseType{

		private string TransactionIDField;
		public string TransactionID {
			get {
				return this.TransactionIDField;
			}
			set {
				this.TransactionIDField = value;
			}
		}

		private string StatusField;
		public string Status {
			get {
				return this.StatusField;
			}
			set {
				this.StatusField = value;
			}
		}

	 public ManagePendingTransactionStatusResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("TransactionID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TransactionID")[0])){ 
		 this.TransactionID =(string)document.GetElementsByTagName("TransactionID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Status").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Status")[0])){ 
		 this.Status =(string)document.GetElementsByTagName("Status")[0].InnerText;

}
	}
	}
	}


	/**
	 */
	public partial class ManageRecurringPaymentsProfileStatusReq {

		private ManageRecurringPaymentsProfileStatusRequestType ManageRecurringPaymentsProfileStatusRequestField;
		public ManageRecurringPaymentsProfileStatusRequestType ManageRecurringPaymentsProfileStatusRequest {
			get {
				return this.ManageRecurringPaymentsProfileStatusRequestField;
			}
			set {
				this.ManageRecurringPaymentsProfileStatusRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:ManageRecurringPaymentsProfileStatusReq>");
		if( ManageRecurringPaymentsProfileStatusRequest != null ) {
			sb.Append("<urn:ManageRecurringPaymentsProfileStatusRequest>");
			sb.Append(ManageRecurringPaymentsProfileStatusRequest.toXMLString());
			sb.Append("</urn:ManageRecurringPaymentsProfileStatusRequest>");
		}
sb.Append("</urn:ManageRecurringPaymentsProfileStatusReq>");
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class ManageRecurringPaymentsProfileStatusRequestDetailsType {

		/**
		 */
		private string ProfileIDField;
		public string ProfileID {
			get {
				return this.ProfileIDField;
			}
			set {
				this.ProfileIDField = value;
			}
		}

		/**
		 */
		private StatusChangeActionType? ActionField;
		public StatusChangeActionType? Action {
			get {
				return this.ActionField;
			}
			set {
				this.ActionField = value;
			}
		}

		/**
		 */
		private string NoteField;
		public string Note {
			get {
				return this.NoteField;
			}
			set {
				this.NoteField = value;
			}
		}

		public ManageRecurringPaymentsProfileStatusRequestDetailsType(string ProfileID, StatusChangeActionType? Action) {
			this.ProfileID = ProfileID;
			this.Action = Action;
		}
		public ManageRecurringPaymentsProfileStatusRequestDetailsType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( ProfileID != null ) {
			sb.Append("<ebl:ProfileID>").Append(ProfileID);
			sb.Append("</ebl:ProfileID>");
		}
		if( Action != null ) {
			sb.Append("<ebl:Action>").Append(EnumUtils.getDescription(Action));
			sb.Append("</ebl:Action>");
		}
		if( Note != null ) {
			sb.Append("<ebl:Note>").Append(Note);
			sb.Append("</ebl:Note>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class ManageRecurringPaymentsProfileStatusRequestType :AbstractRequestType{

		private ManageRecurringPaymentsProfileStatusRequestDetailsType ManageRecurringPaymentsProfileStatusRequestDetailsField;
		public ManageRecurringPaymentsProfileStatusRequestDetailsType ManageRecurringPaymentsProfileStatusRequestDetails {
			get {
				return this.ManageRecurringPaymentsProfileStatusRequestDetailsField;
			}
			set {
				this.ManageRecurringPaymentsProfileStatusRequestDetailsField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( ManageRecurringPaymentsProfileStatusRequestDetails != null ) {
			sb.Append("<ebl:ManageRecurringPaymentsProfileStatusRequestDetails>");
			sb.Append(ManageRecurringPaymentsProfileStatusRequestDetails.toXMLString());
			sb.Append("</ebl:ManageRecurringPaymentsProfileStatusRequestDetails>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class ManageRecurringPaymentsProfileStatusResponseDetailsType {

		/**
		 */
		private string ProfileIDField;
		public string ProfileID {
			get {
				return this.ProfileIDField;
			}
			set {
				this.ProfileIDField = value;
			}
		}

	 public ManageRecurringPaymentsProfileStatusResponseDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("ProfileID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ProfileID")[0])){ 
		 nodeList = document.GetElementsByTagName("ProfileID");
			 string value = nodeList[0].InnerText; 
		 this.ProfileID =value;

}
	}
	}
	}


	/**
	 */
	public partial class ManageRecurringPaymentsProfileStatusResponseType :AbstractResponseType{

		private ManageRecurringPaymentsProfileStatusResponseDetailsType ManageRecurringPaymentsProfileStatusResponseDetailsField;
		public ManageRecurringPaymentsProfileStatusResponseDetailsType ManageRecurringPaymentsProfileStatusResponseDetails {
			get {
				return this.ManageRecurringPaymentsProfileStatusResponseDetailsField;
			}
			set {
				this.ManageRecurringPaymentsProfileStatusResponseDetailsField = value;
			}
		}

	 public ManageRecurringPaymentsProfileStatusResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("ManageRecurringPaymentsProfileStatusResponseDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ManageRecurringPaymentsProfileStatusResponseDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("ManageRecurringPaymentsProfileStatusResponseDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.ManageRecurringPaymentsProfileStatusResponseDetails =  new ManageRecurringPaymentsProfileStatusResponseDetailsType(xmlString);

}
	}
	}
	}


	public enum MarketingCategoryType {
[Description("Marketing-Category-Default")]MARKETINGCATEGORYDEFAULT,
[Description("Marketing-Category1")]MARKETINGCATEGORY1,
[Description("Marketing-Category2")]MARKETINGCATEGORY2,
[Description("Marketing-Category3")]MARKETINGCATEGORY3,
[Description("Marketing-Category4")]MARKETINGCATEGORY4,
[Description("Marketing-Category5")]MARKETINGCATEGORY5,
[Description("Marketing-Category6")]MARKETINGCATEGORY6,
[Description("Marketing-Category7")]MARKETINGCATEGORY7,
[Description("Marketing-Category8")]MARKETINGCATEGORY8,
[Description("Marketing-Category9")]MARKETINGCATEGORY9,
[Description("Marketing-Category10")]MARKETINGCATEGORY10,
[Description("Marketing-Category11")]MARKETINGCATEGORY11,
[Description("Marketing-Category12")]MARKETINGCATEGORY12,
[Description("Marketing-Category13")]MARKETINGCATEGORY13,
[Description("Marketing-Category14")]MARKETINGCATEGORY14,
[Description("Marketing-Category15")]MARKETINGCATEGORY15,
[Description("Marketing-Category16")]MARKETINGCATEGORY16,
[Description("Marketing-Category17")]MARKETINGCATEGORY17,
[Description("Marketing-Category18")]MARKETINGCATEGORY18,
[Description("Marketing-Category19")]MARKETINGCATEGORY19,
[Description("Marketing-Category20")]MARKETINGCATEGORY20,
	}
	/**
	 */
	public partial class MassPayReq {

		private MassPayRequestType MassPayRequestField;
		public MassPayRequestType MassPayRequest {
			get {
				return this.MassPayRequestField;
			}
			set {
				this.MassPayRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:MassPayReq>");
		if( MassPayRequest != null ) {
			sb.Append("<urn:MassPayRequest>");
			sb.Append(MassPayRequest.toXMLString());
			sb.Append("</urn:MassPayRequest>");
		}
sb.Append("</urn:MassPayReq>");
		return sb.ToString();
	}

	}


	/**
	 * MassPayRequestItemType
	 */
	public partial class MassPayRequestItemType {

		/**
Email address of recipient. 
		 * Required
		 * You must specify ReceiverEmail, ReceiverPhone, or ReceiverID, but all MassPayItems in a request must use the same field to specify recipients.
		 * Character length and limitations: 127 single-byte characters maximum.
		 */
		private string ReceiverEmailField;
		public string ReceiverEmail {
			get {
				return this.ReceiverEmailField;
			}
			set {
				this.ReceiverEmailField = value;
			}
		}

		/**
Phone number of recipient. 
		 * Required
		 * You must specify ReceiverEmail, ReceiverPhone, or ReceiverID, but all MassPayItems in a request must use the same field to specify recipients.
		 */
		private string ReceiverPhoneField;
		public string ReceiverPhone {
			get {
				return this.ReceiverPhoneField;
			}
			set {
				this.ReceiverPhoneField = value;
			}
		}

		/**
Unique PayPal customer account number. This value corresponds to the value of PayerID returned by GetTransactionDetails. 
		 * Required
		 * You must specify ReceiverEmail, ReceiverPhone, or ReceiverID, but all MassPayItems in a request must use the same field to specify recipients.
		 * Character length and limitations: 17 single-byte characters maximum.
		 */
		private string ReceiverIDField;
		public string ReceiverID {
			get {
				return this.ReceiverIDField;
			}
			set {
				this.ReceiverIDField = value;
			}
		}

		/**
Payment amount. You must set the currencyID attribute to one of the three-character currency codes for any of the supported PayPal currencies. 
		 * Required
		 * You cannot mix currencies in a single MassPayRequest. A single request must include items that are of the same currency.
		 */
		private BasicAmountType AmountField;
		public BasicAmountType Amount {
			get {
				return this.AmountField;
			}
			set {
				this.AmountField = value;
			}
		}

		/**
Transaction-specific identification number for tracking in an accounting system. 
		 * Optional
		 * Character length and limitations: 30 single-byte characters. No whitespace allowed.
		 */
		private string UniqueIdField;
		public string UniqueId {
			get {
				return this.UniqueIdField;
			}
			set {
				this.UniqueIdField = value;
			}
		}

		/**
Custom note for each recipient. 
		 * Optional
		 * Character length and limitations: 4,000 single-byte alphanumeric characters
		 */
		private string NoteField;
		public string Note {
			get {
				return this.NoteField;
			}
			set {
				this.NoteField = value;
			}
		}

		public MassPayRequestItemType(BasicAmountType Amount) {
			this.Amount = Amount;
		}
		public MassPayRequestItemType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( ReceiverEmail != null ) {
			sb.Append("<urn:ReceiverEmail>").Append(ReceiverEmail);
			sb.Append("</urn:ReceiverEmail>");
		}
		if( ReceiverPhone != null ) {
			sb.Append("<urn:ReceiverPhone>").Append(ReceiverPhone);
			sb.Append("</urn:ReceiverPhone>");
		}
		if( ReceiverID != null ) {
			sb.Append("<urn:ReceiverID>").Append(ReceiverID);
			sb.Append("</urn:ReceiverID>");
		}
		if( Amount != null ) {
			sb.Append("<urn:Amount ");
			sb.Append(Amount.toXMLString());
			sb.Append("</urn:Amount>");
		}
		if( UniqueId != null ) {
			sb.Append("<urn:UniqueId>").Append(UniqueId);
			sb.Append("</urn:UniqueId>");
		}
		if( Note != null ) {
			sb.Append("<urn:Note>").Append(Note);
			sb.Append("</urn:Note>");
		}
		return sb.ToString();
	}

	}


	/**
	 * Subject line of the email sent to all recipients. This subject is not contained in the input file; you must create it with your application. 
	 * Optional
	 * Character length and limitations: 255 single-byte alphanumeric characters
	 */
	public partial class MassPayRequestType :AbstractRequestType{

		/**
Subject line of the email sent to all recipients. This subject is not contained in the input file; you must create it with your application. 
		 * Optional
		 * Character length and limitations: 255 single-byte alphanumeric characters
		 */
		private string EmailSubjectField;
		public string EmailSubject {
			get {
				return this.EmailSubjectField;
			}
			set {
				this.EmailSubjectField = value;
			}
		}

		/**
Indicates how you identify the recipients of payments in all MassPayItems: either by EmailAddress (ReceiverEmail in MassPayItem), PhoneNumber (ReceiverPhone in MassPayItem), or by UserID (ReceiverID in MassPayItem). 
		 * Required. You must specify one or the other of EmailAddress or UserID.
		 */
		private ReceiverInfoCodeType? ReceiverTypeField;
		public ReceiverInfoCodeType? ReceiverType {
			get {
				return this.ReceiverTypeField;
			}
			set {
				this.ReceiverTypeField = value;
			}
		}

		/**
Known as BN code, to track the partner referred merchant transactions. 
		 * Optional
		 * Character length and limitations: 32 single-byte alphanumeric characters
		 */
		private string ButtonSourceField;
		public string ButtonSource {
			get {
				return this.ButtonSourceField;
			}
			set {
				this.ButtonSourceField = value;
			}
		}

		/**
Details of each payment. A single MassPayRequest can include up to 250 MassPayItems. 
		 * Required
		 */
		private List<MassPayRequestItemType> MassPayItemField = new List<MassPayRequestItemType>();
		public List<MassPayRequestItemType> MassPayItem {
			get {
				return this.MassPayItemField;
			}
			set {
				this.MassPayItemField = value;
			}
		}

		public MassPayRequestType(List<MassPayRequestItemType> MassPayItem) {
			this.MassPayItem = MassPayItem;
		}
		public MassPayRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( EmailSubject != null ) {
			sb.Append("<urn:EmailSubject>").Append(EmailSubject);
			sb.Append("</urn:EmailSubject>");
		}
		if( ReceiverType != null ) {
			sb.Append("<urn:ReceiverType>").Append(EnumUtils.getDescription(ReceiverType));
			sb.Append("</urn:ReceiverType>");
		}
		if( ButtonSource != null ) {
			sb.Append("<urn:ButtonSource>").Append(ButtonSource);
			sb.Append("</urn:ButtonSource>");
		}
		if( MassPayItem != null ) {
			for(int i=0; i<MassPayItem.Count; i++) {
				sb.Append("<urn:MassPayItem>");
				sb.Append(MassPayItem[i].toXMLString());
				sb.Append("</urn:MassPayItem>");
			}
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class MassPayResponseType :AbstractResponseType{

	 public MassPayResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
	}
	}


	public enum MatchStatusCodeType {
[Description("None")]NONE,
[Description("Matched")]MATCHED,
[Description("Unmatched")]UNMATCHED,
	}
	/**
	 */
	public partial class MeasureType {

		private string unitField;
		public string unit {
			get {
				return this.unitField;
			}
			set {
				this.unitField = value;
			}
		}

		private decimal? valueField;
		public decimal? value {
			get {
				return this.valueField;
			}
			set {
				this.valueField = value;
			}
		}

		public MeasureType(string unit, decimal? value) {
			this.unit = unit;
			this.value = value;
		}
		public MeasureType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( unit != null ) {
			sb.Append("<cc:unit>").Append(unit);
			sb.Append("</cc:unit>");
		}
		if( value != null ) {
sb.Append(value);		}
		return sb.ToString();
	}

	 public MeasureType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("unit").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("unit")[0])){ 
		 this.unit =(string)document.GetElementsByTagName("unit")[0].InnerText;

}
	}
		 this.value =System.Convert.ToDecimal(document.ChildNodes[0].InnerText);
	}
	}


	/**
	 * MerchantPullInfoType 
	 * Information about the merchant pull.
	 */
	public partial class MerchantPullInfoType {

		/**
		 * Current status of billing agreement 
		 */
		private MerchantPullStatusCodeType? MpStatusField;
		public MerchantPullStatusCodeType? MpStatus {
			get {
				return this.MpStatusField;
			}
			set {
				this.MpStatusField = value;
			}
		}

		/**
Monthly maximum payment amount		 */
		private BasicAmountType MpMaxField;
		public BasicAmountType MpMax {
			get {
				return this.MpMaxField;
			}
			set {
				this.MpMaxField = value;
			}
		}

		/**
The value of the mp_custom variable that you specified in a FORM submission to PayPal during the creation or updating of a customer billing agreement 
		 */
		private string MpCustomField;
		public string MpCustom {
			get {
				return this.MpCustomField;
			}
			set {
				this.MpCustomField = value;
			}
		}

		/**
The value of the mp_desc variable (description of goods or services) associated with the billing agreement 
		 */
		private string DescField;
		public string Desc {
			get {
				return this.DescField;
			}
			set {
				this.DescField = value;
			}
		}

		/**
Invoice value as set by BillUserRequest API call 		 */
		private string InvoiceField;
		public string Invoice {
			get {
				return this.InvoiceField;
			}
			set {
				this.InvoiceField = value;
			}
		}

		/**
Custom field as set by BillUserRequest API call 		 */
		private string CustomField;
		public string Custom {
			get {
				return this.CustomField;
			}
			set {
				this.CustomField = value;
			}
		}

		/**
Note: This field is no longer used and is always empty.		 */
		private string PaymentSourceIDField;
		public string PaymentSourceID {
			get {
				return this.PaymentSourceIDField;
			}
			set {
				this.PaymentSourceIDField = value;
			}
		}

	 public MerchantPullInfoType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("MpStatus").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("MpStatus")[0])){ 
		 this.MpStatus = (MerchantPullStatusCodeType)EnumUtils.getValue(document.GetElementsByTagName("MpStatus")[0].InnerText,typeof(MerchantPullStatusCodeType));

}
	}
		 if(document.GetElementsByTagName("MpMax").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("MpMax")[0])){ 
		 nodeList = document.GetElementsByTagName("MpMax");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.MpMax =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("MpCustom").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("MpCustom")[0])){ 
		 this.MpCustom =(string)document.GetElementsByTagName("MpCustom")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Desc").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Desc")[0])){ 
		 this.Desc =(string)document.GetElementsByTagName("Desc")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Invoice").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Invoice")[0])){ 
		 this.Invoice =(string)document.GetElementsByTagName("Invoice")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Custom").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Custom")[0])){ 
		 this.Custom =(string)document.GetElementsByTagName("Custom")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("PaymentSourceID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentSourceID")[0])){ 
		 this.PaymentSourceID =(string)document.GetElementsByTagName("PaymentSourceID")[0].InnerText;

}
	}
	}
	}


	public enum MerchantPullPaymentCodeType {
[Description("Any")]ANY,
[Description("InstantOnly")]INSTANTONLY,
[Description("EcheckOnly")]ECHECKONLY,
	}
	/**
	 * MerchantPullPaymentResponseType
	 * Response data from the merchant pull.
	 */
	public partial class MerchantPullPaymentResponseType {

		/**
		 * information about the customer		 */
		private PayerInfoType PayerInfoField;
		public PayerInfoType PayerInfo {
			get {
				return this.PayerInfoField;
			}
			set {
				this.PayerInfoField = value;
			}
		}

		/**
Information about the transaction 		 */
		private PaymentInfoType PaymentInfoField;
		public PaymentInfoType PaymentInfo {
			get {
				return this.PaymentInfoField;
			}
			set {
				this.PaymentInfoField = value;
			}
		}

		/**
		 * Specific information about the preapproved payment 		 */
		private MerchantPullInfoType MerchantPullInfoField;
		public MerchantPullInfoType MerchantPullInfo {
			get {
				return this.MerchantPullInfoField;
			}
			set {
				this.MerchantPullInfoField = value;
			}
		}

	 public MerchantPullPaymentResponseType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("PayerInfo").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PayerInfo")[0])){ 
		 nodeList = document.GetElementsByTagName("PayerInfo");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.PayerInfo =  new PayerInfoType(xmlString);

}
	}
		 if(document.GetElementsByTagName("PaymentInfo").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentInfo")[0])){ 
		 nodeList = document.GetElementsByTagName("PaymentInfo");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.PaymentInfo =  new PaymentInfoType(xmlString);

}
	}
		 if(document.GetElementsByTagName("MerchantPullInfo").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("MerchantPullInfo")[0])){ 
		 nodeList = document.GetElementsByTagName("MerchantPullInfo");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.MerchantPullInfo =  new MerchantPullInfoType(xmlString);

}
	}
	}
	}


	/**
	 * MerchantPullPayment 
	 * Parameters to make initiate a pull payment
	 */
	public partial class MerchantPullPaymentType {

		/**
		 * The amount to charge to the customer. 
		 * Required
		 * Only numeric characters and a decimal separator are allowed. Limit: 10 single-byte characters, including two for decimals You must set the currencyID attribute to one of the three-character currency code for any of the supported PayPal currencies. 
		 */
		private BasicAmountType AmountField;
		public BasicAmountType Amount {
			get {
				return this.AmountField;
			}
			set {
				this.AmountField = value;
			}
		}

		/**
		 * Preapproved Payments billing agreement identification number between the PayPal customer and you. 
		 * Required
		 * Character limit: 19 single-byte alphanumeric characters.
		 * The format of a billing agreement identification number is the single-character prefix B, followed by a hyphen and an alphanumeric character string: 
		 * B-unique_alphanumeric_string
		 */
		private string MpIDField;
		public string MpID {
			get {
				return this.MpIDField;
			}
			set {
				this.MpIDField = value;
			}
		}

		/**
Specifies type of PayPal payment you require 
		 * Optional
		 */
		private MerchantPullPaymentCodeType? PaymentTypeField;
		public MerchantPullPaymentCodeType? PaymentType {
			get {
				return this.PaymentTypeField;
			}
			set {
				this.PaymentTypeField = value;
			}
		}

		/**
Text entered by the customer in the Note field during enrollment 
		 * Optional
		 */
		private string MemoField;
		public string Memo {
			get {
				return this.MemoField;
			}
			set {
				this.MemoField = value;
			}
		}

		/**
Subject line of confirmation email sent to recipient
		 * Optional
		 */
		private string EmailSubjectField;
		public string EmailSubject {
			get {
				return this.EmailSubjectField;
			}
			set {
				this.EmailSubjectField = value;
			}
		}

		/**
The tax charged on the transaction
		 * Optional
		 */
		private BasicAmountType TaxField;
		public BasicAmountType Tax {
			get {
				return this.TaxField;
			}
			set {
				this.TaxField = value;
			}
		}

		/**
Per-transaction shipping charge 
		 * Optional		 */
		private BasicAmountType ShippingField;
		public BasicAmountType Shipping {
			get {
				return this.ShippingField;
			}
			set {
				this.ShippingField = value;
			}
		}

		/**
Per-transaction handling charge
		 * Optional		 */
		private BasicAmountType HandlingField;
		public BasicAmountType Handling {
			get {
				return this.HandlingField;
			}
			set {
				this.HandlingField = value;
			}
		}

		/**
Name of purchased item
		 * Optional		 */
		private string ItemNameField;
		public string ItemName {
			get {
				return this.ItemNameField;
			}
			set {
				this.ItemNameField = value;
			}
		}

		/**
Reference number of purchased item
		 * Optional		 */
		private string ItemNumberField;
		public string ItemNumber {
			get {
				return this.ItemNumberField;
			}
			set {
				this.ItemNumberField = value;
			}
		}

		/**
Your invoice number  
		 * Optional
		 */
		private string InvoiceField;
		public string Invoice {
			get {
				return this.InvoiceField;
			}
			set {
				this.InvoiceField = value;
			}
		}

		/**
Custom annotation field for tracking or other use
		 * Optional
		 */
		private string CustomField;
		public string Custom {
			get {
				return this.CustomField;
			}
			set {
				this.CustomField = value;
			}
		}

		/**
An identification code for use by third-party applications to identify transactions. 
		 * Optional
		 * Character length and limitations: 32 single-byte alphanumeric characters
		 */
		private string ButtonSourceField;
		public string ButtonSource {
			get {
				return this.ButtonSourceField;
			}
			set {
				this.ButtonSourceField = value;
			}
		}

		/**
Passed in soft descriptor string to be appended. 
		 * Optional
		 * Character length and limitations: single-byte alphanumeric characters
		 */
		private string SoftDescriptorField;
		public string SoftDescriptor {
			get {
				return this.SoftDescriptorField;
			}
			set {
				this.SoftDescriptorField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( Amount != null ) {
			sb.Append("<ebl:Amount ");
			sb.Append(Amount.toXMLString());
			sb.Append("</ebl:Amount>");
		}
		if( MpID != null ) {
			sb.Append("<ebl:MpID>").Append(MpID);
			sb.Append("</ebl:MpID>");
		}
		if( PaymentType != null ) {
			sb.Append("<ebl:PaymentType>").Append(EnumUtils.getDescription(PaymentType));
			sb.Append("</ebl:PaymentType>");
		}
		if( Memo != null ) {
			sb.Append("<ebl:Memo>").Append(Memo);
			sb.Append("</ebl:Memo>");
		}
		if( EmailSubject != null ) {
			sb.Append("<ebl:EmailSubject>").Append(EmailSubject);
			sb.Append("</ebl:EmailSubject>");
		}
		if( Tax != null ) {
			sb.Append("<ebl:Tax ");
			sb.Append(Tax.toXMLString());
			sb.Append("</ebl:Tax>");
		}
		if( Shipping != null ) {
			sb.Append("<ebl:Shipping ");
			sb.Append(Shipping.toXMLString());
			sb.Append("</ebl:Shipping>");
		}
		if( Handling != null ) {
			sb.Append("<ebl:Handling ");
			sb.Append(Handling.toXMLString());
			sb.Append("</ebl:Handling>");
		}
		if( ItemName != null ) {
			sb.Append("<ebl:ItemName>").Append(ItemName);
			sb.Append("</ebl:ItemName>");
		}
		if( ItemNumber != null ) {
			sb.Append("<ebl:ItemNumber>").Append(ItemNumber);
			sb.Append("</ebl:ItemNumber>");
		}
		if( Invoice != null ) {
			sb.Append("<ebl:Invoice>").Append(Invoice);
			sb.Append("</ebl:Invoice>");
		}
		if( Custom != null ) {
			sb.Append("<ebl:Custom>").Append(Custom);
			sb.Append("</ebl:Custom>");
		}
		if( ButtonSource != null ) {
			sb.Append("<ebl:ButtonSource>").Append(ButtonSource);
			sb.Append("</ebl:ButtonSource>");
		}
		if( SoftDescriptor != null ) {
			sb.Append("<ebl:SoftDescriptor>").Append(SoftDescriptor);
			sb.Append("</ebl:SoftDescriptor>");
		}
		return sb.ToString();
	}

	}


	public enum MerchantPullStatusCodeType {
[Description("Active")]ACTIVE,
[Description("Canceled")]CANCELED,
	}
	/**
	 * Store IDOptional
	 * Character length and limits: 50 single-byte characters
	 */
	public partial class MerchantStoreDetailsType {

		/**
Store IDOptional
		 * Character length and limits: 50 single-byte characters
		 */
		private string StoreIDField;
		public string StoreID {
			get {
				return this.StoreIDField;
			}
			set {
				this.StoreIDField = value;
			}
		}

		/**
Terminal IDOptional
		 * Character length and limits: 50 single-byte characters
		 */
		private string TerminalIDField;
		public string TerminalID {
			get {
				return this.TerminalIDField;
			}
			set {
				this.TerminalIDField = value;
			}
		}

		public MerchantStoreDetailsType(string StoreID) {
			this.StoreID = StoreID;
		}
		public MerchantStoreDetailsType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( StoreID != null ) {
			sb.Append("<ebl:StoreID>").Append(StoreID);
			sb.Append("</ebl:StoreID>");
		}
		if( TerminalID != null ) {
			sb.Append("<ebl:TerminalID>").Append(TerminalID);
			sb.Append("</ebl:TerminalID>");
		}
		return sb.ToString();
	}

	}


	/**
	 * The Session token returned during buyer authentication.
	 */
	public partial class MobileIDInfoType {

		/**
The Session token returned during buyer authentication.		 */
		private string SessionTokenField;
		public string SessionToken {
			get {
				return this.SessionTokenField;
			}
			set {
				this.SessionTokenField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( SessionToken != null ) {
			sb.Append("<ebl:SessionToken>").Append(SessionToken);
			sb.Append("</ebl:SessionToken>");
		}
		return sb.ToString();
	}

	}


	public enum MobilePaymentCodeType {
[Description("P2P")]PP,
[Description("HardGoods")]HARDGOODS,
[Description("Donation")]DONATION,
[Description("TopUp")]TOPUP,
	}
	public enum MobileRecipientCodeType {
[Description("PhoneNumber")]PHONENUMBER,
[Description("EmailAddress")]EMAILADDRESS,
	}
	/**
	 * OffersAndCouponsInfoType
	 * Information about a Offers and Coupons.
	 */
	public partial class OfferCouponInfoType {

		/**
		 * Type of the incentive 		 */
		private string TypeField;
		public string Type {
			get {
				return this.TypeField;
			}
			set {
				this.TypeField = value;
			}
		}

		/**
		 * ID of the Incentive used in transaction		 */
		private string IDField;
		public string ID {
			get {
				return this.IDField;
			}
			set {
				this.IDField = value;
			}
		}

		/**
		 * Amount used on transaction		 */
		private string AmountField;
		public string Amount {
			get {
				return this.AmountField;
			}
			set {
				this.AmountField = value;
			}
		}

		/**
		 * Amount Currency		 */
		private string AmountCurrencyField;
		public string AmountCurrency {
			get {
				return this.AmountCurrencyField;
			}
			set {
				this.AmountCurrencyField = value;
			}
		}

	 public OfferCouponInfoType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Type").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Type")[0])){ 
		 this.Type =(string)document.GetElementsByTagName("Type")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ID")[0])){ 
		 this.ID =(string)document.GetElementsByTagName("ID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Amount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Amount")[0])){ 
		 this.Amount =(string)document.GetElementsByTagName("Amount")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("AmountCurrency").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AmountCurrency")[0])){ 
		 this.AmountCurrency =(string)document.GetElementsByTagName("AmountCurrency")[0].InnerText;

}
	}
	}
	}


	/**
	 * OfferDetailsType
	 * Specific information for an offer.
	 */
	public partial class OfferDetailsType {

		/**
		 * Code used to identify the promotion offer.
		 */
		private string OfferCodeField;
		public string OfferCode {
			get {
				return this.OfferCodeField;
			}
			set {
				this.OfferCodeField = value;
			}
		}

		/**
		 * Specific infromation for BML, Similar structure could be added for sepcific
		 * promotion needs like CrossPromotions
		 */
		private BMLOfferInfoType BMLOfferInfoField;
		public BMLOfferInfoType BMLOfferInfo {
			get {
				return this.BMLOfferInfoField;
			}
			set {
				this.BMLOfferInfoField = value;
			}
		}

		public OfferDetailsType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( OfferCode != null ) {
			sb.Append("<ebl:OfferCode>").Append(OfferCode);
			sb.Append("</ebl:OfferCode>");
		}
		if( BMLOfferInfo != null ) {
			sb.Append("<ebl:BMLOfferInfo>");
			sb.Append(BMLOfferInfo.toXMLString());
			sb.Append("</ebl:BMLOfferInfo>");
		}
		return sb.ToString();
	}

	 public OfferDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("OfferCode").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OfferCode")[0])){ 
		 this.OfferCode =(string)document.GetElementsByTagName("OfferCode")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("BMLOfferInfo").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BMLOfferInfo")[0])){ 
		 nodeList = document.GetElementsByTagName("BMLOfferInfo");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.BMLOfferInfo =  new BMLOfferInfoType(xmlString);

}
	}
	}
	}


	/**
	 * Option Name.
	 * Optional
	 */
	public partial class OptionDetailsType {

		/**
		 * Option Name.
		 * Optional
		 */
		private string OptionNameField;
		public string OptionName {
			get {
				return this.OptionNameField;
			}
			set {
				this.OptionNameField = value;
			}
		}

		private List<OptionSelectionDetailsType> OptionSelectionDetailsField = new List<OptionSelectionDetailsType>();
		public List<OptionSelectionDetailsType> OptionSelectionDetails {
			get {
				return this.OptionSelectionDetailsField;
			}
			set {
				this.OptionSelectionDetailsField = value;
			}
		}

		public OptionDetailsType(string OptionName) {
			this.OptionName = OptionName;
		}
		public OptionDetailsType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( OptionName != null ) {
			sb.Append("<urn:OptionName>").Append(OptionName);
			sb.Append("</urn:OptionName>");
		}
		if( OptionSelectionDetails != null ) {
			for(int i=0; i<OptionSelectionDetails.Count; i++) {
				sb.Append("<urn:OptionSelectionDetails>");
				sb.Append(OptionSelectionDetails[i].toXMLString());
				sb.Append("</urn:OptionSelectionDetails>");
			}
		}
		return sb.ToString();
	}

	 public OptionDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("OptionName").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OptionName")[0])){ 
		 this.OptionName =(string)document.GetElementsByTagName("OptionName")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("OptionSelectionDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OptionSelectionDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("OptionSelectionDetails");
		 for(int i=0; i<nodeList.Count; i++) {
			 xmlString = DeserializationUtils.convertToXML(nodeList[i]); 
				this.OptionSelectionDetails.Add(new OptionSelectionDetailsType(xmlString));
			}

}
	}
	}
	}


	/**
	 * Option Selection.
	 * Required
	 * Character length and limitations: 12 single-byte alphanumeric characters
	 */
	public partial class OptionSelectionDetailsType {

		/**
		 * Option Selection.
		 * Required
		 * Character length and limitations: 12 single-byte alphanumeric characters
		 */
		private string OptionSelectionField;
		public string OptionSelection {
			get {
				return this.OptionSelectionField;
			}
			set {
				this.OptionSelectionField = value;
			}
		}

		/**
		 * Option Price.
		 * Optional     
		 */
		private string PriceField;
		public string Price {
			get {
				return this.PriceField;
			}
			set {
				this.PriceField = value;
			}
		}

		/**
		 * Option Type
		 * Optional
		 */
		private OptionTypeListType? OptionTypeField;
		public OptionTypeListType? OptionType {
			get {
				return this.OptionTypeField;
			}
			set {
				this.OptionTypeField = value;
			}
		}

		private List<InstallmentDetailsType> PaymentPeriodField = new List<InstallmentDetailsType>();
		public List<InstallmentDetailsType> PaymentPeriod {
			get {
				return this.PaymentPeriodField;
			}
			set {
				this.PaymentPeriodField = value;
			}
		}

		public OptionSelectionDetailsType(string OptionSelection) {
			this.OptionSelection = OptionSelection;
		}
		public OptionSelectionDetailsType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( OptionSelection != null ) {
			sb.Append("<urn:OptionSelection>").Append(OptionSelection);
			sb.Append("</urn:OptionSelection>");
		}
		if( Price != null ) {
			sb.Append("<urn:Price>").Append(Price);
			sb.Append("</urn:Price>");
		}
		if( OptionType != null ) {
			sb.Append("<urn:OptionType>").Append(EnumUtils.getDescription(OptionType));
			sb.Append("</urn:OptionType>");
		}
		if( PaymentPeriod != null ) {
			for(int i=0; i<PaymentPeriod.Count; i++) {
				sb.Append("<urn:PaymentPeriod>");
				sb.Append(PaymentPeriod[i].toXMLString());
				sb.Append("</urn:PaymentPeriod>");
			}
		}
		return sb.ToString();
	}

	 public OptionSelectionDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("OptionSelection").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OptionSelection")[0])){ 
		 this.OptionSelection =(string)document.GetElementsByTagName("OptionSelection")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Price").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Price")[0])){ 
		 this.Price =(string)document.GetElementsByTagName("Price")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("OptionType").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OptionType")[0])){ 
		 this.OptionType = (OptionTypeListType)EnumUtils.getValue(document.GetElementsByTagName("OptionType")[0].InnerText,typeof(OptionTypeListType));

}
	}
		 if(document.GetElementsByTagName("PaymentPeriod").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentPeriod")[0])){ 
		 nodeList = document.GetElementsByTagName("PaymentPeriod");
		 for(int i=0; i<nodeList.Count; i++) {
			 xmlString = DeserializationUtils.convertToXML(nodeList[i]); 
				this.PaymentPeriod.Add(new InstallmentDetailsType(xmlString));
			}

}
	}
	}
	}


	/**
	 * Option Number.
	 * Optional
	 */
	public partial class OptionTrackingDetailsType {

		/**
		 * Option Number.
		 * Optional
		 */
		private string OptionNumberField;
		public string OptionNumber {
			get {
				return this.OptionNumberField;
			}
			set {
				this.OptionNumberField = value;
			}
		}

		/**
		 * Option Quantity.
		 * Optional
		 */
		private string OptionQtyField;
		public string OptionQty {
			get {
				return this.OptionQtyField;
			}
			set {
				this.OptionQtyField = value;
			}
		}

		/**
		 * Option Select Name.
		 * Optional
		 */
		private string OptionSelectField;
		public string OptionSelect {
			get {
				return this.OptionSelectField;
			}
			set {
				this.OptionSelectField = value;
			}
		}

		/**
		 * Option Quantity Delta.
		 * Optional
		 */
		private string OptionQtyDeltaField;
		public string OptionQtyDelta {
			get {
				return this.OptionQtyDeltaField;
			}
			set {
				this.OptionQtyDeltaField = value;
			}
		}

		/**
		 * Option Alert.
		 * Optional
		 */
		private string OptionAlertField;
		public string OptionAlert {
			get {
				return this.OptionAlertField;
			}
			set {
				this.OptionAlertField = value;
			}
		}

		/**
		 * Option Cost.
		 * Optional
		 */
		private string OptionCostField;
		public string OptionCost {
			get {
				return this.OptionCostField;
			}
			set {
				this.OptionCostField = value;
			}
		}

		public OptionTrackingDetailsType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( OptionNumber != null ) {
			sb.Append("<ebl:OptionNumber>").Append(OptionNumber);
			sb.Append("</ebl:OptionNumber>");
		}
		if( OptionQty != null ) {
			sb.Append("<ebl:OptionQty>").Append(OptionQty);
			sb.Append("</ebl:OptionQty>");
		}
		if( OptionSelect != null ) {
			sb.Append("<ebl:OptionSelect>").Append(OptionSelect);
			sb.Append("</ebl:OptionSelect>");
		}
		if( OptionQtyDelta != null ) {
			sb.Append("<ebl:OptionQtyDelta>").Append(OptionQtyDelta);
			sb.Append("</ebl:OptionQtyDelta>");
		}
		if( OptionAlert != null ) {
			sb.Append("<ebl:OptionAlert>").Append(OptionAlert);
			sb.Append("</ebl:OptionAlert>");
		}
		if( OptionCost != null ) {
			sb.Append("<ebl:OptionCost>").Append(OptionCost);
			sb.Append("</ebl:OptionCost>");
		}
		return sb.ToString();
	}

	 public OptionTrackingDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("OptionNumber").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OptionNumber")[0])){ 
		 this.OptionNumber =(string)document.GetElementsByTagName("OptionNumber")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("OptionQty").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OptionQty")[0])){ 
		 this.OptionQty =(string)document.GetElementsByTagName("OptionQty")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("OptionSelect").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OptionSelect")[0])){ 
		 this.OptionSelect =(string)document.GetElementsByTagName("OptionSelect")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("OptionQtyDelta").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OptionQtyDelta")[0])){ 
		 this.OptionQtyDelta =(string)document.GetElementsByTagName("OptionQtyDelta")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("OptionAlert").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OptionAlert")[0])){ 
		 this.OptionAlert =(string)document.GetElementsByTagName("OptionAlert")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("OptionCost").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OptionCost")[0])){ 
		 this.OptionCost =(string)document.GetElementsByTagName("OptionCost")[0].InnerText;

}
	}
	}
	}


	/**
	 * OptionType 
	 * PayPal item options for shopping cart.
	 */
	public partial class OptionType {

	 public OptionType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
	}
	}


	public enum OptionTypeListType {
[Description("NoOptionType")]NOOPTIONTYPE,
[Description("FULL")]FULL,
[Description("EMI")]EMI,
[Description("VARIABLE")]VARIABLE,
	}
	/**
	 * Description of the Order.
	 */
	public partial class OrderDetailsType {

		/**
Description of the Order.		 */
		private string DescriptionField;
		public string Description {
			get {
				return this.DescriptionField;
			}
			set {
				this.DescriptionField = value;
			}
		}

		/**
Expected maximum amount that the merchant may pull using DoReferenceTransaction		 */
		private BasicAmountType MaxAmountField;
		public BasicAmountType MaxAmount {
			get {
				return this.MaxAmountField;
			}
			set {
				this.MaxAmountField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( Description != null ) {
			sb.Append("<ebl:Description>").Append(Description);
			sb.Append("</ebl:Description>");
		}
		if( MaxAmount != null ) {
			sb.Append("<ebl:MaxAmount ");
			sb.Append(MaxAmount.toXMLString());
			sb.Append("</ebl:MaxAmount>");
		}
		return sb.ToString();
	}

	}


	/**
	 * Lists the Payment Methods (other than PayPal) that the use can pay with e.g. Money Order. 
	 * Optional.
	 */
	public partial class OtherPaymentMethodDetailsType {

		/**
		 * The identifier of the Payment Method.
		 */
		private string OtherPaymentMethodIdField;
		public string OtherPaymentMethodId {
			get {
				return this.OtherPaymentMethodIdField;
			}
			set {
				this.OtherPaymentMethodIdField = value;
			}
		}

		/**
		 * Valid values are 'Method', 'SubMethod'.
		 */
		private string OtherPaymentMethodTypeField;
		public string OtherPaymentMethodType {
			get {
				return this.OtherPaymentMethodTypeField;
			}
			set {
				this.OtherPaymentMethodTypeField = value;
			}
		}

		/**
		 * The name of the Payment Method.
		 */
		private string OtherPaymentMethodLabelField;
		public string OtherPaymentMethodLabel {
			get {
				return this.OtherPaymentMethodLabelField;
			}
			set {
				this.OtherPaymentMethodLabelField = value;
			}
		}

		/**
		 * The short description of the Payment Method, goes along with the label.
		 */
		private string OtherPaymentMethodLabelDescriptionField;
		public string OtherPaymentMethodLabelDescription {
			get {
				return this.OtherPaymentMethodLabelDescriptionField;
			}
			set {
				this.OtherPaymentMethodLabelDescriptionField = value;
			}
		}

		/**
		 * The title for the long description.
		 */
		private string OtherPaymentMethodLongDescriptionTitleField;
		public string OtherPaymentMethodLongDescriptionTitle {
			get {
				return this.OtherPaymentMethodLongDescriptionTitleField;
			}
			set {
				this.OtherPaymentMethodLongDescriptionTitleField = value;
			}
		}

		/**
		 * The long description of the Payment Method.
		 */
		private string OtherPaymentMethodLongDescriptionField;
		public string OtherPaymentMethodLongDescription {
			get {
				return this.OtherPaymentMethodLongDescriptionField;
			}
			set {
				this.OtherPaymentMethodLongDescriptionField = value;
			}
		}

		/**
		 * The icon of the Payment Method.
		 */
		private string OtherPaymentMethodIconField;
		public string OtherPaymentMethodIcon {
			get {
				return this.OtherPaymentMethodIconField;
			}
			set {
				this.OtherPaymentMethodIconField = value;
			}
		}

		/**
		 * If this flag is true, then OtherPaymentMethodIcon is required to have a valid value; the label will be hidden and only ICON will be shown.
		 */
		private bool? OtherPaymentMethodHideLabelField;
		public bool? OtherPaymentMethodHideLabel {
			get {
				return this.OtherPaymentMethodHideLabelField;
			}
			set {
				this.OtherPaymentMethodHideLabelField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( OtherPaymentMethodId != null ) {
			sb.Append("<ebl:OtherPaymentMethodId>").Append(OtherPaymentMethodId);
			sb.Append("</ebl:OtherPaymentMethodId>");
		}
		if( OtherPaymentMethodType != null ) {
			sb.Append("<ebl:OtherPaymentMethodType>").Append(OtherPaymentMethodType);
			sb.Append("</ebl:OtherPaymentMethodType>");
		}
		if( OtherPaymentMethodLabel != null ) {
			sb.Append("<ebl:OtherPaymentMethodLabel>").Append(OtherPaymentMethodLabel);
			sb.Append("</ebl:OtherPaymentMethodLabel>");
		}
		if( OtherPaymentMethodLabelDescription != null ) {
			sb.Append("<ebl:OtherPaymentMethodLabelDescription>").Append(OtherPaymentMethodLabelDescription);
			sb.Append("</ebl:OtherPaymentMethodLabelDescription>");
		}
		if( OtherPaymentMethodLongDescriptionTitle != null ) {
			sb.Append("<ebl:OtherPaymentMethodLongDescriptionTitle>").Append(OtherPaymentMethodLongDescriptionTitle);
			sb.Append("</ebl:OtherPaymentMethodLongDescriptionTitle>");
		}
		if( OtherPaymentMethodLongDescription != null ) {
			sb.Append("<ebl:OtherPaymentMethodLongDescription>").Append(OtherPaymentMethodLongDescription);
			sb.Append("</ebl:OtherPaymentMethodLongDescription>");
		}
		if( OtherPaymentMethodIcon != null ) {
			sb.Append("<ebl:OtherPaymentMethodIcon>").Append(OtherPaymentMethodIcon);
			sb.Append("</ebl:OtherPaymentMethodIcon>");
		}
		if( OtherPaymentMethodHideLabel != null ) {
			sb.Append("<ebl:OtherPaymentMethodHideLabel>").Append(OtherPaymentMethodHideLabel);
			sb.Append("</ebl:OtherPaymentMethodHideLabel>");
		}
		return sb.ToString();
	}

	}


	public enum PayPalUserStatusCodeType {
[Description("verified")]VERIFIED,
[Description("unverified")]UNVERIFIED,
	}
	/**
	 * PayerInfoType 
	 * Payer information
	 */
	public partial class PayerInfoType {

		/**
		 * Email address of payer 
Character length and limitations: 127 single-byte characters
		 */
		private string PayerField;
		public string Payer {
			get {
				return this.PayerField;
			}
			set {
				this.PayerField = value;
			}
		}

		/**
		 * Unique customer ID 
Character length and limitations: 17 single-byte characters
		 */
		private string PayerIDField;
		public string PayerID {
			get {
				return this.PayerIDField;
			}
			set {
				this.PayerIDField = value;
			}
		}

		/**
		 * Status of payer's email address
		 */
		private PayPalUserStatusCodeType? PayerStatusField;
		public PayPalUserStatusCodeType? PayerStatus {
			get {
				return this.PayerStatusField;
			}
			set {
				this.PayerStatusField = value;
			}
		}

		/**
		 * Name of payer 		 */
		private PersonNameType PayerNameField;
		public PersonNameType PayerName {
			get {
				return this.PayerNameField;
			}
			set {
				this.PayerNameField = value;
			}
		}

		/**
		 * Payment sender's country of residence using standard two-character ISO 3166 country codes. 
Character length and limitations: Two single-byte characters
		 */
		private CountryCodeType? PayerCountryField;
		public CountryCodeType? PayerCountry {
			get {
				return this.PayerCountryField;
			}
			set {
				this.PayerCountryField = value;
			}
		}

		/**
		 * Payer's business name. 
Character length and limitations: 127 single-byte characters		 */
		private string PayerBusinessField;
		public string PayerBusiness {
			get {
				return this.PayerBusinessField;
			}
			set {
				this.PayerBusinessField = value;
			}
		}

		/**
		 * Payer's business address		 */
		private AddressType AddressField;
		public AddressType Address {
			get {
				return this.AddressField;
			}
			set {
				this.AddressField = value;
			}
		}

		/**
Business contact telephone number		 */
		private string ContactPhoneField;
		public string ContactPhone {
			get {
				return this.ContactPhoneField;
			}
			set {
				this.ContactPhoneField = value;
			}
		}

		/**
		 * Details about payer's tax info.
		 * Refer to the TaxIdDetailsType for more details.
		 */
		private TaxIdDetailsType TaxIdDetailsField;
		public TaxIdDetailsType TaxIdDetails {
			get {
				return this.TaxIdDetailsField;
			}
			set {
				this.TaxIdDetailsField = value;
			}
		}

		/**
Holds any enhanced information about the payer		 */
		private EnhancedPayerInfoType EnhancedPayerInfoField;
		public EnhancedPayerInfoType EnhancedPayerInfo {
			get {
				return this.EnhancedPayerInfoField;
			}
			set {
				this.EnhancedPayerInfoField = value;
			}
		}

		public PayerInfoType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( Payer != null ) {
			sb.Append("<ebl:Payer>").Append(Payer);
			sb.Append("</ebl:Payer>");
		}
		if( PayerID != null ) {
			sb.Append("<ebl:PayerID>").Append(PayerID);
			sb.Append("</ebl:PayerID>");
		}
		if( PayerStatus != null ) {
			sb.Append("<ebl:PayerStatus>").Append(EnumUtils.getDescription(PayerStatus));
			sb.Append("</ebl:PayerStatus>");
		}
		if( PayerName != null ) {
			sb.Append("<ebl:PayerName>");
			sb.Append(PayerName.toXMLString());
			sb.Append("</ebl:PayerName>");
		}
		if( PayerCountry != null ) {
			sb.Append("<ebl:PayerCountry>").Append(EnumUtils.getDescription(PayerCountry));
			sb.Append("</ebl:PayerCountry>");
		}
		if( PayerBusiness != null ) {
			sb.Append("<ebl:PayerBusiness>").Append(PayerBusiness);
			sb.Append("</ebl:PayerBusiness>");
		}
		if( Address != null ) {
			sb.Append("<ebl:Address>");
			sb.Append(Address.toXMLString());
			sb.Append("</ebl:Address>");
		}
		if( ContactPhone != null ) {
			sb.Append("<ebl:ContactPhone>").Append(ContactPhone);
			sb.Append("</ebl:ContactPhone>");
		}
		if( TaxIdDetails != null ) {
			sb.Append("<ebl:TaxIdDetails>");
			sb.Append(TaxIdDetails.toXMLString());
			sb.Append("</ebl:TaxIdDetails>");
		}
		if( EnhancedPayerInfo != null ) {
			sb.Append("<ebl:EnhancedPayerInfo>");
			sb.Append(EnhancedPayerInfo.toXMLString());
			sb.Append("</ebl:EnhancedPayerInfo>");
		}
		return sb.ToString();
	}

	 public PayerInfoType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Payer").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Payer")[0])){ 
		 this.Payer =(string)document.GetElementsByTagName("Payer")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("PayerID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PayerID")[0])){ 
		 this.PayerID =(string)document.GetElementsByTagName("PayerID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("PayerStatus").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PayerStatus")[0])){ 
		 this.PayerStatus = (PayPalUserStatusCodeType)EnumUtils.getValue(document.GetElementsByTagName("PayerStatus")[0].InnerText,typeof(PayPalUserStatusCodeType));

}
	}
		 if(document.GetElementsByTagName("PayerName").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PayerName")[0])){ 
		 nodeList = document.GetElementsByTagName("PayerName");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.PayerName =  new PersonNameType(xmlString);

}
	}
		 if(document.GetElementsByTagName("PayerCountry").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PayerCountry")[0])){ 
		 this.PayerCountry = (CountryCodeType)EnumUtils.getValue(document.GetElementsByTagName("PayerCountry")[0].InnerText,typeof(CountryCodeType));

}
	}
		 if(document.GetElementsByTagName("PayerBusiness").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PayerBusiness")[0])){ 
		 this.PayerBusiness =(string)document.GetElementsByTagName("PayerBusiness")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Address").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Address")[0])){ 
		 nodeList = document.GetElementsByTagName("Address");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.Address =  new AddressType(xmlString);

}
	}
		 if(document.GetElementsByTagName("ContactPhone").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ContactPhone")[0])){ 
		 this.ContactPhone =(string)document.GetElementsByTagName("ContactPhone")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("TaxIdDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TaxIdDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("TaxIdDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.TaxIdDetails =  new TaxIdDetailsType(xmlString);

}
	}
		 if(document.GetElementsByTagName("EnhancedPayerInfo").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("EnhancedPayerInfo")[0])){ 
		 nodeList = document.GetElementsByTagName("EnhancedPayerInfo");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.EnhancedPayerInfo =  new EnhancedPayerInfoType(xmlString);

}
	}
	}
	}


	public enum PaymentActionCodeType {
[Description("None")]NONE,
[Description("Authorization")]AUTHORIZATION,
[Description("Sale")]SALE,
[Description("Order")]ORDER,
	}
	public enum PaymentCodeType {
[Description("none")]NONE,
[Description("echeck")]ECHECK,
[Description("instant")]INSTANT,
	}
	/**
	 * PaymentDetailsItemType 
	 * Information about a Payment Item.
	 */
	public partial class PaymentDetailsItemType {

		/**
		 * Item name. 
		 * Optional
		 * Character length and limitations: 127 single-byte characters
		 */
		private string NameField;
		public string Name {
			get {
				return this.NameField;
			}
			set {
				this.NameField = value;
			}
		}

		/**
		 * Item number. 
		 * Optional
		 * Character length and limitations: 127 single-byte characters
		 */
		private string NumberField;
		public string Number {
			get {
				return this.NumberField;
			}
			set {
				this.NumberField = value;
			}
		}

		/**
		 * Item quantity. 
		 * Optional
		 * Character length and limitations: Any positive integer		 */
		private int? QuantityField;
		public int? Quantity {
			get {
				return this.QuantityField;
			}
			set {
				this.QuantityField = value;
			}
		}

		/**
		 * Item sales tax. 
		 * Optional
		 * Character length and limitations: any valid currency amount; currency code is set the same as for OrderTotal.
		 */
		private BasicAmountType TaxField;
		public BasicAmountType Tax {
			get {
				return this.TaxField;
			}
			set {
				this.TaxField = value;
			}
		}

		/**
		 * Cost of item 
You must set the currencyID attribute to one of the three-character currency codes for any of the supported PayPal currencies. 
		 * Optional
		 * Limitations: Must not exceed $10,000 USD in any currency. No currency symbol. Decimal separator must be a period (.), and the thousands separator must be a comma (,).
		 */
		private BasicAmountType AmountField;
		public BasicAmountType Amount {
			get {
				return this.AmountField;
			}
			set {
				this.AmountField = value;
			}
		}

		/**
		 * Ebay specific details.
		 * Optional
		 */
		private EbayItemPaymentDetailsItemType EbayItemPaymentDetailsItemField;
		public EbayItemPaymentDetailsItemType EbayItemPaymentDetailsItem {
			get {
				return this.EbayItemPaymentDetailsItemField;
			}
			set {
				this.EbayItemPaymentDetailsItemField = value;
			}
		}

		/**
		 * Promotional financing code for item. Part of the Merchant Services Promotion Financing feature.
		 */
		private string PromoCodeField;
		public string PromoCode {
			get {
				return this.PromoCodeField;
			}
			set {
				this.PromoCodeField = value;
			}
		}

		/**
		 */
		private ProductCategoryType? ProductCategoryField;
		public ProductCategoryType? ProductCategory {
			get {
				return this.ProductCategoryField;
			}
			set {
				this.ProductCategoryField = value;
			}
		}

		/**
		 * Item description. 
		 * Optional
		 * Character length and limitations: 127 single-byte characters
		 */
		private string DescriptionField;
		public string Description {
			get {
				return this.DescriptionField;
			}
			set {
				this.DescriptionField = value;
			}
		}

		/**
		 * Information about the Item weight.
		 */
		private MeasureType ItemWeightField;
		public MeasureType ItemWeight {
			get {
				return this.ItemWeightField;
			}
			set {
				this.ItemWeightField = value;
			}
		}

		/**
		 * Information about the Item length.
		 */
		private MeasureType ItemLengthField;
		public MeasureType ItemLength {
			get {
				return this.ItemLengthField;
			}
			set {
				this.ItemLengthField = value;
			}
		}

		/**
		 * Information about the Item width.
		 */
		private MeasureType ItemWidthField;
		public MeasureType ItemWidth {
			get {
				return this.ItemWidthField;
			}
			set {
				this.ItemWidthField = value;
			}
		}

		/**
		 * Information about the Item height.
		 */
		private MeasureType ItemHeightField;
		public MeasureType ItemHeight {
			get {
				return this.ItemHeightField;
			}
			set {
				this.ItemHeightField = value;
			}
		}

		/**
		 * URL for the item.
		 * Optional
		 * Character length and limitations: no limit.
		 */
		private string ItemURLField;
		public string ItemURL {
			get {
				return this.ItemURLField;
			}
			set {
				this.ItemURLField = value;
			}
		}

		/**
		 * Enhanced data for each item in the cart.
		 * Optional
		 */
		private EnhancedItemDataType EnhancedItemDataField;
		public EnhancedItemDataType EnhancedItemData {
			get {
				return this.EnhancedItemDataField;
			}
			set {
				this.EnhancedItemDataField = value;
			}
		}

		/**
		 * Item category - physical or digital. 
		 * Optional
		 */
		private ItemCategoryType? ItemCategoryField;
		public ItemCategoryType? ItemCategory {
			get {
				return this.ItemCategoryField;
			}
			set {
				this.ItemCategoryField = value;
			}
		}

		public PaymentDetailsItemType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( Name != null ) {
			sb.Append("<ebl:Name>").Append(Name);
			sb.Append("</ebl:Name>");
		}
		if( Number != null ) {
			sb.Append("<ebl:Number>").Append(Number);
			sb.Append("</ebl:Number>");
		}
		if( Quantity != null ) {
			sb.Append("<ebl:Quantity>").Append(Quantity);
			sb.Append("</ebl:Quantity>");
		}
		if( Tax != null ) {
			sb.Append("<ebl:Tax ");
			sb.Append(Tax.toXMLString());
			sb.Append("</ebl:Tax>");
		}
		if( Amount != null ) {
			sb.Append("<ebl:Amount ");
			sb.Append(Amount.toXMLString());
			sb.Append("</ebl:Amount>");
		}
		if( EbayItemPaymentDetailsItem != null ) {
			sb.Append("<ebl:EbayItemPaymentDetailsItem>");
			sb.Append(EbayItemPaymentDetailsItem.toXMLString());
			sb.Append("</ebl:EbayItemPaymentDetailsItem>");
		}
		if( PromoCode != null ) {
			sb.Append("<ebl:PromoCode>").Append(PromoCode);
			sb.Append("</ebl:PromoCode>");
		}
		if( ProductCategory != null ) {
			sb.Append("<ebl:ProductCategory>").Append(EnumUtils.getDescription(ProductCategory));
			sb.Append("</ebl:ProductCategory>");
		}
		if( Description != null ) {
			sb.Append("<ebl:Description>").Append(Description);
			sb.Append("</ebl:Description>");
		}
		if( ItemWeight != null ) {
			sb.Append("<ebl:ItemWeight ");
			sb.Append(ItemWeight.toXMLString());
			sb.Append("</ebl:ItemWeight>");
		}
		if( ItemLength != null ) {
			sb.Append("<ebl:ItemLength ");
			sb.Append(ItemLength.toXMLString());
			sb.Append("</ebl:ItemLength>");
		}
		if( ItemWidth != null ) {
			sb.Append("<ebl:ItemWidth ");
			sb.Append(ItemWidth.toXMLString());
			sb.Append("</ebl:ItemWidth>");
		}
		if( ItemHeight != null ) {
			sb.Append("<ebl:ItemHeight ");
			sb.Append(ItemHeight.toXMLString());
			sb.Append("</ebl:ItemHeight>");
		}
		if( ItemURL != null ) {
			sb.Append("<ebl:ItemURL>").Append(ItemURL);
			sb.Append("</ebl:ItemURL>");
		}
		if( EnhancedItemData != null ) {
			sb.Append("<ebl:EnhancedItemData>");
			sb.Append(EnhancedItemData.toXMLString());
			sb.Append("</ebl:EnhancedItemData>");
		}
		if( ItemCategory != null ) {
			sb.Append("<ebl:ItemCategory>").Append(EnumUtils.getDescription(ItemCategory));
			sb.Append("</ebl:ItemCategory>");
		}
		return sb.ToString();
	}

	 public PaymentDetailsItemType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Name").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Name")[0])){ 
		 this.Name =(string)document.GetElementsByTagName("Name")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Number").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Number")[0])){ 
		 this.Number =(string)document.GetElementsByTagName("Number")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Quantity").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Quantity")[0])){ 
		 this.Quantity =System.Convert.ToInt32(document.GetElementsByTagName("Quantity")[0].InnerText);

}
	}
		 if(document.GetElementsByTagName("Tax").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Tax")[0])){ 
		 nodeList = document.GetElementsByTagName("Tax");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.Tax =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("Amount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Amount")[0])){ 
		 nodeList = document.GetElementsByTagName("Amount");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.Amount =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("EbayItemPaymentDetailsItem").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("EbayItemPaymentDetailsItem")[0])){ 
		 nodeList = document.GetElementsByTagName("EbayItemPaymentDetailsItem");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.EbayItemPaymentDetailsItem =  new EbayItemPaymentDetailsItemType(xmlString);

}
	}
		 if(document.GetElementsByTagName("PromoCode").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PromoCode")[0])){ 
		 this.PromoCode =(string)document.GetElementsByTagName("PromoCode")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ProductCategory").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ProductCategory")[0])){ 
		 this.ProductCategory = (ProductCategoryType)EnumUtils.getValue(document.GetElementsByTagName("ProductCategory")[0].InnerText,typeof(ProductCategoryType));

}
	}
		 if(document.GetElementsByTagName("Description").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Description")[0])){ 
		 this.Description =(string)document.GetElementsByTagName("Description")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ItemWeight").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ItemWeight")[0])){ 
		 nodeList = document.GetElementsByTagName("ItemWeight");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.ItemWeight =  new MeasureType(xmlString);

}
	}
		 if(document.GetElementsByTagName("ItemLength").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ItemLength")[0])){ 
		 nodeList = document.GetElementsByTagName("ItemLength");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.ItemLength =  new MeasureType(xmlString);

}
	}
		 if(document.GetElementsByTagName("ItemWidth").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ItemWidth")[0])){ 
		 nodeList = document.GetElementsByTagName("ItemWidth");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.ItemWidth =  new MeasureType(xmlString);

}
	}
		 if(document.GetElementsByTagName("ItemHeight").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ItemHeight")[0])){ 
		 nodeList = document.GetElementsByTagName("ItemHeight");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.ItemHeight =  new MeasureType(xmlString);

}
	}
		 if(document.GetElementsByTagName("ItemURL").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ItemURL")[0])){ 
		 this.ItemURL =(string)document.GetElementsByTagName("ItemURL")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("EnhancedItemData").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("EnhancedItemData")[0])){ 
		 nodeList = document.GetElementsByTagName("EnhancedItemData");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.EnhancedItemData =  new EnhancedItemDataType(xmlString);

}
	}
		 if(document.GetElementsByTagName("ItemCategory").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ItemCategory")[0])){ 
		 this.ItemCategory = (ItemCategoryType)EnumUtils.getValue(document.GetElementsByTagName("ItemCategory")[0].InnerText,typeof(ItemCategoryType));

}
	}
	}
	}


	/**
	 * PaymentDetailsType 
	 * Information about a payment.  Used by DCC and Express Checkout.
	 */
	public partial class PaymentDetailsType {

		/**
		 * Total of order, including shipping, handling, and tax. 
You must set the currencyID attribute to one of the three-character currency codes for any of the supported PayPal currencies.
		 * Limitations: Must not exceed $10,000 USD in any currency. No currency symbol. Decimal separator must be a period (.), and the thousands separator must be a comma (,). 		 */
		private BasicAmountType OrderTotalField;
		public BasicAmountType OrderTotal {
			get {
				return this.OrderTotalField;
			}
			set {
				this.OrderTotalField = value;
			}
		}

		/**
		 * Sum of cost of all items in this order. 
You must set the currencyID attribute to one of the three-character currency codes for any of the supported PayPal currencies.
		 * Optional
		 * separator must be a comma (,).
		 */
		private BasicAmountType ItemTotalField;
		public BasicAmountType ItemTotal {
			get {
				return this.ItemTotalField;
			}
			set {
				this.ItemTotalField = value;
			}
		}

		/**
		 * Total shipping costs for this order. 
You must set the currencyID attribute to one of the three-character currency codes for any of the supported PayPal currencies.
		 * Optional
		 * Limitations: Must not exceed $10,000 USD in any currency. No currency symbol. Decimal separator must be a period (.), and the thousands separator must be a comma (,).
		 */
		private BasicAmountType ShippingTotalField;
		public BasicAmountType ShippingTotal {
			get {
				return this.ShippingTotalField;
			}
			set {
				this.ShippingTotalField = value;
			}
		}

		/**
		 * Total handling costs for this order. 
You must set the currencyID attribute to one of the three-character currency codes for any of the supported PayPal currencies.
		 * Optional
		 * Limitations: Must not exceed $10,000 USD in any currency. No currency symbol. Decimal separator must be a period (.), and the thousands separator must be a comma (,).
		 */
		private BasicAmountType HandlingTotalField;
		public BasicAmountType HandlingTotal {
			get {
				return this.HandlingTotalField;
			}
			set {
				this.HandlingTotalField = value;
			}
		}

		/**
		 * Sum of tax for all items in this order. 
You must set the currencyID attribute to one of the three-character currency codes for any of the supported PayPal currencies.
		 * Optional
		 * Limitations: Must not exceed $10,000 USD in any currency. No currency symbol. Decimal separator must be a period (.), and the thousands separator must be a comma (,).
		 */
		private BasicAmountType TaxTotalField;
		public BasicAmountType TaxTotal {
			get {
				return this.TaxTotalField;
			}
			set {
				this.TaxTotalField = value;
			}
		}

		/**
		 * Description of items the customer is purchasing. 
		 * Optional
		 * Character length and limitations: 127 single-byte alphanumeric characters
		 */
		private string OrderDescriptionField;
		public string OrderDescription {
			get {
				return this.OrderDescriptionField;
			}
			set {
				this.OrderDescriptionField = value;
			}
		}

		/**
		 * A free-form field for your own use. 
		 * Optional
		 * Character length and limitations: 256 single-byte alphanumeric characters
		 */
		private string CustomField;
		public string Custom {
			get {
				return this.CustomField;
			}
			set {
				this.CustomField = value;
			}
		}

		/**
		 * Your own invoice or tracking number. 
		 * Optional
		 * Character length and limitations: 127 single-byte alphanumeric characters
		 */
		private string InvoiceIDField;
		public string InvoiceID {
			get {
				return this.InvoiceIDField;
			}
			set {
				this.InvoiceIDField = value;
			}
		}

		/**
		 * An identification code for use by third-party applications to identify transactions. 
		 * Optional
		 * Character length and limitations: 32 single-byte alphanumeric characters
		 */
		private string ButtonSourceField;
		public string ButtonSource {
			get {
				return this.ButtonSourceField;
			}
			set {
				this.ButtonSourceField = value;
			}
		}

		/**
		 * Your URL for receiving Instant Payment Notification (IPN) about this transaction. 
		 * Optional
		 * If you do not specify NotifyURL in the request, the notification URL from your Merchant Profile is used, if one exists. 
		 * Character length and limitations: 2,048 single-byte alphanumeric characters
		 */
		private string NotifyURLField;
		public string NotifyURL {
			get {
				return this.NotifyURLField;
			}
			set {
				this.NotifyURLField = value;
			}
		}

		/**
		 * Address the order will be shipped to. 
		 * Optional
		 * If you include the ShipToAddress element, the AddressType elements are required: 
		 * Name
		 * Street1
		 * CityName
		 * CountryCode
		 * Do not set set the CountryName element.
		 */
		private AddressType ShipToAddressField;
		public AddressType ShipToAddress {
			get {
				return this.ShipToAddressField;
			}
			set {
				this.ShipToAddressField = value;
			}
		}

		/**
		 */
		private ShippingServiceCodeType? ShippingMethodField;
		public ShippingServiceCodeType? ShippingMethod {
			get {
				return this.ShippingMethodField;
			}
			set {
				this.ShippingMethodField = value;
			}
		}

		/**
		 * Date and time (in GMT in the format yyyy-MM-ddTHH:mm:ssZ) at which address was changed by the user. 
		 */
		private string ProfileAddressChangeDateField;
		public string ProfileAddressChangeDate {
			get {
				return this.ProfileAddressChangeDateField;
			}
			set {
				this.ProfileAddressChangeDateField = value;
			}
		}

		/**
		 * Information about the individual purchased items		 */
		private List<PaymentDetailsItemType> PaymentDetailsItemField = new List<PaymentDetailsItemType>();
		public List<PaymentDetailsItemType> PaymentDetailsItem {
			get {
				return this.PaymentDetailsItemField;
			}
			set {
				this.PaymentDetailsItemField = value;
			}
		}

		/**
		 * Total shipping insurance costs for this order.
		 * Optional
		 */
		private BasicAmountType InsuranceTotalField;
		public BasicAmountType InsuranceTotal {
			get {
				return this.InsuranceTotalField;
			}
			set {
				this.InsuranceTotalField = value;
			}
		}

		/**
		 * Shipping discount for this order, specified as a negative number.
		 * Optional
		 */
		private BasicAmountType ShippingDiscountField;
		public BasicAmountType ShippingDiscount {
			get {
				return this.ShippingDiscountField;
			}
			set {
				this.ShippingDiscountField = value;
			}
		}

		/**
		 * Information about the Insurance options.
		 */
		private string InsuranceOptionOfferedField;
		public string InsuranceOptionOffered {
			get {
				return this.InsuranceOptionOfferedField;
			}
			set {
				this.InsuranceOptionOfferedField = value;
			}
		}

		/**
		 * Allowed payment methods for this transaction.
		 */
		private AllowedPaymentMethodType? AllowedPaymentMethodField;
		public AllowedPaymentMethodType? AllowedPaymentMethod {
			get {
				return this.AllowedPaymentMethodField;
			}
			set {
				this.AllowedPaymentMethodField = value;
			}
		}

		/**
		 * Enhanced Data section to accept channel specific data.
		 * Optional
		 * Refer to EnhancedPaymentDataType for details.
		 */
		private EnhancedPaymentDataType EnhancedPaymentDataField;
		public EnhancedPaymentDataType EnhancedPaymentData {
			get {
				return this.EnhancedPaymentDataField;
			}
			set {
				this.EnhancedPaymentDataField = value;
			}
		}

		/**
		 * Details about the seller.
		 * Optional 
		 */
		private SellerDetailsType SellerDetailsField;
		public SellerDetailsType SellerDetails {
			get {
				return this.SellerDetailsField;
			}
			set {
				this.SellerDetailsField = value;
			}
		}

		/**
		 * Note to recipient/seller. 
		 * Optional 
		 * Character length and limitations: 127 single-byte alphanumeric characters.
		 */
		private string NoteTextField;
		public string NoteText {
			get {
				return this.NoteTextField;
			}
			set {
				this.NoteTextField = value;
			}
		}

		/**
		 * PayPal Transaction Id, returned once DoExpressCheckout is completed. 
		 */
		private string TransactionIdField;
		public string TransactionId {
			get {
				return this.TransactionIdField;
			}
			set {
				this.TransactionIdField = value;
			}
		}

		/**
		 * How you want to obtain payment.
		 * This payment action input will be used for split payments
		 * Authorization indicates that this payment is a basic authorization subject to settlement with PayPal Authorization and Capture.
		 * Order indicates that this payment is is an order authorization subject to settlement with PayPal Authorization and Capture.
		 * Sale indicates that this is a final sale for which you are requesting payment.
		 * IMPORTANT: You cannot set PaymentAction to Sale on SetExpressCheckoutRequest and then change PaymentAction to Authorization on the final Express Checkout API, DoExpressCheckoutPaymentRequest.
		 * Character length and limit: Up to 13 single-byte alphabetic characters
		 */
		private PaymentActionCodeType? PaymentActionField;
		public PaymentActionCodeType? PaymentAction {
			get {
				return this.PaymentActionField;
			}
			set {
				this.PaymentActionField = value;
			}
		}

		/**
		 * Unique identifier and mandatory for the particular payment request in case of multiple payment
		 */
		private string PaymentRequestIDField;
		public string PaymentRequestID {
			get {
				return this.PaymentRequestIDField;
			}
			set {
				this.PaymentRequestIDField = value;
			}
		}

		/**
		 * URL on Merchant site pertaining to this invoice. 
		 * Optional
		 */
		private string OrderURLField;
		public string OrderURL {
			get {
				return this.OrderURLField;
			}
			set {
				this.OrderURLField = value;
			}
		}

		/**
		 * Soft Descriptor supported for Sale and Auth in DEC only. For Order this will be ignored.
		 */
		private string SoftDescriptorField;
		public string SoftDescriptor {
			get {
				return this.SoftDescriptorField;
			}
			set {
				this.SoftDescriptorField = value;
			}
		}

		/**
		 * BranchLevel is used to identify chain payment.
		 * If BranchLevel is 0 or 1, this payment is where money moves to.
		 * If BranchLevel greater than 1, this payment contains the actual seller info.	
		 * Optional
		 */
		private int? BranchLevelField;
		public int? BranchLevel {
			get {
				return this.BranchLevelField;
			}
			set {
				this.BranchLevelField = value;
			}
		}

		/**
		 * Soft Descriptor supported for Sale and Auth in DEC only. For Order this will be ignored.
		 */
		private OfferDetailsType OfferDetailsField;
		public OfferDetailsType OfferDetails {
			get {
				return this.OfferDetailsField;
			}
			set {
				this.OfferDetailsField = value;
			}
		}

		/**
		 * Flag to indicate the recurring transaction
		 */
		private RecurringFlagType? RecurringField;
		public RecurringFlagType? Recurring {
			get {
				return this.RecurringField;
			}
			set {
				this.RecurringField = value;
			}
		}

		public PaymentDetailsType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( OrderTotal != null ) {
			sb.Append("<ebl:OrderTotal ");
			sb.Append(OrderTotal.toXMLString());
			sb.Append("</ebl:OrderTotal>");
		}
		if( ItemTotal != null ) {
			sb.Append("<ebl:ItemTotal ");
			sb.Append(ItemTotal.toXMLString());
			sb.Append("</ebl:ItemTotal>");
		}
		if( ShippingTotal != null ) {
			sb.Append("<ebl:ShippingTotal ");
			sb.Append(ShippingTotal.toXMLString());
			sb.Append("</ebl:ShippingTotal>");
		}
		if( HandlingTotal != null ) {
			sb.Append("<ebl:HandlingTotal ");
			sb.Append(HandlingTotal.toXMLString());
			sb.Append("</ebl:HandlingTotal>");
		}
		if( TaxTotal != null ) {
			sb.Append("<ebl:TaxTotal ");
			sb.Append(TaxTotal.toXMLString());
			sb.Append("</ebl:TaxTotal>");
		}
		if( OrderDescription != null ) {
			sb.Append("<ebl:OrderDescription>").Append(OrderDescription);
			sb.Append("</ebl:OrderDescription>");
		}
		if( Custom != null ) {
			sb.Append("<ebl:Custom>").Append(Custom);
			sb.Append("</ebl:Custom>");
		}
		if( InvoiceID != null ) {
			sb.Append("<ebl:InvoiceID>").Append(InvoiceID);
			sb.Append("</ebl:InvoiceID>");
		}
		if( ButtonSource != null ) {
			sb.Append("<ebl:ButtonSource>").Append(ButtonSource);
			sb.Append("</ebl:ButtonSource>");
		}
		if( NotifyURL != null ) {
			sb.Append("<ebl:NotifyURL>").Append(NotifyURL);
			sb.Append("</ebl:NotifyURL>");
		}
		if( ShipToAddress != null ) {
			sb.Append("<ebl:ShipToAddress>");
			sb.Append(ShipToAddress.toXMLString());
			sb.Append("</ebl:ShipToAddress>");
		}
		if( ShippingMethod != null ) {
			sb.Append("<ebl:ShippingMethod>").Append(EnumUtils.getDescription(ShippingMethod));
			sb.Append("</ebl:ShippingMethod>");
		}
		if( ProfileAddressChangeDate != null ) {
			sb.Append("<ebl:ProfileAddressChangeDate>").Append(ProfileAddressChangeDate);
			sb.Append("</ebl:ProfileAddressChangeDate>");
		}
		if( PaymentDetailsItem != null ) {
			for(int i=0; i<PaymentDetailsItem.Count; i++) {
				sb.Append("<ebl:PaymentDetailsItem>");
				sb.Append(PaymentDetailsItem[i].toXMLString());
				sb.Append("</ebl:PaymentDetailsItem>");
			}
		}
		if( InsuranceTotal != null ) {
			sb.Append("<ebl:InsuranceTotal ");
			sb.Append(InsuranceTotal.toXMLString());
			sb.Append("</ebl:InsuranceTotal>");
		}
		if( ShippingDiscount != null ) {
			sb.Append("<ebl:ShippingDiscount ");
			sb.Append(ShippingDiscount.toXMLString());
			sb.Append("</ebl:ShippingDiscount>");
		}
		if( InsuranceOptionOffered != null ) {
			sb.Append("<ebl:InsuranceOptionOffered>").Append(InsuranceOptionOffered);
			sb.Append("</ebl:InsuranceOptionOffered>");
		}
		if( AllowedPaymentMethod != null ) {
			sb.Append("<ebl:AllowedPaymentMethod>").Append(EnumUtils.getDescription(AllowedPaymentMethod));
			sb.Append("</ebl:AllowedPaymentMethod>");
		}
		if( EnhancedPaymentData != null ) {
			sb.Append("<ebl:EnhancedPaymentData>");
			sb.Append(EnhancedPaymentData.toXMLString());
			sb.Append("</ebl:EnhancedPaymentData>");
		}
		if( SellerDetails != null ) {
			sb.Append("<ebl:SellerDetails>");
			sb.Append(SellerDetails.toXMLString());
			sb.Append("</ebl:SellerDetails>");
		}
		if( NoteText != null ) {
			sb.Append("<ebl:NoteText>").Append(NoteText);
			sb.Append("</ebl:NoteText>");
		}
		if( TransactionId != null ) {
			sb.Append("<ebl:TransactionId>").Append(TransactionId);
			sb.Append("</ebl:TransactionId>");
		}
		if( PaymentAction != null ) {
			sb.Append("<ebl:PaymentAction>").Append(EnumUtils.getDescription(PaymentAction));
			sb.Append("</ebl:PaymentAction>");
		}
		if( PaymentRequestID != null ) {
			sb.Append("<ebl:PaymentRequestID>").Append(PaymentRequestID);
			sb.Append("</ebl:PaymentRequestID>");
		}
		if( OrderURL != null ) {
			sb.Append("<ebl:OrderURL>").Append(OrderURL);
			sb.Append("</ebl:OrderURL>");
		}
		if( SoftDescriptor != null ) {
			sb.Append("<ebl:SoftDescriptor>").Append(SoftDescriptor);
			sb.Append("</ebl:SoftDescriptor>");
		}
		if( BranchLevel != null ) {
			sb.Append("<ebl:BranchLevel>").Append(BranchLevel);
			sb.Append("</ebl:BranchLevel>");
		}
		if( OfferDetails != null ) {
			sb.Append("<ebl:OfferDetails>");
			sb.Append(OfferDetails.toXMLString());
			sb.Append("</ebl:OfferDetails>");
		}
		if( Recurring != null ) {
			sb.Append("<ebl:Recurring>").Append(EnumUtils.getDescription(Recurring));
			sb.Append("</ebl:Recurring>");
		}
		return sb.ToString();
	}

	 public PaymentDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("OrderTotal").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OrderTotal")[0])){ 
		 nodeList = document.GetElementsByTagName("OrderTotal");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.OrderTotal =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("ItemTotal").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ItemTotal")[0])){ 
		 nodeList = document.GetElementsByTagName("ItemTotal");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.ItemTotal =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("ShippingTotal").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ShippingTotal")[0])){ 
		 nodeList = document.GetElementsByTagName("ShippingTotal");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.ShippingTotal =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("HandlingTotal").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("HandlingTotal")[0])){ 
		 nodeList = document.GetElementsByTagName("HandlingTotal");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.HandlingTotal =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("TaxTotal").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TaxTotal")[0])){ 
		 nodeList = document.GetElementsByTagName("TaxTotal");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.TaxTotal =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("OrderDescription").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OrderDescription")[0])){ 
		 this.OrderDescription =(string)document.GetElementsByTagName("OrderDescription")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Custom").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Custom")[0])){ 
		 this.Custom =(string)document.GetElementsByTagName("Custom")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("InvoiceID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("InvoiceID")[0])){ 
		 this.InvoiceID =(string)document.GetElementsByTagName("InvoiceID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ButtonSource").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ButtonSource")[0])){ 
		 this.ButtonSource =(string)document.GetElementsByTagName("ButtonSource")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("NotifyURL").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("NotifyURL")[0])){ 
		 this.NotifyURL =(string)document.GetElementsByTagName("NotifyURL")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ShipToAddress").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ShipToAddress")[0])){ 
		 nodeList = document.GetElementsByTagName("ShipToAddress");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.ShipToAddress =  new AddressType(xmlString);

}
	}
		 if(document.GetElementsByTagName("ShippingMethod").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ShippingMethod")[0])){ 
		 this.ShippingMethod = (ShippingServiceCodeType)EnumUtils.getValue(document.GetElementsByTagName("ShippingMethod")[0].InnerText,typeof(ShippingServiceCodeType));

}
	}
		 if(document.GetElementsByTagName("ProfileAddressChangeDate").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ProfileAddressChangeDate")[0])){ 
		 this.ProfileAddressChangeDate =(string)document.GetElementsByTagName("ProfileAddressChangeDate")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("PaymentDetailsItem").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentDetailsItem")[0])){ 
		 nodeList = document.GetElementsByTagName("PaymentDetailsItem");
		 for(int i=0; i<nodeList.Count; i++) {
			 xmlString = DeserializationUtils.convertToXML(nodeList[i]); 
				this.PaymentDetailsItem.Add(new PaymentDetailsItemType(xmlString));
			}

}
	}
		 if(document.GetElementsByTagName("InsuranceTotal").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("InsuranceTotal")[0])){ 
		 nodeList = document.GetElementsByTagName("InsuranceTotal");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.InsuranceTotal =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("ShippingDiscount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ShippingDiscount")[0])){ 
		 nodeList = document.GetElementsByTagName("ShippingDiscount");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.ShippingDiscount =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("InsuranceOptionOffered").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("InsuranceOptionOffered")[0])){ 
		 this.InsuranceOptionOffered =(string)document.GetElementsByTagName("InsuranceOptionOffered")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("AllowedPaymentMethod").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AllowedPaymentMethod")[0])){ 
		 this.AllowedPaymentMethod = (AllowedPaymentMethodType)EnumUtils.getValue(document.GetElementsByTagName("AllowedPaymentMethod")[0].InnerText,typeof(AllowedPaymentMethodType));

}
	}
		 if(document.GetElementsByTagName("EnhancedPaymentData").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("EnhancedPaymentData")[0])){ 
		 nodeList = document.GetElementsByTagName("EnhancedPaymentData");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.EnhancedPaymentData =  new EnhancedPaymentDataType(xmlString);

}
	}
		 if(document.GetElementsByTagName("SellerDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SellerDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("SellerDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.SellerDetails =  new SellerDetailsType(xmlString);

}
	}
		 if(document.GetElementsByTagName("NoteText").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("NoteText")[0])){ 
		 this.NoteText =(string)document.GetElementsByTagName("NoteText")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("TransactionId").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TransactionId")[0])){ 
		 this.TransactionId =(string)document.GetElementsByTagName("TransactionId")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("PaymentAction").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentAction")[0])){ 
		 this.PaymentAction = (PaymentActionCodeType)EnumUtils.getValue(document.GetElementsByTagName("PaymentAction")[0].InnerText,typeof(PaymentActionCodeType));

}
	}
		 if(document.GetElementsByTagName("PaymentRequestID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentRequestID")[0])){ 
		 this.PaymentRequestID =(string)document.GetElementsByTagName("PaymentRequestID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("OrderURL").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OrderURL")[0])){ 
		 this.OrderURL =(string)document.GetElementsByTagName("OrderURL")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("SoftDescriptor").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SoftDescriptor")[0])){ 
		 this.SoftDescriptor =(string)document.GetElementsByTagName("SoftDescriptor")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("BranchLevel").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BranchLevel")[0])){ 
		 this.BranchLevel =System.Convert.ToInt32(document.GetElementsByTagName("BranchLevel")[0].InnerText);

}
	}
		 if(document.GetElementsByTagName("OfferDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OfferDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("OfferDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.OfferDetails =  new OfferDetailsType(xmlString);

}
	}
		 if(document.GetElementsByTagName("Recurring").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Recurring")[0])){ 
		 this.Recurring = (RecurringFlagType)EnumUtils.getValue(document.GetElementsByTagName("Recurring")[0].InnerText,typeof(RecurringFlagType));

}
	}
	}
	}


	/**
	 * Type of the Payment is it Instant or Echeck or Any.
	 */
	public partial class PaymentDirectivesType {

		/**
Type of the Payment is it Instant or Echeck or Any.		 */
		private MerchantPullPaymentCodeType? PaymentTypeField;
		public MerchantPullPaymentCodeType? PaymentType {
			get {
				return this.PaymentTypeField;
			}
			set {
				this.PaymentTypeField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( PaymentType != null ) {
			sb.Append("<ebl:PaymentType>").Append(EnumUtils.getDescription(PaymentType));
			sb.Append("</ebl:PaymentType>");
		}
		return sb.ToString();
	}

	}


	/**
	 * PaymentInfoType 
	 * Payment information.
	 */
	public partial class PaymentInfoType {

		/**
A transaction identification number. 
Character length and limits: 19 single-byte characters maximum
		 */
		private string TransactionIDField;
		public string TransactionID {
			get {
				return this.TransactionIDField;
			}
			set {
				this.TransactionIDField = value;
			}
		}

		/**
Its Ebay transaction id.
		 * EbayTransactionID will returned for immediate pay item transaction in ECA 
		 */
		private string EbayTransactionIDField;
		public string EbayTransactionID {
			get {
				return this.EbayTransactionIDField;
			}
			set {
				this.EbayTransactionIDField = value;
			}
		}

		/**
		 * Parent or related transaction identification number. This field is populated for the following transaction types: 
		 * Reversal
		 * Capture of an authorized transaction.
		 * Reauthorization of a transaction.
		 * Capture of an order. The value of ParentTransactionID is the original OrderID.
		 * Authorization of an order. The value of ParentTransactionID is the original OrderID.
		 * Capture of an order authorization.
		 * Void of an order. The value of ParentTransactionID is the original OrderID.
		 * Character length and limits: 19 single-byte characters maximum		 */
		private string ParentTransactionIDField;
		public string ParentTransactionID {
			get {
				return this.ParentTransactionIDField;
			}
			set {
				this.ParentTransactionIDField = value;
			}
		}

		/**
		 * Receipt ID 
		 * Character length and limitations: 16 digits in xxxx-xxxx-xxxx-xxxx format		 */
		private string ReceiptIDField;
		public string ReceiptID {
			get {
				return this.ReceiptIDField;
			}
			set {
				this.ReceiptIDField = value;
			}
		}

		/**
		 * The type of transaction 
		 * cart: Transaction created via the PayPal Shopping Cart feature or by Express Checkout with multiple purchased item
		 * express-checkout: Transaction created by Express Checkout with a single purchased items
		 * send-money: Transaction created by customer from the Send Money tab on the PayPal website.
		 * web-accept: Transaction created by customer via Buy Now, Donation, or Auction Smart Logos.
		 * subscr-*: Transaction created by customer via Subscription. eot means "end of subscription term."
		 * merch-pmt: preapproved payment.
		 * mass-pay: Transaction created via MassPay.
		 * virtual-terminal: Transaction created via merchant virtual terminal.
		 * credit: Transaction created via merchant virtual terminal or API to credit a customer.
		 */
		private PaymentTransactionCodeType? TransactionTypeField;
		public PaymentTransactionCodeType? TransactionType {
			get {
				return this.TransactionTypeField;
			}
			set {
				this.TransactionTypeField = value;
			}
		}

		/**
		 * The type of payment		 */
		private PaymentCodeType? PaymentTypeField;
		public PaymentCodeType? PaymentType {
			get {
				return this.PaymentTypeField;
			}
			set {
				this.PaymentTypeField = value;
			}
		}

		/**
		 * The type of funding source		 */
		private RefundSourceCodeType? RefundSourceCodeTypeField;
		public RefundSourceCodeType? RefundSourceCodeType {
			get {
				return this.RefundSourceCodeTypeField;
			}
			set {
				this.RefundSourceCodeTypeField = value;
			}
		}

		/**
		 * eCheck latest expected clear date 		 */
		private string ExpectedeCheckClearDateField;
		public string ExpectedeCheckClearDate {
			get {
				return this.ExpectedeCheckClearDateField;
			}
			set {
				this.ExpectedeCheckClearDateField = value;
			}
		}

		/**
		 * Date and time of payment 		 */
		private string PaymentDateField;
		public string PaymentDate {
			get {
				return this.PaymentDateField;
			}
			set {
				this.PaymentDateField = value;
			}
		}

		/**
		 * Full amount of the customer's payment, before transaction fee is subtracted		 */
		private BasicAmountType GrossAmountField;
		public BasicAmountType GrossAmount {
			get {
				return this.GrossAmountField;
			}
			set {
				this.GrossAmountField = value;
			}
		}

		/**
		 * Transaction fee associated with the payment 		 */
		private BasicAmountType FeeAmountField;
		public BasicAmountType FeeAmount {
			get {
				return this.FeeAmountField;
			}
			set {
				this.FeeAmountField = value;
			}
		}

		/**
Amount deposited into the account's primary balance after a currency conversion from automatic conversion through your Payment Receiving Preferences or manual conversion through manually accepting a payment. This amount is calculated after fees and taxes have been assessed. 		 */
		private BasicAmountType SettleAmountField;
		public BasicAmountType SettleAmount {
			get {
				return this.SettleAmountField;
			}
			set {
				this.SettleAmountField = value;
			}
		}

		/**
		 * Amount of tax for transaction 		 */
		private BasicAmountType TaxAmountField;
		public BasicAmountType TaxAmount {
			get {
				return this.TaxAmountField;
			}
			set {
				this.TaxAmountField = value;
			}
		}

		/**
		 * Exchange rate for transaction 		 */
		private string ExchangeRateField;
		public string ExchangeRate {
			get {
				return this.ExchangeRateField;
			}
			set {
				this.ExchangeRateField = value;
			}
		}

		/**
		 * The status of the payment:
		 * None: No status
		 * Created: A giropay payment has been initiated.
		 * Canceled-Reversal: A reversal has been canceled. For example, you won a dispute with the customer, and the funds for the transaction that was reversed have been returned to you.
		 * Completed: The payment has been completed, and the funds have been added successfully to your account balance.
		 * Denied: You denied the payment. This happens only if the payment was previously pending because of possible reasons described for the PendingReason element.
		 * Expired: This authorization has expired and cannot be captured.
		 * Failed: The payment has failed. This happens only if the payment was made from your customer's bank account.
		 * In-Progress: The transaction is in process of authorization and capture.
		 * Partially-Refunded: The transaction has been partially refunded.
		 * Pending: The payment is pending. See "PendingReason" for more information.
		 * Refunded: You refunded the payment.
		 * Reversed: A payment was reversed due to a chargeback or other type of reversal. The funds have been removed from your account balance and returned to the buyer. The reason for the reversal is specified in the ReasonCode element.
		 * Processed: A payment has been accepted.
		 * Voided: This authorization has been voided.
		 * Completed-Funds-Held: The payment has been completed, and the funds have been added successfully to your pending balance. See the "HoldDecision" field for more information.
		 */
		private PaymentStatusCodeType? PaymentStatusField;
		public PaymentStatusCodeType? PaymentStatus {
			get {
				return this.PaymentStatusField;
			}
			set {
				this.PaymentStatusField = value;
			}
		}

		/**
		 * The reason the payment is pending: 
none: No pending reason
		 * address: The payment is pending because your customer did not include a confirmed shipping address and your Payment Receiving Preferences is set such that you want to manually accept or deny each of these payments. To change your preference, go to the Preferences section of your Profile.
		 * authorization: You set PaymentAction to Authorization on SetExpressCheckoutRequest and have not yet captured funds.
		 * echeck: The payment is pending because it was made by an eCheck that has not yet cleared.
		 * intl: The payment is pending because you hold a non-U.S. account and do not have a withdrawal mechanism. You must manually accept or deny this payment from your Account Overview.
		 * multi-currency: You do not have a balance in the currency sent, and you do not have your Payment Receiving Preferences set to automatically convert and accept this payment. You must manually accept or deny this payment.
		 * unilateral: The payment is pending because it was made to an email address that is not yet registered or confirmed.
		 * upgrade: The payment is pending because it was made via credit card and you must upgrade your account to Business or Premier status in order to receive the funds. upgrade can also mean that you have reached the monthly limit for transactions on your account.
		 * verify: The payment is pending because you are not yet verified. You must verify your account before you can accept this payment.
		 * other: The payment is pending for a reason other than those listed above. For more information, contact PayPal Customer Service.
		 */
		private PendingStatusCodeType? PendingReasonField;
		public PendingStatusCodeType? PendingReason {
			get {
				return this.PendingReasonField;
			}
			set {
				this.PendingReasonField = value;
			}
		}

		/**
		 * The reason for a reversal if TransactionType is reversal: 
none: No reason code
		 * chargeback: A reversal has occurred on this transaction due to a chargeback by your customer.
		 * guarantee: A reversal has occurred on this transaction due to your customer triggering a money-back guarantee.
		 * buyer-complaint: A reversal has occurred on this transaction due to a complaint about the transaction from your customer.
		 * refund: A reversal has occurred on this transaction because you have given the customer a refund.
		 * other: A reversal has occurred on this transaction due to a reason not listed above.
		 */
		private ReversalReasonCodeType? ReasonCodeField;
		public ReversalReasonCodeType? ReasonCode {
			get {
				return this.ReasonCodeField;
			}
			set {
				this.ReasonCodeField = value;
			}
		}

		/**
		 * HoldDecision is returned in the response only if PaymentStatus is Completed-Funds-Held. The reason the funds are kept in pending balance: 
newsellerpaymenthold: The seller is new.
		 * paymenthold: A hold is placed on your transaction due to a reason not listed above.
		 */
		private string HoldDecisionField;
		public string HoldDecision {
			get {
				return this.HoldDecisionField;
			}
			set {
				this.HoldDecisionField = value;
			}
		}

		/**
		 * Shipping method selected by the user during check-out.
		 */
		private string ShippingMethodField;
		public string ShippingMethod {
			get {
				return this.ShippingMethodField;
			}
			set {
				this.ShippingMethodField = value;
			}
		}

		/**
		 * Protection Eligibility for this Transaction - None, SPP or ESPP
		 */
		private string ProtectionEligibilityField;
		public string ProtectionEligibility {
			get {
				return this.ProtectionEligibilityField;
			}
			set {
				this.ProtectionEligibilityField = value;
			}
		}

		/**
		 * Protection Eligibility details  for this Transaction
		 */
		private string ProtectionEligibilityTypeField;
		public string ProtectionEligibilityType {
			get {
				return this.ProtectionEligibilityTypeField;
			}
			set {
				this.ProtectionEligibilityTypeField = value;
			}
		}

		/**
		 * Amount of shipping charged on transaction		 */
		private string ShipAmountField;
		public string ShipAmount {
			get {
				return this.ShipAmountField;
			}
			set {
				this.ShipAmountField = value;
			}
		}

		/**
		 * Amount of ship handling charged on transaction		 */
		private string ShipHandleAmountField;
		public string ShipHandleAmount {
			get {
				return this.ShipHandleAmountField;
			}
			set {
				this.ShipHandleAmountField = value;
			}
		}

		/**
		 * Amount of shipping discount on transaction		 */
		private string ShipDiscountField;
		public string ShipDiscount {
			get {
				return this.ShipDiscountField;
			}
			set {
				this.ShipDiscountField = value;
			}
		}

		/**
		 * Amount of Insurance amount on transaction		 */
		private string InsuranceAmountField;
		public string InsuranceAmount {
			get {
				return this.InsuranceAmountField;
			}
			set {
				this.InsuranceAmountField = value;
			}
		}

		/**
		 * Subject as entered in the transaction		 */
		private string SubjectField;
		public string Subject {
			get {
				return this.SubjectField;
			}
			set {
				this.SubjectField = value;
			}
		}

		/**
		 * StoreID as entered in the transaction		 */
		private string StoreIDField;
		public string StoreID {
			get {
				return this.StoreIDField;
			}
			set {
				this.StoreIDField = value;
			}
		}

		/**
		 * TerminalID as entered in the transaction		 */
		private string TerminalIDField;
		public string TerminalID {
			get {
				return this.TerminalIDField;
			}
			set {
				this.TerminalIDField = value;
			}
		}

		/**
		 * Details about the seller.
		 * Optional 
		 */
		private SellerDetailsType SellerDetailsField;
		public SellerDetailsType SellerDetails {
			get {
				return this.SellerDetailsField;
			}
			set {
				this.SellerDetailsField = value;
			}
		}

		/**
		 * Unique identifier and mandatory for each bucket in case of split payement
		 */
		private string PaymentRequestIDField;
		public string PaymentRequestID {
			get {
				return this.PaymentRequestIDField;
			}
			set {
				this.PaymentRequestIDField = value;
			}
		}

		/**
		 * Thes are filters that could result in accept/deny/pending action.
		 */
		private FMFDetailsType FMFDetailsField;
		public FMFDetailsType FMFDetails {
			get {
				return this.FMFDetailsField;
			}
			set {
				this.FMFDetailsField = value;
			}
		}

		/**
		 * This will be enhanced info for the payment: Example: UATP details
		 */
		private EnhancedPaymentInfoType EnhancedPaymentInfoField;
		public EnhancedPaymentInfoType EnhancedPaymentInfo {
			get {
				return this.EnhancedPaymentInfoField;
			}
			set {
				this.EnhancedPaymentInfoField = value;
			}
		}

		/**
		 * This will indicate the payment status for individual payment request in case of split payment
		 */
		private ErrorType PaymentErrorField;
		public ErrorType PaymentError {
			get {
				return this.PaymentErrorField;
			}
			set {
				this.PaymentErrorField = value;
			}
		}

		/**
		 * Type of the payment instrument.
		 */
		private InstrumentDetailsType InstrumentDetailsField;
		public InstrumentDetailsType InstrumentDetails {
			get {
				return this.InstrumentDetailsField;
			}
			set {
				this.InstrumentDetailsField = value;
			}
		}

		/**
		 * Offer Details.
		 */
		private OfferDetailsType OfferDetailsField;
		public OfferDetailsType OfferDetails {
			get {
				return this.OfferDetailsField;
			}
			set {
				this.OfferDetailsField = value;
			}
		}

	 public PaymentInfoType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("TransactionID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TransactionID")[0])){ 
		 this.TransactionID =(string)document.GetElementsByTagName("TransactionID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("EbayTransactionID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("EbayTransactionID")[0])){ 
		 this.EbayTransactionID =(string)document.GetElementsByTagName("EbayTransactionID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ParentTransactionID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ParentTransactionID")[0])){ 
		 this.ParentTransactionID =(string)document.GetElementsByTagName("ParentTransactionID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ReceiptID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ReceiptID")[0])){ 
		 this.ReceiptID =(string)document.GetElementsByTagName("ReceiptID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("TransactionType").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TransactionType")[0])){ 
		 this.TransactionType = (PaymentTransactionCodeType)EnumUtils.getValue(document.GetElementsByTagName("TransactionType")[0].InnerText,typeof(PaymentTransactionCodeType));

}
	}
		 if(document.GetElementsByTagName("PaymentType").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentType")[0])){ 
		 this.PaymentType = (PaymentCodeType)EnumUtils.getValue(document.GetElementsByTagName("PaymentType")[0].InnerText,typeof(PaymentCodeType));

}
	}
		 if(document.GetElementsByTagName("RefundSourceCodeType").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("RefundSourceCodeType")[0])){ 
		 this.RefundSourceCodeType = (RefundSourceCodeType)EnumUtils.getValue(document.GetElementsByTagName("RefundSourceCodeType")[0].InnerText,typeof(RefundSourceCodeType));

}
	}
		 if(document.GetElementsByTagName("ExpectedeCheckClearDate").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ExpectedeCheckClearDate")[0])){ 
		 this.ExpectedeCheckClearDate =(string)document.GetElementsByTagName("ExpectedeCheckClearDate")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("PaymentDate").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentDate")[0])){ 
		 this.PaymentDate =(string)document.GetElementsByTagName("PaymentDate")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("GrossAmount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GrossAmount")[0])){ 
		 nodeList = document.GetElementsByTagName("GrossAmount");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.GrossAmount =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("FeeAmount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("FeeAmount")[0])){ 
		 nodeList = document.GetElementsByTagName("FeeAmount");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.FeeAmount =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("SettleAmount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SettleAmount")[0])){ 
		 nodeList = document.GetElementsByTagName("SettleAmount");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.SettleAmount =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("TaxAmount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TaxAmount")[0])){ 
		 nodeList = document.GetElementsByTagName("TaxAmount");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.TaxAmount =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("ExchangeRate").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ExchangeRate")[0])){ 
		 this.ExchangeRate =(string)document.GetElementsByTagName("ExchangeRate")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("PaymentStatus").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentStatus")[0])){ 
		 this.PaymentStatus = (PaymentStatusCodeType)EnumUtils.getValue(document.GetElementsByTagName("PaymentStatus")[0].InnerText,typeof(PaymentStatusCodeType));

}
	}
		 if(document.GetElementsByTagName("PendingReason").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PendingReason")[0])){ 
		 this.PendingReason = (PendingStatusCodeType)EnumUtils.getValue(document.GetElementsByTagName("PendingReason")[0].InnerText,typeof(PendingStatusCodeType));

}
	}
		 if(document.GetElementsByTagName("ReasonCode").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ReasonCode")[0])){ 
		 this.ReasonCode = (ReversalReasonCodeType)EnumUtils.getValue(document.GetElementsByTagName("ReasonCode")[0].InnerText,typeof(ReversalReasonCodeType));

}
	}
		 if(document.GetElementsByTagName("HoldDecision").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("HoldDecision")[0])){ 
		 this.HoldDecision =(string)document.GetElementsByTagName("HoldDecision")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ShippingMethod").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ShippingMethod")[0])){ 
		 this.ShippingMethod =(string)document.GetElementsByTagName("ShippingMethod")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ProtectionEligibility").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ProtectionEligibility")[0])){ 
		 this.ProtectionEligibility =(string)document.GetElementsByTagName("ProtectionEligibility")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ProtectionEligibilityType").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ProtectionEligibilityType")[0])){ 
		 this.ProtectionEligibilityType =(string)document.GetElementsByTagName("ProtectionEligibilityType")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ShipAmount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ShipAmount")[0])){ 
		 this.ShipAmount =(string)document.GetElementsByTagName("ShipAmount")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ShipHandleAmount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ShipHandleAmount")[0])){ 
		 this.ShipHandleAmount =(string)document.GetElementsByTagName("ShipHandleAmount")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ShipDiscount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ShipDiscount")[0])){ 
		 this.ShipDiscount =(string)document.GetElementsByTagName("ShipDiscount")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("InsuranceAmount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("InsuranceAmount")[0])){ 
		 this.InsuranceAmount =(string)document.GetElementsByTagName("InsuranceAmount")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Subject").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Subject")[0])){ 
		 this.Subject =(string)document.GetElementsByTagName("Subject")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("StoreID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("StoreID")[0])){ 
		 this.StoreID =(string)document.GetElementsByTagName("StoreID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("TerminalID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TerminalID")[0])){ 
		 this.TerminalID =(string)document.GetElementsByTagName("TerminalID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("SellerDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SellerDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("SellerDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.SellerDetails =  new SellerDetailsType(xmlString);

}
	}
		 if(document.GetElementsByTagName("PaymentRequestID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentRequestID")[0])){ 
		 this.PaymentRequestID =(string)document.GetElementsByTagName("PaymentRequestID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("FMFDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("FMFDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("FMFDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.FMFDetails =  new FMFDetailsType(xmlString);

}
	}
		 if(document.GetElementsByTagName("EnhancedPaymentInfo").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("EnhancedPaymentInfo")[0])){ 
		 nodeList = document.GetElementsByTagName("EnhancedPaymentInfo");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.EnhancedPaymentInfo =  new EnhancedPaymentInfoType(xmlString);

}
	}
		 if(document.GetElementsByTagName("PaymentError").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentError")[0])){ 
		 nodeList = document.GetElementsByTagName("PaymentError");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.PaymentError =  new ErrorType(xmlString);

}
	}
		 if(document.GetElementsByTagName("InstrumentDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("InstrumentDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("InstrumentDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.InstrumentDetails =  new InstrumentDetailsType(xmlString);

}
	}
		 if(document.GetElementsByTagName("OfferDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OfferDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("OfferDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.OfferDetails =  new OfferDetailsType(xmlString);

}
	}
	}
	}


	/**
	 * PaymentItemInfoType 
	 * Information about a PayPal item.
	 */
	public partial class PaymentItemInfoType {

		/**
		 * Invoice number you set in the original transaction.
		 * Character length and limitations: 127 single-byte alphanumeric characters 		 */
		private string InvoiceIDField;
		public string InvoiceID {
			get {
				return this.InvoiceIDField;
			}
			set {
				this.InvoiceIDField = value;
			}
		}

		/**
		 * Custom field you set in the original transaction. 
		 * Character length and limitations: 127 single-byte alphanumeric characters		 */
		private string CustomField;
		public string Custom {
			get {
				return this.CustomField;
			}
			set {
				this.CustomField = value;
			}
		}

		/**
		 * Memo entered by your customer in PayPal Website Payments note field. 
		 * Character length and limitations: 255 single-byte alphanumeric characters		 */
		private string MemoField;
		public string Memo {
			get {
				return this.MemoField;
			}
			set {
				this.MemoField = value;
			}
		}

		/**
		 * Amount of tax charged on transaction		 */
		private string SalesTaxField;
		public string SalesTax {
			get {
				return this.SalesTaxField;
			}
			set {
				this.SalesTaxField = value;
			}
		}

		/**
		 * Details about the indivudal purchased item		 */
		private List<PaymentItemType> PaymentItemField = new List<PaymentItemType>();
		public List<PaymentItemType> PaymentItem {
			get {
				return this.PaymentItemField;
			}
			set {
				this.PaymentItemField = value;
			}
		}

		/**
		 * Information about the transaction if it was created via PayPal Subcriptions		 */
		private SubscriptionInfoType SubscriptionField;
		public SubscriptionInfoType Subscription {
			get {
				return this.SubscriptionField;
			}
			set {
				this.SubscriptionField = value;
			}
		}

		/**
		 * Information about the transaction if it was created via an auction		 */
		private AuctionInfoType AuctionField;
		public AuctionInfoType Auction {
			get {
				return this.AuctionField;
			}
			set {
				this.AuctionField = value;
			}
		}

	 public PaymentItemInfoType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("InvoiceID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("InvoiceID")[0])){ 
		 this.InvoiceID =(string)document.GetElementsByTagName("InvoiceID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Custom").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Custom")[0])){ 
		 this.Custom =(string)document.GetElementsByTagName("Custom")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Memo").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Memo")[0])){ 
		 this.Memo =(string)document.GetElementsByTagName("Memo")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("SalesTax").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SalesTax")[0])){ 
		 this.SalesTax =(string)document.GetElementsByTagName("SalesTax")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("PaymentItem").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentItem")[0])){ 
		 nodeList = document.GetElementsByTagName("PaymentItem");
		 for(int i=0; i<nodeList.Count; i++) {
			 xmlString = DeserializationUtils.convertToXML(nodeList[i]); 
				this.PaymentItem.Add(new PaymentItemType(xmlString));
			}

}
	}
		 if(document.GetElementsByTagName("Subscription").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Subscription")[0])){ 
		 nodeList = document.GetElementsByTagName("Subscription");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.Subscription =  new SubscriptionInfoType(xmlString);

}
	}
		 if(document.GetElementsByTagName("Auction").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Auction")[0])){ 
		 nodeList = document.GetElementsByTagName("Auction");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.Auction =  new AuctionInfoType(xmlString);

}
	}
	}
	}


	/**
	 * PaymentItemType 
	 * Information about a Payment Item.
	 */
	public partial class PaymentItemType {

		/**
		 * eBay Auction Transaction ID of the Item 
		 * Optional
		 * Character length and limitations: 255 single-byte characters
		 */
		private string EbayItemTxnIdField;
		public string EbayItemTxnId {
			get {
				return this.EbayItemTxnIdField;
			}
			set {
				this.EbayItemTxnIdField = value;
			}
		}

		/**
		 * Item name set by you or entered by the customer. 
Character length and limitations: 127 single-byte alphanumeric characters
		 */
		private string NameField;
		public string Name {
			get {
				return this.NameField;
			}
			set {
				this.NameField = value;
			}
		}

		/**
		 * Item number set by you. 
		 * Character length and limitations: 127 single-byte alphanumeric characters		 */
		private string NumberField;
		public string Number {
			get {
				return this.NumberField;
			}
			set {
				this.NumberField = value;
			}
		}

		/**
		 * Quantity set by you or entered by the customer. 
		 * Character length and limitations: no limit		 */
		private string QuantityField;
		public string Quantity {
			get {
				return this.QuantityField;
			}
			set {
				this.QuantityField = value;
			}
		}

		/**
		 * Amount of tax charged on payment 		 */
		private string SalesTaxField;
		public string SalesTax {
			get {
				return this.SalesTaxField;
			}
			set {
				this.SalesTaxField = value;
			}
		}

		/**
		 * Amount of shipping charged on payment 		 */
		private string ShippingAmountField;
		public string ShippingAmount {
			get {
				return this.ShippingAmountField;
			}
			set {
				this.ShippingAmountField = value;
			}
		}

		/**
		 * Amount of handling charged on payment 		 */
		private string HandlingAmountField;
		public string HandlingAmount {
			get {
				return this.HandlingAmountField;
			}
			set {
				this.HandlingAmountField = value;
			}
		}

		/**
		 * Coupon ID Number 		 */
		private string CouponIDField;
		public string CouponID {
			get {
				return this.CouponIDField;
			}
			set {
				this.CouponIDField = value;
			}
		}

		/**
		 * Amount Value of The Coupon 		 */
		private string CouponAmountField;
		public string CouponAmount {
			get {
				return this.CouponAmountField;
			}
			set {
				this.CouponAmountField = value;
			}
		}

		/**
		 * Currency of the Coupon Amount 		 */
		private string CouponAmountCurrencyField;
		public string CouponAmountCurrency {
			get {
				return this.CouponAmountCurrencyField;
			}
			set {
				this.CouponAmountCurrencyField = value;
			}
		}

		/**
		 * Amount of Discount on this Loyality Card		 */
		private string LoyalityCardDiscountAmountField;
		public string LoyalityCardDiscountAmount {
			get {
				return this.LoyalityCardDiscountAmountField;
			}
			set {
				this.LoyalityCardDiscountAmountField = value;
			}
		}

		/**
		 * Currency of the Discount		 */
		private string LoyalityCardDiscountCurrencyField;
		public string LoyalityCardDiscountCurrency {
			get {
				return this.LoyalityCardDiscountCurrencyField;
			}
			set {
				this.LoyalityCardDiscountCurrencyField = value;
			}
		}

		/**
		 * Cost of item 		 */
		private BasicAmountType AmountField;
		public BasicAmountType Amount {
			get {
				return this.AmountField;
			}
			set {
				this.AmountField = value;
			}
		}

		/**
		 * Item options selected in PayPal shopping cart 		 */
		private List<OptionType> OptionsField = new List<OptionType>();
		public List<OptionType> Options {
			get {
				return this.OptionsField;
			}
			set {
				this.OptionsField = value;
			}
		}

	 public PaymentItemType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("EbayItemTxnId").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("EbayItemTxnId")[0])){ 
		 this.EbayItemTxnId =(string)document.GetElementsByTagName("EbayItemTxnId")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Name").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Name")[0])){ 
		 this.Name =(string)document.GetElementsByTagName("Name")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Number").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Number")[0])){ 
		 this.Number =(string)document.GetElementsByTagName("Number")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Quantity").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Quantity")[0])){ 
		 this.Quantity =(string)document.GetElementsByTagName("Quantity")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("SalesTax").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SalesTax")[0])){ 
		 this.SalesTax =(string)document.GetElementsByTagName("SalesTax")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ShippingAmount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ShippingAmount")[0])){ 
		 this.ShippingAmount =(string)document.GetElementsByTagName("ShippingAmount")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("HandlingAmount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("HandlingAmount")[0])){ 
		 this.HandlingAmount =(string)document.GetElementsByTagName("HandlingAmount")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("CouponID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CouponID")[0])){ 
		 this.CouponID =(string)document.GetElementsByTagName("CouponID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("CouponAmount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CouponAmount")[0])){ 
		 this.CouponAmount =(string)document.GetElementsByTagName("CouponAmount")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("CouponAmountCurrency").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CouponAmountCurrency")[0])){ 
		 this.CouponAmountCurrency =(string)document.GetElementsByTagName("CouponAmountCurrency")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("LoyalityCardDiscountAmount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("LoyalityCardDiscountAmount")[0])){ 
		 this.LoyalityCardDiscountAmount =(string)document.GetElementsByTagName("LoyalityCardDiscountAmount")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("LoyalityCardDiscountCurrency").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("LoyalityCardDiscountCurrency")[0])){ 
		 this.LoyalityCardDiscountCurrency =(string)document.GetElementsByTagName("LoyalityCardDiscountCurrency")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Amount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Amount")[0])){ 
		 nodeList = document.GetElementsByTagName("Amount");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.Amount =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("Options").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Options")[0])){ 
		 nodeList = document.GetElementsByTagName("Options");
		 for(int i=0; i<nodeList.Count; i++) {
			 xmlString = DeserializationUtils.convertToXML(nodeList[i]); 
				this.Options.Add(new OptionType(xmlString));
			}

}
	}
	}
	}


	/**
	 * Contains payment request information for each bucket in the cart.
	 */
	public partial class PaymentRequestInfoType {

		/**
		 * Contains the transaction id of the bucket.
		 */
		private string TransactionIdField;
		public string TransactionId {
			get {
				return this.TransactionIdField;
			}
			set {
				this.TransactionIdField = value;
			}
		}

		/**
		 * Contains the bucket id.
		 */
		private string PaymentRequestIDField;
		public string PaymentRequestID {
			get {
				return this.PaymentRequestIDField;
			}
			set {
				this.PaymentRequestIDField = value;
			}
		}

		/**
		 * Contains the error details.
		 */
		private ErrorType PaymentErrorField;
		public ErrorType PaymentError {
			get {
				return this.PaymentErrorField;
			}
			set {
				this.PaymentErrorField = value;
			}
		}

	 public PaymentRequestInfoType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("TransactionId").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TransactionId")[0])){ 
		 this.TransactionId =(string)document.GetElementsByTagName("TransactionId")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("PaymentRequestID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentRequestID")[0])){ 
		 this.PaymentRequestID =(string)document.GetElementsByTagName("PaymentRequestID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("PaymentError").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentError")[0])){ 
		 nodeList = document.GetElementsByTagName("PaymentError");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.PaymentError =  new ErrorType(xmlString);

}
	}
	}
	}


	public enum PaymentStatusCodeType {
[Description("None")]NONE,
[Description("Completed")]COMPLETED,
[Description("Failed")]FAILED,
[Description("Pending")]PENDING,
[Description("Denied")]DENIED,
[Description("Refunded")]REFUNDED,
[Description("Reversed")]REVERSED,
[Description("Canceled-Reversal")]CANCELEDREVERSAL,
[Description("Processed")]PROCESSED,
[Description("Partially-Refunded")]PARTIALLYREFUNDED,
[Description("Voided")]VOIDED,
[Description("Expired")]EXPIRED,
[Description("In-Progress")]INPROGRESS,
[Description("Created")]CREATED,
[Description("Completed-Funds-Held")]COMPLETEDFUNDSHELD,
[Description("Instant")]INSTANT,
[Description("Delayed")]DELAYED,
	}
	public enum PaymentTransactionClassCodeType {
[Description("All")]ALL,
[Description("Sent")]SENT,
[Description("Received")]RECEIVED,
[Description("MassPay")]MASSPAY,
[Description("MoneyRequest")]MONEYREQUEST,
[Description("FundsAdded")]FUNDSADDED,
[Description("FundsWithdrawn")]FUNDSWITHDRAWN,
[Description("PayPalDebitCard")]PAYPALDEBITCARD,
[Description("Referral")]REFERRAL,
[Description("Fee")]FEE,
[Description("Subscription")]SUBSCRIPTION,
[Description("Dividend")]DIVIDEND,
[Description("Billpay")]BILLPAY,
[Description("Refund")]REFUND,
[Description("CurrencyConversions")]CURRENCYCONVERSIONS,
[Description("BalanceTransfer")]BALANCETRANSFER,
[Description("Reversal")]REVERSAL,
[Description("Shipping")]SHIPPING,
[Description("BalanceAffecting")]BALANCEAFFECTING,
[Description("ECheck")]ECHECK,
	}
	public enum PaymentTransactionCodeType {
[Description("none")]NONE,
[Description("web-accept")]WEBACCEPT,
[Description("cart")]CART,
[Description("send-money")]SENDMONEY,
[Description("subscr-failed")]SUBSCRFAILED,
[Description("subscr-cancel")]SUBSCRCANCEL,
[Description("subscr-payment")]SUBSCRPAYMENT,
[Description("subscr-signup")]SUBSCRSIGNUP,
[Description("subscr-eot")]SUBSCREOT,
[Description("subscr-modify")]SUBSCRMODIFY,
[Description("mercht-pmt")]MERCHTPMT,
[Description("mass-pay")]MASSPAY,
[Description("virtual-terminal")]VIRTUALTERMINAL,
[Description("integral-evolution")]INTEGRALEVOLUTION,
[Description("express-checkout")]EXPRESSCHECKOUT,
[Description("pro-hosted")]PROHOSTED,
[Description("pro-api")]PROAPI,
[Description("credit")]CREDIT,
	}
	/**
	 * PaymentTransactionSearchResultType 
	 * Results from a PaymentTransaction search
	 */
	public partial class PaymentTransactionSearchResultType {

		/**
The date and time (in UTC/GMT format) the transaction occurred		 */
		private string TimestampField;
		public string Timestamp {
			get {
				return this.TimestampField;
			}
			set {
				this.TimestampField = value;
			}
		}

		/**
The time zone of the transaction 		 */
		private string TimezoneField;
		public string Timezone {
			get {
				return this.TimezoneField;
			}
			set {
				this.TimezoneField = value;
			}
		}

		/**
The type of the transaction		 */
		private string TypeField;
		public string Type {
			get {
				return this.TypeField;
			}
			set {
				this.TypeField = value;
			}
		}

		/**
The email address of the payer		 */
		private string PayerField;
		public string Payer {
			get {
				return this.PayerField;
			}
			set {
				this.PayerField = value;
			}
		}

		/**
Display name of the payer		 */
		private string PayerDisplayNameField;
		public string PayerDisplayName {
			get {
				return this.PayerDisplayNameField;
			}
			set {
				this.PayerDisplayNameField = value;
			}
		}

		/**
The transaction ID of the seller		 */
		private string TransactionIDField;
		public string TransactionID {
			get {
				return this.TransactionIDField;
			}
			set {
				this.TransactionIDField = value;
			}
		}

		/**
The status of the transaction		 */
		private string StatusField;
		public string Status {
			get {
				return this.StatusField;
			}
			set {
				this.StatusField = value;
			}
		}

		/**
The total gross amount charged, including any profile shipping cost and taxes		 */
		private BasicAmountType GrossAmountField;
		public BasicAmountType GrossAmount {
			get {
				return this.GrossAmountField;
			}
			set {
				this.GrossAmountField = value;
			}
		}

		/**
The fee that PayPal charged for the transaction 		 */
		private BasicAmountType FeeAmountField;
		public BasicAmountType FeeAmount {
			get {
				return this.FeeAmountField;
			}
			set {
				this.FeeAmountField = value;
			}
		}

		/**
The net amount of the transaction 		 */
		private BasicAmountType NetAmountField;
		public BasicAmountType NetAmount {
			get {
				return this.NetAmountField;
			}
			set {
				this.NetAmountField = value;
			}
		}

	 public PaymentTransactionSearchResultType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Timestamp").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Timestamp")[0])){ 
		 this.Timestamp =(string)document.GetElementsByTagName("Timestamp")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Timezone").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Timezone")[0])){ 
		 this.Timezone =(string)document.GetElementsByTagName("Timezone")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Type").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Type")[0])){ 
		 this.Type =(string)document.GetElementsByTagName("Type")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Payer").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Payer")[0])){ 
		 this.Payer =(string)document.GetElementsByTagName("Payer")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("PayerDisplayName").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PayerDisplayName")[0])){ 
		 this.PayerDisplayName =(string)document.GetElementsByTagName("PayerDisplayName")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("TransactionID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TransactionID")[0])){ 
		 this.TransactionID =(string)document.GetElementsByTagName("TransactionID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Status").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Status")[0])){ 
		 this.Status =(string)document.GetElementsByTagName("Status")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("GrossAmount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GrossAmount")[0])){ 
		 nodeList = document.GetElementsByTagName("GrossAmount");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.GrossAmount =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("FeeAmount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("FeeAmount")[0])){ 
		 nodeList = document.GetElementsByTagName("FeeAmount");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.FeeAmount =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("NetAmount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("NetAmount")[0])){ 
		 nodeList = document.GetElementsByTagName("NetAmount");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.NetAmount =  new BasicAmountType(xmlString);

}
	}
	}
	}


	public enum PaymentTransactionStatusCodeType {
[Description("Pending")]PENDING,
[Description("Processing")]PROCESSING,
[Description("Success")]SUCCESS,
[Description("Denied")]DENIED,
[Description("Reversed")]REVERSED,
	}
	/**
	 * PaymentTransactionType 
	 * Information about a PayPal payment from the seller side
	 */
	public partial class PaymentTransactionType {

		/**
Information about the recipient of the payment 		 */
		private ReceiverInfoType ReceiverInfoField;
		public ReceiverInfoType ReceiverInfo {
			get {
				return this.ReceiverInfoField;
			}
			set {
				this.ReceiverInfoField = value;
			}
		}

		/**
Information about the payer 		 */
		private PayerInfoType PayerInfoField;
		public PayerInfoType PayerInfo {
			get {
				return this.PayerInfoField;
			}
			set {
				this.PayerInfoField = value;
			}
		}

		/**
Information about the transaction 		 */
		private PaymentInfoType PaymentInfoField;
		public PaymentInfoType PaymentInfo {
			get {
				return this.PaymentInfoField;
			}
			set {
				this.PaymentInfoField = value;
			}
		}

		/**
Information about an individual item in the transaction		 */
		private PaymentItemInfoType PaymentItemInfoField;
		public PaymentItemInfoType PaymentItemInfo {
			get {
				return this.PaymentItemInfoField;
			}
			set {
				this.PaymentItemInfoField = value;
			}
		}

		/**
Information about an individual Offer and Coupon information in the transaction		 */
		private OfferCouponInfoType OfferCouponInfoField;
		public OfferCouponInfoType OfferCouponInfo {
			get {
				return this.OfferCouponInfoField;
			}
			set {
				this.OfferCouponInfoField = value;
			}
		}

		/**
		 * Information about the user selected options.
		 */
		private UserSelectedOptionType UserSelectedOptionsField;
		public UserSelectedOptionType UserSelectedOptions {
			get {
				return this.UserSelectedOptionsField;
			}
			set {
				this.UserSelectedOptionsField = value;
			}
		}

		/**
		 * Information about the Gift message.
		 */
		private string GiftMessageField;
		public string GiftMessage {
			get {
				return this.GiftMessageField;
			}
			set {
				this.GiftMessageField = value;
			}
		}

		/**
		 * Information about the Gift receipt.
		 */
		private string GiftReceiptField;
		public string GiftReceipt {
			get {
				return this.GiftReceiptField;
			}
			set {
				this.GiftReceiptField = value;
			}
		}

		/**
		 * Information about the Gift Wrap name.
		 */
		private string GiftWrapNameField;
		public string GiftWrapName {
			get {
				return this.GiftWrapNameField;
			}
			set {
				this.GiftWrapNameField = value;
			}
		}

		/**
		 * Information about the Gift Wrap amount.
		 */
		private BasicAmountType GiftWrapAmountField;
		public BasicAmountType GiftWrapAmount {
			get {
				return this.GiftWrapAmountField;
			}
			set {
				this.GiftWrapAmountField = value;
			}
		}

		/**
		 * Information about the Buyer email.
		 */
		private string BuyerEmailOptInField;
		public string BuyerEmailOptIn {
			get {
				return this.BuyerEmailOptInField;
			}
			set {
				this.BuyerEmailOptInField = value;
			}
		}

		/**
		 * Information about the survey question.
		 */
		private string SurveyQuestionField;
		public string SurveyQuestion {
			get {
				return this.SurveyQuestionField;
			}
			set {
				this.SurveyQuestionField = value;
			}
		}

		/**
		 * Information about the survey choice selected by the user.
		 */
		private List<string> SurveyChoiceSelectedField = new List<string>();
		public List<string> SurveyChoiceSelected {
			get {
				return this.SurveyChoiceSelectedField;
			}
			set {
				this.SurveyChoiceSelectedField = value;
			}
		}

	 public PaymentTransactionType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("ReceiverInfo").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ReceiverInfo")[0])){ 
		 nodeList = document.GetElementsByTagName("ReceiverInfo");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.ReceiverInfo =  new ReceiverInfoType(xmlString);

}
	}
		 if(document.GetElementsByTagName("PayerInfo").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PayerInfo")[0])){ 
		 nodeList = document.GetElementsByTagName("PayerInfo");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.PayerInfo =  new PayerInfoType(xmlString);

}
	}
		 if(document.GetElementsByTagName("PaymentInfo").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentInfo")[0])){ 
		 nodeList = document.GetElementsByTagName("PaymentInfo");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.PaymentInfo =  new PaymentInfoType(xmlString);

}
	}
		 if(document.GetElementsByTagName("PaymentItemInfo").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentItemInfo")[0])){ 
		 nodeList = document.GetElementsByTagName("PaymentItemInfo");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.PaymentItemInfo =  new PaymentItemInfoType(xmlString);

}
	}
		 if(document.GetElementsByTagName("OfferCouponInfo").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OfferCouponInfo")[0])){ 
		 nodeList = document.GetElementsByTagName("OfferCouponInfo");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.OfferCouponInfo =  new OfferCouponInfoType(xmlString);

}
	}
		 if(document.GetElementsByTagName("UserSelectedOptions").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("UserSelectedOptions")[0])){ 
		 nodeList = document.GetElementsByTagName("UserSelectedOptions");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.UserSelectedOptions =  new UserSelectedOptionType(xmlString);

}
	}
		 if(document.GetElementsByTagName("GiftMessage").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GiftMessage")[0])){ 
		 this.GiftMessage =(string)document.GetElementsByTagName("GiftMessage")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("GiftReceipt").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GiftReceipt")[0])){ 
		 this.GiftReceipt =(string)document.GetElementsByTagName("GiftReceipt")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("GiftWrapName").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GiftWrapName")[0])){ 
		 this.GiftWrapName =(string)document.GetElementsByTagName("GiftWrapName")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("GiftWrapAmount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GiftWrapAmount")[0])){ 
		 nodeList = document.GetElementsByTagName("GiftWrapAmount");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.GiftWrapAmount =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("BuyerEmailOptIn").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BuyerEmailOptIn")[0])){ 
		 this.BuyerEmailOptIn =(string)document.GetElementsByTagName("BuyerEmailOptIn")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("SurveyQuestion").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SurveyQuestion")[0])){ 
		 this.SurveyQuestion =(string)document.GetElementsByTagName("SurveyQuestion")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("SurveyChoiceSelected").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SurveyChoiceSelected")[0])){ 
		 nodeList = document.GetElementsByTagName("SurveyChoiceSelected");
		 for(int i=0; i<nodeList.Count; i++) {
			 string value = nodeList[i].InnerText; 
			 this.SurveyChoiceSelected.Add(value);
		}

}
	}
	}
	}


	public enum PendingStatusCodeType {
[Description("none")]NONE,
[Description("echeck")]ECHECK,
[Description("intl")]INTL,
[Description("verify")]VERIFY,
[Description("address")]ADDRESS,
[Description("unilateral")]UNILATERAL,
[Description("other")]OTHER,
[Description("upgrade")]UPGRADE,
[Description("multi-currency")]MULTICURRENCY,
[Description("authorization")]AUTHORIZATION,
[Description("order")]ORDER,
[Description("payment-review")]PAYMENTREVIEW,
	}
	public enum PercentageRevenueFromOnlineSalesType {
[Description("PercentageRevenueFromOnlineSales-Not-Applicable")]PERCENTAGEREVENUEFROMONLINESALESNOTAPPLICABLE,
[Description("PercentageRevenueFromOnlineSales-Range1")]PERCENTAGEREVENUEFROMONLINESALESRANGE1,
[Description("PercentageRevenueFromOnlineSales-Range2")]PERCENTAGEREVENUEFROMONLINESALESRANGE2,
[Description("PercentageRevenueFromOnlineSales-Range3")]PERCENTAGEREVENUEFROMONLINESALESRANGE3,
[Description("PercentageRevenueFromOnlineSales-Range4")]PERCENTAGEREVENUEFROMONLINESALESRANGE4,
	}
	/**
	 */
	public partial class PersonNameType {

		private string SalutationField;
		public string Salutation {
			get {
				return this.SalutationField;
			}
			set {
				this.SalutationField = value;
			}
		}

		private string FirstNameField;
		public string FirstName {
			get {
				return this.FirstNameField;
			}
			set {
				this.FirstNameField = value;
			}
		}

		private string MiddleNameField;
		public string MiddleName {
			get {
				return this.MiddleNameField;
			}
			set {
				this.MiddleNameField = value;
			}
		}

		private string LastNameField;
		public string LastName {
			get {
				return this.LastNameField;
			}
			set {
				this.LastNameField = value;
			}
		}

		private string SuffixField;
		public string Suffix {
			get {
				return this.SuffixField;
			}
			set {
				this.SuffixField = value;
			}
		}

		public PersonNameType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( Salutation != null ) {
			sb.Append("<ebl:Salutation>").Append(Salutation);
			sb.Append("</ebl:Salutation>");
		}
		if( FirstName != null ) {
			sb.Append("<ebl:FirstName>").Append(FirstName);
			sb.Append("</ebl:FirstName>");
		}
		if( MiddleName != null ) {
			sb.Append("<ebl:MiddleName>").Append(MiddleName);
			sb.Append("</ebl:MiddleName>");
		}
		if( LastName != null ) {
			sb.Append("<ebl:LastName>").Append(LastName);
			sb.Append("</ebl:LastName>");
		}
		if( Suffix != null ) {
			sb.Append("<ebl:Suffix>").Append(Suffix);
			sb.Append("</ebl:Suffix>");
		}
		return sb.ToString();
	}

	 public PersonNameType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Salutation").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Salutation")[0])){ 
		 this.Salutation =(string)document.GetElementsByTagName("Salutation")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("FirstName").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("FirstName")[0])){ 
		 this.FirstName =(string)document.GetElementsByTagName("FirstName")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("MiddleName").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("MiddleName")[0])){ 
		 this.MiddleName =(string)document.GetElementsByTagName("MiddleName")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("LastName").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("LastName")[0])){ 
		 this.LastName =(string)document.GetElementsByTagName("LastName")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Suffix").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Suffix")[0])){ 
		 this.Suffix =(string)document.GetElementsByTagName("Suffix")[0].InnerText;

}
	}
	}
	}


	/**
	 * Country code associated with this phone number.  
	 */
	public partial class PhoneNumberType {

		/**
		 * Country code associated with this phone number.  
		 */
		private string CountryCodeField;
		public string CountryCode {
			get {
				return this.CountryCodeField;
			}
			set {
				this.CountryCodeField = value;
			}
		}

		/**
		 * Phone number associated with this phone.  
		 */
		private string PhoneNumberField;
		public string PhoneNumber {
			get {
				return this.PhoneNumberField;
			}
			set {
				this.PhoneNumberField = value;
			}
		}

		/**
		 * Extension associated with this phone number.  
		 */
		private string ExtensionField;
		public string Extension {
			get {
				return this.ExtensionField;
			}
			set {
				this.ExtensionField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( CountryCode != null ) {
			sb.Append("<ebl:CountryCode>").Append(CountryCode);
			sb.Append("</ebl:CountryCode>");
		}
		if( PhoneNumber != null ) {
			sb.Append("<ebl:PhoneNumber>").Append(PhoneNumber);
			sb.Append("</ebl:PhoneNumber>");
		}
		if( Extension != null ) {
			sb.Append("<ebl:Extension>").Append(Extension);
			sb.Append("</ebl:Extension>");
		}
		return sb.ToString();
	}

	}


	public enum ProductCategoryType {
[Description("Other")]OTHER,
[Description("Airlines")]AIRLINES,
[Description("Antiques")]ANTIQUES,
[Description("Art")]ART,
[Description("Cameras_Photos")]CAMERASPHOTOS,
[Description("Cars_Boats_Vehicles_Parts")]CARSBOATSVEHICLESPARTS,
[Description("CellPhones_Telecom")]CELLPHONESTELECOM,
[Description("Coins_PaperMoney")]COINSPAPERMONEY,
[Description("Collectibles")]COLLECTIBLES,
[Description("Computers_Networking")]COMPUTERSNETWORKING,
[Description("ConsumerElectronics")]CONSUMERELECTRONICS,
[Description("Jewelry_Watches")]JEWELRYWATCHES,
[Description("MusicalInstruments")]MUSICALINSTRUMENTS,
[Description("RealEstate")]REALESTATE,
[Description("SportsMemorabilia_Cards_FanShop")]SPORTSMEMORABILIACARDSFANSHOP,
[Description("Stamps")]STAMPS,
[Description("Tickets")]TICKETS,
[Description("Travels")]TRAVELS,
[Description("Gambling")]GAMBLING,
[Description("Alcohol")]ALCOHOL,
[Description("Tobacco")]TOBACCO,
[Description("MoneyTransfer")]MONEYTRANSFER,
[Description("Software")]SOFTWARE,
	}
	public enum ReceiverInfoCodeType {
[Description("EmailAddress")]EMAILADDRESS,
[Description("UserID")]USERID,
[Description("PhoneNumber")]PHONENUMBER,
	}
	/**
	 * ReceiverInfoType 
	 * Receiver information.
	 */
	public partial class ReceiverInfoType {

		/**
		 * Email address or account ID of the payment recipient (the seller). Equivalent to Receiver if payment is sent to primary account. 
Character length and limitations: 127 single-byte alphanumeric characters
		 */
		private string BusinessField;
		public string Business {
			get {
				return this.BusinessField;
			}
			set {
				this.BusinessField = value;
			}
		}

		/**
Primary email address of the payment recipient (the seller). If you are the recipient of the payment and the payment is sent to your non-primary email address, the value of Receiver is still your primary email address. 
Character length and limitations: 127 single-byte alphanumeric characters
		 */
		private string ReceiverField;
		public string Receiver {
			get {
				return this.ReceiverField;
			}
			set {
				this.ReceiverField = value;
			}
		}

		/**
Unique account ID of the payment recipient (the seller). This value is the same as the value of the recipient's referral ID. 		 */
		private string ReceiverIDField;
		public string ReceiverID {
			get {
				return this.ReceiverIDField;
			}
			set {
				this.ReceiverIDField = value;
			}
		}

	 public ReceiverInfoType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Business").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Business")[0])){ 
		 this.Business =(string)document.GetElementsByTagName("Business")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Receiver").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Receiver")[0])){ 
		 this.Receiver =(string)document.GetElementsByTagName("Receiver")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ReceiverID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ReceiverID")[0])){ 
		 this.ReceiverID =(string)document.GetElementsByTagName("ReceiverID")[0].InnerText;

}
	}
	}
	}


	public enum RecurringFlagType {
[Description("Y")]Y1,
[Description("y")]Y2,
	}
	/**
	 * Subscriber name - if missing, will use name in buyer's account 
	 */
	public partial class RecurringPaymentsProfileDetailsType {

		/**
		 * Subscriber name - if missing, will use name in buyer's account 
		 */
		private string SubscriberNameField;
		public string SubscriberName {
			get {
				return this.SubscriberNameField;
			}
			set {
				this.SubscriberNameField = value;
			}
		}

		/**
		 * Subscriber address - if missing, will use address in buyer's account
		 */
		private AddressType SubscriberShippingAddressField;
		public AddressType SubscriberShippingAddress {
			get {
				return this.SubscriberShippingAddressField;
			}
			set {
				this.SubscriberShippingAddressField = value;
			}
		}

		/**
		 * When does this Profile begin billing?
		 */
		private string BillingStartDateField;
		public string BillingStartDate {
			get {
				return this.BillingStartDateField;
			}
			set {
				this.BillingStartDateField = value;
			}
		}

		/**
Your own unique invoice or tracking number.
		 * Optional
		 * Character length and limitations: 127 single-byte alphanumeric characters
		 */
		private string ProfileReferenceField;
		public string ProfileReference {
			get {
				return this.ProfileReferenceField;
			}
			set {
				this.ProfileReferenceField = value;
			}
		}

		public RecurringPaymentsProfileDetailsType(string BillingStartDate) {
			this.BillingStartDate = BillingStartDate;
		}
		public RecurringPaymentsProfileDetailsType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( SubscriberName != null ) {
			sb.Append("<ebl:SubscriberName>").Append(SubscriberName);
			sb.Append("</ebl:SubscriberName>");
		}
		if( SubscriberShippingAddress != null ) {
			sb.Append("<ebl:SubscriberShippingAddress>");
			sb.Append(SubscriberShippingAddress.toXMLString());
			sb.Append("</ebl:SubscriberShippingAddress>");
		}
		if( BillingStartDate != null ) {
			sb.Append("<ebl:BillingStartDate>").Append(BillingStartDate);
			sb.Append("</ebl:BillingStartDate>");
		}
		if( ProfileReference != null ) {
			sb.Append("<ebl:ProfileReference>").Append(ProfileReference);
			sb.Append("</ebl:ProfileReference>");
		}
		return sb.ToString();
	}

	 public RecurringPaymentsProfileDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("SubscriberName").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SubscriberName")[0])){ 
		 this.SubscriberName =(string)document.GetElementsByTagName("SubscriberName")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("SubscriberShippingAddress").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SubscriberShippingAddress")[0])){ 
		 nodeList = document.GetElementsByTagName("SubscriberShippingAddress");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.SubscriberShippingAddress =  new AddressType(xmlString);

}
	}
		 if(document.GetElementsByTagName("BillingStartDate").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillingStartDate")[0])){ 
		 this.BillingStartDate =(string)document.GetElementsByTagName("BillingStartDate")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ProfileReference").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ProfileReference")[0])){ 
		 this.ProfileReference =(string)document.GetElementsByTagName("ProfileReference")[0].InnerText;

}
	}
	}
	}


	public enum RecurringPaymentsProfileStatusType {
[Description("ActiveProfile")]ACTIVEPROFILE,
[Description("PendingProfile")]PENDINGPROFILE,
[Description("CancelledProfile")]CANCELLEDPROFILE,
[Description("ExpiredProfile")]EXPIREDPROFILE,
[Description("SuspendedProfile")]SUSPENDEDPROFILE,
	}
	/**
	 */
	public partial class RecurringPaymentsSummaryType {

		/**
		 */
		private string NextBillingDateField;
		public string NextBillingDate {
			get {
				return this.NextBillingDateField;
			}
			set {
				this.NextBillingDateField = value;
			}
		}

		/**
		 */
		private int? NumberCyclesCompletedField;
		public int? NumberCyclesCompleted {
			get {
				return this.NumberCyclesCompletedField;
			}
			set {
				this.NumberCyclesCompletedField = value;
			}
		}

		/**
		 */
		private int? NumberCyclesRemainingField;
		public int? NumberCyclesRemaining {
			get {
				return this.NumberCyclesRemainingField;
			}
			set {
				this.NumberCyclesRemainingField = value;
			}
		}

		/**
		 */
		private BasicAmountType OutstandingBalanceField;
		public BasicAmountType OutstandingBalance {
			get {
				return this.OutstandingBalanceField;
			}
			set {
				this.OutstandingBalanceField = value;
			}
		}

		/**
		 */
		private int? FailedPaymentCountField;
		public int? FailedPaymentCount {
			get {
				return this.FailedPaymentCountField;
			}
			set {
				this.FailedPaymentCountField = value;
			}
		}

		/**
		 */
		private string LastPaymentDateField;
		public string LastPaymentDate {
			get {
				return this.LastPaymentDateField;
			}
			set {
				this.LastPaymentDateField = value;
			}
		}

		/**
		 */
		private BasicAmountType LastPaymentAmountField;
		public BasicAmountType LastPaymentAmount {
			get {
				return this.LastPaymentAmountField;
			}
			set {
				this.LastPaymentAmountField = value;
			}
		}

	 public RecurringPaymentsSummaryType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("NextBillingDate").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("NextBillingDate")[0])){ 
		 this.NextBillingDate =(string)document.GetElementsByTagName("NextBillingDate")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("NumberCyclesCompleted").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("NumberCyclesCompleted")[0])){ 
		 this.NumberCyclesCompleted =System.Convert.ToInt32(document.GetElementsByTagName("NumberCyclesCompleted")[0].InnerText);

}
	}
		 if(document.GetElementsByTagName("NumberCyclesRemaining").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("NumberCyclesRemaining")[0])){ 
		 this.NumberCyclesRemaining =System.Convert.ToInt32(document.GetElementsByTagName("NumberCyclesRemaining")[0].InnerText);

}
	}
		 if(document.GetElementsByTagName("OutstandingBalance").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OutstandingBalance")[0])){ 
		 nodeList = document.GetElementsByTagName("OutstandingBalance");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.OutstandingBalance =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("FailedPaymentCount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("FailedPaymentCount")[0])){ 
		 this.FailedPaymentCount =System.Convert.ToInt32(document.GetElementsByTagName("FailedPaymentCount")[0].InnerText);

}
	}
		 if(document.GetElementsByTagName("LastPaymentDate").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("LastPaymentDate")[0])){ 
		 this.LastPaymentDate =(string)document.GetElementsByTagName("LastPaymentDate")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("LastPaymentAmount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("LastPaymentAmount")[0])){ 
		 nodeList = document.GetElementsByTagName("LastPaymentAmount");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.LastPaymentAmount =  new BasicAmountType(xmlString);

}
	}
	}
	}


	public enum RedeemedOfferType {
[Description("MERCHANT_COUPON")]MERCHANTCOUPON,
[Description("LOYALTY_CARD")]LOYALTYCARD,
[Description("MANUFACTURER_COUPON")]MANUFACTURERCOUPON,
[Description("RESERVED")]RESERVED,
	}
	/**
	 * CreditCardDetailsType for DCC Reference Transaction
	 * Information about a Credit Card.
	 */
	public partial class ReferenceCreditCardDetailsType {

		private CreditCardNumberTypeType CreditCardNumberTypeField;
		public CreditCardNumberTypeType CreditCardNumberType {
			get {
				return this.CreditCardNumberTypeField;
			}
			set {
				this.CreditCardNumberTypeField = value;
			}
		}

		private int? ExpMonthField;
		public int? ExpMonth {
			get {
				return this.ExpMonthField;
			}
			set {
				this.ExpMonthField = value;
			}
		}

		private int? ExpYearField;
		public int? ExpYear {
			get {
				return this.ExpYearField;
			}
			set {
				this.ExpYearField = value;
			}
		}

		private PersonNameType CardOwnerNameField;
		public PersonNameType CardOwnerName {
			get {
				return this.CardOwnerNameField;
			}
			set {
				this.CardOwnerNameField = value;
			}
		}

		private AddressType BillingAddressField;
		public AddressType BillingAddress {
			get {
				return this.BillingAddressField;
			}
			set {
				this.BillingAddressField = value;
			}
		}

		private string CVV2Field;
		public string CVV2 {
			get {
				return this.CVV2Field;
			}
			set {
				this.CVV2Field = value;
			}
		}

		private int? StartMonthField;
		public int? StartMonth {
			get {
				return this.StartMonthField;
			}
			set {
				this.StartMonthField = value;
			}
		}

		private int? StartYearField;
		public int? StartYear {
			get {
				return this.StartYearField;
			}
			set {
				this.StartYearField = value;
			}
		}

		private string IssueNumberField;
		public string IssueNumber {
			get {
				return this.IssueNumberField;
			}
			set {
				this.IssueNumberField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( CreditCardNumberType != null ) {
			sb.Append("<ebl:CreditCardNumberType>");
			sb.Append(CreditCardNumberType.toXMLString());
			sb.Append("</ebl:CreditCardNumberType>");
		}
		if( ExpMonth != null ) {
			sb.Append("<ebl:ExpMonth>").Append(ExpMonth);
			sb.Append("</ebl:ExpMonth>");
		}
		if( ExpYear != null ) {
			sb.Append("<ebl:ExpYear>").Append(ExpYear);
			sb.Append("</ebl:ExpYear>");
		}
		if( CardOwnerName != null ) {
			sb.Append("<ebl:CardOwnerName>");
			sb.Append(CardOwnerName.toXMLString());
			sb.Append("</ebl:CardOwnerName>");
		}
		if( BillingAddress != null ) {
			sb.Append("<ebl:BillingAddress>");
			sb.Append(BillingAddress.toXMLString());
			sb.Append("</ebl:BillingAddress>");
		}
		if( CVV2 != null ) {
			sb.Append("<ebl:CVV2>").Append(CVV2);
			sb.Append("</ebl:CVV2>");
		}
		if( StartMonth != null ) {
			sb.Append("<ebl:StartMonth>").Append(StartMonth);
			sb.Append("</ebl:StartMonth>");
		}
		if( StartYear != null ) {
			sb.Append("<ebl:StartYear>").Append(StartYear);
			sb.Append("</ebl:StartYear>");
		}
		if( IssueNumber != null ) {
			sb.Append("<ebl:IssueNumber>").Append(IssueNumber);
			sb.Append("</ebl:IssueNumber>");
		}
		return sb.ToString();
	}

	}


	/**
	 * Holds refunds payment status information
	 */
	public partial class RefundInfoType {

		/**
		 * Refund status whether it is Instant or Delayed.
		 */
		private PaymentStatusCodeType? RefundStatusField;
		public PaymentStatusCodeType? RefundStatus {
			get {
				return this.RefundStatusField;
			}
			set {
				this.RefundStatusField = value;
			}
		}

		/**
		 * Tells us the reason when refund payment status is Delayed.
		 */
		private PendingStatusCodeType? PendingReasonField;
		public PendingStatusCodeType? PendingReason {
			get {
				return this.PendingReasonField;
			}
			set {
				this.PendingReasonField = value;
			}
		}

	 public RefundInfoType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("RefundStatus").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("RefundStatus")[0])){ 
		 this.RefundStatus = (PaymentStatusCodeType)EnumUtils.getValue(document.GetElementsByTagName("RefundStatus")[0].InnerText,typeof(PaymentStatusCodeType));

}
	}
		 if(document.GetElementsByTagName("PendingReason").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PendingReason")[0])){ 
		 this.PendingReason = (PendingStatusCodeType)EnumUtils.getValue(document.GetElementsByTagName("PendingReason")[0].InnerText,typeof(PendingStatusCodeType));

}
	}
	}
	}


	public enum RefundSourceCodeType {
[Description("any")]ANY,
[Description("default")]DEFAULT,
[Description("instant")]INSTANT,
[Description("echeck")]ECHECK,
	}
	/**
	 */
	public partial class RefundTransactionReq {

		private RefundTransactionRequestType RefundTransactionRequestField;
		public RefundTransactionRequestType RefundTransactionRequest {
			get {
				return this.RefundTransactionRequestField;
			}
			set {
				this.RefundTransactionRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:RefundTransactionReq>");
		if( RefundTransactionRequest != null ) {
			sb.Append("<urn:RefundTransactionRequest>");
			sb.Append(RefundTransactionRequest.toXMLString());
			sb.Append("</urn:RefundTransactionRequest>");
		}
sb.Append("</urn:RefundTransactionReq>");
		return sb.ToString();
	}

	}


	/**
	 * Unique identifier of the  transaction you are refunding.
	 * Required
	 * Character length and limitations: 17 single-byte alphanumeric characters 
	 */
	public partial class RefundTransactionRequestType :AbstractRequestType{

		/**
Unique identifier of the  transaction you are refunding.
		 * Required
		 * Character length and limitations: 17 single-byte alphanumeric characters 
		 */
		private string TransactionIDField;
		public string TransactionID {
			get {
				return this.TransactionIDField;
			}
			set {
				this.TransactionIDField = value;
			}
		}

		/**
Invoice number corresponding to transaction details for tracking the refund of a payment. This parameter is passed by the merchant or recipient while refunding the transaction. This parameter does not affect the business logic, it is persisted in the DB for transaction reference
		 * Optional
		 */
		private string InvoiceIDField;
		public string InvoiceID {
			get {
				return this.InvoiceIDField;
			}
			set {
				this.InvoiceIDField = value;
			}
		}

		/**
Type of refund you are making
		 * Required
		 */
		private RefundType? RefundTypeField;
		public RefundType? RefundType {
			get {
				return this.RefundTypeField;
			}
			set {
				this.RefundTypeField = value;
			}
		}

		/**
Refund amount. 
		 * Amount is required  if RefundType is Partial.
		 * NOTE: If RefundType is Full, do not set Amount.
		 */
		private BasicAmountType AmountField;
		public BasicAmountType Amount {
			get {
				return this.AmountField;
			}
			set {
				this.AmountField = value;
			}
		}

		/**
Custom memo about the refund. 
		 * Optional
		 * Character length and limitations: 255 single-byte alphanumeric characters
		 */
		private string MemoField;
		public string Memo {
			get {
				return this.MemoField;
			}
			set {
				this.MemoField = value;
			}
		}

		/**
The maximum time till which refund must be tried.
		 * Optional
		 */
		private string RetryUntilField;
		public string RetryUntil {
			get {
				return this.RetryUntilField;
			}
			set {
				this.RetryUntilField = value;
			}
		}

		/**
The type of funding source for refund.
		 * Optional
		 */
		private RefundSourceCodeType? RefundSourceField;
		public RefundSourceCodeType? RefundSource {
			get {
				return this.RefundSourceField;
			}
			set {
				this.RefundSourceField = value;
			}
		}

		/**
Flag to indicate that the customer was already given store credit for a given transaction. This will allow us to make sure we do not double refund.
		 * Optional
		 */
		private bool? RefundAdviceField;
		public bool? RefundAdvice {
			get {
				return this.RefundAdviceField;
			}
			set {
				this.RefundAdviceField = value;
			}
		}

		/**
To pass the Merchant store informationOptional
		 */
		private MerchantStoreDetailsType MerchantStoreDetailsField;
		public MerchantStoreDetailsType MerchantStoreDetails {
			get {
				return this.MerchantStoreDetailsField;
			}
			set {
				this.MerchantStoreDetailsField = value;
			}
		}

		/**
Information about the individual details of the items to be refunded.Optional
		 */
		private List<InvoiceItemType> RefundItemDetailsField = new List<InvoiceItemType>();
		public List<InvoiceItemType> RefundItemDetails {
			get {
				return this.RefundItemDetailsField;
			}
			set {
				this.RefundItemDetailsField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( TransactionID != null ) {
			sb.Append("<urn:TransactionID>").Append(TransactionID);
			sb.Append("</urn:TransactionID>");
		}
		if( InvoiceID != null ) {
			sb.Append("<urn:InvoiceID>").Append(InvoiceID);
			sb.Append("</urn:InvoiceID>");
		}
		if( RefundType != null ) {
			sb.Append("<urn:RefundType>").Append(EnumUtils.getDescription(RefundType));
			sb.Append("</urn:RefundType>");
		}
		if( Amount != null ) {
			sb.Append("<urn:Amount ");
			sb.Append(Amount.toXMLString());
			sb.Append("</urn:Amount>");
		}
		if( Memo != null ) {
			sb.Append("<urn:Memo>").Append(Memo);
			sb.Append("</urn:Memo>");
		}
		if( RetryUntil != null ) {
			sb.Append("<urn:RetryUntil>").Append(RetryUntil);
			sb.Append("</urn:RetryUntil>");
		}
		if( RefundSource != null ) {
			sb.Append("<urn:RefundSource>").Append(EnumUtils.getDescription(RefundSource));
			sb.Append("</urn:RefundSource>");
		}
		if( RefundAdvice != null ) {
			sb.Append("<urn:RefundAdvice>").Append(RefundAdvice);
			sb.Append("</urn:RefundAdvice>");
		}
		if( MerchantStoreDetails != null ) {
			sb.Append("<ebl:MerchantStoreDetails>");
			sb.Append(MerchantStoreDetails.toXMLString());
			sb.Append("</ebl:MerchantStoreDetails>");
		}
		if( RefundItemDetails != null ) {
			for(int i=0; i<RefundItemDetails.Count; i++) {
				sb.Append("<ebl:RefundItemDetails>");
				sb.Append(RefundItemDetails[i].toXMLString());
				sb.Append("</ebl:RefundItemDetails>");
			}
		}
		return sb.ToString();
	}

	}


	/**
	 * Unique transaction ID of the refund. 
	 * Character length and limitations:17 single-byte characters
	 */
	public partial class RefundTransactionResponseType :AbstractResponseType{

		/**
Unique transaction ID of the refund. 
		 * Character length and limitations:17 single-byte characters
		 */
		private string RefundTransactionIDField;
		public string RefundTransactionID {
			get {
				return this.RefundTransactionIDField;
			}
			set {
				this.RefundTransactionIDField = value;
			}
		}

		/**
Amount subtracted from PayPal balance of original recipient of payment to make this refund 
		 */
		private BasicAmountType NetRefundAmountField;
		public BasicAmountType NetRefundAmount {
			get {
				return this.NetRefundAmountField;
			}
			set {
				this.NetRefundAmountField = value;
			}
		}

		/**
Transaction fee refunded to original recipient of payment 
		 */
		private BasicAmountType FeeRefundAmountField;
		public BasicAmountType FeeRefundAmount {
			get {
				return this.FeeRefundAmountField;
			}
			set {
				this.FeeRefundAmountField = value;
			}
		}

		/**
Amount of money refunded to original payer 		 */
		private BasicAmountType GrossRefundAmountField;
		public BasicAmountType GrossRefundAmount {
			get {
				return this.GrossRefundAmountField;
			}
			set {
				this.GrossRefundAmountField = value;
			}
		}

		/**
Total of all previous refunds		 */
		private BasicAmountType TotalRefundedAmountField;
		public BasicAmountType TotalRefundedAmount {
			get {
				return this.TotalRefundedAmountField;
			}
			set {
				this.TotalRefundedAmountField = value;
			}
		}

		/**
Contains Refund Payment status information.		 */
		private RefundInfoType RefundInfoField;
		public RefundInfoType RefundInfo {
			get {
				return this.RefundInfoField;
			}
			set {
				this.RefundInfoField = value;
			}
		}

		/**
Any general information like offer details that is reinstated or any other marketing data		 */
		private string ReceiptDataField;
		public string ReceiptData {
			get {
				return this.ReceiptDataField;
			}
			set {
				this.ReceiptDataField = value;
			}
		}

	 public RefundTransactionResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("RefundTransactionID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("RefundTransactionID")[0])){ 
		 this.RefundTransactionID =(string)document.GetElementsByTagName("RefundTransactionID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("NetRefundAmount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("NetRefundAmount")[0])){ 
		 nodeList = document.GetElementsByTagName("NetRefundAmount");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.NetRefundAmount =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("FeeRefundAmount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("FeeRefundAmount")[0])){ 
		 nodeList = document.GetElementsByTagName("FeeRefundAmount");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.FeeRefundAmount =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("GrossRefundAmount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GrossRefundAmount")[0])){ 
		 nodeList = document.GetElementsByTagName("GrossRefundAmount");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.GrossRefundAmount =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("TotalRefundedAmount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TotalRefundedAmount")[0])){ 
		 nodeList = document.GetElementsByTagName("TotalRefundedAmount");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.TotalRefundedAmount =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("RefundInfo").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("RefundInfo")[0])){ 
		 nodeList = document.GetElementsByTagName("RefundInfo");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.RefundInfo =  new RefundInfoType(xmlString);

}
	}
		 if(document.GetElementsByTagName("ReceiptData").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ReceiptData")[0])){ 
		 this.ReceiptData =(string)document.GetElementsByTagName("ReceiptData")[0].InnerText;

}
	}
	}
	}


	public enum RefundType {
[Description("Other")]OTHER,
[Description("Full")]FULL,
[Description("Partial")]PARTIAL,
[Description("ExternalDispute")]EXTERNALDISPUTE,
	}
	/**
	 * External remember-me ID returned by GetExpressCheckoutDetails on successful opt-in. The
	 * ExternalRememberMeID is a 17-character alphanumeric (encrypted) string that identifies
	 * the buyer's remembered login with a merchant and has meaning only to the merchant.  If
	 * present, requests that the web flow attempt bypass of login.
	 */
	public partial class RememberMeIDInfoType {

		/**
		 * External remember-me ID returned by GetExpressCheckoutDetails on successful opt-in. The
		 * ExternalRememberMeID is a 17-character alphanumeric (encrypted) string that identifies
		 * the buyer's remembered login with a merchant and has meaning only to the merchant.  If
		 * present, requests that the web flow attempt bypass of login.
		 */
		private string ExternalRememberMeIDField;
		public string ExternalRememberMeID {
			get {
				return this.ExternalRememberMeIDField;
			}
			set {
				this.ExternalRememberMeIDField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( ExternalRememberMeID != null ) {
			sb.Append("<ebl:ExternalRememberMeID>").Append(ExternalRememberMeID);
			sb.Append("</ebl:ExternalRememberMeID>");
		}
		return sb.ToString();
	}

	}


	public enum ReversalReasonCodeType {
[Description("none")]NONE,
[Description("chargeback")]CHARGEBACK,
[Description("guarantee")]GUARANTEE,
[Description("buyer-complaint")]BUYERCOMPLAINT,
[Description("refund")]REFUND,
[Description("other")]OTHER,
	}
	/**
	 */
	public partial class ReverseTransactionReq {

		private ReverseTransactionRequestType ReverseTransactionRequestField;
		public ReverseTransactionRequestType ReverseTransactionRequest {
			get {
				return this.ReverseTransactionRequestField;
			}
			set {
				this.ReverseTransactionRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:ReverseTransactionReq>");
		if( ReverseTransactionRequest != null ) {
			sb.Append("<urn:ReverseTransactionRequest>");
			sb.Append(ReverseTransactionRequest.toXMLString());
			sb.Append("</urn:ReverseTransactionRequest>");
		}
sb.Append("</urn:ReverseTransactionReq>");
		return sb.ToString();
	}

	}


	/**
	 * Identifier of the transaction to reverse.
	 * Required
	 * Character length and limitations: 17 single-byte alphanumeric characters
	 */
	public partial class ReverseTransactionRequestDetailsType {

		/**
Identifier of the transaction to reverse.
		 * Required
		 * Character length and limitations: 17 single-byte alphanumeric characters
		 */
		private string TransactionIDField;
		public string TransactionID {
			get {
				return this.TransactionIDField;
			}
			set {
				this.TransactionIDField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( TransactionID != null ) {
			sb.Append("<ebl:TransactionID>").Append(TransactionID);
			sb.Append("</ebl:TransactionID>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class ReverseTransactionRequestType :AbstractRequestType{

		private ReverseTransactionRequestDetailsType ReverseTransactionRequestDetailsField;
		public ReverseTransactionRequestDetailsType ReverseTransactionRequestDetails {
			get {
				return this.ReverseTransactionRequestDetailsField;
			}
			set {
				this.ReverseTransactionRequestDetailsField = value;
			}
		}

		public ReverseTransactionRequestType(ReverseTransactionRequestDetailsType ReverseTransactionRequestDetails) {
			this.ReverseTransactionRequestDetails = ReverseTransactionRequestDetails;
		}
		public ReverseTransactionRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( ReverseTransactionRequestDetails != null ) {
			sb.Append("<ebl:ReverseTransactionRequestDetails>");
			sb.Append(ReverseTransactionRequestDetails.toXMLString());
			sb.Append("</ebl:ReverseTransactionRequestDetails>");
		}
		return sb.ToString();
	}

	}


	/**
	 * Unique transaction identifier of the reversal transaction created.
	 * Character length and limitations:17 single-byte characters
	 */
	public partial class ReverseTransactionResponseDetailsType {

		/**
Unique transaction identifier of the reversal transaction created.
		 * Character length and limitations:17 single-byte characters
		 */
		private string ReverseTransactionIDField;
		public string ReverseTransactionID {
			get {
				return this.ReverseTransactionIDField;
			}
			set {
				this.ReverseTransactionIDField = value;
			}
		}

		/**
Status of reversal request.
		 * Required
		 */
		private string StatusField;
		public string Status {
			get {
				return this.StatusField;
			}
			set {
				this.StatusField = value;
			}
		}

	 public ReverseTransactionResponseDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("ReverseTransactionID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ReverseTransactionID")[0])){ 
		 this.ReverseTransactionID =(string)document.GetElementsByTagName("ReverseTransactionID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Status").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Status")[0])){ 
		 this.Status =(string)document.GetElementsByTagName("Status")[0].InnerText;

}
	}
	}
	}


	/**
	 */
	public partial class ReverseTransactionResponseType :AbstractResponseType{

		private ReverseTransactionResponseDetailsType ReverseTransactionResponseDetailsField;
		public ReverseTransactionResponseDetailsType ReverseTransactionResponseDetails {
			get {
				return this.ReverseTransactionResponseDetailsField;
			}
			set {
				this.ReverseTransactionResponseDetailsField = value;
			}
		}

	 public ReverseTransactionResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("ReverseTransactionResponseDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ReverseTransactionResponseDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("ReverseTransactionResponseDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.ReverseTransactionResponseDetails =  new ReverseTransactionResponseDetailsType(xmlString);

}
	}
	}
	}


	/**
	 * Details of Risk Filter.
	 */
	public partial class RiskFilterDetailsType {

		private int? IdField;
		public int? Id {
			get {
				return this.IdField;
			}
			set {
				this.IdField = value;
			}
		}

		private string NameField;
		public string Name {
			get {
				return this.NameField;
			}
			set {
				this.NameField = value;
			}
		}

		private string DescriptionField;
		public string Description {
			get {
				return this.DescriptionField;
			}
			set {
				this.DescriptionField = value;
			}
		}

	 public RiskFilterDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Id").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Id")[0])){ 
		 this.Id =System.Convert.ToInt32(document.GetElementsByTagName("Id")[0].InnerText);

}
	}
		 if(document.GetElementsByTagName("Name").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Name")[0])){ 
		 this.Name =(string)document.GetElementsByTagName("Name")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Description").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Description")[0])){ 
		 this.Description =(string)document.GetElementsByTagName("Description")[0].InnerText;

}
	}
	}
	}


	/**
	 * Details of Risk Filter.
	 */
	public partial class RiskFilterListType {

		private List<RiskFilterDetailsType> FiltersField = new List<RiskFilterDetailsType>();
		public List<RiskFilterDetailsType> Filters {
			get {
				return this.FiltersField;
			}
			set {
				this.FiltersField = value;
			}
		}

	 public RiskFilterListType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Filters").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Filters")[0])){ 
		 nodeList = document.GetElementsByTagName("Filters");
		 for(int i=0; i<nodeList.Count; i++) {
			 xmlString = DeserializationUtils.convertToXML(nodeList[i]); 
				this.Filters.Add(new RiskFilterDetailsType(xmlString));
			}

}
	}
	}
	}


	public enum SalesVenueType {
[Description("Venue-Unspecified")]VENUEUNSPECIFIED,
[Description("eBay")]EBAY,
[Description("AnotherMarketPlace")]ANOTHERMARKETPLACE,
[Description("OwnWebsite")]OWNWEBSITE,
[Description("Other")]OTHER,
	}
	/**
	 * Schedule details for the Recurring Payment
	 */
	public partial class ScheduleDetailsType {

		/**
		 * Schedule details for the Recurring Payment
		 */
		private string DescriptionField;
		public string Description {
			get {
				return this.DescriptionField;
			}
			set {
				this.DescriptionField = value;
			}
		}

		/**
		 * Trial period of this schedule
		 */
		private BillingPeriodDetailsType TrialPeriodField;
		public BillingPeriodDetailsType TrialPeriod {
			get {
				return this.TrialPeriodField;
			}
			set {
				this.TrialPeriodField = value;
			}
		}

		/**
		 */
		private BillingPeriodDetailsType PaymentPeriodField;
		public BillingPeriodDetailsType PaymentPeriod {
			get {
				return this.PaymentPeriodField;
			}
			set {
				this.PaymentPeriodField = value;
			}
		}

		/**
		 * The max number of payments the buyer can fail before this Recurring Payments profile is cancelled
		 */
		private int? MaxFailedPaymentsField;
		public int? MaxFailedPayments {
			get {
				return this.MaxFailedPaymentsField;
			}
			set {
				this.MaxFailedPaymentsField = value;
			}
		}

		/**
		 */
		private ActivationDetailsType ActivationDetailsField;
		public ActivationDetailsType ActivationDetails {
			get {
				return this.ActivationDetailsField;
			}
			set {
				this.ActivationDetailsField = value;
			}
		}

		/**
		 */
		private AutoBillType? AutoBillOutstandingAmountField;
		public AutoBillType? AutoBillOutstandingAmount {
			get {
				return this.AutoBillOutstandingAmountField;
			}
			set {
				this.AutoBillOutstandingAmountField = value;
			}
		}

		public ScheduleDetailsType(string Description, BillingPeriodDetailsType PaymentPeriod) {
			this.Description = Description;
			this.PaymentPeriod = PaymentPeriod;
		}
		public ScheduleDetailsType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( Description != null ) {
			sb.Append("<ebl:Description>").Append(Description);
			sb.Append("</ebl:Description>");
		}
		if( TrialPeriod != null ) {
			sb.Append("<ebl:TrialPeriod>");
			sb.Append(TrialPeriod.toXMLString());
			sb.Append("</ebl:TrialPeriod>");
		}
		if( PaymentPeriod != null ) {
			sb.Append("<ebl:PaymentPeriod>");
			sb.Append(PaymentPeriod.toXMLString());
			sb.Append("</ebl:PaymentPeriod>");
		}
		if( MaxFailedPayments != null ) {
			sb.Append("<ebl:MaxFailedPayments>").Append(MaxFailedPayments);
			sb.Append("</ebl:MaxFailedPayments>");
		}
		if( ActivationDetails != null ) {
			sb.Append("<ebl:ActivationDetails>");
			sb.Append(ActivationDetails.toXMLString());
			sb.Append("</ebl:ActivationDetails>");
		}
		if( AutoBillOutstandingAmount != null ) {
			sb.Append("<ebl:AutoBillOutstandingAmount>").Append(EnumUtils.getDescription(AutoBillOutstandingAmount));
			sb.Append("</ebl:AutoBillOutstandingAmount>");
		}
		return sb.ToString();
	}

	}


	/**
	 * Details about the seller.
	 */
	public partial class SellerDetailsType {

		/**
		 * Unique identifier for the seller.
		 * Optional 
		 */
		private string SellerIdField;
		public string SellerId {
			get {
				return this.SellerIdField;
			}
			set {
				this.SellerIdField = value;
			}
		}

		/**
		 * The user name of the user at the marketplaces site.
		 * Optional 
		 */
		private string SellerUserNameField;
		public string SellerUserName {
			get {
				return this.SellerUserNameField;
			}
			set {
				this.SellerUserNameField = value;
			}
		}

		/**
		 * Date when the user registered with the marketplace.
		 * Optional 
		 */
		private string SellerRegistrationDateField;
		public string SellerRegistrationDate {
			get {
				return this.SellerRegistrationDateField;
			}
			set {
				this.SellerRegistrationDateField = value;
			}
		}

		/**
		 * Seller Paypal Account Id contains the seller EmailId or PayerId or PhoneNo passed during the Request. 
		 */
		private string PayPalAccountIDField;
		public string PayPalAccountID {
			get {
				return this.PayPalAccountIDField;
			}
			set {
				this.PayPalAccountIDField = value;
			}
		}

		/**
		 * Unique PayPal customer account identification number (of the seller). This feild is meant for Response. This field is ignored, if passed in the Request.
		 */
		private string SecureMerchantAccountIDField;
		public string SecureMerchantAccountID {
			get {
				return this.SecureMerchantAccountIDField;
			}
			set {
				this.SecureMerchantAccountIDField = value;
			}
		}

		public SellerDetailsType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( SellerId != null ) {
			sb.Append("<ebl:SellerId>").Append(SellerId);
			sb.Append("</ebl:SellerId>");
		}
		if( SellerUserName != null ) {
			sb.Append("<ebl:SellerUserName>").Append(SellerUserName);
			sb.Append("</ebl:SellerUserName>");
		}
		if( SellerRegistrationDate != null ) {
			sb.Append("<ebl:SellerRegistrationDate>").Append(SellerRegistrationDate);
			sb.Append("</ebl:SellerRegistrationDate>");
		}
		if( PayPalAccountID != null ) {
			sb.Append("<ebl:PayPalAccountID>").Append(PayPalAccountID);
			sb.Append("</ebl:PayPalAccountID>");
		}
		if( SecureMerchantAccountID != null ) {
			sb.Append("<ebl:SecureMerchantAccountID>").Append(SecureMerchantAccountID);
			sb.Append("</ebl:SecureMerchantAccountID>");
		}
		return sb.ToString();
	}

	 public SellerDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("SellerId").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SellerId")[0])){ 
		 this.SellerId =(string)document.GetElementsByTagName("SellerId")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("SellerUserName").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SellerUserName")[0])){ 
		 this.SellerUserName =(string)document.GetElementsByTagName("SellerUserName")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("SellerRegistrationDate").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SellerRegistrationDate")[0])){ 
		 this.SellerRegistrationDate =(string)document.GetElementsByTagName("SellerRegistrationDate")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("PayPalAccountID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PayPalAccountID")[0])){ 
		 this.PayPalAccountID =(string)document.GetElementsByTagName("PayPalAccountID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("SecureMerchantAccountID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SecureMerchantAccountID")[0])){ 
		 this.SecureMerchantAccountID =(string)document.GetElementsByTagName("SecureMerchantAccountID")[0].InnerText;

}
	}
	}
	}


	/**
	 */
	public partial class SenderDetailsType {

		/**
		 */
		private DeviceDetailsType DeviceDetailsField;
		public DeviceDetailsType DeviceDetails {
			get {
				return this.DeviceDetailsField;
			}
			set {
				this.DeviceDetailsField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( DeviceDetails != null ) {
			sb.Append("<ebl:DeviceDetails>");
			sb.Append(DeviceDetails.toXMLString());
			sb.Append("</ebl:DeviceDetails>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class SetAccessPermissionsReq {

		private SetAccessPermissionsRequestType SetAccessPermissionsRequestField;
		public SetAccessPermissionsRequestType SetAccessPermissionsRequest {
			get {
				return this.SetAccessPermissionsRequestField;
			}
			set {
				this.SetAccessPermissionsRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:SetAccessPermissionsReq>");
		if( SetAccessPermissionsRequest != null ) {
			sb.Append("<urn:SetAccessPermissionsRequest>");
			sb.Append(SetAccessPermissionsRequest.toXMLString());
			sb.Append("</urn:SetAccessPermissionsRequest>");
		}
sb.Append("</urn:SetAccessPermissionsReq>");
		return sb.ToString();
	}

	}


	/**
	 * URL to which the customer's browser is returned after choosing to login with PayPal.
	 * Required
	 * Character length and limitations: no limit. 
	 */
	public partial class SetAccessPermissionsRequestDetailsType {

		/**
URL to which the customer's browser is returned after choosing to login with PayPal.
		 * Required
		 * Character length and limitations: no limit. 
		 */
		private string ReturnURLField;
		public string ReturnURL {
			get {
				return this.ReturnURLField;
			}
			set {
				this.ReturnURLField = value;
			}
		}

		/**
URL to which the customer is returned if he does not approve the use of PayPal login. 
		 * Required
		 * Character length and limitations: no limit
		 */
		private string CancelURLField;
		public string CancelURL {
			get {
				return this.CancelURLField;
			}
			set {
				this.CancelURLField = value;
			}
		}

		/**
URL to which the customer's browser is returned after user logs out from PayPal. 
		 * Required
		 * Character length and limitations: no limit. 
		 */
		private string LogoutURLField;
		public string LogoutURL {
			get {
				return this.LogoutURLField;
			}
			set {
				this.LogoutURLField = value;
			}
		}

		/**
The type of the flow.
		 * Optional
		 * Character length and limitations: 127 single-byte alphanumeric characters
		 */
		private string InitFlowTypeField;
		public string InitFlowType {
			get {
				return this.InitFlowTypeField;
			}
			set {
				this.InitFlowTypeField = value;
			}
		}

		/**
The used to decide SkipLogin allowed or not.
		 * Optional
		 * Character length and limitations: 127 single-byte alphanumeric characters
		 */
		private string SkipLoginPageField;
		public string SkipLoginPage {
			get {
				return this.SkipLoginPageField;
			}
			set {
				this.SkipLoginPageField = value;
			}
		}

		/**
		 * contains information about API Services
		 */
		private List<string> RequiredAccessPermissionsField = new List<string>();
		public List<string> RequiredAccessPermissions {
			get {
				return this.RequiredAccessPermissionsField;
			}
			set {
				this.RequiredAccessPermissionsField = value;
			}
		}

		/**
		 * contains information about API Services
		 */
		private List<string> OptionalAccessPermissionsField = new List<string>();
		public List<string> OptionalAccessPermissions {
			get {
				return this.OptionalAccessPermissionsField;
			}
			set {
				this.OptionalAccessPermissionsField = value;
			}
		}

		/**
		 * Locale of pages displayed by PayPal during Authentication Login.
		 * Optional
		 * Character length and limitations: Five single-byte alphabetic characters, upper- or lowercase. 
		 * Allowable values: 
		 * AU or en_AU
		 * DE or de_DE
		 * FR or fr_FR
		 * GB or en_GB
		 * IT or it_IT
		 * JP or ja_JP
		 * US or en_US
		 */
		private string LocaleCodeField;
		public string LocaleCode {
			get {
				return this.LocaleCodeField;
			}
			set {
				this.LocaleCodeField = value;
			}
		}

		/**
Sets the Custom Payment Page Style for flow pages associated with this button/link. PageStyle corresponds to the HTML variable page_style for customizing flow pages. The value is the same as the Page Style Name you chose when adding or editing the page style from the Profile subtab of the My Account tab of your PayPal account. 
		 * Optional
		 * Character length and limitations: 30 single-byte alphabetic characters.
		 */
		private string PageStyleField;
		public string PageStyle {
			get {
				return this.PageStyleField;
			}
			set {
				this.PageStyleField = value;
			}
		}

		/**
		 * A URL for the image you want to appear at the top left of the flow page. The image has a maximum size of 750 pixels wide by 90 pixels high. PayPal recommends that you provide an image that is stored on a secure (https) server. 
		 * Optional
		 * Character length and limitations: 127
		 */
		private string cppheaderimageField;
		public string cppheaderimage {
			get {
				return this.cppheaderimageField;
			}
			set {
				this.cppheaderimageField = value;
			}
		}

		/**
		 * Sets the border color around the header of the flow page. The border is a 2-pixel perimeter around the header space, which is 750 pixels wide by 90 pixels high. 
		 * Optional
		 * Character length and limitations: Six character HTML hexadecimal color code in ASCII
		 */
		private string cppheaderbordercolorField;
		public string cppheaderbordercolor {
			get {
				return this.cppheaderbordercolorField;
			}
			set {
				this.cppheaderbordercolorField = value;
			}
		}

		/**
		 * Sets the background color for the header of the flow page. 
		 * Optional
		 * Character length and limitation: Six character HTML hexadecimal color code in ASCII
		 */
		private string cppheaderbackcolorField;
		public string cppheaderbackcolor {
			get {
				return this.cppheaderbackcolorField;
			}
			set {
				this.cppheaderbackcolorField = value;
			}
		}

		/**
		 * Sets the background color for the payment page. 
		 * Optional
		 * Character length and limitation: Six character HTML hexadecimal color code in ASCII
		 */
		private string cpppayflowcolorField;
		public string cpppayflowcolor {
			get {
				return this.cpppayflowcolorField;
			}
			set {
				this.cpppayflowcolorField = value;
			}
		}

		/**
First Name of the user, this information is used if user chooses to signup with PayPal.
		 * Optional
		 * Character length and limitation: Six character HTML hexadecimal color code in ASCII
		 */
		private string FirstNameField;
		public string FirstName {
			get {
				return this.FirstNameField;
			}
			set {
				this.FirstNameField = value;
			}
		}

		/**
Last Name of the user, this information is used if user chooses to signup with PayPal.
		 * Optional
		 * Character length and limitation: Six character HTML hexadecimal color code in ASCII
		 */
		private string LastNameField;
		public string LastName {
			get {
				return this.LastNameField;
			}
			set {
				this.LastNameField = value;
			}
		}

		/**
User address, this information is used when user chooses to signup for PayPal.
		 * Optional
		 * If you include a shipping address and set the AddressOverride element on the request, PayPal returns this same address in GetExpressCheckoutDetailsResponse. 
		 */
		private AddressType AddressField;
		public AddressType Address {
			get {
				return this.AddressField;
			}
			set {
				this.AddressField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( ReturnURL != null ) {
			sb.Append("<ebl:ReturnURL>").Append(ReturnURL);
			sb.Append("</ebl:ReturnURL>");
		}
		if( CancelURL != null ) {
			sb.Append("<ebl:CancelURL>").Append(CancelURL);
			sb.Append("</ebl:CancelURL>");
		}
		if( LogoutURL != null ) {
			sb.Append("<ebl:LogoutURL>").Append(LogoutURL);
			sb.Append("</ebl:LogoutURL>");
		}
		if( InitFlowType != null ) {
			sb.Append("<ebl:InitFlowType>").Append(InitFlowType);
			sb.Append("</ebl:InitFlowType>");
		}
		if( SkipLoginPage != null ) {
			sb.Append("<ebl:SkipLoginPage>").Append(SkipLoginPage);
			sb.Append("</ebl:SkipLoginPage>");
		}
		if( RequiredAccessPermissions != null ) {
			for(int i=0; i<RequiredAccessPermissions.Count; i++) {
				sb.Append("<ebl:RequiredAccessPermissions>").Append(RequiredAccessPermissions[i]);
				sb.Append("</ebl:RequiredAccessPermissions>");
			}
		}
		if( OptionalAccessPermissions != null ) {
			for(int i=0; i<OptionalAccessPermissions.Count; i++) {
				sb.Append("<ebl:OptionalAccessPermissions>").Append(OptionalAccessPermissions[i]);
				sb.Append("</ebl:OptionalAccessPermissions>");
			}
		}
		if( LocaleCode != null ) {
			sb.Append("<ebl:LocaleCode>").Append(LocaleCode);
			sb.Append("</ebl:LocaleCode>");
		}
		if( PageStyle != null ) {
			sb.Append("<ebl:PageStyle>").Append(PageStyle);
			sb.Append("</ebl:PageStyle>");
		}
		if( cppheaderimage != null ) {
			sb.Append("<ebl:cpp-header-image>").Append(cppheaderimage);
			sb.Append("</ebl:cpp-header-image>");
		}
		if( cppheaderbordercolor != null ) {
			sb.Append("<ebl:cpp-header-border-color>").Append(cppheaderbordercolor);
			sb.Append("</ebl:cpp-header-border-color>");
		}
		if( cppheaderbackcolor != null ) {
			sb.Append("<ebl:cpp-header-back-color>").Append(cppheaderbackcolor);
			sb.Append("</ebl:cpp-header-back-color>");
		}
		if( cpppayflowcolor != null ) {
			sb.Append("<ebl:cpp-payflow-color>").Append(cpppayflowcolor);
			sb.Append("</ebl:cpp-payflow-color>");
		}
		if( FirstName != null ) {
			sb.Append("<ebl:FirstName>").Append(FirstName);
			sb.Append("</ebl:FirstName>");
		}
		if( LastName != null ) {
			sb.Append("<ebl:LastName>").Append(LastName);
			sb.Append("</ebl:LastName>");
		}
		if( Address != null ) {
			sb.Append("<ebl:Address>");
			sb.Append(Address.toXMLString());
			sb.Append("</ebl:Address>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class SetAccessPermissionsRequestType :AbstractRequestType{

		private SetAccessPermissionsRequestDetailsType SetAccessPermissionsRequestDetailsField;
		public SetAccessPermissionsRequestDetailsType SetAccessPermissionsRequestDetails {
			get {
				return this.SetAccessPermissionsRequestDetailsField;
			}
			set {
				this.SetAccessPermissionsRequestDetailsField = value;
			}
		}

		public SetAccessPermissionsRequestType(SetAccessPermissionsRequestDetailsType SetAccessPermissionsRequestDetails) {
			this.SetAccessPermissionsRequestDetails = SetAccessPermissionsRequestDetails;
		}
		public SetAccessPermissionsRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( SetAccessPermissionsRequestDetails != null ) {
			sb.Append("<ebl:SetAccessPermissionsRequestDetails>");
			sb.Append(SetAccessPermissionsRequestDetails.toXMLString());
			sb.Append("</ebl:SetAccessPermissionsRequestDetails>");
		}
		return sb.ToString();
	}

	}


	/**
A timestamped token by which you identify to PayPal that you are processing this user. The token expires after three hours.
	 * Character length and limitations: 20 single-byte characters
	 */
	public partial class SetAccessPermissionsResponseType :AbstractResponseType{

		/**
A timestamped token by which you identify to PayPal that you are processing this user. The token expires after three hours.
		 * Character length and limitations: 20 single-byte characters
		 */
		private string TokenField;
		public string Token {
			get {
				return this.TokenField;
			}
			set {
				this.TokenField = value;
			}
		}

	 public SetAccessPermissionsResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Token").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Token")[0])){ 
		 this.Token =(string)document.GetElementsByTagName("Token")[0].InnerText;

}
	}
	}
	}


	/**
	 */
	public partial class SetAuthFlowParamReq {

		private SetAuthFlowParamRequestType SetAuthFlowParamRequestField;
		public SetAuthFlowParamRequestType SetAuthFlowParamRequest {
			get {
				return this.SetAuthFlowParamRequestField;
			}
			set {
				this.SetAuthFlowParamRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:SetAuthFlowParamReq>");
		if( SetAuthFlowParamRequest != null ) {
			sb.Append("<urn:SetAuthFlowParamRequest>");
			sb.Append(SetAuthFlowParamRequest.toXMLString());
			sb.Append("</urn:SetAuthFlowParamRequest>");
		}
sb.Append("</urn:SetAuthFlowParamReq>");
		return sb.ToString();
	}

	}


	/**
	 * URL to which the customer's browser is returned after choosing to login with PayPal.
	 * Required
	 * Character length and limitations: no limit. 
	 */
	public partial class SetAuthFlowParamRequestDetailsType {

		/**
URL to which the customer's browser is returned after choosing to login with PayPal.
		 * Required
		 * Character length and limitations: no limit. 		 */
		private string ReturnURLField;
		public string ReturnURL {
			get {
				return this.ReturnURLField;
			}
			set {
				this.ReturnURLField = value;
			}
		}

		/**
URL to which the customer is returned if he does not approve the use of PayPal login. 
		 * Required
		 * Character length and limitations: no limit
		 */
		private string CancelURLField;
		public string CancelURL {
			get {
				return this.CancelURLField;
			}
			set {
				this.CancelURLField = value;
			}
		}

		/**
URL to which the customer's browser is returned after user logs out from PayPal. 
		 * Required
		 * Character length and limitations: no limit. 		 */
		private string LogoutURLField;
		public string LogoutURL {
			get {
				return this.LogoutURLField;
			}
			set {
				this.LogoutURLField = value;
			}
		}

		/**
The type of the flow.
		 * Optional
		 * Character length and limitations: 127 single-byte alphanumeric characters
		 */
		private string InitFlowTypeField;
		public string InitFlowType {
			get {
				return this.InitFlowTypeField;
			}
			set {
				this.InitFlowTypeField = value;
			}
		}

		/**
The used to decide SkipLogin allowed or not.
		 * Optional
		 * Character length and limitations: 127 single-byte alphanumeric characters
		 */
		private string SkipLoginPageField;
		public string SkipLoginPage {
			get {
				return this.SkipLoginPageField;
			}
			set {
				this.SkipLoginPageField = value;
			}
		}

		/**
The name of the field Merchant requires from PayPal after user's login.
		 * Optional
		 * Character length and limitations: 256 single-byte alphanumeric characters
		 */
		private string ServiceName1Field;
		public string ServiceName1 {
			get {
				return this.ServiceName1Field;
			}
			set {
				this.ServiceName1Field = value;
			}
		}

		/**
Whether the field is required, opt-in or opt-out.
		 * Optional
		 * Character length and limitations: 127 single-byte alphanumeric characters
		 */
		private string ServiceDefReq1Field;
		public string ServiceDefReq1 {
			get {
				return this.ServiceDefReq1Field;
			}
			set {
				this.ServiceDefReq1Field = value;
			}
		}

		/**
The name of the field Merchant requires from PayPal after user's login.
		 * Optional
		 * Character length and limitations: 256 single-byte alphanumeric characters
		 */
		private string ServiceName2Field;
		public string ServiceName2 {
			get {
				return this.ServiceName2Field;
			}
			set {
				this.ServiceName2Field = value;
			}
		}

		/**
Whether the field is required, opt-in or opt-out.
		 * Optional
		 * Character length and limitations: 127 single-byte alphanumeric characters
		 */
		private string ServiceDefReq2Field;
		public string ServiceDefReq2 {
			get {
				return this.ServiceDefReq2Field;
			}
			set {
				this.ServiceDefReq2Field = value;
			}
		}

		/**
		 * Locale of pages displayed by PayPal during Authentication Login.
		 * Optional
		 * Character length and limitations: Five single-byte alphabetic characters, upper- or lowercase. 
		 * Allowable values: 
		 * AU or en_AU
		 * DE or de_DE
		 * FR or fr_FR
		 * GB or en_GB
		 * IT or it_IT
		 * JP or ja_JP
		 * US or en_US
		 */
		private string LocaleCodeField;
		public string LocaleCode {
			get {
				return this.LocaleCodeField;
			}
			set {
				this.LocaleCodeField = value;
			}
		}

		/**
Sets the Custom Payment Page Style for flow pages associated with this button/link. PageStyle corresponds to the HTML variable page_style for customizing flow pages. The value is the same as the Page Style Name you chose when adding or editing the page style from the Profile subtab of the My Account tab of your PayPal account. 
		 * Optional
		 * Character length and limitations: 30 single-byte alphabetic characters.
		 */
		private string PageStyleField;
		public string PageStyle {
			get {
				return this.PageStyleField;
			}
			set {
				this.PageStyleField = value;
			}
		}

		/**
		 * A URL for the image you want to appear at the top left of the flow page. The image has a maximum size of 750 pixels wide by 90 pixels high. PayPal recommends that you provide an image that is stored on a secure (https) server. 
		 * Optional
		 * Character length and limitations: 127
		 */
		private string cppheaderimageField;
		public string cppheaderimage {
			get {
				return this.cppheaderimageField;
			}
			set {
				this.cppheaderimageField = value;
			}
		}

		/**
		 * Sets the border color around the header of the flow page. The border is a 2-pixel perimeter around the header space, which is 750 pixels wide by 90 pixels high. 
		 * Optional
		 * Character length and limitations: Six character HTML hexadecimal color code in ASCII
		 */
		private string cppheaderbordercolorField;
		public string cppheaderbordercolor {
			get {
				return this.cppheaderbordercolorField;
			}
			set {
				this.cppheaderbordercolorField = value;
			}
		}

		/**
		 * Sets the background color for the header of the flow page. 
		 * Optional
		 * Character length and limitation: Six character HTML hexadecimal color code in ASCII
		 */
		private string cppheaderbackcolorField;
		public string cppheaderbackcolor {
			get {
				return this.cppheaderbackcolorField;
			}
			set {
				this.cppheaderbackcolorField = value;
			}
		}

		/**
		 * Sets the background color for the payment page. 
		 * Optional
		 * Character length and limitation: Six character HTML hexadecimal color code in ASCII
		 */
		private string cpppayflowcolorField;
		public string cpppayflowcolor {
			get {
				return this.cpppayflowcolorField;
			}
			set {
				this.cpppayflowcolorField = value;
			}
		}

		/**
First Name of the user, this information is used if user chooses to signup with PayPal.
		 * Optional
		 * Character length and limitation: Six character HTML hexadecimal color code in ASCII
		 */
		private string FirstNameField;
		public string FirstName {
			get {
				return this.FirstNameField;
			}
			set {
				this.FirstNameField = value;
			}
		}

		/**
Last Name of the user, this information is used if user chooses to signup with PayPal.
		 * Optional
		 * Character length and limitation: Six character HTML hexadecimal color code in ASCII
		 */
		private string LastNameField;
		public string LastName {
			get {
				return this.LastNameField;
			}
			set {
				this.LastNameField = value;
			}
		}

		/**
User address, this information is used when user chooses to signup for PayPal.
		 * Optional
		 * If you include a shipping address and set the AddressOverride element on the request, PayPal returns this same address in GetExpressCheckoutDetailsResponse. 
		 */
		private AddressType AddressField;
		public AddressType Address {
			get {
				return this.AddressField;
			}
			set {
				this.AddressField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( ReturnURL != null ) {
			sb.Append("<ebl:ReturnURL>").Append(ReturnURL);
			sb.Append("</ebl:ReturnURL>");
		}
		if( CancelURL != null ) {
			sb.Append("<ebl:CancelURL>").Append(CancelURL);
			sb.Append("</ebl:CancelURL>");
		}
		if( LogoutURL != null ) {
			sb.Append("<ebl:LogoutURL>").Append(LogoutURL);
			sb.Append("</ebl:LogoutURL>");
		}
		if( InitFlowType != null ) {
			sb.Append("<ebl:InitFlowType>").Append(InitFlowType);
			sb.Append("</ebl:InitFlowType>");
		}
		if( SkipLoginPage != null ) {
			sb.Append("<ebl:SkipLoginPage>").Append(SkipLoginPage);
			sb.Append("</ebl:SkipLoginPage>");
		}
		if( ServiceName1 != null ) {
			sb.Append("<ebl:ServiceName1>").Append(ServiceName1);
			sb.Append("</ebl:ServiceName1>");
		}
		if( ServiceDefReq1 != null ) {
			sb.Append("<ebl:ServiceDefReq1>").Append(ServiceDefReq1);
			sb.Append("</ebl:ServiceDefReq1>");
		}
		if( ServiceName2 != null ) {
			sb.Append("<ebl:ServiceName2>").Append(ServiceName2);
			sb.Append("</ebl:ServiceName2>");
		}
		if( ServiceDefReq2 != null ) {
			sb.Append("<ebl:ServiceDefReq2>").Append(ServiceDefReq2);
			sb.Append("</ebl:ServiceDefReq2>");
		}
		if( LocaleCode != null ) {
			sb.Append("<ebl:LocaleCode>").Append(LocaleCode);
			sb.Append("</ebl:LocaleCode>");
		}
		if( PageStyle != null ) {
			sb.Append("<ebl:PageStyle>").Append(PageStyle);
			sb.Append("</ebl:PageStyle>");
		}
		if( cppheaderimage != null ) {
			sb.Append("<ebl:cpp-header-image>").Append(cppheaderimage);
			sb.Append("</ebl:cpp-header-image>");
		}
		if( cppheaderbordercolor != null ) {
			sb.Append("<ebl:cpp-header-border-color>").Append(cppheaderbordercolor);
			sb.Append("</ebl:cpp-header-border-color>");
		}
		if( cppheaderbackcolor != null ) {
			sb.Append("<ebl:cpp-header-back-color>").Append(cppheaderbackcolor);
			sb.Append("</ebl:cpp-header-back-color>");
		}
		if( cpppayflowcolor != null ) {
			sb.Append("<ebl:cpp-payflow-color>").Append(cpppayflowcolor);
			sb.Append("</ebl:cpp-payflow-color>");
		}
		if( FirstName != null ) {
			sb.Append("<ebl:FirstName>").Append(FirstName);
			sb.Append("</ebl:FirstName>");
		}
		if( LastName != null ) {
			sb.Append("<ebl:LastName>").Append(LastName);
			sb.Append("</ebl:LastName>");
		}
		if( Address != null ) {
			sb.Append("<ebl:Address>");
			sb.Append(Address.toXMLString());
			sb.Append("</ebl:Address>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class SetAuthFlowParamRequestType :AbstractRequestType{

		private SetAuthFlowParamRequestDetailsType SetAuthFlowParamRequestDetailsField;
		public SetAuthFlowParamRequestDetailsType SetAuthFlowParamRequestDetails {
			get {
				return this.SetAuthFlowParamRequestDetailsField;
			}
			set {
				this.SetAuthFlowParamRequestDetailsField = value;
			}
		}

		public SetAuthFlowParamRequestType(SetAuthFlowParamRequestDetailsType SetAuthFlowParamRequestDetails) {
			this.SetAuthFlowParamRequestDetails = SetAuthFlowParamRequestDetails;
		}
		public SetAuthFlowParamRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( SetAuthFlowParamRequestDetails != null ) {
			sb.Append("<ebl:SetAuthFlowParamRequestDetails>");
			sb.Append(SetAuthFlowParamRequestDetails.toXMLString());
			sb.Append("</ebl:SetAuthFlowParamRequestDetails>");
		}
		return sb.ToString();
	}

	}


	/**
A timestamped token by which you identify to PayPal that you are processing this user. The token expires after three hours.
	 * Character length and limitations: 20 single-byte characters
	 */
	public partial class SetAuthFlowParamResponseType :AbstractResponseType{

		/**
A timestamped token by which you identify to PayPal that you are processing this user. The token expires after three hours.
		 * Character length and limitations: 20 single-byte characters
		 */
		private string TokenField;
		public string Token {
			get {
				return this.TokenField;
			}
			set {
				this.TokenField = value;
			}
		}

	 public SetAuthFlowParamResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Token").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Token")[0])){ 
		 this.Token =(string)document.GetElementsByTagName("Token")[0].InnerText;

}
	}
	}
	}


	/**
	 */
	public partial class SetCustomerBillingAgreementReq {

		private SetCustomerBillingAgreementRequestType SetCustomerBillingAgreementRequestField;
		public SetCustomerBillingAgreementRequestType SetCustomerBillingAgreementRequest {
			get {
				return this.SetCustomerBillingAgreementRequestField;
			}
			set {
				this.SetCustomerBillingAgreementRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:SetCustomerBillingAgreementReq>");
		if( SetCustomerBillingAgreementRequest != null ) {
			sb.Append("<urn:SetCustomerBillingAgreementRequest>");
			sb.Append(SetCustomerBillingAgreementRequest.toXMLString());
			sb.Append("</urn:SetCustomerBillingAgreementRequest>");
		}
sb.Append("</urn:SetCustomerBillingAgreementReq>");
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class SetCustomerBillingAgreementRequestDetailsType {

		/**
		 */
		private BillingAgreementDetailsType BillingAgreementDetailsField;
		public BillingAgreementDetailsType BillingAgreementDetails {
			get {
				return this.BillingAgreementDetailsField;
			}
			set {
				this.BillingAgreementDetailsField = value;
			}
		}

		/**
		 */
		private string ReturnURLField;
		public string ReturnURL {
			get {
				return this.ReturnURLField;
			}
			set {
				this.ReturnURLField = value;
			}
		}

		/**
		 */
		private string CancelURLField;
		public string CancelURL {
			get {
				return this.CancelURLField;
			}
			set {
				this.CancelURLField = value;
			}
		}

		/**
		 */
		private string LocaleCodeField;
		public string LocaleCode {
			get {
				return this.LocaleCodeField;
			}
			set {
				this.LocaleCodeField = value;
			}
		}

		/**
		 */
		private string PageStyleField;
		public string PageStyle {
			get {
				return this.PageStyleField;
			}
			set {
				this.PageStyleField = value;
			}
		}

		/**
		 */
		private string cppheaderimageField;
		public string cppheaderimage {
			get {
				return this.cppheaderimageField;
			}
			set {
				this.cppheaderimageField = value;
			}
		}

		/**
		 */
		private string cppheaderbordercolorField;
		public string cppheaderbordercolor {
			get {
				return this.cppheaderbordercolorField;
			}
			set {
				this.cppheaderbordercolorField = value;
			}
		}

		/**
		 */
		private string cppheaderbackcolorField;
		public string cppheaderbackcolor {
			get {
				return this.cppheaderbackcolorField;
			}
			set {
				this.cppheaderbackcolorField = value;
			}
		}

		/**
		 */
		private string cpppayflowcolorField;
		public string cpppayflowcolor {
			get {
				return this.cpppayflowcolorField;
			}
			set {
				this.cpppayflowcolorField = value;
			}
		}

		/**
		 */
		private string BuyerEmailField;
		public string BuyerEmail {
			get {
				return this.BuyerEmailField;
			}
			set {
				this.BuyerEmailField = value;
			}
		}

		/**
The value 1 indicates that you require that the customer's billing address on file. Setting this element overrides the setting you have specified in Admin.
		 * Optional
		 * Character length and limitations: One single-byte numeric character.
		 */
		private string ReqBillingAddressField;
		public string ReqBillingAddress {
			get {
				return this.ReqBillingAddressField;
			}
			set {
				this.ReqBillingAddressField = value;
			}
		}

		public SetCustomerBillingAgreementRequestDetailsType(BillingAgreementDetailsType BillingAgreementDetails, string ReturnURL, string CancelURL) {
			this.BillingAgreementDetails = BillingAgreementDetails;
			this.ReturnURL = ReturnURL;
			this.CancelURL = CancelURL;
		}
		public SetCustomerBillingAgreementRequestDetailsType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( BillingAgreementDetails != null ) {
			sb.Append("<ebl:BillingAgreementDetails>");
			sb.Append(BillingAgreementDetails.toXMLString());
			sb.Append("</ebl:BillingAgreementDetails>");
		}
		if( ReturnURL != null ) {
			sb.Append("<ebl:ReturnURL>").Append(ReturnURL);
			sb.Append("</ebl:ReturnURL>");
		}
		if( CancelURL != null ) {
			sb.Append("<ebl:CancelURL>").Append(CancelURL);
			sb.Append("</ebl:CancelURL>");
		}
		if( LocaleCode != null ) {
			sb.Append("<ebl:LocaleCode>").Append(LocaleCode);
			sb.Append("</ebl:LocaleCode>");
		}
		if( PageStyle != null ) {
			sb.Append("<ebl:PageStyle>").Append(PageStyle);
			sb.Append("</ebl:PageStyle>");
		}
		if( cppheaderimage != null ) {
			sb.Append("<ebl:cpp-header-image>").Append(cppheaderimage);
			sb.Append("</ebl:cpp-header-image>");
		}
		if( cppheaderbordercolor != null ) {
			sb.Append("<ebl:cpp-header-border-color>").Append(cppheaderbordercolor);
			sb.Append("</ebl:cpp-header-border-color>");
		}
		if( cppheaderbackcolor != null ) {
			sb.Append("<ebl:cpp-header-back-color>").Append(cppheaderbackcolor);
			sb.Append("</ebl:cpp-header-back-color>");
		}
		if( cpppayflowcolor != null ) {
			sb.Append("<ebl:cpp-payflow-color>").Append(cpppayflowcolor);
			sb.Append("</ebl:cpp-payflow-color>");
		}
		if( BuyerEmail != null ) {
			sb.Append("<ebl:BuyerEmail>").Append(BuyerEmail);
			sb.Append("</ebl:BuyerEmail>");
		}
		if( ReqBillingAddress != null ) {
			sb.Append("<ebl:ReqBillingAddress>").Append(ReqBillingAddress);
			sb.Append("</ebl:ReqBillingAddress>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class SetCustomerBillingAgreementRequestType :AbstractRequestType{

		private SetCustomerBillingAgreementRequestDetailsType SetCustomerBillingAgreementRequestDetailsField;
		public SetCustomerBillingAgreementRequestDetailsType SetCustomerBillingAgreementRequestDetails {
			get {
				return this.SetCustomerBillingAgreementRequestDetailsField;
			}
			set {
				this.SetCustomerBillingAgreementRequestDetailsField = value;
			}
		}

		public SetCustomerBillingAgreementRequestType(SetCustomerBillingAgreementRequestDetailsType SetCustomerBillingAgreementRequestDetails) {
			this.SetCustomerBillingAgreementRequestDetails = SetCustomerBillingAgreementRequestDetails;
		}
		public SetCustomerBillingAgreementRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( SetCustomerBillingAgreementRequestDetails != null ) {
			sb.Append("<ebl:SetCustomerBillingAgreementRequestDetails>");
			sb.Append(SetCustomerBillingAgreementRequestDetails.toXMLString());
			sb.Append("</ebl:SetCustomerBillingAgreementRequestDetails>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class SetCustomerBillingAgreementResponseType :AbstractResponseType{

		/**
		 */
		private string TokenField;
		public string Token {
			get {
				return this.TokenField;
			}
			set {
				this.TokenField = value;
			}
		}

	 public SetCustomerBillingAgreementResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Token").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Token")[0])){ 
		 this.Token =(string)document.GetElementsByTagName("Token")[0].InnerText;

}
	}
	}
	}


	/**
	 * Details about Billing Agreements requested to be created.
	 */
	public partial class SetDataRequestType {

		/**
		 * Details about Billing Agreements requested to be created.
		 */
		private List<BillingApprovalDetailsType> BillingApprovalDetailsField = new List<BillingApprovalDetailsType>();
		public List<BillingApprovalDetailsType> BillingApprovalDetails {
			get {
				return this.BillingApprovalDetailsField;
			}
			set {
				this.BillingApprovalDetailsField = value;
			}
		}

		/**
		 * Only needed if Auto Authorization is requested. The authentication session token will be passed in here.
		 */
		private BuyerDetailType BuyerDetailField;
		public BuyerDetailType BuyerDetail {
			get {
				return this.BuyerDetailField;
			}
			set {
				this.BuyerDetailField = value;
			}
		}

		/**
		 * Requests for specific buyer information like Billing Address to be returned through GetExpressCheckoutDetails should be specified under this.
		 */
		private InfoSharingDirectivesType InfoSharingDirectivesField;
		public InfoSharingDirectivesType InfoSharingDirectives {
			get {
				return this.InfoSharingDirectivesField;
			}
			set {
				this.InfoSharingDirectivesField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( BillingApprovalDetails != null ) {
			for(int i=0; i<BillingApprovalDetails.Count; i++) {
				sb.Append("<ebl:BillingApprovalDetails>");
				sb.Append(BillingApprovalDetails[i].toXMLString());
				sb.Append("</ebl:BillingApprovalDetails>");
			}
		}
		if( BuyerDetail != null ) {
			sb.Append("<ebl:BuyerDetail>");
			sb.Append(BuyerDetail.toXMLString());
			sb.Append("</ebl:BuyerDetail>");
		}
		if( InfoSharingDirectives != null ) {
			sb.Append("<ebl:InfoSharingDirectives>");
			sb.Append(InfoSharingDirectives.toXMLString());
			sb.Append("</ebl:InfoSharingDirectives>");
		}
		return sb.ToString();
	}

	}


	/**
	 * If Checkout session was initialized successfully, the corresponding token is returned in this element.
	 */
	public partial class SetDataResponseType {

		/**
		 * If Checkout session was initialized successfully, the corresponding token is returned in this element.
		 */
		private string TokenField;
		public string Token {
			get {
				return this.TokenField;
			}
			set {
				this.TokenField = value;
			}
		}

		private List<ErrorType> SetDataErrorField = new List<ErrorType>();
		public List<ErrorType> SetDataError {
			get {
				return this.SetDataErrorField;
			}
			set {
				this.SetDataErrorField = value;
			}
		}

	 public SetDataResponseType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Token").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Token")[0])){ 
		 this.Token =(string)document.GetElementsByTagName("Token")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("SetDataError").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SetDataError")[0])){ 
		 nodeList = document.GetElementsByTagName("SetDataError");
		 for(int i=0; i<nodeList.Count; i++) {
			 xmlString = DeserializationUtils.convertToXML(nodeList[i]); 
				this.SetDataError.Add(new ErrorType(xmlString));
			}

}
	}
	}
	}


	/**
	 */
	public partial class SetExpressCheckoutReq {

		private SetExpressCheckoutRequestType SetExpressCheckoutRequestField;
		public SetExpressCheckoutRequestType SetExpressCheckoutRequest {
			get {
				return this.SetExpressCheckoutRequestField;
			}
			set {
				this.SetExpressCheckoutRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:SetExpressCheckoutReq>");
		if( SetExpressCheckoutRequest != null ) {
			sb.Append("<urn:SetExpressCheckoutRequest>");
			sb.Append(SetExpressCheckoutRequest.toXMLString());
			sb.Append("</urn:SetExpressCheckoutRequest>");
		}
sb.Append("</urn:SetExpressCheckoutReq>");
		return sb.ToString();
	}

	}


	/**
	 * The total cost of the order to the customer. If shipping cost and tax charges are known, include them in OrderTotal; if not, OrderTotal should be the current sub-total of the order. 
	 * You must set the currencyID attribute to one of the three-character currency codes for any of the supported PayPal currencies. 
	 * Limitations: Must not exceed $10,000 USD in any currency. No currency symbol. Decimal separator must be a period (.), and the thousands separator must be a comma (,).
	 */
	public partial class SetExpressCheckoutRequestDetailsType {

		/**
The total cost of the order to the customer. If shipping cost and tax charges are known, include them in OrderTotal; if not, OrderTotal should be the current sub-total of the order. 
		 * You must set the currencyID attribute to one of the three-character currency codes for any of the supported PayPal currencies. 
		 * Limitations: Must not exceed $10,000 USD in any currency. No currency symbol. Decimal separator must be a period (.), and the thousands separator must be a comma (,).
		 */
		private BasicAmountType OrderTotalField;
		public BasicAmountType OrderTotal {
			get {
				return this.OrderTotalField;
			}
			set {
				this.OrderTotalField = value;
			}
		}

		/**
URL to which the customer's browser is returned after choosing to pay with PayPal. PayPal recommends that the value of ReturnURL be the final review page on which the customer confirms the order and payment. 
		 * Required
		 * Character length and limitations: no limit. 		 */
		private string ReturnURLField;
		public string ReturnURL {
			get {
				return this.ReturnURLField;
			}
			set {
				this.ReturnURLField = value;
			}
		}

		/**
URL to which the customer is returned if he does not approve the use of PayPal to pay you. PayPal recommends that the value of CancelURL be the original page on which the customer chose to pay with PayPal. 
		 * Required
		 * Character length and limitations: no limit
		 */
		private string CancelURLField;
		public string CancelURL {
			get {
				return this.CancelURLField;
			}
			set {
				this.CancelURLField = value;
			}
		}

		/**
Tracking URL for ebay. 
		 * Required
		 * Character length and limitations: no limit
		 */
		private string TrackingImageURLField;
		public string TrackingImageURL {
			get {
				return this.TrackingImageURLField;
			}
			set {
				this.TrackingImageURLField = value;
			}
		}

		/**
URL to which the customer's browser is returned after paying with giropay online. 
		 * Optional
		 * Character length and limitations: no limit.
		 */
		private string giropaySuccessURLField;
		public string giropaySuccessURL {
			get {
				return this.giropaySuccessURLField;
			}
			set {
				this.giropaySuccessURLField = value;
			}
		}

		/**
URL to which the customer's browser is returned after fail to pay with giropay online. 
		 * Optional
		 * Character length and limitations: no limit.
		 */
		private string giropayCancelURLField;
		public string giropayCancelURL {
			get {
				return this.giropayCancelURLField;
			}
			set {
				this.giropayCancelURLField = value;
			}
		}

		/**
URL to which the customer's browser can be returned in the mEFT done page. 
		 * Optional
		 * Character length and limitations: no limit.
		 */
		private string BanktxnPendingURLField;
		public string BanktxnPendingURL {
			get {
				return this.BanktxnPendingURLField;
			}
			set {
				this.BanktxnPendingURLField = value;
			}
		}

		/**
On your first invocation of SetExpressCheckoutRequest, the value of this token is returned by SetExpressCheckoutResponse. 
		 * Optional
		 * Include this element and its value only if you want to modify an existing checkout session with another invocation of SetExpressCheckoutRequest; for example, if you want the customer to edit his shipping address on PayPal. 
		 * Character length and limitations: 20 single-byte characters
		 */
		private string TokenField;
		public string Token {
			get {
				return this.TokenField;
			}
			set {
				this.TokenField = value;
			}
		}

		/**
The expected maximum total amount of the complete order, including shipping cost and tax charges. 
		 * Optional
		 * You must set the currencyID attribute to one of the three-character currency codes for any of the supported PayPal currencies. 
		 * Limitations: Must not exceed $10,000 USD in any currency. No currency symbol. Decimal separator must be a period (.), and the thousands separator must be a comma (,).
		 */
		private BasicAmountType MaxAmountField;
		public BasicAmountType MaxAmount {
			get {
				return this.MaxAmountField;
			}
			set {
				this.MaxAmountField = value;
			}
		}

		/**
Description of items the customer is purchasing. 
		 * Optional
		 * Character length and limitations: 127 single-byte alphanumeric characters
		 */
		private string OrderDescriptionField;
		public string OrderDescription {
			get {
				return this.OrderDescriptionField;
			}
			set {
				this.OrderDescriptionField = value;
			}
		}

		/**
A free-form field for your own use, such as a tracking number or other value you want PayPal to return on GetExpressCheckoutDetailsResponse and DoExpressCheckoutPaymentResponse. 
		 * Optional
		 * Character length and limitations: 256 single-byte alphanumeric characters
		 */
		private string CustomField;
		public string Custom {
			get {
				return this.CustomField;
			}
			set {
				this.CustomField = value;
			}
		}

		/**
Your own unique invoice or tracking number. PayPal returns this value to you on DoExpressCheckoutPaymentResponse. 
		 * Optional
		 * Character length and limitations: 127 single-byte alphanumeric characters
		 */
		private string InvoiceIDField;
		public string InvoiceID {
			get {
				return this.InvoiceIDField;
			}
			set {
				this.InvoiceIDField = value;
			}
		}

		/**
The value 1 indicates that you require that the customer's shipping address on file with PayPal be a confirmed address. Any value other than 1 indicates that the customer's shipping address on file with PayPal need NOT be a confirmed address. Setting this element overrides the setting you have specified in the recipient's Merchant Account Profile. 
		 * Optional
		 * Character length and limitations: One single-byte numeric character.
		 */
		private string ReqConfirmShippingField;
		public string ReqConfirmShipping {
			get {
				return this.ReqConfirmShippingField;
			}
			set {
				this.ReqConfirmShippingField = value;
			}
		}

		/**
The value 1 indicates that you require that the customer's billing address on file. Setting this element overrides the setting you have specified in Admin.
		 * Optional
		 * Character length and limitations: One single-byte numeric character.
		 */
		private string ReqBillingAddressField;
		public string ReqBillingAddress {
			get {
				return this.ReqBillingAddressField;
			}
			set {
				this.ReqBillingAddressField = value;
			}
		}

		/**
		 * The billing address for the buyer.
		 * Optional
		 * If you include the BillingAddress element, the AddressType elements are required:
		 * Name
		 * Street1
		 * CityName
		 * CountryCode
		 * Do not set set the CountryName element.
		 */
		private AddressType BillingAddressField;
		public AddressType BillingAddress {
			get {
				return this.BillingAddressField;
			}
			set {
				this.BillingAddressField = value;
			}
		}

		/**
The value 1 indicates that on the PayPal pages, no shipping address fields should be displayed whatsoever. 
		 * Optional
		 * Character length and limitations: Four single-byte numeric characters.
		 */
		private string NoShippingField;
		public string NoShipping {
			get {
				return this.NoShippingField;
			}
			set {
				this.NoShippingField = value;
			}
		}

		/**
The value 1 indicates that the PayPal pages should display the shipping address set by you in the Address element on this SetExpressCheckoutRequest, not the shipping address on file with PayPal for this customer. Displaying the PayPal street address on file does not allow the customer to edit that address. 
		 * Optional
		 * Character length and limitations: Four single-byte numeric characters.
		 */
		private string AddressOverrideField;
		public string AddressOverride {
			get {
				return this.AddressOverrideField;
			}
			set {
				this.AddressOverrideField = value;
			}
		}

		/**
		 * Locale of pages displayed by PayPal during Express Checkout. 
		 * Optional
		 * Character length and limitations: Five single-byte alphabetic characters, upper- or lowercase. 
		 * Allowable values: 
		 * AU or en_AU
		 * DE or de_DE
		 * FR or fr_FR
		 * GB or en_GB
		 * IT or it_IT
		 * JP or ja_JP
		 * US or en_US
		 */
		private string LocaleCodeField;
		public string LocaleCode {
			get {
				return this.LocaleCodeField;
			}
			set {
				this.LocaleCodeField = value;
			}
		}

		/**
Sets the Custom Payment Page Style for payment pages associated with this button/link. PageStyle corresponds to the HTML variable page_style for customizing payment pages. The value is the same as the Page Style Name you chose when adding or editing the page style from the Profile subtab of the My Account tab of your PayPal account. 
		 * Optional
		 * Character length and limitations: 30 single-byte alphabetic characters.
		 */
		private string PageStyleField;
		public string PageStyle {
			get {
				return this.PageStyleField;
			}
			set {
				this.PageStyleField = value;
			}
		}

		/**
		 * A URL for the image you want to appear at the top left of the payment page. The image has a maximum size of 750 pixels wide by 90 pixels high. PayPal recommends that you provide an image that is stored on a secure (https) server. 
		 * Optional
		 * Character length and limitations: 127
		 */
		private string cppheaderimageField;
		public string cppheaderimage {
			get {
				return this.cppheaderimageField;
			}
			set {
				this.cppheaderimageField = value;
			}
		}

		/**
		 * Sets the border color around the header of the payment page. The border is a 2-pixel perimeter around the header space, which is 750 pixels wide by 90 pixels high. 
		 * Optional
		 * Character length and limitations: Six character HTML hexadecimal color code in ASCII
		 */
		private string cppheaderbordercolorField;
		public string cppheaderbordercolor {
			get {
				return this.cppheaderbordercolorField;
			}
			set {
				this.cppheaderbordercolorField = value;
			}
		}

		/**
		 * Sets the background color for the header of the payment page. 
		 * Optional
		 * Character length and limitation: Six character HTML hexadecimal color code in ASCII
		 */
		private string cppheaderbackcolorField;
		public string cppheaderbackcolor {
			get {
				return this.cppheaderbackcolorField;
			}
			set {
				this.cppheaderbackcolorField = value;
			}
		}

		/**
		 * Sets the background color for the payment page. 
		 * Optional
		 * Character length and limitation: Six character HTML hexadecimal color code in ASCII
		 */
		private string cpppayflowcolorField;
		public string cpppayflowcolor {
			get {
				return this.cpppayflowcolorField;
			}
			set {
				this.cpppayflowcolorField = value;
			}
		}

		/**
		 * Sets the cart gradient color for the Mini Cart on 1X flow. 
		 * Optional
		 * Character length and limitation: Six character HTML hexadecimal color code in ASCII
		 */
		private string cppcartbordercolorField;
		public string cppcartbordercolor {
			get {
				return this.cppcartbordercolorField;
			}
			set {
				this.cppcartbordercolorField = value;
			}
		}

		/**
		 * A URL for the image you want to appear above the mini-cart. The image has a maximum size of 190 pixels wide by 60 pixels high. PayPal recommends that you provide an image that is stored on a secure (https) server. 
		 * Optional
		 * Character length and limitations: 127
		 */
		private string cpplogoimageField;
		public string cpplogoimage {
			get {
				return this.cpplogoimageField;
			}
			set {
				this.cpplogoimageField = value;
			}
		}

		/**
Customer's shipping address. 
		 * Optional
		 * If you include a shipping address and set the AddressOverride element on the request, PayPal returns this same address in GetExpressCheckoutDetailsResponse. 
		 */
		private AddressType AddressField;
		public AddressType Address {
			get {
				return this.AddressField;
			}
			set {
				this.AddressField = value;
			}
		}

		/**
		 * How you want to obtain payment. 
		 * Required
		 * Authorization indicates that this payment is a basic authorization subject to settlement with PayPal Authorization and Capture.
		 * Order indicates that this payment is is an order authorization subject to settlement with PayPal Authorization and Capture.
		 * Sale indicates that this is a final sale for which you are requesting payment.
		 * IMPORTANT: You cannot set PaymentAction to Sale or Order on SetExpressCheckoutRequest and then change PaymentAction to Authorization on the final Express Checkout API, DoExpressCheckoutPaymentRequest.
		 * Character length and limit: Up to 13 single-byte alphabetic characters
		 */
		private PaymentActionCodeType? PaymentActionField;
		public PaymentActionCodeType? PaymentAction {
			get {
				return this.PaymentActionField;
			}
			set {
				this.PaymentActionField = value;
			}
		}

		/**
		 * This will indicate which flow you are choosing (expresschecheckout or expresscheckout optional)
		 * Optional
		 * None
		 * Sole indicates that you are in the ExpressO flow
		 * Mark indicates that you are in the old express flow.
		 */
		private SolutionTypeType? SolutionTypeField;
		public SolutionTypeType? SolutionType {
			get {
				return this.SolutionTypeField;
			}
			set {
				this.SolutionTypeField = value;
			}
		}

		/**
		 * This indicates Which page to display for ExpressO (Billing or Login) 
		 * Optional
		 * None
		 * Billing indicates that you are not a paypal account holder
		 * Login indicates that you are a paypal account holder
		 */
		private LandingPageType? LandingPageField;
		public LandingPageType? LandingPage {
			get {
				return this.LandingPageField;
			}
			set {
				this.LandingPageField = value;
			}
		}

		/**
		 * Email address of the buyer as entered during checkout. PayPal uses this value to pre-fill the PayPal membership sign-up portion of the PayPal login page. 
		 * Optional
		 * Character length and limit: 127 single-byte alphanumeric characters 
		 */
		private string BuyerEmailField;
		public string BuyerEmail {
			get {
				return this.BuyerEmailField;
			}
			set {
				this.BuyerEmailField = value;
			}
		}

		private ChannelType? ChannelTypeField;
		public ChannelType? ChannelType {
			get {
				return this.ChannelTypeField;
			}
			set {
				this.ChannelTypeField = value;
			}
		}

		private List<BillingAgreementDetailsType> BillingAgreementDetailsField = new List<BillingAgreementDetailsType>();
		public List<BillingAgreementDetailsType> BillingAgreementDetails {
			get {
				return this.BillingAgreementDetailsField;
			}
			set {
				this.BillingAgreementDetailsField = value;
			}
		}

		/**
		 * Promo Code
		 * Optional
		 * List of promo codes supplied by merchant. These promo codes enable the Merchant Services Promotion Financing feature.
		 */
		private List<string> PromoCodesField = new List<string>();
		public List<string> PromoCodes {
			get {
				return this.PromoCodesField;
			}
			set {
				this.PromoCodesField = value;
			}
		}

		/**
		 * Default Funding option for PayLater Checkout button.
		 */
		private string PayPalCheckOutBtnTypeField;
		public string PayPalCheckOutBtnType {
			get {
				return this.PayPalCheckOutBtnTypeField;
			}
			set {
				this.PayPalCheckOutBtnTypeField = value;
			}
		}

		/**
		 */
		private ProductCategoryType? ProductCategoryField;
		public ProductCategoryType? ProductCategory {
			get {
				return this.ProductCategoryField;
			}
			set {
				this.ProductCategoryField = value;
			}
		}

		/**
		 */
		private ShippingServiceCodeType? ShippingMethodField;
		public ShippingServiceCodeType? ShippingMethod {
			get {
				return this.ShippingMethodField;
			}
			set {
				this.ShippingMethodField = value;
			}
		}

		/**
		 * Date and time (in GMT in the format yyyy-MM-ddTHH:mm:ssZ) at which address was changed by the user. 
		 */
		private string ProfileAddressChangeDateField;
		public string ProfileAddressChangeDate {
			get {
				return this.ProfileAddressChangeDateField;
			}
			set {
				this.ProfileAddressChangeDateField = value;
			}
		}

		/**
		 * The value 1 indicates that the customer may enter a note to the merchant on the PayPal page during checkout. The note is returned in the GetExpressCheckoutDetails response and the DoExpressCheckoutPayment response.
		 * Optional
		 * Character length and limitations: One single-byte numeric character.
		 * Allowable values: 0,1 
		 */
		private string AllowNoteField;
		public string AllowNote {
			get {
				return this.AllowNoteField;
			}
			set {
				this.AllowNoteField = value;
			}
		}

		/**
		 * Funding source preferences. 
		 */
		private FundingSourceDetailsType FundingSourceDetailsField;
		public FundingSourceDetailsType FundingSourceDetails {
			get {
				return this.FundingSourceDetailsField;
			}
			set {
				this.FundingSourceDetailsField = value;
			}
		}

		/**
		 * The label that needs to be displayed on the cancel links in the PayPal hosted checkout pages.  
		 * Optional  
		 * Character length and limit: 127 single-byte alphanumeric characters 
		 */
		private string BrandNameField;
		public string BrandName {
			get {
				return this.BrandNameField;
			}
			set {
				this.BrandNameField = value;
			}
		}

		/**
		 * URL for PayPal to use to retrieve shipping, handling, insurance, and tax details from your website.
		 * Optional
		 * Character length and limitations: 2048 characters.
		 */
		private string CallbackURLField;
		public string CallbackURL {
			get {
				return this.CallbackURLField;
			}
			set {
				this.CallbackURLField = value;
			}
		}

		/**
		 * Enhanced data for different industry segments. 
		 * Optional
		 */
		private EnhancedCheckoutDataType EnhancedCheckoutDataField;
		public EnhancedCheckoutDataType EnhancedCheckoutData {
			get {
				return this.EnhancedCheckoutDataField;
			}
			set {
				this.EnhancedCheckoutDataField = value;
			}
		}

		/**
		 * List of other payment methods the user can pay with.
		 * Optional
		 * Refer to the OtherPaymentMethodDetailsType for more details.
		 */
		private List<OtherPaymentMethodDetailsType> OtherPaymentMethodsField = new List<OtherPaymentMethodDetailsType>();
		public List<OtherPaymentMethodDetailsType> OtherPaymentMethods {
			get {
				return this.OtherPaymentMethodsField;
			}
			set {
				this.OtherPaymentMethodsField = value;
			}
		}

		/**
		 * Details about the buyer's account. 
		 * Optional
		 * Refer to the BuyerDetailsType for more details. 
		 */
		private BuyerDetailsType BuyerDetailsField;
		public BuyerDetailsType BuyerDetails {
			get {
				return this.BuyerDetailsField;
			}
			set {
				this.BuyerDetailsField = value;
			}
		}

		/**
		 * Information about the payment.
		 */
		private List<PaymentDetailsType> PaymentDetailsField = new List<PaymentDetailsType>();
		public List<PaymentDetailsType> PaymentDetails {
			get {
				return this.PaymentDetailsField;
			}
			set {
				this.PaymentDetailsField = value;
			}
		}

		/**
		 * List of Fall Back Shipping options provided by merchant.
		 */
		private List<ShippingOptionType> FlatRateShippingOptionsField = new List<ShippingOptionType>();
		public List<ShippingOptionType> FlatRateShippingOptions {
			get {
				return this.FlatRateShippingOptionsField;
			}
			set {
				this.FlatRateShippingOptionsField = value;
			}
		}

		/**
		 * Information about the call back timeout override.
		 */
		private string CallbackTimeoutField;
		public string CallbackTimeout {
			get {
				return this.CallbackTimeoutField;
			}
			set {
				this.CallbackTimeoutField = value;
			}
		}

		/**
		 * Information about the call back version.
		 */
		private string CallbackVersionField;
		public string CallbackVersion {
			get {
				return this.CallbackVersionField;
			}
			set {
				this.CallbackVersionField = value;
			}
		}

		/**
		 * Information about the Customer service number.
		 */
		private string CustomerServiceNumberField;
		public string CustomerServiceNumber {
			get {
				return this.CustomerServiceNumberField;
			}
			set {
				this.CustomerServiceNumberField = value;
			}
		}

		/**
		 * Information about the Gift message enable.
		 */
		private string GiftMessageEnableField;
		public string GiftMessageEnable {
			get {
				return this.GiftMessageEnableField;
			}
			set {
				this.GiftMessageEnableField = value;
			}
		}

		/**
		 * Information about the Gift receipt enable.
		 */
		private string GiftReceiptEnableField;
		public string GiftReceiptEnable {
			get {
				return this.GiftReceiptEnableField;
			}
			set {
				this.GiftReceiptEnableField = value;
			}
		}

		/**
		 * Information about the Gift Wrap enable.
		 */
		private string GiftWrapEnableField;
		public string GiftWrapEnable {
			get {
				return this.GiftWrapEnableField;
			}
			set {
				this.GiftWrapEnableField = value;
			}
		}

		/**
		 * Information about the Gift Wrap name.
		 */
		private string GiftWrapNameField;
		public string GiftWrapName {
			get {
				return this.GiftWrapNameField;
			}
			set {
				this.GiftWrapNameField = value;
			}
		}

		/**
		 * Information about the Gift Wrap amount.
		 */
		private BasicAmountType GiftWrapAmountField;
		public BasicAmountType GiftWrapAmount {
			get {
				return this.GiftWrapAmountField;
			}
			set {
				this.GiftWrapAmountField = value;
			}
		}

		/**
		 * Information about the Buyer email option enable .
		 */
		private string BuyerEmailOptInEnableField;
		public string BuyerEmailOptInEnable {
			get {
				return this.BuyerEmailOptInEnableField;
			}
			set {
				this.BuyerEmailOptInEnableField = value;
			}
		}

		/**
		 * Information about the survey enable.
		 */
		private string SurveyEnableField;
		public string SurveyEnable {
			get {
				return this.SurveyEnableField;
			}
			set {
				this.SurveyEnableField = value;
			}
		}

		/**
		 * Information about the survey question.
		 */
		private string SurveyQuestionField;
		public string SurveyQuestion {
			get {
				return this.SurveyQuestionField;
			}
			set {
				this.SurveyQuestionField = value;
			}
		}

		/**
		 * Information about the survey choices for survey question.
		 */
		private List<string> SurveyChoiceField = new List<string>();
		public List<string> SurveyChoice {
			get {
				return this.SurveyChoiceField;
			}
			set {
				this.SurveyChoiceField = value;
			}
		}

		private TotalType? TotalTypeField;
		public TotalType? TotalType {
			get {
				return this.TotalTypeField;
			}
			set {
				this.TotalTypeField = value;
			}
		}

		/**
		 * Any message the seller would like to be displayed in the Mini Cart for UX.
		 */
		private string NoteToBuyerField;
		public string NoteToBuyer {
			get {
				return this.NoteToBuyerField;
			}
			set {
				this.NoteToBuyerField = value;
			}
		}

		/**
		 * Incentive Code
		 * Optional
		 * List of incentive codes supplied by ebay/merchant.
		 */
		private List<IncentiveInfoType> IncentivesField = new List<IncentiveInfoType>();
		public List<IncentiveInfoType> Incentives {
			get {
				return this.IncentivesField;
			}
			set {
				this.IncentivesField = value;
			}
		}

		/**
		 * Merchant specified flag which indicates whether to return Funding Instrument Details in DoEC or not.
		 * Optional
		 */
		private string ReqInstrumentDetailsField;
		public string ReqInstrumentDetails {
			get {
				return this.ReqInstrumentDetailsField;
			}
			set {
				this.ReqInstrumentDetailsField = value;
			}
		}

		/**
		 * This element contains information that allows the merchant to request to
		 * opt into external remember me on behalf of the buyer or to request login
		 * bypass using external remember me.  Note the opt-in details are silently
		 * ignored if the ExternalRememberMeID is present.
		 */
		private ExternalRememberMeOptInDetailsType ExternalRememberMeOptInDetailsField;
		public ExternalRememberMeOptInDetailsType ExternalRememberMeOptInDetails {
			get {
				return this.ExternalRememberMeOptInDetailsField;
			}
			set {
				this.ExternalRememberMeOptInDetailsField = value;
			}
		}

		/**
		 * An optional set of values related to flow-specific details.
		 */
		private FlowControlDetailsType FlowControlDetailsField;
		public FlowControlDetailsType FlowControlDetails {
			get {
				return this.FlowControlDetailsField;
			}
			set {
				this.FlowControlDetailsField = value;
			}
		}

		/**
		 * An optional set of values related to display-specific details.
		 */
		private DisplayControlDetailsType DisplayControlDetailsField;
		public DisplayControlDetailsType DisplayControlDetails {
			get {
				return this.DisplayControlDetailsField;
			}
			set {
				this.DisplayControlDetailsField = value;
			}
		}

		/**
		 * An optional set of values related to tracking for external partner.
		 */
		private ExternalPartnerTrackingDetailsType ExternalPartnerTrackingDetailsField;
		public ExternalPartnerTrackingDetailsType ExternalPartnerTrackingDetails {
			get {
				return this.ExternalPartnerTrackingDetailsField;
			}
			set {
				this.ExternalPartnerTrackingDetailsField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( OrderTotal != null ) {
			sb.Append("<ebl:OrderTotal ");
			sb.Append(OrderTotal.toXMLString());
			sb.Append("</ebl:OrderTotal>");
		}
		if( ReturnURL != null ) {
			sb.Append("<ebl:ReturnURL>").Append(ReturnURL);
			sb.Append("</ebl:ReturnURL>");
		}
		if( CancelURL != null ) {
			sb.Append("<ebl:CancelURL>").Append(CancelURL);
			sb.Append("</ebl:CancelURL>");
		}
		if( TrackingImageURL != null ) {
			sb.Append("<ebl:TrackingImageURL>").Append(TrackingImageURL);
			sb.Append("</ebl:TrackingImageURL>");
		}
		if( giropaySuccessURL != null ) {
			sb.Append("<ebl:giropaySuccessURL>").Append(giropaySuccessURL);
			sb.Append("</ebl:giropaySuccessURL>");
		}
		if( giropayCancelURL != null ) {
			sb.Append("<ebl:giropayCancelURL>").Append(giropayCancelURL);
			sb.Append("</ebl:giropayCancelURL>");
		}
		if( BanktxnPendingURL != null ) {
			sb.Append("<ebl:BanktxnPendingURL>").Append(BanktxnPendingURL);
			sb.Append("</ebl:BanktxnPendingURL>");
		}
		if( Token != null ) {
			sb.Append("<ebl:Token>").Append(Token);
			sb.Append("</ebl:Token>");
		}
		if( MaxAmount != null ) {
			sb.Append("<ebl:MaxAmount ");
			sb.Append(MaxAmount.toXMLString());
			sb.Append("</ebl:MaxAmount>");
		}
		if( OrderDescription != null ) {
			sb.Append("<ebl:OrderDescription>").Append(OrderDescription);
			sb.Append("</ebl:OrderDescription>");
		}
		if( Custom != null ) {
			sb.Append("<ebl:Custom>").Append(Custom);
			sb.Append("</ebl:Custom>");
		}
		if( InvoiceID != null ) {
			sb.Append("<ebl:InvoiceID>").Append(InvoiceID);
			sb.Append("</ebl:InvoiceID>");
		}
		if( ReqConfirmShipping != null ) {
			sb.Append("<ebl:ReqConfirmShipping>").Append(ReqConfirmShipping);
			sb.Append("</ebl:ReqConfirmShipping>");
		}
		if( ReqBillingAddress != null ) {
			sb.Append("<ebl:ReqBillingAddress>").Append(ReqBillingAddress);
			sb.Append("</ebl:ReqBillingAddress>");
		}
		if( BillingAddress != null ) {
			sb.Append("<ebl:BillingAddress>");
			sb.Append(BillingAddress.toXMLString());
			sb.Append("</ebl:BillingAddress>");
		}
		if( NoShipping != null ) {
			sb.Append("<ebl:NoShipping>").Append(NoShipping);
			sb.Append("</ebl:NoShipping>");
		}
		if( AddressOverride != null ) {
			sb.Append("<ebl:AddressOverride>").Append(AddressOverride);
			sb.Append("</ebl:AddressOverride>");
		}
		if( LocaleCode != null ) {
			sb.Append("<ebl:LocaleCode>").Append(LocaleCode);
			sb.Append("</ebl:LocaleCode>");
		}
		if( PageStyle != null ) {
			sb.Append("<ebl:PageStyle>").Append(PageStyle);
			sb.Append("</ebl:PageStyle>");
		}
		if( cppheaderimage != null ) {
			sb.Append("<ebl:cpp-header-image>").Append(cppheaderimage);
			sb.Append("</ebl:cpp-header-image>");
		}
		if( cppheaderbordercolor != null ) {
			sb.Append("<ebl:cpp-header-border-color>").Append(cppheaderbordercolor);
			sb.Append("</ebl:cpp-header-border-color>");
		}
		if( cppheaderbackcolor != null ) {
			sb.Append("<ebl:cpp-header-back-color>").Append(cppheaderbackcolor);
			sb.Append("</ebl:cpp-header-back-color>");
		}
		if( cpppayflowcolor != null ) {
			sb.Append("<ebl:cpp-payflow-color>").Append(cpppayflowcolor);
			sb.Append("</ebl:cpp-payflow-color>");
		}
		if( cppcartbordercolor != null ) {
			sb.Append("<ebl:cpp-cart-border-color>").Append(cppcartbordercolor);
			sb.Append("</ebl:cpp-cart-border-color>");
		}
		if( cpplogoimage != null ) {
			sb.Append("<ebl:cpp-logo-image>").Append(cpplogoimage);
			sb.Append("</ebl:cpp-logo-image>");
		}
		if( Address != null ) {
			sb.Append("<ebl:Address>");
			sb.Append(Address.toXMLString());
			sb.Append("</ebl:Address>");
		}
		if( PaymentAction != null ) {
			sb.Append("<ebl:PaymentAction>").Append(EnumUtils.getDescription(PaymentAction));
			sb.Append("</ebl:PaymentAction>");
		}
		if( SolutionType != null ) {
			sb.Append("<ebl:SolutionType>").Append(EnumUtils.getDescription(SolutionType));
			sb.Append("</ebl:SolutionType>");
		}
		if( LandingPage != null ) {
			sb.Append("<ebl:LandingPage>").Append(EnumUtils.getDescription(LandingPage));
			sb.Append("</ebl:LandingPage>");
		}
		if( BuyerEmail != null ) {
			sb.Append("<ebl:BuyerEmail>").Append(BuyerEmail);
			sb.Append("</ebl:BuyerEmail>");
		}
		if( ChannelType != null ) {
			sb.Append("<ebl:ChannelType>").Append(EnumUtils.getDescription(ChannelType));
			sb.Append("</ebl:ChannelType>");
		}
		if( BillingAgreementDetails != null ) {
			for(int i=0; i<BillingAgreementDetails.Count; i++) {
				sb.Append("<ebl:BillingAgreementDetails>");
				sb.Append(BillingAgreementDetails[i].toXMLString());
				sb.Append("</ebl:BillingAgreementDetails>");
			}
		}
		if( PromoCodes != null ) {
			for(int i=0; i<PromoCodes.Count; i++) {
				sb.Append("<ebl:PromoCodes>").Append(PromoCodes[i]);
				sb.Append("</ebl:PromoCodes>");
			}
		}
		if( PayPalCheckOutBtnType != null ) {
			sb.Append("<ebl:PayPalCheckOutBtnType>").Append(PayPalCheckOutBtnType);
			sb.Append("</ebl:PayPalCheckOutBtnType>");
		}
		if( ProductCategory != null ) {
			sb.Append("<ebl:ProductCategory>").Append(EnumUtils.getDescription(ProductCategory));
			sb.Append("</ebl:ProductCategory>");
		}
		if( ShippingMethod != null ) {
			sb.Append("<ebl:ShippingMethod>").Append(EnumUtils.getDescription(ShippingMethod));
			sb.Append("</ebl:ShippingMethod>");
		}
		if( ProfileAddressChangeDate != null ) {
			sb.Append("<ebl:ProfileAddressChangeDate>").Append(ProfileAddressChangeDate);
			sb.Append("</ebl:ProfileAddressChangeDate>");
		}
		if( AllowNote != null ) {
			sb.Append("<ebl:AllowNote>").Append(AllowNote);
			sb.Append("</ebl:AllowNote>");
		}
		if( FundingSourceDetails != null ) {
			sb.Append("<ebl:FundingSourceDetails>");
			sb.Append(FundingSourceDetails.toXMLString());
			sb.Append("</ebl:FundingSourceDetails>");
		}
		if( BrandName != null ) {
			sb.Append("<ebl:BrandName>").Append(BrandName);
			sb.Append("</ebl:BrandName>");
		}
		if( CallbackURL != null ) {
			sb.Append("<ebl:CallbackURL>").Append(CallbackURL);
			sb.Append("</ebl:CallbackURL>");
		}
		if( EnhancedCheckoutData != null ) {
			sb.Append("<ebl:EnhancedCheckoutData>");
			sb.Append(EnhancedCheckoutData.toXMLString());
			sb.Append("</ebl:EnhancedCheckoutData>");
		}
		if( OtherPaymentMethods != null ) {
			for(int i=0; i<OtherPaymentMethods.Count; i++) {
				sb.Append("<ebl:OtherPaymentMethods>");
				sb.Append(OtherPaymentMethods[i].toXMLString());
				sb.Append("</ebl:OtherPaymentMethods>");
			}
		}
		if( BuyerDetails != null ) {
			sb.Append("<ebl:BuyerDetails>");
			sb.Append(BuyerDetails.toXMLString());
			sb.Append("</ebl:BuyerDetails>");
		}
		if( PaymentDetails != null ) {
			for(int i=0; i<PaymentDetails.Count; i++) {
				sb.Append("<ebl:PaymentDetails>");
				sb.Append(PaymentDetails[i].toXMLString());
				sb.Append("</ebl:PaymentDetails>");
			}
		}
		if( FlatRateShippingOptions != null ) {
			for(int i=0; i<FlatRateShippingOptions.Count; i++) {
				sb.Append("<ebl:FlatRateShippingOptions>");
				sb.Append(FlatRateShippingOptions[i].toXMLString());
				sb.Append("</ebl:FlatRateShippingOptions>");
			}
		}
		if( CallbackTimeout != null ) {
			sb.Append("<ebl:CallbackTimeout>").Append(CallbackTimeout);
			sb.Append("</ebl:CallbackTimeout>");
		}
		if( CallbackVersion != null ) {
			sb.Append("<ebl:CallbackVersion>").Append(CallbackVersion);
			sb.Append("</ebl:CallbackVersion>");
		}
		if( CustomerServiceNumber != null ) {
			sb.Append("<ebl:CustomerServiceNumber>").Append(CustomerServiceNumber);
			sb.Append("</ebl:CustomerServiceNumber>");
		}
		if( GiftMessageEnable != null ) {
			sb.Append("<ebl:GiftMessageEnable>").Append(GiftMessageEnable);
			sb.Append("</ebl:GiftMessageEnable>");
		}
		if( GiftReceiptEnable != null ) {
			sb.Append("<ebl:GiftReceiptEnable>").Append(GiftReceiptEnable);
			sb.Append("</ebl:GiftReceiptEnable>");
		}
		if( GiftWrapEnable != null ) {
			sb.Append("<ebl:GiftWrapEnable>").Append(GiftWrapEnable);
			sb.Append("</ebl:GiftWrapEnable>");
		}
		if( GiftWrapName != null ) {
			sb.Append("<ebl:GiftWrapName>").Append(GiftWrapName);
			sb.Append("</ebl:GiftWrapName>");
		}
		if( GiftWrapAmount != null ) {
			sb.Append("<ebl:GiftWrapAmount ");
			sb.Append(GiftWrapAmount.toXMLString());
			sb.Append("</ebl:GiftWrapAmount>");
		}
		if( BuyerEmailOptInEnable != null ) {
			sb.Append("<ebl:BuyerEmailOptInEnable>").Append(BuyerEmailOptInEnable);
			sb.Append("</ebl:BuyerEmailOptInEnable>");
		}
		if( SurveyEnable != null ) {
			sb.Append("<ebl:SurveyEnable>").Append(SurveyEnable);
			sb.Append("</ebl:SurveyEnable>");
		}
		if( SurveyQuestion != null ) {
			sb.Append("<ebl:SurveyQuestion>").Append(SurveyQuestion);
			sb.Append("</ebl:SurveyQuestion>");
		}
		if( SurveyChoice != null ) {
			for(int i=0; i<SurveyChoice.Count; i++) {
				sb.Append("<ebl:SurveyChoice>").Append(SurveyChoice[i]);
				sb.Append("</ebl:SurveyChoice>");
			}
		}
		if( TotalType != null ) {
			sb.Append("<ebl:TotalType>").Append(EnumUtils.getDescription(TotalType));
			sb.Append("</ebl:TotalType>");
		}
		if( NoteToBuyer != null ) {
			sb.Append("<ebl:NoteToBuyer>").Append(NoteToBuyer);
			sb.Append("</ebl:NoteToBuyer>");
		}
		if( Incentives != null ) {
			for(int i=0; i<Incentives.Count; i++) {
				sb.Append("<ebl:Incentives>");
				sb.Append(Incentives[i].toXMLString());
				sb.Append("</ebl:Incentives>");
			}
		}
		if( ReqInstrumentDetails != null ) {
			sb.Append("<ebl:ReqInstrumentDetails>").Append(ReqInstrumentDetails);
			sb.Append("</ebl:ReqInstrumentDetails>");
		}
		if( ExternalRememberMeOptInDetails != null ) {
			sb.Append("<ebl:ExternalRememberMeOptInDetails>");
			sb.Append(ExternalRememberMeOptInDetails.toXMLString());
			sb.Append("</ebl:ExternalRememberMeOptInDetails>");
		}
		if( FlowControlDetails != null ) {
			sb.Append("<ebl:FlowControlDetails>");
			sb.Append(FlowControlDetails.toXMLString());
			sb.Append("</ebl:FlowControlDetails>");
		}
		if( DisplayControlDetails != null ) {
			sb.Append("<ebl:DisplayControlDetails>");
			sb.Append(DisplayControlDetails.toXMLString());
			sb.Append("</ebl:DisplayControlDetails>");
		}
		if( ExternalPartnerTrackingDetails != null ) {
			sb.Append("<ebl:ExternalPartnerTrackingDetails>");
			sb.Append(ExternalPartnerTrackingDetails.toXMLString());
			sb.Append("</ebl:ExternalPartnerTrackingDetails>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class SetExpressCheckoutRequestType :AbstractRequestType{

		private SetExpressCheckoutRequestDetailsType SetExpressCheckoutRequestDetailsField;
		public SetExpressCheckoutRequestDetailsType SetExpressCheckoutRequestDetails {
			get {
				return this.SetExpressCheckoutRequestDetailsField;
			}
			set {
				this.SetExpressCheckoutRequestDetailsField = value;
			}
		}

		public SetExpressCheckoutRequestType(SetExpressCheckoutRequestDetailsType SetExpressCheckoutRequestDetails) {
			this.SetExpressCheckoutRequestDetails = SetExpressCheckoutRequestDetails;
		}
		public SetExpressCheckoutRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( SetExpressCheckoutRequestDetails != null ) {
			sb.Append("<ebl:SetExpressCheckoutRequestDetails>");
			sb.Append(SetExpressCheckoutRequestDetails.toXMLString());
			sb.Append("</ebl:SetExpressCheckoutRequestDetails>");
		}
		return sb.ToString();
	}

	}


	/**
A timestamped token by which you identify to PayPal that you are processing this payment with Express Checkout. The token expires after three hours. If you set Token in the SetExpressCheckoutRequest, the value of Token in the response is identical to the value in the request. 
	 * Character length and limitations: 20 single-byte characters
	 */
	public partial class SetExpressCheckoutResponseType :AbstractResponseType{

		/**
A timestamped token by which you identify to PayPal that you are processing this payment with Express Checkout. The token expires after three hours. If you set Token in the SetExpressCheckoutRequest, the value of Token in the response is identical to the value in the request. 
		 * Character length and limitations: 20 single-byte characters
		 */
		private string TokenField;
		public string Token {
			get {
				return this.TokenField;
			}
			set {
				this.TokenField = value;
			}
		}

	 public SetExpressCheckoutResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Token").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Token")[0])){ 
		 this.Token =(string)document.GetElementsByTagName("Token")[0].InnerText;

}
	}
	}
	}


	/**
	 */
	public partial class SetMobileCheckoutReq {

		private SetMobileCheckoutRequestType SetMobileCheckoutRequestField;
		public SetMobileCheckoutRequestType SetMobileCheckoutRequest {
			get {
				return this.SetMobileCheckoutRequestField;
			}
			set {
				this.SetMobileCheckoutRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:SetMobileCheckoutReq>");
		if( SetMobileCheckoutRequest != null ) {
			sb.Append("<urn:SetMobileCheckoutRequest>");
			sb.Append(SetMobileCheckoutRequest.toXMLString());
			sb.Append("</urn:SetMobileCheckoutRequest>");
		}
sb.Append("</urn:SetMobileCheckoutReq>");
		return sb.ToString();
	}

	}


	/**
	 * The phone number of the buyer's mobile device, if available.
	 * Optional
	 */
	public partial class SetMobileCheckoutRequestDetailsType {

		/**
The phone number of the buyer's mobile device, if available.
		 * Optional
		 */
		private PhoneNumberType BuyerPhoneField;
		public PhoneNumberType BuyerPhone {
			get {
				return this.BuyerPhoneField;
			}
			set {
				this.BuyerPhoneField = value;
			}
		}

		/**
		 * Cost of this item before tax and shipping.
You must set the currencyID attribute to one of the three-character currency codes for any of the supported PayPal currencies.
		 * Required
		 */
		private BasicAmountType ItemAmountField;
		public BasicAmountType ItemAmount {
			get {
				return this.ItemAmountField;
			}
			set {
				this.ItemAmountField = value;
			}
		}

		/**
		 * Tax amount for this item.
You must set the currencyID attribute to one of the three-character currency codes for any of the supported PayPal currencies.
		 * Optional
		 */
		private BasicAmountType TaxField;
		public BasicAmountType Tax {
			get {
				return this.TaxField;
			}
			set {
				this.TaxField = value;
			}
		}

		/**
		 * Shipping amount for this item.
You must set the currencyID attribute to one of the three-character currency codes for any of the supported PayPal currencies.
		 * Optional
		 */
		private BasicAmountType ShippingField;
		public BasicAmountType Shipping {
			get {
				return this.ShippingField;
			}
			set {
				this.ShippingField = value;
			}
		}

		/**
Description of the item that the customer is purchasing. 
		 * Required
		 * Character length and limitations: 127 single-byte alphanumeric characters
		 */
		private string ItemNameField;
		public string ItemName {
			get {
				return this.ItemNameField;
			}
			set {
				this.ItemNameField = value;
			}
		}

		/**
Reference number of the item that the customer is purchasing. 
		 * Optional
		 * Character length and limitations: 127 single-byte alphanumeric characters
		 */
		private string ItemNumberField;
		public string ItemNumber {
			get {
				return this.ItemNumberField;
			}
			set {
				this.ItemNumberField = value;
			}
		}

		/**
A free-form field for your own use, such as a tracking number or other value you want returned to you in IPN.
		 * Optional
		 * Character length and limitations: 256 single-byte alphanumeric characters
		 */
		private string CustomField;
		public string Custom {
			get {
				return this.CustomField;
			}
			set {
				this.CustomField = value;
			}
		}

		/**
Your own unique invoice or tracking number.
		 * Optional
		 * Character length and limitations: 127 single-byte alphanumeric characters
		 */
		private string InvoiceIDField;
		public string InvoiceID {
			get {
				return this.InvoiceIDField;
			}
			set {
				this.InvoiceIDField = value;
			}
		}

		/**
URL to which the customer's browser is returned after choosing to pay with PayPal. PayPal recommends that the value of ReturnURL be the final review page on which the customer confirms the order and payment. 
		 * Required
		 * Character length and limitations: no limit. 		 */
		private string ReturnURLField;
		public string ReturnURL {
			get {
				return this.ReturnURLField;
			}
			set {
				this.ReturnURLField = value;
			}
		}

		/**
URL to which the customer is returned if he does not approve the use of PayPal to pay you. PayPal recommends that the value of CancelURL be the original page on which the customer chose to pay with PayPal. 
		 * Optional
		 * Character length and limitations: no limit
		 */
		private string CancelURLField;
		public string CancelURL {
			get {
				return this.CancelURLField;
			}
			set {
				this.CancelURLField = value;
			}
		}

		/**
The value 1 indicates that you require that the customer's shipping address on file with PayPal be a confirmed address. Setting this element overrides the setting you have specified in your Merchant Account Profile. 
		 * Optional
		 */
		private int? AddressDisplayOptionsField;
		public int? AddressDisplayOptions {
			get {
				return this.AddressDisplayOptionsField;
			}
			set {
				this.AddressDisplayOptionsField = value;
			}
		}

		/**
The value 1 indicates that you require that the customer specifies a contact phone for the transactxion.  Default is 0 / none required.
		 * Optional
		 */
		private int? SharePhoneField;
		public int? SharePhone {
			get {
				return this.SharePhoneField;
			}
			set {
				this.SharePhoneField = value;
			}
		}

		/**
Customer's shipping address. 
		 * Optional
		 */
		private AddressType ShipToAddressField;
		public AddressType ShipToAddress {
			get {
				return this.ShipToAddressField;
			}
			set {
				this.ShipToAddressField = value;
			}
		}

		/**
		 * Email address of the buyer as entered during checkout. PayPal uses this value to pre-fill the login portion of the PayPal login page. 
		 * Optional
		 * Character length and limit: 127 single-byte alphanumeric characters 
		 */
		private string BuyerEmailField;
		public string BuyerEmail {
			get {
				return this.BuyerEmailField;
			}
			set {
				this.BuyerEmailField = value;
			}
		}

		public SetMobileCheckoutRequestDetailsType(BasicAmountType ItemAmount, string ItemName, string ReturnURL) {
			this.ItemAmount = ItemAmount;
			this.ItemName = ItemName;
			this.ReturnURL = ReturnURL;
		}
		public SetMobileCheckoutRequestDetailsType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( BuyerPhone != null ) {
			sb.Append("<ebl:BuyerPhone>");
			sb.Append(BuyerPhone.toXMLString());
			sb.Append("</ebl:BuyerPhone>");
		}
		if( ItemAmount != null ) {
			sb.Append("<ebl:ItemAmount ");
			sb.Append(ItemAmount.toXMLString());
			sb.Append("</ebl:ItemAmount>");
		}
		if( Tax != null ) {
			sb.Append("<ebl:Tax ");
			sb.Append(Tax.toXMLString());
			sb.Append("</ebl:Tax>");
		}
		if( Shipping != null ) {
			sb.Append("<ebl:Shipping ");
			sb.Append(Shipping.toXMLString());
			sb.Append("</ebl:Shipping>");
		}
		if( ItemName != null ) {
			sb.Append("<ebl:ItemName>").Append(ItemName);
			sb.Append("</ebl:ItemName>");
		}
		if( ItemNumber != null ) {
			sb.Append("<ebl:ItemNumber>").Append(ItemNumber);
			sb.Append("</ebl:ItemNumber>");
		}
		if( Custom != null ) {
			sb.Append("<ebl:Custom>").Append(Custom);
			sb.Append("</ebl:Custom>");
		}
		if( InvoiceID != null ) {
			sb.Append("<ebl:InvoiceID>").Append(InvoiceID);
			sb.Append("</ebl:InvoiceID>");
		}
		if( ReturnURL != null ) {
			sb.Append("<ebl:ReturnURL>").Append(ReturnURL);
			sb.Append("</ebl:ReturnURL>");
		}
		if( CancelURL != null ) {
			sb.Append("<ebl:CancelURL>").Append(CancelURL);
			sb.Append("</ebl:CancelURL>");
		}
		if( AddressDisplayOptions != null ) {
			sb.Append("<ebl:AddressDisplayOptions>").Append(AddressDisplayOptions);
			sb.Append("</ebl:AddressDisplayOptions>");
		}
		if( SharePhone != null ) {
			sb.Append("<ebl:SharePhone>").Append(SharePhone);
			sb.Append("</ebl:SharePhone>");
		}
		if( ShipToAddress != null ) {
			sb.Append("<ebl:ShipToAddress>");
			sb.Append(ShipToAddress.toXMLString());
			sb.Append("</ebl:ShipToAddress>");
		}
		if( BuyerEmail != null ) {
			sb.Append("<ebl:BuyerEmail>").Append(BuyerEmail);
			sb.Append("</ebl:BuyerEmail>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class SetMobileCheckoutRequestType :AbstractRequestType{

		private SetMobileCheckoutRequestDetailsType SetMobileCheckoutRequestDetailsField;
		public SetMobileCheckoutRequestDetailsType SetMobileCheckoutRequestDetails {
			get {
				return this.SetMobileCheckoutRequestDetailsField;
			}
			set {
				this.SetMobileCheckoutRequestDetailsField = value;
			}
		}

		public SetMobileCheckoutRequestType(SetMobileCheckoutRequestDetailsType SetMobileCheckoutRequestDetails) {
			this.SetMobileCheckoutRequestDetails = SetMobileCheckoutRequestDetails;
		}
		public SetMobileCheckoutRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( SetMobileCheckoutRequestDetails != null ) {
			sb.Append("<ebl:SetMobileCheckoutRequestDetails>");
			sb.Append(SetMobileCheckoutRequestDetails.toXMLString());
			sb.Append("</ebl:SetMobileCheckoutRequestDetails>");
		}
		return sb.ToString();
	}

	}


	/**
A timestamped token by which you identify to PayPal that you are processing this payment with Mobile Checkout. The token expires after three hours.
	 * Character length and limitations: 20 single-byte characters
	 */
	public partial class SetMobileCheckoutResponseType :AbstractResponseType{

		/**
A timestamped token by which you identify to PayPal that you are processing this payment with Mobile Checkout. The token expires after three hours.
		 * Character length and limitations: 20 single-byte characters
		 */
		private string TokenField;
		public string Token {
			get {
				return this.TokenField;
			}
			set {
				this.TokenField = value;
			}
		}

	 public SetMobileCheckoutResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Token").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Token")[0])){ 
		 nodeList = document.GetElementsByTagName("Token");
			 string value = nodeList[0].InnerText; 
		 this.Token =value;

}
	}
	}
	}


	public enum SeverityCodeType {
[Description("Warning")]WARNING,
[Description("Error")]ERROR,
[Description("PartialSuccess")]PARTIALSUCCESS,
[Description("CustomCode")]CUSTOMCODE,
	}
	/**
	 * Fallback shipping options type.
	 */
	public partial class ShippingOptionType {

		private string ShippingOptionIsDefaultField;
		public string ShippingOptionIsDefault {
			get {
				return this.ShippingOptionIsDefaultField;
			}
			set {
				this.ShippingOptionIsDefaultField = value;
			}
		}

		private BasicAmountType ShippingOptionAmountField;
		public BasicAmountType ShippingOptionAmount {
			get {
				return this.ShippingOptionAmountField;
			}
			set {
				this.ShippingOptionAmountField = value;
			}
		}

		private string ShippingOptionNameField;
		public string ShippingOptionName {
			get {
				return this.ShippingOptionNameField;
			}
			set {
				this.ShippingOptionNameField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( ShippingOptionIsDefault != null ) {
			sb.Append("<ebl:ShippingOptionIsDefault>").Append(ShippingOptionIsDefault);
			sb.Append("</ebl:ShippingOptionIsDefault>");
		}
		if( ShippingOptionAmount != null ) {
			sb.Append("<ebl:ShippingOptionAmount ");
			sb.Append(ShippingOptionAmount.toXMLString());
			sb.Append("</ebl:ShippingOptionAmount>");
		}
		if( ShippingOptionName != null ) {
			sb.Append("<ebl:ShippingOptionName>").Append(ShippingOptionName);
			sb.Append("</ebl:ShippingOptionName>");
		}
		return sb.ToString();
	}

	}


	public enum ShippingServiceCodeType {
[Description("UPSGround")]UPSGROUND,
[Description("UPS3rdDay")]UPSRDDAY,
[Description("UPS2ndDay")]UPSNDDAY,
[Description("UPSNextDay")]UPSNEXTDAY,
[Description("USPSPriority")]USPSPRIORITY,
[Description("USPSParcel")]USPSPARCEL,
[Description("USPSMedia")]USPSMEDIA,
[Description("USPSFirstClass")]USPSFIRSTCLASS,
[Description("ShippingMethodStandard")]SHIPPINGMETHODSTANDARD,
[Description("ShippingMethodExpress")]SHIPPINGMETHODEXPRESS,
[Description("ShippingMethodNextDay")]SHIPPINGMETHODNEXTDAY,
[Description("USPSExpressMail")]USPSEXPRESSMAIL,
[Description("USPSGround")]USPSGROUND,
[Description("Download")]DOWNLOAD,
[Description("WillCall_Or_Pickup")]WILLCALLORPICKUP,
[Description("CustomCode")]CUSTOMCODE,
	}
	public enum SolutionTypeType {
[Description("Mark")]MARK,
[Description("Sole")]SOLE,
	}
	public enum StatusChangeActionType {
[Description("Cancel")]CANCEL,
[Description("Suspend")]SUSPEND,
[Description("Reactivate")]REACTIVATE,
	}
	public enum SubscribeTextType {
[Description("BUYNOW")]BUYNOW,
[Description("SUBSCRIBE")]SUBSCRIBE,
	}
	/**
	 * SubscriptionInfoType 
	 * Information about a PayPal Subscription.
	 */
	public partial class SubscriptionInfoType {

		/**
		 * ID generated by PayPal for the subscriber. 
Character length and limitations: no limit		 */
		private string SubscriptionIDField;
		public string SubscriptionID {
			get {
				return this.SubscriptionIDField;
			}
			set {
				this.SubscriptionIDField = value;
			}
		}

		/**
		 * Subscription start date 		 */
		private string SubscriptionDateField;
		public string SubscriptionDate {
			get {
				return this.SubscriptionDateField;
			}
			set {
				this.SubscriptionDateField = value;
			}
		}

		/**
		 * Date when the subscription modification will be effective 		 */
		private string EffectiveDateField;
		public string EffectiveDate {
			get {
				return this.EffectiveDateField;
			}
			set {
				this.EffectiveDateField = value;
			}
		}

		/**
		 * Date PayPal will retry a failed subscription payment 		 */
		private string RetryTimeField;
		public string RetryTime {
			get {
				return this.RetryTimeField;
			}
			set {
				this.RetryTimeField = value;
			}
		}

		/**
		 * Username generated by PayPal and given to subscriber to access the subscription. 
Character length and limitations: 64 alphanumeric single-byte characters		 */
		private string UsernameField;
		public string Username {
			get {
				return this.UsernameField;
			}
			set {
				this.UsernameField = value;
			}
		}

		/**
		 * Password generated by PayPal and given to subscriber to access the subscription. For security, the value of the password is hashed. 
Character length and limitations: 128 alphanumeric single-byte characters		 */
		private string PasswordField;
		public string Password {
			get {
				return this.PasswordField;
			}
			set {
				this.PasswordField = value;
			}
		}

		/**
		 * The number of payment installments that will occur at the regular rate. 
Character length and limitations: no limit		 */
		private string RecurrencesField;
		public string Recurrences {
			get {
				return this.RecurrencesField;
			}
			set {
				this.RecurrencesField = value;
			}
		}

		/**
		 * Subscription duration and charges		 */
		private List<SubscriptionTermsType> TermsField = new List<SubscriptionTermsType>();
		public List<SubscriptionTermsType> Terms {
			get {
				return this.TermsField;
			}
			set {
				this.TermsField = value;
			}
		}

	 public SubscriptionInfoType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("SubscriptionID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SubscriptionID")[0])){ 
		 this.SubscriptionID =(string)document.GetElementsByTagName("SubscriptionID")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("SubscriptionDate").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SubscriptionDate")[0])){ 
		 this.SubscriptionDate =(string)document.GetElementsByTagName("SubscriptionDate")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("EffectiveDate").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("EffectiveDate")[0])){ 
		 this.EffectiveDate =(string)document.GetElementsByTagName("EffectiveDate")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("RetryTime").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("RetryTime")[0])){ 
		 this.RetryTime =(string)document.GetElementsByTagName("RetryTime")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Username").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Username")[0])){ 
		 this.Username =(string)document.GetElementsByTagName("Username")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Password").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Password")[0])){ 
		 this.Password =(string)document.GetElementsByTagName("Password")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Recurrences").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Recurrences")[0])){ 
		 this.Recurrences =(string)document.GetElementsByTagName("Recurrences")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Terms").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Terms")[0])){ 
		 nodeList = document.GetElementsByTagName("Terms");
		 for(int i=0; i<nodeList.Count; i++) {
			 xmlString = DeserializationUtils.convertToXML(nodeList[i]); 
				this.Terms.Add(new SubscriptionTermsType(xmlString));
			}

}
	}
	}
	}


	/**
	 * SubscriptionTermsType 
	 * Terms of a PayPal subscription.
	 */
	public partial class SubscriptionTermsType {

		private BasicAmountType AmountField;
		public BasicAmountType Amount {
			get {
				return this.AmountField;
			}
			set {
				this.AmountField = value;
			}
		}

	 public SubscriptionTermsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Amount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Amount")[0])){ 
		 nodeList = document.GetElementsByTagName("Amount");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.Amount =  new BasicAmountType(xmlString);

}
	}
	}
	}


	/**
	 * Details about the payer's tax info passed in by the merchant or partner.
	 * Optional.
	 */
	public partial class TaxIdDetailsType {

		/**
		 * The payer's Tax ID type; CNPJ/CPF for BR country.
		 */
		private string TaxIdTypeField;
		public string TaxIdType {
			get {
				return this.TaxIdTypeField;
			}
			set {
				this.TaxIdTypeField = value;
			}
		}

		/**
		 * The payer's Tax ID
		 */
		private string TaxIdField;
		public string TaxId {
			get {
				return this.TaxIdField;
			}
			set {
				this.TaxIdField = value;
			}
		}

		public TaxIdDetailsType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( TaxIdType != null ) {
			sb.Append("<ebl:TaxIdType>").Append(TaxIdType);
			sb.Append("</ebl:TaxIdType>");
		}
		if( TaxId != null ) {
			sb.Append("<ebl:TaxId>").Append(TaxId);
			sb.Append("</ebl:TaxId>");
		}
		return sb.ToString();
	}

	 public TaxIdDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("TaxIdType").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TaxIdType")[0])){ 
		 this.TaxIdType =(string)document.GetElementsByTagName("TaxIdType")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("TaxId").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TaxId")[0])){ 
		 this.TaxId =(string)document.GetElementsByTagName("TaxId")[0].InnerText;

}
	}
	}
	}


	/**
	 * 3DSecureInfoType
	 * Information about 3D Secure parameters.
	 */
	public partial class ThreeDSecureInfoType {

		private ThreeDSecureRequestType ThreeDSecureRequestField;
		public ThreeDSecureRequestType ThreeDSecureRequest {
			get {
				return this.ThreeDSecureRequestField;
			}
			set {
				this.ThreeDSecureRequestField = value;
			}
		}

		private ThreeDSecureResponseType ThreeDSecureResponseField;
		public ThreeDSecureResponseType ThreeDSecureResponse {
			get {
				return this.ThreeDSecureResponseField;
			}
			set {
				this.ThreeDSecureResponseField = value;
			}
		}

	 public ThreeDSecureInfoType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("ThreeDSecureRequest").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ThreeDSecureRequest")[0])){ 
		 nodeList = document.GetElementsByTagName("ThreeDSecureRequest");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.ThreeDSecureRequest =  new ThreeDSecureRequestType(xmlString);

}
	}
		 if(document.GetElementsByTagName("ThreeDSecureResponse").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ThreeDSecureResponse")[0])){ 
		 nodeList = document.GetElementsByTagName("ThreeDSecureResponse");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.ThreeDSecureResponse =  new ThreeDSecureResponseType(xmlString);

}
	}
	}
	}


	/**
	 * The Common 3DS fields. Common for both GTD and DCC API's.
	 */
	public partial class ThreeDSecureRequestType {

		private string Eci3dsField;
		public string Eci3ds {
			get {
				return this.Eci3dsField;
			}
			set {
				this.Eci3dsField = value;
			}
		}

		private string CavvField;
		public string Cavv {
			get {
				return this.CavvField;
			}
			set {
				this.CavvField = value;
			}
		}

		private string XidField;
		public string Xid {
			get {
				return this.XidField;
			}
			set {
				this.XidField = value;
			}
		}

		private string MpiVendor3dsField;
		public string MpiVendor3ds {
			get {
				return this.MpiVendor3dsField;
			}
			set {
				this.MpiVendor3dsField = value;
			}
		}

		private string AuthStatus3dsField;
		public string AuthStatus3ds {
			get {
				return this.AuthStatus3dsField;
			}
			set {
				this.AuthStatus3dsField = value;
			}
		}

		public ThreeDSecureRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( Eci3ds != null ) {
			sb.Append("<ebl:Eci3ds>").Append(Eci3ds);
			sb.Append("</ebl:Eci3ds>");
		}
		if( Cavv != null ) {
			sb.Append("<ebl:Cavv>").Append(Cavv);
			sb.Append("</ebl:Cavv>");
		}
		if( Xid != null ) {
			sb.Append("<ebl:Xid>").Append(Xid);
			sb.Append("</ebl:Xid>");
		}
		if( MpiVendor3ds != null ) {
			sb.Append("<ebl:MpiVendor3ds>").Append(MpiVendor3ds);
			sb.Append("</ebl:MpiVendor3ds>");
		}
		if( AuthStatus3ds != null ) {
			sb.Append("<ebl:AuthStatus3ds>").Append(AuthStatus3ds);
			sb.Append("</ebl:AuthStatus3ds>");
		}
		return sb.ToString();
	}

	 public ThreeDSecureRequestType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Eci3ds").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Eci3ds")[0])){ 
		 this.Eci3ds =(string)document.GetElementsByTagName("Eci3ds")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Cavv").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Cavv")[0])){ 
		 this.Cavv =(string)document.GetElementsByTagName("Cavv")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("Xid").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Xid")[0])){ 
		 this.Xid =(string)document.GetElementsByTagName("Xid")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("MpiVendor3ds").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("MpiVendor3ds")[0])){ 
		 this.MpiVendor3ds =(string)document.GetElementsByTagName("MpiVendor3ds")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("AuthStatus3ds").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AuthStatus3ds")[0])){ 
		 this.AuthStatus3ds =(string)document.GetElementsByTagName("AuthStatus3ds")[0].InnerText;

}
	}
	}
	}


	/**
	 * 3DS remaining fields.
	 */
	public partial class ThreeDSecureResponseType {

		private string VpasField;
		public string Vpas {
			get {
				return this.VpasField;
			}
			set {
				this.VpasField = value;
			}
		}

		private string EciSubmitted3DSField;
		public string EciSubmitted3DS {
			get {
				return this.EciSubmitted3DSField;
			}
			set {
				this.EciSubmitted3DSField = value;
			}
		}

	 public ThreeDSecureResponseType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Vpas").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Vpas")[0])){ 
		 this.Vpas =(string)document.GetElementsByTagName("Vpas")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("EciSubmitted3DS").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("EciSubmitted3DS")[0])){ 
		 this.EciSubmitted3DS =(string)document.GetElementsByTagName("EciSubmitted3DS")[0].InnerText;

}
	}
	}
	}


	public enum TotalType {
[Description("Total")]TOTAL,
[Description("EstimatedTotal")]ESTIMATEDTOTAL,
	}
	public enum TransactionEntityType {
[Description("None")]NONE,
[Description("Auth")]AUTH,
[Description("Reauth")]REAUTH,
[Description("Order")]ORDER,
[Description("Payment")]PAYMENT,
	}
	/**
	 */
	public partial class TransactionSearchReq {

		private TransactionSearchRequestType TransactionSearchRequestField;
		public TransactionSearchRequestType TransactionSearchRequest {
			get {
				return this.TransactionSearchRequestField;
			}
			set {
				this.TransactionSearchRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:TransactionSearchReq>");
		if( TransactionSearchRequest != null ) {
			sb.Append("<urn:TransactionSearchRequest>");
			sb.Append(TransactionSearchRequest.toXMLString());
			sb.Append("</urn:TransactionSearchRequest>");
		}
sb.Append("</urn:TransactionSearchReq>");
		return sb.ToString();
	}

	}


	/**
The earliest transaction date at which to start the search. No wildcards are allowed. 
	 * Required
	 */
	public partial class TransactionSearchRequestType :AbstractRequestType{

		/**
The earliest transaction date at which to start the search. No wildcards are allowed. 
		 * Required
		 */
		private string StartDateField;
		public string StartDate {
			get {
				return this.StartDateField;
			}
			set {
				this.StartDateField = value;
			}
		}

		/**
The latest transaction date to be included in the search 
		 * Optional
		 */
		private string EndDateField;
		public string EndDate {
			get {
				return this.EndDateField;
			}
			set {
				this.EndDateField = value;
			}
		}

		/**
Search by the buyer's email address 
		 * Optional
		 * Character length and limitations: 127 single-byte alphanumeric characters
		 */
		private string PayerField;
		public string Payer {
			get {
				return this.PayerField;
			}
			set {
				this.PayerField = value;
			}
		}

		/**
Search by the receiver's email address. If the merchant account has only one email, this is the primary email. Can also be a non-primary email.
		 * Optional
		 */
		private string ReceiverField;
		public string Receiver {
			get {
				return this.ReceiverField;
			}
			set {
				this.ReceiverField = value;
			}
		}

		/**
Search by the PayPal Account Optional receipt ID
		 * Optional
		 */
		private string ReceiptIDField;
		public string ReceiptID {
			get {
				return this.ReceiptIDField;
			}
			set {
				this.ReceiptIDField = value;
			}
		}

		/**
Search by the transaction ID. 
		 * Optional
		 * The returned results are from the merchant's transaction records. 
		 * Character length and limitations: 19 single-byte characters maximum
		 */
		private string TransactionIDField;
		public string TransactionID {
			get {
				return this.TransactionIDField;
			}
			set {
				this.TransactionIDField = value;
			}
		}

		/**
Search by Recurring Payment Profile id.  The ProfileID is returned as part of the CreateRecurringPaymentsProfile API response. 
		 * Optional
		 */
		private string ProfileIDField;
		public string ProfileID {
			get {
				return this.ProfileIDField;
			}
			set {
				this.ProfileIDField = value;
			}
		}

		/**
Search by Store Id. It is mandatory field if Terminal Id is specified as one of the search parameters.
		 * Optional
		 */
		private string StoreIDField;
		public string StoreID {
			get {
				return this.StoreIDField;
			}
			set {
				this.StoreIDField = value;
			}
		}

		/**
Search by Store Id and Terminal Id. If the Terminal Id field is specified as one of the search parameters, then there should be a valid Store Id value set in the StoreID field.
		 * Optional
		 */
		private string TerminalIDField;
		public string TerminalID {
			get {
				return this.TerminalIDField;
			}
			set {
				this.TerminalIDField = value;
			}
		}

		/**
Search by the buyer's name 
		 * Optional
		 * Salutation: 20 single-byte character limit.
		 * FirstName: 25 single-byte character limit.
		 * MiddleName: 25 single-byte character limit.
		 * LastName: 25 single-byte character limit.
		 * Suffix: 12 single-byte character limit.
		 */
		private PersonNameType PayerNameField;
		public PersonNameType PayerName {
			get {
				return this.PayerNameField;
			}
			set {
				this.PayerNameField = value;
			}
		}

		/**
Search by item number of the purchased goods.
		 * Optional
		 * To search for purchased items not related to auctions, set the AuctionItemNumber element to the value of the HTML item_number variable set in the shopping cart for the original transaction.		 */
		private string AuctionItemNumberField;
		public string AuctionItemNumber {
			get {
				return this.AuctionItemNumberField;
			}
			set {
				this.AuctionItemNumberField = value;
			}
		}

		/**
Search by invoice identification key, as set by you for the original transaction. InvoiceID searches the invoice records for items sold by the merchant, not the items purchased. 
		 * Optional
		 * The value for InvoiceID must exactly match an invoice identification number. No wildcards are allowed. 
		 * Character length and limitations: 127 single-byte characters maximum		 */
		private string InvoiceIDField;
		public string InvoiceID {
			get {
				return this.InvoiceIDField;
			}
			set {
				this.InvoiceIDField = value;
			}
		}

		private string CardNumberField;
		public string CardNumber {
			get {
				return this.CardNumberField;
			}
			set {
				this.CardNumberField = value;
			}
		}

		/**
		 * Search by classification of transaction. Some kinds of possible classes of transactions are not searchable with TransactionSearchRequest. You cannot search for bank transfer withdrawals, for example. 
		 * Optional
		 * All: all transaction classifications.
		 * Sent: only payments sent.
		 * Received: only payments received.
		 * MassPay: only mass payments.
		 * MoneyRequest: only money requests.
		 * FundsAdded: only funds added to balance.
		 * FundsWithdrawn: only funds withdrawn from balance.
		 * Referral: only transactions involving referrals.
		 * Fee: only transactions involving fees.
		 * Subscription: only transactions involving subscriptions.
		 * Dividend: only transactions involving dividends.
		 * Billpay: only transactions involving BillPay Transactions.
		 * Refund: only transactions involving funds.
		 * CurrencyConversions: only transactions involving currency conversions.
		 * BalanceTransfer: only transactions involving balance transfers.
		 * Reversal: only transactions involving BillPay reversals.
		 * Shipping: only transactions involving UPS shipping fees.
		 * BalanceAffecting: only transactions that affect the account balance.
		 * ECheck: only transactions involving eCheck
		 */
		private PaymentTransactionClassCodeType? TransactionClassField;
		public PaymentTransactionClassCodeType? TransactionClass {
			get {
				return this.TransactionClassField;
			}
			set {
				this.TransactionClassField = value;
			}
		}

		/**
Search by transaction amount 
		 * Optional
		 * You must set the currencyID attribute to one of the three-character currency codes for any of the supported PayPal currencies. 		 */
		private BasicAmountType AmountField;
		public BasicAmountType Amount {
			get {
				return this.AmountField;
			}
			set {
				this.AmountField = value;
			}
		}

		/**
Search by currency code
		 * Optional
		 */
		private CurrencyCodeType? CurrencyCodeField;
		public CurrencyCodeType? CurrencyCode {
			get {
				return this.CurrencyCodeField;
			}
			set {
				this.CurrencyCodeField = value;
			}
		}

		/**
Search by transaction status 
		 * Optional
		 * Pending: The payment is pending. The specific reason the payment is pending is returned by the GetTransactionDetails APIPendingReason element. For more information, see PendingReason.
		 * Processing: The payment is being processed.
		 * Success: The payment has been completed and the funds have been added successfully to your account balance.
		 * Denied: You denied the payment. This happens only if the payment was previously pending.
		 * Reversed: A payment was reversed due to a chargeback or other type of reversal. The funds have been removed from your account balance and returned to the buyer.
		 */
		private PaymentTransactionStatusCodeType? StatusField;
		public PaymentTransactionStatusCodeType? Status {
			get {
				return this.StatusField;
			}
			set {
				this.StatusField = value;
			}
		}

		public TransactionSearchRequestType(string StartDate) {
			this.StartDate = StartDate;
		}
		public TransactionSearchRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( StartDate != null ) {
			sb.Append("<urn:StartDate>").Append(StartDate);
			sb.Append("</urn:StartDate>");
		}
		if( EndDate != null ) {
			sb.Append("<urn:EndDate>").Append(EndDate);
			sb.Append("</urn:EndDate>");
		}
		if( Payer != null ) {
			sb.Append("<urn:Payer>").Append(Payer);
			sb.Append("</urn:Payer>");
		}
		if( Receiver != null ) {
			sb.Append("<urn:Receiver>").Append(Receiver);
			sb.Append("</urn:Receiver>");
		}
		if( ReceiptID != null ) {
			sb.Append("<urn:ReceiptID>").Append(ReceiptID);
			sb.Append("</urn:ReceiptID>");
		}
		if( TransactionID != null ) {
			sb.Append("<urn:TransactionID>").Append(TransactionID);
			sb.Append("</urn:TransactionID>");
		}
		if( ProfileID != null ) {
			sb.Append("<urn:ProfileID>").Append(ProfileID);
			sb.Append("</urn:ProfileID>");
		}
		if( StoreID != null ) {
			sb.Append("<urn:StoreID>").Append(StoreID);
			sb.Append("</urn:StoreID>");
		}
		if( TerminalID != null ) {
			sb.Append("<urn:TerminalID>").Append(TerminalID);
			sb.Append("</urn:TerminalID>");
		}
		if( PayerName != null ) {
			sb.Append("<urn:PayerName>");
			sb.Append(PayerName.toXMLString());
			sb.Append("</urn:PayerName>");
		}
		if( AuctionItemNumber != null ) {
			sb.Append("<urn:AuctionItemNumber>").Append(AuctionItemNumber);
			sb.Append("</urn:AuctionItemNumber>");
		}
		if( InvoiceID != null ) {
			sb.Append("<urn:InvoiceID>").Append(InvoiceID);
			sb.Append("</urn:InvoiceID>");
		}
		if( CardNumber != null ) {
			sb.Append("<urn:CardNumber>").Append(CardNumber);
			sb.Append("</urn:CardNumber>");
		}
		if( TransactionClass != null ) {
			sb.Append("<urn:TransactionClass>").Append(EnumUtils.getDescription(TransactionClass));
			sb.Append("</urn:TransactionClass>");
		}
		if( Amount != null ) {
			sb.Append("<urn:Amount ");
			sb.Append(Amount.toXMLString());
			sb.Append("</urn:Amount>");
		}
		if( CurrencyCode != null ) {
			sb.Append("<urn:CurrencyCode>").Append(EnumUtils.getDescription(CurrencyCode));
			sb.Append("</urn:CurrencyCode>");
		}
		if( Status != null ) {
			sb.Append("<urn:Status>").Append(EnumUtils.getDescription(Status));
			sb.Append("</urn:Status>");
		}
		return sb.ToString();
	}

	}


	/**
Results of a Transaction Search.	 */
	public partial class TransactionSearchResponseType :AbstractResponseType{

		/**
Results of a Transaction Search.		 */
		private List<PaymentTransactionSearchResultType> PaymentTransactionsField = new List<PaymentTransactionSearchResultType>();
		public List<PaymentTransactionSearchResultType> PaymentTransactions {
			get {
				return this.PaymentTransactionsField;
			}
			set {
				this.PaymentTransactionsField = value;
			}
		}

	 public TransactionSearchResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("PaymentTransactions").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentTransactions")[0])){ 
		 nodeList = document.GetElementsByTagName("PaymentTransactions");
		 for(int i=0; i<nodeList.Count; i++) {
			 xmlString = DeserializationUtils.convertToXML(nodeList[i]); 
				this.PaymentTransactions.Add(new PaymentTransactionSearchResultType(xmlString));
			}

}
	}
	}
	}


	/**
	 * UATP Card Details Type 
	 */
	public partial class UATPDetailsType {

		/**
UATP Card Number		 */
		private string UATPNumberField;
		public string UATPNumber {
			get {
				return this.UATPNumberField;
			}
			set {
				this.UATPNumberField = value;
			}
		}

		/**
		 * UATP Card expirty month		 */
		private int? ExpMonthField;
		public int? ExpMonth {
			get {
				return this.ExpMonthField;
			}
			set {
				this.ExpMonthField = value;
			}
		}

		/**
		 * UATP Card expirty year		 */
		private int? ExpYearField;
		public int? ExpYear {
			get {
				return this.ExpYearField;
			}
			set {
				this.ExpYearField = value;
			}
		}

		public UATPDetailsType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( UATPNumber != null ) {
			sb.Append("<ebl:UATPNumber>").Append(UATPNumber);
			sb.Append("</ebl:UATPNumber>");
		}
		if( ExpMonth != null ) {
			sb.Append("<ebl:ExpMonth>").Append(ExpMonth);
			sb.Append("</ebl:ExpMonth>");
		}
		if( ExpYear != null ) {
			sb.Append("<ebl:ExpYear>").Append(ExpYear);
			sb.Append("</ebl:ExpYear>");
		}
		return sb.ToString();
	}

	 public UATPDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("UATPNumber").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("UATPNumber")[0])){ 
		 this.UATPNumber =(string)document.GetElementsByTagName("UATPNumber")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ExpMonth").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ExpMonth")[0])){ 
		 this.ExpMonth =System.Convert.ToInt32(document.GetElementsByTagName("ExpMonth")[0].InnerText);

}
	}
		 if(document.GetElementsByTagName("ExpYear").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ExpYear")[0])){ 
		 this.ExpYear =System.Convert.ToInt32(document.GetElementsByTagName("ExpYear")[0].InnerText);

}
	}
	}
	}


	public enum UnitOfMeasure {
[Description("EA")]EA,
[Description("Hours")]HOURS,
[Description("Days")]DAYS,
[Description("Seconds")]SECONDS,
[Description("CrateOf12")]CRATEOF,
[Description("6Pack")]PACK,
[Description("GLI")]GLI,
[Description("GLL")]GLL,
[Description("LTR")]LTR,
[Description("INH")]INH,
[Description("FOT")]FOT,
[Description("MMT")]MMT,
[Description("CMQ")]CMQ,
[Description("MTR")]MTR,
[Description("MTK")]MTK,
[Description("MTQ")]MTQ,
[Description("GRM")]GRM,
[Description("KGM")]KGM,
[Description("KG")]KG,
[Description("LBR")]LBR,
[Description("ANN")]ANN,
[Description("CEL")]CEL,
[Description("FAH")]FAH,
[Description("RESERVED")]RESERVED,
	}
	/**
	 */
	public partial class UpdateAccessPermissionsReq {

		private UpdateAccessPermissionsRequestType UpdateAccessPermissionsRequestField;
		public UpdateAccessPermissionsRequestType UpdateAccessPermissionsRequest {
			get {
				return this.UpdateAccessPermissionsRequestField;
			}
			set {
				this.UpdateAccessPermissionsRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:UpdateAccessPermissionsReq>");
		if( UpdateAccessPermissionsRequest != null ) {
			sb.Append("<urn:UpdateAccessPermissionsRequest>");
			sb.Append(UpdateAccessPermissionsRequest.toXMLString());
			sb.Append("</urn:UpdateAccessPermissionsRequest>");
		}
sb.Append("</urn:UpdateAccessPermissionsReq>");
		return sb.ToString();
	}

	}


	/**
	 * Unique PayPal customer account number, the value of which was returned by GetAuthDetails Response.
	 * Required
	 * Character length and limitations: 20 single-byte characters
	 */
	public partial class UpdateAccessPermissionsRequestType :AbstractRequestType{

		/**
Unique PayPal customer account number, the value of which was returned by GetAuthDetails Response.
		 * Required
		 * Character length and limitations: 20 single-byte characters
		 */
		private string PayerIDField;
		public string PayerID {
			get {
				return this.PayerIDField;
			}
			set {
				this.PayerIDField = value;
			}
		}

		public UpdateAccessPermissionsRequestType(string PayerID) {
			this.PayerID = PayerID;
		}
		public UpdateAccessPermissionsRequestType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( PayerID != null ) {
			sb.Append("<urn:PayerID>").Append(PayerID);
			sb.Append("</urn:PayerID>");
		}
		return sb.ToString();
	}

	}


	/**
	 * The status of the update call, Success/Failure.
	 * Character length and limitations: 20 single-byte characters
	 */
	public partial class UpdateAccessPermissionsResponseType :AbstractResponseType{

		/**
The status of the update call, Success/Failure.
		 * Character length and limitations: 20 single-byte characters
		 */
		private string StatusField;
		public string Status {
			get {
				return this.StatusField;
			}
			set {
				this.StatusField = value;
			}
		}

	 public UpdateAccessPermissionsResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("Status").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Status")[0])){ 
		 nodeList = document.GetElementsByTagName("Status");
			 string value = nodeList[0].InnerText; 
		 this.Status =value;

}
	}
	}
	}


	/**
	 */
	public partial class UpdateRecurringPaymentsProfileReq {

		private UpdateRecurringPaymentsProfileRequestType UpdateRecurringPaymentsProfileRequestField;
		public UpdateRecurringPaymentsProfileRequestType UpdateRecurringPaymentsProfileRequest {
			get {
				return this.UpdateRecurringPaymentsProfileRequestField;
			}
			set {
				this.UpdateRecurringPaymentsProfileRequestField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append("<urn:UpdateRecurringPaymentsProfileReq>");
		if( UpdateRecurringPaymentsProfileRequest != null ) {
			sb.Append("<urn:UpdateRecurringPaymentsProfileRequest>");
			sb.Append(UpdateRecurringPaymentsProfileRequest.toXMLString());
			sb.Append("</urn:UpdateRecurringPaymentsProfileRequest>");
		}
sb.Append("</urn:UpdateRecurringPaymentsProfileReq>");
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class UpdateRecurringPaymentsProfileRequestDetailsType {

		/**
		 */
		private string ProfileIDField;
		public string ProfileID {
			get {
				return this.ProfileIDField;
			}
			set {
				this.ProfileIDField = value;
			}
		}

		/**
		 */
		private string NoteField;
		public string Note {
			get {
				return this.NoteField;
			}
			set {
				this.NoteField = value;
			}
		}

		/**
		 */
		private string DescriptionField;
		public string Description {
			get {
				return this.DescriptionField;
			}
			set {
				this.DescriptionField = value;
			}
		}

		/**
		 */
		private string SubscriberNameField;
		public string SubscriberName {
			get {
				return this.SubscriberNameField;
			}
			set {
				this.SubscriberNameField = value;
			}
		}

		/**
		 */
		private AddressType SubscriberShippingAddressField;
		public AddressType SubscriberShippingAddress {
			get {
				return this.SubscriberShippingAddressField;
			}
			set {
				this.SubscriberShippingAddressField = value;
			}
		}

		/**
		 */
		private string ProfileReferenceField;
		public string ProfileReference {
			get {
				return this.ProfileReferenceField;
			}
			set {
				this.ProfileReferenceField = value;
			}
		}

		/**
		 */
		private int? AdditionalBillingCyclesField;
		public int? AdditionalBillingCycles {
			get {
				return this.AdditionalBillingCyclesField;
			}
			set {
				this.AdditionalBillingCyclesField = value;
			}
		}

		/**
		 */
		private BasicAmountType AmountField;
		public BasicAmountType Amount {
			get {
				return this.AmountField;
			}
			set {
				this.AmountField = value;
			}
		}

		/**
		 */
		private BasicAmountType ShippingAmountField;
		public BasicAmountType ShippingAmount {
			get {
				return this.ShippingAmountField;
			}
			set {
				this.ShippingAmountField = value;
			}
		}

		/**
		 */
		private BasicAmountType TaxAmountField;
		public BasicAmountType TaxAmount {
			get {
				return this.TaxAmountField;
			}
			set {
				this.TaxAmountField = value;
			}
		}

		/**
		 */
		private BasicAmountType OutstandingBalanceField;
		public BasicAmountType OutstandingBalance {
			get {
				return this.OutstandingBalanceField;
			}
			set {
				this.OutstandingBalanceField = value;
			}
		}

		/**
		 */
		private AutoBillType? AutoBillOutstandingAmountField;
		public AutoBillType? AutoBillOutstandingAmount {
			get {
				return this.AutoBillOutstandingAmountField;
			}
			set {
				this.AutoBillOutstandingAmountField = value;
			}
		}

		/**
		 */
		private int? MaxFailedPaymentsField;
		public int? MaxFailedPayments {
			get {
				return this.MaxFailedPaymentsField;
			}
			set {
				this.MaxFailedPaymentsField = value;
			}
		}

		/**
		 * Information about the credit card to be charged (required if Direct Payment)
		 */
		private CreditCardDetailsType CreditCardField;
		public CreditCardDetailsType CreditCard {
			get {
				return this.CreditCardField;
			}
			set {
				this.CreditCardField = value;
			}
		}

		/**
		 * When does this Profile begin billing?
		 */
		private string BillingStartDateField;
		public string BillingStartDate {
			get {
				return this.BillingStartDateField;
			}
			set {
				this.BillingStartDateField = value;
			}
		}

		/**
		 * Trial period of this schedule
		 */
		private BillingPeriodDetailsType_Update TrialPeriodField;
		public BillingPeriodDetailsType_Update TrialPeriod {
			get {
				return this.TrialPeriodField;
			}
			set {
				this.TrialPeriodField = value;
			}
		}

		/**
		 */
		private BillingPeriodDetailsType_Update PaymentPeriodField;
		public BillingPeriodDetailsType_Update PaymentPeriod {
			get {
				return this.PaymentPeriodField;
			}
			set {
				this.PaymentPeriodField = value;
			}
		}

		public UpdateRecurringPaymentsProfileRequestDetailsType(string ProfileID) {
			this.ProfileID = ProfileID;
		}
		public UpdateRecurringPaymentsProfileRequestDetailsType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( ProfileID != null ) {
			sb.Append("<ebl:ProfileID>").Append(ProfileID);
			sb.Append("</ebl:ProfileID>");
		}
		if( Note != null ) {
			sb.Append("<ebl:Note>").Append(Note);
			sb.Append("</ebl:Note>");
		}
		if( Description != null ) {
			sb.Append("<ebl:Description>").Append(Description);
			sb.Append("</ebl:Description>");
		}
		if( SubscriberName != null ) {
			sb.Append("<ebl:SubscriberName>").Append(SubscriberName);
			sb.Append("</ebl:SubscriberName>");
		}
		if( SubscriberShippingAddress != null ) {
			sb.Append("<ebl:SubscriberShippingAddress>");
			sb.Append(SubscriberShippingAddress.toXMLString());
			sb.Append("</ebl:SubscriberShippingAddress>");
		}
		if( ProfileReference != null ) {
			sb.Append("<ebl:ProfileReference>").Append(ProfileReference);
			sb.Append("</ebl:ProfileReference>");
		}
		if( AdditionalBillingCycles != null ) {
			sb.Append("<ebl:AdditionalBillingCycles>").Append(AdditionalBillingCycles);
			sb.Append("</ebl:AdditionalBillingCycles>");
		}
		if( Amount != null ) {
			sb.Append("<ebl:Amount ");
			sb.Append(Amount.toXMLString());
			sb.Append("</ebl:Amount>");
		}
		if( ShippingAmount != null ) {
			sb.Append("<ebl:ShippingAmount ");
			sb.Append(ShippingAmount.toXMLString());
			sb.Append("</ebl:ShippingAmount>");
		}
		if( TaxAmount != null ) {
			sb.Append("<ebl:TaxAmount ");
			sb.Append(TaxAmount.toXMLString());
			sb.Append("</ebl:TaxAmount>");
		}
		if( OutstandingBalance != null ) {
			sb.Append("<ebl:OutstandingBalance ");
			sb.Append(OutstandingBalance.toXMLString());
			sb.Append("</ebl:OutstandingBalance>");
		}
		if( AutoBillOutstandingAmount != null ) {
			sb.Append("<ebl:AutoBillOutstandingAmount>").Append(EnumUtils.getDescription(AutoBillOutstandingAmount));
			sb.Append("</ebl:AutoBillOutstandingAmount>");
		}
		if( MaxFailedPayments != null ) {
			sb.Append("<ebl:MaxFailedPayments>").Append(MaxFailedPayments);
			sb.Append("</ebl:MaxFailedPayments>");
		}
		if( CreditCard != null ) {
			sb.Append("<ebl:CreditCard>");
			sb.Append(CreditCard.toXMLString());
			sb.Append("</ebl:CreditCard>");
		}
		if( BillingStartDate != null ) {
			sb.Append("<ebl:BillingStartDate>").Append(BillingStartDate);
			sb.Append("</ebl:BillingStartDate>");
		}
		if( TrialPeriod != null ) {
			sb.Append("<ebl:TrialPeriod>");
			sb.Append(TrialPeriod.toXMLString());
			sb.Append("</ebl:TrialPeriod>");
		}
		if( PaymentPeriod != null ) {
			sb.Append("<ebl:PaymentPeriod>");
			sb.Append(PaymentPeriod.toXMLString());
			sb.Append("</ebl:PaymentPeriod>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class UpdateRecurringPaymentsProfileRequestType :AbstractRequestType{

		private UpdateRecurringPaymentsProfileRequestDetailsType UpdateRecurringPaymentsProfileRequestDetailsField;
		public UpdateRecurringPaymentsProfileRequestDetailsType UpdateRecurringPaymentsProfileRequestDetails {
			get {
				return this.UpdateRecurringPaymentsProfileRequestDetailsField;
			}
			set {
				this.UpdateRecurringPaymentsProfileRequestDetailsField = value;
			}
		}


	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
sb.Append(base.toXMLString());
		if( UpdateRecurringPaymentsProfileRequestDetails != null ) {
			sb.Append("<ebl:UpdateRecurringPaymentsProfileRequestDetails>");
			sb.Append(UpdateRecurringPaymentsProfileRequestDetails.toXMLString());
			sb.Append("</ebl:UpdateRecurringPaymentsProfileRequestDetails>");
		}
		return sb.ToString();
	}

	}


	/**
	 */
	public partial class UpdateRecurringPaymentsProfileResponseDetailsType {

		/**
		 */
		private string ProfileIDField;
		public string ProfileID {
			get {
				return this.ProfileIDField;
			}
			set {
				this.ProfileIDField = value;
			}
		}

	 public UpdateRecurringPaymentsProfileResponseDetailsType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("ProfileID").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ProfileID")[0])){ 
		 nodeList = document.GetElementsByTagName("ProfileID");
			 string value = nodeList[0].InnerText; 
		 this.ProfileID =value;

}
	}
	}
	}


	/**
	 */
	public partial class UpdateRecurringPaymentsProfileResponseType :AbstractResponseType{

		private UpdateRecurringPaymentsProfileResponseDetailsType UpdateRecurringPaymentsProfileResponseDetailsField;
		public UpdateRecurringPaymentsProfileResponseDetailsType UpdateRecurringPaymentsProfileResponseDetails {
			get {
				return this.UpdateRecurringPaymentsProfileResponseDetailsField;
			}
			set {
				this.UpdateRecurringPaymentsProfileResponseDetailsField = value;
			}
		}

	 public UpdateRecurringPaymentsProfileResponseType(Object xmlSoap):base(xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("UpdateRecurringPaymentsProfileResponseDetails").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("UpdateRecurringPaymentsProfileResponseDetails")[0])){ 
		 nodeList = document.GetElementsByTagName("UpdateRecurringPaymentsProfileResponseDetails");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.UpdateRecurringPaymentsProfileResponseDetails =  new UpdateRecurringPaymentsProfileResponseDetailsType(xmlString);

}
	}
	}
	}


	public enum UserSelectedFundingSourceType {
[Description("ELV")]ELV,
[Description("CreditCard")]CREDITCARD,
[Description("ChinaUnionPay")]CHINAUNIONPAY,
[Description("BML")]BML,
	}
	/**
	 * Information on user selected options
	 */
	public partial class UserSelectedOptionType {

		private string ShippingCalculationModeField;
		public string ShippingCalculationMode {
			get {
				return this.ShippingCalculationModeField;
			}
			set {
				this.ShippingCalculationModeField = value;
			}
		}

		private string InsuranceOptionSelectedField;
		public string InsuranceOptionSelected {
			get {
				return this.InsuranceOptionSelectedField;
			}
			set {
				this.InsuranceOptionSelectedField = value;
			}
		}

		private string ShippingOptionIsDefaultField;
		public string ShippingOptionIsDefault {
			get {
				return this.ShippingOptionIsDefaultField;
			}
			set {
				this.ShippingOptionIsDefaultField = value;
			}
		}

		private BasicAmountType ShippingOptionAmountField;
		public BasicAmountType ShippingOptionAmount {
			get {
				return this.ShippingOptionAmountField;
			}
			set {
				this.ShippingOptionAmountField = value;
			}
		}

		private string ShippingOptionNameField;
		public string ShippingOptionName {
			get {
				return this.ShippingOptionNameField;
			}
			set {
				this.ShippingOptionNameField = value;
			}
		}

		public UserSelectedOptionType() {
		}

	public string toXMLString()  {
		StringBuilder sb = new StringBuilder();
		if( ShippingCalculationMode != null ) {
			sb.Append("<ebl:ShippingCalculationMode>").Append(ShippingCalculationMode);
			sb.Append("</ebl:ShippingCalculationMode>");
		}
		if( InsuranceOptionSelected != null ) {
			sb.Append("<ebl:InsuranceOptionSelected>").Append(InsuranceOptionSelected);
			sb.Append("</ebl:InsuranceOptionSelected>");
		}
		if( ShippingOptionIsDefault != null ) {
			sb.Append("<ebl:ShippingOptionIsDefault>").Append(ShippingOptionIsDefault);
			sb.Append("</ebl:ShippingOptionIsDefault>");
		}
		if( ShippingOptionAmount != null ) {
			sb.Append("<ebl:ShippingOptionAmount ");
			sb.Append(ShippingOptionAmount.toXMLString());
			sb.Append("</ebl:ShippingOptionAmount>");
		}
		if( ShippingOptionName != null ) {
			sb.Append("<ebl:ShippingOptionName>").Append(ShippingOptionName);
			sb.Append("</ebl:ShippingOptionName>");
		}
		return sb.ToString();
	}

	 public UserSelectedOptionType(Object xmlSoap) {
		XmlDocument document=new XmlDocument();
		document.LoadXml(xmlSoap.ToString());
		XmlNodeList nodeList=null;
		 string xmlString ="";
		 if(document.GetElementsByTagName("ShippingCalculationMode").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ShippingCalculationMode")[0])){ 
		 this.ShippingCalculationMode =(string)document.GetElementsByTagName("ShippingCalculationMode")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("InsuranceOptionSelected").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("InsuranceOptionSelected")[0])){ 
		 this.InsuranceOptionSelected =(string)document.GetElementsByTagName("InsuranceOptionSelected")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ShippingOptionIsDefault").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ShippingOptionIsDefault")[0])){ 
		 this.ShippingOptionIsDefault =(string)document.GetElementsByTagName("ShippingOptionIsDefault")[0].InnerText;

}
	}
		 if(document.GetElementsByTagName("ShippingOptionAmount").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ShippingOptionAmount")[0])){ 
		 nodeList = document.GetElementsByTagName("ShippingOptionAmount");
			 xmlString = DeserializationUtils.convertToXML(nodeList[0]); 
			 this.ShippingOptionAmount =  new BasicAmountType(xmlString);

}
	}
		 if(document.GetElementsByTagName("ShippingOptionName").Count!=0){		 if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ShippingOptionName")[0])){ 
		 this.ShippingOptionName =(string)document.GetElementsByTagName("ShippingOptionName")[0].InnerText;

}
	}
	}
	}


	public enum UserWithdrawalLimitTypeType {
[Description("Unknown")]UNKNOWN,
[Description("Limited")]LIMITED,
[Description("Unlimited")]UNLIMITED,
	}
}
