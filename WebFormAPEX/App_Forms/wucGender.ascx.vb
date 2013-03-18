Partial Class wucGender
    Inherits System.Web.UI.UserControl

#Region "Properties"
    Public ReadOnly Property getDdlGenderValue() As Char
        Get
            Return ddlGender.SelectedItem.Value
        End Get
    End Property
    Public ReadOnly Property getDdlGenderText() As String
        Get
            Return ddlGender.SelectedItem.Text
        End Get
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            loadItems()
        End If

    End Sub

    Public Sub loadItems()
        ddlGender.Items.Insert(0, New ListItem(GetLocalResourceObject("itemDefault").ToString, "0"))
        ddlGender.Items.Insert(1, New ListItem(GetLocalResourceObject("itemMale").ToString, "M"))
        ddlGender.Items.Insert(2, New ListItem(GetLocalResourceObject("itemFemale").ToString, "F"))
    End Sub

    Public Sub cleanValues()
        ddlGender.SelectedIndex = 0
    End Sub

    Public Sub changeColorTitle(ByVal op As Integer)
        If op = 1 Then
            lblPDGender.ForeColor = Drawing.Color.Red
        Else
            lblPDGender.ForeColor = Drawing.Color.Black
        End If
    End Sub
    Public Sub setValue(ByVal val As String)
        ddlGender.SelectedValue = val
    End Sub
End Class