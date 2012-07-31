using PayPal;
using PayPal.Authentication;
using PayPal.Util;
using PayPal.Manager;
using PayPal.PayPalAPIInterfaceService.Model;

namespace PayPal.PayPalAPIInterfaceService {
	public partial class PayPalAPIInterfaceServiceService : BasePayPalService {

		// Service Version
		private static string ServiceVersion = "92.0";

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
	 	public BMCreateButtonResponseType BMCreateButton(BMCreateButtonReq BMCreateButtonReq, string apiUsername)
	 	{
			setStandardParams(BMCreateButtonReq.BMCreateButtonRequest);
		
			string resp = call("BMCreateButton", BMCreateButtonReq.toXMLString(), apiUsername);
			return new BMCreateButtonResponseType(resp);
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public BMCreateButtonResponseType BMCreateButton(BMCreateButtonReq BMCreateButtonReq)
	 	{
	 		return BMCreateButton(BMCreateButtonReq, null);
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public BMUpdateButtonResponseType BMUpdateButton(BMUpdateButtonReq BMUpdateButtonReq, string apiUsername)
	 	{
			setStandardParams(BMUpdateButtonReq.BMUpdateButtonRequest);
		
			string resp = call("BMUpdateButton", BMUpdateButtonReq.toXMLString(), apiUsername);
			return new BMUpdateButtonResponseType(resp);
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public BMUpdateButtonResponseType BMUpdateButton(BMUpdateButtonReq BMUpdateButtonReq)
	 	{
	 		return BMUpdateButton(BMUpdateButtonReq, null);
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public BMManageButtonStatusResponseType BMManageButtonStatus(BMManageButtonStatusReq BMManageButtonStatusReq, string apiUsername)
	 	{
			setStandardParams(BMManageButtonStatusReq.BMManageButtonStatusRequest);
		
			string resp = call("BMManageButtonStatus", BMManageButtonStatusReq.toXMLString(), apiUsername);
			return new BMManageButtonStatusResponseType(resp);
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public BMManageButtonStatusResponseType BMManageButtonStatus(BMManageButtonStatusReq BMManageButtonStatusReq)
	 	{
	 		return BMManageButtonStatus(BMManageButtonStatusReq, null);
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public BMGetButtonDetailsResponseType BMGetButtonDetails(BMGetButtonDetailsReq BMGetButtonDetailsReq, string apiUsername)
	 	{
			setStandardParams(BMGetButtonDetailsReq.BMGetButtonDetailsRequest);
		
			string resp = call("BMGetButtonDetails", BMGetButtonDetailsReq.toXMLString(), apiUsername);
			return new BMGetButtonDetailsResponseType(resp);
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public BMGetButtonDetailsResponseType BMGetButtonDetails(BMGetButtonDetailsReq BMGetButtonDetailsReq)
	 	{
	 		return BMGetButtonDetails(BMGetButtonDetailsReq, null);
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public BMSetInventoryResponseType BMSetInventory(BMSetInventoryReq BMSetInventoryReq, string apiUsername)
	 	{
			setStandardParams(BMSetInventoryReq.BMSetInventoryRequest);
		
			string resp = call("BMSetInventory", BMSetInventoryReq.toXMLString(), apiUsername);
			return new BMSetInventoryResponseType(resp);
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public BMSetInventoryResponseType BMSetInventory(BMSetInventoryReq BMSetInventoryReq)
	 	{
	 		return BMSetInventory(BMSetInventoryReq, null);
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public BMGetInventoryResponseType BMGetInventory(BMGetInventoryReq BMGetInventoryReq, string apiUsername)
	 	{
			setStandardParams(BMGetInventoryReq.BMGetInventoryRequest);
		
			string resp = call("BMGetInventory", BMGetInventoryReq.toXMLString(), apiUsername);
			return new BMGetInventoryResponseType(resp);
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public BMGetInventoryResponseType BMGetInventory(BMGetInventoryReq BMGetInventoryReq)
	 	{
	 		return BMGetInventory(BMGetInventoryReq, null);
	 	}

		/**	
          *AUTO_GENERATED
	 	  */
	 	public BMButtonSearchResponseType BMButtonSearch(BMButtonSearchReq BMButtonSearchReq, string apiUsername)
	 	{
			setStandardParams(BMButtonSearchReq.BMButtonSearchRequest);
		
			string resp = call("BMButtonSearch", BMButtonSearchReq.toXMLString(), apiUsername);
			return new BMButtonSearchResponseType(resp);
	 	}
	 
	 	/** 
          *AUTO_GENERATED
	 	  */
	 	public BMButtonSearchResponseType BMButtonSearch(BMButtonSearchReq BMButtonSearchReq)
	 	{
	 		return BMButtonSearch(BMButtonSearchReq, null);
	 	}
	}
}
