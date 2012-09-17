<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="APIResponse.aspx.cs" Inherits="PayPalAPISample.APIResponse" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="PayPal.PayPalAPIInterfaceService.Model" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>PayPal ButtonManager SDK - API Response</title>
    <link rel="stylesheet" type="text/css" href="APICalls/sdk.css" />
</head>
<body>
<div id="wrapper">
<h3><%=apiName %></h3>

<% if (errorMessages != null)
   {
        %>
            <div class="section_header">Error messages</div>
            <div class="note">Investigate the response object for further error information</div>
            <ul>
       <%
        foreach (ErrorType error in errorMessages)
        { 
       %>
            <li><%=error.LongMessage %></li> 
       <%
        }
       %>
       </ul>
       <%
    }
    if(redirectURL != null) {%>    
    <div>This API involves a web flow. You must now redirect your user to <%=redirectURL%><br />
    Please click <a href="<%=redirectURL%>">here</a> to try the flow.</div>
<%} %>

    <div class="section_header">Key values from response</div>
    <div class="note">Consult response object and reference doc for complete list of response values.</div>
    <table>
<%  foreach (KeyValuePair<String, String> entry in responseValues) { %>
        <tr>
            <td class="label">                       
                <%=entry.Key%>:             
            </td>
            <td>
                <%--//Selenium Test Case--%>
                <div id="<%=entry.Key%>">            
                    <%=entry.Value%>
                </div>
            </td>
        </tr>
<% } %>        
    </table>

<%if(requestMessage != null) { %>    
    <div class="section_header">Request Message</div>
    <textarea id="requestMessageDump" rows="8" cols="80" readonly="readonly" ><%=requestMessage %></textarea>
<%} %>
<%if(requestMessage != null) { %>
    <div class="section_header">Response Message</div>    
    <textarea id="responseMessageDump" rows="8" cols="80" readonly="readonly" ><%=responseMessage %></textarea>
<%} %>
<br /><br />
<a href="../Default.aspx">Home</a>&nbsp;&nbsp;
<a href="<%=apiName%>.aspx">Back</a>    
</div>
</body>
</html>
