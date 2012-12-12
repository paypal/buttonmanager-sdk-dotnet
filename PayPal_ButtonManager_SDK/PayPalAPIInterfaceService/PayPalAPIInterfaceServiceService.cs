using System;
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
	 	public RefundTransactionResponseType RefundTransaction(RefundTransactionReq refundTransactionReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(refundTransactionReq.RefundTransactionRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(refundTransactionReq.ToXMLString(null, "RefundTransactionReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='RefundTransactionResponse']");
			return new RefundTransactionResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public RefundTransactionResponseType RefundTransaction(RefundTransactionReq refundTransactionReq)
	 	{
	 		return RefundTransaction(refundTransactionReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public RefundTransactionResponseType RefundTransaction(RefundTransactionReq refundTransactionReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(refundTransactionReq.RefundTransactionRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(refundTransactionReq.ToXMLString(null, "RefundTransactionReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='RefundTransactionResponse']");
			return new RefundTransactionResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public InitiateRecoupResponseType InitiateRecoup(InitiateRecoupReq initiateRecoupReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(initiateRecoupReq.InitiateRecoupRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(initiateRecoupReq.ToXMLString(null, "InitiateRecoupReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='InitiateRecoupResponse']");
			return new InitiateRecoupResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public InitiateRecoupResponseType InitiateRecoup(InitiateRecoupReq initiateRecoupReq)
	 	{
	 		return InitiateRecoup(initiateRecoupReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public InitiateRecoupResponseType InitiateRecoup(InitiateRecoupReq initiateRecoupReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(initiateRecoupReq.InitiateRecoupRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(initiateRecoupReq.ToXMLString(null, "InitiateRecoupReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='InitiateRecoupResponse']");
			return new InitiateRecoupResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public CompleteRecoupResponseType CompleteRecoup(CompleteRecoupReq completeRecoupReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(completeRecoupReq.CompleteRecoupRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(completeRecoupReq.ToXMLString(null, "CompleteRecoupReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='CompleteRecoupResponse']");
			return new CompleteRecoupResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public CompleteRecoupResponseType CompleteRecoup(CompleteRecoupReq completeRecoupReq)
	 	{
	 		return CompleteRecoup(completeRecoupReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public CompleteRecoupResponseType CompleteRecoup(CompleteRecoupReq completeRecoupReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(completeRecoupReq.CompleteRecoupRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(completeRecoupReq.ToXMLString(null, "CompleteRecoupReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='CompleteRecoupResponse']");
			return new CompleteRecoupResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public CancelRecoupResponseType CancelRecoup(CancelRecoupReq cancelRecoupReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(cancelRecoupReq.CancelRecoupRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(cancelRecoupReq.ToXMLString(null, "CancelRecoupReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='CancelRecoupResponse']");
			return new CancelRecoupResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public CancelRecoupResponseType CancelRecoup(CancelRecoupReq cancelRecoupReq)
	 	{
	 		return CancelRecoup(cancelRecoupReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public CancelRecoupResponseType CancelRecoup(CancelRecoupReq cancelRecoupReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(cancelRecoupReq.CancelRecoupRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(cancelRecoupReq.ToXMLString(null, "CancelRecoupReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='CancelRecoupResponse']");
			return new CancelRecoupResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public GetTransactionDetailsResponseType GetTransactionDetails(GetTransactionDetailsReq getTransactionDetailsReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(getTransactionDetailsReq.GetTransactionDetailsRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(getTransactionDetailsReq.ToXMLString(null, "GetTransactionDetailsReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='GetTransactionDetailsResponse']");
			return new GetTransactionDetailsResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public GetTransactionDetailsResponseType GetTransactionDetails(GetTransactionDetailsReq getTransactionDetailsReq)
	 	{
	 		return GetTransactionDetails(getTransactionDetailsReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public GetTransactionDetailsResponseType GetTransactionDetails(GetTransactionDetailsReq getTransactionDetailsReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(getTransactionDetailsReq.GetTransactionDetailsRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(getTransactionDetailsReq.ToXMLString(null, "GetTransactionDetailsReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='GetTransactionDetailsResponse']");
			return new GetTransactionDetailsResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public BMCreateButtonResponseType BMCreateButton(BMCreateButtonReq bMCreateButtonReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(bMCreateButtonReq.BMCreateButtonRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(bMCreateButtonReq.ToXMLString(null, "BMCreateButtonReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
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
	 		string portName = "PayPalAPI";
			setStandardParams(bMCreateButtonReq.BMCreateButtonRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(bMCreateButtonReq.ToXMLString(null, "BMCreateButtonReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
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
	 		string portName = "PayPalAPI";
			setStandardParams(bMUpdateButtonReq.BMUpdateButtonRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(bMUpdateButtonReq.ToXMLString(null, "BMUpdateButtonReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
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
	 		string portName = "PayPalAPI";
			setStandardParams(bMUpdateButtonReq.BMUpdateButtonRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(bMUpdateButtonReq.ToXMLString(null, "BMUpdateButtonReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
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
	 		string portName = "PayPalAPI";
			setStandardParams(bMManageButtonStatusReq.BMManageButtonStatusRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(bMManageButtonStatusReq.ToXMLString(null, "BMManageButtonStatusReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
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
	 		string portName = "PayPalAPI";
			setStandardParams(bMManageButtonStatusReq.BMManageButtonStatusRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(bMManageButtonStatusReq.ToXMLString(null, "BMManageButtonStatusReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
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
	 		string portName = "PayPalAPI";
			setStandardParams(bMGetButtonDetailsReq.BMGetButtonDetailsRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(bMGetButtonDetailsReq.ToXMLString(null, "BMGetButtonDetailsReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
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
	 		string portName = "PayPalAPI";
			setStandardParams(bMGetButtonDetailsReq.BMGetButtonDetailsRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(bMGetButtonDetailsReq.ToXMLString(null, "BMGetButtonDetailsReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
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
	 		string portName = "PayPalAPI";
			setStandardParams(bMSetInventoryReq.BMSetInventoryRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(bMSetInventoryReq.ToXMLString(null, "BMSetInventoryReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
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
	 		string portName = "PayPalAPI";
			setStandardParams(bMSetInventoryReq.BMSetInventoryRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(bMSetInventoryReq.ToXMLString(null, "BMSetInventoryReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
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
	 		string portName = "PayPalAPI";
			setStandardParams(bMGetInventoryReq.BMGetInventoryRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(bMGetInventoryReq.ToXMLString(null, "BMGetInventoryReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
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
	 		string portName = "PayPalAPI";
			setStandardParams(bMGetInventoryReq.BMGetInventoryRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(bMGetInventoryReq.ToXMLString(null, "BMGetInventoryReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
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
	 		string portName = "PayPalAPI";
			setStandardParams(bMButtonSearchReq.BMButtonSearchRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(bMButtonSearchReq.ToXMLString(null, "BMButtonSearchReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
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
	 		string portName = "PayPalAPI";
			setStandardParams(bMButtonSearchReq.BMButtonSearchRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(bMButtonSearchReq.ToXMLString(null, "BMButtonSearchReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BMButtonSearchResponse']");
			return new BMButtonSearchResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public BillUserResponseType BillUser(BillUserReq billUserReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(billUserReq.BillUserRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(billUserReq.ToXMLString(null, "BillUserReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BillUserResponse']");
			return new BillUserResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public BillUserResponseType BillUser(BillUserReq billUserReq)
	 	{
	 		return BillUser(billUserReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public BillUserResponseType BillUser(BillUserReq billUserReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(billUserReq.BillUserRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(billUserReq.ToXMLString(null, "BillUserReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BillUserResponse']");
			return new BillUserResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public TransactionSearchResponseType TransactionSearch(TransactionSearchReq transactionSearchReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(transactionSearchReq.TransactionSearchRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(transactionSearchReq.ToXMLString(null, "TransactionSearchReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='TransactionSearchResponse']");
			return new TransactionSearchResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public TransactionSearchResponseType TransactionSearch(TransactionSearchReq transactionSearchReq)
	 	{
	 		return TransactionSearch(transactionSearchReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public TransactionSearchResponseType TransactionSearch(TransactionSearchReq transactionSearchReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(transactionSearchReq.TransactionSearchRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(transactionSearchReq.ToXMLString(null, "TransactionSearchReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='TransactionSearchResponse']");
			return new TransactionSearchResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public MassPayResponseType MassPay(MassPayReq massPayReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(massPayReq.MassPayRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(massPayReq.ToXMLString(null, "MassPayReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='MassPayResponse']");
			return new MassPayResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public MassPayResponseType MassPay(MassPayReq massPayReq)
	 	{
	 		return MassPay(massPayReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public MassPayResponseType MassPay(MassPayReq massPayReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(massPayReq.MassPayRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(massPayReq.ToXMLString(null, "MassPayReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='MassPayResponse']");
			return new MassPayResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public BAUpdateResponseType BillAgreementUpdate(BillAgreementUpdateReq billAgreementUpdateReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(billAgreementUpdateReq.BAUpdateRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(billAgreementUpdateReq.ToXMLString(null, "BillAgreementUpdateReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BAUpdateResponse']");
			return new BAUpdateResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public BAUpdateResponseType BillAgreementUpdate(BillAgreementUpdateReq billAgreementUpdateReq)
	 	{
	 		return BillAgreementUpdate(billAgreementUpdateReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public BAUpdateResponseType BillAgreementUpdate(BillAgreementUpdateReq billAgreementUpdateReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(billAgreementUpdateReq.BAUpdateRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(billAgreementUpdateReq.ToXMLString(null, "BillAgreementUpdateReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BAUpdateResponse']");
			return new BAUpdateResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public AddressVerifyResponseType AddressVerify(AddressVerifyReq addressVerifyReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(addressVerifyReq.AddressVerifyRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(addressVerifyReq.ToXMLString(null, "AddressVerifyReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='AddressVerifyResponse']");
			return new AddressVerifyResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public AddressVerifyResponseType AddressVerify(AddressVerifyReq addressVerifyReq)
	 	{
	 		return AddressVerify(addressVerifyReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public AddressVerifyResponseType AddressVerify(AddressVerifyReq addressVerifyReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(addressVerifyReq.AddressVerifyRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(addressVerifyReq.ToXMLString(null, "AddressVerifyReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='AddressVerifyResponse']");
			return new AddressVerifyResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public EnterBoardingResponseType EnterBoarding(EnterBoardingReq enterBoardingReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(enterBoardingReq.EnterBoardingRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(enterBoardingReq.ToXMLString(null, "EnterBoardingReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='EnterBoardingResponse']");
			return new EnterBoardingResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public EnterBoardingResponseType EnterBoarding(EnterBoardingReq enterBoardingReq)
	 	{
	 		return EnterBoarding(enterBoardingReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public EnterBoardingResponseType EnterBoarding(EnterBoardingReq enterBoardingReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(enterBoardingReq.EnterBoardingRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(enterBoardingReq.ToXMLString(null, "EnterBoardingReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='EnterBoardingResponse']");
			return new EnterBoardingResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public GetBoardingDetailsResponseType GetBoardingDetails(GetBoardingDetailsReq getBoardingDetailsReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(getBoardingDetailsReq.GetBoardingDetailsRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(getBoardingDetailsReq.ToXMLString(null, "GetBoardingDetailsReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='GetBoardingDetailsResponse']");
			return new GetBoardingDetailsResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public GetBoardingDetailsResponseType GetBoardingDetails(GetBoardingDetailsReq getBoardingDetailsReq)
	 	{
	 		return GetBoardingDetails(getBoardingDetailsReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public GetBoardingDetailsResponseType GetBoardingDetails(GetBoardingDetailsReq getBoardingDetailsReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(getBoardingDetailsReq.GetBoardingDetailsRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(getBoardingDetailsReq.ToXMLString(null, "GetBoardingDetailsReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='GetBoardingDetailsResponse']");
			return new GetBoardingDetailsResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public CreateMobilePaymentResponseType CreateMobilePayment(CreateMobilePaymentReq createMobilePaymentReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(createMobilePaymentReq.CreateMobilePaymentRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(createMobilePaymentReq.ToXMLString(null, "CreateMobilePaymentReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='CreateMobilePaymentResponse']");
			return new CreateMobilePaymentResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public CreateMobilePaymentResponseType CreateMobilePayment(CreateMobilePaymentReq createMobilePaymentReq)
	 	{
	 		return CreateMobilePayment(createMobilePaymentReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public CreateMobilePaymentResponseType CreateMobilePayment(CreateMobilePaymentReq createMobilePaymentReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(createMobilePaymentReq.CreateMobilePaymentRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(createMobilePaymentReq.ToXMLString(null, "CreateMobilePaymentReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='CreateMobilePaymentResponse']");
			return new CreateMobilePaymentResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public GetMobileStatusResponseType GetMobileStatus(GetMobileStatusReq getMobileStatusReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(getMobileStatusReq.GetMobileStatusRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(getMobileStatusReq.ToXMLString(null, "GetMobileStatusReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='GetMobileStatusResponse']");
			return new GetMobileStatusResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public GetMobileStatusResponseType GetMobileStatus(GetMobileStatusReq getMobileStatusReq)
	 	{
	 		return GetMobileStatus(getMobileStatusReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public GetMobileStatusResponseType GetMobileStatus(GetMobileStatusReq getMobileStatusReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(getMobileStatusReq.GetMobileStatusRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(getMobileStatusReq.ToXMLString(null, "GetMobileStatusReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='GetMobileStatusResponse']");
			return new GetMobileStatusResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public SetMobileCheckoutResponseType SetMobileCheckout(SetMobileCheckoutReq setMobileCheckoutReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(setMobileCheckoutReq.SetMobileCheckoutRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(setMobileCheckoutReq.ToXMLString(null, "SetMobileCheckoutReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='SetMobileCheckoutResponse']");
			return new SetMobileCheckoutResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public SetMobileCheckoutResponseType SetMobileCheckout(SetMobileCheckoutReq setMobileCheckoutReq)
	 	{
	 		return SetMobileCheckout(setMobileCheckoutReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public SetMobileCheckoutResponseType SetMobileCheckout(SetMobileCheckoutReq setMobileCheckoutReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(setMobileCheckoutReq.SetMobileCheckoutRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(setMobileCheckoutReq.ToXMLString(null, "SetMobileCheckoutReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='SetMobileCheckoutResponse']");
			return new SetMobileCheckoutResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public DoMobileCheckoutPaymentResponseType DoMobileCheckoutPayment(DoMobileCheckoutPaymentReq doMobileCheckoutPaymentReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(doMobileCheckoutPaymentReq.DoMobileCheckoutPaymentRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(doMobileCheckoutPaymentReq.ToXMLString(null, "DoMobileCheckoutPaymentReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='DoMobileCheckoutPaymentResponse']");
			return new DoMobileCheckoutPaymentResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public DoMobileCheckoutPaymentResponseType DoMobileCheckoutPayment(DoMobileCheckoutPaymentReq doMobileCheckoutPaymentReq)
	 	{
	 		return DoMobileCheckoutPayment(doMobileCheckoutPaymentReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public DoMobileCheckoutPaymentResponseType DoMobileCheckoutPayment(DoMobileCheckoutPaymentReq doMobileCheckoutPaymentReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(doMobileCheckoutPaymentReq.DoMobileCheckoutPaymentRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(doMobileCheckoutPaymentReq.ToXMLString(null, "DoMobileCheckoutPaymentReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='DoMobileCheckoutPaymentResponse']");
			return new DoMobileCheckoutPaymentResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public GetBalanceResponseType GetBalance(GetBalanceReq getBalanceReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(getBalanceReq.GetBalanceRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(getBalanceReq.ToXMLString(null, "GetBalanceReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='GetBalanceResponse']");
			return new GetBalanceResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public GetBalanceResponseType GetBalance(GetBalanceReq getBalanceReq)
	 	{
	 		return GetBalance(getBalanceReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public GetBalanceResponseType GetBalance(GetBalanceReq getBalanceReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(getBalanceReq.GetBalanceRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(getBalanceReq.ToXMLString(null, "GetBalanceReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='GetBalanceResponse']");
			return new GetBalanceResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public GetPalDetailsResponseType GetPalDetails(GetPalDetailsReq getPalDetailsReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(getPalDetailsReq.GetPalDetailsRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(getPalDetailsReq.ToXMLString(null, "GetPalDetailsReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='GetPalDetailsResponse']");
			return new GetPalDetailsResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public GetPalDetailsResponseType GetPalDetails(GetPalDetailsReq getPalDetailsReq)
	 	{
	 		return GetPalDetails(getPalDetailsReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public GetPalDetailsResponseType GetPalDetails(GetPalDetailsReq getPalDetailsReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPI";
			setStandardParams(getPalDetailsReq.GetPalDetailsRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(getPalDetailsReq.ToXMLString(null, "GetPalDetailsReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='GetPalDetailsResponse']");
			return new GetPalDetailsResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public DoExpressCheckoutPaymentResponseType DoExpressCheckoutPayment(DoExpressCheckoutPaymentReq doExpressCheckoutPaymentReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(doExpressCheckoutPaymentReq.DoExpressCheckoutPaymentRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(doExpressCheckoutPaymentReq.ToXMLString(null, "DoExpressCheckoutPaymentReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='DoExpressCheckoutPaymentResponse']");
			return new DoExpressCheckoutPaymentResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public DoExpressCheckoutPaymentResponseType DoExpressCheckoutPayment(DoExpressCheckoutPaymentReq doExpressCheckoutPaymentReq)
	 	{
	 		return DoExpressCheckoutPayment(doExpressCheckoutPaymentReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public DoExpressCheckoutPaymentResponseType DoExpressCheckoutPayment(DoExpressCheckoutPaymentReq doExpressCheckoutPaymentReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(doExpressCheckoutPaymentReq.DoExpressCheckoutPaymentRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(doExpressCheckoutPaymentReq.ToXMLString(null, "DoExpressCheckoutPaymentReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='DoExpressCheckoutPaymentResponse']");
			return new DoExpressCheckoutPaymentResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public DoUATPExpressCheckoutPaymentResponseType DoUATPExpressCheckoutPayment(DoUATPExpressCheckoutPaymentReq doUATPExpressCheckoutPaymentReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(doUATPExpressCheckoutPaymentReq.DoUATPExpressCheckoutPaymentRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(doUATPExpressCheckoutPaymentReq.ToXMLString(null, "DoUATPExpressCheckoutPaymentReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='DoUATPExpressCheckoutPaymentResponse']");
			return new DoUATPExpressCheckoutPaymentResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public DoUATPExpressCheckoutPaymentResponseType DoUATPExpressCheckoutPayment(DoUATPExpressCheckoutPaymentReq doUATPExpressCheckoutPaymentReq)
	 	{
	 		return DoUATPExpressCheckoutPayment(doUATPExpressCheckoutPaymentReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public DoUATPExpressCheckoutPaymentResponseType DoUATPExpressCheckoutPayment(DoUATPExpressCheckoutPaymentReq doUATPExpressCheckoutPaymentReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(doUATPExpressCheckoutPaymentReq.DoUATPExpressCheckoutPaymentRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(doUATPExpressCheckoutPaymentReq.ToXMLString(null, "DoUATPExpressCheckoutPaymentReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='DoUATPExpressCheckoutPaymentResponse']");
			return new DoUATPExpressCheckoutPaymentResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public SetAuthFlowParamResponseType SetAuthFlowParam(SetAuthFlowParamReq setAuthFlowParamReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(setAuthFlowParamReq.SetAuthFlowParamRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(setAuthFlowParamReq.ToXMLString(null, "SetAuthFlowParamReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='SetAuthFlowParamResponse']");
			return new SetAuthFlowParamResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public SetAuthFlowParamResponseType SetAuthFlowParam(SetAuthFlowParamReq setAuthFlowParamReq)
	 	{
	 		return SetAuthFlowParam(setAuthFlowParamReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public SetAuthFlowParamResponseType SetAuthFlowParam(SetAuthFlowParamReq setAuthFlowParamReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(setAuthFlowParamReq.SetAuthFlowParamRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(setAuthFlowParamReq.ToXMLString(null, "SetAuthFlowParamReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='SetAuthFlowParamResponse']");
			return new SetAuthFlowParamResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public GetAuthDetailsResponseType GetAuthDetails(GetAuthDetailsReq getAuthDetailsReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(getAuthDetailsReq.GetAuthDetailsRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(getAuthDetailsReq.ToXMLString(null, "GetAuthDetailsReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='GetAuthDetailsResponse']");
			return new GetAuthDetailsResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public GetAuthDetailsResponseType GetAuthDetails(GetAuthDetailsReq getAuthDetailsReq)
	 	{
	 		return GetAuthDetails(getAuthDetailsReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public GetAuthDetailsResponseType GetAuthDetails(GetAuthDetailsReq getAuthDetailsReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(getAuthDetailsReq.GetAuthDetailsRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(getAuthDetailsReq.ToXMLString(null, "GetAuthDetailsReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='GetAuthDetailsResponse']");
			return new GetAuthDetailsResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public SetAccessPermissionsResponseType SetAccessPermissions(SetAccessPermissionsReq setAccessPermissionsReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(setAccessPermissionsReq.SetAccessPermissionsRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(setAccessPermissionsReq.ToXMLString(null, "SetAccessPermissionsReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='SetAccessPermissionsResponse']");
			return new SetAccessPermissionsResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public SetAccessPermissionsResponseType SetAccessPermissions(SetAccessPermissionsReq setAccessPermissionsReq)
	 	{
	 		return SetAccessPermissions(setAccessPermissionsReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public SetAccessPermissionsResponseType SetAccessPermissions(SetAccessPermissionsReq setAccessPermissionsReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(setAccessPermissionsReq.SetAccessPermissionsRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(setAccessPermissionsReq.ToXMLString(null, "SetAccessPermissionsReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='SetAccessPermissionsResponse']");
			return new SetAccessPermissionsResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public UpdateAccessPermissionsResponseType UpdateAccessPermissions(UpdateAccessPermissionsReq updateAccessPermissionsReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(updateAccessPermissionsReq.UpdateAccessPermissionsRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(updateAccessPermissionsReq.ToXMLString(null, "UpdateAccessPermissionsReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='UpdateAccessPermissionsResponse']");
			return new UpdateAccessPermissionsResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public UpdateAccessPermissionsResponseType UpdateAccessPermissions(UpdateAccessPermissionsReq updateAccessPermissionsReq)
	 	{
	 		return UpdateAccessPermissions(updateAccessPermissionsReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public UpdateAccessPermissionsResponseType UpdateAccessPermissions(UpdateAccessPermissionsReq updateAccessPermissionsReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(updateAccessPermissionsReq.UpdateAccessPermissionsRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(updateAccessPermissionsReq.ToXMLString(null, "UpdateAccessPermissionsReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='UpdateAccessPermissionsResponse']");
			return new UpdateAccessPermissionsResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public GetAccessPermissionDetailsResponseType GetAccessPermissionDetails(GetAccessPermissionDetailsReq getAccessPermissionDetailsReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(getAccessPermissionDetailsReq.GetAccessPermissionDetailsRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(getAccessPermissionDetailsReq.ToXMLString(null, "GetAccessPermissionDetailsReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='GetAccessPermissionDetailsResponse']");
			return new GetAccessPermissionDetailsResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public GetAccessPermissionDetailsResponseType GetAccessPermissionDetails(GetAccessPermissionDetailsReq getAccessPermissionDetailsReq)
	 	{
	 		return GetAccessPermissionDetails(getAccessPermissionDetailsReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public GetAccessPermissionDetailsResponseType GetAccessPermissionDetails(GetAccessPermissionDetailsReq getAccessPermissionDetailsReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(getAccessPermissionDetailsReq.GetAccessPermissionDetailsRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(getAccessPermissionDetailsReq.ToXMLString(null, "GetAccessPermissionDetailsReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='GetAccessPermissionDetailsResponse']");
			return new GetAccessPermissionDetailsResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public GetIncentiveEvaluationResponseType GetIncentiveEvaluation(GetIncentiveEvaluationReq getIncentiveEvaluationReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(getIncentiveEvaluationReq.GetIncentiveEvaluationRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(getIncentiveEvaluationReq.ToXMLString(null, "GetIncentiveEvaluationReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='GetIncentiveEvaluationResponse']");
			return new GetIncentiveEvaluationResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public GetIncentiveEvaluationResponseType GetIncentiveEvaluation(GetIncentiveEvaluationReq getIncentiveEvaluationReq)
	 	{
	 		return GetIncentiveEvaluation(getIncentiveEvaluationReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public GetIncentiveEvaluationResponseType GetIncentiveEvaluation(GetIncentiveEvaluationReq getIncentiveEvaluationReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(getIncentiveEvaluationReq.GetIncentiveEvaluationRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(getIncentiveEvaluationReq.ToXMLString(null, "GetIncentiveEvaluationReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='GetIncentiveEvaluationResponse']");
			return new GetIncentiveEvaluationResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public SetExpressCheckoutResponseType SetExpressCheckout(SetExpressCheckoutReq setExpressCheckoutReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(setExpressCheckoutReq.SetExpressCheckoutRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(setExpressCheckoutReq.ToXMLString(null, "SetExpressCheckoutReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='SetExpressCheckoutResponse']");
			return new SetExpressCheckoutResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public SetExpressCheckoutResponseType SetExpressCheckout(SetExpressCheckoutReq setExpressCheckoutReq)
	 	{
	 		return SetExpressCheckout(setExpressCheckoutReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public SetExpressCheckoutResponseType SetExpressCheckout(SetExpressCheckoutReq setExpressCheckoutReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(setExpressCheckoutReq.SetExpressCheckoutRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(setExpressCheckoutReq.ToXMLString(null, "SetExpressCheckoutReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='SetExpressCheckoutResponse']");
			return new SetExpressCheckoutResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public ExecuteCheckoutOperationsResponseType ExecuteCheckoutOperations(ExecuteCheckoutOperationsReq executeCheckoutOperationsReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(executeCheckoutOperationsReq.ExecuteCheckoutOperationsRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(executeCheckoutOperationsReq.ToXMLString(null, "ExecuteCheckoutOperationsReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='ExecuteCheckoutOperationsResponse']");
			return new ExecuteCheckoutOperationsResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public ExecuteCheckoutOperationsResponseType ExecuteCheckoutOperations(ExecuteCheckoutOperationsReq executeCheckoutOperationsReq)
	 	{
	 		return ExecuteCheckoutOperations(executeCheckoutOperationsReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public ExecuteCheckoutOperationsResponseType ExecuteCheckoutOperations(ExecuteCheckoutOperationsReq executeCheckoutOperationsReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(executeCheckoutOperationsReq.ExecuteCheckoutOperationsRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(executeCheckoutOperationsReq.ToXMLString(null, "ExecuteCheckoutOperationsReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='ExecuteCheckoutOperationsResponse']");
			return new ExecuteCheckoutOperationsResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public GetExpressCheckoutDetailsResponseType GetExpressCheckoutDetails(GetExpressCheckoutDetailsReq getExpressCheckoutDetailsReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(getExpressCheckoutDetailsReq.GetExpressCheckoutDetailsRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(getExpressCheckoutDetailsReq.ToXMLString(null, "GetExpressCheckoutDetailsReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='GetExpressCheckoutDetailsResponse']");
			return new GetExpressCheckoutDetailsResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public GetExpressCheckoutDetailsResponseType GetExpressCheckoutDetails(GetExpressCheckoutDetailsReq getExpressCheckoutDetailsReq)
	 	{
	 		return GetExpressCheckoutDetails(getExpressCheckoutDetailsReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public GetExpressCheckoutDetailsResponseType GetExpressCheckoutDetails(GetExpressCheckoutDetailsReq getExpressCheckoutDetailsReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(getExpressCheckoutDetailsReq.GetExpressCheckoutDetailsRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(getExpressCheckoutDetailsReq.ToXMLString(null, "GetExpressCheckoutDetailsReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='GetExpressCheckoutDetailsResponse']");
			return new GetExpressCheckoutDetailsResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public DoDirectPaymentResponseType DoDirectPayment(DoDirectPaymentReq doDirectPaymentReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(doDirectPaymentReq.DoDirectPaymentRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(doDirectPaymentReq.ToXMLString(null, "DoDirectPaymentReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='DoDirectPaymentResponse']");
			return new DoDirectPaymentResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public DoDirectPaymentResponseType DoDirectPayment(DoDirectPaymentReq doDirectPaymentReq)
	 	{
	 		return DoDirectPayment(doDirectPaymentReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public DoDirectPaymentResponseType DoDirectPayment(DoDirectPaymentReq doDirectPaymentReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(doDirectPaymentReq.DoDirectPaymentRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(doDirectPaymentReq.ToXMLString(null, "DoDirectPaymentReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='DoDirectPaymentResponse']");
			return new DoDirectPaymentResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public ManagePendingTransactionStatusResponseType ManagePendingTransactionStatus(ManagePendingTransactionStatusReq managePendingTransactionStatusReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(managePendingTransactionStatusReq.ManagePendingTransactionStatusRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(managePendingTransactionStatusReq.ToXMLString(null, "ManagePendingTransactionStatusReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='ManagePendingTransactionStatusResponse']");
			return new ManagePendingTransactionStatusResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public ManagePendingTransactionStatusResponseType ManagePendingTransactionStatus(ManagePendingTransactionStatusReq managePendingTransactionStatusReq)
	 	{
	 		return ManagePendingTransactionStatus(managePendingTransactionStatusReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public ManagePendingTransactionStatusResponseType ManagePendingTransactionStatus(ManagePendingTransactionStatusReq managePendingTransactionStatusReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(managePendingTransactionStatusReq.ManagePendingTransactionStatusRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(managePendingTransactionStatusReq.ToXMLString(null, "ManagePendingTransactionStatusReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='ManagePendingTransactionStatusResponse']");
			return new ManagePendingTransactionStatusResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public DoCancelResponseType DoCancel(DoCancelReq doCancelReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(doCancelReq.DoCancelRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(doCancelReq.ToXMLString(null, "DoCancelReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='DoCancelResponse']");
			return new DoCancelResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public DoCancelResponseType DoCancel(DoCancelReq doCancelReq)
	 	{
	 		return DoCancel(doCancelReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public DoCancelResponseType DoCancel(DoCancelReq doCancelReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(doCancelReq.DoCancelRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(doCancelReq.ToXMLString(null, "DoCancelReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='DoCancelResponse']");
			return new DoCancelResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public DoCaptureResponseType DoCapture(DoCaptureReq doCaptureReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(doCaptureReq.DoCaptureRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(doCaptureReq.ToXMLString(null, "DoCaptureReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='DoCaptureResponse']");
			return new DoCaptureResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public DoCaptureResponseType DoCapture(DoCaptureReq doCaptureReq)
	 	{
	 		return DoCapture(doCaptureReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public DoCaptureResponseType DoCapture(DoCaptureReq doCaptureReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(doCaptureReq.DoCaptureRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(doCaptureReq.ToXMLString(null, "DoCaptureReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='DoCaptureResponse']");
			return new DoCaptureResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public DoReauthorizationResponseType DoReauthorization(DoReauthorizationReq doReauthorizationReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(doReauthorizationReq.DoReauthorizationRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(doReauthorizationReq.ToXMLString(null, "DoReauthorizationReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='DoReauthorizationResponse']");
			return new DoReauthorizationResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public DoReauthorizationResponseType DoReauthorization(DoReauthorizationReq doReauthorizationReq)
	 	{
	 		return DoReauthorization(doReauthorizationReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public DoReauthorizationResponseType DoReauthorization(DoReauthorizationReq doReauthorizationReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(doReauthorizationReq.DoReauthorizationRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(doReauthorizationReq.ToXMLString(null, "DoReauthorizationReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='DoReauthorizationResponse']");
			return new DoReauthorizationResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public DoVoidResponseType DoVoid(DoVoidReq doVoidReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(doVoidReq.DoVoidRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(doVoidReq.ToXMLString(null, "DoVoidReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='DoVoidResponse']");
			return new DoVoidResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public DoVoidResponseType DoVoid(DoVoidReq doVoidReq)
	 	{
	 		return DoVoid(doVoidReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public DoVoidResponseType DoVoid(DoVoidReq doVoidReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(doVoidReq.DoVoidRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(doVoidReq.ToXMLString(null, "DoVoidReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='DoVoidResponse']");
			return new DoVoidResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public DoAuthorizationResponseType DoAuthorization(DoAuthorizationReq doAuthorizationReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(doAuthorizationReq.DoAuthorizationRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(doAuthorizationReq.ToXMLString(null, "DoAuthorizationReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='DoAuthorizationResponse']");
			return new DoAuthorizationResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public DoAuthorizationResponseType DoAuthorization(DoAuthorizationReq doAuthorizationReq)
	 	{
	 		return DoAuthorization(doAuthorizationReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public DoAuthorizationResponseType DoAuthorization(DoAuthorizationReq doAuthorizationReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(doAuthorizationReq.DoAuthorizationRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(doAuthorizationReq.ToXMLString(null, "DoAuthorizationReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='DoAuthorizationResponse']");
			return new DoAuthorizationResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public SetCustomerBillingAgreementResponseType SetCustomerBillingAgreement(SetCustomerBillingAgreementReq setCustomerBillingAgreementReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(setCustomerBillingAgreementReq.SetCustomerBillingAgreementRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(setCustomerBillingAgreementReq.ToXMLString(null, "SetCustomerBillingAgreementReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='SetCustomerBillingAgreementResponse']");
			return new SetCustomerBillingAgreementResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public SetCustomerBillingAgreementResponseType SetCustomerBillingAgreement(SetCustomerBillingAgreementReq setCustomerBillingAgreementReq)
	 	{
	 		return SetCustomerBillingAgreement(setCustomerBillingAgreementReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public SetCustomerBillingAgreementResponseType SetCustomerBillingAgreement(SetCustomerBillingAgreementReq setCustomerBillingAgreementReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(setCustomerBillingAgreementReq.SetCustomerBillingAgreementRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(setCustomerBillingAgreementReq.ToXMLString(null, "SetCustomerBillingAgreementReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='SetCustomerBillingAgreementResponse']");
			return new SetCustomerBillingAgreementResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public GetBillingAgreementCustomerDetailsResponseType GetBillingAgreementCustomerDetails(GetBillingAgreementCustomerDetailsReq getBillingAgreementCustomerDetailsReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(getBillingAgreementCustomerDetailsReq.GetBillingAgreementCustomerDetailsRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(getBillingAgreementCustomerDetailsReq.ToXMLString(null, "GetBillingAgreementCustomerDetailsReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='GetBillingAgreementCustomerDetailsResponse']");
			return new GetBillingAgreementCustomerDetailsResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public GetBillingAgreementCustomerDetailsResponseType GetBillingAgreementCustomerDetails(GetBillingAgreementCustomerDetailsReq getBillingAgreementCustomerDetailsReq)
	 	{
	 		return GetBillingAgreementCustomerDetails(getBillingAgreementCustomerDetailsReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public GetBillingAgreementCustomerDetailsResponseType GetBillingAgreementCustomerDetails(GetBillingAgreementCustomerDetailsReq getBillingAgreementCustomerDetailsReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(getBillingAgreementCustomerDetailsReq.GetBillingAgreementCustomerDetailsRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(getBillingAgreementCustomerDetailsReq.ToXMLString(null, "GetBillingAgreementCustomerDetailsReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='GetBillingAgreementCustomerDetailsResponse']");
			return new GetBillingAgreementCustomerDetailsResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public CreateBillingAgreementResponseType CreateBillingAgreement(CreateBillingAgreementReq createBillingAgreementReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(createBillingAgreementReq.CreateBillingAgreementRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(createBillingAgreementReq.ToXMLString(null, "CreateBillingAgreementReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='CreateBillingAgreementResponse']");
			return new CreateBillingAgreementResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public CreateBillingAgreementResponseType CreateBillingAgreement(CreateBillingAgreementReq createBillingAgreementReq)
	 	{
	 		return CreateBillingAgreement(createBillingAgreementReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public CreateBillingAgreementResponseType CreateBillingAgreement(CreateBillingAgreementReq createBillingAgreementReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(createBillingAgreementReq.CreateBillingAgreementRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(createBillingAgreementReq.ToXMLString(null, "CreateBillingAgreementReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='CreateBillingAgreementResponse']");
			return new CreateBillingAgreementResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public DoReferenceTransactionResponseType DoReferenceTransaction(DoReferenceTransactionReq doReferenceTransactionReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(doReferenceTransactionReq.DoReferenceTransactionRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(doReferenceTransactionReq.ToXMLString(null, "DoReferenceTransactionReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='DoReferenceTransactionResponse']");
			return new DoReferenceTransactionResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public DoReferenceTransactionResponseType DoReferenceTransaction(DoReferenceTransactionReq doReferenceTransactionReq)
	 	{
	 		return DoReferenceTransaction(doReferenceTransactionReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public DoReferenceTransactionResponseType DoReferenceTransaction(DoReferenceTransactionReq doReferenceTransactionReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(doReferenceTransactionReq.DoReferenceTransactionRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(doReferenceTransactionReq.ToXMLString(null, "DoReferenceTransactionReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='DoReferenceTransactionResponse']");
			return new DoReferenceTransactionResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public DoNonReferencedCreditResponseType DoNonReferencedCredit(DoNonReferencedCreditReq doNonReferencedCreditReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(doNonReferencedCreditReq.DoNonReferencedCreditRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(doNonReferencedCreditReq.ToXMLString(null, "DoNonReferencedCreditReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='DoNonReferencedCreditResponse']");
			return new DoNonReferencedCreditResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public DoNonReferencedCreditResponseType DoNonReferencedCredit(DoNonReferencedCreditReq doNonReferencedCreditReq)
	 	{
	 		return DoNonReferencedCredit(doNonReferencedCreditReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public DoNonReferencedCreditResponseType DoNonReferencedCredit(DoNonReferencedCreditReq doNonReferencedCreditReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(doNonReferencedCreditReq.DoNonReferencedCreditRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(doNonReferencedCreditReq.ToXMLString(null, "DoNonReferencedCreditReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='DoNonReferencedCreditResponse']");
			return new DoNonReferencedCreditResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public DoUATPAuthorizationResponseType DoUATPAuthorization(DoUATPAuthorizationReq doUATPAuthorizationReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(doUATPAuthorizationReq.DoUATPAuthorizationRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(doUATPAuthorizationReq.ToXMLString(null, "DoUATPAuthorizationReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='DoUATPAuthorizationResponse']");
			return new DoUATPAuthorizationResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public DoUATPAuthorizationResponseType DoUATPAuthorization(DoUATPAuthorizationReq doUATPAuthorizationReq)
	 	{
	 		return DoUATPAuthorization(doUATPAuthorizationReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public DoUATPAuthorizationResponseType DoUATPAuthorization(DoUATPAuthorizationReq doUATPAuthorizationReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(doUATPAuthorizationReq.DoUATPAuthorizationRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(doUATPAuthorizationReq.ToXMLString(null, "DoUATPAuthorizationReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='DoUATPAuthorizationResponse']");
			return new DoUATPAuthorizationResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public CreateRecurringPaymentsProfileResponseType CreateRecurringPaymentsProfile(CreateRecurringPaymentsProfileReq createRecurringPaymentsProfileReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(createRecurringPaymentsProfileReq.CreateRecurringPaymentsProfileRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(createRecurringPaymentsProfileReq.ToXMLString(null, "CreateRecurringPaymentsProfileReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='CreateRecurringPaymentsProfileResponse']");
			return new CreateRecurringPaymentsProfileResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public CreateRecurringPaymentsProfileResponseType CreateRecurringPaymentsProfile(CreateRecurringPaymentsProfileReq createRecurringPaymentsProfileReq)
	 	{
	 		return CreateRecurringPaymentsProfile(createRecurringPaymentsProfileReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public CreateRecurringPaymentsProfileResponseType CreateRecurringPaymentsProfile(CreateRecurringPaymentsProfileReq createRecurringPaymentsProfileReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(createRecurringPaymentsProfileReq.CreateRecurringPaymentsProfileRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(createRecurringPaymentsProfileReq.ToXMLString(null, "CreateRecurringPaymentsProfileReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='CreateRecurringPaymentsProfileResponse']");
			return new CreateRecurringPaymentsProfileResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public GetRecurringPaymentsProfileDetailsResponseType GetRecurringPaymentsProfileDetails(GetRecurringPaymentsProfileDetailsReq getRecurringPaymentsProfileDetailsReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(getRecurringPaymentsProfileDetailsReq.GetRecurringPaymentsProfileDetailsRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(getRecurringPaymentsProfileDetailsReq.ToXMLString(null, "GetRecurringPaymentsProfileDetailsReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='GetRecurringPaymentsProfileDetailsResponse']");
			return new GetRecurringPaymentsProfileDetailsResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public GetRecurringPaymentsProfileDetailsResponseType GetRecurringPaymentsProfileDetails(GetRecurringPaymentsProfileDetailsReq getRecurringPaymentsProfileDetailsReq)
	 	{
	 		return GetRecurringPaymentsProfileDetails(getRecurringPaymentsProfileDetailsReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public GetRecurringPaymentsProfileDetailsResponseType GetRecurringPaymentsProfileDetails(GetRecurringPaymentsProfileDetailsReq getRecurringPaymentsProfileDetailsReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(getRecurringPaymentsProfileDetailsReq.GetRecurringPaymentsProfileDetailsRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(getRecurringPaymentsProfileDetailsReq.ToXMLString(null, "GetRecurringPaymentsProfileDetailsReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='GetRecurringPaymentsProfileDetailsResponse']");
			return new GetRecurringPaymentsProfileDetailsResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public ManageRecurringPaymentsProfileStatusResponseType ManageRecurringPaymentsProfileStatus(ManageRecurringPaymentsProfileStatusReq manageRecurringPaymentsProfileStatusReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(manageRecurringPaymentsProfileStatusReq.ManageRecurringPaymentsProfileStatusRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(manageRecurringPaymentsProfileStatusReq.ToXMLString(null, "ManageRecurringPaymentsProfileStatusReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='ManageRecurringPaymentsProfileStatusResponse']");
			return new ManageRecurringPaymentsProfileStatusResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public ManageRecurringPaymentsProfileStatusResponseType ManageRecurringPaymentsProfileStatus(ManageRecurringPaymentsProfileStatusReq manageRecurringPaymentsProfileStatusReq)
	 	{
	 		return ManageRecurringPaymentsProfileStatus(manageRecurringPaymentsProfileStatusReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public ManageRecurringPaymentsProfileStatusResponseType ManageRecurringPaymentsProfileStatus(ManageRecurringPaymentsProfileStatusReq manageRecurringPaymentsProfileStatusReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(manageRecurringPaymentsProfileStatusReq.ManageRecurringPaymentsProfileStatusRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(manageRecurringPaymentsProfileStatusReq.ToXMLString(null, "ManageRecurringPaymentsProfileStatusReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='ManageRecurringPaymentsProfileStatusResponse']");
			return new ManageRecurringPaymentsProfileStatusResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public BillOutstandingAmountResponseType BillOutstandingAmount(BillOutstandingAmountReq billOutstandingAmountReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(billOutstandingAmountReq.BillOutstandingAmountRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(billOutstandingAmountReq.ToXMLString(null, "BillOutstandingAmountReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BillOutstandingAmountResponse']");
			return new BillOutstandingAmountResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public BillOutstandingAmountResponseType BillOutstandingAmount(BillOutstandingAmountReq billOutstandingAmountReq)
	 	{
	 		return BillOutstandingAmount(billOutstandingAmountReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public BillOutstandingAmountResponseType BillOutstandingAmount(BillOutstandingAmountReq billOutstandingAmountReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(billOutstandingAmountReq.BillOutstandingAmountRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(billOutstandingAmountReq.ToXMLString(null, "BillOutstandingAmountReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='BillOutstandingAmountResponse']");
			return new BillOutstandingAmountResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public UpdateRecurringPaymentsProfileResponseType UpdateRecurringPaymentsProfile(UpdateRecurringPaymentsProfileReq updateRecurringPaymentsProfileReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(updateRecurringPaymentsProfileReq.UpdateRecurringPaymentsProfileRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(updateRecurringPaymentsProfileReq.ToXMLString(null, "UpdateRecurringPaymentsProfileReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='UpdateRecurringPaymentsProfileResponse']");
			return new UpdateRecurringPaymentsProfileResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public UpdateRecurringPaymentsProfileResponseType UpdateRecurringPaymentsProfile(UpdateRecurringPaymentsProfileReq updateRecurringPaymentsProfileReq)
	 	{
	 		return UpdateRecurringPaymentsProfile(updateRecurringPaymentsProfileReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public UpdateRecurringPaymentsProfileResponseType UpdateRecurringPaymentsProfile(UpdateRecurringPaymentsProfileReq updateRecurringPaymentsProfileReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(updateRecurringPaymentsProfileReq.UpdateRecurringPaymentsProfileRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(updateRecurringPaymentsProfileReq.ToXMLString(null, "UpdateRecurringPaymentsProfileReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='UpdateRecurringPaymentsProfileResponse']");
			return new UpdateRecurringPaymentsProfileResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public ReverseTransactionResponseType ReverseTransaction(ReverseTransactionReq reverseTransactionReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(reverseTransactionReq.ReverseTransactionRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(reverseTransactionReq.ToXMLString(null, "ReverseTransactionReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='ReverseTransactionResponse']");
			return new ReverseTransactionResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public ReverseTransactionResponseType ReverseTransaction(ReverseTransactionReq reverseTransactionReq)
	 	{
	 		return ReverseTransaction(reverseTransactionReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public ReverseTransactionResponseType ReverseTransaction(ReverseTransactionReq reverseTransactionReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(reverseTransactionReq.ReverseTransactionRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(reverseTransactionReq.ToXMLString(null, "ReverseTransactionReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='ReverseTransactionResponse']");
			return new ReverseTransactionResponseType(xmlNode);
			
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public ExternalRememberMeOptOutResponseType ExternalRememberMeOptOut(ExternalRememberMeOptOutReq externalRememberMeOptOutReq, string apiUserName)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(externalRememberMeOptOutReq.ExternalRememberMeOptOutRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(externalRememberMeOptOutReq.ToXMLString(null, "ExternalRememberMeOptOutReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, apiUserName, getAccessToken(), getAccessTokenSecret());
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='ExternalRememberMeOptOutResponse']");
			return new ExternalRememberMeOptOutResponseType(xmlNode);
			
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public ExternalRememberMeOptOutResponseType ExternalRememberMeOptOut(ExternalRememberMeOptOutReq externalRememberMeOptOutReq)
	 	{
	 		return ExternalRememberMeOptOut(externalRememberMeOptOutReq,(string) null);
	 	}
	 	
	 	/**	
          *AUTO_GENERATED
	 	  */
	 	public ExternalRememberMeOptOutResponseType ExternalRememberMeOptOut(ExternalRememberMeOptOutReq externalRememberMeOptOutReq, ICredential credential)
	 	{
	 		IAPICallPreHandler apiCallPreHandler = null;
	 		string portName = "PayPalAPIAA";
			setStandardParams(externalRememberMeOptOutReq.ExternalRememberMeOptOutRequest);
			DefaultSOAPAPICallHandler defaultHandler = new DefaultSOAPAPICallHandler(externalRememberMeOptOutReq.ToXMLString(null, "ExternalRememberMeOptOutReq"), null, null);
			apiCallPreHandler = new MerchantAPICallPreHandler(defaultHandler, credential);
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((MerchantAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((MerchantAPICallPreHandler) apiCallPreHandler).PortName = portName;
			string response = Call(apiCallPreHandler);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='ExternalRememberMeOptOutResponse']");
			return new ExternalRememberMeOptOutResponseType(xmlNode);
			
	 	}
	}
}
