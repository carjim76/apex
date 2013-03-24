Imports System.Data

Public Class wucRelationship
    Inherits System.Web.UI.UserControl
#Region "Variables"
    Dim dbTransactions As New DataBaseTransactions

#End Region
#Region "Properties"
    'Property to get the value of the DropDownList
    Public ReadOnly Property getDdlRelationshipValue As Integer
        Get
            Return ddlRelationship.SelectedItem.Value
        End Get
    End Property
    'Property to get the text of the DropDownList
    Public ReadOnly Property getDdlRelationshipText
        Get
            Return ddlRelationship.SelectedItem.Text
        End Get
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loadItems()
        End If
    End Sub
    'Method to load items DropDownList
    Public Sub loadItems()
        Dim ds As DataSet
        ds = dbTransactions.fillCatalogs()
        ddlRelationship.DataSource = ds.Tables(0)
        ddlRelationship.DataValueField = ds.Tables(0).Columns(0).ToString
        ddlRelationship.DataTextField = ds.Tables(0).Columns(1).ToString
        ddlRelationship.DataBind()
        ddlRelationship.Items.Insert(0, New ListItem(GetLocalResourceObject("selectRelationship").ToString, "-1"))
    End Sub
    'method that sets the DropDownList index to zero
    Public Sub cleanValues()
        ddlRelationship.SelectedIndex = 0
    End Sub
    'method to change the color of the label that identifies the DropDownList
    Public Sub changeColorTitle(ByVal op As Integer)
        If op = 1 Then
            lblRelationship.ForeColor = Drawing.Color.Red
        Else
            lblRelationship.ForeColor = Drawing.Color.Black
        End If
    End Sub
    'method to set the value of DropDownList
    Public Sub setValue(ByVal val As String)
        ddlRelationship.SelectedValue = val
    End Sub

End Class