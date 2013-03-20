<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="wucPrincipalForm.ascx.vb" Inherits="WebFormAPEX.wucPrincipalForm" %>
<%@ Register Src="wucGender.ascx" Tagname = "wucGender" TagPrefix = "uc1"%>
<%@ Register Src="wucRelationship.ascx" Tagname = "wucRelationship" TagPrefix = "uc2"%>
<%@ Register Src="wucState.ascx" Tagname = "wucState" TagPrefix = "uc3"%>
<%@ Register Src="wucMedicalTest.ascx" Tagname = "wucMedicalTest" TagPrefix = "uc4"%>
<%@ Register Src="wucCalendar.ascx" Tagname = "wucCalendar" TagPrefix = "uc5"%>
<%@ Register Src="wucGridSearch.ascx" Tagname = "wucGridSearch" TagPrefix = "uc6"%>

<script type="text/javascript" language="javascript">
    function solonumeros(e) {

        var key;

        if (window.event) // IE
        {
            key = e.keyCode;
        }
        else if (e.which) // Netscape/Firefox/Opera
        {
            key = e.which;
        }

        if (key < 48 || key > 57) {
            return false;
        }

        return true;
    }
</script>
    
<div id="divForm" runat="server"> 
    <table width="100%" align="center" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td width="30%">Patient Orders</td>
            <td width="30%">
                <table width="100%" align="center" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <asp:Label ID="lblOrderingProvider" runat="server" meta:resourcekey="titleLblOrderingProviderResource"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlOrderingProvider" runat="server" Width="206"></asp:DropDownList>
                        </td>
                    </tr>
                </table>     
            </td>
            <td width="30%">
                <table width="100%" align="center" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblPrintBarcode" runat="server" meta:resourcekey="titleLblPrintBarcodeResource"/>                                        
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="printBC" runat="server" ImageUrl="~/App_Forms/Images/printer.gif"/>
                                    </td>
                                </tr>
                            </table>   
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblPrintRequisition" runat="server" meta:resourcekey="titleLblPrintRequisitionResource"/>                                        
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnPrintRequisition" runat="server" ImageUrl="~/App_Forms/Images/printer.gif"/>
                                    </td>
                                </tr>
                            </table>   
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr><td><div>&nbsp;</div></td></tr>
        <tr>
            <td width="30%">
                <asp:Label ID="lblPatienData" runat="server" meta:resourcekey="titleLblPatienDataResource"/>
            </td>
            <td width="30%">
                <asp:Label ID="lblGuarantorData" runat="server" meta:resourcekey="titleLblGuarantorDataResource"/>
            </td>
            <td width="30%">
                <asp:Label ID="lblInsuranceData" runat="server" meta:resourcekey="titleLblInsuranceDataResource"/>
            </td>
        </tr>
        <tr>
            <td>
                <table width="90%" align="center" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblPDMRN" runat="server" meta:resourcekey="titleLblPDMRNResource"/>
                        </td>   
                        <td align="right">
                            <asp:TextBox ID="txtPDMRN" runat="server"  Width="200" MaxLength="50" onkeypress="javascript:return solonumeros(event)"/>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblPDFirstName" runat="server" meta:resourcekey="titleLblFirtsNameResource"/>
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtPDFirstName" runat="server"  Width="200" MaxLength="50" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblPDMiddleName" runat="server" meta:resourcekey="titleLblMiddleNameResource"/>
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtPDMiddleName" runat="server"  Width="200" MaxLength="50" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblPDLastName" runat="server" meta:resourcekey="titleLblLastNameResource"/>
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtPDLastName" runat="server"  Width="200" MaxLength="50" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <uc1:wucGender ID="wucGender1" runat="server"/>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblPDBirthday" runat="server" meta:resourcekey="titleLblBirthdayResource"/>
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtPDBirthday" runat="server"  Width="200" MaxLength="50" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblPDEthnicity" runat="server" meta:resourcekey="titleLblPDEthnicityResource"/>
                        </td>
                        <td align="right">
                            <asp:DropDownList ID="ddlPDEthnicity" runat="server" Width="206"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblPDAddress" runat="server" meta:resourcekey="titleLblAddressResource"/>
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtPDAddress" runat="server"  Width="200" MaxLength="50" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblPDCity" runat="server" meta:resourcekey="titleLblCityResource"/>
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtPDCity" runat="server"  Width="200" MaxLength="50" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <uc3:wucState ID="wucState1" runat="server"/>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblPDZip" runat="server" meta:resourcekey="titleLblZipResource"/>
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtPDZip" runat="server"  Width="200" MaxLength="50" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblPDOrder" runat="server" meta:resourcekey="titleLblPDOrderResource"/>
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtPDOrder" runat="server"  Width="200" MaxLength="50" 
                                Enabled="False" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblPDSpecimenCollect" runat="server" meta:resourcekey="titleLblPDSpecimenCollectResource"/>
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtPDDateSpecimenCollect" runat="server"  Width="140" MaxLength="50" />
                            <asp:TextBox ID="txtPDHourSpecimenCollectDate" runat="server"  Width="50" MaxLength="50" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <table width="90%" align="center" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblGDFirstName" runat="server" meta:resourcekey="titleLblFirtsNameResource"/>
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtGDFirstName" runat="server"  Width="200" MaxLength="50" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblGDMiddleName" runat="server" meta:resourcekey="titleLblMiddleNameResource"/>
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtGDMiddleName" runat="server"  Width="200" MaxLength="50" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblGDLastName" runat="server" meta:resourcekey="titleLblLastNameResource"/>
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtGDLastName" runat="server"  Width="200" MaxLength="50" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <uc1:wucGender ID="wucGender2" runat="server"/>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblGDBirthday" runat="server" meta:resourcekey="titleLblBirthdayResource"/>
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtGDBirthday" runat="server"  Width="200" MaxLength="50" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <uc2:wucRelationship ID="wucRelationship1" runat="server"/>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblGDAddress" runat="server" meta:resourcekey="titleLblAddressResource"/>
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtGDAddress" runat="server"  Width="200" MaxLength="50" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblGDCity" runat="server" meta:resourcekey="titleLblCityResource"/>
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtGDCity" runat="server"  Width="200" MaxLength="50" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <uc3:wucState ID="wucState2" runat="server"/>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblGDZip" runat="server" meta:resourcekey="titleLblZipResource"/>
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtGDZip" runat="server"  Width="200" MaxLength="50" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <table width="90%" align="center" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblInsurancePlan" runat="server" meta:resourcekey="titleLblInsurancePlanResource"/>
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtInsurancePlan" runat="server"  Width="200" MaxLength="50" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblIDFirstName" runat="server" meta:resourcekey="titleLblFirtsNameResource"/>
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtIDFirstName" runat="server"  Width="200" MaxLength="50" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblIDMiddleName" runat="server" meta:resourcekey="titleLblMiddleNameResource"/>
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtIDMiddleName" runat="server"  Width="200" MaxLength="50" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblIDLastName" runat="server" meta:resourcekey="titleLblLastNameResource"/>
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtIDLastName" runat="server"  Width="200" MaxLength="50" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <uc1:wucGender ID="wucGender3" runat="server"/>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblIDBirthday" runat="server" meta:resourcekey="titleLblBirthdayResource"/>
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtIDBirthday" runat="server"  Width="200" MaxLength="50" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <uc2:wucRelationship ID="wucRelationship2" runat="server"/>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblIDAddress" runat="server" meta:resourcekey="titleLblAddressResource"/>
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtIDAddress" runat="server"  Width="200" MaxLength="50" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblIDCity" runat="server" meta:resourcekey="titleLblCityResource"/>
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtIDCity" runat="server"  Width="200" MaxLength="50" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <uc3:wucState ID="wucState3" runat="server"/>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblIDZip" runat="server" meta:resourcekey="titleLblZipResource"/>
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtIDZip" runat="server"  Width="200" MaxLength="50" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblIDGroup" runat="server" meta:resourcekey="titleLblIDGroupResource"/>
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtIDGroup" runat="server"  Width="200" MaxLength="50" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblIDPolicy" runat="server" meta:resourcekey="titleLblIDPolicyResource"/>
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtIDPolicy" runat="server"  Width="200" MaxLength="50" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <table id="testtable" width="100%" align="center" border="0" cellspacing="0" cellpadding="0">
                    <tr><td><div>&nbsp;</div></td></tr>
                    <tr>
                        <td align="left" colspan="3">
                            <table id="table_tests" width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblTest" runat="server" meta:resourcekey="titleLblTestResource"/>
                                    </td>
                                    <td width="80" align ="left" >
                                        <asp:Label ID="Label1" runat="server" meta:resourcekey="titleLblICD1Resource"/>
                                    </td>
                                    <td width="80" align ="left">
                                        <asp:Label ID="Label2" runat="server" meta:resourcekey="titleLblICD2Resource"/>
                                    </td>
                                    <td width="80" align ="left">
                                        <asp:Label ID="Label3" runat="server" meta:resourcekey="titleLblICD3Resource"/>
                                    </td>
                                    <td width="80" align ="left">
                                        <asp:Label ID="Label4" runat="server" meta:resourcekey="titleLblICD4Resource"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlMedicalTest1" runat="server" Width="500" class="chosen"></asp:DropDownList>
                                    </td>
                                    <td width="80" align ="left" >
                                        <asp:TextBox ID="txtICD11" name="wucPrincipalForm1$TextBox11" runat="server" Width="110" MaxLength="50" />
                                    </td>
                                    <td width="80" align ="left">
                                        <asp:TextBox ID="txtICD12" name="wucPrincipalForm1$TextBox12" runat="server" Width="110" MaxLength="50" />
                                    </td>
                                    <td width="80" align ="left">
                                        <asp:TextBox ID="txtICD13" name="wucPrincipalForm1$TextBox13" runat="server" Width="110" MaxLength="50" />
                                    </td>
                                    <td width="80" align ="left">
                                        <asp:TextBox ID="txtICD14" name="wucPrincipalForm1$TextBox14" runat="server" Width="110" MaxLength="50" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlMedicalTest2" runat="server" Width="500" class="chosen"></asp:DropDownList>
                                    </td>
                                    <td width="80" align ="left" >
                                        <asp:TextBox ID="txtICD21" name="wucPrincipalForm1$TextBox21" runat="server" Width="110" MaxLength="50" />
                                    </td>
                                    <td width="80" align ="left">
                                        <asp:TextBox ID="txtICD22" name="wucPrincipalForm1$TextBox22" runat="server" Width="110" MaxLength="50" />
                                    </td>
                                    <td width="80" align ="left">
                                        <asp:TextBox ID="txtICD23" runat="server" name="wucPrincipalForm1$TextBox1123" Width="110" MaxLength="50" />
                                    </td>
                                    <td width="80" align ="left">
                                        <asp:TextBox ID="txtICD24" name="wucPrincipalForm1$TextBox24" runat="server" Width="110" MaxLength="50" />
                                    </td>
                                </tr>
                            </table>                        
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <%--<tr>
            <td colspan="3">
                <uc6:wucGridSearch ID="wucGridSearch1" runat="server"/>
            </td>
        </tr>--%>
        <tr>
            <td>
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btnReset" runat="server" Text="Reset" />
                        </td>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" Text="Search" />
                        </td>
                        <td>
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
                        </td>
                        <td>
                            <asp:Button ID="btnMenu" runat="server" Text="Menu" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>
<div id="divSearch" runat="server">
    <table>
        <tr>
            <td colspan="3">
                <uc6:wucGridSearch ID="wucGridSearch1" runat="server"/>
            </td>
        </tr>
    </table>    
</div>
<div id="divBarcode" runat="server" visible="false">
    <asp:Panel ID="pnlBarcode" runat="server">
        <asp:Image runat="server" ID="imgBarcode" Visible="false"/>
    </asp:Panel>
</div>
<asp:HiddenField ID="hdfPatientId" runat="server"/>
<asp:HiddenField ID="hdfGuarantorId" runat="server"/>
<asp:HiddenField ID="hdfInsuranceId" runat="server"/>
