/**
  * Stub objects for PayPalAPIInterfaceService 
  * AUTO_GENERATED_CODE 
  */
using System;
using System.Text;
using System.Web;
using System.Xml;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using PayPal.Util;

namespace PayPal.PayPalAPIInterfaceService.Model
{

	public class EnumUtils
	{
		public static string getDescription(Enum value)
		{
			string description = "";
			DescriptionAttribute[] attributes = (DescriptionAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
			{
				description= attributes[0].Description;
			}
			return description;
		}
		
		public static object getValue(String value,Type enumType)
		{
			string[] names = Enum.GetNames(enumType);
			foreach(string name in names)
            {
            	if (getDescription((Enum)Enum.Parse(enumType, name)).Equals(value))
            	{
					return Enum.Parse(enumType, name);
				}
			}
			return null;
		}
	}

	public class DeserializationUtils
	{
		public static bool isWhiteSpaceNode(XmlNode n)
		{
			if (n.NodeType == XmlNodeType.Text)
			{
				string val = n.InnerText;
				return val.Trim().Length == 0;
			}
			else
			{
				return false;
			}
		}
		
		public static string convertToXML(XmlNode n)
        {
            string name = n.Name;
            if (XmlNodeType.CDATA == n.NodeType)
            {
                return "$lt;![CDATA[" + n.Value + "]]&gt;";
            }
            if (name.StartsWith("#"))
            {
                return "";
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("<").Append(name);
            XmlNamedNodeMap attrs = n.Attributes;
            if (attrs != null)
            {
                for (int i = 0; i < attrs.Count; i++)
                {
                    XmlNode attr = attrs.Item(i);
                    if (!attr.Value.Contains(":"))
                        sb.Append(" ").Append(attr.Name).Append("=\"").Append(attr.Value).Append("\"");
                }
            }
            string textContent = null;
            XmlNodeList children = n.ChildNodes;
            if (children.Count == 0)
            {
                if (((textContent = n.InnerText) != null) && (!"".Equals(textContent)))
                {
                    sb.Append(textContent).Append("</").Append(name).Append(">");
                }
                else
                {
                    sb.Append("/>");
                }
            }
            else
            {
                sb.Append(">");
                bool hasValidChildren = false;
                for (int i = 0; i < children.Count; i++)
                {
                    string childToString = DeserializationUtils.convertToXML(children[i]);
                    if (!"".Equals(childToString))
                    {
                        sb.Append(childToString);
                        hasValidChildren = true;
                    }
                }
                if ((!hasValidChildren) && ((textContent = n.InnerText) != null))
                {
                    sb.Append(textContent);
                }
                sb.Append("</").Append(name).Append(">");
            }
            return sb.ToString();
        }
	}


	/**
      *On requests, you must set the currencyID attribute to one of
      *the three-character currency codes for any of the supported
      *PayPal currencies. Limitations: Must not exceed $10,000 USD
      *in any currency. No currency symbol. Decimal separator must
      *be a period (.), and the thousands separator must be a comma
      *(,).
      */
	public partial class BasicAmountType	
	{

		/**
          *No Document Comments
		  */
		private CurrencyCodeType? currencyIDField;
		public CurrencyCodeType? currencyID
		{
			get
			{
				return this.currencyIDField;
			}
			set
			{
				this.currencyIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string valueField;
		public string value
		{
			get
			{
				return this.valueField;
			}
			set
			{
				this.valueField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public BasicAmountType(CurrencyCodeType? currencyID, string value){
			this.currencyID = currencyID;
			this.value = value;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public BasicAmountType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(currencyID != null)
			{
				sb.Append(" currencyID=\"").Append(EnumUtils.getDescription(currencyID)).Append("\">");
			}
			if(value != null)
			{
				sb.Append(value);
			}
			return sb.ToString();
		}
		public BasicAmountType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			this.currencyID = (CurrencyCodeType)EnumUtils.getValue(document.ChildNodes[0].Attributes.GetNamedItem("currencyID").Value, typeof(CurrencyCodeType));
		this.value = (string)document.ChildNodes[0].InnerText;
	
		}
		
	}




	/**
      *
      */
	public partial class MeasureType	
	{

		/**
          *No Document Comments
		  */
		private string unitField;
		public string unit
		{
			get
			{
				return this.unitField;
			}
			set
			{
				this.unitField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private decimal? valueField;
		public decimal? value
		{
			get
			{
				return this.valueField;
			}
			set
			{
				this.valueField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public MeasureType(string unit, decimal? value){
			this.unit = unit;
			this.value = value;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public MeasureType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(unit != null)
			{
				sb.Append("<cc:unit>").Append(unit);
				sb.Append("</cc:unit>");
			}
			if(value != null)
			{
				sb.Append(value);
			}
			return sb.ToString();
		}
		public MeasureType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("unit").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("unit")[0]))
			{
				this.unit = (string)document.GetElementsByTagName("unit")[0].InnerText;
			}
		}
		this.value = System.Convert.ToDecimal(document.ChildNodes[0].InnerText);
	
		}
		
	}




	/**
      * AckCodeType
      *    This code identifies the acknowledgement code types that
      *
      *    could be used to communicate the status of processing a 
      *    (request) message to an application. This code would be
      *used 
      *    as part of a response message that contains an
      *application 
      *    level acknowledgement element.
      * 
      */
	public enum AckCodeType {
		[Description("Success")]SUCCESS,	
		[Description("Failure")]FAILURE,	
		[Description("Warning")]WARNING,	
		[Description("SuccessWithWarning")]SUCCESSWITHWARNING,	
		[Description("FailureWithWarning")]FAILUREWITHWARNING,	
		[Description("PartialSuccess")]PARTIALSUCCESS,	
		[Description("CustomCode")]CUSTOMCODE	
	}




	/**
      * AddressOwnerCodeType
      *    This code identifies the AddressOwner code types which
      *indicates
      *    who owns the user'a address.
      * 
      */
	public enum AddressOwnerCodeType {
		[Description("PayPal")]PAYPAL,	
		[Description("eBay")]EBAY,	
		[Description("CustomCode")]CUSTOMCODE	
	}




	/**
      * CountryCodeType
      *   This code list module defines the enumerated types
      *    of standard 2-letter ISO 3166 country codes. This
      *codelist
      *    contains some additional country code not defined in
      *    the ISO 3166 country code set. 
      * 
      */
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
		[Description("TL")]TL	
	}




	/**
      * ISO 4217 standard 3-letter currency code. 
      *
      * 
      *The following currencies are supported by PayPal.
      *
      * Code
      * CurrencyMaximum Transaction Amount
      * 
      * AUD
      * Australian Dollar 
      * 12,500 AUD
      * 
      * 
      * CAD
      * Canadian Dollar12,500 CAD
      * 
      * 
      * EUR
      * Euro
      *  8,000 EUR
      * 
      * 
      * GBP
      * Pound Sterling
      *   5,500 GBP
      * 
      * 
      * JPY
      * Japanese Yen
      * 1,000,000 JPY
      * 
      * 
      * USD
      *  U.S. Dollar
      * 10,000 USD
      * 
      * 
      * CHF
      *  Czech Koruna
      * 70,000 CHF
      * 
      * 
      * SEK
      *  Swedish Krona
      * 3,50,000 SEK
      * 
      * 
      * NOK
      *  Norwegian Krone
      * 4,00,000 NOK
      * 
      * 
      * DKK
      *  Danish Krone
      * 3,00,000 DKK
      * 
      * 
      * PLN
      *  Poland Zloty
      * 1,60,000 PLN
      * 
      * 
      * HUF
      *  Hungary Forint
      * 110,00,000 HUF
      * 
      * 
      * SGD
      *  Singapore Dollar
      * 80,000 SGD
      * 
      * 
      * HKD
      *  HongKong Dollar
      * 3,80,000 HKD
      * 
      * 
      * NZD
      *  New Zealand Dollar
      * 77,000 NZD
      * 
      * 
      * CZK
      *  Czech Koruna
      * 1,20,000 CZK
      * 
      * 
      * 
      */
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
		[Description("CustomCode")]CUSTOMCODE	
	}




	/**
      * DetailLevelCodeType   
      * 
      */
	public enum DetailLevelCodeType {
		[Description("ReturnAll")]RETURNALL,	
		[Description("ItemReturnDescription")]ITEMRETURNDESCRIPTION,	
		[Description("ItemReturnAttributes")]ITEMRETURNATTRIBUTES	
	}




	/**
      * This defines if the incentive is applied on Ebay or PayPal.
      *            
      */
	public enum IncentiveSiteAppliedOnType {
		[Description("INCENTIVE-SITE-APPLIED-ON-UNKNOWN")]INCENTIVESITEAPPLIEDONUNKNOWN,	
		[Description("INCENTIVE-SITE-APPLIED-ON-MERCHANT")]INCENTIVESITEAPPLIEDONMERCHANT,	
		[Description("INCENTIVE-SITE-APPLIED-ON-PAYPAL")]INCENTIVESITEAPPLIEDONPAYPAL	
	}




	/**
      * This defines if the incentive is applied successfully or
      *not.
      *            
      */
	public enum IncentiveAppliedStatusType {
		[Description("INCENTIVE-APPLIED-STATUS-SUCCESS")]INCENTIVEAPPLIEDSTATUSSUCCESS,	
		[Description("INCENTIVE-APPLIED-STATUS-ERROR")]INCENTIVEAPPLIEDSTATUSERROR	
	}




	/**
      * PaymentReasonType
      * This is the Payment Reason type (used by DoRT and SetEC for
      *Refund of PI transaction, eBay return shipment, external
      *dispute)
      * 
      */
	public enum PaymentReasonType {
		[Description("None")]NONE,	
		[Description("Refund")]REFUND,	
		[Description("ReturnShipment")]RETURNSHIPMENT	
	}




	/**
      * SeverityCodeType
      *    This code identifies the Severity code types in terms of
      *whether
      *    there is an API-level error or warning that needs to be
      *communicated
      *    to the client.
      * 
      */
	public enum SeverityCodeType {
		[Description("Warning")]WARNING,	
		[Description("Error")]ERROR,	
		[Description("PartialSuccess")]PARTIALSUCCESS,	
		[Description("CustomCode")]CUSTOMCODE	
	}




	/**
      * ShippingServiceCodeType
      *      These are the possible codes to describe insurance
      *option as part of shipping
      *      service.
      * 
      */
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
		[Description("CustomCode")]CUSTOMCODE	
	}




	/**
      * Type declaration to be used by other schemas.
      * This is the credit card type
      * 
      */
	public enum CreditCardTypeType {
		[Description("Visa")]VISA,	
		[Description("MasterCard")]MASTERCARD,	
		[Description("Discover")]DISCOVER,	
		[Description("Amex")]AMEX,	
		[Description("Switch")]SWITCH,	
		[Description("Solo")]SOLO,	
		[Description("Maestro")]MAESTRO	
	}




	/**
      * RefundType - Type declaration to be used by other 
      * schema. This code identifies the types of refund
      *transactions 
      * supported.
      * 
      */
	public enum RefundType {
		[Description("Other")]OTHER,	
		[Description("Full")]FULL,	
		[Description("Partial")]PARTIAL,	
		[Description("ExternalDispute")]EXTERNALDISPUTE	
	}




	/**
      * Based on NRF-ARTS Specification for Units of Measure
      * 
      */
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
		[Description("RESERVED")]RESERVED	
	}




	/**
      *
      */
	public enum RedeemedOfferType {
		[Description("MERCHANT_COUPON")]MERCHANTCOUPON,	
		[Description("LOYALTY_CARD")]LOYALTYCARD,	
		[Description("MANUFACTURER_COUPON")]MANUFACTURERCOUPON,	
		[Description("RESERVED")]RESERVED	
	}




	/**
      *Supported API Types for DoCancel operation
      */
	public enum APIType {
		[Description("CHECKOUT_AUTHORIZATION")]CHECKOUTAUTHORIZATION,	
		[Description("CHECKOUT_SALE")]CHECKOUTSALE	
	}




	/**
      * IncentiveRequestType 
      * This identifies the type of request for the API call. The
      *type of request may be used to determine whether the request
      *is for evaluating incentives in pre-checkout or in-checkout
      *phase.
      * 
      */
	public enum IncentiveRequestCodeType {
		[Description("InCheckout")]INCHECKOUT,	
		[Description("PreCheckout")]PRECHECKOUT	
	}




	/**
      * IncentiveRequestDetailLevelType 
      * This identifies the granularity of information requested by
      *the client application. This information will be used to
      *define the contents and details of the response.
      * 
      */
	public enum IncentiveRequestDetailLevelCodeType {
		[Description("Aggregated")]AGGREGATED,	
		[Description("Detail")]DETAIL	
	}




	/**
      * IncentiveType 
      * This identifies the type of INCENTIVE for the redemption
      *code.
      * 
      */
	public enum IncentiveTypeCodeType {
		[Description("Coupon")]COUPON,	
		[Description("eBayGiftCertificate")]EBAYGIFTCERTIFICATE,	
		[Description("eBayGiftCard")]EBAYGIFTCARD,	
		[Description("PayPalRewardVoucher")]PAYPALREWARDVOUCHER,	
		[Description("MerchantGiftCertificate")]MERCHANTGIFTCERTIFICATE,	
		[Description("eBayRewardVoucher")]EBAYREWARDVOUCHER	
	}




	/**
      * PaymentTransactionCodeType 
      * This is the type of a PayPal of which matches the output
      *from IPN
      * 
      */
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
		[Description("credit")]CREDIT	
	}




	/**
      * PaymentStatusCodeType 
      * This is the status of a PayPal Payment which matches the
      *output from IPN
      * 
      */
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
		[Description("Delayed")]DELAYED	
	}




	/**
      * AddressStatusCodeType 
      * This is the PayPal address status
      * 
      */
	public enum AddressStatusCodeType {
		[Description("None")]NONE,	
		[Description("Confirmed")]CONFIRMED,	
		[Description("Unconfirmed")]UNCONFIRMED	
	}




	/**
      * PaymentDetailsCodeType 
      * This is the PayPal payment details type (used by DCC and
      *Express Checkout)
      * 
      */
	public enum PaymentActionCodeType {
		[Description("None")]NONE,	
		[Description("Authorization")]AUTHORIZATION,	
		[Description("Sale")]SALE,	
		[Description("Order")]ORDER	
	}




	/**
      * This is various actions that a merchant can take on a FMF
      *Pending Transaction.
      * 
      */
	public enum FMFPendingTransactionActionType {
		[Description("Accept")]ACCEPT,	
		[Description("Deny")]DENY	
	}




	/**
      * ChannelType - Type declaration to be used by other schemas.
      * This is the PayPal Channel type (used by Express Checkout)
      * 
      */
	public enum ChannelType {
		[Description("Merchant")]MERCHANT,	
		[Description("eBayItem")]EBAYITEM	
	}




	/**
      * TotalType - Type declaration for the label to be displayed
      * in MiniCart for UX.
      * 
      */
	public enum TotalType {
		[Description("Total")]TOTAL,	
		[Description("EstimatedTotal")]ESTIMATEDTOTAL	
	}




	/**
      * SolutionTypeType 
      * This is the PayPal payment Solution details type (used by
      *Express Checkout)
      * 
      */
	public enum SolutionTypeType {
		[Description("Mark")]MARK,	
		[Description("Sole")]SOLE	
	}




	/**
      * AllowedPaymentMethodType
      * This is the payment Solution merchant needs to specify for
      *Autopay (used by Express Checkout)
      * Optional
      * Default indicates that its merchant supports all funding
      *source
      * InstantPaymentOnly indicates that its merchant only
      *supports instant payment
      * AnyFundingSource allow all funding methods to be chosen by
      *the buyer irrespective of merchant's profile setting
      * InstantFundingSource allow only instant funding methods,
      *block echeck, meft, elevecheck. This will override any
      *merchant profile setting
      * 
      */
	public enum AllowedPaymentMethodType {
		[Description("Default")]DEFAULT,	
		[Description("InstantPaymentOnly")]INSTANTPAYMENTONLY,	
		[Description("AnyFundingSource")]ANYFUNDINGSOURCE,	
		[Description("InstantFundingSource")]INSTANTFUNDINGSOURCE	
	}




	/**
      * LandingPageType 
      * This is the PayPal payment Landing Page details type (used
      *by Express Checkout)
      * 
      */
	public enum LandingPageType {
		[Description("None")]NONE,	
		[Description("Login")]LOGIN,	
		[Description("Billing")]BILLING	
	}




	/**
      * 
      */
	public enum BillingCodeType {
		[Description("None")]NONE,	
		[Description("MerchantInitiatedBilling")]MERCHANTINITIATEDBILLING,	
		[Description("RecurringPayments")]RECURRINGPAYMENTS,	
		[Description("MerchantInitiatedBillingSingleAgreement")]MERCHANTINITIATEDBILLINGSINGLEAGREEMENT,	
		[Description("ChannelInitiatedBilling")]CHANNELINITIATEDBILLING	
	}




	/**
      * 
      */
	public enum ApprovalTypeType {
		[Description("BillingAgreement")]BILLINGAGREEMENT,	
		[Description("Profile")]PROFILE	
	}




	/**
      * 
      */
	public enum ApprovalSubTypeType {
		[Description("None")]NONE,	
		[Description("MerchantInitiatedBilling")]MERCHANTINITIATEDBILLING	
	}




	/**
      * PendingStatusCodeType 
      * The pending status for a PayPal Payment transaction which
      *matches the output from IPN
      * 
      */
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
		[Description("payment-review")]PAYMENTREVIEW	
	}




	/**
      * ReceiverInfoCodeType 
      * Payee identifier type for MassPay API
      * 
      */
	public enum ReceiverInfoCodeType {
		[Description("EmailAddress")]EMAILADDRESS,	
		[Description("UserID")]USERID,	
		[Description("PhoneNumber")]PHONENUMBER	
	}




	/**
      * ReversalReasonCodeType 
      * Reason for a reversal on a PayPal transaction which matches
      *the output from IPN
      * 
      */
	public enum ReversalReasonCodeType {
		[Description("none")]NONE,	
		[Description("chargeback")]CHARGEBACK,	
		[Description("guarantee")]GUARANTEE,	
		[Description("buyer-complaint")]BUYERCOMPLAINT,	
		[Description("refund")]REFUND,	
		[Description("other")]OTHER	
	}




	/**
      * PaymentCodeType 
      * This is the type of PayPal payment which matches the output
      *from IPN.
      * 
      */
	public enum PaymentCodeType {
		[Description("none")]NONE,	
		[Description("echeck")]ECHECK,	
		[Description("instant")]INSTANT	
	}




	/**
      * RefundSourceCodeType
      * This is the type of PayPal funding source that can be used
      *for auto refund.
      * any - Means Merchant doesn't have any preference. PayPal
      *can use any available funding source (Balance or eCheck)
      * default - Means merchant's preferred funding source as
      *configured in his profile. (Balance or eCheck)
      * instant - Only Balance
      * echeck - Merchant prefers echeck. If PayPal balance can
      *cover the refund amount, we will use PayPal balance.
      *(balance or eCheck)
      * 
      */
	public enum RefundSourceCodeType {
		[Description("any")]ANY,	
		[Description("default")]DEFAULT,	
		[Description("instant")]INSTANT,	
		[Description("echeck")]ECHECK	
	}




	/**
      * PayPalUserStatusCodeType 
      * PayPal status of a user Address
      * 
      */
	public enum PayPalUserStatusCodeType {
		[Description("verified")]VERIFIED,	
		[Description("unverified")]UNVERIFIED	
	}




	/**
      * MerchantPullPaymentCodeType 
      * Type of Payment to be initiated by the merchant
      * 
      */
	public enum MerchantPullPaymentCodeType {
		[Description("Any")]ANY,	
		[Description("InstantOnly")]INSTANTONLY,	
		[Description("EcheckOnly")]ECHECKONLY	
	}




	/**
      * MerchantPullStatusCodeType 
      * Status of the merchant pull
      * 
      */
	public enum MerchantPullStatusCodeType {
		[Description("Active")]ACTIVE,	
		[Description("Canceled")]CANCELED	
	}




	/**
      * PaymentTransactionStatusCodeType 
      * The status of the PayPal payment.
      * 
      */
	public enum PaymentTransactionStatusCodeType {
		[Description("Pending")]PENDING,	
		[Description("Processing")]PROCESSING,	
		[Description("Success")]SUCCESS,	
		[Description("Denied")]DENIED,	
		[Description("Reversed")]REVERSED	
	}




	/**
      * PaymentTransactionClassCodeType 
      * The Type of PayPal payment.
      * 
      */
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
		[Description("ECheck")]ECHECK	
	}




	/**
      * MatchStatusCodeType 
      * This is the PayPal (street/zip) match code
      * 
      */
	public enum MatchStatusCodeType {
		[Description("None")]NONE,	
		[Description("Matched")]MATCHED,	
		[Description("Unmatched")]UNMATCHED	
	}




	/**
      * CompleteCodeType 
      * This is the PayPal DoCapture CompleteType code
      * 
      */
	public enum CompleteCodeType {
		[Description("NotComplete")]NOTCOMPLETE,	
		[Description("Complete")]COMPLETE	
	}




	/**
      * TransactionEntityType 
      * This is the PayPal DoAuthorization TransactionEntityType
      *code
      * 
      */
	public enum TransactionEntityType {
		[Description("None")]NONE,	
		[Description("Auth")]AUTH,	
		[Description("Reauth")]REAUTH,	
		[Description("Order")]ORDER,	
		[Description("Payment")]PAYMENT	
	}




	/**
      * MobileRecipientCodeType 
      * These are the accepted types of recipients for
      *mobile-originated transactions
      * 
      */
	public enum MobileRecipientCodeType {
		[Description("PhoneNumber")]PHONENUMBER,	
		[Description("EmailAddress")]EMAILADDRESS	
	}




	/**
      * MobilePaymentCodeType 
      * These are the accepted types of mobile payments
      * 
      */
	public enum MobilePaymentCodeType {
		[Description("P2P")]PP,	
		[Description("HardGoods")]HARDGOODS,	
		[Description("Donation")]DONATION,	
		[Description("TopUp")]TOPUP	
	}




	/**
      * MarketingCategoryType 
      * 
      */
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
		[Description("Marketing-Category20")]MARKETINGCATEGORY20	
	}




	/**
      * BusinessTypeType
      * 
      */
	public enum BusinessTypeType {
		[Description("Unknown")]UNKNOWN,	
		[Description("Individual")]INDIVIDUAL,	
		[Description("Proprietorship")]PROPRIETORSHIP,	
		[Description("Partnership")]PARTNERSHIP,	
		[Description("Corporation")]CORPORATION,	
		[Description("Nonprofit")]NONPROFIT,	
		[Description("Government")]GOVERNMENT	
	}




	/**
      * BusinessCategoryType 
      * 
      */
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
		[Description("Other-Categories")]OTHERCATEGORIES	
	}




	/**
      * BusinessSubCategoryType 
      * 
      */
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
		[Description("Other-SubCategories")]OTHERSUBCATEGORIES	
	}




	/**
      * AverageTransactionPriceType
      * 
      * 
      * 
      * 
      * Enumeration
      * Meaning
      * 
      * 
      * 
      * 
      * AverageTransactionPrice-Not-Applicable 
      *
      * AverageTransactionPrice-Range1
      * Less than $25 USD
      * 
      * 
      * AverageTransactionPrice-Range2
      * $25 USD to $50 USD
      * 
      * 
      * AverageTransactionPrice-Range3
      * $50 USD to $100 USD
      * 
      * 
      * AverageTransactionPrice-Range4
      * $100 USD to $250 USD
      * 
      * 
      * AverageTransactionPrice-Range5
      * $250 USD to $500 USD
      * 
      * 
      * AverageTransactionPrice-Range6
      * $500 USD to $1,000 USD
      * 
      * 
      * AverageTransactionPrice-Range7
      * $1,000 USD to $2,000 USD
      * 
      * 
      * AverageTransactionPrice-Range8
      * $2,000 USD to $5,000 USD
      * 
      * 
      * AverageTransactionPrice-Range9
      * $5,000 USD to $10,000 USD
      * 
      * 
      * AverageTransactionPrice-Range10
      * More than $10,000 USD
      * 
      * 
      * 
      */
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
		[Description("AverageTransactionPrice-Range10")]AVERAGETRANSACTIONPRICERANGE10	
	}




	/**
      * AverageMonthlyVolumeType 
      * 
      * 
      * Enumeration
      * Meaning
      * 
      * 
      * AverageMonthlyVolume-Not-Applicable
      * 
      * 
      * 
      * AverageMonthlyVolume-Range1
      * Less than $1,000 USD
      * 
      * 
      * AverageMonthlyVolume-Range2
      * $1,000 USD to $5,000 USD
      * 
      * 
      * AverageMonthlyVolume-Range3
      * $5,000 USD to $25,000 USD
      * 
      * 
      * AverageMonthlyVolume-Range4
      * $25,000 USD to $100,000 USD
      * 
      * 
      * AverageMonthlyVolume-Range5
      * $100,000 USD to $1,000,000 USD
      * 
      * 
      * AverageMonthlyVolume-Range6
      * More than $1,000,000 USD
      * 
      * 
      * 
      */
	public enum AverageMonthlyVolumeType {
		[Description("AverageMonthlyVolume-Not-Applicable")]AVERAGEMONTHLYVOLUMENOTAPPLICABLE,	
		[Description("AverageMonthlyVolume-Range1")]AVERAGEMONTHLYVOLUMERANGE1,	
		[Description("AverageMonthlyVolume-Range2")]AVERAGEMONTHLYVOLUMERANGE2,	
		[Description("AverageMonthlyVolume-Range3")]AVERAGEMONTHLYVOLUMERANGE3,	
		[Description("AverageMonthlyVolume-Range4")]AVERAGEMONTHLYVOLUMERANGE4,	
		[Description("AverageMonthlyVolume-Range5")]AVERAGEMONTHLYVOLUMERANGE5,	
		[Description("AverageMonthlyVolume-Range6")]AVERAGEMONTHLYVOLUMERANGE6	
	}




	/**
      * SalesVenueType 
      * 
      */
	public enum SalesVenueType {
		[Description("Venue-Unspecified")]VENUEUNSPECIFIED,	
		[Description("eBay")]EBAY,	
		[Description("AnotherMarketPlace")]ANOTHERMARKETPLACE,	
		[Description("OwnWebsite")]OWNWEBSITE,	
		[Description("Other")]OTHER	
	}




	/**
      * PercentageRevenueFromOnlineSalesType
      * 
      * 
      * 
      * 
      * Enumeration
      * Meaning
      * 
      * 
      * 
      * 
      * PercentageRevenueFromOnlineSales-Not-Applicable 
      *
      * PercentageRevenueFromOnlineSales-Range1
      * Less than 25%
      * 
      * 
      * PercentageRevenueFromOnlineSales-Range2
      * 25% to 50%
      * 
      * 
      * PercentageRevenueFromOnlineSales-Range3
      * 50% to 75%
      * 
      * 
      * PercentageRevenueFromOnlineSales-Range4
      * 75% to 100%
      * 
      * 
      * 
      */
	public enum PercentageRevenueFromOnlineSalesType {
		[Description("PercentageRevenueFromOnlineSales-Not-Applicable")]PERCENTAGEREVENUEFROMONLINESALESNOTAPPLICABLE,	
		[Description("PercentageRevenueFromOnlineSales-Range1")]PERCENTAGEREVENUEFROMONLINESALESRANGE1,	
		[Description("PercentageRevenueFromOnlineSales-Range2")]PERCENTAGEREVENUEFROMONLINESALESRANGE2,	
		[Description("PercentageRevenueFromOnlineSales-Range3")]PERCENTAGEREVENUEFROMONLINESALESRANGE3,	
		[Description("PercentageRevenueFromOnlineSales-Range4")]PERCENTAGEREVENUEFROMONLINESALESRANGE4	
	}




	/**
      * BankAccountTypeType 
      * 
      */
	public enum BankAccountTypeType {
		[Description("Checking")]CHECKING,	
		[Description("Savings")]SAVINGS	
	}




	/**
      * Boarding Status 
      * 
      */
	public enum BoardingStatusType {
		[Description("Unknown")]UNKNOWN,	
		[Description("Completed")]COMPLETED,	
		[Description("Cancelled")]CANCELLED,	
		[Description("Pending")]PENDING	
	}




	/**
      * User Withdrawal Limit Type Type 
      * 
      */
	public enum UserWithdrawalLimitTypeType {
		[Description("Unknown")]UNKNOWN,	
		[Description("Limited")]LIMITED,	
		[Description("Unlimited")]UNLIMITED	
	}




	/**
      * API Authentication Type 
      * 
      */
	public enum APIAuthenticationType {
		[Description("Auth-None")]AUTHNONE,	
		[Description("Cert")]CERT,	
		[Description("Sign")]SIGN	
	}




	/**
      * 
      */
	public enum RecurringPaymentsProfileStatusType {
		[Description("ActiveProfile")]ACTIVEPROFILE,	
		[Description("PendingProfile")]PENDINGPROFILE,	
		[Description("CancelledProfile")]CANCELLEDPROFILE,	
		[Description("ExpiredProfile")]EXPIREDPROFILE,	
		[Description("SuspendedProfile")]SUSPENDEDPROFILE	
	}




	/**
      * 
      */
	public enum FailedPaymentActionType {
		[Description("CancelOnFailure")]CANCELONFAILURE,	
		[Description("ContinueOnFailure")]CONTINUEONFAILURE	
	}




	/**
      * 
      */
	public enum AutoBillType {
		[Description("NoAutoBill")]NOAUTOBILL,	
		[Description("AddToNextBilling")]ADDTONEXTBILLING	
	}




	/**
      * 
      */
	public enum StatusChangeActionType {
		[Description("Cancel")]CANCEL,	
		[Description("Suspend")]SUSPEND,	
		[Description("Reactivate")]REACTIVATE	
	}




	/**
      * 
      */
	public enum BillingPeriodType {
		[Description("NoBillingPeriodType")]NOBILLINGPERIODTYPE,	
		[Description("Day")]DAY,	
		[Description("Week")]WEEK,	
		[Description("SemiMonth")]SEMIMONTH,	
		[Description("Month")]MONTH,	
		[Description("Year")]YEAR	
	}




	/**
      * 
      */
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
		[Description("Software")]SOFTWARE	
	}




	/**
      * Types of button coding
      * 
      */
	public enum ButtonCodeType {
		[Description("HOSTED")]HOSTED,	
		[Description("ENCRYPTED")]ENCRYPTED,	
		[Description("CLEARTEXT")]CLEARTEXT,	
		[Description("TOKEN")]TOKEN	
	}




	/**
      * Types of buttons
      * 
      */
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
		[Description("PAYMENT")]PAYMENT	
	}




	/**
      * Types of button sub types
      * 
      */
	public enum ButtonSubTypeType {
		[Description("PRODUCTS")]PRODUCTS,	
		[Description("SERVICES")]SERVICES	
	}




	/**
      * Types of button images
      * 
      */
	public enum ButtonImageType {
		[Description("REG")]REG,	
		[Description("SML")]SML,	
		[Description("CC")]CC	
	}




	/**
      * values for buynow button text
      * 
      */
	public enum BuyNowTextType {
		[Description("BUYNOW")]BUYNOW,	
		[Description("PAYNOW")]PAYNOW	
	}




	/**
      * values for subscribe button text
      * 
      */
	public enum SubscribeTextType {
		[Description("BUYNOW")]BUYNOW,	
		[Description("SUBSCRIBE")]SUBSCRIBE	
	}




	/**
      * values for subscribe button text
      * 
      */
	public enum ButtonStatusType {
		[Description("DELETE")]DELETE	
	}




	/**
      * 
      */
	public enum OptionTypeListType {
		[Description("NoOptionType")]NOOPTIONTYPE,	
		[Description("FULL")]FULL,	
		[Description("EMI")]EMI,	
		[Description("VARIABLE")]VARIABLE	
	}




	/**
      * UserSelectedFundingSourceType
      * User Selected Funding Source (used by Express Checkout)
      * 
      */
	public enum UserSelectedFundingSourceType {
		[Description("ELV")]ELV,	
		[Description("CreditCard")]CREDITCARD,	
		[Description("ChinaUnionPay")]CHINAUNIONPAY,	
		[Description("BML")]BML	
	}




	/**
      * 
      */
	public enum ItemCategoryType {
		[Description("Physical")]PHYSICAL,	
		[Description("Digital")]DIGITAL	
	}




	/**
      * 
      */
	public enum RecurringFlagType {
		[Description("Y")]Y1,	
		[Description("y")]Y2	
	}




	/**
      *Value of the application-specific error parameter.  
      */
	public partial class ErrorParameterType	
	{

		/**
          *No Document Comments
		  */
		private string ValueField;
		public string Value
		{
			get
			{
				return this.ValueField;
			}
			set
			{
				this.ValueField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public ErrorParameterType(){
		}


		public ErrorParameterType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("Value").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Value")[0]))
			{
				this.Value = (string)document.GetElementsByTagName("Value")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *Error code can be used by a receiving application to
      *debugging a response message. These codes will need to be
      *uniquely defined for each application. 
      */
	public partial class ErrorType	
	{

		/**
          *No Document Comments
		  */
		private string ShortMessageField;
		public string ShortMessage
		{
			get
			{
				return this.ShortMessageField;
			}
			set
			{
				this.ShortMessageField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string LongMessageField;
		public string LongMessage
		{
			get
			{
				return this.LongMessageField;
			}
			set
			{
				this.LongMessageField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ErrorCodeField;
		public string ErrorCode
		{
			get
			{
				return this.ErrorCodeField;
			}
			set
			{
				this.ErrorCodeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private SeverityCodeType? SeverityCodeField;
		public SeverityCodeType? SeverityCode
		{
			get
			{
				return this.SeverityCodeField;
			}
			set
			{
				this.SeverityCodeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<ErrorParameterType> ErrorParametersField = new List<ErrorParameterType>();
		public List<ErrorParameterType> ErrorParameters
		{
			get
			{
				return this.ErrorParametersField;
			}
			set
			{
				this.ErrorParametersField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public ErrorType(){
		}


		public ErrorType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("ShortMessage").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ShortMessage")[0]))
			{
				this.ShortMessage = (string)document.GetElementsByTagName("ShortMessage")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("LongMessage").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("LongMessage")[0]))
			{
				this.LongMessage = (string)document.GetElementsByTagName("LongMessage")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ErrorCode").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ErrorCode")[0]))
			{
				this.ErrorCode = (string)document.GetElementsByTagName("ErrorCode")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("SeverityCode").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SeverityCode")[0]))
				{
					this.SeverityCode = (SeverityCodeType)EnumUtils.getValue(document.GetElementsByTagName("SeverityCode")[0].InnerText,typeof(SeverityCodeType));
				}
			}
			if(document.GetElementsByTagName("ErrorParameters").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ErrorParameters")[0]))
				{
					nodeList = document.GetElementsByTagName("ErrorParameters");
					for(int i = 0; i < nodeList.Count; i++)
					{
						xmlString = DeserializationUtils.convertToXML(nodeList[i]);
						this.ErrorParameters.Add(new ErrorParameterType(xmlString));
					}
				}
			}
	
		}
		
	}




	/**
      *Base type definition of request payload that can carry any
      *type of payload content with optional versioning information
      *and detail level requirements. 
      */
	public partial class AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private List<DetailLevelCodeType?> DetailLevelField = new List<DetailLevelCodeType?>();
		public List<DetailLevelCodeType?> DetailLevel
		{
			get
			{
				return this.DetailLevelField;
			}
			set
			{
				this.DetailLevelField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ErrorLanguageField;
		public string ErrorLanguage
		{
			get
			{
				return this.ErrorLanguageField;
			}
			set
			{
				this.ErrorLanguageField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string VersionField;
		public string Version
		{
			get
			{
				return this.VersionField;
			}
			set
			{
				this.VersionField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public AbstractRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(DetailLevel != null)
			{
				for(int i = 0; i < DetailLevel.Count; i++)
				{
					sb.Append("<ebl:DetailLevel>").Append(EnumUtils.getDescription(DetailLevel[i])).Append("</ebl:DetailLevel>");
				
				}
			}
			if(ErrorLanguage != null)
			{
				sb.Append("<ebl:ErrorLanguage>").Append(ErrorLanguage);
				sb.Append("</ebl:ErrorLanguage>");
			}
			if(Version != null)
			{
				sb.Append("<ebl:Version>").Append(Version);
				sb.Append("</ebl:Version>");
			}
			return sb.ToString();
		}
	}




	/**
      *Base type definition of a response payload that can carry
      *any type of payload content with following optional
      *elements: - timestamp of response message, - application
      *level acknowledgement, and - application-level errors and
      *warnings. 
      */
	public partial class AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private string TimestampField;
		public string Timestamp
		{
			get
			{
				return this.TimestampField;
			}
			set
			{
				this.TimestampField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private AckCodeType? AckField;
		public AckCodeType? Ack
		{
			get
			{
				return this.AckField;
			}
			set
			{
				this.AckField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CorrelationIDField;
		public string CorrelationID
		{
			get
			{
				return this.CorrelationIDField;
			}
			set
			{
				this.CorrelationIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<ErrorType> ErrorsField = new List<ErrorType>();
		public List<ErrorType> Errors
		{
			get
			{
				return this.ErrorsField;
			}
			set
			{
				this.ErrorsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string VersionField;
		public string Version
		{
			get
			{
				return this.VersionField;
			}
			set
			{
				this.VersionField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string BuildField;
		public string Build
		{
			get
			{
				return this.BuildField;
			}
			set
			{
				this.BuildField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public AbstractResponseType(){
		}


		public AbstractResponseType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("Timestamp").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Timestamp")[0]))
			{
				this.Timestamp = (string)document.GetElementsByTagName("Timestamp")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("Ack").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Ack")[0]))
				{
					this.Ack = (AckCodeType)EnumUtils.getValue(document.GetElementsByTagName("Ack")[0].InnerText,typeof(AckCodeType));
				}
			}
		if(document.GetElementsByTagName("CorrelationID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CorrelationID")[0]))
			{
				this.CorrelationID = (string)document.GetElementsByTagName("CorrelationID")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("Errors").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Errors")[0]))
				{
					nodeList = document.GetElementsByTagName("Errors");
					for(int i = 0; i < nodeList.Count; i++)
					{
						xmlString = DeserializationUtils.convertToXML(nodeList[i]);
						this.Errors.Add(new ErrorType(xmlString));
					}
				}
			}
		if(document.GetElementsByTagName("Version").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Version")[0]))
			{
				this.Version = (string)document.GetElementsByTagName("Version")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Build").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Build")[0]))
			{
				this.Build = (string)document.GetElementsByTagName("Build")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *Country code associated with this phone number. 
      */
	public partial class PhoneNumberType	
	{

		/**
          *No Document Comments
		  */
		private string CountryCodeField;
		public string CountryCode
		{
			get
			{
				return this.CountryCodeField;
			}
			set
			{
				this.CountryCodeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PhoneNumberField;
		public string PhoneNumber
		{
			get
			{
				return this.PhoneNumberField;
			}
			set
			{
				this.PhoneNumberField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ExtensionField;
		public string Extension
		{
			get
			{
				return this.ExtensionField;
			}
			set
			{
				this.ExtensionField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public PhoneNumberType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(CountryCode != null)
			{
				sb.Append("<ebl:CountryCode>").Append(CountryCode);
				sb.Append("</ebl:CountryCode>");
			}
			if(PhoneNumber != null)
			{
				sb.Append("<ebl:PhoneNumber>").Append(PhoneNumber);
				sb.Append("</ebl:PhoneNumber>");
			}
			if(Extension != null)
			{
				sb.Append("<ebl:Extension>").Append(Extension);
				sb.Append("</ebl:Extension>");
			}
			return sb.ToString();
		}
	}




	/**
      *Person's name associated with this address. Character length
      *and limitations: 32 single-byte alphanumeric characters 
      */
	public partial class AddressType	
	{

		/**
          *No Document Comments
		  */
		private string NameField;
		public string Name
		{
			get
			{
				return this.NameField;
			}
			set
			{
				this.NameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string Street1Field;
		public string Street1
		{
			get
			{
				return this.Street1Field;
			}
			set
			{
				this.Street1Field = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string Street2Field;
		public string Street2
		{
			get
			{
				return this.Street2Field;
			}
			set
			{
				this.Street2Field = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CityNameField;
		public string CityName
		{
			get
			{
				return this.CityNameField;
			}
			set
			{
				this.CityNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string StateOrProvinceField;
		public string StateOrProvince
		{
			get
			{
				return this.StateOrProvinceField;
			}
			set
			{
				this.StateOrProvinceField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private CountryCodeType? CountryField;
		public CountryCodeType? Country
		{
			get
			{
				return this.CountryField;
			}
			set
			{
				this.CountryField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CountryNameField;
		public string CountryName
		{
			get
			{
				return this.CountryNameField;
			}
			set
			{
				this.CountryNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PhoneField;
		public string Phone
		{
			get
			{
				return this.PhoneField;
			}
			set
			{
				this.PhoneField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PostalCodeField;
		public string PostalCode
		{
			get
			{
				return this.PostalCodeField;
			}
			set
			{
				this.PostalCodeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string AddressIDField;
		public string AddressID
		{
			get
			{
				return this.AddressIDField;
			}
			set
			{
				this.AddressIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private AddressOwnerCodeType? AddressOwnerField;
		public AddressOwnerCodeType? AddressOwner
		{
			get
			{
				return this.AddressOwnerField;
			}
			set
			{
				this.AddressOwnerField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ExternalAddressIDField;
		public string ExternalAddressID
		{
			get
			{
				return this.ExternalAddressIDField;
			}
			set
			{
				this.ExternalAddressIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string InternationalNameField;
		public string InternationalName
		{
			get
			{
				return this.InternationalNameField;
			}
			set
			{
				this.InternationalNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string InternationalStateAndCityField;
		public string InternationalStateAndCity
		{
			get
			{
				return this.InternationalStateAndCityField;
			}
			set
			{
				this.InternationalStateAndCityField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string InternationalStreetField;
		public string InternationalStreet
		{
			get
			{
				return this.InternationalStreetField;
			}
			set
			{
				this.InternationalStreetField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private AddressStatusCodeType? AddressStatusField;
		public AddressStatusCodeType? AddressStatus
		{
			get
			{
				return this.AddressStatusField;
			}
			set
			{
				this.AddressStatusField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public AddressType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Name != null)
			{
				sb.Append("<ebl:Name>").Append(Name);
				sb.Append("</ebl:Name>");
			}
			if(Street1 != null)
			{
				sb.Append("<ebl:Street1>").Append(Street1);
				sb.Append("</ebl:Street1>");
			}
			if(Street2 != null)
			{
				sb.Append("<ebl:Street2>").Append(Street2);
				sb.Append("</ebl:Street2>");
			}
			if(CityName != null)
			{
				sb.Append("<ebl:CityName>").Append(CityName);
				sb.Append("</ebl:CityName>");
			}
			if(StateOrProvince != null)
			{
				sb.Append("<ebl:StateOrProvince>").Append(StateOrProvince);
				sb.Append("</ebl:StateOrProvince>");
			}
			if(Country != null)
			{
				sb.Append("<ebl:Country>").Append(EnumUtils.getDescription(Country));
				sb.Append("</ebl:Country>");
			}
			if(CountryName != null)
			{
				sb.Append("<ebl:CountryName>").Append(CountryName);
				sb.Append("</ebl:CountryName>");
			}
			if(Phone != null)
			{
				sb.Append("<ebl:Phone>").Append(Phone);
				sb.Append("</ebl:Phone>");
			}
			if(PostalCode != null)
			{
				sb.Append("<ebl:PostalCode>").Append(PostalCode);
				sb.Append("</ebl:PostalCode>");
			}
			if(AddressID != null)
			{
				sb.Append("<ebl:AddressID>").Append(AddressID);
				sb.Append("</ebl:AddressID>");
			}
			if(AddressOwner != null)
			{
				sb.Append("<ebl:AddressOwner>").Append(EnumUtils.getDescription(AddressOwner));
				sb.Append("</ebl:AddressOwner>");
			}
			if(ExternalAddressID != null)
			{
				sb.Append("<ebl:ExternalAddressID>").Append(ExternalAddressID);
				sb.Append("</ebl:ExternalAddressID>");
			}
			if(InternationalName != null)
			{
				sb.Append("<ebl:InternationalName>").Append(InternationalName);
				sb.Append("</ebl:InternationalName>");
			}
			if(InternationalStateAndCity != null)
			{
				sb.Append("<ebl:InternationalStateAndCity>").Append(InternationalStateAndCity);
				sb.Append("</ebl:InternationalStateAndCity>");
			}
			if(InternationalStreet != null)
			{
				sb.Append("<ebl:InternationalStreet>").Append(InternationalStreet);
				sb.Append("</ebl:InternationalStreet>");
			}
			if(AddressStatus != null)
			{
				sb.Append("<ebl:AddressStatus>").Append(EnumUtils.getDescription(AddressStatus));
				sb.Append("</ebl:AddressStatus>");
			}
			return sb.ToString();
		}
		public AddressType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("Name").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Name")[0]))
			{
				this.Name = (string)document.GetElementsByTagName("Name")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Street1").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Street1")[0]))
			{
				this.Street1 = (string)document.GetElementsByTagName("Street1")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Street2").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Street2")[0]))
			{
				this.Street2 = (string)document.GetElementsByTagName("Street2")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("CityName").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CityName")[0]))
			{
				this.CityName = (string)document.GetElementsByTagName("CityName")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("StateOrProvince").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("StateOrProvince")[0]))
			{
				this.StateOrProvince = (string)document.GetElementsByTagName("StateOrProvince")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("Country").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Country")[0]))
				{
					this.Country = (CountryCodeType)EnumUtils.getValue(document.GetElementsByTagName("Country")[0].InnerText,typeof(CountryCodeType));
				}
			}
		if(document.GetElementsByTagName("CountryName").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CountryName")[0]))
			{
				this.CountryName = (string)document.GetElementsByTagName("CountryName")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Phone").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Phone")[0]))
			{
				this.Phone = (string)document.GetElementsByTagName("Phone")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("PostalCode").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PostalCode")[0]))
			{
				this.PostalCode = (string)document.GetElementsByTagName("PostalCode")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("AddressID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AddressID")[0]))
			{
				this.AddressID = (string)document.GetElementsByTagName("AddressID")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("AddressOwner").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AddressOwner")[0]))
				{
					this.AddressOwner = (AddressOwnerCodeType)EnumUtils.getValue(document.GetElementsByTagName("AddressOwner")[0].InnerText,typeof(AddressOwnerCodeType));
				}
			}
		if(document.GetElementsByTagName("ExternalAddressID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ExternalAddressID")[0]))
			{
				this.ExternalAddressID = (string)document.GetElementsByTagName("ExternalAddressID")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("InternationalName").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("InternationalName")[0]))
			{
				this.InternationalName = (string)document.GetElementsByTagName("InternationalName")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("InternationalStateAndCity").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("InternationalStateAndCity")[0]))
			{
				this.InternationalStateAndCity = (string)document.GetElementsByTagName("InternationalStateAndCity")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("InternationalStreet").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("InternationalStreet")[0]))
			{
				this.InternationalStreet = (string)document.GetElementsByTagName("InternationalStreet")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("AddressStatus").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AddressStatus")[0]))
				{
					this.AddressStatus = (AddressStatusCodeType)EnumUtils.getValue(document.GetElementsByTagName("AddressStatus")[0].InnerText,typeof(AddressStatusCodeType));
				}
			}
	
		}
		
	}




	/**
      *
      */
	public partial class PersonNameType	
	{

		/**
          *No Document Comments
		  */
		private string SalutationField;
		public string Salutation
		{
			get
			{
				return this.SalutationField;
			}
			set
			{
				this.SalutationField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string FirstNameField;
		public string FirstName
		{
			get
			{
				return this.FirstNameField;
			}
			set
			{
				this.FirstNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string MiddleNameField;
		public string MiddleName
		{
			get
			{
				return this.MiddleNameField;
			}
			set
			{
				this.MiddleNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string LastNameField;
		public string LastName
		{
			get
			{
				return this.LastNameField;
			}
			set
			{
				this.LastNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string SuffixField;
		public string Suffix
		{
			get
			{
				return this.SuffixField;
			}
			set
			{
				this.SuffixField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public PersonNameType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Salutation != null)
			{
				sb.Append("<ebl:Salutation>").Append(Salutation);
				sb.Append("</ebl:Salutation>");
			}
			if(FirstName != null)
			{
				sb.Append("<ebl:FirstName>").Append(FirstName);
				sb.Append("</ebl:FirstName>");
			}
			if(MiddleName != null)
			{
				sb.Append("<ebl:MiddleName>").Append(MiddleName);
				sb.Append("</ebl:MiddleName>");
			}
			if(LastName != null)
			{
				sb.Append("<ebl:LastName>").Append(LastName);
				sb.Append("</ebl:LastName>");
			}
			if(Suffix != null)
			{
				sb.Append("<ebl:Suffix>").Append(Suffix);
				sb.Append("</ebl:Suffix>");
			}
			return sb.ToString();
		}
		public PersonNameType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("Salutation").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Salutation")[0]))
			{
				this.Salutation = (string)document.GetElementsByTagName("Salutation")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("FirstName").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("FirstName")[0]))
			{
				this.FirstName = (string)document.GetElementsByTagName("FirstName")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("MiddleName").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("MiddleName")[0]))
			{
				this.MiddleName = (string)document.GetElementsByTagName("MiddleName")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("LastName").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("LastName")[0]))
			{
				this.LastName = (string)document.GetElementsByTagName("LastName")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Suffix").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Suffix")[0]))
			{
				this.Suffix = (string)document.GetElementsByTagName("Suffix")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *
      */
	public partial class IncentiveAppliedToType	
	{

		/**
          *No Document Comments
		  */
		private string BucketIdField;
		public string BucketId
		{
			get
			{
				return this.BucketIdField;
			}
			set
			{
				this.BucketIdField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ItemIdField;
		public string ItemId
		{
			get
			{
				return this.ItemIdField;
			}
			set
			{
				this.ItemIdField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType IncentiveAmountField;
		public BasicAmountType IncentiveAmount
		{
			get
			{
				return this.IncentiveAmountField;
			}
			set
			{
				this.IncentiveAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string SubTypeField;
		public string SubType
		{
			get
			{
				return this.SubTypeField;
			}
			set
			{
				this.SubTypeField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public IncentiveAppliedToType(){
		}


		public IncentiveAppliedToType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("BucketId").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BucketId")[0]))
			{
				this.BucketId = (string)document.GetElementsByTagName("BucketId")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ItemId").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ItemId")[0]))
			{
				this.ItemId = (string)document.GetElementsByTagName("ItemId")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("IncentiveAmount").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("IncentiveAmount")[0]))
				{
					nodeList = document.GetElementsByTagName("IncentiveAmount");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.IncentiveAmount =  new BasicAmountType(xmlString);
				}
			}
		if(document.GetElementsByTagName("SubType").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SubType")[0]))
			{
				this.SubType = (string)document.GetElementsByTagName("SubType")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *
      */
	public partial class IncentiveDetailType	
	{

		/**
          *No Document Comments
		  */
		private string RedemptionCodeField;
		public string RedemptionCode
		{
			get
			{
				return this.RedemptionCodeField;
			}
			set
			{
				this.RedemptionCodeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string DisplayCodeField;
		public string DisplayCode
		{
			get
			{
				return this.DisplayCodeField;
			}
			set
			{
				this.DisplayCodeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ProgramIdField;
		public string ProgramId
		{
			get
			{
				return this.ProgramIdField;
			}
			set
			{
				this.ProgramIdField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private IncentiveTypeCodeType? IncentiveTypeField;
		public IncentiveTypeCodeType? IncentiveType
		{
			get
			{
				return this.IncentiveTypeField;
			}
			set
			{
				this.IncentiveTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string IncentiveDescriptionField;
		public string IncentiveDescription
		{
			get
			{
				return this.IncentiveDescriptionField;
			}
			set
			{
				this.IncentiveDescriptionField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<IncentiveAppliedToType> AppliedToField = new List<IncentiveAppliedToType>();
		public List<IncentiveAppliedToType> AppliedTo
		{
			get
			{
				return this.AppliedToField;
			}
			set
			{
				this.AppliedToField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string StatusField;
		public string Status
		{
			get
			{
				return this.StatusField;
			}
			set
			{
				this.StatusField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ErrorCodeField;
		public string ErrorCode
		{
			get
			{
				return this.ErrorCodeField;
			}
			set
			{
				this.ErrorCodeField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public IncentiveDetailType(){
		}


		public IncentiveDetailType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("RedemptionCode").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("RedemptionCode")[0]))
			{
				this.RedemptionCode = (string)document.GetElementsByTagName("RedemptionCode")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("DisplayCode").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("DisplayCode")[0]))
			{
				this.DisplayCode = (string)document.GetElementsByTagName("DisplayCode")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ProgramId").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ProgramId")[0]))
			{
				this.ProgramId = (string)document.GetElementsByTagName("ProgramId")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("IncentiveType").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("IncentiveType")[0]))
				{
					this.IncentiveType = (IncentiveTypeCodeType)EnumUtils.getValue(document.GetElementsByTagName("IncentiveType")[0].InnerText,typeof(IncentiveTypeCodeType));
				}
			}
		if(document.GetElementsByTagName("IncentiveDescription").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("IncentiveDescription")[0]))
			{
				this.IncentiveDescription = (string)document.GetElementsByTagName("IncentiveDescription")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("AppliedTo").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AppliedTo")[0]))
				{
					nodeList = document.GetElementsByTagName("AppliedTo");
					for(int i = 0; i < nodeList.Count; i++)
					{
						xmlString = DeserializationUtils.convertToXML(nodeList[i]);
						this.AppliedTo.Add(new IncentiveAppliedToType(xmlString));
					}
				}
			}
		if(document.GetElementsByTagName("Status").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Status")[0]))
			{
				this.Status = (string)document.GetElementsByTagName("Status")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ErrorCode").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ErrorCode")[0]))
			{
				this.ErrorCode = (string)document.GetElementsByTagName("ErrorCode")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *
      */
	public partial class IncentiveItemType	
	{

		/**
          *No Document Comments
		  */
		private string ItemIdField;
		public string ItemId
		{
			get
			{
				return this.ItemIdField;
			}
			set
			{
				this.ItemIdField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PurchaseTimeField;
		public string PurchaseTime
		{
			get
			{
				return this.PurchaseTimeField;
			}
			set
			{
				this.PurchaseTimeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ItemCategoryListField;
		public string ItemCategoryList
		{
			get
			{
				return this.ItemCategoryListField;
			}
			set
			{
				this.ItemCategoryListField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType ItemPriceField;
		public BasicAmountType ItemPrice
		{
			get
			{
				return this.ItemPriceField;
			}
			set
			{
				this.ItemPriceField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? ItemQuantityField;
		public int? ItemQuantity
		{
			get
			{
				return this.ItemQuantityField;
			}
			set
			{
				this.ItemQuantityField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public IncentiveItemType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ItemId != null)
			{
				sb.Append("<ebl:ItemId>").Append(ItemId);
				sb.Append("</ebl:ItemId>");
			}
			if(PurchaseTime != null)
			{
				sb.Append("<ebl:PurchaseTime>").Append(PurchaseTime);
				sb.Append("</ebl:PurchaseTime>");
			}
			if(ItemCategoryList != null)
			{
				sb.Append("<ebl:ItemCategoryList>").Append(ItemCategoryList);
				sb.Append("</ebl:ItemCategoryList>");
			}
			if(ItemPrice != null)
			{
				sb.Append("<ebl:ItemPrice");
				sb.Append(ItemPrice.toXMLString());
				sb.Append("</ebl:ItemPrice>");
			}
			if(ItemQuantity != null)
			{
				sb.Append("<ebl:ItemQuantity>").Append(ItemQuantity);
				sb.Append("</ebl:ItemQuantity>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class IncentiveBucketType	
	{

		/**
          *No Document Comments
		  */
		private List<IncentiveItemType> ItemsField = new List<IncentiveItemType>();
		public List<IncentiveItemType> Items
		{
			get
			{
				return this.ItemsField;
			}
			set
			{
				this.ItemsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string BucketIdField;
		public string BucketId
		{
			get
			{
				return this.BucketIdField;
			}
			set
			{
				this.BucketIdField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string SellerIdField;
		public string SellerId
		{
			get
			{
				return this.SellerIdField;
			}
			set
			{
				this.SellerIdField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ExternalSellerIdField;
		public string ExternalSellerId
		{
			get
			{
				return this.ExternalSellerIdField;
			}
			set
			{
				this.ExternalSellerIdField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType BucketSubtotalAmtField;
		public BasicAmountType BucketSubtotalAmt
		{
			get
			{
				return this.BucketSubtotalAmtField;
			}
			set
			{
				this.BucketSubtotalAmtField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType BucketShippingAmtField;
		public BasicAmountType BucketShippingAmt
		{
			get
			{
				return this.BucketShippingAmtField;
			}
			set
			{
				this.BucketShippingAmtField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType BucketInsuranceAmtField;
		public BasicAmountType BucketInsuranceAmt
		{
			get
			{
				return this.BucketInsuranceAmtField;
			}
			set
			{
				this.BucketInsuranceAmtField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType BucketSalesTaxAmtField;
		public BasicAmountType BucketSalesTaxAmt
		{
			get
			{
				return this.BucketSalesTaxAmtField;
			}
			set
			{
				this.BucketSalesTaxAmtField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType BucketTotalAmtField;
		public BasicAmountType BucketTotalAmt
		{
			get
			{
				return this.BucketTotalAmtField;
			}
			set
			{
				this.BucketTotalAmtField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public IncentiveBucketType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Items != null)
			{
				for(int i = 0; i < Items.Count; i++)
				{
					sb.Append("<ebl:Items>");
					sb.Append(Items[i].toXMLString());
					sb.Append("</ebl:Items>");
				
				}
			}
			if(BucketId != null)
			{
				sb.Append("<ebl:BucketId>").Append(BucketId);
				sb.Append("</ebl:BucketId>");
			}
			if(SellerId != null)
			{
				sb.Append("<ebl:SellerId>").Append(SellerId);
				sb.Append("</ebl:SellerId>");
			}
			if(ExternalSellerId != null)
			{
				sb.Append("<ebl:ExternalSellerId>").Append(ExternalSellerId);
				sb.Append("</ebl:ExternalSellerId>");
			}
			if(BucketSubtotalAmt != null)
			{
				sb.Append("<ebl:BucketSubtotalAmt");
				sb.Append(BucketSubtotalAmt.toXMLString());
				sb.Append("</ebl:BucketSubtotalAmt>");
			}
			if(BucketShippingAmt != null)
			{
				sb.Append("<ebl:BucketShippingAmt");
				sb.Append(BucketShippingAmt.toXMLString());
				sb.Append("</ebl:BucketShippingAmt>");
			}
			if(BucketInsuranceAmt != null)
			{
				sb.Append("<ebl:BucketInsuranceAmt");
				sb.Append(BucketInsuranceAmt.toXMLString());
				sb.Append("</ebl:BucketInsuranceAmt>");
			}
			if(BucketSalesTaxAmt != null)
			{
				sb.Append("<ebl:BucketSalesTaxAmt");
				sb.Append(BucketSalesTaxAmt.toXMLString());
				sb.Append("</ebl:BucketSalesTaxAmt>");
			}
			if(BucketTotalAmt != null)
			{
				sb.Append("<ebl:BucketTotalAmt");
				sb.Append(BucketTotalAmt.toXMLString());
				sb.Append("</ebl:BucketTotalAmt>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class IncentiveRequestDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string RequestIdField;
		public string RequestId
		{
			get
			{
				return this.RequestIdField;
			}
			set
			{
				this.RequestIdField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private IncentiveRequestCodeType? RequestTypeField;
		public IncentiveRequestCodeType? RequestType
		{
			get
			{
				return this.RequestTypeField;
			}
			set
			{
				this.RequestTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private IncentiveRequestDetailLevelCodeType? RequestDetailLevelField;
		public IncentiveRequestDetailLevelCodeType? RequestDetailLevel
		{
			get
			{
				return this.RequestDetailLevelField;
			}
			set
			{
				this.RequestDetailLevelField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public IncentiveRequestDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(RequestId != null)
			{
				sb.Append("<ebl:RequestId>").Append(RequestId);
				sb.Append("</ebl:RequestId>");
			}
			if(RequestType != null)
			{
				sb.Append("<ebl:RequestType>").Append(EnumUtils.getDescription(RequestType));
				sb.Append("</ebl:RequestType>");
			}
			if(RequestDetailLevel != null)
			{
				sb.Append("<ebl:RequestDetailLevel>").Append(EnumUtils.getDescription(RequestDetailLevel));
				sb.Append("</ebl:RequestDetailLevel>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class GetIncentiveEvaluationRequestDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string ExternalBuyerIdField;
		public string ExternalBuyerId
		{
			get
			{
				return this.ExternalBuyerIdField;
			}
			set
			{
				this.ExternalBuyerIdField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<string> IncentiveCodesField = new List<string>();
		public List<string> IncentiveCodes
		{
			get
			{
				return this.IncentiveCodesField;
			}
			set
			{
				this.IncentiveCodesField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<IncentiveApplyIndicationType> ApplyIndicationField = new List<IncentiveApplyIndicationType>();
		public List<IncentiveApplyIndicationType> ApplyIndication
		{
			get
			{
				return this.ApplyIndicationField;
			}
			set
			{
				this.ApplyIndicationField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<IncentiveBucketType> BucketsField = new List<IncentiveBucketType>();
		public List<IncentiveBucketType> Buckets
		{
			get
			{
				return this.BucketsField;
			}
			set
			{
				this.BucketsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType CartTotalAmtField;
		public BasicAmountType CartTotalAmt
		{
			get
			{
				return this.CartTotalAmtField;
			}
			set
			{
				this.CartTotalAmtField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private IncentiveRequestDetailsType RequestDetailsField;
		public IncentiveRequestDetailsType RequestDetails
		{
			get
			{
				return this.RequestDetailsField;
			}
			set
			{
				this.RequestDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public GetIncentiveEvaluationRequestDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ExternalBuyerId != null)
			{
				sb.Append("<ebl:ExternalBuyerId>").Append(ExternalBuyerId);
				sb.Append("</ebl:ExternalBuyerId>");
			}
			if(IncentiveCodes != null)
			{
				for(int i = 0; i < IncentiveCodes.Count; i++)
				{
					sb.Append("<ebl:IncentiveCodes>").Append(IncentiveCodes[i]);
					sb.Append("</ebl:IncentiveCodes>");
				
				}
			}
			if(ApplyIndication != null)
			{
				for(int i = 0; i < ApplyIndication.Count; i++)
				{
					sb.Append("<ebl:ApplyIndication>");
					sb.Append(ApplyIndication[i].toXMLString());
					sb.Append("</ebl:ApplyIndication>");
				
				}
			}
			if(Buckets != null)
			{
				for(int i = 0; i < Buckets.Count; i++)
				{
					sb.Append("<ebl:Buckets>");
					sb.Append(Buckets[i].toXMLString());
					sb.Append("</ebl:Buckets>");
				
				}
			}
			if(CartTotalAmt != null)
			{
				sb.Append("<ebl:CartTotalAmt");
				sb.Append(CartTotalAmt.toXMLString());
				sb.Append("</ebl:CartTotalAmt>");
			}
			if(RequestDetails != null)
			{
				sb.Append("<ebl:RequestDetails>");
				sb.Append(RequestDetails.toXMLString());
				sb.Append("</ebl:RequestDetails>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class GetIncentiveEvaluationResponseDetailsType	
	{

		/**
          *No Document Comments
		  */
		private List<IncentiveDetailType> IncentiveDetailsField = new List<IncentiveDetailType>();
		public List<IncentiveDetailType> IncentiveDetails
		{
			get
			{
				return this.IncentiveDetailsField;
			}
			set
			{
				this.IncentiveDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string RequestIdField;
		public string RequestId
		{
			get
			{
				return this.RequestIdField;
			}
			set
			{
				this.RequestIdField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public GetIncentiveEvaluationResponseDetailsType(){
		}


		public GetIncentiveEvaluationResponseDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("IncentiveDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("IncentiveDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("IncentiveDetails");
					for(int i = 0; i < nodeList.Count; i++)
					{
						xmlString = DeserializationUtils.convertToXML(nodeList[i]);
						this.IncentiveDetails.Add(new IncentiveDetailType(xmlString));
					}
				}
			}
		if(document.GetElementsByTagName("RequestId").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("RequestId")[0]))
			{
				this.RequestId = (string)document.GetElementsByTagName("RequestId")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *The total cost of the order to the customer. If shipping
      *cost and tax charges are known, include them in OrderTotal;
      *if not, OrderTotal should be the current sub-total of the
      *order. You must set the currencyID attribute to one of the
      *three-character currency codes for any of the supported
      *PayPal currencies. Limitations: Must not exceed $10,000 USD
      *in any currency. No currency symbol. Decimal separator must
      *be a period (.), and the thousands separator must be a comma
      *(,). 
      */
	public partial class SetExpressCheckoutRequestDetailsType	
	{

		/**
          *No Document Comments
		  */
		private BasicAmountType OrderTotalField;
		public BasicAmountType OrderTotal
		{
			get
			{
				return this.OrderTotalField;
			}
			set
			{
				this.OrderTotalField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ReturnURLField;
		public string ReturnURL
		{
			get
			{
				return this.ReturnURLField;
			}
			set
			{
				this.ReturnURLField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CancelURLField;
		public string CancelURL
		{
			get
			{
				return this.CancelURLField;
			}
			set
			{
				this.CancelURLField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string TrackingImageURLField;
		public string TrackingImageURL
		{
			get
			{
				return this.TrackingImageURLField;
			}
			set
			{
				this.TrackingImageURLField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string giropaySuccessURLField;
		public string giropaySuccessURL
		{
			get
			{
				return this.giropaySuccessURLField;
			}
			set
			{
				this.giropaySuccessURLField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string giropayCancelURLField;
		public string giropayCancelURL
		{
			get
			{
				return this.giropayCancelURLField;
			}
			set
			{
				this.giropayCancelURLField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string BanktxnPendingURLField;
		public string BanktxnPendingURL
		{
			get
			{
				return this.BanktxnPendingURLField;
			}
			set
			{
				this.BanktxnPendingURLField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string TokenField;
		public string Token
		{
			get
			{
				return this.TokenField;
			}
			set
			{
				this.TokenField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType MaxAmountField;
		public BasicAmountType MaxAmount
		{
			get
			{
				return this.MaxAmountField;
			}
			set
			{
				this.MaxAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string OrderDescriptionField;
		public string OrderDescription
		{
			get
			{
				return this.OrderDescriptionField;
			}
			set
			{
				this.OrderDescriptionField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CustomField;
		public string Custom
		{
			get
			{
				return this.CustomField;
			}
			set
			{
				this.CustomField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string InvoiceIDField;
		public string InvoiceID
		{
			get
			{
				return this.InvoiceIDField;
			}
			set
			{
				this.InvoiceIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ReqConfirmShippingField;
		public string ReqConfirmShipping
		{
			get
			{
				return this.ReqConfirmShippingField;
			}
			set
			{
				this.ReqConfirmShippingField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ReqBillingAddressField;
		public string ReqBillingAddress
		{
			get
			{
				return this.ReqBillingAddressField;
			}
			set
			{
				this.ReqBillingAddressField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private AddressType BillingAddressField;
		public AddressType BillingAddress
		{
			get
			{
				return this.BillingAddressField;
			}
			set
			{
				this.BillingAddressField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string NoShippingField;
		public string NoShipping
		{
			get
			{
				return this.NoShippingField;
			}
			set
			{
				this.NoShippingField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string AddressOverrideField;
		public string AddressOverride
		{
			get
			{
				return this.AddressOverrideField;
			}
			set
			{
				this.AddressOverrideField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string LocaleCodeField;
		public string LocaleCode
		{
			get
			{
				return this.LocaleCodeField;
			}
			set
			{
				this.LocaleCodeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PageStyleField;
		public string PageStyle
		{
			get
			{
				return this.PageStyleField;
			}
			set
			{
				this.PageStyleField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string cppHeaderImageField;
		public string cppHeaderImage
		{
			get
			{
				return this.cppHeaderImageField;
			}
			set
			{
				this.cppHeaderImageField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string cppHeaderBorderColorField;
		public string cppHeaderBorderColor
		{
			get
			{
				return this.cppHeaderBorderColorField;
			}
			set
			{
				this.cppHeaderBorderColorField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string cppHeaderBackColorField;
		public string cppHeaderBackColor
		{
			get
			{
				return this.cppHeaderBackColorField;
			}
			set
			{
				this.cppHeaderBackColorField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string cppPayflowColorField;
		public string cppPayflowColor
		{
			get
			{
				return this.cppPayflowColorField;
			}
			set
			{
				this.cppPayflowColorField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string cppCartBorderColorField;
		public string cppCartBorderColor
		{
			get
			{
				return this.cppCartBorderColorField;
			}
			set
			{
				this.cppCartBorderColorField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string cppLogoImageField;
		public string cppLogoImage
		{
			get
			{
				return this.cppLogoImageField;
			}
			set
			{
				this.cppLogoImageField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private AddressType AddressField;
		public AddressType Address
		{
			get
			{
				return this.AddressField;
			}
			set
			{
				this.AddressField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PaymentActionCodeType? PaymentActionField;
		public PaymentActionCodeType? PaymentAction
		{
			get
			{
				return this.PaymentActionField;
			}
			set
			{
				this.PaymentActionField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private SolutionTypeType? SolutionTypeField;
		public SolutionTypeType? SolutionType
		{
			get
			{
				return this.SolutionTypeField;
			}
			set
			{
				this.SolutionTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private LandingPageType? LandingPageField;
		public LandingPageType? LandingPage
		{
			get
			{
				return this.LandingPageField;
			}
			set
			{
				this.LandingPageField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string BuyerEmailField;
		public string BuyerEmail
		{
			get
			{
				return this.BuyerEmailField;
			}
			set
			{
				this.BuyerEmailField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ChannelType? ChannelTypeField;
		public ChannelType? ChannelType
		{
			get
			{
				return this.ChannelTypeField;
			}
			set
			{
				this.ChannelTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<BillingAgreementDetailsType> BillingAgreementDetailsField = new List<BillingAgreementDetailsType>();
		public List<BillingAgreementDetailsType> BillingAgreementDetails
		{
			get
			{
				return this.BillingAgreementDetailsField;
			}
			set
			{
				this.BillingAgreementDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<string> PromoCodesField = new List<string>();
		public List<string> PromoCodes
		{
			get
			{
				return this.PromoCodesField;
			}
			set
			{
				this.PromoCodesField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PayPalCheckOutBtnTypeField;
		public string PayPalCheckOutBtnType
		{
			get
			{
				return this.PayPalCheckOutBtnTypeField;
			}
			set
			{
				this.PayPalCheckOutBtnTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ProductCategoryType? ProductCategoryField;
		public ProductCategoryType? ProductCategory
		{
			get
			{
				return this.ProductCategoryField;
			}
			set
			{
				this.ProductCategoryField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ShippingServiceCodeType? ShippingMethodField;
		public ShippingServiceCodeType? ShippingMethod
		{
			get
			{
				return this.ShippingMethodField;
			}
			set
			{
				this.ShippingMethodField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ProfileAddressChangeDateField;
		public string ProfileAddressChangeDate
		{
			get
			{
				return this.ProfileAddressChangeDateField;
			}
			set
			{
				this.ProfileAddressChangeDateField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string AllowNoteField;
		public string AllowNote
		{
			get
			{
				return this.AllowNoteField;
			}
			set
			{
				this.AllowNoteField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private FundingSourceDetailsType FundingSourceDetailsField;
		public FundingSourceDetailsType FundingSourceDetails
		{
			get
			{
				return this.FundingSourceDetailsField;
			}
			set
			{
				this.FundingSourceDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string BrandNameField;
		public string BrandName
		{
			get
			{
				return this.BrandNameField;
			}
			set
			{
				this.BrandNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CallbackURLField;
		public string CallbackURL
		{
			get
			{
				return this.CallbackURLField;
			}
			set
			{
				this.CallbackURLField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private EnhancedCheckoutDataType EnhancedCheckoutDataField;
		public EnhancedCheckoutDataType EnhancedCheckoutData
		{
			get
			{
				return this.EnhancedCheckoutDataField;
			}
			set
			{
				this.EnhancedCheckoutDataField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<OtherPaymentMethodDetailsType> OtherPaymentMethodsField = new List<OtherPaymentMethodDetailsType>();
		public List<OtherPaymentMethodDetailsType> OtherPaymentMethods
		{
			get
			{
				return this.OtherPaymentMethodsField;
			}
			set
			{
				this.OtherPaymentMethodsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BuyerDetailsType BuyerDetailsField;
		public BuyerDetailsType BuyerDetails
		{
			get
			{
				return this.BuyerDetailsField;
			}
			set
			{
				this.BuyerDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<PaymentDetailsType> PaymentDetailsField = new List<PaymentDetailsType>();
		public List<PaymentDetailsType> PaymentDetails
		{
			get
			{
				return this.PaymentDetailsField;
			}
			set
			{
				this.PaymentDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<ShippingOptionType> FlatRateShippingOptionsField = new List<ShippingOptionType>();
		public List<ShippingOptionType> FlatRateShippingOptions
		{
			get
			{
				return this.FlatRateShippingOptionsField;
			}
			set
			{
				this.FlatRateShippingOptionsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CallbackTimeoutField;
		public string CallbackTimeout
		{
			get
			{
				return this.CallbackTimeoutField;
			}
			set
			{
				this.CallbackTimeoutField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CallbackVersionField;
		public string CallbackVersion
		{
			get
			{
				return this.CallbackVersionField;
			}
			set
			{
				this.CallbackVersionField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CustomerServiceNumberField;
		public string CustomerServiceNumber
		{
			get
			{
				return this.CustomerServiceNumberField;
			}
			set
			{
				this.CustomerServiceNumberField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string GiftMessageEnableField;
		public string GiftMessageEnable
		{
			get
			{
				return this.GiftMessageEnableField;
			}
			set
			{
				this.GiftMessageEnableField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string GiftReceiptEnableField;
		public string GiftReceiptEnable
		{
			get
			{
				return this.GiftReceiptEnableField;
			}
			set
			{
				this.GiftReceiptEnableField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string GiftWrapEnableField;
		public string GiftWrapEnable
		{
			get
			{
				return this.GiftWrapEnableField;
			}
			set
			{
				this.GiftWrapEnableField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string GiftWrapNameField;
		public string GiftWrapName
		{
			get
			{
				return this.GiftWrapNameField;
			}
			set
			{
				this.GiftWrapNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType GiftWrapAmountField;
		public BasicAmountType GiftWrapAmount
		{
			get
			{
				return this.GiftWrapAmountField;
			}
			set
			{
				this.GiftWrapAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string BuyerEmailOptInEnableField;
		public string BuyerEmailOptInEnable
		{
			get
			{
				return this.BuyerEmailOptInEnableField;
			}
			set
			{
				this.BuyerEmailOptInEnableField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string SurveyEnableField;
		public string SurveyEnable
		{
			get
			{
				return this.SurveyEnableField;
			}
			set
			{
				this.SurveyEnableField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string SurveyQuestionField;
		public string SurveyQuestion
		{
			get
			{
				return this.SurveyQuestionField;
			}
			set
			{
				this.SurveyQuestionField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<string> SurveyChoiceField = new List<string>();
		public List<string> SurveyChoice
		{
			get
			{
				return this.SurveyChoiceField;
			}
			set
			{
				this.SurveyChoiceField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private TotalType? TotalTypeField;
		public TotalType? TotalType
		{
			get
			{
				return this.TotalTypeField;
			}
			set
			{
				this.TotalTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string NoteToBuyerField;
		public string NoteToBuyer
		{
			get
			{
				return this.NoteToBuyerField;
			}
			set
			{
				this.NoteToBuyerField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<IncentiveInfoType> IncentivesField = new List<IncentiveInfoType>();
		public List<IncentiveInfoType> Incentives
		{
			get
			{
				return this.IncentivesField;
			}
			set
			{
				this.IncentivesField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ReqInstrumentDetailsField;
		public string ReqInstrumentDetails
		{
			get
			{
				return this.ReqInstrumentDetailsField;
			}
			set
			{
				this.ReqInstrumentDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ExternalRememberMeOptInDetailsType ExternalRememberMeOptInDetailsField;
		public ExternalRememberMeOptInDetailsType ExternalRememberMeOptInDetails
		{
			get
			{
				return this.ExternalRememberMeOptInDetailsField;
			}
			set
			{
				this.ExternalRememberMeOptInDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private FlowControlDetailsType FlowControlDetailsField;
		public FlowControlDetailsType FlowControlDetails
		{
			get
			{
				return this.FlowControlDetailsField;
			}
			set
			{
				this.FlowControlDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private DisplayControlDetailsType DisplayControlDetailsField;
		public DisplayControlDetailsType DisplayControlDetails
		{
			get
			{
				return this.DisplayControlDetailsField;
			}
			set
			{
				this.DisplayControlDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ExternalPartnerTrackingDetailsType ExternalPartnerTrackingDetailsField;
		public ExternalPartnerTrackingDetailsType ExternalPartnerTrackingDetails
		{
			get
			{
				return this.ExternalPartnerTrackingDetailsField;
			}
			set
			{
				this.ExternalPartnerTrackingDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public SetExpressCheckoutRequestDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(OrderTotal != null)
			{
				sb.Append("<ebl:OrderTotal");
				sb.Append(OrderTotal.toXMLString());
				sb.Append("</ebl:OrderTotal>");
			}
			if(ReturnURL != null)
			{
				sb.Append("<ebl:ReturnURL>").Append(ReturnURL);
				sb.Append("</ebl:ReturnURL>");
			}
			if(CancelURL != null)
			{
				sb.Append("<ebl:CancelURL>").Append(CancelURL);
				sb.Append("</ebl:CancelURL>");
			}
			if(TrackingImageURL != null)
			{
				sb.Append("<ebl:TrackingImageURL>").Append(TrackingImageURL);
				sb.Append("</ebl:TrackingImageURL>");
			}
			if(giropaySuccessURL != null)
			{
				sb.Append("<ebl:giropaySuccessURL>").Append(giropaySuccessURL);
				sb.Append("</ebl:giropaySuccessURL>");
			}
			if(giropayCancelURL != null)
			{
				sb.Append("<ebl:giropayCancelURL>").Append(giropayCancelURL);
				sb.Append("</ebl:giropayCancelURL>");
			}
			if(BanktxnPendingURL != null)
			{
				sb.Append("<ebl:BanktxnPendingURL>").Append(BanktxnPendingURL);
				sb.Append("</ebl:BanktxnPendingURL>");
			}
			if(Token != null)
			{
				sb.Append("<ebl:Token>").Append(Token);
				sb.Append("</ebl:Token>");
			}
			if(MaxAmount != null)
			{
				sb.Append("<ebl:MaxAmount");
				sb.Append(MaxAmount.toXMLString());
				sb.Append("</ebl:MaxAmount>");
			}
			if(OrderDescription != null)
			{
				sb.Append("<ebl:OrderDescription>").Append(OrderDescription);
				sb.Append("</ebl:OrderDescription>");
			}
			if(Custom != null)
			{
				sb.Append("<ebl:Custom>").Append(Custom);
				sb.Append("</ebl:Custom>");
			}
			if(InvoiceID != null)
			{
				sb.Append("<ebl:InvoiceID>").Append(InvoiceID);
				sb.Append("</ebl:InvoiceID>");
			}
			if(ReqConfirmShipping != null)
			{
				sb.Append("<ebl:ReqConfirmShipping>").Append(ReqConfirmShipping);
				sb.Append("</ebl:ReqConfirmShipping>");
			}
			if(ReqBillingAddress != null)
			{
				sb.Append("<ebl:ReqBillingAddress>").Append(ReqBillingAddress);
				sb.Append("</ebl:ReqBillingAddress>");
			}
			if(BillingAddress != null)
			{
				sb.Append("<ebl:BillingAddress>");
				sb.Append(BillingAddress.toXMLString());
				sb.Append("</ebl:BillingAddress>");
			}
			if(NoShipping != null)
			{
				sb.Append("<ebl:NoShipping>").Append(NoShipping);
				sb.Append("</ebl:NoShipping>");
			}
			if(AddressOverride != null)
			{
				sb.Append("<ebl:AddressOverride>").Append(AddressOverride);
				sb.Append("</ebl:AddressOverride>");
			}
			if(LocaleCode != null)
			{
				sb.Append("<ebl:LocaleCode>").Append(LocaleCode);
				sb.Append("</ebl:LocaleCode>");
			}
			if(PageStyle != null)
			{
				sb.Append("<ebl:PageStyle>").Append(PageStyle);
				sb.Append("</ebl:PageStyle>");
			}
			if(cppHeaderImage != null)
			{
				sb.Append("<ebl:cpp-header-image>").Append(cppHeaderImage);
				sb.Append("</ebl:cpp-header-image>");
			}
			if(cppHeaderBorderColor != null)
			{
				sb.Append("<ebl:cpp-header-border-color>").Append(cppHeaderBorderColor);
				sb.Append("</ebl:cpp-header-border-color>");
			}
			if(cppHeaderBackColor != null)
			{
				sb.Append("<ebl:cpp-header-back-color>").Append(cppHeaderBackColor);
				sb.Append("</ebl:cpp-header-back-color>");
			}
			if(cppPayflowColor != null)
			{
				sb.Append("<ebl:cpp-payflow-color>").Append(cppPayflowColor);
				sb.Append("</ebl:cpp-payflow-color>");
			}
			if(cppCartBorderColor != null)
			{
				sb.Append("<ebl:cpp-cart-border-color>").Append(cppCartBorderColor);
				sb.Append("</ebl:cpp-cart-border-color>");
			}
			if(cppLogoImage != null)
			{
				sb.Append("<ebl:cpp-logo-image>").Append(cppLogoImage);
				sb.Append("</ebl:cpp-logo-image>");
			}
			if(Address != null)
			{
				sb.Append("<ebl:Address>");
				sb.Append(Address.toXMLString());
				sb.Append("</ebl:Address>");
			}
			if(PaymentAction != null)
			{
				sb.Append("<ebl:PaymentAction>").Append(EnumUtils.getDescription(PaymentAction));
				sb.Append("</ebl:PaymentAction>");
			}
			if(SolutionType != null)
			{
				sb.Append("<ebl:SolutionType>").Append(EnumUtils.getDescription(SolutionType));
				sb.Append("</ebl:SolutionType>");
			}
			if(LandingPage != null)
			{
				sb.Append("<ebl:LandingPage>").Append(EnumUtils.getDescription(LandingPage));
				sb.Append("</ebl:LandingPage>");
			}
			if(BuyerEmail != null)
			{
				sb.Append("<ebl:BuyerEmail>").Append(BuyerEmail);
				sb.Append("</ebl:BuyerEmail>");
			}
			if(ChannelType != null)
			{
				sb.Append("<ebl:ChannelType>").Append(EnumUtils.getDescription(ChannelType));
				sb.Append("</ebl:ChannelType>");
			}
			if(BillingAgreementDetails != null)
			{
				for(int i = 0; i < BillingAgreementDetails.Count; i++)
				{
					sb.Append("<ebl:BillingAgreementDetails>");
					sb.Append(BillingAgreementDetails[i].toXMLString());
					sb.Append("</ebl:BillingAgreementDetails>");
				
				}
			}
			if(PromoCodes != null)
			{
				for(int i = 0; i < PromoCodes.Count; i++)
				{
					sb.Append("<ebl:PromoCodes>").Append(PromoCodes[i]);
					sb.Append("</ebl:PromoCodes>");
				
				}
			}
			if(PayPalCheckOutBtnType != null)
			{
				sb.Append("<ebl:PayPalCheckOutBtnType>").Append(PayPalCheckOutBtnType);
				sb.Append("</ebl:PayPalCheckOutBtnType>");
			}
			if(ProductCategory != null)
			{
				sb.Append("<ebl:ProductCategory>").Append(EnumUtils.getDescription(ProductCategory));
				sb.Append("</ebl:ProductCategory>");
			}
			if(ShippingMethod != null)
			{
				sb.Append("<ebl:ShippingMethod>").Append(EnumUtils.getDescription(ShippingMethod));
				sb.Append("</ebl:ShippingMethod>");
			}
			if(ProfileAddressChangeDate != null)
			{
				sb.Append("<ebl:ProfileAddressChangeDate>").Append(ProfileAddressChangeDate);
				sb.Append("</ebl:ProfileAddressChangeDate>");
			}
			if(AllowNote != null)
			{
				sb.Append("<ebl:AllowNote>").Append(AllowNote);
				sb.Append("</ebl:AllowNote>");
			}
			if(FundingSourceDetails != null)
			{
				sb.Append("<ebl:FundingSourceDetails>");
				sb.Append(FundingSourceDetails.toXMLString());
				sb.Append("</ebl:FundingSourceDetails>");
			}
			if(BrandName != null)
			{
				sb.Append("<ebl:BrandName>").Append(BrandName);
				sb.Append("</ebl:BrandName>");
			}
			if(CallbackURL != null)
			{
				sb.Append("<ebl:CallbackURL>").Append(CallbackURL);
				sb.Append("</ebl:CallbackURL>");
			}
			if(EnhancedCheckoutData != null)
			{
				sb.Append("<ebl:EnhancedCheckoutData>");
				sb.Append(EnhancedCheckoutData.toXMLString());
				sb.Append("</ebl:EnhancedCheckoutData>");
			}
			if(OtherPaymentMethods != null)
			{
				for(int i = 0; i < OtherPaymentMethods.Count; i++)
				{
					sb.Append("<ebl:OtherPaymentMethods>");
					sb.Append(OtherPaymentMethods[i].toXMLString());
					sb.Append("</ebl:OtherPaymentMethods>");
				
				}
			}
			if(BuyerDetails != null)
			{
				sb.Append("<ebl:BuyerDetails>");
				sb.Append(BuyerDetails.toXMLString());
				sb.Append("</ebl:BuyerDetails>");
			}
			if(PaymentDetails != null)
			{
				for(int i = 0; i < PaymentDetails.Count; i++)
				{
					sb.Append("<ebl:PaymentDetails>");
					sb.Append(PaymentDetails[i].toXMLString());
					sb.Append("</ebl:PaymentDetails>");
				
				}
			}
			if(FlatRateShippingOptions != null)
			{
				for(int i = 0; i < FlatRateShippingOptions.Count; i++)
				{
					sb.Append("<ebl:FlatRateShippingOptions>");
					sb.Append(FlatRateShippingOptions[i].toXMLString());
					sb.Append("</ebl:FlatRateShippingOptions>");
				
				}
			}
			if(CallbackTimeout != null)
			{
				sb.Append("<ebl:CallbackTimeout>").Append(CallbackTimeout);
				sb.Append("</ebl:CallbackTimeout>");
			}
			if(CallbackVersion != null)
			{
				sb.Append("<ebl:CallbackVersion>").Append(CallbackVersion);
				sb.Append("</ebl:CallbackVersion>");
			}
			if(CustomerServiceNumber != null)
			{
				sb.Append("<ebl:CustomerServiceNumber>").Append(CustomerServiceNumber);
				sb.Append("</ebl:CustomerServiceNumber>");
			}
			if(GiftMessageEnable != null)
			{
				sb.Append("<ebl:GiftMessageEnable>").Append(GiftMessageEnable);
				sb.Append("</ebl:GiftMessageEnable>");
			}
			if(GiftReceiptEnable != null)
			{
				sb.Append("<ebl:GiftReceiptEnable>").Append(GiftReceiptEnable);
				sb.Append("</ebl:GiftReceiptEnable>");
			}
			if(GiftWrapEnable != null)
			{
				sb.Append("<ebl:GiftWrapEnable>").Append(GiftWrapEnable);
				sb.Append("</ebl:GiftWrapEnable>");
			}
			if(GiftWrapName != null)
			{
				sb.Append("<ebl:GiftWrapName>").Append(GiftWrapName);
				sb.Append("</ebl:GiftWrapName>");
			}
			if(GiftWrapAmount != null)
			{
				sb.Append("<ebl:GiftWrapAmount");
				sb.Append(GiftWrapAmount.toXMLString());
				sb.Append("</ebl:GiftWrapAmount>");
			}
			if(BuyerEmailOptInEnable != null)
			{
				sb.Append("<ebl:BuyerEmailOptInEnable>").Append(BuyerEmailOptInEnable);
				sb.Append("</ebl:BuyerEmailOptInEnable>");
			}
			if(SurveyEnable != null)
			{
				sb.Append("<ebl:SurveyEnable>").Append(SurveyEnable);
				sb.Append("</ebl:SurveyEnable>");
			}
			if(SurveyQuestion != null)
			{
				sb.Append("<ebl:SurveyQuestion>").Append(SurveyQuestion);
				sb.Append("</ebl:SurveyQuestion>");
			}
			if(SurveyChoice != null)
			{
				for(int i = 0; i < SurveyChoice.Count; i++)
				{
					sb.Append("<ebl:SurveyChoice>").Append(SurveyChoice[i]);
					sb.Append("</ebl:SurveyChoice>");
				
				}
			}
			if(TotalType != null)
			{
				sb.Append("<ebl:TotalType>").Append(EnumUtils.getDescription(TotalType));
				sb.Append("</ebl:TotalType>");
			}
			if(NoteToBuyer != null)
			{
				sb.Append("<ebl:NoteToBuyer>").Append(NoteToBuyer);
				sb.Append("</ebl:NoteToBuyer>");
			}
			if(Incentives != null)
			{
				for(int i = 0; i < Incentives.Count; i++)
				{
					sb.Append("<ebl:Incentives>");
					sb.Append(Incentives[i].toXMLString());
					sb.Append("</ebl:Incentives>");
				
				}
			}
			if(ReqInstrumentDetails != null)
			{
				sb.Append("<ebl:ReqInstrumentDetails>").Append(ReqInstrumentDetails);
				sb.Append("</ebl:ReqInstrumentDetails>");
			}
			if(ExternalRememberMeOptInDetails != null)
			{
				sb.Append("<ebl:ExternalRememberMeOptInDetails>");
				sb.Append(ExternalRememberMeOptInDetails.toXMLString());
				sb.Append("</ebl:ExternalRememberMeOptInDetails>");
			}
			if(FlowControlDetails != null)
			{
				sb.Append("<ebl:FlowControlDetails>");
				sb.Append(FlowControlDetails.toXMLString());
				sb.Append("</ebl:FlowControlDetails>");
			}
			if(DisplayControlDetails != null)
			{
				sb.Append("<ebl:DisplayControlDetails>");
				sb.Append(DisplayControlDetails.toXMLString());
				sb.Append("</ebl:DisplayControlDetails>");
			}
			if(ExternalPartnerTrackingDetails != null)
			{
				sb.Append("<ebl:ExternalPartnerTrackingDetails>");
				sb.Append(ExternalPartnerTrackingDetails.toXMLString());
				sb.Append("</ebl:ExternalPartnerTrackingDetails>");
			}
			return sb.ToString();
		}
	}




	/**
      *On your first invocation of
      *ExecuteCheckoutOperationsRequest, the value of this token is
      *returned by ExecuteCheckoutOperationsResponse. Optional
      *Include this element and its value only if you want to
      *modify an existing checkout session with another invocation
      *of ExecuteCheckoutOperationsRequest; for example, if you
      *want the customer to edit his shipping address on PayPal.
      *Character length and limitations: 20 single-byte characters 
      */
	public partial class ExecuteCheckoutOperationsRequestDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string TokenField;
		public string Token
		{
			get
			{
				return this.TokenField;
			}
			set
			{
				this.TokenField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private SetDataRequestType SetDataRequestField;
		public SetDataRequestType SetDataRequest
		{
			get
			{
				return this.SetDataRequestField;
			}
			set
			{
				this.SetDataRequestField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private AuthorizationRequestType AuthorizationRequestField;
		public AuthorizationRequestType AuthorizationRequest
		{
			get
			{
				return this.AuthorizationRequestField;
			}
			set
			{
				this.AuthorizationRequestField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public ExecuteCheckoutOperationsRequestDetailsType(SetDataRequestType SetDataRequest){
			this.SetDataRequest = SetDataRequest;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public ExecuteCheckoutOperationsRequestDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Token != null)
			{
				sb.Append("<ebl:Token>").Append(Token);
				sb.Append("</ebl:Token>");
			}
			if(SetDataRequest != null)
			{
				sb.Append("<ebl:SetDataRequest>");
				sb.Append(SetDataRequest.toXMLString());
				sb.Append("</ebl:SetDataRequest>");
			}
			if(AuthorizationRequest != null)
			{
				sb.Append("<ebl:AuthorizationRequest>");
				sb.Append(AuthorizationRequest.toXMLString());
				sb.Append("</ebl:AuthorizationRequest>");
			}
			return sb.ToString();
		}
	}




	/**
      *Details about Billing Agreements requested to be created. 
      */
	public partial class SetDataRequestType	
	{

		/**
          *No Document Comments
		  */
		private List<BillingApprovalDetailsType> BillingApprovalDetailsField = new List<BillingApprovalDetailsType>();
		public List<BillingApprovalDetailsType> BillingApprovalDetails
		{
			get
			{
				return this.BillingApprovalDetailsField;
			}
			set
			{
				this.BillingApprovalDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BuyerDetailType BuyerDetailField;
		public BuyerDetailType BuyerDetail
		{
			get
			{
				return this.BuyerDetailField;
			}
			set
			{
				this.BuyerDetailField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private InfoSharingDirectivesType InfoSharingDirectivesField;
		public InfoSharingDirectivesType InfoSharingDirectives
		{
			get
			{
				return this.InfoSharingDirectivesField;
			}
			set
			{
				this.InfoSharingDirectivesField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public SetDataRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(BillingApprovalDetails != null)
			{
				for(int i = 0; i < BillingApprovalDetails.Count; i++)
				{
					sb.Append("<ebl:BillingApprovalDetails>");
					sb.Append(BillingApprovalDetails[i].toXMLString());
					sb.Append("</ebl:BillingApprovalDetails>");
				
				}
			}
			if(BuyerDetail != null)
			{
				sb.Append("<ebl:BuyerDetail>");
				sb.Append(BuyerDetail.toXMLString());
				sb.Append("</ebl:BuyerDetail>");
			}
			if(InfoSharingDirectives != null)
			{
				sb.Append("<ebl:InfoSharingDirectives>");
				sb.Append(InfoSharingDirectives.toXMLString());
				sb.Append("</ebl:InfoSharingDirectives>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class AuthorizationRequestType	
	{

		/**
          *No Document Comments
		  */
		private bool? IsRequestedField;
		public bool? IsRequested
		{
			get
			{
				return this.IsRequestedField;
			}
			set
			{
				this.IsRequestedField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public AuthorizationRequestType(bool? IsRequested){
			this.IsRequested = IsRequested;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public AuthorizationRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(IsRequested != null)
			{
				sb.Append("<ebl:IsRequested>").Append(IsRequested);
				sb.Append("</ebl:IsRequested>");
			}
			return sb.ToString();
		}
	}




	/**
      *The Type of Approval requested - Billing Agreement or
      *Profile 
      */
	public partial class BillingApprovalDetailsType	
	{

		/**
          *No Document Comments
		  */
		private ApprovalTypeType? ApprovalTypeField;
		public ApprovalTypeType? ApprovalType
		{
			get
			{
				return this.ApprovalTypeField;
			}
			set
			{
				this.ApprovalTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ApprovalSubTypeType? ApprovalSubTypeField;
		public ApprovalSubTypeType? ApprovalSubType
		{
			get
			{
				return this.ApprovalSubTypeField;
			}
			set
			{
				this.ApprovalSubTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private OrderDetailsType OrderDetailsField;
		public OrderDetailsType OrderDetails
		{
			get
			{
				return this.OrderDetailsField;
			}
			set
			{
				this.OrderDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PaymentDirectivesType PaymentDirectivesField;
		public PaymentDirectivesType PaymentDirectives
		{
			get
			{
				return this.PaymentDirectivesField;
			}
			set
			{
				this.PaymentDirectivesField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CustomField;
		public string Custom
		{
			get
			{
				return this.CustomField;
			}
			set
			{
				this.CustomField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public BillingApprovalDetailsType(ApprovalTypeType? ApprovalType){
			this.ApprovalType = ApprovalType;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public BillingApprovalDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ApprovalType != null)
			{
				sb.Append("<ebl:ApprovalType>").Append(EnumUtils.getDescription(ApprovalType));
				sb.Append("</ebl:ApprovalType>");
			}
			if(ApprovalSubType != null)
			{
				sb.Append("<ebl:ApprovalSubType>").Append(EnumUtils.getDescription(ApprovalSubType));
				sb.Append("</ebl:ApprovalSubType>");
			}
			if(OrderDetails != null)
			{
				sb.Append("<ebl:OrderDetails>");
				sb.Append(OrderDetails.toXMLString());
				sb.Append("</ebl:OrderDetails>");
			}
			if(PaymentDirectives != null)
			{
				sb.Append("<ebl:PaymentDirectives>");
				sb.Append(PaymentDirectives.toXMLString());
				sb.Append("</ebl:PaymentDirectives>");
			}
			if(Custom != null)
			{
				sb.Append("<ebl:Custom>").Append(Custom);
				sb.Append("</ebl:Custom>");
			}
			return sb.ToString();
		}
	}




	/**
      *If Billing Address should be returned in
      *GetExpressCheckoutDetails response, this parameter should be
      *set to yes here 
      */
	public partial class InfoSharingDirectivesType	
	{

		/**
          *No Document Comments
		  */
		private string ReqBillingAddressField;
		public string ReqBillingAddress
		{
			get
			{
				return this.ReqBillingAddressField;
			}
			set
			{
				this.ReqBillingAddressField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public InfoSharingDirectivesType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ReqBillingAddress != null)
			{
				sb.Append("<ebl:ReqBillingAddress>").Append(ReqBillingAddress);
				sb.Append("</ebl:ReqBillingAddress>");
			}
			return sb.ToString();
		}
	}




	/**
      *Description of the Order. 
      */
	public partial class OrderDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string DescriptionField;
		public string Description
		{
			get
			{
				return this.DescriptionField;
			}
			set
			{
				this.DescriptionField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType MaxAmountField;
		public BasicAmountType MaxAmount
		{
			get
			{
				return this.MaxAmountField;
			}
			set
			{
				this.MaxAmountField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public OrderDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Description != null)
			{
				sb.Append("<ebl:Description>").Append(Description);
				sb.Append("</ebl:Description>");
			}
			if(MaxAmount != null)
			{
				sb.Append("<ebl:MaxAmount");
				sb.Append(MaxAmount.toXMLString());
				sb.Append("</ebl:MaxAmount>");
			}
			return sb.ToString();
		}
	}




	/**
      *Type of the Payment is it Instant or Echeck or Any. 
      */
	public partial class PaymentDirectivesType	
	{

		/**
          *No Document Comments
		  */
		private MerchantPullPaymentCodeType? PaymentTypeField;
		public MerchantPullPaymentCodeType? PaymentType
		{
			get
			{
				return this.PaymentTypeField;
			}
			set
			{
				this.PaymentTypeField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public PaymentDirectivesType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(PaymentType != null)
			{
				sb.Append("<ebl:PaymentType>").Append(EnumUtils.getDescription(PaymentType));
				sb.Append("</ebl:PaymentType>");
			}
			return sb.ToString();
		}
	}




	/**
      *Information that is used to indentify the Buyer. This is
      *used for auto authorization. Mandatory if Authorization is
      *requested. 
      */
	public partial class BuyerDetailType	
	{

		/**
          *No Document Comments
		  */
		private IdentificationInfoType IdentificationInfoField;
		public IdentificationInfoType IdentificationInfo
		{
			get
			{
				return this.IdentificationInfoField;
			}
			set
			{
				this.IdentificationInfoField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public BuyerDetailType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(IdentificationInfo != null)
			{
				sb.Append("<ebl:IdentificationInfo>");
				sb.Append(IdentificationInfo.toXMLString());
				sb.Append("</ebl:IdentificationInfo>");
			}
			return sb.ToString();
		}
	}




	/**
      *Mobile specific buyer identification. 
      */
	public partial class IdentificationInfoType	
	{

		/**
          *No Document Comments
		  */
		private MobileIDInfoType MobileIDInfoField;
		public MobileIDInfoType MobileIDInfo
		{
			get
			{
				return this.MobileIDInfoField;
			}
			set
			{
				this.MobileIDInfoField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private RememberMeIDInfoType RememberMeIDInfoField;
		public RememberMeIDInfoType RememberMeIDInfo
		{
			get
			{
				return this.RememberMeIDInfoField;
			}
			set
			{
				this.RememberMeIDInfoField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private IdentityTokenInfoType IdentityTokenInfoField;
		public IdentityTokenInfoType IdentityTokenInfo
		{
			get
			{
				return this.IdentityTokenInfoField;
			}
			set
			{
				this.IdentityTokenInfoField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public IdentificationInfoType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(MobileIDInfo != null)
			{
				sb.Append("<ebl:MobileIDInfo>");
				sb.Append(MobileIDInfo.toXMLString());
				sb.Append("</ebl:MobileIDInfo>");
			}
			if(RememberMeIDInfo != null)
			{
				sb.Append("<ebl:RememberMeIDInfo>");
				sb.Append(RememberMeIDInfo.toXMLString());
				sb.Append("</ebl:RememberMeIDInfo>");
			}
			if(IdentityTokenInfo != null)
			{
				sb.Append("<ebl:IdentityTokenInfo>");
				sb.Append(IdentityTokenInfo.toXMLString());
				sb.Append("</ebl:IdentityTokenInfo>");
			}
			return sb.ToString();
		}
	}




	/**
      *The Session token returned during buyer authentication. 
      */
	public partial class MobileIDInfoType	
	{

		/**
          *No Document Comments
		  */
		private string SessionTokenField;
		public string SessionToken
		{
			get
			{
				return this.SessionTokenField;
			}
			set
			{
				this.SessionTokenField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public MobileIDInfoType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(SessionToken != null)
			{
				sb.Append("<ebl:SessionToken>").Append(SessionToken);
				sb.Append("</ebl:SessionToken>");
			}
			return sb.ToString();
		}
	}




	/**
      *External remember-me ID returned by
      *GetExpressCheckoutDetails on successful opt-in. The
      *ExternalRememberMeID is a 17-character alphanumeric
      *(encrypted) string that identifies the buyer's remembered
      *login with a merchant and has meaning only to the merchant.
      *If present, requests that the web flow attempt bypass of
      *login. 
      */
	public partial class RememberMeIDInfoType	
	{

		/**
          *No Document Comments
		  */
		private string ExternalRememberMeIDField;
		public string ExternalRememberMeID
		{
			get
			{
				return this.ExternalRememberMeIDField;
			}
			set
			{
				this.ExternalRememberMeIDField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public RememberMeIDInfoType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ExternalRememberMeID != null)
			{
				sb.Append("<ebl:ExternalRememberMeID>").Append(ExternalRememberMeID);
				sb.Append("</ebl:ExternalRememberMeID>");
			}
			return sb.ToString();
		}
	}




	/**
      *Identity Access token from merchant 
      */
	public partial class IdentityTokenInfoType	
	{

		/**
          *No Document Comments
		  */
		private string AccessTokenField;
		public string AccessToken
		{
			get
			{
				return this.AccessTokenField;
			}
			set
			{
				this.AccessTokenField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public IdentityTokenInfoType(string AccessToken){
			this.AccessToken = AccessToken;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public IdentityTokenInfoType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(AccessToken != null)
			{
				sb.Append("<ebl:AccessToken>").Append(AccessToken);
				sb.Append("</ebl:AccessToken>");
			}
			return sb.ToString();
		}
	}




	/**
      *Allowable values: 0,1 The value 1 indicates that the
      *customer can accept push funding, and 0 means they cannot.
      *Optional Character length and limitations: One single-byte
      *numeric character. 
      */
	public partial class FundingSourceDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string AllowPushFundingField;
		public string AllowPushFunding
		{
			get
			{
				return this.AllowPushFundingField;
			}
			set
			{
				this.AllowPushFundingField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private UserSelectedFundingSourceType? UserSelectedFundingSourceField;
		public UserSelectedFundingSourceType? UserSelectedFundingSource
		{
			get
			{
				return this.UserSelectedFundingSourceField;
			}
			set
			{
				this.UserSelectedFundingSourceField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public FundingSourceDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(AllowPushFunding != null)
			{
				sb.Append("<ebl:AllowPushFunding>").Append(AllowPushFunding);
				sb.Append("</ebl:AllowPushFunding>");
			}
			if(UserSelectedFundingSource != null)
			{
				sb.Append("<ebl:UserSelectedFundingSource>").Append(EnumUtils.getDescription(UserSelectedFundingSource));
				sb.Append("</ebl:UserSelectedFundingSource>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class BillingAgreementDetailsType	
	{

		/**
          *No Document Comments
		  */
		private BillingCodeType? BillingTypeField;
		public BillingCodeType? BillingType
		{
			get
			{
				return this.BillingTypeField;
			}
			set
			{
				this.BillingTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string BillingAgreementDescriptionField;
		public string BillingAgreementDescription
		{
			get
			{
				return this.BillingAgreementDescriptionField;
			}
			set
			{
				this.BillingAgreementDescriptionField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private MerchantPullPaymentCodeType? PaymentTypeField;
		public MerchantPullPaymentCodeType? PaymentType
		{
			get
			{
				return this.PaymentTypeField;
			}
			set
			{
				this.PaymentTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string BillingAgreementCustomField;
		public string BillingAgreementCustom
		{
			get
			{
				return this.BillingAgreementCustomField;
			}
			set
			{
				this.BillingAgreementCustomField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public BillingAgreementDetailsType(BillingCodeType? BillingType){
			this.BillingType = BillingType;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public BillingAgreementDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(BillingType != null)
			{
				sb.Append("<ebl:BillingType>").Append(EnumUtils.getDescription(BillingType));
				sb.Append("</ebl:BillingType>");
			}
			if(BillingAgreementDescription != null)
			{
				sb.Append("<ebl:BillingAgreementDescription>").Append(BillingAgreementDescription);
				sb.Append("</ebl:BillingAgreementDescription>");
			}
			if(PaymentType != null)
			{
				sb.Append("<ebl:PaymentType>").Append(EnumUtils.getDescription(PaymentType));
				sb.Append("</ebl:PaymentType>");
			}
			if(BillingAgreementCustom != null)
			{
				sb.Append("<ebl:BillingAgreementCustom>").Append(BillingAgreementCustom);
				sb.Append("</ebl:BillingAgreementCustom>");
			}
			return sb.ToString();
		}
	}




	/**
      *The timestamped token value that was returned by
      *SetExpressCheckoutResponse and passed on
      *GetExpressCheckoutDetailsRequest. Character length and
      *limitations: 20 single-byte characters 
      */
	public partial class GetExpressCheckoutDetailsResponseDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string TokenField;
		public string Token
		{
			get
			{
				return this.TokenField;
			}
			set
			{
				this.TokenField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PayerInfoType PayerInfoField;
		public PayerInfoType PayerInfo
		{
			get
			{
				return this.PayerInfoField;
			}
			set
			{
				this.PayerInfoField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CustomField;
		public string Custom
		{
			get
			{
				return this.CustomField;
			}
			set
			{
				this.CustomField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string InvoiceIDField;
		public string InvoiceID
		{
			get
			{
				return this.InvoiceIDField;
			}
			set
			{
				this.InvoiceIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ContactPhoneField;
		public string ContactPhone
		{
			get
			{
				return this.ContactPhoneField;
			}
			set
			{
				this.ContactPhoneField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private bool? BillingAgreementAcceptedStatusField;
		public bool? BillingAgreementAcceptedStatus
		{
			get
			{
				return this.BillingAgreementAcceptedStatusField;
			}
			set
			{
				this.BillingAgreementAcceptedStatusField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string RedirectRequiredField;
		public string RedirectRequired
		{
			get
			{
				return this.RedirectRequiredField;
			}
			set
			{
				this.RedirectRequiredField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private AddressType BillingAddressField;
		public AddressType BillingAddress
		{
			get
			{
				return this.BillingAddressField;
			}
			set
			{
				this.BillingAddressField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string NoteField;
		public string Note
		{
			get
			{
				return this.NoteField;
			}
			set
			{
				this.NoteField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CheckoutStatusField;
		public string CheckoutStatus
		{
			get
			{
				return this.CheckoutStatusField;
			}
			set
			{
				this.CheckoutStatusField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType PayPalAdjustmentField;
		public BasicAmountType PayPalAdjustment
		{
			get
			{
				return this.PayPalAdjustmentField;
			}
			set
			{
				this.PayPalAdjustmentField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<PaymentDetailsType> PaymentDetailsField = new List<PaymentDetailsType>();
		public List<PaymentDetailsType> PaymentDetails
		{
			get
			{
				return this.PaymentDetailsField;
			}
			set
			{
				this.PaymentDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private UserSelectedOptionType UserSelectedOptionsField;
		public UserSelectedOptionType UserSelectedOptions
		{
			get
			{
				return this.UserSelectedOptionsField;
			}
			set
			{
				this.UserSelectedOptionsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<IncentiveDetailsType> IncentiveDetailsField = new List<IncentiveDetailsType>();
		public List<IncentiveDetailsType> IncentiveDetails
		{
			get
			{
				return this.IncentiveDetailsField;
			}
			set
			{
				this.IncentiveDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string GiftMessageField;
		public string GiftMessage
		{
			get
			{
				return this.GiftMessageField;
			}
			set
			{
				this.GiftMessageField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string GiftReceiptEnableField;
		public string GiftReceiptEnable
		{
			get
			{
				return this.GiftReceiptEnableField;
			}
			set
			{
				this.GiftReceiptEnableField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string GiftWrapNameField;
		public string GiftWrapName
		{
			get
			{
				return this.GiftWrapNameField;
			}
			set
			{
				this.GiftWrapNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType GiftWrapAmountField;
		public BasicAmountType GiftWrapAmount
		{
			get
			{
				return this.GiftWrapAmountField;
			}
			set
			{
				this.GiftWrapAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string BuyerMarketingEmailField;
		public string BuyerMarketingEmail
		{
			get
			{
				return this.BuyerMarketingEmailField;
			}
			set
			{
				this.BuyerMarketingEmailField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string SurveyQuestionField;
		public string SurveyQuestion
		{
			get
			{
				return this.SurveyQuestionField;
			}
			set
			{
				this.SurveyQuestionField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<string> SurveyChoiceSelectedField = new List<string>();
		public List<string> SurveyChoiceSelected
		{
			get
			{
				return this.SurveyChoiceSelectedField;
			}
			set
			{
				this.SurveyChoiceSelectedField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<PaymentRequestInfoType> PaymentRequestInfoField = new List<PaymentRequestInfoType>();
		public List<PaymentRequestInfoType> PaymentRequestInfo
		{
			get
			{
				return this.PaymentRequestInfoField;
			}
			set
			{
				this.PaymentRequestInfoField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ExternalRememberMeStatusDetailsType ExternalRememberMeStatusDetailsField;
		public ExternalRememberMeStatusDetailsType ExternalRememberMeStatusDetails
		{
			get
			{
				return this.ExternalRememberMeStatusDetailsField;
			}
			set
			{
				this.ExternalRememberMeStatusDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public GetExpressCheckoutDetailsResponseDetailsType(){
		}


		public GetExpressCheckoutDetailsResponseDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("Token").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Token")[0]))
			{
				this.Token = (string)document.GetElementsByTagName("Token")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("PayerInfo").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PayerInfo")[0]))
				{
					nodeList = document.GetElementsByTagName("PayerInfo");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.PayerInfo =  new PayerInfoType(xmlString);
				}
			}
		if(document.GetElementsByTagName("Custom").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Custom")[0]))
			{
				this.Custom = (string)document.GetElementsByTagName("Custom")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("InvoiceID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("InvoiceID")[0]))
			{
				this.InvoiceID = (string)document.GetElementsByTagName("InvoiceID")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ContactPhone").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ContactPhone")[0]))
			{
				this.ContactPhone = (string)document.GetElementsByTagName("ContactPhone")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("BillingAgreementAcceptedStatus").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillingAgreementAcceptedStatus")[0]))
			{
				this.BillingAgreementAcceptedStatus = System.Convert.ToBoolean(document.GetElementsByTagName("BillingAgreementAcceptedStatus")[0].InnerText);
			}
		}
		if(document.GetElementsByTagName("RedirectRequired").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("RedirectRequired")[0]))
			{
				this.RedirectRequired = (string)document.GetElementsByTagName("RedirectRequired")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("BillingAddress").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillingAddress")[0]))
				{
					nodeList = document.GetElementsByTagName("BillingAddress");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.BillingAddress =  new AddressType(xmlString);
				}
			}
		if(document.GetElementsByTagName("Note").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Note")[0]))
			{
				this.Note = (string)document.GetElementsByTagName("Note")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("CheckoutStatus").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CheckoutStatus")[0]))
			{
				this.CheckoutStatus = (string)document.GetElementsByTagName("CheckoutStatus")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("PayPalAdjustment").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PayPalAdjustment")[0]))
				{
					nodeList = document.GetElementsByTagName("PayPalAdjustment");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.PayPalAdjustment =  new BasicAmountType(xmlString);
				}
			}
			if(document.GetElementsByTagName("PaymentDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("PaymentDetails");
					for(int i = 0; i < nodeList.Count; i++)
					{
						xmlString = DeserializationUtils.convertToXML(nodeList[i]);
						this.PaymentDetails.Add(new PaymentDetailsType(xmlString));
					}
				}
			}
			if(document.GetElementsByTagName("UserSelectedOptions").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("UserSelectedOptions")[0]))
				{
					nodeList = document.GetElementsByTagName("UserSelectedOptions");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.UserSelectedOptions =  new UserSelectedOptionType(xmlString);
				}
			}
			if(document.GetElementsByTagName("IncentiveDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("IncentiveDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("IncentiveDetails");
					for(int i = 0; i < nodeList.Count; i++)
					{
						xmlString = DeserializationUtils.convertToXML(nodeList[i]);
						this.IncentiveDetails.Add(new IncentiveDetailsType(xmlString));
					}
				}
			}
		if(document.GetElementsByTagName("GiftMessage").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GiftMessage")[0]))
			{
				this.GiftMessage = (string)document.GetElementsByTagName("GiftMessage")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("GiftReceiptEnable").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GiftReceiptEnable")[0]))
			{
				this.GiftReceiptEnable = (string)document.GetElementsByTagName("GiftReceiptEnable")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("GiftWrapName").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GiftWrapName")[0]))
			{
				this.GiftWrapName = (string)document.GetElementsByTagName("GiftWrapName")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("GiftWrapAmount").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GiftWrapAmount")[0]))
				{
					nodeList = document.GetElementsByTagName("GiftWrapAmount");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.GiftWrapAmount =  new BasicAmountType(xmlString);
				}
			}
		if(document.GetElementsByTagName("BuyerMarketingEmail").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BuyerMarketingEmail")[0]))
			{
				this.BuyerMarketingEmail = (string)document.GetElementsByTagName("BuyerMarketingEmail")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("SurveyQuestion").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SurveyQuestion")[0]))
			{
				this.SurveyQuestion = (string)document.GetElementsByTagName("SurveyQuestion")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("SurveyChoiceSelected").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SurveyChoiceSelected")[0]))
				{
					nodeList = document.GetElementsByTagName("SurveyChoiceSelected");
					for(int i = 0; i < nodeList.Count; i++)
					{
						string value = nodeList[i].InnerText;
						this.SurveyChoiceSelected.Add(value);
					}
				}
			}
			if(document.GetElementsByTagName("PaymentRequestInfo").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentRequestInfo")[0]))
				{
					nodeList = document.GetElementsByTagName("PaymentRequestInfo");
					for(int i = 0; i < nodeList.Count; i++)
					{
						xmlString = DeserializationUtils.convertToXML(nodeList[i]);
						this.PaymentRequestInfo.Add(new PaymentRequestInfoType(xmlString));
					}
				}
			}
			if(document.GetElementsByTagName("ExternalRememberMeStatusDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ExternalRememberMeStatusDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("ExternalRememberMeStatusDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.ExternalRememberMeStatusDetails =  new ExternalRememberMeStatusDetailsType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *
      */
	public partial class ExecuteCheckoutOperationsResponseDetailsType	
	{

		/**
          *No Document Comments
		  */
		private SetDataResponseType SetDataResponseField;
		public SetDataResponseType SetDataResponse
		{
			get
			{
				return this.SetDataResponseField;
			}
			set
			{
				this.SetDataResponseField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private AuthorizationResponseType AuthorizationResponseField;
		public AuthorizationResponseType AuthorizationResponse
		{
			get
			{
				return this.AuthorizationResponseField;
			}
			set
			{
				this.AuthorizationResponseField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public ExecuteCheckoutOperationsResponseDetailsType(){
		}


		public ExecuteCheckoutOperationsResponseDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("SetDataResponse").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SetDataResponse")[0]))
				{
					nodeList = document.GetElementsByTagName("SetDataResponse");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.SetDataResponse =  new SetDataResponseType(xmlString);
				}
			}
			if(document.GetElementsByTagName("AuthorizationResponse").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AuthorizationResponse")[0]))
				{
					nodeList = document.GetElementsByTagName("AuthorizationResponse");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.AuthorizationResponse =  new AuthorizationResponseType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *If Checkout session was initialized successfully, the
      *corresponding token is returned in this element. 
      */
	public partial class SetDataResponseType	
	{

		/**
          *No Document Comments
		  */
		private string TokenField;
		public string Token
		{
			get
			{
				return this.TokenField;
			}
			set
			{
				this.TokenField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<ErrorType> SetDataErrorField = new List<ErrorType>();
		public List<ErrorType> SetDataError
		{
			get
			{
				return this.SetDataErrorField;
			}
			set
			{
				this.SetDataErrorField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public SetDataResponseType(){
		}


		public SetDataResponseType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("Token").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Token")[0]))
			{
				this.Token = (string)document.GetElementsByTagName("Token")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("SetDataError").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SetDataError")[0]))
				{
					nodeList = document.GetElementsByTagName("SetDataError");
					for(int i = 0; i < nodeList.Count; i++)
					{
						xmlString = DeserializationUtils.convertToXML(nodeList[i]);
						this.SetDataError.Add(new ErrorType(xmlString));
					}
				}
			}
	
		}
		
	}




	/**
      *Status will denote whether Auto authorization was successful
      *or not. 
      */
	public partial class AuthorizationResponseType	
	{

		/**
          *No Document Comments
		  */
		private AckCodeType? StatusField;
		public AckCodeType? Status
		{
			get
			{
				return this.StatusField;
			}
			set
			{
				this.StatusField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<ErrorType> AuthorizationErrorField = new List<ErrorType>();
		public List<ErrorType> AuthorizationError
		{
			get
			{
				return this.AuthorizationErrorField;
			}
			set
			{
				this.AuthorizationErrorField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public AuthorizationResponseType(){
		}


		public AuthorizationResponseType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("Status").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Status")[0]))
				{
					this.Status = (AckCodeType)EnumUtils.getValue(document.GetElementsByTagName("Status")[0].InnerText,typeof(AckCodeType));
				}
			}
			if(document.GetElementsByTagName("AuthorizationError").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AuthorizationError")[0]))
				{
					nodeList = document.GetElementsByTagName("AuthorizationError");
					for(int i = 0; i < nodeList.Count; i++)
					{
						xmlString = DeserializationUtils.convertToXML(nodeList[i]);
						this.AuthorizationError.Add(new ErrorType(xmlString));
					}
				}
			}
	
		}
		
	}




	/**
      *How you want to obtain payment. Required Authorization
      *indicates that this payment is a basic authorization subject
      *to settlement with PayPal Authorization and Capture. Order
      *indicates that this payment is is an order authorization
      *subject to settlement with PayPal Authorization and Capture.
      *Sale indicates that this is a final sale for which you are
      *requesting payment. IMPORTANT: You cannot set PaymentAction
      *to Sale on SetExpressCheckoutRequest and then change
      *PaymentAction to Authorization on the final Express Checkout
      *API, DoExpressCheckoutPaymentRequest. Character length and
      *limit: Up to 13 single-byte alphabetic characters 
      */
	public partial class DoExpressCheckoutPaymentRequestDetailsType	
	{

		/**
          *No Document Comments
		  */
		private PaymentActionCodeType? PaymentActionField;
		public PaymentActionCodeType? PaymentAction
		{
			get
			{
				return this.PaymentActionField;
			}
			set
			{
				this.PaymentActionField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string TokenField;
		public string Token
		{
			get
			{
				return this.TokenField;
			}
			set
			{
				this.TokenField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PayerIDField;
		public string PayerID
		{
			get
			{
				return this.PayerIDField;
			}
			set
			{
				this.PayerIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string OrderURLField;
		public string OrderURL
		{
			get
			{
				return this.OrderURLField;
			}
			set
			{
				this.OrderURLField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<PaymentDetailsType> PaymentDetailsField = new List<PaymentDetailsType>();
		public List<PaymentDetailsType> PaymentDetails
		{
			get
			{
				return this.PaymentDetailsField;
			}
			set
			{
				this.PaymentDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PromoOverrideFlagField;
		public string PromoOverrideFlag
		{
			get
			{
				return this.PromoOverrideFlagField;
			}
			set
			{
				this.PromoOverrideFlagField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PromoCodeField;
		public string PromoCode
		{
			get
			{
				return this.PromoCodeField;
			}
			set
			{
				this.PromoCodeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private EnhancedDataType EnhancedDataField;
		public EnhancedDataType EnhancedData
		{
			get
			{
				return this.EnhancedDataField;
			}
			set
			{
				this.EnhancedDataField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string SoftDescriptorField;
		public string SoftDescriptor
		{
			get
			{
				return this.SoftDescriptorField;
			}
			set
			{
				this.SoftDescriptorField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private UserSelectedOptionType UserSelectedOptionsField;
		public UserSelectedOptionType UserSelectedOptions
		{
			get
			{
				return this.UserSelectedOptionsField;
			}
			set
			{
				this.UserSelectedOptionsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string GiftMessageField;
		public string GiftMessage
		{
			get
			{
				return this.GiftMessageField;
			}
			set
			{
				this.GiftMessageField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string GiftReceiptEnableField;
		public string GiftReceiptEnable
		{
			get
			{
				return this.GiftReceiptEnableField;
			}
			set
			{
				this.GiftReceiptEnableField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string GiftWrapNameField;
		public string GiftWrapName
		{
			get
			{
				return this.GiftWrapNameField;
			}
			set
			{
				this.GiftWrapNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType GiftWrapAmountField;
		public BasicAmountType GiftWrapAmount
		{
			get
			{
				return this.GiftWrapAmountField;
			}
			set
			{
				this.GiftWrapAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string BuyerMarketingEmailField;
		public string BuyerMarketingEmail
		{
			get
			{
				return this.BuyerMarketingEmailField;
			}
			set
			{
				this.BuyerMarketingEmailField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string SurveyQuestionField;
		public string SurveyQuestion
		{
			get
			{
				return this.SurveyQuestionField;
			}
			set
			{
				this.SurveyQuestionField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<string> SurveyChoiceSelectedField = new List<string>();
		public List<string> SurveyChoiceSelected
		{
			get
			{
				return this.SurveyChoiceSelectedField;
			}
			set
			{
				this.SurveyChoiceSelectedField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ButtonSourceField;
		public string ButtonSource
		{
			get
			{
				return this.ButtonSourceField;
			}
			set
			{
				this.ButtonSourceField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private bool? SkipBACreationField;
		public bool? SkipBACreation
		{
			get
			{
				return this.SkipBACreationField;
			}
			set
			{
				this.SkipBACreationField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DoExpressCheckoutPaymentRequestDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(PaymentAction != null)
			{
				sb.Append("<ebl:PaymentAction>").Append(EnumUtils.getDescription(PaymentAction));
				sb.Append("</ebl:PaymentAction>");
			}
			if(Token != null)
			{
				sb.Append("<ebl:Token>").Append(Token);
				sb.Append("</ebl:Token>");
			}
			if(PayerID != null)
			{
				sb.Append("<ebl:PayerID>").Append(PayerID);
				sb.Append("</ebl:PayerID>");
			}
			if(OrderURL != null)
			{
				sb.Append("<ebl:OrderURL>").Append(OrderURL);
				sb.Append("</ebl:OrderURL>");
			}
			if(PaymentDetails != null)
			{
				for(int i = 0; i < PaymentDetails.Count; i++)
				{
					sb.Append("<ebl:PaymentDetails>");
					sb.Append(PaymentDetails[i].toXMLString());
					sb.Append("</ebl:PaymentDetails>");
				
				}
			}
			if(PromoOverrideFlag != null)
			{
				sb.Append("<ebl:PromoOverrideFlag>").Append(PromoOverrideFlag);
				sb.Append("</ebl:PromoOverrideFlag>");
			}
			if(PromoCode != null)
			{
				sb.Append("<ebl:PromoCode>").Append(PromoCode);
				sb.Append("</ebl:PromoCode>");
			}
			if(EnhancedData != null)
			{
				sb.Append("<ebl:EnhancedData>");
				sb.Append(EnhancedData.toXMLString());
				sb.Append("</ebl:EnhancedData>");
			}
			if(SoftDescriptor != null)
			{
				sb.Append("<ebl:SoftDescriptor>").Append(SoftDescriptor);
				sb.Append("</ebl:SoftDescriptor>");
			}
			if(UserSelectedOptions != null)
			{
				sb.Append("<ebl:UserSelectedOptions>");
				sb.Append(UserSelectedOptions.toXMLString());
				sb.Append("</ebl:UserSelectedOptions>");
			}
			if(GiftMessage != null)
			{
				sb.Append("<ebl:GiftMessage>").Append(GiftMessage);
				sb.Append("</ebl:GiftMessage>");
			}
			if(GiftReceiptEnable != null)
			{
				sb.Append("<ebl:GiftReceiptEnable>").Append(GiftReceiptEnable);
				sb.Append("</ebl:GiftReceiptEnable>");
			}
			if(GiftWrapName != null)
			{
				sb.Append("<ebl:GiftWrapName>").Append(GiftWrapName);
				sb.Append("</ebl:GiftWrapName>");
			}
			if(GiftWrapAmount != null)
			{
				sb.Append("<ebl:GiftWrapAmount");
				sb.Append(GiftWrapAmount.toXMLString());
				sb.Append("</ebl:GiftWrapAmount>");
			}
			if(BuyerMarketingEmail != null)
			{
				sb.Append("<ebl:BuyerMarketingEmail>").Append(BuyerMarketingEmail);
				sb.Append("</ebl:BuyerMarketingEmail>");
			}
			if(SurveyQuestion != null)
			{
				sb.Append("<ebl:SurveyQuestion>").Append(SurveyQuestion);
				sb.Append("</ebl:SurveyQuestion>");
			}
			if(SurveyChoiceSelected != null)
			{
				for(int i = 0; i < SurveyChoiceSelected.Count; i++)
				{
					sb.Append("<ebl:SurveyChoiceSelected>").Append(SurveyChoiceSelected[i]);
					sb.Append("</ebl:SurveyChoiceSelected>");
				
				}
			}
			if(ButtonSource != null)
			{
				sb.Append("<ebl:ButtonSource>").Append(ButtonSource);
				sb.Append("</ebl:ButtonSource>");
			}
			if(SkipBACreation != null)
			{
				sb.Append("<ebl:SkipBACreation>").Append(SkipBACreation);
				sb.Append("</ebl:SkipBACreation>");
			}
			return sb.ToString();
		}
	}




	/**
      *The timestamped token value that was returned by
      *SetExpressCheckoutResponse and passed on
      *GetExpressCheckoutDetailsRequest. Character length and
      *limitations:20 single-byte characters 
      */
	public partial class DoExpressCheckoutPaymentResponseDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string TokenField;
		public string Token
		{
			get
			{
				return this.TokenField;
			}
			set
			{
				this.TokenField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<PaymentInfoType> PaymentInfoField = new List<PaymentInfoType>();
		public List<PaymentInfoType> PaymentInfo
		{
			get
			{
				return this.PaymentInfoField;
			}
			set
			{
				this.PaymentInfoField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string BillingAgreementIDField;
		public string BillingAgreementID
		{
			get
			{
				return this.BillingAgreementIDField;
			}
			set
			{
				this.BillingAgreementIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string RedirectRequiredField;
		public string RedirectRequired
		{
			get
			{
				return this.RedirectRequiredField;
			}
			set
			{
				this.RedirectRequiredField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string NoteField;
		public string Note
		{
			get
			{
				return this.NoteField;
			}
			set
			{
				this.NoteField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string SuccessPageRedirectRequestedField;
		public string SuccessPageRedirectRequested
		{
			get
			{
				return this.SuccessPageRedirectRequestedField;
			}
			set
			{
				this.SuccessPageRedirectRequestedField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private UserSelectedOptionType UserSelectedOptionsField;
		public UserSelectedOptionType UserSelectedOptions
		{
			get
			{
				return this.UserSelectedOptionsField;
			}
			set
			{
				this.UserSelectedOptionsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DoExpressCheckoutPaymentResponseDetailsType(){
		}


		public DoExpressCheckoutPaymentResponseDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("Token").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Token")[0]))
			{
				this.Token = (string)document.GetElementsByTagName("Token")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("PaymentInfo").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentInfo")[0]))
				{
					nodeList = document.GetElementsByTagName("PaymentInfo");
					for(int i = 0; i < nodeList.Count; i++)
					{
						xmlString = DeserializationUtils.convertToXML(nodeList[i]);
						this.PaymentInfo.Add(new PaymentInfoType(xmlString));
					}
				}
			}
		if(document.GetElementsByTagName("BillingAgreementID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillingAgreementID")[0]))
			{
				this.BillingAgreementID = (string)document.GetElementsByTagName("BillingAgreementID")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("RedirectRequired").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("RedirectRequired")[0]))
			{
				this.RedirectRequired = (string)document.GetElementsByTagName("RedirectRequired")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Note").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Note")[0]))
			{
				this.Note = (string)document.GetElementsByTagName("Note")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("SuccessPageRedirectRequested").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SuccessPageRedirectRequested")[0]))
			{
				this.SuccessPageRedirectRequested = (string)document.GetElementsByTagName("SuccessPageRedirectRequested")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("UserSelectedOptions").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("UserSelectedOptions")[0]))
				{
					nodeList = document.GetElementsByTagName("UserSelectedOptions");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.UserSelectedOptions =  new UserSelectedOptionType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *The authorization identification number you specified in the
      *request. Character length and limits: 19 single-byte
      *characters maximum 
      */
	public partial class DoCaptureResponseDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string AuthorizationIDField;
		public string AuthorizationID
		{
			get
			{
				return this.AuthorizationIDField;
			}
			set
			{
				this.AuthorizationIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PaymentInfoType PaymentInfoField;
		public PaymentInfoType PaymentInfo
		{
			get
			{
				return this.PaymentInfoField;
			}
			set
			{
				this.PaymentInfoField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DoCaptureResponseDetailsType(){
		}


		public DoCaptureResponseDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("AuthorizationID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AuthorizationID")[0]))
			{
				this.AuthorizationID = (string)document.GetElementsByTagName("AuthorizationID")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("PaymentInfo").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentInfo")[0]))
				{
					nodeList = document.GetElementsByTagName("PaymentInfo");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.PaymentInfo =  new PaymentInfoType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *How you want to obtain payment. Required Authorization
      *indicates that this payment is a basic authorization subject
      *to settlement with PayPal Authorization and Capture. Sale
      *indicates that this is a final sale for which you are
      *requesting payment. NOTE: Order is not allowed for Direct
      *Payment. Character length and limit: Up to 13 single-byte
      *alphabetic characters 
      */
	public partial class DoDirectPaymentRequestDetailsType	
	{

		/**
          *No Document Comments
		  */
		private PaymentActionCodeType? PaymentActionField;
		public PaymentActionCodeType? PaymentAction
		{
			get
			{
				return this.PaymentActionField;
			}
			set
			{
				this.PaymentActionField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PaymentDetailsType PaymentDetailsField;
		public PaymentDetailsType PaymentDetails
		{
			get
			{
				return this.PaymentDetailsField;
			}
			set
			{
				this.PaymentDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private CreditCardDetailsType CreditCardField;
		public CreditCardDetailsType CreditCard
		{
			get
			{
				return this.CreditCardField;
			}
			set
			{
				this.CreditCardField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string IPAddressField;
		public string IPAddress
		{
			get
			{
				return this.IPAddressField;
			}
			set
			{
				this.IPAddressField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string MerchantSessionIdField;
		public string MerchantSessionId
		{
			get
			{
				return this.MerchantSessionIdField;
			}
			set
			{
				this.MerchantSessionIdField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private bool? ReturnFMFDetailsField;
		public bool? ReturnFMFDetails
		{
			get
			{
				return this.ReturnFMFDetailsField;
			}
			set
			{
				this.ReturnFMFDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DoDirectPaymentRequestDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(PaymentAction != null)
			{
				sb.Append("<ebl:PaymentAction>").Append(EnumUtils.getDescription(PaymentAction));
				sb.Append("</ebl:PaymentAction>");
			}
			if(PaymentDetails != null)
			{
				sb.Append("<ebl:PaymentDetails>");
				sb.Append(PaymentDetails.toXMLString());
				sb.Append("</ebl:PaymentDetails>");
			}
			if(CreditCard != null)
			{
				sb.Append("<ebl:CreditCard>");
				sb.Append(CreditCard.toXMLString());
				sb.Append("</ebl:CreditCard>");
			}
			if(IPAddress != null)
			{
				sb.Append("<ebl:IPAddress>").Append(IPAddress);
				sb.Append("</ebl:IPAddress>");
			}
			if(MerchantSessionId != null)
			{
				sb.Append("<ebl:MerchantSessionId>").Append(MerchantSessionId);
				sb.Append("</ebl:MerchantSessionId>");
			}
			if(ReturnFMFDetails != null)
			{
				sb.Append("<ebl:ReturnFMFDetails>").Append(ReturnFMFDetails);
				sb.Append("</ebl:ReturnFMFDetails>");
			}
			return sb.ToString();
		}
	}




	/**
      *Type of the payment Required 
      */
	public partial class CreateMobilePaymentRequestDetailsType	
	{

		/**
          *No Document Comments
		  */
		private MobilePaymentCodeType? PaymentTypeField;
		public MobilePaymentCodeType? PaymentType
		{
			get
			{
				return this.PaymentTypeField;
			}
			set
			{
				this.PaymentTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PaymentActionCodeType? PaymentActionField;
		public PaymentActionCodeType? PaymentAction
		{
			get
			{
				return this.PaymentActionField;
			}
			set
			{
				this.PaymentActionField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PhoneNumberType SenderPhoneField;
		public PhoneNumberType SenderPhone
		{
			get
			{
				return this.SenderPhoneField;
			}
			set
			{
				this.SenderPhoneField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private MobileRecipientCodeType? RecipientTypeField;
		public MobileRecipientCodeType? RecipientType
		{
			get
			{
				return this.RecipientTypeField;
			}
			set
			{
				this.RecipientTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string RecipientEmailField;
		public string RecipientEmail
		{
			get
			{
				return this.RecipientEmailField;
			}
			set
			{
				this.RecipientEmailField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PhoneNumberType RecipientPhoneField;
		public PhoneNumberType RecipientPhone
		{
			get
			{
				return this.RecipientPhoneField;
			}
			set
			{
				this.RecipientPhoneField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType ItemAmountField;
		public BasicAmountType ItemAmount
		{
			get
			{
				return this.ItemAmountField;
			}
			set
			{
				this.ItemAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType TaxField;
		public BasicAmountType Tax
		{
			get
			{
				return this.TaxField;
			}
			set
			{
				this.TaxField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType ShippingField;
		public BasicAmountType Shipping
		{
			get
			{
				return this.ShippingField;
			}
			set
			{
				this.ShippingField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ItemNameField;
		public string ItemName
		{
			get
			{
				return this.ItemNameField;
			}
			set
			{
				this.ItemNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ItemNumberField;
		public string ItemNumber
		{
			get
			{
				return this.ItemNumberField;
			}
			set
			{
				this.ItemNumberField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string NoteField;
		public string Note
		{
			get
			{
				return this.NoteField;
			}
			set
			{
				this.NoteField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CustomIDField;
		public string CustomID
		{
			get
			{
				return this.CustomIDField;
			}
			set
			{
				this.CustomIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? SharePhoneNumberField;
		public int? SharePhoneNumber
		{
			get
			{
				return this.SharePhoneNumberField;
			}
			set
			{
				this.SharePhoneNumberField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? ShareHomeAddressField;
		public int? ShareHomeAddress
		{
			get
			{
				return this.ShareHomeAddressField;
			}
			set
			{
				this.ShareHomeAddressField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public CreateMobilePaymentRequestDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(PaymentType != null)
			{
				sb.Append("<ebl:PaymentType>").Append(EnumUtils.getDescription(PaymentType));
				sb.Append("</ebl:PaymentType>");
			}
			if(PaymentAction != null)
			{
				sb.Append("<ebl:PaymentAction>").Append(EnumUtils.getDescription(PaymentAction));
				sb.Append("</ebl:PaymentAction>");
			}
			if(SenderPhone != null)
			{
				sb.Append("<ebl:SenderPhone>");
				sb.Append(SenderPhone.toXMLString());
				sb.Append("</ebl:SenderPhone>");
			}
			if(RecipientType != null)
			{
				sb.Append("<ebl:RecipientType>").Append(EnumUtils.getDescription(RecipientType));
				sb.Append("</ebl:RecipientType>");
			}
			if(RecipientEmail != null)
			{
				sb.Append("<ebl:RecipientEmail>").Append(RecipientEmail);
				sb.Append("</ebl:RecipientEmail>");
			}
			if(RecipientPhone != null)
			{
				sb.Append("<ebl:RecipientPhone>");
				sb.Append(RecipientPhone.toXMLString());
				sb.Append("</ebl:RecipientPhone>");
			}
			if(ItemAmount != null)
			{
				sb.Append("<ebl:ItemAmount");
				sb.Append(ItemAmount.toXMLString());
				sb.Append("</ebl:ItemAmount>");
			}
			if(Tax != null)
			{
				sb.Append("<ebl:Tax");
				sb.Append(Tax.toXMLString());
				sb.Append("</ebl:Tax>");
			}
			if(Shipping != null)
			{
				sb.Append("<ebl:Shipping");
				sb.Append(Shipping.toXMLString());
				sb.Append("</ebl:Shipping>");
			}
			if(ItemName != null)
			{
				sb.Append("<ebl:ItemName>").Append(ItemName);
				sb.Append("</ebl:ItemName>");
			}
			if(ItemNumber != null)
			{
				sb.Append("<ebl:ItemNumber>").Append(ItemNumber);
				sb.Append("</ebl:ItemNumber>");
			}
			if(Note != null)
			{
				sb.Append("<ebl:Note>").Append(Note);
				sb.Append("</ebl:Note>");
			}
			if(CustomID != null)
			{
				sb.Append("<ebl:CustomID>").Append(CustomID);
				sb.Append("</ebl:CustomID>");
			}
			if(SharePhoneNumber != null)
			{
				sb.Append("<ebl:SharePhoneNumber>").Append(SharePhoneNumber);
				sb.Append("</ebl:SharePhoneNumber>");
			}
			if(ShareHomeAddress != null)
			{
				sb.Append("<ebl:ShareHomeAddress>").Append(ShareHomeAddress);
				sb.Append("</ebl:ShareHomeAddress>");
			}
			return sb.ToString();
		}
	}




	/**
      *Phone number for status inquiry 
      */
	public partial class GetMobileStatusRequestDetailsType	
	{

		/**
          *No Document Comments
		  */
		private PhoneNumberType PhoneField;
		public PhoneNumberType Phone
		{
			get
			{
				return this.PhoneField;
			}
			set
			{
				this.PhoneField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public GetMobileStatusRequestDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Phone != null)
			{
				sb.Append("<ebl:Phone>");
				sb.Append(Phone.toXMLString());
				sb.Append("</ebl:Phone>");
			}
			return sb.ToString();
		}
	}




	/**
      *URL to which the customer's browser is returned after
      *choosing to login with PayPal. Required Character length and
      *limitations: no limit. 
      */
	public partial class SetAuthFlowParamRequestDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string ReturnURLField;
		public string ReturnURL
		{
			get
			{
				return this.ReturnURLField;
			}
			set
			{
				this.ReturnURLField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CancelURLField;
		public string CancelURL
		{
			get
			{
				return this.CancelURLField;
			}
			set
			{
				this.CancelURLField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string LogoutURLField;
		public string LogoutURL
		{
			get
			{
				return this.LogoutURLField;
			}
			set
			{
				this.LogoutURLField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string InitFlowTypeField;
		public string InitFlowType
		{
			get
			{
				return this.InitFlowTypeField;
			}
			set
			{
				this.InitFlowTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string SkipLoginPageField;
		public string SkipLoginPage
		{
			get
			{
				return this.SkipLoginPageField;
			}
			set
			{
				this.SkipLoginPageField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ServiceName1Field;
		public string ServiceName1
		{
			get
			{
				return this.ServiceName1Field;
			}
			set
			{
				this.ServiceName1Field = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ServiceDefReq1Field;
		public string ServiceDefReq1
		{
			get
			{
				return this.ServiceDefReq1Field;
			}
			set
			{
				this.ServiceDefReq1Field = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ServiceName2Field;
		public string ServiceName2
		{
			get
			{
				return this.ServiceName2Field;
			}
			set
			{
				this.ServiceName2Field = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ServiceDefReq2Field;
		public string ServiceDefReq2
		{
			get
			{
				return this.ServiceDefReq2Field;
			}
			set
			{
				this.ServiceDefReq2Field = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string LocaleCodeField;
		public string LocaleCode
		{
			get
			{
				return this.LocaleCodeField;
			}
			set
			{
				this.LocaleCodeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PageStyleField;
		public string PageStyle
		{
			get
			{
				return this.PageStyleField;
			}
			set
			{
				this.PageStyleField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string cppHeaderImageField;
		public string cppHeaderImage
		{
			get
			{
				return this.cppHeaderImageField;
			}
			set
			{
				this.cppHeaderImageField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string cppHeaderBorderColorField;
		public string cppHeaderBorderColor
		{
			get
			{
				return this.cppHeaderBorderColorField;
			}
			set
			{
				this.cppHeaderBorderColorField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string cppHeaderBackColorField;
		public string cppHeaderBackColor
		{
			get
			{
				return this.cppHeaderBackColorField;
			}
			set
			{
				this.cppHeaderBackColorField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string cppPayflowColorField;
		public string cppPayflowColor
		{
			get
			{
				return this.cppPayflowColorField;
			}
			set
			{
				this.cppPayflowColorField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string FirstNameField;
		public string FirstName
		{
			get
			{
				return this.FirstNameField;
			}
			set
			{
				this.FirstNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string LastNameField;
		public string LastName
		{
			get
			{
				return this.LastNameField;
			}
			set
			{
				this.LastNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private AddressType AddressField;
		public AddressType Address
		{
			get
			{
				return this.AddressField;
			}
			set
			{
				this.AddressField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public SetAuthFlowParamRequestDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ReturnURL != null)
			{
				sb.Append("<ebl:ReturnURL>").Append(ReturnURL);
				sb.Append("</ebl:ReturnURL>");
			}
			if(CancelURL != null)
			{
				sb.Append("<ebl:CancelURL>").Append(CancelURL);
				sb.Append("</ebl:CancelURL>");
			}
			if(LogoutURL != null)
			{
				sb.Append("<ebl:LogoutURL>").Append(LogoutURL);
				sb.Append("</ebl:LogoutURL>");
			}
			if(InitFlowType != null)
			{
				sb.Append("<ebl:InitFlowType>").Append(InitFlowType);
				sb.Append("</ebl:InitFlowType>");
			}
			if(SkipLoginPage != null)
			{
				sb.Append("<ebl:SkipLoginPage>").Append(SkipLoginPage);
				sb.Append("</ebl:SkipLoginPage>");
			}
			if(ServiceName1 != null)
			{
				sb.Append("<ebl:ServiceName1>").Append(ServiceName1);
				sb.Append("</ebl:ServiceName1>");
			}
			if(ServiceDefReq1 != null)
			{
				sb.Append("<ebl:ServiceDefReq1>").Append(ServiceDefReq1);
				sb.Append("</ebl:ServiceDefReq1>");
			}
			if(ServiceName2 != null)
			{
				sb.Append("<ebl:ServiceName2>").Append(ServiceName2);
				sb.Append("</ebl:ServiceName2>");
			}
			if(ServiceDefReq2 != null)
			{
				sb.Append("<ebl:ServiceDefReq2>").Append(ServiceDefReq2);
				sb.Append("</ebl:ServiceDefReq2>");
			}
			if(LocaleCode != null)
			{
				sb.Append("<ebl:LocaleCode>").Append(LocaleCode);
				sb.Append("</ebl:LocaleCode>");
			}
			if(PageStyle != null)
			{
				sb.Append("<ebl:PageStyle>").Append(PageStyle);
				sb.Append("</ebl:PageStyle>");
			}
			if(cppHeaderImage != null)
			{
				sb.Append("<ebl:cpp-header-image>").Append(cppHeaderImage);
				sb.Append("</ebl:cpp-header-image>");
			}
			if(cppHeaderBorderColor != null)
			{
				sb.Append("<ebl:cpp-header-border-color>").Append(cppHeaderBorderColor);
				sb.Append("</ebl:cpp-header-border-color>");
			}
			if(cppHeaderBackColor != null)
			{
				sb.Append("<ebl:cpp-header-back-color>").Append(cppHeaderBackColor);
				sb.Append("</ebl:cpp-header-back-color>");
			}
			if(cppPayflowColor != null)
			{
				sb.Append("<ebl:cpp-payflow-color>").Append(cppPayflowColor);
				sb.Append("</ebl:cpp-payflow-color>");
			}
			if(FirstName != null)
			{
				sb.Append("<ebl:FirstName>").Append(FirstName);
				sb.Append("</ebl:FirstName>");
			}
			if(LastName != null)
			{
				sb.Append("<ebl:LastName>").Append(LastName);
				sb.Append("</ebl:LastName>");
			}
			if(Address != null)
			{
				sb.Append("<ebl:Address>");
				sb.Append(Address.toXMLString());
				sb.Append("</ebl:Address>");
			}
			return sb.ToString();
		}
	}




	/**
      *The first name of the User. Character length and
      *limitations: 127 single-byte alphanumeric characters 
      */
	public partial class GetAuthDetailsResponseDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string FirstNameField;
		public string FirstName
		{
			get
			{
				return this.FirstNameField;
			}
			set
			{
				this.FirstNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string LastNameField;
		public string LastName
		{
			get
			{
				return this.LastNameField;
			}
			set
			{
				this.LastNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string EmailField;
		public string Email
		{
			get
			{
				return this.EmailField;
			}
			set
			{
				this.EmailField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PayerIDField;
		public string PayerID
		{
			get
			{
				return this.PayerIDField;
			}
			set
			{
				this.PayerIDField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public GetAuthDetailsResponseDetailsType(){
		}


		public GetAuthDetailsResponseDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("FirstName").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("FirstName")[0]))
			{
				this.FirstName = (string)document.GetElementsByTagName("FirstName")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("LastName").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("LastName")[0]))
			{
				this.LastName = (string)document.GetElementsByTagName("LastName")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Email").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Email")[0]))
			{
				this.Email = (string)document.GetElementsByTagName("Email")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("PayerID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PayerID")[0]))
			{
				this.PayerID = (string)document.GetElementsByTagName("PayerID")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *URL to which the customer's browser is returned after
      *choosing to login with PayPal. Required Character length and
      *limitations: no limit. 
      */
	public partial class SetAccessPermissionsRequestDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string ReturnURLField;
		public string ReturnURL
		{
			get
			{
				return this.ReturnURLField;
			}
			set
			{
				this.ReturnURLField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CancelURLField;
		public string CancelURL
		{
			get
			{
				return this.CancelURLField;
			}
			set
			{
				this.CancelURLField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string LogoutURLField;
		public string LogoutURL
		{
			get
			{
				return this.LogoutURLField;
			}
			set
			{
				this.LogoutURLField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string InitFlowTypeField;
		public string InitFlowType
		{
			get
			{
				return this.InitFlowTypeField;
			}
			set
			{
				this.InitFlowTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string SkipLoginPageField;
		public string SkipLoginPage
		{
			get
			{
				return this.SkipLoginPageField;
			}
			set
			{
				this.SkipLoginPageField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<string> RequiredAccessPermissionsField = new List<string>();
		public List<string> RequiredAccessPermissions
		{
			get
			{
				return this.RequiredAccessPermissionsField;
			}
			set
			{
				this.RequiredAccessPermissionsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<string> OptionalAccessPermissionsField = new List<string>();
		public List<string> OptionalAccessPermissions
		{
			get
			{
				return this.OptionalAccessPermissionsField;
			}
			set
			{
				this.OptionalAccessPermissionsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string LocaleCodeField;
		public string LocaleCode
		{
			get
			{
				return this.LocaleCodeField;
			}
			set
			{
				this.LocaleCodeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PageStyleField;
		public string PageStyle
		{
			get
			{
				return this.PageStyleField;
			}
			set
			{
				this.PageStyleField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string cppHeaderImageField;
		public string cppHeaderImage
		{
			get
			{
				return this.cppHeaderImageField;
			}
			set
			{
				this.cppHeaderImageField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string cppHeaderBorderColorField;
		public string cppHeaderBorderColor
		{
			get
			{
				return this.cppHeaderBorderColorField;
			}
			set
			{
				this.cppHeaderBorderColorField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string cppHeaderBackColorField;
		public string cppHeaderBackColor
		{
			get
			{
				return this.cppHeaderBackColorField;
			}
			set
			{
				this.cppHeaderBackColorField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string cppPayflowColorField;
		public string cppPayflowColor
		{
			get
			{
				return this.cppPayflowColorField;
			}
			set
			{
				this.cppPayflowColorField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string FirstNameField;
		public string FirstName
		{
			get
			{
				return this.FirstNameField;
			}
			set
			{
				this.FirstNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string LastNameField;
		public string LastName
		{
			get
			{
				return this.LastNameField;
			}
			set
			{
				this.LastNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private AddressType AddressField;
		public AddressType Address
		{
			get
			{
				return this.AddressField;
			}
			set
			{
				this.AddressField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public SetAccessPermissionsRequestDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ReturnURL != null)
			{
				sb.Append("<ebl:ReturnURL>").Append(ReturnURL);
				sb.Append("</ebl:ReturnURL>");
			}
			if(CancelURL != null)
			{
				sb.Append("<ebl:CancelURL>").Append(CancelURL);
				sb.Append("</ebl:CancelURL>");
			}
			if(LogoutURL != null)
			{
				sb.Append("<ebl:LogoutURL>").Append(LogoutURL);
				sb.Append("</ebl:LogoutURL>");
			}
			if(InitFlowType != null)
			{
				sb.Append("<ebl:InitFlowType>").Append(InitFlowType);
				sb.Append("</ebl:InitFlowType>");
			}
			if(SkipLoginPage != null)
			{
				sb.Append("<ebl:SkipLoginPage>").Append(SkipLoginPage);
				sb.Append("</ebl:SkipLoginPage>");
			}
			if(RequiredAccessPermissions != null)
			{
				for(int i = 0; i < RequiredAccessPermissions.Count; i++)
				{
					sb.Append("<ebl:RequiredAccessPermissions>").Append(RequiredAccessPermissions[i]);
					sb.Append("</ebl:RequiredAccessPermissions>");
				
				}
			}
			if(OptionalAccessPermissions != null)
			{
				for(int i = 0; i < OptionalAccessPermissions.Count; i++)
				{
					sb.Append("<ebl:OptionalAccessPermissions>").Append(OptionalAccessPermissions[i]);
					sb.Append("</ebl:OptionalAccessPermissions>");
				
				}
			}
			if(LocaleCode != null)
			{
				sb.Append("<ebl:LocaleCode>").Append(LocaleCode);
				sb.Append("</ebl:LocaleCode>");
			}
			if(PageStyle != null)
			{
				sb.Append("<ebl:PageStyle>").Append(PageStyle);
				sb.Append("</ebl:PageStyle>");
			}
			if(cppHeaderImage != null)
			{
				sb.Append("<ebl:cpp-header-image>").Append(cppHeaderImage);
				sb.Append("</ebl:cpp-header-image>");
			}
			if(cppHeaderBorderColor != null)
			{
				sb.Append("<ebl:cpp-header-border-color>").Append(cppHeaderBorderColor);
				sb.Append("</ebl:cpp-header-border-color>");
			}
			if(cppHeaderBackColor != null)
			{
				sb.Append("<ebl:cpp-header-back-color>").Append(cppHeaderBackColor);
				sb.Append("</ebl:cpp-header-back-color>");
			}
			if(cppPayflowColor != null)
			{
				sb.Append("<ebl:cpp-payflow-color>").Append(cppPayflowColor);
				sb.Append("</ebl:cpp-payflow-color>");
			}
			if(FirstName != null)
			{
				sb.Append("<ebl:FirstName>").Append(FirstName);
				sb.Append("</ebl:FirstName>");
			}
			if(LastName != null)
			{
				sb.Append("<ebl:LastName>").Append(LastName);
				sb.Append("</ebl:LastName>");
			}
			if(Address != null)
			{
				sb.Append("<ebl:Address>");
				sb.Append(Address.toXMLString());
				sb.Append("</ebl:Address>");
			}
			return sb.ToString();
		}
	}




	/**
      *The first name of the User. Character length and
      *limitations: 127 single-byte alphanumeric characters 
      */
	public partial class GetAccessPermissionDetailsResponseDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string FirstNameField;
		public string FirstName
		{
			get
			{
				return this.FirstNameField;
			}
			set
			{
				this.FirstNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string LastNameField;
		public string LastName
		{
			get
			{
				return this.LastNameField;
			}
			set
			{
				this.LastNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string EmailField;
		public string Email
		{
			get
			{
				return this.EmailField;
			}
			set
			{
				this.EmailField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<string> AccessPermissionNameField = new List<string>();
		public List<string> AccessPermissionName
		{
			get
			{
				return this.AccessPermissionNameField;
			}
			set
			{
				this.AccessPermissionNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<string> AccessPermissionStatusField = new List<string>();
		public List<string> AccessPermissionStatus
		{
			get
			{
				return this.AccessPermissionStatusField;
			}
			set
			{
				this.AccessPermissionStatusField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PayerIDField;
		public string PayerID
		{
			get
			{
				return this.PayerIDField;
			}
			set
			{
				this.PayerIDField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public GetAccessPermissionDetailsResponseDetailsType(){
		}


		public GetAccessPermissionDetailsResponseDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("FirstName").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("FirstName")[0]))
			{
				this.FirstName = (string)document.GetElementsByTagName("FirstName")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("LastName").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("LastName")[0]))
			{
				this.LastName = (string)document.GetElementsByTagName("LastName")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Email").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Email")[0]))
			{
				this.Email = (string)document.GetElementsByTagName("Email")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("AccessPermissionName").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AccessPermissionName")[0]))
				{
					nodeList = document.GetElementsByTagName("AccessPermissionName");
					for(int i = 0; i < nodeList.Count; i++)
					{
						string value = nodeList[i].InnerText;
						this.AccessPermissionName.Add(value);
					}
				}
			}
			if(document.GetElementsByTagName("AccessPermissionStatus").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AccessPermissionStatus")[0]))
				{
					nodeList = document.GetElementsByTagName("AccessPermissionStatus");
					for(int i = 0; i < nodeList.Count; i++)
					{
						string value = nodeList[i].InnerText;
						this.AccessPermissionStatus.Add(value);
					}
				}
			}
		if(document.GetElementsByTagName("PayerID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PayerID")[0]))
			{
				this.PayerID = (string)document.GetElementsByTagName("PayerID")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *
      */
	public partial class BAUpdateResponseDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string BillingAgreementIDField;
		public string BillingAgreementID
		{
			get
			{
				return this.BillingAgreementIDField;
			}
			set
			{
				this.BillingAgreementIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string BillingAgreementDescriptionField;
		public string BillingAgreementDescription
		{
			get
			{
				return this.BillingAgreementDescriptionField;
			}
			set
			{
				this.BillingAgreementDescriptionField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private MerchantPullStatusCodeType? BillingAgreementStatusField;
		public MerchantPullStatusCodeType? BillingAgreementStatus
		{
			get
			{
				return this.BillingAgreementStatusField;
			}
			set
			{
				this.BillingAgreementStatusField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string BillingAgreementCustomField;
		public string BillingAgreementCustom
		{
			get
			{
				return this.BillingAgreementCustomField;
			}
			set
			{
				this.BillingAgreementCustomField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PayerInfoType PayerInfoField;
		public PayerInfoType PayerInfo
		{
			get
			{
				return this.PayerInfoField;
			}
			set
			{
				this.PayerInfoField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType BillingAgreementMaxField;
		public BasicAmountType BillingAgreementMax
		{
			get
			{
				return this.BillingAgreementMaxField;
			}
			set
			{
				this.BillingAgreementMaxField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private AddressType BillingAddressField;
		public AddressType BillingAddress
		{
			get
			{
				return this.BillingAddressField;
			}
			set
			{
				this.BillingAddressField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public BAUpdateResponseDetailsType(){
		}


		public BAUpdateResponseDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("BillingAgreementID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillingAgreementID")[0]))
			{
				this.BillingAgreementID = (string)document.GetElementsByTagName("BillingAgreementID")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("BillingAgreementDescription").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillingAgreementDescription")[0]))
			{
				this.BillingAgreementDescription = (string)document.GetElementsByTagName("BillingAgreementDescription")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("BillingAgreementStatus").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillingAgreementStatus")[0]))
				{
					this.BillingAgreementStatus = (MerchantPullStatusCodeType)EnumUtils.getValue(document.GetElementsByTagName("BillingAgreementStatus")[0].InnerText,typeof(MerchantPullStatusCodeType));
				}
			}
		if(document.GetElementsByTagName("BillingAgreementCustom").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillingAgreementCustom")[0]))
			{
				this.BillingAgreementCustom = (string)document.GetElementsByTagName("BillingAgreementCustom")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("PayerInfo").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PayerInfo")[0]))
				{
					nodeList = document.GetElementsByTagName("PayerInfo");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.PayerInfo =  new PayerInfoType(xmlString);
				}
			}
			if(document.GetElementsByTagName("BillingAgreementMax").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillingAgreementMax")[0]))
				{
					nodeList = document.GetElementsByTagName("BillingAgreementMax");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.BillingAgreementMax =  new BasicAmountType(xmlString);
				}
			}
			if(document.GetElementsByTagName("BillingAddress").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillingAddress")[0]))
				{
					nodeList = document.GetElementsByTagName("BillingAddress");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.BillingAddress =  new AddressType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *MerchantPullPaymentResponseType Response data from the
      *merchant pull. 
      */
	public partial class MerchantPullPaymentResponseType	
	{

		/**
          *No Document Comments
		  */
		private PayerInfoType PayerInfoField;
		public PayerInfoType PayerInfo
		{
			get
			{
				return this.PayerInfoField;
			}
			set
			{
				this.PayerInfoField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PaymentInfoType PaymentInfoField;
		public PaymentInfoType PaymentInfo
		{
			get
			{
				return this.PaymentInfoField;
			}
			set
			{
				this.PaymentInfoField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private MerchantPullInfoType MerchantPullInfoField;
		public MerchantPullInfoType MerchantPullInfo
		{
			get
			{
				return this.MerchantPullInfoField;
			}
			set
			{
				this.MerchantPullInfoField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public MerchantPullPaymentResponseType(){
		}


		public MerchantPullPaymentResponseType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("PayerInfo").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PayerInfo")[0]))
				{
					nodeList = document.GetElementsByTagName("PayerInfo");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.PayerInfo =  new PayerInfoType(xmlString);
				}
			}
			if(document.GetElementsByTagName("PaymentInfo").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentInfo")[0]))
				{
					nodeList = document.GetElementsByTagName("PaymentInfo");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.PaymentInfo =  new PaymentInfoType(xmlString);
				}
			}
			if(document.GetElementsByTagName("MerchantPullInfo").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("MerchantPullInfo")[0]))
				{
					nodeList = document.GetElementsByTagName("MerchantPullInfo");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.MerchantPullInfo =  new MerchantPullInfoType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *MerchantPullInfoType Information about the merchant pull. 
      */
	public partial class MerchantPullInfoType	
	{

		/**
          *No Document Comments
		  */
		private MerchantPullStatusCodeType? MpStatusField;
		public MerchantPullStatusCodeType? MpStatus
		{
			get
			{
				return this.MpStatusField;
			}
			set
			{
				this.MpStatusField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType MpMaxField;
		public BasicAmountType MpMax
		{
			get
			{
				return this.MpMaxField;
			}
			set
			{
				this.MpMaxField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string MpCustomField;
		public string MpCustom
		{
			get
			{
				return this.MpCustomField;
			}
			set
			{
				this.MpCustomField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string DescField;
		public string Desc
		{
			get
			{
				return this.DescField;
			}
			set
			{
				this.DescField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string InvoiceField;
		public string Invoice
		{
			get
			{
				return this.InvoiceField;
			}
			set
			{
				this.InvoiceField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CustomField;
		public string Custom
		{
			get
			{
				return this.CustomField;
			}
			set
			{
				this.CustomField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PaymentSourceIDField;
		public string PaymentSourceID
		{
			get
			{
				return this.PaymentSourceIDField;
			}
			set
			{
				this.PaymentSourceIDField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public MerchantPullInfoType(){
		}


		public MerchantPullInfoType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("MpStatus").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("MpStatus")[0]))
				{
					this.MpStatus = (MerchantPullStatusCodeType)EnumUtils.getValue(document.GetElementsByTagName("MpStatus")[0].InnerText,typeof(MerchantPullStatusCodeType));
				}
			}
			if(document.GetElementsByTagName("MpMax").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("MpMax")[0]))
				{
					nodeList = document.GetElementsByTagName("MpMax");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.MpMax =  new BasicAmountType(xmlString);
				}
			}
		if(document.GetElementsByTagName("MpCustom").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("MpCustom")[0]))
			{
				this.MpCustom = (string)document.GetElementsByTagName("MpCustom")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Desc").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Desc")[0]))
			{
				this.Desc = (string)document.GetElementsByTagName("Desc")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Invoice").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Invoice")[0]))
			{
				this.Invoice = (string)document.GetElementsByTagName("Invoice")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Custom").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Custom")[0]))
			{
				this.Custom = (string)document.GetElementsByTagName("Custom")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("PaymentSourceID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentSourceID")[0]))
			{
				this.PaymentSourceID = (string)document.GetElementsByTagName("PaymentSourceID")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *PaymentTransactionSearchResultType Results from a
      *PaymentTransaction search 
      */
	public partial class PaymentTransactionSearchResultType	
	{

		/**
          *No Document Comments
		  */
		private string TimestampField;
		public string Timestamp
		{
			get
			{
				return this.TimestampField;
			}
			set
			{
				this.TimestampField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string TimezoneField;
		public string Timezone
		{
			get
			{
				return this.TimezoneField;
			}
			set
			{
				this.TimezoneField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string TypeField;
		public string Type
		{
			get
			{
				return this.TypeField;
			}
			set
			{
				this.TypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PayerField;
		public string Payer
		{
			get
			{
				return this.PayerField;
			}
			set
			{
				this.PayerField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PayerDisplayNameField;
		public string PayerDisplayName
		{
			get
			{
				return this.PayerDisplayNameField;
			}
			set
			{
				this.PayerDisplayNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string TransactionIDField;
		public string TransactionID
		{
			get
			{
				return this.TransactionIDField;
			}
			set
			{
				this.TransactionIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string StatusField;
		public string Status
		{
			get
			{
				return this.StatusField;
			}
			set
			{
				this.StatusField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType GrossAmountField;
		public BasicAmountType GrossAmount
		{
			get
			{
				return this.GrossAmountField;
			}
			set
			{
				this.GrossAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType FeeAmountField;
		public BasicAmountType FeeAmount
		{
			get
			{
				return this.FeeAmountField;
			}
			set
			{
				this.FeeAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType NetAmountField;
		public BasicAmountType NetAmount
		{
			get
			{
				return this.NetAmountField;
			}
			set
			{
				this.NetAmountField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public PaymentTransactionSearchResultType(){
		}


		public PaymentTransactionSearchResultType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("Timestamp").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Timestamp")[0]))
			{
				this.Timestamp = (string)document.GetElementsByTagName("Timestamp")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Timezone").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Timezone")[0]))
			{
				this.Timezone = (string)document.GetElementsByTagName("Timezone")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Type").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Type")[0]))
			{
				this.Type = (string)document.GetElementsByTagName("Type")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Payer").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Payer")[0]))
			{
				this.Payer = (string)document.GetElementsByTagName("Payer")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("PayerDisplayName").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PayerDisplayName")[0]))
			{
				this.PayerDisplayName = (string)document.GetElementsByTagName("PayerDisplayName")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("TransactionID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TransactionID")[0]))
			{
				this.TransactionID = (string)document.GetElementsByTagName("TransactionID")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Status").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Status")[0]))
			{
				this.Status = (string)document.GetElementsByTagName("Status")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("GrossAmount").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GrossAmount")[0]))
				{
					nodeList = document.GetElementsByTagName("GrossAmount");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.GrossAmount =  new BasicAmountType(xmlString);
				}
			}
			if(document.GetElementsByTagName("FeeAmount").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("FeeAmount")[0]))
				{
					nodeList = document.GetElementsByTagName("FeeAmount");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.FeeAmount =  new BasicAmountType(xmlString);
				}
			}
			if(document.GetElementsByTagName("NetAmount").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("NetAmount")[0]))
				{
					nodeList = document.GetElementsByTagName("NetAmount");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.NetAmount =  new BasicAmountType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *MerchantPullPayment Parameters to make initiate a pull
      *payment 
      */
	public partial class MerchantPullPaymentType	
	{

		/**
          *No Document Comments
		  */
		private BasicAmountType AmountField;
		public BasicAmountType Amount
		{
			get
			{
				return this.AmountField;
			}
			set
			{
				this.AmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string MpIDField;
		public string MpID
		{
			get
			{
				return this.MpIDField;
			}
			set
			{
				this.MpIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private MerchantPullPaymentCodeType? PaymentTypeField;
		public MerchantPullPaymentCodeType? PaymentType
		{
			get
			{
				return this.PaymentTypeField;
			}
			set
			{
				this.PaymentTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string MemoField;
		public string Memo
		{
			get
			{
				return this.MemoField;
			}
			set
			{
				this.MemoField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string EmailSubjectField;
		public string EmailSubject
		{
			get
			{
				return this.EmailSubjectField;
			}
			set
			{
				this.EmailSubjectField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType TaxField;
		public BasicAmountType Tax
		{
			get
			{
				return this.TaxField;
			}
			set
			{
				this.TaxField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType ShippingField;
		public BasicAmountType Shipping
		{
			get
			{
				return this.ShippingField;
			}
			set
			{
				this.ShippingField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType HandlingField;
		public BasicAmountType Handling
		{
			get
			{
				return this.HandlingField;
			}
			set
			{
				this.HandlingField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ItemNameField;
		public string ItemName
		{
			get
			{
				return this.ItemNameField;
			}
			set
			{
				this.ItemNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ItemNumberField;
		public string ItemNumber
		{
			get
			{
				return this.ItemNumberField;
			}
			set
			{
				this.ItemNumberField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string InvoiceField;
		public string Invoice
		{
			get
			{
				return this.InvoiceField;
			}
			set
			{
				this.InvoiceField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CustomField;
		public string Custom
		{
			get
			{
				return this.CustomField;
			}
			set
			{
				this.CustomField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ButtonSourceField;
		public string ButtonSource
		{
			get
			{
				return this.ButtonSourceField;
			}
			set
			{
				this.ButtonSourceField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string SoftDescriptorField;
		public string SoftDescriptor
		{
			get
			{
				return this.SoftDescriptorField;
			}
			set
			{
				this.SoftDescriptorField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public MerchantPullPaymentType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Amount != null)
			{
				sb.Append("<ebl:Amount");
				sb.Append(Amount.toXMLString());
				sb.Append("</ebl:Amount>");
			}
			if(MpID != null)
			{
				sb.Append("<ebl:MpID>").Append(MpID);
				sb.Append("</ebl:MpID>");
			}
			if(PaymentType != null)
			{
				sb.Append("<ebl:PaymentType>").Append(EnumUtils.getDescription(PaymentType));
				sb.Append("</ebl:PaymentType>");
			}
			if(Memo != null)
			{
				sb.Append("<ebl:Memo>").Append(Memo);
				sb.Append("</ebl:Memo>");
			}
			if(EmailSubject != null)
			{
				sb.Append("<ebl:EmailSubject>").Append(EmailSubject);
				sb.Append("</ebl:EmailSubject>");
			}
			if(Tax != null)
			{
				sb.Append("<ebl:Tax");
				sb.Append(Tax.toXMLString());
				sb.Append("</ebl:Tax>");
			}
			if(Shipping != null)
			{
				sb.Append("<ebl:Shipping");
				sb.Append(Shipping.toXMLString());
				sb.Append("</ebl:Shipping>");
			}
			if(Handling != null)
			{
				sb.Append("<ebl:Handling");
				sb.Append(Handling.toXMLString());
				sb.Append("</ebl:Handling>");
			}
			if(ItemName != null)
			{
				sb.Append("<ebl:ItemName>").Append(ItemName);
				sb.Append("</ebl:ItemName>");
			}
			if(ItemNumber != null)
			{
				sb.Append("<ebl:ItemNumber>").Append(ItemNumber);
				sb.Append("</ebl:ItemNumber>");
			}
			if(Invoice != null)
			{
				sb.Append("<ebl:Invoice>").Append(Invoice);
				sb.Append("</ebl:Invoice>");
			}
			if(Custom != null)
			{
				sb.Append("<ebl:Custom>").Append(Custom);
				sb.Append("</ebl:Custom>");
			}
			if(ButtonSource != null)
			{
				sb.Append("<ebl:ButtonSource>").Append(ButtonSource);
				sb.Append("</ebl:ButtonSource>");
			}
			if(SoftDescriptor != null)
			{
				sb.Append("<ebl:SoftDescriptor>").Append(SoftDescriptor);
				sb.Append("</ebl:SoftDescriptor>");
			}
			return sb.ToString();
		}
	}




	/**
      *PaymentTransactionType Information about a PayPal payment
      *from the seller side 
      */
	public partial class PaymentTransactionType	
	{

		/**
          *No Document Comments
		  */
		private ReceiverInfoType ReceiverInfoField;
		public ReceiverInfoType ReceiverInfo
		{
			get
			{
				return this.ReceiverInfoField;
			}
			set
			{
				this.ReceiverInfoField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PayerInfoType PayerInfoField;
		public PayerInfoType PayerInfo
		{
			get
			{
				return this.PayerInfoField;
			}
			set
			{
				this.PayerInfoField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PaymentInfoType PaymentInfoField;
		public PaymentInfoType PaymentInfo
		{
			get
			{
				return this.PaymentInfoField;
			}
			set
			{
				this.PaymentInfoField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PaymentItemInfoType PaymentItemInfoField;
		public PaymentItemInfoType PaymentItemInfo
		{
			get
			{
				return this.PaymentItemInfoField;
			}
			set
			{
				this.PaymentItemInfoField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private OfferCouponInfoType OfferCouponInfoField;
		public OfferCouponInfoType OfferCouponInfo
		{
			get
			{
				return this.OfferCouponInfoField;
			}
			set
			{
				this.OfferCouponInfoField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private UserSelectedOptionType UserSelectedOptionsField;
		public UserSelectedOptionType UserSelectedOptions
		{
			get
			{
				return this.UserSelectedOptionsField;
			}
			set
			{
				this.UserSelectedOptionsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string GiftMessageField;
		public string GiftMessage
		{
			get
			{
				return this.GiftMessageField;
			}
			set
			{
				this.GiftMessageField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string GiftReceiptField;
		public string GiftReceipt
		{
			get
			{
				return this.GiftReceiptField;
			}
			set
			{
				this.GiftReceiptField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string GiftWrapNameField;
		public string GiftWrapName
		{
			get
			{
				return this.GiftWrapNameField;
			}
			set
			{
				this.GiftWrapNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType GiftWrapAmountField;
		public BasicAmountType GiftWrapAmount
		{
			get
			{
				return this.GiftWrapAmountField;
			}
			set
			{
				this.GiftWrapAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string BuyerEmailOptInField;
		public string BuyerEmailOptIn
		{
			get
			{
				return this.BuyerEmailOptInField;
			}
			set
			{
				this.BuyerEmailOptInField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string SurveyQuestionField;
		public string SurveyQuestion
		{
			get
			{
				return this.SurveyQuestionField;
			}
			set
			{
				this.SurveyQuestionField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<string> SurveyChoiceSelectedField = new List<string>();
		public List<string> SurveyChoiceSelected
		{
			get
			{
				return this.SurveyChoiceSelectedField;
			}
			set
			{
				this.SurveyChoiceSelectedField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public PaymentTransactionType(){
		}


		public PaymentTransactionType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("ReceiverInfo").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ReceiverInfo")[0]))
				{
					nodeList = document.GetElementsByTagName("ReceiverInfo");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.ReceiverInfo =  new ReceiverInfoType(xmlString);
				}
			}
			if(document.GetElementsByTagName("PayerInfo").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PayerInfo")[0]))
				{
					nodeList = document.GetElementsByTagName("PayerInfo");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.PayerInfo =  new PayerInfoType(xmlString);
				}
			}
			if(document.GetElementsByTagName("PaymentInfo").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentInfo")[0]))
				{
					nodeList = document.GetElementsByTagName("PaymentInfo");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.PaymentInfo =  new PaymentInfoType(xmlString);
				}
			}
			if(document.GetElementsByTagName("PaymentItemInfo").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentItemInfo")[0]))
				{
					nodeList = document.GetElementsByTagName("PaymentItemInfo");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.PaymentItemInfo =  new PaymentItemInfoType(xmlString);
				}
			}
			if(document.GetElementsByTagName("OfferCouponInfo").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OfferCouponInfo")[0]))
				{
					nodeList = document.GetElementsByTagName("OfferCouponInfo");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.OfferCouponInfo =  new OfferCouponInfoType(xmlString);
				}
			}
			if(document.GetElementsByTagName("UserSelectedOptions").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("UserSelectedOptions")[0]))
				{
					nodeList = document.GetElementsByTagName("UserSelectedOptions");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.UserSelectedOptions =  new UserSelectedOptionType(xmlString);
				}
			}
		if(document.GetElementsByTagName("GiftMessage").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GiftMessage")[0]))
			{
				this.GiftMessage = (string)document.GetElementsByTagName("GiftMessage")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("GiftReceipt").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GiftReceipt")[0]))
			{
				this.GiftReceipt = (string)document.GetElementsByTagName("GiftReceipt")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("GiftWrapName").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GiftWrapName")[0]))
			{
				this.GiftWrapName = (string)document.GetElementsByTagName("GiftWrapName")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("GiftWrapAmount").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GiftWrapAmount")[0]))
				{
					nodeList = document.GetElementsByTagName("GiftWrapAmount");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.GiftWrapAmount =  new BasicAmountType(xmlString);
				}
			}
		if(document.GetElementsByTagName("BuyerEmailOptIn").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BuyerEmailOptIn")[0]))
			{
				this.BuyerEmailOptIn = (string)document.GetElementsByTagName("BuyerEmailOptIn")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("SurveyQuestion").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SurveyQuestion")[0]))
			{
				this.SurveyQuestion = (string)document.GetElementsByTagName("SurveyQuestion")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("SurveyChoiceSelected").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SurveyChoiceSelected")[0]))
				{
					nodeList = document.GetElementsByTagName("SurveyChoiceSelected");
					for(int i = 0; i < nodeList.Count; i++)
					{
						string value = nodeList[i].InnerText;
						this.SurveyChoiceSelected.Add(value);
					}
				}
			}
	
		}
		
	}




	/**
      *ReceiverInfoType Receiver information. 
      */
	public partial class ReceiverInfoType	
	{

		/**
          *No Document Comments
		  */
		private string BusinessField;
		public string Business
		{
			get
			{
				return this.BusinessField;
			}
			set
			{
				this.BusinessField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ReceiverField;
		public string Receiver
		{
			get
			{
				return this.ReceiverField;
			}
			set
			{
				this.ReceiverField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ReceiverIDField;
		public string ReceiverID
		{
			get
			{
				return this.ReceiverIDField;
			}
			set
			{
				this.ReceiverIDField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public ReceiverInfoType(){
		}


		public ReceiverInfoType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("Business").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Business")[0]))
			{
				this.Business = (string)document.GetElementsByTagName("Business")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Receiver").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Receiver")[0]))
			{
				this.Receiver = (string)document.GetElementsByTagName("Receiver")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ReceiverID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ReceiverID")[0]))
			{
				this.ReceiverID = (string)document.GetElementsByTagName("ReceiverID")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *PayerInfoType Payer information 
      */
	public partial class PayerInfoType	
	{

		/**
          *No Document Comments
		  */
		private string PayerField;
		public string Payer
		{
			get
			{
				return this.PayerField;
			}
			set
			{
				this.PayerField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PayerIDField;
		public string PayerID
		{
			get
			{
				return this.PayerIDField;
			}
			set
			{
				this.PayerIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PayPalUserStatusCodeType? PayerStatusField;
		public PayPalUserStatusCodeType? PayerStatus
		{
			get
			{
				return this.PayerStatusField;
			}
			set
			{
				this.PayerStatusField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PersonNameType PayerNameField;
		public PersonNameType PayerName
		{
			get
			{
				return this.PayerNameField;
			}
			set
			{
				this.PayerNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private CountryCodeType? PayerCountryField;
		public CountryCodeType? PayerCountry
		{
			get
			{
				return this.PayerCountryField;
			}
			set
			{
				this.PayerCountryField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PayerBusinessField;
		public string PayerBusiness
		{
			get
			{
				return this.PayerBusinessField;
			}
			set
			{
				this.PayerBusinessField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private AddressType AddressField;
		public AddressType Address
		{
			get
			{
				return this.AddressField;
			}
			set
			{
				this.AddressField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ContactPhoneField;
		public string ContactPhone
		{
			get
			{
				return this.ContactPhoneField;
			}
			set
			{
				this.ContactPhoneField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private TaxIdDetailsType TaxIdDetailsField;
		public TaxIdDetailsType TaxIdDetails
		{
			get
			{
				return this.TaxIdDetailsField;
			}
			set
			{
				this.TaxIdDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private EnhancedPayerInfoType EnhancedPayerInfoField;
		public EnhancedPayerInfoType EnhancedPayerInfo
		{
			get
			{
				return this.EnhancedPayerInfoField;
			}
			set
			{
				this.EnhancedPayerInfoField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public PayerInfoType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Payer != null)
			{
				sb.Append("<ebl:Payer>").Append(Payer);
				sb.Append("</ebl:Payer>");
			}
			if(PayerID != null)
			{
				sb.Append("<ebl:PayerID>").Append(PayerID);
				sb.Append("</ebl:PayerID>");
			}
			if(PayerStatus != null)
			{
				sb.Append("<ebl:PayerStatus>").Append(EnumUtils.getDescription(PayerStatus));
				sb.Append("</ebl:PayerStatus>");
			}
			if(PayerName != null)
			{
				sb.Append("<ebl:PayerName>");
				sb.Append(PayerName.toXMLString());
				sb.Append("</ebl:PayerName>");
			}
			if(PayerCountry != null)
			{
				sb.Append("<ebl:PayerCountry>").Append(EnumUtils.getDescription(PayerCountry));
				sb.Append("</ebl:PayerCountry>");
			}
			if(PayerBusiness != null)
			{
				sb.Append("<ebl:PayerBusiness>").Append(PayerBusiness);
				sb.Append("</ebl:PayerBusiness>");
			}
			if(Address != null)
			{
				sb.Append("<ebl:Address>");
				sb.Append(Address.toXMLString());
				sb.Append("</ebl:Address>");
			}
			if(ContactPhone != null)
			{
				sb.Append("<ebl:ContactPhone>").Append(ContactPhone);
				sb.Append("</ebl:ContactPhone>");
			}
			if(TaxIdDetails != null)
			{
				sb.Append("<ebl:TaxIdDetails>");
				sb.Append(TaxIdDetails.toXMLString());
				sb.Append("</ebl:TaxIdDetails>");
			}
			if(EnhancedPayerInfo != null)
			{
				sb.Append("<ebl:EnhancedPayerInfo>");
				sb.Append(EnhancedPayerInfo.toXMLString());
				sb.Append("</ebl:EnhancedPayerInfo>");
			}
			return sb.ToString();
		}
		public PayerInfoType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("Payer").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Payer")[0]))
			{
				this.Payer = (string)document.GetElementsByTagName("Payer")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("PayerID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PayerID")[0]))
			{
				this.PayerID = (string)document.GetElementsByTagName("PayerID")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("PayerStatus").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PayerStatus")[0]))
				{
					this.PayerStatus = (PayPalUserStatusCodeType)EnumUtils.getValue(document.GetElementsByTagName("PayerStatus")[0].InnerText,typeof(PayPalUserStatusCodeType));
				}
			}
			if(document.GetElementsByTagName("PayerName").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PayerName")[0]))
				{
					nodeList = document.GetElementsByTagName("PayerName");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.PayerName =  new PersonNameType(xmlString);
				}
			}
			if(document.GetElementsByTagName("PayerCountry").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PayerCountry")[0]))
				{
					this.PayerCountry = (CountryCodeType)EnumUtils.getValue(document.GetElementsByTagName("PayerCountry")[0].InnerText,typeof(CountryCodeType));
				}
			}
		if(document.GetElementsByTagName("PayerBusiness").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PayerBusiness")[0]))
			{
				this.PayerBusiness = (string)document.GetElementsByTagName("PayerBusiness")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("Address").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Address")[0]))
				{
					nodeList = document.GetElementsByTagName("Address");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.Address =  new AddressType(xmlString);
				}
			}
		if(document.GetElementsByTagName("ContactPhone").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ContactPhone")[0]))
			{
				this.ContactPhone = (string)document.GetElementsByTagName("ContactPhone")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("TaxIdDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TaxIdDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("TaxIdDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.TaxIdDetails =  new TaxIdDetailsType(xmlString);
				}
			}
			if(document.GetElementsByTagName("EnhancedPayerInfo").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("EnhancedPayerInfo")[0]))
				{
					nodeList = document.GetElementsByTagName("EnhancedPayerInfo");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.EnhancedPayerInfo =  new EnhancedPayerInfoType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *InstrumentDetailsType Promotional Instrument Information. 
      */
	public partial class InstrumentDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string InstrumentCategoryField;
		public string InstrumentCategory
		{
			get
			{
				return this.InstrumentCategoryField;
			}
			set
			{
				this.InstrumentCategoryField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public InstrumentDetailsType(){
		}


		public InstrumentDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("InstrumentCategory").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("InstrumentCategory")[0]))
			{
				this.InstrumentCategory = (string)document.GetElementsByTagName("InstrumentCategory")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *BMLOfferInfoType Specific information for BML. 
      */
	public partial class BMLOfferInfoType	
	{

		/**
          *No Document Comments
		  */
		private string OfferTrackingIDField;
		public string OfferTrackingID
		{
			get
			{
				return this.OfferTrackingIDField;
			}
			set
			{
				this.OfferTrackingIDField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public BMLOfferInfoType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(OfferTrackingID != null)
			{
				sb.Append("<ebl:OfferTrackingID>").Append(OfferTrackingID);
				sb.Append("</ebl:OfferTrackingID>");
			}
			return sb.ToString();
		}
		public BMLOfferInfoType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("OfferTrackingID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OfferTrackingID")[0]))
			{
				this.OfferTrackingID = (string)document.GetElementsByTagName("OfferTrackingID")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *OfferDetailsType Specific information for an offer. 
      */
	public partial class OfferDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string OfferCodeField;
		public string OfferCode
		{
			get
			{
				return this.OfferCodeField;
			}
			set
			{
				this.OfferCodeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BMLOfferInfoType BMLOfferInfoField;
		public BMLOfferInfoType BMLOfferInfo
		{
			get
			{
				return this.BMLOfferInfoField;
			}
			set
			{
				this.BMLOfferInfoField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public OfferDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(OfferCode != null)
			{
				sb.Append("<ebl:OfferCode>").Append(OfferCode);
				sb.Append("</ebl:OfferCode>");
			}
			if(BMLOfferInfo != null)
			{
				sb.Append("<ebl:BMLOfferInfo>");
				sb.Append(BMLOfferInfo.toXMLString());
				sb.Append("</ebl:BMLOfferInfo>");
			}
			return sb.ToString();
		}
		public OfferDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("OfferCode").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OfferCode")[0]))
			{
				this.OfferCode = (string)document.GetElementsByTagName("OfferCode")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("BMLOfferInfo").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BMLOfferInfo")[0]))
				{
					nodeList = document.GetElementsByTagName("BMLOfferInfo");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.BMLOfferInfo =  new BMLOfferInfoType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *PaymentInfoType Payment information. 
      */
	public partial class PaymentInfoType	
	{

		/**
          *No Document Comments
		  */
		private string TransactionIDField;
		public string TransactionID
		{
			get
			{
				return this.TransactionIDField;
			}
			set
			{
				this.TransactionIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string EbayTransactionIDField;
		public string EbayTransactionID
		{
			get
			{
				return this.EbayTransactionIDField;
			}
			set
			{
				this.EbayTransactionIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ParentTransactionIDField;
		public string ParentTransactionID
		{
			get
			{
				return this.ParentTransactionIDField;
			}
			set
			{
				this.ParentTransactionIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ReceiptIDField;
		public string ReceiptID
		{
			get
			{
				return this.ReceiptIDField;
			}
			set
			{
				this.ReceiptIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PaymentTransactionCodeType? TransactionTypeField;
		public PaymentTransactionCodeType? TransactionType
		{
			get
			{
				return this.TransactionTypeField;
			}
			set
			{
				this.TransactionTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PaymentCodeType? PaymentTypeField;
		public PaymentCodeType? PaymentType
		{
			get
			{
				return this.PaymentTypeField;
			}
			set
			{
				this.PaymentTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private RefundSourceCodeType? RefundSourceCodeTypeField;
		public RefundSourceCodeType? RefundSourceCodeType
		{
			get
			{
				return this.RefundSourceCodeTypeField;
			}
			set
			{
				this.RefundSourceCodeTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ExpectedeCheckClearDateField;
		public string ExpectedeCheckClearDate
		{
			get
			{
				return this.ExpectedeCheckClearDateField;
			}
			set
			{
				this.ExpectedeCheckClearDateField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PaymentDateField;
		public string PaymentDate
		{
			get
			{
				return this.PaymentDateField;
			}
			set
			{
				this.PaymentDateField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType GrossAmountField;
		public BasicAmountType GrossAmount
		{
			get
			{
				return this.GrossAmountField;
			}
			set
			{
				this.GrossAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType FeeAmountField;
		public BasicAmountType FeeAmount
		{
			get
			{
				return this.FeeAmountField;
			}
			set
			{
				this.FeeAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType SettleAmountField;
		public BasicAmountType SettleAmount
		{
			get
			{
				return this.SettleAmountField;
			}
			set
			{
				this.SettleAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType TaxAmountField;
		public BasicAmountType TaxAmount
		{
			get
			{
				return this.TaxAmountField;
			}
			set
			{
				this.TaxAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ExchangeRateField;
		public string ExchangeRate
		{
			get
			{
				return this.ExchangeRateField;
			}
			set
			{
				this.ExchangeRateField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PaymentStatusCodeType? PaymentStatusField;
		public PaymentStatusCodeType? PaymentStatus
		{
			get
			{
				return this.PaymentStatusField;
			}
			set
			{
				this.PaymentStatusField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PendingStatusCodeType? PendingReasonField;
		public PendingStatusCodeType? PendingReason
		{
			get
			{
				return this.PendingReasonField;
			}
			set
			{
				this.PendingReasonField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ReversalReasonCodeType? ReasonCodeField;
		public ReversalReasonCodeType? ReasonCode
		{
			get
			{
				return this.ReasonCodeField;
			}
			set
			{
				this.ReasonCodeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string HoldDecisionField;
		public string HoldDecision
		{
			get
			{
				return this.HoldDecisionField;
			}
			set
			{
				this.HoldDecisionField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ShippingMethodField;
		public string ShippingMethod
		{
			get
			{
				return this.ShippingMethodField;
			}
			set
			{
				this.ShippingMethodField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ProtectionEligibilityField;
		public string ProtectionEligibility
		{
			get
			{
				return this.ProtectionEligibilityField;
			}
			set
			{
				this.ProtectionEligibilityField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ProtectionEligibilityTypeField;
		public string ProtectionEligibilityType
		{
			get
			{
				return this.ProtectionEligibilityTypeField;
			}
			set
			{
				this.ProtectionEligibilityTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ShipAmountField;
		public string ShipAmount
		{
			get
			{
				return this.ShipAmountField;
			}
			set
			{
				this.ShipAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ShipHandleAmountField;
		public string ShipHandleAmount
		{
			get
			{
				return this.ShipHandleAmountField;
			}
			set
			{
				this.ShipHandleAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ShipDiscountField;
		public string ShipDiscount
		{
			get
			{
				return this.ShipDiscountField;
			}
			set
			{
				this.ShipDiscountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string InsuranceAmountField;
		public string InsuranceAmount
		{
			get
			{
				return this.InsuranceAmountField;
			}
			set
			{
				this.InsuranceAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string SubjectField;
		public string Subject
		{
			get
			{
				return this.SubjectField;
			}
			set
			{
				this.SubjectField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string StoreIDField;
		public string StoreID
		{
			get
			{
				return this.StoreIDField;
			}
			set
			{
				this.StoreIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string TerminalIDField;
		public string TerminalID
		{
			get
			{
				return this.TerminalIDField;
			}
			set
			{
				this.TerminalIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private SellerDetailsType SellerDetailsField;
		public SellerDetailsType SellerDetails
		{
			get
			{
				return this.SellerDetailsField;
			}
			set
			{
				this.SellerDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PaymentRequestIDField;
		public string PaymentRequestID
		{
			get
			{
				return this.PaymentRequestIDField;
			}
			set
			{
				this.PaymentRequestIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private FMFDetailsType FMFDetailsField;
		public FMFDetailsType FMFDetails
		{
			get
			{
				return this.FMFDetailsField;
			}
			set
			{
				this.FMFDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private EnhancedPaymentInfoType EnhancedPaymentInfoField;
		public EnhancedPaymentInfoType EnhancedPaymentInfo
		{
			get
			{
				return this.EnhancedPaymentInfoField;
			}
			set
			{
				this.EnhancedPaymentInfoField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ErrorType PaymentErrorField;
		public ErrorType PaymentError
		{
			get
			{
				return this.PaymentErrorField;
			}
			set
			{
				this.PaymentErrorField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private InstrumentDetailsType InstrumentDetailsField;
		public InstrumentDetailsType InstrumentDetails
		{
			get
			{
				return this.InstrumentDetailsField;
			}
			set
			{
				this.InstrumentDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private OfferDetailsType OfferDetailsField;
		public OfferDetailsType OfferDetails
		{
			get
			{
				return this.OfferDetailsField;
			}
			set
			{
				this.OfferDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public PaymentInfoType(){
		}


		public PaymentInfoType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("TransactionID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TransactionID")[0]))
			{
				this.TransactionID = (string)document.GetElementsByTagName("TransactionID")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("EbayTransactionID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("EbayTransactionID")[0]))
			{
				this.EbayTransactionID = (string)document.GetElementsByTagName("EbayTransactionID")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ParentTransactionID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ParentTransactionID")[0]))
			{
				this.ParentTransactionID = (string)document.GetElementsByTagName("ParentTransactionID")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ReceiptID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ReceiptID")[0]))
			{
				this.ReceiptID = (string)document.GetElementsByTagName("ReceiptID")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("TransactionType").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TransactionType")[0]))
				{
					this.TransactionType = (PaymentTransactionCodeType)EnumUtils.getValue(document.GetElementsByTagName("TransactionType")[0].InnerText,typeof(PaymentTransactionCodeType));
				}
			}
			if(document.GetElementsByTagName("PaymentType").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentType")[0]))
				{
					this.PaymentType = (PaymentCodeType)EnumUtils.getValue(document.GetElementsByTagName("PaymentType")[0].InnerText,typeof(PaymentCodeType));
				}
			}
			if(document.GetElementsByTagName("RefundSourceCodeType").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("RefundSourceCodeType")[0]))
				{
					this.RefundSourceCodeType = (RefundSourceCodeType)EnumUtils.getValue(document.GetElementsByTagName("RefundSourceCodeType")[0].InnerText,typeof(RefundSourceCodeType));
				}
			}
		if(document.GetElementsByTagName("ExpectedeCheckClearDate").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ExpectedeCheckClearDate")[0]))
			{
				this.ExpectedeCheckClearDate = (string)document.GetElementsByTagName("ExpectedeCheckClearDate")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("PaymentDate").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentDate")[0]))
			{
				this.PaymentDate = (string)document.GetElementsByTagName("PaymentDate")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("GrossAmount").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GrossAmount")[0]))
				{
					nodeList = document.GetElementsByTagName("GrossAmount");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.GrossAmount =  new BasicAmountType(xmlString);
				}
			}
			if(document.GetElementsByTagName("FeeAmount").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("FeeAmount")[0]))
				{
					nodeList = document.GetElementsByTagName("FeeAmount");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.FeeAmount =  new BasicAmountType(xmlString);
				}
			}
			if(document.GetElementsByTagName("SettleAmount").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SettleAmount")[0]))
				{
					nodeList = document.GetElementsByTagName("SettleAmount");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.SettleAmount =  new BasicAmountType(xmlString);
				}
			}
			if(document.GetElementsByTagName("TaxAmount").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TaxAmount")[0]))
				{
					nodeList = document.GetElementsByTagName("TaxAmount");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.TaxAmount =  new BasicAmountType(xmlString);
				}
			}
		if(document.GetElementsByTagName("ExchangeRate").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ExchangeRate")[0]))
			{
				this.ExchangeRate = (string)document.GetElementsByTagName("ExchangeRate")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("PaymentStatus").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentStatus")[0]))
				{
					this.PaymentStatus = (PaymentStatusCodeType)EnumUtils.getValue(document.GetElementsByTagName("PaymentStatus")[0].InnerText,typeof(PaymentStatusCodeType));
				}
			}
			if(document.GetElementsByTagName("PendingReason").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PendingReason")[0]))
				{
					this.PendingReason = (PendingStatusCodeType)EnumUtils.getValue(document.GetElementsByTagName("PendingReason")[0].InnerText,typeof(PendingStatusCodeType));
				}
			}
			if(document.GetElementsByTagName("ReasonCode").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ReasonCode")[0]))
				{
					this.ReasonCode = (ReversalReasonCodeType)EnumUtils.getValue(document.GetElementsByTagName("ReasonCode")[0].InnerText,typeof(ReversalReasonCodeType));
				}
			}
		if(document.GetElementsByTagName("HoldDecision").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("HoldDecision")[0]))
			{
				this.HoldDecision = (string)document.GetElementsByTagName("HoldDecision")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ShippingMethod").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ShippingMethod")[0]))
			{
				this.ShippingMethod = (string)document.GetElementsByTagName("ShippingMethod")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ProtectionEligibility").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ProtectionEligibility")[0]))
			{
				this.ProtectionEligibility = (string)document.GetElementsByTagName("ProtectionEligibility")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ProtectionEligibilityType").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ProtectionEligibilityType")[0]))
			{
				this.ProtectionEligibilityType = (string)document.GetElementsByTagName("ProtectionEligibilityType")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ShipAmount").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ShipAmount")[0]))
			{
				this.ShipAmount = (string)document.GetElementsByTagName("ShipAmount")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ShipHandleAmount").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ShipHandleAmount")[0]))
			{
				this.ShipHandleAmount = (string)document.GetElementsByTagName("ShipHandleAmount")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ShipDiscount").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ShipDiscount")[0]))
			{
				this.ShipDiscount = (string)document.GetElementsByTagName("ShipDiscount")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("InsuranceAmount").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("InsuranceAmount")[0]))
			{
				this.InsuranceAmount = (string)document.GetElementsByTagName("InsuranceAmount")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Subject").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Subject")[0]))
			{
				this.Subject = (string)document.GetElementsByTagName("Subject")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("StoreID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("StoreID")[0]))
			{
				this.StoreID = (string)document.GetElementsByTagName("StoreID")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("TerminalID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TerminalID")[0]))
			{
				this.TerminalID = (string)document.GetElementsByTagName("TerminalID")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("SellerDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SellerDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("SellerDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.SellerDetails =  new SellerDetailsType(xmlString);
				}
			}
		if(document.GetElementsByTagName("PaymentRequestID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentRequestID")[0]))
			{
				this.PaymentRequestID = (string)document.GetElementsByTagName("PaymentRequestID")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("FMFDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("FMFDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("FMFDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.FMFDetails =  new FMFDetailsType(xmlString);
				}
			}
			if(document.GetElementsByTagName("EnhancedPaymentInfo").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("EnhancedPaymentInfo")[0]))
				{
					nodeList = document.GetElementsByTagName("EnhancedPaymentInfo");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.EnhancedPaymentInfo =  new EnhancedPaymentInfoType(xmlString);
				}
			}
			if(document.GetElementsByTagName("PaymentError").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentError")[0]))
				{
					nodeList = document.GetElementsByTagName("PaymentError");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.PaymentError =  new ErrorType(xmlString);
				}
			}
			if(document.GetElementsByTagName("InstrumentDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("InstrumentDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("InstrumentDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.InstrumentDetails =  new InstrumentDetailsType(xmlString);
				}
			}
			if(document.GetElementsByTagName("OfferDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OfferDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("OfferDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.OfferDetails =  new OfferDetailsType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *SubscriptionTermsType Terms of a PayPal subscription. 
      */
	public partial class SubscriptionTermsType	
	{

		/**
          *No Document Comments
		  */
		private BasicAmountType AmountField;
		public BasicAmountType Amount
		{
			get
			{
				return this.AmountField;
			}
			set
			{
				this.AmountField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public SubscriptionTermsType(){
		}


		public SubscriptionTermsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("Amount").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Amount")[0]))
				{
					nodeList = document.GetElementsByTagName("Amount");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.Amount =  new BasicAmountType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *SubscriptionInfoType Information about a PayPal
      *Subscription. 
      */
	public partial class SubscriptionInfoType	
	{

		/**
          *No Document Comments
		  */
		private string SubscriptionIDField;
		public string SubscriptionID
		{
			get
			{
				return this.SubscriptionIDField;
			}
			set
			{
				this.SubscriptionIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string SubscriptionDateField;
		public string SubscriptionDate
		{
			get
			{
				return this.SubscriptionDateField;
			}
			set
			{
				this.SubscriptionDateField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string EffectiveDateField;
		public string EffectiveDate
		{
			get
			{
				return this.EffectiveDateField;
			}
			set
			{
				this.EffectiveDateField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string RetryTimeField;
		public string RetryTime
		{
			get
			{
				return this.RetryTimeField;
			}
			set
			{
				this.RetryTimeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string UsernameField;
		public string Username
		{
			get
			{
				return this.UsernameField;
			}
			set
			{
				this.UsernameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PasswordField;
		public string Password
		{
			get
			{
				return this.PasswordField;
			}
			set
			{
				this.PasswordField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string RecurrencesField;
		public string Recurrences
		{
			get
			{
				return this.RecurrencesField;
			}
			set
			{
				this.RecurrencesField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<SubscriptionTermsType> TermsField = new List<SubscriptionTermsType>();
		public List<SubscriptionTermsType> Terms
		{
			get
			{
				return this.TermsField;
			}
			set
			{
				this.TermsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public SubscriptionInfoType(){
		}


		public SubscriptionInfoType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("SubscriptionID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SubscriptionID")[0]))
			{
				this.SubscriptionID = (string)document.GetElementsByTagName("SubscriptionID")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("SubscriptionDate").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SubscriptionDate")[0]))
			{
				this.SubscriptionDate = (string)document.GetElementsByTagName("SubscriptionDate")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("EffectiveDate").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("EffectiveDate")[0]))
			{
				this.EffectiveDate = (string)document.GetElementsByTagName("EffectiveDate")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("RetryTime").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("RetryTime")[0]))
			{
				this.RetryTime = (string)document.GetElementsByTagName("RetryTime")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Username").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Username")[0]))
			{
				this.Username = (string)document.GetElementsByTagName("Username")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Password").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Password")[0]))
			{
				this.Password = (string)document.GetElementsByTagName("Password")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Recurrences").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Recurrences")[0]))
			{
				this.Recurrences = (string)document.GetElementsByTagName("Recurrences")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("Terms").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Terms")[0]))
				{
					nodeList = document.GetElementsByTagName("Terms");
					for(int i = 0; i < nodeList.Count; i++)
					{
						xmlString = DeserializationUtils.convertToXML(nodeList[i]);
						this.Terms.Add(new SubscriptionTermsType(xmlString));
					}
				}
			}
	
		}
		
	}




	/**
      *AuctionInfoType Basic information about an auction. 
      */
	public partial class AuctionInfoType	
	{

		/**
          *No Document Comments
		  */
		private string BuyerIDField;
		public string BuyerID
		{
			get
			{
				return this.BuyerIDField;
			}
			set
			{
				this.BuyerIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ClosingDateField;
		public string ClosingDate
		{
			get
			{
				return this.ClosingDateField;
			}
			set
			{
				this.ClosingDateField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public AuctionInfoType(){
		}


		public AuctionInfoType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("BuyerID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BuyerID")[0]))
			{
				this.BuyerID = (string)document.GetElementsByTagName("BuyerID")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ClosingDate").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ClosingDate")[0]))
			{
				this.ClosingDate = (string)document.GetElementsByTagName("ClosingDate")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *OptionType PayPal item options for shopping cart. 
      */
	public partial class OptionType	
	{

		/**
	 	  * Default Constructor
	 	  */
	 	public OptionType(){
		}


		public OptionType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
	
		}
		
	}




	/**
      *EbayItemPaymentDetailsItemType - Type declaration to be used
      *by other schemas. Information about an Ebay Payment Item. 
      */
	public partial class EbayItemPaymentDetailsItemType	
	{

		/**
          *No Document Comments
		  */
		private string ItemNumberField;
		public string ItemNumber
		{
			get
			{
				return this.ItemNumberField;
			}
			set
			{
				this.ItemNumberField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string AuctionTransactionIdField;
		public string AuctionTransactionId
		{
			get
			{
				return this.AuctionTransactionIdField;
			}
			set
			{
				this.AuctionTransactionIdField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string OrderIdField;
		public string OrderId
		{
			get
			{
				return this.OrderIdField;
			}
			set
			{
				this.OrderIdField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CartIDField;
		public string CartID
		{
			get
			{
				return this.CartIDField;
			}
			set
			{
				this.CartIDField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public EbayItemPaymentDetailsItemType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ItemNumber != null)
			{
				sb.Append("<ebl:ItemNumber>").Append(ItemNumber);
				sb.Append("</ebl:ItemNumber>");
			}
			if(AuctionTransactionId != null)
			{
				sb.Append("<ebl:AuctionTransactionId>").Append(AuctionTransactionId);
				sb.Append("</ebl:AuctionTransactionId>");
			}
			if(OrderId != null)
			{
				sb.Append("<ebl:OrderId>").Append(OrderId);
				sb.Append("</ebl:OrderId>");
			}
			if(CartID != null)
			{
				sb.Append("<ebl:CartID>").Append(CartID);
				sb.Append("</ebl:CartID>");
			}
			return sb.ToString();
		}
		public EbayItemPaymentDetailsItemType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("ItemNumber").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ItemNumber")[0]))
			{
				this.ItemNumber = (string)document.GetElementsByTagName("ItemNumber")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("AuctionTransactionId").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AuctionTransactionId")[0]))
			{
				this.AuctionTransactionId = (string)document.GetElementsByTagName("AuctionTransactionId")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("OrderId").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OrderId")[0]))
			{
				this.OrderId = (string)document.GetElementsByTagName("OrderId")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("CartID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CartID")[0]))
			{
				this.CartID = (string)document.GetElementsByTagName("CartID")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *PaymentDetailsItemType Information about a Payment Item. 
      */
	public partial class PaymentDetailsItemType	
	{

		/**
          *No Document Comments
		  */
		private string NameField;
		public string Name
		{
			get
			{
				return this.NameField;
			}
			set
			{
				this.NameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string NumberField;
		public string Number
		{
			get
			{
				return this.NumberField;
			}
			set
			{
				this.NumberField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? QuantityField;
		public int? Quantity
		{
			get
			{
				return this.QuantityField;
			}
			set
			{
				this.QuantityField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType TaxField;
		public BasicAmountType Tax
		{
			get
			{
				return this.TaxField;
			}
			set
			{
				this.TaxField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType AmountField;
		public BasicAmountType Amount
		{
			get
			{
				return this.AmountField;
			}
			set
			{
				this.AmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private EbayItemPaymentDetailsItemType EbayItemPaymentDetailsItemField;
		public EbayItemPaymentDetailsItemType EbayItemPaymentDetailsItem
		{
			get
			{
				return this.EbayItemPaymentDetailsItemField;
			}
			set
			{
				this.EbayItemPaymentDetailsItemField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PromoCodeField;
		public string PromoCode
		{
			get
			{
				return this.PromoCodeField;
			}
			set
			{
				this.PromoCodeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ProductCategoryType? ProductCategoryField;
		public ProductCategoryType? ProductCategory
		{
			get
			{
				return this.ProductCategoryField;
			}
			set
			{
				this.ProductCategoryField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string DescriptionField;
		public string Description
		{
			get
			{
				return this.DescriptionField;
			}
			set
			{
				this.DescriptionField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private MeasureType ItemWeightField;
		public MeasureType ItemWeight
		{
			get
			{
				return this.ItemWeightField;
			}
			set
			{
				this.ItemWeightField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private MeasureType ItemLengthField;
		public MeasureType ItemLength
		{
			get
			{
				return this.ItemLengthField;
			}
			set
			{
				this.ItemLengthField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private MeasureType ItemWidthField;
		public MeasureType ItemWidth
		{
			get
			{
				return this.ItemWidthField;
			}
			set
			{
				this.ItemWidthField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private MeasureType ItemHeightField;
		public MeasureType ItemHeight
		{
			get
			{
				return this.ItemHeightField;
			}
			set
			{
				this.ItemHeightField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ItemURLField;
		public string ItemURL
		{
			get
			{
				return this.ItemURLField;
			}
			set
			{
				this.ItemURLField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private EnhancedItemDataType EnhancedItemDataField;
		public EnhancedItemDataType EnhancedItemData
		{
			get
			{
				return this.EnhancedItemDataField;
			}
			set
			{
				this.EnhancedItemDataField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ItemCategoryType? ItemCategoryField;
		public ItemCategoryType? ItemCategory
		{
			get
			{
				return this.ItemCategoryField;
			}
			set
			{
				this.ItemCategoryField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public PaymentDetailsItemType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Name != null)
			{
				sb.Append("<ebl:Name>").Append(Name);
				sb.Append("</ebl:Name>");
			}
			if(Number != null)
			{
				sb.Append("<ebl:Number>").Append(Number);
				sb.Append("</ebl:Number>");
			}
			if(Quantity != null)
			{
				sb.Append("<ebl:Quantity>").Append(Quantity);
				sb.Append("</ebl:Quantity>");
			}
			if(Tax != null)
			{
				sb.Append("<ebl:Tax");
				sb.Append(Tax.toXMLString());
				sb.Append("</ebl:Tax>");
			}
			if(Amount != null)
			{
				sb.Append("<ebl:Amount");
				sb.Append(Amount.toXMLString());
				sb.Append("</ebl:Amount>");
			}
			if(EbayItemPaymentDetailsItem != null)
			{
				sb.Append("<ebl:EbayItemPaymentDetailsItem>");
				sb.Append(EbayItemPaymentDetailsItem.toXMLString());
				sb.Append("</ebl:EbayItemPaymentDetailsItem>");
			}
			if(PromoCode != null)
			{
				sb.Append("<ebl:PromoCode>").Append(PromoCode);
				sb.Append("</ebl:PromoCode>");
			}
			if(ProductCategory != null)
			{
				sb.Append("<ebl:ProductCategory>").Append(EnumUtils.getDescription(ProductCategory));
				sb.Append("</ebl:ProductCategory>");
			}
			if(Description != null)
			{
				sb.Append("<ebl:Description>").Append(Description);
				sb.Append("</ebl:Description>");
			}
			if(ItemWeight != null)
			{
				sb.Append("<ebl:ItemWeight");
				sb.Append(ItemWeight.toXMLString());
				sb.Append("</ebl:ItemWeight>");
			}
			if(ItemLength != null)
			{
				sb.Append("<ebl:ItemLength");
				sb.Append(ItemLength.toXMLString());
				sb.Append("</ebl:ItemLength>");
			}
			if(ItemWidth != null)
			{
				sb.Append("<ebl:ItemWidth");
				sb.Append(ItemWidth.toXMLString());
				sb.Append("</ebl:ItemWidth>");
			}
			if(ItemHeight != null)
			{
				sb.Append("<ebl:ItemHeight");
				sb.Append(ItemHeight.toXMLString());
				sb.Append("</ebl:ItemHeight>");
			}
			if(ItemURL != null)
			{
				sb.Append("<ebl:ItemURL>").Append(ItemURL);
				sb.Append("</ebl:ItemURL>");
			}
			if(EnhancedItemData != null)
			{
				sb.Append("<ebl:EnhancedItemData>");
				sb.Append(EnhancedItemData.toXMLString());
				sb.Append("</ebl:EnhancedItemData>");
			}
			if(ItemCategory != null)
			{
				sb.Append("<ebl:ItemCategory>").Append(EnumUtils.getDescription(ItemCategory));
				sb.Append("</ebl:ItemCategory>");
			}
			return sb.ToString();
		}
		public PaymentDetailsItemType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("Name").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Name")[0]))
			{
				this.Name = (string)document.GetElementsByTagName("Name")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Number").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Number")[0]))
			{
				this.Number = (string)document.GetElementsByTagName("Number")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Quantity").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Quantity")[0]))
			{
				this.Quantity = System.Convert.ToInt32(document.GetElementsByTagName("Quantity")[0].InnerText);
			}
		}
			if(document.GetElementsByTagName("Tax").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Tax")[0]))
				{
					nodeList = document.GetElementsByTagName("Tax");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.Tax =  new BasicAmountType(xmlString);
				}
			}
			if(document.GetElementsByTagName("Amount").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Amount")[0]))
				{
					nodeList = document.GetElementsByTagName("Amount");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.Amount =  new BasicAmountType(xmlString);
				}
			}
			if(document.GetElementsByTagName("EbayItemPaymentDetailsItem").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("EbayItemPaymentDetailsItem")[0]))
				{
					nodeList = document.GetElementsByTagName("EbayItemPaymentDetailsItem");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.EbayItemPaymentDetailsItem =  new EbayItemPaymentDetailsItemType(xmlString);
				}
			}
		if(document.GetElementsByTagName("PromoCode").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PromoCode")[0]))
			{
				this.PromoCode = (string)document.GetElementsByTagName("PromoCode")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("ProductCategory").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ProductCategory")[0]))
				{
					this.ProductCategory = (ProductCategoryType)EnumUtils.getValue(document.GetElementsByTagName("ProductCategory")[0].InnerText,typeof(ProductCategoryType));
				}
			}
		if(document.GetElementsByTagName("Description").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Description")[0]))
			{
				this.Description = (string)document.GetElementsByTagName("Description")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("ItemWeight").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ItemWeight")[0]))
				{
					nodeList = document.GetElementsByTagName("ItemWeight");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.ItemWeight =  new MeasureType(xmlString);
				}
			}
			if(document.GetElementsByTagName("ItemLength").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ItemLength")[0]))
				{
					nodeList = document.GetElementsByTagName("ItemLength");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.ItemLength =  new MeasureType(xmlString);
				}
			}
			if(document.GetElementsByTagName("ItemWidth").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ItemWidth")[0]))
				{
					nodeList = document.GetElementsByTagName("ItemWidth");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.ItemWidth =  new MeasureType(xmlString);
				}
			}
			if(document.GetElementsByTagName("ItemHeight").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ItemHeight")[0]))
				{
					nodeList = document.GetElementsByTagName("ItemHeight");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.ItemHeight =  new MeasureType(xmlString);
				}
			}
		if(document.GetElementsByTagName("ItemURL").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ItemURL")[0]))
			{
				this.ItemURL = (string)document.GetElementsByTagName("ItemURL")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("EnhancedItemData").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("EnhancedItemData")[0]))
				{
					nodeList = document.GetElementsByTagName("EnhancedItemData");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.EnhancedItemData =  new EnhancedItemDataType(xmlString);
				}
			}
			if(document.GetElementsByTagName("ItemCategory").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ItemCategory")[0]))
				{
					this.ItemCategory = (ItemCategoryType)EnumUtils.getValue(document.GetElementsByTagName("ItemCategory")[0].InnerText,typeof(ItemCategoryType));
				}
			}
	
		}
		
	}




	/**
      *PaymentItemType Information about a Payment Item. 
      */
	public partial class PaymentItemType	
	{

		/**
          *No Document Comments
		  */
		private string EbayItemTxnIdField;
		public string EbayItemTxnId
		{
			get
			{
				return this.EbayItemTxnIdField;
			}
			set
			{
				this.EbayItemTxnIdField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string NameField;
		public string Name
		{
			get
			{
				return this.NameField;
			}
			set
			{
				this.NameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string NumberField;
		public string Number
		{
			get
			{
				return this.NumberField;
			}
			set
			{
				this.NumberField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string QuantityField;
		public string Quantity
		{
			get
			{
				return this.QuantityField;
			}
			set
			{
				this.QuantityField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string SalesTaxField;
		public string SalesTax
		{
			get
			{
				return this.SalesTaxField;
			}
			set
			{
				this.SalesTaxField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ShippingAmountField;
		public string ShippingAmount
		{
			get
			{
				return this.ShippingAmountField;
			}
			set
			{
				this.ShippingAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string HandlingAmountField;
		public string HandlingAmount
		{
			get
			{
				return this.HandlingAmountField;
			}
			set
			{
				this.HandlingAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CouponIDField;
		public string CouponID
		{
			get
			{
				return this.CouponIDField;
			}
			set
			{
				this.CouponIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CouponAmountField;
		public string CouponAmount
		{
			get
			{
				return this.CouponAmountField;
			}
			set
			{
				this.CouponAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CouponAmountCurrencyField;
		public string CouponAmountCurrency
		{
			get
			{
				return this.CouponAmountCurrencyField;
			}
			set
			{
				this.CouponAmountCurrencyField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string LoyaltyCardDiscountAmountField;
		public string LoyaltyCardDiscountAmount
		{
			get
			{
				return this.LoyaltyCardDiscountAmountField;
			}
			set
			{
				this.LoyaltyCardDiscountAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string LoyaltyCardDiscountCurrencyField;
		public string LoyaltyCardDiscountCurrency
		{
			get
			{
				return this.LoyaltyCardDiscountCurrencyField;
			}
			set
			{
				this.LoyaltyCardDiscountCurrencyField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType AmountField;
		public BasicAmountType Amount
		{
			get
			{
				return this.AmountField;
			}
			set
			{
				this.AmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<OptionType> OptionsField = new List<OptionType>();
		public List<OptionType> Options
		{
			get
			{
				return this.OptionsField;
			}
			set
			{
				this.OptionsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public PaymentItemType(){
		}


		public PaymentItemType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("EbayItemTxnId").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("EbayItemTxnId")[0]))
			{
				this.EbayItemTxnId = (string)document.GetElementsByTagName("EbayItemTxnId")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Name").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Name")[0]))
			{
				this.Name = (string)document.GetElementsByTagName("Name")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Number").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Number")[0]))
			{
				this.Number = (string)document.GetElementsByTagName("Number")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Quantity").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Quantity")[0]))
			{
				this.Quantity = (string)document.GetElementsByTagName("Quantity")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("SalesTax").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SalesTax")[0]))
			{
				this.SalesTax = (string)document.GetElementsByTagName("SalesTax")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ShippingAmount").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ShippingAmount")[0]))
			{
				this.ShippingAmount = (string)document.GetElementsByTagName("ShippingAmount")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("HandlingAmount").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("HandlingAmount")[0]))
			{
				this.HandlingAmount = (string)document.GetElementsByTagName("HandlingAmount")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("CouponID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CouponID")[0]))
			{
				this.CouponID = (string)document.GetElementsByTagName("CouponID")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("CouponAmount").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CouponAmount")[0]))
			{
				this.CouponAmount = (string)document.GetElementsByTagName("CouponAmount")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("CouponAmountCurrency").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CouponAmountCurrency")[0]))
			{
				this.CouponAmountCurrency = (string)document.GetElementsByTagName("CouponAmountCurrency")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("LoyaltyCardDiscountAmount").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("LoyaltyCardDiscountAmount")[0]))
			{
				this.LoyaltyCardDiscountAmount = (string)document.GetElementsByTagName("LoyaltyCardDiscountAmount")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("LoyaltyCardDiscountCurrency").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("LoyaltyCardDiscountCurrency")[0]))
			{
				this.LoyaltyCardDiscountCurrency = (string)document.GetElementsByTagName("LoyaltyCardDiscountCurrency")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("Amount").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Amount")[0]))
				{
					nodeList = document.GetElementsByTagName("Amount");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.Amount =  new BasicAmountType(xmlString);
				}
			}
			if(document.GetElementsByTagName("Options").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Options")[0]))
				{
					nodeList = document.GetElementsByTagName("Options");
					for(int i = 0; i < nodeList.Count; i++)
					{
						xmlString = DeserializationUtils.convertToXML(nodeList[i]);
						this.Options.Add(new OptionType(xmlString));
					}
				}
			}
	
		}
		
	}




	/**
      *PaymentItemInfoType Information about a PayPal item. 
      */
	public partial class PaymentItemInfoType	
	{

		/**
          *No Document Comments
		  */
		private string InvoiceIDField;
		public string InvoiceID
		{
			get
			{
				return this.InvoiceIDField;
			}
			set
			{
				this.InvoiceIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CustomField;
		public string Custom
		{
			get
			{
				return this.CustomField;
			}
			set
			{
				this.CustomField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string MemoField;
		public string Memo
		{
			get
			{
				return this.MemoField;
			}
			set
			{
				this.MemoField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string SalesTaxField;
		public string SalesTax
		{
			get
			{
				return this.SalesTaxField;
			}
			set
			{
				this.SalesTaxField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<PaymentItemType> PaymentItemField = new List<PaymentItemType>();
		public List<PaymentItemType> PaymentItem
		{
			get
			{
				return this.PaymentItemField;
			}
			set
			{
				this.PaymentItemField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private SubscriptionInfoType SubscriptionField;
		public SubscriptionInfoType Subscription
		{
			get
			{
				return this.SubscriptionField;
			}
			set
			{
				this.SubscriptionField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private AuctionInfoType AuctionField;
		public AuctionInfoType Auction
		{
			get
			{
				return this.AuctionField;
			}
			set
			{
				this.AuctionField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public PaymentItemInfoType(){
		}


		public PaymentItemInfoType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("InvoiceID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("InvoiceID")[0]))
			{
				this.InvoiceID = (string)document.GetElementsByTagName("InvoiceID")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Custom").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Custom")[0]))
			{
				this.Custom = (string)document.GetElementsByTagName("Custom")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Memo").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Memo")[0]))
			{
				this.Memo = (string)document.GetElementsByTagName("Memo")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("SalesTax").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SalesTax")[0]))
			{
				this.SalesTax = (string)document.GetElementsByTagName("SalesTax")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("PaymentItem").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentItem")[0]))
				{
					nodeList = document.GetElementsByTagName("PaymentItem");
					for(int i = 0; i < nodeList.Count; i++)
					{
						xmlString = DeserializationUtils.convertToXML(nodeList[i]);
						this.PaymentItem.Add(new PaymentItemType(xmlString));
					}
				}
			}
			if(document.GetElementsByTagName("Subscription").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Subscription")[0]))
				{
					nodeList = document.GetElementsByTagName("Subscription");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.Subscription =  new SubscriptionInfoType(xmlString);
				}
			}
			if(document.GetElementsByTagName("Auction").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Auction")[0]))
				{
					nodeList = document.GetElementsByTagName("Auction");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.Auction =  new AuctionInfoType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *OffersAndCouponsInfoType Information about a Offers and
      *Coupons. 
      */
	public partial class OfferCouponInfoType	
	{

		/**
          *No Document Comments
		  */
		private string TypeField;
		public string Type
		{
			get
			{
				return this.TypeField;
			}
			set
			{
				this.TypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string IDField;
		public string ID
		{
			get
			{
				return this.IDField;
			}
			set
			{
				this.IDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string AmountField;
		public string Amount
		{
			get
			{
				return this.AmountField;
			}
			set
			{
				this.AmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string AmountCurrencyField;
		public string AmountCurrency
		{
			get
			{
				return this.AmountCurrencyField;
			}
			set
			{
				this.AmountCurrencyField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public OfferCouponInfoType(){
		}


		public OfferCouponInfoType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("Type").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Type")[0]))
			{
				this.Type = (string)document.GetElementsByTagName("Type")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ID")[0]))
			{
				this.ID = (string)document.GetElementsByTagName("ID")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Amount").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Amount")[0]))
			{
				this.Amount = (string)document.GetElementsByTagName("Amount")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("AmountCurrency").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AmountCurrency")[0]))
			{
				this.AmountCurrency = (string)document.GetElementsByTagName("AmountCurrency")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *PaymentDetailsType Information about a payment. Used by DCC
      *and Express Checkout. 
      */
	public partial class PaymentDetailsType	
	{

		/**
          *No Document Comments
		  */
		private BasicAmountType OrderTotalField;
		public BasicAmountType OrderTotal
		{
			get
			{
				return this.OrderTotalField;
			}
			set
			{
				this.OrderTotalField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType ItemTotalField;
		public BasicAmountType ItemTotal
		{
			get
			{
				return this.ItemTotalField;
			}
			set
			{
				this.ItemTotalField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType ShippingTotalField;
		public BasicAmountType ShippingTotal
		{
			get
			{
				return this.ShippingTotalField;
			}
			set
			{
				this.ShippingTotalField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType HandlingTotalField;
		public BasicAmountType HandlingTotal
		{
			get
			{
				return this.HandlingTotalField;
			}
			set
			{
				this.HandlingTotalField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType TaxTotalField;
		public BasicAmountType TaxTotal
		{
			get
			{
				return this.TaxTotalField;
			}
			set
			{
				this.TaxTotalField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string OrderDescriptionField;
		public string OrderDescription
		{
			get
			{
				return this.OrderDescriptionField;
			}
			set
			{
				this.OrderDescriptionField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CustomField;
		public string Custom
		{
			get
			{
				return this.CustomField;
			}
			set
			{
				this.CustomField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string InvoiceIDField;
		public string InvoiceID
		{
			get
			{
				return this.InvoiceIDField;
			}
			set
			{
				this.InvoiceIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ButtonSourceField;
		public string ButtonSource
		{
			get
			{
				return this.ButtonSourceField;
			}
			set
			{
				this.ButtonSourceField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string NotifyURLField;
		public string NotifyURL
		{
			get
			{
				return this.NotifyURLField;
			}
			set
			{
				this.NotifyURLField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private AddressType ShipToAddressField;
		public AddressType ShipToAddress
		{
			get
			{
				return this.ShipToAddressField;
			}
			set
			{
				this.ShipToAddressField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ShippingServiceCodeType? ShippingMethodField;
		public ShippingServiceCodeType? ShippingMethod
		{
			get
			{
				return this.ShippingMethodField;
			}
			set
			{
				this.ShippingMethodField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ProfileAddressChangeDateField;
		public string ProfileAddressChangeDate
		{
			get
			{
				return this.ProfileAddressChangeDateField;
			}
			set
			{
				this.ProfileAddressChangeDateField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<PaymentDetailsItemType> PaymentDetailsItemField = new List<PaymentDetailsItemType>();
		public List<PaymentDetailsItemType> PaymentDetailsItem
		{
			get
			{
				return this.PaymentDetailsItemField;
			}
			set
			{
				this.PaymentDetailsItemField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType InsuranceTotalField;
		public BasicAmountType InsuranceTotal
		{
			get
			{
				return this.InsuranceTotalField;
			}
			set
			{
				this.InsuranceTotalField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType ShippingDiscountField;
		public BasicAmountType ShippingDiscount
		{
			get
			{
				return this.ShippingDiscountField;
			}
			set
			{
				this.ShippingDiscountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string InsuranceOptionOfferedField;
		public string InsuranceOptionOffered
		{
			get
			{
				return this.InsuranceOptionOfferedField;
			}
			set
			{
				this.InsuranceOptionOfferedField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private AllowedPaymentMethodType? AllowedPaymentMethodField;
		public AllowedPaymentMethodType? AllowedPaymentMethod
		{
			get
			{
				return this.AllowedPaymentMethodField;
			}
			set
			{
				this.AllowedPaymentMethodField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private EnhancedPaymentDataType EnhancedPaymentDataField;
		public EnhancedPaymentDataType EnhancedPaymentData
		{
			get
			{
				return this.EnhancedPaymentDataField;
			}
			set
			{
				this.EnhancedPaymentDataField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private SellerDetailsType SellerDetailsField;
		public SellerDetailsType SellerDetails
		{
			get
			{
				return this.SellerDetailsField;
			}
			set
			{
				this.SellerDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string NoteTextField;
		public string NoteText
		{
			get
			{
				return this.NoteTextField;
			}
			set
			{
				this.NoteTextField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string TransactionIdField;
		public string TransactionId
		{
			get
			{
				return this.TransactionIdField;
			}
			set
			{
				this.TransactionIdField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PaymentActionCodeType? PaymentActionField;
		public PaymentActionCodeType? PaymentAction
		{
			get
			{
				return this.PaymentActionField;
			}
			set
			{
				this.PaymentActionField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PaymentRequestIDField;
		public string PaymentRequestID
		{
			get
			{
				return this.PaymentRequestIDField;
			}
			set
			{
				this.PaymentRequestIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string OrderURLField;
		public string OrderURL
		{
			get
			{
				return this.OrderURLField;
			}
			set
			{
				this.OrderURLField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string SoftDescriptorField;
		public string SoftDescriptor
		{
			get
			{
				return this.SoftDescriptorField;
			}
			set
			{
				this.SoftDescriptorField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? BranchLevelField;
		public int? BranchLevel
		{
			get
			{
				return this.BranchLevelField;
			}
			set
			{
				this.BranchLevelField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private OfferDetailsType OfferDetailsField;
		public OfferDetailsType OfferDetails
		{
			get
			{
				return this.OfferDetailsField;
			}
			set
			{
				this.OfferDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private RecurringFlagType? RecurringField;
		public RecurringFlagType? Recurring
		{
			get
			{
				return this.RecurringField;
			}
			set
			{
				this.RecurringField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PaymentReasonType? PaymentReasonField;
		public PaymentReasonType? PaymentReason
		{
			get
			{
				return this.PaymentReasonField;
			}
			set
			{
				this.PaymentReasonField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public PaymentDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(OrderTotal != null)
			{
				sb.Append("<ebl:OrderTotal");
				sb.Append(OrderTotal.toXMLString());
				sb.Append("</ebl:OrderTotal>");
			}
			if(ItemTotal != null)
			{
				sb.Append("<ebl:ItemTotal");
				sb.Append(ItemTotal.toXMLString());
				sb.Append("</ebl:ItemTotal>");
			}
			if(ShippingTotal != null)
			{
				sb.Append("<ebl:ShippingTotal");
				sb.Append(ShippingTotal.toXMLString());
				sb.Append("</ebl:ShippingTotal>");
			}
			if(HandlingTotal != null)
			{
				sb.Append("<ebl:HandlingTotal");
				sb.Append(HandlingTotal.toXMLString());
				sb.Append("</ebl:HandlingTotal>");
			}
			if(TaxTotal != null)
			{
				sb.Append("<ebl:TaxTotal");
				sb.Append(TaxTotal.toXMLString());
				sb.Append("</ebl:TaxTotal>");
			}
			if(OrderDescription != null)
			{
				sb.Append("<ebl:OrderDescription>").Append(OrderDescription);
				sb.Append("</ebl:OrderDescription>");
			}
			if(Custom != null)
			{
				sb.Append("<ebl:Custom>").Append(Custom);
				sb.Append("</ebl:Custom>");
			}
			if(InvoiceID != null)
			{
				sb.Append("<ebl:InvoiceID>").Append(InvoiceID);
				sb.Append("</ebl:InvoiceID>");
			}
			if(ButtonSource != null)
			{
				sb.Append("<ebl:ButtonSource>").Append(ButtonSource);
				sb.Append("</ebl:ButtonSource>");
			}
			if(NotifyURL != null)
			{
				sb.Append("<ebl:NotifyURL>").Append(NotifyURL);
				sb.Append("</ebl:NotifyURL>");
			}
			if(ShipToAddress != null)
			{
				sb.Append("<ebl:ShipToAddress>");
				sb.Append(ShipToAddress.toXMLString());
				sb.Append("</ebl:ShipToAddress>");
			}
			if(ShippingMethod != null)
			{
				sb.Append("<ebl:ShippingMethod>").Append(EnumUtils.getDescription(ShippingMethod));
				sb.Append("</ebl:ShippingMethod>");
			}
			if(ProfileAddressChangeDate != null)
			{
				sb.Append("<ebl:ProfileAddressChangeDate>").Append(ProfileAddressChangeDate);
				sb.Append("</ebl:ProfileAddressChangeDate>");
			}
			if(PaymentDetailsItem != null)
			{
				for(int i = 0; i < PaymentDetailsItem.Count; i++)
				{
					sb.Append("<ebl:PaymentDetailsItem>");
					sb.Append(PaymentDetailsItem[i].toXMLString());
					sb.Append("</ebl:PaymentDetailsItem>");
				
				}
			}
			if(InsuranceTotal != null)
			{
				sb.Append("<ebl:InsuranceTotal");
				sb.Append(InsuranceTotal.toXMLString());
				sb.Append("</ebl:InsuranceTotal>");
			}
			if(ShippingDiscount != null)
			{
				sb.Append("<ebl:ShippingDiscount");
				sb.Append(ShippingDiscount.toXMLString());
				sb.Append("</ebl:ShippingDiscount>");
			}
			if(InsuranceOptionOffered != null)
			{
				sb.Append("<ebl:InsuranceOptionOffered>").Append(InsuranceOptionOffered);
				sb.Append("</ebl:InsuranceOptionOffered>");
			}
			if(AllowedPaymentMethod != null)
			{
				sb.Append("<ebl:AllowedPaymentMethod>").Append(EnumUtils.getDescription(AllowedPaymentMethod));
				sb.Append("</ebl:AllowedPaymentMethod>");
			}
			if(EnhancedPaymentData != null)
			{
				sb.Append("<ebl:EnhancedPaymentData>");
				sb.Append(EnhancedPaymentData.toXMLString());
				sb.Append("</ebl:EnhancedPaymentData>");
			}
			if(SellerDetails != null)
			{
				sb.Append("<ebl:SellerDetails>");
				sb.Append(SellerDetails.toXMLString());
				sb.Append("</ebl:SellerDetails>");
			}
			if(NoteText != null)
			{
				sb.Append("<ebl:NoteText>").Append(NoteText);
				sb.Append("</ebl:NoteText>");
			}
			if(TransactionId != null)
			{
				sb.Append("<ebl:TransactionId>").Append(TransactionId);
				sb.Append("</ebl:TransactionId>");
			}
			if(PaymentAction != null)
			{
				sb.Append("<ebl:PaymentAction>").Append(EnumUtils.getDescription(PaymentAction));
				sb.Append("</ebl:PaymentAction>");
			}
			if(PaymentRequestID != null)
			{
				sb.Append("<ebl:PaymentRequestID>").Append(PaymentRequestID);
				sb.Append("</ebl:PaymentRequestID>");
			}
			if(OrderURL != null)
			{
				sb.Append("<ebl:OrderURL>").Append(OrderURL);
				sb.Append("</ebl:OrderURL>");
			}
			if(SoftDescriptor != null)
			{
				sb.Append("<ebl:SoftDescriptor>").Append(SoftDescriptor);
				sb.Append("</ebl:SoftDescriptor>");
			}
			if(BranchLevel != null)
			{
				sb.Append("<ebl:BranchLevel>").Append(BranchLevel);
				sb.Append("</ebl:BranchLevel>");
			}
			if(OfferDetails != null)
			{
				sb.Append("<ebl:OfferDetails>");
				sb.Append(OfferDetails.toXMLString());
				sb.Append("</ebl:OfferDetails>");
			}
			if(Recurring != null)
			{
				sb.Append("<ebl:Recurring>").Append(EnumUtils.getDescription(Recurring));
				sb.Append("</ebl:Recurring>");
			}
			if(PaymentReason != null)
			{
				sb.Append("<ebl:PaymentReason>").Append(EnumUtils.getDescription(PaymentReason));
				sb.Append("</ebl:PaymentReason>");
			}
			return sb.ToString();
		}
		public PaymentDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("OrderTotal").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OrderTotal")[0]))
				{
					nodeList = document.GetElementsByTagName("OrderTotal");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.OrderTotal =  new BasicAmountType(xmlString);
				}
			}
			if(document.GetElementsByTagName("ItemTotal").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ItemTotal")[0]))
				{
					nodeList = document.GetElementsByTagName("ItemTotal");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.ItemTotal =  new BasicAmountType(xmlString);
				}
			}
			if(document.GetElementsByTagName("ShippingTotal").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ShippingTotal")[0]))
				{
					nodeList = document.GetElementsByTagName("ShippingTotal");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.ShippingTotal =  new BasicAmountType(xmlString);
				}
			}
			if(document.GetElementsByTagName("HandlingTotal").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("HandlingTotal")[0]))
				{
					nodeList = document.GetElementsByTagName("HandlingTotal");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.HandlingTotal =  new BasicAmountType(xmlString);
				}
			}
			if(document.GetElementsByTagName("TaxTotal").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TaxTotal")[0]))
				{
					nodeList = document.GetElementsByTagName("TaxTotal");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.TaxTotal =  new BasicAmountType(xmlString);
				}
			}
		if(document.GetElementsByTagName("OrderDescription").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OrderDescription")[0]))
			{
				this.OrderDescription = (string)document.GetElementsByTagName("OrderDescription")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Custom").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Custom")[0]))
			{
				this.Custom = (string)document.GetElementsByTagName("Custom")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("InvoiceID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("InvoiceID")[0]))
			{
				this.InvoiceID = (string)document.GetElementsByTagName("InvoiceID")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ButtonSource").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ButtonSource")[0]))
			{
				this.ButtonSource = (string)document.GetElementsByTagName("ButtonSource")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("NotifyURL").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("NotifyURL")[0]))
			{
				this.NotifyURL = (string)document.GetElementsByTagName("NotifyURL")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("ShipToAddress").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ShipToAddress")[0]))
				{
					nodeList = document.GetElementsByTagName("ShipToAddress");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.ShipToAddress =  new AddressType(xmlString);
				}
			}
			if(document.GetElementsByTagName("ShippingMethod").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ShippingMethod")[0]))
				{
					this.ShippingMethod = (ShippingServiceCodeType)EnumUtils.getValue(document.GetElementsByTagName("ShippingMethod")[0].InnerText,typeof(ShippingServiceCodeType));
				}
			}
		if(document.GetElementsByTagName("ProfileAddressChangeDate").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ProfileAddressChangeDate")[0]))
			{
				this.ProfileAddressChangeDate = (string)document.GetElementsByTagName("ProfileAddressChangeDate")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("PaymentDetailsItem").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentDetailsItem")[0]))
				{
					nodeList = document.GetElementsByTagName("PaymentDetailsItem");
					for(int i = 0; i < nodeList.Count; i++)
					{
						xmlString = DeserializationUtils.convertToXML(nodeList[i]);
						this.PaymentDetailsItem.Add(new PaymentDetailsItemType(xmlString));
					}
				}
			}
			if(document.GetElementsByTagName("InsuranceTotal").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("InsuranceTotal")[0]))
				{
					nodeList = document.GetElementsByTagName("InsuranceTotal");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.InsuranceTotal =  new BasicAmountType(xmlString);
				}
			}
			if(document.GetElementsByTagName("ShippingDiscount").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ShippingDiscount")[0]))
				{
					nodeList = document.GetElementsByTagName("ShippingDiscount");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.ShippingDiscount =  new BasicAmountType(xmlString);
				}
			}
		if(document.GetElementsByTagName("InsuranceOptionOffered").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("InsuranceOptionOffered")[0]))
			{
				this.InsuranceOptionOffered = (string)document.GetElementsByTagName("InsuranceOptionOffered")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("AllowedPaymentMethod").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AllowedPaymentMethod")[0]))
				{
					this.AllowedPaymentMethod = (AllowedPaymentMethodType)EnumUtils.getValue(document.GetElementsByTagName("AllowedPaymentMethod")[0].InnerText,typeof(AllowedPaymentMethodType));
				}
			}
			if(document.GetElementsByTagName("EnhancedPaymentData").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("EnhancedPaymentData")[0]))
				{
					nodeList = document.GetElementsByTagName("EnhancedPaymentData");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.EnhancedPaymentData =  new EnhancedPaymentDataType(xmlString);
				}
			}
			if(document.GetElementsByTagName("SellerDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SellerDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("SellerDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.SellerDetails =  new SellerDetailsType(xmlString);
				}
			}
		if(document.GetElementsByTagName("NoteText").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("NoteText")[0]))
			{
				this.NoteText = (string)document.GetElementsByTagName("NoteText")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("TransactionId").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TransactionId")[0]))
			{
				this.TransactionId = (string)document.GetElementsByTagName("TransactionId")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("PaymentAction").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentAction")[0]))
				{
					this.PaymentAction = (PaymentActionCodeType)EnumUtils.getValue(document.GetElementsByTagName("PaymentAction")[0].InnerText,typeof(PaymentActionCodeType));
				}
			}
		if(document.GetElementsByTagName("PaymentRequestID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentRequestID")[0]))
			{
				this.PaymentRequestID = (string)document.GetElementsByTagName("PaymentRequestID")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("OrderURL").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OrderURL")[0]))
			{
				this.OrderURL = (string)document.GetElementsByTagName("OrderURL")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("SoftDescriptor").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SoftDescriptor")[0]))
			{
				this.SoftDescriptor = (string)document.GetElementsByTagName("SoftDescriptor")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("BranchLevel").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BranchLevel")[0]))
			{
				this.BranchLevel = System.Convert.ToInt32(document.GetElementsByTagName("BranchLevel")[0].InnerText);
			}
		}
			if(document.GetElementsByTagName("OfferDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OfferDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("OfferDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.OfferDetails =  new OfferDetailsType(xmlString);
				}
			}
			if(document.GetElementsByTagName("Recurring").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Recurring")[0]))
				{
					this.Recurring = (RecurringFlagType)EnumUtils.getValue(document.GetElementsByTagName("Recurring")[0].InnerText,typeof(RecurringFlagType));
				}
			}
			if(document.GetElementsByTagName("PaymentReason").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentReason")[0]))
				{
					this.PaymentReason = (PaymentReasonType)EnumUtils.getValue(document.GetElementsByTagName("PaymentReason")[0].InnerText,typeof(PaymentReasonType));
				}
			}
	
		}
		
	}




	/**
      *Information about the incentives that were applied from Ebay
      *RYP page and PayPal RYP page. 
      */
	public partial class IncentiveDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string UniqueIdentifierField;
		public string UniqueIdentifier
		{
			get
			{
				return this.UniqueIdentifierField;
			}
			set
			{
				this.UniqueIdentifierField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private IncentiveSiteAppliedOnType? SiteAppliedOnField;
		public IncentiveSiteAppliedOnType? SiteAppliedOn
		{
			get
			{
				return this.SiteAppliedOnField;
			}
			set
			{
				this.SiteAppliedOnField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType TotalDiscountAmountField;
		public BasicAmountType TotalDiscountAmount
		{
			get
			{
				return this.TotalDiscountAmountField;
			}
			set
			{
				this.TotalDiscountAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private IncentiveAppliedStatusType? StatusField;
		public IncentiveAppliedStatusType? Status
		{
			get
			{
				return this.StatusField;
			}
			set
			{
				this.StatusField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? ErrorCodeField;
		public int? ErrorCode
		{
			get
			{
				return this.ErrorCodeField;
			}
			set
			{
				this.ErrorCodeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<IncentiveAppliedDetailsType> IncentiveAppliedDetailsField = new List<IncentiveAppliedDetailsType>();
		public List<IncentiveAppliedDetailsType> IncentiveAppliedDetails
		{
			get
			{
				return this.IncentiveAppliedDetailsField;
			}
			set
			{
				this.IncentiveAppliedDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public IncentiveDetailsType(){
		}


		public IncentiveDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("UniqueIdentifier").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("UniqueIdentifier")[0]))
			{
				this.UniqueIdentifier = (string)document.GetElementsByTagName("UniqueIdentifier")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("SiteAppliedOn").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SiteAppliedOn")[0]))
				{
					this.SiteAppliedOn = (IncentiveSiteAppliedOnType)EnumUtils.getValue(document.GetElementsByTagName("SiteAppliedOn")[0].InnerText,typeof(IncentiveSiteAppliedOnType));
				}
			}
			if(document.GetElementsByTagName("TotalDiscountAmount").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TotalDiscountAmount")[0]))
				{
					nodeList = document.GetElementsByTagName("TotalDiscountAmount");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.TotalDiscountAmount =  new BasicAmountType(xmlString);
				}
			}
			if(document.GetElementsByTagName("Status").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Status")[0]))
				{
					this.Status = (IncentiveAppliedStatusType)EnumUtils.getValue(document.GetElementsByTagName("Status")[0].InnerText,typeof(IncentiveAppliedStatusType));
				}
			}
		if(document.GetElementsByTagName("ErrorCode").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ErrorCode")[0]))
			{
				this.ErrorCode = System.Convert.ToInt32(document.GetElementsByTagName("ErrorCode")[0].InnerText);
			}
		}
			if(document.GetElementsByTagName("IncentiveAppliedDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("IncentiveAppliedDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("IncentiveAppliedDetails");
					for(int i = 0; i < nodeList.Count; i++)
					{
						xmlString = DeserializationUtils.convertToXML(nodeList[i]);
						this.IncentiveAppliedDetails.Add(new IncentiveAppliedDetailsType(xmlString));
					}
				}
			}
	
		}
		
	}




	/**
      *Details of incentive application on individual bucket/item. 
      */
	public partial class IncentiveAppliedDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string PaymentRequestIDField;
		public string PaymentRequestID
		{
			get
			{
				return this.PaymentRequestIDField;
			}
			set
			{
				this.PaymentRequestIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ItemIdField;
		public string ItemId
		{
			get
			{
				return this.ItemIdField;
			}
			set
			{
				this.ItemIdField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ExternalTxnIdField;
		public string ExternalTxnId
		{
			get
			{
				return this.ExternalTxnIdField;
			}
			set
			{
				this.ExternalTxnIdField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType DiscountAmountField;
		public BasicAmountType DiscountAmount
		{
			get
			{
				return this.DiscountAmountField;
			}
			set
			{
				this.DiscountAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string SubTypeField;
		public string SubType
		{
			get
			{
				return this.SubTypeField;
			}
			set
			{
				this.SubTypeField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public IncentiveAppliedDetailsType(){
		}


		public IncentiveAppliedDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("PaymentRequestID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentRequestID")[0]))
			{
				this.PaymentRequestID = (string)document.GetElementsByTagName("PaymentRequestID")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ItemId").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ItemId")[0]))
			{
				this.ItemId = (string)document.GetElementsByTagName("ItemId")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ExternalTxnId").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ExternalTxnId")[0]))
			{
				this.ExternalTxnId = (string)document.GetElementsByTagName("ExternalTxnId")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("DiscountAmount").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("DiscountAmount")[0]))
				{
					nodeList = document.GetElementsByTagName("DiscountAmount");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.DiscountAmount =  new BasicAmountType(xmlString);
				}
			}
		if(document.GetElementsByTagName("SubType").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SubType")[0]))
			{
				this.SubType = (string)document.GetElementsByTagName("SubType")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *Details about the seller. 
      */
	public partial class SellerDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string SellerIdField;
		public string SellerId
		{
			get
			{
				return this.SellerIdField;
			}
			set
			{
				this.SellerIdField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string SellerUserNameField;
		public string SellerUserName
		{
			get
			{
				return this.SellerUserNameField;
			}
			set
			{
				this.SellerUserNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string SellerRegistrationDateField;
		public string SellerRegistrationDate
		{
			get
			{
				return this.SellerRegistrationDateField;
			}
			set
			{
				this.SellerRegistrationDateField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PayPalAccountIDField;
		public string PayPalAccountID
		{
			get
			{
				return this.PayPalAccountIDField;
			}
			set
			{
				this.PayPalAccountIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string SecureMerchantAccountIDField;
		public string SecureMerchantAccountID
		{
			get
			{
				return this.SecureMerchantAccountIDField;
			}
			set
			{
				this.SecureMerchantAccountIDField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public SellerDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(SellerId != null)
			{
				sb.Append("<ebl:SellerId>").Append(SellerId);
				sb.Append("</ebl:SellerId>");
			}
			if(SellerUserName != null)
			{
				sb.Append("<ebl:SellerUserName>").Append(SellerUserName);
				sb.Append("</ebl:SellerUserName>");
			}
			if(SellerRegistrationDate != null)
			{
				sb.Append("<ebl:SellerRegistrationDate>").Append(SellerRegistrationDate);
				sb.Append("</ebl:SellerRegistrationDate>");
			}
			if(PayPalAccountID != null)
			{
				sb.Append("<ebl:PayPalAccountID>").Append(PayPalAccountID);
				sb.Append("</ebl:PayPalAccountID>");
			}
			if(SecureMerchantAccountID != null)
			{
				sb.Append("<ebl:SecureMerchantAccountID>").Append(SecureMerchantAccountID);
				sb.Append("</ebl:SecureMerchantAccountID>");
			}
			return sb.ToString();
		}
		public SellerDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("SellerId").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SellerId")[0]))
			{
				this.SellerId = (string)document.GetElementsByTagName("SellerId")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("SellerUserName").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SellerUserName")[0]))
			{
				this.SellerUserName = (string)document.GetElementsByTagName("SellerUserName")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("SellerRegistrationDate").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SellerRegistrationDate")[0]))
			{
				this.SellerRegistrationDate = (string)document.GetElementsByTagName("SellerRegistrationDate")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("PayPalAccountID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PayPalAccountID")[0]))
			{
				this.PayPalAccountID = (string)document.GetElementsByTagName("PayPalAccountID")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("SecureMerchantAccountID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SecureMerchantAccountID")[0]))
			{
				this.SecureMerchantAccountID = (string)document.GetElementsByTagName("SecureMerchantAccountID")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *Lists the Payment Methods (other than PayPal) that the use
      *can pay with e.g. Money Order. Optional. 
      */
	public partial class OtherPaymentMethodDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string OtherPaymentMethodIdField;
		public string OtherPaymentMethodId
		{
			get
			{
				return this.OtherPaymentMethodIdField;
			}
			set
			{
				this.OtherPaymentMethodIdField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string OtherPaymentMethodTypeField;
		public string OtherPaymentMethodType
		{
			get
			{
				return this.OtherPaymentMethodTypeField;
			}
			set
			{
				this.OtherPaymentMethodTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string OtherPaymentMethodLabelField;
		public string OtherPaymentMethodLabel
		{
			get
			{
				return this.OtherPaymentMethodLabelField;
			}
			set
			{
				this.OtherPaymentMethodLabelField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string OtherPaymentMethodLabelDescriptionField;
		public string OtherPaymentMethodLabelDescription
		{
			get
			{
				return this.OtherPaymentMethodLabelDescriptionField;
			}
			set
			{
				this.OtherPaymentMethodLabelDescriptionField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string OtherPaymentMethodLongDescriptionTitleField;
		public string OtherPaymentMethodLongDescriptionTitle
		{
			get
			{
				return this.OtherPaymentMethodLongDescriptionTitleField;
			}
			set
			{
				this.OtherPaymentMethodLongDescriptionTitleField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string OtherPaymentMethodLongDescriptionField;
		public string OtherPaymentMethodLongDescription
		{
			get
			{
				return this.OtherPaymentMethodLongDescriptionField;
			}
			set
			{
				this.OtherPaymentMethodLongDescriptionField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string OtherPaymentMethodIconField;
		public string OtherPaymentMethodIcon
		{
			get
			{
				return this.OtherPaymentMethodIconField;
			}
			set
			{
				this.OtherPaymentMethodIconField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private bool? OtherPaymentMethodHideLabelField;
		public bool? OtherPaymentMethodHideLabel
		{
			get
			{
				return this.OtherPaymentMethodHideLabelField;
			}
			set
			{
				this.OtherPaymentMethodHideLabelField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public OtherPaymentMethodDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(OtherPaymentMethodId != null)
			{
				sb.Append("<ebl:OtherPaymentMethodId>").Append(OtherPaymentMethodId);
				sb.Append("</ebl:OtherPaymentMethodId>");
			}
			if(OtherPaymentMethodType != null)
			{
				sb.Append("<ebl:OtherPaymentMethodType>").Append(OtherPaymentMethodType);
				sb.Append("</ebl:OtherPaymentMethodType>");
			}
			if(OtherPaymentMethodLabel != null)
			{
				sb.Append("<ebl:OtherPaymentMethodLabel>").Append(OtherPaymentMethodLabel);
				sb.Append("</ebl:OtherPaymentMethodLabel>");
			}
			if(OtherPaymentMethodLabelDescription != null)
			{
				sb.Append("<ebl:OtherPaymentMethodLabelDescription>").Append(OtherPaymentMethodLabelDescription);
				sb.Append("</ebl:OtherPaymentMethodLabelDescription>");
			}
			if(OtherPaymentMethodLongDescriptionTitle != null)
			{
				sb.Append("<ebl:OtherPaymentMethodLongDescriptionTitle>").Append(OtherPaymentMethodLongDescriptionTitle);
				sb.Append("</ebl:OtherPaymentMethodLongDescriptionTitle>");
			}
			if(OtherPaymentMethodLongDescription != null)
			{
				sb.Append("<ebl:OtherPaymentMethodLongDescription>").Append(OtherPaymentMethodLongDescription);
				sb.Append("</ebl:OtherPaymentMethodLongDescription>");
			}
			if(OtherPaymentMethodIcon != null)
			{
				sb.Append("<ebl:OtherPaymentMethodIcon>").Append(OtherPaymentMethodIcon);
				sb.Append("</ebl:OtherPaymentMethodIcon>");
			}
			if(OtherPaymentMethodHideLabel != null)
			{
				sb.Append("<ebl:OtherPaymentMethodHideLabel>").Append(OtherPaymentMethodHideLabel);
				sb.Append("</ebl:OtherPaymentMethodHideLabel>");
			}
			return sb.ToString();
		}
	}




	/**
      *Details about the buyer's account passed in by the merchant
      *or partner. Optional. 
      */
	public partial class BuyerDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string BuyerIdField;
		public string BuyerId
		{
			get
			{
				return this.BuyerIdField;
			}
			set
			{
				this.BuyerIdField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string BuyerUserNameField;
		public string BuyerUserName
		{
			get
			{
				return this.BuyerUserNameField;
			}
			set
			{
				this.BuyerUserNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string BuyerRegistrationDateField;
		public string BuyerRegistrationDate
		{
			get
			{
				return this.BuyerRegistrationDateField;
			}
			set
			{
				this.BuyerRegistrationDateField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private TaxIdDetailsType TaxIdDetailsField;
		public TaxIdDetailsType TaxIdDetails
		{
			get
			{
				return this.TaxIdDetailsField;
			}
			set
			{
				this.TaxIdDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private IdentificationInfoType IdentificationInfoField;
		public IdentificationInfoType IdentificationInfo
		{
			get
			{
				return this.IdentificationInfoField;
			}
			set
			{
				this.IdentificationInfoField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public BuyerDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(BuyerId != null)
			{
				sb.Append("<ebl:BuyerId>").Append(BuyerId);
				sb.Append("</ebl:BuyerId>");
			}
			if(BuyerUserName != null)
			{
				sb.Append("<ebl:BuyerUserName>").Append(BuyerUserName);
				sb.Append("</ebl:BuyerUserName>");
			}
			if(BuyerRegistrationDate != null)
			{
				sb.Append("<ebl:BuyerRegistrationDate>").Append(BuyerRegistrationDate);
				sb.Append("</ebl:BuyerRegistrationDate>");
			}
			if(TaxIdDetails != null)
			{
				sb.Append("<ebl:TaxIdDetails>");
				sb.Append(TaxIdDetails.toXMLString());
				sb.Append("</ebl:TaxIdDetails>");
			}
			if(IdentificationInfo != null)
			{
				sb.Append("<ebl:IdentificationInfo>");
				sb.Append(IdentificationInfo.toXMLString());
				sb.Append("</ebl:IdentificationInfo>");
			}
			return sb.ToString();
		}
	}




	/**
      *Details about the payer's tax info passed in by the merchant
      *or partner. Optional. 
      */
	public partial class TaxIdDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string TaxIdTypeField;
		public string TaxIdType
		{
			get
			{
				return this.TaxIdTypeField;
			}
			set
			{
				this.TaxIdTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string TaxIdField;
		public string TaxId
		{
			get
			{
				return this.TaxIdField;
			}
			set
			{
				this.TaxIdField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public TaxIdDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(TaxIdType != null)
			{
				sb.Append("<ebl:TaxIdType>").Append(TaxIdType);
				sb.Append("</ebl:TaxIdType>");
			}
			if(TaxId != null)
			{
				sb.Append("<ebl:TaxId>").Append(TaxId);
				sb.Append("</ebl:TaxId>");
			}
			return sb.ToString();
		}
		public TaxIdDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("TaxIdType").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TaxIdType")[0]))
			{
				this.TaxIdType = (string)document.GetElementsByTagName("TaxIdType")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("TaxId").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TaxId")[0]))
			{
				this.TaxId = (string)document.GetElementsByTagName("TaxId")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *The Common 3DS fields. Common for both GTD and DCC API's. 
      */
	public partial class ThreeDSecureRequestType	
	{

		/**
          *No Document Comments
		  */
		private string Eci3dsField;
		public string Eci3ds
		{
			get
			{
				return this.Eci3dsField;
			}
			set
			{
				this.Eci3dsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CavvField;
		public string Cavv
		{
			get
			{
				return this.CavvField;
			}
			set
			{
				this.CavvField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string XidField;
		public string Xid
		{
			get
			{
				return this.XidField;
			}
			set
			{
				this.XidField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string MpiVendor3dsField;
		public string MpiVendor3ds
		{
			get
			{
				return this.MpiVendor3dsField;
			}
			set
			{
				this.MpiVendor3dsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string AuthStatus3dsField;
		public string AuthStatus3ds
		{
			get
			{
				return this.AuthStatus3dsField;
			}
			set
			{
				this.AuthStatus3dsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public ThreeDSecureRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Eci3ds != null)
			{
				sb.Append("<ebl:Eci3ds>").Append(Eci3ds);
				sb.Append("</ebl:Eci3ds>");
			}
			if(Cavv != null)
			{
				sb.Append("<ebl:Cavv>").Append(Cavv);
				sb.Append("</ebl:Cavv>");
			}
			if(Xid != null)
			{
				sb.Append("<ebl:Xid>").Append(Xid);
				sb.Append("</ebl:Xid>");
			}
			if(MpiVendor3ds != null)
			{
				sb.Append("<ebl:MpiVendor3ds>").Append(MpiVendor3ds);
				sb.Append("</ebl:MpiVendor3ds>");
			}
			if(AuthStatus3ds != null)
			{
				sb.Append("<ebl:AuthStatus3ds>").Append(AuthStatus3ds);
				sb.Append("</ebl:AuthStatus3ds>");
			}
			return sb.ToString();
		}
		public ThreeDSecureRequestType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("Eci3ds").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Eci3ds")[0]))
			{
				this.Eci3ds = (string)document.GetElementsByTagName("Eci3ds")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Cavv").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Cavv")[0]))
			{
				this.Cavv = (string)document.GetElementsByTagName("Cavv")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Xid").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Xid")[0]))
			{
				this.Xid = (string)document.GetElementsByTagName("Xid")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("MpiVendor3ds").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("MpiVendor3ds")[0]))
			{
				this.MpiVendor3ds = (string)document.GetElementsByTagName("MpiVendor3ds")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("AuthStatus3ds").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AuthStatus3ds")[0]))
			{
				this.AuthStatus3ds = (string)document.GetElementsByTagName("AuthStatus3ds")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *3DS remaining fields. 
      */
	public partial class ThreeDSecureResponseType	
	{

		/**
          *No Document Comments
		  */
		private string VpasField;
		public string Vpas
		{
			get
			{
				return this.VpasField;
			}
			set
			{
				this.VpasField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string EciSubmitted3DSField;
		public string EciSubmitted3DS
		{
			get
			{
				return this.EciSubmitted3DSField;
			}
			set
			{
				this.EciSubmitted3DSField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public ThreeDSecureResponseType(){
		}


		public ThreeDSecureResponseType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("Vpas").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Vpas")[0]))
			{
				this.Vpas = (string)document.GetElementsByTagName("Vpas")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("EciSubmitted3DS").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("EciSubmitted3DS")[0]))
			{
				this.EciSubmitted3DS = (string)document.GetElementsByTagName("EciSubmitted3DS")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *3DSecureInfoType Information about 3D Secure parameters. 
      */
	public partial class ThreeDSecureInfoType	
	{

		/**
          *No Document Comments
		  */
		private ThreeDSecureRequestType ThreeDSecureRequestField;
		public ThreeDSecureRequestType ThreeDSecureRequest
		{
			get
			{
				return this.ThreeDSecureRequestField;
			}
			set
			{
				this.ThreeDSecureRequestField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ThreeDSecureResponseType ThreeDSecureResponseField;
		public ThreeDSecureResponseType ThreeDSecureResponse
		{
			get
			{
				return this.ThreeDSecureResponseField;
			}
			set
			{
				this.ThreeDSecureResponseField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public ThreeDSecureInfoType(){
		}


		public ThreeDSecureInfoType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("ThreeDSecureRequest").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ThreeDSecureRequest")[0]))
				{
					nodeList = document.GetElementsByTagName("ThreeDSecureRequest");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.ThreeDSecureRequest =  new ThreeDSecureRequestType(xmlString);
				}
			}
			if(document.GetElementsByTagName("ThreeDSecureResponse").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ThreeDSecureResponse")[0]))
				{
					nodeList = document.GetElementsByTagName("ThreeDSecureResponse");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.ThreeDSecureResponse =  new ThreeDSecureResponseType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *CreditCardDetailsType Information about a Credit Card. 
      */
	public partial class CreditCardDetailsType	
	{

		/**
          *No Document Comments
		  */
		private CreditCardTypeType? CreditCardTypeField;
		public CreditCardTypeType? CreditCardType
		{
			get
			{
				return this.CreditCardTypeField;
			}
			set
			{
				this.CreditCardTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CreditCardNumberField;
		public string CreditCardNumber
		{
			get
			{
				return this.CreditCardNumberField;
			}
			set
			{
				this.CreditCardNumberField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? ExpMonthField;
		public int? ExpMonth
		{
			get
			{
				return this.ExpMonthField;
			}
			set
			{
				this.ExpMonthField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? ExpYearField;
		public int? ExpYear
		{
			get
			{
				return this.ExpYearField;
			}
			set
			{
				this.ExpYearField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PayerInfoType CardOwnerField;
		public PayerInfoType CardOwner
		{
			get
			{
				return this.CardOwnerField;
			}
			set
			{
				this.CardOwnerField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CVV2Field;
		public string CVV2
		{
			get
			{
				return this.CVV2Field;
			}
			set
			{
				this.CVV2Field = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? StartMonthField;
		public int? StartMonth
		{
			get
			{
				return this.StartMonthField;
			}
			set
			{
				this.StartMonthField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? StartYearField;
		public int? StartYear
		{
			get
			{
				return this.StartYearField;
			}
			set
			{
				this.StartYearField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string IssueNumberField;
		public string IssueNumber
		{
			get
			{
				return this.IssueNumberField;
			}
			set
			{
				this.IssueNumberField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ThreeDSecureRequestType ThreeDSecureRequestField;
		public ThreeDSecureRequestType ThreeDSecureRequest
		{
			get
			{
				return this.ThreeDSecureRequestField;
			}
			set
			{
				this.ThreeDSecureRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public CreditCardDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(CreditCardType != null)
			{
				sb.Append("<ebl:CreditCardType>").Append(EnumUtils.getDescription(CreditCardType));
				sb.Append("</ebl:CreditCardType>");
			}
			if(CreditCardNumber != null)
			{
				sb.Append("<ebl:CreditCardNumber>").Append(CreditCardNumber);
				sb.Append("</ebl:CreditCardNumber>");
			}
			if(ExpMonth != null)
			{
				sb.Append("<ebl:ExpMonth>").Append(ExpMonth);
				sb.Append("</ebl:ExpMonth>");
			}
			if(ExpYear != null)
			{
				sb.Append("<ebl:ExpYear>").Append(ExpYear);
				sb.Append("</ebl:ExpYear>");
			}
			if(CardOwner != null)
			{
				sb.Append("<ebl:CardOwner>");
				sb.Append(CardOwner.toXMLString());
				sb.Append("</ebl:CardOwner>");
			}
			if(CVV2 != null)
			{
				sb.Append("<ebl:CVV2>").Append(CVV2);
				sb.Append("</ebl:CVV2>");
			}
			if(StartMonth != null)
			{
				sb.Append("<ebl:StartMonth>").Append(StartMonth);
				sb.Append("</ebl:StartMonth>");
			}
			if(StartYear != null)
			{
				sb.Append("<ebl:StartYear>").Append(StartYear);
				sb.Append("</ebl:StartYear>");
			}
			if(IssueNumber != null)
			{
				sb.Append("<ebl:IssueNumber>").Append(IssueNumber);
				sb.Append("</ebl:IssueNumber>");
			}
			if(ThreeDSecureRequest != null)
			{
				sb.Append("<ebl:ThreeDSecureRequest>");
				sb.Append(ThreeDSecureRequest.toXMLString());
				sb.Append("</ebl:ThreeDSecureRequest>");
			}
			return sb.ToString();
		}
		public CreditCardDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("CreditCardType").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CreditCardType")[0]))
				{
					this.CreditCardType = (CreditCardTypeType)EnumUtils.getValue(document.GetElementsByTagName("CreditCardType")[0].InnerText,typeof(CreditCardTypeType));
				}
			}
		if(document.GetElementsByTagName("CreditCardNumber").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CreditCardNumber")[0]))
			{
				this.CreditCardNumber = (string)document.GetElementsByTagName("CreditCardNumber")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ExpMonth").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ExpMonth")[0]))
			{
				this.ExpMonth = System.Convert.ToInt32(document.GetElementsByTagName("ExpMonth")[0].InnerText);
			}
		}
		if(document.GetElementsByTagName("ExpYear").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ExpYear")[0]))
			{
				this.ExpYear = System.Convert.ToInt32(document.GetElementsByTagName("ExpYear")[0].InnerText);
			}
		}
			if(document.GetElementsByTagName("CardOwner").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CardOwner")[0]))
				{
					nodeList = document.GetElementsByTagName("CardOwner");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.CardOwner =  new PayerInfoType(xmlString);
				}
			}
		if(document.GetElementsByTagName("CVV2").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CVV2")[0]))
			{
				this.CVV2 = (string)document.GetElementsByTagName("CVV2")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("StartMonth").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("StartMonth")[0]))
			{
				this.StartMonth = System.Convert.ToInt32(document.GetElementsByTagName("StartMonth")[0].InnerText);
			}
		}
		if(document.GetElementsByTagName("StartYear").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("StartYear")[0]))
			{
				this.StartYear = System.Convert.ToInt32(document.GetElementsByTagName("StartYear")[0].InnerText);
			}
		}
		if(document.GetElementsByTagName("IssueNumber").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("IssueNumber")[0]))
			{
				this.IssueNumber = (string)document.GetElementsByTagName("IssueNumber")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("ThreeDSecureRequest").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ThreeDSecureRequest")[0]))
				{
					nodeList = document.GetElementsByTagName("ThreeDSecureRequest");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.ThreeDSecureRequest =  new ThreeDSecureRequestType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *Fallback shipping options type. 
      */
	public partial class ShippingOptionType	
	{

		/**
          *No Document Comments
		  */
		private string ShippingOptionIsDefaultField;
		public string ShippingOptionIsDefault
		{
			get
			{
				return this.ShippingOptionIsDefaultField;
			}
			set
			{
				this.ShippingOptionIsDefaultField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType ShippingOptionAmountField;
		public BasicAmountType ShippingOptionAmount
		{
			get
			{
				return this.ShippingOptionAmountField;
			}
			set
			{
				this.ShippingOptionAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ShippingOptionNameField;
		public string ShippingOptionName
		{
			get
			{
				return this.ShippingOptionNameField;
			}
			set
			{
				this.ShippingOptionNameField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public ShippingOptionType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ShippingOptionIsDefault != null)
			{
				sb.Append("<ebl:ShippingOptionIsDefault>").Append(ShippingOptionIsDefault);
				sb.Append("</ebl:ShippingOptionIsDefault>");
			}
			if(ShippingOptionAmount != null)
			{
				sb.Append("<ebl:ShippingOptionAmount");
				sb.Append(ShippingOptionAmount.toXMLString());
				sb.Append("</ebl:ShippingOptionAmount>");
			}
			if(ShippingOptionName != null)
			{
				sb.Append("<ebl:ShippingOptionName>").Append(ShippingOptionName);
				sb.Append("</ebl:ShippingOptionName>");
			}
			return sb.ToString();
		}
	}




	/**
      *Information on user selected options 
      */
	public partial class UserSelectedOptionType	
	{

		/**
          *No Document Comments
		  */
		private string ShippingCalculationModeField;
		public string ShippingCalculationMode
		{
			get
			{
				return this.ShippingCalculationModeField;
			}
			set
			{
				this.ShippingCalculationModeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string InsuranceOptionSelectedField;
		public string InsuranceOptionSelected
		{
			get
			{
				return this.InsuranceOptionSelectedField;
			}
			set
			{
				this.InsuranceOptionSelectedField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ShippingOptionIsDefaultField;
		public string ShippingOptionIsDefault
		{
			get
			{
				return this.ShippingOptionIsDefaultField;
			}
			set
			{
				this.ShippingOptionIsDefaultField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType ShippingOptionAmountField;
		public BasicAmountType ShippingOptionAmount
		{
			get
			{
				return this.ShippingOptionAmountField;
			}
			set
			{
				this.ShippingOptionAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ShippingOptionNameField;
		public string ShippingOptionName
		{
			get
			{
				return this.ShippingOptionNameField;
			}
			set
			{
				this.ShippingOptionNameField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public UserSelectedOptionType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ShippingCalculationMode != null)
			{
				sb.Append("<ebl:ShippingCalculationMode>").Append(ShippingCalculationMode);
				sb.Append("</ebl:ShippingCalculationMode>");
			}
			if(InsuranceOptionSelected != null)
			{
				sb.Append("<ebl:InsuranceOptionSelected>").Append(InsuranceOptionSelected);
				sb.Append("</ebl:InsuranceOptionSelected>");
			}
			if(ShippingOptionIsDefault != null)
			{
				sb.Append("<ebl:ShippingOptionIsDefault>").Append(ShippingOptionIsDefault);
				sb.Append("</ebl:ShippingOptionIsDefault>");
			}
			if(ShippingOptionAmount != null)
			{
				sb.Append("<ebl:ShippingOptionAmount");
				sb.Append(ShippingOptionAmount.toXMLString());
				sb.Append("</ebl:ShippingOptionAmount>");
			}
			if(ShippingOptionName != null)
			{
				sb.Append("<ebl:ShippingOptionName>").Append(ShippingOptionName);
				sb.Append("</ebl:ShippingOptionName>");
			}
			return sb.ToString();
		}
		public UserSelectedOptionType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("ShippingCalculationMode").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ShippingCalculationMode")[0]))
			{
				this.ShippingCalculationMode = (string)document.GetElementsByTagName("ShippingCalculationMode")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("InsuranceOptionSelected").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("InsuranceOptionSelected")[0]))
			{
				this.InsuranceOptionSelected = (string)document.GetElementsByTagName("InsuranceOptionSelected")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ShippingOptionIsDefault").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ShippingOptionIsDefault")[0]))
			{
				this.ShippingOptionIsDefault = (string)document.GetElementsByTagName("ShippingOptionIsDefault")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("ShippingOptionAmount").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ShippingOptionAmount")[0]))
				{
					nodeList = document.GetElementsByTagName("ShippingOptionAmount");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.ShippingOptionAmount =  new BasicAmountType(xmlString);
				}
			}
		if(document.GetElementsByTagName("ShippingOptionName").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ShippingOptionName")[0]))
			{
				this.ShippingOptionName = (string)document.GetElementsByTagName("ShippingOptionName")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *
      */
	public partial class CreditCardNumberTypeType	
	{

		/**
          *No Document Comments
		  */
		private CreditCardTypeType? CreditCardTypeField;
		public CreditCardTypeType? CreditCardType
		{
			get
			{
				return this.CreditCardTypeField;
			}
			set
			{
				this.CreditCardTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CreditCardNumberField;
		public string CreditCardNumber
		{
			get
			{
				return this.CreditCardNumberField;
			}
			set
			{
				this.CreditCardNumberField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public CreditCardNumberTypeType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(CreditCardType != null)
			{
				sb.Append("<ebl:CreditCardType>").Append(EnumUtils.getDescription(CreditCardType));
				sb.Append("</ebl:CreditCardType>");
			}
			if(CreditCardNumber != null)
			{
				sb.Append("<ebl:CreditCardNumber>").Append(CreditCardNumber);
				sb.Append("</ebl:CreditCardNumber>");
			}
			return sb.ToString();
		}
	}




	/**
      *CreditCardDetailsType for DCC Reference Transaction
      *Information about a Credit Card. 
      */
	public partial class ReferenceCreditCardDetailsType	
	{

		/**
          *No Document Comments
		  */
		private CreditCardNumberTypeType CreditCardNumberTypeField;
		public CreditCardNumberTypeType CreditCardNumberType
		{
			get
			{
				return this.CreditCardNumberTypeField;
			}
			set
			{
				this.CreditCardNumberTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? ExpMonthField;
		public int? ExpMonth
		{
			get
			{
				return this.ExpMonthField;
			}
			set
			{
				this.ExpMonthField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? ExpYearField;
		public int? ExpYear
		{
			get
			{
				return this.ExpYearField;
			}
			set
			{
				this.ExpYearField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PersonNameType CardOwnerNameField;
		public PersonNameType CardOwnerName
		{
			get
			{
				return this.CardOwnerNameField;
			}
			set
			{
				this.CardOwnerNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private AddressType BillingAddressField;
		public AddressType BillingAddress
		{
			get
			{
				return this.BillingAddressField;
			}
			set
			{
				this.BillingAddressField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CVV2Field;
		public string CVV2
		{
			get
			{
				return this.CVV2Field;
			}
			set
			{
				this.CVV2Field = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? StartMonthField;
		public int? StartMonth
		{
			get
			{
				return this.StartMonthField;
			}
			set
			{
				this.StartMonthField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? StartYearField;
		public int? StartYear
		{
			get
			{
				return this.StartYearField;
			}
			set
			{
				this.StartYearField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string IssueNumberField;
		public string IssueNumber
		{
			get
			{
				return this.IssueNumberField;
			}
			set
			{
				this.IssueNumberField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public ReferenceCreditCardDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(CreditCardNumberType != null)
			{
				sb.Append("<ebl:CreditCardNumberType>");
				sb.Append(CreditCardNumberType.toXMLString());
				sb.Append("</ebl:CreditCardNumberType>");
			}
			if(ExpMonth != null)
			{
				sb.Append("<ebl:ExpMonth>").Append(ExpMonth);
				sb.Append("</ebl:ExpMonth>");
			}
			if(ExpYear != null)
			{
				sb.Append("<ebl:ExpYear>").Append(ExpYear);
				sb.Append("</ebl:ExpYear>");
			}
			if(CardOwnerName != null)
			{
				sb.Append("<ebl:CardOwnerName>");
				sb.Append(CardOwnerName.toXMLString());
				sb.Append("</ebl:CardOwnerName>");
			}
			if(BillingAddress != null)
			{
				sb.Append("<ebl:BillingAddress>");
				sb.Append(BillingAddress.toXMLString());
				sb.Append("</ebl:BillingAddress>");
			}
			if(CVV2 != null)
			{
				sb.Append("<ebl:CVV2>").Append(CVV2);
				sb.Append("</ebl:CVV2>");
			}
			if(StartMonth != null)
			{
				sb.Append("<ebl:StartMonth>").Append(StartMonth);
				sb.Append("</ebl:StartMonth>");
			}
			if(StartYear != null)
			{
				sb.Append("<ebl:StartYear>").Append(StartYear);
				sb.Append("</ebl:StartYear>");
			}
			if(IssueNumber != null)
			{
				sb.Append("<ebl:IssueNumber>").Append(IssueNumber);
				sb.Append("</ebl:IssueNumber>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class SetCustomerBillingAgreementRequestDetailsType	
	{

		/**
          *No Document Comments
		  */
		private BillingAgreementDetailsType BillingAgreementDetailsField;
		public BillingAgreementDetailsType BillingAgreementDetails
		{
			get
			{
				return this.BillingAgreementDetailsField;
			}
			set
			{
				this.BillingAgreementDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ReturnURLField;
		public string ReturnURL
		{
			get
			{
				return this.ReturnURLField;
			}
			set
			{
				this.ReturnURLField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CancelURLField;
		public string CancelURL
		{
			get
			{
				return this.CancelURLField;
			}
			set
			{
				this.CancelURLField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string LocaleCodeField;
		public string LocaleCode
		{
			get
			{
				return this.LocaleCodeField;
			}
			set
			{
				this.LocaleCodeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PageStyleField;
		public string PageStyle
		{
			get
			{
				return this.PageStyleField;
			}
			set
			{
				this.PageStyleField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string cppHeaderImageField;
		public string cppHeaderImage
		{
			get
			{
				return this.cppHeaderImageField;
			}
			set
			{
				this.cppHeaderImageField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string cppHeaderBorderColorField;
		public string cppHeaderBorderColor
		{
			get
			{
				return this.cppHeaderBorderColorField;
			}
			set
			{
				this.cppHeaderBorderColorField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string cppHeaderBackColorField;
		public string cppHeaderBackColor
		{
			get
			{
				return this.cppHeaderBackColorField;
			}
			set
			{
				this.cppHeaderBackColorField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string cppPayflowColorField;
		public string cppPayflowColor
		{
			get
			{
				return this.cppPayflowColorField;
			}
			set
			{
				this.cppPayflowColorField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string BuyerEmailField;
		public string BuyerEmail
		{
			get
			{
				return this.BuyerEmailField;
			}
			set
			{
				this.BuyerEmailField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ReqBillingAddressField;
		public string ReqBillingAddress
		{
			get
			{
				return this.ReqBillingAddressField;
			}
			set
			{
				this.ReqBillingAddressField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public SetCustomerBillingAgreementRequestDetailsType(BillingAgreementDetailsType BillingAgreementDetails, string ReturnURL, string CancelURL){
			this.BillingAgreementDetails = BillingAgreementDetails;
			this.ReturnURL = ReturnURL;
			this.CancelURL = CancelURL;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public SetCustomerBillingAgreementRequestDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(BillingAgreementDetails != null)
			{
				sb.Append("<ebl:BillingAgreementDetails>");
				sb.Append(BillingAgreementDetails.toXMLString());
				sb.Append("</ebl:BillingAgreementDetails>");
			}
			if(ReturnURL != null)
			{
				sb.Append("<ebl:ReturnURL>").Append(ReturnURL);
				sb.Append("</ebl:ReturnURL>");
			}
			if(CancelURL != null)
			{
				sb.Append("<ebl:CancelURL>").Append(CancelURL);
				sb.Append("</ebl:CancelURL>");
			}
			if(LocaleCode != null)
			{
				sb.Append("<ebl:LocaleCode>").Append(LocaleCode);
				sb.Append("</ebl:LocaleCode>");
			}
			if(PageStyle != null)
			{
				sb.Append("<ebl:PageStyle>").Append(PageStyle);
				sb.Append("</ebl:PageStyle>");
			}
			if(cppHeaderImage != null)
			{
				sb.Append("<ebl:cpp-header-image>").Append(cppHeaderImage);
				sb.Append("</ebl:cpp-header-image>");
			}
			if(cppHeaderBorderColor != null)
			{
				sb.Append("<ebl:cpp-header-border-color>").Append(cppHeaderBorderColor);
				sb.Append("</ebl:cpp-header-border-color>");
			}
			if(cppHeaderBackColor != null)
			{
				sb.Append("<ebl:cpp-header-back-color>").Append(cppHeaderBackColor);
				sb.Append("</ebl:cpp-header-back-color>");
			}
			if(cppPayflowColor != null)
			{
				sb.Append("<ebl:cpp-payflow-color>").Append(cppPayflowColor);
				sb.Append("</ebl:cpp-payflow-color>");
			}
			if(BuyerEmail != null)
			{
				sb.Append("<ebl:BuyerEmail>").Append(BuyerEmail);
				sb.Append("</ebl:BuyerEmail>");
			}
			if(ReqBillingAddress != null)
			{
				sb.Append("<ebl:ReqBillingAddress>").Append(ReqBillingAddress);
				sb.Append("</ebl:ReqBillingAddress>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class GetBillingAgreementCustomerDetailsResponseDetailsType	
	{

		/**
          *No Document Comments
		  */
		private PayerInfoType PayerInfoField;
		public PayerInfoType PayerInfo
		{
			get
			{
				return this.PayerInfoField;
			}
			set
			{
				this.PayerInfoField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private AddressType BillingAddressField;
		public AddressType BillingAddress
		{
			get
			{
				return this.BillingAddressField;
			}
			set
			{
				this.BillingAddressField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public GetBillingAgreementCustomerDetailsResponseDetailsType(){
		}


		public GetBillingAgreementCustomerDetailsResponseDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("PayerInfo").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PayerInfo")[0]))
				{
					nodeList = document.GetElementsByTagName("PayerInfo");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.PayerInfo =  new PayerInfoType(xmlString);
				}
			}
			if(document.GetElementsByTagName("BillingAddress").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillingAddress")[0]))
				{
					nodeList = document.GetElementsByTagName("BillingAddress");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.BillingAddress =  new AddressType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *Device ID Optional  Character length and limits: 256
      *single-byte characters DeviceID length morethan 256 is
      *truncated  
      */
	public partial class DeviceDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string DeviceIDField;
		public string DeviceID
		{
			get
			{
				return this.DeviceIDField;
			}
			set
			{
				this.DeviceIDField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DeviceDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(DeviceID != null)
			{
				sb.Append("<ebl:DeviceID>").Append(DeviceID);
				sb.Append("</ebl:DeviceID>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class SenderDetailsType	
	{

		/**
          *No Document Comments
		  */
		private DeviceDetailsType DeviceDetailsField;
		public DeviceDetailsType DeviceDetails
		{
			get
			{
				return this.DeviceDetailsField;
			}
			set
			{
				this.DeviceDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public SenderDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(DeviceDetails != null)
			{
				sb.Append("<ebl:DeviceDetails>");
				sb.Append(DeviceDetails.toXMLString());
				sb.Append("</ebl:DeviceDetails>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class DoReferenceTransactionRequestDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string ReferenceIDField;
		public string ReferenceID
		{
			get
			{
				return this.ReferenceIDField;
			}
			set
			{
				this.ReferenceIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PaymentActionCodeType? PaymentActionField;
		public PaymentActionCodeType? PaymentAction
		{
			get
			{
				return this.PaymentActionField;
			}
			set
			{
				this.PaymentActionField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private MerchantPullPaymentCodeType? PaymentTypeField;
		public MerchantPullPaymentCodeType? PaymentType
		{
			get
			{
				return this.PaymentTypeField;
			}
			set
			{
				this.PaymentTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PaymentDetailsType PaymentDetailsField;
		public PaymentDetailsType PaymentDetails
		{
			get
			{
				return this.PaymentDetailsField;
			}
			set
			{
				this.PaymentDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ReferenceCreditCardDetailsType CreditCardField;
		public ReferenceCreditCardDetailsType CreditCard
		{
			get
			{
				return this.CreditCardField;
			}
			set
			{
				this.CreditCardField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string IPAddressField;
		public string IPAddress
		{
			get
			{
				return this.IPAddressField;
			}
			set
			{
				this.IPAddressField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string MerchantSessionIdField;
		public string MerchantSessionId
		{
			get
			{
				return this.MerchantSessionIdField;
			}
			set
			{
				this.MerchantSessionIdField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ReqConfirmShippingField;
		public string ReqConfirmShipping
		{
			get
			{
				return this.ReqConfirmShippingField;
			}
			set
			{
				this.ReqConfirmShippingField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string SoftDescriptorField;
		public string SoftDescriptor
		{
			get
			{
				return this.SoftDescriptorField;
			}
			set
			{
				this.SoftDescriptorField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private SenderDetailsType SenderDetailsField;
		public SenderDetailsType SenderDetails
		{
			get
			{
				return this.SenderDetailsField;
			}
			set
			{
				this.SenderDetailsField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public DoReferenceTransactionRequestDetailsType(string ReferenceID, PaymentActionCodeType? PaymentAction, PaymentDetailsType PaymentDetails){
			this.ReferenceID = ReferenceID;
			this.PaymentAction = PaymentAction;
			this.PaymentDetails = PaymentDetails;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public DoReferenceTransactionRequestDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ReferenceID != null)
			{
				sb.Append("<ebl:ReferenceID>").Append(ReferenceID);
				sb.Append("</ebl:ReferenceID>");
			}
			if(PaymentAction != null)
			{
				sb.Append("<ebl:PaymentAction>").Append(EnumUtils.getDescription(PaymentAction));
				sb.Append("</ebl:PaymentAction>");
			}
			if(PaymentType != null)
			{
				sb.Append("<ebl:PaymentType>").Append(EnumUtils.getDescription(PaymentType));
				sb.Append("</ebl:PaymentType>");
			}
			if(PaymentDetails != null)
			{
				sb.Append("<ebl:PaymentDetails>");
				sb.Append(PaymentDetails.toXMLString());
				sb.Append("</ebl:PaymentDetails>");
			}
			if(CreditCard != null)
			{
				sb.Append("<ebl:CreditCard>");
				sb.Append(CreditCard.toXMLString());
				sb.Append("</ebl:CreditCard>");
			}
			if(IPAddress != null)
			{
				sb.Append("<ebl:IPAddress>").Append(IPAddress);
				sb.Append("</ebl:IPAddress>");
			}
			if(MerchantSessionId != null)
			{
				sb.Append("<ebl:MerchantSessionId>").Append(MerchantSessionId);
				sb.Append("</ebl:MerchantSessionId>");
			}
			if(ReqConfirmShipping != null)
			{
				sb.Append("<ebl:ReqConfirmShipping>").Append(ReqConfirmShipping);
				sb.Append("</ebl:ReqConfirmShipping>");
			}
			if(SoftDescriptor != null)
			{
				sb.Append("<ebl:SoftDescriptor>").Append(SoftDescriptor);
				sb.Append("</ebl:SoftDescriptor>");
			}
			if(SenderDetails != null)
			{
				sb.Append("<ebl:SenderDetails>");
				sb.Append(SenderDetails.toXMLString());
				sb.Append("</ebl:SenderDetails>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class DoReferenceTransactionResponseDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string BillingAgreementIDField;
		public string BillingAgreementID
		{
			get
			{
				return this.BillingAgreementIDField;
			}
			set
			{
				this.BillingAgreementIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PaymentInfoType PaymentInfoField;
		public PaymentInfoType PaymentInfo
		{
			get
			{
				return this.PaymentInfoField;
			}
			set
			{
				this.PaymentInfoField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType AmountField;
		public BasicAmountType Amount
		{
			get
			{
				return this.AmountField;
			}
			set
			{
				this.AmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string AVSCodeField;
		public string AVSCode
		{
			get
			{
				return this.AVSCodeField;
			}
			set
			{
				this.AVSCodeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CVV2CodeField;
		public string CVV2Code
		{
			get
			{
				return this.CVV2CodeField;
			}
			set
			{
				this.CVV2CodeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string TransactionIDField;
		public string TransactionID
		{
			get
			{
				return this.TransactionIDField;
			}
			set
			{
				this.TransactionIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PaymentAdviceCodeField;
		public string PaymentAdviceCode
		{
			get
			{
				return this.PaymentAdviceCodeField;
			}
			set
			{
				this.PaymentAdviceCodeField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DoReferenceTransactionResponseDetailsType(){
		}


		public DoReferenceTransactionResponseDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("BillingAgreementID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillingAgreementID")[0]))
			{
				this.BillingAgreementID = (string)document.GetElementsByTagName("BillingAgreementID")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("PaymentInfo").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentInfo")[0]))
				{
					nodeList = document.GetElementsByTagName("PaymentInfo");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.PaymentInfo =  new PaymentInfoType(xmlString);
				}
			}
			if(document.GetElementsByTagName("Amount").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Amount")[0]))
				{
					nodeList = document.GetElementsByTagName("Amount");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.Amount =  new BasicAmountType(xmlString);
				}
			}
		if(document.GetElementsByTagName("AVSCode").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AVSCode")[0]))
			{
				this.AVSCode = (string)document.GetElementsByTagName("AVSCode")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("CVV2Code").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CVV2Code")[0]))
			{
				this.CVV2Code = (string)document.GetElementsByTagName("CVV2Code")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("TransactionID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TransactionID")[0]))
			{
				this.TransactionID = (string)document.GetElementsByTagName("TransactionID")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("PaymentAdviceCode").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentAdviceCode")[0]))
			{
				this.PaymentAdviceCode = (string)document.GetElementsByTagName("PaymentAdviceCode")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *
      */
	public partial class DoNonReferencedCreditRequestDetailsType	
	{

		/**
          *No Document Comments
		  */
		private BasicAmountType AmountField;
		public BasicAmountType Amount
		{
			get
			{
				return this.AmountField;
			}
			set
			{
				this.AmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType NetAmountField;
		public BasicAmountType NetAmount
		{
			get
			{
				return this.NetAmountField;
			}
			set
			{
				this.NetAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType TaxAmountField;
		public BasicAmountType TaxAmount
		{
			get
			{
				return this.TaxAmountField;
			}
			set
			{
				this.TaxAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType ShippingAmountField;
		public BasicAmountType ShippingAmount
		{
			get
			{
				return this.ShippingAmountField;
			}
			set
			{
				this.ShippingAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private CreditCardDetailsType CreditCardField;
		public CreditCardDetailsType CreditCard
		{
			get
			{
				return this.CreditCardField;
			}
			set
			{
				this.CreditCardField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ReceiverEmailField;
		public string ReceiverEmail
		{
			get
			{
				return this.ReceiverEmailField;
			}
			set
			{
				this.ReceiverEmailField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CommentField;
		public string Comment
		{
			get
			{
				return this.CommentField;
			}
			set
			{
				this.CommentField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DoNonReferencedCreditRequestDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Amount != null)
			{
				sb.Append("<ebl:Amount");
				sb.Append(Amount.toXMLString());
				sb.Append("</ebl:Amount>");
			}
			if(NetAmount != null)
			{
				sb.Append("<ebl:NetAmount");
				sb.Append(NetAmount.toXMLString());
				sb.Append("</ebl:NetAmount>");
			}
			if(TaxAmount != null)
			{
				sb.Append("<ebl:TaxAmount");
				sb.Append(TaxAmount.toXMLString());
				sb.Append("</ebl:TaxAmount>");
			}
			if(ShippingAmount != null)
			{
				sb.Append("<ebl:ShippingAmount");
				sb.Append(ShippingAmount.toXMLString());
				sb.Append("</ebl:ShippingAmount>");
			}
			if(CreditCard != null)
			{
				sb.Append("<ebl:CreditCard>");
				sb.Append(CreditCard.toXMLString());
				sb.Append("</ebl:CreditCard>");
			}
			if(ReceiverEmail != null)
			{
				sb.Append("<ebl:ReceiverEmail>").Append(ReceiverEmail);
				sb.Append("</ebl:ReceiverEmail>");
			}
			if(Comment != null)
			{
				sb.Append("<ebl:Comment>").Append(Comment);
				sb.Append("</ebl:Comment>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class DoNonReferencedCreditResponseDetailsType	
	{

		/**
          *No Document Comments
		  */
		private BasicAmountType AmountField;
		public BasicAmountType Amount
		{
			get
			{
				return this.AmountField;
			}
			set
			{
				this.AmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string TransactionIDField;
		public string TransactionID
		{
			get
			{
				return this.TransactionIDField;
			}
			set
			{
				this.TransactionIDField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DoNonReferencedCreditResponseDetailsType(){
		}


		public DoNonReferencedCreditResponseDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("Amount").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Amount")[0]))
				{
					nodeList = document.GetElementsByTagName("Amount");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.Amount =  new BasicAmountType(xmlString);
				}
			}
		if(document.GetElementsByTagName("TransactionID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TransactionID")[0]))
			{
				this.TransactionID = (string)document.GetElementsByTagName("TransactionID")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *Onboarding program code given to you by PayPal. Required
      *Character length and limitations: 64 alphanumeric characters
      *
      */
	public partial class EnterBoardingRequestDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string ProgramCodeField;
		public string ProgramCode
		{
			get
			{
				return this.ProgramCodeField;
			}
			set
			{
				this.ProgramCodeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ProductListField;
		public string ProductList
		{
			get
			{
				return this.ProductListField;
			}
			set
			{
				this.ProductListField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PartnerCustomField;
		public string PartnerCustom
		{
			get
			{
				return this.PartnerCustomField;
			}
			set
			{
				this.PartnerCustomField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ImageUrlField;
		public string ImageUrl
		{
			get
			{
				return this.ImageUrlField;
			}
			set
			{
				this.ImageUrlField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private MarketingCategoryType? MarketingCategoryField;
		public MarketingCategoryType? MarketingCategory
		{
			get
			{
				return this.MarketingCategoryField;
			}
			set
			{
				this.MarketingCategoryField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BusinessInfoType BusinessInfoField;
		public BusinessInfoType BusinessInfo
		{
			get
			{
				return this.BusinessInfoField;
			}
			set
			{
				this.BusinessInfoField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BusinessOwnerInfoType OwnerInfoField;
		public BusinessOwnerInfoType OwnerInfo
		{
			get
			{
				return this.OwnerInfoField;
			}
			set
			{
				this.OwnerInfoField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BankAccountDetailsType BankAccountField;
		public BankAccountDetailsType BankAccount
		{
			get
			{
				return this.BankAccountField;
			}
			set
			{
				this.BankAccountField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public EnterBoardingRequestDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ProgramCode != null)
			{
				sb.Append("<ebl:ProgramCode>").Append(ProgramCode);
				sb.Append("</ebl:ProgramCode>");
			}
			if(ProductList != null)
			{
				sb.Append("<ebl:ProductList>").Append(ProductList);
				sb.Append("</ebl:ProductList>");
			}
			if(PartnerCustom != null)
			{
				sb.Append("<ebl:PartnerCustom>").Append(PartnerCustom);
				sb.Append("</ebl:PartnerCustom>");
			}
			if(ImageUrl != null)
			{
				sb.Append("<ebl:ImageUrl>").Append(ImageUrl);
				sb.Append("</ebl:ImageUrl>");
			}
			if(MarketingCategory != null)
			{
				sb.Append("<ebl:MarketingCategory>").Append(EnumUtils.getDescription(MarketingCategory));
				sb.Append("</ebl:MarketingCategory>");
			}
			if(BusinessInfo != null)
			{
				sb.Append("<ebl:BusinessInfo>");
				sb.Append(BusinessInfo.toXMLString());
				sb.Append("</ebl:BusinessInfo>");
			}
			if(OwnerInfo != null)
			{
				sb.Append("<ebl:OwnerInfo>");
				sb.Append(OwnerInfo.toXMLString());
				sb.Append("</ebl:OwnerInfo>");
			}
			if(BankAccount != null)
			{
				sb.Append("<ebl:BankAccount>");
				sb.Append(BankAccount.toXMLString());
				sb.Append("</ebl:BankAccount>");
			}
			return sb.ToString();
		}
	}




	/**
      *BusinessInfoType 
      */
	public partial class BusinessInfoType	
	{

		/**
          *No Document Comments
		  */
		private BusinessTypeType? TypeField;
		public BusinessTypeType? Type
		{
			get
			{
				return this.TypeField;
			}
			set
			{
				this.TypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string NameField;
		public string Name
		{
			get
			{
				return this.NameField;
			}
			set
			{
				this.NameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private AddressType AddressField;
		public AddressType Address
		{
			get
			{
				return this.AddressField;
			}
			set
			{
				this.AddressField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string WorkPhoneField;
		public string WorkPhone
		{
			get
			{
				return this.WorkPhoneField;
			}
			set
			{
				this.WorkPhoneField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BusinessCategoryType? CategoryField;
		public BusinessCategoryType? Category
		{
			get
			{
				return this.CategoryField;
			}
			set
			{
				this.CategoryField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BusinessSubCategoryType? SubCategoryField;
		public BusinessSubCategoryType? SubCategory
		{
			get
			{
				return this.SubCategoryField;
			}
			set
			{
				this.SubCategoryField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private AverageTransactionPriceType? AveragePriceField;
		public AverageTransactionPriceType? AveragePrice
		{
			get
			{
				return this.AveragePriceField;
			}
			set
			{
				this.AveragePriceField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private AverageMonthlyVolumeType? AverageMonthlyVolumeField;
		public AverageMonthlyVolumeType? AverageMonthlyVolume
		{
			get
			{
				return this.AverageMonthlyVolumeField;
			}
			set
			{
				this.AverageMonthlyVolumeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private SalesVenueType? SalesVenueField;
		public SalesVenueType? SalesVenue
		{
			get
			{
				return this.SalesVenueField;
			}
			set
			{
				this.SalesVenueField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string WebsiteField;
		public string Website
		{
			get
			{
				return this.WebsiteField;
			}
			set
			{
				this.WebsiteField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PercentageRevenueFromOnlineSalesType? RevenueFromOnlineSalesField;
		public PercentageRevenueFromOnlineSalesType? RevenueFromOnlineSales
		{
			get
			{
				return this.RevenueFromOnlineSalesField;
			}
			set
			{
				this.RevenueFromOnlineSalesField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string BusinessEstablishedField;
		public string BusinessEstablished
		{
			get
			{
				return this.BusinessEstablishedField;
			}
			set
			{
				this.BusinessEstablishedField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CustomerServiceEmailField;
		public string CustomerServiceEmail
		{
			get
			{
				return this.CustomerServiceEmailField;
			}
			set
			{
				this.CustomerServiceEmailField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CustomerServicePhoneField;
		public string CustomerServicePhone
		{
			get
			{
				return this.CustomerServicePhoneField;
			}
			set
			{
				this.CustomerServicePhoneField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public BusinessInfoType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Type != null)
			{
				sb.Append("<ebl:Type>").Append(EnumUtils.getDescription(Type));
				sb.Append("</ebl:Type>");
			}
			if(Name != null)
			{
				sb.Append("<ebl:Name>").Append(Name);
				sb.Append("</ebl:Name>");
			}
			if(Address != null)
			{
				sb.Append("<ebl:Address>");
				sb.Append(Address.toXMLString());
				sb.Append("</ebl:Address>");
			}
			if(WorkPhone != null)
			{
				sb.Append("<ebl:WorkPhone>").Append(WorkPhone);
				sb.Append("</ebl:WorkPhone>");
			}
			if(Category != null)
			{
				sb.Append("<ebl:Category>").Append(EnumUtils.getDescription(Category));
				sb.Append("</ebl:Category>");
			}
			if(SubCategory != null)
			{
				sb.Append("<ebl:SubCategory>").Append(EnumUtils.getDescription(SubCategory));
				sb.Append("</ebl:SubCategory>");
			}
			if(AveragePrice != null)
			{
				sb.Append("<ebl:AveragePrice>").Append(EnumUtils.getDescription(AveragePrice));
				sb.Append("</ebl:AveragePrice>");
			}
			if(AverageMonthlyVolume != null)
			{
				sb.Append("<ebl:AverageMonthlyVolume>").Append(EnumUtils.getDescription(AverageMonthlyVolume));
				sb.Append("</ebl:AverageMonthlyVolume>");
			}
			if(SalesVenue != null)
			{
				sb.Append("<ebl:SalesVenue>").Append(EnumUtils.getDescription(SalesVenue));
				sb.Append("</ebl:SalesVenue>");
			}
			if(Website != null)
			{
				sb.Append("<ebl:Website>").Append(Website);
				sb.Append("</ebl:Website>");
			}
			if(RevenueFromOnlineSales != null)
			{
				sb.Append("<ebl:RevenueFromOnlineSales>").Append(EnumUtils.getDescription(RevenueFromOnlineSales));
				sb.Append("</ebl:RevenueFromOnlineSales>");
			}
			if(BusinessEstablished != null)
			{
				sb.Append("<ebl:BusinessEstablished>").Append(BusinessEstablished);
				sb.Append("</ebl:BusinessEstablished>");
			}
			if(CustomerServiceEmail != null)
			{
				sb.Append("<ebl:CustomerServiceEmail>").Append(CustomerServiceEmail);
				sb.Append("</ebl:CustomerServiceEmail>");
			}
			if(CustomerServicePhone != null)
			{
				sb.Append("<ebl:CustomerServicePhone>").Append(CustomerServicePhone);
				sb.Append("</ebl:CustomerServicePhone>");
			}
			return sb.ToString();
		}
	}




	/**
      *BusinessOwnerInfoType 
      */
	public partial class BusinessOwnerInfoType	
	{

		/**
          *No Document Comments
		  */
		private PayerInfoType OwnerField;
		public PayerInfoType Owner
		{
			get
			{
				return this.OwnerField;
			}
			set
			{
				this.OwnerField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string HomePhoneField;
		public string HomePhone
		{
			get
			{
				return this.HomePhoneField;
			}
			set
			{
				this.HomePhoneField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string MobilePhoneField;
		public string MobilePhone
		{
			get
			{
				return this.MobilePhoneField;
			}
			set
			{
				this.MobilePhoneField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string SSNField;
		public string SSN
		{
			get
			{
				return this.SSNField;
			}
			set
			{
				this.SSNField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public BusinessOwnerInfoType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Owner != null)
			{
				sb.Append("<ebl:Owner>");
				sb.Append(Owner.toXMLString());
				sb.Append("</ebl:Owner>");
			}
			if(HomePhone != null)
			{
				sb.Append("<ebl:HomePhone>").Append(HomePhone);
				sb.Append("</ebl:HomePhone>");
			}
			if(MobilePhone != null)
			{
				sb.Append("<ebl:MobilePhone>").Append(MobilePhone);
				sb.Append("</ebl:MobilePhone>");
			}
			if(SSN != null)
			{
				sb.Append("<ebl:SSN>").Append(SSN);
				sb.Append("</ebl:SSN>");
			}
			return sb.ToString();
		}
	}




	/**
      *BankAccountDetailsType 
      */
	public partial class BankAccountDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string NameField;
		public string Name
		{
			get
			{
				return this.NameField;
			}
			set
			{
				this.NameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BankAccountTypeType? TypeField;
		public BankAccountTypeType? Type
		{
			get
			{
				return this.TypeField;
			}
			set
			{
				this.TypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string RoutingNumberField;
		public string RoutingNumber
		{
			get
			{
				return this.RoutingNumberField;
			}
			set
			{
				this.RoutingNumberField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string AccountNumberField;
		public string AccountNumber
		{
			get
			{
				return this.AccountNumberField;
			}
			set
			{
				this.AccountNumberField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public BankAccountDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Name != null)
			{
				sb.Append("<ebl:Name>").Append(Name);
				sb.Append("</ebl:Name>");
			}
			if(Type != null)
			{
				sb.Append("<ebl:Type>").Append(EnumUtils.getDescription(Type));
				sb.Append("</ebl:Type>");
			}
			if(RoutingNumber != null)
			{
				sb.Append("<ebl:RoutingNumber>").Append(RoutingNumber);
				sb.Append("</ebl:RoutingNumber>");
			}
			if(AccountNumber != null)
			{
				sb.Append("<ebl:AccountNumber>").Append(AccountNumber);
				sb.Append("</ebl:AccountNumber>");
			}
			return sb.ToString();
		}
	}




	/**
      *Status of merchant's onboarding process:
      *CompletedCancelledPending Character length and limitations:
      *Eight alphabetic characters 
      */
	public partial class GetBoardingDetailsResponseDetailsType	
	{

		/**
          *No Document Comments
		  */
		private BoardingStatusType? StatusField;
		public BoardingStatusType? Status
		{
			get
			{
				return this.StatusField;
			}
			set
			{
				this.StatusField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string StartDateField;
		public string StartDate
		{
			get
			{
				return this.StartDateField;
			}
			set
			{
				this.StartDateField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string LastUpdatedField;
		public string LastUpdated
		{
			get
			{
				return this.LastUpdatedField;
			}
			set
			{
				this.LastUpdatedField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ReasonField;
		public string Reason
		{
			get
			{
				return this.ReasonField;
			}
			set
			{
				this.ReasonField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ProgramNameField;
		public string ProgramName
		{
			get
			{
				return this.ProgramNameField;
			}
			set
			{
				this.ProgramNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ProgramCodeField;
		public string ProgramCode
		{
			get
			{
				return this.ProgramCodeField;
			}
			set
			{
				this.ProgramCodeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CampaignIDField;
		public string CampaignID
		{
			get
			{
				return this.CampaignIDField;
			}
			set
			{
				this.CampaignIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private UserWithdrawalLimitTypeType? UserWithdrawalLimitField;
		public UserWithdrawalLimitTypeType? UserWithdrawalLimit
		{
			get
			{
				return this.UserWithdrawalLimitField;
			}
			set
			{
				this.UserWithdrawalLimitField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PartnerCustomField;
		public string PartnerCustom
		{
			get
			{
				return this.PartnerCustomField;
			}
			set
			{
				this.PartnerCustomField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PayerInfoType AccountOwnerField;
		public PayerInfoType AccountOwner
		{
			get
			{
				return this.AccountOwnerField;
			}
			set
			{
				this.AccountOwnerField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private APICredentialsType CredentialsField;
		public APICredentialsType Credentials
		{
			get
			{
				return this.CredentialsField;
			}
			set
			{
				this.CredentialsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ConfigureAPIsField;
		public string ConfigureAPIs
		{
			get
			{
				return this.ConfigureAPIsField;
			}
			set
			{
				this.ConfigureAPIsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string EmailVerificationStatusField;
		public string EmailVerificationStatus
		{
			get
			{
				return this.EmailVerificationStatusField;
			}
			set
			{
				this.EmailVerificationStatusField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string VettingStatusField;
		public string VettingStatus
		{
			get
			{
				return this.VettingStatusField;
			}
			set
			{
				this.VettingStatusField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string BankAccountVerificationStatusField;
		public string BankAccountVerificationStatus
		{
			get
			{
				return this.BankAccountVerificationStatusField;
			}
			set
			{
				this.BankAccountVerificationStatusField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public GetBoardingDetailsResponseDetailsType(){
		}


		public GetBoardingDetailsResponseDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("Status").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Status")[0]))
				{
					this.Status = (BoardingStatusType)EnumUtils.getValue(document.GetElementsByTagName("Status")[0].InnerText,typeof(BoardingStatusType));
				}
			}
		if(document.GetElementsByTagName("StartDate").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("StartDate")[0]))
			{
				this.StartDate = (string)document.GetElementsByTagName("StartDate")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("LastUpdated").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("LastUpdated")[0]))
			{
				this.LastUpdated = (string)document.GetElementsByTagName("LastUpdated")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Reason").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Reason")[0]))
			{
				this.Reason = (string)document.GetElementsByTagName("Reason")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ProgramName").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ProgramName")[0]))
			{
				this.ProgramName = (string)document.GetElementsByTagName("ProgramName")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ProgramCode").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ProgramCode")[0]))
			{
				this.ProgramCode = (string)document.GetElementsByTagName("ProgramCode")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("CampaignID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CampaignID")[0]))
			{
				this.CampaignID = (string)document.GetElementsByTagName("CampaignID")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("UserWithdrawalLimit").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("UserWithdrawalLimit")[0]))
				{
					this.UserWithdrawalLimit = (UserWithdrawalLimitTypeType)EnumUtils.getValue(document.GetElementsByTagName("UserWithdrawalLimit")[0].InnerText,typeof(UserWithdrawalLimitTypeType));
				}
			}
		if(document.GetElementsByTagName("PartnerCustom").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PartnerCustom")[0]))
			{
				this.PartnerCustom = (string)document.GetElementsByTagName("PartnerCustom")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("AccountOwner").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AccountOwner")[0]))
				{
					nodeList = document.GetElementsByTagName("AccountOwner");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.AccountOwner =  new PayerInfoType(xmlString);
				}
			}
			if(document.GetElementsByTagName("Credentials").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Credentials")[0]))
				{
					nodeList = document.GetElementsByTagName("Credentials");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.Credentials =  new APICredentialsType(xmlString);
				}
			}
		if(document.GetElementsByTagName("ConfigureAPIs").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ConfigureAPIs")[0]))
			{
				this.ConfigureAPIs = (string)document.GetElementsByTagName("ConfigureAPIs")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("EmailVerificationStatus").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("EmailVerificationStatus")[0]))
			{
				this.EmailVerificationStatus = (string)document.GetElementsByTagName("EmailVerificationStatus")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("VettingStatus").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("VettingStatus")[0]))
			{
				this.VettingStatus = (string)document.GetElementsByTagName("VettingStatus")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("BankAccountVerificationStatus").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BankAccountVerificationStatus")[0]))
			{
				this.BankAccountVerificationStatus = (string)document.GetElementsByTagName("BankAccountVerificationStatus")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *APICredentialsType 
      */
	public partial class APICredentialsType	
	{

		/**
          *No Document Comments
		  */
		private string UsernameField;
		public string Username
		{
			get
			{
				return this.UsernameField;
			}
			set
			{
				this.UsernameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PasswordField;
		public string Password
		{
			get
			{
				return this.PasswordField;
			}
			set
			{
				this.PasswordField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string SignatureField;
		public string Signature
		{
			get
			{
				return this.SignatureField;
			}
			set
			{
				this.SignatureField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CertificateField;
		public string Certificate
		{
			get
			{
				return this.CertificateField;
			}
			set
			{
				this.CertificateField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private APIAuthenticationType? TypeField;
		public APIAuthenticationType? Type
		{
			get
			{
				return this.TypeField;
			}
			set
			{
				this.TypeField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public APICredentialsType(){
		}


		public APICredentialsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("Username").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Username")[0]))
			{
				this.Username = (string)document.GetElementsByTagName("Username")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Password").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Password")[0]))
			{
				this.Password = (string)document.GetElementsByTagName("Password")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Signature").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Signature")[0]))
			{
				this.Signature = (string)document.GetElementsByTagName("Signature")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Certificate").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Certificate")[0]))
			{
				this.Certificate = (string)document.GetElementsByTagName("Certificate")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("Type").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Type")[0]))
				{
					this.Type = (APIAuthenticationType)EnumUtils.getValue(document.GetElementsByTagName("Type")[0].InnerText,typeof(APIAuthenticationType));
				}
			}
	
		}
		
	}




	/**
      *The phone number of the buyer's mobile device, if available.
      *Optional 
      */
	public partial class SetMobileCheckoutRequestDetailsType	
	{

		/**
          *No Document Comments
		  */
		private PhoneNumberType BuyerPhoneField;
		public PhoneNumberType BuyerPhone
		{
			get
			{
				return this.BuyerPhoneField;
			}
			set
			{
				this.BuyerPhoneField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType ItemAmountField;
		public BasicAmountType ItemAmount
		{
			get
			{
				return this.ItemAmountField;
			}
			set
			{
				this.ItemAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType TaxField;
		public BasicAmountType Tax
		{
			get
			{
				return this.TaxField;
			}
			set
			{
				this.TaxField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType ShippingField;
		public BasicAmountType Shipping
		{
			get
			{
				return this.ShippingField;
			}
			set
			{
				this.ShippingField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ItemNameField;
		public string ItemName
		{
			get
			{
				return this.ItemNameField;
			}
			set
			{
				this.ItemNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ItemNumberField;
		public string ItemNumber
		{
			get
			{
				return this.ItemNumberField;
			}
			set
			{
				this.ItemNumberField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CustomField;
		public string Custom
		{
			get
			{
				return this.CustomField;
			}
			set
			{
				this.CustomField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string InvoiceIDField;
		public string InvoiceID
		{
			get
			{
				return this.InvoiceIDField;
			}
			set
			{
				this.InvoiceIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ReturnURLField;
		public string ReturnURL
		{
			get
			{
				return this.ReturnURLField;
			}
			set
			{
				this.ReturnURLField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CancelURLField;
		public string CancelURL
		{
			get
			{
				return this.CancelURLField;
			}
			set
			{
				this.CancelURLField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? AddressDisplayOptionsField;
		public int? AddressDisplayOptions
		{
			get
			{
				return this.AddressDisplayOptionsField;
			}
			set
			{
				this.AddressDisplayOptionsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? SharePhoneField;
		public int? SharePhone
		{
			get
			{
				return this.SharePhoneField;
			}
			set
			{
				this.SharePhoneField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private AddressType ShipToAddressField;
		public AddressType ShipToAddress
		{
			get
			{
				return this.ShipToAddressField;
			}
			set
			{
				this.ShipToAddressField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string BuyerEmailField;
		public string BuyerEmail
		{
			get
			{
				return this.BuyerEmailField;
			}
			set
			{
				this.BuyerEmailField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public SetMobileCheckoutRequestDetailsType(BasicAmountType ItemAmount, string ItemName, string ReturnURL){
			this.ItemAmount = ItemAmount;
			this.ItemName = ItemName;
			this.ReturnURL = ReturnURL;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public SetMobileCheckoutRequestDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(BuyerPhone != null)
			{
				sb.Append("<ebl:BuyerPhone>");
				sb.Append(BuyerPhone.toXMLString());
				sb.Append("</ebl:BuyerPhone>");
			}
			if(ItemAmount != null)
			{
				sb.Append("<ebl:ItemAmount");
				sb.Append(ItemAmount.toXMLString());
				sb.Append("</ebl:ItemAmount>");
			}
			if(Tax != null)
			{
				sb.Append("<ebl:Tax");
				sb.Append(Tax.toXMLString());
				sb.Append("</ebl:Tax>");
			}
			if(Shipping != null)
			{
				sb.Append("<ebl:Shipping");
				sb.Append(Shipping.toXMLString());
				sb.Append("</ebl:Shipping>");
			}
			if(ItemName != null)
			{
				sb.Append("<ebl:ItemName>").Append(ItemName);
				sb.Append("</ebl:ItemName>");
			}
			if(ItemNumber != null)
			{
				sb.Append("<ebl:ItemNumber>").Append(ItemNumber);
				sb.Append("</ebl:ItemNumber>");
			}
			if(Custom != null)
			{
				sb.Append("<ebl:Custom>").Append(Custom);
				sb.Append("</ebl:Custom>");
			}
			if(InvoiceID != null)
			{
				sb.Append("<ebl:InvoiceID>").Append(InvoiceID);
				sb.Append("</ebl:InvoiceID>");
			}
			if(ReturnURL != null)
			{
				sb.Append("<ebl:ReturnURL>").Append(ReturnURL);
				sb.Append("</ebl:ReturnURL>");
			}
			if(CancelURL != null)
			{
				sb.Append("<ebl:CancelURL>").Append(CancelURL);
				sb.Append("</ebl:CancelURL>");
			}
			if(AddressDisplayOptions != null)
			{
				sb.Append("<ebl:AddressDisplayOptions>").Append(AddressDisplayOptions);
				sb.Append("</ebl:AddressDisplayOptions>");
			}
			if(SharePhone != null)
			{
				sb.Append("<ebl:SharePhone>").Append(SharePhone);
				sb.Append("</ebl:SharePhone>");
			}
			if(ShipToAddress != null)
			{
				sb.Append("<ebl:ShipToAddress>");
				sb.Append(ShipToAddress.toXMLString());
				sb.Append("</ebl:ShipToAddress>");
			}
			if(BuyerEmail != null)
			{
				sb.Append("<ebl:BuyerEmail>").Append(BuyerEmail);
				sb.Append("</ebl:BuyerEmail>");
			}
			return sb.ToString();
		}
	}




	/**
      *A free-form field for your own use, such as a tracking
      *number or other value you want returned to you in IPN.
      *Optional Character length and limitations: 256 single-byte
      *alphanumeric characters 
      */
	public partial class DoMobileCheckoutPaymentResponseDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string CustomField;
		public string Custom
		{
			get
			{
				return this.CustomField;
			}
			set
			{
				this.CustomField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string InvoiceIDField;
		public string InvoiceID
		{
			get
			{
				return this.InvoiceIDField;
			}
			set
			{
				this.InvoiceIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PayerInfoType PayerInfoField;
		public PayerInfoType PayerInfo
		{
			get
			{
				return this.PayerInfoField;
			}
			set
			{
				this.PayerInfoField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PaymentInfoType PaymentInfoField;
		public PaymentInfoType PaymentInfo
		{
			get
			{
				return this.PaymentInfoField;
			}
			set
			{
				this.PaymentInfoField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DoMobileCheckoutPaymentResponseDetailsType(){
		}


		public DoMobileCheckoutPaymentResponseDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("Custom").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Custom")[0]))
			{
				this.Custom = (string)document.GetElementsByTagName("Custom")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("InvoiceID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("InvoiceID")[0]))
			{
				this.InvoiceID = (string)document.GetElementsByTagName("InvoiceID")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("PayerInfo").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PayerInfo")[0]))
				{
					nodeList = document.GetElementsByTagName("PayerInfo");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.PayerInfo =  new PayerInfoType(xmlString);
				}
			}
			if(document.GetElementsByTagName("PaymentInfo").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentInfo")[0]))
				{
					nodeList = document.GetElementsByTagName("PaymentInfo");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.PaymentInfo =  new PaymentInfoType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *UATP Card Details Type 
      */
	public partial class UATPDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string UATPNumberField;
		public string UATPNumber
		{
			get
			{
				return this.UATPNumberField;
			}
			set
			{
				this.UATPNumberField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? ExpMonthField;
		public int? ExpMonth
		{
			get
			{
				return this.ExpMonthField;
			}
			set
			{
				this.ExpMonthField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? ExpYearField;
		public int? ExpYear
		{
			get
			{
				return this.ExpYearField;
			}
			set
			{
				this.ExpYearField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public UATPDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(UATPNumber != null)
			{
				sb.Append("<ebl:UATPNumber>").Append(UATPNumber);
				sb.Append("</ebl:UATPNumber>");
			}
			if(ExpMonth != null)
			{
				sb.Append("<ebl:ExpMonth>").Append(ExpMonth);
				sb.Append("</ebl:ExpMonth>");
			}
			if(ExpYear != null)
			{
				sb.Append("<ebl:ExpYear>").Append(ExpYear);
				sb.Append("</ebl:ExpYear>");
			}
			return sb.ToString();
		}
		public UATPDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("UATPNumber").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("UATPNumber")[0]))
			{
				this.UATPNumber = (string)document.GetElementsByTagName("UATPNumber")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ExpMonth").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ExpMonth")[0]))
			{
				this.ExpMonth = System.Convert.ToInt32(document.GetElementsByTagName("ExpMonth")[0].InnerText);
			}
		}
		if(document.GetElementsByTagName("ExpYear").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ExpYear")[0]))
			{
				this.ExpYear = System.Convert.ToInt32(document.GetElementsByTagName("ExpYear")[0].InnerText);
			}
		}
	
		}
		
	}




	/**
      *
      */
	public partial class RecurringPaymentsSummaryType	
	{

		/**
          *No Document Comments
		  */
		private string NextBillingDateField;
		public string NextBillingDate
		{
			get
			{
				return this.NextBillingDateField;
			}
			set
			{
				this.NextBillingDateField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? NumberCyclesCompletedField;
		public int? NumberCyclesCompleted
		{
			get
			{
				return this.NumberCyclesCompletedField;
			}
			set
			{
				this.NumberCyclesCompletedField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? NumberCyclesRemainingField;
		public int? NumberCyclesRemaining
		{
			get
			{
				return this.NumberCyclesRemainingField;
			}
			set
			{
				this.NumberCyclesRemainingField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType OutstandingBalanceField;
		public BasicAmountType OutstandingBalance
		{
			get
			{
				return this.OutstandingBalanceField;
			}
			set
			{
				this.OutstandingBalanceField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? FailedPaymentCountField;
		public int? FailedPaymentCount
		{
			get
			{
				return this.FailedPaymentCountField;
			}
			set
			{
				this.FailedPaymentCountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string LastPaymentDateField;
		public string LastPaymentDate
		{
			get
			{
				return this.LastPaymentDateField;
			}
			set
			{
				this.LastPaymentDateField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType LastPaymentAmountField;
		public BasicAmountType LastPaymentAmount
		{
			get
			{
				return this.LastPaymentAmountField;
			}
			set
			{
				this.LastPaymentAmountField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public RecurringPaymentsSummaryType(){
		}


		public RecurringPaymentsSummaryType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("NextBillingDate").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("NextBillingDate")[0]))
			{
				this.NextBillingDate = (string)document.GetElementsByTagName("NextBillingDate")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("NumberCyclesCompleted").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("NumberCyclesCompleted")[0]))
			{
				this.NumberCyclesCompleted = System.Convert.ToInt32(document.GetElementsByTagName("NumberCyclesCompleted")[0].InnerText);
			}
		}
		if(document.GetElementsByTagName("NumberCyclesRemaining").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("NumberCyclesRemaining")[0]))
			{
				this.NumberCyclesRemaining = System.Convert.ToInt32(document.GetElementsByTagName("NumberCyclesRemaining")[0].InnerText);
			}
		}
			if(document.GetElementsByTagName("OutstandingBalance").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OutstandingBalance")[0]))
				{
					nodeList = document.GetElementsByTagName("OutstandingBalance");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.OutstandingBalance =  new BasicAmountType(xmlString);
				}
			}
		if(document.GetElementsByTagName("FailedPaymentCount").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("FailedPaymentCount")[0]))
			{
				this.FailedPaymentCount = System.Convert.ToInt32(document.GetElementsByTagName("FailedPaymentCount")[0].InnerText);
			}
		}
		if(document.GetElementsByTagName("LastPaymentDate").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("LastPaymentDate")[0]))
			{
				this.LastPaymentDate = (string)document.GetElementsByTagName("LastPaymentDate")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("LastPaymentAmount").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("LastPaymentAmount")[0]))
				{
					nodeList = document.GetElementsByTagName("LastPaymentAmount");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.LastPaymentAmount =  new BasicAmountType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *
      */
	public partial class ActivationDetailsType	
	{

		/**
          *No Document Comments
		  */
		private BasicAmountType InitialAmountField;
		public BasicAmountType InitialAmount
		{
			get
			{
				return this.InitialAmountField;
			}
			set
			{
				this.InitialAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private FailedPaymentActionType? FailedInitialAmountActionField;
		public FailedPaymentActionType? FailedInitialAmountAction
		{
			get
			{
				return this.FailedInitialAmountActionField;
			}
			set
			{
				this.FailedInitialAmountActionField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public ActivationDetailsType(BasicAmountType InitialAmount){
			this.InitialAmount = InitialAmount;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public ActivationDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(InitialAmount != null)
			{
				sb.Append("<ebl:InitialAmount");
				sb.Append(InitialAmount.toXMLString());
				sb.Append("</ebl:InitialAmount>");
			}
			if(FailedInitialAmountAction != null)
			{
				sb.Append("<ebl:FailedInitialAmountAction>").Append(EnumUtils.getDescription(FailedInitialAmountAction));
				sb.Append("</ebl:FailedInitialAmountAction>");
			}
			return sb.ToString();
		}
	}




	/**
      *Unit of meausre for billing cycle 
      */
	public partial class BillingPeriodDetailsType	
	{

		/**
          *No Document Comments
		  */
		private BillingPeriodType? BillingPeriodField;
		public BillingPeriodType? BillingPeriod
		{
			get
			{
				return this.BillingPeriodField;
			}
			set
			{
				this.BillingPeriodField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? BillingFrequencyField;
		public int? BillingFrequency
		{
			get
			{
				return this.BillingFrequencyField;
			}
			set
			{
				this.BillingFrequencyField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? TotalBillingCyclesField;
		public int? TotalBillingCycles
		{
			get
			{
				return this.TotalBillingCyclesField;
			}
			set
			{
				this.TotalBillingCyclesField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType AmountField;
		public BasicAmountType Amount
		{
			get
			{
				return this.AmountField;
			}
			set
			{
				this.AmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType ShippingAmountField;
		public BasicAmountType ShippingAmount
		{
			get
			{
				return this.ShippingAmountField;
			}
			set
			{
				this.ShippingAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType TaxAmountField;
		public BasicAmountType TaxAmount
		{
			get
			{
				return this.TaxAmountField;
			}
			set
			{
				this.TaxAmountField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public BillingPeriodDetailsType(BillingPeriodType? BillingPeriod, int? BillingFrequency, BasicAmountType Amount){
			this.BillingPeriod = BillingPeriod;
			this.BillingFrequency = BillingFrequency;
			this.Amount = Amount;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public BillingPeriodDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(BillingPeriod != null)
			{
				sb.Append("<ebl:BillingPeriod>").Append(EnumUtils.getDescription(BillingPeriod));
				sb.Append("</ebl:BillingPeriod>");
			}
			if(BillingFrequency != null)
			{
				sb.Append("<ebl:BillingFrequency>").Append(BillingFrequency);
				sb.Append("</ebl:BillingFrequency>");
			}
			if(TotalBillingCycles != null)
			{
				sb.Append("<ebl:TotalBillingCycles>").Append(TotalBillingCycles);
				sb.Append("</ebl:TotalBillingCycles>");
			}
			if(Amount != null)
			{
				sb.Append("<ebl:Amount");
				sb.Append(Amount.toXMLString());
				sb.Append("</ebl:Amount>");
			}
			if(ShippingAmount != null)
			{
				sb.Append("<ebl:ShippingAmount");
				sb.Append(ShippingAmount.toXMLString());
				sb.Append("</ebl:ShippingAmount>");
			}
			if(TaxAmount != null)
			{
				sb.Append("<ebl:TaxAmount");
				sb.Append(TaxAmount.toXMLString());
				sb.Append("</ebl:TaxAmount>");
			}
			return sb.ToString();
		}
		public BillingPeriodDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("BillingPeriod").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillingPeriod")[0]))
				{
					this.BillingPeriod = (BillingPeriodType)EnumUtils.getValue(document.GetElementsByTagName("BillingPeriod")[0].InnerText,typeof(BillingPeriodType));
				}
			}
		if(document.GetElementsByTagName("BillingFrequency").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillingFrequency")[0]))
			{
				this.BillingFrequency = System.Convert.ToInt32(document.GetElementsByTagName("BillingFrequency")[0].InnerText);
			}
		}
		if(document.GetElementsByTagName("TotalBillingCycles").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TotalBillingCycles")[0]))
			{
				this.TotalBillingCycles = System.Convert.ToInt32(document.GetElementsByTagName("TotalBillingCycles")[0].InnerText);
			}
		}
			if(document.GetElementsByTagName("Amount").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Amount")[0]))
				{
					nodeList = document.GetElementsByTagName("Amount");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.Amount =  new BasicAmountType(xmlString);
				}
			}
			if(document.GetElementsByTagName("ShippingAmount").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ShippingAmount")[0]))
				{
					nodeList = document.GetElementsByTagName("ShippingAmount");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.ShippingAmount =  new BasicAmountType(xmlString);
				}
			}
			if(document.GetElementsByTagName("TaxAmount").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TaxAmount")[0]))
				{
					nodeList = document.GetElementsByTagName("TaxAmount");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.TaxAmount =  new BasicAmountType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *Unit of meausre for billing cycle 
      */
	public partial class BillingPeriodDetailsType_Update	
	{

		/**
          *No Document Comments
		  */
		private BillingPeriodType? BillingPeriodField;
		public BillingPeriodType? BillingPeriod
		{
			get
			{
				return this.BillingPeriodField;
			}
			set
			{
				this.BillingPeriodField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? BillingFrequencyField;
		public int? BillingFrequency
		{
			get
			{
				return this.BillingFrequencyField;
			}
			set
			{
				this.BillingFrequencyField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? TotalBillingCyclesField;
		public int? TotalBillingCycles
		{
			get
			{
				return this.TotalBillingCyclesField;
			}
			set
			{
				this.TotalBillingCyclesField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType AmountField;
		public BasicAmountType Amount
		{
			get
			{
				return this.AmountField;
			}
			set
			{
				this.AmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType ShippingAmountField;
		public BasicAmountType ShippingAmount
		{
			get
			{
				return this.ShippingAmountField;
			}
			set
			{
				this.ShippingAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType TaxAmountField;
		public BasicAmountType TaxAmount
		{
			get
			{
				return this.TaxAmountField;
			}
			set
			{
				this.TaxAmountField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public BillingPeriodDetailsType_Update(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(BillingPeriod != null)
			{
				sb.Append("<ebl:BillingPeriod>").Append(EnumUtils.getDescription(BillingPeriod));
				sb.Append("</ebl:BillingPeriod>");
			}
			if(BillingFrequency != null)
			{
				sb.Append("<ebl:BillingFrequency>").Append(BillingFrequency);
				sb.Append("</ebl:BillingFrequency>");
			}
			if(TotalBillingCycles != null)
			{
				sb.Append("<ebl:TotalBillingCycles>").Append(TotalBillingCycles);
				sb.Append("</ebl:TotalBillingCycles>");
			}
			if(Amount != null)
			{
				sb.Append("<ebl:Amount");
				sb.Append(Amount.toXMLString());
				sb.Append("</ebl:Amount>");
			}
			if(ShippingAmount != null)
			{
				sb.Append("<ebl:ShippingAmount");
				sb.Append(ShippingAmount.toXMLString());
				sb.Append("</ebl:ShippingAmount>");
			}
			if(TaxAmount != null)
			{
				sb.Append("<ebl:TaxAmount");
				sb.Append(TaxAmount.toXMLString());
				sb.Append("</ebl:TaxAmount>");
			}
			return sb.ToString();
		}
	}




	/**
      *Schedule details for the Recurring Payment 
      */
	public partial class ScheduleDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string DescriptionField;
		public string Description
		{
			get
			{
				return this.DescriptionField;
			}
			set
			{
				this.DescriptionField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BillingPeriodDetailsType TrialPeriodField;
		public BillingPeriodDetailsType TrialPeriod
		{
			get
			{
				return this.TrialPeriodField;
			}
			set
			{
				this.TrialPeriodField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BillingPeriodDetailsType PaymentPeriodField;
		public BillingPeriodDetailsType PaymentPeriod
		{
			get
			{
				return this.PaymentPeriodField;
			}
			set
			{
				this.PaymentPeriodField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? MaxFailedPaymentsField;
		public int? MaxFailedPayments
		{
			get
			{
				return this.MaxFailedPaymentsField;
			}
			set
			{
				this.MaxFailedPaymentsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ActivationDetailsType ActivationDetailsField;
		public ActivationDetailsType ActivationDetails
		{
			get
			{
				return this.ActivationDetailsField;
			}
			set
			{
				this.ActivationDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private AutoBillType? AutoBillOutstandingAmountField;
		public AutoBillType? AutoBillOutstandingAmount
		{
			get
			{
				return this.AutoBillOutstandingAmountField;
			}
			set
			{
				this.AutoBillOutstandingAmountField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public ScheduleDetailsType(string Description, BillingPeriodDetailsType PaymentPeriod){
			this.Description = Description;
			this.PaymentPeriod = PaymentPeriod;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public ScheduleDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Description != null)
			{
				sb.Append("<ebl:Description>").Append(Description);
				sb.Append("</ebl:Description>");
			}
			if(TrialPeriod != null)
			{
				sb.Append("<ebl:TrialPeriod>");
				sb.Append(TrialPeriod.toXMLString());
				sb.Append("</ebl:TrialPeriod>");
			}
			if(PaymentPeriod != null)
			{
				sb.Append("<ebl:PaymentPeriod>");
				sb.Append(PaymentPeriod.toXMLString());
				sb.Append("</ebl:PaymentPeriod>");
			}
			if(MaxFailedPayments != null)
			{
				sb.Append("<ebl:MaxFailedPayments>").Append(MaxFailedPayments);
				sb.Append("</ebl:MaxFailedPayments>");
			}
			if(ActivationDetails != null)
			{
				sb.Append("<ebl:ActivationDetails>");
				sb.Append(ActivationDetails.toXMLString());
				sb.Append("</ebl:ActivationDetails>");
			}
			if(AutoBillOutstandingAmount != null)
			{
				sb.Append("<ebl:AutoBillOutstandingAmount>").Append(EnumUtils.getDescription(AutoBillOutstandingAmount));
				sb.Append("</ebl:AutoBillOutstandingAmount>");
			}
			return sb.ToString();
		}
	}




	/**
      *Subscriber name - if missing, will use name in buyer's
      *account 
      */
	public partial class RecurringPaymentsProfileDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string SubscriberNameField;
		public string SubscriberName
		{
			get
			{
				return this.SubscriberNameField;
			}
			set
			{
				this.SubscriberNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private AddressType SubscriberShippingAddressField;
		public AddressType SubscriberShippingAddress
		{
			get
			{
				return this.SubscriberShippingAddressField;
			}
			set
			{
				this.SubscriberShippingAddressField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string BillingStartDateField;
		public string BillingStartDate
		{
			get
			{
				return this.BillingStartDateField;
			}
			set
			{
				this.BillingStartDateField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ProfileReferenceField;
		public string ProfileReference
		{
			get
			{
				return this.ProfileReferenceField;
			}
			set
			{
				this.ProfileReferenceField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public RecurringPaymentsProfileDetailsType(string BillingStartDate){
			this.BillingStartDate = BillingStartDate;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public RecurringPaymentsProfileDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(SubscriberName != null)
			{
				sb.Append("<ebl:SubscriberName>").Append(SubscriberName);
				sb.Append("</ebl:SubscriberName>");
			}
			if(SubscriberShippingAddress != null)
			{
				sb.Append("<ebl:SubscriberShippingAddress>");
				sb.Append(SubscriberShippingAddress.toXMLString());
				sb.Append("</ebl:SubscriberShippingAddress>");
			}
			if(BillingStartDate != null)
			{
				sb.Append("<ebl:BillingStartDate>").Append(BillingStartDate);
				sb.Append("</ebl:BillingStartDate>");
			}
			if(ProfileReference != null)
			{
				sb.Append("<ebl:ProfileReference>").Append(ProfileReference);
				sb.Append("</ebl:ProfileReference>");
			}
			return sb.ToString();
		}
		public RecurringPaymentsProfileDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("SubscriberName").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SubscriberName")[0]))
			{
				this.SubscriberName = (string)document.GetElementsByTagName("SubscriberName")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("SubscriberShippingAddress").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SubscriberShippingAddress")[0]))
				{
					nodeList = document.GetElementsByTagName("SubscriberShippingAddress");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.SubscriberShippingAddress =  new AddressType(xmlString);
				}
			}
		if(document.GetElementsByTagName("BillingStartDate").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillingStartDate")[0]))
			{
				this.BillingStartDate = (string)document.GetElementsByTagName("BillingStartDate")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ProfileReference").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ProfileReference")[0]))
			{
				this.ProfileReference = (string)document.GetElementsByTagName("ProfileReference")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *Billing Agreement token (required if Express Checkout) 
      */
	public partial class CreateRecurringPaymentsProfileRequestDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string TokenField;
		public string Token
		{
			get
			{
				return this.TokenField;
			}
			set
			{
				this.TokenField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private CreditCardDetailsType CreditCardField;
		public CreditCardDetailsType CreditCard
		{
			get
			{
				return this.CreditCardField;
			}
			set
			{
				this.CreditCardField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private RecurringPaymentsProfileDetailsType RecurringPaymentsProfileDetailsField;
		public RecurringPaymentsProfileDetailsType RecurringPaymentsProfileDetails
		{
			get
			{
				return this.RecurringPaymentsProfileDetailsField;
			}
			set
			{
				this.RecurringPaymentsProfileDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ScheduleDetailsType ScheduleDetailsField;
		public ScheduleDetailsType ScheduleDetails
		{
			get
			{
				return this.ScheduleDetailsField;
			}
			set
			{
				this.ScheduleDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<PaymentDetailsItemType> PaymentDetailsItemField = new List<PaymentDetailsItemType>();
		public List<PaymentDetailsItemType> PaymentDetailsItem
		{
			get
			{
				return this.PaymentDetailsItemField;
			}
			set
			{
				this.PaymentDetailsItemField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public CreateRecurringPaymentsProfileRequestDetailsType(RecurringPaymentsProfileDetailsType RecurringPaymentsProfileDetails, ScheduleDetailsType ScheduleDetails){
			this.RecurringPaymentsProfileDetails = RecurringPaymentsProfileDetails;
			this.ScheduleDetails = ScheduleDetails;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public CreateRecurringPaymentsProfileRequestDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Token != null)
			{
				sb.Append("<ebl:Token>").Append(Token);
				sb.Append("</ebl:Token>");
			}
			if(CreditCard != null)
			{
				sb.Append("<ebl:CreditCard>");
				sb.Append(CreditCard.toXMLString());
				sb.Append("</ebl:CreditCard>");
			}
			if(RecurringPaymentsProfileDetails != null)
			{
				sb.Append("<ebl:RecurringPaymentsProfileDetails>");
				sb.Append(RecurringPaymentsProfileDetails.toXMLString());
				sb.Append("</ebl:RecurringPaymentsProfileDetails>");
			}
			if(ScheduleDetails != null)
			{
				sb.Append("<ebl:ScheduleDetails>");
				sb.Append(ScheduleDetails.toXMLString());
				sb.Append("</ebl:ScheduleDetails>");
			}
			if(PaymentDetailsItem != null)
			{
				for(int i = 0; i < PaymentDetailsItem.Count; i++)
				{
					sb.Append("<ebl:PaymentDetailsItem>");
					sb.Append(PaymentDetailsItem[i].toXMLString());
					sb.Append("</ebl:PaymentDetailsItem>");
				
				}
			}
			return sb.ToString();
		}
	}




	/**
      *Recurring Billing Profile ID 
      */
	public partial class CreateRecurringPaymentsProfileResponseDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string ProfileIDField;
		public string ProfileID
		{
			get
			{
				return this.ProfileIDField;
			}
			set
			{
				this.ProfileIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private RecurringPaymentsProfileStatusType? ProfileStatusField;
		public RecurringPaymentsProfileStatusType? ProfileStatus
		{
			get
			{
				return this.ProfileStatusField;
			}
			set
			{
				this.ProfileStatusField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string TransactionIDField;
		public string TransactionID
		{
			get
			{
				return this.TransactionIDField;
			}
			set
			{
				this.TransactionIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string DCCProcessorResponseField;
		public string DCCProcessorResponse
		{
			get
			{
				return this.DCCProcessorResponseField;
			}
			set
			{
				this.DCCProcessorResponseField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string DCCReturnCodeField;
		public string DCCReturnCode
		{
			get
			{
				return this.DCCReturnCodeField;
			}
			set
			{
				this.DCCReturnCodeField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public CreateRecurringPaymentsProfileResponseDetailsType(){
		}


		public CreateRecurringPaymentsProfileResponseDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("ProfileID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ProfileID")[0]))
			{
				this.ProfileID = (string)document.GetElementsByTagName("ProfileID")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("ProfileStatus").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ProfileStatus")[0]))
				{
					this.ProfileStatus = (RecurringPaymentsProfileStatusType)EnumUtils.getValue(document.GetElementsByTagName("ProfileStatus")[0].InnerText,typeof(RecurringPaymentsProfileStatusType));
				}
			}
		if(document.GetElementsByTagName("TransactionID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TransactionID")[0]))
			{
				this.TransactionID = (string)document.GetElementsByTagName("TransactionID")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("DCCProcessorResponse").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("DCCProcessorResponse")[0]))
			{
				this.DCCProcessorResponse = (string)document.GetElementsByTagName("DCCProcessorResponse")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("DCCReturnCode").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("DCCReturnCode")[0]))
			{
				this.DCCReturnCode = (string)document.GetElementsByTagName("DCCReturnCode")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *Recurring Billing Profile ID 
      */
	public partial class GetRecurringPaymentsProfileDetailsResponseDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string ProfileIDField;
		public string ProfileID
		{
			get
			{
				return this.ProfileIDField;
			}
			set
			{
				this.ProfileIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private RecurringPaymentsProfileStatusType? ProfileStatusField;
		public RecurringPaymentsProfileStatusType? ProfileStatus
		{
			get
			{
				return this.ProfileStatusField;
			}
			set
			{
				this.ProfileStatusField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string DescriptionField;
		public string Description
		{
			get
			{
				return this.DescriptionField;
			}
			set
			{
				this.DescriptionField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private AutoBillType? AutoBillOutstandingAmountField;
		public AutoBillType? AutoBillOutstandingAmount
		{
			get
			{
				return this.AutoBillOutstandingAmountField;
			}
			set
			{
				this.AutoBillOutstandingAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? MaxFailedPaymentsField;
		public int? MaxFailedPayments
		{
			get
			{
				return this.MaxFailedPaymentsField;
			}
			set
			{
				this.MaxFailedPaymentsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private RecurringPaymentsProfileDetailsType RecurringPaymentsProfileDetailsField;
		public RecurringPaymentsProfileDetailsType RecurringPaymentsProfileDetails
		{
			get
			{
				return this.RecurringPaymentsProfileDetailsField;
			}
			set
			{
				this.RecurringPaymentsProfileDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BillingPeriodDetailsType CurrentRecurringPaymentsPeriodField;
		public BillingPeriodDetailsType CurrentRecurringPaymentsPeriod
		{
			get
			{
				return this.CurrentRecurringPaymentsPeriodField;
			}
			set
			{
				this.CurrentRecurringPaymentsPeriodField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private RecurringPaymentsSummaryType RecurringPaymentsSummaryField;
		public RecurringPaymentsSummaryType RecurringPaymentsSummary
		{
			get
			{
				return this.RecurringPaymentsSummaryField;
			}
			set
			{
				this.RecurringPaymentsSummaryField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private CreditCardDetailsType CreditCardField;
		public CreditCardDetailsType CreditCard
		{
			get
			{
				return this.CreditCardField;
			}
			set
			{
				this.CreditCardField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BillingPeriodDetailsType TrialRecurringPaymentsPeriodField;
		public BillingPeriodDetailsType TrialRecurringPaymentsPeriod
		{
			get
			{
				return this.TrialRecurringPaymentsPeriodField;
			}
			set
			{
				this.TrialRecurringPaymentsPeriodField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BillingPeriodDetailsType RegularRecurringPaymentsPeriodField;
		public BillingPeriodDetailsType RegularRecurringPaymentsPeriod
		{
			get
			{
				return this.RegularRecurringPaymentsPeriodField;
			}
			set
			{
				this.RegularRecurringPaymentsPeriodField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType TrialAmountPaidField;
		public BasicAmountType TrialAmountPaid
		{
			get
			{
				return this.TrialAmountPaidField;
			}
			set
			{
				this.TrialAmountPaidField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType RegularAmountPaidField;
		public BasicAmountType RegularAmountPaid
		{
			get
			{
				return this.RegularAmountPaidField;
			}
			set
			{
				this.RegularAmountPaidField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType AggregateAmountField;
		public BasicAmountType AggregateAmount
		{
			get
			{
				return this.AggregateAmountField;
			}
			set
			{
				this.AggregateAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType AggregateOptionalAmountField;
		public BasicAmountType AggregateOptionalAmount
		{
			get
			{
				return this.AggregateOptionalAmountField;
			}
			set
			{
				this.AggregateOptionalAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string FinalPaymentDueDateField;
		public string FinalPaymentDueDate
		{
			get
			{
				return this.FinalPaymentDueDateField;
			}
			set
			{
				this.FinalPaymentDueDateField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public GetRecurringPaymentsProfileDetailsResponseDetailsType(){
		}


		public GetRecurringPaymentsProfileDetailsResponseDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("ProfileID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ProfileID")[0]))
			{
				this.ProfileID = (string)document.GetElementsByTagName("ProfileID")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("ProfileStatus").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ProfileStatus")[0]))
				{
					this.ProfileStatus = (RecurringPaymentsProfileStatusType)EnumUtils.getValue(document.GetElementsByTagName("ProfileStatus")[0].InnerText,typeof(RecurringPaymentsProfileStatusType));
				}
			}
		if(document.GetElementsByTagName("Description").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Description")[0]))
			{
				this.Description = (string)document.GetElementsByTagName("Description")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("AutoBillOutstandingAmount").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AutoBillOutstandingAmount")[0]))
				{
					this.AutoBillOutstandingAmount = (AutoBillType)EnumUtils.getValue(document.GetElementsByTagName("AutoBillOutstandingAmount")[0].InnerText,typeof(AutoBillType));
				}
			}
		if(document.GetElementsByTagName("MaxFailedPayments").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("MaxFailedPayments")[0]))
			{
				this.MaxFailedPayments = System.Convert.ToInt32(document.GetElementsByTagName("MaxFailedPayments")[0].InnerText);
			}
		}
			if(document.GetElementsByTagName("RecurringPaymentsProfileDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("RecurringPaymentsProfileDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("RecurringPaymentsProfileDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.RecurringPaymentsProfileDetails =  new RecurringPaymentsProfileDetailsType(xmlString);
				}
			}
			if(document.GetElementsByTagName("CurrentRecurringPaymentsPeriod").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CurrentRecurringPaymentsPeriod")[0]))
				{
					nodeList = document.GetElementsByTagName("CurrentRecurringPaymentsPeriod");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.CurrentRecurringPaymentsPeriod =  new BillingPeriodDetailsType(xmlString);
				}
			}
			if(document.GetElementsByTagName("RecurringPaymentsSummary").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("RecurringPaymentsSummary")[0]))
				{
					nodeList = document.GetElementsByTagName("RecurringPaymentsSummary");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.RecurringPaymentsSummary =  new RecurringPaymentsSummaryType(xmlString);
				}
			}
			if(document.GetElementsByTagName("CreditCard").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CreditCard")[0]))
				{
					nodeList = document.GetElementsByTagName("CreditCard");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.CreditCard =  new CreditCardDetailsType(xmlString);
				}
			}
			if(document.GetElementsByTagName("TrialRecurringPaymentsPeriod").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TrialRecurringPaymentsPeriod")[0]))
				{
					nodeList = document.GetElementsByTagName("TrialRecurringPaymentsPeriod");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.TrialRecurringPaymentsPeriod =  new BillingPeriodDetailsType(xmlString);
				}
			}
			if(document.GetElementsByTagName("RegularRecurringPaymentsPeriod").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("RegularRecurringPaymentsPeriod")[0]))
				{
					nodeList = document.GetElementsByTagName("RegularRecurringPaymentsPeriod");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.RegularRecurringPaymentsPeriod =  new BillingPeriodDetailsType(xmlString);
				}
			}
			if(document.GetElementsByTagName("TrialAmountPaid").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TrialAmountPaid")[0]))
				{
					nodeList = document.GetElementsByTagName("TrialAmountPaid");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.TrialAmountPaid =  new BasicAmountType(xmlString);
				}
			}
			if(document.GetElementsByTagName("RegularAmountPaid").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("RegularAmountPaid")[0]))
				{
					nodeList = document.GetElementsByTagName("RegularAmountPaid");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.RegularAmountPaid =  new BasicAmountType(xmlString);
				}
			}
			if(document.GetElementsByTagName("AggregateAmount").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AggregateAmount")[0]))
				{
					nodeList = document.GetElementsByTagName("AggregateAmount");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.AggregateAmount =  new BasicAmountType(xmlString);
				}
			}
			if(document.GetElementsByTagName("AggregateOptionalAmount").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AggregateOptionalAmount")[0]))
				{
					nodeList = document.GetElementsByTagName("AggregateOptionalAmount");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.AggregateOptionalAmount =  new BasicAmountType(xmlString);
				}
			}
		if(document.GetElementsByTagName("FinalPaymentDueDate").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("FinalPaymentDueDate")[0]))
			{
				this.FinalPaymentDueDate = (string)document.GetElementsByTagName("FinalPaymentDueDate")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *
      */
	public partial class ManageRecurringPaymentsProfileStatusRequestDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string ProfileIDField;
		public string ProfileID
		{
			get
			{
				return this.ProfileIDField;
			}
			set
			{
				this.ProfileIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private StatusChangeActionType? ActionField;
		public StatusChangeActionType? Action
		{
			get
			{
				return this.ActionField;
			}
			set
			{
				this.ActionField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string NoteField;
		public string Note
		{
			get
			{
				return this.NoteField;
			}
			set
			{
				this.NoteField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public ManageRecurringPaymentsProfileStatusRequestDetailsType(string ProfileID, StatusChangeActionType? Action){
			this.ProfileID = ProfileID;
			this.Action = Action;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public ManageRecurringPaymentsProfileStatusRequestDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ProfileID != null)
			{
				sb.Append("<ebl:ProfileID>").Append(ProfileID);
				sb.Append("</ebl:ProfileID>");
			}
			if(Action != null)
			{
				sb.Append("<ebl:Action>").Append(EnumUtils.getDescription(Action));
				sb.Append("</ebl:Action>");
			}
			if(Note != null)
			{
				sb.Append("<ebl:Note>").Append(Note);
				sb.Append("</ebl:Note>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class ManageRecurringPaymentsProfileStatusResponseDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string ProfileIDField;
		public string ProfileID
		{
			get
			{
				return this.ProfileIDField;
			}
			set
			{
				this.ProfileIDField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public ManageRecurringPaymentsProfileStatusResponseDetailsType(){
		}


		public ManageRecurringPaymentsProfileStatusResponseDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("ProfileID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ProfileID")[0]))
			{
				this.ProfileID = (string)document.GetElementsByTagName("ProfileID")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *
      */
	public partial class BillOutstandingAmountRequestDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string ProfileIDField;
		public string ProfileID
		{
			get
			{
				return this.ProfileIDField;
			}
			set
			{
				this.ProfileIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType AmountField;
		public BasicAmountType Amount
		{
			get
			{
				return this.AmountField;
			}
			set
			{
				this.AmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string NoteField;
		public string Note
		{
			get
			{
				return this.NoteField;
			}
			set
			{
				this.NoteField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public BillOutstandingAmountRequestDetailsType(string ProfileID){
			this.ProfileID = ProfileID;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public BillOutstandingAmountRequestDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ProfileID != null)
			{
				sb.Append("<ebl:ProfileID>").Append(ProfileID);
				sb.Append("</ebl:ProfileID>");
			}
			if(Amount != null)
			{
				sb.Append("<ebl:Amount");
				sb.Append(Amount.toXMLString());
				sb.Append("</ebl:Amount>");
			}
			if(Note != null)
			{
				sb.Append("<ebl:Note>").Append(Note);
				sb.Append("</ebl:Note>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class BillOutstandingAmountResponseDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string ProfileIDField;
		public string ProfileID
		{
			get
			{
				return this.ProfileIDField;
			}
			set
			{
				this.ProfileIDField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public BillOutstandingAmountResponseDetailsType(){
		}


		public BillOutstandingAmountResponseDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("ProfileID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ProfileID")[0]))
			{
				this.ProfileID = (string)document.GetElementsByTagName("ProfileID")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *
      */
	public partial class UpdateRecurringPaymentsProfileRequestDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string ProfileIDField;
		public string ProfileID
		{
			get
			{
				return this.ProfileIDField;
			}
			set
			{
				this.ProfileIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string NoteField;
		public string Note
		{
			get
			{
				return this.NoteField;
			}
			set
			{
				this.NoteField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string DescriptionField;
		public string Description
		{
			get
			{
				return this.DescriptionField;
			}
			set
			{
				this.DescriptionField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string SubscriberNameField;
		public string SubscriberName
		{
			get
			{
				return this.SubscriberNameField;
			}
			set
			{
				this.SubscriberNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private AddressType SubscriberShippingAddressField;
		public AddressType SubscriberShippingAddress
		{
			get
			{
				return this.SubscriberShippingAddressField;
			}
			set
			{
				this.SubscriberShippingAddressField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ProfileReferenceField;
		public string ProfileReference
		{
			get
			{
				return this.ProfileReferenceField;
			}
			set
			{
				this.ProfileReferenceField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? AdditionalBillingCyclesField;
		public int? AdditionalBillingCycles
		{
			get
			{
				return this.AdditionalBillingCyclesField;
			}
			set
			{
				this.AdditionalBillingCyclesField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType AmountField;
		public BasicAmountType Amount
		{
			get
			{
				return this.AmountField;
			}
			set
			{
				this.AmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType ShippingAmountField;
		public BasicAmountType ShippingAmount
		{
			get
			{
				return this.ShippingAmountField;
			}
			set
			{
				this.ShippingAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType TaxAmountField;
		public BasicAmountType TaxAmount
		{
			get
			{
				return this.TaxAmountField;
			}
			set
			{
				this.TaxAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType OutstandingBalanceField;
		public BasicAmountType OutstandingBalance
		{
			get
			{
				return this.OutstandingBalanceField;
			}
			set
			{
				this.OutstandingBalanceField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private AutoBillType? AutoBillOutstandingAmountField;
		public AutoBillType? AutoBillOutstandingAmount
		{
			get
			{
				return this.AutoBillOutstandingAmountField;
			}
			set
			{
				this.AutoBillOutstandingAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? MaxFailedPaymentsField;
		public int? MaxFailedPayments
		{
			get
			{
				return this.MaxFailedPaymentsField;
			}
			set
			{
				this.MaxFailedPaymentsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private CreditCardDetailsType CreditCardField;
		public CreditCardDetailsType CreditCard
		{
			get
			{
				return this.CreditCardField;
			}
			set
			{
				this.CreditCardField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string BillingStartDateField;
		public string BillingStartDate
		{
			get
			{
				return this.BillingStartDateField;
			}
			set
			{
				this.BillingStartDateField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BillingPeriodDetailsType_Update TrialPeriodField;
		public BillingPeriodDetailsType_Update TrialPeriod
		{
			get
			{
				return this.TrialPeriodField;
			}
			set
			{
				this.TrialPeriodField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BillingPeriodDetailsType_Update PaymentPeriodField;
		public BillingPeriodDetailsType_Update PaymentPeriod
		{
			get
			{
				return this.PaymentPeriodField;
			}
			set
			{
				this.PaymentPeriodField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public UpdateRecurringPaymentsProfileRequestDetailsType(string ProfileID){
			this.ProfileID = ProfileID;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public UpdateRecurringPaymentsProfileRequestDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ProfileID != null)
			{
				sb.Append("<ebl:ProfileID>").Append(ProfileID);
				sb.Append("</ebl:ProfileID>");
			}
			if(Note != null)
			{
				sb.Append("<ebl:Note>").Append(Note);
				sb.Append("</ebl:Note>");
			}
			if(Description != null)
			{
				sb.Append("<ebl:Description>").Append(Description);
				sb.Append("</ebl:Description>");
			}
			if(SubscriberName != null)
			{
				sb.Append("<ebl:SubscriberName>").Append(SubscriberName);
				sb.Append("</ebl:SubscriberName>");
			}
			if(SubscriberShippingAddress != null)
			{
				sb.Append("<ebl:SubscriberShippingAddress>");
				sb.Append(SubscriberShippingAddress.toXMLString());
				sb.Append("</ebl:SubscriberShippingAddress>");
			}
			if(ProfileReference != null)
			{
				sb.Append("<ebl:ProfileReference>").Append(ProfileReference);
				sb.Append("</ebl:ProfileReference>");
			}
			if(AdditionalBillingCycles != null)
			{
				sb.Append("<ebl:AdditionalBillingCycles>").Append(AdditionalBillingCycles);
				sb.Append("</ebl:AdditionalBillingCycles>");
			}
			if(Amount != null)
			{
				sb.Append("<ebl:Amount");
				sb.Append(Amount.toXMLString());
				sb.Append("</ebl:Amount>");
			}
			if(ShippingAmount != null)
			{
				sb.Append("<ebl:ShippingAmount");
				sb.Append(ShippingAmount.toXMLString());
				sb.Append("</ebl:ShippingAmount>");
			}
			if(TaxAmount != null)
			{
				sb.Append("<ebl:TaxAmount");
				sb.Append(TaxAmount.toXMLString());
				sb.Append("</ebl:TaxAmount>");
			}
			if(OutstandingBalance != null)
			{
				sb.Append("<ebl:OutstandingBalance");
				sb.Append(OutstandingBalance.toXMLString());
				sb.Append("</ebl:OutstandingBalance>");
			}
			if(AutoBillOutstandingAmount != null)
			{
				sb.Append("<ebl:AutoBillOutstandingAmount>").Append(EnumUtils.getDescription(AutoBillOutstandingAmount));
				sb.Append("</ebl:AutoBillOutstandingAmount>");
			}
			if(MaxFailedPayments != null)
			{
				sb.Append("<ebl:MaxFailedPayments>").Append(MaxFailedPayments);
				sb.Append("</ebl:MaxFailedPayments>");
			}
			if(CreditCard != null)
			{
				sb.Append("<ebl:CreditCard>");
				sb.Append(CreditCard.toXMLString());
				sb.Append("</ebl:CreditCard>");
			}
			if(BillingStartDate != null)
			{
				sb.Append("<ebl:BillingStartDate>").Append(BillingStartDate);
				sb.Append("</ebl:BillingStartDate>");
			}
			if(TrialPeriod != null)
			{
				sb.Append("<ebl:TrialPeriod>");
				sb.Append(TrialPeriod.toXMLString());
				sb.Append("</ebl:TrialPeriod>");
			}
			if(PaymentPeriod != null)
			{
				sb.Append("<ebl:PaymentPeriod>");
				sb.Append(PaymentPeriod.toXMLString());
				sb.Append("</ebl:PaymentPeriod>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class UpdateRecurringPaymentsProfileResponseDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string ProfileIDField;
		public string ProfileID
		{
			get
			{
				return this.ProfileIDField;
			}
			set
			{
				this.ProfileIDField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public UpdateRecurringPaymentsProfileResponseDetailsType(){
		}


		public UpdateRecurringPaymentsProfileResponseDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("ProfileID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ProfileID")[0]))
			{
				this.ProfileID = (string)document.GetElementsByTagName("ProfileID")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *Details of Risk Filter. 
      */
	public partial class RiskFilterDetailsType	
	{

		/**
          *No Document Comments
		  */
		private int? IdField;
		public int? Id
		{
			get
			{
				return this.IdField;
			}
			set
			{
				this.IdField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string NameField;
		public string Name
		{
			get
			{
				return this.NameField;
			}
			set
			{
				this.NameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string DescriptionField;
		public string Description
		{
			get
			{
				return this.DescriptionField;
			}
			set
			{
				this.DescriptionField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public RiskFilterDetailsType(){
		}


		public RiskFilterDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("Id").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Id")[0]))
			{
				this.Id = System.Convert.ToInt32(document.GetElementsByTagName("Id")[0].InnerText);
			}
		}
		if(document.GetElementsByTagName("Name").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Name")[0]))
			{
				this.Name = (string)document.GetElementsByTagName("Name")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Description").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Description")[0]))
			{
				this.Description = (string)document.GetElementsByTagName("Description")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *Details of Risk Filter. 
      */
	public partial class RiskFilterListType	
	{

		/**
          *No Document Comments
		  */
		private List<RiskFilterDetailsType> FiltersField = new List<RiskFilterDetailsType>();
		public List<RiskFilterDetailsType> Filters
		{
			get
			{
				return this.FiltersField;
			}
			set
			{
				this.FiltersField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public RiskFilterListType(){
		}


		public RiskFilterListType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("Filters").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Filters")[0]))
				{
					nodeList = document.GetElementsByTagName("Filters");
					for(int i = 0; i < nodeList.Count; i++)
					{
						xmlString = DeserializationUtils.convertToXML(nodeList[i]);
						this.Filters.Add(new RiskFilterDetailsType(xmlString));
					}
				}
			}
	
		}
		
	}




	/**
      *Thes are filters that could result in accept/deny/pending
      *action. 
      */
	public partial class FMFDetailsType	
	{

		/**
          *No Document Comments
		  */
		private RiskFilterListType AcceptFiltersField;
		public RiskFilterListType AcceptFilters
		{
			get
			{
				return this.AcceptFiltersField;
			}
			set
			{
				this.AcceptFiltersField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private RiskFilterListType PendingFiltersField;
		public RiskFilterListType PendingFilters
		{
			get
			{
				return this.PendingFiltersField;
			}
			set
			{
				this.PendingFiltersField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private RiskFilterListType DenyFiltersField;
		public RiskFilterListType DenyFilters
		{
			get
			{
				return this.DenyFiltersField;
			}
			set
			{
				this.DenyFiltersField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private RiskFilterListType ReportFiltersField;
		public RiskFilterListType ReportFilters
		{
			get
			{
				return this.ReportFiltersField;
			}
			set
			{
				this.ReportFiltersField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public FMFDetailsType(){
		}


		public FMFDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("AcceptFilters").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AcceptFilters")[0]))
				{
					nodeList = document.GetElementsByTagName("AcceptFilters");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.AcceptFilters =  new RiskFilterListType(xmlString);
				}
			}
			if(document.GetElementsByTagName("PendingFilters").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PendingFilters")[0]))
				{
					nodeList = document.GetElementsByTagName("PendingFilters");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.PendingFilters =  new RiskFilterListType(xmlString);
				}
			}
			if(document.GetElementsByTagName("DenyFilters").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("DenyFilters")[0]))
				{
					nodeList = document.GetElementsByTagName("DenyFilters");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.DenyFilters =  new RiskFilterListType(xmlString);
				}
			}
			if(document.GetElementsByTagName("ReportFilters").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ReportFilters")[0]))
				{
					nodeList = document.GetElementsByTagName("ReportFilters");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.ReportFilters =  new RiskFilterListType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *Enhanced Data Information. Example: AID for Airlines 
      */
	public partial class EnhancedDataType	
	{

		/**
          *No Document Comments
		  */
		private AirlineItineraryType AirlineItineraryField;
		public AirlineItineraryType AirlineItinerary
		{
			get
			{
				return this.AirlineItineraryField;
			}
			set
			{
				this.AirlineItineraryField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public EnhancedDataType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(AirlineItinerary != null)
			{
				sb.Append("<ebl:AirlineItinerary>");
				sb.Append(AirlineItinerary.toXMLString());
				sb.Append("</ebl:AirlineItinerary>");
			}
			return sb.ToString();
		}
	}




	/**
      *AID for Airlines 
      */
	public partial class AirlineItineraryType	
	{

		/**
          *No Document Comments
		  */
		private string PassengerNameField;
		public string PassengerName
		{
			get
			{
				return this.PassengerNameField;
			}
			set
			{
				this.PassengerNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string IssueDateField;
		public string IssueDate
		{
			get
			{
				return this.IssueDateField;
			}
			set
			{
				this.IssueDateField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string TravelAgencyNameField;
		public string TravelAgencyName
		{
			get
			{
				return this.TravelAgencyNameField;
			}
			set
			{
				this.TravelAgencyNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string TravelAgencyCodeField;
		public string TravelAgencyCode
		{
			get
			{
				return this.TravelAgencyCodeField;
			}
			set
			{
				this.TravelAgencyCodeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string TicketNumberField;
		public string TicketNumber
		{
			get
			{
				return this.TicketNumberField;
			}
			set
			{
				this.TicketNumberField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string IssuingCarrierCodeField;
		public string IssuingCarrierCode
		{
			get
			{
				return this.IssuingCarrierCodeField;
			}
			set
			{
				this.IssuingCarrierCodeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CustomerCodeField;
		public string CustomerCode
		{
			get
			{
				return this.CustomerCodeField;
			}
			set
			{
				this.CustomerCodeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType TotalFareField;
		public BasicAmountType TotalFare
		{
			get
			{
				return this.TotalFareField;
			}
			set
			{
				this.TotalFareField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType TotalTaxesField;
		public BasicAmountType TotalTaxes
		{
			get
			{
				return this.TotalTaxesField;
			}
			set
			{
				this.TotalTaxesField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType TotalFeeField;
		public BasicAmountType TotalFee
		{
			get
			{
				return this.TotalFeeField;
			}
			set
			{
				this.TotalFeeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string RestrictedTicketField;
		public string RestrictedTicket
		{
			get
			{
				return this.RestrictedTicketField;
			}
			set
			{
				this.RestrictedTicketField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ClearingSequenceField;
		public string ClearingSequence
		{
			get
			{
				return this.ClearingSequenceField;
			}
			set
			{
				this.ClearingSequenceField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ClearingCountField;
		public string ClearingCount
		{
			get
			{
				return this.ClearingCountField;
			}
			set
			{
				this.ClearingCountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<FlightDetailsType> FlightDetailsField = new List<FlightDetailsType>();
		public List<FlightDetailsType> FlightDetails
		{
			get
			{
				return this.FlightDetailsField;
			}
			set
			{
				this.FlightDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public AirlineItineraryType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(PassengerName != null)
			{
				sb.Append("<ebl:PassengerName>").Append(PassengerName);
				sb.Append("</ebl:PassengerName>");
			}
			if(IssueDate != null)
			{
				sb.Append("<ebl:IssueDate>").Append(IssueDate);
				sb.Append("</ebl:IssueDate>");
			}
			if(TravelAgencyName != null)
			{
				sb.Append("<ebl:TravelAgencyName>").Append(TravelAgencyName);
				sb.Append("</ebl:TravelAgencyName>");
			}
			if(TravelAgencyCode != null)
			{
				sb.Append("<ebl:TravelAgencyCode>").Append(TravelAgencyCode);
				sb.Append("</ebl:TravelAgencyCode>");
			}
			if(TicketNumber != null)
			{
				sb.Append("<ebl:TicketNumber>").Append(TicketNumber);
				sb.Append("</ebl:TicketNumber>");
			}
			if(IssuingCarrierCode != null)
			{
				sb.Append("<ebl:IssuingCarrierCode>").Append(IssuingCarrierCode);
				sb.Append("</ebl:IssuingCarrierCode>");
			}
			if(CustomerCode != null)
			{
				sb.Append("<ebl:CustomerCode>").Append(CustomerCode);
				sb.Append("</ebl:CustomerCode>");
			}
			if(TotalFare != null)
			{
				sb.Append("<ebl:TotalFare");
				sb.Append(TotalFare.toXMLString());
				sb.Append("</ebl:TotalFare>");
			}
			if(TotalTaxes != null)
			{
				sb.Append("<ebl:TotalTaxes");
				sb.Append(TotalTaxes.toXMLString());
				sb.Append("</ebl:TotalTaxes>");
			}
			if(TotalFee != null)
			{
				sb.Append("<ebl:TotalFee");
				sb.Append(TotalFee.toXMLString());
				sb.Append("</ebl:TotalFee>");
			}
			if(RestrictedTicket != null)
			{
				sb.Append("<ebl:RestrictedTicket>").Append(RestrictedTicket);
				sb.Append("</ebl:RestrictedTicket>");
			}
			if(ClearingSequence != null)
			{
				sb.Append("<ebl:ClearingSequence>").Append(ClearingSequence);
				sb.Append("</ebl:ClearingSequence>");
			}
			if(ClearingCount != null)
			{
				sb.Append("<ebl:ClearingCount>").Append(ClearingCount);
				sb.Append("</ebl:ClearingCount>");
			}
			if(FlightDetails != null)
			{
				for(int i = 0; i < FlightDetails.Count; i++)
				{
					sb.Append("<ebl:FlightDetails>");
					sb.Append(FlightDetails[i].toXMLString());
					sb.Append("</ebl:FlightDetails>");
				
				}
			}
			return sb.ToString();
		}
	}




	/**
      *Details of leg information 
      */
	public partial class FlightDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string ConjuctionTicketField;
		public string ConjuctionTicket
		{
			get
			{
				return this.ConjuctionTicketField;
			}
			set
			{
				this.ConjuctionTicketField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ExchangeTicketField;
		public string ExchangeTicket
		{
			get
			{
				return this.ExchangeTicketField;
			}
			set
			{
				this.ExchangeTicketField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CouponNumberField;
		public string CouponNumber
		{
			get
			{
				return this.CouponNumberField;
			}
			set
			{
				this.CouponNumberField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ServiceClassField;
		public string ServiceClass
		{
			get
			{
				return this.ServiceClassField;
			}
			set
			{
				this.ServiceClassField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string TravelDateField;
		public string TravelDate
		{
			get
			{
				return this.TravelDateField;
			}
			set
			{
				this.TravelDateField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CarrierCodeField;
		public string CarrierCode
		{
			get
			{
				return this.CarrierCodeField;
			}
			set
			{
				this.CarrierCodeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string StopOverPermittedField;
		public string StopOverPermitted
		{
			get
			{
				return this.StopOverPermittedField;
			}
			set
			{
				this.StopOverPermittedField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string DepartureAirportField;
		public string DepartureAirport
		{
			get
			{
				return this.DepartureAirportField;
			}
			set
			{
				this.DepartureAirportField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ArrivalAirportField;
		public string ArrivalAirport
		{
			get
			{
				return this.ArrivalAirportField;
			}
			set
			{
				this.ArrivalAirportField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string FlightNumberField;
		public string FlightNumber
		{
			get
			{
				return this.FlightNumberField;
			}
			set
			{
				this.FlightNumberField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string DepartureTimeField;
		public string DepartureTime
		{
			get
			{
				return this.DepartureTimeField;
			}
			set
			{
				this.DepartureTimeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ArrivalTimeField;
		public string ArrivalTime
		{
			get
			{
				return this.ArrivalTimeField;
			}
			set
			{
				this.ArrivalTimeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string FareBasisCodeField;
		public string FareBasisCode
		{
			get
			{
				return this.FareBasisCodeField;
			}
			set
			{
				this.FareBasisCodeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType FareField;
		public BasicAmountType Fare
		{
			get
			{
				return this.FareField;
			}
			set
			{
				this.FareField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType TaxesField;
		public BasicAmountType Taxes
		{
			get
			{
				return this.TaxesField;
			}
			set
			{
				this.TaxesField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType FeeField;
		public BasicAmountType Fee
		{
			get
			{
				return this.FeeField;
			}
			set
			{
				this.FeeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string EndorsementOrRestrictionsField;
		public string EndorsementOrRestrictions
		{
			get
			{
				return this.EndorsementOrRestrictionsField;
			}
			set
			{
				this.EndorsementOrRestrictionsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public FlightDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ConjuctionTicket != null)
			{
				sb.Append("<ebl:ConjuctionTicket>").Append(ConjuctionTicket);
				sb.Append("</ebl:ConjuctionTicket>");
			}
			if(ExchangeTicket != null)
			{
				sb.Append("<ebl:ExchangeTicket>").Append(ExchangeTicket);
				sb.Append("</ebl:ExchangeTicket>");
			}
			if(CouponNumber != null)
			{
				sb.Append("<ebl:CouponNumber>").Append(CouponNumber);
				sb.Append("</ebl:CouponNumber>");
			}
			if(ServiceClass != null)
			{
				sb.Append("<ebl:ServiceClass>").Append(ServiceClass);
				sb.Append("</ebl:ServiceClass>");
			}
			if(TravelDate != null)
			{
				sb.Append("<ebl:TravelDate>").Append(TravelDate);
				sb.Append("</ebl:TravelDate>");
			}
			if(CarrierCode != null)
			{
				sb.Append("<ebl:CarrierCode>").Append(CarrierCode);
				sb.Append("</ebl:CarrierCode>");
			}
			if(StopOverPermitted != null)
			{
				sb.Append("<ebl:StopOverPermitted>").Append(StopOverPermitted);
				sb.Append("</ebl:StopOverPermitted>");
			}
			if(DepartureAirport != null)
			{
				sb.Append("<ebl:DepartureAirport>").Append(DepartureAirport);
				sb.Append("</ebl:DepartureAirport>");
			}
			if(ArrivalAirport != null)
			{
				sb.Append("<ebl:ArrivalAirport>").Append(ArrivalAirport);
				sb.Append("</ebl:ArrivalAirport>");
			}
			if(FlightNumber != null)
			{
				sb.Append("<ebl:FlightNumber>").Append(FlightNumber);
				sb.Append("</ebl:FlightNumber>");
			}
			if(DepartureTime != null)
			{
				sb.Append("<ebl:DepartureTime>").Append(DepartureTime);
				sb.Append("</ebl:DepartureTime>");
			}
			if(ArrivalTime != null)
			{
				sb.Append("<ebl:ArrivalTime>").Append(ArrivalTime);
				sb.Append("</ebl:ArrivalTime>");
			}
			if(FareBasisCode != null)
			{
				sb.Append("<ebl:FareBasisCode>").Append(FareBasisCode);
				sb.Append("</ebl:FareBasisCode>");
			}
			if(Fare != null)
			{
				sb.Append("<ebl:Fare");
				sb.Append(Fare.toXMLString());
				sb.Append("</ebl:Fare>");
			}
			if(Taxes != null)
			{
				sb.Append("<ebl:Taxes");
				sb.Append(Taxes.toXMLString());
				sb.Append("</ebl:Taxes>");
			}
			if(Fee != null)
			{
				sb.Append("<ebl:Fee");
				sb.Append(Fee.toXMLString());
				sb.Append("</ebl:Fee>");
			}
			if(EndorsementOrRestrictions != null)
			{
				sb.Append("<ebl:EndorsementOrRestrictions>").Append(EndorsementOrRestrictions);
				sb.Append("</ebl:EndorsementOrRestrictions>");
			}
			return sb.ToString();
		}
	}




	/**
      *Authorization details 
      */
	public partial class AuthorizationInfoType	
	{

		/**
          *No Document Comments
		  */
		private PaymentStatusCodeType? PaymentStatusField;
		public PaymentStatusCodeType? PaymentStatus
		{
			get
			{
				return this.PaymentStatusField;
			}
			set
			{
				this.PaymentStatusField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PendingStatusCodeType? PendingReasonField;
		public PendingStatusCodeType? PendingReason
		{
			get
			{
				return this.PendingReasonField;
			}
			set
			{
				this.PendingReasonField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ProtectionEligibilityField;
		public string ProtectionEligibility
		{
			get
			{
				return this.ProtectionEligibilityField;
			}
			set
			{
				this.ProtectionEligibilityField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ProtectionEligibilityTypeField;
		public string ProtectionEligibilityType
		{
			get
			{
				return this.ProtectionEligibilityTypeField;
			}
			set
			{
				this.ProtectionEligibilityTypeField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public AuthorizationInfoType(){
		}


		public AuthorizationInfoType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("PaymentStatus").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentStatus")[0]))
				{
					this.PaymentStatus = (PaymentStatusCodeType)EnumUtils.getValue(document.GetElementsByTagName("PaymentStatus")[0].InnerText,typeof(PaymentStatusCodeType));
				}
			}
			if(document.GetElementsByTagName("PendingReason").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PendingReason")[0]))
				{
					this.PendingReason = (PendingStatusCodeType)EnumUtils.getValue(document.GetElementsByTagName("PendingReason")[0].InnerText,typeof(PendingStatusCodeType));
				}
			}
		if(document.GetElementsByTagName("ProtectionEligibility").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ProtectionEligibility")[0]))
			{
				this.ProtectionEligibility = (string)document.GetElementsByTagName("ProtectionEligibility")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ProtectionEligibilityType").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ProtectionEligibilityType")[0]))
			{
				this.ProtectionEligibilityType = (string)document.GetElementsByTagName("ProtectionEligibilityType")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *Option Number. Optional 
      */
	public partial class OptionTrackingDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string OptionNumberField;
		public string OptionNumber
		{
			get
			{
				return this.OptionNumberField;
			}
			set
			{
				this.OptionNumberField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string OptionQtyField;
		public string OptionQty
		{
			get
			{
				return this.OptionQtyField;
			}
			set
			{
				this.OptionQtyField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string OptionSelectField;
		public string OptionSelect
		{
			get
			{
				return this.OptionSelectField;
			}
			set
			{
				this.OptionSelectField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string OptionQtyDeltaField;
		public string OptionQtyDelta
		{
			get
			{
				return this.OptionQtyDeltaField;
			}
			set
			{
				this.OptionQtyDeltaField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string OptionAlertField;
		public string OptionAlert
		{
			get
			{
				return this.OptionAlertField;
			}
			set
			{
				this.OptionAlertField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string OptionCostField;
		public string OptionCost
		{
			get
			{
				return this.OptionCostField;
			}
			set
			{
				this.OptionCostField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public OptionTrackingDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(OptionNumber != null)
			{
				sb.Append("<ebl:OptionNumber>").Append(OptionNumber);
				sb.Append("</ebl:OptionNumber>");
			}
			if(OptionQty != null)
			{
				sb.Append("<ebl:OptionQty>").Append(OptionQty);
				sb.Append("</ebl:OptionQty>");
			}
			if(OptionSelect != null)
			{
				sb.Append("<ebl:OptionSelect>").Append(OptionSelect);
				sb.Append("</ebl:OptionSelect>");
			}
			if(OptionQtyDelta != null)
			{
				sb.Append("<ebl:OptionQtyDelta>").Append(OptionQtyDelta);
				sb.Append("</ebl:OptionQtyDelta>");
			}
			if(OptionAlert != null)
			{
				sb.Append("<ebl:OptionAlert>").Append(OptionAlert);
				sb.Append("</ebl:OptionAlert>");
			}
			if(OptionCost != null)
			{
				sb.Append("<ebl:OptionCost>").Append(OptionCost);
				sb.Append("</ebl:OptionCost>");
			}
			return sb.ToString();
		}
		public OptionTrackingDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("OptionNumber").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OptionNumber")[0]))
			{
				this.OptionNumber = (string)document.GetElementsByTagName("OptionNumber")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("OptionQty").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OptionQty")[0]))
			{
				this.OptionQty = (string)document.GetElementsByTagName("OptionQty")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("OptionSelect").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OptionSelect")[0]))
			{
				this.OptionSelect = (string)document.GetElementsByTagName("OptionSelect")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("OptionQtyDelta").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OptionQtyDelta")[0]))
			{
				this.OptionQtyDelta = (string)document.GetElementsByTagName("OptionQtyDelta")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("OptionAlert").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OptionAlert")[0]))
			{
				this.OptionAlert = (string)document.GetElementsByTagName("OptionAlert")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("OptionCost").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OptionCost")[0]))
			{
				this.OptionCost = (string)document.GetElementsByTagName("OptionCost")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *Item Number. Required 
      */
	public partial class ItemTrackingDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string ItemNumberField;
		public string ItemNumber
		{
			get
			{
				return this.ItemNumberField;
			}
			set
			{
				this.ItemNumberField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ItemQtyField;
		public string ItemQty
		{
			get
			{
				return this.ItemQtyField;
			}
			set
			{
				this.ItemQtyField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ItemQtyDeltaField;
		public string ItemQtyDelta
		{
			get
			{
				return this.ItemQtyDeltaField;
			}
			set
			{
				this.ItemQtyDeltaField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ItemAlertField;
		public string ItemAlert
		{
			get
			{
				return this.ItemAlertField;
			}
			set
			{
				this.ItemAlertField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ItemCostField;
		public string ItemCost
		{
			get
			{
				return this.ItemCostField;
			}
			set
			{
				this.ItemCostField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public ItemTrackingDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ItemNumber != null)
			{
				sb.Append("<ebl:ItemNumber>").Append(ItemNumber);
				sb.Append("</ebl:ItemNumber>");
			}
			if(ItemQty != null)
			{
				sb.Append("<ebl:ItemQty>").Append(ItemQty);
				sb.Append("</ebl:ItemQty>");
			}
			if(ItemQtyDelta != null)
			{
				sb.Append("<ebl:ItemQtyDelta>").Append(ItemQtyDelta);
				sb.Append("</ebl:ItemQtyDelta>");
			}
			if(ItemAlert != null)
			{
				sb.Append("<ebl:ItemAlert>").Append(ItemAlert);
				sb.Append("</ebl:ItemAlert>");
			}
			if(ItemCost != null)
			{
				sb.Append("<ebl:ItemCost>").Append(ItemCost);
				sb.Append("</ebl:ItemCost>");
			}
			return sb.ToString();
		}
		public ItemTrackingDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("ItemNumber").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ItemNumber")[0]))
			{
				this.ItemNumber = (string)document.GetElementsByTagName("ItemNumber")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ItemQty").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ItemQty")[0]))
			{
				this.ItemQty = (string)document.GetElementsByTagName("ItemQty")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ItemQtyDelta").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ItemQtyDelta")[0]))
			{
				this.ItemQtyDelta = (string)document.GetElementsByTagName("ItemQtyDelta")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ItemAlert").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ItemAlert")[0]))
			{
				this.ItemAlert = (string)document.GetElementsByTagName("ItemAlert")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ItemCost").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ItemCost")[0]))
			{
				this.ItemCost = (string)document.GetElementsByTagName("ItemCost")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *
      */
	public partial class ButtonSearchResultType	
	{

		/**
          *No Document Comments
		  */
		private string HostedButtonIDField;
		public string HostedButtonID
		{
			get
			{
				return this.HostedButtonIDField;
			}
			set
			{
				this.HostedButtonIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ButtonTypeField;
		public string ButtonType
		{
			get
			{
				return this.ButtonTypeField;
			}
			set
			{
				this.ButtonTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ItemNameField;
		public string ItemName
		{
			get
			{
				return this.ItemNameField;
			}
			set
			{
				this.ItemNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ModifyDateField;
		public string ModifyDate
		{
			get
			{
				return this.ModifyDateField;
			}
			set
			{
				this.ModifyDateField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public ButtonSearchResultType(){
		}


		public ButtonSearchResultType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("HostedButtonID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("HostedButtonID")[0]))
			{
				this.HostedButtonID = (string)document.GetElementsByTagName("HostedButtonID")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ButtonType").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ButtonType")[0]))
			{
				this.ButtonType = (string)document.GetElementsByTagName("ButtonType")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ItemName").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ItemName")[0]))
			{
				this.ItemName = (string)document.GetElementsByTagName("ItemName")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ModifyDate").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ModifyDate")[0]))
			{
				this.ModifyDate = (string)document.GetElementsByTagName("ModifyDate")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *Identifier of the transaction to reverse. Required Character
      *length and limitations: 17 single-byte alphanumeric
      *characters 
      */
	public partial class ReverseTransactionRequestDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string TransactionIDField;
		public string TransactionID
		{
			get
			{
				return this.TransactionIDField;
			}
			set
			{
				this.TransactionIDField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public ReverseTransactionRequestDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(TransactionID != null)
			{
				sb.Append("<ebl:TransactionID>").Append(TransactionID);
				sb.Append("</ebl:TransactionID>");
			}
			return sb.ToString();
		}
	}




	/**
      *Unique transaction identifier of the reversal transaction
      *created. Character length and limitations:17 single-byte
      *characters 
      */
	public partial class ReverseTransactionResponseDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string ReverseTransactionIDField;
		public string ReverseTransactionID
		{
			get
			{
				return this.ReverseTransactionIDField;
			}
			set
			{
				this.ReverseTransactionIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string StatusField;
		public string Status
		{
			get
			{
				return this.StatusField;
			}
			set
			{
				this.StatusField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public ReverseTransactionResponseDetailsType(){
		}


		public ReverseTransactionResponseDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("ReverseTransactionID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ReverseTransactionID")[0]))
			{
				this.ReverseTransactionID = (string)document.GetElementsByTagName("ReverseTransactionID")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Status").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Status")[0]))
			{
				this.Status = (string)document.GetElementsByTagName("Status")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *Details of incentive application on individual bucket. 
      */
	public partial class IncentiveInfoType	
	{

		/**
          *No Document Comments
		  */
		private string IncentiveCodeField;
		public string IncentiveCode
		{
			get
			{
				return this.IncentiveCodeField;
			}
			set
			{
				this.IncentiveCodeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<IncentiveApplyIndicationType> ApplyIndicationField = new List<IncentiveApplyIndicationType>();
		public List<IncentiveApplyIndicationType> ApplyIndication
		{
			get
			{
				return this.ApplyIndicationField;
			}
			set
			{
				this.ApplyIndicationField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public IncentiveInfoType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(IncentiveCode != null)
			{
				sb.Append("<ebl:IncentiveCode>").Append(IncentiveCode);
				sb.Append("</ebl:IncentiveCode>");
			}
			if(ApplyIndication != null)
			{
				for(int i = 0; i < ApplyIndication.Count; i++)
				{
					sb.Append("<ebl:ApplyIndication>");
					sb.Append(ApplyIndication[i].toXMLString());
					sb.Append("</ebl:ApplyIndication>");
				
				}
			}
			return sb.ToString();
		}
	}




	/**
      *Defines which bucket or item that the incentive should be
      *applied to. 
      */
	public partial class IncentiveApplyIndicationType	
	{

		/**
          *No Document Comments
		  */
		private string PaymentRequestIDField;
		public string PaymentRequestID
		{
			get
			{
				return this.PaymentRequestIDField;
			}
			set
			{
				this.PaymentRequestIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ItemIdField;
		public string ItemId
		{
			get
			{
				return this.ItemIdField;
			}
			set
			{
				this.ItemIdField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public IncentiveApplyIndicationType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(PaymentRequestID != null)
			{
				sb.Append("<ebl:PaymentRequestID>").Append(PaymentRequestID);
				sb.Append("</ebl:PaymentRequestID>");
			}
			if(ItemId != null)
			{
				sb.Append("<ebl:ItemId>").Append(ItemId);
				sb.Append("</ebl:ItemId>");
			}
			return sb.ToString();
		}
	}




	/**
      *Contains payment request information for each bucket in the
      *cart.  
      */
	public partial class PaymentRequestInfoType	
	{

		/**
          *No Document Comments
		  */
		private string TransactionIdField;
		public string TransactionId
		{
			get
			{
				return this.TransactionIdField;
			}
			set
			{
				this.TransactionIdField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PaymentRequestIDField;
		public string PaymentRequestID
		{
			get
			{
				return this.PaymentRequestIDField;
			}
			set
			{
				this.PaymentRequestIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ErrorType PaymentErrorField;
		public ErrorType PaymentError
		{
			get
			{
				return this.PaymentErrorField;
			}
			set
			{
				this.PaymentErrorField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public PaymentRequestInfoType(){
		}


		public PaymentRequestInfoType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("TransactionId").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TransactionId")[0]))
			{
				this.TransactionId = (string)document.GetElementsByTagName("TransactionId")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("PaymentRequestID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentRequestID")[0]))
			{
				this.PaymentRequestID = (string)document.GetElementsByTagName("PaymentRequestID")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("PaymentError").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentError")[0]))
				{
					nodeList = document.GetElementsByTagName("PaymentError");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.PaymentError =  new ErrorType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *E-mail address or secure merchant account ID of merchant to
      *associate with new external remember-me. 
      */
	public partial class ExternalRememberMeOwnerDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string ExternalRememberMeOwnerIDTypeField;
		public string ExternalRememberMeOwnerIDType
		{
			get
			{
				return this.ExternalRememberMeOwnerIDTypeField;
			}
			set
			{
				this.ExternalRememberMeOwnerIDTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ExternalRememberMeOwnerIDField;
		public string ExternalRememberMeOwnerID
		{
			get
			{
				return this.ExternalRememberMeOwnerIDField;
			}
			set
			{
				this.ExternalRememberMeOwnerIDField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public ExternalRememberMeOwnerDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ExternalRememberMeOwnerIDType != null)
			{
				sb.Append("<ebl:ExternalRememberMeOwnerIDType>").Append(ExternalRememberMeOwnerIDType);
				sb.Append("</ebl:ExternalRememberMeOwnerIDType>");
			}
			if(ExternalRememberMeOwnerID != null)
			{
				sb.Append("<ebl:ExternalRememberMeOwnerID>").Append(ExternalRememberMeOwnerID);
				sb.Append("</ebl:ExternalRememberMeOwnerID>");
			}
			return sb.ToString();
		}
	}




	/**
      *This element contains information that allows the merchant
      *to request to opt into external remember me on behalf of the
      *buyer or to request login bypass using external remember me.
      *
      */
	public partial class ExternalRememberMeOptInDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string ExternalRememberMeOptInField;
		public string ExternalRememberMeOptIn
		{
			get
			{
				return this.ExternalRememberMeOptInField;
			}
			set
			{
				this.ExternalRememberMeOptInField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ExternalRememberMeOwnerDetailsType ExternalRememberMeOwnerDetailsField;
		public ExternalRememberMeOwnerDetailsType ExternalRememberMeOwnerDetails
		{
			get
			{
				return this.ExternalRememberMeOwnerDetailsField;
			}
			set
			{
				this.ExternalRememberMeOwnerDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public ExternalRememberMeOptInDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ExternalRememberMeOptIn != null)
			{
				sb.Append("<ebl:ExternalRememberMeOptIn>").Append(ExternalRememberMeOptIn);
				sb.Append("</ebl:ExternalRememberMeOptIn>");
			}
			if(ExternalRememberMeOwnerDetails != null)
			{
				sb.Append("<ebl:ExternalRememberMeOwnerDetails>");
				sb.Append(ExternalRememberMeOwnerDetails.toXMLString());
				sb.Append("</ebl:ExternalRememberMeOwnerDetails>");
			}
			return sb.ToString();
		}
	}




	/**
      *An optional set of values related to flow-specific details. 
      */
	public partial class FlowControlDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string ErrorURLField;
		public string ErrorURL
		{
			get
			{
				return this.ErrorURLField;
			}
			set
			{
				this.ErrorURLField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string InContextReturnURLField;
		public string InContextReturnURL
		{
			get
			{
				return this.InContextReturnURLField;
			}
			set
			{
				this.InContextReturnURLField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public FlowControlDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ErrorURL != null)
			{
				sb.Append("<ebl:ErrorURL>").Append(ErrorURL);
				sb.Append("</ebl:ErrorURL>");
			}
			if(InContextReturnURL != null)
			{
				sb.Append("<ebl:InContextReturnURL>").Append(InContextReturnURL);
				sb.Append("</ebl:InContextReturnURL>");
			}
			return sb.ToString();
		}
	}




	/**
      *Response information resulting from opt-in operation or
      *current login bypass status. 
      */
	public partial class ExternalRememberMeStatusDetailsType	
	{

		/**
          *No Document Comments
		  */
		private int? ExternalRememberMeStatusField;
		public int? ExternalRememberMeStatus
		{
			get
			{
				return this.ExternalRememberMeStatusField;
			}
			set
			{
				this.ExternalRememberMeStatusField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ExternalRememberMeIDField;
		public string ExternalRememberMeID
		{
			get
			{
				return this.ExternalRememberMeIDField;
			}
			set
			{
				this.ExternalRememberMeIDField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public ExternalRememberMeStatusDetailsType(){
		}


		public ExternalRememberMeStatusDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("ExternalRememberMeStatus").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ExternalRememberMeStatus")[0]))
			{
				this.ExternalRememberMeStatus = System.Convert.ToInt32(document.GetElementsByTagName("ExternalRememberMeStatus")[0].InnerText);
			}
		}
		if(document.GetElementsByTagName("ExternalRememberMeID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ExternalRememberMeID")[0]))
			{
				this.ExternalRememberMeID = (string)document.GetElementsByTagName("ExternalRememberMeID")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *Contains elements that allows customization of display (user
      *interface) elements. 
      */
	public partial class DisplayControlDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string InContextPaymentButtonImageField;
		public string InContextPaymentButtonImage
		{
			get
			{
				return this.InContextPaymentButtonImageField;
			}
			set
			{
				this.InContextPaymentButtonImageField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DisplayControlDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(InContextPaymentButtonImage != null)
			{
				sb.Append("<ebl:InContextPaymentButtonImage>").Append(InContextPaymentButtonImage);
				sb.Append("</ebl:InContextPaymentButtonImage>");
			}
			return sb.ToString();
		}
	}




	/**
      *Contains elements that allow tracking for an external
      *partner. 
      */
	public partial class ExternalPartnerTrackingDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string ExternalPartnerSegmentIDField;
		public string ExternalPartnerSegmentID
		{
			get
			{
				return this.ExternalPartnerSegmentIDField;
			}
			set
			{
				this.ExternalPartnerSegmentIDField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public ExternalPartnerTrackingDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ExternalPartnerSegmentID != null)
			{
				sb.Append("<ebl:ExternalPartnerSegmentID>").Append(ExternalPartnerSegmentID);
				sb.Append("</ebl:ExternalPartnerSegmentID>");
			}
			return sb.ToString();
		}
	}




	/**
      *Store IDOptional Character length and limits: 50 single-byte
      *characters 
      */
	public partial class MerchantStoreDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string StoreIDField;
		public string StoreID
		{
			get
			{
				return this.StoreIDField;
			}
			set
			{
				this.StoreIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string TerminalIDField;
		public string TerminalID
		{
			get
			{
				return this.TerminalIDField;
			}
			set
			{
				this.TerminalIDField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public MerchantStoreDetailsType(string StoreID){
			this.StoreID = StoreID;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public MerchantStoreDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(StoreID != null)
			{
				sb.Append("<ebl:StoreID>").Append(StoreID);
				sb.Append("</ebl:StoreID>");
			}
			if(TerminalID != null)
			{
				sb.Append("<ebl:TerminalID>").Append(TerminalID);
				sb.Append("</ebl:TerminalID>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class AdditionalFeeType	
	{

		/**
          *No Document Comments
		  */
		private string TypeField;
		public string Type
		{
			get
			{
				return this.TypeField;
			}
			set
			{
				this.TypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType AmountField;
		public BasicAmountType Amount
		{
			get
			{
				return this.AmountField;
			}
			set
			{
				this.AmountField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public AdditionalFeeType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Type != null)
			{
				sb.Append("<ebl:Type>").Append(Type);
				sb.Append("</ebl:Type>");
			}
			if(Amount != null)
			{
				sb.Append("<ebl:Amount");
				sb.Append(Amount.toXMLString());
				sb.Append("</ebl:Amount>");
			}
			return sb.ToString();
		}
	}




	/**
      *Describes discount information 
      */
	public partial class DiscountType	
	{

		/**
          *No Document Comments
		  */
		private string NameField;
		public string Name
		{
			get
			{
				return this.NameField;
			}
			set
			{
				this.NameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string DescriptionField;
		public string Description
		{
			get
			{
				return this.DescriptionField;
			}
			set
			{
				this.DescriptionField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType AmountField;
		public BasicAmountType Amount
		{
			get
			{
				return this.AmountField;
			}
			set
			{
				this.AmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private RedeemedOfferType? RedeemedOfferTypeField;
		public RedeemedOfferType? RedeemedOfferType
		{
			get
			{
				return this.RedeemedOfferTypeField;
			}
			set
			{
				this.RedeemedOfferTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string RedeemedOfferIDField;
		public string RedeemedOfferID
		{
			get
			{
				return this.RedeemedOfferIDField;
			}
			set
			{
				this.RedeemedOfferIDField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public DiscountType(BasicAmountType Amount){
			this.Amount = Amount;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public DiscountType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Name != null)
			{
				sb.Append("<ebl:Name>").Append(Name);
				sb.Append("</ebl:Name>");
			}
			if(Description != null)
			{
				sb.Append("<ebl:Description>").Append(Description);
				sb.Append("</ebl:Description>");
			}
			if(Amount != null)
			{
				sb.Append("<ebl:Amount");
				sb.Append(Amount.toXMLString());
				sb.Append("</ebl:Amount>");
			}
			if(RedeemedOfferType != null)
			{
				sb.Append("<ebl:RedeemedOfferType>").Append(EnumUtils.getDescription(RedeemedOfferType));
				sb.Append("</ebl:RedeemedOfferType>");
			}
			if(RedeemedOfferID != null)
			{
				sb.Append("<ebl:RedeemedOfferID>").Append(RedeemedOfferID);
				sb.Append("</ebl:RedeemedOfferID>");
			}
			return sb.ToString();
		}
	}




	/**
      *Describes an individual item for an invoice. 
      */
	public partial class InvoiceItemType	
	{

		/**
          *No Document Comments
		  */
		private string NameField;
		public string Name
		{
			get
			{
				return this.NameField;
			}
			set
			{
				this.NameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string DescriptionField;
		public string Description
		{
			get
			{
				return this.DescriptionField;
			}
			set
			{
				this.DescriptionField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string EANField;
		public string EAN
		{
			get
			{
				return this.EANField;
			}
			set
			{
				this.EANField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string SKUField;
		public string SKU
		{
			get
			{
				return this.SKUField;
			}
			set
			{
				this.SKUField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ReturnPolicyIdentifierField;
		public string ReturnPolicyIdentifier
		{
			get
			{
				return this.ReturnPolicyIdentifierField;
			}
			set
			{
				this.ReturnPolicyIdentifierField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType PriceField;
		public BasicAmountType Price
		{
			get
			{
				return this.PriceField;
			}
			set
			{
				this.PriceField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType ItemPriceField;
		public BasicAmountType ItemPrice
		{
			get
			{
				return this.ItemPriceField;
			}
			set
			{
				this.ItemPriceField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private decimal? ItemCountField;
		public decimal? ItemCount
		{
			get
			{
				return this.ItemCountField;
			}
			set
			{
				this.ItemCountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private UnitOfMeasure? ItemCountUnitField;
		public UnitOfMeasure? ItemCountUnit
		{
			get
			{
				return this.ItemCountUnitField;
			}
			set
			{
				this.ItemCountUnitField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<DiscountType> DiscountField = new List<DiscountType>();
		public List<DiscountType> Discount
		{
			get
			{
				return this.DiscountField;
			}
			set
			{
				this.DiscountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private bool? TaxableField;
		public bool? Taxable
		{
			get
			{
				return this.TaxableField;
			}
			set
			{
				this.TaxableField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private decimal? TaxRateField;
		public decimal? TaxRate
		{
			get
			{
				return this.TaxRateField;
			}
			set
			{
				this.TaxRateField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<AdditionalFeeType> AdditionalFeesField = new List<AdditionalFeeType>();
		public List<AdditionalFeeType> AdditionalFees
		{
			get
			{
				return this.AdditionalFeesField;
			}
			set
			{
				this.AdditionalFeesField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private bool? ReimbursableField;
		public bool? Reimbursable
		{
			get
			{
				return this.ReimbursableField;
			}
			set
			{
				this.ReimbursableField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string MPNField;
		public string MPN
		{
			get
			{
				return this.MPNField;
			}
			set
			{
				this.MPNField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ISBNField;
		public string ISBN
		{
			get
			{
				return this.ISBNField;
			}
			set
			{
				this.ISBNField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PLUField;
		public string PLU
		{
			get
			{
				return this.PLUField;
			}
			set
			{
				this.PLUField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ModelNumberField;
		public string ModelNumber
		{
			get
			{
				return this.ModelNumberField;
			}
			set
			{
				this.ModelNumberField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string StyleNumberField;
		public string StyleNumber
		{
			get
			{
				return this.StyleNumberField;
			}
			set
			{
				this.StyleNumberField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public InvoiceItemType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Name != null)
			{
				sb.Append("<ebl:Name>").Append(Name);
				sb.Append("</ebl:Name>");
			}
			if(Description != null)
			{
				sb.Append("<ebl:Description>").Append(Description);
				sb.Append("</ebl:Description>");
			}
			if(EAN != null)
			{
				sb.Append("<ebl:EAN>").Append(EAN);
				sb.Append("</ebl:EAN>");
			}
			if(SKU != null)
			{
				sb.Append("<ebl:SKU>").Append(SKU);
				sb.Append("</ebl:SKU>");
			}
			if(ReturnPolicyIdentifier != null)
			{
				sb.Append("<ebl:ReturnPolicyIdentifier>").Append(ReturnPolicyIdentifier);
				sb.Append("</ebl:ReturnPolicyIdentifier>");
			}
			if(Price != null)
			{
				sb.Append("<ebl:Price");
				sb.Append(Price.toXMLString());
				sb.Append("</ebl:Price>");
			}
			if(ItemPrice != null)
			{
				sb.Append("<ebl:ItemPrice");
				sb.Append(ItemPrice.toXMLString());
				sb.Append("</ebl:ItemPrice>");
			}
			if(ItemCount != null)
			{
				sb.Append("<ebl:ItemCount>").Append(ItemCount);
				sb.Append("</ebl:ItemCount>");
			}
			if(ItemCountUnit != null)
			{
				sb.Append("<ebl:ItemCountUnit>").Append(EnumUtils.getDescription(ItemCountUnit));
				sb.Append("</ebl:ItemCountUnit>");
			}
			if(Discount != null)
			{
				for(int i = 0; i < Discount.Count; i++)
				{
					sb.Append("<ebl:Discount>");
					sb.Append(Discount[i].toXMLString());
					sb.Append("</ebl:Discount>");
				
				}
			}
			if(Taxable != null)
			{
				sb.Append("<ebl:Taxable>").Append(Taxable);
				sb.Append("</ebl:Taxable>");
			}
			if(TaxRate != null)
			{
				sb.Append("<ebl:TaxRate>").Append(TaxRate);
				sb.Append("</ebl:TaxRate>");
			}
			if(AdditionalFees != null)
			{
				for(int i = 0; i < AdditionalFees.Count; i++)
				{
					sb.Append("<ebl:AdditionalFees>");
					sb.Append(AdditionalFees[i].toXMLString());
					sb.Append("</ebl:AdditionalFees>");
				
				}
			}
			if(Reimbursable != null)
			{
				sb.Append("<ebl:Reimbursable>").Append(Reimbursable);
				sb.Append("</ebl:Reimbursable>");
			}
			if(MPN != null)
			{
				sb.Append("<ebl:MPN>").Append(MPN);
				sb.Append("</ebl:MPN>");
			}
			if(ISBN != null)
			{
				sb.Append("<ebl:ISBN>").Append(ISBN);
				sb.Append("</ebl:ISBN>");
			}
			if(PLU != null)
			{
				sb.Append("<ebl:PLU>").Append(PLU);
				sb.Append("</ebl:PLU>");
			}
			if(ModelNumber != null)
			{
				sb.Append("<ebl:ModelNumber>").Append(ModelNumber);
				sb.Append("</ebl:ModelNumber>");
			}
			if(StyleNumber != null)
			{
				sb.Append("<ebl:StyleNumber>").Append(StyleNumber);
				sb.Append("</ebl:StyleNumber>");
			}
			return sb.ToString();
		}
	}




	/**
      *Holds refunds payment status information 
      */
	public partial class RefundInfoType	
	{

		/**
          *No Document Comments
		  */
		private PaymentStatusCodeType? RefundStatusField;
		public PaymentStatusCodeType? RefundStatus
		{
			get
			{
				return this.RefundStatusField;
			}
			set
			{
				this.RefundStatusField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PendingStatusCodeType? PendingReasonField;
		public PendingStatusCodeType? PendingReason
		{
			get
			{
				return this.PendingReasonField;
			}
			set
			{
				this.PendingReasonField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public RefundInfoType(){
		}


		public RefundInfoType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("RefundStatus").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("RefundStatus")[0]))
				{
					this.RefundStatus = (PaymentStatusCodeType)EnumUtils.getValue(document.GetElementsByTagName("RefundStatus")[0].InnerText,typeof(PaymentStatusCodeType));
				}
			}
			if(document.GetElementsByTagName("PendingReason").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PendingReason")[0]))
				{
					this.PendingReason = (PendingStatusCodeType)EnumUtils.getValue(document.GetElementsByTagName("PendingReason")[0].InnerText,typeof(PendingStatusCodeType));
				}
			}
	
		}
		
	}




	/**
      *
      */
	public partial class EnhancedCheckoutDataType	
	{

		/**
	 	  * Default Constructor
	 	  */
	 	public EnhancedCheckoutDataType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class EnhancedPaymentDataType	
	{

		/**
	 	  * Default Constructor
	 	  */
	 	public EnhancedPaymentDataType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			return sb.ToString();
		}
		public EnhancedPaymentDataType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
	
		}
		
	}




	/**
      *
      */
	public partial class EnhancedItemDataType	
	{

		/**
	 	  * Default Constructor
	 	  */
	 	public EnhancedItemDataType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			return sb.ToString();
		}
		public EnhancedItemDataType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
	
		}
		
	}




	/**
      *
      */
	public partial class EnhancedPaymentInfoType	
	{

		/**
	 	  * Default Constructor
	 	  */
	 	public EnhancedPaymentInfoType(){
		}


		public EnhancedPaymentInfoType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
	
		}
		
	}




	/**
      *
      */
	public partial class EnhancedInitiateRecoupRequestDetailsType	
	{

		/**
	 	  * Default Constructor
	 	  */
	 	public EnhancedInitiateRecoupRequestDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class EnhancedCompleteRecoupRequestDetailsType	
	{

		/**
	 	  * Default Constructor
	 	  */
	 	public EnhancedCompleteRecoupRequestDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class EnhancedCompleteRecoupResponseDetailsType	
	{

		/**
	 	  * Default Constructor
	 	  */
	 	public EnhancedCompleteRecoupResponseDetailsType(){
		}


		public EnhancedCompleteRecoupResponseDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
	
		}
		
	}




	/**
      *
      */
	public partial class EnhancedCancelRecoupRequestDetailsType	
	{

		/**
	 	  * Default Constructor
	 	  */
	 	public EnhancedCancelRecoupRequestDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class EnhancedPayerInfoType	
	{

		/**
	 	  * Default Constructor
	 	  */
	 	public EnhancedPayerInfoType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			return sb.ToString();
		}
		public EnhancedPayerInfoType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
	
		}
		
	}




	/**
      *Installment Period. Optional 
      */
	public partial class InstallmentDetailsType	
	{

		/**
          *No Document Comments
		  */
		private BillingPeriodType? BillingPeriodField;
		public BillingPeriodType? BillingPeriod
		{
			get
			{
				return this.BillingPeriodField;
			}
			set
			{
				this.BillingPeriodField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? BillingFrequencyField;
		public int? BillingFrequency
		{
			get
			{
				return this.BillingFrequencyField;
			}
			set
			{
				this.BillingFrequencyField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? TotalBillingCyclesField;
		public int? TotalBillingCycles
		{
			get
			{
				return this.TotalBillingCyclesField;
			}
			set
			{
				this.TotalBillingCyclesField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string AmountField;
		public string Amount
		{
			get
			{
				return this.AmountField;
			}
			set
			{
				this.AmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ShippingAmountField;
		public string ShippingAmount
		{
			get
			{
				return this.ShippingAmountField;
			}
			set
			{
				this.ShippingAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string TaxAmountField;
		public string TaxAmount
		{
			get
			{
				return this.TaxAmountField;
			}
			set
			{
				this.TaxAmountField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public InstallmentDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(BillingPeriod != null)
			{
				sb.Append("<urn:BillingPeriod>").Append(EnumUtils.getDescription(BillingPeriod));
				sb.Append("</urn:BillingPeriod>");
			}
			if(BillingFrequency != null)
			{
				sb.Append("<urn:BillingFrequency>").Append(BillingFrequency);
				sb.Append("</urn:BillingFrequency>");
			}
			if(TotalBillingCycles != null)
			{
				sb.Append("<urn:TotalBillingCycles>").Append(TotalBillingCycles);
				sb.Append("</urn:TotalBillingCycles>");
			}
			if(Amount != null)
			{
				sb.Append("<urn:Amount>").Append(Amount);
				sb.Append("</urn:Amount>");
			}
			if(ShippingAmount != null)
			{
				sb.Append("<urn:ShippingAmount>").Append(ShippingAmount);
				sb.Append("</urn:ShippingAmount>");
			}
			if(TaxAmount != null)
			{
				sb.Append("<urn:TaxAmount>").Append(TaxAmount);
				sb.Append("</urn:TaxAmount>");
			}
			return sb.ToString();
		}
		public InstallmentDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("BillingPeriod").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillingPeriod")[0]))
				{
					this.BillingPeriod = (BillingPeriodType)EnumUtils.getValue(document.GetElementsByTagName("BillingPeriod")[0].InnerText,typeof(BillingPeriodType));
				}
			}
		if(document.GetElementsByTagName("BillingFrequency").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillingFrequency")[0]))
			{
				this.BillingFrequency = System.Convert.ToInt32(document.GetElementsByTagName("BillingFrequency")[0].InnerText);
			}
		}
		if(document.GetElementsByTagName("TotalBillingCycles").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TotalBillingCycles")[0]))
			{
				this.TotalBillingCycles = System.Convert.ToInt32(document.GetElementsByTagName("TotalBillingCycles")[0].InnerText);
			}
		}
		if(document.GetElementsByTagName("Amount").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Amount")[0]))
			{
				this.Amount = (string)document.GetElementsByTagName("Amount")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("ShippingAmount").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ShippingAmount")[0]))
			{
				this.ShippingAmount = (string)document.GetElementsByTagName("ShippingAmount")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("TaxAmount").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TaxAmount")[0]))
			{
				this.TaxAmount = (string)document.GetElementsByTagName("TaxAmount")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *Option Selection. Required Character length and limitations:
      *12 single-byte alphanumeric characters 
      */
	public partial class OptionSelectionDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string OptionSelectionField;
		public string OptionSelection
		{
			get
			{
				return this.OptionSelectionField;
			}
			set
			{
				this.OptionSelectionField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PriceField;
		public string Price
		{
			get
			{
				return this.PriceField;
			}
			set
			{
				this.PriceField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private OptionTypeListType? OptionTypeField;
		public OptionTypeListType? OptionType
		{
			get
			{
				return this.OptionTypeField;
			}
			set
			{
				this.OptionTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<InstallmentDetailsType> PaymentPeriodField = new List<InstallmentDetailsType>();
		public List<InstallmentDetailsType> PaymentPeriod
		{
			get
			{
				return this.PaymentPeriodField;
			}
			set
			{
				this.PaymentPeriodField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public OptionSelectionDetailsType(string OptionSelection){
			this.OptionSelection = OptionSelection;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public OptionSelectionDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(OptionSelection != null)
			{
				sb.Append("<urn:OptionSelection>").Append(OptionSelection);
				sb.Append("</urn:OptionSelection>");
			}
			if(Price != null)
			{
				sb.Append("<urn:Price>").Append(Price);
				sb.Append("</urn:Price>");
			}
			if(OptionType != null)
			{
				sb.Append("<urn:OptionType>").Append(EnumUtils.getDescription(OptionType));
				sb.Append("</urn:OptionType>");
			}
			if(PaymentPeriod != null)
			{
				for(int i = 0; i < PaymentPeriod.Count; i++)
				{
					sb.Append("<urn:PaymentPeriod>");
					sb.Append(PaymentPeriod[i].toXMLString());
					sb.Append("</urn:PaymentPeriod>");
				
				}
			}
			return sb.ToString();
		}
		public OptionSelectionDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("OptionSelection").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OptionSelection")[0]))
			{
				this.OptionSelection = (string)document.GetElementsByTagName("OptionSelection")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Price").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Price")[0]))
			{
				this.Price = (string)document.GetElementsByTagName("Price")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("OptionType").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OptionType")[0]))
				{
					this.OptionType = (OptionTypeListType)EnumUtils.getValue(document.GetElementsByTagName("OptionType")[0].InnerText,typeof(OptionTypeListType));
				}
			}
			if(document.GetElementsByTagName("PaymentPeriod").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentPeriod")[0]))
				{
					nodeList = document.GetElementsByTagName("PaymentPeriod");
					for(int i = 0; i < nodeList.Count; i++)
					{
						xmlString = DeserializationUtils.convertToXML(nodeList[i]);
						this.PaymentPeriod.Add(new InstallmentDetailsType(xmlString));
					}
				}
			}
	
		}
		
	}




	/**
      *Option Name. Optional 
      */
	public partial class OptionDetailsType	
	{

		/**
          *No Document Comments
		  */
		private string OptionNameField;
		public string OptionName
		{
			get
			{
				return this.OptionNameField;
			}
			set
			{
				this.OptionNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<OptionSelectionDetailsType> OptionSelectionDetailsField = new List<OptionSelectionDetailsType>();
		public List<OptionSelectionDetailsType> OptionSelectionDetails
		{
			get
			{
				return this.OptionSelectionDetailsField;
			}
			set
			{
				this.OptionSelectionDetailsField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public OptionDetailsType(string OptionName){
			this.OptionName = OptionName;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public OptionDetailsType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(OptionName != null)
			{
				sb.Append("<urn:OptionName>").Append(OptionName);
				sb.Append("</urn:OptionName>");
			}
			if(OptionSelectionDetails != null)
			{
				for(int i = 0; i < OptionSelectionDetails.Count; i++)
				{
					sb.Append("<urn:OptionSelectionDetails>");
					sb.Append(OptionSelectionDetails[i].toXMLString());
					sb.Append("</urn:OptionSelectionDetails>");
				
				}
			}
			return sb.ToString();
		}
		public OptionDetailsType(Object xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("OptionName").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OptionName")[0]))
			{
				this.OptionName = (string)document.GetElementsByTagName("OptionName")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("OptionSelectionDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OptionSelectionDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("OptionSelectionDetails");
					for(int i = 0; i < nodeList.Count; i++)
					{
						xmlString = DeserializationUtils.convertToXML(nodeList[i]);
						this.OptionSelectionDetails.Add(new OptionSelectionDetailsType(xmlString));
					}
				}
			}
	
		}
		
	}




	/**
      *
      */
	public partial class BMCreateButtonReq	
	{

		/**
          *No Document Comments
		  */
		private BMCreateButtonRequestType BMCreateButtonRequestField;
		public BMCreateButtonRequestType BMCreateButtonRequest
		{
			get
			{
				return this.BMCreateButtonRequestField;
			}
			set
			{
				this.BMCreateButtonRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public BMCreateButtonReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:BMCreateButtonReq>");
			if(BMCreateButtonRequest != null)
			{
				sb.Append("<urn:BMCreateButtonRequest>");
				sb.Append(BMCreateButtonRequest.toXMLString());
				sb.Append("</urn:BMCreateButtonRequest>");
			}
			sb.Append("</urn:BMCreateButtonReq>");
			return sb.ToString();
		}
	}




	/**
      *Type of Button to create.  Required Must be one of the
      *following: BUYNOW, CART, GIFTCERTIFICATE. SUBSCRIBE,
      *PAYMENTPLAN, AUTOBILLING, DONATE, VIEWCART or UNSUBSCRIBE  
      */
	public partial class BMCreateButtonRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private ButtonTypeType? ButtonTypeField;
		public ButtonTypeType? ButtonType
		{
			get
			{
				return this.ButtonTypeField;
			}
			set
			{
				this.ButtonTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ButtonCodeType? ButtonCodeField;
		public ButtonCodeType? ButtonCode
		{
			get
			{
				return this.ButtonCodeField;
			}
			set
			{
				this.ButtonCodeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ButtonSubTypeType? ButtonSubTypeField;
		public ButtonSubTypeType? ButtonSubType
		{
			get
			{
				return this.ButtonSubTypeField;
			}
			set
			{
				this.ButtonSubTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<string> ButtonVarField = new List<string>();
		public List<string> ButtonVar
		{
			get
			{
				return this.ButtonVarField;
			}
			set
			{
				this.ButtonVarField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<OptionDetailsType> OptionDetailsField = new List<OptionDetailsType>();
		public List<OptionDetailsType> OptionDetails
		{
			get
			{
				return this.OptionDetailsField;
			}
			set
			{
				this.OptionDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<string> TextBoxField = new List<string>();
		public List<string> TextBox
		{
			get
			{
				return this.TextBoxField;
			}
			set
			{
				this.TextBoxField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ButtonImageType? ButtonImageField;
		public ButtonImageType? ButtonImage
		{
			get
			{
				return this.ButtonImageField;
			}
			set
			{
				this.ButtonImageField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ButtonImageURLField;
		public string ButtonImageURL
		{
			get
			{
				return this.ButtonImageURLField;
			}
			set
			{
				this.ButtonImageURLField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BuyNowTextType? BuyNowTextField;
		public BuyNowTextType? BuyNowText
		{
			get
			{
				return this.BuyNowTextField;
			}
			set
			{
				this.BuyNowTextField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private SubscribeTextType? SubscribeTextField;
		public SubscribeTextType? SubscribeText
		{
			get
			{
				return this.SubscribeTextField;
			}
			set
			{
				this.SubscribeTextField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private CountryCodeType? ButtonCountryField;
		public CountryCodeType? ButtonCountry
		{
			get
			{
				return this.ButtonCountryField;
			}
			set
			{
				this.ButtonCountryField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ButtonLanguageField;
		public string ButtonLanguage
		{
			get
			{
				return this.ButtonLanguageField;
			}
			set
			{
				this.ButtonLanguageField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public BMCreateButtonRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(ButtonType != null)
			{
				sb.Append("<urn:ButtonType>").Append(EnumUtils.getDescription(ButtonType));
				sb.Append("</urn:ButtonType>");
			}
			if(ButtonCode != null)
			{
				sb.Append("<urn:ButtonCode>").Append(EnumUtils.getDescription(ButtonCode));
				sb.Append("</urn:ButtonCode>");
			}
			if(ButtonSubType != null)
			{
				sb.Append("<urn:ButtonSubType>").Append(EnumUtils.getDescription(ButtonSubType));
				sb.Append("</urn:ButtonSubType>");
			}
			if(ButtonVar != null)
			{
				for(int i = 0; i < ButtonVar.Count; i++)
				{
					sb.Append("<urn:ButtonVar>").Append(ButtonVar[i]);
					sb.Append("</urn:ButtonVar>");
				
				}
			}
			if(OptionDetails != null)
			{
				for(int i = 0; i < OptionDetails.Count; i++)
				{
					sb.Append("<urn:OptionDetails>");
					sb.Append(OptionDetails[i].toXMLString());
					sb.Append("</urn:OptionDetails>");
				
				}
			}
			if(TextBox != null)
			{
				for(int i = 0; i < TextBox.Count; i++)
				{
					sb.Append("<urn:TextBox>").Append(TextBox[i]);
					sb.Append("</urn:TextBox>");
				
				}
			}
			if(ButtonImage != null)
			{
				sb.Append("<urn:ButtonImage>").Append(EnumUtils.getDescription(ButtonImage));
				sb.Append("</urn:ButtonImage>");
			}
			if(ButtonImageURL != null)
			{
				sb.Append("<urn:ButtonImageURL>").Append(ButtonImageURL);
				sb.Append("</urn:ButtonImageURL>");
			}
			if(BuyNowText != null)
			{
				sb.Append("<urn:BuyNowText>").Append(EnumUtils.getDescription(BuyNowText));
				sb.Append("</urn:BuyNowText>");
			}
			if(SubscribeText != null)
			{
				sb.Append("<urn:SubscribeText>").Append(EnumUtils.getDescription(SubscribeText));
				sb.Append("</urn:SubscribeText>");
			}
			if(ButtonCountry != null)
			{
				sb.Append("<urn:ButtonCountry>").Append(EnumUtils.getDescription(ButtonCountry));
				sb.Append("</urn:ButtonCountry>");
			}
			if(ButtonLanguage != null)
			{
				sb.Append("<urn:ButtonLanguage>").Append(ButtonLanguage);
				sb.Append("</urn:ButtonLanguage>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class BMCreateButtonResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private string WebsiteField;
		public string Website
		{
			get
			{
				return this.WebsiteField;
			}
			set
			{
				this.WebsiteField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string EmailField;
		public string Email
		{
			get
			{
				return this.EmailField;
			}
			set
			{
				this.EmailField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string MobileField;
		public string Mobile
		{
			get
			{
				return this.MobileField;
			}
			set
			{
				this.MobileField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string HostedButtonIDField;
		public string HostedButtonID
		{
			get
			{
				return this.HostedButtonIDField;
			}
			set
			{
				this.HostedButtonIDField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public BMCreateButtonResponseType(){
		}


		public BMCreateButtonResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("Website").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Website")[0]))
			{
				this.Website = (string)document.GetElementsByTagName("Website")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Email").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Email")[0]))
			{
				this.Email = (string)document.GetElementsByTagName("Email")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Mobile").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Mobile")[0]))
			{
				this.Mobile = (string)document.GetElementsByTagName("Mobile")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("HostedButtonID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("HostedButtonID")[0]))
			{
				this.HostedButtonID = (string)document.GetElementsByTagName("HostedButtonID")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *
      */
	public partial class BMUpdateButtonReq	
	{

		/**
          *No Document Comments
		  */
		private BMUpdateButtonRequestType BMUpdateButtonRequestField;
		public BMUpdateButtonRequestType BMUpdateButtonRequest
		{
			get
			{
				return this.BMUpdateButtonRequestField;
			}
			set
			{
				this.BMUpdateButtonRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public BMUpdateButtonReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:BMUpdateButtonReq>");
			if(BMUpdateButtonRequest != null)
			{
				sb.Append("<urn:BMUpdateButtonRequest>");
				sb.Append(BMUpdateButtonRequest.toXMLString());
				sb.Append("</urn:BMUpdateButtonRequest>");
			}
			sb.Append("</urn:BMUpdateButtonReq>");
			return sb.ToString();
		}
	}




	/**
      *Hosted Button id of the button to update.  Required
      *Character length and limitations: 10 single-byte numeric
      *characters  
      */
	public partial class BMUpdateButtonRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private string HostedButtonIDField;
		public string HostedButtonID
		{
			get
			{
				return this.HostedButtonIDField;
			}
			set
			{
				this.HostedButtonIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ButtonTypeType? ButtonTypeField;
		public ButtonTypeType? ButtonType
		{
			get
			{
				return this.ButtonTypeField;
			}
			set
			{
				this.ButtonTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ButtonCodeType? ButtonCodeField;
		public ButtonCodeType? ButtonCode
		{
			get
			{
				return this.ButtonCodeField;
			}
			set
			{
				this.ButtonCodeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ButtonSubTypeType? ButtonSubTypeField;
		public ButtonSubTypeType? ButtonSubType
		{
			get
			{
				return this.ButtonSubTypeField;
			}
			set
			{
				this.ButtonSubTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<string> ButtonVarField = new List<string>();
		public List<string> ButtonVar
		{
			get
			{
				return this.ButtonVarField;
			}
			set
			{
				this.ButtonVarField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<OptionDetailsType> OptionDetailsField = new List<OptionDetailsType>();
		public List<OptionDetailsType> OptionDetails
		{
			get
			{
				return this.OptionDetailsField;
			}
			set
			{
				this.OptionDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<string> TextBoxField = new List<string>();
		public List<string> TextBox
		{
			get
			{
				return this.TextBoxField;
			}
			set
			{
				this.TextBoxField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ButtonImageType? ButtonImageField;
		public ButtonImageType? ButtonImage
		{
			get
			{
				return this.ButtonImageField;
			}
			set
			{
				this.ButtonImageField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ButtonImageURLField;
		public string ButtonImageURL
		{
			get
			{
				return this.ButtonImageURLField;
			}
			set
			{
				this.ButtonImageURLField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BuyNowTextType? BuyNowTextField;
		public BuyNowTextType? BuyNowText
		{
			get
			{
				return this.BuyNowTextField;
			}
			set
			{
				this.BuyNowTextField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private SubscribeTextType? SubscribeTextField;
		public SubscribeTextType? SubscribeText
		{
			get
			{
				return this.SubscribeTextField;
			}
			set
			{
				this.SubscribeTextField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private CountryCodeType? ButtonCountryField;
		public CountryCodeType? ButtonCountry
		{
			get
			{
				return this.ButtonCountryField;
			}
			set
			{
				this.ButtonCountryField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ButtonLanguageField;
		public string ButtonLanguage
		{
			get
			{
				return this.ButtonLanguageField;
			}
			set
			{
				this.ButtonLanguageField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public BMUpdateButtonRequestType(string HostedButtonID){
			this.HostedButtonID = HostedButtonID;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public BMUpdateButtonRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(HostedButtonID != null)
			{
				sb.Append("<urn:HostedButtonID>").Append(HostedButtonID);
				sb.Append("</urn:HostedButtonID>");
			}
			if(ButtonType != null)
			{
				sb.Append("<urn:ButtonType>").Append(EnumUtils.getDescription(ButtonType));
				sb.Append("</urn:ButtonType>");
			}
			if(ButtonCode != null)
			{
				sb.Append("<urn:ButtonCode>").Append(EnumUtils.getDescription(ButtonCode));
				sb.Append("</urn:ButtonCode>");
			}
			if(ButtonSubType != null)
			{
				sb.Append("<urn:ButtonSubType>").Append(EnumUtils.getDescription(ButtonSubType));
				sb.Append("</urn:ButtonSubType>");
			}
			if(ButtonVar != null)
			{
				for(int i = 0; i < ButtonVar.Count; i++)
				{
					sb.Append("<urn:ButtonVar>").Append(ButtonVar[i]);
					sb.Append("</urn:ButtonVar>");
				
				}
			}
			if(OptionDetails != null)
			{
				for(int i = 0; i < OptionDetails.Count; i++)
				{
					sb.Append("<urn:OptionDetails>");
					sb.Append(OptionDetails[i].toXMLString());
					sb.Append("</urn:OptionDetails>");
				
				}
			}
			if(TextBox != null)
			{
				for(int i = 0; i < TextBox.Count; i++)
				{
					sb.Append("<urn:TextBox>").Append(TextBox[i]);
					sb.Append("</urn:TextBox>");
				
				}
			}
			if(ButtonImage != null)
			{
				sb.Append("<urn:ButtonImage>").Append(EnumUtils.getDescription(ButtonImage));
				sb.Append("</urn:ButtonImage>");
			}
			if(ButtonImageURL != null)
			{
				sb.Append("<urn:ButtonImageURL>").Append(ButtonImageURL);
				sb.Append("</urn:ButtonImageURL>");
			}
			if(BuyNowText != null)
			{
				sb.Append("<urn:BuyNowText>").Append(EnumUtils.getDescription(BuyNowText));
				sb.Append("</urn:BuyNowText>");
			}
			if(SubscribeText != null)
			{
				sb.Append("<urn:SubscribeText>").Append(EnumUtils.getDescription(SubscribeText));
				sb.Append("</urn:SubscribeText>");
			}
			if(ButtonCountry != null)
			{
				sb.Append("<urn:ButtonCountry>").Append(EnumUtils.getDescription(ButtonCountry));
				sb.Append("</urn:ButtonCountry>");
			}
			if(ButtonLanguage != null)
			{
				sb.Append("<urn:ButtonLanguage>").Append(ButtonLanguage);
				sb.Append("</urn:ButtonLanguage>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class BMUpdateButtonResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private string WebsiteField;
		public string Website
		{
			get
			{
				return this.WebsiteField;
			}
			set
			{
				this.WebsiteField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string EmailField;
		public string Email
		{
			get
			{
				return this.EmailField;
			}
			set
			{
				this.EmailField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string MobileField;
		public string Mobile
		{
			get
			{
				return this.MobileField;
			}
			set
			{
				this.MobileField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string HostedButtonIDField;
		public string HostedButtonID
		{
			get
			{
				return this.HostedButtonIDField;
			}
			set
			{
				this.HostedButtonIDField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public BMUpdateButtonResponseType(){
		}


		public BMUpdateButtonResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("Website").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Website")[0]))
			{
				this.Website = (string)document.GetElementsByTagName("Website")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Email").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Email")[0]))
			{
				this.Email = (string)document.GetElementsByTagName("Email")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Mobile").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Mobile")[0]))
			{
				this.Mobile = (string)document.GetElementsByTagName("Mobile")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("HostedButtonID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("HostedButtonID")[0]))
			{
				this.HostedButtonID = (string)document.GetElementsByTagName("HostedButtonID")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *
      */
	public partial class BMManageButtonStatusReq	
	{

		/**
          *No Document Comments
		  */
		private BMManageButtonStatusRequestType BMManageButtonStatusRequestField;
		public BMManageButtonStatusRequestType BMManageButtonStatusRequest
		{
			get
			{
				return this.BMManageButtonStatusRequestField;
			}
			set
			{
				this.BMManageButtonStatusRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public BMManageButtonStatusReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:BMManageButtonStatusReq>");
			if(BMManageButtonStatusRequest != null)
			{
				sb.Append("<urn:BMManageButtonStatusRequest>");
				sb.Append(BMManageButtonStatusRequest.toXMLString());
				sb.Append("</urn:BMManageButtonStatusRequest>");
			}
			sb.Append("</urn:BMManageButtonStatusReq>");
			return sb.ToString();
		}
	}




	/**
      *Button ID of Hosted button.  Required Character length and
      *limitations: 10 single-byte numeric characters  
      */
	public partial class BMManageButtonStatusRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private string HostedButtonIDField;
		public string HostedButtonID
		{
			get
			{
				return this.HostedButtonIDField;
			}
			set
			{
				this.HostedButtonIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ButtonStatusType? ButtonStatusField;
		public ButtonStatusType? ButtonStatus
		{
			get
			{
				return this.ButtonStatusField;
			}
			set
			{
				this.ButtonStatusField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public BMManageButtonStatusRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(HostedButtonID != null)
			{
				sb.Append("<urn:HostedButtonID>").Append(HostedButtonID);
				sb.Append("</urn:HostedButtonID>");
			}
			if(ButtonStatus != null)
			{
				sb.Append("<urn:ButtonStatus>").Append(EnumUtils.getDescription(ButtonStatus));
				sb.Append("</urn:ButtonStatus>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class BMManageButtonStatusResponseType : AbstractResponseType	
	{

		/**
	 	  * Default Constructor
	 	  */
	 	public BMManageButtonStatusResponseType(){
		}


		public BMManageButtonStatusResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
	
		}
		
	}




	/**
      *
      */
	public partial class BMGetButtonDetailsReq	
	{

		/**
          *No Document Comments
		  */
		private BMGetButtonDetailsRequestType BMGetButtonDetailsRequestField;
		public BMGetButtonDetailsRequestType BMGetButtonDetailsRequest
		{
			get
			{
				return this.BMGetButtonDetailsRequestField;
			}
			set
			{
				this.BMGetButtonDetailsRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public BMGetButtonDetailsReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:BMGetButtonDetailsReq>");
			if(BMGetButtonDetailsRequest != null)
			{
				sb.Append("<urn:BMGetButtonDetailsRequest>");
				sb.Append(BMGetButtonDetailsRequest.toXMLString());
				sb.Append("</urn:BMGetButtonDetailsRequest>");
			}
			sb.Append("</urn:BMGetButtonDetailsReq>");
			return sb.ToString();
		}
	}




	/**
      *Button ID of button to return.  Required Character length
      *and limitations: 10 single-byte numeric characters  
      */
	public partial class BMGetButtonDetailsRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private string HostedButtonIDField;
		public string HostedButtonID
		{
			get
			{
				return this.HostedButtonIDField;
			}
			set
			{
				this.HostedButtonIDField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public BMGetButtonDetailsRequestType(string HostedButtonID){
			this.HostedButtonID = HostedButtonID;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public BMGetButtonDetailsRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(HostedButtonID != null)
			{
				sb.Append("<urn:HostedButtonID>").Append(HostedButtonID);
				sb.Append("</urn:HostedButtonID>");
			}
			return sb.ToString();
		}
	}




	/**
      *Type of button. One of the following: BUYNOW, CART,
      *GIFTCERTIFICATE. SUBSCRIBE, PAYMENTPLAN, AUTOBILLING,
      *DONATE, VIEWCART or UNSUBSCRIBE 
      */
	public partial class BMGetButtonDetailsResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private string WebsiteField;
		public string Website
		{
			get
			{
				return this.WebsiteField;
			}
			set
			{
				this.WebsiteField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string EmailField;
		public string Email
		{
			get
			{
				return this.EmailField;
			}
			set
			{
				this.EmailField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string MobileField;
		public string Mobile
		{
			get
			{
				return this.MobileField;
			}
			set
			{
				this.MobileField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string HostedButtonIDField;
		public string HostedButtonID
		{
			get
			{
				return this.HostedButtonIDField;
			}
			set
			{
				this.HostedButtonIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ButtonTypeType? ButtonTypeField;
		public ButtonTypeType? ButtonType
		{
			get
			{
				return this.ButtonTypeField;
			}
			set
			{
				this.ButtonTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ButtonCodeType? ButtonCodeField;
		public ButtonCodeType? ButtonCode
		{
			get
			{
				return this.ButtonCodeField;
			}
			set
			{
				this.ButtonCodeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ButtonSubTypeType? ButtonSubTypeField;
		public ButtonSubTypeType? ButtonSubType
		{
			get
			{
				return this.ButtonSubTypeField;
			}
			set
			{
				this.ButtonSubTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<string> ButtonVarField = new List<string>();
		public List<string> ButtonVar
		{
			get
			{
				return this.ButtonVarField;
			}
			set
			{
				this.ButtonVarField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<OptionDetailsType> OptionDetailsField = new List<OptionDetailsType>();
		public List<OptionDetailsType> OptionDetails
		{
			get
			{
				return this.OptionDetailsField;
			}
			set
			{
				this.OptionDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<string> TextBoxField = new List<string>();
		public List<string> TextBox
		{
			get
			{
				return this.TextBoxField;
			}
			set
			{
				this.TextBoxField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ButtonImageType? ButtonImageField;
		public ButtonImageType? ButtonImage
		{
			get
			{
				return this.ButtonImageField;
			}
			set
			{
				this.ButtonImageField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ButtonImageURLField;
		public string ButtonImageURL
		{
			get
			{
				return this.ButtonImageURLField;
			}
			set
			{
				this.ButtonImageURLField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BuyNowTextType? BuyNowTextField;
		public BuyNowTextType? BuyNowText
		{
			get
			{
				return this.BuyNowTextField;
			}
			set
			{
				this.BuyNowTextField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private SubscribeTextType? SubscribeTextField;
		public SubscribeTextType? SubscribeText
		{
			get
			{
				return this.SubscribeTextField;
			}
			set
			{
				this.SubscribeTextField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private CountryCodeType? ButtonCountryField;
		public CountryCodeType? ButtonCountry
		{
			get
			{
				return this.ButtonCountryField;
			}
			set
			{
				this.ButtonCountryField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ButtonLanguageField;
		public string ButtonLanguage
		{
			get
			{
				return this.ButtonLanguageField;
			}
			set
			{
				this.ButtonLanguageField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public BMGetButtonDetailsResponseType(){
		}


		public BMGetButtonDetailsResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("Website").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Website")[0]))
			{
				this.Website = (string)document.GetElementsByTagName("Website")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Email").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Email")[0]))
			{
				this.Email = (string)document.GetElementsByTagName("Email")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Mobile").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Mobile")[0]))
			{
				this.Mobile = (string)document.GetElementsByTagName("Mobile")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("HostedButtonID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("HostedButtonID")[0]))
			{
				this.HostedButtonID = (string)document.GetElementsByTagName("HostedButtonID")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("ButtonType").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ButtonType")[0]))
				{
					this.ButtonType = (ButtonTypeType)EnumUtils.getValue(document.GetElementsByTagName("ButtonType")[0].InnerText,typeof(ButtonTypeType));
				}
			}
			if(document.GetElementsByTagName("ButtonCode").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ButtonCode")[0]))
				{
					this.ButtonCode = (ButtonCodeType)EnumUtils.getValue(document.GetElementsByTagName("ButtonCode")[0].InnerText,typeof(ButtonCodeType));
				}
			}
			if(document.GetElementsByTagName("ButtonSubType").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ButtonSubType")[0]))
				{
					this.ButtonSubType = (ButtonSubTypeType)EnumUtils.getValue(document.GetElementsByTagName("ButtonSubType")[0].InnerText,typeof(ButtonSubTypeType));
				}
			}
			if(document.GetElementsByTagName("ButtonVar").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ButtonVar")[0]))
				{
					nodeList = document.GetElementsByTagName("ButtonVar");
					for(int i = 0; i < nodeList.Count; i++)
					{
						string value = nodeList[i].InnerText;
						this.ButtonVar.Add(value);
					}
				}
			}
			if(document.GetElementsByTagName("OptionDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OptionDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("OptionDetails");
					for(int i = 0; i < nodeList.Count; i++)
					{
						xmlString = DeserializationUtils.convertToXML(nodeList[i]);
						this.OptionDetails.Add(new OptionDetailsType(xmlString));
					}
				}
			}
			if(document.GetElementsByTagName("TextBox").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TextBox")[0]))
				{
					nodeList = document.GetElementsByTagName("TextBox");
					for(int i = 0; i < nodeList.Count; i++)
					{
						string value = nodeList[i].InnerText;
						this.TextBox.Add(value);
					}
				}
			}
			if(document.GetElementsByTagName("ButtonImage").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ButtonImage")[0]))
				{
					this.ButtonImage = (ButtonImageType)EnumUtils.getValue(document.GetElementsByTagName("ButtonImage")[0].InnerText,typeof(ButtonImageType));
				}
			}
		if(document.GetElementsByTagName("ButtonImageURL").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ButtonImageURL")[0]))
			{
				this.ButtonImageURL = (string)document.GetElementsByTagName("ButtonImageURL")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("BuyNowText").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BuyNowText")[0]))
				{
					this.BuyNowText = (BuyNowTextType)EnumUtils.getValue(document.GetElementsByTagName("BuyNowText")[0].InnerText,typeof(BuyNowTextType));
				}
			}
			if(document.GetElementsByTagName("SubscribeText").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SubscribeText")[0]))
				{
					this.SubscribeText = (SubscribeTextType)EnumUtils.getValue(document.GetElementsByTagName("SubscribeText")[0].InnerText,typeof(SubscribeTextType));
				}
			}
			if(document.GetElementsByTagName("ButtonCountry").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ButtonCountry")[0]))
				{
					this.ButtonCountry = (CountryCodeType)EnumUtils.getValue(document.GetElementsByTagName("ButtonCountry")[0].InnerText,typeof(CountryCodeType));
				}
			}
		if(document.GetElementsByTagName("ButtonLanguage").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ButtonLanguage")[0]))
			{
				this.ButtonLanguage = (string)document.GetElementsByTagName("ButtonLanguage")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *
      */
	public partial class BMSetInventoryReq	
	{

		/**
          *No Document Comments
		  */
		private BMSetInventoryRequestType BMSetInventoryRequestField;
		public BMSetInventoryRequestType BMSetInventoryRequest
		{
			get
			{
				return this.BMSetInventoryRequestField;
			}
			set
			{
				this.BMSetInventoryRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public BMSetInventoryReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:BMSetInventoryReq>");
			if(BMSetInventoryRequest != null)
			{
				sb.Append("<urn:BMSetInventoryRequest>");
				sb.Append(BMSetInventoryRequest.toXMLString());
				sb.Append("</urn:BMSetInventoryRequest>");
			}
			sb.Append("</urn:BMSetInventoryReq>");
			return sb.ToString();
		}
	}




	/**
      *Hosted Button ID of button you wish to change.  Required
      *Character length and limitations: 10 single-byte numeric
      *characters  
      */
	public partial class BMSetInventoryRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private string HostedButtonIDField;
		public string HostedButtonID
		{
			get
			{
				return this.HostedButtonIDField;
			}
			set
			{
				this.HostedButtonIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string TrackInvField;
		public string TrackInv
		{
			get
			{
				return this.TrackInvField;
			}
			set
			{
				this.TrackInvField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string TrackPnlField;
		public string TrackPnl
		{
			get
			{
				return this.TrackPnlField;
			}
			set
			{
				this.TrackPnlField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ItemTrackingDetailsType ItemTrackingDetailsField;
		public ItemTrackingDetailsType ItemTrackingDetails
		{
			get
			{
				return this.ItemTrackingDetailsField;
			}
			set
			{
				this.ItemTrackingDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string OptionIndexField;
		public string OptionIndex
		{
			get
			{
				return this.OptionIndexField;
			}
			set
			{
				this.OptionIndexField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<OptionTrackingDetailsType> OptionTrackingDetailsField = new List<OptionTrackingDetailsType>();
		public List<OptionTrackingDetailsType> OptionTrackingDetails
		{
			get
			{
				return this.OptionTrackingDetailsField;
			}
			set
			{
				this.OptionTrackingDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string SoldoutURLField;
		public string SoldoutURL
		{
			get
			{
				return this.SoldoutURLField;
			}
			set
			{
				this.SoldoutURLField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ReuseDigitalDownloadKeysField;
		public string ReuseDigitalDownloadKeys
		{
			get
			{
				return this.ReuseDigitalDownloadKeysField;
			}
			set
			{
				this.ReuseDigitalDownloadKeysField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string AppendDigitalDownloadKeysField;
		public string AppendDigitalDownloadKeys
		{
			get
			{
				return this.AppendDigitalDownloadKeysField;
			}
			set
			{
				this.AppendDigitalDownloadKeysField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<string> DigitalDownloadKeysField = new List<string>();
		public List<string> DigitalDownloadKeys
		{
			get
			{
				return this.DigitalDownloadKeysField;
			}
			set
			{
				this.DigitalDownloadKeysField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public BMSetInventoryRequestType(string HostedButtonID, string TrackInv, string TrackPnl){
			this.HostedButtonID = HostedButtonID;
			this.TrackInv = TrackInv;
			this.TrackPnl = TrackPnl;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public BMSetInventoryRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(HostedButtonID != null)
			{
				sb.Append("<urn:HostedButtonID>").Append(HostedButtonID);
				sb.Append("</urn:HostedButtonID>");
			}
			if(TrackInv != null)
			{
				sb.Append("<urn:TrackInv>").Append(TrackInv);
				sb.Append("</urn:TrackInv>");
			}
			if(TrackPnl != null)
			{
				sb.Append("<urn:TrackPnl>").Append(TrackPnl);
				sb.Append("</urn:TrackPnl>");
			}
			if(ItemTrackingDetails != null)
			{
				sb.Append("<ebl:ItemTrackingDetails>");
				sb.Append(ItemTrackingDetails.toXMLString());
				sb.Append("</ebl:ItemTrackingDetails>");
			}
			if(OptionIndex != null)
			{
				sb.Append("<urn:OptionIndex>").Append(OptionIndex);
				sb.Append("</urn:OptionIndex>");
			}
			if(OptionTrackingDetails != null)
			{
				for(int i = 0; i < OptionTrackingDetails.Count; i++)
				{
					sb.Append("<ebl:OptionTrackingDetails>");
					sb.Append(OptionTrackingDetails[i].toXMLString());
					sb.Append("</ebl:OptionTrackingDetails>");
				
				}
			}
			if(SoldoutURL != null)
			{
				sb.Append("<urn:SoldoutURL>").Append(SoldoutURL);
				sb.Append("</urn:SoldoutURL>");
			}
			if(ReuseDigitalDownloadKeys != null)
			{
				sb.Append("<urn:ReuseDigitalDownloadKeys>").Append(ReuseDigitalDownloadKeys);
				sb.Append("</urn:ReuseDigitalDownloadKeys>");
			}
			if(AppendDigitalDownloadKeys != null)
			{
				sb.Append("<urn:AppendDigitalDownloadKeys>").Append(AppendDigitalDownloadKeys);
				sb.Append("</urn:AppendDigitalDownloadKeys>");
			}
			if(DigitalDownloadKeys != null)
			{
				for(int i = 0; i < DigitalDownloadKeys.Count; i++)
				{
					sb.Append("<urn:DigitalDownloadKeys>").Append(DigitalDownloadKeys[i]);
					sb.Append("</urn:DigitalDownloadKeys>");
				
				}
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class BMSetInventoryResponseType : AbstractResponseType	
	{

		/**
	 	  * Default Constructor
	 	  */
	 	public BMSetInventoryResponseType(){
		}


		public BMSetInventoryResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
	
		}
		
	}




	/**
      *
      */
	public partial class BMGetInventoryReq	
	{

		/**
          *No Document Comments
		  */
		private BMGetInventoryRequestType BMGetInventoryRequestField;
		public BMGetInventoryRequestType BMGetInventoryRequest
		{
			get
			{
				return this.BMGetInventoryRequestField;
			}
			set
			{
				this.BMGetInventoryRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public BMGetInventoryReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:BMGetInventoryReq>");
			if(BMGetInventoryRequest != null)
			{
				sb.Append("<urn:BMGetInventoryRequest>");
				sb.Append(BMGetInventoryRequest.toXMLString());
				sb.Append("</urn:BMGetInventoryRequest>");
			}
			sb.Append("</urn:BMGetInventoryReq>");
			return sb.ToString();
		}
	}




	/**
      *Hosted Button ID of the button to return inventory for. 
      *Required Character length and limitations: 10 single-byte
      *numeric characters  
      */
	public partial class BMGetInventoryRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private string HostedButtonIDField;
		public string HostedButtonID
		{
			get
			{
				return this.HostedButtonIDField;
			}
			set
			{
				this.HostedButtonIDField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public BMGetInventoryRequestType(string HostedButtonID){
			this.HostedButtonID = HostedButtonID;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public BMGetInventoryRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(HostedButtonID != null)
			{
				sb.Append("<urn:HostedButtonID>").Append(HostedButtonID);
				sb.Append("</urn:HostedButtonID>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class BMGetInventoryResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private string HostedButtonIDField;
		public string HostedButtonID
		{
			get
			{
				return this.HostedButtonIDField;
			}
			set
			{
				this.HostedButtonIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string TrackInvField;
		public string TrackInv
		{
			get
			{
				return this.TrackInvField;
			}
			set
			{
				this.TrackInvField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string TrackPnlField;
		public string TrackPnl
		{
			get
			{
				return this.TrackPnlField;
			}
			set
			{
				this.TrackPnlField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ItemTrackingDetailsType ItemTrackingDetailsField;
		public ItemTrackingDetailsType ItemTrackingDetails
		{
			get
			{
				return this.ItemTrackingDetailsField;
			}
			set
			{
				this.ItemTrackingDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string OptionIndexField;
		public string OptionIndex
		{
			get
			{
				return this.OptionIndexField;
			}
			set
			{
				this.OptionIndexField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string OptionNameField;
		public string OptionName
		{
			get
			{
				return this.OptionNameField;
			}
			set
			{
				this.OptionNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<OptionTrackingDetailsType> OptionTrackingDetailsField = new List<OptionTrackingDetailsType>();
		public List<OptionTrackingDetailsType> OptionTrackingDetails
		{
			get
			{
				return this.OptionTrackingDetailsField;
			}
			set
			{
				this.OptionTrackingDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string SoldoutURLField;
		public string SoldoutURL
		{
			get
			{
				return this.SoldoutURLField;
			}
			set
			{
				this.SoldoutURLField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<string> DigitalDownloadKeysField = new List<string>();
		public List<string> DigitalDownloadKeys
		{
			get
			{
				return this.DigitalDownloadKeysField;
			}
			set
			{
				this.DigitalDownloadKeysField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public BMGetInventoryResponseType(){
		}


		public BMGetInventoryResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("HostedButtonID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("HostedButtonID")[0]))
			{
				this.HostedButtonID = (string)document.GetElementsByTagName("HostedButtonID")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("TrackInv").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TrackInv")[0]))
			{
				this.TrackInv = (string)document.GetElementsByTagName("TrackInv")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("TrackPnl").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TrackPnl")[0]))
			{
				this.TrackPnl = (string)document.GetElementsByTagName("TrackPnl")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("ItemTrackingDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ItemTrackingDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("ItemTrackingDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.ItemTrackingDetails =  new ItemTrackingDetailsType(xmlString);
				}
			}
		if(document.GetElementsByTagName("OptionIndex").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OptionIndex")[0]))
			{
				this.OptionIndex = (string)document.GetElementsByTagName("OptionIndex")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("OptionName").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OptionName")[0]))
			{
				this.OptionName = (string)document.GetElementsByTagName("OptionName")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("OptionTrackingDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("OptionTrackingDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("OptionTrackingDetails");
					for(int i = 0; i < nodeList.Count; i++)
					{
						xmlString = DeserializationUtils.convertToXML(nodeList[i]);
						this.OptionTrackingDetails.Add(new OptionTrackingDetailsType(xmlString));
					}
				}
			}
		if(document.GetElementsByTagName("SoldoutURL").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("SoldoutURL")[0]))
			{
				this.SoldoutURL = (string)document.GetElementsByTagName("SoldoutURL")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("DigitalDownloadKeys").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("DigitalDownloadKeys")[0]))
				{
					nodeList = document.GetElementsByTagName("DigitalDownloadKeys");
					for(int i = 0; i < nodeList.Count; i++)
					{
						string value = nodeList[i].InnerText;
						this.DigitalDownloadKeys.Add(value);
					}
				}
			}
	
		}
		
	}




	/**
      *
      */
	public partial class BMButtonSearchReq	
	{

		/**
          *No Document Comments
		  */
		private BMButtonSearchRequestType BMButtonSearchRequestField;
		public BMButtonSearchRequestType BMButtonSearchRequest
		{
			get
			{
				return this.BMButtonSearchRequestField;
			}
			set
			{
				this.BMButtonSearchRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public BMButtonSearchReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:BMButtonSearchReq>");
			if(BMButtonSearchRequest != null)
			{
				sb.Append("<urn:BMButtonSearchRequest>");
				sb.Append(BMButtonSearchRequest.toXMLString());
				sb.Append("</urn:BMButtonSearchRequest>");
			}
			sb.Append("</urn:BMButtonSearchReq>");
			return sb.ToString();
		}
	}




	/**
      *The earliest transaction date at which to start the search.
      *No wildcards are allowed. Required 
      */
	public partial class BMButtonSearchRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private string StartDateField;
		public string StartDate
		{
			get
			{
				return this.StartDateField;
			}
			set
			{
				this.StartDateField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string EndDateField;
		public string EndDate
		{
			get
			{
				return this.EndDateField;
			}
			set
			{
				this.EndDateField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public BMButtonSearchRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(StartDate != null)
			{
				sb.Append("<urn:StartDate>").Append(StartDate);
				sb.Append("</urn:StartDate>");
			}
			if(EndDate != null)
			{
				sb.Append("<urn:EndDate>").Append(EndDate);
				sb.Append("</urn:EndDate>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class BMButtonSearchResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private List<ButtonSearchResultType> ButtonSearchResultField = new List<ButtonSearchResultType>();
		public List<ButtonSearchResultType> ButtonSearchResult
		{
			get
			{
				return this.ButtonSearchResultField;
			}
			set
			{
				this.ButtonSearchResultField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public BMButtonSearchResponseType(){
		}


		public BMButtonSearchResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("ButtonSearchResult").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ButtonSearchResult")[0]))
				{
					nodeList = document.GetElementsByTagName("ButtonSearchResult");
					for(int i = 0; i < nodeList.Count; i++)
					{
						xmlString = DeserializationUtils.convertToXML(nodeList[i]);
						this.ButtonSearchResult.Add(new ButtonSearchResultType(xmlString));
					}
				}
			}
	
		}
		
	}




	/**
      *
      */
	public partial class RefundTransactionReq	
	{

		/**
          *No Document Comments
		  */
		private RefundTransactionRequestType RefundTransactionRequestField;
		public RefundTransactionRequestType RefundTransactionRequest
		{
			get
			{
				return this.RefundTransactionRequestField;
			}
			set
			{
				this.RefundTransactionRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public RefundTransactionReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:RefundTransactionReq>");
			if(RefundTransactionRequest != null)
			{
				sb.Append("<urn:RefundTransactionRequest>");
				sb.Append(RefundTransactionRequest.toXMLString());
				sb.Append("</urn:RefundTransactionRequest>");
			}
			sb.Append("</urn:RefundTransactionReq>");
			return sb.ToString();
		}
	}




	/**
      *Unique identifier of the transaction you are refunding.
      *Required Character length and limitations: 17 single-byte
      *alphanumeric characters 
      */
	public partial class RefundTransactionRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private string TransactionIDField;
		public string TransactionID
		{
			get
			{
				return this.TransactionIDField;
			}
			set
			{
				this.TransactionIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string InvoiceIDField;
		public string InvoiceID
		{
			get
			{
				return this.InvoiceIDField;
			}
			set
			{
				this.InvoiceIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private RefundType? RefundTypeField;
		public RefundType? RefundType
		{
			get
			{
				return this.RefundTypeField;
			}
			set
			{
				this.RefundTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType AmountField;
		public BasicAmountType Amount
		{
			get
			{
				return this.AmountField;
			}
			set
			{
				this.AmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string MemoField;
		public string Memo
		{
			get
			{
				return this.MemoField;
			}
			set
			{
				this.MemoField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string RetryUntilField;
		public string RetryUntil
		{
			get
			{
				return this.RetryUntilField;
			}
			set
			{
				this.RetryUntilField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private RefundSourceCodeType? RefundSourceField;
		public RefundSourceCodeType? RefundSource
		{
			get
			{
				return this.RefundSourceField;
			}
			set
			{
				this.RefundSourceField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private bool? RefundAdviceField;
		public bool? RefundAdvice
		{
			get
			{
				return this.RefundAdviceField;
			}
			set
			{
				this.RefundAdviceField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private MerchantStoreDetailsType MerchantStoreDetailsField;
		public MerchantStoreDetailsType MerchantStoreDetails
		{
			get
			{
				return this.MerchantStoreDetailsField;
			}
			set
			{
				this.MerchantStoreDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<InvoiceItemType> RefundItemDetailsField = new List<InvoiceItemType>();
		public List<InvoiceItemType> RefundItemDetails
		{
			get
			{
				return this.RefundItemDetailsField;
			}
			set
			{
				this.RefundItemDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string MsgSubIDField;
		public string MsgSubID
		{
			get
			{
				return this.MsgSubIDField;
			}
			set
			{
				this.MsgSubIDField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public RefundTransactionRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(TransactionID != null)
			{
				sb.Append("<urn:TransactionID>").Append(TransactionID);
				sb.Append("</urn:TransactionID>");
			}
			if(InvoiceID != null)
			{
				sb.Append("<urn:InvoiceID>").Append(InvoiceID);
				sb.Append("</urn:InvoiceID>");
			}
			if(RefundType != null)
			{
				sb.Append("<urn:RefundType>").Append(EnumUtils.getDescription(RefundType));
				sb.Append("</urn:RefundType>");
			}
			if(Amount != null)
			{
				sb.Append("<urn:Amount");
				sb.Append(Amount.toXMLString());
				sb.Append("</urn:Amount>");
			}
			if(Memo != null)
			{
				sb.Append("<urn:Memo>").Append(Memo);
				sb.Append("</urn:Memo>");
			}
			if(RetryUntil != null)
			{
				sb.Append("<urn:RetryUntil>").Append(RetryUntil);
				sb.Append("</urn:RetryUntil>");
			}
			if(RefundSource != null)
			{
				sb.Append("<urn:RefundSource>").Append(EnumUtils.getDescription(RefundSource));
				sb.Append("</urn:RefundSource>");
			}
			if(RefundAdvice != null)
			{
				sb.Append("<urn:RefundAdvice>").Append(RefundAdvice);
				sb.Append("</urn:RefundAdvice>");
			}
			if(MerchantStoreDetails != null)
			{
				sb.Append("<ebl:MerchantStoreDetails>");
				sb.Append(MerchantStoreDetails.toXMLString());
				sb.Append("</ebl:MerchantStoreDetails>");
			}
			if(RefundItemDetails != null)
			{
				for(int i = 0; i < RefundItemDetails.Count; i++)
				{
					sb.Append("<ebl:RefundItemDetails>");
					sb.Append(RefundItemDetails[i].toXMLString());
					sb.Append("</ebl:RefundItemDetails>");
				
				}
			}
			if(MsgSubID != null)
			{
				sb.Append("<urn:MsgSubID>").Append(MsgSubID);
				sb.Append("</urn:MsgSubID>");
			}
			return sb.ToString();
		}
	}




	/**
      *Unique transaction ID of the refund. Character length and
      *limitations:17 single-byte characters 
      */
	public partial class RefundTransactionResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private string RefundTransactionIDField;
		public string RefundTransactionID
		{
			get
			{
				return this.RefundTransactionIDField;
			}
			set
			{
				this.RefundTransactionIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType NetRefundAmountField;
		public BasicAmountType NetRefundAmount
		{
			get
			{
				return this.NetRefundAmountField;
			}
			set
			{
				this.NetRefundAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType FeeRefundAmountField;
		public BasicAmountType FeeRefundAmount
		{
			get
			{
				return this.FeeRefundAmountField;
			}
			set
			{
				this.FeeRefundAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType GrossRefundAmountField;
		public BasicAmountType GrossRefundAmount
		{
			get
			{
				return this.GrossRefundAmountField;
			}
			set
			{
				this.GrossRefundAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType TotalRefundedAmountField;
		public BasicAmountType TotalRefundedAmount
		{
			get
			{
				return this.TotalRefundedAmountField;
			}
			set
			{
				this.TotalRefundedAmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private RefundInfoType RefundInfoField;
		public RefundInfoType RefundInfo
		{
			get
			{
				return this.RefundInfoField;
			}
			set
			{
				this.RefundInfoField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ReceiptDataField;
		public string ReceiptData
		{
			get
			{
				return this.ReceiptDataField;
			}
			set
			{
				this.ReceiptDataField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string MsgSubIDField;
		public string MsgSubID
		{
			get
			{
				return this.MsgSubIDField;
			}
			set
			{
				this.MsgSubIDField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public RefundTransactionResponseType(){
		}


		public RefundTransactionResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("RefundTransactionID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("RefundTransactionID")[0]))
			{
				this.RefundTransactionID = (string)document.GetElementsByTagName("RefundTransactionID")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("NetRefundAmount").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("NetRefundAmount")[0]))
				{
					nodeList = document.GetElementsByTagName("NetRefundAmount");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.NetRefundAmount =  new BasicAmountType(xmlString);
				}
			}
			if(document.GetElementsByTagName("FeeRefundAmount").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("FeeRefundAmount")[0]))
				{
					nodeList = document.GetElementsByTagName("FeeRefundAmount");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.FeeRefundAmount =  new BasicAmountType(xmlString);
				}
			}
			if(document.GetElementsByTagName("GrossRefundAmount").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GrossRefundAmount")[0]))
				{
					nodeList = document.GetElementsByTagName("GrossRefundAmount");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.GrossRefundAmount =  new BasicAmountType(xmlString);
				}
			}
			if(document.GetElementsByTagName("TotalRefundedAmount").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TotalRefundedAmount")[0]))
				{
					nodeList = document.GetElementsByTagName("TotalRefundedAmount");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.TotalRefundedAmount =  new BasicAmountType(xmlString);
				}
			}
			if(document.GetElementsByTagName("RefundInfo").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("RefundInfo")[0]))
				{
					nodeList = document.GetElementsByTagName("RefundInfo");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.RefundInfo =  new RefundInfoType(xmlString);
				}
			}
		if(document.GetElementsByTagName("ReceiptData").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ReceiptData")[0]))
			{
				this.ReceiptData = (string)document.GetElementsByTagName("ReceiptData")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("MsgSubID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("MsgSubID")[0]))
			{
				this.MsgSubID = (string)document.GetElementsByTagName("MsgSubID")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *
      */
	public partial class InitiateRecoupReq	
	{

		/**
          *No Document Comments
		  */
		private InitiateRecoupRequestType InitiateRecoupRequestField;
		public InitiateRecoupRequestType InitiateRecoupRequest
		{
			get
			{
				return this.InitiateRecoupRequestField;
			}
			set
			{
				this.InitiateRecoupRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public InitiateRecoupReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:InitiateRecoupReq>");
			if(InitiateRecoupRequest != null)
			{
				sb.Append("<urn:InitiateRecoupRequest>");
				sb.Append(InitiateRecoupRequest.toXMLString());
				sb.Append("</urn:InitiateRecoupRequest>");
			}
			sb.Append("</urn:InitiateRecoupReq>");
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class InitiateRecoupRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private EnhancedInitiateRecoupRequestDetailsType EnhancedInitiateRecoupRequestDetailsField;
		public EnhancedInitiateRecoupRequestDetailsType EnhancedInitiateRecoupRequestDetails
		{
			get
			{
				return this.EnhancedInitiateRecoupRequestDetailsField;
			}
			set
			{
				this.EnhancedInitiateRecoupRequestDetailsField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public InitiateRecoupRequestType(EnhancedInitiateRecoupRequestDetailsType EnhancedInitiateRecoupRequestDetails){
			this.EnhancedInitiateRecoupRequestDetails = EnhancedInitiateRecoupRequestDetails;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public InitiateRecoupRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(EnhancedInitiateRecoupRequestDetails != null)
			{
				sb.Append("<ed:EnhancedInitiateRecoupRequestDetails>");
				sb.Append(EnhancedInitiateRecoupRequestDetails.toXMLString());
				sb.Append("</ed:EnhancedInitiateRecoupRequestDetails>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class InitiateRecoupResponseType : AbstractResponseType	
	{

		/**
	 	  * Default Constructor
	 	  */
	 	public InitiateRecoupResponseType(){
		}


		public InitiateRecoupResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
	
		}
		
	}




	/**
      *
      */
	public partial class CompleteRecoupReq	
	{

		/**
          *No Document Comments
		  */
		private CompleteRecoupRequestType CompleteRecoupRequestField;
		public CompleteRecoupRequestType CompleteRecoupRequest
		{
			get
			{
				return this.CompleteRecoupRequestField;
			}
			set
			{
				this.CompleteRecoupRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public CompleteRecoupReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:CompleteRecoupReq>");
			if(CompleteRecoupRequest != null)
			{
				sb.Append("<urn:CompleteRecoupRequest>");
				sb.Append(CompleteRecoupRequest.toXMLString());
				sb.Append("</urn:CompleteRecoupRequest>");
			}
			sb.Append("</urn:CompleteRecoupReq>");
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class CompleteRecoupRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private EnhancedCompleteRecoupRequestDetailsType EnhancedCompleteRecoupRequestDetailsField;
		public EnhancedCompleteRecoupRequestDetailsType EnhancedCompleteRecoupRequestDetails
		{
			get
			{
				return this.EnhancedCompleteRecoupRequestDetailsField;
			}
			set
			{
				this.EnhancedCompleteRecoupRequestDetailsField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public CompleteRecoupRequestType(EnhancedCompleteRecoupRequestDetailsType EnhancedCompleteRecoupRequestDetails){
			this.EnhancedCompleteRecoupRequestDetails = EnhancedCompleteRecoupRequestDetails;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public CompleteRecoupRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(EnhancedCompleteRecoupRequestDetails != null)
			{
				sb.Append("<ed:EnhancedCompleteRecoupRequestDetails>");
				sb.Append(EnhancedCompleteRecoupRequestDetails.toXMLString());
				sb.Append("</ed:EnhancedCompleteRecoupRequestDetails>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class CompleteRecoupResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private EnhancedCompleteRecoupResponseDetailsType EnhancedCompleteRecoupResponseDetailsField;
		public EnhancedCompleteRecoupResponseDetailsType EnhancedCompleteRecoupResponseDetails
		{
			get
			{
				return this.EnhancedCompleteRecoupResponseDetailsField;
			}
			set
			{
				this.EnhancedCompleteRecoupResponseDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public CompleteRecoupResponseType(){
		}


		public CompleteRecoupResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("EnhancedCompleteRecoupResponseDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("EnhancedCompleteRecoupResponseDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("EnhancedCompleteRecoupResponseDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.EnhancedCompleteRecoupResponseDetails =  new EnhancedCompleteRecoupResponseDetailsType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *
      */
	public partial class CancelRecoupReq	
	{

		/**
          *No Document Comments
		  */
		private CancelRecoupRequestType CancelRecoupRequestField;
		public CancelRecoupRequestType CancelRecoupRequest
		{
			get
			{
				return this.CancelRecoupRequestField;
			}
			set
			{
				this.CancelRecoupRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public CancelRecoupReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:CancelRecoupReq>");
			if(CancelRecoupRequest != null)
			{
				sb.Append("<urn:CancelRecoupRequest>");
				sb.Append(CancelRecoupRequest.toXMLString());
				sb.Append("</urn:CancelRecoupRequest>");
			}
			sb.Append("</urn:CancelRecoupReq>");
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class CancelRecoupRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private EnhancedCancelRecoupRequestDetailsType EnhancedCancelRecoupRequestDetailsField;
		public EnhancedCancelRecoupRequestDetailsType EnhancedCancelRecoupRequestDetails
		{
			get
			{
				return this.EnhancedCancelRecoupRequestDetailsField;
			}
			set
			{
				this.EnhancedCancelRecoupRequestDetailsField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public CancelRecoupRequestType(EnhancedCancelRecoupRequestDetailsType EnhancedCancelRecoupRequestDetails){
			this.EnhancedCancelRecoupRequestDetails = EnhancedCancelRecoupRequestDetails;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public CancelRecoupRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(EnhancedCancelRecoupRequestDetails != null)
			{
				sb.Append("<ed:EnhancedCancelRecoupRequestDetails>");
				sb.Append(EnhancedCancelRecoupRequestDetails.toXMLString());
				sb.Append("</ed:EnhancedCancelRecoupRequestDetails>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class CancelRecoupResponseType : AbstractResponseType	
	{

		/**
	 	  * Default Constructor
	 	  */
	 	public CancelRecoupResponseType(){
		}


		public CancelRecoupResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
	
		}
		
	}




	/**
      *
      */
	public partial class GetTransactionDetailsReq	
	{

		/**
          *No Document Comments
		  */
		private GetTransactionDetailsRequestType GetTransactionDetailsRequestField;
		public GetTransactionDetailsRequestType GetTransactionDetailsRequest
		{
			get
			{
				return this.GetTransactionDetailsRequestField;
			}
			set
			{
				this.GetTransactionDetailsRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public GetTransactionDetailsReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:GetTransactionDetailsReq>");
			if(GetTransactionDetailsRequest != null)
			{
				sb.Append("<urn:GetTransactionDetailsRequest>");
				sb.Append(GetTransactionDetailsRequest.toXMLString());
				sb.Append("</urn:GetTransactionDetailsRequest>");
			}
			sb.Append("</urn:GetTransactionDetailsReq>");
			return sb.ToString();
		}
	}




	/**
      *Unique identifier of a transaction. RequiredThe details for
      *some kinds of transactions cannot be retrieved with
      *GetTransactionDetailsRequest. You cannot obtain details of
      *bank transfer withdrawals, for example. Character length and
      *limitations: 17 single-byte alphanumeric characters
      */
	public partial class GetTransactionDetailsRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private string TransactionIDField;
		public string TransactionID
		{
			get
			{
				return this.TransactionIDField;
			}
			set
			{
				this.TransactionIDField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public GetTransactionDetailsRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(TransactionID != null)
			{
				sb.Append("<urn:TransactionID>").Append(TransactionID);
				sb.Append("</urn:TransactionID>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class GetTransactionDetailsResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private PaymentTransactionType PaymentTransactionDetailsField;
		public PaymentTransactionType PaymentTransactionDetails
		{
			get
			{
				return this.PaymentTransactionDetailsField;
			}
			set
			{
				this.PaymentTransactionDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ThreeDSecureInfoType ThreeDSecureDetailsField;
		public ThreeDSecureInfoType ThreeDSecureDetails
		{
			get
			{
				return this.ThreeDSecureDetailsField;
			}
			set
			{
				this.ThreeDSecureDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public GetTransactionDetailsResponseType(){
		}


		public GetTransactionDetailsResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("PaymentTransactionDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentTransactionDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("PaymentTransactionDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.PaymentTransactionDetails =  new PaymentTransactionType(xmlString);
				}
			}
			if(document.GetElementsByTagName("ThreeDSecureDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ThreeDSecureDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("ThreeDSecureDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.ThreeDSecureDetails =  new ThreeDSecureInfoType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *
      */
	public partial class BillUserReq	
	{

		/**
          *No Document Comments
		  */
		private BillUserRequestType BillUserRequestField;
		public BillUserRequestType BillUserRequest
		{
			get
			{
				return this.BillUserRequestField;
			}
			set
			{
				this.BillUserRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public BillUserReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:BillUserReq>");
			if(BillUserRequest != null)
			{
				sb.Append("<urn:BillUserRequest>");
				sb.Append(BillUserRequest.toXMLString());
				sb.Append("</urn:BillUserRequest>");
			}
			sb.Append("</urn:BillUserReq>");
			return sb.ToString();
		}
	}




	/**
      *This flag indicates that the response should include
      *FMFDetails 
      */
	public partial class BillUserRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private MerchantPullPaymentType MerchantPullPaymentDetailsField;
		public MerchantPullPaymentType MerchantPullPaymentDetails
		{
			get
			{
				return this.MerchantPullPaymentDetailsField;
			}
			set
			{
				this.MerchantPullPaymentDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? ReturnFMFDetailsField;
		public int? ReturnFMFDetails
		{
			get
			{
				return this.ReturnFMFDetailsField;
			}
			set
			{
				this.ReturnFMFDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public BillUserRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(MerchantPullPaymentDetails != null)
			{
				sb.Append("<ebl:MerchantPullPaymentDetails>");
				sb.Append(MerchantPullPaymentDetails.toXMLString());
				sb.Append("</ebl:MerchantPullPaymentDetails>");
			}
			if(ReturnFMFDetails != null)
			{
				sb.Append("<urn:ReturnFMFDetails>").Append(ReturnFMFDetails);
				sb.Append("</urn:ReturnFMFDetails>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class BillUserResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private MerchantPullPaymentResponseType BillUserResponseDetailsField;
		public MerchantPullPaymentResponseType BillUserResponseDetails
		{
			get
			{
				return this.BillUserResponseDetailsField;
			}
			set
			{
				this.BillUserResponseDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private FMFDetailsType FMFDetailsField;
		public FMFDetailsType FMFDetails
		{
			get
			{
				return this.FMFDetailsField;
			}
			set
			{
				this.FMFDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public BillUserResponseType(){
		}


		public BillUserResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("BillUserResponseDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillUserResponseDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("BillUserResponseDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.BillUserResponseDetails =  new MerchantPullPaymentResponseType(xmlString);
				}
			}
			if(document.GetElementsByTagName("FMFDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("FMFDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("FMFDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.FMFDetails =  new FMFDetailsType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *
      */
	public partial class TransactionSearchReq	
	{

		/**
          *No Document Comments
		  */
		private TransactionSearchRequestType TransactionSearchRequestField;
		public TransactionSearchRequestType TransactionSearchRequest
		{
			get
			{
				return this.TransactionSearchRequestField;
			}
			set
			{
				this.TransactionSearchRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public TransactionSearchReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:TransactionSearchReq>");
			if(TransactionSearchRequest != null)
			{
				sb.Append("<urn:TransactionSearchRequest>");
				sb.Append(TransactionSearchRequest.toXMLString());
				sb.Append("</urn:TransactionSearchRequest>");
			}
			sb.Append("</urn:TransactionSearchReq>");
			return sb.ToString();
		}
	}




	/**
      *The earliest transaction date at which to start the search.
      *No wildcards are allowed. Required
      */
	public partial class TransactionSearchRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private string StartDateField;
		public string StartDate
		{
			get
			{
				return this.StartDateField;
			}
			set
			{
				this.StartDateField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string EndDateField;
		public string EndDate
		{
			get
			{
				return this.EndDateField;
			}
			set
			{
				this.EndDateField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PayerField;
		public string Payer
		{
			get
			{
				return this.PayerField;
			}
			set
			{
				this.PayerField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ReceiverField;
		public string Receiver
		{
			get
			{
				return this.ReceiverField;
			}
			set
			{
				this.ReceiverField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ReceiptIDField;
		public string ReceiptID
		{
			get
			{
				return this.ReceiptIDField;
			}
			set
			{
				this.ReceiptIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string TransactionIDField;
		public string TransactionID
		{
			get
			{
				return this.TransactionIDField;
			}
			set
			{
				this.TransactionIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ProfileIDField;
		public string ProfileID
		{
			get
			{
				return this.ProfileIDField;
			}
			set
			{
				this.ProfileIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PersonNameType PayerNameField;
		public PersonNameType PayerName
		{
			get
			{
				return this.PayerNameField;
			}
			set
			{
				this.PayerNameField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string AuctionItemNumberField;
		public string AuctionItemNumber
		{
			get
			{
				return this.AuctionItemNumberField;
			}
			set
			{
				this.AuctionItemNumberField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string InvoiceIDField;
		public string InvoiceID
		{
			get
			{
				return this.InvoiceIDField;
			}
			set
			{
				this.InvoiceIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CardNumberField;
		public string CardNumber
		{
			get
			{
				return this.CardNumberField;
			}
			set
			{
				this.CardNumberField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PaymentTransactionClassCodeType? TransactionClassField;
		public PaymentTransactionClassCodeType? TransactionClass
		{
			get
			{
				return this.TransactionClassField;
			}
			set
			{
				this.TransactionClassField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType AmountField;
		public BasicAmountType Amount
		{
			get
			{
				return this.AmountField;
			}
			set
			{
				this.AmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private CurrencyCodeType? CurrencyCodeField;
		public CurrencyCodeType? CurrencyCode
		{
			get
			{
				return this.CurrencyCodeField;
			}
			set
			{
				this.CurrencyCodeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PaymentTransactionStatusCodeType? StatusField;
		public PaymentTransactionStatusCodeType? Status
		{
			get
			{
				return this.StatusField;
			}
			set
			{
				this.StatusField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public TransactionSearchRequestType(string StartDate){
			this.StartDate = StartDate;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public TransactionSearchRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(StartDate != null)
			{
				sb.Append("<urn:StartDate>").Append(StartDate);
				sb.Append("</urn:StartDate>");
			}
			if(EndDate != null)
			{
				sb.Append("<urn:EndDate>").Append(EndDate);
				sb.Append("</urn:EndDate>");
			}
			if(Payer != null)
			{
				sb.Append("<urn:Payer>").Append(Payer);
				sb.Append("</urn:Payer>");
			}
			if(Receiver != null)
			{
				sb.Append("<urn:Receiver>").Append(Receiver);
				sb.Append("</urn:Receiver>");
			}
			if(ReceiptID != null)
			{
				sb.Append("<urn:ReceiptID>").Append(ReceiptID);
				sb.Append("</urn:ReceiptID>");
			}
			if(TransactionID != null)
			{
				sb.Append("<urn:TransactionID>").Append(TransactionID);
				sb.Append("</urn:TransactionID>");
			}
			if(ProfileID != null)
			{
				sb.Append("<urn:ProfileID>").Append(ProfileID);
				sb.Append("</urn:ProfileID>");
			}
			if(PayerName != null)
			{
				sb.Append("<urn:PayerName>");
				sb.Append(PayerName.toXMLString());
				sb.Append("</urn:PayerName>");
			}
			if(AuctionItemNumber != null)
			{
				sb.Append("<urn:AuctionItemNumber>").Append(AuctionItemNumber);
				sb.Append("</urn:AuctionItemNumber>");
			}
			if(InvoiceID != null)
			{
				sb.Append("<urn:InvoiceID>").Append(InvoiceID);
				sb.Append("</urn:InvoiceID>");
			}
			if(CardNumber != null)
			{
				sb.Append("<urn:CardNumber>").Append(CardNumber);
				sb.Append("</urn:CardNumber>");
			}
			if(TransactionClass != null)
			{
				sb.Append("<urn:TransactionClass>").Append(EnumUtils.getDescription(TransactionClass));
				sb.Append("</urn:TransactionClass>");
			}
			if(Amount != null)
			{
				sb.Append("<urn:Amount");
				sb.Append(Amount.toXMLString());
				sb.Append("</urn:Amount>");
			}
			if(CurrencyCode != null)
			{
				sb.Append("<urn:CurrencyCode>").Append(EnumUtils.getDescription(CurrencyCode));
				sb.Append("</urn:CurrencyCode>");
			}
			if(Status != null)
			{
				sb.Append("<urn:Status>").Append(EnumUtils.getDescription(Status));
				sb.Append("</urn:Status>");
			}
			return sb.ToString();
		}
	}




	/**
      *Results of a Transaction Search.
      */
	public partial class TransactionSearchResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private List<PaymentTransactionSearchResultType> PaymentTransactionsField = new List<PaymentTransactionSearchResultType>();
		public List<PaymentTransactionSearchResultType> PaymentTransactions
		{
			get
			{
				return this.PaymentTransactionsField;
			}
			set
			{
				this.PaymentTransactionsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public TransactionSearchResponseType(){
		}


		public TransactionSearchResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("PaymentTransactions").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentTransactions")[0]))
				{
					nodeList = document.GetElementsByTagName("PaymentTransactions");
					for(int i = 0; i < nodeList.Count; i++)
					{
						xmlString = DeserializationUtils.convertToXML(nodeList[i]);
						this.PaymentTransactions.Add(new PaymentTransactionSearchResultType(xmlString));
					}
				}
			}
	
		}
		
	}




	/**
      *
      */
	public partial class MassPayReq	
	{

		/**
          *No Document Comments
		  */
		private MassPayRequestType MassPayRequestField;
		public MassPayRequestType MassPayRequest
		{
			get
			{
				return this.MassPayRequestField;
			}
			set
			{
				this.MassPayRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public MassPayReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:MassPayReq>");
			if(MassPayRequest != null)
			{
				sb.Append("<urn:MassPayRequest>");
				sb.Append(MassPayRequest.toXMLString());
				sb.Append("</urn:MassPayRequest>");
			}
			sb.Append("</urn:MassPayReq>");
			return sb.ToString();
		}
	}




	/**
      *Subject line of the email sent to all recipients. This
      *subject is not contained in the input file; you must create
      *it with your application. Optional Character length and
      *limitations: 255 single-byte alphanumeric characters 
      */
	public partial class MassPayRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private string EmailSubjectField;
		public string EmailSubject
		{
			get
			{
				return this.EmailSubjectField;
			}
			set
			{
				this.EmailSubjectField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ReceiverInfoCodeType? ReceiverTypeField;
		public ReceiverInfoCodeType? ReceiverType
		{
			get
			{
				return this.ReceiverTypeField;
			}
			set
			{
				this.ReceiverTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ButtonSourceField;
		public string ButtonSource
		{
			get
			{
				return this.ButtonSourceField;
			}
			set
			{
				this.ButtonSourceField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<MassPayRequestItemType> MassPayItemField = new List<MassPayRequestItemType>();
		public List<MassPayRequestItemType> MassPayItem
		{
			get
			{
				return this.MassPayItemField;
			}
			set
			{
				this.MassPayItemField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public MassPayRequestType(List<MassPayRequestItemType> MassPayItem){
			this.MassPayItem = MassPayItem;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public MassPayRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(EmailSubject != null)
			{
				sb.Append("<urn:EmailSubject>").Append(EmailSubject);
				sb.Append("</urn:EmailSubject>");
			}
			if(ReceiverType != null)
			{
				sb.Append("<urn:ReceiverType>").Append(EnumUtils.getDescription(ReceiverType));
				sb.Append("</urn:ReceiverType>");
			}
			if(ButtonSource != null)
			{
				sb.Append("<urn:ButtonSource>").Append(ButtonSource);
				sb.Append("</urn:ButtonSource>");
			}
			if(MassPayItem != null)
			{
				for(int i = 0; i < MassPayItem.Count; i++)
				{
					sb.Append("<urn:MassPayItem>");
					sb.Append(MassPayItem[i].toXMLString());
					sb.Append("</urn:MassPayItem>");
				
				}
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class MassPayResponseType : AbstractResponseType	
	{

		/**
	 	  * Default Constructor
	 	  */
	 	public MassPayResponseType(){
		}


		public MassPayResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
	
		}
		
	}




	/**
      *MassPayRequestItemType 
      */
	public partial class MassPayRequestItemType	
	{

		/**
          *No Document Comments
		  */
		private string ReceiverEmailField;
		public string ReceiverEmail
		{
			get
			{
				return this.ReceiverEmailField;
			}
			set
			{
				this.ReceiverEmailField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ReceiverPhoneField;
		public string ReceiverPhone
		{
			get
			{
				return this.ReceiverPhoneField;
			}
			set
			{
				this.ReceiverPhoneField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ReceiverIDField;
		public string ReceiverID
		{
			get
			{
				return this.ReceiverIDField;
			}
			set
			{
				this.ReceiverIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType AmountField;
		public BasicAmountType Amount
		{
			get
			{
				return this.AmountField;
			}
			set
			{
				this.AmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string UniqueIdField;
		public string UniqueId
		{
			get
			{
				return this.UniqueIdField;
			}
			set
			{
				this.UniqueIdField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string NoteField;
		public string Note
		{
			get
			{
				return this.NoteField;
			}
			set
			{
				this.NoteField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public MassPayRequestItemType(BasicAmountType Amount){
			this.Amount = Amount;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public MassPayRequestItemType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ReceiverEmail != null)
			{
				sb.Append("<urn:ReceiverEmail>").Append(ReceiverEmail);
				sb.Append("</urn:ReceiverEmail>");
			}
			if(ReceiverPhone != null)
			{
				sb.Append("<urn:ReceiverPhone>").Append(ReceiverPhone);
				sb.Append("</urn:ReceiverPhone>");
			}
			if(ReceiverID != null)
			{
				sb.Append("<urn:ReceiverID>").Append(ReceiverID);
				sb.Append("</urn:ReceiverID>");
			}
			if(Amount != null)
			{
				sb.Append("<urn:Amount");
				sb.Append(Amount.toXMLString());
				sb.Append("</urn:Amount>");
			}
			if(UniqueId != null)
			{
				sb.Append("<urn:UniqueId>").Append(UniqueId);
				sb.Append("</urn:UniqueId>");
			}
			if(Note != null)
			{
				sb.Append("<urn:Note>").Append(Note);
				sb.Append("</urn:Note>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class BillAgreementUpdateReq	
	{

		/**
          *No Document Comments
		  */
		private BAUpdateRequestType BAUpdateRequestField;
		public BAUpdateRequestType BAUpdateRequest
		{
			get
			{
				return this.BAUpdateRequestField;
			}
			set
			{
				this.BAUpdateRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public BillAgreementUpdateReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:BillAgreementUpdateReq>");
			if(BAUpdateRequest != null)
			{
				sb.Append("<urn:BAUpdateRequest>");
				sb.Append(BAUpdateRequest.toXMLString());
				sb.Append("</urn:BAUpdateRequest>");
			}
			sb.Append("</urn:BillAgreementUpdateReq>");
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class BAUpdateRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private string ReferenceIDField;
		public string ReferenceID
		{
			get
			{
				return this.ReferenceIDField;
			}
			set
			{
				this.ReferenceIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string BillingAgreementDescriptionField;
		public string BillingAgreementDescription
		{
			get
			{
				return this.BillingAgreementDescriptionField;
			}
			set
			{
				this.BillingAgreementDescriptionField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private MerchantPullStatusCodeType? BillingAgreementStatusField;
		public MerchantPullStatusCodeType? BillingAgreementStatus
		{
			get
			{
				return this.BillingAgreementStatusField;
			}
			set
			{
				this.BillingAgreementStatusField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string BillingAgreementCustomField;
		public string BillingAgreementCustom
		{
			get
			{
				return this.BillingAgreementCustomField;
			}
			set
			{
				this.BillingAgreementCustomField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public BAUpdateRequestType(string ReferenceID){
			this.ReferenceID = ReferenceID;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public BAUpdateRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(ReferenceID != null)
			{
				sb.Append("<urn:ReferenceID>").Append(ReferenceID);
				sb.Append("</urn:ReferenceID>");
			}
			if(BillingAgreementDescription != null)
			{
				sb.Append("<urn:BillingAgreementDescription>").Append(BillingAgreementDescription);
				sb.Append("</urn:BillingAgreementDescription>");
			}
			if(BillingAgreementStatus != null)
			{
				sb.Append("<urn:BillingAgreementStatus>").Append(EnumUtils.getDescription(BillingAgreementStatus));
				sb.Append("</urn:BillingAgreementStatus>");
			}
			if(BillingAgreementCustom != null)
			{
				sb.Append("<urn:BillingAgreementCustom>").Append(BillingAgreementCustom);
				sb.Append("</urn:BillingAgreementCustom>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class BAUpdateResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private BAUpdateResponseDetailsType BAUpdateResponseDetailsField;
		public BAUpdateResponseDetailsType BAUpdateResponseDetails
		{
			get
			{
				return this.BAUpdateResponseDetailsField;
			}
			set
			{
				this.BAUpdateResponseDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public BAUpdateResponseType(){
		}


		public BAUpdateResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("BAUpdateResponseDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BAUpdateResponseDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("BAUpdateResponseDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.BAUpdateResponseDetails =  new BAUpdateResponseDetailsType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *
      */
	public partial class AddressVerifyReq	
	{

		/**
          *No Document Comments
		  */
		private AddressVerifyRequestType AddressVerifyRequestField;
		public AddressVerifyRequestType AddressVerifyRequest
		{
			get
			{
				return this.AddressVerifyRequestField;
			}
			set
			{
				this.AddressVerifyRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public AddressVerifyReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:AddressVerifyReq>");
			if(AddressVerifyRequest != null)
			{
				sb.Append("<urn:AddressVerifyRequest>");
				sb.Append(AddressVerifyRequest.toXMLString());
				sb.Append("</urn:AddressVerifyRequest>");
			}
			sb.Append("</urn:AddressVerifyReq>");
			return sb.ToString();
		}
	}




	/**
      *Email address of buyer to be verified. Required Maximum
      *string length: 255 single-byte characters Input mask: ?@?.??
      *
      */
	public partial class AddressVerifyRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private string EmailField;
		public string Email
		{
			get
			{
				return this.EmailField;
			}
			set
			{
				this.EmailField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string StreetField;
		public string Street
		{
			get
			{
				return this.StreetField;
			}
			set
			{
				this.StreetField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string ZipField;
		public string Zip
		{
			get
			{
				return this.ZipField;
			}
			set
			{
				this.ZipField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public AddressVerifyRequestType(string Email, string Street, string Zip){
			this.Email = Email;
			this.Street = Street;
			this.Zip = Zip;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public AddressVerifyRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(Email != null)
			{
				sb.Append("<urn:Email>").Append(Email);
				sb.Append("</urn:Email>");
			}
			if(Street != null)
			{
				sb.Append("<urn:Street>").Append(Street);
				sb.Append("</urn:Street>");
			}
			if(Zip != null)
			{
				sb.Append("<urn:Zip>").Append(Zip);
				sb.Append("</urn:Zip>");
			}
			return sb.ToString();
		}
	}




	/**
      *Confirmation of a match, with one of the following tokens:
      *None: The input value of the Email object does not match any
      *email address on file at PayPal. Confirmed: If the value of
      *the StreetMatch object is Matched, PayPal responds that the
      *entire postal address is confirmed. Unconfirmed: PayPal
      *responds that the postal address is unconfirmed 
      */
	public partial class AddressVerifyResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private AddressStatusCodeType? ConfirmationCodeField;
		public AddressStatusCodeType? ConfirmationCode
		{
			get
			{
				return this.ConfirmationCodeField;
			}
			set
			{
				this.ConfirmationCodeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private MatchStatusCodeType? StreetMatchField;
		public MatchStatusCodeType? StreetMatch
		{
			get
			{
				return this.StreetMatchField;
			}
			set
			{
				this.StreetMatchField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private MatchStatusCodeType? ZipMatchField;
		public MatchStatusCodeType? ZipMatch
		{
			get
			{
				return this.ZipMatchField;
			}
			set
			{
				this.ZipMatchField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private CountryCodeType? CountryCodeField;
		public CountryCodeType? CountryCode
		{
			get
			{
				return this.CountryCodeField;
			}
			set
			{
				this.CountryCodeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PayPalTokenField;
		public string PayPalToken
		{
			get
			{
				return this.PayPalTokenField;
			}
			set
			{
				this.PayPalTokenField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public AddressVerifyResponseType(){
		}


		public AddressVerifyResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("ConfirmationCode").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ConfirmationCode")[0]))
				{
					this.ConfirmationCode = (AddressStatusCodeType)EnumUtils.getValue(document.GetElementsByTagName("ConfirmationCode")[0].InnerText,typeof(AddressStatusCodeType));
				}
			}
			if(document.GetElementsByTagName("StreetMatch").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("StreetMatch")[0]))
				{
					this.StreetMatch = (MatchStatusCodeType)EnumUtils.getValue(document.GetElementsByTagName("StreetMatch")[0].InnerText,typeof(MatchStatusCodeType));
				}
			}
			if(document.GetElementsByTagName("ZipMatch").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ZipMatch")[0]))
				{
					this.ZipMatch = (MatchStatusCodeType)EnumUtils.getValue(document.GetElementsByTagName("ZipMatch")[0].InnerText,typeof(MatchStatusCodeType));
				}
			}
			if(document.GetElementsByTagName("CountryCode").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CountryCode")[0]))
				{
					this.CountryCode = (CountryCodeType)EnumUtils.getValue(document.GetElementsByTagName("CountryCode")[0].InnerText,typeof(CountryCodeType));
				}
			}
		if(document.GetElementsByTagName("PayPalToken").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PayPalToken")[0]))
			{
				this.PayPalToken = (string)document.GetElementsByTagName("PayPalToken")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *
      */
	public partial class EnterBoardingReq	
	{

		/**
          *No Document Comments
		  */
		private EnterBoardingRequestType EnterBoardingRequestField;
		public EnterBoardingRequestType EnterBoardingRequest
		{
			get
			{
				return this.EnterBoardingRequestField;
			}
			set
			{
				this.EnterBoardingRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public EnterBoardingReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:EnterBoardingReq>");
			if(EnterBoardingRequest != null)
			{
				sb.Append("<urn:EnterBoardingRequest>");
				sb.Append(EnterBoardingRequest.toXMLString());
				sb.Append("</urn:EnterBoardingRequest>");
			}
			sb.Append("</urn:EnterBoardingReq>");
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class EnterBoardingRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private EnterBoardingRequestDetailsType EnterBoardingRequestDetailsField;
		public EnterBoardingRequestDetailsType EnterBoardingRequestDetails
		{
			get
			{
				return this.EnterBoardingRequestDetailsField;
			}
			set
			{
				this.EnterBoardingRequestDetailsField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public EnterBoardingRequestType(EnterBoardingRequestDetailsType EnterBoardingRequestDetails){
			this.EnterBoardingRequestDetails = EnterBoardingRequestDetails;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public EnterBoardingRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(EnterBoardingRequestDetails != null)
			{
				sb.Append("<ebl:EnterBoardingRequestDetails>");
				sb.Append(EnterBoardingRequestDetails.toXMLString());
				sb.Append("</ebl:EnterBoardingRequestDetails>");
			}
			return sb.ToString();
		}
	}




	/**
      *A unique token that identifies this boarding session. Use
      *this token with the GetBoarding Details API call.Character
      *length and limitations: 64 alphanumeric characters. The
      *token has the following format:OB-61characterstring
      */
	public partial class EnterBoardingResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private string TokenField;
		public string Token
		{
			get
			{
				return this.TokenField;
			}
			set
			{
				this.TokenField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public EnterBoardingResponseType(){
		}


		public EnterBoardingResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("Token").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Token")[0]))
			{
				this.Token = (string)document.GetElementsByTagName("Token")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *
      */
	public partial class GetBoardingDetailsReq	
	{

		/**
          *No Document Comments
		  */
		private GetBoardingDetailsRequestType GetBoardingDetailsRequestField;
		public GetBoardingDetailsRequestType GetBoardingDetailsRequest
		{
			get
			{
				return this.GetBoardingDetailsRequestField;
			}
			set
			{
				this.GetBoardingDetailsRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public GetBoardingDetailsReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:GetBoardingDetailsReq>");
			if(GetBoardingDetailsRequest != null)
			{
				sb.Append("<urn:GetBoardingDetailsRequest>");
				sb.Append(GetBoardingDetailsRequest.toXMLString());
				sb.Append("</urn:GetBoardingDetailsRequest>");
			}
			sb.Append("</urn:GetBoardingDetailsReq>");
			return sb.ToString();
		}
	}




	/**
      *A unique token returned by the EnterBoarding API call that
      *identifies this boarding session. RequiredCharacter length
      *and limitations: 64 alphanumeric characters. The token has
      *the following format:OB-61characterstring
      */
	public partial class GetBoardingDetailsRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private string TokenField;
		public string Token
		{
			get
			{
				return this.TokenField;
			}
			set
			{
				this.TokenField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public GetBoardingDetailsRequestType(string Token){
			this.Token = Token;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public GetBoardingDetailsRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(Token != null)
			{
				sb.Append("<urn:Token>").Append(Token);
				sb.Append("</urn:Token>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class GetBoardingDetailsResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private GetBoardingDetailsResponseDetailsType GetBoardingDetailsResponseDetailsField;
		public GetBoardingDetailsResponseDetailsType GetBoardingDetailsResponseDetails
		{
			get
			{
				return this.GetBoardingDetailsResponseDetailsField;
			}
			set
			{
				this.GetBoardingDetailsResponseDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public GetBoardingDetailsResponseType(){
		}


		public GetBoardingDetailsResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("GetBoardingDetailsResponseDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GetBoardingDetailsResponseDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("GetBoardingDetailsResponseDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.GetBoardingDetailsResponseDetails =  new GetBoardingDetailsResponseDetailsType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *
      */
	public partial class SetAuthFlowParamReq	
	{

		/**
          *No Document Comments
		  */
		private SetAuthFlowParamRequestType SetAuthFlowParamRequestField;
		public SetAuthFlowParamRequestType SetAuthFlowParamRequest
		{
			get
			{
				return this.SetAuthFlowParamRequestField;
			}
			set
			{
				this.SetAuthFlowParamRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public SetAuthFlowParamReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:SetAuthFlowParamReq>");
			if(SetAuthFlowParamRequest != null)
			{
				sb.Append("<urn:SetAuthFlowParamRequest>");
				sb.Append(SetAuthFlowParamRequest.toXMLString());
				sb.Append("</urn:SetAuthFlowParamRequest>");
			}
			sb.Append("</urn:SetAuthFlowParamReq>");
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class SetAuthFlowParamRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private SetAuthFlowParamRequestDetailsType SetAuthFlowParamRequestDetailsField;
		public SetAuthFlowParamRequestDetailsType SetAuthFlowParamRequestDetails
		{
			get
			{
				return this.SetAuthFlowParamRequestDetailsField;
			}
			set
			{
				this.SetAuthFlowParamRequestDetailsField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public SetAuthFlowParamRequestType(SetAuthFlowParamRequestDetailsType SetAuthFlowParamRequestDetails){
			this.SetAuthFlowParamRequestDetails = SetAuthFlowParamRequestDetails;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public SetAuthFlowParamRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(SetAuthFlowParamRequestDetails != null)
			{
				sb.Append("<ebl:SetAuthFlowParamRequestDetails>");
				sb.Append(SetAuthFlowParamRequestDetails.toXMLString());
				sb.Append("</ebl:SetAuthFlowParamRequestDetails>");
			}
			return sb.ToString();
		}
	}




	/**
      *A timestamped token by which you identify to PayPal that you
      *are processing this user. The token expires after three
      *hours. Character length and limitations: 20 single-byte
      *characters
      */
	public partial class SetAuthFlowParamResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private string TokenField;
		public string Token
		{
			get
			{
				return this.TokenField;
			}
			set
			{
				this.TokenField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public SetAuthFlowParamResponseType(){
		}


		public SetAuthFlowParamResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("Token").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Token")[0]))
			{
				this.Token = (string)document.GetElementsByTagName("Token")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *
      */
	public partial class GetAuthDetailsReq	
	{

		/**
          *No Document Comments
		  */
		private GetAuthDetailsRequestType GetAuthDetailsRequestField;
		public GetAuthDetailsRequestType GetAuthDetailsRequest
		{
			get
			{
				return this.GetAuthDetailsRequestField;
			}
			set
			{
				this.GetAuthDetailsRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public GetAuthDetailsReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:GetAuthDetailsReq>");
			if(GetAuthDetailsRequest != null)
			{
				sb.Append("<urn:GetAuthDetailsRequest>");
				sb.Append(GetAuthDetailsRequest.toXMLString());
				sb.Append("</urn:GetAuthDetailsRequest>");
			}
			sb.Append("</urn:GetAuthDetailsReq>");
			return sb.ToString();
		}
	}




	/**
      *A timestamped token, the value of which was returned by
      *SetAuthFlowParam Response. RequiredCharacter length and
      *limitations: 20 single-byte characters
      */
	public partial class GetAuthDetailsRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private string TokenField;
		public string Token
		{
			get
			{
				return this.TokenField;
			}
			set
			{
				this.TokenField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public GetAuthDetailsRequestType(string Token){
			this.Token = Token;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public GetAuthDetailsRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(Token != null)
			{
				sb.Append("<urn:Token>").Append(Token);
				sb.Append("</urn:Token>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class GetAuthDetailsResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private GetAuthDetailsResponseDetailsType GetAuthDetailsResponseDetailsField;
		public GetAuthDetailsResponseDetailsType GetAuthDetailsResponseDetails
		{
			get
			{
				return this.GetAuthDetailsResponseDetailsField;
			}
			set
			{
				this.GetAuthDetailsResponseDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public GetAuthDetailsResponseType(){
		}


		public GetAuthDetailsResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("GetAuthDetailsResponseDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GetAuthDetailsResponseDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("GetAuthDetailsResponseDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.GetAuthDetailsResponseDetails =  new GetAuthDetailsResponseDetailsType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *
      */
	public partial class SetAccessPermissionsReq	
	{

		/**
          *No Document Comments
		  */
		private SetAccessPermissionsRequestType SetAccessPermissionsRequestField;
		public SetAccessPermissionsRequestType SetAccessPermissionsRequest
		{
			get
			{
				return this.SetAccessPermissionsRequestField;
			}
			set
			{
				this.SetAccessPermissionsRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public SetAccessPermissionsReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:SetAccessPermissionsReq>");
			if(SetAccessPermissionsRequest != null)
			{
				sb.Append("<urn:SetAccessPermissionsRequest>");
				sb.Append(SetAccessPermissionsRequest.toXMLString());
				sb.Append("</urn:SetAccessPermissionsRequest>");
			}
			sb.Append("</urn:SetAccessPermissionsReq>");
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class SetAccessPermissionsRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private SetAccessPermissionsRequestDetailsType SetAccessPermissionsRequestDetailsField;
		public SetAccessPermissionsRequestDetailsType SetAccessPermissionsRequestDetails
		{
			get
			{
				return this.SetAccessPermissionsRequestDetailsField;
			}
			set
			{
				this.SetAccessPermissionsRequestDetailsField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public SetAccessPermissionsRequestType(SetAccessPermissionsRequestDetailsType SetAccessPermissionsRequestDetails){
			this.SetAccessPermissionsRequestDetails = SetAccessPermissionsRequestDetails;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public SetAccessPermissionsRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(SetAccessPermissionsRequestDetails != null)
			{
				sb.Append("<ebl:SetAccessPermissionsRequestDetails>");
				sb.Append(SetAccessPermissionsRequestDetails.toXMLString());
				sb.Append("</ebl:SetAccessPermissionsRequestDetails>");
			}
			return sb.ToString();
		}
	}




	/**
      *A timestamped token by which you identify to PayPal that you
      *are processing this user. The token expires after three
      *hours. Character length and limitations: 20 single-byte
      *characters
      */
	public partial class SetAccessPermissionsResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private string TokenField;
		public string Token
		{
			get
			{
				return this.TokenField;
			}
			set
			{
				this.TokenField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public SetAccessPermissionsResponseType(){
		}


		public SetAccessPermissionsResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("Token").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Token")[0]))
			{
				this.Token = (string)document.GetElementsByTagName("Token")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *
      */
	public partial class UpdateAccessPermissionsReq	
	{

		/**
          *No Document Comments
		  */
		private UpdateAccessPermissionsRequestType UpdateAccessPermissionsRequestField;
		public UpdateAccessPermissionsRequestType UpdateAccessPermissionsRequest
		{
			get
			{
				return this.UpdateAccessPermissionsRequestField;
			}
			set
			{
				this.UpdateAccessPermissionsRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public UpdateAccessPermissionsReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:UpdateAccessPermissionsReq>");
			if(UpdateAccessPermissionsRequest != null)
			{
				sb.Append("<urn:UpdateAccessPermissionsRequest>");
				sb.Append(UpdateAccessPermissionsRequest.toXMLString());
				sb.Append("</urn:UpdateAccessPermissionsRequest>");
			}
			sb.Append("</urn:UpdateAccessPermissionsReq>");
			return sb.ToString();
		}
	}




	/**
      *Unique PayPal customer account number, the value of which
      *was returned by GetAuthDetails Response. Required Character
      *length and limitations: 20 single-byte characters 
      */
	public partial class UpdateAccessPermissionsRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private string PayerIDField;
		public string PayerID
		{
			get
			{
				return this.PayerIDField;
			}
			set
			{
				this.PayerIDField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public UpdateAccessPermissionsRequestType(string PayerID){
			this.PayerID = PayerID;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public UpdateAccessPermissionsRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(PayerID != null)
			{
				sb.Append("<urn:PayerID>").Append(PayerID);
				sb.Append("</urn:PayerID>");
			}
			return sb.ToString();
		}
	}




	/**
      *The status of the update call, Success/Failure. Character
      *length and limitations: 20 single-byte characters 
      */
	public partial class UpdateAccessPermissionsResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private string StatusField;
		public string Status
		{
			get
			{
				return this.StatusField;
			}
			set
			{
				this.StatusField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public UpdateAccessPermissionsResponseType(){
		}


		public UpdateAccessPermissionsResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("Status").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Status")[0]))
			{
				this.Status = (string)document.GetElementsByTagName("Status")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *
      */
	public partial class GetAccessPermissionDetailsReq	
	{

		/**
          *No Document Comments
		  */
		private GetAccessPermissionDetailsRequestType GetAccessPermissionDetailsRequestField;
		public GetAccessPermissionDetailsRequestType GetAccessPermissionDetailsRequest
		{
			get
			{
				return this.GetAccessPermissionDetailsRequestField;
			}
			set
			{
				this.GetAccessPermissionDetailsRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public GetAccessPermissionDetailsReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:GetAccessPermissionDetailsReq>");
			if(GetAccessPermissionDetailsRequest != null)
			{
				sb.Append("<urn:GetAccessPermissionDetailsRequest>");
				sb.Append(GetAccessPermissionDetailsRequest.toXMLString());
				sb.Append("</urn:GetAccessPermissionDetailsRequest>");
			}
			sb.Append("</urn:GetAccessPermissionDetailsReq>");
			return sb.ToString();
		}
	}




	/**
      *A timestamped token, the value of which was returned by
      *SetAuthFlowParam Response. Required Character length and
      *limitations: 20 single-byte characters 
      */
	public partial class GetAccessPermissionDetailsRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private string TokenField;
		public string Token
		{
			get
			{
				return this.TokenField;
			}
			set
			{
				this.TokenField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public GetAccessPermissionDetailsRequestType(string Token){
			this.Token = Token;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public GetAccessPermissionDetailsRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(Token != null)
			{
				sb.Append("<urn:Token>").Append(Token);
				sb.Append("</urn:Token>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class GetAccessPermissionDetailsResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private GetAccessPermissionDetailsResponseDetailsType GetAccessPermissionDetailsResponseDetailsField;
		public GetAccessPermissionDetailsResponseDetailsType GetAccessPermissionDetailsResponseDetails
		{
			get
			{
				return this.GetAccessPermissionDetailsResponseDetailsField;
			}
			set
			{
				this.GetAccessPermissionDetailsResponseDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public GetAccessPermissionDetailsResponseType(){
		}


		public GetAccessPermissionDetailsResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("GetAccessPermissionDetailsResponseDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GetAccessPermissionDetailsResponseDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("GetAccessPermissionDetailsResponseDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.GetAccessPermissionDetailsResponseDetails =  new GetAccessPermissionDetailsResponseDetailsType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *
      */
	public partial class GetIncentiveEvaluationReq	
	{

		/**
          *No Document Comments
		  */
		private GetIncentiveEvaluationRequestType GetIncentiveEvaluationRequestField;
		public GetIncentiveEvaluationRequestType GetIncentiveEvaluationRequest
		{
			get
			{
				return this.GetIncentiveEvaluationRequestField;
			}
			set
			{
				this.GetIncentiveEvaluationRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public GetIncentiveEvaluationReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:GetIncentiveEvaluationReq>");
			if(GetIncentiveEvaluationRequest != null)
			{
				sb.Append("<urn:GetIncentiveEvaluationRequest>");
				sb.Append(GetIncentiveEvaluationRequest.toXMLString());
				sb.Append("</urn:GetIncentiveEvaluationRequest>");
			}
			sb.Append("</urn:GetIncentiveEvaluationReq>");
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class GetIncentiveEvaluationRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private GetIncentiveEvaluationRequestDetailsType GetIncentiveEvaluationRequestDetailsField;
		public GetIncentiveEvaluationRequestDetailsType GetIncentiveEvaluationRequestDetails
		{
			get
			{
				return this.GetIncentiveEvaluationRequestDetailsField;
			}
			set
			{
				this.GetIncentiveEvaluationRequestDetailsField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public GetIncentiveEvaluationRequestType(GetIncentiveEvaluationRequestDetailsType GetIncentiveEvaluationRequestDetails){
			this.GetIncentiveEvaluationRequestDetails = GetIncentiveEvaluationRequestDetails;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public GetIncentiveEvaluationRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(GetIncentiveEvaluationRequestDetails != null)
			{
				sb.Append("<ebl:GetIncentiveEvaluationRequestDetails>");
				sb.Append(GetIncentiveEvaluationRequestDetails.toXMLString());
				sb.Append("</ebl:GetIncentiveEvaluationRequestDetails>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class GetIncentiveEvaluationResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private GetIncentiveEvaluationResponseDetailsType GetIncentiveEvaluationResponseDetailsField;
		public GetIncentiveEvaluationResponseDetailsType GetIncentiveEvaluationResponseDetails
		{
			get
			{
				return this.GetIncentiveEvaluationResponseDetailsField;
			}
			set
			{
				this.GetIncentiveEvaluationResponseDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public GetIncentiveEvaluationResponseType(){
		}


		public GetIncentiveEvaluationResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("GetIncentiveEvaluationResponseDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GetIncentiveEvaluationResponseDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("GetIncentiveEvaluationResponseDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.GetIncentiveEvaluationResponseDetails =  new GetIncentiveEvaluationResponseDetailsType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *
      */
	public partial class SetExpressCheckoutReq	
	{

		/**
          *No Document Comments
		  */
		private SetExpressCheckoutRequestType SetExpressCheckoutRequestField;
		public SetExpressCheckoutRequestType SetExpressCheckoutRequest
		{
			get
			{
				return this.SetExpressCheckoutRequestField;
			}
			set
			{
				this.SetExpressCheckoutRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public SetExpressCheckoutReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:SetExpressCheckoutReq>");
			if(SetExpressCheckoutRequest != null)
			{
				sb.Append("<urn:SetExpressCheckoutRequest>");
				sb.Append(SetExpressCheckoutRequest.toXMLString());
				sb.Append("</urn:SetExpressCheckoutRequest>");
			}
			sb.Append("</urn:SetExpressCheckoutReq>");
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class SetExpressCheckoutRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private SetExpressCheckoutRequestDetailsType SetExpressCheckoutRequestDetailsField;
		public SetExpressCheckoutRequestDetailsType SetExpressCheckoutRequestDetails
		{
			get
			{
				return this.SetExpressCheckoutRequestDetailsField;
			}
			set
			{
				this.SetExpressCheckoutRequestDetailsField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public SetExpressCheckoutRequestType(SetExpressCheckoutRequestDetailsType SetExpressCheckoutRequestDetails){
			this.SetExpressCheckoutRequestDetails = SetExpressCheckoutRequestDetails;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public SetExpressCheckoutRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(SetExpressCheckoutRequestDetails != null)
			{
				sb.Append("<ebl:SetExpressCheckoutRequestDetails>");
				sb.Append(SetExpressCheckoutRequestDetails.toXMLString());
				sb.Append("</ebl:SetExpressCheckoutRequestDetails>");
			}
			return sb.ToString();
		}
	}




	/**
      *A timestamped token by which you identify to PayPal that you
      *are processing this payment with Express Checkout. The token
      *expires after three hours. If you set Token in the
      *SetExpressCheckoutRequest, the value of Token in the
      *response is identical to the value in the request. Character
      *length and limitations: 20 single-byte characters
      */
	public partial class SetExpressCheckoutResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private string TokenField;
		public string Token
		{
			get
			{
				return this.TokenField;
			}
			set
			{
				this.TokenField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public SetExpressCheckoutResponseType(){
		}


		public SetExpressCheckoutResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("Token").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Token")[0]))
			{
				this.Token = (string)document.GetElementsByTagName("Token")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *
      */
	public partial class ExecuteCheckoutOperationsReq	
	{

		/**
          *No Document Comments
		  */
		private ExecuteCheckoutOperationsRequestType ExecuteCheckoutOperationsRequestField;
		public ExecuteCheckoutOperationsRequestType ExecuteCheckoutOperationsRequest
		{
			get
			{
				return this.ExecuteCheckoutOperationsRequestField;
			}
			set
			{
				this.ExecuteCheckoutOperationsRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public ExecuteCheckoutOperationsReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:ExecuteCheckoutOperationsReq>");
			if(ExecuteCheckoutOperationsRequest != null)
			{
				sb.Append("<urn:ExecuteCheckoutOperationsRequest>");
				sb.Append(ExecuteCheckoutOperationsRequest.toXMLString());
				sb.Append("</urn:ExecuteCheckoutOperationsRequest>");
			}
			sb.Append("</urn:ExecuteCheckoutOperationsReq>");
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class ExecuteCheckoutOperationsRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private ExecuteCheckoutOperationsRequestDetailsType ExecuteCheckoutOperationsRequestDetailsField;
		public ExecuteCheckoutOperationsRequestDetailsType ExecuteCheckoutOperationsRequestDetails
		{
			get
			{
				return this.ExecuteCheckoutOperationsRequestDetailsField;
			}
			set
			{
				this.ExecuteCheckoutOperationsRequestDetailsField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public ExecuteCheckoutOperationsRequestType(ExecuteCheckoutOperationsRequestDetailsType ExecuteCheckoutOperationsRequestDetails){
			this.ExecuteCheckoutOperationsRequestDetails = ExecuteCheckoutOperationsRequestDetails;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public ExecuteCheckoutOperationsRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(ExecuteCheckoutOperationsRequestDetails != null)
			{
				sb.Append("<ebl:ExecuteCheckoutOperationsRequestDetails>");
				sb.Append(ExecuteCheckoutOperationsRequestDetails.toXMLString());
				sb.Append("</ebl:ExecuteCheckoutOperationsRequestDetails>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class ExecuteCheckoutOperationsResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private ExecuteCheckoutOperationsResponseDetailsType ExecuteCheckoutOperationsResponseDetailsField;
		public ExecuteCheckoutOperationsResponseDetailsType ExecuteCheckoutOperationsResponseDetails
		{
			get
			{
				return this.ExecuteCheckoutOperationsResponseDetailsField;
			}
			set
			{
				this.ExecuteCheckoutOperationsResponseDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public ExecuteCheckoutOperationsResponseType(){
		}


		public ExecuteCheckoutOperationsResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("ExecuteCheckoutOperationsResponseDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ExecuteCheckoutOperationsResponseDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("ExecuteCheckoutOperationsResponseDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.ExecuteCheckoutOperationsResponseDetails =  new ExecuteCheckoutOperationsResponseDetailsType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *
      */
	public partial class GetExpressCheckoutDetailsReq	
	{

		/**
          *No Document Comments
		  */
		private GetExpressCheckoutDetailsRequestType GetExpressCheckoutDetailsRequestField;
		public GetExpressCheckoutDetailsRequestType GetExpressCheckoutDetailsRequest
		{
			get
			{
				return this.GetExpressCheckoutDetailsRequestField;
			}
			set
			{
				this.GetExpressCheckoutDetailsRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public GetExpressCheckoutDetailsReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:GetExpressCheckoutDetailsReq>");
			if(GetExpressCheckoutDetailsRequest != null)
			{
				sb.Append("<urn:GetExpressCheckoutDetailsRequest>");
				sb.Append(GetExpressCheckoutDetailsRequest.toXMLString());
				sb.Append("</urn:GetExpressCheckoutDetailsRequest>");
			}
			sb.Append("</urn:GetExpressCheckoutDetailsReq>");
			return sb.ToString();
		}
	}




	/**
      *A timestamped token, the value of which was returned by
      *SetExpressCheckoutResponse. RequiredCharacter length and
      *limitations: 20 single-byte characters
      */
	public partial class GetExpressCheckoutDetailsRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private string TokenField;
		public string Token
		{
			get
			{
				return this.TokenField;
			}
			set
			{
				this.TokenField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public GetExpressCheckoutDetailsRequestType(string Token){
			this.Token = Token;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public GetExpressCheckoutDetailsRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(Token != null)
			{
				sb.Append("<urn:Token>").Append(Token);
				sb.Append("</urn:Token>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class GetExpressCheckoutDetailsResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private GetExpressCheckoutDetailsResponseDetailsType GetExpressCheckoutDetailsResponseDetailsField;
		public GetExpressCheckoutDetailsResponseDetailsType GetExpressCheckoutDetailsResponseDetails
		{
			get
			{
				return this.GetExpressCheckoutDetailsResponseDetailsField;
			}
			set
			{
				this.GetExpressCheckoutDetailsResponseDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public GetExpressCheckoutDetailsResponseType(){
		}


		public GetExpressCheckoutDetailsResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("GetExpressCheckoutDetailsResponseDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GetExpressCheckoutDetailsResponseDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("GetExpressCheckoutDetailsResponseDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.GetExpressCheckoutDetailsResponseDetails =  new GetExpressCheckoutDetailsResponseDetailsType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *
      */
	public partial class DoExpressCheckoutPaymentReq	
	{

		/**
          *No Document Comments
		  */
		private DoExpressCheckoutPaymentRequestType DoExpressCheckoutPaymentRequestField;
		public DoExpressCheckoutPaymentRequestType DoExpressCheckoutPaymentRequest
		{
			get
			{
				return this.DoExpressCheckoutPaymentRequestField;
			}
			set
			{
				this.DoExpressCheckoutPaymentRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DoExpressCheckoutPaymentReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:DoExpressCheckoutPaymentReq>");
			if(DoExpressCheckoutPaymentRequest != null)
			{
				sb.Append("<urn:DoExpressCheckoutPaymentRequest>");
				sb.Append(DoExpressCheckoutPaymentRequest.toXMLString());
				sb.Append("</urn:DoExpressCheckoutPaymentRequest>");
			}
			sb.Append("</urn:DoExpressCheckoutPaymentReq>");
			return sb.ToString();
		}
	}




	/**
      *This flag indicates that the response should include
      *FMFDetails 
      */
	public partial class DoExpressCheckoutPaymentRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private DoExpressCheckoutPaymentRequestDetailsType DoExpressCheckoutPaymentRequestDetailsField;
		public DoExpressCheckoutPaymentRequestDetailsType DoExpressCheckoutPaymentRequestDetails
		{
			get
			{
				return this.DoExpressCheckoutPaymentRequestDetailsField;
			}
			set
			{
				this.DoExpressCheckoutPaymentRequestDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? ReturnFMFDetailsField;
		public int? ReturnFMFDetails
		{
			get
			{
				return this.ReturnFMFDetailsField;
			}
			set
			{
				this.ReturnFMFDetailsField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public DoExpressCheckoutPaymentRequestType(DoExpressCheckoutPaymentRequestDetailsType DoExpressCheckoutPaymentRequestDetails){
			this.DoExpressCheckoutPaymentRequestDetails = DoExpressCheckoutPaymentRequestDetails;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public DoExpressCheckoutPaymentRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(DoExpressCheckoutPaymentRequestDetails != null)
			{
				sb.Append("<ebl:DoExpressCheckoutPaymentRequestDetails>");
				sb.Append(DoExpressCheckoutPaymentRequestDetails.toXMLString());
				sb.Append("</ebl:DoExpressCheckoutPaymentRequestDetails>");
			}
			if(ReturnFMFDetails != null)
			{
				sb.Append("<urn:ReturnFMFDetails>").Append(ReturnFMFDetails);
				sb.Append("</urn:ReturnFMFDetails>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class DoExpressCheckoutPaymentResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private DoExpressCheckoutPaymentResponseDetailsType DoExpressCheckoutPaymentResponseDetailsField;
		public DoExpressCheckoutPaymentResponseDetailsType DoExpressCheckoutPaymentResponseDetails
		{
			get
			{
				return this.DoExpressCheckoutPaymentResponseDetailsField;
			}
			set
			{
				this.DoExpressCheckoutPaymentResponseDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private FMFDetailsType FMFDetailsField;
		public FMFDetailsType FMFDetails
		{
			get
			{
				return this.FMFDetailsField;
			}
			set
			{
				this.FMFDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DoExpressCheckoutPaymentResponseType(){
		}


		public DoExpressCheckoutPaymentResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("DoExpressCheckoutPaymentResponseDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("DoExpressCheckoutPaymentResponseDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("DoExpressCheckoutPaymentResponseDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.DoExpressCheckoutPaymentResponseDetails =  new DoExpressCheckoutPaymentResponseDetailsType(xmlString);
				}
			}
			if(document.GetElementsByTagName("FMFDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("FMFDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("FMFDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.FMFDetails =  new FMFDetailsType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *
      */
	public partial class DoUATPExpressCheckoutPaymentReq	
	{

		/**
          *No Document Comments
		  */
		private DoUATPExpressCheckoutPaymentRequestType DoUATPExpressCheckoutPaymentRequestField;
		public DoUATPExpressCheckoutPaymentRequestType DoUATPExpressCheckoutPaymentRequest
		{
			get
			{
				return this.DoUATPExpressCheckoutPaymentRequestField;
			}
			set
			{
				this.DoUATPExpressCheckoutPaymentRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DoUATPExpressCheckoutPaymentReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:DoUATPExpressCheckoutPaymentReq>");
			if(DoUATPExpressCheckoutPaymentRequest != null)
			{
				sb.Append("<urn:DoUATPExpressCheckoutPaymentRequest>");
				sb.Append(DoUATPExpressCheckoutPaymentRequest.toXMLString());
				sb.Append("</urn:DoUATPExpressCheckoutPaymentRequest>");
			}
			sb.Append("</urn:DoUATPExpressCheckoutPaymentReq>");
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class DoUATPExpressCheckoutPaymentRequestType : DoExpressCheckoutPaymentRequestType	
	{

		/**
	 	  * Default Constructor
	 	  */
	 	public DoUATPExpressCheckoutPaymentRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class DoUATPExpressCheckoutPaymentResponseType : DoExpressCheckoutPaymentResponseType	
	{

		/**
          *No Document Comments
		  */
		private UATPDetailsType UATPDetailsField;
		public UATPDetailsType UATPDetails
		{
			get
			{
				return this.UATPDetailsField;
			}
			set
			{
				this.UATPDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DoUATPExpressCheckoutPaymentResponseType(){
		}


		public DoUATPExpressCheckoutPaymentResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("UATPDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("UATPDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("UATPDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.UATPDetails =  new UATPDetailsType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *
      */
	public partial class ManagePendingTransactionStatusReq	
	{

		/**
          *No Document Comments
		  */
		private ManagePendingTransactionStatusRequestType ManagePendingTransactionStatusRequestField;
		public ManagePendingTransactionStatusRequestType ManagePendingTransactionStatusRequest
		{
			get
			{
				return this.ManagePendingTransactionStatusRequestField;
			}
			set
			{
				this.ManagePendingTransactionStatusRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public ManagePendingTransactionStatusReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:ManagePendingTransactionStatusReq>");
			if(ManagePendingTransactionStatusRequest != null)
			{
				sb.Append("<urn:ManagePendingTransactionStatusRequest>");
				sb.Append(ManagePendingTransactionStatusRequest.toXMLString());
				sb.Append("</urn:ManagePendingTransactionStatusRequest>");
			}
			sb.Append("</urn:ManagePendingTransactionStatusReq>");
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class ManagePendingTransactionStatusRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private string TransactionIDField;
		public string TransactionID
		{
			get
			{
				return this.TransactionIDField;
			}
			set
			{
				this.TransactionIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private FMFPendingTransactionActionType? ActionField;
		public FMFPendingTransactionActionType? Action
		{
			get
			{
				return this.ActionField;
			}
			set
			{
				this.ActionField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public ManagePendingTransactionStatusRequestType(string TransactionID, FMFPendingTransactionActionType? Action){
			this.TransactionID = TransactionID;
			this.Action = Action;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public ManagePendingTransactionStatusRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(TransactionID != null)
			{
				sb.Append("<urn:TransactionID>").Append(TransactionID);
				sb.Append("</urn:TransactionID>");
			}
			if(Action != null)
			{
				sb.Append("<urn:Action>").Append(EnumUtils.getDescription(Action));
				sb.Append("</urn:Action>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class ManagePendingTransactionStatusResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private string TransactionIDField;
		public string TransactionID
		{
			get
			{
				return this.TransactionIDField;
			}
			set
			{
				this.TransactionIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string StatusField;
		public string Status
		{
			get
			{
				return this.StatusField;
			}
			set
			{
				this.StatusField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public ManagePendingTransactionStatusResponseType(){
		}


		public ManagePendingTransactionStatusResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("TransactionID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TransactionID")[0]))
			{
				this.TransactionID = (string)document.GetElementsByTagName("TransactionID")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Status").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Status")[0]))
			{
				this.Status = (string)document.GetElementsByTagName("Status")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *
      */
	public partial class DoDirectPaymentReq	
	{

		/**
          *No Document Comments
		  */
		private DoDirectPaymentRequestType DoDirectPaymentRequestField;
		public DoDirectPaymentRequestType DoDirectPaymentRequest
		{
			get
			{
				return this.DoDirectPaymentRequestField;
			}
			set
			{
				this.DoDirectPaymentRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DoDirectPaymentReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:DoDirectPaymentReq>");
			if(DoDirectPaymentRequest != null)
			{
				sb.Append("<urn:DoDirectPaymentRequest>");
				sb.Append(DoDirectPaymentRequest.toXMLString());
				sb.Append("</urn:DoDirectPaymentRequest>");
			}
			sb.Append("</urn:DoDirectPaymentReq>");
			return sb.ToString();
		}
	}




	/**
      *This flag indicates that the response should include
      *FMFDetails 
      */
	public partial class DoDirectPaymentRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private DoDirectPaymentRequestDetailsType DoDirectPaymentRequestDetailsField;
		public DoDirectPaymentRequestDetailsType DoDirectPaymentRequestDetails
		{
			get
			{
				return this.DoDirectPaymentRequestDetailsField;
			}
			set
			{
				this.DoDirectPaymentRequestDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? ReturnFMFDetailsField;
		public int? ReturnFMFDetails
		{
			get
			{
				return this.ReturnFMFDetailsField;
			}
			set
			{
				this.ReturnFMFDetailsField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public DoDirectPaymentRequestType(DoDirectPaymentRequestDetailsType DoDirectPaymentRequestDetails){
			this.DoDirectPaymentRequestDetails = DoDirectPaymentRequestDetails;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public DoDirectPaymentRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(DoDirectPaymentRequestDetails != null)
			{
				sb.Append("<ebl:DoDirectPaymentRequestDetails>");
				sb.Append(DoDirectPaymentRequestDetails.toXMLString());
				sb.Append("</ebl:DoDirectPaymentRequestDetails>");
			}
			if(ReturnFMFDetails != null)
			{
				sb.Append("<urn:ReturnFMFDetails>").Append(ReturnFMFDetails);
				sb.Append("</urn:ReturnFMFDetails>");
			}
			return sb.ToString();
		}
	}




	/**
      *The amount of the payment as specified by you on
      *DoDirectPaymentRequest.
      */
	public partial class DoDirectPaymentResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private BasicAmountType AmountField;
		public BasicAmountType Amount
		{
			get
			{
				return this.AmountField;
			}
			set
			{
				this.AmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string AVSCodeField;
		public string AVSCode
		{
			get
			{
				return this.AVSCodeField;
			}
			set
			{
				this.AVSCodeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string CVV2CodeField;
		public string CVV2Code
		{
			get
			{
				return this.CVV2CodeField;
			}
			set
			{
				this.CVV2CodeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string TransactionIDField;
		public string TransactionID
		{
			get
			{
				return this.TransactionIDField;
			}
			set
			{
				this.TransactionIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PendingStatusCodeType? PendingReasonField;
		public PendingStatusCodeType? PendingReason
		{
			get
			{
				return this.PendingReasonField;
			}
			set
			{
				this.PendingReasonField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private PaymentStatusCodeType? PaymentStatusField;
		public PaymentStatusCodeType? PaymentStatus
		{
			get
			{
				return this.PaymentStatusField;
			}
			set
			{
				this.PaymentStatusField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private FMFDetailsType FMFDetailsField;
		public FMFDetailsType FMFDetails
		{
			get
			{
				return this.FMFDetailsField;
			}
			set
			{
				this.FMFDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ThreeDSecureResponseType ThreeDSecureResponseField;
		public ThreeDSecureResponseType ThreeDSecureResponse
		{
			get
			{
				return this.ThreeDSecureResponseField;
			}
			set
			{
				this.ThreeDSecureResponseField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string PaymentAdviceCodeField;
		public string PaymentAdviceCode
		{
			get
			{
				return this.PaymentAdviceCodeField;
			}
			set
			{
				this.PaymentAdviceCodeField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DoDirectPaymentResponseType(){
		}


		public DoDirectPaymentResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("Amount").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Amount")[0]))
				{
					nodeList = document.GetElementsByTagName("Amount");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.Amount =  new BasicAmountType(xmlString);
				}
			}
		if(document.GetElementsByTagName("AVSCode").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AVSCode")[0]))
			{
				this.AVSCode = (string)document.GetElementsByTagName("AVSCode")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("CVV2Code").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CVV2Code")[0]))
			{
				this.CVV2Code = (string)document.GetElementsByTagName("CVV2Code")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("TransactionID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TransactionID")[0]))
			{
				this.TransactionID = (string)document.GetElementsByTagName("TransactionID")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("PendingReason").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PendingReason")[0]))
				{
					this.PendingReason = (PendingStatusCodeType)EnumUtils.getValue(document.GetElementsByTagName("PendingReason")[0].InnerText,typeof(PendingStatusCodeType));
				}
			}
			if(document.GetElementsByTagName("PaymentStatus").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentStatus")[0]))
				{
					this.PaymentStatus = (PaymentStatusCodeType)EnumUtils.getValue(document.GetElementsByTagName("PaymentStatus")[0].InnerText,typeof(PaymentStatusCodeType));
				}
			}
			if(document.GetElementsByTagName("FMFDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("FMFDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("FMFDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.FMFDetails =  new FMFDetailsType(xmlString);
				}
			}
			if(document.GetElementsByTagName("ThreeDSecureResponse").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ThreeDSecureResponse")[0]))
				{
					nodeList = document.GetElementsByTagName("ThreeDSecureResponse");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.ThreeDSecureResponse =  new ThreeDSecureResponseType(xmlString);
				}
			}
		if(document.GetElementsByTagName("PaymentAdviceCode").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentAdviceCode")[0]))
			{
				this.PaymentAdviceCode = (string)document.GetElementsByTagName("PaymentAdviceCode")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *
      */
	public partial class DoCancelReq	
	{

		/**
          *No Document Comments
		  */
		private DoCancelRequestType DoCancelRequestField;
		public DoCancelRequestType DoCancelRequest
		{
			get
			{
				return this.DoCancelRequestField;
			}
			set
			{
				this.DoCancelRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DoCancelReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:DoCancelReq>");
			if(DoCancelRequest != null)
			{
				sb.Append("<urn:DoCancelRequest>");
				sb.Append(DoCancelRequest.toXMLString());
				sb.Append("</urn:DoCancelRequest>");
			}
			sb.Append("</urn:DoCancelReq>");
			return sb.ToString();
		}
	}




	/**
      *Msg Sub Id that was used for the orginal operation. 
      */
	public partial class DoCancelRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private string CancelMsgSubIDField;
		public string CancelMsgSubID
		{
			get
			{
				return this.CancelMsgSubIDField;
			}
			set
			{
				this.CancelMsgSubIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private APIType? APITypeField;
		public APIType? APIType
		{
			get
			{
				return this.APITypeField;
			}
			set
			{
				this.APITypeField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public DoCancelRequestType(string CancelMsgSubID, APIType? APIType){
			this.CancelMsgSubID = CancelMsgSubID;
			this.APIType = APIType;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public DoCancelRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(CancelMsgSubID != null)
			{
				sb.Append("<urn:CancelMsgSubID>").Append(CancelMsgSubID);
				sb.Append("</urn:CancelMsgSubID>");
			}
			if(APIType != null)
			{
				sb.Append("<urn:APIType>").Append(EnumUtils.getDescription(APIType));
				sb.Append("</urn:APIType>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class DoCancelResponseType : AbstractResponseType	
	{

		/**
	 	  * Default Constructor
	 	  */
	 	public DoCancelResponseType(){
		}


		public DoCancelResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
	
		}
		
	}




	/**
      *
      */
	public partial class DoCaptureReq	
	{

		/**
          *No Document Comments
		  */
		private DoCaptureRequestType DoCaptureRequestField;
		public DoCaptureRequestType DoCaptureRequest
		{
			get
			{
				return this.DoCaptureRequestField;
			}
			set
			{
				this.DoCaptureRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DoCaptureReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:DoCaptureReq>");
			if(DoCaptureRequest != null)
			{
				sb.Append("<urn:DoCaptureRequest>");
				sb.Append(DoCaptureRequest.toXMLString());
				sb.Append("</urn:DoCaptureRequest>");
			}
			sb.Append("</urn:DoCaptureReq>");
			return sb.ToString();
		}
	}




	/**
      *The authorization identification number of the payment you
      *want to capture. Required Character length and limits: 19
      *single-byte characters maximum 
      */
	public partial class DoCaptureRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private string AuthorizationIDField;
		public string AuthorizationID
		{
			get
			{
				return this.AuthorizationIDField;
			}
			set
			{
				this.AuthorizationIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType AmountField;
		public BasicAmountType Amount
		{
			get
			{
				return this.AmountField;
			}
			set
			{
				this.AmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private CompleteCodeType? CompleteTypeField;
		public CompleteCodeType? CompleteType
		{
			get
			{
				return this.CompleteTypeField;
			}
			set
			{
				this.CompleteTypeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string NoteField;
		public string Note
		{
			get
			{
				return this.NoteField;
			}
			set
			{
				this.NoteField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string InvoiceIDField;
		public string InvoiceID
		{
			get
			{
				return this.InvoiceIDField;
			}
			set
			{
				this.InvoiceIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private EnhancedDataType EnhancedDataField;
		public EnhancedDataType EnhancedData
		{
			get
			{
				return this.EnhancedDataField;
			}
			set
			{
				this.EnhancedDataField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string DescriptorField;
		public string Descriptor
		{
			get
			{
				return this.DescriptorField;
			}
			set
			{
				this.DescriptorField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private MerchantStoreDetailsType MerchantStoreDetailsField;
		public MerchantStoreDetailsType MerchantStoreDetails
		{
			get
			{
				return this.MerchantStoreDetailsField;
			}
			set
			{
				this.MerchantStoreDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string MsgSubIDField;
		public string MsgSubID
		{
			get
			{
				return this.MsgSubIDField;
			}
			set
			{
				this.MsgSubIDField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public DoCaptureRequestType(string AuthorizationID, BasicAmountType Amount, CompleteCodeType? CompleteType){
			this.AuthorizationID = AuthorizationID;
			this.Amount = Amount;
			this.CompleteType = CompleteType;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public DoCaptureRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(AuthorizationID != null)
			{
				sb.Append("<urn:AuthorizationID>").Append(AuthorizationID);
				sb.Append("</urn:AuthorizationID>");
			}
			if(Amount != null)
			{
				sb.Append("<urn:Amount");
				sb.Append(Amount.toXMLString());
				sb.Append("</urn:Amount>");
			}
			if(CompleteType != null)
			{
				sb.Append("<urn:CompleteType>").Append(EnumUtils.getDescription(CompleteType));
				sb.Append("</urn:CompleteType>");
			}
			if(Note != null)
			{
				sb.Append("<urn:Note>").Append(Note);
				sb.Append("</urn:Note>");
			}
			if(InvoiceID != null)
			{
				sb.Append("<urn:InvoiceID>").Append(InvoiceID);
				sb.Append("</urn:InvoiceID>");
			}
			if(EnhancedData != null)
			{
				sb.Append("<ebl:EnhancedData>");
				sb.Append(EnhancedData.toXMLString());
				sb.Append("</ebl:EnhancedData>");
			}
			if(Descriptor != null)
			{
				sb.Append("<urn:Descriptor>").Append(Descriptor);
				sb.Append("</urn:Descriptor>");
			}
			if(MerchantStoreDetails != null)
			{
				sb.Append("<ebl:MerchantStoreDetails>");
				sb.Append(MerchantStoreDetails.toXMLString());
				sb.Append("</ebl:MerchantStoreDetails>");
			}
			if(MsgSubID != null)
			{
				sb.Append("<urn:MsgSubID>").Append(MsgSubID);
				sb.Append("</urn:MsgSubID>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class DoCaptureResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private DoCaptureResponseDetailsType DoCaptureResponseDetailsField;
		public DoCaptureResponseDetailsType DoCaptureResponseDetails
		{
			get
			{
				return this.DoCaptureResponseDetailsField;
			}
			set
			{
				this.DoCaptureResponseDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DoCaptureResponseType(){
		}


		public DoCaptureResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("DoCaptureResponseDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("DoCaptureResponseDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("DoCaptureResponseDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.DoCaptureResponseDetails =  new DoCaptureResponseDetailsType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *
      */
	public partial class DoReauthorizationReq	
	{

		/**
          *No Document Comments
		  */
		private DoReauthorizationRequestType DoReauthorizationRequestField;
		public DoReauthorizationRequestType DoReauthorizationRequest
		{
			get
			{
				return this.DoReauthorizationRequestField;
			}
			set
			{
				this.DoReauthorizationRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DoReauthorizationReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:DoReauthorizationReq>");
			if(DoReauthorizationRequest != null)
			{
				sb.Append("<urn:DoReauthorizationRequest>");
				sb.Append(DoReauthorizationRequest.toXMLString());
				sb.Append("</urn:DoReauthorizationRequest>");
			}
			sb.Append("</urn:DoReauthorizationReq>");
			return sb.ToString();
		}
	}




	/**
      *The value of a previously authorized transaction
      *identification number returned by a PayPal product. You can
      *obtain a buyer's transaction number from the TransactionID
      *element of the PayerInfo structure returned by
      *GetTransactionDetailsResponse. Required Character length and
      *limits: 19 single-byte characters maximum 
      */
	public partial class DoReauthorizationRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private string AuthorizationIDField;
		public string AuthorizationID
		{
			get
			{
				return this.AuthorizationIDField;
			}
			set
			{
				this.AuthorizationIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType AmountField;
		public BasicAmountType Amount
		{
			get
			{
				return this.AmountField;
			}
			set
			{
				this.AmountField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public DoReauthorizationRequestType(string AuthorizationID, BasicAmountType Amount){
			this.AuthorizationID = AuthorizationID;
			this.Amount = Amount;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public DoReauthorizationRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(AuthorizationID != null)
			{
				sb.Append("<urn:AuthorizationID>").Append(AuthorizationID);
				sb.Append("</urn:AuthorizationID>");
			}
			if(Amount != null)
			{
				sb.Append("<urn:Amount");
				sb.Append(Amount.toXMLString());
				sb.Append("</urn:Amount>");
			}
			return sb.ToString();
		}
	}




	/**
      *A new authorization identification number. Character length
      *and limits: 19 single-byte characters 
      */
	public partial class DoReauthorizationResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private string AuthorizationIDField;
		public string AuthorizationID
		{
			get
			{
				return this.AuthorizationIDField;
			}
			set
			{
				this.AuthorizationIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private AuthorizationInfoType AuthorizationInfoField;
		public AuthorizationInfoType AuthorizationInfo
		{
			get
			{
				return this.AuthorizationInfoField;
			}
			set
			{
				this.AuthorizationInfoField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DoReauthorizationResponseType(){
		}


		public DoReauthorizationResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("AuthorizationID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AuthorizationID")[0]))
			{
				this.AuthorizationID = (string)document.GetElementsByTagName("AuthorizationID")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("AuthorizationInfo").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AuthorizationInfo")[0]))
				{
					nodeList = document.GetElementsByTagName("AuthorizationInfo");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.AuthorizationInfo =  new AuthorizationInfoType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *
      */
	public partial class DoVoidReq	
	{

		/**
          *No Document Comments
		  */
		private DoVoidRequestType DoVoidRequestField;
		public DoVoidRequestType DoVoidRequest
		{
			get
			{
				return this.DoVoidRequestField;
			}
			set
			{
				this.DoVoidRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DoVoidReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:DoVoidReq>");
			if(DoVoidRequest != null)
			{
				sb.Append("<urn:DoVoidRequest>");
				sb.Append(DoVoidRequest.toXMLString());
				sb.Append("</urn:DoVoidRequest>");
			}
			sb.Append("</urn:DoVoidReq>");
			return sb.ToString();
		}
	}




	/**
      *The value of the original authorization identification
      *number returned by a PayPal product. If you are voiding a
      *transaction that has been reauthorized, use the ID from the
      *original authorization, and not the reauthorization.
      *Required Character length and limits: 19 single-byte
      *characters 
      */
	public partial class DoVoidRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private string AuthorizationIDField;
		public string AuthorizationID
		{
			get
			{
				return this.AuthorizationIDField;
			}
			set
			{
				this.AuthorizationIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string NoteField;
		public string Note
		{
			get
			{
				return this.NoteField;
			}
			set
			{
				this.NoteField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public DoVoidRequestType(string AuthorizationID){
			this.AuthorizationID = AuthorizationID;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public DoVoidRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(AuthorizationID != null)
			{
				sb.Append("<urn:AuthorizationID>").Append(AuthorizationID);
				sb.Append("</urn:AuthorizationID>");
			}
			if(Note != null)
			{
				sb.Append("<urn:Note>").Append(Note);
				sb.Append("</urn:Note>");
			}
			return sb.ToString();
		}
	}




	/**
      *The authorization identification number you specified in the
      *request. Character length and limits: 19 single-byte
      *characters 
      */
	public partial class DoVoidResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private string AuthorizationIDField;
		public string AuthorizationID
		{
			get
			{
				return this.AuthorizationIDField;
			}
			set
			{
				this.AuthorizationIDField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DoVoidResponseType(){
		}


		public DoVoidResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("AuthorizationID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AuthorizationID")[0]))
			{
				this.AuthorizationID = (string)document.GetElementsByTagName("AuthorizationID")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *
      */
	public partial class DoAuthorizationReq	
	{

		/**
          *No Document Comments
		  */
		private DoAuthorizationRequestType DoAuthorizationRequestField;
		public DoAuthorizationRequestType DoAuthorizationRequest
		{
			get
			{
				return this.DoAuthorizationRequestField;
			}
			set
			{
				this.DoAuthorizationRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DoAuthorizationReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:DoAuthorizationReq>");
			if(DoAuthorizationRequest != null)
			{
				sb.Append("<urn:DoAuthorizationRequest>");
				sb.Append(DoAuthorizationRequest.toXMLString());
				sb.Append("</urn:DoAuthorizationRequest>");
			}
			sb.Append("</urn:DoAuthorizationReq>");
			return sb.ToString();
		}
	}




	/**
      *The value of the order’s transaction identification number
      *returned by a PayPal product. Required Character length and
      *limits: 19 single-byte characters maximum 
      */
	public partial class DoAuthorizationRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private string TransactionIDField;
		public string TransactionID
		{
			get
			{
				return this.TransactionIDField;
			}
			set
			{
				this.TransactionIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private TransactionEntityType? TransactionEntityField;
		public TransactionEntityType? TransactionEntity
		{
			get
			{
				return this.TransactionEntityField;
			}
			set
			{
				this.TransactionEntityField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType AmountField;
		public BasicAmountType Amount
		{
			get
			{
				return this.AmountField;
			}
			set
			{
				this.AmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string MsgSubIDField;
		public string MsgSubID
		{
			get
			{
				return this.MsgSubIDField;
			}
			set
			{
				this.MsgSubIDField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public DoAuthorizationRequestType(string TransactionID, BasicAmountType Amount){
			this.TransactionID = TransactionID;
			this.Amount = Amount;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public DoAuthorizationRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(TransactionID != null)
			{
				sb.Append("<urn:TransactionID>").Append(TransactionID);
				sb.Append("</urn:TransactionID>");
			}
			if(TransactionEntity != null)
			{
				sb.Append("<urn:TransactionEntity>").Append(EnumUtils.getDescription(TransactionEntity));
				sb.Append("</urn:TransactionEntity>");
			}
			if(Amount != null)
			{
				sb.Append("<urn:Amount");
				sb.Append(Amount.toXMLString());
				sb.Append("</urn:Amount>");
			}
			if(MsgSubID != null)
			{
				sb.Append("<urn:MsgSubID>").Append(MsgSubID);
				sb.Append("</urn:MsgSubID>");
			}
			return sb.ToString();
		}
	}




	/**
      *An authorization identification number. Character length and
      *limits: 19 single-byte characters 
      */
	public partial class DoAuthorizationResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private string TransactionIDField;
		public string TransactionID
		{
			get
			{
				return this.TransactionIDField;
			}
			set
			{
				this.TransactionIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType AmountField;
		public BasicAmountType Amount
		{
			get
			{
				return this.AmountField;
			}
			set
			{
				this.AmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private AuthorizationInfoType AuthorizationInfoField;
		public AuthorizationInfoType AuthorizationInfo
		{
			get
			{
				return this.AuthorizationInfoField;
			}
			set
			{
				this.AuthorizationInfoField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string MsgSubIDField;
		public string MsgSubID
		{
			get
			{
				return this.MsgSubIDField;
			}
			set
			{
				this.MsgSubIDField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DoAuthorizationResponseType(){
		}


		public DoAuthorizationResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("TransactionID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("TransactionID")[0]))
			{
				this.TransactionID = (string)document.GetElementsByTagName("TransactionID")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("Amount").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Amount")[0]))
				{
					nodeList = document.GetElementsByTagName("Amount");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.Amount =  new BasicAmountType(xmlString);
				}
			}
			if(document.GetElementsByTagName("AuthorizationInfo").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AuthorizationInfo")[0]))
				{
					nodeList = document.GetElementsByTagName("AuthorizationInfo");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.AuthorizationInfo =  new AuthorizationInfoType(xmlString);
				}
			}
		if(document.GetElementsByTagName("MsgSubID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("MsgSubID")[0]))
			{
				this.MsgSubID = (string)document.GetElementsByTagName("MsgSubID")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *
      */
	public partial class DoUATPAuthorizationReq	
	{

		/**
          *No Document Comments
		  */
		private DoUATPAuthorizationRequestType DoUATPAuthorizationRequestField;
		public DoUATPAuthorizationRequestType DoUATPAuthorizationRequest
		{
			get
			{
				return this.DoUATPAuthorizationRequestField;
			}
			set
			{
				this.DoUATPAuthorizationRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DoUATPAuthorizationReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:DoUATPAuthorizationReq>");
			if(DoUATPAuthorizationRequest != null)
			{
				sb.Append("<urn:DoUATPAuthorizationRequest>");
				sb.Append(DoUATPAuthorizationRequest.toXMLString());
				sb.Append("</urn:DoUATPAuthorizationRequest>");
			}
			sb.Append("</urn:DoUATPAuthorizationReq>");
			return sb.ToString();
		}
	}




	/**
      *UATP card details Required 
      */
	public partial class DoUATPAuthorizationRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private UATPDetailsType UATPDetailsField;
		public UATPDetailsType UATPDetails
		{
			get
			{
				return this.UATPDetailsField;
			}
			set
			{
				this.UATPDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private TransactionEntityType? TransactionEntityField;
		public TransactionEntityType? TransactionEntity
		{
			get
			{
				return this.TransactionEntityField;
			}
			set
			{
				this.TransactionEntityField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private BasicAmountType AmountField;
		public BasicAmountType Amount
		{
			get
			{
				return this.AmountField;
			}
			set
			{
				this.AmountField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string InvoiceIDField;
		public string InvoiceID
		{
			get
			{
				return this.InvoiceIDField;
			}
			set
			{
				this.InvoiceIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string MsgSubIDField;
		public string MsgSubID
		{
			get
			{
				return this.MsgSubIDField;
			}
			set
			{
				this.MsgSubIDField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public DoUATPAuthorizationRequestType(UATPDetailsType UATPDetails, BasicAmountType Amount){
			this.UATPDetails = UATPDetails;
			this.Amount = Amount;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public DoUATPAuthorizationRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(UATPDetails != null)
			{
				sb.Append("<ebl:UATPDetails>");
				sb.Append(UATPDetails.toXMLString());
				sb.Append("</ebl:UATPDetails>");
			}
			if(TransactionEntity != null)
			{
				sb.Append("<urn:TransactionEntity>").Append(EnumUtils.getDescription(TransactionEntity));
				sb.Append("</urn:TransactionEntity>");
			}
			if(Amount != null)
			{
				sb.Append("<urn:Amount");
				sb.Append(Amount.toXMLString());
				sb.Append("</urn:Amount>");
			}
			if(InvoiceID != null)
			{
				sb.Append("<urn:InvoiceID>").Append(InvoiceID);
				sb.Append("</urn:InvoiceID>");
			}
			if(MsgSubID != null)
			{
				sb.Append("<urn:MsgSubID>").Append(MsgSubID);
				sb.Append("</urn:MsgSubID>");
			}
			return sb.ToString();
		}
	}




	/**
      *Auth Authorization Code. 
      */
	public partial class DoUATPAuthorizationResponseType : DoAuthorizationResponseType	
	{

		/**
          *No Document Comments
		  */
		private UATPDetailsType UATPDetailsField;
		public UATPDetailsType UATPDetails
		{
			get
			{
				return this.UATPDetailsField;
			}
			set
			{
				this.UATPDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string AuthorizationCodeField;
		public string AuthorizationCode
		{
			get
			{
				return this.AuthorizationCodeField;
			}
			set
			{
				this.AuthorizationCodeField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string InvoiceIDField;
		public string InvoiceID
		{
			get
			{
				return this.InvoiceIDField;
			}
			set
			{
				this.InvoiceIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string MsgSubIDField;
		public string MsgSubID
		{
			get
			{
				return this.MsgSubIDField;
			}
			set
			{
				this.MsgSubIDField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DoUATPAuthorizationResponseType(){
		}


		public DoUATPAuthorizationResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("UATPDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("UATPDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("UATPDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.UATPDetails =  new UATPDetailsType(xmlString);
				}
			}
		if(document.GetElementsByTagName("AuthorizationCode").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("AuthorizationCode")[0]))
			{
				this.AuthorizationCode = (string)document.GetElementsByTagName("AuthorizationCode")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("InvoiceID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("InvoiceID")[0]))
			{
				this.InvoiceID = (string)document.GetElementsByTagName("InvoiceID")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("MsgSubID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("MsgSubID")[0]))
			{
				this.MsgSubID = (string)document.GetElementsByTagName("MsgSubID")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *
      */
	public partial class CreateMobilePaymentReq	
	{

		/**
          *No Document Comments
		  */
		private CreateMobilePaymentRequestType CreateMobilePaymentRequestField;
		public CreateMobilePaymentRequestType CreateMobilePaymentRequest
		{
			get
			{
				return this.CreateMobilePaymentRequestField;
			}
			set
			{
				this.CreateMobilePaymentRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public CreateMobilePaymentReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:CreateMobilePaymentReq>");
			if(CreateMobilePaymentRequest != null)
			{
				sb.Append("<urn:CreateMobilePaymentRequest>");
				sb.Append(CreateMobilePaymentRequest.toXMLString());
				sb.Append("</urn:CreateMobilePaymentRequest>");
			}
			sb.Append("</urn:CreateMobilePaymentReq>");
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class CreateMobilePaymentRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private CreateMobilePaymentRequestDetailsType CreateMobilePaymentRequestDetailsField;
		public CreateMobilePaymentRequestDetailsType CreateMobilePaymentRequestDetails
		{
			get
			{
				return this.CreateMobilePaymentRequestDetailsField;
			}
			set
			{
				this.CreateMobilePaymentRequestDetailsField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public CreateMobilePaymentRequestType(CreateMobilePaymentRequestDetailsType CreateMobilePaymentRequestDetails){
			this.CreateMobilePaymentRequestDetails = CreateMobilePaymentRequestDetails;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public CreateMobilePaymentRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(CreateMobilePaymentRequestDetails != null)
			{
				sb.Append("<ebl:CreateMobilePaymentRequestDetails>");
				sb.Append(CreateMobilePaymentRequestDetails.toXMLString());
				sb.Append("</ebl:CreateMobilePaymentRequestDetails>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class CreateMobilePaymentResponseType : AbstractResponseType	
	{

		/**
	 	  * Default Constructor
	 	  */
	 	public CreateMobilePaymentResponseType(){
		}


		public CreateMobilePaymentResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
	
		}
		
	}




	/**
      *
      */
	public partial class GetMobileStatusReq	
	{

		/**
          *No Document Comments
		  */
		private GetMobileStatusRequestType GetMobileStatusRequestField;
		public GetMobileStatusRequestType GetMobileStatusRequest
		{
			get
			{
				return this.GetMobileStatusRequestField;
			}
			set
			{
				this.GetMobileStatusRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public GetMobileStatusReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:GetMobileStatusReq>");
			if(GetMobileStatusRequest != null)
			{
				sb.Append("<urn:GetMobileStatusRequest>");
				sb.Append(GetMobileStatusRequest.toXMLString());
				sb.Append("</urn:GetMobileStatusRequest>");
			}
			sb.Append("</urn:GetMobileStatusReq>");
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class GetMobileStatusRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private GetMobileStatusRequestDetailsType GetMobileStatusRequestDetailsField;
		public GetMobileStatusRequestDetailsType GetMobileStatusRequestDetails
		{
			get
			{
				return this.GetMobileStatusRequestDetailsField;
			}
			set
			{
				this.GetMobileStatusRequestDetailsField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public GetMobileStatusRequestType(GetMobileStatusRequestDetailsType GetMobileStatusRequestDetails){
			this.GetMobileStatusRequestDetails = GetMobileStatusRequestDetails;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public GetMobileStatusRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(GetMobileStatusRequestDetails != null)
			{
				sb.Append("<ebl:GetMobileStatusRequestDetails>");
				sb.Append(GetMobileStatusRequestDetails.toXMLString());
				sb.Append("</ebl:GetMobileStatusRequestDetails>");
			}
			return sb.ToString();
		}
	}




	/**
      *Indicates whether the phone is activated for mobile payments
      *
      */
	public partial class GetMobileStatusResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private int? IsActivatedField;
		public int? IsActivated
		{
			get
			{
				return this.IsActivatedField;
			}
			set
			{
				this.IsActivatedField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? PaymentPendingField;
		public int? PaymentPending
		{
			get
			{
				return this.PaymentPendingField;
			}
			set
			{
				this.PaymentPendingField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public GetMobileStatusResponseType(){
		}


		public GetMobileStatusResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("IsActivated").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("IsActivated")[0]))
			{
				this.IsActivated = System.Convert.ToInt32(document.GetElementsByTagName("IsActivated")[0].InnerText);
			}
		}
		if(document.GetElementsByTagName("PaymentPending").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("PaymentPending")[0]))
			{
				this.PaymentPending = System.Convert.ToInt32(document.GetElementsByTagName("PaymentPending")[0].InnerText);
			}
		}
	
		}
		
	}




	/**
      *
      */
	public partial class SetMobileCheckoutReq	
	{

		/**
          *No Document Comments
		  */
		private SetMobileCheckoutRequestType SetMobileCheckoutRequestField;
		public SetMobileCheckoutRequestType SetMobileCheckoutRequest
		{
			get
			{
				return this.SetMobileCheckoutRequestField;
			}
			set
			{
				this.SetMobileCheckoutRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public SetMobileCheckoutReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:SetMobileCheckoutReq>");
			if(SetMobileCheckoutRequest != null)
			{
				sb.Append("<urn:SetMobileCheckoutRequest>");
				sb.Append(SetMobileCheckoutRequest.toXMLString());
				sb.Append("</urn:SetMobileCheckoutRequest>");
			}
			sb.Append("</urn:SetMobileCheckoutReq>");
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class SetMobileCheckoutRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private SetMobileCheckoutRequestDetailsType SetMobileCheckoutRequestDetailsField;
		public SetMobileCheckoutRequestDetailsType SetMobileCheckoutRequestDetails
		{
			get
			{
				return this.SetMobileCheckoutRequestDetailsField;
			}
			set
			{
				this.SetMobileCheckoutRequestDetailsField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public SetMobileCheckoutRequestType(SetMobileCheckoutRequestDetailsType SetMobileCheckoutRequestDetails){
			this.SetMobileCheckoutRequestDetails = SetMobileCheckoutRequestDetails;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public SetMobileCheckoutRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(SetMobileCheckoutRequestDetails != null)
			{
				sb.Append("<ebl:SetMobileCheckoutRequestDetails>");
				sb.Append(SetMobileCheckoutRequestDetails.toXMLString());
				sb.Append("</ebl:SetMobileCheckoutRequestDetails>");
			}
			return sb.ToString();
		}
	}




	/**
      *A timestamped token by which you identify to PayPal that you
      *are processing this payment with Mobile Checkout. The token
      *expires after three hours. Character length and limitations:
      *20 single-byte characters
      */
	public partial class SetMobileCheckoutResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private string TokenField;
		public string Token
		{
			get
			{
				return this.TokenField;
			}
			set
			{
				this.TokenField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public SetMobileCheckoutResponseType(){
		}


		public SetMobileCheckoutResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("Token").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Token")[0]))
			{
				this.Token = (string)document.GetElementsByTagName("Token")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *
      */
	public partial class DoMobileCheckoutPaymentReq	
	{

		/**
          *No Document Comments
		  */
		private DoMobileCheckoutPaymentRequestType DoMobileCheckoutPaymentRequestField;
		public DoMobileCheckoutPaymentRequestType DoMobileCheckoutPaymentRequest
		{
			get
			{
				return this.DoMobileCheckoutPaymentRequestField;
			}
			set
			{
				this.DoMobileCheckoutPaymentRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DoMobileCheckoutPaymentReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:DoMobileCheckoutPaymentReq>");
			if(DoMobileCheckoutPaymentRequest != null)
			{
				sb.Append("<urn:DoMobileCheckoutPaymentRequest>");
				sb.Append(DoMobileCheckoutPaymentRequest.toXMLString());
				sb.Append("</urn:DoMobileCheckoutPaymentRequest>");
			}
			sb.Append("</urn:DoMobileCheckoutPaymentReq>");
			return sb.ToString();
		}
	}




	/**
      *A timestamped token, the value of which was returned by
      *SetMobileCheckoutResponse. RequiredCharacter length and
      *limitations: 20 single-byte characters
      */
	public partial class DoMobileCheckoutPaymentRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private string TokenField;
		public string Token
		{
			get
			{
				return this.TokenField;
			}
			set
			{
				this.TokenField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public DoMobileCheckoutPaymentRequestType(string Token){
			this.Token = Token;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public DoMobileCheckoutPaymentRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(Token != null)
			{
				sb.Append("<urn:Token>").Append(Token);
				sb.Append("</urn:Token>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class DoMobileCheckoutPaymentResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private DoMobileCheckoutPaymentResponseDetailsType DoMobileCheckoutPaymentResponseDetailsField;
		public DoMobileCheckoutPaymentResponseDetailsType DoMobileCheckoutPaymentResponseDetails
		{
			get
			{
				return this.DoMobileCheckoutPaymentResponseDetailsField;
			}
			set
			{
				this.DoMobileCheckoutPaymentResponseDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DoMobileCheckoutPaymentResponseType(){
		}


		public DoMobileCheckoutPaymentResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("DoMobileCheckoutPaymentResponseDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("DoMobileCheckoutPaymentResponseDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("DoMobileCheckoutPaymentResponseDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.DoMobileCheckoutPaymentResponseDetails =  new DoMobileCheckoutPaymentResponseDetailsType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *
      */
	public partial class GetBalanceReq	
	{

		/**
          *No Document Comments
		  */
		private GetBalanceRequestType GetBalanceRequestField;
		public GetBalanceRequestType GetBalanceRequest
		{
			get
			{
				return this.GetBalanceRequestField;
			}
			set
			{
				this.GetBalanceRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public GetBalanceReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:GetBalanceReq>");
			if(GetBalanceRequest != null)
			{
				sb.Append("<urn:GetBalanceRequest>");
				sb.Append(GetBalanceRequest.toXMLString());
				sb.Append("</urn:GetBalanceRequest>");
			}
			sb.Append("</urn:GetBalanceReq>");
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class GetBalanceRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private string ReturnAllCurrenciesField;
		public string ReturnAllCurrencies
		{
			get
			{
				return this.ReturnAllCurrenciesField;
			}
			set
			{
				this.ReturnAllCurrenciesField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public GetBalanceRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(ReturnAllCurrencies != null)
			{
				sb.Append("<urn:ReturnAllCurrencies>").Append(ReturnAllCurrencies);
				sb.Append("</urn:ReturnAllCurrencies>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class GetBalanceResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private BasicAmountType BalanceField;
		public BasicAmountType Balance
		{
			get
			{
				return this.BalanceField;
			}
			set
			{
				this.BalanceField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string BalanceTimeStampField;
		public string BalanceTimeStamp
		{
			get
			{
				return this.BalanceTimeStampField;
			}
			set
			{
				this.BalanceTimeStampField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private List<BasicAmountType> BalanceHoldingsField = new List<BasicAmountType>();
		public List<BasicAmountType> BalanceHoldings
		{
			get
			{
				return this.BalanceHoldingsField;
			}
			set
			{
				this.BalanceHoldingsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public GetBalanceResponseType(){
		}


		public GetBalanceResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("Balance").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Balance")[0]))
				{
					nodeList = document.GetElementsByTagName("Balance");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.Balance =  new BasicAmountType(xmlString);
				}
			}
		if(document.GetElementsByTagName("BalanceTimeStamp").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BalanceTimeStamp")[0]))
			{
				this.BalanceTimeStamp = (string)document.GetElementsByTagName("BalanceTimeStamp")[0].InnerText;
			}
		}
			if(document.GetElementsByTagName("BalanceHoldings").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BalanceHoldings")[0]))
				{
					nodeList = document.GetElementsByTagName("BalanceHoldings");
					for(int i = 0; i < nodeList.Count; i++)
					{
						xmlString = DeserializationUtils.convertToXML(nodeList[i]);
						this.BalanceHoldings.Add(new BasicAmountType(xmlString));
					}
				}
			}
	
		}
		
	}




	/**
      *
      */
	public partial class SetCustomerBillingAgreementReq	
	{

		/**
          *No Document Comments
		  */
		private SetCustomerBillingAgreementRequestType SetCustomerBillingAgreementRequestField;
		public SetCustomerBillingAgreementRequestType SetCustomerBillingAgreementRequest
		{
			get
			{
				return this.SetCustomerBillingAgreementRequestField;
			}
			set
			{
				this.SetCustomerBillingAgreementRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public SetCustomerBillingAgreementReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:SetCustomerBillingAgreementReq>");
			if(SetCustomerBillingAgreementRequest != null)
			{
				sb.Append("<urn:SetCustomerBillingAgreementRequest>");
				sb.Append(SetCustomerBillingAgreementRequest.toXMLString());
				sb.Append("</urn:SetCustomerBillingAgreementRequest>");
			}
			sb.Append("</urn:SetCustomerBillingAgreementReq>");
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class SetCustomerBillingAgreementRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private SetCustomerBillingAgreementRequestDetailsType SetCustomerBillingAgreementRequestDetailsField;
		public SetCustomerBillingAgreementRequestDetailsType SetCustomerBillingAgreementRequestDetails
		{
			get
			{
				return this.SetCustomerBillingAgreementRequestDetailsField;
			}
			set
			{
				this.SetCustomerBillingAgreementRequestDetailsField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public SetCustomerBillingAgreementRequestType(SetCustomerBillingAgreementRequestDetailsType SetCustomerBillingAgreementRequestDetails){
			this.SetCustomerBillingAgreementRequestDetails = SetCustomerBillingAgreementRequestDetails;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public SetCustomerBillingAgreementRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(SetCustomerBillingAgreementRequestDetails != null)
			{
				sb.Append("<ebl:SetCustomerBillingAgreementRequestDetails>");
				sb.Append(SetCustomerBillingAgreementRequestDetails.toXMLString());
				sb.Append("</ebl:SetCustomerBillingAgreementRequestDetails>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class SetCustomerBillingAgreementResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private string TokenField;
		public string Token
		{
			get
			{
				return this.TokenField;
			}
			set
			{
				this.TokenField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public SetCustomerBillingAgreementResponseType(){
		}


		public SetCustomerBillingAgreementResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("Token").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Token")[0]))
			{
				this.Token = (string)document.GetElementsByTagName("Token")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *
      */
	public partial class GetBillingAgreementCustomerDetailsReq	
	{

		/**
          *No Document Comments
		  */
		private GetBillingAgreementCustomerDetailsRequestType GetBillingAgreementCustomerDetailsRequestField;
		public GetBillingAgreementCustomerDetailsRequestType GetBillingAgreementCustomerDetailsRequest
		{
			get
			{
				return this.GetBillingAgreementCustomerDetailsRequestField;
			}
			set
			{
				this.GetBillingAgreementCustomerDetailsRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public GetBillingAgreementCustomerDetailsReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:GetBillingAgreementCustomerDetailsReq>");
			if(GetBillingAgreementCustomerDetailsRequest != null)
			{
				sb.Append("<urn:GetBillingAgreementCustomerDetailsRequest>");
				sb.Append(GetBillingAgreementCustomerDetailsRequest.toXMLString());
				sb.Append("</urn:GetBillingAgreementCustomerDetailsRequest>");
			}
			sb.Append("</urn:GetBillingAgreementCustomerDetailsReq>");
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class GetBillingAgreementCustomerDetailsRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private string TokenField;
		public string Token
		{
			get
			{
				return this.TokenField;
			}
			set
			{
				this.TokenField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public GetBillingAgreementCustomerDetailsRequestType(string Token){
			this.Token = Token;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public GetBillingAgreementCustomerDetailsRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(Token != null)
			{
				sb.Append("<urn:Token>").Append(Token);
				sb.Append("</urn:Token>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class GetBillingAgreementCustomerDetailsResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private GetBillingAgreementCustomerDetailsResponseDetailsType GetBillingAgreementCustomerDetailsResponseDetailsField;
		public GetBillingAgreementCustomerDetailsResponseDetailsType GetBillingAgreementCustomerDetailsResponseDetails
		{
			get
			{
				return this.GetBillingAgreementCustomerDetailsResponseDetailsField;
			}
			set
			{
				this.GetBillingAgreementCustomerDetailsResponseDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public GetBillingAgreementCustomerDetailsResponseType(){
		}


		public GetBillingAgreementCustomerDetailsResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("GetBillingAgreementCustomerDetailsResponseDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GetBillingAgreementCustomerDetailsResponseDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("GetBillingAgreementCustomerDetailsResponseDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.GetBillingAgreementCustomerDetailsResponseDetails =  new GetBillingAgreementCustomerDetailsResponseDetailsType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *
      */
	public partial class CreateBillingAgreementReq	
	{

		/**
          *No Document Comments
		  */
		private CreateBillingAgreementRequestType CreateBillingAgreementRequestField;
		public CreateBillingAgreementRequestType CreateBillingAgreementRequest
		{
			get
			{
				return this.CreateBillingAgreementRequestField;
			}
			set
			{
				this.CreateBillingAgreementRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public CreateBillingAgreementReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:CreateBillingAgreementReq>");
			if(CreateBillingAgreementRequest != null)
			{
				sb.Append("<urn:CreateBillingAgreementRequest>");
				sb.Append(CreateBillingAgreementRequest.toXMLString());
				sb.Append("</urn:CreateBillingAgreementRequest>");
			}
			sb.Append("</urn:CreateBillingAgreementReq>");
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class CreateBillingAgreementRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private string TokenField;
		public string Token
		{
			get
			{
				return this.TokenField;
			}
			set
			{
				this.TokenField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public CreateBillingAgreementRequestType(string Token){
			this.Token = Token;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public CreateBillingAgreementRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(Token != null)
			{
				sb.Append("<urn:Token>").Append(Token);
				sb.Append("</urn:Token>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class CreateBillingAgreementResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private string BillingAgreementIDField;
		public string BillingAgreementID
		{
			get
			{
				return this.BillingAgreementIDField;
			}
			set
			{
				this.BillingAgreementIDField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public CreateBillingAgreementResponseType(){
		}


		public CreateBillingAgreementResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("BillingAgreementID").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillingAgreementID")[0]))
			{
				this.BillingAgreementID = (string)document.GetElementsByTagName("BillingAgreementID")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *
      */
	public partial class DoReferenceTransactionReq	
	{

		/**
          *No Document Comments
		  */
		private DoReferenceTransactionRequestType DoReferenceTransactionRequestField;
		public DoReferenceTransactionRequestType DoReferenceTransactionRequest
		{
			get
			{
				return this.DoReferenceTransactionRequestField;
			}
			set
			{
				this.DoReferenceTransactionRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DoReferenceTransactionReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:DoReferenceTransactionReq>");
			if(DoReferenceTransactionRequest != null)
			{
				sb.Append("<urn:DoReferenceTransactionRequest>");
				sb.Append(DoReferenceTransactionRequest.toXMLString());
				sb.Append("</urn:DoReferenceTransactionRequest>");
			}
			sb.Append("</urn:DoReferenceTransactionReq>");
			return sb.ToString();
		}
	}




	/**
      *This flag indicates that the response should include
      *FMFDetails 
      */
	public partial class DoReferenceTransactionRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private DoReferenceTransactionRequestDetailsType DoReferenceTransactionRequestDetailsField;
		public DoReferenceTransactionRequestDetailsType DoReferenceTransactionRequestDetails
		{
			get
			{
				return this.DoReferenceTransactionRequestDetailsField;
			}
			set
			{
				this.DoReferenceTransactionRequestDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private int? ReturnFMFDetailsField;
		public int? ReturnFMFDetails
		{
			get
			{
				return this.ReturnFMFDetailsField;
			}
			set
			{
				this.ReturnFMFDetailsField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public DoReferenceTransactionRequestType(DoReferenceTransactionRequestDetailsType DoReferenceTransactionRequestDetails){
			this.DoReferenceTransactionRequestDetails = DoReferenceTransactionRequestDetails;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public DoReferenceTransactionRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(DoReferenceTransactionRequestDetails != null)
			{
				sb.Append("<ebl:DoReferenceTransactionRequestDetails>");
				sb.Append(DoReferenceTransactionRequestDetails.toXMLString());
				sb.Append("</ebl:DoReferenceTransactionRequestDetails>");
			}
			if(ReturnFMFDetails != null)
			{
				sb.Append("<urn:ReturnFMFDetails>").Append(ReturnFMFDetails);
				sb.Append("</urn:ReturnFMFDetails>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class DoReferenceTransactionResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private DoReferenceTransactionResponseDetailsType DoReferenceTransactionResponseDetailsField;
		public DoReferenceTransactionResponseDetailsType DoReferenceTransactionResponseDetails
		{
			get
			{
				return this.DoReferenceTransactionResponseDetailsField;
			}
			set
			{
				this.DoReferenceTransactionResponseDetailsField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private FMFDetailsType FMFDetailsField;
		public FMFDetailsType FMFDetails
		{
			get
			{
				return this.FMFDetailsField;
			}
			set
			{
				this.FMFDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DoReferenceTransactionResponseType(){
		}


		public DoReferenceTransactionResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("DoReferenceTransactionResponseDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("DoReferenceTransactionResponseDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("DoReferenceTransactionResponseDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.DoReferenceTransactionResponseDetails =  new DoReferenceTransactionResponseDetailsType(xmlString);
				}
			}
			if(document.GetElementsByTagName("FMFDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("FMFDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("FMFDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.FMFDetails =  new FMFDetailsType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *
      */
	public partial class DoNonReferencedCreditReq	
	{

		/**
          *No Document Comments
		  */
		private DoNonReferencedCreditRequestType DoNonReferencedCreditRequestField;
		public DoNonReferencedCreditRequestType DoNonReferencedCreditRequest
		{
			get
			{
				return this.DoNonReferencedCreditRequestField;
			}
			set
			{
				this.DoNonReferencedCreditRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DoNonReferencedCreditReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:DoNonReferencedCreditReq>");
			if(DoNonReferencedCreditRequest != null)
			{
				sb.Append("<urn:DoNonReferencedCreditRequest>");
				sb.Append(DoNonReferencedCreditRequest.toXMLString());
				sb.Append("</urn:DoNonReferencedCreditRequest>");
			}
			sb.Append("</urn:DoNonReferencedCreditReq>");
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class DoNonReferencedCreditRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private DoNonReferencedCreditRequestDetailsType DoNonReferencedCreditRequestDetailsField;
		public DoNonReferencedCreditRequestDetailsType DoNonReferencedCreditRequestDetails
		{
			get
			{
				return this.DoNonReferencedCreditRequestDetailsField;
			}
			set
			{
				this.DoNonReferencedCreditRequestDetailsField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public DoNonReferencedCreditRequestType(DoNonReferencedCreditRequestDetailsType DoNonReferencedCreditRequestDetails){
			this.DoNonReferencedCreditRequestDetails = DoNonReferencedCreditRequestDetails;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public DoNonReferencedCreditRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(DoNonReferencedCreditRequestDetails != null)
			{
				sb.Append("<ebl:DoNonReferencedCreditRequestDetails>");
				sb.Append(DoNonReferencedCreditRequestDetails.toXMLString());
				sb.Append("</ebl:DoNonReferencedCreditRequestDetails>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class DoNonReferencedCreditResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private DoNonReferencedCreditResponseDetailsType DoNonReferencedCreditResponseDetailsField;
		public DoNonReferencedCreditResponseDetailsType DoNonReferencedCreditResponseDetails
		{
			get
			{
				return this.DoNonReferencedCreditResponseDetailsField;
			}
			set
			{
				this.DoNonReferencedCreditResponseDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DoNonReferencedCreditResponseType(){
		}


		public DoNonReferencedCreditResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("DoNonReferencedCreditResponseDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("DoNonReferencedCreditResponseDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("DoNonReferencedCreditResponseDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.DoNonReferencedCreditResponseDetails =  new DoNonReferencedCreditResponseDetailsType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *
      */
	public partial class CreateRecurringPaymentsProfileReq	
	{

		/**
          *No Document Comments
		  */
		private CreateRecurringPaymentsProfileRequestType CreateRecurringPaymentsProfileRequestField;
		public CreateRecurringPaymentsProfileRequestType CreateRecurringPaymentsProfileRequest
		{
			get
			{
				return this.CreateRecurringPaymentsProfileRequestField;
			}
			set
			{
				this.CreateRecurringPaymentsProfileRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public CreateRecurringPaymentsProfileReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:CreateRecurringPaymentsProfileReq>");
			if(CreateRecurringPaymentsProfileRequest != null)
			{
				sb.Append("<urn:CreateRecurringPaymentsProfileRequest>");
				sb.Append(CreateRecurringPaymentsProfileRequest.toXMLString());
				sb.Append("</urn:CreateRecurringPaymentsProfileRequest>");
			}
			sb.Append("</urn:CreateRecurringPaymentsProfileReq>");
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class CreateRecurringPaymentsProfileRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private CreateRecurringPaymentsProfileRequestDetailsType CreateRecurringPaymentsProfileRequestDetailsField;
		public CreateRecurringPaymentsProfileRequestDetailsType CreateRecurringPaymentsProfileRequestDetails
		{
			get
			{
				return this.CreateRecurringPaymentsProfileRequestDetailsField;
			}
			set
			{
				this.CreateRecurringPaymentsProfileRequestDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public CreateRecurringPaymentsProfileRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(CreateRecurringPaymentsProfileRequestDetails != null)
			{
				sb.Append("<ebl:CreateRecurringPaymentsProfileRequestDetails>");
				sb.Append(CreateRecurringPaymentsProfileRequestDetails.toXMLString());
				sb.Append("</ebl:CreateRecurringPaymentsProfileRequestDetails>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class CreateRecurringPaymentsProfileResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private CreateRecurringPaymentsProfileResponseDetailsType CreateRecurringPaymentsProfileResponseDetailsField;
		public CreateRecurringPaymentsProfileResponseDetailsType CreateRecurringPaymentsProfileResponseDetails
		{
			get
			{
				return this.CreateRecurringPaymentsProfileResponseDetailsField;
			}
			set
			{
				this.CreateRecurringPaymentsProfileResponseDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public CreateRecurringPaymentsProfileResponseType(){
		}


		public CreateRecurringPaymentsProfileResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("CreateRecurringPaymentsProfileResponseDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("CreateRecurringPaymentsProfileResponseDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("CreateRecurringPaymentsProfileResponseDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.CreateRecurringPaymentsProfileResponseDetails =  new CreateRecurringPaymentsProfileResponseDetailsType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *
      */
	public partial class GetRecurringPaymentsProfileDetailsReq	
	{

		/**
          *No Document Comments
		  */
		private GetRecurringPaymentsProfileDetailsRequestType GetRecurringPaymentsProfileDetailsRequestField;
		public GetRecurringPaymentsProfileDetailsRequestType GetRecurringPaymentsProfileDetailsRequest
		{
			get
			{
				return this.GetRecurringPaymentsProfileDetailsRequestField;
			}
			set
			{
				this.GetRecurringPaymentsProfileDetailsRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public GetRecurringPaymentsProfileDetailsReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:GetRecurringPaymentsProfileDetailsReq>");
			if(GetRecurringPaymentsProfileDetailsRequest != null)
			{
				sb.Append("<urn:GetRecurringPaymentsProfileDetailsRequest>");
				sb.Append(GetRecurringPaymentsProfileDetailsRequest.toXMLString());
				sb.Append("</urn:GetRecurringPaymentsProfileDetailsRequest>");
			}
			sb.Append("</urn:GetRecurringPaymentsProfileDetailsReq>");
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class GetRecurringPaymentsProfileDetailsRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private string ProfileIDField;
		public string ProfileID
		{
			get
			{
				return this.ProfileIDField;
			}
			set
			{
				this.ProfileIDField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public GetRecurringPaymentsProfileDetailsRequestType(string ProfileID){
			this.ProfileID = ProfileID;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public GetRecurringPaymentsProfileDetailsRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(ProfileID != null)
			{
				sb.Append("<urn:ProfileID>").Append(ProfileID);
				sb.Append("</urn:ProfileID>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class GetRecurringPaymentsProfileDetailsResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private GetRecurringPaymentsProfileDetailsResponseDetailsType GetRecurringPaymentsProfileDetailsResponseDetailsField;
		public GetRecurringPaymentsProfileDetailsResponseDetailsType GetRecurringPaymentsProfileDetailsResponseDetails
		{
			get
			{
				return this.GetRecurringPaymentsProfileDetailsResponseDetailsField;
			}
			set
			{
				this.GetRecurringPaymentsProfileDetailsResponseDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public GetRecurringPaymentsProfileDetailsResponseType(){
		}


		public GetRecurringPaymentsProfileDetailsResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("GetRecurringPaymentsProfileDetailsResponseDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("GetRecurringPaymentsProfileDetailsResponseDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("GetRecurringPaymentsProfileDetailsResponseDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.GetRecurringPaymentsProfileDetailsResponseDetails =  new GetRecurringPaymentsProfileDetailsResponseDetailsType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *
      */
	public partial class ManageRecurringPaymentsProfileStatusReq	
	{

		/**
          *No Document Comments
		  */
		private ManageRecurringPaymentsProfileStatusRequestType ManageRecurringPaymentsProfileStatusRequestField;
		public ManageRecurringPaymentsProfileStatusRequestType ManageRecurringPaymentsProfileStatusRequest
		{
			get
			{
				return this.ManageRecurringPaymentsProfileStatusRequestField;
			}
			set
			{
				this.ManageRecurringPaymentsProfileStatusRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public ManageRecurringPaymentsProfileStatusReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:ManageRecurringPaymentsProfileStatusReq>");
			if(ManageRecurringPaymentsProfileStatusRequest != null)
			{
				sb.Append("<urn:ManageRecurringPaymentsProfileStatusRequest>");
				sb.Append(ManageRecurringPaymentsProfileStatusRequest.toXMLString());
				sb.Append("</urn:ManageRecurringPaymentsProfileStatusRequest>");
			}
			sb.Append("</urn:ManageRecurringPaymentsProfileStatusReq>");
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class ManageRecurringPaymentsProfileStatusRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private ManageRecurringPaymentsProfileStatusRequestDetailsType ManageRecurringPaymentsProfileStatusRequestDetailsField;
		public ManageRecurringPaymentsProfileStatusRequestDetailsType ManageRecurringPaymentsProfileStatusRequestDetails
		{
			get
			{
				return this.ManageRecurringPaymentsProfileStatusRequestDetailsField;
			}
			set
			{
				this.ManageRecurringPaymentsProfileStatusRequestDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public ManageRecurringPaymentsProfileStatusRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(ManageRecurringPaymentsProfileStatusRequestDetails != null)
			{
				sb.Append("<ebl:ManageRecurringPaymentsProfileStatusRequestDetails>");
				sb.Append(ManageRecurringPaymentsProfileStatusRequestDetails.toXMLString());
				sb.Append("</ebl:ManageRecurringPaymentsProfileStatusRequestDetails>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class ManageRecurringPaymentsProfileStatusResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private ManageRecurringPaymentsProfileStatusResponseDetailsType ManageRecurringPaymentsProfileStatusResponseDetailsField;
		public ManageRecurringPaymentsProfileStatusResponseDetailsType ManageRecurringPaymentsProfileStatusResponseDetails
		{
			get
			{
				return this.ManageRecurringPaymentsProfileStatusResponseDetailsField;
			}
			set
			{
				this.ManageRecurringPaymentsProfileStatusResponseDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public ManageRecurringPaymentsProfileStatusResponseType(){
		}


		public ManageRecurringPaymentsProfileStatusResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("ManageRecurringPaymentsProfileStatusResponseDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ManageRecurringPaymentsProfileStatusResponseDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("ManageRecurringPaymentsProfileStatusResponseDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.ManageRecurringPaymentsProfileStatusResponseDetails =  new ManageRecurringPaymentsProfileStatusResponseDetailsType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *
      */
	public partial class BillOutstandingAmountReq	
	{

		/**
          *No Document Comments
		  */
		private BillOutstandingAmountRequestType BillOutstandingAmountRequestField;
		public BillOutstandingAmountRequestType BillOutstandingAmountRequest
		{
			get
			{
				return this.BillOutstandingAmountRequestField;
			}
			set
			{
				this.BillOutstandingAmountRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public BillOutstandingAmountReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:BillOutstandingAmountReq>");
			if(BillOutstandingAmountRequest != null)
			{
				sb.Append("<urn:BillOutstandingAmountRequest>");
				sb.Append(BillOutstandingAmountRequest.toXMLString());
				sb.Append("</urn:BillOutstandingAmountRequest>");
			}
			sb.Append("</urn:BillOutstandingAmountReq>");
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class BillOutstandingAmountRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private BillOutstandingAmountRequestDetailsType BillOutstandingAmountRequestDetailsField;
		public BillOutstandingAmountRequestDetailsType BillOutstandingAmountRequestDetails
		{
			get
			{
				return this.BillOutstandingAmountRequestDetailsField;
			}
			set
			{
				this.BillOutstandingAmountRequestDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public BillOutstandingAmountRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(BillOutstandingAmountRequestDetails != null)
			{
				sb.Append("<ebl:BillOutstandingAmountRequestDetails>");
				sb.Append(BillOutstandingAmountRequestDetails.toXMLString());
				sb.Append("</ebl:BillOutstandingAmountRequestDetails>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class BillOutstandingAmountResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private BillOutstandingAmountResponseDetailsType BillOutstandingAmountResponseDetailsField;
		public BillOutstandingAmountResponseDetailsType BillOutstandingAmountResponseDetails
		{
			get
			{
				return this.BillOutstandingAmountResponseDetailsField;
			}
			set
			{
				this.BillOutstandingAmountResponseDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public BillOutstandingAmountResponseType(){
		}


		public BillOutstandingAmountResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("BillOutstandingAmountResponseDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("BillOutstandingAmountResponseDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("BillOutstandingAmountResponseDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.BillOutstandingAmountResponseDetails =  new BillOutstandingAmountResponseDetailsType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *
      */
	public partial class UpdateRecurringPaymentsProfileReq	
	{

		/**
          *No Document Comments
		  */
		private UpdateRecurringPaymentsProfileRequestType UpdateRecurringPaymentsProfileRequestField;
		public UpdateRecurringPaymentsProfileRequestType UpdateRecurringPaymentsProfileRequest
		{
			get
			{
				return this.UpdateRecurringPaymentsProfileRequestField;
			}
			set
			{
				this.UpdateRecurringPaymentsProfileRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public UpdateRecurringPaymentsProfileReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:UpdateRecurringPaymentsProfileReq>");
			if(UpdateRecurringPaymentsProfileRequest != null)
			{
				sb.Append("<urn:UpdateRecurringPaymentsProfileRequest>");
				sb.Append(UpdateRecurringPaymentsProfileRequest.toXMLString());
				sb.Append("</urn:UpdateRecurringPaymentsProfileRequest>");
			}
			sb.Append("</urn:UpdateRecurringPaymentsProfileReq>");
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class UpdateRecurringPaymentsProfileRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private UpdateRecurringPaymentsProfileRequestDetailsType UpdateRecurringPaymentsProfileRequestDetailsField;
		public UpdateRecurringPaymentsProfileRequestDetailsType UpdateRecurringPaymentsProfileRequestDetails
		{
			get
			{
				return this.UpdateRecurringPaymentsProfileRequestDetailsField;
			}
			set
			{
				this.UpdateRecurringPaymentsProfileRequestDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public UpdateRecurringPaymentsProfileRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(UpdateRecurringPaymentsProfileRequestDetails != null)
			{
				sb.Append("<ebl:UpdateRecurringPaymentsProfileRequestDetails>");
				sb.Append(UpdateRecurringPaymentsProfileRequestDetails.toXMLString());
				sb.Append("</ebl:UpdateRecurringPaymentsProfileRequestDetails>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class UpdateRecurringPaymentsProfileResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private UpdateRecurringPaymentsProfileResponseDetailsType UpdateRecurringPaymentsProfileResponseDetailsField;
		public UpdateRecurringPaymentsProfileResponseDetailsType UpdateRecurringPaymentsProfileResponseDetails
		{
			get
			{
				return this.UpdateRecurringPaymentsProfileResponseDetailsField;
			}
			set
			{
				this.UpdateRecurringPaymentsProfileResponseDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public UpdateRecurringPaymentsProfileResponseType(){
		}


		public UpdateRecurringPaymentsProfileResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("UpdateRecurringPaymentsProfileResponseDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("UpdateRecurringPaymentsProfileResponseDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("UpdateRecurringPaymentsProfileResponseDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.UpdateRecurringPaymentsProfileResponseDetails =  new UpdateRecurringPaymentsProfileResponseDetailsType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *
      */
	public partial class GetPalDetailsReq	
	{

		/**
          *No Document Comments
		  */
		private GetPalDetailsRequestType GetPalDetailsRequestField;
		public GetPalDetailsRequestType GetPalDetailsRequest
		{
			get
			{
				return this.GetPalDetailsRequestField;
			}
			set
			{
				this.GetPalDetailsRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public GetPalDetailsReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:GetPalDetailsReq>");
			if(GetPalDetailsRequest != null)
			{
				sb.Append("<urn:GetPalDetailsRequest>");
				sb.Append(GetPalDetailsRequest.toXMLString());
				sb.Append("</urn:GetPalDetailsRequest>");
			}
			sb.Append("</urn:GetPalDetailsReq>");
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class GetPalDetailsRequestType : AbstractRequestType	
	{

		/**
	 	  * Default Constructor
	 	  */
	 	public GetPalDetailsRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class GetPalDetailsResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private string PalField;
		public string Pal
		{
			get
			{
				return this.PalField;
			}
			set
			{
				this.PalField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private string LocaleField;
		public string Locale
		{
			get
			{
				return this.LocaleField;
			}
			set
			{
				this.LocaleField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public GetPalDetailsResponseType(){
		}


		public GetPalDetailsResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
		if(document.GetElementsByTagName("Pal").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Pal")[0]))
			{
				this.Pal = (string)document.GetElementsByTagName("Pal")[0].InnerText;
			}
		}
		if(document.GetElementsByTagName("Locale").Count != 0)
		{
			if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("Locale")[0]))
			{
				this.Locale = (string)document.GetElementsByTagName("Locale")[0].InnerText;
			}
		}
	
		}
		
	}




	/**
      *
      */
	public partial class ReverseTransactionReq	
	{

		/**
          *No Document Comments
		  */
		private ReverseTransactionRequestType ReverseTransactionRequestField;
		public ReverseTransactionRequestType ReverseTransactionRequest
		{
			get
			{
				return this.ReverseTransactionRequestField;
			}
			set
			{
				this.ReverseTransactionRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public ReverseTransactionReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:ReverseTransactionReq>");
			if(ReverseTransactionRequest != null)
			{
				sb.Append("<urn:ReverseTransactionRequest>");
				sb.Append(ReverseTransactionRequest.toXMLString());
				sb.Append("</urn:ReverseTransactionRequest>");
			}
			sb.Append("</urn:ReverseTransactionReq>");
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class ReverseTransactionRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private ReverseTransactionRequestDetailsType ReverseTransactionRequestDetailsField;
		public ReverseTransactionRequestDetailsType ReverseTransactionRequestDetails
		{
			get
			{
				return this.ReverseTransactionRequestDetailsField;
			}
			set
			{
				this.ReverseTransactionRequestDetailsField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public ReverseTransactionRequestType(ReverseTransactionRequestDetailsType ReverseTransactionRequestDetails){
			this.ReverseTransactionRequestDetails = ReverseTransactionRequestDetails;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public ReverseTransactionRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(ReverseTransactionRequestDetails != null)
			{
				sb.Append("<ebl:ReverseTransactionRequestDetails>");
				sb.Append(ReverseTransactionRequestDetails.toXMLString());
				sb.Append("</ebl:ReverseTransactionRequestDetails>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class ReverseTransactionResponseType : AbstractResponseType	
	{

		/**
          *No Document Comments
		  */
		private ReverseTransactionResponseDetailsType ReverseTransactionResponseDetailsField;
		public ReverseTransactionResponseDetailsType ReverseTransactionResponseDetails
		{
			get
			{
				return this.ReverseTransactionResponseDetailsField;
			}
			set
			{
				this.ReverseTransactionResponseDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public ReverseTransactionResponseType(){
		}


		public ReverseTransactionResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
			if(document.GetElementsByTagName("ReverseTransactionResponseDetails").Count != 0)
			{
				if(!DeserializationUtils.isWhiteSpaceNode(document.GetElementsByTagName("ReverseTransactionResponseDetails")[0]))
				{
					nodeList = document.GetElementsByTagName("ReverseTransactionResponseDetails");
					xmlString = DeserializationUtils.convertToXML(nodeList[0]);
					this.ReverseTransactionResponseDetails =  new ReverseTransactionResponseDetailsType(xmlString);
				}
			}
	
		}
		
	}




	/**
      *
      */
	public partial class ExternalRememberMeOptOutReq	
	{

		/**
          *No Document Comments
		  */
		private ExternalRememberMeOptOutRequestType ExternalRememberMeOptOutRequestField;
		public ExternalRememberMeOptOutRequestType ExternalRememberMeOptOutRequest
		{
			get
			{
				return this.ExternalRememberMeOptOutRequestField;
			}
			set
			{
				this.ExternalRememberMeOptOutRequestField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public ExternalRememberMeOptOutReq(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:ExternalRememberMeOptOutReq>");
			if(ExternalRememberMeOptOutRequest != null)
			{
				sb.Append("<urn:ExternalRememberMeOptOutRequest>");
				sb.Append(ExternalRememberMeOptOutRequest.toXMLString());
				sb.Append("</urn:ExternalRememberMeOptOutRequest>");
			}
			sb.Append("</urn:ExternalRememberMeOptOutReq>");
			return sb.ToString();
		}
	}




	/**
      *The merchant passes in the ExternalRememberMeID to identify
      *the user to opt out. This is a 17-character alphanumeric
      *(encrypted) string that identifies the buyer's remembered
      *login with a merchant and has meaning only to the merchant.
      *Required 
      */
	public partial class ExternalRememberMeOptOutRequestType : AbstractRequestType	
	{

		/**
          *No Document Comments
		  */
		private string ExternalRememberMeIDField;
		public string ExternalRememberMeID
		{
			get
			{
				return this.ExternalRememberMeIDField;
			}
			set
			{
				this.ExternalRememberMeIDField = value;
			}
		}
		

		/**
          *No Document Comments
		  */
		private ExternalRememberMeOwnerDetailsType ExternalRememberMeOwnerDetailsField;
		public ExternalRememberMeOwnerDetailsType ExternalRememberMeOwnerDetails
		{
			get
			{
				return this.ExternalRememberMeOwnerDetailsField;
			}
			set
			{
				this.ExternalRememberMeOwnerDetailsField = value;
			}
		}
		

		/**
	 	  * Constructor with arguments
	 	  */
	 	public ExternalRememberMeOptOutRequestType(string ExternalRememberMeID){
			this.ExternalRememberMeID = ExternalRememberMeID;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public ExternalRememberMeOptOutRequestType(){
		}


		public string toXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.toXMLString());
			if(ExternalRememberMeID != null)
			{
				sb.Append("<urn:ExternalRememberMeID>").Append(ExternalRememberMeID);
				sb.Append("</urn:ExternalRememberMeID>");
			}
			if(ExternalRememberMeOwnerDetails != null)
			{
				sb.Append("<urn:ExternalRememberMeOwnerDetails>");
				sb.Append(ExternalRememberMeOwnerDetails.toXMLString());
				sb.Append("</urn:ExternalRememberMeOwnerDetails>");
			}
			return sb.ToString();
		}
	}




	/**
      *
      */
	public partial class ExternalRememberMeOptOutResponseType : AbstractResponseType	
	{

		/**
	 	  * Default Constructor
	 	  */
	 	public ExternalRememberMeOptOutResponseType(){
		}


		public ExternalRememberMeOptOutResponseType(Object xmlSoap) : base(xmlSoap)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlSoap.ToString());
			XmlNodeList nodeList = null;
			string xmlString = "";
	
		}
		
	}





}