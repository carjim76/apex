Imports System.Drawing.Text
Imports System.Drawing.Printing
Imports System.Drawing
Imports System.Web.UI.WebControls.Image
'Imports System.contr

Public Class wucPrincipalForm
    Inherits System.Web.UI.UserControl

#Region "Variables"
    'global variables of the class
    Dim dbTransactions As New DataBaseTransactions
    Dim dt As DataTable
    Private printer As New PrintDocument()
    Private _MedicalTestChain As String
    Private _insertNewTest As String
    Dim op As Integer

#End Region
#Region "Properties"
    'property to insert "n" number of testing a patient in the database
    Public Property InsertNewTest() As String
        Get
            Return _insertNewTest
        End Get
        Set(ByVal value As String)
            _insertNewTest = value
        End Set
    End Property
    'property to update "n" number of testing a patient in the database
    Public Property MedicalTestChain() As String
        Get
            Return _MedicalTestChain
        End Get
        Set(ByVal value As String)
            _MedicalTestChain = value
        End Set
    End Property

    'property to load the test catalog in a session variable
    Public Property DropDownSelectValues() As DataTable
        Get
            Return IIf(Session("DropDownSelectValues") Is Nothing, _
                       New DataTable("DropDownSelectValues"), _
                       CType(Session("DropDownSelectValues"), DataTable))
        End Get
        Set(ByVal value As DataTable)
            Session("DropDownSelectValues") = value
        End Set
    End Property

    'property to store the values ​​of the "ICD's"
    Public Property DropDownsDataInMemory() As DataTable
        Get
            Dim dtDropDownsData As DataTable

            If Session("DropDownsData") IsNot Nothing Then
                dtDropDownsData = CType(Session("DropDownsData"), DataTable)
            Else
                dtDropDownsData = New DataTable("DropDownsData")

                'DropDown id
                Dim dcIdDropDown As New DataColumn
                dcIdDropDown.AllowDBNull = False
                dcIdDropDown.AutoIncrement = True
                dcIdDropDown.ColumnName = "Id"
                dcIdDropDown.DataType = Type.GetType("System.Int32")

                'Add the first column to maintain the dropdown id.
                dtDropDownsData.Columns.Add(dcIdDropDown)

                'DropDown value
                Dim dcValueDropDown As New DataColumn
                dcValueDropDown.ColumnName = "Value"
                dcValueDropDown.DataType = Type.GetType("System.String")

                'Add the Second column to maintain the dropdown value.
                dtDropDownsData.Columns.Add(dcValueDropDown)

                'ICD1 value
                Dim dcValueicd1 As New DataColumn
                dcValueicd1.ColumnName = "icd1"
                dcValueicd1.DataType = Type.GetType("System.String")

                'Add the third column to maintain the icd1 value.
                dtDropDownsData.Columns.Add(dcValueicd1)

                'ICD2 value
                Dim dcValueicd2 As New DataColumn
                dcValueicd2.ColumnName = "icd2"
                dcValueicd2.DataType = Type.GetType("System.String")

                'Add the fourth column to maintain the icd2 value.
                dtDropDownsData.Columns.Add(dcValueicd2)

                'ICD3 value
                Dim dcValueicd3 As New DataColumn
                dcValueicd3.ColumnName = "icd3"
                dcValueicd3.DataType = Type.GetType("System.String")

                'Add the fifth column to maintain the icd3 value.
                dtDropDownsData.Columns.Add(dcValueicd3)

                'ICD4 value
                Dim dcValueicd4 As New DataColumn
                dcValueicd4.ColumnName = "icd4"
                dcValueicd4.DataType = Type.GetType("System.String")

                'Add the fifth column to maintain the icd3 value.
                dtDropDownsData.Columns.Add(dcValueicd4)

                Dim drDefault As DataRow = dtDropDownsData.NewRow
                drDefault("Value") = "-1"
                drDefault("icd1") = ""
                drDefault("icd2") = ""
                drDefault("icd3") = ""
                drDefault("icd4") = ""

                dtDropDownsData.Rows.Add(drDefault)
                dtDropDownsData.AcceptChanges()

            End If
            Return dtDropDownsData
        End Get
        Set(ByVal value As DataTable)
            Session("DropDownsData") = value
        End Set
    End Property
