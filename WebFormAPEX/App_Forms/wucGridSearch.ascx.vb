Imports System.Data

Public Class wucGridSearch
    Inherits System.Web.UI.UserControl

#Region "Events"
    Public Event FillFormFields()
    Public Event Back()
#End Region
#Region "Variables"
    Dim _dt As New DataTable
#End Region

#Region "Properties"
    'Property to get and set values ​​containing a DataTable
    Public Property Grid() As DataTable
        Get
            Return _dt
        End Get
        Set(ByVal value As DataTable)
            _dt = value
        End Set
    End Property
    'Property to get and set the Id of a patient selected in the GridView
    Public Property PatientId() As Integer
        Get
            Return hdfPatientId.Value
        End Get
        Set(ByVal value As Integer)
            hdfPatientId.Value = value
        End Set
    End Property
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
    End Sub
    'method that loads a search values ​​in GridView
    Public Sub FillGrid()

        Me.GridSearch.DataSource = Grid
        Me.GridSearch.DataBind()

        'Me.GridSearch.HeaderRow.Cells(1).Text = GetLocalResourceObject("MRN.Header.Text").ToString()
        'Me.GridSearch.HeaderRow.Cells(2).Text = GetLocalResourceObject("FirstName.Header.Text").ToString()
        'Me.GridSearch.HeaderRow.Cells(3).Text = GetLocalResourceObject("LastName.Header.Text").ToString()
        'Me.GridSearch.HeaderRow.Cells(4).Text = GetLocalResourceObject("OrderNumber.Header.Text").ToString()
        'Me.GridSearch.HeaderRow.Cells(5).Text = GetLocalResourceObject("Details.Header.Text").ToString()
    End Sub

    
    
    Private Sub GridSearch_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridSearch.RowCommand
        If e.CommandName = "Detail" Then
            'hdfPatientId.Value = GridSearch.DataKeys.Item(e.CommandArgument).Value
            hdfPatientId.Value = GridSearch.DataKeys(e.CommandArgument).Item("patient_id")
            RaiseEvent FillFormFields()
        End If
    End Sub

    Private Sub GridSearch_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridSearch.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btn As ImageButton = CType(e.Row.Cells(3).FindControl("btndetail"), ImageButton)
            btn.CommandArgument = e.Row.RowIndex
        End If
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBack.Click
        RaiseEvent Back()
    End Sub
End Class

