IPN Overview:
------------
* PayPal Instant Payment Notification is a call back system that is initiated when a transaction is completed 
  (Example: On successful payment transaction)
* The transaction related IPN variables will be received on the call back URL specified in the request
* The IPN variables have to be sent back to the PayPal system for validation, 
  upon validation PayPal will send a response string "VERIFIED" or "INVALID"
* PayPal would continuously resend IPN if a wrong IPN is sent


IPN Configuration:
-----------------
* IPN endpoint URL is specified in 'Web.config' as 'IPNEndpoint'. This will be used for the IPN post back
* A utility class 'IPNMessage.cs' is provided in sdk-core-dotnet for IPN message validation


IPN Deployment:
--------------
* IPN Listener - buttonmanager-sdk-dotnet\Samples\ButtonManagerAPISample\IPNListener.aspx
* Deploy IPN Listener sample in IIS and expose your server port using any third party 
  LocalTunneling software, so that the PayPal IPN call back can be received
* Make a PayPal API call (Example: BMCreateButton request), setting the IPNNotificationUrl field of the API request class
  to the URL of deployed IPNListener sample (Example: http://DNS-Name/IPNListener.aspx)
* The IPN call back from PayPal would be logged in the log file of the IPN sample


IPN variables :
--------------

[TransactionType]
-----------------   
* txn_type    

[Transaction_Notification]
---------------------------
* business
* charset
* custom
* ipn_track_id
* notify_version
* parent_txn_id
* receipt_id
* receiver_email
* receiver_id
* resend
* residence_country
* test_ipn
* txn_id
* txn_type
* verify_sign
* transaction_subject
* btn_id 


[BuyerInfo]
------------
* address_country
* address_city
* address_country_code
* address_name
* address_state
* address_status
* address_street
* address_zip
* contact_phone
* first_name
* last_name
* payer_business_name
* payer_email
* payer_id



[Auction]
-----------
* auction_buyer_id
* auction_closing_date
* auction_multi_item
* for_auction

[MassPay]
----------
* masspay_txn_id_X
* mc_currency_X
* mc_fee_X
* mc_gross_X
* mc_handlingX
* payment_date
* payment_status
* reason_code
* receiver_email_X
* status_X
* unique_id_X

[RecurringPayment]
------------------
* amount
* amount_per_cycle
* initial_payment_amount
* next_payment_date
* outstanding_balance
* payment_cycle
* period_type
* product_name
* product_type
* profile_status
* recurring_payment_id
* rp_invoice_id
* time_created

[Subscription]
--------------
* amountX
* mc_amountX
* password
* periodX
* reattempt
* recur_times
* recurring
* retry_at
* subscr_date
* subscr_effective
* subscr_id
* username


[DisputeResolution]
-------------------
* case_creation_date
* case_id
* case_type
* reason_code
 
[Paymentinfo]
-------------
* exchange_rate
* fraud_managment_pending_filters_X
* invoice
* item_name
* item_nameX
* item_numberX
* mc_currency
* mc_fee
* mc_gross
* mc_gross_X
* mc_handling
* mc_shipping
* mc_shippingX
* memo
* num_cart_items
* option_nameX
* option_selectionX
* payer_status
* payment_date
* payment_fee
* payment_fee_X
* payment_gross
* payment_gross_X
* payment_status
* pending_reason
* protection_eligibility
* quantity
* reason_code
* remaining_settle
* settle_amount
* settle_currency
* shipping
* shipping_method
* tax
* transaction_entity
* payment_type
* handling_amount
* shipping_discount
* insurance_amount
* discount

[BillingAgreement]
------------------
* mp_currency
* mp_custom
* mp_cycle_start
* mp_desc
* mp_id
* mp_pay_type
* mp_status


* For a full list of IPN variables you need to check the log file that the IPN Listener logs.    

IPN Reference :
--------------
* Please refer to 'Instant Payment Notification: Getting Started' at [https://www.x.com/developers/paypal/documentation-tools/IPN/gs_IPN]