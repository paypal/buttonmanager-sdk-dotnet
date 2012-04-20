/** 
 * Auto generated code
 */

using PayPal.Authentication;

namespace PayPal.PayPalAPIInterfaceService {

	using PayPal;
	using PayPal.Util;
	using PayPal.Manager;
	using PayPal.PayPalAPIInterfaceService.Model;

	public partial class PayPalAPIInterfaceServiceService :BasePayPalService{

		private static string serviceName = "PayPalAPIInterfaceService";


		private static string serviceVersion"87.0";


		 public PayPalAPIInterfaceServiceService() : base(serviceName)
		        {}
	/// <summary>
 /// Sets standard parameters common to all requests
 /// </summary>
   private void setStandardParams(AbstractRequestType request)
  {
       if (request.Version == null)
    {
      request.Version = serviceVersion;
     }
    if(request.ErrorLanguage != null && ConfigManager.Instance.GetProperty("languageCode") != null)
    {
    request.ErrorLanguage = ConfigManager.Instance.GetProperty("languageCode");
   }            
   }
		/**
		 *
		 */
		public BMCreateButtonResponseType BMCreateButton(BMCreateButtonReq BMCreateButtonReq, string apiUsername) 
		{
			BasePayPalService service = new BasePayPalService(serviceName);
		setStandardParams(BMCreateButtonReq.getBMCreateButtonRequest);
			string resp = service.call("BMCreateButton", BMCreateButtonReq.toXMLString(), apiUsername);

			return new BMCreateButtonResponseType(resp);
		}

		public BMCreateButtonResponseType BMCreateButton(BMCreateButtonReq BMCreateButtonReq) 
		{
			return BMCreateButton(BMCreateButtonReq, null);
		}
		/**
		 *
		 */
		public BMUpdateButtonResponseType BMUpdateButton(BMUpdateButtonReq BMUpdateButtonReq, string apiUsername) 
		{
			BasePayPalService service = new BasePayPalService(serviceName);
		setStandardParams(BMUpdateButtonReq.getBMUpdateButtonRequest);
			string resp = service.call("BMUpdateButton", BMUpdateButtonReq.toXMLString(), apiUsername);

			return new BMUpdateButtonResponseType(resp);
		}

		public BMUpdateButtonResponseType BMUpdateButton(BMUpdateButtonReq BMUpdateButtonReq) 
		{
			return BMUpdateButton(BMUpdateButtonReq, null);
		}
		/**
		 *
		 */
		public BMManageButtonStatusResponseType BMManageButtonStatus(BMManageButtonStatusReq BMManageButtonStatusReq, string apiUsername) 
		{
			BasePayPalService service = new BasePayPalService(serviceName);
		setStandardParams(BMManageButtonStatusReq.getBMManageButtonStatusRequest);
			string resp = service.call("BMManageButtonStatus", BMManageButtonStatusReq.toXMLString(), apiUsername);

			return new BMManageButtonStatusResponseType(resp);
		}

		public BMManageButtonStatusResponseType BMManageButtonStatus(BMManageButtonStatusReq BMManageButtonStatusReq) 
		{
			return BMManageButtonStatus(BMManageButtonStatusReq, null);
		}
		/**
		 *
		 */
		public BMGetButtonDetailsResponseType BMGetButtonDetails(BMGetButtonDetailsReq BMGetButtonDetailsReq, string apiUsername) 
		{
			BasePayPalService service = new BasePayPalService(serviceName);
		setStandardParams(BMGetButtonDetailsReq.getBMGetButtonDetailsRequest);
			string resp = service.call("BMGetButtonDetails", BMGetButtonDetailsReq.toXMLString(), apiUsername);

			return new BMGetButtonDetailsResponseType(resp);
		}

		public BMGetButtonDetailsResponseType BMGetButtonDetails(BMGetButtonDetailsReq BMGetButtonDetailsReq) 
		{
			return BMGetButtonDetails(BMGetButtonDetailsReq, null);
		}
		/**
		 *
		 */
		public BMSetInventoryResponseType BMSetInventory(BMSetInventoryReq BMSetInventoryReq, string apiUsername) 
		{
			BasePayPalService service = new BasePayPalService(serviceName);
		setStandardParams(BMSetInventoryReq.getBMSetInventoryRequest);
			string resp = service.call("BMSetInventory", BMSetInventoryReq.toXMLString(), apiUsername);

			return new BMSetInventoryResponseType(resp);
		}

		public BMSetInventoryResponseType BMSetInventory(BMSetInventoryReq BMSetInventoryReq) 
		{
			return BMSetInventory(BMSetInventoryReq, null);
		}
		/**
		 *
		 */
		public BMGetInventoryResponseType BMGetInventory(BMGetInventoryReq BMGetInventoryReq, string apiUsername) 
		{
			BasePayPalService service = new BasePayPalService(serviceName);
		setStandardParams(BMGetInventoryReq.getBMGetInventoryRequest);
			string resp = service.call("BMGetInventory", BMGetInventoryReq.toXMLString(), apiUsername);

			return new BMGetInventoryResponseType(resp);
		}

		public BMGetInventoryResponseType BMGetInventory(BMGetInventoryReq BMGetInventoryReq) 
		{
			return BMGetInventory(BMGetInventoryReq, null);
		}
		/**
		 *
		 */
		public BMButtonSearchResponseType BMButtonSearch(BMButtonSearchReq BMButtonSearchReq, string apiUsername) 
		{
			BasePayPalService service = new BasePayPalService(serviceName);
		setStandardParams(BMButtonSearchReq.getBMButtonSearchRequest);
			string resp = service.call("BMButtonSearch", BMButtonSearchReq.toXMLString(), apiUsername);

			return new BMButtonSearchResponseType(resp);
		}

		public BMButtonSearchResponseType BMButtonSearch(BMButtonSearchReq BMButtonSearchReq) 
		{
			return BMButtonSearch(BMButtonSearchReq, null);
		}
	}
}

