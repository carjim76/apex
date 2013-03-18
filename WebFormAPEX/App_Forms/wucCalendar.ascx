<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="wucCalendar.ascx.vb" Inherits="WebFormAPEX.wucCalendar" %>

<asp:TextBox ID="TextBox1" runat="server" ReadOnly="true" ></asp:TextBox>
<asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
