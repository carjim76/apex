<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="wucMedicalTest.ascx.vb" Inherits="WebFormAPEX.wucMedicalTest" %>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            <asp:DropDownList ID="ddlMedicalTest" runat="server" Width="500"></asp:DropDownList>
        </td>
        <td align="right" width="320">
            <table width="100%" align="center" border="0" cellspacing="0" cellpadding="0">
                <tr >
                    <td width="80" align ="left" >
                        <asp:TextBox ID="txtICD11" runat="server" Width="50" MaxLength="50" />
                    </td>
                    <td width="80" align ="left">
                        <asp:TextBox ID="txtICD12" runat="server" Width="50" MaxLength="50" />
                    </td>
                    <td width="80" align ="left">
                        <asp:TextBox ID="txtICD13" runat="server" Width="50" MaxLength="50" />
                    </td>
                    <td width="80" align ="left">
                        <asp:TextBox ID="txtICD14" runat="server" Width="50" MaxLength="50" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
