Public Class MyTextBox
    Inherits TextBox
    Implements IPostBackEventHandler

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        If Not Page.ClientScript.IsClientScriptBlockRegistered("OnBlurTextBoxEvent") Then
            Page.ClientScript.RegisterStartupScript(MyBase.GetType, "OnBlurTextBoxEvent", GetScript, True)
            Attributes.Add("onblur", "OnBlurred('" & UniqueID & "','')")
        End If
    End Sub

    Public Delegate Sub OnBlurDelegate(ByVal sender As Object, ByVal e As EventArgs)

    Public Event Blur As OnBlurDelegate

    Protected Sub OnBlur()
        RaiseEvent Blur(Me, EventArgs.Empty)
    End Sub

    Private Function GetScript() As String
        Return "function OnBlurred(control, arg)" & vbCrLf & _
                "{" & vbCrLf & _
                "    __doPostBack(control, arg);" & vbCrLf & _
                "}"
    End Function

    Public Sub RaisePostBackEvent(ByVal eventArgument As String) Implements System.Web.UI.IPostBackEventHandler.RaisePostBackEvent
        OnBlur()
    End Sub
End Class