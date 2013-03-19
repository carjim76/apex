<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="principalForm.aspx.vb" Inherits="WebFormAPEX.principalForm" %>
<%@ Register Src = "wucPrincipalForm.ascx" Tagname = "wucPrincipalForm" TagPrefix = "uc1"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../js/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="../js/chosen/chosen.jquery.min.js"></script>
    <script type="text/javascript" src="../js/formee.js"></script>
    <script type="text/javascript" src="../js/jquery-ui-1.10.2.custom.min.js"></script>
    <script type="text/javascript" src="../js/custom.js"></script>

    <link rel="stylesheet" href="../css/formee-structure.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="../js/chosen/chosen.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="../css/formee-style.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="../css/redmond/jquery-ui-1.10.2.custom.css"  />
    <link rel="stylesheet" href="../css/custom.css" type="text/css" media="screen"/>
    <link rel="stylesheet" href="../css/table.css" type="text/css" media="screen"/>

    <style>
        .formee {
            font-size: 14px;
        }
    
        .title1{
            color: #05568D;
            font-size: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="formee" >
        <div>
        </div>
        <uc1:wucPrincipalForm ID = "wucPrincipalForm1" runat = "server"  />
        <input type="hidden" id="total_selects" name="total_selects"/>
    </form>

</body>
</html>
