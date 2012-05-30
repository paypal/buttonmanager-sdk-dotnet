/** 
 * Auto generated code
 */

using PayPal.Authentication;

namespace PayPal.PayPalAPIInterfaceService {

	using PayPal;
	using PayPal.Util;
	using PayPal.Manager;
	using PayPal.PayPalAPIInterfaceService.Model;

	public partial class PayPalAPIInterfaceServiceService : BasePayPalService{

		private static string serviceName = "PayPalAPIInterfaceService";
		private static string serviceVersion = "87.0";

		public PayPalAPIInterfaceServiceService() : base(serviceName, serviceVersion) {}
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
			setStandardParams(BMCreateButtonReq.BMCreateButtonRequest);
			string resp = call("BMCreateButton", BMCreateButtonReq.toXMLString(), apiUsername);

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
			setStandardParams(BMUpdateButtonReq.BMUpdateButtonRequest);
			string resp = call("BMUpdateButton", BMUpdateButtonReq.toXMLString(), apiUsername);

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
			setStandardParams(BMManageButtonStatusReq.BMManageButtonStatusRequest);
			string resp = call("BMManageButtonStatus", BMManageButtonStatusReq.toXMLString(), apiUsername);

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
			setStandardParams(BMGetButtonDetailsReq.BMGetButtonDetailsRequest);
			string resp = call("BMGetButtonDetails", BMGetButtonDetailsReq.toXMLString(), apiUsername);

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
			setStandardParams(BMSetInventoryReq.BMSetInventoryRequest);
			string resp = call("BMSetInventory", BMSetInventoryReq.toXMLString(), apiUsername);

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
			setStandardParams(BMGetInventoryReq.BMGetInventoryRequest);
			string resp = call("BMGetInventory", BMGetInventoryReq.toXMLString(), apiUsername);

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
			setStandardParams(BMButtonSearchReq.BMButtonSearchRequest);
			string resp = call("BMButtonSearch", BMButtonSearchReq.toXMLString(), apiUsername);

			return new BMButtonSearchResponseType(resp);
		}

		public BMButtonSearchResponseType BMButtonSearch(BMButtonSearchReq BMButtonSearchReq) 
		{
			return BMButtonSearch(BMButtonSearchReq, null);
		}
	}
}