#End Region
    'event that initializes the form
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler wucGridSearch1.FillFormFields, AddressOf SelectPatient
        AddHandler wucGridSearch1.Back, AddressOf back

        If Not Page.IsPostBack Then
            Me.divSearch.Visible = False
            loadHour()
            loadCatalogs()
            getOrderNumber()
            Session("option") = 1

            BindDropDowns()
            ClearDropdowns()
        End If

    End Sub
    'repeater control event "rptDropDowns" to add n number of tests in the form
    Protected Sub rptDropDowns_ItemDataBound(ByVal sender As Object, _
                                             ByVal e As RepeaterItemEventArgs) Handles rptDropDowns.ItemDataBound
        '
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim ddlMedicalTest As DropDownList = CType(e.Item.FindControl("ddlMedicalTest"), DropDownList)
            Dim txtICD1 As TextBox = CType(e.Item.FindControl("txtICD1"), TextBox)
            Dim txtICD2 As TextBox = CType(e.Item.FindControl("txtICD2"), TextBox)
            Dim txtICD3 As TextBox = CType(e.Item.FindControl("txtICD3"), TextBox)
            Dim txtICD4 As TextBox = CType(e.Item.FindControl("txtICD4"), TextBox)

            If Not ddlMedicalTest Is Nothing Then
                ddlMedicalTest.DataSource = DropDownSelectValues
                ddlMedicalTest.DataTextField = "test_name"
                ddlMedicalTest.DataValueField = "test_name_id"
                ddlMedicalTest.DataBind()
                'Default value
                ddlMedicalTest.Items.Insert(0, New ListItem(GetLocalResourceObject("selectMedicalTest").ToString, "-1"))

                'Select the correct value stored in memory table.
                Dim SelectedValue As String = CType(e.Item.DataItem, DataRowView)("Value")
                Dim Icd1Text As String = CType(e.Item.DataItem, DataRowView)("icd1")
                Dim Icd2Text As String = CType(e.Item.DataItem, DataRowView)("icd2")
                Dim Icd3Text As String = CType(e.Item.DataItem, DataRowView)("icd3")
                Dim Icd4Text As String = CType(e.Item.DataItem, DataRowView)("icd4")

                If Not ddlMedicalTest.Items.FindByValue(SelectedValue) Is Nothing Then
                    ddlMedicalTest.SelectedValue = SelectedValue
                    txtICD1.Text = Icd1Text
                    txtICD2.Text = Icd2Text
                    txtICD3.Text = Icd3Text
                    txtICD4.Text = Icd4Text
                End If

            End If
        End If
    End Sub

    'event that creates a new dod dwon list to select a member from the list of control "ddlMedicalTest"
    Protected Sub ddlMedicalTest_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)

        Dim DropwDownId As String = CType(CType(sender, DropDownList).Parent.FindControl("hdnId"), HiddenField).Value
        Dim DropDownValue As String = CType(sender, DropDownList).SelectedValue

        Dim Icd1Value As String = CType(CType(sender, DropDownList).Parent.FindControl("txtICD1"), TextBox).Text
        Dim Icd2Value As String = CType(CType(sender, DropDownList).Parent.FindControl("txtICD2"), TextBox).Text
        Dim Icd3Value As String = CType(CType(sender, DropDownList).Parent.FindControl("txtICD3"), TextBox).Text
        Dim Icd4Value As String = CType(CType(sender, DropDownList).Parent.FindControl("txtICD4"), TextBox).Text

        If DropDownValue <> -1 Then
            'Save current selected value in dropdown
            Dim dtTempo As DataTable = DropDownsDataInMemory
            dtTempo.Rows(Convert.ToInt32(DropwDownId))("Value") = DropDownValue
            dtTempo.Rows(Convert.ToInt32(DropwDownId))("icd1") = Icd1Value
            dtTempo.Rows(Convert.ToInt32(DropwDownId))("icd2") = Icd2Value
            dtTempo.Rows(Convert.ToInt32(DropwDownId))("icd3") = Icd3Value
            dtTempo.Rows(Convert.ToInt32(DropwDownId))("icd4") = Icd4Value
            dtTempo.AcceptChanges()
            DropDownsDataInMemory = dtTempo

            'update DropDownsDataInMemory with icd's data
            LoadDataICDS()

            'determine if a DropDown control must be added
            AddNewDropDown(DropwDownId)
        End If

    End Sub
    'metodo para obtener los valores de los ICD's
    Sub LoadDataICDS()
        For i As Integer = 0 To DropDownsDataInMemory.Rows.Count - 1

            Dim dtTempo As DataTable = DropDownsDataInMemory
            Dim num As String = ""

            num = IIf(i < 10, "0" & i, i)

            dtTempo.Rows(Convert.ToInt32(i))("icd1") = Request.Form("wucPrincipalForm1$rptDropDowns$ctl" & num & "$txtICD1")
            dtTempo.Rows(Convert.ToInt32(i))("icd2") = Request.Form("wucPrincipalForm1$rptDropDowns$ctl" & num & "$txtICD2")
            dtTempo.Rows(Convert.ToInt32(i))("icd3") = Request.Form("wucPrincipalForm1$rptDropDowns$ctl" & num & "$txtICD3")
            dtTempo.Rows(Convert.ToInt32(i))("icd4") = Request.Form("wucPrincipalForm1$rptDropDowns$ctl" & num & "$txtICD4")
            dtTempo.AcceptChanges()
            DropDownsDataInMemory = dtTempo

        Next
    End Sub
    'method to add a new DropDownList and set its default values
    Sub AddNewDropDown(ByVal id As String)

        Dim dvFilter As New DataView(DropDownsDataInMemory)
        dvFilter.RowFilter = String.Format("Id = {0}", id)
        If Not dvFilter.ToTable().Rows.Count.Equals(0) AndAlso _
            DropDownsDataInMemory.Rows(DropDownsDataInMemory.Rows.Count - 1)("Id").ToString().Equals(id) Then
            Dim drNewDropDown As DataRow = DropDownsDataInMemory.NewRow()
            drNewDropDown("Value") = "-1"
            drNewDropDown("icd1") = ""
            drNewDropDown("icd2") = ""
            drNewDropDown("icd3") = ""
            drNewDropDown("icd4") = ""
            DropDownsDataInMemory.Rows.Add(drNewDropDown)
            DropDownsDataInMemory.AcceptChanges()
        End If
        BindDropDowns()
    End Sub

    'function that returns the value of the DropDownsDataInMemory property
    Function GetDataDropDowns() As DataTable

        Return DropDownsDataInMemory

    End Function

    'method that adds the user-created DropDownList
    Sub BindDropDowns()
        rptDropDowns.DataSource = GetDataDropDowns()
        rptDropDowns.DataBind()
    End Sub
    'method that deleted the DropDownList user-created 
    Sub ClearDropdowns()
        DropDownsDataInMemory = Nothing
        BindDropDowns()
    End Sub
    'event to clear entries in the form
    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReset.Click
        cleanForm()
        cleanVariables()
        FieldsEnable(True)
        Session("option") = 1
        btnSubmit.Text = "SUBMIT"
    End Sub
    'Method to clean the form fields
    Public Sub cleanForm()

        txtPDMRN.Text = ""
        txtPDFirstName.Text = ""
        txtPDMiddleName.Text = ""
        txtPDLastName.Text = ""
        txtPDBirthday.Text = ""
        txtPDAddress.Text = ""
        txtPDCity.Text = ""
        txtPDZip.Text = ""
        txtPDDateSpecimenCollect.Text = ""
        getOrderNumber()

        loadHour()

        txtGDFirstName.Text = ""
        txtGDMiddleName.Text = ""
        txtGDLastName.Text = ""
        txtGDBirthday.Text = ""
        txtGDAddress.Text = ""
        txtGDCity.Text = ""
        txtGDZip.Text = ""

        txtInsurancePlan.Text = ""
        txtIDFirstName.Text = ""
        txtIDMiddleName.Text = ""
        txtIDLastName.Text = ""
        txtIDBirthday.Text = ""
        txtIDAddress.Text = ""
        txtIDCity.Text = ""
        txtIDZip.Text = ""
        txtIDGroup.Text = ""
        txtIDPolicy.Text = ""

        wucGender1.cleanValues()
        wucGender2.cleanValues()
        wucGender3.cleanValues()
        wucRelationship1.cleanValues()
        wucRelationship2.cleanValues()
        wucState1.cleanValues()
        wucState2.cleanValues()
        wucState3.cleanValues()

        ddlPDEthnicity.SelectedIndex = 0
        ddlOrderingProvider.SelectedIndex = 0

        lblOrderingProvider.ForeColor = Drawing.Color.Black

        lblPDMRN.ForeColor = Drawing.Color.Black

        lblPDFirstName.ForeColor = Drawing.Color.Black

        lblPDLastName.ForeColor = Drawing.Color.Black

        wucGender1.changeColorTitle(2)

        lblPDEthnicity.ForeColor = Drawing.Color.Black

        wucState1.changeColorTitle(2)

        lblTest.ForeColor = Drawing.Color.Black

        lblTest.ForeColor = Drawing.Color.Black

        lblGDFirstName.ForeColor = Drawing.Color.Black

        lblGDLastName.ForeColor = Drawing.Color.Black

        wucGender2.changeColorTitle(2)

        wucRelationship1.changeColorTitle(2)

        wucState2.changeColorTitle(2)

        lblIDFirstName.ForeColor = Drawing.Color.Black

        lblIDLastName.ForeColor = Drawing.Color.Black


        wucGender3.changeColorTitle(2)

        wucRelationship2.changeColorTitle(2)

        wucState3.changeColorTitle(2)

        ClearDropdowns()

    End Sub
    'Method that collects form data and save it in database
    Public Sub CollectDataOfForm()
        Try
            Dim strDate, strHour, strDateAndHour As String
            op = Session("option")

            If op = 2 Then
                dbTransactions.PatientId = IIf(hdfPatientId.Value <> "", hdfPatientId.Value, 0)
                dbTransactions.GuarantorId = IIf(hdfGuarantorId.Value <> "", hdfGuarantorId.Value, 0)
                dbTransactions.InsuranceId = IIf(hdfInsuranceId.Value <> "", hdfInsuranceId.Value, 0)
                dbTransactions.OrderId = IIf(txtPDOrder.Text <> "", txtPDOrder.Text, 0)
            End If

            dbTransactions.PatientMRN = IIf(txtPDMRN.Text <> "", txtPDMRN.Text, 0)
            dbTransactions.PatientFirstname = IIf(txtPDFirstName.Text <> "", txtPDFirstName.Text, " ")
            dbTransactions.PatientMiddleName = txtPDMiddleName.Text
            dbTransactions.PatientLastname = IIf(txtPDLastName.Text <> "", txtPDLastName.Text, " ")
            dbTransactions.PatientGender = wucGender1.getDdlGenderValue
            dbTransactions.PatientDOB = IIf(txtPDBirthday.Text <> "", txtPDBirthday.Text, " ")
            dbTransactions.PatientEthnicityId = ddlPDEthnicity.SelectedItem.Value
            dbTransactions.PatientAddress = IIf(txtPDAddress.Text <> "", txtPDAddress.Text, " ")
            dbTransactions.PatientCity = IIf(txtPDCity.Text <> "", txtPDCity.Text, " ")
            dbTransactions.PatientStateId = wucState1.getDdlStateValue
            dbTransactions.PatientZip = IIf(txtPDZip.Text <> "", txtPDZip.Text, " ")

            dbTransactions.GuarantorFirstname = IIf(txtGDFirstName.Text <> "", txtGDFirstName.Text, " ")
            dbTransactions.GuarantorMiddleName = txtGDMiddleName.Text
            dbTransactions.GuarantorLastname = IIf(txtGDLastName.Text <> "", txtGDLastName.Text, " ")
            dbTransactions.GuarantorGender = wucGender2.getDdlGenderValue
            dbTransactions.GuarantorDOB = IIf(txtGDBirthday.Text <> "", txtGDBirthday.Text, " ")
            dbTransactions.GuarantorRelationshipId = wucRelationship1.getDdlRelationshipValue
            dbTransactions.GuarantorAddress = IIf(txtGDAddress.Text <> "", txtGDAddress.Text, " ")
            dbTransactions.GuarantorCity = IIf(txtGDCity.Text <> "", txtGDCity.Text, " ")
            dbTransactions.GuarantorStateId = wucState2.getDdlStateValue
            dbTransactions.GuarantorZip = IIf(txtGDZip.Text <> "", txtGDZip.Text, " ")

            dbTransactions.InsurancePlan = IIf(txtInsurancePlan.Text <> "", txtInsurancePlan.Text, " ")
            dbTransactions.InsuranceFirstname = IIf(txtIDFirstName.Text <> "", txtIDFirstName.Text, " ")
            dbTransactions.InsuranceNiddleName = txtIDMiddleName.Text
            dbTransactions.InsuranceLastname = IIf(txtIDLastName.Text <> "", txtIDLastName.Text, " ")
            dbTransactions.InsuranceGender = wucGender3.getDdlGenderValue
            dbTransactions.InsuranceDOB = IIf(txtIDBirthday.Text <> "", txtIDBirthday.Text, " ")
            dbTransactions.InsuranceRelationshipId = wucRelationship2.getDdlRelationshipValue
            dbTransactions.InsuranceAddress = IIf(txtIDAddress.Text <> "", txtIDAddress.Text, " ")
            dbTransactions.InsuranceCity = IIf(txtIDCity.Text <> "", txtIDCity.Text, " ")
            dbTransactions.InsuranceStateId = wucState3.getDdlStateValue
            dbTransactions.InsuranceZip = IIf(txtIDZip.Text <> "", txtIDZip.Text, " ")

            strDate = IIf(txtPDDateSpecimenCollect.Text <> "", txtPDDateSpecimenCollect.Text, " ")
            strHour = IIf(txtPDHourSpecimenCollectDate.Text <> "", txtPDHourSpecimenCollectDate.Text, " ")
            strDateAndHour = strDate & " " & strHour
            dbTransactions.PatientSpecimenCollect = IIf(txtPDDateSpecimenCollect.Text <> "", strDateAndHour, " ")

            collectMedicalTest()

        Catch ex As Exception

        End Try

    End Sub
    'method that validates the required fields of the form
    Public Function validateFields() As Boolean
        Dim flag As Boolean = True

        If txtPDMRN.Text = "" Then
            flag = False
            lblPDMRN.ForeColor = Drawing.Color.Red
        Else
            lblPDMRN.ForeColor = Drawing.Color.Black
        End If
        If txtPDFirstName.Text = "" Then
            flag = False
            lblPDFirstName.ForeColor = Drawing.Color.Red
        Else
            lblPDFirstName.ForeColor = Drawing.Color.Black
        End If
        If txtPDLastName.Text = "" Then
            flag = False
            lblPDLastName.ForeColor = Drawing.Color.Red
        Else
            lblPDLastName.ForeColor = Drawing.Color.Black
        End If

        If txtGDFirstName.Text = "" Then
            flag = False
            lblGDFirstName.ForeColor = Drawing.Color.Red
        Else
            lblGDFirstName.ForeColor = Drawing.Color.Black
        End If
        If txtGDLastName.Text = "" Then
            flag = False
            lblGDLastName.ForeColor = Drawing.Color.Red
        Else
            lblGDLastName.ForeColor = Drawing.Color.Black
        End If
        
        If txtIDFirstName.Text = "" Then
            flag = False
            lblIDFirstName.ForeColor = Drawing.Color.Red
        Else
            lblIDFirstName.ForeColor = Drawing.Color.Black
        End If
        If txtIDLastName.Text = "" Then
            flag = False
            lblIDLastName.ForeColor = Drawing.Color.Red
        Else
            lblIDLastName.ForeColor = Drawing.Color.Black
        End If

        Return flag
    End Function
    'charging method that DropDownList values ​​with data from catalogs database
    Public Sub loadCatalogs()
        Dim ds As DataSet
        ds = dbTransactions.fillCatalogs()

        ddlPDEthnicity.DataSource = ds.Tables(1)
        ddlPDEthnicity.DataValueField = ds.Tables(1).Columns(0).ToString
        ddlPDEthnicity.DataTextField = ds.Tables(1).Columns(1).ToString
        ddlPDEthnicity.DataBind()
        ddlPDEthnicity.Items.Insert(0, New ListItem(GetLocalResourceObject("selectEthicity").ToString, "-1"))

        ddlOrderingProvider.DataSource = ds.Tables(2)
        ddlOrderingProvider.DataValueField = ds.Tables(2).Columns(0).ToString
        ddlOrderingProvider.DataTextField = ds.Tables(2).Columns(1).ToString
        ddlOrderingProvider.DataBind()
        ddlOrderingProvider.Items.Insert(0, New ListItem(GetLocalResourceObject("selectProvider").ToString, "-1"))

        If ds.Tables.Count > 4 Then
            DropDownSelectValues = ds.Tables(4)
        End If

    End Sub
    'event that adds or updates the data of a patient
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click

        Dim result As Integer
        Dim MsjAlert As String
        op = Session("option")

        LoadDataICDS()

        If op = 1 Then

            insertNewPatien()
        Else

            collectDataOfForm()
            result = dbTransactions.patientDataUpdates
            If result <> 0 Then
                MsjAlert = "<script language='JavaScript'>" & _
                "alert('" & GetLocalResourceObject("MsSuccessUpdate") & "')" & _
                "</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MsjAlert", MsjAlert)
            Else
                MsjAlert = "<script language='JavaScript'>" & _
                "alert('" & GetLocalResourceObject("MsErrorUpdate") & "')" & _
                "</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MsjAlert", MsjAlert)
            End If

        End If

    End Sub
    'event to search the data of a patient
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Dim ds As DataSet
        Dim dt As DataTable

        Session("option") = 2
        collectDataOfForm()

        dt = dbTransactions.SearchPatients

        wucGridSearch1.Grid = dt
        wucGridSearch1.FillGrid()

        Me.divForm.Visible = False
        Me.divSearch.Visible = True
        btnSubmit.Text = "UPDATE"
    End Sub
    'method that loads patient data after performing a search
    Public Sub fillFormFields(ByVal ds As DataSet)

        Dim stringDate As Date
        hdfPatientId.Value = ds.Tables(0).Rows(0)(0)
        txtPDMRN.Text = ds.Tables(0).Rows(0)(1) '
        txtPDFirstName.Text = ds.Tables(0).Rows(0)(2)
        txtPDMiddleName.Text = ds.Tables(0).Rows(0)(3)
        txtPDLastName.Text = ds.Tables(0).Rows(0)(4)
        wucGender1.setValue(ds.Tables(0).Rows(0)(5))

        stringDate = CType(ds.Tables(0).Rows(0)(6), DateTime)
        txtPDBirthday.Text = stringDate.ToString("MM/dd/yyyy")

        ddlPDEthnicity.SelectedValue = ds.Tables(0).Rows(0)(7)
        txtPDAddress.Text = ds.Tables(0).Rows(0)(8)
        txtPDCity.Text = ds.Tables(0).Rows(0)(9)
        wucState1.setValue(ds.Tables(0).Rows(0)(10))
        txtPDZip.Text = ds.Tables(0).Rows(0)(11)

        hdfGuarantorId.Value = ds.Tables(1).Rows(0)(0)
        txtGDFirstName.Text = ds.Tables(1).Rows(0)(1)
        txtGDMiddleName.Text = ds.Tables(1).Rows(0)(2)
        txtGDLastName.Text = ds.Tables(1).Rows(0)(3)
        wucGender2.setValue(ds.Tables(1).Rows(0)(4))
        stringDate = CType(ds.Tables(1).Rows(0)(5), DateTime)
        txtGDBirthday.Text = stringDate.ToString("MM/dd/yyyy")
        wucRelationship1.setValue(ds.Tables(1).Rows(0)(6))
        txtGDAddress.Text = ds.Tables(1).Rows(0)(7)
        txtGDCity.Text = ds.Tables(1).Rows(0)(8)
        wucState2.setValue(ds.Tables(1).Rows(0)(9))
        txtGDZip.Text = ds.Tables(1).Rows(0)(10)

        hdfInsuranceId.Value = ds.Tables(2).Rows(0)(0)
        txtInsurancePlan.Text = ds.Tables(2).Rows(0)(1)
        txtIDFirstName.Text = ds.Tables(2).Rows(0)(2)
        txtIDMiddleName.Text = ds.Tables(2).Rows(0)(3)
        txtIDLastName.Text = ds.Tables(2).Rows(0)(4)
        wucGender3.setValue(ds.Tables(2).Rows(0)(5))
        stringDate = CType(ds.Tables(2).Rows(0)(6), DateTime)
        txtIDBirthday.Text = stringDate.ToString("MM/dd/yyyy")
        wucRelationship2.setValue(ds.Tables(2).Rows(0)(7))
        txtIDAddress.Text = ds.Tables(2).Rows(0)(8)
        txtIDCity.Text = ds.Tables(2).Rows(0)(9)
        wucState3.setValue(ds.Tables(2).Rows(0)(10))
        txtIDZip.Text = ds.Tables(2).Rows(0)(11)
        txtIDGroup.Text = ""
        txtIDPolicy.Text = ""

        txtPDOrder.Text = ds.Tables(3).Rows(0)(0)
        stringDate = CType(ds.Tables(3).Rows(0)(1), DateTime)
        txtPDDateSpecimenCollect.Text = stringDate.ToString("MM/dd/yyyy")
        txtPDHourSpecimenCollectDate.Text = stringDate.ToString("HH:mm")

        Session("NumRows") = ds.Tables(4).Rows.Count
        LoadMedicalTest(ds.Tables(4))
        BindDropDowns()

    End Sub
    'method that collects the values ​​of the patient's medical tests and stores them in a string
    Public Sub collectMedicalTest()
        
        Try
            If DropDownsDataInMemory IsNot Nothing Then
                Dim total As Integer
                Dim testId As String
                Dim icd1 As String
                Dim icd2 As String
                Dim icd3 As String
                Dim icd4 As String
                Dim OrderTestId As String
                Dim op As Integer = Session("option")
                Dim NumRows As Integer = Session("NumRows")

                total = DropDownsDataInMemory.Rows.Count
                MedicalTestChain = Nothing
                InsertNewTest = Nothing

                For i As Integer = 0 To total - 1

                    testId = DropDownsDataInMemory.Rows(i)(1)
                    If testId <> "-1" Then
                        If op = 1 Then
                            icd1 = DropDownsDataInMemory.Rows(i)(2)
                            icd2 = DropDownsDataInMemory.Rows(i)(3)
                            icd3 = DropDownsDataInMemory.Rows(i)(4)
                            icd4 = DropDownsDataInMemory.Rows(i)(5)

                            InsertNewTest = InsertNewTest & testId & "," & icd1 & "," & icd2 & "," & icd3 & "," & icd4 & "|"
                        Else

                            icd1 = DropDownsDataInMemory.Rows(i)(2)
                            icd2 = DropDownsDataInMemory.Rows(i)(3)
                            icd3 = DropDownsDataInMemory.Rows(i)(4)
                            icd4 = DropDownsDataInMemory.Rows(i)(5)
                            OrderTestId = DropDownsDataInMemory.Rows(i)(6)

                            If i < NumRows Then
                                MedicalTestChain = MedicalTestChain & OrderTestId & "," & testId & "," & icd1 & "," & icd2 & "," & icd3 & "," & icd4 & "|"
                            Else
                                InsertNewTest = InsertNewTest & testId & "," & icd1 & "," & icd2 & "," & icd3 & "," & icd4 & "|"
                            End If
                        End If
                    End If

                Next

                If InsertNewTest IsNot Nothing Then
                    InsertNewTest = InsertNewTest.Remove(InsertNewTest.Length - 1, 1)
                    dbTransactions.InsertNewTestChain = InsertNewTest
                    If op = 2 Then

                        dbTransactions.InsertNewTests()

                    End If
                Else
                    dbTransactions.InsertNewTestChain = ""
                End If

                If MedicalTestChain IsNot Nothing Then
                    MedicalTestChain = MedicalTestChain.Remove(MedicalTestChain.Length - 1, 1)
                    dbTransactions.MedicalTestChain = MedicalTestChain
                Else
                    dbTransactions.MedicalTestChain = ""
                End If

            End If
        Catch ex As Exception

        End Try

    End Sub
    'method that gets the last order number inserted into the database
    Public Sub getOrderNumber()
        Dim dt As DataTable
        Dim orderNumber As Integer

        dt = dbTransactions.getOrderNumber()

        If dt.Rows.Count < 1 Then
            txtPDOrder.Text = 1
        Else
            orderNumber = dt.Rows(0)(0)
            txtPDOrder.Text = orderNumber + 1
        End If

    End Sub
    'event that prints the bar code to each patient's medical test
    Protected Sub printBC_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles printBC.Click
        Dim strcadena As String
        Dim dateString As String
        Dim espace() As LiteralControl
        Dim intro() As LiteralControl
        Dim img() As WebControls.Image
        Dim lbl() As Label
        Dim testDescription As String = ""

        If txtPDFirstName.Text <> "" And txtPDBirthday.Text <> "" And wucGender1.getDdlGenderText <> "" Then
            If DropDownsDataInMemory.Rows.Count > 1 Then
                For i As Integer = 0 To DropDownsDataInMemory.Rows.Count - 1
                    If DropDownsDataInMemory.Rows(i)(1) <> "-1" Then

                        For j As Integer = 0 To DropDownSelectValues.Rows.Count - 1
                            If DropDownsDataInMemory.Rows(i)(1) = DropDownSelectValues.Rows(j)(0) Then
                                testDescription = DropDownSelectValues.Rows(j)(1)
                                Exit For
                            End If
                        Next
                        ReDim Preserve lbl(i)
                        ReDim Preserve img(i)
                        ReDim Preserve intro(i)

                        lbl(i) = New Label
                        img(i) = New WebControls.Image
                        dateString = Replace(txtPDBirthday.Text, "/", "")
                        
                        strcadena = "*" & txtPDOrder.Text & txtPDFirstName.Text & dateString & wucGender1.getDdlGenderValue & DropDownsDataInMemory.Rows(i)(1) & "*"

                        lbl(i).Text = "Order number: " & txtPDOrder.Text & " Patienr Name: " & txtPDFirstName.Text & " " & txtPDLastName.Text & " Birthday: " & txtPDBirthday.Text & " Gender: " & wucGender1.getDdlGenderText & " Test: " & testDescription
                        img(i).ImageUrl = String.Format("BarcodeGenerator.ashx?code={0}", strcadena)

                        intro(i) = New LiteralControl("<br />")

                        pnlBarcode.Controls.Add(lbl(i))
                        pnlBarcode.Controls.Add(intro(i))
                        pnlBarcode.Controls.Add(img(i))

                        Session("ctrl") = pnlBarcode
                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "onclick", "<script language=javascript>window.open('PrintBarcode.aspx','PrintMe','height=600px,width=400px,scrollbars=1');</script>")

                    End If
                    
                Next

                

            End If


        End If

        
    End Sub
    'method that displays patient data after being selected from a grid
    Public Sub SelectPatient()
        Dim ds As DataSet
        dbTransactions.PatientId = wucGridSearch1.PatientId
        ds = dbTransactions.searchDataByPatientId()
        fillFormFields(ds)
        Me.divForm.Visible = True
        Me.divSearch.Visible = False
        FieldsEnable(False)
    End Sub
    'method that initializes the value of the properties of the class DataBaseTransactions
    Public Sub cleanVariables()
        dbTransactions.PatientId = 0
        dbTransactions.PatientMRN = 0
        dbTransactions.PatientFirstname = ""
        dbTransactions.PatientMiddleName = ""
        dbTransactions.PatientLastname = ""
        dbTransactions.PatientGender = ""
        dbTransactions.PatientDOB = ""
        dbTransactions.PatientEthnicityId = 0
        dbTransactions.PatientAddress = ""
        dbTransactions.PatientCity = ""
        dbTransactions.PatientStateId = ""
        dbTransactions.PatientZip = ""

        dbTransactions.GuarantorId = 0
        dbTransactions.GuarantorFirstname = ""
        dbTransactions.GuarantorMiddleName = ""
        dbTransactions.GuarantorLastname = ""
        dbTransactions.GuarantorGender = ""
        dbTransactions.GuarantorDOB = ""
        dbTransactions.GuarantorRelationshipId = 0
        dbTransactions.GuarantorAddress = ""
        dbTransactions.GuarantorCity = ""
        dbTransactions.GuarantorStateId = ""
        dbTransactions.GuarantorZip = ""

        dbTransactions.InsuranceId = 0
        dbTransactions.InsurancePlan = ""
        dbTransactions.InsuranceFirstname = ""
        dbTransactions.InsuranceNiddleName = ""
        dbTransactions.InsuranceLastname = ""
        dbTransactions.InsuranceGender = ""
        dbTransactions.InsuranceDOB = ""
        dbTransactions.InsuranceRelationshipId = 0
        dbTransactions.InsuranceAddress = ""
        dbTransactions.InsuranceCity = ""
        dbTransactions.InsuranceStateId = ""
        dbTransactions.InsuranceZip = ""

        dbTransactions.OrderId = 0
        dbTransactions.PatientSpecimenCollect = ""
        dbTransactions.MedicalTestChain = ""

    End Sub
    'method that gets the current time
    Public Sub loadHour()
        Dim time As DateTime = Now
        txtPDHourSpecimenCollectDate.Text = time.ToString("HH:mm")
    End Sub
    'method that inserts data from a new patient
    Public Sub insertNewPatien()
        Dim result As Integer
        Dim numberOfRows As Integer
        Dim ds As DataSet
        Dim MsjAlert As String

        If validateFields() Then
            collectDataOfForm()
            ds = dbTransactions.searchData()
            numberOfRows = ds.Tables(0).Rows.Count
            If numberOfRows < 1 Then
                result = dbTransactions.dataProcessing()
                If result <> 0 Then
                    MsjAlert = "<script language='JavaScript'>" & _
                    "alert('" & GetLocalResourceObject("MsSuccess") & "')" & _
                    "</script>"
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MsjAlert", MsjAlert)
                Else
                    MsjAlert = "<script language='JavaScript'>" & _
                    "alert('" & GetLocalResourceObject("MsError") & "')" & _
                    "</script>"
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MsjAlert", MsjAlert)
                End If
            Else

                MsjAlert = "<script language='JavaScript'>" & _
                    "alert('" & GetLocalResourceObject("MsMrnDuplicated") & "')" & _
                    "</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MsjAlert", MsjAlert)
            End If
        Else
            MsjAlert = "<script language='JavaScript'>" & _
                    "alert('" & GetLocalResourceObject("MsValidated") & "')" & _
                    "</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MsjAlert", MsjAlert)

        End If
    End Sub
    'method that displays the main form after a search
    Public Sub back()
        Me.divForm.Visible = True
        Me.divSearch.Visible = False
        btnSubmit.Text = "SUBMIT"
        Session("option") = 1
    End Sub
    'method that enables or disables the field "MRN"
    Public Sub FieldsEnable(ByVal lock As Boolean)

        txtPDMRN.Enabled = lock
        
    End Sub
    'metodo que recarga el valor de la propiedad DropDownsDataInMemory
    Sub LoadMedicalTest(ByVal table As DataTable)

        Dim dtDropDownsData As DataTable

        dtDropDownsData = New DataTable("DropDownsData")

        'DropDown id 
        Dim dcIdDropDown As New DataColumn
        dcIdDropDown.AllowDBNull = False
        dcIdDropDown.AutoIncrement = True
        dcIdDropDown.ColumnName = "Id"
        dcIdDropDown.DataType = Type.GetType("System.Int32")

        'Add the first column to maintain the dropdown id. 
        dtDropDownsData.Columns.Add(dcIdDropDown)

        'DropDown value 
        Dim dcValueDropDown As New DataColumn
        dcValueDropDown.ColumnName = "Value"
        dcValueDropDown.DataType = Type.GetType("System.String")

        'Add the Second column to maintain the dropdown value. 
        dtDropDownsData.Columns.Add(dcValueDropDown)

        'ICD1 value 
        Dim dcValueicd1 As New DataColumn
        dcValueicd1.ColumnName = "icd1"
        dcValueicd1.DataType = Type.GetType("System.String")

        'Add the third column to maintain the icd1 value. 
        dtDropDownsData.Columns.Add(dcValueicd1)

        'ICD2 value 
        Dim dcValueicd2 As New DataColumn
        dcValueicd2.ColumnName = "icd2"
        dcValueicd2.DataType = Type.GetType("System.String")

        'Add the fourth column to maintain the icd2 value. 
        dtDropDownsData.Columns.Add(dcValueicd2)

        'ICD3 value 
        Dim dcValueicd3 As New DataColumn
        dcValueicd3.ColumnName = "icd3"
        dcValueicd3.DataType = Type.GetType("System.String")

        'Add the fifth column to maintain the icd3 value. 
        dtDropDownsData.Columns.Add(dcValueicd3)

        'ICD4 value 
        Dim dcValueicd4 As New DataColumn
        dcValueicd4.ColumnName = "icd4"
        dcValueicd4.DataType = Type.GetType("System.String")

        'Add the fifth column to maintain the icd3 value. 
        dtDropDownsData.Columns.Add(dcValueicd4)

        'Id Order-Test
        Dim OrderTestId As New DataColumn
        OrderTestId.ColumnName = "OrderTestId"
        OrderTestId.DataType = Type.GetType("System.Int32")

        'Add the first column to maintain the dropdown id. 
        dtDropDownsData.Columns.Add(OrderTestId)

        Dim numRow = table.Rows.Count
        For i As Integer = 0 To numRow

            Dim drDefault As DataRow = dtDropDownsData.NewRow

            If numRow = i Then
                drDefault("icd1") = ""
                drDefault("icd2") = ""
                drDefault("icd3") = ""
                drDefault("icd4") = ""
                drDefault("Value") = "-1"
                drDefault("OrderTestId") = 0
            Else
                drDefault("icd1") = IIf(Not IsDBNull(table.Rows(i)(1)), table.Rows(i)(1), "")
                drDefault("icd2") = IIf(Not IsDBNull(table.Rows(i)(2)), table.Rows(i)(2), "")
                drDefault("icd3") = IIf(Not IsDBNull(table.Rows(i)(3)), table.Rows(i)(3), "")
                drDefault("icd4") = IIf(Not IsDBNull(table.Rows(i)(4)), table.Rows(i)(4), "")
                drDefault("Value") = table.Rows(i)(5)
                drDefault("OrderTestId") = table.Rows(i)(0)
            End If

            dtDropDownsData.Rows.Add(drDefault)
            dtDropDownsData.AcceptChanges()
        Next

        DropDownsDataInMemory = dtDropDownsData

    End Sub

End Class
