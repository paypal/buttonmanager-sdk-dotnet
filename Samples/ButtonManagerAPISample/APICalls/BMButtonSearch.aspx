<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BMButtonSearch.aspx.cs" Inherits="PayPalAPISample.APICalls.BMButtonSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>PayPal ButtonManager SDK - BMButtonSearch</title>
    <link href="sdk.css" type="text/css" rel="stylesheet" />    
    <script type="text/javascript">
       
        function popupCalendar(id) {
            var dateField = document.getElementById(id);
            if (dateField.style.display == 'none')
                dateField.style.display = 'block';
            else
                dateField.style.display = 'none';
        }
    </script>
</head>
<body>
    <div id="wrapper">
    <div id="header">
        <h3>BMButtonSearch</h3>
        <div id="apidetails">Search previously created "Web Payment Standard" buttons.</div>
    </div>
    <form id="form1" runat="server">
        <div id="request_form">
            <div class="param_name">Start date *</div>
            <div class="param_value">
                <div id="startDateField" style="display:none;">
                    <asp:Calendar id="calStartDate"
                        OnSelectionChanged="calDate_SelectionChanged"
                        Runat="server" />
                </div>
                <asp:TextBox id="startDate" runat="server" />
                <img src="calendar_icon.png" alt="calendar" onclick="popupCalendar('startDateField')" />
            </div>
            <div class="param_name">End date</div>
            <div class="param_value">
                <div id="endDateField" style="display:none;">
                    <asp:Calendar id="calEndDate"
                        OnSelectionChanged="calDate_SelectionChanged"
                        Runat="server" />
                </div>
                <asp:TextBox id="endDate" runat="server" />
                <img src="calendar_icon.png" alt="calendar" onclick="popupCalendar('endDateField')" />
            </div>                        
            <div class="submit">
                <input id="submitBtn" type="submit" name="submitBtn" value="Submit" runat="server" onserverclick="Submit_Click"/>
            </div>            
        </div>
    </form>
    <div id="relatedcalls"> 
    </div>
    </div>
</body>
</html>            