/**
  * Stub objects for PayPalAPIInterfaceService 
  * AUTO_GENERATED_CODE 
  */
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using PayPal.Util;

namespace PayPal.PayPalAPIInterfaceService.Model
{

	public static class EnumUtils
	{
		public static string GetDescription(Enum value)
		{
			string description = "";
			DescriptionAttribute[] attributes = (DescriptionAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
			{
				description= attributes[0].Description;
			}
			return description;
		}
		
		public static object GetValue(string value,Type enumType)
		{
			string[] names = Enum.GetNames(enumType);
			foreach(string name in names)
            {
            	if (GetDescription((Enum)Enum.Parse(enumType, name)).Equals(value))
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
				return (val.Trim().Length == 0);
			}
			else if (n.NodeType == XmlNodeType.Element)
			{
				return (n.ChildNodes.Count == 0);
			}
			else
			{
				return false;
			}
		}
		
		public static string escapeInvalidXmlCharsRegex(string textContent)
        {
            string response = null;
            if (textContent != null && textContent.Length > 0)
            {
                response = Regex.Replace(
                                Regex.Replace(
                                    Regex.Replace(
                                        Regex.Replace(
                                            Regex.Replace(textContent, "&(?!(amp;|lt;|gt;|quot;|apos;))", "&amp;"), 
                                        "<", "&lt;"), 
                                    ">", "&gt;"), 
                                "\"", "&quot;"), 
                           "'", "&apos;");
            }
            return response;
        }
        
        public static string escapeInvalidXmlCharsRegex(int? intContent)
        {
            string response = null;
            if (intContent != null)
            {
                string textContent = intContent.ToString();
                response = escapeInvalidXmlCharsRegex(textContent);
            }
            return response;
        }

        public static string escapeInvalidXmlCharsRegex(decimal? decimalContent)
        {
            string response = null;
            if (decimalContent != null)
            {
                string textContent = decimalContent.ToString();
                response = escapeInvalidXmlCharsRegex(textContent);
            }
            return response;
        }

        public static string escapeInvalidXmlCharsRegex(bool? boolContent)
        {
            string response = null;
            if (boolContent != null)
            {
                string textContent = boolContent.ToString();
                response = escapeInvalidXmlCharsRegex(textContent);
            }
            return response;
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
	public partial class BasicAmountType	{

		/**
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(GetAttributeAsXml());
			sb.Append(">");
			if(value != null)
			{
				sb.Append(DeserializationUtils.escapeInvalidXmlCharsRegex(value));
			}
			return sb.ToString();
		}

		
		private string GetAttributeAsXml()
		{
			StringBuilder sb = new StringBuilder();
		if(currencyID != null)
		{
			sb.Append(" currencyID=\"").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(currencyID))).Append("\"");	
		}
			
			return sb.ToString();
		}
		public BasicAmountType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("@*[local-name() = 'currencyID']");
			if (ChildNode != null)
			{
				this.currencyID = (CurrencyCodeType)EnumUtils.GetValue(ChildNode.Value, typeof(CurrencyCodeType));	
			}
			this.value = xmlNode.InnerText;
	
		}
	}




	/**
      *
      */
	public partial class MeasureType	{

		/**
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(GetAttributeAsXml());
			sb.Append(">");
			if(value != null)
			{
				sb.Append(DeserializationUtils.escapeInvalidXmlCharsRegex(value));
			}
			return sb.ToString();
		}

		
		private string GetAttributeAsXml()
		{
			StringBuilder sb = new StringBuilder();
		if(unit != null)
		{
			sb.Append(" unit =\"").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(unit)).Append("\"");
		}
			
			return sb.ToString();
		}
		public MeasureType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'unit']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.unit = ChildNode.InnerText;
			}
			this.value = System.Convert.ToDecimal(xmlNode.InnerText);
	
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
    [Serializable]
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
    [Serializable]
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
    [Serializable]
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
    [Serializable]
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
    [Serializable]
	public enum DetailLevelCodeType {
		[Description("ReturnAll")]RETURNALL,	
		[Description("ItemReturnDescription")]ITEMRETURNDESCRIPTION,	
		[Description("ItemReturnAttributes")]ITEMRETURNATTRIBUTES	
	}




	/**
      * This defines if the incentive is applied on Ebay or PayPal.
      *            
      */
    [Serializable]
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
    [Serializable]
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
    [Serializable]
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
    [Serializable]
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
    [Serializable]
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
    [Serializable]
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
    [Serializable]
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
    [Serializable]
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
    [Serializable]
	public enum RedeemedOfferType {
		[Description("MERCHANT_COUPON")]MERCHANTCOUPON,	
		[Description("LOYALTY_CARD")]LOYALTYCARD,	
		[Description("MANUFACTURER_COUPON")]MANUFACTURERCOUPON,	
		[Description("RESERVED")]RESERVED	
	}




	/**
      *Supported API Types for DoCancel operation
      */
    [Serializable]
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
    [Serializable]
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
    [Serializable]
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
    [Serializable]
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
    [Serializable]
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
    [Serializable]
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
    [Serializable]
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
    [Serializable]
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
    [Serializable]
	public enum FMFPendingTransactionActionType {
		[Description("Accept")]ACCEPT,	
		[Description("Deny")]DENY	
	}




	/**
      * ChannelType - Type declaration to be used by other schemas.
      * This is the PayPal Channel type (used by Express Checkout)
      * 
      */
    [Serializable]
	public enum ChannelType {
		[Description("Merchant")]MERCHANT,	
		[Description("eBayItem")]EBAYITEM	
	}




	/**
      * TotalType - Type declaration for the label to be displayed
      * in MiniCart for UX.
      * 
      */
    [Serializable]
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
    [Serializable]
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
    [Serializable]
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
    [Serializable]
	public enum LandingPageType {
		[Description("None")]NONE,	
		[Description("Login")]LOGIN,	
		[Description("Billing")]BILLING	
	}




	/**
      * 
      */
    [Serializable]
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
    [Serializable]
	public enum ApprovalTypeType {
		[Description("BillingAgreement")]BILLINGAGREEMENT,	
		[Description("Profile")]PROFILE	
	}




	/**
      * 
      */
    [Serializable]
	public enum ApprovalSubTypeType {
		[Description("None")]NONE,	
		[Description("MerchantInitiatedBilling")]MERCHANTINITIATEDBILLING,	
		[Description("MerchantInitiatedBillingSingleAgreement")]MERCHANTINITIATEDBILLINGSINGLEAGREEMENT,	
		[Description("ChannelInitiatedBilling")]CHANNELINITIATEDBILLING	
	}




	/**
      * PendingStatusCodeType 
      * The pending status for a PayPal Payment transaction which
      *matches the output from IPN
      * 
      */
    [Serializable]
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
    [Serializable]
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
    [Serializable]
	public enum ReversalReasonCodeType {
		[Description("none")]NONE,	
		[Description("chargeback")]CHARGEBACK,	
		[Description("guarantee")]GUARANTEE,	
		[Description("buyer-complaint")]BUYERCOMPLAINT,	
		[Description("refund")]REFUND,	
		[Description("other")]OTHER	
	}




	/**
      * POSTransactionCodeType
      * POS Transaction Code Type. F for Forced Post Transaction
      *and S for Single Call Checkout
      * 
      */
    [Serializable]
	public enum POSTransactionCodeType {
		[Description("F")]F,	
		[Description("S")]S	
	}




	/**
      * PaymentCodeType 
      * This is the type of PayPal payment which matches the output
      *from IPN.
      * 
      */
    [Serializable]
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
    [Serializable]
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
    [Serializable]
	public enum PayPalUserStatusCodeType {
		[Description("verified")]VERIFIED,	
		[Description("unverified")]UNVERIFIED	
	}




	/**
      * MerchantPullPaymentCodeType 
      * Type of Payment to be initiated by the merchant
      * 
      */
    [Serializable]
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
    [Serializable]
	public enum MerchantPullStatusCodeType {
		[Description("Active")]ACTIVE,	
		[Description("Canceled")]CANCELED	
	}




	/**
      * PaymentTransactionStatusCodeType 
      * The status of the PayPal payment.
      * 
      */
    [Serializable]
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
    [Serializable]
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
		[Description("ForcedPostTransaction")]FORCEDPOSTTRANSACTION,	
		[Description("NonReferencedRefunds")]NONREFERENCEDREFUNDS	
	}




	/**
      * MatchStatusCodeType 
      * This is the PayPal (street/zip) match code
      * 
      */
    [Serializable]
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
    [Serializable]
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
    [Serializable]
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
    [Serializable]
	public enum MobileRecipientCodeType {
		[Description("PhoneNumber")]PHONENUMBER,	
		[Description("EmailAddress")]EMAILADDRESS	
	}




	/**
      * MobilePaymentCodeType 
      * These are the accepted types of mobile payments
      * 
      */
    [Serializable]
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
    [Serializable]
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
    [Serializable]
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
    [Serializable]
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
    [Serializable]
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
    [Serializable]
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
    [Serializable]
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
    [Serializable]
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
    [Serializable]
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
    [Serializable]
	public enum BankAccountTypeType {
		[Description("Checking")]CHECKING,	
		[Description("Savings")]SAVINGS	
	}




	/**
      * Boarding Status 
      * 
      */
    [Serializable]
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
    [Serializable]
	public enum UserWithdrawalLimitTypeType {
		[Description("Unknown")]UNKNOWN,	
		[Description("Limited")]LIMITED,	
		[Description("Unlimited")]UNLIMITED	
	}




	/**
      * API Authentication Type 
      * 
      */
    [Serializable]
	public enum APIAuthenticationType {
		[Description("Auth-None")]AUTHNONE,	
		[Description("Cert")]CERT,	
		[Description("Sign")]SIGN	
	}




	/**
      * 
      */
    [Serializable]
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
    [Serializable]
	public enum FailedPaymentActionType {
		[Description("CancelOnFailure")]CANCELONFAILURE,	
		[Description("ContinueOnFailure")]CONTINUEONFAILURE	
	}




	/**
      * 
      */
    [Serializable]
	public enum AutoBillType {
		[Description("NoAutoBill")]NOAUTOBILL,	
		[Description("AddToNextBilling")]ADDTONEXTBILLING	
	}




	/**
      * 
      */
    [Serializable]
	public enum StatusChangeActionType {
		[Description("Cancel")]CANCEL,	
		[Description("Suspend")]SUSPEND,	
		[Description("Reactivate")]REACTIVATE	
	}




	/**
      * 
      */
    [Serializable]
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
    [Serializable]
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
    [Serializable]
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
    [Serializable]
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
    [Serializable]
	public enum ButtonSubTypeType {
		[Description("PRODUCTS")]PRODUCTS,	
		[Description("SERVICES")]SERVICES	
	}




	/**
      * Types of button images
      * 
      */
    [Serializable]
	public enum ButtonImageType {
		[Description("REG")]REG,	
		[Description("SML")]SML,	
		[Description("CC")]CC	
	}




	/**
      * values for buynow button text
      * 
      */
    [Serializable]
	public enum BuyNowTextType {
		[Description("BUYNOW")]BUYNOW,	
		[Description("PAYNOW")]PAYNOW	
	}




	/**
      * values for subscribe button text
      * 
      */
    [Serializable]
	public enum SubscribeTextType {
		[Description("BUYNOW")]BUYNOW,	
		[Description("SUBSCRIBE")]SUBSCRIBE	
	}




	/**
      * values for subscribe button text
      * 
      */
    [Serializable]
	public enum ButtonStatusType {
		[Description("DELETE")]DELETE	
	}




	/**
      * 
      */
    [Serializable]
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
    [Serializable]
	public enum UserSelectedFundingSourceType {
		[Description("ELV")]ELV,	
		[Description("CreditCard")]CREDITCARD,	
		[Description("ChinaUnionPay")]CHINAUNIONPAY,	
		[Description("BML")]BML	
	}




	/**
      * 
      */
    [Serializable]
	public enum ItemCategoryType {
		[Description("Physical")]PHYSICAL,	
		[Description("Digital")]DIGITAL	
	}




	/**
      * 
      */
    [Serializable]
	public enum RecurringFlagType {
		[Description("Y")]Y1,	
		[Description("y")]Y2	
	}




	/**
      * Defines couple relationship type between buckets 
      */
    [Serializable]
	public enum CoupleType {
		[Description("LifeTime")]LIFETIME	
	}




	/**
      * Category of payment like international shipping
      * 
      */
    [Serializable]
	public enum PaymentCategoryType {
		[Description("InternationalShipping")]INTERNATIONALSHIPPING	
	}




	/**
      *Value of the application-specific error parameter.  
      */
	public partial class ErrorParameterType	{

		/**
          *
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


		public ErrorParameterType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Value']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Value = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *Error code can be used by a receiving application to
      *debugging a response message. These codes will need to be
      *uniquely defined for each application. 
      */
	public partial class ErrorType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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


		public ErrorType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ShortMessage']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ShortMessage = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'LongMessage']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.LongMessage = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ErrorCode']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ErrorCode = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'SeverityCode']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.SeverityCode = (SeverityCodeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(SeverityCodeType));
			}
			ChildNodeList = xmlNode.SelectNodes("*[local-name() = 'ErrorParameters']");
			if (ChildNodeList != null && ChildNodeList.Count > 0)
			{
				for(int i = 0; i < ChildNodeList.Count; i++)
				{
					XmlNode subNode = ChildNodeList.Item(i);
					this.ErrorParameters.Add(new ErrorParameterType(subNode));
				}
			}
	
		}
	}




	/**
      *Base type definition of request payload that can carry any
      *type of payload content with optional versioning information
      *and detail level requirements. 
      */
	public partial class AbstractRequestType	{

		/**
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(DetailLevel != null)
			{
				for(int i = 0; i < DetailLevel.Count; i++)
				{
					sb.Append("<ebl:DetailLevel>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(DetailLevel[i]))).Append("</ebl:DetailLevel>");
				}
			}
			if(ErrorLanguage != null)
			{
				sb.Append("<ebl:ErrorLanguage>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ErrorLanguage));
				sb.Append("</ebl:ErrorLanguage>");
			}
			if(Version != null)
			{
				sb.Append("<ebl:Version>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Version));
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
	public partial class AbstractResponseType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public AbstractResponseType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Timestamp']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Timestamp = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Ack']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Ack = (AckCodeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(AckCodeType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'CorrelationID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.CorrelationID = ChildNode.InnerText;
			}
			ChildNodeList = xmlNode.SelectNodes("*[local-name() = 'Errors']");
			if (ChildNodeList != null && ChildNodeList.Count > 0)
			{
				for(int i = 0; i < ChildNodeList.Count; i++)
				{
					XmlNode subNode = ChildNodeList.Item(i);
					this.Errors.Add(new ErrorType(subNode));
				}
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Version']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Version = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Build']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Build = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *Country code associated with this phone number. 
      */
	public partial class PhoneNumberType	{

