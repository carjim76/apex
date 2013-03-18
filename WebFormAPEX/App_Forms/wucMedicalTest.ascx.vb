Imports System.Data

Public Class wucMedicalTest
    Inherits System.Web.UI.UserControl
#Region "Variables"
    Dim dbTransactions As New DataBaseTransactions
    Private _lcd1 As String
    Private _lcd2 As String
    Private _lcd3 As String
    Private _lcd4 As String

#End Region
#Region "Properties"
    Public ReadOnly Property getDdlMedicalTestValue As Integer
        Get
            Return ddlMedicalTest.SelectedItem.Value
        End Get
    End Property

    Public ReadOnly Property getDdlMedicalTestText
        Get
            Return ddlMedicalTest.SelectedItem.Text
        End Get
    End Property

    Public Property LCD1() As String
        Get
            Return _lcd1
        End Get
        Set(ByVal value As String)
            _lcd1 = txtICD11.Text
        End Set
    End Property

    Public Property LCD2() As String
        Get
            Return _lcd2
        End Get
        Set(ByVal value As String)
            _lcd2 = txtICD12.Text
        End Set
    End Property
    Public Property LCD3() As String
        Get
            Return _lcd3
        End Get
        Set(ByVal value As String)
            _lcd3 = txtICD13.Text
        End Set
    End Property
    Public Property LCD4() As String
        Get
            Return _lcd4
        End Get
        Set(ByVal value As String)
            _lcd4 = txtICD14.Text
        End Set
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
        ddlMedicalTest.DataSource = ds.Tables(4)
        ddlMedicalTest.DataValueField = ds.Tables(4).Columns(0).ToString
        ddlMedicalTest.DataTextField = ds.Tables(4).Columns(1).ToString
        ddlMedicalTest.DataBind()
        ddlMedicalTest.Items.Insert(0, New ListItem(GetLocalResourceObject("selectMedicalTest").ToString, "-1"))
    End Sub

    Public Sub cleanValues()
        ddlMedicalTest.SelectedIndex = 0
    End Sub

End Class