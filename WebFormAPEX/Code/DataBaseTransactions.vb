Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Runtime.Serialization
Imports System.Globalization

<Serializable()> _
Public Class DataBaseTransactions
    Implements ISerializable
#Region "Variables"
    Private data As New DatDataBaseTransactions
    Private _flag As Integer
    Private _medicalTestChain As String

#Region "Patient Attributes"
    Private _patientId As Integer
    Private _patientMRN As Integer
    Private _patientFirstname As String
    Private _patientMiddleName As String
    Private _patientLastname As String
    Private _patientGender As Char
    Private _patientDOB As String
    Private _patientEthnicityId As Integer
    Private _patientAddress As String
    Private _patientCity As String
    Private _patientStateId As String
    Private _patientZip As String
    Private _patientOrderNumber As String
    Private _patientSpecimenCollect As String
#End Region
#Region "Guarantor Attributes"
    Private _guarantorFirstname As String
    Private _guarantorMiddleName As String
    Private _guarantorLastname As String
    Private _guarantorGender As Char
    Private _guarantorDOB As String
    Private _guarantorRelationshipId As Integer
    Private _guarantorAddress As String
    Private _guarantorCity As String
    Private _guarantorStateId As String
    Private _guarantorZip As String
#End Region
#Region "Insurance Attributes"
    Private _insurancePlan As String
    Private _insuranceFirstname As String
    Private _insuranceNiddleName As String
    Private _insuranceLastname As String
    Private _insuranceGender As Char
    Private _insuranceDOB As String
    Private _insuranceRelationshipId As Integer
    Private _insuranceAddress As String
    Private _insuranceCity As String
    Private _insuranceStateId As String
    Private _insuranceZip As String
#End Region
#End Region

#Region "Properties"
    Public Property Flag() As Integer
        Get
            Return _flag
        End Get
        Set(ByVal value As Integer)
            _flag = value
        End Set
    End Property

    Public Property MedicalTestChain() As String
        Get
            Return _medicalTestChain
        End Get
        Set(ByVal value As String)
            _medicalTestChain = value
        End Set
    End Property

#Region "Patient Properties"

    Public Property PatientId() As Integer
        Get
            Return _patientId
        End Get
        Set(ByVal value As Integer)
            _patientId = value
        End Set
    End Property
    Public Property PatientMRN() As Integer
        Get
            Return _patientMRN
        End Get
        Set(ByVal value As Integer)
            _patientMRN = value
        End Set
    End Property
    Public Property PatientFirstname() As String
        Get
            Return _patientFirstname
        End Get
        Set(ByVal value As String)
            _patientFirstname = value
        End Set
    End Property
    Public Property PatientMiddleName() As String
        Get
            Return _patientMiddleName
        End Get
        Set(ByVal value As String)
            _patientMiddleName = value
        End Set
    End Property
    Public Property PatientLastname() As String
        Get
            Return _patientLastname
        End Get
        Set(ByVal value As String)
            _patientLastname = value
        End Set
    End Property
    Public Property PatientGender() As Char
        Get
            Return _patientGender
        End Get
        Set(ByVal value As Char)
            _patientGender = value
        End Set
    End Property
    Public Property PatientDOB() As String
        Get
            Return _patientDOB
        End Get
        Set(ByVal value As String)
            _patientDOB = value
        End Set
    End Property
    Public Property PatientEthnicityId() As Integer
        Get
            Return _patientEthnicityId
        End Get
        Set(ByVal value As Integer)
            _patientEthnicityId = value
        End Set
    End Property
    Public Property PatientAddress() As String
        Get
            Return _patientAddress
        End Get
        Set(ByVal value As String)
            _patientAddress = value
        End Set
    End Property
    Public Property PatientCity() As String
        Get
            Return _patientCity
        End Get
        Set(ByVal value As String)
            _patientCity = value
        End Set
    End Property
    Public Property PatientStateId() As String
        Get
            Return _patientStateId
        End Get
        Set(ByVal value As String)
            _patientStateId = value
        End Set
    End Property
    Public Property PatientZip() As String
        Get
            Return _patientZip
        End Get
        Set(ByVal value As String)
            _patientZip = value
        End Set
    End Property
    Public Property PatientOrderNumber() As String
        Get
            Return _patientOrderNumber
        End Get
        Set(ByVal value As String)
            _patientOrderNumber = value
        End Set
    End Property
    Public Property PatientSpecimenCollect() As String
        Get
            Return _patientSpecimenCollect
        End Get
        Set(ByVal value As String)
            _patientSpecimenCollect = value
        End Set
    End Property
