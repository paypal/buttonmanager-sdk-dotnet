using System.Xml;
using PayPal;
using PayPal.Authentication;
using PayPal.Util;
using PayPal.Manager;
using PayPal.PayPalAPIInterfaceService.Model;

namespace PayPal.PayPalAPIInterfaceService {
	public partial class PayPalAPIInterfaceServiceService : BasePayPalService {

		// Service Version
		private static string ServiceVersion = "94.0";

		// Service Name
		private static string ServiceName = "PayPalAPIInterfaceService";

		public PayPalAPIInterfaceServiceService() : base(ServiceName, ServiceVersion)
		{
		}
	
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
			setStandardParams(bMCreateButtonReq.BMCreateButtonRequest);
			string response = Call("BMCreateButton", bMCreateButtonReq.ToXMLString(), apiUserName);
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
	 		return BMCreateButton(bMCreateButtonReq, null);
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public BMUpdateButtonResponseType BMUpdateButton(BMUpdateButtonReq bMUpdateButtonReq, string apiUserName)
	 	{
			setStandardParams(bMUpdateButtonReq.BMUpdateButtonRequest);
			string response = Call("BMUpdateButton", bMUpdateButtonReq.ToXMLString(), apiUserName);
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
	 		return BMUpdateButton(bMUpdateButtonReq, null);
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public BMManageButtonStatusResponseType BMManageButtonStatus(BMManageButtonStatusReq bMManageButtonStatusReq, string apiUserName)
	 	{
			setStandardParams(bMManageButtonStatusReq.BMManageButtonStatusRequest);
			string response = Call("BMManageButtonStatus", bMManageButtonStatusReq.ToXMLString(), apiUserName);
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
	 		return BMManageButtonStatus(bMManageButtonStatusReq, null);
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public BMGetButtonDetailsResponseType BMGetButtonDetails(BMGetButtonDetailsReq bMGetButtonDetailsReq, string apiUserName)
	 	{
			setStandardParams(bMGetButtonDetailsReq.BMGetButtonDetailsRequest);
			string response = Call("BMGetButtonDetails", bMGetButtonDetailsReq.ToXMLString(), apiUserName);
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
	 		return BMGetButtonDetails(bMGetButtonDetailsReq, null);
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public BMSetInventoryResponseType BMSetInventory(BMSetInventoryReq bMSetInventoryReq, string apiUserName)
	 	{
			setStandardParams(bMSetInventoryReq.BMSetInventoryRequest);
			string response = Call("BMSetInventory", bMSetInventoryReq.ToXMLString(), apiUserName);
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
	 		return BMSetInventory(bMSetInventoryReq, null);
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public BMGetInventoryResponseType BMGetInventory(BMGetInventoryReq bMGetInventoryReq, string apiUserName)
	 	{
			setStandardParams(bMGetInventoryReq.BMGetInventoryRequest);
			string response = Call("BMGetInventory", bMGetInventoryReq.ToXMLString(), apiUserName);
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
	 		return BMGetInventory(bMGetInventoryReq, null);
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public BMButtonSearchResponseType BMButtonSearch(BMButtonSearchReq bMButtonSearchReq, string apiUserName)
	 	{
			setStandardParams(bMButtonSearchReq.BMButtonSearchRequest);
			string response = Call("BMButtonSearch", bMButtonSearchReq.ToXMLString(), apiUserName);
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
	 		return BMButtonSearch(bMButtonSearchReq, null);
	 	}
	}
}
