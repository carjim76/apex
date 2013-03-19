Imports System.Drawing.Text
Imports System.Drawing.Printing
Imports System.Drawing
Imports System.IO

Public Class wucPrincipalForm
    Inherits System.Web.UI.UserControl

#Region "Variables"
    Dim dbTransactions As New DataBaseTransactions
    Dim dt As DataTable
    Private printer As New PrintDocument()
    Private myFont As Font
    Private _flag As Integer
    Private _MedicalTestChain As String

#End Region
#Region "Properties"
    Public Property opDB() As Integer
        Get
            Return _flag
        End Get
        Set(ByVal value As Integer)
            _flag = value
        End Set
    End Property

    Public Property MedicalTestChain() As String
        Get
            Return _MedicalTestChain
        End Get
        Set(ByVal value As String)
            _MedicalTestChain = value
        End Set
    End Property
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler wucGridSearch1.FillFormFields, AddressOf SelectPatient
        AddHandler wucGridSearch1.Back, AddressOf back
        'opDB = 1
        If Not Page.IsPostBack Then
            Me.divSearch.Visible = False
            loadHour()
            loadCatalogs()
            opDB = 1
            getOrderNumber()
            loadFont()
            If Not myFont Is Nothing Then
                'lblPatienData.Font = myFont
            End If
            '    MedicalTestChain = Is Nothing 
        End If
    End Sub

    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReset.Click
        cleanForm()
        cleanVariables()
        opDB = 1
    End Sub
    'Method to clean the form fields
    Public Sub cleanForm()
        opDB = 1
        txtPDMRN.Text = ""
        txtPDFirstName.Text = ""
        txtPDMiddleName.Text = ""
        txtPDLastName.Text = ""
        txtPDBirthday.Text = ""
        txtPDAddress.Text = ""
        txtPDCity.Text = ""
        txtPDZip.Text = ""
        txtPDDateSpecimenCollect.Text = ""
        'txtPDOrder.Text = ""
        getOrderNumber()

        'txtPDHourSpecimenCollectDate.Text = ""
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

        txtICD11.Text = ""
        txtICD12.Text = ""
        txtICD13.Text = ""
        txtICD14.Text = ""
        txtICD21.Text = ""
        txtICD22.Text = ""
        txtICD23.Text = ""
        txtICD24.Text = ""

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

        ddlMedicalTest1.SelectedIndex = 0
        ddlMedicalTest2.SelectedIndex = 0

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

    End Sub
    'Method that collects form data and save it in database
    Public Sub collectDataOfForm()
        Try
            Dim strDate, strHour, strDateAndHour As String

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
            dbTransactions.PatientOrderNumber = IIf(txtPDOrder.Text <> "", txtPDOrder.Text, " ")

            strDate = IIf(txtPDDateSpecimenCollect.Text <> "", txtPDDateSpecimenCollect.Text, " ")
            strHour = IIf(txtPDHourSpecimenCollectDate.Text <> "", txtPDHourSpecimenCollectDate.Text, " ")
            strDateAndHour = strDate & " " & strHour
            dbTransactions.PatientSpecimenCollect = IIf(txtPDDateSpecimenCollect.Text <> "", strDateAndHour, " ")
            'dbTransactions.PatientSpecimenCollect = IIf(txtPDDateSpecimenCollect.Text <> "", txtPDDateSpecimenCollect.Text, " ")

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

            collectMedicalTest()
        Catch ex As Exception

        End Try



    End Sub
    'method that validates the required fields of the form
    Public Function validateFields() As Boolean
        Dim flag As Boolean = True
        If ddlOrderingProvider.SelectedValue = -1 Then
            flag = False
            lblOrderingProvider.ForeColor = Drawing.Color.Red
        Else
            lblOrderingProvider.ForeColor = Drawing.Color.Black
        End If

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
        If wucGender1.getDdlGenderValue = "0" Then
            flag = False
            wucGender1.changeColorTitle(1)
        Else
            wucGender1.changeColorTitle(2)

        End If
        If ddlPDEthnicity.SelectedValue = -1 Then
            flag = False
            lblPDEthnicity.ForeColor = Drawing.Color.Red
        Else
            lblPDEthnicity.ForeColor = Drawing.Color.Black
        End If
        If wucState1.getDdlStateValue = "-1" Then
            flag = False
            wucState1.changeColorTitle(1)
        Else
            wucState1.changeColorTitle(2)
        End If

        If ddlMedicalTest1.SelectedValue = -1 Then
            flag = False
            lblTest.ForeColor = Drawing.Color.Red
        Else
            lblTest.ForeColor = Drawing.Color.Black
        End If

        'If wucMedicalTest2.getDdlMedicalTestValue = -1 Then
        '    flag = False
        '    lblTest.ForeColor = Drawing.Color.Red
        'Else
        '    lblTest.ForeColor = Drawing.Color.Black
        'End If

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
        If wucGender2.getDdlGenderValue = "0" Then
            flag = False
            wucGender2.changeColorTitle(1)
        Else
            wucGender2.changeColorTitle(2)
        End If
        If wucRelationship1.getDdlRelationshipValue = -1 Then
            flag = False
            wucRelationship1.changeColorTitle(1)
        Else
            wucRelationship1.changeColorTitle(2)
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
        If wucGender3.getDdlGenderValue = "0" Then
            flag = False
            wucGender3.changeColorTitle(1)
        Else
            wucGender3.changeColorTitle(2)
        End If
        If wucRelationship2.getDdlRelationshipValue = -1 Then
            flag = False
            wucRelationship2.changeColorTitle(1)
        Else
            wucRelationship2.changeColorTitle(2)
        End If
        If wucState2.getDdlStateValue = "-1" Then
            flag = False
            wucState2.changeColorTitle(1)
        Else
            wucState2.changeColorTitle(2)
        End If

        If wucState3.getDdlStateValue = "-1" Then
            flag = False
            wucState3.changeColorTitle(1)
        Else
            wucState3.changeColorTitle(2)
        End If

        Return flag
    End Function

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

        ddlMedicalTest1.DataSource = ds.Tables(4)
        ddlMedicalTest1.DataValueField = ds.Tables(4).Columns(0).ToString
        ddlMedicalTest1.DataTextField = ds.Tables(4).Columns(1).ToString
        ddlMedicalTest1.DataBind()
        ddlMedicalTest1.Items.Insert(0, New ListItem(GetLocalResourceObject("selectMedicalTest").ToString, "-1"))

        ddlMedicalTest2.DataSource = ds.Tables(4)
        ddlMedicalTest2.DataValueField = ds.Tables(4).Columns(0).ToString
        ddlMedicalTest2.DataTextField = ds.Tables(4).Columns(1).ToString
        ddlMedicalTest2.DataBind()
        ddlMedicalTest2.Items.Insert(0, New ListItem(GetLocalResourceObject("selectMedicalTest").ToString, "-1"))
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        If opDB = 1 Then
            insertNewPatien()
        Else
            Response.Write("actualizar datos")
        End If




        ' '' '' ''<%
        ' '' '' ''declare the variables that will receive the values 
        '' '' ''Dim tes1, tes2, test3 As String
        '' '' ''Dim total As Integer
        ' '' '' ''receive the values sent from the form and assign them to variables
        ' '' '' ''note that request.form("name") will receive the value entered 
        ' '' '' ''into the textfield called name
        '' '' ''total = Request.Form("total_selects")

        '' '' ''tes1 = Request.Form("wucPrincipalForm1$ddlMedicalTest1")
        '' '' ''tes2 = Request.Form("wucPrincipalForm1$ddlMedicalTest2")
        '' '' ''test3 = Request.Form("wucPrincipalForm1$ddlMedicalTest3")

        ' '' '' ''lblGDAddress.Text = tes1
        ' '' '' ''lblGDFirstName.Text = tes2
        ' '' '' ''lblGuarantorData.Text = test3

        ' '' '' ''let's now print out the received values in the browser  wucPrincipalForm1$DropDownList3
        '' '' ''Response.Write("Name: " & tes1 & "<br>")
        '' '' ''Response.Write("E-mail: " & tes2 & "<br>")
        '' '' ''Response.Write("Comments: " & test3 & "<br>")

        '' '' ''Response.Write("tatal: " & total & "<br>")

        '' '' ''Dim i As Integer
        '' '' ''Dim var As String
        '' '' ''Dim v1, v2, v3, v4 As String
        '' '' ''For i = 1 To total
        '' '' ''    var = Request.Form("wucPrincipalForm1$ddlMedicalTest" & i)
        '' '' ''    v1 = Request.Form("wucPrincipalForm1$TextBox" & i & "1")
        '' '' ''    v2 = Request.Form("wucPrincipalForm1$TextBox" & i & "2")
        '' '' ''    v3 = Request.Form("wucPrincipalForm1$TextBox" & i & "3")
        '' '' ''    v4 = Request.Form("wucPrincipalForm1$TextBox" & i & "4")

        '' '' ''    Response.Write("value combobox " & i & ": " & var & "<br>")

        '' '' ''    Response.Write("value icd1" & i & ": " & v1 & "<br>")
        '' '' ''    Response.Write("value icd2" & i & ":" & v2 & "<br>")
        '' '' ''    Response.Write("value icd3" & i & ":" & v3 & "<br>")
        '' '' ''    Response.Write("value icd4" & i & ":" & v4 & "<br>")

        '' '' ''Next

        ' '' '' ''%>
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Dim ds As DataSet
        Dim dt As DataTable

        collectDataOfForm()

        'ds = dbTransactions.searchData()

        'fillFormFields(ds)
        opDB = 2
        dt = dbTransactions.SearchPatients
        'If dt.Rows.Count > 1 Then
        wucGridSearch1.Grid = dt
        wucGridSearch1.FillGrid()

        'Else
        '    Dim patientId As Integer
        '    cleanVariables()
        '    patientId = dt.Rows(0)(0)
        '    dbTransactions.PatientId = patientId
        '    ds = dbTransactions.searchDataByPatientId()
        '    fillFormFields(ds)
        'End If
        Me.divForm.Visible = False
        Me.divSearch.Visible = True
    End Sub

    Public Sub fillFormFields(ByVal ds As DataSet)

        Dim stringDate As Date

        txtPDMRN.Text = ds.Tables(0).Rows(0)(1)
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

        txtIDFirstName.Text = ds.Tables(2).Rows(0)(1)
        txtIDMiddleName.Text = ds.Tables(2).Rows(0)(2)
        txtIDLastName.Text = ds.Tables(2).Rows(0)(3)
        txtIDLastName.Text = ds.Tables(2).Rows(0)(4)
        wucGender3.setValue(ds.Tables(2).Rows(0)(5))
        stringDate = CType(ds.Tables(2).Rows(0)(6), DateTime)
        txtIDBirthday.Text = stringDate.ToString("MM/dd/yyyy")
        wucRelationship2.setValue(ds.Tables(2).Rows(0)(7))
        txtIDAddress.Text = ds.Tables(2).Rows(0)(8)
        txtIDCity.Text = ds.Tables(2).Rows(0)(9)
        wucState3.setValue(ds.Tables(2).Rows(0)(10))
        txtIDZip.Text = ds.Tables(2).Rows(0)(11)

        txtPDOrder.Text = ds.Tables(3).Rows(0)(0)
        stringDate = CType(ds.Tables(3).Rows(0)(1), DateTime)
        txtPDDateSpecimenCollect.Text = stringDate.ToString("MM/dd/yyyy")
        txtPDHourSpecimenCollectDate.Text = stringDate.ToString("HH:mm")

        If ds.Tables(4).Rows.Count = 1 Then
            txtICD11.Text = IIf(ds.Tables(4).Rows(0)(1) Is DBNull.Value, "", ds.Tables(4).Rows(0)(1))
            txtICD12.Text = IIf(ds.Tables(4).Rows(0)(2) Is DBNull.Value, "", ds.Tables(4).Rows(0)(2))
            txtICD13.Text = IIf(ds.Tables(4).Rows(0)(3) Is DBNull.Value, "", ds.Tables(4).Rows(0)(3))
            txtICD14.Text = IIf(ds.Tables(4).Rows(0)(4) Is DBNull.Value, "", ds.Tables(4).Rows(0)(4))
            ddlMedicalTest1.SelectedValue = ds.Tables(4).Rows(0)(5)
        End If

        If ds.Tables(4).Rows.Count >= 2 Then
            txtICD11.Text = IIf(ds.Tables(4).Rows(0)(1) Is DBNull.Value, "", ds.Tables(4).Rows(0)(1))
            txtICD12.Text = IIf(ds.Tables(4).Rows(0)(2) Is DBNull.Value, "", ds.Tables(4).Rows(0)(2))
            txtICD13.Text = IIf(ds.Tables(4).Rows(0)(3) Is DBNull.Value, "", ds.Tables(4).Rows(0)(3))
            txtICD14.Text = IIf(ds.Tables(4).Rows(0)(4) Is DBNull.Value, "", ds.Tables(4).Rows(0)(4))
            ddlMedicalTest1.SelectedValue = ds.Tables(4).Rows(0)(5)

            txtICD21.Text = IIf(ds.Tables(4).Rows(1)(1) Is Nothing, "", ds.Tables(4).Rows(1)(1))
            txtICD22.Text = IIf(ds.Tables(4).Rows(1)(2) Is Nothing, "", ds.Tables(4).Rows(1)(2))
            txtICD23.Text = IIf(ds.Tables(4).Rows(1)(3) Is Nothing, "", ds.Tables(4).Rows(1)(3))
            txtICD24.Text = IIf(ds.Tables(4).Rows(1)(4) Is Nothing, "", ds.Tables(4).Rows(1)(4))
            ddlMedicalTest2.SelectedValue = ds.Tables(4).Rows(1)(5)

        End If

    End Sub

    Public Sub collectMedicalTest()
        Dim total As Integer
        total = Request.Form("total_selects")

        Dim testId As String
        Dim icd1 As String
        Dim icd2 As String
        Dim icd3 As String
        Dim icd4 As String
        Try
            For i As Integer = 1 To total
                If i = 1 Then
                    testId = ddlMedicalTest1.SelectedValue
                    icd1 = txtICD11.Text
                    icd2 = txtICD12.Text
                    icd3 = txtICD13.Text
                    icd4 = txtICD14.Text

                    MedicalTestChain = MedicalTestChain & testId & "," & icd1 & "," & icd2 & "," & icd3 & "," & icd4 & "|"

                End If
                If i = 2 Then
                    testId = ddlMedicalTest2.SelectedValue
                    icd1 = txtICD21.Text
                    icd2 = txtICD22.Text
                    icd3 = txtICD23.Text
                    icd4 = txtICD24.Text

                    MedicalTestChain = MedicalTestChain & testId & "," & icd1 & "," & icd2 & "," & icd3 & "," & icd4 & "|"
                End If

                If i > 2 Then
                    testId = Request.Form("wucPrincipalForm1$ddlMedicalTest" & i)
                    icd1 = Request.Form("wucPrincipalForm1$TextBox" & i & "1")
                    icd2 = Request.Form("wucPrincipalForm1$TextBox" & i & "2")
                    icd3 = Request.Form("wucPrincipalForm1$TextBox" & i & "3")
                    icd4 = Request.Form("wucPrincipalForm1$TextBox" & i & "4")

                    MedicalTestChain = MedicalTestChain & testId & "," & icd1 & "," & icd2 & "," & icd3 & "," & icd4 & "|"
                End If
            Next
        Catch ex As Exception
            If ddlMedicalTest1.SelectedIndex <> 0 Then
                testId = ddlMedicalTest1.SelectedValue
                icd1 = txtICD11.Text
                icd2 = txtICD12.Text
                icd3 = txtICD13.Text
                icd4 = txtICD14.Text

                MedicalTestChain = MedicalTestChain & testId & "," & icd1 & "," & icd2 & "," & icd3 & "," & icd4 & "|"
            End If

            If ddlMedicalTest2.SelectedIndex <> 0 Then
                testId = ddlMedicalTest2.SelectedValue
                icd1 = txtICD21.Text
                icd2 = txtICD22.Text
                icd3 = txtICD23.Text
                icd4 = txtICD24.Text

                MedicalTestChain = MedicalTestChain & testId & "," & icd1 & "," & icd2 & "," & icd3 & "," & icd4 & "|"
            End If
        End Try


        If MedicalTestChain IsNot Nothing Then
            MedicalTestChain = MedicalTestChain.Remove(MedicalTestChain.Length - 1, 1)
        End If

        dbTransactions.MedicalTestChain = MedicalTestChain
    End Sub
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
    Private Sub loadFont()
        Dim collectionOfFonts As New PrivateFontCollection()
        Dim pathFont As String
        pathFont = System.AppDomain.CurrentDomain.BaseDirectory & GetLocalResourceObject("pathFont")
        'cargamos la fuente el archivo esta en Debug\bin
        If File.Exists(pathFont) Then
            collectionOfFonts.AddFontFile(pathFont)
            Dim fontFamilies As FontFamily = collectionOfFonts.Families(0)
            'llamamos al constructor de la clase font, donde le pasamos como 
            'parametros la familia de fuentes y el tamaño que tendra la fuente
            myFont = New Font(fontFamilies, 25)
        End If
    End Sub

    Protected Sub printBC_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles printBC.Click
        lblPatienData.Text = "*algo123*"

        'Dim var As String
        ''var = Directory.GetFiles(System.Configuration.ConfigurationManager.AppSettings.Get("PATH_FONTS"))
        ''var = Directory.GetFiles(GetLocalResourceObject("pathFont"))
        'var = System.AppDomain.CurrentDomain.BaseDirectory & GetLocalResourceObject("pathFont")
        'var = var


        
    End Sub

    Public Sub SelectPatient()
        Dim ds As DataSet
        dbTransactions.PatientId = wucGridSearch1.PatientId
        ds = dbTransactions.searchDataByPatientId()
        fillFormFields(ds)
        Me.divForm.Visible = True
        Me.divSearch.Visible = False
    End Sub

    Protected Sub btnMenu_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMenu.Click
        ''Response.Redirect("SearchPatient.aspx?Grid")
        ''Response.Redirect("SearchPatient.aspx/FillGrid")
        Me.divForm.Visible = False
        Me.divSearch.Visible = True
    End Sub

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
        dbTransactions.PatientOrderNumber = ""
        dbTransactions.PatientSpecimenCollect = ""

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
    End Sub
    Public Sub loadHour()
        Dim time As DateTime = Now
        txtPDHourSpecimenCollectDate.Text = time.ToString("HH:mm")
    End Sub
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
    Public Sub back()
        Me.divForm.Visible = True
        Me.divSearch.Visible = False
    End Sub
End Class