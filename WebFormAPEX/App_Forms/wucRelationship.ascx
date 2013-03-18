<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="wucRelationship.ascx.vb" Inherits="WebFormAPEX.wucRelationship" %>

<table width="100%" align="center" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td align="left">
            <asp:Label ID="lblRelationship" runat="server" meta:resourcekey="titleLblRelationshipResource"/>
        </td>
        <td align="right">
            <asp:DropDownList ID="ddlRelationship" runat="server" Width="206">
            </asp:DropDownList>
        </td>
    </tr>
</table>