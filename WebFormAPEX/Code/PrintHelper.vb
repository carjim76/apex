Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO
Imports System.Text
Imports System.Web.SessionState

Public Class PrintHelper

    Public Class PrintHelper

    End Class
    Public Sub PrintWebControl(ByVal ctrl As Control)
        PrintWebControl(ctrl, String.Empty)

    End Sub

    Public Sub PrintWebControl(ByVal ctrl As Control, ByVal script As String)
        Dim stringWrite As StringWriter = New StringWriter
        Dim htmlWrite = New System.Web.UI.HtmlTextWriter(stringWrite)
        

        Dim pg As Page = New Page
        pg.EnableEventValidation = False

        If script <> String.Empty Then
            pg.ClientScript.RegisterStartupScript(pg.GetType(), "PrintJavaScript", script)
        End If

        Dim frm As HtmlForm = New HtmlForm
        Dim strHTML As String
        pg.Controls.Add(frm)
        frm.Attributes.Add("runat", "server")
        frm.Controls.Add(ctrl)
        pg.DesignerInitialize()
        pg.RenderControl(htmlWrite)
        strHTML = stringWrite.ToString()
        HttpContext.Current.Response.Clear()
        HttpContext.Current.Response.Write(strHTML)
        HttpContext.Current.Response.Write("<script>window.print();</script>")
        HttpContext.Current.Response.End()

    End Sub
End Class
