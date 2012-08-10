<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BMUpdateButton.aspx.cs" Inherits="PayPalAPISample.APICalls.BMUpdateButton" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>PayPal ButtonManager SDK - BMCreateButton</title>
    <link href="sdk.css" type="text/css" rel="stylesheet" />    
</head>
<body>
    <div id="wrapper">
    <div id="header">
        <h3>BMUpdateButton</h3>
        <div id="apidetails">Modify a Website Payments Standard button that is hosted on PayPal. This
         operation replaces all fields in the specified button.</div>
    </div>
    <form id="form1" runat="server">
        <div id="request_form">
			<div class="params">
				<div class="param_name">
					Hosted Button ID* <a href='BMCreateButton.aspx?buttonCode=HOSTED'>(Create a hosted button)</a>
				</div>
				<div class="param_value">
					<input type="text" id="hostedID" name="hostedID" value="" runat="server" />
				</div>
			</div>				        
			<div class="params">
				<div class="param_name">Button type</div>
				<div class="param_value">
				    <asp:DropDownList ID="buttonType" runat="server">
						<asp:ListItem value="AUTOBILLING" Text="Auto Billing"/>
						<asp:ListItem value="BUYNOW" Text="Buy Now"/>
						<asp:ListItem value="CART" Text="Cart"/>
						<asp:ListItem value="DONATE" Text="Donation"/>
						<asp:ListItem value="GIFTCERTIFICATE" Text="Gift Certificate"/>
						<asp:ListItem value="PAYMENT" Text="Payment"/>
						<asp:ListItem value="PAYMENTPLAN" Text="Payment Plan"/>
						<asp:ListItem value="SUBSCRIBE" Text="Subscribe"/>
						<asp:ListItem value="UNSUBSCRIBE" Text="Unsubscribe"/>
						<asp:ListItem value="VIEWCART" Text="View Cart"/>
					</asp:DropDownList>
				</div>
			</div>
			<div class="params">
				<div class="param_name">Button code</div>
				<div class="param_value">
					<asp:DropDownList ID="buttonCode" runat="server">
						<asp:ListItem value="CLEARTEXT" Text="Cleartext"/>
						<asp:ListItem value="ENCRYPTED" Text="Encrypted"/>
						<asp:ListItem value="HOSTED" Text="Hosted"/>
						<asp:ListItem value="TOKEN" Text="Token"/>
					</asp:DropDownList>
				</div>
			</div>

			<div class="section_header">Button variables</div>
			<div class="params">
				<div class="param_name">Return URL</div>
				<div class="param_value">
					<input id="returnURL" type="text" name="returnURL" value="" runat="Server"
						size="50" maxlength="260" />
				</div>
			</div>
			<div class="params">
				<div class="param_name">Item Name</div>
				<div class="param_value">
					<input type="text" id="itemName" name="itemName" value="Widget" runat="Server" size="50"
						maxlength="260" />
				</div>
			</div>
			<div class="params">
				<div class="param_name">Business Mail</div>
				<div class="param_value">
					<input type="text" id="businessMail" name="businessMail" runat="Server"
						value="" size="50" maxlength="260" />
				</div>
			</div>
			<div class="params">
				<div class="param_name">Amount</div>
				<div class="param_value">
					<input type="text" id="amount" name="amount" value="2.00" size="50" runat="Server"
						maxlength="260" />
				</div>
			</div>			        

			<div class="section_header">For "Payment Plan" button</div>
			<table class="params">
				<tr>
					<th class="param_name">Billing Cycles</th>
					<th class="param_name">Installment Amount</th>
					<th class="param_name">Billing Frequency</th>
					<th class="param_name">Billing Period</th>
					<th class="param_name">Option Type</th>
				</tr>
				<tr>
					<td class="param_value"><input type="text"
						id="billingCycles" name="billingCycles" value="3" size="25" maxlength="260" runat="Server" /></td>
					<td class="param_value"><input type="text"
						id="installmentAmt" name="installmentAmt" value="3.00" size="25" maxlength="260" runat="Server"/>
					</td>
					<td class="param_value"><input type="text" id="billingFreq" name="billingFreq"
						value="3" size="25" maxlength="260" runat="Server"/></td>
					<td class="param_value">
				        <asp:DropDownList ID="billingPeriod" runat="server">
				            <asp:ListItem value="NOBILLINGPERIODTYPE" Text="No Billing Period Type"/>
						    <asp:ListItem value="DAY" Text="Day"/>
						    <asp:ListItem value="WEEK" Text="Week"/>
						    <asp:ListItem value="SEMIMONTH" Text="Semi-Month"/>
						    <asp:ListItem value="MONTH" Text="Month"/>
						    <asp:ListItem value="YEAR" Text="Year"/>
				        </asp:DropDownList>
					</td>
					<td class="param_value">
					    <asp:DropDownList ID="optionType" runat="server">
							<asp:ListItem value="NOOPTIONTYPE" Text="No Option Type"/>
							<asp:ListItem value="FULL" Text="Full"/>
							<asp:ListItem value="EMI" Text="EMI"/>
							<asp:ListItem value="VARIABLE" Text="Variable"/>
					    </asp:DropDownList>
					</td>
					</tr>
			</table>
			<div class="section_header">For "Gift Certificate" button</div>
			<div class="params">
				<div class="param_name">Shopping Url</div>
				<div class="param_value">
					<input type="text" id="shoppingUrl" name="shoppingUrl" value="http://www.ebay.com"
						size="50" maxlength="260" runat="server"/>
				</div>
			</div>
			<div class="section_header">For "Auto billing" button</div>
			<div class="params">
				<div class="param_name">Minimum Amount</div>
				<div class="param_value">
					<input type="text" id="minAmt" name="minAmt" value="1.00" size="50"
						maxlength="260" runat="server"/>
				</div>
			</div>
			<div class="section_header">For "Payment" button</div>
			<div class="params">
				<div class="param_name">Sub total</div>
				<div class="param_value">
					<input type="text" id="subTotal" name="subTotal" value="2.00" size="50"
						maxlength="260" runat="server"/>
				</div>
			</div>
			<div class="section_header">For "Subscribe" button</div>
			<table class="params">
				<tr>
					<th class="param_name">Subscription Amount</th>
					<th class="param_name">Subscription Duration</th>
					<th class="param_name">Subscription Interval</th>
				</tr>
				<tr>
					<td class="param_value"><input type="text" id="subAmt" name="subAmt"
						value="3.00" size="25" maxlength="260" runat="server"/></td>
					<td class="param_value"><input type="text" id="subPeriod" name="subPeriod"
						value="3" size="25" maxlength="260" runat="server"/></td>
					<td class="param_value">
					    <asp:DropDownList ID="subInterval" runat="server" >
							<asp:ListItem value="D" Text="Day"/>
							<asp:ListItem value="W" Text="Week"/>
							<asp:ListItem value="M" Text="Month"/>
							<asp:ListItem value="Y" Text="Year"/>
					    </asp:DropDownList></td>
				</tr>
			</table>			
	        <div class="submit">
                <input id="submit" type="submit" name="submit" value="Submit" runat="server" onserverclick="Submit_Click"/>
            </div>            
        </div>       
    </form>
    <div id="relatedcalls"></div>
    </div>
</body>
</html>        