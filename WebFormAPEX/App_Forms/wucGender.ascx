<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="wucGender.ascx.vb" Inherits="WebFormAPEX.wucGender" %>

<table width="100%" align="center" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td align="left">
            <asp:Label ID="lblPDGender" runat="server" meta:resourcekey="titleLblGenderResource"/>
        </td>
        <td align="right">
            <asp:DropDownList ID="ddlGender" runat="server" Width="206">
            </asp:DropDownList>
        </td>
    </tr>
</table>