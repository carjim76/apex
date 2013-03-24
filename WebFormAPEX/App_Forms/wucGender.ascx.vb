Partial Class wucGender
    Inherits System.Web.UI.UserControl
#Region "Variables"
    Private _lock As Boolean
#End Region
#Region "Properties"
    'property to get and set value of the DropDownList
    Public ReadOnly Property getDdlGenderValue() As Char
        Get
            Return ddlGender.SelectedItem.Value
        End Get
    End Property
    'Property to get and set the text of DropDownList items
    Public ReadOnly Property getDdlGenderText() As String
        Get
            Return ddlGender.SelectedItem.Text
        End Get
    End Property
    'property to enable or disable the DropDownList
    Public Property Enabled() As Boolean
        Get
            Return ddlGender.Enabled
        End Get
        Set(ByVal value As Boolean)
            ddlGender.Enabled = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            loadItems()
        End If

    End Sub
    'Method to load items DropDownList
    Public Sub loadItems()
        ddlGender.Items.Insert(0, New ListItem(GetLocalResourceObject("itemDefault").ToString, "0"))
        ddlGender.Items.Insert(1, New ListItem(GetLocalResourceObject("itemMale").ToString, "M"))
        ddlGender.Items.Insert(2, New ListItem(GetLocalResourceObject("itemFemale").ToString, "F"))
    End Sub
    'method that sets the DropDownList index to zero
    Public Sub cleanValues()
        ddlGender.SelectedIndex = 0
    End Sub
    'method to change the color of the label that identifies the DropDownList
    Public Sub changeColorTitle(ByVal op As Integer)
        If op = 1 Then
            lblPDGender.ForeColor = Drawing.Color.Red
        Else
            lblPDGender.ForeColor = Drawing.Color.Black
        End If
    End Sub
    'method to set the value of DropDownList
    Public Sub setValue(ByVal val As String)
        ddlGender.SelectedValue = val
    End Sub
End Class