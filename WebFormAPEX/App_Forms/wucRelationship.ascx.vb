Imports System.Data

Public Class wucRelationship
    Inherits System.Web.UI.UserControl
#Region "Variables"
    Dim dbTransactions As New DataBaseTransactions

#End Region
#Region "Properties"

    Public ReadOnly Property getDdlRelationshipValue As Integer
        Get
            Return ddlRelationship.SelectedItem.Value
        End Get
    End Property

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

    Public Sub loadItems()
        Dim ds As DataSet
        ds = dbTransactions.fillCatalogs()
        ddlRelationship.DataSource = ds.Tables(0)
        ddlRelationship.DataValueField = ds.Tables(0).Columns(0).ToString
        ddlRelationship.DataTextField = ds.Tables(0).Columns(1).ToString
        ddlRelationship.DataBind()
        ddlRelationship.Items.Insert(0, New ListItem(GetLocalResourceObject("selectRelationship").ToString, "-1"))
    End Sub

    Public Sub cleanValues()
        ddlRelationship.SelectedIndex = 0
    End Sub

    Public Sub changeColorTitle(ByVal op As Integer)
        If op = 1 Then
            lblRelationship.ForeColor = Drawing.Color.Red
        Else
            lblRelationship.ForeColor = Drawing.Color.Black
        End If
    End Sub

    Public Sub setValue(ByVal val As String)
        ddlRelationship.SelectedValue = val
    End Sub

End Class