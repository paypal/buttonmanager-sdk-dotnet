<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BMManageButtonStatus.aspx.cs" Inherits="PayPalAPISample.APICalls.BMManageButtonStatus" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>PayPal ButtonManager SDK - BMManageButtonStatus</title>
    <link href="sdk.css" type="text/css" rel="stylesheet" />    
</head>
<body>
    <div id="wrapper">
    <div id="header">
        <h3>BMManageButtonStatus</h3>
        <div id="apidetails">.</div>
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
				<div class="param_name">Button status*</div>
				<div class="param_value">
				    <asp:DropDownList ID="buttonStatus" runat="server">
				        <asp:ListItem Text="Delete" Value="DELETE" />
				    </asp:DropDownList>
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