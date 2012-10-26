using System.Xml;
using PayPal;
using PayPal.Authentication;
using PayPal.Util;
using PayPal.Manager;
using PayPal.SOAP;
using PayPal.PayPalAPIInterfaceService.Model;

namespace PayPal.PayPalAPIInterfaceService 
{
	public partial class PayPalAPIInterfaceServiceService : BasePayPalService 
	{

		// Service Version
		private const string ServiceVersion = "94.0";

		// Service Name
		private const string ServiceName = "PayPalAPIInterfaceService";
		
		//SDK Name
		private const string SDKName = "sdkname";
	
		//SDK Version
		private const string SDKVersion = "sdkversion";

		public PayPalAPIInterfaceServiceService() {}
	
		private void setStandardParams(AbstractRequestType request) {
			if (request.Version == null)
			{
				request.Version = ServiceVersion;
			}
			if (request.ErrorLanguage != null && ConfigManager.Instance.GetProperty("languageCode") != null)
			{
				request.ErrorLanguage = ConfigManager.Instance.GetProperty("languageCode");
			}
		}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public BMCreateButtonResponseType BMCreateButton(BMCreateButtonReq bMCreateButtonReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
			setStandardParams(bMCreateButtonReq.BMCreateButtonRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(bMCreateButtonReq.ToXMLString(null, "BMCreateButtonReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BMCreateButtonResponse']");
			return new BMCreateButtonResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public BMCreateButtonResponseType BMCreateButton(BMCreateButtonReq bMCreateButtonReq)
	 	{
	 		return BMCreateButton(bMCreateButtonReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public BMCreateButtonResponseType BMCreateButton(BMCreateButtonReq bMCreateButtonReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
			setStandardParams(bMCreateButtonReq.BMCreateButtonRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(bMCreateButtonReq.ToXMLString(null, "BMCreateButtonReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BMCreateButtonResponse']");
			return new BMCreateButtonResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public BMUpdateButtonResponseType BMUpdateButton(BMUpdateButtonReq bMUpdateButtonReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
			setStandardParams(bMUpdateButtonReq.BMUpdateButtonRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(bMUpdateButtonReq.ToXMLString(null, "BMUpdateButtonReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BMUpdateButtonResponse']");
			return new BMUpdateButtonResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public BMUpdateButtonResponseType BMUpdateButton(BMUpdateButtonReq bMUpdateButtonReq)
	 	{
	 		return BMUpdateButton(bMUpdateButtonReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public BMUpdateButtonResponseType BMUpdateButton(BMUpdateButtonReq bMUpdateButtonReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
			setStandardParams(bMUpdateButtonReq.BMUpdateButtonRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(bMUpdateButtonReq.ToXMLString(null, "BMUpdateButtonReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BMUpdateButtonResponse']");
			return new BMUpdateButtonResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public BMManageButtonStatusResponseType BMManageButtonStatus(BMManageButtonStatusReq bMManageButtonStatusReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
			setStandardParams(bMManageButtonStatusReq.BMManageButtonStatusRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(bMManageButtonStatusReq.ToXMLString(null, "BMManageButtonStatusReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BMManageButtonStatusResponse']");
			return new BMManageButtonStatusResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public BMManageButtonStatusResponseType BMManageButtonStatus(BMManageButtonStatusReq bMManageButtonStatusReq)
	 	{
	 		return BMManageButtonStatus(bMManageButtonStatusReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public BMManageButtonStatusResponseType BMManageButtonStatus(BMManageButtonStatusReq bMManageButtonStatusReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
			setStandardParams(bMManageButtonStatusReq.BMManageButtonStatusRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(bMManageButtonStatusReq.ToXMLString(null, "BMManageButtonStatusReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BMManageButtonStatusResponse']");
			return new BMManageButtonStatusResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public BMGetButtonDetailsResponseType BMGetButtonDetails(BMGetButtonDetailsReq bMGetButtonDetailsReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
			setStandardParams(bMGetButtonDetailsReq.BMGetButtonDetailsRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(bMGetButtonDetailsReq.ToXMLString(null, "BMGetButtonDetailsReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BMGetButtonDetailsResponse']");
			return new BMGetButtonDetailsResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public BMGetButtonDetailsResponseType BMGetButtonDetails(BMGetButtonDetailsReq bMGetButtonDetailsReq)
	 	{
	 		return BMGetButtonDetails(bMGetButtonDetailsReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public BMGetButtonDetailsResponseType BMGetButtonDetails(BMGetButtonDetailsReq bMGetButtonDetailsReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
			setStandardParams(bMGetButtonDetailsReq.BMGetButtonDetailsRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(bMGetButtonDetailsReq.ToXMLString(null, "BMGetButtonDetailsReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BMGetButtonDetailsResponse']");
			return new BMGetButtonDetailsResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public BMSetInventoryResponseType BMSetInventory(BMSetInventoryReq bMSetInventoryReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
			setStandardParams(bMSetInventoryReq.BMSetInventoryRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(bMSetInventoryReq.ToXMLString(null, "BMSetInventoryReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BMSetInventoryResponse']");
			return new BMSetInventoryResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public BMSetInventoryResponseType BMSetInventory(BMSetInventoryReq bMSetInventoryReq)
	 	{
	 		return BMSetInventory(bMSetInventoryReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public BMSetInventoryResponseType BMSetInventory(BMSetInventoryReq bMSetInventoryReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
			setStandardParams(bMSetInventoryReq.BMSetInventoryRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(bMSetInventoryReq.ToXMLString(null, "BMSetInventoryReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BMSetInventoryResponse']");
			return new BMSetInventoryResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public BMGetInventoryResponseType BMGetInventory(BMGetInventoryReq bMGetInventoryReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
			setStandardParams(bMGetInventoryReq.BMGetInventoryRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(bMGetInventoryReq.ToXMLString(null, "BMGetInventoryReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BMGetInventoryResponse']");
			return new BMGetInventoryResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public BMGetInventoryResponseType BMGetInventory(BMGetInventoryReq bMGetInventoryReq)
	 	{
	 		return BMGetInventory(bMGetInventoryReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public BMGetInventoryResponseType BMGetInventory(BMGetInventoryReq bMGetInventoryReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
			setStandardParams(bMGetInventoryReq.BMGetInventoryRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(bMGetInventoryReq.ToXMLString(null, "BMGetInventoryReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BMGetInventoryResponse']");
			return new BMGetInventoryResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public BMButtonSearchResponseType BMButtonSearch(BMButtonSearchReq bMButtonSearchReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
			setStandardParams(bMButtonSearchReq.BMButtonSearchRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(bMButtonSearchReq.ToXMLString(null, "BMButtonSearchReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BMButtonSearchResponse']");
			return new BMButtonSearchResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public BMButtonSearchResponseType BMButtonSearch(BMButtonSearchReq bMButtonSearchReq)
	 	{
	 		return BMButtonSearch(bMButtonSearchReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public BMButtonSearchResponseType BMButtonSearch(BMButtonSearchReq bMButtonSearchReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
			setStandardParams(bMButtonSearchReq.BMButtonSearchRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(bMButtonSearchReq.ToXMLString(null, "BMButtonSearchReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BMButtonSearchResponse']");
			return new BMButtonSearchResponseType(xmlNode);
			
	 	}
	}
}
