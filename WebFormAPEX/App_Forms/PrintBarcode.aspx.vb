Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports WebFormAPEX
Imports Microsoft.CSharp.CSharpCodeProvider
Imports Microsoft.VisualBasic
Public Class PrintBarcode
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ph As New PrintHelper
        Dim ctrl As Control

        ctrl = Session("ctrl")

        ph.PrintWebControl(ctrl)

    End Sub

End Class