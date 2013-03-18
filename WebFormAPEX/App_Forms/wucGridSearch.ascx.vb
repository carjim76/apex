Imports System.Data

Public Class wucGridSearch
    Inherits System.Web.UI.UserControl

#Region "Variables"
    Dim _dt As New DataTable
#End Region

#Region "Properties"
    Public Property Grid() As DataTable
        Get
            Return _dt
        End Get
        Set(ByVal value As DataTable)
            _dt = value
        End Set
    End Property
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Sub FillGrid()
        'Me.gvSearch.DataSource = _ds.Tables(0)
        Me.GridSearch.DataSource = Grid
        Me.GridSearch.DataBind()

        Me.GridSearch.HeaderRow.Cells(1).Text = GetLocalResourceObject("MRN.Header.Text").ToString()
        Me.GridSearch.HeaderRow.Cells(2).Text = GetLocalResourceObject("FirstName.Header.Text").ToString()
        Me.GridSearch.HeaderRow.Cells(3).Text = GetLocalResourceObject("LastName.Header.Text").ToString()
        Me.GridSearch.HeaderRow.Cells(4).Text = GetLocalResourceObject("OrderNumber.Header.Text").ToString()
    End Sub

    Protected Sub GridSearch_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GridSearch.SelectedIndexChanged

    End Sub
End Class
