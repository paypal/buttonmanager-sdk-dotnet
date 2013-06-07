using System;
using System.Collections.Generic;
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

		/// <summary>
		/// Service Version
		/// </summary>
		private const string ServiceVersion = "98.0";

		/// <summary>
		/// Service Name
		/// </summary>
		private const string ServiceName = "PayPalAPIInterfaceService";
		
		/// <summary>
		/// SDK Name
		/// </summary>
		private const string SDKName = "buttonmanager-dotnet-sdk";
	
		/// <summary>
		/// SDK Version
		/// </summary>
		private const string SDKVersion = "2.5.103";

		/// <summary>
		/// Default constructor for loading configuration from *.Config file
		/// </summary>
		public PayPalAPIInterfaceServiceService() : base() {}
		
		/// <summary>
		/// constructor for passing in a dynamic configuration object
		/// </summary>
		public PayPalAPIInterfaceServiceService(Dictionary<string, string> config) : base(config) {}
		
	
		private void setStandardParams(AbstractRequestType request) {
			if (request.Version == null)
			{
				request.Version = ServiceVersion;
			}
			if (request.ErrorLanguage != null && this.config.ContainsKey("languageCode"))
			{
				request.ErrorLanguage = config["languageCode"];
			}
		}

		/// <summary>
		/// 
	 	/// </summary>
		///<param name="bMCreateButtonReq"></param>
		///<param name="apiUserName">API Username that you want to authenticate this call against. This username and the corresponding 3-token/certificate credentials must be available in Web.Config/App.Config</param>
	 	public BMCreateButtonResponseType BMCreateButton(BMCreateButtonReq bMCreateButtonReq, string apiUserName)
	 	{	 		
			setStandardParams(bMCreateButtonReq.BMCreateButtonRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(this.config, bMCreateButtonReq.ToXMLString(null, "BMCreateButtonReq"), null, null);
			IAPICallPreHandler apiCallPreHandler = new MerchantAPICallPreHandler(this.config, defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = "PayPalAPI";
			
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(Call(apiCallPreHandler));			
			return new BMCreateButtonResponseType(
				xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BMCreateButtonResponse']")
			);
			
	 	}
	 
	 	/// <summary> 
		/// 
	 	/// </summary>
		///<param name="bMCreateButtonReq"></param>
	 	
	 	public BMCreateButtonResponseType BMCreateButton(BMCreateButtonReq bMCreateButtonReq)
	 	{
	 		return BMCreateButton(bMCreateButtonReq,(string) null);
	 	}
	 	
	 	/// <summary>
		/// 
	 	/// </summary>
		///<param name="bMCreateButtonReq"></param>
		///<param name="credential">An explicit ICredential object that you want to authenticate this call against</param> 
	 	public BMCreateButtonResponseType BMCreateButton(BMCreateButtonReq bMCreateButtonReq, ICredential credential)
	 	{	 			 		
			setStandardParams(bMCreateButtonReq.BMCreateButtonRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(this.config, bMCreateButtonReq.ToXMLString(null, "BMCreateButtonReq"), null, null);
			IAPICallPreHandler apiCallPreHandler = new MerchantAPICallPreHandler(this.config, defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = "PayPalAPI";
			
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(Call(apiCallPreHandler));			
			return new BMCreateButtonResponseType(
				xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BMCreateButtonResponse']")
			);
			
	 	}

		/// <summary>
		/// 
	 	/// </summary>
		///<param name="bMUpdateButtonReq"></param>
		///<param name="apiUserName">API Username that you want to authenticate this call against. This username and the corresponding 3-token/certificate credentials must be available in Web.Config/App.Config</param>
	 	public BMUpdateButtonResponseType BMUpdateButton(BMUpdateButtonReq bMUpdateButtonReq, string apiUserName)
	 	{	 		
			setStandardParams(bMUpdateButtonReq.BMUpdateButtonRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(this.config, bMUpdateButtonReq.ToXMLString(null, "BMUpdateButtonReq"), null, null);
			IAPICallPreHandler apiCallPreHandler = new MerchantAPICallPreHandler(this.config, defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = "PayPalAPI";
			
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(Call(apiCallPreHandler));			
			return new BMUpdateButtonResponseType(
				xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BMUpdateButtonResponse']")
			);
			
	 	}
	 
	 	/// <summary> 
		/// 
	 	/// </summary>
		///<param name="bMUpdateButtonReq"></param>
	 	
	 	public BMUpdateButtonResponseType BMUpdateButton(BMUpdateButtonReq bMUpdateButtonReq)
	 	{
	 		return BMUpdateButton(bMUpdateButtonReq,(string) null);
	 	}
	 	
	 	/// <summary>
		/// 
	 	/// </summary>
		///<param name="bMUpdateButtonReq"></param>
		///<param name="credential">An explicit ICredential object that you want to authenticate this call against</param> 
	 	public BMUpdateButtonResponseType BMUpdateButton(BMUpdateButtonReq bMUpdateButtonReq, ICredential credential)
	 	{	 			 		
			setStandardParams(bMUpdateButtonReq.BMUpdateButtonRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(this.config, bMUpdateButtonReq.ToXMLString(null, "BMUpdateButtonReq"), null, null);
			IAPICallPreHandler apiCallPreHandler = new MerchantAPICallPreHandler(this.config, defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = "PayPalAPI";
			
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(Call(apiCallPreHandler));			
			return new BMUpdateButtonResponseType(
				xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BMUpdateButtonResponse']")
			);
			
	 	}

		/// <summary>
		/// 
	 	/// </summary>
		///<param name="bMManageButtonStatusReq"></param>
		///<param name="apiUserName">API Username that you want to authenticate this call against. This username and the corresponding 3-token/certificate credentials must be available in Web.Config/App.Config</param>
	 	public BMManageButtonStatusResponseType BMManageButtonStatus(BMManageButtonStatusReq bMManageButtonStatusReq, string apiUserName)
	 	{	 		
			setStandardParams(bMManageButtonStatusReq.BMManageButtonStatusRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(this.config, bMManageButtonStatusReq.ToXMLString(null, "BMManageButtonStatusReq"), null, null);
			IAPICallPreHandler apiCallPreHandler = new MerchantAPICallPreHandler(this.config, defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = "PayPalAPI";
			
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(Call(apiCallPreHandler));			
			return new BMManageButtonStatusResponseType(
				xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BMManageButtonStatusResponse']")
			);
			
	 	}
	 
	 	/// <summary> 
		/// 
	 	/// </summary>
		///<param name="bMManageButtonStatusReq"></param>
	 	
	 	public BMManageButtonStatusResponseType BMManageButtonStatus(BMManageButtonStatusReq bMManageButtonStatusReq)
	 	{
	 		return BMManageButtonStatus(bMManageButtonStatusReq,(string) null);
	 	}
	 	
	 	/// <summary>
		/// 
	 	/// </summary>
		///<param name="bMManageButtonStatusReq"></param>
		///<param name="credential">An explicit ICredential object that you want to authenticate this call against</param> 
	 	public BMManageButtonStatusResponseType BMManageButtonStatus(BMManageButtonStatusReq bMManageButtonStatusReq, ICredential credential)
	 	{	 			 		
			setStandardParams(bMManageButtonStatusReq.BMManageButtonStatusRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(this.config, bMManageButtonStatusReq.ToXMLString(null, "BMManageButtonStatusReq"), null, null);
			IAPICallPreHandler apiCallPreHandler = new MerchantAPICallPreHandler(this.config, defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = "PayPalAPI";
			
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(Call(apiCallPreHandler));			
			return new BMManageButtonStatusResponseType(
				xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BMManageButtonStatusResponse']")
			);
			
	 	}

		/// <summary>
		/// 
	 	/// </summary>
		///<param name="bMGetButtonDetailsReq"></param>
		///<param name="apiUserName">API Username that you want to authenticate this call against. This username and the corresponding 3-token/certificate credentials must be available in Web.Config/App.Config</param>
	 	public BMGetButtonDetailsResponseType BMGetButtonDetails(BMGetButtonDetailsReq bMGetButtonDetailsReq, string apiUserName)
	 	{	 		
			setStandardParams(bMGetButtonDetailsReq.BMGetButtonDetailsRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(this.config, bMGetButtonDetailsReq.ToXMLString(null, "BMGetButtonDetailsReq"), null, null);
			IAPICallPreHandler apiCallPreHandler = new MerchantAPICallPreHandler(this.config, defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = "PayPalAPI";
			
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(Call(apiCallPreHandler));			
			return new BMGetButtonDetailsResponseType(
				xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BMGetButtonDetailsResponse']")
			);
			
	 	}
	 
	 	/// <summary> 
		/// 
	 	/// </summary>
		///<param name="bMGetButtonDetailsReq"></param>
	 	
	 	public BMGetButtonDetailsResponseType BMGetButtonDetails(BMGetButtonDetailsReq bMGetButtonDetailsReq)
	 	{
	 		return BMGetButtonDetails(bMGetButtonDetailsReq,(string) null);
	 	}
	 	
	 	/// <summary>
		/// 
	 	/// </summary>
		///<param name="bMGetButtonDetailsReq"></param>
		///<param name="credential">An explicit ICredential object that you want to authenticate this call against</param> 
	 	public BMGetButtonDetailsResponseType BMGetButtonDetails(BMGetButtonDetailsReq bMGetButtonDetailsReq, ICredential credential)
	 	{	 			 		
			setStandardParams(bMGetButtonDetailsReq.BMGetButtonDetailsRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(this.config, bMGetButtonDetailsReq.ToXMLString(null, "BMGetButtonDetailsReq"), null, null);
			IAPICallPreHandler apiCallPreHandler = new MerchantAPICallPreHandler(this.config, defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = "PayPalAPI";
			
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(Call(apiCallPreHandler));			
			return new BMGetButtonDetailsResponseType(
				xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BMGetButtonDetailsResponse']")
			);
			
	 	}

		/// <summary>
		/// 
	 	/// </summary>
		///<param name="bMSetInventoryReq"></param>
		///<param name="apiUserName">API Username that you want to authenticate this call against. This username and the corresponding 3-token/certificate credentials must be available in Web.Config/App.Config</param>
	 	public BMSetInventoryResponseType BMSetInventory(BMSetInventoryReq bMSetInventoryReq, string apiUserName)
	 	{	 		
			setStandardParams(bMSetInventoryReq.BMSetInventoryRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(this.config, bMSetInventoryReq.ToXMLString(null, "BMSetInventoryReq"), null, null);
			IAPICallPreHandler apiCallPreHandler = new MerchantAPICallPreHandler(this.config, defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = "PayPalAPI";
			
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(Call(apiCallPreHandler));			
			return new BMSetInventoryResponseType(
				xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BMSetInventoryResponse']")
			);
			
	 	}
	 
	 	/// <summary> 
		/// 
	 	/// </summary>
		///<param name="bMSetInventoryReq"></param>
	 	
	 	public BMSetInventoryResponseType BMSetInventory(BMSetInventoryReq bMSetInventoryReq)
	 	{
	 		return BMSetInventory(bMSetInventoryReq,(string) null);
	 	}
	 	
	 	/// <summary>
		/// 
	 	/// </summary>
		///<param name="bMSetInventoryReq"></param>
		///<param name="credential">An explicit ICredential object that you want to authenticate this call against</param> 
	 	public BMSetInventoryResponseType BMSetInventory(BMSetInventoryReq bMSetInventoryReq, ICredential credential)
	 	{	 			 		
			setStandardParams(bMSetInventoryReq.BMSetInventoryRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(this.config, bMSetInventoryReq.ToXMLString(null, "BMSetInventoryReq"), null, null);
			IAPICallPreHandler apiCallPreHandler = new MerchantAPICallPreHandler(this.config, defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = "PayPalAPI";
			
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(Call(apiCallPreHandler));			
			return new BMSetInventoryResponseType(
				xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BMSetInventoryResponse']")
			);
			
	 	}

		/// <summary>
		/// 
	 	/// </summary>
		///<param name="bMGetInventoryReq"></param>
		///<param name="apiUserName">API Username that you want to authenticate this call against. This username and the corresponding 3-token/certificate credentials must be available in Web.Config/App.Config</param>
	 	public BMGetInventoryResponseType BMGetInventory(BMGetInventoryReq bMGetInventoryReq, string apiUserName)
	 	{	 		
			setStandardParams(bMGetInventoryReq.BMGetInventoryRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(this.config, bMGetInventoryReq.ToXMLString(null, "BMGetInventoryReq"), null, null);
			IAPICallPreHandler apiCallPreHandler = new MerchantAPICallPreHandler(this.config, defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = "PayPalAPI";
			
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(Call(apiCallPreHandler));			
			return new BMGetInventoryResponseType(
				xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BMGetInventoryResponse']")
			);
			
	 	}
	 
	 	/// <summary> 
		/// 
	 	/// </summary>
		///<param name="bMGetInventoryReq"></param>
	 	
	 	public BMGetInventoryResponseType BMGetInventory(BMGetInventoryReq bMGetInventoryReq)
	 	{
	 		return BMGetInventory(bMGetInventoryReq,(string) null);
	 	}
	 	
	 	/// <summary>
		/// 
	 	/// </summary>
		///<param name="bMGetInventoryReq"></param>
		///<param name="credential">An explicit ICredential object that you want to authenticate this call against</param> 
	 	public BMGetInventoryResponseType BMGetInventory(BMGetInventoryReq bMGetInventoryReq, ICredential credential)
	 	{	 			 		
			setStandardParams(bMGetInventoryReq.BMGetInventoryRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(this.config, bMGetInventoryReq.ToXMLString(null, "BMGetInventoryReq"), null, null);
			IAPICallPreHandler apiCallPreHandler = new MerchantAPICallPreHandler(this.config, defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = "PayPalAPI";
			
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(Call(apiCallPreHandler));			
			return new BMGetInventoryResponseType(
				xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BMGetInventoryResponse']")
			);
			
	 	}

		/// <summary>
		/// 
	 	/// </summary>
		///<param name="bMButtonSearchReq"></param>
		///<param name="apiUserName">API Username that you want to authenticate this call against. This username and the corresponding 3-token/certificate credentials must be available in Web.Config/App.Config</param>
	 	public BMButtonSearchResponseType BMButtonSearch(BMButtonSearchReq bMButtonSearchReq, string apiUserName)
	 	{	 		
			setStandardParams(bMButtonSearchReq.BMButtonSearchRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(this.config, bMButtonSearchReq.ToXMLString(null, "BMButtonSearchReq"), null, null);
			IAPICallPreHandler apiCallPreHandler = new MerchantAPICallPreHandler(this.config, defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = "PayPalAPI";
			
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(Call(apiCallPreHandler));			
			return new BMButtonSearchResponseType(
				xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BMButtonSearchResponse']")
			);
			
	 	}
	 
	 	/// <summary> 
		/// 
	 	/// </summary>
		///<param name="bMButtonSearchReq"></param>
	 	
	 	public BMButtonSearchResponseType BMButtonSearch(BMButtonSearchReq bMButtonSearchReq)
	 	{
	 		return BMButtonSearch(bMButtonSearchReq,(string) null);
	 	}
	 	
	 	/// <summary>
		/// 
	 	/// </summary>
		///<param name="bMButtonSearchReq"></param>
		///<param name="credential">An explicit ICredential object that you want to authenticate this call against</param> 
	 	public BMButtonSearchResponseType BMButtonSearch(BMButtonSearchReq bMButtonSearchReq, ICredential credential)
	 	{	 			 		
			setStandardParams(bMButtonSearchReq.BMButtonSearchRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(this.config, bMButtonSearchReq.ToXMLString(null, "BMButtonSearchReq"), null, null);
			IAPICallPreHandler apiCallPreHandler = new MerchantAPICallPreHandler(this.config, defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = "PayPalAPI";
			
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(Call(apiCallPreHandler));			
			return new BMButtonSearchResponseType(
				xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BMButtonSearchResponse']")
			);
			
	 	}
	}
}
