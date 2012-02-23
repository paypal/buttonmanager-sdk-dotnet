<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BMGetButtonDetails.aspx.cs" Inherits="PayPalAPISample.APICalls.BMGetButtonDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>PayPal ButtonManager SDK - BMGetButtonDetails</title>
    <link href="sdk.css" type="text/css" rel="stylesheet" />    
</head>
<body>
    <div id="wrapper">
    <div id="header">
        <h3>BMGetButtonDetails</h3>
        <div id="apidetails">Obtain information about a hosted Website Payments Standard button.</div>
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