#End Region
#Region "Guarantor Properties"
    Public Property GuarantorFirstname() As String
        Get
            Return _guarantorFirstname
        End Get
        Set(ByVal value As String)
            _guarantorFirstname = value
        End Set
    End Property
    Public Property GuarantorMiddleName() As String
        Get
            Return _guarantorMiddleName
        End Get
        Set(ByVal value As String)
            _guarantorMiddleName = value
        End Set
    End Property
    Public Property GuarantorLastname() As String
        Get
            Return _guarantorLastname
        End Get
        Set(ByVal value As String)
            _guarantorLastname = value
        End Set
    End Property
    Public Property GuarantorGender() As Char
        Get
            Return _guarantorGender
        End Get
        Set(ByVal value As Char)
            _guarantorGender = value
        End Set
    End Property
    Public Property GuarantorDOB() As String
        Get
            Return _guarantorDOB
        End Get
        Set(ByVal value As String)
            _guarantorDOB = value
        End Set
    End Property
    Public Property GuarantorRelationshipId() As Integer
        Get
            Return _guarantorRelationshipId
        End Get
        Set(ByVal value As Integer)
            _guarantorRelationshipId = value
        End Set
    End Property
    Public Property GuarantorAddress() As String
        Get
            Return _guarantorAddress
        End Get
        Set(ByVal value As String)
            _guarantorAddress = value
        End Set
    End Property
    Public Property GuarantorCity() As String
        Get
            Return _guarantorCity
        End Get
        Set(ByVal value As String)
            _guarantorCity = value
        End Set
    End Property
    Public Property GuarantorStateId() As String
        Get
            Return _guarantorStateId
        End Get
        Set(ByVal value As String)
            _guarantorStateId = value
        End Set
    End Property
    Public Property GuarantorZip() As String
        Get
            Return _guarantorZip
        End Get
        Set(ByVal value As String)
            _guarantorZip = value
        End Set
    End Property
#End Region
#Region "Insurance Properties"
    Public Property InsurancePlan() As String
        Get
            Return _insurancePlan
        End Get
        Set(ByVal value As String)
            _insurancePlan = value
        End Set
    End Property
    Public Property InsuranceFirstname() As String
        Get
            Return _insuranceFirstname
        End Get
        Set(ByVal value As String)
            _insuranceFirstname = value
        End Set
    End Property
    Public Property InsuranceNiddleName() As String
        Get
            Return _insuranceNiddleName
        End Get
        Set(ByVal value As String)
            _insuranceNiddleName = value
        End Set
    End Property
    Public Property InsuranceLastname() As String
        Get
            Return _insuranceLastname
        End Get
        Set(ByVal value As String)
            _insuranceLastname = value
        End Set
    End Property
    Public Property InsuranceGender() As Char
        Get
            Return _insuranceGender
        End Get
        Set(ByVal value As Char)
            _insuranceGender = value
        End Set
    End Property
    Public Property InsuranceDOB() As String
        Get
            Return _insuranceDOB
        End Get
        Set(ByVal value As String)
            _insuranceDOB = value
        End Set
    End Property
    Public Property InsuranceRelationshipId() As Integer
        Get
            Return _insuranceRelationshipId
        End Get
        Set(ByVal value As Integer)
            _insuranceRelationshipId = value
        End Set
    End Property
    Public Property InsuranceAddress() As String
        Get
            Return _insuranceAddress
        End Get
        Set(ByVal value As String)
            _insuranceAddress = value
        End Set
    End Property
    Public Property InsuranceCity() As String
        Get
            Return _insuranceCity
        End Get
        Set(ByVal value As String)
            _insuranceCity = value
        End Set
    End Property
    Public Property InsuranceStateId() As String
        Get
            Return _insuranceStateId
        End Get
        Set(ByVal value As String)
            _insuranceStateId = value
        End Set
    End Property
    Public Property InsuranceZip() As String
        Get
            Return _insuranceZip
        End Get
        Set(ByVal value As String)
            _insuranceZip = value
        End Set
    End Property
