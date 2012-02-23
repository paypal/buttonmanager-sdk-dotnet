<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BMSetInventory.aspx.cs" Inherits="PayPalAPISample.APICalls.BMSetInventory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>PayPal ButtonManager SDK - BMSetInventory</title>
    <link href="sdk.css" type="text/css" rel="stylesheet" />    
</head>
<body>
    <div id="wrapper">
    <div id="header">
        <h3>BMSetInventory</h3>
        <div id="apidetails">Set the inventory level and inventory management features for the 
        specified button. When you set the inventory level for a button, PayPal can track inventory, 
        calculate the gross profit associated with sales, send you an alert when inventory drops 
        below a specified quantity, and manage sold out conditions.</div>
    </div>
    <form id="form1" runat="server">
        <div id="request_form">
			<div class="params">
				<div class="param_name">Hosted Button ID* <a href='BMCreateButton.aspx?buttonCode=HOSTED'>(Create a hosted button)</a></div>
				<div class="param_value">
					<input type="text" id="hostedID" name="hostedID" value="" size="50"
						maxlength="260" runat="server"/>
				</div>
			</div>
			<div class="params">
				<div class="param_name">Track inventory</div>
				<div class="param_value">
					<input type="text" id="trackInv" name="trackInv" value="1" size="50" runat="server"/>
				</div>
			</div>
			<div class="params">
				<div class="param_name">Track Gross profit</div>
				<div class="param_value">
					<input type="text" id="trackPnl" name="trackPnl" value="1" size="50" runat="server"/>
				</div>
			</div>
			<div class="params">
				<div class="param_name">Item Number (mandatory if Track Inventory = 1)</div>
				<div class="param_value">
					<input type="text" id="itemNumber" name="itemNumber" value="IT-12345" size="50" runat="server"/> 
				</div>
			</div>			
			<div class="params">
				<div class="param_name">Item Quantity (mandatory if Track Inventory = 1)</div>
				<div class="param_value">
					<input type="text" id="itemQty" name="itemQty" value="10" size="50" runat="server"/> 
				</div>
			</div>
			<div class="params">
				<div class="param_name">Item Cost (mandatory if TrackGrossProfit = 1)</div>
				<div class="param_value">
					<input id="itemCost" type="text" name="itemCost" value="2.00" size="50" runat="server"/>
				</div>
			</div>
			<div class="params">
				<div class="param_name">Item quantity below which PayPal should send you an email notification</div>
				<div class="param_value">
					<input id="itemAlert" type="text" name="itemAlert" value="3" size="50" runat="server"/>
				</div>
			</div>
			<div class="params">
				<div class="param_name">Soldout URL</div>
				<div class="param_value">
					<input id="soldoutURL" type="text" name="soldoutURL" value="http://yourwebsite.com" runat="server"/>
				</div>
			</div>									            
	        <div class="submit">
                <input id="submit" type="submit" name="submit" value="Submit" runat="server" onserverclick="Submit_Click"/>
            </div>            
        </div>
    </form>
    <div id="relatedcalls"> 
    </div>
    </div>
</body>
</html>        