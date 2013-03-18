<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="wucState.ascx.vb" Inherits="WebFormAPEX.wucState" %>

<table width="100%" align="center" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td align="left">
            <asp:Label ID="lblState" runat="server" meta:resourcekey="titleLblStateResource"/>
        </td>
        <td align="right">
            <asp:DropDownList ID="ddlState" runat="server" Width="206">
            </asp:DropDownList>
        </td>
    </tr>
</table>