#End Region
#End Region

#Region "Constructors"
    Public Sub New()

    End Sub
    Public Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        Me._patientMRN = info.GetValue("_patientMRN", GetType(String))
        Me._patientFirstname = info.GetValue("_patientFirstname", GetType(String))
        Me._patientMiddleName = info.GetValue("_patientMiddleName", GetType(String))
        Me._patientLastname = info.GetValue("_patientLastname", GetType(String))
        Me._patientGender = info.GetValue("_patientGender", GetType(Char))
        Me._patientDOB = info.GetValue("_patientDOB", GetType(String))
        Me._patientEthnicityId = info.GetValue("_patientEthnicityId", GetType(Integer))
        Me._patientAddress = info.GetValue("_patientAddress", GetType(String))
        Me._patientCity = info.GetValue("_patientCity", GetType(String))
        Me._patientStateId = info.GetValue("_patientStateId", GetType(String))
        Me._patientZip = info.GetValue("_patientZip", GetType(String))
        Me._patientOrderNumber = info.GetValue("_patientOrderNumber", GetType(String))
        Me._patientSpecimenCollect = info.GetValue("_patientSpecimenCollect", GetType(String))
        Me._guarantorFirstname = info.GetValue("_guarantorFirstname", GetType(String))
        Me._guarantorMiddleName = info.GetValue("_guarantorMiddleName", GetType(String))
        Me._guarantorLastname = info.GetValue("_guarantorLastname", GetType(String))
        Me._guarantorGender = info.GetValue("_guarantorGender", GetType(Char))
        Me._guarantorDOB = info.GetValue("_guarantorDOB", GetType(String))
        Me._guarantorRelationshipId = info.GetValue("_guarantorRelationshipId", GetType(Integer))
        Me._guarantorAddress = info.GetValue("_guarantorAddress", GetType(String))
        Me._guarantorCity = info.GetValue("_guarantorCity", GetType(String))
        Me._guarantorStateId = info.GetValue("_guarantorStateId", GetType(String))
        Me._guarantorZip = info.GetValue("_guarantorZip", GetType(String))
        Me._insurancePlan = info.GetValue("_insurancePlan", GetType(String))
        Me._insuranceFirstname = info.GetValue("_insuranceFirstname", GetType(String))
        Me._insuranceNiddleName = info.GetValue("_insuranceNiddleName", GetType(String))
        Me._insuranceLastname = info.GetValue("_insuranceLastname", GetType(String))
        Me._insuranceGender = info.GetValue("_insuranceGender", GetType(Char))
        Me._insuranceDOB = info.GetValue("_insuranceDOB", GetType(String))
        Me._insuranceRelationshipId = info.GetValue("_insuranceRelationshipId", GetType(Integer))
        Me._insuranceAddress = info.GetValue("_insuranceAddress", GetType(String))
        Me._insuranceCity = info.GetValue("_insuranceCity", GetType(String))
        Me._insuranceStateId = info.GetValue("_insuranceStateId", GetType(String))
        Me._insuranceZip = info.GetValue("_insuranceZip", GetType(String))
        Me._flag = info.GetValue("_flag", GetType(Integer))
        Me._medicalTestChain = info.GetValue("_medicalTestChain", GetType(String))
        Me._patientId = info.GetValue("_patientId", GetType(Integer))
    End Sub
