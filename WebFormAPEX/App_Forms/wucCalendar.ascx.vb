Public Class wucCalendar
    Inherits System.Web.UI.UserControl

    Public ReadOnly Property getSelectedDate As String
        Get
            If Not TextBox1.MaxLength = 0 Then
                Return Convert.ToDateTime(TextBox1.Text)
            End If
            Return DateAndTime.DateString
        End Get
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'TextBox1.Text = Date.Now
            TextBox1.Text = DateAndTime.Now.ToString("MM/dd/yyyy")
            Calendar1.SelectedDate = DateAndTime.Today
        End If
    End Sub

    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Calendar1.SelectionChanged
        TextBox1.Text = Calendar1.SelectedDate.ToString("MM/dd/yyyy")
    End Sub
End Class