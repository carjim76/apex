Imports System.Data

Public Class wucState
    Inherits System.Web.UI.UserControl

#Region "Variables"
    Dim dbTransactions As New DataBaseTransactions

#End Region
#Region "Properties"

    Public ReadOnly Property getDdlStateValue As String
        Get
            Return ddlState.SelectedItem.Value
        End Get
    End Property

    Public ReadOnly Property getDdlStateText
        Get
            Return ddlState.SelectedItem.Text
        End Get
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loadItems()
        End If
    End Sub

    Public Sub cleanValues()
        ddlState.SelectedIndex = 0
    End Sub

    Public Sub loadItems()
        Dim ds As DataSet
        ds = dbTransactions.fillCatalogs()
        ddlState.DataSource = ds.Tables(3)
        ddlState.DataValueField = ds.Tables(3).Columns(0).ToString
        ddlState.DataTextField = ds.Tables(3).Columns(1).ToString
        ddlState.DataBind()
        ddlState.Items.Insert(0, New ListItem(GetLocalResourceObject("selectState").ToString, "-1"))
    End Sub

    Public Sub changeColorTitle(ByVal op As Integer)
        If op = 1 Then
            lblState.ForeColor = Drawing.Color.Red
        Else
            lblState.ForeColor = Drawing.Color.Black
        End If
    End Sub
    Public Sub setValue(ByVal val As String)
        ddlState.SelectedValue = val
    End Sub
End Class