		/**
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(CountryCode != null)
			{
				sb.Append("<ebl:CountryCode>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(CountryCode));
				sb.Append("</ebl:CountryCode>");
			}
			if(PhoneNumber != null)
			{
				sb.Append("<ebl:PhoneNumber>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(PhoneNumber));
				sb.Append("</ebl:PhoneNumber>");
			}
			if(Extension != null)
			{
				sb.Append("<ebl:Extension>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Extension));
				sb.Append("</ebl:Extension>");
			}
			return sb.ToString();
		}

	}




	/**
      *Person's name associated with this address. Character length
      *and limitations: 32 single-byte alphanumeric characters 
      */
	public partial class AddressType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Name != null)
			{
				sb.Append("<ebl:Name>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Name));
				sb.Append("</ebl:Name>");
			}
			if(Street1 != null)
			{
				sb.Append("<ebl:Street1>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Street1));
				sb.Append("</ebl:Street1>");
			}
			if(Street2 != null)
			{
				sb.Append("<ebl:Street2>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Street2));
				sb.Append("</ebl:Street2>");
			}
			if(CityName != null)
			{
				sb.Append("<ebl:CityName>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(CityName));
				sb.Append("</ebl:CityName>");
			}
			if(StateOrProvince != null)
			{
				sb.Append("<ebl:StateOrProvince>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(StateOrProvince));
				sb.Append("</ebl:StateOrProvince>");
			}
			if(Country != null)
			{
				sb.Append("<ebl:Country>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(Country)));
				sb.Append("</ebl:Country>");
			}
			if(CountryName != null)
			{
				sb.Append("<ebl:CountryName>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(CountryName));
				sb.Append("</ebl:CountryName>");
			}
			if(Phone != null)
			{
				sb.Append("<ebl:Phone>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Phone));
				sb.Append("</ebl:Phone>");
			}
			if(PostalCode != null)
			{
				sb.Append("<ebl:PostalCode>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(PostalCode));
				sb.Append("</ebl:PostalCode>");
			}
			if(AddressID != null)
			{
				sb.Append("<ebl:AddressID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(AddressID));
				sb.Append("</ebl:AddressID>");
			}
			if(AddressOwner != null)
			{
				sb.Append("<ebl:AddressOwner>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(AddressOwner)));
				sb.Append("</ebl:AddressOwner>");
			}
			if(ExternalAddressID != null)
			{
				sb.Append("<ebl:ExternalAddressID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ExternalAddressID));
				sb.Append("</ebl:ExternalAddressID>");
			}
			if(InternationalName != null)
			{
				sb.Append("<ebl:InternationalName>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(InternationalName));
				sb.Append("</ebl:InternationalName>");
			}
			if(InternationalStateAndCity != null)
			{
				sb.Append("<ebl:InternationalStateAndCity>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(InternationalStateAndCity));
				sb.Append("</ebl:InternationalStateAndCity>");
			}
			if(InternationalStreet != null)
			{
				sb.Append("<ebl:InternationalStreet>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(InternationalStreet));
				sb.Append("</ebl:InternationalStreet>");
			}
			if(AddressStatus != null)
			{
				sb.Append("<ebl:AddressStatus>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(AddressStatus)));
				sb.Append("</ebl:AddressStatus>");
			}
			return sb.ToString();
		}

		public AddressType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Name']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Name = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Street1']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Street1 = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Street2']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Street2 = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'CityName']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.CityName = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'StateOrProvince']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.StateOrProvince = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Country']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Country = (CountryCodeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(CountryCodeType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'CountryName']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.CountryName = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Phone']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Phone = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PostalCode']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PostalCode = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'AddressID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.AddressID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'AddressOwner']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.AddressOwner = (AddressOwnerCodeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(AddressOwnerCodeType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ExternalAddressID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ExternalAddressID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'InternationalName']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.InternationalName = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'InternationalStateAndCity']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.InternationalStateAndCity = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'InternationalStreet']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.InternationalStreet = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'AddressStatus']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.AddressStatus = (AddressStatusCodeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(AddressStatusCodeType));
			}
	
		}
	}




	/**
      *
      */
	public partial class PersonNameType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Salutation != null)
			{
				sb.Append("<ebl:Salutation>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Salutation));
				sb.Append("</ebl:Salutation>");
			}
			if(FirstName != null)
			{
				sb.Append("<ebl:FirstName>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(FirstName));
				sb.Append("</ebl:FirstName>");
			}
			if(MiddleName != null)
			{
				sb.Append("<ebl:MiddleName>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(MiddleName));
				sb.Append("</ebl:MiddleName>");
			}
			if(LastName != null)
			{
				sb.Append("<ebl:LastName>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(LastName));
				sb.Append("</ebl:LastName>");
			}
			if(Suffix != null)
			{
				sb.Append("<ebl:Suffix>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Suffix));
				sb.Append("</ebl:Suffix>");
			}
			return sb.ToString();
		}

		public PersonNameType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Salutation']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Salutation = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'FirstName']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.FirstName = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'MiddleName']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.MiddleName = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'LastName']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.LastName = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Suffix']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Suffix = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *
      */
	public partial class IncentiveAppliedToType	{

		/**
          *
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
          *
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
          *
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
          *
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


		public IncentiveAppliedToType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'BucketId']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.BucketId = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ItemId']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ItemId = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'IncentiveAmount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.IncentiveAmount =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'SubType']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.SubType = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *
      */
	public partial class IncentiveDetailType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public IncentiveDetailType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'RedemptionCode']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.RedemptionCode = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'DisplayCode']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.DisplayCode = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ProgramId']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ProgramId = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'IncentiveType']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.IncentiveType = (IncentiveTypeCodeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(IncentiveTypeCodeType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'IncentiveDescription']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.IncentiveDescription = ChildNode.InnerText;
			}
			ChildNodeList = xmlNode.SelectNodes("*[local-name() = 'AppliedTo']");
			if (ChildNodeList != null && ChildNodeList.Count > 0)
			{
				for(int i = 0; i < ChildNodeList.Count; i++)
				{
					XmlNode subNode = ChildNodeList.Item(i);
					this.AppliedTo.Add(new IncentiveAppliedToType(subNode));
				}
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Status']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Status = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ErrorCode']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ErrorCode = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *
      */
	public partial class IncentiveItemType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ItemId != null)
			{
				sb.Append("<ebl:ItemId>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ItemId));
				sb.Append("</ebl:ItemId>");
			}
			if(PurchaseTime != null)
			{
				sb.Append("<ebl:PurchaseTime>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(PurchaseTime));
				sb.Append("</ebl:PurchaseTime>");
			}
			if(ItemCategoryList != null)
			{
				sb.Append("<ebl:ItemCategoryList>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ItemCategoryList));
				sb.Append("</ebl:ItemCategoryList>");
			}
			if(ItemPrice != null)
			{
				sb.Append("<ebl:ItemPrice");
				sb.Append(ItemPrice.ToXMLString());
				sb.Append("</ebl:ItemPrice>");
			}
			if(ItemQuantity != null)
			{
				sb.Append("<ebl:ItemQuantity>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ItemQuantity));
				sb.Append("</ebl:ItemQuantity>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class IncentiveBucketType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Items != null)
			{
				for(int i = 0; i < Items.Count; i++)
				{
					sb.Append("<ebl:Items>");
					sb.Append(Items[i].ToXMLString());
					sb.Append("</ebl:Items>");
				}
			}
			if(BucketId != null)
			{
				sb.Append("<ebl:BucketId>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(BucketId));
				sb.Append("</ebl:BucketId>");
			}
			if(SellerId != null)
			{
				sb.Append("<ebl:SellerId>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(SellerId));
				sb.Append("</ebl:SellerId>");
			}
			if(ExternalSellerId != null)
			{
				sb.Append("<ebl:ExternalSellerId>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ExternalSellerId));
				sb.Append("</ebl:ExternalSellerId>");
			}
			if(BucketSubtotalAmt != null)
			{
				sb.Append("<ebl:BucketSubtotalAmt");
				sb.Append(BucketSubtotalAmt.ToXMLString());
				sb.Append("</ebl:BucketSubtotalAmt>");
			}
			if(BucketShippingAmt != null)
			{
				sb.Append("<ebl:BucketShippingAmt");
				sb.Append(BucketShippingAmt.ToXMLString());
				sb.Append("</ebl:BucketShippingAmt>");
			}
			if(BucketInsuranceAmt != null)
			{
				sb.Append("<ebl:BucketInsuranceAmt");
				sb.Append(BucketInsuranceAmt.ToXMLString());
				sb.Append("</ebl:BucketInsuranceAmt>");
			}
			if(BucketSalesTaxAmt != null)
			{
				sb.Append("<ebl:BucketSalesTaxAmt");
				sb.Append(BucketSalesTaxAmt.ToXMLString());
				sb.Append("</ebl:BucketSalesTaxAmt>");
			}
			if(BucketTotalAmt != null)
			{
				sb.Append("<ebl:BucketTotalAmt");
				sb.Append(BucketTotalAmt.ToXMLString());
				sb.Append("</ebl:BucketTotalAmt>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class IncentiveRequestDetailsType	{

		/**
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(RequestId != null)
			{
				sb.Append("<ebl:RequestId>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(RequestId));
				sb.Append("</ebl:RequestId>");
			}
			if(RequestType != null)
			{
				sb.Append("<ebl:RequestType>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(RequestType)));
				sb.Append("</ebl:RequestType>");
			}
			if(RequestDetailLevel != null)
			{
				sb.Append("<ebl:RequestDetailLevel>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(RequestDetailLevel)));
				sb.Append("</ebl:RequestDetailLevel>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class GetIncentiveEvaluationRequestDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ExternalBuyerId != null)
			{
				sb.Append("<ebl:ExternalBuyerId>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ExternalBuyerId));
				sb.Append("</ebl:ExternalBuyerId>");
			}
			if(IncentiveCodes != null)
			{
				for(int i = 0; i < IncentiveCodes.Count; i++)
				{
					sb.Append("<ebl:IncentiveCodes>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(IncentiveCodes[i]));
					sb.Append("</ebl:IncentiveCodes>");
				}
			}
			if(ApplyIndication != null)
			{
				for(int i = 0; i < ApplyIndication.Count; i++)
				{
					sb.Append("<ebl:ApplyIndication>");
					sb.Append(ApplyIndication[i].ToXMLString());
					sb.Append("</ebl:ApplyIndication>");
				}
			}
			if(Buckets != null)
			{
				for(int i = 0; i < Buckets.Count; i++)
				{
					sb.Append("<ebl:Buckets>");
					sb.Append(Buckets[i].ToXMLString());
					sb.Append("</ebl:Buckets>");
				}
			}
			if(CartTotalAmt != null)
			{
				sb.Append("<ebl:CartTotalAmt");
				sb.Append(CartTotalAmt.ToXMLString());
				sb.Append("</ebl:CartTotalAmt>");
			}
			if(RequestDetails != null)
			{
				sb.Append("<ebl:RequestDetails>");
				sb.Append(RequestDetails.ToXMLString());
				sb.Append("</ebl:RequestDetails>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class GetIncentiveEvaluationResponseDetailsType	{

		/**
          *
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
          *
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


		public GetIncentiveEvaluationResponseDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNodeList = xmlNode.SelectNodes("*[local-name() = 'IncentiveDetails']");
			if (ChildNodeList != null && ChildNodeList.Count > 0)
			{
				for(int i = 0; i < ChildNodeList.Count; i++)
				{
					XmlNode subNode = ChildNodeList.Item(i);
					this.IncentiveDetails.Add(new IncentiveDetailType(subNode));
				}
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'RequestId']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.RequestId = ChildNode.InnerText;
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
	public partial class SetExpressCheckoutRequestDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
		  */
		private List<CoupledBucketsType> CoupledBucketsField = new List<CoupledBucketsType>();
		public List<CoupledBucketsType> CoupledBuckets
		{
			get
			{
				return this.CoupledBucketsField;
			}
			set
			{
				this.CoupledBucketsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public SetExpressCheckoutRequestDetailsType(){
		}


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(OrderTotal != null)
			{
				sb.Append("<ebl:OrderTotal");
				sb.Append(OrderTotal.ToXMLString());
				sb.Append("</ebl:OrderTotal>");
			}
			if(ReturnURL != null)
			{
				sb.Append("<ebl:ReturnURL>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ReturnURL));
				sb.Append("</ebl:ReturnURL>");
			}
			if(CancelURL != null)
			{
				sb.Append("<ebl:CancelURL>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(CancelURL));
				sb.Append("</ebl:CancelURL>");
			}
			if(TrackingImageURL != null)
			{
				sb.Append("<ebl:TrackingImageURL>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(TrackingImageURL));
				sb.Append("</ebl:TrackingImageURL>");
			}
			if(giropaySuccessURL != null)
			{
				sb.Append("<ebl:giropaySuccessURL>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(giropaySuccessURL));
				sb.Append("</ebl:giropaySuccessURL>");
			}
			if(giropayCancelURL != null)
			{
				sb.Append("<ebl:giropayCancelURL>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(giropayCancelURL));
				sb.Append("</ebl:giropayCancelURL>");
			}
			if(BanktxnPendingURL != null)
			{
				sb.Append("<ebl:BanktxnPendingURL>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(BanktxnPendingURL));
				sb.Append("</ebl:BanktxnPendingURL>");
			}
			if(Token != null)
			{
				sb.Append("<ebl:Token>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Token));
				sb.Append("</ebl:Token>");
			}
			if(MaxAmount != null)
			{
				sb.Append("<ebl:MaxAmount");
				sb.Append(MaxAmount.ToXMLString());
				sb.Append("</ebl:MaxAmount>");
			}
			if(OrderDescription != null)
			{
				sb.Append("<ebl:OrderDescription>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(OrderDescription));
				sb.Append("</ebl:OrderDescription>");
			}
			if(Custom != null)
			{
				sb.Append("<ebl:Custom>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Custom));
				sb.Append("</ebl:Custom>");
			}
			if(InvoiceID != null)
			{
				sb.Append("<ebl:InvoiceID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(InvoiceID));
				sb.Append("</ebl:InvoiceID>");
			}
			if(ReqConfirmShipping != null)
			{
				sb.Append("<ebl:ReqConfirmShipping>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ReqConfirmShipping));
				sb.Append("</ebl:ReqConfirmShipping>");
			}
			if(ReqBillingAddress != null)
			{
				sb.Append("<ebl:ReqBillingAddress>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ReqBillingAddress));
				sb.Append("</ebl:ReqBillingAddress>");
			}
			if(BillingAddress != null)
			{
				sb.Append("<ebl:BillingAddress>");
				sb.Append(BillingAddress.ToXMLString());
				sb.Append("</ebl:BillingAddress>");
			}
			if(NoShipping != null)
			{
				sb.Append("<ebl:NoShipping>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(NoShipping));
				sb.Append("</ebl:NoShipping>");
			}
			if(AddressOverride != null)
			{
				sb.Append("<ebl:AddressOverride>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(AddressOverride));
				sb.Append("</ebl:AddressOverride>");
			}
			if(LocaleCode != null)
			{
				sb.Append("<ebl:LocaleCode>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(LocaleCode));
				sb.Append("</ebl:LocaleCode>");
			}
			if(PageStyle != null)
			{
				sb.Append("<ebl:PageStyle>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(PageStyle));
				sb.Append("</ebl:PageStyle>");
			}
			if(cppHeaderImage != null)
			{
				sb.Append("<ebl:cpp-header-image>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(cppHeaderImage));
				sb.Append("</ebl:cpp-header-image>");
			}
			if(cppHeaderBorderColor != null)
			{
				sb.Append("<ebl:cpp-header-border-color>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(cppHeaderBorderColor));
				sb.Append("</ebl:cpp-header-border-color>");
			}
			if(cppHeaderBackColor != null)
			{
				sb.Append("<ebl:cpp-header-back-color>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(cppHeaderBackColor));
				sb.Append("</ebl:cpp-header-back-color>");
			}
			if(cppPayflowColor != null)
			{
				sb.Append("<ebl:cpp-payflow-color>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(cppPayflowColor));
				sb.Append("</ebl:cpp-payflow-color>");
			}
			if(cppCartBorderColor != null)
			{
				sb.Append("<ebl:cpp-cart-border-color>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(cppCartBorderColor));
				sb.Append("</ebl:cpp-cart-border-color>");
			}
			if(cppLogoImage != null)
			{
				sb.Append("<ebl:cpp-logo-image>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(cppLogoImage));
				sb.Append("</ebl:cpp-logo-image>");
			}
			if(Address != null)
			{
				sb.Append("<ebl:Address>");
				sb.Append(Address.ToXMLString());
				sb.Append("</ebl:Address>");
			}
			if(PaymentAction != null)
			{
				sb.Append("<ebl:PaymentAction>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(PaymentAction)));
				sb.Append("</ebl:PaymentAction>");
			}
			if(SolutionType != null)
			{
				sb.Append("<ebl:SolutionType>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(SolutionType)));
				sb.Append("</ebl:SolutionType>");
			}
			if(LandingPage != null)
			{
				sb.Append("<ebl:LandingPage>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(LandingPage)));
				sb.Append("</ebl:LandingPage>");
			}
			if(BuyerEmail != null)
			{
				sb.Append("<ebl:BuyerEmail>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(BuyerEmail));
				sb.Append("</ebl:BuyerEmail>");
			}
			if(ChannelType != null)
			{
				sb.Append("<ebl:ChannelType>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(ChannelType)));
				sb.Append("</ebl:ChannelType>");
			}
			if(BillingAgreementDetails != null)
			{
				for(int i = 0; i < BillingAgreementDetails.Count; i++)
				{
					sb.Append("<ebl:BillingAgreementDetails>");
					sb.Append(BillingAgreementDetails[i].ToXMLString());
					sb.Append("</ebl:BillingAgreementDetails>");
				}
			}
			if(PromoCodes != null)
			{
				for(int i = 0; i < PromoCodes.Count; i++)
				{
					sb.Append("<ebl:PromoCodes>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(PromoCodes[i]));
					sb.Append("</ebl:PromoCodes>");
				}
			}
			if(PayPalCheckOutBtnType != null)
			{
				sb.Append("<ebl:PayPalCheckOutBtnType>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(PayPalCheckOutBtnType));
				sb.Append("</ebl:PayPalCheckOutBtnType>");
			}
			if(ProductCategory != null)
			{
				sb.Append("<ebl:ProductCategory>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(ProductCategory)));
				sb.Append("</ebl:ProductCategory>");
			}
			if(ShippingMethod != null)
			{
				sb.Append("<ebl:ShippingMethod>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(ShippingMethod)));
				sb.Append("</ebl:ShippingMethod>");
			}
			if(ProfileAddressChangeDate != null)
			{
				sb.Append("<ebl:ProfileAddressChangeDate>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ProfileAddressChangeDate));
				sb.Append("</ebl:ProfileAddressChangeDate>");
			}
			if(AllowNote != null)
			{
				sb.Append("<ebl:AllowNote>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(AllowNote));
				sb.Append("</ebl:AllowNote>");
			}
			if(FundingSourceDetails != null)
			{
				sb.Append("<ebl:FundingSourceDetails>");
				sb.Append(FundingSourceDetails.ToXMLString());
				sb.Append("</ebl:FundingSourceDetails>");
			}
			if(BrandName != null)
			{
				sb.Append("<ebl:BrandName>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(BrandName));
				sb.Append("</ebl:BrandName>");
			}
			if(CallbackURL != null)
			{
				sb.Append("<ebl:CallbackURL>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(CallbackURL));
				sb.Append("</ebl:CallbackURL>");
			}
			if(EnhancedCheckoutData != null)
			{
				sb.Append("<ebl:EnhancedCheckoutData>");
				sb.Append(EnhancedCheckoutData.ToXMLString());
				sb.Append("</ebl:EnhancedCheckoutData>");
			}
			if(OtherPaymentMethods != null)
			{
				for(int i = 0; i < OtherPaymentMethods.Count; i++)
				{
					sb.Append("<ebl:OtherPaymentMethods>");
					sb.Append(OtherPaymentMethods[i].ToXMLString());
					sb.Append("</ebl:OtherPaymentMethods>");
				}
			}
			if(BuyerDetails != null)
			{
				sb.Append("<ebl:BuyerDetails>");
				sb.Append(BuyerDetails.ToXMLString());
				sb.Append("</ebl:BuyerDetails>");
			}
			if(PaymentDetails != null)
			{
				for(int i = 0; i < PaymentDetails.Count; i++)
				{
					sb.Append("<ebl:PaymentDetails>");
					sb.Append(PaymentDetails[i].ToXMLString());
					sb.Append("</ebl:PaymentDetails>");
				}
			}
			if(FlatRateShippingOptions != null)
			{
				for(int i = 0; i < FlatRateShippingOptions.Count; i++)
				{
					sb.Append("<ebl:FlatRateShippingOptions>");
					sb.Append(FlatRateShippingOptions[i].ToXMLString());
					sb.Append("</ebl:FlatRateShippingOptions>");
				}
			}
			if(CallbackTimeout != null)
			{
				sb.Append("<ebl:CallbackTimeout>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(CallbackTimeout));
				sb.Append("</ebl:CallbackTimeout>");
			}
			if(CallbackVersion != null)
			{
				sb.Append("<ebl:CallbackVersion>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(CallbackVersion));
				sb.Append("</ebl:CallbackVersion>");
			}
			if(CustomerServiceNumber != null)
			{
				sb.Append("<ebl:CustomerServiceNumber>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(CustomerServiceNumber));
				sb.Append("</ebl:CustomerServiceNumber>");
			}
			if(GiftMessageEnable != null)
			{
				sb.Append("<ebl:GiftMessageEnable>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(GiftMessageEnable));
				sb.Append("</ebl:GiftMessageEnable>");
			}
			if(GiftReceiptEnable != null)
			{
				sb.Append("<ebl:GiftReceiptEnable>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(GiftReceiptEnable));
				sb.Append("</ebl:GiftReceiptEnable>");
			}
			if(GiftWrapEnable != null)
			{
				sb.Append("<ebl:GiftWrapEnable>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(GiftWrapEnable));
				sb.Append("</ebl:GiftWrapEnable>");
			}
			if(GiftWrapName != null)
			{
				sb.Append("<ebl:GiftWrapName>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(GiftWrapName));
				sb.Append("</ebl:GiftWrapName>");
			}
			if(GiftWrapAmount != null)
			{
				sb.Append("<ebl:GiftWrapAmount");
				sb.Append(GiftWrapAmount.ToXMLString());
				sb.Append("</ebl:GiftWrapAmount>");
			}
			if(BuyerEmailOptInEnable != null)
			{
				sb.Append("<ebl:BuyerEmailOptInEnable>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(BuyerEmailOptInEnable));
				sb.Append("</ebl:BuyerEmailOptInEnable>");
			}
			if(SurveyEnable != null)
			{
				sb.Append("<ebl:SurveyEnable>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(SurveyEnable));
				sb.Append("</ebl:SurveyEnable>");
			}
			if(SurveyQuestion != null)
			{
				sb.Append("<ebl:SurveyQuestion>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(SurveyQuestion));
				sb.Append("</ebl:SurveyQuestion>");
			}
			if(SurveyChoice != null)
			{
				for(int i = 0; i < SurveyChoice.Count; i++)
				{
					sb.Append("<ebl:SurveyChoice>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(SurveyChoice[i]));
					sb.Append("</ebl:SurveyChoice>");
				}
			}
			if(TotalType != null)
			{
				sb.Append("<ebl:TotalType>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(TotalType)));
				sb.Append("</ebl:TotalType>");
			}
			if(NoteToBuyer != null)
			{
				sb.Append("<ebl:NoteToBuyer>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(NoteToBuyer));
				sb.Append("</ebl:NoteToBuyer>");
			}
			if(Incentives != null)
			{
				for(int i = 0; i < Incentives.Count; i++)
				{
					sb.Append("<ebl:Incentives>");
					sb.Append(Incentives[i].ToXMLString());
					sb.Append("</ebl:Incentives>");
				}
			}
			if(ReqInstrumentDetails != null)
			{
				sb.Append("<ebl:ReqInstrumentDetails>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ReqInstrumentDetails));
				sb.Append("</ebl:ReqInstrumentDetails>");
			}
			if(ExternalRememberMeOptInDetails != null)
			{
				sb.Append("<ebl:ExternalRememberMeOptInDetails>");
				sb.Append(ExternalRememberMeOptInDetails.ToXMLString());
				sb.Append("</ebl:ExternalRememberMeOptInDetails>");
			}
			if(FlowControlDetails != null)
			{
				sb.Append("<ebl:FlowControlDetails>");
				sb.Append(FlowControlDetails.ToXMLString());
				sb.Append("</ebl:FlowControlDetails>");
			}
			if(DisplayControlDetails != null)
			{
				sb.Append("<ebl:DisplayControlDetails>");
				sb.Append(DisplayControlDetails.ToXMLString());
				sb.Append("</ebl:DisplayControlDetails>");
			}
			if(ExternalPartnerTrackingDetails != null)
			{
				sb.Append("<ebl:ExternalPartnerTrackingDetails>");
				sb.Append(ExternalPartnerTrackingDetails.ToXMLString());
				sb.Append("</ebl:ExternalPartnerTrackingDetails>");
			}
			if(CoupledBuckets != null)
			{
				for(int i = 0; i < CoupledBuckets.Count; i++)
				{
					sb.Append("<ebl:CoupledBuckets>");
					sb.Append(CoupledBuckets[i].ToXMLString());
					sb.Append("</ebl:CoupledBuckets>");
				}
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
	public partial class ExecuteCheckoutOperationsRequestDetailsType	{

		/**
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Token != null)
			{
				sb.Append("<ebl:Token>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Token));
				sb.Append("</ebl:Token>");
			}
			if(SetDataRequest != null)
			{
				sb.Append("<ebl:SetDataRequest>");
				sb.Append(SetDataRequest.ToXMLString());
				sb.Append("</ebl:SetDataRequest>");
			}
			if(AuthorizationRequest != null)
			{
				sb.Append("<ebl:AuthorizationRequest>");
				sb.Append(AuthorizationRequest.ToXMLString());
				sb.Append("</ebl:AuthorizationRequest>");
			}
			return sb.ToString();
		}

	}




	/**
      *Details about Billing Agreements requested to be created. 
      */
	public partial class SetDataRequestType	{

		/**
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(BillingApprovalDetails != null)
			{
				for(int i = 0; i < BillingApprovalDetails.Count; i++)
				{
					sb.Append("<ebl:BillingApprovalDetails>");
					sb.Append(BillingApprovalDetails[i].ToXMLString());
					sb.Append("</ebl:BillingApprovalDetails>");
				}
			}
			if(BuyerDetail != null)
			{
				sb.Append("<ebl:BuyerDetail>");
				sb.Append(BuyerDetail.ToXMLString());
				sb.Append("</ebl:BuyerDetail>");
			}
			if(InfoSharingDirectives != null)
			{
				sb.Append("<ebl:InfoSharingDirectives>");
				sb.Append(InfoSharingDirectives.ToXMLString());
				sb.Append("</ebl:InfoSharingDirectives>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class AuthorizationRequestType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(IsRequested != null)
			{
				sb.Append("<ebl:IsRequested>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(IsRequested));
				sb.Append("</ebl:IsRequested>");
			}
			return sb.ToString();
		}

	}




	/**
      *The Type of Approval requested - Billing Agreement or
      *Profile 
      */
	public partial class BillingApprovalDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ApprovalType != null)
			{
				sb.Append("<ebl:ApprovalType>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(ApprovalType)));
				sb.Append("</ebl:ApprovalType>");
			}
			if(ApprovalSubType != null)
			{
				sb.Append("<ebl:ApprovalSubType>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(ApprovalSubType)));
				sb.Append("</ebl:ApprovalSubType>");
			}
			if(OrderDetails != null)
			{
				sb.Append("<ebl:OrderDetails>");
				sb.Append(OrderDetails.ToXMLString());
				sb.Append("</ebl:OrderDetails>");
			}
			if(PaymentDirectives != null)
			{
				sb.Append("<ebl:PaymentDirectives>");
				sb.Append(PaymentDirectives.ToXMLString());
				sb.Append("</ebl:PaymentDirectives>");
			}
			if(Custom != null)
			{
				sb.Append("<ebl:Custom>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Custom));
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
	public partial class InfoSharingDirectivesType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ReqBillingAddress != null)
			{
				sb.Append("<ebl:ReqBillingAddress>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ReqBillingAddress));
				sb.Append("</ebl:ReqBillingAddress>");
			}
			return sb.ToString();
		}

	}




	/**
      *Description of the Order. 
      */
	public partial class OrderDetailsType	{

		/**
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Description != null)
			{
				sb.Append("<ebl:Description>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Description));
				sb.Append("</ebl:Description>");
			}
			if(MaxAmount != null)
			{
				sb.Append("<ebl:MaxAmount");
				sb.Append(MaxAmount.ToXMLString());
				sb.Append("</ebl:MaxAmount>");
			}
			return sb.ToString();
		}

	}




	/**
      *Type of the Payment is it Instant or Echeck or Any. 
      */
	public partial class PaymentDirectivesType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(PaymentType != null)
			{
				sb.Append("<ebl:PaymentType>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(PaymentType)));
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
	public partial class BuyerDetailType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(IdentificationInfo != null)
			{
				sb.Append("<ebl:IdentificationInfo>");
				sb.Append(IdentificationInfo.ToXMLString());
				sb.Append("</ebl:IdentificationInfo>");
			}
			return sb.ToString();
		}

	}




	/**
      *Mobile specific buyer identification. 
      */
	public partial class IdentificationInfoType	{

		/**
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(MobileIDInfo != null)
			{
				sb.Append("<ebl:MobileIDInfo>");
				sb.Append(MobileIDInfo.ToXMLString());
				sb.Append("</ebl:MobileIDInfo>");
			}
			if(RememberMeIDInfo != null)
			{
				sb.Append("<ebl:RememberMeIDInfo>");
				sb.Append(RememberMeIDInfo.ToXMLString());
				sb.Append("</ebl:RememberMeIDInfo>");
			}
			if(IdentityTokenInfo != null)
			{
				sb.Append("<ebl:IdentityTokenInfo>");
				sb.Append(IdentityTokenInfo.ToXMLString());
				sb.Append("</ebl:IdentityTokenInfo>");
			}
			return sb.ToString();
		}

	}




	/**
      *The Session token returned during buyer authentication. 
      */
	public partial class MobileIDInfoType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(SessionToken != null)
			{
				sb.Append("<ebl:SessionToken>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(SessionToken));
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
	public partial class RememberMeIDInfoType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ExternalRememberMeID != null)
			{
				sb.Append("<ebl:ExternalRememberMeID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ExternalRememberMeID));
				sb.Append("</ebl:ExternalRememberMeID>");
			}
			return sb.ToString();
		}

	}




	/**
      *Identity Access token from merchant 
      */
	public partial class IdentityTokenInfoType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(AccessToken != null)
			{
				sb.Append("<ebl:AccessToken>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(AccessToken));
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
	public partial class FundingSourceDetailsType	{

		/**
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(AllowPushFunding != null)
			{
				sb.Append("<ebl:AllowPushFunding>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(AllowPushFunding));
				sb.Append("</ebl:AllowPushFunding>");
			}
			if(UserSelectedFundingSource != null)
			{
				sb.Append("<ebl:UserSelectedFundingSource>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(UserSelectedFundingSource)));
				sb.Append("</ebl:UserSelectedFundingSource>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class BillingAgreementDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(BillingType != null)
			{
				sb.Append("<ebl:BillingType>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(BillingType)));
				sb.Append("</ebl:BillingType>");
			}
			if(BillingAgreementDescription != null)
			{
				sb.Append("<ebl:BillingAgreementDescription>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(BillingAgreementDescription));
				sb.Append("</ebl:BillingAgreementDescription>");
			}
			if(PaymentType != null)
			{
				sb.Append("<ebl:PaymentType>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(PaymentType)));
				sb.Append("</ebl:PaymentType>");
			}
			if(BillingAgreementCustom != null)
			{
				sb.Append("<ebl:BillingAgreementCustom>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(BillingAgreementCustom));
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
	public partial class GetExpressCheckoutDetailsResponseDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
		  */
		private RefreshTokenStatusDetailsType RefreshTokenStatusDetailsField;
		public RefreshTokenStatusDetailsType RefreshTokenStatusDetails
		{
			get
			{
				return this.RefreshTokenStatusDetailsField;
			}
			set
			{
				this.RefreshTokenStatusDetailsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public GetExpressCheckoutDetailsResponseDetailsType(){
		}


		public GetExpressCheckoutDetailsResponseDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Token']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Token = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PayerInfo']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PayerInfo =  new PayerInfoType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Custom']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Custom = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'InvoiceID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.InvoiceID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ContactPhone']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ContactPhone = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'BillingAgreementAcceptedStatus']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.BillingAgreementAcceptedStatus = System.Convert.ToBoolean(ChildNode.InnerText);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'RedirectRequired']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.RedirectRequired = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'BillingAddress']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.BillingAddress =  new AddressType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Note']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Note = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'CheckoutStatus']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.CheckoutStatus = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PayPalAdjustment']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PayPalAdjustment =  new BasicAmountType(ChildNode);
			}
			ChildNodeList = xmlNode.SelectNodes("*[local-name() = 'PaymentDetails']");
			if (ChildNodeList != null && ChildNodeList.Count > 0)
			{
				for(int i = 0; i < ChildNodeList.Count; i++)
				{
					XmlNode subNode = ChildNodeList.Item(i);
					this.PaymentDetails.Add(new PaymentDetailsType(subNode));
				}
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'UserSelectedOptions']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.UserSelectedOptions =  new UserSelectedOptionType(ChildNode);
			}
			ChildNodeList = xmlNode.SelectNodes("*[local-name() = 'IncentiveDetails']");
			if (ChildNodeList != null && ChildNodeList.Count > 0)
			{
				for(int i = 0; i < ChildNodeList.Count; i++)
				{
					XmlNode subNode = ChildNodeList.Item(i);
					this.IncentiveDetails.Add(new IncentiveDetailsType(subNode));
				}
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'GiftMessage']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.GiftMessage = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'GiftReceiptEnable']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.GiftReceiptEnable = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'GiftWrapName']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.GiftWrapName = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'GiftWrapAmount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.GiftWrapAmount =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'BuyerMarketingEmail']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.BuyerMarketingEmail = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'SurveyQuestion']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.SurveyQuestion = ChildNode.InnerText;
			}
			ChildNodeList = xmlNode.SelectNodes("*[local-name() = 'SurveyChoiceSelected']");
			if (ChildNodeList != null && ChildNodeList.Count > 0)
			{
				for(int i = 0; i < ChildNodeList.Count; i++)
				{
					string value = ChildNodeList[i].InnerText;
					this.SurveyChoiceSelected.Add(value);
				}
			}
			ChildNodeList = xmlNode.SelectNodes("*[local-name() = 'PaymentRequestInfo']");
			if (ChildNodeList != null && ChildNodeList.Count > 0)
			{
				for(int i = 0; i < ChildNodeList.Count; i++)
				{
					XmlNode subNode = ChildNodeList.Item(i);
					this.PaymentRequestInfo.Add(new PaymentRequestInfoType(subNode));
				}
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ExternalRememberMeStatusDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ExternalRememberMeStatusDetails =  new ExternalRememberMeStatusDetailsType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'RefreshTokenStatusDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.RefreshTokenStatusDetails =  new RefreshTokenStatusDetailsType(ChildNode);
			}
	
		}
	}




	/**
      *
      */
	public partial class ExecuteCheckoutOperationsResponseDetailsType	{

		/**
          *
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
          *
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


		public ExecuteCheckoutOperationsResponseDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'SetDataResponse']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.SetDataResponse =  new SetDataResponseType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'AuthorizationResponse']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.AuthorizationResponse =  new AuthorizationResponseType(ChildNode);
			}
	
		}
	}




	/**
      *If Checkout session was initialized successfully, the
      *corresponding token is returned in this element. 
      */
	public partial class SetDataResponseType	{

		/**
          *
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
          *
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


		public SetDataResponseType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Token']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Token = ChildNode.InnerText;
			}
			ChildNodeList = xmlNode.SelectNodes("*[local-name() = 'SetDataError']");
			if (ChildNodeList != null && ChildNodeList.Count > 0)
			{
				for(int i = 0; i < ChildNodeList.Count; i++)
				{
					XmlNode subNode = ChildNodeList.Item(i);
					this.SetDataError.Add(new ErrorType(subNode));
				}
			}
	
		}
	}




	/**
      *Status will denote whether Auto authorization was successful
      *or not. 
      */
	public partial class AuthorizationResponseType	{

		/**
          *
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
          *
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


		public AuthorizationResponseType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Status']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Status = (AckCodeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(AckCodeType));
			}
			ChildNodeList = xmlNode.SelectNodes("*[local-name() = 'AuthorizationError']");
			if (ChildNodeList != null && ChildNodeList.Count > 0)
			{
				for(int i = 0; i < ChildNodeList.Count; i++)
				{
					XmlNode subNode = ChildNodeList.Item(i);
					this.AuthorizationError.Add(new ErrorType(subNode));
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
	public partial class DoExpressCheckoutPaymentRequestDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
		  */
		private List<CoupledBucketsType> CoupledBucketsField = new List<CoupledBucketsType>();
		public List<CoupledBucketsType> CoupledBuckets
		{
			get
			{
				return this.CoupledBucketsField;
			}
			set
			{
				this.CoupledBucketsField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DoExpressCheckoutPaymentRequestDetailsType(){
		}


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(PaymentAction != null)
			{
				sb.Append("<ebl:PaymentAction>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(PaymentAction)));
				sb.Append("</ebl:PaymentAction>");
			}
			if(Token != null)
			{
				sb.Append("<ebl:Token>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Token));
				sb.Append("</ebl:Token>");
			}
			if(PayerID != null)
			{
				sb.Append("<ebl:PayerID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(PayerID));
				sb.Append("</ebl:PayerID>");
			}
			if(OrderURL != null)
			{
				sb.Append("<ebl:OrderURL>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(OrderURL));
				sb.Append("</ebl:OrderURL>");
			}
			if(PaymentDetails != null)
			{
				for(int i = 0; i < PaymentDetails.Count; i++)
				{
					sb.Append("<ebl:PaymentDetails>");
					sb.Append(PaymentDetails[i].ToXMLString());
					sb.Append("</ebl:PaymentDetails>");
				}
			}
			if(PromoOverrideFlag != null)
			{
				sb.Append("<ebl:PromoOverrideFlag>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(PromoOverrideFlag));
				sb.Append("</ebl:PromoOverrideFlag>");
			}
			if(PromoCode != null)
			{
				sb.Append("<ebl:PromoCode>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(PromoCode));
				sb.Append("</ebl:PromoCode>");
			}
			if(EnhancedData != null)
			{
				sb.Append("<ebl:EnhancedData>");
				sb.Append(EnhancedData.ToXMLString());
				sb.Append("</ebl:EnhancedData>");
			}
			if(SoftDescriptor != null)
			{
				sb.Append("<ebl:SoftDescriptor>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(SoftDescriptor));
				sb.Append("</ebl:SoftDescriptor>");
			}
			if(UserSelectedOptions != null)
			{
				sb.Append("<ebl:UserSelectedOptions>");
				sb.Append(UserSelectedOptions.ToXMLString());
				sb.Append("</ebl:UserSelectedOptions>");
			}
			if(GiftMessage != null)
			{
				sb.Append("<ebl:GiftMessage>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(GiftMessage));
				sb.Append("</ebl:GiftMessage>");
			}
			if(GiftReceiptEnable != null)
			{
				sb.Append("<ebl:GiftReceiptEnable>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(GiftReceiptEnable));
				sb.Append("</ebl:GiftReceiptEnable>");
			}
			if(GiftWrapName != null)
			{
				sb.Append("<ebl:GiftWrapName>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(GiftWrapName));
				sb.Append("</ebl:GiftWrapName>");
			}
			if(GiftWrapAmount != null)
			{
				sb.Append("<ebl:GiftWrapAmount");
				sb.Append(GiftWrapAmount.ToXMLString());
				sb.Append("</ebl:GiftWrapAmount>");
			}
			if(BuyerMarketingEmail != null)
			{
				sb.Append("<ebl:BuyerMarketingEmail>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(BuyerMarketingEmail));
				sb.Append("</ebl:BuyerMarketingEmail>");
			}
			if(SurveyQuestion != null)
			{
				sb.Append("<ebl:SurveyQuestion>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(SurveyQuestion));
				sb.Append("</ebl:SurveyQuestion>");
			}
			if(SurveyChoiceSelected != null)
			{
				for(int i = 0; i < SurveyChoiceSelected.Count; i++)
				{
					sb.Append("<ebl:SurveyChoiceSelected>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(SurveyChoiceSelected[i]));
					sb.Append("</ebl:SurveyChoiceSelected>");
				}
			}
			if(ButtonSource != null)
			{
				sb.Append("<ebl:ButtonSource>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ButtonSource));
				sb.Append("</ebl:ButtonSource>");
			}
			if(SkipBACreation != null)
			{
				sb.Append("<ebl:SkipBACreation>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(SkipBACreation));
				sb.Append("</ebl:SkipBACreation>");
			}
			if(CoupledBuckets != null)
			{
				for(int i = 0; i < CoupledBuckets.Count; i++)
				{
					sb.Append("<ebl:CoupledBuckets>");
					sb.Append(CoupledBuckets[i].ToXMLString());
					sb.Append("</ebl:CoupledBuckets>");
				}
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
	public partial class DoExpressCheckoutPaymentResponseDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
		  */
		private List<CoupledPaymentInfoType> CoupledPaymentInfoField = new List<CoupledPaymentInfoType>();
		public List<CoupledPaymentInfoType> CoupledPaymentInfo
		{
			get
			{
				return this.CoupledPaymentInfoField;
			}
			set
			{
				this.CoupledPaymentInfoField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public DoExpressCheckoutPaymentResponseDetailsType(){
		}


		public DoExpressCheckoutPaymentResponseDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Token']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Token = ChildNode.InnerText;
			}
			ChildNodeList = xmlNode.SelectNodes("*[local-name() = 'PaymentInfo']");
			if (ChildNodeList != null && ChildNodeList.Count > 0)
			{
				for(int i = 0; i < ChildNodeList.Count; i++)
				{
					XmlNode subNode = ChildNodeList.Item(i);
					this.PaymentInfo.Add(new PaymentInfoType(subNode));
				}
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'BillingAgreementID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.BillingAgreementID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'RedirectRequired']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.RedirectRequired = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Note']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Note = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'SuccessPageRedirectRequested']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.SuccessPageRedirectRequested = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'UserSelectedOptions']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.UserSelectedOptions =  new UserSelectedOptionType(ChildNode);
			}
			ChildNodeList = xmlNode.SelectNodes("*[local-name() = 'CoupledPaymentInfo']");
			if (ChildNodeList != null && ChildNodeList.Count > 0)
			{
				for(int i = 0; i < ChildNodeList.Count; i++)
				{
					XmlNode subNode = ChildNodeList.Item(i);
					this.CoupledPaymentInfo.Add(new CoupledPaymentInfoType(subNode));
				}
			}
	
		}
	}




	/**
      *The authorization identification number you specified in the
      *request. Character length and limits: 19 single-byte
      *characters maximum 
      */
	public partial class DoCaptureResponseDetailsType	{

		/**
          *
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
          *
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
          *
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
	 	public DoCaptureResponseDetailsType(){
		}


		public DoCaptureResponseDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'AuthorizationID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.AuthorizationID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PaymentInfo']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PaymentInfo =  new PaymentInfoType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'MsgSubID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.MsgSubID = ChildNode.InnerText;
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
	public partial class DoDirectPaymentRequestDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(PaymentAction != null)
			{
				sb.Append("<ebl:PaymentAction>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(PaymentAction)));
				sb.Append("</ebl:PaymentAction>");
			}
			if(PaymentDetails != null)
			{
				sb.Append("<ebl:PaymentDetails>");
				sb.Append(PaymentDetails.ToXMLString());
				sb.Append("</ebl:PaymentDetails>");
			}
			if(CreditCard != null)
			{
				sb.Append("<ebl:CreditCard>");
				sb.Append(CreditCard.ToXMLString());
				sb.Append("</ebl:CreditCard>");
			}
			if(IPAddress != null)
			{
				sb.Append("<ebl:IPAddress>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(IPAddress));
				sb.Append("</ebl:IPAddress>");
			}
			if(MerchantSessionId != null)
			{
				sb.Append("<ebl:MerchantSessionId>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(MerchantSessionId));
				sb.Append("</ebl:MerchantSessionId>");
			}
			if(ReturnFMFDetails != null)
			{
				sb.Append("<ebl:ReturnFMFDetails>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ReturnFMFDetails));
				sb.Append("</ebl:ReturnFMFDetails>");
			}
			return sb.ToString();
		}

	}




	/**
      *Type of the payment Required 
      */
	public partial class CreateMobilePaymentRequestDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(PaymentType != null)
			{
				sb.Append("<ebl:PaymentType>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(PaymentType)));
				sb.Append("</ebl:PaymentType>");
			}
			if(PaymentAction != null)
			{
				sb.Append("<ebl:PaymentAction>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(PaymentAction)));
				sb.Append("</ebl:PaymentAction>");
			}
			if(SenderPhone != null)
			{
				sb.Append("<ebl:SenderPhone>");
				sb.Append(SenderPhone.ToXMLString());
				sb.Append("</ebl:SenderPhone>");
			}
			if(RecipientType != null)
			{
				sb.Append("<ebl:RecipientType>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(RecipientType)));
				sb.Append("</ebl:RecipientType>");
			}
			if(RecipientEmail != null)
			{
				sb.Append("<ebl:RecipientEmail>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(RecipientEmail));
				sb.Append("</ebl:RecipientEmail>");
			}
			if(RecipientPhone != null)
			{
				sb.Append("<ebl:RecipientPhone>");
				sb.Append(RecipientPhone.ToXMLString());
				sb.Append("</ebl:RecipientPhone>");
			}
			if(ItemAmount != null)
			{
				sb.Append("<ebl:ItemAmount");
				sb.Append(ItemAmount.ToXMLString());
				sb.Append("</ebl:ItemAmount>");
			}
			if(Tax != null)
			{
				sb.Append("<ebl:Tax");
				sb.Append(Tax.ToXMLString());
				sb.Append("</ebl:Tax>");
			}
			if(Shipping != null)
			{
				sb.Append("<ebl:Shipping");
				sb.Append(Shipping.ToXMLString());
				sb.Append("</ebl:Shipping>");
			}
			if(ItemName != null)
			{
				sb.Append("<ebl:ItemName>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ItemName));
				sb.Append("</ebl:ItemName>");
			}
			if(ItemNumber != null)
			{
				sb.Append("<ebl:ItemNumber>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ItemNumber));
				sb.Append("</ebl:ItemNumber>");
			}
			if(Note != null)
			{
				sb.Append("<ebl:Note>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Note));
				sb.Append("</ebl:Note>");
			}
			if(CustomID != null)
			{
				sb.Append("<ebl:CustomID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(CustomID));
				sb.Append("</ebl:CustomID>");
			}
			if(SharePhoneNumber != null)
			{
				sb.Append("<ebl:SharePhoneNumber>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(SharePhoneNumber));
				sb.Append("</ebl:SharePhoneNumber>");
			}
			if(ShareHomeAddress != null)
			{
				sb.Append("<ebl:ShareHomeAddress>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ShareHomeAddress));
				sb.Append("</ebl:ShareHomeAddress>");
			}
			return sb.ToString();
		}

	}




	/**
      *Phone number for status inquiry 
      */
	public partial class GetMobileStatusRequestDetailsType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Phone != null)
			{
				sb.Append("<ebl:Phone>");
				sb.Append(Phone.ToXMLString());
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
	public partial class SetAuthFlowParamRequestDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ReturnURL != null)
			{
				sb.Append("<ebl:ReturnURL>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ReturnURL));
				sb.Append("</ebl:ReturnURL>");
			}
			if(CancelURL != null)
			{
				sb.Append("<ebl:CancelURL>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(CancelURL));
				sb.Append("</ebl:CancelURL>");
			}
			if(LogoutURL != null)
			{
				sb.Append("<ebl:LogoutURL>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(LogoutURL));
				sb.Append("</ebl:LogoutURL>");
			}
			if(InitFlowType != null)
			{
				sb.Append("<ebl:InitFlowType>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(InitFlowType));
				sb.Append("</ebl:InitFlowType>");
			}
			if(SkipLoginPage != null)
			{
				sb.Append("<ebl:SkipLoginPage>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(SkipLoginPage));
				sb.Append("</ebl:SkipLoginPage>");
			}
			if(ServiceName1 != null)
			{
				sb.Append("<ebl:ServiceName1>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ServiceName1));
				sb.Append("</ebl:ServiceName1>");
			}
			if(ServiceDefReq1 != null)
			{
				sb.Append("<ebl:ServiceDefReq1>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ServiceDefReq1));
				sb.Append("</ebl:ServiceDefReq1>");
			}
			if(ServiceName2 != null)
			{
				sb.Append("<ebl:ServiceName2>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ServiceName2));
				sb.Append("</ebl:ServiceName2>");
			}
			if(ServiceDefReq2 != null)
			{
				sb.Append("<ebl:ServiceDefReq2>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ServiceDefReq2));
				sb.Append("</ebl:ServiceDefReq2>");
			}
			if(LocaleCode != null)
			{
				sb.Append("<ebl:LocaleCode>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(LocaleCode));
				sb.Append("</ebl:LocaleCode>");
			}
			if(PageStyle != null)
			{
				sb.Append("<ebl:PageStyle>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(PageStyle));
				sb.Append("</ebl:PageStyle>");
			}
			if(cppHeaderImage != null)
			{
				sb.Append("<ebl:cpp-header-image>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(cppHeaderImage));
				sb.Append("</ebl:cpp-header-image>");
			}
			if(cppHeaderBorderColor != null)
			{
				sb.Append("<ebl:cpp-header-border-color>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(cppHeaderBorderColor));
				sb.Append("</ebl:cpp-header-border-color>");
			}
			if(cppHeaderBackColor != null)
			{
				sb.Append("<ebl:cpp-header-back-color>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(cppHeaderBackColor));
				sb.Append("</ebl:cpp-header-back-color>");
			}
			if(cppPayflowColor != null)
			{
				sb.Append("<ebl:cpp-payflow-color>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(cppPayflowColor));
				sb.Append("</ebl:cpp-payflow-color>");
			}
			if(FirstName != null)
			{
				sb.Append("<ebl:FirstName>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(FirstName));
				sb.Append("</ebl:FirstName>");
			}
			if(LastName != null)
			{
				sb.Append("<ebl:LastName>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(LastName));
				sb.Append("</ebl:LastName>");
			}
			if(Address != null)
			{
				sb.Append("<ebl:Address>");
				sb.Append(Address.ToXMLString());
				sb.Append("</ebl:Address>");
			}
			return sb.ToString();
		}

	}




	/**
      *The first name of the User. Character length and
      *limitations: 127 single-byte alphanumeric characters 
      */
	public partial class GetAuthDetailsResponseDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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


		public GetAuthDetailsResponseDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'FirstName']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.FirstName = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'LastName']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.LastName = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Email']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Email = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PayerID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PayerID = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *URL to which the customer's browser is returned after
      *choosing to login with PayPal. Required Character length and
      *limitations: no limit. 
      */
	public partial class SetAccessPermissionsRequestDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ReturnURL != null)
			{
				sb.Append("<ebl:ReturnURL>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ReturnURL));
				sb.Append("</ebl:ReturnURL>");
			}
			if(CancelURL != null)
			{
				sb.Append("<ebl:CancelURL>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(CancelURL));
				sb.Append("</ebl:CancelURL>");
			}
			if(LogoutURL != null)
			{
				sb.Append("<ebl:LogoutURL>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(LogoutURL));
				sb.Append("</ebl:LogoutURL>");
			}
			if(InitFlowType != null)
			{
				sb.Append("<ebl:InitFlowType>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(InitFlowType));
				sb.Append("</ebl:InitFlowType>");
			}
			if(SkipLoginPage != null)
			{
				sb.Append("<ebl:SkipLoginPage>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(SkipLoginPage));
				sb.Append("</ebl:SkipLoginPage>");
			}
			if(RequiredAccessPermissions != null)
			{
				for(int i = 0; i < RequiredAccessPermissions.Count; i++)
				{
					sb.Append("<ebl:RequiredAccessPermissions>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(RequiredAccessPermissions[i]));
					sb.Append("</ebl:RequiredAccessPermissions>");
				}
			}
			if(OptionalAccessPermissions != null)
			{
				for(int i = 0; i < OptionalAccessPermissions.Count; i++)
				{
					sb.Append("<ebl:OptionalAccessPermissions>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(OptionalAccessPermissions[i]));
					sb.Append("</ebl:OptionalAccessPermissions>");
				}
			}
			if(LocaleCode != null)
			{
				sb.Append("<ebl:LocaleCode>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(LocaleCode));
				sb.Append("</ebl:LocaleCode>");
			}
			if(PageStyle != null)
			{
				sb.Append("<ebl:PageStyle>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(PageStyle));
				sb.Append("</ebl:PageStyle>");
			}
			if(cppHeaderImage != null)
			{
				sb.Append("<ebl:cpp-header-image>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(cppHeaderImage));
				sb.Append("</ebl:cpp-header-image>");
			}
			if(cppHeaderBorderColor != null)
			{
				sb.Append("<ebl:cpp-header-border-color>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(cppHeaderBorderColor));
				sb.Append("</ebl:cpp-header-border-color>");
			}
			if(cppHeaderBackColor != null)
			{
				sb.Append("<ebl:cpp-header-back-color>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(cppHeaderBackColor));
				sb.Append("</ebl:cpp-header-back-color>");
			}
			if(cppPayflowColor != null)
			{
				sb.Append("<ebl:cpp-payflow-color>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(cppPayflowColor));
				sb.Append("</ebl:cpp-payflow-color>");
			}
			if(FirstName != null)
			{
				sb.Append("<ebl:FirstName>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(FirstName));
				sb.Append("</ebl:FirstName>");
			}
			if(LastName != null)
			{
				sb.Append("<ebl:LastName>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(LastName));
				sb.Append("</ebl:LastName>");
			}
			if(Address != null)
			{
				sb.Append("<ebl:Address>");
				sb.Append(Address.ToXMLString());
				sb.Append("</ebl:Address>");
			}
			return sb.ToString();
		}

	}




	/**
      *The first name of the User. Character length and
      *limitations: 127 single-byte alphanumeric characters 
      */
	public partial class GetAccessPermissionDetailsResponseDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public GetAccessPermissionDetailsResponseDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'FirstName']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.FirstName = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'LastName']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.LastName = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Email']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Email = ChildNode.InnerText;
			}
			ChildNodeList = xmlNode.SelectNodes("*[local-name() = 'AccessPermissionName']");
			if (ChildNodeList != null && ChildNodeList.Count > 0)
			{
				for(int i = 0; i < ChildNodeList.Count; i++)
				{
					string value = ChildNodeList[i].InnerText;
					this.AccessPermissionName.Add(value);
				}
			}
			ChildNodeList = xmlNode.SelectNodes("*[local-name() = 'AccessPermissionStatus']");
			if (ChildNodeList != null && ChildNodeList.Count > 0)
			{
				for(int i = 0; i < ChildNodeList.Count; i++)
				{
					string value = ChildNodeList[i].InnerText;
					this.AccessPermissionStatus.Add(value);
				}
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PayerID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PayerID = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *
      */
	public partial class BAUpdateResponseDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public BAUpdateResponseDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'BillingAgreementID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.BillingAgreementID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'BillingAgreementDescription']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.BillingAgreementDescription = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'BillingAgreementStatus']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.BillingAgreementStatus = (MerchantPullStatusCodeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(MerchantPullStatusCodeType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'BillingAgreementCustom']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.BillingAgreementCustom = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PayerInfo']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PayerInfo =  new PayerInfoType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'BillingAgreementMax']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.BillingAgreementMax =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'BillingAddress']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.BillingAddress =  new AddressType(ChildNode);
			}
	
		}
	}




	/**
      *MerchantPullPaymentResponseType Response data from the
      *merchant pull. 
      */
	public partial class MerchantPullPaymentResponseType	{

		/**
          *
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
          *
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
          *
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


		public MerchantPullPaymentResponseType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PayerInfo']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PayerInfo =  new PayerInfoType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PaymentInfo']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PaymentInfo =  new PaymentInfoType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'MerchantPullInfo']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.MerchantPullInfo =  new MerchantPullInfoType(ChildNode);
			}
	
		}
	}




	/**
      *MerchantPullInfoType Information about the merchant pull. 
      */
	public partial class MerchantPullInfoType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public MerchantPullInfoType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'MpStatus']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.MpStatus = (MerchantPullStatusCodeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(MerchantPullStatusCodeType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'MpMax']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.MpMax =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'MpCustom']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.MpCustom = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Desc']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Desc = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Invoice']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Invoice = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Custom']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Custom = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PaymentSourceID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PaymentSourceID = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *PaymentTransactionSearchResultType Results from a
      *PaymentTransaction search 
      */
	public partial class PaymentTransactionSearchResultType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public PaymentTransactionSearchResultType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Timestamp']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Timestamp = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Timezone']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Timezone = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Type']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Type = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Payer']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Payer = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PayerDisplayName']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PayerDisplayName = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'TransactionID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.TransactionID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Status']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Status = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'GrossAmount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.GrossAmount =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'FeeAmount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.FeeAmount =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'NetAmount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.NetAmount =  new BasicAmountType(ChildNode);
			}
	
		}
	}




	/**
      *MerchantPullPayment Parameters to make initiate a pull
      *payment 
      */
	public partial class MerchantPullPaymentType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Amount != null)
			{
				sb.Append("<ebl:Amount");
				sb.Append(Amount.ToXMLString());
				sb.Append("</ebl:Amount>");
			}
			if(MpID != null)
			{
				sb.Append("<ebl:MpID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(MpID));
				sb.Append("</ebl:MpID>");
			}
			if(PaymentType != null)
			{
				sb.Append("<ebl:PaymentType>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(PaymentType)));
				sb.Append("</ebl:PaymentType>");
			}
			if(Memo != null)
			{
				sb.Append("<ebl:Memo>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Memo));
				sb.Append("</ebl:Memo>");
			}
			if(EmailSubject != null)
			{
				sb.Append("<ebl:EmailSubject>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EmailSubject));
				sb.Append("</ebl:EmailSubject>");
			}
			if(Tax != null)
			{
				sb.Append("<ebl:Tax");
				sb.Append(Tax.ToXMLString());
				sb.Append("</ebl:Tax>");
			}
			if(Shipping != null)
			{
				sb.Append("<ebl:Shipping");
				sb.Append(Shipping.ToXMLString());
				sb.Append("</ebl:Shipping>");
			}
			if(Handling != null)
			{
				sb.Append("<ebl:Handling");
				sb.Append(Handling.ToXMLString());
				sb.Append("</ebl:Handling>");
			}
			if(ItemName != null)
			{
				sb.Append("<ebl:ItemName>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ItemName));
				sb.Append("</ebl:ItemName>");
			}
			if(ItemNumber != null)
			{
				sb.Append("<ebl:ItemNumber>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ItemNumber));
				sb.Append("</ebl:ItemNumber>");
			}
			if(Invoice != null)
			{
				sb.Append("<ebl:Invoice>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Invoice));
				sb.Append("</ebl:Invoice>");
			}
			if(Custom != null)
			{
				sb.Append("<ebl:Custom>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Custom));
				sb.Append("</ebl:Custom>");
			}
			if(ButtonSource != null)
			{
				sb.Append("<ebl:ButtonSource>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ButtonSource));
				sb.Append("</ebl:ButtonSource>");
			}
			if(SoftDescriptor != null)
			{
				sb.Append("<ebl:SoftDescriptor>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(SoftDescriptor));
				sb.Append("</ebl:SoftDescriptor>");
			}
			return sb.ToString();
		}

	}




	/**
      *PaymentTransactionType Information about a PayPal payment
      *from the seller side 
      */
	public partial class PaymentTransactionType	{

		/**
          *
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
          *
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
          *
		  */
		private string TPLReferenceIDField;
		public string TPLReferenceID
		{
			get
			{
				return this.TPLReferenceIDField;
			}
			set
			{
				this.TPLReferenceIDField = value;
			}
		}
		

		/**
          *
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
          *
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
          *
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
          *
		  */
		private AddressType SecondaryAddressField;
		public AddressType SecondaryAddress
		{
			get
			{
				return this.SecondaryAddressField;
			}
			set
			{
				this.SecondaryAddressField = value;
			}
		}
		

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public PaymentTransactionType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ReceiverInfo']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ReceiverInfo =  new ReceiverInfoType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PayerInfo']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PayerInfo =  new PayerInfoType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'TPLReferenceID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.TPLReferenceID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PaymentInfo']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PaymentInfo =  new PaymentInfoType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PaymentItemInfo']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PaymentItemInfo =  new PaymentItemInfoType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'OfferCouponInfo']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.OfferCouponInfo =  new OfferCouponInfoType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'SecondaryAddress']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.SecondaryAddress =  new AddressType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'UserSelectedOptions']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.UserSelectedOptions =  new UserSelectedOptionType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'GiftMessage']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.GiftMessage = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'GiftReceipt']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.GiftReceipt = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'GiftWrapName']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.GiftWrapName = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'GiftWrapAmount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.GiftWrapAmount =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'BuyerEmailOptIn']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.BuyerEmailOptIn = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'SurveyQuestion']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.SurveyQuestion = ChildNode.InnerText;
			}
			ChildNodeList = xmlNode.SelectNodes("*[local-name() = 'SurveyChoiceSelected']");
			if (ChildNodeList != null && ChildNodeList.Count > 0)
			{
				for(int i = 0; i < ChildNodeList.Count; i++)
				{
					string value = ChildNodeList[i].InnerText;
					this.SurveyChoiceSelected.Add(value);
				}
			}
	
		}
	}




	/**
      *ReceiverInfoType Receiver information. 
      */
	public partial class ReceiverInfoType	{

		/**
          *
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
          *
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
          *
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


		public ReceiverInfoType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Business']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Business = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Receiver']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Receiver = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ReceiverID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ReceiverID = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *PayerInfoType Payer information 
      */
	public partial class PayerInfoType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Payer != null)
			{
				sb.Append("<ebl:Payer>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Payer));
				sb.Append("</ebl:Payer>");
			}
			if(PayerID != null)
			{
				sb.Append("<ebl:PayerID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(PayerID));
				sb.Append("</ebl:PayerID>");
			}
			if(PayerStatus != null)
			{
				sb.Append("<ebl:PayerStatus>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(PayerStatus)));
				sb.Append("</ebl:PayerStatus>");
			}
			if(PayerName != null)
			{
				sb.Append("<ebl:PayerName>");
				sb.Append(PayerName.ToXMLString());
				sb.Append("</ebl:PayerName>");
			}
			if(PayerCountry != null)
			{
				sb.Append("<ebl:PayerCountry>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(PayerCountry)));
				sb.Append("</ebl:PayerCountry>");
			}
			if(PayerBusiness != null)
			{
				sb.Append("<ebl:PayerBusiness>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(PayerBusiness));
				sb.Append("</ebl:PayerBusiness>");
			}
			if(Address != null)
			{
				sb.Append("<ebl:Address>");
				sb.Append(Address.ToXMLString());
				sb.Append("</ebl:Address>");
			}
			if(ContactPhone != null)
			{
				sb.Append("<ebl:ContactPhone>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ContactPhone));
				sb.Append("</ebl:ContactPhone>");
			}
			if(TaxIdDetails != null)
			{
				sb.Append("<ebl:TaxIdDetails>");
				sb.Append(TaxIdDetails.ToXMLString());
				sb.Append("</ebl:TaxIdDetails>");
			}
			if(EnhancedPayerInfo != null)
			{
				sb.Append("<ebl:EnhancedPayerInfo>");
				sb.Append(EnhancedPayerInfo.ToXMLString());
				sb.Append("</ebl:EnhancedPayerInfo>");
			}
			return sb.ToString();
		}

		public PayerInfoType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Payer']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Payer = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PayerID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PayerID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PayerStatus']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PayerStatus = (PayPalUserStatusCodeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(PayPalUserStatusCodeType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PayerName']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PayerName =  new PersonNameType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PayerCountry']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PayerCountry = (CountryCodeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(CountryCodeType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PayerBusiness']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PayerBusiness = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Address']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Address =  new AddressType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ContactPhone']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ContactPhone = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'TaxIdDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.TaxIdDetails =  new TaxIdDetailsType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'EnhancedPayerInfo']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.EnhancedPayerInfo =  new EnhancedPayerInfoType(ChildNode);
			}
	
		}
	}




	/**
      *InstrumentDetailsType Promotional Instrument Information. 
      */
	public partial class InstrumentDetailsType	{

		/**
          *
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


		public InstrumentDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'InstrumentCategory']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.InstrumentCategory = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *BMLOfferInfoType Specific information for BML. 
      */
	public partial class BMLOfferInfoType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(OfferTrackingID != null)
			{
				sb.Append("<ebl:OfferTrackingID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(OfferTrackingID));
				sb.Append("</ebl:OfferTrackingID>");
			}
			return sb.ToString();
		}

		public BMLOfferInfoType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'OfferTrackingID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.OfferTrackingID = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *OfferDetailsType Specific information for an offer. 
      */
	public partial class OfferDetailsType	{

		/**
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(OfferCode != null)
			{
				sb.Append("<ebl:OfferCode>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(OfferCode));
				sb.Append("</ebl:OfferCode>");
			}
			if(BMLOfferInfo != null)
			{
				sb.Append("<ebl:BMLOfferInfo>");
				sb.Append(BMLOfferInfo.ToXMLString());
				sb.Append("</ebl:BMLOfferInfo>");
			}
			return sb.ToString();
		}

		public OfferDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'OfferCode']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.OfferCode = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'BMLOfferInfo']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.BMLOfferInfo =  new BMLOfferInfoType(ChildNode);
			}
	
		}
	}




	/**
      *PaymentInfoType Payment information. 
      */
	public partial class PaymentInfoType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
		  */
		private string ReceiptReferenceNumberField;
		public string ReceiptReferenceNumber
		{
			get
			{
				return this.ReceiptReferenceNumberField;
			}
			set
			{
				this.ReceiptReferenceNumberField = value;
			}
		}
		

		/**
          *
		  */
		private POSTransactionCodeType? POSTransactionTypeField;
		public POSTransactionCodeType? POSTransactionType
		{
			get
			{
				return this.POSTransactionTypeField;
			}
			set
			{
				this.POSTransactionTypeField = value;
			}
		}
		

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public PaymentInfoType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'TransactionID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.TransactionID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'EbayTransactionID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.EbayTransactionID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ParentTransactionID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ParentTransactionID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ReceiptID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ReceiptID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'TransactionType']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.TransactionType = (PaymentTransactionCodeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(PaymentTransactionCodeType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PaymentType']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PaymentType = (PaymentCodeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(PaymentCodeType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'RefundSourceCodeType']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.RefundSourceCodeType = (RefundSourceCodeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(RefundSourceCodeType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ExpectedeCheckClearDate']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ExpectedeCheckClearDate = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PaymentDate']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PaymentDate = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'GrossAmount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.GrossAmount =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'FeeAmount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.FeeAmount =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'SettleAmount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.SettleAmount =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'TaxAmount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.TaxAmount =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ExchangeRate']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ExchangeRate = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PaymentStatus']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PaymentStatus = (PaymentStatusCodeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(PaymentStatusCodeType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PendingReason']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PendingReason = (PendingStatusCodeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(PendingStatusCodeType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ReasonCode']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ReasonCode = (ReversalReasonCodeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(ReversalReasonCodeType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'HoldDecision']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.HoldDecision = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ShippingMethod']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ShippingMethod = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ProtectionEligibility']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ProtectionEligibility = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ProtectionEligibilityType']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ProtectionEligibilityType = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ReceiptReferenceNumber']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ReceiptReferenceNumber = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'POSTransactionType']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.POSTransactionType = (POSTransactionCodeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(POSTransactionCodeType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ShipAmount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ShipAmount = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ShipHandleAmount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ShipHandleAmount = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ShipDiscount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ShipDiscount = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'InsuranceAmount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.InsuranceAmount = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Subject']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Subject = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'StoreID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.StoreID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'TerminalID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.TerminalID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'SellerDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.SellerDetails =  new SellerDetailsType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PaymentRequestID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PaymentRequestID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'FMFDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.FMFDetails =  new FMFDetailsType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'EnhancedPaymentInfo']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.EnhancedPaymentInfo =  new EnhancedPaymentInfoType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PaymentError']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PaymentError =  new ErrorType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'InstrumentDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.InstrumentDetails =  new InstrumentDetailsType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'OfferDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.OfferDetails =  new OfferDetailsType(ChildNode);
			}
	
		}
	}




	/**
      *SubscriptionTermsType Terms of a PayPal subscription. 
      */
	public partial class SubscriptionTermsType	{

		/**
          *
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


		public SubscriptionTermsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Amount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Amount =  new BasicAmountType(ChildNode);
			}
	
		}
	}




	/**
      *SubscriptionInfoType Information about a PayPal
      *Subscription. 
      */
	public partial class SubscriptionInfoType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public SubscriptionInfoType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'SubscriptionID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.SubscriptionID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'SubscriptionDate']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.SubscriptionDate = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'EffectiveDate']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.EffectiveDate = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'RetryTime']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.RetryTime = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Username']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Username = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Password']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Password = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Recurrences']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Recurrences = ChildNode.InnerText;
			}
			ChildNodeList = xmlNode.SelectNodes("*[local-name() = 'Terms']");
			if (ChildNodeList != null && ChildNodeList.Count > 0)
			{
				for(int i = 0; i < ChildNodeList.Count; i++)
				{
					XmlNode subNode = ChildNodeList.Item(i);
					this.Terms.Add(new SubscriptionTermsType(subNode));
				}
			}
	
		}
	}




	/**
      *AuctionInfoType Basic information about an auction. 
      */
	public partial class AuctionInfoType	{

		/**
          *
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
          *
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


		public AuctionInfoType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'BuyerID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.BuyerID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ClosingDate']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ClosingDate = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *OptionType PayPal item options for shopping cart. 
      */
	public partial class OptionType	{

		/**
	 	  * Default Constructor
	 	  */
	 	public OptionType(){
		}


		public OptionType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
	
		}
	}




	/**
      *EbayItemPaymentDetailsItemType - Type declaration to be used
      *by other schemas. Information about an Ebay Payment Item. 
      */
	public partial class EbayItemPaymentDetailsItemType	{

		/**
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ItemNumber != null)
			{
				sb.Append("<ebl:ItemNumber>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ItemNumber));
				sb.Append("</ebl:ItemNumber>");
			}
			if(AuctionTransactionId != null)
			{
				sb.Append("<ebl:AuctionTransactionId>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(AuctionTransactionId));
				sb.Append("</ebl:AuctionTransactionId>");
			}
			if(OrderId != null)
			{
				sb.Append("<ebl:OrderId>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(OrderId));
				sb.Append("</ebl:OrderId>");
			}
			if(CartID != null)
			{
				sb.Append("<ebl:CartID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(CartID));
				sb.Append("</ebl:CartID>");
			}
			return sb.ToString();
		}

		public EbayItemPaymentDetailsItemType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ItemNumber']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ItemNumber = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'AuctionTransactionId']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.AuctionTransactionId = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'OrderId']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.OrderId = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'CartID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.CartID = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *PaymentDetailsItemType Information about a Payment Item. 
      */
	public partial class PaymentDetailsItemType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Name != null)
			{
				sb.Append("<ebl:Name>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Name));
				sb.Append("</ebl:Name>");
			}
			if(Number != null)
			{
				sb.Append("<ebl:Number>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Number));
				sb.Append("</ebl:Number>");
			}
			if(Quantity != null)
			{
				sb.Append("<ebl:Quantity>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Quantity));
				sb.Append("</ebl:Quantity>");
			}
			if(Tax != null)
			{
				sb.Append("<ebl:Tax");
				sb.Append(Tax.ToXMLString());
				sb.Append("</ebl:Tax>");
			}
			if(Amount != null)
			{
				sb.Append("<ebl:Amount");
				sb.Append(Amount.ToXMLString());
				sb.Append("</ebl:Amount>");
			}
			if(EbayItemPaymentDetailsItem != null)
			{
				sb.Append("<ebl:EbayItemPaymentDetailsItem>");
				sb.Append(EbayItemPaymentDetailsItem.ToXMLString());
				sb.Append("</ebl:EbayItemPaymentDetailsItem>");
			}
			if(PromoCode != null)
			{
				sb.Append("<ebl:PromoCode>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(PromoCode));
				sb.Append("</ebl:PromoCode>");
			}
			if(ProductCategory != null)
			{
				sb.Append("<ebl:ProductCategory>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(ProductCategory)));
				sb.Append("</ebl:ProductCategory>");
			}
			if(Description != null)
			{
				sb.Append("<ebl:Description>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Description));
				sb.Append("</ebl:Description>");
			}
			if(ItemWeight != null)
			{
				sb.Append("<ebl:ItemWeight");
				sb.Append(ItemWeight.ToXMLString());
				sb.Append("</ebl:ItemWeight>");
			}
			if(ItemLength != null)
			{
				sb.Append("<ebl:ItemLength");
				sb.Append(ItemLength.ToXMLString());
				sb.Append("</ebl:ItemLength>");
			}
			if(ItemWidth != null)
			{
				sb.Append("<ebl:ItemWidth");
				sb.Append(ItemWidth.ToXMLString());
				sb.Append("</ebl:ItemWidth>");
			}
			if(ItemHeight != null)
			{
				sb.Append("<ebl:ItemHeight");
				sb.Append(ItemHeight.ToXMLString());
				sb.Append("</ebl:ItemHeight>");
			}
			if(ItemURL != null)
			{
				sb.Append("<ebl:ItemURL>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ItemURL));
				sb.Append("</ebl:ItemURL>");
			}
			if(EnhancedItemData != null)
			{
				sb.Append("<ebl:EnhancedItemData>");
				sb.Append(EnhancedItemData.ToXMLString());
				sb.Append("</ebl:EnhancedItemData>");
			}
			if(ItemCategory != null)
			{
				sb.Append("<ebl:ItemCategory>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(ItemCategory)));
				sb.Append("</ebl:ItemCategory>");
			}
			return sb.ToString();
		}

		public PaymentDetailsItemType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Name']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Name = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Number']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Number = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Quantity']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Quantity = System.Convert.ToInt32(ChildNode.InnerText);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Tax']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Tax =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Amount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Amount =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'EbayItemPaymentDetailsItem']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.EbayItemPaymentDetailsItem =  new EbayItemPaymentDetailsItemType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PromoCode']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PromoCode = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ProductCategory']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ProductCategory = (ProductCategoryType)EnumUtils.GetValue(ChildNode.InnerText,typeof(ProductCategoryType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Description']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Description = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ItemWeight']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ItemWeight =  new MeasureType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ItemLength']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ItemLength =  new MeasureType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ItemWidth']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ItemWidth =  new MeasureType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ItemHeight']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ItemHeight =  new MeasureType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ItemURL']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ItemURL = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'EnhancedItemData']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.EnhancedItemData =  new EnhancedItemDataType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ItemCategory']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ItemCategory = (ItemCategoryType)EnumUtils.GetValue(ChildNode.InnerText,typeof(ItemCategoryType));
			}
	
		}
	}




	/**
      *PaymentItemType Information about a Payment Item. 
      */
	public partial class PaymentItemType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
		  */
		private InvoiceItemType InvoiceItemDetailsField;
		public InvoiceItemType InvoiceItemDetails
		{
			get
			{
				return this.InvoiceItemDetailsField;
			}
			set
			{
				this.InvoiceItemDetailsField = value;
			}
		}
		

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public PaymentItemType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'EbayItemTxnId']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.EbayItemTxnId = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Name']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Name = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Number']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Number = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Quantity']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Quantity = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'SalesTax']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.SalesTax = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ShippingAmount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ShippingAmount = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'HandlingAmount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.HandlingAmount = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'InvoiceItemDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.InvoiceItemDetails =  new InvoiceItemType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'CouponID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.CouponID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'CouponAmount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.CouponAmount = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'CouponAmountCurrency']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.CouponAmountCurrency = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'LoyaltyCardDiscountAmount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.LoyaltyCardDiscountAmount = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'LoyaltyCardDiscountCurrency']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.LoyaltyCardDiscountCurrency = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Amount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Amount =  new BasicAmountType(ChildNode);
			}
			ChildNodeList = xmlNode.SelectNodes("*[local-name() = 'Options']");
			if (ChildNodeList != null && ChildNodeList.Count > 0)
			{
				for(int i = 0; i < ChildNodeList.Count; i++)
				{
					XmlNode subNode = ChildNodeList.Item(i);
					this.Options.Add(new OptionType(subNode));
				}
			}
	
		}
	}




	/**
      *PaymentItemInfoType Information about a PayPal item. 
      */
	public partial class PaymentItemInfoType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public PaymentItemInfoType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'InvoiceID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.InvoiceID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Custom']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Custom = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Memo']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Memo = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'SalesTax']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.SalesTax = ChildNode.InnerText;
			}
			ChildNodeList = xmlNode.SelectNodes("*[local-name() = 'PaymentItem']");
			if (ChildNodeList != null && ChildNodeList.Count > 0)
			{
				for(int i = 0; i < ChildNodeList.Count; i++)
				{
					XmlNode subNode = ChildNodeList.Item(i);
					this.PaymentItem.Add(new PaymentItemType(subNode));
				}
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Subscription']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Subscription =  new SubscriptionInfoType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Auction']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Auction =  new AuctionInfoType(ChildNode);
			}
	
		}
	}




	/**
      *OffersAndCouponsInfoType Information about a Offers and
      *Coupons. 
      */
	public partial class OfferCouponInfoType	{

		/**
          *
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
          *
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
          *
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
          *
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


		public OfferCouponInfoType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Type']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Type = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Amount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Amount = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'AmountCurrency']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.AmountCurrency = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *PaymentDetailsType Information about a payment. Used by DCC
      *and Express Checkout. 
      */
	public partial class PaymentDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
		  */
		private string FulfillmentReferenceNumberField;
		public string FulfillmentReferenceNumber
		{
			get
			{
				return this.FulfillmentReferenceNumberField;
			}
			set
			{
				this.FulfillmentReferenceNumberField = value;
			}
		}
		

		/**
          *
		  */
		private AddressType FulfillmentAddressField;
		public AddressType FulfillmentAddress
		{
			get
			{
				return this.FulfillmentAddressField;
			}
			set
			{
				this.FulfillmentAddressField = value;
			}
		}
		

		/**
          *
		  */
		private PaymentCategoryType? PaymentCategoryTypeField;
		public PaymentCategoryType? PaymentCategoryType
		{
			get
			{
				return this.PaymentCategoryTypeField;
			}
			set
			{
				this.PaymentCategoryTypeField = value;
			}
		}
		

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(OrderTotal != null)
			{
				sb.Append("<ebl:OrderTotal");
				sb.Append(OrderTotal.ToXMLString());
				sb.Append("</ebl:OrderTotal>");
			}
			if(ItemTotal != null)
			{
				sb.Append("<ebl:ItemTotal");
				sb.Append(ItemTotal.ToXMLString());
				sb.Append("</ebl:ItemTotal>");
			}
			if(ShippingTotal != null)
			{
				sb.Append("<ebl:ShippingTotal");
				sb.Append(ShippingTotal.ToXMLString());
				sb.Append("</ebl:ShippingTotal>");
			}
			if(HandlingTotal != null)
			{
				sb.Append("<ebl:HandlingTotal");
				sb.Append(HandlingTotal.ToXMLString());
				sb.Append("</ebl:HandlingTotal>");
			}
			if(TaxTotal != null)
			{
				sb.Append("<ebl:TaxTotal");
				sb.Append(TaxTotal.ToXMLString());
				sb.Append("</ebl:TaxTotal>");
			}
			if(OrderDescription != null)
			{
				sb.Append("<ebl:OrderDescription>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(OrderDescription));
				sb.Append("</ebl:OrderDescription>");
			}
			if(Custom != null)
			{
				sb.Append("<ebl:Custom>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Custom));
				sb.Append("</ebl:Custom>");
			}
			if(InvoiceID != null)
			{
				sb.Append("<ebl:InvoiceID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(InvoiceID));
				sb.Append("</ebl:InvoiceID>");
			}
			if(ButtonSource != null)
			{
				sb.Append("<ebl:ButtonSource>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ButtonSource));
				sb.Append("</ebl:ButtonSource>");
			}
			if(NotifyURL != null)
			{
				sb.Append("<ebl:NotifyURL>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(NotifyURL));
				sb.Append("</ebl:NotifyURL>");
			}
			if(ShipToAddress != null)
			{
				sb.Append("<ebl:ShipToAddress>");
				sb.Append(ShipToAddress.ToXMLString());
				sb.Append("</ebl:ShipToAddress>");
			}
			if(FulfillmentReferenceNumber != null)
			{
				sb.Append("<ebl:FulfillmentReferenceNumber>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(FulfillmentReferenceNumber));
				sb.Append("</ebl:FulfillmentReferenceNumber>");
			}
			if(FulfillmentAddress != null)
			{
				sb.Append("<ebl:FulfillmentAddress>");
				sb.Append(FulfillmentAddress.ToXMLString());
				sb.Append("</ebl:FulfillmentAddress>");
			}
			if(PaymentCategoryType != null)
			{
				sb.Append("<ebl:PaymentCategoryType>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(PaymentCategoryType)));
				sb.Append("</ebl:PaymentCategoryType>");
			}
			if(ShippingMethod != null)
			{
				sb.Append("<ebl:ShippingMethod>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(ShippingMethod)));
				sb.Append("</ebl:ShippingMethod>");
			}
			if(ProfileAddressChangeDate != null)
			{
				sb.Append("<ebl:ProfileAddressChangeDate>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ProfileAddressChangeDate));
				sb.Append("</ebl:ProfileAddressChangeDate>");
			}
			if(PaymentDetailsItem != null)
			{
				for(int i = 0; i < PaymentDetailsItem.Count; i++)
				{
					sb.Append("<ebl:PaymentDetailsItem>");
					sb.Append(PaymentDetailsItem[i].ToXMLString());
					sb.Append("</ebl:PaymentDetailsItem>");
				}
			}
			if(InsuranceTotal != null)
			{
				sb.Append("<ebl:InsuranceTotal");
				sb.Append(InsuranceTotal.ToXMLString());
				sb.Append("</ebl:InsuranceTotal>");
			}
			if(ShippingDiscount != null)
			{
				sb.Append("<ebl:ShippingDiscount");
				sb.Append(ShippingDiscount.ToXMLString());
				sb.Append("</ebl:ShippingDiscount>");
			}
			if(InsuranceOptionOffered != null)
			{
				sb.Append("<ebl:InsuranceOptionOffered>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(InsuranceOptionOffered));
				sb.Append("</ebl:InsuranceOptionOffered>");
			}
			if(AllowedPaymentMethod != null)
			{
				sb.Append("<ebl:AllowedPaymentMethod>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(AllowedPaymentMethod)));
				sb.Append("</ebl:AllowedPaymentMethod>");
			}
			if(EnhancedPaymentData != null)
			{
				sb.Append("<ebl:EnhancedPaymentData>");
				sb.Append(EnhancedPaymentData.ToXMLString());
				sb.Append("</ebl:EnhancedPaymentData>");
			}
			if(SellerDetails != null)
			{
				sb.Append("<ebl:SellerDetails>");
				sb.Append(SellerDetails.ToXMLString());
				sb.Append("</ebl:SellerDetails>");
			}
			if(NoteText != null)
			{
				sb.Append("<ebl:NoteText>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(NoteText));
				sb.Append("</ebl:NoteText>");
			}
			if(TransactionId != null)
			{
				sb.Append("<ebl:TransactionId>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(TransactionId));
				sb.Append("</ebl:TransactionId>");
			}
			if(PaymentAction != null)
			{
				sb.Append("<ebl:PaymentAction>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(PaymentAction)));
				sb.Append("</ebl:PaymentAction>");
			}
			if(PaymentRequestID != null)
			{
				sb.Append("<ebl:PaymentRequestID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(PaymentRequestID));
				sb.Append("</ebl:PaymentRequestID>");
			}
			if(OrderURL != null)
			{
				sb.Append("<ebl:OrderURL>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(OrderURL));
				sb.Append("</ebl:OrderURL>");
			}
			if(SoftDescriptor != null)
			{
				sb.Append("<ebl:SoftDescriptor>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(SoftDescriptor));
				sb.Append("</ebl:SoftDescriptor>");
			}
			if(BranchLevel != null)
			{
				sb.Append("<ebl:BranchLevel>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(BranchLevel));
				sb.Append("</ebl:BranchLevel>");
			}
			if(OfferDetails != null)
			{
				sb.Append("<ebl:OfferDetails>");
				sb.Append(OfferDetails.ToXMLString());
				sb.Append("</ebl:OfferDetails>");
			}
			if(Recurring != null)
			{
				sb.Append("<ebl:Recurring>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(Recurring)));
				sb.Append("</ebl:Recurring>");
			}
			if(PaymentReason != null)
			{
				sb.Append("<ebl:PaymentReason>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(PaymentReason)));
				sb.Append("</ebl:PaymentReason>");
			}
			return sb.ToString();
		}

		public PaymentDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'OrderTotal']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.OrderTotal =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ItemTotal']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ItemTotal =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ShippingTotal']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ShippingTotal =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'HandlingTotal']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.HandlingTotal =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'TaxTotal']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.TaxTotal =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'OrderDescription']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.OrderDescription = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Custom']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Custom = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'InvoiceID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.InvoiceID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ButtonSource']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ButtonSource = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'NotifyURL']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.NotifyURL = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ShipToAddress']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ShipToAddress =  new AddressType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'FulfillmentReferenceNumber']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.FulfillmentReferenceNumber = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'FulfillmentAddress']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.FulfillmentAddress =  new AddressType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PaymentCategoryType']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PaymentCategoryType = (PaymentCategoryType)EnumUtils.GetValue(ChildNode.InnerText,typeof(PaymentCategoryType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ShippingMethod']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ShippingMethod = (ShippingServiceCodeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(ShippingServiceCodeType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ProfileAddressChangeDate']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ProfileAddressChangeDate = ChildNode.InnerText;
			}
			ChildNodeList = xmlNode.SelectNodes("*[local-name() = 'PaymentDetailsItem']");
			if (ChildNodeList != null && ChildNodeList.Count > 0)
			{
				for(int i = 0; i < ChildNodeList.Count; i++)
				{
					XmlNode subNode = ChildNodeList.Item(i);
					this.PaymentDetailsItem.Add(new PaymentDetailsItemType(subNode));
				}
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'InsuranceTotal']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.InsuranceTotal =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ShippingDiscount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ShippingDiscount =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'InsuranceOptionOffered']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.InsuranceOptionOffered = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'AllowedPaymentMethod']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.AllowedPaymentMethod = (AllowedPaymentMethodType)EnumUtils.GetValue(ChildNode.InnerText,typeof(AllowedPaymentMethodType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'EnhancedPaymentData']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.EnhancedPaymentData =  new EnhancedPaymentDataType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'SellerDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.SellerDetails =  new SellerDetailsType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'NoteText']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.NoteText = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'TransactionId']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.TransactionId = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PaymentAction']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PaymentAction = (PaymentActionCodeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(PaymentActionCodeType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PaymentRequestID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PaymentRequestID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'OrderURL']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.OrderURL = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'SoftDescriptor']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.SoftDescriptor = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'BranchLevel']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.BranchLevel = System.Convert.ToInt32(ChildNode.InnerText);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'OfferDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.OfferDetails =  new OfferDetailsType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Recurring']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Recurring = (RecurringFlagType)EnumUtils.GetValue(ChildNode.InnerText,typeof(RecurringFlagType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PaymentReason']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PaymentReason = (PaymentReasonType)EnumUtils.GetValue(ChildNode.InnerText,typeof(PaymentReasonType));
			}
	
		}
	}




	/**
      *Information about the incentives that were applied from Ebay
      *RYP page and PayPal RYP page. 
      */
	public partial class IncentiveDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public IncentiveDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'UniqueIdentifier']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.UniqueIdentifier = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'SiteAppliedOn']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.SiteAppliedOn = (IncentiveSiteAppliedOnType)EnumUtils.GetValue(ChildNode.InnerText,typeof(IncentiveSiteAppliedOnType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'TotalDiscountAmount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.TotalDiscountAmount =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Status']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Status = (IncentiveAppliedStatusType)EnumUtils.GetValue(ChildNode.InnerText,typeof(IncentiveAppliedStatusType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ErrorCode']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ErrorCode = System.Convert.ToInt32(ChildNode.InnerText);
			}
			ChildNodeList = xmlNode.SelectNodes("*[local-name() = 'IncentiveAppliedDetails']");
			if (ChildNodeList != null && ChildNodeList.Count > 0)
			{
				for(int i = 0; i < ChildNodeList.Count; i++)
				{
					XmlNode subNode = ChildNodeList.Item(i);
					this.IncentiveAppliedDetails.Add(new IncentiveAppliedDetailsType(subNode));
				}
			}
	
		}
	}




	/**
      *Details of incentive application on individual bucket/item. 
      */
	public partial class IncentiveAppliedDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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


		public IncentiveAppliedDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PaymentRequestID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PaymentRequestID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ItemId']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ItemId = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ExternalTxnId']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ExternalTxnId = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'DiscountAmount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.DiscountAmount =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'SubType']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.SubType = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *Details about the seller. 
      */
	public partial class SellerDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(SellerId != null)
			{
				sb.Append("<ebl:SellerId>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(SellerId));
				sb.Append("</ebl:SellerId>");
			}
			if(SellerUserName != null)
			{
				sb.Append("<ebl:SellerUserName>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(SellerUserName));
				sb.Append("</ebl:SellerUserName>");
			}
			if(SellerRegistrationDate != null)
			{
				sb.Append("<ebl:SellerRegistrationDate>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(SellerRegistrationDate));
				sb.Append("</ebl:SellerRegistrationDate>");
			}
			if(PayPalAccountID != null)
			{
				sb.Append("<ebl:PayPalAccountID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(PayPalAccountID));
				sb.Append("</ebl:PayPalAccountID>");
			}
			if(SecureMerchantAccountID != null)
			{
				sb.Append("<ebl:SecureMerchantAccountID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(SecureMerchantAccountID));
				sb.Append("</ebl:SecureMerchantAccountID>");
			}
			return sb.ToString();
		}

		public SellerDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'SellerId']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.SellerId = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'SellerUserName']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.SellerUserName = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'SellerRegistrationDate']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.SellerRegistrationDate = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PayPalAccountID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PayPalAccountID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'SecureMerchantAccountID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.SecureMerchantAccountID = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *Lists the Payment Methods (other than PayPal) that the use
      *can pay with e.g. Money Order. Optional. 
      */
	public partial class OtherPaymentMethodDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(OtherPaymentMethodId != null)
			{
				sb.Append("<ebl:OtherPaymentMethodId>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(OtherPaymentMethodId));
				sb.Append("</ebl:OtherPaymentMethodId>");
			}
			if(OtherPaymentMethodType != null)
			{
				sb.Append("<ebl:OtherPaymentMethodType>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(OtherPaymentMethodType));
				sb.Append("</ebl:OtherPaymentMethodType>");
			}
			if(OtherPaymentMethodLabel != null)
			{
				sb.Append("<ebl:OtherPaymentMethodLabel>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(OtherPaymentMethodLabel));
				sb.Append("</ebl:OtherPaymentMethodLabel>");
			}
			if(OtherPaymentMethodLabelDescription != null)
			{
				sb.Append("<ebl:OtherPaymentMethodLabelDescription>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(OtherPaymentMethodLabelDescription));
				sb.Append("</ebl:OtherPaymentMethodLabelDescription>");
			}
			if(OtherPaymentMethodLongDescriptionTitle != null)
			{
				sb.Append("<ebl:OtherPaymentMethodLongDescriptionTitle>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(OtherPaymentMethodLongDescriptionTitle));
				sb.Append("</ebl:OtherPaymentMethodLongDescriptionTitle>");
			}
			if(OtherPaymentMethodLongDescription != null)
			{
				sb.Append("<ebl:OtherPaymentMethodLongDescription>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(OtherPaymentMethodLongDescription));
				sb.Append("</ebl:OtherPaymentMethodLongDescription>");
			}
			if(OtherPaymentMethodIcon != null)
			{
				sb.Append("<ebl:OtherPaymentMethodIcon>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(OtherPaymentMethodIcon));
				sb.Append("</ebl:OtherPaymentMethodIcon>");
			}
			if(OtherPaymentMethodHideLabel != null)
			{
				sb.Append("<ebl:OtherPaymentMethodHideLabel>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(OtherPaymentMethodHideLabel));
				sb.Append("</ebl:OtherPaymentMethodHideLabel>");
			}
			return sb.ToString();
		}

	}




	/**
      *Details about the buyer's account passed in by the merchant
      *or partner. Optional. 
      */
	public partial class BuyerDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(BuyerId != null)
			{
				sb.Append("<ebl:BuyerId>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(BuyerId));
				sb.Append("</ebl:BuyerId>");
			}
			if(BuyerUserName != null)
			{
				sb.Append("<ebl:BuyerUserName>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(BuyerUserName));
				sb.Append("</ebl:BuyerUserName>");
			}
			if(BuyerRegistrationDate != null)
			{
				sb.Append("<ebl:BuyerRegistrationDate>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(BuyerRegistrationDate));
				sb.Append("</ebl:BuyerRegistrationDate>");
			}
			if(TaxIdDetails != null)
			{
				sb.Append("<ebl:TaxIdDetails>");
				sb.Append(TaxIdDetails.ToXMLString());
				sb.Append("</ebl:TaxIdDetails>");
			}
			if(IdentificationInfo != null)
			{
				sb.Append("<ebl:IdentificationInfo>");
				sb.Append(IdentificationInfo.ToXMLString());
				sb.Append("</ebl:IdentificationInfo>");
			}
			return sb.ToString();
		}

	}




	/**
      *Details about the payer's tax info passed in by the merchant
      *or partner. Optional. 
      */
	public partial class TaxIdDetailsType	{

		/**
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(TaxIdType != null)
			{
				sb.Append("<ebl:TaxIdType>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(TaxIdType));
				sb.Append("</ebl:TaxIdType>");
			}
			if(TaxId != null)
			{
				sb.Append("<ebl:TaxId>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(TaxId));
				sb.Append("</ebl:TaxId>");
			}
			return sb.ToString();
		}

		public TaxIdDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'TaxIdType']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.TaxIdType = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'TaxId']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.TaxId = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *The Common 3DS fields. Common for both GTD and DCC API's. 
      */
	public partial class ThreeDSecureRequestType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Eci3ds != null)
			{
				sb.Append("<ebl:Eci3ds>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Eci3ds));
				sb.Append("</ebl:Eci3ds>");
			}
			if(Cavv != null)
			{
				sb.Append("<ebl:Cavv>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Cavv));
				sb.Append("</ebl:Cavv>");
			}
			if(Xid != null)
			{
				sb.Append("<ebl:Xid>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Xid));
				sb.Append("</ebl:Xid>");
			}
			if(MpiVendor3ds != null)
			{
				sb.Append("<ebl:MpiVendor3ds>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(MpiVendor3ds));
				sb.Append("</ebl:MpiVendor3ds>");
			}
			if(AuthStatus3ds != null)
			{
				sb.Append("<ebl:AuthStatus3ds>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(AuthStatus3ds));
				sb.Append("</ebl:AuthStatus3ds>");
			}
			return sb.ToString();
		}

		public ThreeDSecureRequestType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Eci3ds']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Eci3ds = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Cavv']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Cavv = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Xid']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Xid = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'MpiVendor3ds']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.MpiVendor3ds = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'AuthStatus3ds']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.AuthStatus3ds = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *3DS remaining fields. 
      */
	public partial class ThreeDSecureResponseType	{

		/**
          *
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
          *
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


		public ThreeDSecureResponseType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Vpas']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Vpas = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'EciSubmitted3DS']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.EciSubmitted3DS = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *3DSecureInfoType Information about 3D Secure parameters. 
      */
	public partial class ThreeDSecureInfoType	{

		/**
          *
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
          *
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


		public ThreeDSecureInfoType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ThreeDSecureRequest']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ThreeDSecureRequest =  new ThreeDSecureRequestType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ThreeDSecureResponse']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ThreeDSecureResponse =  new ThreeDSecureResponseType(ChildNode);
			}
	
		}
	}




	/**
      *CreditCardDetailsType Information about a Credit Card. 
      */
	public partial class CreditCardDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(CreditCardType != null)
			{
				sb.Append("<ebl:CreditCardType>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(CreditCardType)));
				sb.Append("</ebl:CreditCardType>");
			}
			if(CreditCardNumber != null)
			{
				sb.Append("<ebl:CreditCardNumber>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(CreditCardNumber));
				sb.Append("</ebl:CreditCardNumber>");
			}
			if(ExpMonth != null)
			{
				sb.Append("<ebl:ExpMonth>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ExpMonth));
				sb.Append("</ebl:ExpMonth>");
			}
			if(ExpYear != null)
			{
				sb.Append("<ebl:ExpYear>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ExpYear));
				sb.Append("</ebl:ExpYear>");
			}
			if(CardOwner != null)
			{
				sb.Append("<ebl:CardOwner>");
				sb.Append(CardOwner.ToXMLString());
				sb.Append("</ebl:CardOwner>");
			}
			if(CVV2 != null)
			{
				sb.Append("<ebl:CVV2>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(CVV2));
				sb.Append("</ebl:CVV2>");
			}
			if(StartMonth != null)
			{
				sb.Append("<ebl:StartMonth>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(StartMonth));
				sb.Append("</ebl:StartMonth>");
			}
			if(StartYear != null)
			{
				sb.Append("<ebl:StartYear>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(StartYear));
				sb.Append("</ebl:StartYear>");
			}
			if(IssueNumber != null)
			{
				sb.Append("<ebl:IssueNumber>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(IssueNumber));
				sb.Append("</ebl:IssueNumber>");
			}
			if(ThreeDSecureRequest != null)
			{
				sb.Append("<ebl:ThreeDSecureRequest>");
				sb.Append(ThreeDSecureRequest.ToXMLString());
				sb.Append("</ebl:ThreeDSecureRequest>");
			}
			return sb.ToString();
		}

		public CreditCardDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'CreditCardType']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.CreditCardType = (CreditCardTypeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(CreditCardTypeType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'CreditCardNumber']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.CreditCardNumber = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ExpMonth']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ExpMonth = System.Convert.ToInt32(ChildNode.InnerText);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ExpYear']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ExpYear = System.Convert.ToInt32(ChildNode.InnerText);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'CardOwner']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.CardOwner =  new PayerInfoType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'CVV2']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.CVV2 = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'StartMonth']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.StartMonth = System.Convert.ToInt32(ChildNode.InnerText);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'StartYear']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.StartYear = System.Convert.ToInt32(ChildNode.InnerText);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'IssueNumber']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.IssueNumber = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ThreeDSecureRequest']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ThreeDSecureRequest =  new ThreeDSecureRequestType(ChildNode);
			}
	
		}
	}




	/**
      *Fallback shipping options type. 
      */
	public partial class ShippingOptionType	{

		/**
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ShippingOptionIsDefault != null)
			{
				sb.Append("<ebl:ShippingOptionIsDefault>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ShippingOptionIsDefault));
				sb.Append("</ebl:ShippingOptionIsDefault>");
			}
			if(ShippingOptionAmount != null)
			{
				sb.Append("<ebl:ShippingOptionAmount");
				sb.Append(ShippingOptionAmount.ToXMLString());
				sb.Append("</ebl:ShippingOptionAmount>");
			}
			if(ShippingOptionName != null)
			{
				sb.Append("<ebl:ShippingOptionName>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ShippingOptionName));
				sb.Append("</ebl:ShippingOptionName>");
			}
			return sb.ToString();
		}

	}




	/**
      *Information on user selected options 
      */
	public partial class UserSelectedOptionType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ShippingCalculationMode != null)
			{
				sb.Append("<ebl:ShippingCalculationMode>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ShippingCalculationMode));
				sb.Append("</ebl:ShippingCalculationMode>");
			}
			if(InsuranceOptionSelected != null)
			{
				sb.Append("<ebl:InsuranceOptionSelected>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(InsuranceOptionSelected));
				sb.Append("</ebl:InsuranceOptionSelected>");
			}
			if(ShippingOptionIsDefault != null)
			{
				sb.Append("<ebl:ShippingOptionIsDefault>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ShippingOptionIsDefault));
				sb.Append("</ebl:ShippingOptionIsDefault>");
			}
			if(ShippingOptionAmount != null)
			{
				sb.Append("<ebl:ShippingOptionAmount");
				sb.Append(ShippingOptionAmount.ToXMLString());
				sb.Append("</ebl:ShippingOptionAmount>");
			}
			if(ShippingOptionName != null)
			{
				sb.Append("<ebl:ShippingOptionName>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ShippingOptionName));
				sb.Append("</ebl:ShippingOptionName>");
			}
			return sb.ToString();
		}

		public UserSelectedOptionType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ShippingCalculationMode']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ShippingCalculationMode = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'InsuranceOptionSelected']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.InsuranceOptionSelected = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ShippingOptionIsDefault']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ShippingOptionIsDefault = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ShippingOptionAmount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ShippingOptionAmount =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ShippingOptionName']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ShippingOptionName = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *
      */
	public partial class CreditCardNumberTypeType	{

		/**
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(CreditCardType != null)
			{
				sb.Append("<ebl:CreditCardType>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(CreditCardType)));
				sb.Append("</ebl:CreditCardType>");
			}
			if(CreditCardNumber != null)
			{
				sb.Append("<ebl:CreditCardNumber>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(CreditCardNumber));
				sb.Append("</ebl:CreditCardNumber>");
			}
			return sb.ToString();
		}

	}




	/**
      *CreditCardDetailsType for DCC Reference Transaction
      *Information about a Credit Card. 
      */
	public partial class ReferenceCreditCardDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(CreditCardNumberType != null)
			{
				sb.Append("<ebl:CreditCardNumberType>");
				sb.Append(CreditCardNumberType.ToXMLString());
				sb.Append("</ebl:CreditCardNumberType>");
			}
			if(ExpMonth != null)
			{
				sb.Append("<ebl:ExpMonth>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ExpMonth));
				sb.Append("</ebl:ExpMonth>");
			}
			if(ExpYear != null)
			{
				sb.Append("<ebl:ExpYear>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ExpYear));
				sb.Append("</ebl:ExpYear>");
			}
			if(CardOwnerName != null)
			{
				sb.Append("<ebl:CardOwnerName>");
				sb.Append(CardOwnerName.ToXMLString());
				sb.Append("</ebl:CardOwnerName>");
			}
			if(BillingAddress != null)
			{
				sb.Append("<ebl:BillingAddress>");
				sb.Append(BillingAddress.ToXMLString());
				sb.Append("</ebl:BillingAddress>");
			}
			if(CVV2 != null)
			{
				sb.Append("<ebl:CVV2>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(CVV2));
				sb.Append("</ebl:CVV2>");
			}
			if(StartMonth != null)
			{
				sb.Append("<ebl:StartMonth>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(StartMonth));
				sb.Append("</ebl:StartMonth>");
			}
			if(StartYear != null)
			{
				sb.Append("<ebl:StartYear>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(StartYear));
				sb.Append("</ebl:StartYear>");
			}
			if(IssueNumber != null)
			{
				sb.Append("<ebl:IssueNumber>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(IssueNumber));
				sb.Append("</ebl:IssueNumber>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class SetCustomerBillingAgreementRequestDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(BillingAgreementDetails != null)
			{
				sb.Append("<ebl:BillingAgreementDetails>");
				sb.Append(BillingAgreementDetails.ToXMLString());
				sb.Append("</ebl:BillingAgreementDetails>");
			}
			if(ReturnURL != null)
			{
				sb.Append("<ebl:ReturnURL>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ReturnURL));
				sb.Append("</ebl:ReturnURL>");
			}
			if(CancelURL != null)
			{
				sb.Append("<ebl:CancelURL>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(CancelURL));
				sb.Append("</ebl:CancelURL>");
			}
			if(LocaleCode != null)
			{
				sb.Append("<ebl:LocaleCode>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(LocaleCode));
				sb.Append("</ebl:LocaleCode>");
			}
			if(PageStyle != null)
			{
				sb.Append("<ebl:PageStyle>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(PageStyle));
				sb.Append("</ebl:PageStyle>");
			}
			if(cppHeaderImage != null)
			{
				sb.Append("<ebl:cpp-header-image>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(cppHeaderImage));
				sb.Append("</ebl:cpp-header-image>");
			}
			if(cppHeaderBorderColor != null)
			{
				sb.Append("<ebl:cpp-header-border-color>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(cppHeaderBorderColor));
				sb.Append("</ebl:cpp-header-border-color>");
			}
			if(cppHeaderBackColor != null)
			{
				sb.Append("<ebl:cpp-header-back-color>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(cppHeaderBackColor));
				sb.Append("</ebl:cpp-header-back-color>");
			}
			if(cppPayflowColor != null)
			{
				sb.Append("<ebl:cpp-payflow-color>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(cppPayflowColor));
				sb.Append("</ebl:cpp-payflow-color>");
			}
			if(BuyerEmail != null)
			{
				sb.Append("<ebl:BuyerEmail>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(BuyerEmail));
				sb.Append("</ebl:BuyerEmail>");
			}
			if(ReqBillingAddress != null)
			{
				sb.Append("<ebl:ReqBillingAddress>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ReqBillingAddress));
				sb.Append("</ebl:ReqBillingAddress>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class GetBillingAgreementCustomerDetailsResponseDetailsType	{

		/**
          *
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
          *
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


		public GetBillingAgreementCustomerDetailsResponseDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PayerInfo']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PayerInfo =  new PayerInfoType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'BillingAddress']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.BillingAddress =  new AddressType(ChildNode);
			}
	
		}
	}




	/**
      *Device ID Optional  Character length and limits: 256
      *single-byte characters DeviceID length morethan 256 is
      *truncated  
      */
	public partial class DeviceDetailsType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(DeviceID != null)
			{
				sb.Append("<ebl:DeviceID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(DeviceID));
				sb.Append("</ebl:DeviceID>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class SenderDetailsType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(DeviceDetails != null)
			{
				sb.Append("<ebl:DeviceDetails>");
				sb.Append(DeviceDetails.ToXMLString());
				sb.Append("</ebl:DeviceDetails>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class DoReferenceTransactionRequestDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ReferenceID != null)
			{
				sb.Append("<ebl:ReferenceID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ReferenceID));
				sb.Append("</ebl:ReferenceID>");
			}
			if(PaymentAction != null)
			{
				sb.Append("<ebl:PaymentAction>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(PaymentAction)));
				sb.Append("</ebl:PaymentAction>");
			}
			if(PaymentType != null)
			{
				sb.Append("<ebl:PaymentType>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(PaymentType)));
				sb.Append("</ebl:PaymentType>");
			}
			if(PaymentDetails != null)
			{
				sb.Append("<ebl:PaymentDetails>");
				sb.Append(PaymentDetails.ToXMLString());
				sb.Append("</ebl:PaymentDetails>");
			}
			if(CreditCard != null)
			{
				sb.Append("<ebl:CreditCard>");
				sb.Append(CreditCard.ToXMLString());
				sb.Append("</ebl:CreditCard>");
			}
			if(IPAddress != null)
			{
				sb.Append("<ebl:IPAddress>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(IPAddress));
				sb.Append("</ebl:IPAddress>");
			}
			if(MerchantSessionId != null)
			{
				sb.Append("<ebl:MerchantSessionId>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(MerchantSessionId));
				sb.Append("</ebl:MerchantSessionId>");
			}
			if(ReqConfirmShipping != null)
			{
				sb.Append("<ebl:ReqConfirmShipping>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ReqConfirmShipping));
				sb.Append("</ebl:ReqConfirmShipping>");
			}
			if(SoftDescriptor != null)
			{
				sb.Append("<ebl:SoftDescriptor>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(SoftDescriptor));
				sb.Append("</ebl:SoftDescriptor>");
			}
			if(SenderDetails != null)
			{
				sb.Append("<ebl:SenderDetails>");
				sb.Append(SenderDetails.ToXMLString());
				sb.Append("</ebl:SenderDetails>");
			}
			if(MsgSubID != null)
			{
				sb.Append("<ebl:MsgSubID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(MsgSubID));
				sb.Append("</ebl:MsgSubID>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class DoReferenceTransactionResponseDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
	 	public DoReferenceTransactionResponseDetailsType(){
		}


		public DoReferenceTransactionResponseDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'BillingAgreementID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.BillingAgreementID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PaymentInfo']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PaymentInfo =  new PaymentInfoType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Amount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Amount =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'AVSCode']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.AVSCode = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'CVV2Code']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.CVV2Code = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'TransactionID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.TransactionID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PaymentAdviceCode']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PaymentAdviceCode = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'MsgSubID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.MsgSubID = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *
      */
	public partial class DoNonReferencedCreditRequestDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Amount != null)
			{
				sb.Append("<ebl:Amount");
				sb.Append(Amount.ToXMLString());
				sb.Append("</ebl:Amount>");
			}
			if(NetAmount != null)
			{
				sb.Append("<ebl:NetAmount");
				sb.Append(NetAmount.ToXMLString());
				sb.Append("</ebl:NetAmount>");
			}
			if(TaxAmount != null)
			{
				sb.Append("<ebl:TaxAmount");
				sb.Append(TaxAmount.ToXMLString());
				sb.Append("</ebl:TaxAmount>");
			}
			if(ShippingAmount != null)
			{
				sb.Append("<ebl:ShippingAmount");
				sb.Append(ShippingAmount.ToXMLString());
				sb.Append("</ebl:ShippingAmount>");
			}
			if(CreditCard != null)
			{
				sb.Append("<ebl:CreditCard>");
				sb.Append(CreditCard.ToXMLString());
				sb.Append("</ebl:CreditCard>");
			}
			if(ReceiverEmail != null)
			{
				sb.Append("<ebl:ReceiverEmail>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ReceiverEmail));
				sb.Append("</ebl:ReceiverEmail>");
			}
			if(Comment != null)
			{
				sb.Append("<ebl:Comment>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Comment));
				sb.Append("</ebl:Comment>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class DoNonReferencedCreditResponseDetailsType	{

		/**
          *
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
          *
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


		public DoNonReferencedCreditResponseDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Amount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Amount =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'TransactionID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.TransactionID = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *Onboarding program code given to you by PayPal. Required
      *Character length and limitations: 64 alphanumeric characters
      *
      */
	public partial class EnterBoardingRequestDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ProgramCode != null)
			{
				sb.Append("<ebl:ProgramCode>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ProgramCode));
				sb.Append("</ebl:ProgramCode>");
			}
			if(ProductList != null)
			{
				sb.Append("<ebl:ProductList>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ProductList));
				sb.Append("</ebl:ProductList>");
			}
			if(PartnerCustom != null)
			{
				sb.Append("<ebl:PartnerCustom>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(PartnerCustom));
				sb.Append("</ebl:PartnerCustom>");
			}
			if(ImageUrl != null)
			{
				sb.Append("<ebl:ImageUrl>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ImageUrl));
				sb.Append("</ebl:ImageUrl>");
			}
			if(MarketingCategory != null)
			{
				sb.Append("<ebl:MarketingCategory>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(MarketingCategory)));
				sb.Append("</ebl:MarketingCategory>");
			}
			if(BusinessInfo != null)
			{
				sb.Append("<ebl:BusinessInfo>");
				sb.Append(BusinessInfo.ToXMLString());
				sb.Append("</ebl:BusinessInfo>");
			}
			if(OwnerInfo != null)
			{
				sb.Append("<ebl:OwnerInfo>");
				sb.Append(OwnerInfo.ToXMLString());
				sb.Append("</ebl:OwnerInfo>");
			}
			if(BankAccount != null)
			{
				sb.Append("<ebl:BankAccount>");
				sb.Append(BankAccount.ToXMLString());
				sb.Append("</ebl:BankAccount>");
			}
			return sb.ToString();
		}

	}




	/**
      *BusinessInfoType 
      */
	public partial class BusinessInfoType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Type != null)
			{
				sb.Append("<ebl:Type>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(Type)));
				sb.Append("</ebl:Type>");
			}
			if(Name != null)
			{
				sb.Append("<ebl:Name>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Name));
				sb.Append("</ebl:Name>");
			}
			if(Address != null)
			{
				sb.Append("<ebl:Address>");
				sb.Append(Address.ToXMLString());
				sb.Append("</ebl:Address>");
			}
			if(WorkPhone != null)
			{
				sb.Append("<ebl:WorkPhone>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(WorkPhone));
				sb.Append("</ebl:WorkPhone>");
			}
			if(Category != null)
			{
				sb.Append("<ebl:Category>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(Category)));
				sb.Append("</ebl:Category>");
			}
			if(SubCategory != null)
			{
				sb.Append("<ebl:SubCategory>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(SubCategory)));
				sb.Append("</ebl:SubCategory>");
			}
			if(AveragePrice != null)
			{
				sb.Append("<ebl:AveragePrice>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(AveragePrice)));
				sb.Append("</ebl:AveragePrice>");
			}
			if(AverageMonthlyVolume != null)
			{
				sb.Append("<ebl:AverageMonthlyVolume>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(AverageMonthlyVolume)));
				sb.Append("</ebl:AverageMonthlyVolume>");
			}
			if(SalesVenue != null)
			{
				sb.Append("<ebl:SalesVenue>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(SalesVenue)));
				sb.Append("</ebl:SalesVenue>");
			}
			if(Website != null)
			{
				sb.Append("<ebl:Website>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Website));
				sb.Append("</ebl:Website>");
			}
			if(RevenueFromOnlineSales != null)
			{
				sb.Append("<ebl:RevenueFromOnlineSales>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(RevenueFromOnlineSales)));
				sb.Append("</ebl:RevenueFromOnlineSales>");
			}
			if(BusinessEstablished != null)
			{
				sb.Append("<ebl:BusinessEstablished>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(BusinessEstablished));
				sb.Append("</ebl:BusinessEstablished>");
			}
			if(CustomerServiceEmail != null)
			{
				sb.Append("<ebl:CustomerServiceEmail>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(CustomerServiceEmail));
				sb.Append("</ebl:CustomerServiceEmail>");
			}
			if(CustomerServicePhone != null)
			{
				sb.Append("<ebl:CustomerServicePhone>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(CustomerServicePhone));
				sb.Append("</ebl:CustomerServicePhone>");
			}
			return sb.ToString();
		}

	}




	/**
      *BusinessOwnerInfoType 
      */
	public partial class BusinessOwnerInfoType	{

		/**
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Owner != null)
			{
				sb.Append("<ebl:Owner>");
				sb.Append(Owner.ToXMLString());
				sb.Append("</ebl:Owner>");
			}
			if(HomePhone != null)
			{
				sb.Append("<ebl:HomePhone>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(HomePhone));
				sb.Append("</ebl:HomePhone>");
			}
			if(MobilePhone != null)
			{
				sb.Append("<ebl:MobilePhone>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(MobilePhone));
				sb.Append("</ebl:MobilePhone>");
			}
			if(SSN != null)
			{
				sb.Append("<ebl:SSN>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(SSN));
				sb.Append("</ebl:SSN>");
			}
			return sb.ToString();
		}

	}




	/**
      *BankAccountDetailsType 
      */
	public partial class BankAccountDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Name != null)
			{
				sb.Append("<ebl:Name>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Name));
				sb.Append("</ebl:Name>");
			}
			if(Type != null)
			{
				sb.Append("<ebl:Type>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(Type)));
				sb.Append("</ebl:Type>");
			}
			if(RoutingNumber != null)
			{
				sb.Append("<ebl:RoutingNumber>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(RoutingNumber));
				sb.Append("</ebl:RoutingNumber>");
			}
			if(AccountNumber != null)
			{
				sb.Append("<ebl:AccountNumber>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(AccountNumber));
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
	public partial class GetBoardingDetailsResponseDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public GetBoardingDetailsResponseDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Status']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Status = (BoardingStatusType)EnumUtils.GetValue(ChildNode.InnerText,typeof(BoardingStatusType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'StartDate']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.StartDate = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'LastUpdated']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.LastUpdated = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Reason']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Reason = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ProgramName']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ProgramName = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ProgramCode']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ProgramCode = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'CampaignID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.CampaignID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'UserWithdrawalLimit']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.UserWithdrawalLimit = (UserWithdrawalLimitTypeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(UserWithdrawalLimitTypeType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PartnerCustom']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PartnerCustom = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'AccountOwner']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.AccountOwner =  new PayerInfoType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Credentials']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Credentials =  new APICredentialsType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ConfigureAPIs']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ConfigureAPIs = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'EmailVerificationStatus']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.EmailVerificationStatus = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'VettingStatus']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.VettingStatus = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'BankAccountVerificationStatus']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.BankAccountVerificationStatus = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *APICredentialsType 
      */
	public partial class APICredentialsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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


		public APICredentialsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Username']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Username = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Password']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Password = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Signature']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Signature = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Certificate']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Certificate = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Type']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Type = (APIAuthenticationType)EnumUtils.GetValue(ChildNode.InnerText,typeof(APIAuthenticationType));
			}
	
		}
	}




	/**
      *The phone number of the buyer's mobile device, if available.
      *Optional 
      */
	public partial class SetMobileCheckoutRequestDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(BuyerPhone != null)
			{
				sb.Append("<ebl:BuyerPhone>");
				sb.Append(BuyerPhone.ToXMLString());
				sb.Append("</ebl:BuyerPhone>");
			}
			if(ItemAmount != null)
			{
				sb.Append("<ebl:ItemAmount");
				sb.Append(ItemAmount.ToXMLString());
				sb.Append("</ebl:ItemAmount>");
			}
			if(Tax != null)
			{
				sb.Append("<ebl:Tax");
				sb.Append(Tax.ToXMLString());
				sb.Append("</ebl:Tax>");
			}
			if(Shipping != null)
			{
				sb.Append("<ebl:Shipping");
				sb.Append(Shipping.ToXMLString());
				sb.Append("</ebl:Shipping>");
			}
			if(ItemName != null)
			{
				sb.Append("<ebl:ItemName>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ItemName));
				sb.Append("</ebl:ItemName>");
			}
			if(ItemNumber != null)
			{
				sb.Append("<ebl:ItemNumber>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ItemNumber));
				sb.Append("</ebl:ItemNumber>");
			}
			if(Custom != null)
			{
				sb.Append("<ebl:Custom>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Custom));
				sb.Append("</ebl:Custom>");
			}
			if(InvoiceID != null)
			{
				sb.Append("<ebl:InvoiceID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(InvoiceID));
				sb.Append("</ebl:InvoiceID>");
			}
			if(ReturnURL != null)
			{
				sb.Append("<ebl:ReturnURL>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ReturnURL));
				sb.Append("</ebl:ReturnURL>");
			}
			if(CancelURL != null)
			{
				sb.Append("<ebl:CancelURL>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(CancelURL));
				sb.Append("</ebl:CancelURL>");
			}
			if(AddressDisplayOptions != null)
			{
				sb.Append("<ebl:AddressDisplayOptions>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(AddressDisplayOptions));
				sb.Append("</ebl:AddressDisplayOptions>");
			}
			if(SharePhone != null)
			{
				sb.Append("<ebl:SharePhone>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(SharePhone));
				sb.Append("</ebl:SharePhone>");
			}
			if(ShipToAddress != null)
			{
				sb.Append("<ebl:ShipToAddress>");
				sb.Append(ShipToAddress.ToXMLString());
				sb.Append("</ebl:ShipToAddress>");
			}
			if(BuyerEmail != null)
			{
				sb.Append("<ebl:BuyerEmail>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(BuyerEmail));
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
	public partial class DoMobileCheckoutPaymentResponseDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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


		public DoMobileCheckoutPaymentResponseDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Custom']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Custom = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'InvoiceID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.InvoiceID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PayerInfo']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PayerInfo =  new PayerInfoType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PaymentInfo']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PaymentInfo =  new PaymentInfoType(ChildNode);
			}
	
		}
	}




	/**
      *UATP Card Details Type 
      */
	public partial class UATPDetailsType	{

		/**
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(UATPNumber != null)
			{
				sb.Append("<ebl:UATPNumber>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(UATPNumber));
				sb.Append("</ebl:UATPNumber>");
			}
			if(ExpMonth != null)
			{
				sb.Append("<ebl:ExpMonth>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ExpMonth));
				sb.Append("</ebl:ExpMonth>");
			}
			if(ExpYear != null)
			{
				sb.Append("<ebl:ExpYear>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ExpYear));
				sb.Append("</ebl:ExpYear>");
			}
			return sb.ToString();
		}

		public UATPDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'UATPNumber']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.UATPNumber = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ExpMonth']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ExpMonth = System.Convert.ToInt32(ChildNode.InnerText);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ExpYear']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ExpYear = System.Convert.ToInt32(ChildNode.InnerText);
			}
	
		}
	}




	/**
      *
      */
	public partial class RecurringPaymentsSummaryType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public RecurringPaymentsSummaryType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'NextBillingDate']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.NextBillingDate = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'NumberCyclesCompleted']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.NumberCyclesCompleted = System.Convert.ToInt32(ChildNode.InnerText);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'NumberCyclesRemaining']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.NumberCyclesRemaining = System.Convert.ToInt32(ChildNode.InnerText);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'OutstandingBalance']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.OutstandingBalance =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'FailedPaymentCount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.FailedPaymentCount = System.Convert.ToInt32(ChildNode.InnerText);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'LastPaymentDate']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.LastPaymentDate = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'LastPaymentAmount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.LastPaymentAmount =  new BasicAmountType(ChildNode);
			}
	
		}
	}




	/**
      *
      */
	public partial class ActivationDetailsType	{

		/**
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(InitialAmount != null)
			{
				sb.Append("<ebl:InitialAmount");
				sb.Append(InitialAmount.ToXMLString());
				sb.Append("</ebl:InitialAmount>");
			}
			if(FailedInitialAmountAction != null)
			{
				sb.Append("<ebl:FailedInitialAmountAction>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(FailedInitialAmountAction)));
				sb.Append("</ebl:FailedInitialAmountAction>");
			}
			return sb.ToString();
		}

	}




	/**
      *Unit of meausre for billing cycle 
      */
	public partial class BillingPeriodDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(BillingPeriod != null)
			{
				sb.Append("<ebl:BillingPeriod>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(BillingPeriod)));
				sb.Append("</ebl:BillingPeriod>");
			}
			if(BillingFrequency != null)
			{
				sb.Append("<ebl:BillingFrequency>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(BillingFrequency));
				sb.Append("</ebl:BillingFrequency>");
			}
			if(TotalBillingCycles != null)
			{
				sb.Append("<ebl:TotalBillingCycles>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(TotalBillingCycles));
				sb.Append("</ebl:TotalBillingCycles>");
			}
			if(Amount != null)
			{
				sb.Append("<ebl:Amount");
				sb.Append(Amount.ToXMLString());
				sb.Append("</ebl:Amount>");
			}
			if(ShippingAmount != null)
			{
				sb.Append("<ebl:ShippingAmount");
				sb.Append(ShippingAmount.ToXMLString());
				sb.Append("</ebl:ShippingAmount>");
			}
			if(TaxAmount != null)
			{
				sb.Append("<ebl:TaxAmount");
				sb.Append(TaxAmount.ToXMLString());
				sb.Append("</ebl:TaxAmount>");
			}
			return sb.ToString();
		}

		public BillingPeriodDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'BillingPeriod']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.BillingPeriod = (BillingPeriodType)EnumUtils.GetValue(ChildNode.InnerText,typeof(BillingPeriodType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'BillingFrequency']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.BillingFrequency = System.Convert.ToInt32(ChildNode.InnerText);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'TotalBillingCycles']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.TotalBillingCycles = System.Convert.ToInt32(ChildNode.InnerText);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Amount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Amount =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ShippingAmount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ShippingAmount =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'TaxAmount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.TaxAmount =  new BasicAmountType(ChildNode);
			}
	
		}
	}




	/**
      *Unit of meausre for billing cycle 
      */
	public partial class BillingPeriodDetailsType_Update	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(BillingPeriod != null)
			{
				sb.Append("<ebl:BillingPeriod>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(BillingPeriod)));
				sb.Append("</ebl:BillingPeriod>");
			}
			if(BillingFrequency != null)
			{
				sb.Append("<ebl:BillingFrequency>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(BillingFrequency));
				sb.Append("</ebl:BillingFrequency>");
			}
			if(TotalBillingCycles != null)
			{
				sb.Append("<ebl:TotalBillingCycles>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(TotalBillingCycles));
				sb.Append("</ebl:TotalBillingCycles>");
			}
			if(Amount != null)
			{
				sb.Append("<ebl:Amount");
				sb.Append(Amount.ToXMLString());
				sb.Append("</ebl:Amount>");
			}
			if(ShippingAmount != null)
			{
				sb.Append("<ebl:ShippingAmount");
				sb.Append(ShippingAmount.ToXMLString());
				sb.Append("</ebl:ShippingAmount>");
			}
			if(TaxAmount != null)
			{
				sb.Append("<ebl:TaxAmount");
				sb.Append(TaxAmount.ToXMLString());
				sb.Append("</ebl:TaxAmount>");
			}
			return sb.ToString();
		}

	}




	/**
      *Schedule details for the Recurring Payment 
      */
	public partial class ScheduleDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Description != null)
			{
				sb.Append("<ebl:Description>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Description));
				sb.Append("</ebl:Description>");
			}
			if(TrialPeriod != null)
			{
				sb.Append("<ebl:TrialPeriod>");
				sb.Append(TrialPeriod.ToXMLString());
				sb.Append("</ebl:TrialPeriod>");
			}
			if(PaymentPeriod != null)
			{
				sb.Append("<ebl:PaymentPeriod>");
				sb.Append(PaymentPeriod.ToXMLString());
				sb.Append("</ebl:PaymentPeriod>");
			}
			if(MaxFailedPayments != null)
			{
				sb.Append("<ebl:MaxFailedPayments>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(MaxFailedPayments));
				sb.Append("</ebl:MaxFailedPayments>");
			}
			if(ActivationDetails != null)
			{
				sb.Append("<ebl:ActivationDetails>");
				sb.Append(ActivationDetails.ToXMLString());
				sb.Append("</ebl:ActivationDetails>");
			}
			if(AutoBillOutstandingAmount != null)
			{
				sb.Append("<ebl:AutoBillOutstandingAmount>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(AutoBillOutstandingAmount)));
				sb.Append("</ebl:AutoBillOutstandingAmount>");
			}
			return sb.ToString();
		}

	}




	/**
      *Subscriber name - if missing, will use name in buyer's
      *account 
      */
	public partial class RecurringPaymentsProfileDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(SubscriberName != null)
			{
				sb.Append("<ebl:SubscriberName>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(SubscriberName));
				sb.Append("</ebl:SubscriberName>");
			}
			if(SubscriberShippingAddress != null)
			{
				sb.Append("<ebl:SubscriberShippingAddress>");
				sb.Append(SubscriberShippingAddress.ToXMLString());
				sb.Append("</ebl:SubscriberShippingAddress>");
			}
			if(BillingStartDate != null)
			{
				sb.Append("<ebl:BillingStartDate>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(BillingStartDate));
				sb.Append("</ebl:BillingStartDate>");
			}
			if(ProfileReference != null)
			{
				sb.Append("<ebl:ProfileReference>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ProfileReference));
				sb.Append("</ebl:ProfileReference>");
			}
			return sb.ToString();
		}

		public RecurringPaymentsProfileDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'SubscriberName']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.SubscriberName = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'SubscriberShippingAddress']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.SubscriberShippingAddress =  new AddressType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'BillingStartDate']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.BillingStartDate = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ProfileReference']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ProfileReference = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *Billing Agreement token (required if Express Checkout) 
      */
	public partial class CreateRecurringPaymentsProfileRequestDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Token != null)
			{
				sb.Append("<ebl:Token>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Token));
				sb.Append("</ebl:Token>");
			}
			if(CreditCard != null)
			{
				sb.Append("<ebl:CreditCard>");
				sb.Append(CreditCard.ToXMLString());
				sb.Append("</ebl:CreditCard>");
			}
			if(RecurringPaymentsProfileDetails != null)
			{
				sb.Append("<ebl:RecurringPaymentsProfileDetails>");
				sb.Append(RecurringPaymentsProfileDetails.ToXMLString());
				sb.Append("</ebl:RecurringPaymentsProfileDetails>");
			}
			if(ScheduleDetails != null)
			{
				sb.Append("<ebl:ScheduleDetails>");
				sb.Append(ScheduleDetails.ToXMLString());
				sb.Append("</ebl:ScheduleDetails>");
			}
			if(PaymentDetailsItem != null)
			{
				for(int i = 0; i < PaymentDetailsItem.Count; i++)
				{
					sb.Append("<ebl:PaymentDetailsItem>");
					sb.Append(PaymentDetailsItem[i].ToXMLString());
					sb.Append("</ebl:PaymentDetailsItem>");
				}
			}
			return sb.ToString();
		}

	}




	/**
      *Recurring Billing Profile ID 
      */
	public partial class CreateRecurringPaymentsProfileResponseDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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


		public CreateRecurringPaymentsProfileResponseDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ProfileID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ProfileID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ProfileStatus']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ProfileStatus = (RecurringPaymentsProfileStatusType)EnumUtils.GetValue(ChildNode.InnerText,typeof(RecurringPaymentsProfileStatusType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'TransactionID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.TransactionID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'DCCProcessorResponse']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.DCCProcessorResponse = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'DCCReturnCode']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.DCCReturnCode = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *Recurring Billing Profile ID 
      */
	public partial class GetRecurringPaymentsProfileDetailsResponseDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public GetRecurringPaymentsProfileDetailsResponseDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ProfileID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ProfileID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ProfileStatus']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ProfileStatus = (RecurringPaymentsProfileStatusType)EnumUtils.GetValue(ChildNode.InnerText,typeof(RecurringPaymentsProfileStatusType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Description']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Description = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'AutoBillOutstandingAmount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.AutoBillOutstandingAmount = (AutoBillType)EnumUtils.GetValue(ChildNode.InnerText,typeof(AutoBillType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'MaxFailedPayments']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.MaxFailedPayments = System.Convert.ToInt32(ChildNode.InnerText);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'RecurringPaymentsProfileDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.RecurringPaymentsProfileDetails =  new RecurringPaymentsProfileDetailsType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'CurrentRecurringPaymentsPeriod']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.CurrentRecurringPaymentsPeriod =  new BillingPeriodDetailsType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'RecurringPaymentsSummary']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.RecurringPaymentsSummary =  new RecurringPaymentsSummaryType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'CreditCard']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.CreditCard =  new CreditCardDetailsType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'TrialRecurringPaymentsPeriod']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.TrialRecurringPaymentsPeriod =  new BillingPeriodDetailsType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'RegularRecurringPaymentsPeriod']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.RegularRecurringPaymentsPeriod =  new BillingPeriodDetailsType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'TrialAmountPaid']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.TrialAmountPaid =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'RegularAmountPaid']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.RegularAmountPaid =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'AggregateAmount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.AggregateAmount =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'AggregateOptionalAmount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.AggregateOptionalAmount =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'FinalPaymentDueDate']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.FinalPaymentDueDate = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *
      */
	public partial class ManageRecurringPaymentsProfileStatusRequestDetailsType	{

		/**
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ProfileID != null)
			{
				sb.Append("<ebl:ProfileID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ProfileID));
				sb.Append("</ebl:ProfileID>");
			}
			if(Action != null)
			{
				sb.Append("<ebl:Action>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(Action)));
				sb.Append("</ebl:Action>");
			}
			if(Note != null)
			{
				sb.Append("<ebl:Note>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Note));
				sb.Append("</ebl:Note>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class ManageRecurringPaymentsProfileStatusResponseDetailsType	{

		/**
          *
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


		public ManageRecurringPaymentsProfileStatusResponseDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ProfileID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ProfileID = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *
      */
	public partial class BillOutstandingAmountRequestDetailsType	{

		/**
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ProfileID != null)
			{
				sb.Append("<ebl:ProfileID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ProfileID));
				sb.Append("</ebl:ProfileID>");
			}
			if(Amount != null)
			{
				sb.Append("<ebl:Amount");
				sb.Append(Amount.ToXMLString());
				sb.Append("</ebl:Amount>");
			}
			if(Note != null)
			{
				sb.Append("<ebl:Note>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Note));
				sb.Append("</ebl:Note>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class BillOutstandingAmountResponseDetailsType	{

		/**
          *
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


		public BillOutstandingAmountResponseDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ProfileID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ProfileID = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *
      */
	public partial class UpdateRecurringPaymentsProfileRequestDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ProfileID != null)
			{
				sb.Append("<ebl:ProfileID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ProfileID));
				sb.Append("</ebl:ProfileID>");
			}
			if(Note != null)
			{
				sb.Append("<ebl:Note>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Note));
				sb.Append("</ebl:Note>");
			}
			if(Description != null)
			{
				sb.Append("<ebl:Description>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Description));
				sb.Append("</ebl:Description>");
			}
			if(SubscriberName != null)
			{
				sb.Append("<ebl:SubscriberName>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(SubscriberName));
				sb.Append("</ebl:SubscriberName>");
			}
			if(SubscriberShippingAddress != null)
			{
				sb.Append("<ebl:SubscriberShippingAddress>");
				sb.Append(SubscriberShippingAddress.ToXMLString());
				sb.Append("</ebl:SubscriberShippingAddress>");
			}
			if(ProfileReference != null)
			{
				sb.Append("<ebl:ProfileReference>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ProfileReference));
				sb.Append("</ebl:ProfileReference>");
			}
			if(AdditionalBillingCycles != null)
			{
				sb.Append("<ebl:AdditionalBillingCycles>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(AdditionalBillingCycles));
				sb.Append("</ebl:AdditionalBillingCycles>");
			}
			if(Amount != null)
			{
				sb.Append("<ebl:Amount");
				sb.Append(Amount.ToXMLString());
				sb.Append("</ebl:Amount>");
			}
			if(ShippingAmount != null)
			{
				sb.Append("<ebl:ShippingAmount");
				sb.Append(ShippingAmount.ToXMLString());
				sb.Append("</ebl:ShippingAmount>");
			}
			if(TaxAmount != null)
			{
				sb.Append("<ebl:TaxAmount");
				sb.Append(TaxAmount.ToXMLString());
				sb.Append("</ebl:TaxAmount>");
			}
			if(OutstandingBalance != null)
			{
				sb.Append("<ebl:OutstandingBalance");
				sb.Append(OutstandingBalance.ToXMLString());
				sb.Append("</ebl:OutstandingBalance>");
			}
			if(AutoBillOutstandingAmount != null)
			{
				sb.Append("<ebl:AutoBillOutstandingAmount>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(AutoBillOutstandingAmount)));
				sb.Append("</ebl:AutoBillOutstandingAmount>");
			}
			if(MaxFailedPayments != null)
			{
				sb.Append("<ebl:MaxFailedPayments>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(MaxFailedPayments));
				sb.Append("</ebl:MaxFailedPayments>");
			}
			if(CreditCard != null)
			{
				sb.Append("<ebl:CreditCard>");
				sb.Append(CreditCard.ToXMLString());
				sb.Append("</ebl:CreditCard>");
			}
			if(BillingStartDate != null)
			{
				sb.Append("<ebl:BillingStartDate>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(BillingStartDate));
				sb.Append("</ebl:BillingStartDate>");
			}
			if(TrialPeriod != null)
			{
				sb.Append("<ebl:TrialPeriod>");
				sb.Append(TrialPeriod.ToXMLString());
				sb.Append("</ebl:TrialPeriod>");
			}
			if(PaymentPeriod != null)
			{
				sb.Append("<ebl:PaymentPeriod>");
				sb.Append(PaymentPeriod.ToXMLString());
				sb.Append("</ebl:PaymentPeriod>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class UpdateRecurringPaymentsProfileResponseDetailsType	{

		/**
          *
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


		public UpdateRecurringPaymentsProfileResponseDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ProfileID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ProfileID = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *Details of Risk Filter. 
      */
	public partial class RiskFilterDetailsType	{

		/**
          *
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
          *
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
          *
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


		public RiskFilterDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Id']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Id = System.Convert.ToInt32(ChildNode.InnerText);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Name']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Name = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Description']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Description = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *Details of Risk Filter. 
      */
	public partial class RiskFilterListType	{

		/**
          *
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


		public RiskFilterListType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNodeList = xmlNode.SelectNodes("*[local-name() = 'Filters']");
			if (ChildNodeList != null && ChildNodeList.Count > 0)
			{
				for(int i = 0; i < ChildNodeList.Count; i++)
				{
					XmlNode subNode = ChildNodeList.Item(i);
					this.Filters.Add(new RiskFilterDetailsType(subNode));
				}
			}
	
		}
	}




	/**
      *Thes are filters that could result in accept/deny/pending
      *action. 
      */
	public partial class FMFDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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


		public FMFDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'AcceptFilters']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.AcceptFilters =  new RiskFilterListType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PendingFilters']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PendingFilters =  new RiskFilterListType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'DenyFilters']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.DenyFilters =  new RiskFilterListType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ReportFilters']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ReportFilters =  new RiskFilterListType(ChildNode);
			}
	
		}
	}




	/**
      *Enhanced Data Information. Example: AID for Airlines 
      */
	public partial class EnhancedDataType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(AirlineItinerary != null)
			{
				sb.Append("<ebl:AirlineItinerary>");
				sb.Append(AirlineItinerary.ToXMLString());
				sb.Append("</ebl:AirlineItinerary>");
			}
			return sb.ToString();
		}

	}




	/**
      *AID for Airlines 
      */
	public partial class AirlineItineraryType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(PassengerName != null)
			{
				sb.Append("<ebl:PassengerName>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(PassengerName));
				sb.Append("</ebl:PassengerName>");
			}
			if(IssueDate != null)
			{
				sb.Append("<ebl:IssueDate>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(IssueDate));
				sb.Append("</ebl:IssueDate>");
			}
			if(TravelAgencyName != null)
			{
				sb.Append("<ebl:TravelAgencyName>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(TravelAgencyName));
				sb.Append("</ebl:TravelAgencyName>");
			}
			if(TravelAgencyCode != null)
			{
				sb.Append("<ebl:TravelAgencyCode>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(TravelAgencyCode));
				sb.Append("</ebl:TravelAgencyCode>");
			}
			if(TicketNumber != null)
			{
				sb.Append("<ebl:TicketNumber>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(TicketNumber));
				sb.Append("</ebl:TicketNumber>");
			}
			if(IssuingCarrierCode != null)
			{
				sb.Append("<ebl:IssuingCarrierCode>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(IssuingCarrierCode));
				sb.Append("</ebl:IssuingCarrierCode>");
			}
			if(CustomerCode != null)
			{
				sb.Append("<ebl:CustomerCode>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(CustomerCode));
				sb.Append("</ebl:CustomerCode>");
			}
			if(TotalFare != null)
			{
				sb.Append("<ebl:TotalFare");
				sb.Append(TotalFare.ToXMLString());
				sb.Append("</ebl:TotalFare>");
			}
			if(TotalTaxes != null)
			{
				sb.Append("<ebl:TotalTaxes");
				sb.Append(TotalTaxes.ToXMLString());
				sb.Append("</ebl:TotalTaxes>");
			}
			if(TotalFee != null)
			{
				sb.Append("<ebl:TotalFee");
				sb.Append(TotalFee.ToXMLString());
				sb.Append("</ebl:TotalFee>");
			}
			if(RestrictedTicket != null)
			{
				sb.Append("<ebl:RestrictedTicket>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(RestrictedTicket));
				sb.Append("</ebl:RestrictedTicket>");
			}
			if(ClearingSequence != null)
			{
				sb.Append("<ebl:ClearingSequence>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ClearingSequence));
				sb.Append("</ebl:ClearingSequence>");
			}
			if(ClearingCount != null)
			{
				sb.Append("<ebl:ClearingCount>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ClearingCount));
				sb.Append("</ebl:ClearingCount>");
			}
			if(FlightDetails != null)
			{
				for(int i = 0; i < FlightDetails.Count; i++)
				{
					sb.Append("<ebl:FlightDetails>");
					sb.Append(FlightDetails[i].ToXMLString());
					sb.Append("</ebl:FlightDetails>");
				}
			}
			return sb.ToString();
		}

	}




	/**
      *Details of leg information 
      */
	public partial class FlightDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ConjuctionTicket != null)
			{
				sb.Append("<ebl:ConjuctionTicket>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ConjuctionTicket));
				sb.Append("</ebl:ConjuctionTicket>");
			}
			if(ExchangeTicket != null)
			{
				sb.Append("<ebl:ExchangeTicket>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ExchangeTicket));
				sb.Append("</ebl:ExchangeTicket>");
			}
			if(CouponNumber != null)
			{
				sb.Append("<ebl:CouponNumber>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(CouponNumber));
				sb.Append("</ebl:CouponNumber>");
			}
			if(ServiceClass != null)
			{
				sb.Append("<ebl:ServiceClass>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ServiceClass));
				sb.Append("</ebl:ServiceClass>");
			}
			if(TravelDate != null)
			{
				sb.Append("<ebl:TravelDate>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(TravelDate));
				sb.Append("</ebl:TravelDate>");
			}
			if(CarrierCode != null)
			{
				sb.Append("<ebl:CarrierCode>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(CarrierCode));
				sb.Append("</ebl:CarrierCode>");
			}
			if(StopOverPermitted != null)
			{
				sb.Append("<ebl:StopOverPermitted>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(StopOverPermitted));
				sb.Append("</ebl:StopOverPermitted>");
			}
			if(DepartureAirport != null)
			{
				sb.Append("<ebl:DepartureAirport>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(DepartureAirport));
				sb.Append("</ebl:DepartureAirport>");
			}
			if(ArrivalAirport != null)
			{
				sb.Append("<ebl:ArrivalAirport>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ArrivalAirport));
				sb.Append("</ebl:ArrivalAirport>");
			}
			if(FlightNumber != null)
			{
				sb.Append("<ebl:FlightNumber>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(FlightNumber));
				sb.Append("</ebl:FlightNumber>");
			}
			if(DepartureTime != null)
			{
				sb.Append("<ebl:DepartureTime>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(DepartureTime));
				sb.Append("</ebl:DepartureTime>");
			}
			if(ArrivalTime != null)
			{
				sb.Append("<ebl:ArrivalTime>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ArrivalTime));
				sb.Append("</ebl:ArrivalTime>");
			}
			if(FareBasisCode != null)
			{
				sb.Append("<ebl:FareBasisCode>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(FareBasisCode));
				sb.Append("</ebl:FareBasisCode>");
			}
			if(Fare != null)
			{
				sb.Append("<ebl:Fare");
				sb.Append(Fare.ToXMLString());
				sb.Append("</ebl:Fare>");
			}
			if(Taxes != null)
			{
				sb.Append("<ebl:Taxes");
				sb.Append(Taxes.ToXMLString());
				sb.Append("</ebl:Taxes>");
			}
			if(Fee != null)
			{
				sb.Append("<ebl:Fee");
				sb.Append(Fee.ToXMLString());
				sb.Append("</ebl:Fee>");
			}
			if(EndorsementOrRestrictions != null)
			{
				sb.Append("<ebl:EndorsementOrRestrictions>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EndorsementOrRestrictions));
				sb.Append("</ebl:EndorsementOrRestrictions>");
			}
			return sb.ToString();
		}

	}




	/**
      *Authorization details 
      */
	public partial class AuthorizationInfoType	{

		/**
          *
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
          *
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
          *
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
          *
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


		public AuthorizationInfoType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PaymentStatus']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PaymentStatus = (PaymentStatusCodeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(PaymentStatusCodeType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PendingReason']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PendingReason = (PendingStatusCodeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(PendingStatusCodeType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ProtectionEligibility']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ProtectionEligibility = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ProtectionEligibilityType']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ProtectionEligibilityType = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *Option Number. Optional 
      */
	public partial class OptionTrackingDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(OptionNumber != null)
			{
				sb.Append("<ebl:OptionNumber>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(OptionNumber));
				sb.Append("</ebl:OptionNumber>");
			}
			if(OptionQty != null)
			{
				sb.Append("<ebl:OptionQty>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(OptionQty));
				sb.Append("</ebl:OptionQty>");
			}
			if(OptionSelect != null)
			{
				sb.Append("<ebl:OptionSelect>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(OptionSelect));
				sb.Append("</ebl:OptionSelect>");
			}
			if(OptionQtyDelta != null)
			{
				sb.Append("<ebl:OptionQtyDelta>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(OptionQtyDelta));
				sb.Append("</ebl:OptionQtyDelta>");
			}
			if(OptionAlert != null)
			{
				sb.Append("<ebl:OptionAlert>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(OptionAlert));
				sb.Append("</ebl:OptionAlert>");
			}
			if(OptionCost != null)
			{
				sb.Append("<ebl:OptionCost>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(OptionCost));
				sb.Append("</ebl:OptionCost>");
			}
			return sb.ToString();
		}

		public OptionTrackingDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'OptionNumber']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.OptionNumber = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'OptionQty']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.OptionQty = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'OptionSelect']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.OptionSelect = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'OptionQtyDelta']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.OptionQtyDelta = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'OptionAlert']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.OptionAlert = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'OptionCost']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.OptionCost = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *Item Number. Required 
      */
	public partial class ItemTrackingDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ItemNumber != null)
			{
				sb.Append("<ebl:ItemNumber>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ItemNumber));
				sb.Append("</ebl:ItemNumber>");
			}
			if(ItemQty != null)
			{
				sb.Append("<ebl:ItemQty>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ItemQty));
				sb.Append("</ebl:ItemQty>");
			}
			if(ItemQtyDelta != null)
			{
				sb.Append("<ebl:ItemQtyDelta>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ItemQtyDelta));
				sb.Append("</ebl:ItemQtyDelta>");
			}
			if(ItemAlert != null)
			{
				sb.Append("<ebl:ItemAlert>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ItemAlert));
				sb.Append("</ebl:ItemAlert>");
			}
			if(ItemCost != null)
			{
				sb.Append("<ebl:ItemCost>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ItemCost));
				sb.Append("</ebl:ItemCost>");
			}
			return sb.ToString();
		}

		public ItemTrackingDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ItemNumber']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ItemNumber = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ItemQty']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ItemQty = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ItemQtyDelta']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ItemQtyDelta = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ItemAlert']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ItemAlert = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ItemCost']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ItemCost = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *
      */
	public partial class ButtonSearchResultType	{

		/**
          *
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
          *
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
          *
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
          *
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


		public ButtonSearchResultType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'HostedButtonID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.HostedButtonID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ButtonType']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ButtonType = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ItemName']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ItemName = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ModifyDate']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ModifyDate = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *Identifier of the transaction to reverse. Required Character
      *length and limitations: 17 single-byte alphanumeric
      *characters 
      */
	public partial class ReverseTransactionRequestDetailsType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(TransactionID != null)
			{
				sb.Append("<ebl:TransactionID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(TransactionID));
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
	public partial class ReverseTransactionResponseDetailsType	{

		/**
          *
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
          *
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


		public ReverseTransactionResponseDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ReverseTransactionID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ReverseTransactionID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Status']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Status = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *Details of incentive application on individual bucket. 
      */
	public partial class IncentiveInfoType	{

		/**
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(IncentiveCode != null)
			{
				sb.Append("<ebl:IncentiveCode>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(IncentiveCode));
				sb.Append("</ebl:IncentiveCode>");
			}
			if(ApplyIndication != null)
			{
				for(int i = 0; i < ApplyIndication.Count; i++)
				{
					sb.Append("<ebl:ApplyIndication>");
					sb.Append(ApplyIndication[i].ToXMLString());
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
	public partial class IncentiveApplyIndicationType	{

		/**
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(PaymentRequestID != null)
			{
				sb.Append("<ebl:PaymentRequestID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(PaymentRequestID));
				sb.Append("</ebl:PaymentRequestID>");
			}
			if(ItemId != null)
			{
				sb.Append("<ebl:ItemId>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ItemId));
				sb.Append("</ebl:ItemId>");
			}
			return sb.ToString();
		}

	}




	/**
      *Contains payment request information for each bucket in the
      *cart.  
      */
	public partial class PaymentRequestInfoType	{

		/**
          *
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
          *
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
          *
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


		public PaymentRequestInfoType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'TransactionId']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.TransactionId = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PaymentRequestID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PaymentRequestID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PaymentError']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PaymentError =  new ErrorType(ChildNode);
			}
	
		}
	}




	/**
      *E-mail address or secure merchant account ID of merchant to
      *associate with new external remember-me. 
      */
	public partial class ExternalRememberMeOwnerDetailsType	{

		/**
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ExternalRememberMeOwnerIDType != null)
			{
				sb.Append("<ebl:ExternalRememberMeOwnerIDType>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ExternalRememberMeOwnerIDType));
				sb.Append("</ebl:ExternalRememberMeOwnerIDType>");
			}
			if(ExternalRememberMeOwnerID != null)
			{
				sb.Append("<ebl:ExternalRememberMeOwnerID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ExternalRememberMeOwnerID));
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
	public partial class ExternalRememberMeOptInDetailsType	{

		/**
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ExternalRememberMeOptIn != null)
			{
				sb.Append("<ebl:ExternalRememberMeOptIn>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ExternalRememberMeOptIn));
				sb.Append("</ebl:ExternalRememberMeOptIn>");
			}
			if(ExternalRememberMeOwnerDetails != null)
			{
				sb.Append("<ebl:ExternalRememberMeOwnerDetails>");
				sb.Append(ExternalRememberMeOwnerDetails.ToXMLString());
				sb.Append("</ebl:ExternalRememberMeOwnerDetails>");
			}
			return sb.ToString();
		}

	}




	/**
      *An optional set of values related to flow-specific details. 
      */
	public partial class FlowControlDetailsType	{

		/**
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ErrorURL != null)
			{
				sb.Append("<ebl:ErrorURL>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ErrorURL));
				sb.Append("</ebl:ErrorURL>");
			}
			if(InContextReturnURL != null)
			{
				sb.Append("<ebl:InContextReturnURL>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(InContextReturnURL));
				sb.Append("</ebl:InContextReturnURL>");
			}
			return sb.ToString();
		}

	}




	/**
      *Response information resulting from opt-in operation or
      *current login bypass status. 
      */
	public partial class ExternalRememberMeStatusDetailsType	{

		/**
          *
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
          *
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


		public ExternalRememberMeStatusDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ExternalRememberMeStatus']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ExternalRememberMeStatus = System.Convert.ToInt32(ChildNode.InnerText);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ExternalRememberMeID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ExternalRememberMeID = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *Response information resulting from opt-in operation or
      *current login bypass status. 
      */
	public partial class RefreshTokenStatusDetailsType	{

		/**
          *
		  */
		private int? RefreshTokenStatusField;
		public int? RefreshTokenStatus
		{
			get
			{
				return this.RefreshTokenStatusField;
			}
			set
			{
				this.RefreshTokenStatusField = value;
			}
		}
		

		/**
          *
		  */
		private string RefreshTokenField;
		public string RefreshToken
		{
			get
			{
				return this.RefreshTokenField;
			}
			set
			{
				this.RefreshTokenField = value;
			}
		}
		

		/**
          *
		  */
		private string ImmutableIDField;
		public string ImmutableID
		{
			get
			{
				return this.ImmutableIDField;
			}
			set
			{
				this.ImmutableIDField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public RefreshTokenStatusDetailsType(){
		}


		public RefreshTokenStatusDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'RefreshTokenStatus']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.RefreshTokenStatus = System.Convert.ToInt32(ChildNode.InnerText);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'RefreshToken']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.RefreshToken = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ImmutableID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ImmutableID = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *Contains elements that allows customization of display (user
      *interface) elements. 
      */
	public partial class DisplayControlDetailsType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(InContextPaymentButtonImage != null)
			{
				sb.Append("<ebl:InContextPaymentButtonImage>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(InContextPaymentButtonImage));
				sb.Append("</ebl:InContextPaymentButtonImage>");
			}
			return sb.ToString();
		}

	}




	/**
      *Contains elements that allow tracking for an external
      *partner. 
      */
	public partial class ExternalPartnerTrackingDetailsType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ExternalPartnerSegmentID != null)
			{
				sb.Append("<ebl:ExternalPartnerSegmentID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ExternalPartnerSegmentID));
				sb.Append("</ebl:ExternalPartnerSegmentID>");
			}
			return sb.ToString();
		}

	}




	/**
      *Store IDOptional Character length and limits: 50 single-byte
      *characters 
      */
	public partial class MerchantStoreDetailsType	{

		/**
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(StoreID != null)
			{
				sb.Append("<ebl:StoreID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(StoreID));
				sb.Append("</ebl:StoreID>");
			}
			if(TerminalID != null)
			{
				sb.Append("<ebl:TerminalID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(TerminalID));
				sb.Append("</ebl:TerminalID>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class AdditionalFeeType	{

		/**
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Type != null)
			{
				sb.Append("<ebl:Type>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Type));
				sb.Append("</ebl:Type>");
			}
			if(Amount != null)
			{
				sb.Append("<ebl:Amount");
				sb.Append(Amount.ToXMLString());
				sb.Append("</ebl:Amount>");
			}
			return sb.ToString();
		}

		public AdditionalFeeType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Type']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Type = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Amount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Amount =  new BasicAmountType(ChildNode);
			}
	
		}
	}




	/**
      *Describes discount information 
      */
	public partial class DiscountType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Name != null)
			{
				sb.Append("<ebl:Name>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Name));
				sb.Append("</ebl:Name>");
			}
			if(Description != null)
			{
				sb.Append("<ebl:Description>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Description));
				sb.Append("</ebl:Description>");
			}
			if(Amount != null)
			{
				sb.Append("<ebl:Amount");
				sb.Append(Amount.ToXMLString());
				sb.Append("</ebl:Amount>");
			}
			if(RedeemedOfferType != null)
			{
				sb.Append("<ebl:RedeemedOfferType>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(RedeemedOfferType)));
				sb.Append("</ebl:RedeemedOfferType>");
			}
			if(RedeemedOfferID != null)
			{
				sb.Append("<ebl:RedeemedOfferID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(RedeemedOfferID));
				sb.Append("</ebl:RedeemedOfferID>");
			}
			return sb.ToString();
		}

		public DiscountType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Name']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Name = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Description']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Description = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Amount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Amount =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'RedeemedOfferType']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.RedeemedOfferType = (RedeemedOfferType)EnumUtils.GetValue(ChildNode.InnerText,typeof(RedeemedOfferType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'RedeemedOfferID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.RedeemedOfferID = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *Describes an individual item for an invoice. 
      */
	public partial class InvoiceItemType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(Name != null)
			{
				sb.Append("<ebl:Name>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Name));
				sb.Append("</ebl:Name>");
			}
			if(Description != null)
			{
				sb.Append("<ebl:Description>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Description));
				sb.Append("</ebl:Description>");
			}
			if(EAN != null)
			{
				sb.Append("<ebl:EAN>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EAN));
				sb.Append("</ebl:EAN>");
			}
			if(SKU != null)
			{
				sb.Append("<ebl:SKU>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(SKU));
				sb.Append("</ebl:SKU>");
			}
			if(ReturnPolicyIdentifier != null)
			{
				sb.Append("<ebl:ReturnPolicyIdentifier>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ReturnPolicyIdentifier));
				sb.Append("</ebl:ReturnPolicyIdentifier>");
			}
			if(Price != null)
			{
				sb.Append("<ebl:Price");
				sb.Append(Price.ToXMLString());
				sb.Append("</ebl:Price>");
			}
			if(ItemPrice != null)
			{
				sb.Append("<ebl:ItemPrice");
				sb.Append(ItemPrice.ToXMLString());
				sb.Append("</ebl:ItemPrice>");
			}
			if(ItemCount != null)
			{
				sb.Append("<ebl:ItemCount>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ItemCount));
				sb.Append("</ebl:ItemCount>");
			}
			if(ItemCountUnit != null)
			{
				sb.Append("<ebl:ItemCountUnit>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(ItemCountUnit)));
				sb.Append("</ebl:ItemCountUnit>");
			}
			if(Discount != null)
			{
				for(int i = 0; i < Discount.Count; i++)
				{
					sb.Append("<ebl:Discount>");
					sb.Append(Discount[i].ToXMLString());
					sb.Append("</ebl:Discount>");
				}
			}
			if(Taxable != null)
			{
				sb.Append("<ebl:Taxable>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Taxable));
				sb.Append("</ebl:Taxable>");
			}
			if(TaxRate != null)
			{
				sb.Append("<ebl:TaxRate>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(TaxRate));
				sb.Append("</ebl:TaxRate>");
			}
			if(AdditionalFees != null)
			{
				for(int i = 0; i < AdditionalFees.Count; i++)
				{
					sb.Append("<ebl:AdditionalFees>");
					sb.Append(AdditionalFees[i].ToXMLString());
					sb.Append("</ebl:AdditionalFees>");
				}
			}
			if(Reimbursable != null)
			{
				sb.Append("<ebl:Reimbursable>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Reimbursable));
				sb.Append("</ebl:Reimbursable>");
			}
			if(MPN != null)
			{
				sb.Append("<ebl:MPN>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(MPN));
				sb.Append("</ebl:MPN>");
			}
			if(ISBN != null)
			{
				sb.Append("<ebl:ISBN>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ISBN));
				sb.Append("</ebl:ISBN>");
			}
			if(PLU != null)
			{
				sb.Append("<ebl:PLU>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(PLU));
				sb.Append("</ebl:PLU>");
			}
			if(ModelNumber != null)
			{
				sb.Append("<ebl:ModelNumber>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ModelNumber));
				sb.Append("</ebl:ModelNumber>");
			}
			if(StyleNumber != null)
			{
				sb.Append("<ebl:StyleNumber>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(StyleNumber));
				sb.Append("</ebl:StyleNumber>");
			}
			return sb.ToString();
		}

		public InvoiceItemType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Name']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Name = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Description']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Description = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'EAN']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.EAN = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'SKU']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.SKU = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ReturnPolicyIdentifier']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ReturnPolicyIdentifier = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Price']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Price =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ItemPrice']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ItemPrice =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ItemCount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ItemCount = System.Convert.ToDecimal(ChildNode.InnerText);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ItemCountUnit']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ItemCountUnit = (UnitOfMeasure)EnumUtils.GetValue(ChildNode.InnerText,typeof(UnitOfMeasure));
			}
			ChildNodeList = xmlNode.SelectNodes("*[local-name() = 'Discount']");
			if (ChildNodeList != null && ChildNodeList.Count > 0)
			{
				for(int i = 0; i < ChildNodeList.Count; i++)
				{
					XmlNode subNode = ChildNodeList.Item(i);
					this.Discount.Add(new DiscountType(subNode));
				}
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Taxable']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Taxable = System.Convert.ToBoolean(ChildNode.InnerText);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'TaxRate']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.TaxRate = System.Convert.ToDecimal(ChildNode.InnerText);
			}
			ChildNodeList = xmlNode.SelectNodes("*[local-name() = 'AdditionalFees']");
			if (ChildNodeList != null && ChildNodeList.Count > 0)
			{
				for(int i = 0; i < ChildNodeList.Count; i++)
				{
					XmlNode subNode = ChildNodeList.Item(i);
					this.AdditionalFees.Add(new AdditionalFeeType(subNode));
				}
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Reimbursable']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Reimbursable = System.Convert.ToBoolean(ChildNode.InnerText);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'MPN']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.MPN = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ISBN']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ISBN = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PLU']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PLU = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ModelNumber']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ModelNumber = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'StyleNumber']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.StyleNumber = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *Holds refunds payment status information 
      */
	public partial class RefundInfoType	{

		/**
          *
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
          *
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


		public RefundInfoType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'RefundStatus']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.RefundStatus = (PaymentStatusCodeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(PaymentStatusCodeType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PendingReason']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PendingReason = (PendingStatusCodeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(PendingStatusCodeType));
			}
	
		}
	}




	/**
      *Defines relationship between buckets 
      */
	public partial class CoupledBucketsType	{

		/**
          *
		  */
		private CoupleType? CoupleTypeField;
		public CoupleType? CoupleType
		{
			get
			{
				return this.CoupleTypeField;
			}
			set
			{
				this.CoupleTypeField = value;
			}
		}
		

		/**
          *
		  */
		private string CoupledPaymentRequestIDField;
		public string CoupledPaymentRequestID
		{
			get
			{
				return this.CoupledPaymentRequestIDField;
			}
			set
			{
				this.CoupledPaymentRequestIDField = value;
			}
		}
		

		/**
          *
		  */
		private List<string> PaymentRequestIDField = new List<string>();
		public List<string> PaymentRequestID
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
	 	  * Constructor with arguments
	 	  */
	 	public CoupledBucketsType(List<string> PaymentRequestID){
			this.PaymentRequestID = PaymentRequestID;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public CoupledBucketsType(){
		}


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(CoupleType != null)
			{
				sb.Append("<ebl:CoupleType>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(CoupleType)));
				sb.Append("</ebl:CoupleType>");
			}
			if(CoupledPaymentRequestID != null)
			{
				sb.Append("<ebl:CoupledPaymentRequestID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(CoupledPaymentRequestID));
				sb.Append("</ebl:CoupledPaymentRequestID>");
			}
			if(PaymentRequestID != null)
			{
				for(int i = 0; i < PaymentRequestID.Count; i++)
				{
					sb.Append("<ebl:PaymentRequestID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(PaymentRequestID[i]));
					sb.Append("</ebl:PaymentRequestID>");
				}
			}
			return sb.ToString();
		}

	}




	/**
      *Information about Coupled Payment transactions. 
      */
	public partial class CoupledPaymentInfoType	{

		/**
          *
		  */
		private string CoupledPaymentRequestIDField;
		public string CoupledPaymentRequestID
		{
			get
			{
				return this.CoupledPaymentRequestIDField;
			}
			set
			{
				this.CoupledPaymentRequestIDField = value;
			}
		}
		

		/**
          *
		  */
		private string CoupledPaymentIDField;
		public string CoupledPaymentID
		{
			get
			{
				return this.CoupledPaymentIDField;
			}
			set
			{
				this.CoupledPaymentIDField = value;
			}
		}
		

		/**
	 	  * Default Constructor
	 	  */
	 	public CoupledPaymentInfoType(){
		}


		public CoupledPaymentInfoType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'CoupledPaymentRequestID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.CoupledPaymentRequestID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'CoupledPaymentID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.CoupledPaymentID = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *
      */
	public partial class EnhancedCheckoutDataType	{

		/**
	 	  * Default Constructor
	 	  */
	 	public EnhancedCheckoutDataType(){
		}


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class EnhancedPaymentDataType	{

		/**
	 	  * Default Constructor
	 	  */
	 	public EnhancedPaymentDataType(){
		}


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			return sb.ToString();
		}

		public EnhancedPaymentDataType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
	
		}
	}




	/**
      *
      */
	public partial class EnhancedItemDataType	{

		/**
	 	  * Default Constructor
	 	  */
	 	public EnhancedItemDataType(){
		}


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			return sb.ToString();
		}

		public EnhancedItemDataType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
	
		}
	}




	/**
      *
      */
	public partial class EnhancedPaymentInfoType	{

		/**
	 	  * Default Constructor
	 	  */
	 	public EnhancedPaymentInfoType(){
		}


		public EnhancedPaymentInfoType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
	
		}
	}




	/**
      *
      */
	public partial class EnhancedInitiateRecoupRequestDetailsType	{

		/**
	 	  * Default Constructor
	 	  */
	 	public EnhancedInitiateRecoupRequestDetailsType(){
		}


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class EnhancedCompleteRecoupRequestDetailsType	{

		/**
	 	  * Default Constructor
	 	  */
	 	public EnhancedCompleteRecoupRequestDetailsType(){
		}


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class EnhancedCompleteRecoupResponseDetailsType	{

		/**
	 	  * Default Constructor
	 	  */
	 	public EnhancedCompleteRecoupResponseDetailsType(){
		}


		public EnhancedCompleteRecoupResponseDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
	
		}
	}




	/**
      *
      */
	public partial class EnhancedCancelRecoupRequestDetailsType	{

		/**
	 	  * Default Constructor
	 	  */
	 	public EnhancedCancelRecoupRequestDetailsType(){
		}


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class EnhancedPayerInfoType	{

		/**
	 	  * Default Constructor
	 	  */
	 	public EnhancedPayerInfoType(){
		}


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			return sb.ToString();
		}

		public EnhancedPayerInfoType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
	
		}
	}




	/**
      *Installment Period. Optional 
      */
	public partial class InstallmentDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(BillingPeriod != null)
			{
				sb.Append("<urn:BillingPeriod>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(BillingPeriod)));
				sb.Append("</urn:BillingPeriod>");
			}
			if(BillingFrequency != null)
			{
				sb.Append("<urn:BillingFrequency>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(BillingFrequency));
				sb.Append("</urn:BillingFrequency>");
			}
			if(TotalBillingCycles != null)
			{
				sb.Append("<urn:TotalBillingCycles>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(TotalBillingCycles));
				sb.Append("</urn:TotalBillingCycles>");
			}
			if(Amount != null)
			{
				sb.Append("<urn:Amount>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Amount));
				sb.Append("</urn:Amount>");
			}
			if(ShippingAmount != null)
			{
				sb.Append("<urn:ShippingAmount>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ShippingAmount));
				sb.Append("</urn:ShippingAmount>");
			}
			if(TaxAmount != null)
			{
				sb.Append("<urn:TaxAmount>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(TaxAmount));
				sb.Append("</urn:TaxAmount>");
			}
			return sb.ToString();
		}

		public InstallmentDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'BillingPeriod']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.BillingPeriod = (BillingPeriodType)EnumUtils.GetValue(ChildNode.InnerText,typeof(BillingPeriodType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'BillingFrequency']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.BillingFrequency = System.Convert.ToInt32(ChildNode.InnerText);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'TotalBillingCycles']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.TotalBillingCycles = System.Convert.ToInt32(ChildNode.InnerText);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Amount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Amount = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ShippingAmount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ShippingAmount = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'TaxAmount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.TaxAmount = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *Option Selection. Required Character length and limitations:
      *12 single-byte alphanumeric characters 
      */
	public partial class OptionSelectionDetailsType	{

		/**
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(OptionSelection != null)
			{
				sb.Append("<urn:OptionSelection>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(OptionSelection));
				sb.Append("</urn:OptionSelection>");
			}
			if(Price != null)
			{
				sb.Append("<urn:Price>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Price));
				sb.Append("</urn:Price>");
			}
			if(OptionType != null)
			{
				sb.Append("<urn:OptionType>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(OptionType)));
				sb.Append("</urn:OptionType>");
			}
			if(PaymentPeriod != null)
			{
				for(int i = 0; i < PaymentPeriod.Count; i++)
				{
					sb.Append("<urn:PaymentPeriod>");
					sb.Append(PaymentPeriod[i].ToXMLString());
					sb.Append("</urn:PaymentPeriod>");
				}
			}
			return sb.ToString();
		}

		public OptionSelectionDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'OptionSelection']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.OptionSelection = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Price']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Price = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'OptionType']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.OptionType = (OptionTypeListType)EnumUtils.GetValue(ChildNode.InnerText,typeof(OptionTypeListType));
			}
			ChildNodeList = xmlNode.SelectNodes("*[local-name() = 'PaymentPeriod']");
			if (ChildNodeList != null && ChildNodeList.Count > 0)
			{
				for(int i = 0; i < ChildNodeList.Count; i++)
				{
					XmlNode subNode = ChildNodeList.Item(i);
					this.PaymentPeriod.Add(new InstallmentDetailsType(subNode));
				}
			}
	
		}
	}




	/**
      *Option Name. Optional 
      */
	public partial class OptionDetailsType	{

		/**
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(OptionName != null)
			{
				sb.Append("<urn:OptionName>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(OptionName));
				sb.Append("</urn:OptionName>");
			}
			if(OptionSelectionDetails != null)
			{
				for(int i = 0; i < OptionSelectionDetails.Count; i++)
				{
					sb.Append("<urn:OptionSelectionDetails>");
					sb.Append(OptionSelectionDetails[i].ToXMLString());
					sb.Append("</urn:OptionSelectionDetails>");
				}
			}
			return sb.ToString();
		}

		public OptionDetailsType(XmlNode xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'OptionName']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.OptionName = ChildNode.InnerText;
			}
			ChildNodeList = xmlNode.SelectNodes("*[local-name() = 'OptionSelectionDetails']");
			if (ChildNodeList != null && ChildNodeList.Count > 0)
			{
				for(int i = 0; i < ChildNodeList.Count; i++)
				{
					XmlNode subNode = ChildNodeList.Item(i);
					this.OptionSelectionDetails.Add(new OptionSelectionDetailsType(subNode));
				}
			}
	
		}
	}




	/**
      *
      */
	public partial class BMCreateButtonReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:BMCreateButtonReq>");
			if(BMCreateButtonRequest != null)
			{
				sb.Append("<urn:BMCreateButtonRequest>");
				sb.Append(BMCreateButtonRequest.ToXMLString());
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
	public partial class BMCreateButtonRequestType : AbstractRequestType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(ButtonType != null)
			{
				sb.Append("<urn:ButtonType>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(ButtonType)));
				sb.Append("</urn:ButtonType>");
			}
			if(ButtonCode != null)
			{
				sb.Append("<urn:ButtonCode>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(ButtonCode)));
				sb.Append("</urn:ButtonCode>");
			}
			if(ButtonSubType != null)
			{
				sb.Append("<urn:ButtonSubType>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(ButtonSubType)));
				sb.Append("</urn:ButtonSubType>");
			}
			if(ButtonVar != null)
			{
				for(int i = 0; i < ButtonVar.Count; i++)
				{
					sb.Append("<urn:ButtonVar>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ButtonVar[i]));
					sb.Append("</urn:ButtonVar>");
				}
			}
			if(OptionDetails != null)
			{
				for(int i = 0; i < OptionDetails.Count; i++)
				{
					sb.Append("<urn:OptionDetails>");
					sb.Append(OptionDetails[i].ToXMLString());
					sb.Append("</urn:OptionDetails>");
				}
			}
			if(TextBox != null)
			{
				for(int i = 0; i < TextBox.Count; i++)
				{
					sb.Append("<urn:TextBox>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(TextBox[i]));
					sb.Append("</urn:TextBox>");
				}
			}
			if(ButtonImage != null)
			{
				sb.Append("<urn:ButtonImage>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(ButtonImage)));
				sb.Append("</urn:ButtonImage>");
			}
			if(ButtonImageURL != null)
			{
				sb.Append("<urn:ButtonImageURL>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ButtonImageURL));
				sb.Append("</urn:ButtonImageURL>");
			}
			if(BuyNowText != null)
			{
				sb.Append("<urn:BuyNowText>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(BuyNowText)));
				sb.Append("</urn:BuyNowText>");
			}
			if(SubscribeText != null)
			{
				sb.Append("<urn:SubscribeText>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(SubscribeText)));
				sb.Append("</urn:SubscribeText>");
			}
			if(ButtonCountry != null)
			{
				sb.Append("<urn:ButtonCountry>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(ButtonCountry)));
				sb.Append("</urn:ButtonCountry>");
			}
			if(ButtonLanguage != null)
			{
				sb.Append("<urn:ButtonLanguage>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ButtonLanguage));
				sb.Append("</urn:ButtonLanguage>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class BMCreateButtonResponseType : AbstractResponseType	{

		/**
          *
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
          *
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
          *
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
          *
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


		public BMCreateButtonResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Website']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Website = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Email']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Email = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Mobile']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Mobile = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'HostedButtonID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.HostedButtonID = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *
      */
	public partial class BMUpdateButtonReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:BMUpdateButtonReq>");
			if(BMUpdateButtonRequest != null)
			{
				sb.Append("<urn:BMUpdateButtonRequest>");
				sb.Append(BMUpdateButtonRequest.ToXMLString());
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
	public partial class BMUpdateButtonRequestType : AbstractRequestType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(HostedButtonID != null)
			{
				sb.Append("<urn:HostedButtonID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(HostedButtonID));
				sb.Append("</urn:HostedButtonID>");
			}
			if(ButtonType != null)
			{
				sb.Append("<urn:ButtonType>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(ButtonType)));
				sb.Append("</urn:ButtonType>");
			}
			if(ButtonCode != null)
			{
				sb.Append("<urn:ButtonCode>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(ButtonCode)));
				sb.Append("</urn:ButtonCode>");
			}
			if(ButtonSubType != null)
			{
				sb.Append("<urn:ButtonSubType>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(ButtonSubType)));
				sb.Append("</urn:ButtonSubType>");
			}
			if(ButtonVar != null)
			{
				for(int i = 0; i < ButtonVar.Count; i++)
				{
					sb.Append("<urn:ButtonVar>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ButtonVar[i]));
					sb.Append("</urn:ButtonVar>");
				}
			}
			if(OptionDetails != null)
			{
				for(int i = 0; i < OptionDetails.Count; i++)
				{
					sb.Append("<urn:OptionDetails>");
					sb.Append(OptionDetails[i].ToXMLString());
					sb.Append("</urn:OptionDetails>");
				}
			}
			if(TextBox != null)
			{
				for(int i = 0; i < TextBox.Count; i++)
				{
					sb.Append("<urn:TextBox>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(TextBox[i]));
					sb.Append("</urn:TextBox>");
				}
			}
			if(ButtonImage != null)
			{
				sb.Append("<urn:ButtonImage>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(ButtonImage)));
				sb.Append("</urn:ButtonImage>");
			}
			if(ButtonImageURL != null)
			{
				sb.Append("<urn:ButtonImageURL>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ButtonImageURL));
				sb.Append("</urn:ButtonImageURL>");
			}
			if(BuyNowText != null)
			{
				sb.Append("<urn:BuyNowText>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(BuyNowText)));
				sb.Append("</urn:BuyNowText>");
			}
			if(SubscribeText != null)
			{
				sb.Append("<urn:SubscribeText>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(SubscribeText)));
				sb.Append("</urn:SubscribeText>");
			}
			if(ButtonCountry != null)
			{
				sb.Append("<urn:ButtonCountry>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(ButtonCountry)));
				sb.Append("</urn:ButtonCountry>");
			}
			if(ButtonLanguage != null)
			{
				sb.Append("<urn:ButtonLanguage>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ButtonLanguage));
				sb.Append("</urn:ButtonLanguage>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class BMUpdateButtonResponseType : AbstractResponseType	{

		/**
          *
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
          *
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
          *
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
          *
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


		public BMUpdateButtonResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Website']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Website = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Email']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Email = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Mobile']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Mobile = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'HostedButtonID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.HostedButtonID = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *
      */
	public partial class BMManageButtonStatusReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:BMManageButtonStatusReq>");
			if(BMManageButtonStatusRequest != null)
			{
				sb.Append("<urn:BMManageButtonStatusRequest>");
				sb.Append(BMManageButtonStatusRequest.ToXMLString());
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
	public partial class BMManageButtonStatusRequestType : AbstractRequestType	{

		/**
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(HostedButtonID != null)
			{
				sb.Append("<urn:HostedButtonID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(HostedButtonID));
				sb.Append("</urn:HostedButtonID>");
			}
			if(ButtonStatus != null)
			{
				sb.Append("<urn:ButtonStatus>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(ButtonStatus)));
				sb.Append("</urn:ButtonStatus>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class BMManageButtonStatusResponseType : AbstractResponseType	{

		/**
	 	  * Default Constructor
	 	  */
	 	public BMManageButtonStatusResponseType(){
		}


		public BMManageButtonStatusResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
	
		}
	}




	/**
      *
      */
	public partial class BMGetButtonDetailsReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:BMGetButtonDetailsReq>");
			if(BMGetButtonDetailsRequest != null)
			{
				sb.Append("<urn:BMGetButtonDetailsRequest>");
				sb.Append(BMGetButtonDetailsRequest.ToXMLString());
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
	public partial class BMGetButtonDetailsRequestType : AbstractRequestType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(HostedButtonID != null)
			{
				sb.Append("<urn:HostedButtonID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(HostedButtonID));
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
	public partial class BMGetButtonDetailsResponseType : AbstractResponseType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public BMGetButtonDetailsResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Website']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Website = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Email']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Email = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Mobile']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Mobile = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'HostedButtonID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.HostedButtonID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ButtonType']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ButtonType = (ButtonTypeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(ButtonTypeType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ButtonCode']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ButtonCode = (ButtonCodeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(ButtonCodeType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ButtonSubType']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ButtonSubType = (ButtonSubTypeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(ButtonSubTypeType));
			}
			ChildNodeList = xmlNode.SelectNodes("*[local-name() = 'ButtonVar']");
			if (ChildNodeList != null && ChildNodeList.Count > 0)
			{
				for(int i = 0; i < ChildNodeList.Count; i++)
				{
					string value = ChildNodeList[i].InnerText;
					this.ButtonVar.Add(value);
				}
			}
			ChildNodeList = xmlNode.SelectNodes("*[local-name() = 'OptionDetails']");
			if (ChildNodeList != null && ChildNodeList.Count > 0)
			{
				for(int i = 0; i < ChildNodeList.Count; i++)
				{
					XmlNode subNode = ChildNodeList.Item(i);
					this.OptionDetails.Add(new OptionDetailsType(subNode));
				}
			}
			ChildNodeList = xmlNode.SelectNodes("*[local-name() = 'TextBox']");
			if (ChildNodeList != null && ChildNodeList.Count > 0)
			{
				for(int i = 0; i < ChildNodeList.Count; i++)
				{
					string value = ChildNodeList[i].InnerText;
					this.TextBox.Add(value);
				}
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ButtonImage']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ButtonImage = (ButtonImageType)EnumUtils.GetValue(ChildNode.InnerText,typeof(ButtonImageType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ButtonImageURL']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ButtonImageURL = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'BuyNowText']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.BuyNowText = (BuyNowTextType)EnumUtils.GetValue(ChildNode.InnerText,typeof(BuyNowTextType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'SubscribeText']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.SubscribeText = (SubscribeTextType)EnumUtils.GetValue(ChildNode.InnerText,typeof(SubscribeTextType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ButtonCountry']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ButtonCountry = (CountryCodeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(CountryCodeType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ButtonLanguage']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ButtonLanguage = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *
      */
	public partial class BMSetInventoryReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:BMSetInventoryReq>");
			if(BMSetInventoryRequest != null)
			{
				sb.Append("<urn:BMSetInventoryRequest>");
				sb.Append(BMSetInventoryRequest.ToXMLString());
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
	public partial class BMSetInventoryRequestType : AbstractRequestType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(HostedButtonID != null)
			{
				sb.Append("<urn:HostedButtonID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(HostedButtonID));
				sb.Append("</urn:HostedButtonID>");
			}
			if(TrackInv != null)
			{
				sb.Append("<urn:TrackInv>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(TrackInv));
				sb.Append("</urn:TrackInv>");
			}
			if(TrackPnl != null)
			{
				sb.Append("<urn:TrackPnl>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(TrackPnl));
				sb.Append("</urn:TrackPnl>");
			}
			if(ItemTrackingDetails != null)
			{
				sb.Append("<ebl:ItemTrackingDetails>");
				sb.Append(ItemTrackingDetails.ToXMLString());
				sb.Append("</ebl:ItemTrackingDetails>");
			}
			if(OptionIndex != null)
			{
				sb.Append("<urn:OptionIndex>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(OptionIndex));
				sb.Append("</urn:OptionIndex>");
			}
			if(OptionTrackingDetails != null)
			{
				for(int i = 0; i < OptionTrackingDetails.Count; i++)
				{
					sb.Append("<ebl:OptionTrackingDetails>");
					sb.Append(OptionTrackingDetails[i].ToXMLString());
					sb.Append("</ebl:OptionTrackingDetails>");
				}
			}
			if(SoldoutURL != null)
			{
				sb.Append("<urn:SoldoutURL>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(SoldoutURL));
				sb.Append("</urn:SoldoutURL>");
			}
			if(ReuseDigitalDownloadKeys != null)
			{
				sb.Append("<urn:ReuseDigitalDownloadKeys>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ReuseDigitalDownloadKeys));
				sb.Append("</urn:ReuseDigitalDownloadKeys>");
			}
			if(AppendDigitalDownloadKeys != null)
			{
				sb.Append("<urn:AppendDigitalDownloadKeys>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(AppendDigitalDownloadKeys));
				sb.Append("</urn:AppendDigitalDownloadKeys>");
			}
			if(DigitalDownloadKeys != null)
			{
				for(int i = 0; i < DigitalDownloadKeys.Count; i++)
				{
					sb.Append("<urn:DigitalDownloadKeys>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(DigitalDownloadKeys[i]));
					sb.Append("</urn:DigitalDownloadKeys>");
				}
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class BMSetInventoryResponseType : AbstractResponseType	{

		/**
	 	  * Default Constructor
	 	  */
	 	public BMSetInventoryResponseType(){
		}


		public BMSetInventoryResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
	
		}
	}




	/**
      *
      */
	public partial class BMGetInventoryReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:BMGetInventoryReq>");
			if(BMGetInventoryRequest != null)
			{
				sb.Append("<urn:BMGetInventoryRequest>");
				sb.Append(BMGetInventoryRequest.ToXMLString());
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
	public partial class BMGetInventoryRequestType : AbstractRequestType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(HostedButtonID != null)
			{
				sb.Append("<urn:HostedButtonID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(HostedButtonID));
				sb.Append("</urn:HostedButtonID>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class BMGetInventoryResponseType : AbstractResponseType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public BMGetInventoryResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'HostedButtonID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.HostedButtonID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'TrackInv']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.TrackInv = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'TrackPnl']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.TrackPnl = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ItemTrackingDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ItemTrackingDetails =  new ItemTrackingDetailsType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'OptionIndex']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.OptionIndex = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'OptionName']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.OptionName = ChildNode.InnerText;
			}
			ChildNodeList = xmlNode.SelectNodes("*[local-name() = 'OptionTrackingDetails']");
			if (ChildNodeList != null && ChildNodeList.Count > 0)
			{
				for(int i = 0; i < ChildNodeList.Count; i++)
				{
					XmlNode subNode = ChildNodeList.Item(i);
					this.OptionTrackingDetails.Add(new OptionTrackingDetailsType(subNode));
				}
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'SoldoutURL']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.SoldoutURL = ChildNode.InnerText;
			}
			ChildNodeList = xmlNode.SelectNodes("*[local-name() = 'DigitalDownloadKeys']");
			if (ChildNodeList != null && ChildNodeList.Count > 0)
			{
				for(int i = 0; i < ChildNodeList.Count; i++)
				{
					string value = ChildNodeList[i].InnerText;
					this.DigitalDownloadKeys.Add(value);
				}
			}
	
		}
	}




	/**
      *
      */
	public partial class BMButtonSearchReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:BMButtonSearchReq>");
			if(BMButtonSearchRequest != null)
			{
				sb.Append("<urn:BMButtonSearchRequest>");
				sb.Append(BMButtonSearchRequest.ToXMLString());
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
	public partial class BMButtonSearchRequestType : AbstractRequestType	{

		/**
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(StartDate != null)
			{
				sb.Append("<urn:StartDate>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(StartDate));
				sb.Append("</urn:StartDate>");
			}
			if(EndDate != null)
			{
				sb.Append("<urn:EndDate>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EndDate));
				sb.Append("</urn:EndDate>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class BMButtonSearchResponseType : AbstractResponseType	{

		/**
          *
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


		public BMButtonSearchResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNodeList = xmlNode.SelectNodes("*[local-name() = 'ButtonSearchResult']");
			if (ChildNodeList != null && ChildNodeList.Count > 0)
			{
				for(int i = 0; i < ChildNodeList.Count; i++)
				{
					XmlNode subNode = ChildNodeList.Item(i);
					this.ButtonSearchResult.Add(new ButtonSearchResultType(subNode));
				}
			}
	
		}
	}




	/**
      *
      */
	public partial class RefundTransactionReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:RefundTransactionReq>");
			if(RefundTransactionRequest != null)
			{
				sb.Append("<urn:RefundTransactionRequest>");
				sb.Append(RefundTransactionRequest.ToXMLString());
				sb.Append("</urn:RefundTransactionRequest>");
			}
			sb.Append("</urn:RefundTransactionReq>");
			return sb.ToString();
		}

	}




	/**
      *Unique identifier of the transaction you are refunding.
      *Optional Character length and limitations: 17 single-byte
      *alphanumeric characters 
      */
	public partial class RefundTransactionRequestType : AbstractRequestType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(TransactionID != null)
			{
				sb.Append("<urn:TransactionID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(TransactionID));
				sb.Append("</urn:TransactionID>");
			}
			if(PayerID != null)
			{
				sb.Append("<urn:PayerID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(PayerID));
				sb.Append("</urn:PayerID>");
			}
			if(InvoiceID != null)
			{
				sb.Append("<urn:InvoiceID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(InvoiceID));
				sb.Append("</urn:InvoiceID>");
			}
			if(RefundType != null)
			{
				sb.Append("<urn:RefundType>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(RefundType)));
				sb.Append("</urn:RefundType>");
			}
			if(Amount != null)
			{
				sb.Append("<urn:Amount");
				sb.Append(Amount.ToXMLString());
				sb.Append("</urn:Amount>");
			}
			if(Memo != null)
			{
				sb.Append("<urn:Memo>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Memo));
				sb.Append("</urn:Memo>");
			}
			if(RetryUntil != null)
			{
				sb.Append("<urn:RetryUntil>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(RetryUntil));
				sb.Append("</urn:RetryUntil>");
			}
			if(RefundSource != null)
			{
				sb.Append("<urn:RefundSource>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(RefundSource)));
				sb.Append("</urn:RefundSource>");
			}
			if(RefundAdvice != null)
			{
				sb.Append("<urn:RefundAdvice>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(RefundAdvice));
				sb.Append("</urn:RefundAdvice>");
			}
			if(MerchantStoreDetails != null)
			{
				sb.Append("<ebl:MerchantStoreDetails>");
				sb.Append(MerchantStoreDetails.ToXMLString());
				sb.Append("</ebl:MerchantStoreDetails>");
			}
			if(RefundItemDetails != null)
			{
				for(int i = 0; i < RefundItemDetails.Count; i++)
				{
					sb.Append("<ebl:RefundItemDetails>");
					sb.Append(RefundItemDetails[i].ToXMLString());
					sb.Append("</ebl:RefundItemDetails>");
				}
			}
			if(MsgSubID != null)
			{
				sb.Append("<urn:MsgSubID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(MsgSubID));
				sb.Append("</urn:MsgSubID>");
			}
			return sb.ToString();
		}

	}




	/**
      *Unique transaction ID of the refund. Character length and
      *limitations:17 single-byte characters 
      */
	public partial class RefundTransactionResponseType : AbstractResponseType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public RefundTransactionResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'RefundTransactionID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.RefundTransactionID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'NetRefundAmount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.NetRefundAmount =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'FeeRefundAmount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.FeeRefundAmount =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'GrossRefundAmount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.GrossRefundAmount =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'TotalRefundedAmount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.TotalRefundedAmount =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'RefundInfo']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.RefundInfo =  new RefundInfoType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ReceiptData']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ReceiptData = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'MsgSubID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.MsgSubID = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *
      */
	public partial class InitiateRecoupReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:InitiateRecoupReq>");
			if(InitiateRecoupRequest != null)
			{
				sb.Append("<urn:InitiateRecoupRequest>");
				sb.Append(InitiateRecoupRequest.ToXMLString());
				sb.Append("</urn:InitiateRecoupRequest>");
			}
			sb.Append("</urn:InitiateRecoupReq>");
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class InitiateRecoupRequestType : AbstractRequestType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(EnhancedInitiateRecoupRequestDetails != null)
			{
				sb.Append("<ed:EnhancedInitiateRecoupRequestDetails>");
				sb.Append(EnhancedInitiateRecoupRequestDetails.ToXMLString());
				sb.Append("</ed:EnhancedInitiateRecoupRequestDetails>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class InitiateRecoupResponseType : AbstractResponseType	{

		/**
	 	  * Default Constructor
	 	  */
	 	public InitiateRecoupResponseType(){
		}


		public InitiateRecoupResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
	
		}
	}




	/**
      *
      */
	public partial class CompleteRecoupReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:CompleteRecoupReq>");
			if(CompleteRecoupRequest != null)
			{
				sb.Append("<urn:CompleteRecoupRequest>");
				sb.Append(CompleteRecoupRequest.ToXMLString());
				sb.Append("</urn:CompleteRecoupRequest>");
			}
			sb.Append("</urn:CompleteRecoupReq>");
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class CompleteRecoupRequestType : AbstractRequestType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(EnhancedCompleteRecoupRequestDetails != null)
			{
				sb.Append("<ed:EnhancedCompleteRecoupRequestDetails>");
				sb.Append(EnhancedCompleteRecoupRequestDetails.ToXMLString());
				sb.Append("</ed:EnhancedCompleteRecoupRequestDetails>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class CompleteRecoupResponseType : AbstractResponseType	{

		/**
          *
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


		public CompleteRecoupResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'EnhancedCompleteRecoupResponseDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.EnhancedCompleteRecoupResponseDetails =  new EnhancedCompleteRecoupResponseDetailsType(ChildNode);
			}
	
		}
	}




	/**
      *
      */
	public partial class CancelRecoupReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:CancelRecoupReq>");
			if(CancelRecoupRequest != null)
			{
				sb.Append("<urn:CancelRecoupRequest>");
				sb.Append(CancelRecoupRequest.ToXMLString());
				sb.Append("</urn:CancelRecoupRequest>");
			}
			sb.Append("</urn:CancelRecoupReq>");
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class CancelRecoupRequestType : AbstractRequestType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(EnhancedCancelRecoupRequestDetails != null)
			{
				sb.Append("<ed:EnhancedCancelRecoupRequestDetails>");
				sb.Append(EnhancedCancelRecoupRequestDetails.ToXMLString());
				sb.Append("</ed:EnhancedCancelRecoupRequestDetails>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class CancelRecoupResponseType : AbstractResponseType	{

		/**
	 	  * Default Constructor
	 	  */
	 	public CancelRecoupResponseType(){
		}


		public CancelRecoupResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
	
		}
	}




	/**
      *
      */
	public partial class GetTransactionDetailsReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:GetTransactionDetailsReq>");
			if(GetTransactionDetailsRequest != null)
			{
				sb.Append("<urn:GetTransactionDetailsRequest>");
				sb.Append(GetTransactionDetailsRequest.ToXMLString());
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
	public partial class GetTransactionDetailsRequestType : AbstractRequestType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(TransactionID != null)
			{
				sb.Append("<urn:TransactionID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(TransactionID));
				sb.Append("</urn:TransactionID>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class GetTransactionDetailsResponseType : AbstractResponseType	{

		/**
          *
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
          *
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


		public GetTransactionDetailsResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PaymentTransactionDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PaymentTransactionDetails =  new PaymentTransactionType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ThreeDSecureDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ThreeDSecureDetails =  new ThreeDSecureInfoType(ChildNode);
			}
	
		}
	}




	/**
      *
      */
	public partial class BillUserReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:BillUserReq>");
			if(BillUserRequest != null)
			{
				sb.Append("<urn:BillUserRequest>");
				sb.Append(BillUserRequest.ToXMLString());
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
	public partial class BillUserRequestType : AbstractRequestType	{

		/**
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(MerchantPullPaymentDetails != null)
			{
				sb.Append("<ebl:MerchantPullPaymentDetails>");
				sb.Append(MerchantPullPaymentDetails.ToXMLString());
				sb.Append("</ebl:MerchantPullPaymentDetails>");
			}
			if(ReturnFMFDetails != null)
			{
				sb.Append("<urn:ReturnFMFDetails>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ReturnFMFDetails));
				sb.Append("</urn:ReturnFMFDetails>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class BillUserResponseType : AbstractResponseType	{

		/**
          *
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
          *
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


		public BillUserResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'BillUserResponseDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.BillUserResponseDetails =  new MerchantPullPaymentResponseType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'FMFDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.FMFDetails =  new FMFDetailsType(ChildNode);
			}
	
		}
	}




	/**
      *
      */
	public partial class TransactionSearchReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:TransactionSearchReq>");
			if(TransactionSearchRequest != null)
			{
				sb.Append("<urn:TransactionSearchRequest>");
				sb.Append(TransactionSearchRequest.ToXMLString());
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
	public partial class TransactionSearchRequestType : AbstractRequestType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(StartDate != null)
			{
				sb.Append("<urn:StartDate>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(StartDate));
				sb.Append("</urn:StartDate>");
			}
			if(EndDate != null)
			{
				sb.Append("<urn:EndDate>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EndDate));
				sb.Append("</urn:EndDate>");
			}
			if(Payer != null)
			{
				sb.Append("<urn:Payer>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Payer));
				sb.Append("</urn:Payer>");
			}
			if(Receiver != null)
			{
				sb.Append("<urn:Receiver>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Receiver));
				sb.Append("</urn:Receiver>");
			}
			if(ReceiptID != null)
			{
				sb.Append("<urn:ReceiptID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ReceiptID));
				sb.Append("</urn:ReceiptID>");
			}
			if(TransactionID != null)
			{
				sb.Append("<urn:TransactionID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(TransactionID));
				sb.Append("</urn:TransactionID>");
			}
			if(ProfileID != null)
			{
				sb.Append("<urn:ProfileID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ProfileID));
				sb.Append("</urn:ProfileID>");
			}
			if(PayerName != null)
			{
				sb.Append("<urn:PayerName>");
				sb.Append(PayerName.ToXMLString());
				sb.Append("</urn:PayerName>");
			}
			if(AuctionItemNumber != null)
			{
				sb.Append("<urn:AuctionItemNumber>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(AuctionItemNumber));
				sb.Append("</urn:AuctionItemNumber>");
			}
			if(InvoiceID != null)
			{
				sb.Append("<urn:InvoiceID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(InvoiceID));
				sb.Append("</urn:InvoiceID>");
			}
			if(CardNumber != null)
			{
				sb.Append("<urn:CardNumber>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(CardNumber));
				sb.Append("</urn:CardNumber>");
			}
			if(TransactionClass != null)
			{
				sb.Append("<urn:TransactionClass>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(TransactionClass)));
				sb.Append("</urn:TransactionClass>");
			}
			if(Amount != null)
			{
				sb.Append("<urn:Amount");
				sb.Append(Amount.ToXMLString());
				sb.Append("</urn:Amount>");
			}
			if(CurrencyCode != null)
			{
				sb.Append("<urn:CurrencyCode>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(CurrencyCode)));
				sb.Append("</urn:CurrencyCode>");
			}
			if(Status != null)
			{
				sb.Append("<urn:Status>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(Status)));
				sb.Append("</urn:Status>");
			}
			return sb.ToString();
		}

	}




	/**
      *Results of a Transaction Search.
      */
	public partial class TransactionSearchResponseType : AbstractResponseType	{

		/**
          *
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


		public TransactionSearchResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNodeList = xmlNode.SelectNodes("*[local-name() = 'PaymentTransactions']");
			if (ChildNodeList != null && ChildNodeList.Count > 0)
			{
				for(int i = 0; i < ChildNodeList.Count; i++)
				{
					XmlNode subNode = ChildNodeList.Item(i);
					this.PaymentTransactions.Add(new PaymentTransactionSearchResultType(subNode));
				}
			}
	
		}
	}




	/**
      *
      */
	public partial class MassPayReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:MassPayReq>");
			if(MassPayRequest != null)
			{
				sb.Append("<urn:MassPayRequest>");
				sb.Append(MassPayRequest.ToXMLString());
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
	public partial class MassPayRequestType : AbstractRequestType	{

		/**
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(EmailSubject != null)
			{
				sb.Append("<urn:EmailSubject>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EmailSubject));
				sb.Append("</urn:EmailSubject>");
			}
			if(ReceiverType != null)
			{
				sb.Append("<urn:ReceiverType>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(ReceiverType)));
				sb.Append("</urn:ReceiverType>");
			}
			if(ButtonSource != null)
			{
				sb.Append("<urn:ButtonSource>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ButtonSource));
				sb.Append("</urn:ButtonSource>");
			}
			if(MassPayItem != null)
			{
				for(int i = 0; i < MassPayItem.Count; i++)
				{
					sb.Append("<urn:MassPayItem>");
					sb.Append(MassPayItem[i].ToXMLString());
					sb.Append("</urn:MassPayItem>");
				}
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class MassPayResponseType : AbstractResponseType	{

		/**
	 	  * Default Constructor
	 	  */
	 	public MassPayResponseType(){
		}


		public MassPayResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
	
		}
	}




	/**
      *MassPayRequestItemType 
      */
	public partial class MassPayRequestItemType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			if(ReceiverEmail != null)
			{
				sb.Append("<urn:ReceiverEmail>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ReceiverEmail));
				sb.Append("</urn:ReceiverEmail>");
			}
			if(ReceiverPhone != null)
			{
				sb.Append("<urn:ReceiverPhone>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ReceiverPhone));
				sb.Append("</urn:ReceiverPhone>");
			}
			if(ReceiverID != null)
			{
				sb.Append("<urn:ReceiverID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ReceiverID));
				sb.Append("</urn:ReceiverID>");
			}
			if(Amount != null)
			{
				sb.Append("<urn:Amount");
				sb.Append(Amount.ToXMLString());
				sb.Append("</urn:Amount>");
			}
			if(UniqueId != null)
			{
				sb.Append("<urn:UniqueId>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(UniqueId));
				sb.Append("</urn:UniqueId>");
			}
			if(Note != null)
			{
				sb.Append("<urn:Note>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Note));
				sb.Append("</urn:Note>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class BillAgreementUpdateReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:BillAgreementUpdateReq>");
			if(BAUpdateRequest != null)
			{
				sb.Append("<urn:BAUpdateRequest>");
				sb.Append(BAUpdateRequest.ToXMLString());
				sb.Append("</urn:BAUpdateRequest>");
			}
			sb.Append("</urn:BillAgreementUpdateReq>");
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class BAUpdateRequestType : AbstractRequestType	{

		/**
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(ReferenceID != null)
			{
				sb.Append("<urn:ReferenceID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ReferenceID));
				sb.Append("</urn:ReferenceID>");
			}
			if(BillingAgreementDescription != null)
			{
				sb.Append("<urn:BillingAgreementDescription>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(BillingAgreementDescription));
				sb.Append("</urn:BillingAgreementDescription>");
			}
			if(BillingAgreementStatus != null)
			{
				sb.Append("<urn:BillingAgreementStatus>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(BillingAgreementStatus)));
				sb.Append("</urn:BillingAgreementStatus>");
			}
			if(BillingAgreementCustom != null)
			{
				sb.Append("<urn:BillingAgreementCustom>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(BillingAgreementCustom));
				sb.Append("</urn:BillingAgreementCustom>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class BAUpdateResponseType : AbstractResponseType	{

		/**
          *
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


		public BAUpdateResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'BAUpdateResponseDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.BAUpdateResponseDetails =  new BAUpdateResponseDetailsType(ChildNode);
			}
	
		}
	}




	/**
      *
      */
	public partial class AddressVerifyReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:AddressVerifyReq>");
			if(AddressVerifyRequest != null)
			{
				sb.Append("<urn:AddressVerifyRequest>");
				sb.Append(AddressVerifyRequest.ToXMLString());
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
	public partial class AddressVerifyRequestType : AbstractRequestType	{

		/**
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(Email != null)
			{
				sb.Append("<urn:Email>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Email));
				sb.Append("</urn:Email>");
			}
			if(Street != null)
			{
				sb.Append("<urn:Street>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Street));
				sb.Append("</urn:Street>");
			}
			if(Zip != null)
			{
				sb.Append("<urn:Zip>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Zip));
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
	public partial class AddressVerifyResponseType : AbstractResponseType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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


		public AddressVerifyResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ConfirmationCode']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ConfirmationCode = (AddressStatusCodeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(AddressStatusCodeType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'StreetMatch']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.StreetMatch = (MatchStatusCodeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(MatchStatusCodeType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ZipMatch']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ZipMatch = (MatchStatusCodeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(MatchStatusCodeType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'CountryCode']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.CountryCode = (CountryCodeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(CountryCodeType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PayPalToken']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PayPalToken = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *
      */
	public partial class EnterBoardingReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:EnterBoardingReq>");
			if(EnterBoardingRequest != null)
			{
				sb.Append("<urn:EnterBoardingRequest>");
				sb.Append(EnterBoardingRequest.ToXMLString());
				sb.Append("</urn:EnterBoardingRequest>");
			}
			sb.Append("</urn:EnterBoardingReq>");
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class EnterBoardingRequestType : AbstractRequestType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(EnterBoardingRequestDetails != null)
			{
				sb.Append("<ebl:EnterBoardingRequestDetails>");
				sb.Append(EnterBoardingRequestDetails.ToXMLString());
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
	public partial class EnterBoardingResponseType : AbstractResponseType	{

		/**
          *
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


		public EnterBoardingResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Token']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Token = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *
      */
	public partial class GetBoardingDetailsReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:GetBoardingDetailsReq>");
			if(GetBoardingDetailsRequest != null)
			{
				sb.Append("<urn:GetBoardingDetailsRequest>");
				sb.Append(GetBoardingDetailsRequest.ToXMLString());
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
	public partial class GetBoardingDetailsRequestType : AbstractRequestType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(Token != null)
			{
				sb.Append("<urn:Token>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Token));
				sb.Append("</urn:Token>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class GetBoardingDetailsResponseType : AbstractResponseType	{

		/**
          *
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


		public GetBoardingDetailsResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'GetBoardingDetailsResponseDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.GetBoardingDetailsResponseDetails =  new GetBoardingDetailsResponseDetailsType(ChildNode);
			}
	
		}
	}




	/**
      *
      */
	public partial class SetAuthFlowParamReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:SetAuthFlowParamReq>");
			if(SetAuthFlowParamRequest != null)
			{
				sb.Append("<urn:SetAuthFlowParamRequest>");
				sb.Append(SetAuthFlowParamRequest.ToXMLString());
				sb.Append("</urn:SetAuthFlowParamRequest>");
			}
			sb.Append("</urn:SetAuthFlowParamReq>");
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class SetAuthFlowParamRequestType : AbstractRequestType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(SetAuthFlowParamRequestDetails != null)
			{
				sb.Append("<ebl:SetAuthFlowParamRequestDetails>");
				sb.Append(SetAuthFlowParamRequestDetails.ToXMLString());
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
	public partial class SetAuthFlowParamResponseType : AbstractResponseType	{

		/**
          *
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


		public SetAuthFlowParamResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Token']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Token = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *
      */
	public partial class GetAuthDetailsReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:GetAuthDetailsReq>");
			if(GetAuthDetailsRequest != null)
			{
				sb.Append("<urn:GetAuthDetailsRequest>");
				sb.Append(GetAuthDetailsRequest.ToXMLString());
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
	public partial class GetAuthDetailsRequestType : AbstractRequestType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(Token != null)
			{
				sb.Append("<urn:Token>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Token));
				sb.Append("</urn:Token>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class GetAuthDetailsResponseType : AbstractResponseType	{

		/**
          *
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


		public GetAuthDetailsResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'GetAuthDetailsResponseDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.GetAuthDetailsResponseDetails =  new GetAuthDetailsResponseDetailsType(ChildNode);
			}
	
		}
	}




	/**
      *
      */
	public partial class SetAccessPermissionsReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:SetAccessPermissionsReq>");
			if(SetAccessPermissionsRequest != null)
			{
				sb.Append("<urn:SetAccessPermissionsRequest>");
				sb.Append(SetAccessPermissionsRequest.ToXMLString());
				sb.Append("</urn:SetAccessPermissionsRequest>");
			}
			sb.Append("</urn:SetAccessPermissionsReq>");
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class SetAccessPermissionsRequestType : AbstractRequestType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(SetAccessPermissionsRequestDetails != null)
			{
				sb.Append("<ebl:SetAccessPermissionsRequestDetails>");
				sb.Append(SetAccessPermissionsRequestDetails.ToXMLString());
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
	public partial class SetAccessPermissionsResponseType : AbstractResponseType	{

		/**
          *
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


		public SetAccessPermissionsResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Token']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Token = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *
      */
	public partial class UpdateAccessPermissionsReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:UpdateAccessPermissionsReq>");
			if(UpdateAccessPermissionsRequest != null)
			{
				sb.Append("<urn:UpdateAccessPermissionsRequest>");
				sb.Append(UpdateAccessPermissionsRequest.ToXMLString());
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
	public partial class UpdateAccessPermissionsRequestType : AbstractRequestType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(PayerID != null)
			{
				sb.Append("<urn:PayerID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(PayerID));
				sb.Append("</urn:PayerID>");
			}
			return sb.ToString();
		}

	}




	/**
      *The status of the update call, Success/Failure. Character
      *length and limitations: 20 single-byte characters 
      */
	public partial class UpdateAccessPermissionsResponseType : AbstractResponseType	{

		/**
          *
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


		public UpdateAccessPermissionsResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Status']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Status = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *
      */
	public partial class GetAccessPermissionDetailsReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:GetAccessPermissionDetailsReq>");
			if(GetAccessPermissionDetailsRequest != null)
			{
				sb.Append("<urn:GetAccessPermissionDetailsRequest>");
				sb.Append(GetAccessPermissionDetailsRequest.ToXMLString());
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
	public partial class GetAccessPermissionDetailsRequestType : AbstractRequestType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(Token != null)
			{
				sb.Append("<urn:Token>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Token));
				sb.Append("</urn:Token>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class GetAccessPermissionDetailsResponseType : AbstractResponseType	{

		/**
          *
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


		public GetAccessPermissionDetailsResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'GetAccessPermissionDetailsResponseDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.GetAccessPermissionDetailsResponseDetails =  new GetAccessPermissionDetailsResponseDetailsType(ChildNode);
			}
	
		}
	}




	/**
      *
      */
	public partial class GetIncentiveEvaluationReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:GetIncentiveEvaluationReq>");
			if(GetIncentiveEvaluationRequest != null)
			{
				sb.Append("<urn:GetIncentiveEvaluationRequest>");
				sb.Append(GetIncentiveEvaluationRequest.ToXMLString());
				sb.Append("</urn:GetIncentiveEvaluationRequest>");
			}
			sb.Append("</urn:GetIncentiveEvaluationReq>");
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class GetIncentiveEvaluationRequestType : AbstractRequestType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(GetIncentiveEvaluationRequestDetails != null)
			{
				sb.Append("<ebl:GetIncentiveEvaluationRequestDetails>");
				sb.Append(GetIncentiveEvaluationRequestDetails.ToXMLString());
				sb.Append("</ebl:GetIncentiveEvaluationRequestDetails>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class GetIncentiveEvaluationResponseType : AbstractResponseType	{

		/**
          *
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


		public GetIncentiveEvaluationResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'GetIncentiveEvaluationResponseDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.GetIncentiveEvaluationResponseDetails =  new GetIncentiveEvaluationResponseDetailsType(ChildNode);
			}
	
		}
	}




	/**
      *
      */
	public partial class SetExpressCheckoutReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:SetExpressCheckoutReq>");
			if(SetExpressCheckoutRequest != null)
			{
				sb.Append("<urn:SetExpressCheckoutRequest>");
				sb.Append(SetExpressCheckoutRequest.ToXMLString());
				sb.Append("</urn:SetExpressCheckoutRequest>");
			}
			sb.Append("</urn:SetExpressCheckoutReq>");
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class SetExpressCheckoutRequestType : AbstractRequestType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(SetExpressCheckoutRequestDetails != null)
			{
				sb.Append("<ebl:SetExpressCheckoutRequestDetails>");
				sb.Append(SetExpressCheckoutRequestDetails.ToXMLString());
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
	public partial class SetExpressCheckoutResponseType : AbstractResponseType	{

		/**
          *
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


		public SetExpressCheckoutResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Token']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Token = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *
      */
	public partial class ExecuteCheckoutOperationsReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:ExecuteCheckoutOperationsReq>");
			if(ExecuteCheckoutOperationsRequest != null)
			{
				sb.Append("<urn:ExecuteCheckoutOperationsRequest>");
				sb.Append(ExecuteCheckoutOperationsRequest.ToXMLString());
				sb.Append("</urn:ExecuteCheckoutOperationsRequest>");
			}
			sb.Append("</urn:ExecuteCheckoutOperationsReq>");
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class ExecuteCheckoutOperationsRequestType : AbstractRequestType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(ExecuteCheckoutOperationsRequestDetails != null)
			{
				sb.Append("<ebl:ExecuteCheckoutOperationsRequestDetails>");
				sb.Append(ExecuteCheckoutOperationsRequestDetails.ToXMLString());
				sb.Append("</ebl:ExecuteCheckoutOperationsRequestDetails>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class ExecuteCheckoutOperationsResponseType : AbstractResponseType	{

		/**
          *
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


		public ExecuteCheckoutOperationsResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ExecuteCheckoutOperationsResponseDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ExecuteCheckoutOperationsResponseDetails =  new ExecuteCheckoutOperationsResponseDetailsType(ChildNode);
			}
	
		}
	}




	/**
      *
      */
	public partial class GetExpressCheckoutDetailsReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:GetExpressCheckoutDetailsReq>");
			if(GetExpressCheckoutDetailsRequest != null)
			{
				sb.Append("<urn:GetExpressCheckoutDetailsRequest>");
				sb.Append(GetExpressCheckoutDetailsRequest.ToXMLString());
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
	public partial class GetExpressCheckoutDetailsRequestType : AbstractRequestType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(Token != null)
			{
				sb.Append("<urn:Token>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Token));
				sb.Append("</urn:Token>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class GetExpressCheckoutDetailsResponseType : AbstractResponseType	{

		/**
          *
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


		public GetExpressCheckoutDetailsResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'GetExpressCheckoutDetailsResponseDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.GetExpressCheckoutDetailsResponseDetails =  new GetExpressCheckoutDetailsResponseDetailsType(ChildNode);
			}
	
		}
	}




	/**
      *
      */
	public partial class DoExpressCheckoutPaymentReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:DoExpressCheckoutPaymentReq>");
			if(DoExpressCheckoutPaymentRequest != null)
			{
				sb.Append("<urn:DoExpressCheckoutPaymentRequest>");
				sb.Append(DoExpressCheckoutPaymentRequest.ToXMLString());
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
	public partial class DoExpressCheckoutPaymentRequestType : AbstractRequestType	{

		/**
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(DoExpressCheckoutPaymentRequestDetails != null)
			{
				sb.Append("<ebl:DoExpressCheckoutPaymentRequestDetails>");
				sb.Append(DoExpressCheckoutPaymentRequestDetails.ToXMLString());
				sb.Append("</ebl:DoExpressCheckoutPaymentRequestDetails>");
			}
			if(ReturnFMFDetails != null)
			{
				sb.Append("<urn:ReturnFMFDetails>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ReturnFMFDetails));
				sb.Append("</urn:ReturnFMFDetails>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class DoExpressCheckoutPaymentResponseType : AbstractResponseType	{

		/**
          *
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
          *
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


		public DoExpressCheckoutPaymentResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'DoExpressCheckoutPaymentResponseDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.DoExpressCheckoutPaymentResponseDetails =  new DoExpressCheckoutPaymentResponseDetailsType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'FMFDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.FMFDetails =  new FMFDetailsType(ChildNode);
			}
	
		}
	}




	/**
      *
      */
	public partial class DoUATPExpressCheckoutPaymentReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:DoUATPExpressCheckoutPaymentReq>");
			if(DoUATPExpressCheckoutPaymentRequest != null)
			{
				sb.Append("<urn:DoUATPExpressCheckoutPaymentRequest>");
				sb.Append(DoUATPExpressCheckoutPaymentRequest.ToXMLString());
				sb.Append("</urn:DoUATPExpressCheckoutPaymentRequest>");
			}
			sb.Append("</urn:DoUATPExpressCheckoutPaymentReq>");
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class DoUATPExpressCheckoutPaymentRequestType : DoExpressCheckoutPaymentRequestType	{

		/**
	 	  * Default Constructor
	 	  */
	 	public DoUATPExpressCheckoutPaymentRequestType(){
		}


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class DoUATPExpressCheckoutPaymentResponseType : DoExpressCheckoutPaymentResponseType	{

		/**
          *
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


		public DoUATPExpressCheckoutPaymentResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'UATPDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.UATPDetails =  new UATPDetailsType(ChildNode);
			}
	
		}
	}




	/**
      *
      */
	public partial class ManagePendingTransactionStatusReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:ManagePendingTransactionStatusReq>");
			if(ManagePendingTransactionStatusRequest != null)
			{
				sb.Append("<urn:ManagePendingTransactionStatusRequest>");
				sb.Append(ManagePendingTransactionStatusRequest.ToXMLString());
				sb.Append("</urn:ManagePendingTransactionStatusRequest>");
			}
			sb.Append("</urn:ManagePendingTransactionStatusReq>");
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class ManagePendingTransactionStatusRequestType : AbstractRequestType	{

		/**
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(TransactionID != null)
			{
				sb.Append("<urn:TransactionID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(TransactionID));
				sb.Append("</urn:TransactionID>");
			}
			if(Action != null)
			{
				sb.Append("<urn:Action>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(Action)));
				sb.Append("</urn:Action>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class ManagePendingTransactionStatusResponseType : AbstractResponseType	{

		/**
          *
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
          *
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


		public ManagePendingTransactionStatusResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'TransactionID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.TransactionID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Status']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Status = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *
      */
	public partial class DoDirectPaymentReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:DoDirectPaymentReq>");
			if(DoDirectPaymentRequest != null)
			{
				sb.Append("<urn:DoDirectPaymentRequest>");
				sb.Append(DoDirectPaymentRequest.ToXMLString());
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
	public partial class DoDirectPaymentRequestType : AbstractRequestType	{

		/**
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(DoDirectPaymentRequestDetails != null)
			{
				sb.Append("<ebl:DoDirectPaymentRequestDetails>");
				sb.Append(DoDirectPaymentRequestDetails.ToXMLString());
				sb.Append("</ebl:DoDirectPaymentRequestDetails>");
			}
			if(ReturnFMFDetails != null)
			{
				sb.Append("<urn:ReturnFMFDetails>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ReturnFMFDetails));
				sb.Append("</urn:ReturnFMFDetails>");
			}
			return sb.ToString();
		}

	}




	/**
      *The amount of the payment as specified by you on
      *DoDirectPaymentRequest.
      */
	public partial class DoDirectPaymentResponseType : AbstractResponseType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public DoDirectPaymentResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Amount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Amount =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'AVSCode']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.AVSCode = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'CVV2Code']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.CVV2Code = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'TransactionID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.TransactionID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PendingReason']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PendingReason = (PendingStatusCodeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(PendingStatusCodeType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PaymentStatus']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PaymentStatus = (PaymentStatusCodeType)EnumUtils.GetValue(ChildNode.InnerText,typeof(PaymentStatusCodeType));
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'FMFDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.FMFDetails =  new FMFDetailsType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ThreeDSecureResponse']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ThreeDSecureResponse =  new ThreeDSecureResponseType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PaymentAdviceCode']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PaymentAdviceCode = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *
      */
	public partial class DoCancelReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:DoCancelReq>");
			if(DoCancelRequest != null)
			{
				sb.Append("<urn:DoCancelRequest>");
				sb.Append(DoCancelRequest.ToXMLString());
				sb.Append("</urn:DoCancelRequest>");
			}
			sb.Append("</urn:DoCancelReq>");
			return sb.ToString();
		}

	}




	/**
      *Msg Sub Id that was used for the orginal operation. 
      */
	public partial class DoCancelRequestType : AbstractRequestType	{

		/**
          *
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
          *
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
          *
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
	 	public DoCancelRequestType(string CancelMsgSubID, APIType? APIType){
			this.CancelMsgSubID = CancelMsgSubID;
			this.APIType = APIType;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public DoCancelRequestType(){
		}


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(CancelMsgSubID != null)
			{
				sb.Append("<urn:CancelMsgSubID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(CancelMsgSubID));
				sb.Append("</urn:CancelMsgSubID>");
			}
			if(APIType != null)
			{
				sb.Append("<urn:APIType>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(APIType)));
				sb.Append("</urn:APIType>");
			}
			if(MsgSubID != null)
			{
				sb.Append("<urn:MsgSubID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(MsgSubID));
				sb.Append("</urn:MsgSubID>");
			}
			return sb.ToString();
		}

	}




	/**
      *Return msgsubid back to merchant 
      */
	public partial class DoCancelResponseType : AbstractResponseType	{

		/**
          *
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
	 	public DoCancelResponseType(){
		}


		public DoCancelResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'MsgSubID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.MsgSubID = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *
      */
	public partial class DoCaptureReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:DoCaptureReq>");
			if(DoCaptureRequest != null)
			{
				sb.Append("<urn:DoCaptureRequest>");
				sb.Append(DoCaptureRequest.ToXMLString());
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
	public partial class DoCaptureRequestType : AbstractRequestType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(AuthorizationID != null)
			{
				sb.Append("<urn:AuthorizationID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(AuthorizationID));
				sb.Append("</urn:AuthorizationID>");
			}
			if(Amount != null)
			{
				sb.Append("<urn:Amount");
				sb.Append(Amount.ToXMLString());
				sb.Append("</urn:Amount>");
			}
			if(CompleteType != null)
			{
				sb.Append("<urn:CompleteType>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(CompleteType)));
				sb.Append("</urn:CompleteType>");
			}
			if(Note != null)
			{
				sb.Append("<urn:Note>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Note));
				sb.Append("</urn:Note>");
			}
			if(InvoiceID != null)
			{
				sb.Append("<urn:InvoiceID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(InvoiceID));
				sb.Append("</urn:InvoiceID>");
			}
			if(EnhancedData != null)
			{
				sb.Append("<ebl:EnhancedData>");
				sb.Append(EnhancedData.ToXMLString());
				sb.Append("</ebl:EnhancedData>");
			}
			if(Descriptor != null)
			{
				sb.Append("<urn:Descriptor>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Descriptor));
				sb.Append("</urn:Descriptor>");
			}
			if(MerchantStoreDetails != null)
			{
				sb.Append("<ebl:MerchantStoreDetails>");
				sb.Append(MerchantStoreDetails.ToXMLString());
				sb.Append("</ebl:MerchantStoreDetails>");
			}
			if(MsgSubID != null)
			{
				sb.Append("<urn:MsgSubID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(MsgSubID));
				sb.Append("</urn:MsgSubID>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class DoCaptureResponseType : AbstractResponseType	{

		/**
          *
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


		public DoCaptureResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'DoCaptureResponseDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.DoCaptureResponseDetails =  new DoCaptureResponseDetailsType(ChildNode);
			}
	
		}
	}




	/**
      *
      */
	public partial class DoReauthorizationReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:DoReauthorizationReq>");
			if(DoReauthorizationRequest != null)
			{
				sb.Append("<urn:DoReauthorizationRequest>");
				sb.Append(DoReauthorizationRequest.ToXMLString());
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
	public partial class DoReauthorizationRequestType : AbstractRequestType	{

		/**
          *
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
          *
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
          *
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
	 	public DoReauthorizationRequestType(string AuthorizationID, BasicAmountType Amount){
			this.AuthorizationID = AuthorizationID;
			this.Amount = Amount;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public DoReauthorizationRequestType(){
		}


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(AuthorizationID != null)
			{
				sb.Append("<urn:AuthorizationID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(AuthorizationID));
				sb.Append("</urn:AuthorizationID>");
			}
			if(Amount != null)
			{
				sb.Append("<urn:Amount");
				sb.Append(Amount.ToXMLString());
				sb.Append("</urn:Amount>");
			}
			if(MsgSubID != null)
			{
				sb.Append("<urn:MsgSubID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(MsgSubID));
				sb.Append("</urn:MsgSubID>");
			}
			return sb.ToString();
		}

	}




	/**
      *A new authorization identification number. Character length
      *and limits: 19 single-byte characters 
      */
	public partial class DoReauthorizationResponseType : AbstractResponseType	{

		/**
          *
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
          *
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
          *
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
	 	public DoReauthorizationResponseType(){
		}


		public DoReauthorizationResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'AuthorizationID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.AuthorizationID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'AuthorizationInfo']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.AuthorizationInfo =  new AuthorizationInfoType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'MsgSubID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.MsgSubID = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *
      */
	public partial class DoVoidReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:DoVoidReq>");
			if(DoVoidRequest != null)
			{
				sb.Append("<urn:DoVoidRequest>");
				sb.Append(DoVoidRequest.ToXMLString());
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
	public partial class DoVoidRequestType : AbstractRequestType	{

		/**
          *
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
          *
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
          *
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
	 	public DoVoidRequestType(string AuthorizationID){
			this.AuthorizationID = AuthorizationID;
		}

		/**
	 	  * Default Constructor
	 	  */
	 	public DoVoidRequestType(){
		}


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(AuthorizationID != null)
			{
				sb.Append("<urn:AuthorizationID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(AuthorizationID));
				sb.Append("</urn:AuthorizationID>");
			}
			if(Note != null)
			{
				sb.Append("<urn:Note>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Note));
				sb.Append("</urn:Note>");
			}
			if(MsgSubID != null)
			{
				sb.Append("<urn:MsgSubID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(MsgSubID));
				sb.Append("</urn:MsgSubID>");
			}
			return sb.ToString();
		}

	}




	/**
      *The authorization identification number you specified in the
      *request. Character length and limits: 19 single-byte
      *characters 
      */
	public partial class DoVoidResponseType : AbstractResponseType	{

		/**
          *
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
          *
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
	 	public DoVoidResponseType(){
		}


		public DoVoidResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'AuthorizationID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.AuthorizationID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'MsgSubID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.MsgSubID = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *
      */
	public partial class DoAuthorizationReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:DoAuthorizationReq>");
			if(DoAuthorizationRequest != null)
			{
				sb.Append("<urn:DoAuthorizationRequest>");
				sb.Append(DoAuthorizationRequest.ToXMLString());
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
	public partial class DoAuthorizationRequestType : AbstractRequestType	{

		/**
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(TransactionID != null)
			{
				sb.Append("<urn:TransactionID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(TransactionID));
				sb.Append("</urn:TransactionID>");
			}
			if(TransactionEntity != null)
			{
				sb.Append("<urn:TransactionEntity>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(TransactionEntity)));
				sb.Append("</urn:TransactionEntity>");
			}
			if(Amount != null)
			{
				sb.Append("<urn:Amount");
				sb.Append(Amount.ToXMLString());
				sb.Append("</urn:Amount>");
			}
			if(MsgSubID != null)
			{
				sb.Append("<urn:MsgSubID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(MsgSubID));
				sb.Append("</urn:MsgSubID>");
			}
			return sb.ToString();
		}

	}




	/**
      *An authorization identification number. Character length and
      *limits: 19 single-byte characters 
      */
	public partial class DoAuthorizationResponseType : AbstractResponseType	{

		/**
          *
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
          *
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
          *
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
          *
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


		public DoAuthorizationResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'TransactionID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.TransactionID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Amount']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Amount =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'AuthorizationInfo']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.AuthorizationInfo =  new AuthorizationInfoType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'MsgSubID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.MsgSubID = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *
      */
	public partial class DoUATPAuthorizationReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:DoUATPAuthorizationReq>");
			if(DoUATPAuthorizationRequest != null)
			{
				sb.Append("<urn:DoUATPAuthorizationRequest>");
				sb.Append(DoUATPAuthorizationRequest.ToXMLString());
				sb.Append("</urn:DoUATPAuthorizationRequest>");
			}
			sb.Append("</urn:DoUATPAuthorizationReq>");
			return sb.ToString();
		}

	}




	/**
      *UATP card details Required 
      */
	public partial class DoUATPAuthorizationRequestType : AbstractRequestType	{

		/**
          *
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
          *
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
          *
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
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(UATPDetails != null)
			{
				sb.Append("<ebl:UATPDetails>");
				sb.Append(UATPDetails.ToXMLString());
				sb.Append("</ebl:UATPDetails>");
			}
			if(TransactionEntity != null)
			{
				sb.Append("<urn:TransactionEntity>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(EnumUtils.GetDescription(TransactionEntity)));
				sb.Append("</urn:TransactionEntity>");
			}
			if(Amount != null)
			{
				sb.Append("<urn:Amount");
				sb.Append(Amount.ToXMLString());
				sb.Append("</urn:Amount>");
			}
			if(InvoiceID != null)
			{
				sb.Append("<urn:InvoiceID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(InvoiceID));
				sb.Append("</urn:InvoiceID>");
			}
			if(MsgSubID != null)
			{
				sb.Append("<urn:MsgSubID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(MsgSubID));
				sb.Append("</urn:MsgSubID>");
			}
			return sb.ToString();
		}

	}




	/**
      *Auth Authorization Code. 
      */
	public partial class DoUATPAuthorizationResponseType : DoAuthorizationResponseType	{

		/**
          *
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
          *
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
          *
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
          *
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


		public DoUATPAuthorizationResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'UATPDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.UATPDetails =  new UATPDetailsType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'AuthorizationCode']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.AuthorizationCode = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'InvoiceID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.InvoiceID = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'MsgSubID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.MsgSubID = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *
      */
	public partial class CreateMobilePaymentReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:CreateMobilePaymentReq>");
			if(CreateMobilePaymentRequest != null)
			{
				sb.Append("<urn:CreateMobilePaymentRequest>");
				sb.Append(CreateMobilePaymentRequest.ToXMLString());
				sb.Append("</urn:CreateMobilePaymentRequest>");
			}
			sb.Append("</urn:CreateMobilePaymentReq>");
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class CreateMobilePaymentRequestType : AbstractRequestType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(CreateMobilePaymentRequestDetails != null)
			{
				sb.Append("<ebl:CreateMobilePaymentRequestDetails>");
				sb.Append(CreateMobilePaymentRequestDetails.ToXMLString());
				sb.Append("</ebl:CreateMobilePaymentRequestDetails>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class CreateMobilePaymentResponseType : AbstractResponseType	{

		/**
	 	  * Default Constructor
	 	  */
	 	public CreateMobilePaymentResponseType(){
		}


		public CreateMobilePaymentResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
	
		}
	}




	/**
      *
      */
	public partial class GetMobileStatusReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:GetMobileStatusReq>");
			if(GetMobileStatusRequest != null)
			{
				sb.Append("<urn:GetMobileStatusRequest>");
				sb.Append(GetMobileStatusRequest.ToXMLString());
				sb.Append("</urn:GetMobileStatusRequest>");
			}
			sb.Append("</urn:GetMobileStatusReq>");
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class GetMobileStatusRequestType : AbstractRequestType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(GetMobileStatusRequestDetails != null)
			{
				sb.Append("<ebl:GetMobileStatusRequestDetails>");
				sb.Append(GetMobileStatusRequestDetails.ToXMLString());
				sb.Append("</ebl:GetMobileStatusRequestDetails>");
			}
			return sb.ToString();
		}

	}




	/**
      *Indicates whether the phone is activated for mobile payments
      *
      */
	public partial class GetMobileStatusResponseType : AbstractResponseType	{

		/**
          *
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
          *
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


		public GetMobileStatusResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'IsActivated']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.IsActivated = System.Convert.ToInt32(ChildNode.InnerText);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'PaymentPending']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.PaymentPending = System.Convert.ToInt32(ChildNode.InnerText);
			}
	
		}
	}




	/**
      *
      */
	public partial class SetMobileCheckoutReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:SetMobileCheckoutReq>");
			if(SetMobileCheckoutRequest != null)
			{
				sb.Append("<urn:SetMobileCheckoutRequest>");
				sb.Append(SetMobileCheckoutRequest.ToXMLString());
				sb.Append("</urn:SetMobileCheckoutRequest>");
			}
			sb.Append("</urn:SetMobileCheckoutReq>");
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class SetMobileCheckoutRequestType : AbstractRequestType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(SetMobileCheckoutRequestDetails != null)
			{
				sb.Append("<ebl:SetMobileCheckoutRequestDetails>");
				sb.Append(SetMobileCheckoutRequestDetails.ToXMLString());
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
	public partial class SetMobileCheckoutResponseType : AbstractResponseType	{

		/**
          *
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


		public SetMobileCheckoutResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Token']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Token = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *
      */
	public partial class DoMobileCheckoutPaymentReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:DoMobileCheckoutPaymentReq>");
			if(DoMobileCheckoutPaymentRequest != null)
			{
				sb.Append("<urn:DoMobileCheckoutPaymentRequest>");
				sb.Append(DoMobileCheckoutPaymentRequest.ToXMLString());
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
	public partial class DoMobileCheckoutPaymentRequestType : AbstractRequestType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(Token != null)
			{
				sb.Append("<urn:Token>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Token));
				sb.Append("</urn:Token>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class DoMobileCheckoutPaymentResponseType : AbstractResponseType	{

		/**
          *
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


		public DoMobileCheckoutPaymentResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'DoMobileCheckoutPaymentResponseDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.DoMobileCheckoutPaymentResponseDetails =  new DoMobileCheckoutPaymentResponseDetailsType(ChildNode);
			}
	
		}
	}




	/**
      *
      */
	public partial class GetBalanceReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:GetBalanceReq>");
			if(GetBalanceRequest != null)
			{
				sb.Append("<urn:GetBalanceRequest>");
				sb.Append(GetBalanceRequest.ToXMLString());
				sb.Append("</urn:GetBalanceRequest>");
			}
			sb.Append("</urn:GetBalanceReq>");
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class GetBalanceRequestType : AbstractRequestType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(ReturnAllCurrencies != null)
			{
				sb.Append("<urn:ReturnAllCurrencies>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ReturnAllCurrencies));
				sb.Append("</urn:ReturnAllCurrencies>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class GetBalanceResponseType : AbstractResponseType	{

		/**
          *
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
          *
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
          *
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


		public GetBalanceResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Balance']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Balance =  new BasicAmountType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'BalanceTimeStamp']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.BalanceTimeStamp = ChildNode.InnerText;
			}
			ChildNodeList = xmlNode.SelectNodes("*[local-name() = 'BalanceHoldings']");
			if (ChildNodeList != null && ChildNodeList.Count > 0)
			{
				for(int i = 0; i < ChildNodeList.Count; i++)
				{
					XmlNode subNode = ChildNodeList.Item(i);
					this.BalanceHoldings.Add(new BasicAmountType(subNode));
				}
			}
	
		}
	}




	/**
      *
      */
	public partial class SetCustomerBillingAgreementReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:SetCustomerBillingAgreementReq>");
			if(SetCustomerBillingAgreementRequest != null)
			{
				sb.Append("<urn:SetCustomerBillingAgreementRequest>");
				sb.Append(SetCustomerBillingAgreementRequest.ToXMLString());
				sb.Append("</urn:SetCustomerBillingAgreementRequest>");
			}
			sb.Append("</urn:SetCustomerBillingAgreementReq>");
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class SetCustomerBillingAgreementRequestType : AbstractRequestType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(SetCustomerBillingAgreementRequestDetails != null)
			{
				sb.Append("<ebl:SetCustomerBillingAgreementRequestDetails>");
				sb.Append(SetCustomerBillingAgreementRequestDetails.ToXMLString());
				sb.Append("</ebl:SetCustomerBillingAgreementRequestDetails>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class SetCustomerBillingAgreementResponseType : AbstractResponseType	{

		/**
          *
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


		public SetCustomerBillingAgreementResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Token']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Token = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *
      */
	public partial class GetBillingAgreementCustomerDetailsReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:GetBillingAgreementCustomerDetailsReq>");
			if(GetBillingAgreementCustomerDetailsRequest != null)
			{
				sb.Append("<urn:GetBillingAgreementCustomerDetailsRequest>");
				sb.Append(GetBillingAgreementCustomerDetailsRequest.ToXMLString());
				sb.Append("</urn:GetBillingAgreementCustomerDetailsRequest>");
			}
			sb.Append("</urn:GetBillingAgreementCustomerDetailsReq>");
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class GetBillingAgreementCustomerDetailsRequestType : AbstractRequestType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(Token != null)
			{
				sb.Append("<urn:Token>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Token));
				sb.Append("</urn:Token>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class GetBillingAgreementCustomerDetailsResponseType : AbstractResponseType	{

		/**
          *
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


		public GetBillingAgreementCustomerDetailsResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'GetBillingAgreementCustomerDetailsResponseDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.GetBillingAgreementCustomerDetailsResponseDetails =  new GetBillingAgreementCustomerDetailsResponseDetailsType(ChildNode);
			}
	
		}
	}




	/**
      *
      */
	public partial class CreateBillingAgreementReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:CreateBillingAgreementReq>");
			if(CreateBillingAgreementRequest != null)
			{
				sb.Append("<urn:CreateBillingAgreementRequest>");
				sb.Append(CreateBillingAgreementRequest.ToXMLString());
				sb.Append("</urn:CreateBillingAgreementRequest>");
			}
			sb.Append("</urn:CreateBillingAgreementReq>");
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class CreateBillingAgreementRequestType : AbstractRequestType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(Token != null)
			{
				sb.Append("<urn:Token>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(Token));
				sb.Append("</urn:Token>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class CreateBillingAgreementResponseType : AbstractResponseType	{

		/**
          *
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


		public CreateBillingAgreementResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'BillingAgreementID']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.BillingAgreementID = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *
      */
	public partial class DoReferenceTransactionReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:DoReferenceTransactionReq>");
			if(DoReferenceTransactionRequest != null)
			{
				sb.Append("<urn:DoReferenceTransactionRequest>");
				sb.Append(DoReferenceTransactionRequest.ToXMLString());
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
	public partial class DoReferenceTransactionRequestType : AbstractRequestType	{

		/**
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(DoReferenceTransactionRequestDetails != null)
			{
				sb.Append("<ebl:DoReferenceTransactionRequestDetails>");
				sb.Append(DoReferenceTransactionRequestDetails.ToXMLString());
				sb.Append("</ebl:DoReferenceTransactionRequestDetails>");
			}
			if(ReturnFMFDetails != null)
			{
				sb.Append("<urn:ReturnFMFDetails>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ReturnFMFDetails));
				sb.Append("</urn:ReturnFMFDetails>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class DoReferenceTransactionResponseType : AbstractResponseType	{

		/**
          *
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
          *
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


		public DoReferenceTransactionResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'DoReferenceTransactionResponseDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.DoReferenceTransactionResponseDetails =  new DoReferenceTransactionResponseDetailsType(ChildNode);
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'FMFDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.FMFDetails =  new FMFDetailsType(ChildNode);
			}
	
		}
	}




	/**
      *
      */
	public partial class DoNonReferencedCreditReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:DoNonReferencedCreditReq>");
			if(DoNonReferencedCreditRequest != null)
			{
				sb.Append("<urn:DoNonReferencedCreditRequest>");
				sb.Append(DoNonReferencedCreditRequest.ToXMLString());
				sb.Append("</urn:DoNonReferencedCreditRequest>");
			}
			sb.Append("</urn:DoNonReferencedCreditReq>");
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class DoNonReferencedCreditRequestType : AbstractRequestType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(DoNonReferencedCreditRequestDetails != null)
			{
				sb.Append("<ebl:DoNonReferencedCreditRequestDetails>");
				sb.Append(DoNonReferencedCreditRequestDetails.ToXMLString());
				sb.Append("</ebl:DoNonReferencedCreditRequestDetails>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class DoNonReferencedCreditResponseType : AbstractResponseType	{

		/**
          *
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


		public DoNonReferencedCreditResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'DoNonReferencedCreditResponseDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.DoNonReferencedCreditResponseDetails =  new DoNonReferencedCreditResponseDetailsType(ChildNode);
			}
	
		}
	}




	/**
      *
      */
	public partial class CreateRecurringPaymentsProfileReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:CreateRecurringPaymentsProfileReq>");
			if(CreateRecurringPaymentsProfileRequest != null)
			{
				sb.Append("<urn:CreateRecurringPaymentsProfileRequest>");
				sb.Append(CreateRecurringPaymentsProfileRequest.ToXMLString());
				sb.Append("</urn:CreateRecurringPaymentsProfileRequest>");
			}
			sb.Append("</urn:CreateRecurringPaymentsProfileReq>");
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class CreateRecurringPaymentsProfileRequestType : AbstractRequestType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(CreateRecurringPaymentsProfileRequestDetails != null)
			{
				sb.Append("<ebl:CreateRecurringPaymentsProfileRequestDetails>");
				sb.Append(CreateRecurringPaymentsProfileRequestDetails.ToXMLString());
				sb.Append("</ebl:CreateRecurringPaymentsProfileRequestDetails>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class CreateRecurringPaymentsProfileResponseType : AbstractResponseType	{

		/**
          *
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


		public CreateRecurringPaymentsProfileResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'CreateRecurringPaymentsProfileResponseDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.CreateRecurringPaymentsProfileResponseDetails =  new CreateRecurringPaymentsProfileResponseDetailsType(ChildNode);
			}
	
		}
	}




	/**
      *
      */
	public partial class GetRecurringPaymentsProfileDetailsReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:GetRecurringPaymentsProfileDetailsReq>");
			if(GetRecurringPaymentsProfileDetailsRequest != null)
			{
				sb.Append("<urn:GetRecurringPaymentsProfileDetailsRequest>");
				sb.Append(GetRecurringPaymentsProfileDetailsRequest.ToXMLString());
				sb.Append("</urn:GetRecurringPaymentsProfileDetailsRequest>");
			}
			sb.Append("</urn:GetRecurringPaymentsProfileDetailsReq>");
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class GetRecurringPaymentsProfileDetailsRequestType : AbstractRequestType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(ProfileID != null)
			{
				sb.Append("<urn:ProfileID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ProfileID));
				sb.Append("</urn:ProfileID>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class GetRecurringPaymentsProfileDetailsResponseType : AbstractResponseType	{

		/**
          *
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


		public GetRecurringPaymentsProfileDetailsResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'GetRecurringPaymentsProfileDetailsResponseDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.GetRecurringPaymentsProfileDetailsResponseDetails =  new GetRecurringPaymentsProfileDetailsResponseDetailsType(ChildNode);
			}
	
		}
	}




	/**
      *
      */
	public partial class ManageRecurringPaymentsProfileStatusReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:ManageRecurringPaymentsProfileStatusReq>");
			if(ManageRecurringPaymentsProfileStatusRequest != null)
			{
				sb.Append("<urn:ManageRecurringPaymentsProfileStatusRequest>");
				sb.Append(ManageRecurringPaymentsProfileStatusRequest.ToXMLString());
				sb.Append("</urn:ManageRecurringPaymentsProfileStatusRequest>");
			}
			sb.Append("</urn:ManageRecurringPaymentsProfileStatusReq>");
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class ManageRecurringPaymentsProfileStatusRequestType : AbstractRequestType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(ManageRecurringPaymentsProfileStatusRequestDetails != null)
			{
				sb.Append("<ebl:ManageRecurringPaymentsProfileStatusRequestDetails>");
				sb.Append(ManageRecurringPaymentsProfileStatusRequestDetails.ToXMLString());
				sb.Append("</ebl:ManageRecurringPaymentsProfileStatusRequestDetails>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class ManageRecurringPaymentsProfileStatusResponseType : AbstractResponseType	{

		/**
          *
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


		public ManageRecurringPaymentsProfileStatusResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ManageRecurringPaymentsProfileStatusResponseDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ManageRecurringPaymentsProfileStatusResponseDetails =  new ManageRecurringPaymentsProfileStatusResponseDetailsType(ChildNode);
			}
	
		}
	}




	/**
      *
      */
	public partial class BillOutstandingAmountReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:BillOutstandingAmountReq>");
			if(BillOutstandingAmountRequest != null)
			{
				sb.Append("<urn:BillOutstandingAmountRequest>");
				sb.Append(BillOutstandingAmountRequest.ToXMLString());
				sb.Append("</urn:BillOutstandingAmountRequest>");
			}
			sb.Append("</urn:BillOutstandingAmountReq>");
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class BillOutstandingAmountRequestType : AbstractRequestType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(BillOutstandingAmountRequestDetails != null)
			{
				sb.Append("<ebl:BillOutstandingAmountRequestDetails>");
				sb.Append(BillOutstandingAmountRequestDetails.ToXMLString());
				sb.Append("</ebl:BillOutstandingAmountRequestDetails>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class BillOutstandingAmountResponseType : AbstractResponseType	{

		/**
          *
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


		public BillOutstandingAmountResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'BillOutstandingAmountResponseDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.BillOutstandingAmountResponseDetails =  new BillOutstandingAmountResponseDetailsType(ChildNode);
			}
	
		}
	}




	/**
      *
      */
	public partial class UpdateRecurringPaymentsProfileReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:UpdateRecurringPaymentsProfileReq>");
			if(UpdateRecurringPaymentsProfileRequest != null)
			{
				sb.Append("<urn:UpdateRecurringPaymentsProfileRequest>");
				sb.Append(UpdateRecurringPaymentsProfileRequest.ToXMLString());
				sb.Append("</urn:UpdateRecurringPaymentsProfileRequest>");
			}
			sb.Append("</urn:UpdateRecurringPaymentsProfileReq>");
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class UpdateRecurringPaymentsProfileRequestType : AbstractRequestType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(UpdateRecurringPaymentsProfileRequestDetails != null)
			{
				sb.Append("<ebl:UpdateRecurringPaymentsProfileRequestDetails>");
				sb.Append(UpdateRecurringPaymentsProfileRequestDetails.ToXMLString());
				sb.Append("</ebl:UpdateRecurringPaymentsProfileRequestDetails>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class UpdateRecurringPaymentsProfileResponseType : AbstractResponseType	{

		/**
          *
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


		public UpdateRecurringPaymentsProfileResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'UpdateRecurringPaymentsProfileResponseDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.UpdateRecurringPaymentsProfileResponseDetails =  new UpdateRecurringPaymentsProfileResponseDetailsType(ChildNode);
			}
	
		}
	}




	/**
      *
      */
	public partial class GetPalDetailsReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:GetPalDetailsReq>");
			if(GetPalDetailsRequest != null)
			{
				sb.Append("<urn:GetPalDetailsRequest>");
				sb.Append(GetPalDetailsRequest.ToXMLString());
				sb.Append("</urn:GetPalDetailsRequest>");
			}
			sb.Append("</urn:GetPalDetailsReq>");
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class GetPalDetailsRequestType : AbstractRequestType	{

		/**
	 	  * Default Constructor
	 	  */
	 	public GetPalDetailsRequestType(){
		}


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class GetPalDetailsResponseType : AbstractResponseType	{

		/**
          *
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
          *
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


		public GetPalDetailsResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Pal']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Pal = ChildNode.InnerText;
			}
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'Locale']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.Locale = ChildNode.InnerText;
			}
	
		}
	}




	/**
      *
      */
	public partial class ReverseTransactionReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:ReverseTransactionReq>");
			if(ReverseTransactionRequest != null)
			{
				sb.Append("<urn:ReverseTransactionRequest>");
				sb.Append(ReverseTransactionRequest.ToXMLString());
				sb.Append("</urn:ReverseTransactionRequest>");
			}
			sb.Append("</urn:ReverseTransactionReq>");
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class ReverseTransactionRequestType : AbstractRequestType	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(ReverseTransactionRequestDetails != null)
			{
				sb.Append("<ebl:ReverseTransactionRequestDetails>");
				sb.Append(ReverseTransactionRequestDetails.ToXMLString());
				sb.Append("</ebl:ReverseTransactionRequestDetails>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class ReverseTransactionResponseType : AbstractResponseType	{

		/**
          *
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


		public ReverseTransactionResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
			ChildNode = xmlNode.SelectSingleNode("*[local-name() = 'ReverseTransactionResponseDetails']");
			if(ChildNode != null && !DeserializationUtils.isWhiteSpaceNode(ChildNode))
			{
				this.ReverseTransactionResponseDetails =  new ReverseTransactionResponseDetailsType(ChildNode);
			}
	
		}
	}




	/**
      *
      */
	public partial class ExternalRememberMeOptOutReq	{

		/**
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<urn:ExternalRememberMeOptOutReq>");
			if(ExternalRememberMeOptOutRequest != null)
			{
				sb.Append("<urn:ExternalRememberMeOptOutRequest>");
				sb.Append(ExternalRememberMeOptOutRequest.ToXMLString());
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
	public partial class ExternalRememberMeOptOutRequestType : AbstractRequestType	{

		/**
          *
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
          *
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


		public string ToXMLString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToXMLString());
			if(ExternalRememberMeID != null)
			{
				sb.Append("<urn:ExternalRememberMeID>").Append(DeserializationUtils.escapeInvalidXmlCharsRegex(ExternalRememberMeID));
				sb.Append("</urn:ExternalRememberMeID>");
			}
			if(ExternalRememberMeOwnerDetails != null)
			{
				sb.Append("<urn:ExternalRememberMeOwnerDetails>");
				sb.Append(ExternalRememberMeOwnerDetails.ToXMLString());
				sb.Append("</urn:ExternalRememberMeOwnerDetails>");
			}
			return sb.ToString();
		}

	}




	/**
      *
      */
	public partial class ExternalRememberMeOptOutResponseType : AbstractResponseType	{

		/**
	 	  * Default Constructor
	 	  */
	 	public ExternalRememberMeOptOutResponseType(){
		}


		public ExternalRememberMeOptOutResponseType(XmlNode xmlNode) : base(xmlNode)
		{
			XmlNode ChildNode = null;
			XmlNodeList ChildNodeList = null;
	
		}
	}





}