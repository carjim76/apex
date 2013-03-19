<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="wucGridSearch.ascx.vb" Inherits="WebFormAPEX.wucGridSearch" %>
<table>
    <tr>
        <td>
            <asp:Button ID="btnBack" runat="server" Text="Back" />
        </td>
    </tr>
    <tr><td><div>&nbsp;</div></td></tr>
    <tr align="center">
        <td align="center">
            <asp:GridView ID="GridSearch" runat="server" AutoGenerateColumns="false" 
                DataKeyNames="patient_id" BorderColor="Transparent" BorderStyle="None" 
                EmptyDataText="No found rows." 
                CellPadding="0" SkinID="GridView" Width="805px">
                <columns>
                    <asp:BoundField DataField="patient_id" meta:resourcekey="patient_id" Visible="False">
                        <ItemStyle HorizontalAlign="Left" Width="80px" />
                        <HeaderStyle HorizontalAlign="Left" />
                        <FooterStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="patient_mrn" meta:resourcekey="patient_mrn">
                        <ItemStyle HorizontalAlign="Left" Width="80px" />
                        <HeaderStyle HorizontalAlign="Left" />
                        <FooterStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="patient_firstname" meta:resourcekey="patient_firstname">
                        <ItemStyle HorizontalAlign="Left" Width="150px" />
                        <HeaderStyle HorizontalAlign="Left" />
                        <FooterStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="patient_lastname" meta:resourcekey="patient_lastname">
                        <ItemStyle HorizontalAlign="Left" Width="150px" />
                        <HeaderStyle HorizontalAlign="Left" />
                        <FooterStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="patient_order_number" meta:resourcekey="patient_order_number">
                        <ItemStyle HorizontalAlign="Left" Width="80px" />
                        <HeaderStyle HorizontalAlign="Left" />
                        <FooterStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField meta:resourcekey="BoundFieldResource6">
                        <ItemTemplate>
                            <asp:ImageButton ID="btndetail" runat="server" CommandName="Detail" ImageUrl="~/App_Forms/Images/btnNext.jpg" />
                        </ItemTemplate>
                        <ItemStyle Width="40px" VerticalAlign="Middle" HorizontalAlign="Center" />
                    </asp:TemplateField>
                </columns>
            </asp:GridView>
        </td>
    </tr>
</table>
<asp:HiddenField ID="hdfPatientId" runat="server" />