#End Region

    Public Sub GetObjectData(ByVal info As System.Runtime.Serialization.SerializationInfo, ByVal context As System.Runtime.Serialization.StreamingContext) Implements System.Runtime.Serialization.ISerializable.GetObjectData
        info.AddValue("_patientMRN", _patientMRN)
        info.AddValue("_patientFirstname", _patientFirstname)
        info.AddValue("_patientMiddleName", _patientMiddleName)
        info.AddValue("_patientLastname", _patientLastname)
        info.AddValue("_patientGender", _patientGender)
        info.AddValue("_patientDOB", _patientDOB)
        info.AddValue("_patientEthnicityId", _patientEthnicityId)
        info.AddValue("_patientAddress", _patientAddress)
        info.AddValue("_patientCity", _patientCity)
        info.AddValue("_patientStateId", _patientStateId)
        info.AddValue("_patientZip", _patientZip)
        info.AddValue("_patientOrderNumber", _patientOrderNumber)
        info.AddValue("_patientSpecimenCollect", _patientSpecimenCollect)
        info.AddValue("_guarantorFirstname", _guarantorFirstname)
        info.AddValue("_guarantorMiddleName", _guarantorMiddleName)
        info.AddValue("_guarantorLastname", _guarantorLastname)
        info.AddValue("_guarantorGender", _guarantorGender)
        info.AddValue("_guarantorDOB", _guarantorDOB)
        info.AddValue("_guarantorRelationshipId", _guarantorRelationshipId)
        info.AddValue("_guarantorAddress", _guarantorAddress)
        info.AddValue("_guarantorCity", _guarantorCity)
        info.AddValue("_guarantorStateId", _guarantorStateId)
        info.AddValue("_guarantorZip", _guarantorZip)
        info.AddValue("_insurancePlan", _insurancePlan)
        info.AddValue("_insuranceFirstname", _insuranceFirstname)
        info.AddValue("_insuranceNiddleName", _insuranceNiddleName)
        info.AddValue("_insuranceLastname", _insuranceLastname)
        info.AddValue("_insuranceGender", _insuranceGender)
        info.AddValue("_insuranceDOB", _insuranceDOB)
        info.AddValue("_insuranceRelationshipId", _insuranceRelationshipId)
        info.AddValue("_insuranceAddress", _insuranceAddress)
        info.AddValue("_insuranceCity", _insuranceCity)
        info.AddValue("_insuranceStateId", _insuranceStateId)
        info.AddValue("_insuranceZip", _insuranceZip)
        info.AddValue("_flag", _flag)
        info.AddValue("_medicalTestChain", _medicalTestChain)
        info.AddValue("_patientId", _patientId)
    End Sub

    'Function that fills the catalogs of the web application
    Public Function fillCatalogs() As DataSet
        Dim dsRelationship As DataSet = New DataSet
        dsRelationship = data.fillCatalogs()
        Return dsRelationship
    End Function

    Public Function dataProcessing()
        Dim result = data.dataProcessing(PatientMRN, PatientFirstname, PatientMiddleName, PatientLastname, PatientGender, PatientDOB, _
                                           PatientEthnicityId, PatientAddress, PatientCity, PatientStateId, PatientZip, PatientOrderNumber, _
                                           PatientSpecimenCollect, GuarantorFirstname, GuarantorMiddleName, GuarantorLastname, GuarantorGender, GuarantorDOB, _
                                           GuarantorRelationshipId, GuarantorAddress, GuarantorCity, GuarantorStateId, GuarantorZip, InsurancePlan, _
                                           InsuranceFirstname, InsuranceNiddleName, InsuranceLastname, InsuranceGender, InsuranceDOB, InsuranceRelationshipId, _
                                           InsuranceAddress, InsuranceCity, InsuranceStateId, InsuranceZip, MedicalTestChain)
        Return result
    End Function

    Public Function SearchPatients() As DataTable
        Dim dt As DataTable = New DataTable
        dt = data.SearchPatients(PatientMRN, PatientFirstname, PatientGender, PatientDOB)
        Return dt
    End Function

    Public Function getLastInsertedPatient() As DataSet
        Dim dt As DataSet = New DataSet
        dt = data.getLastInsertedPatient()
        Return dt
    End Function

    Public Function searchData() As DataSet
        Dim dt As DataSet = New DataSet
        dt = data.searchData(PatientMRN)
        Return dt
    End Function

    Public Function getOrderNumber() As DataTable
        Dim dt As DataTable = New DataTable
        dt = data.getOrderNumber()
        Return dt
    End Function

    Public Function searchDataByPatientId() As DataSet
        Dim ds As DataSet = New DataSet
        ds = data.searchDataByPatientId(PatientId)
        Return ds
    End Function
End Class
