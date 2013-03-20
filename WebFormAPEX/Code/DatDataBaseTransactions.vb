Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class DatDataBaseTransactions
    Inherits DBConnect

    'Function that execute the store procedure for fills the catalogs of the web application
    Function fillCatalogs() As DataSet
        Dim ds As DataSet = New DataSet
        Try
            adapter = New SqlDataAdapter
            command.CommandText = "getAllCatalogs"
            command.CommandType = CommandType.StoredProcedure
            command.Connection = connection
            connection.Open()

            adapter.SelectCommand = command
            adapter.Fill(ds)
            Return ds
        Catch ex As Exception
            Throw ex
        Finally
            connection.Close()
        End Try
    End Function

    Function dataProcessing(ByVal PatientMRN As Integer, ByVal PatientFirstname As String, ByVal PatientMiddleName As String, _
                              ByVal PatientLastname As String, ByVal PatientGender As Char, ByVal PatientDOB As String, _
                              ByVal PatientEthnicityId As Integer, ByVal PatientAddress As String, ByVal PatientCity As String, _
                              ByVal PatientStateId As String, ByVal PatientZip As String, ByVal PatientSpecimenCollect As String, _
                              ByVal GuarantorFirstname As String, ByVal GuarantorMiddleName As String, ByVal GuarantorLastname As String, _
                              ByVal GuarantorGender As Char, ByVal GuarantorDOB As String, ByVal GuarantorRelationshipId As Integer, _
                              ByVal GuarantorAddress As String, ByVal GuarantorCity As String, ByVal GuarantorStateId As String, _
                              ByVal GuarantorZip As String, ByVal InsurancePlan As String, ByVal InsuranceFirstname As String, _
                              ByVal InsuranceNiddleName As String, ByVal InsuranceLastname As String, ByVal InsuranceGender As Char, _
                              ByVal InsuranceDOB As String, ByVal InsuranceRelationshipId As Integer, ByVal InsuranceAddress As String, _
                              ByVal InsuranceCity As String, ByVal InsuranceStateId As String, ByVal InsuranceZip As String, ByVal MedicalTestChain As String) As Integer

        command = New SqlCommand
        Try
            adapter = New SqlDataAdapter
            command.CommandText = "DataProcessing"
            command.CommandType = CommandType.StoredProcedure
            command.Connection = connection

            parameter = New SqlParameter
            parameter.ParameterName = "@patientMRN"
            parameter.SqlDbType = SqlDbType.Int
            parameter.Value = PatientMRN
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@patientFirstname"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = PatientFirstname
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@patientMiddleName"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = PatientMiddleName
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@patientLastname"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = PatientLastname
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@patientGender"
            parameter.SqlDbType = SqlDbType.Char
            parameter.Value = PatientGender
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@patientDOB"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = PatientDOB
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@patientEthnicityId"
            parameter.SqlDbType = SqlDbType.Int
            parameter.Value = PatientEthnicityId
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@patientAddress"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = PatientAddress
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@patientCity"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = PatientCity
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@patientStateId"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = PatientStateId
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@patientZip"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = PatientZip
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@guarantorFirstname"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = GuarantorFirstname
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@guarantorMiddleName"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = GuarantorMiddleName
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@guarantorLastname"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = GuarantorLastname
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@guarantorGender"
            parameter.SqlDbType = SqlDbType.Char
            parameter.Value = GuarantorGender
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@guarantorDOB"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = GuarantorDOB
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@guarantorRelationshipId"
            parameter.SqlDbType = SqlDbType.Int
            parameter.Value = GuarantorRelationshipId
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@guarantorAddress"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = GuarantorAddress
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@guarantorCity"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = GuarantorCity
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@guarantorStateId"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = GuarantorStateId
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@guarantorZip"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = GuarantorZip
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@insurancePlan"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = InsurancePlan
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@insuranceFirstname"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = InsuranceFirstname
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@insuranceNiddleName"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = InsuranceNiddleName
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@insuranceLastname"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = InsuranceLastname
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@insuranceGender"
            parameter.SqlDbType = SqlDbType.Char
            parameter.Value = InsuranceGender
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@insuranceDOB"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = InsuranceDOB
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@insuranceRelationshipId"
            parameter.SqlDbType = SqlDbType.Int
            parameter.Value = InsuranceRelationshipId
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@insuranceAddress"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = InsuranceAddress
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@insuranceCity"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = InsuranceCity
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@insuranceStateId"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = InsuranceStateId
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@insuranceZip"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = InsuranceZip
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@orderSpecimenCollect"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = PatientSpecimenCollect
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@testChain"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = MedicalTestChain
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@outResult"
            parameter.SqlDbType = SqlDbType.Int
            parameter.Value = ParameterDirection.Output
            command.Parameters.Add(parameter)

            connection.Open()
            command.ExecuteNonQuery()
            Return command.Parameters("@outResult").Value
        Catch ex As Exception
            Return 0
            ex.Message.ToString()
        Finally
            connection.Close()
        End Try
    End Function

    Function SearchPatients(ByVal PatientMRN As Integer, ByVal PatientFirstname As String, ByVal PatientGender As Char, ByVal PatientDOB As String) As DataTable
        Dim dt As DataTable = New DataTable
        Try

            adapter = New SqlDataAdapter
            command.CommandText = "SearchPatients"
            command.CommandType = CommandType.StoredProcedure
            command.Connection = connection

            parameter = New SqlParameter
            parameter.ParameterName = "@patientMRN"
            parameter.SqlDbType = SqlDbType.Int
            parameter.Value = PatientMRN
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@patientFirstname"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = PatientFirstname
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@patientGender"
            parameter.SqlDbType = SqlDbType.Char
            parameter.Value = PatientGender
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@patientDOB"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = PatientDOB
            command.Parameters.Add(parameter)

            connection.Open()
            adapter.SelectCommand = command
            adapter.Fill(dt)
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            connection.Close()
        End Try
    End Function

    'Function that execute the store procedure for get th last inserted patient
    Function getLastInsertedPatient() As DataSet
        Dim ds As DataSet = New DataSet
        Try
            adapter = New SqlDataAdapter
            command.CommandText = "getLastInsertedPatient"
            command.CommandType = CommandType.StoredProcedure
            command.Connection = connection
            connection.Open()

            adapter.SelectCommand = command
            adapter.Fill(ds)
            Return ds
        Catch ex As Exception
            Throw ex
        Finally
            connection.Close()
        End Try
    End Function

    Function searchData(ByVal PatientMRN As Integer) As DataSet
        Dim dt As DataSet = New DataSet
        Try

            adapter = New SqlDataAdapter
            command.CommandText = "searchData"
            command.CommandType = CommandType.StoredProcedure
            command.Connection = connection

            parameter = New SqlParameter
            parameter.ParameterName = "@patientMRN"
            parameter.SqlDbType = SqlDbType.Int
            parameter.Value = PatientMRN
            command.Parameters.Add(parameter)

            connection.Open()
            adapter.SelectCommand = command
            adapter.Fill(dt)
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            connection.Close()
        End Try
    End Function

    Function searchDataByPatientId(ByVal patientId As Integer) As DataSet
        Dim ds As DataSet = New DataSet
        Try

            adapter = New SqlDataAdapter
            command.CommandText = "searchDataByPatientId"
            command.CommandType = CommandType.StoredProcedure
            command.Connection = connection

            parameter = New SqlParameter
            parameter.ParameterName = "@patientId"
            parameter.SqlDbType = SqlDbType.Int
            parameter.Value = patientId
            command.Parameters.Add(parameter)

            connection.Open()
            adapter.SelectCommand = command
            adapter.Fill(ds)
            Return ds
        Catch ex As Exception
            Throw ex
        Finally
            connection.Close()
        End Try
    End Function

    Function getOrderNumber() As DataTable
        Dim dt As DataTable = New DataTable
        Try
            adapter = New SqlDataAdapter
            command.CommandText = "getOrderNumber"
            command.CommandType = CommandType.StoredProcedure
            command.Connection = connection
            connection.Open()

            adapter.SelectCommand = command
            adapter.Fill(dt)
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            connection.Close()
        End Try

    End Function

    Function PatientDataUpdates(ByVal PatientId As Integer, ByVal PatientFirstname As String, ByVal PatientMiddleName As String, _
                              ByVal PatientLastname As String, ByVal PatientGender As Char, ByVal PatientDOB As String, _
                              ByVal PatientEthnicityId As Integer, ByVal PatientAddress As String, ByVal PatientCity As String, _
                              ByVal PatientStateId As String, ByVal PatientZip As String, ByVal PatientSpecimenCollect As String, _
                              ByVal GuarantorId As Integer, ByVal GuarantorFirstname As String, ByVal GuarantorMiddleName As String,
                              ByVal GuarantorLastname As String, ByVal GuarantorGender As Char, ByVal GuarantorDOB As String, _
                              ByVal GuarantorRelationshipId As Integer, ByVal GuarantorAddress As String, ByVal GuarantorCity As String, _
                              ByVal GuarantorStateId As String, ByVal GuarantorZip As String, ByVal InsuranceId As Integer, _
                              ByVal InsurancePlan As String, ByVal InsuranceFirstname As String, ByVal InsuranceNiddleName As String, _
                              ByVal InsuranceLastname As String, ByVal InsuranceGender As Char, ByVal InsuranceDOB As String, _
                              ByVal InsuranceRelationshipId As Integer, ByVal InsuranceAddress As String, ByVal InsuranceCity As String, _
                              ByVal InsuranceStateId As String, ByVal InsuranceZip As String, ByVal OrderId As Integer, ByVal MedicalTestChain As String) As Integer
        command = New SqlCommand
        Try
            adapter = New SqlDataAdapter
            command.CommandText = "PatientDataUpdates"
            command.CommandType = CommandType.StoredProcedure
            command.Connection = connection

            parameter = New SqlParameter
            parameter.ParameterName = "@patientID"
            parameter.SqlDbType = SqlDbType.Int
            parameter.Value = PatientId
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@patientFirstname"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = PatientFirstname
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@patientMiddleName"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = PatientMiddleName
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@patientLastname"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = PatientLastname
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@patientGender"
            parameter.SqlDbType = SqlDbType.Char
            parameter.Value = PatientGender
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@patientDOB"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = PatientDOB
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@patientEthnicityId"
            parameter.SqlDbType = SqlDbType.Int
            parameter.Value = PatientEthnicityId
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@patientAddress"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = PatientAddress
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@patientCity"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = PatientCity
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@patientStateId"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = PatientStateId
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@patientZip"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = PatientZip
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@guarantorID"
            parameter.SqlDbType = SqlDbType.Int
            parameter.Value = GuarantorId
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@guarantorFirstname"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = GuarantorFirstname
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@guarantorMiddleName"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = GuarantorMiddleName
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@guarantorLastname"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = GuarantorLastname
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@guarantorGender"
            parameter.SqlDbType = SqlDbType.Char
            parameter.Value = GuarantorGender
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@guarantorDOB"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = GuarantorDOB
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@guarantorRelationshipId"
            parameter.SqlDbType = SqlDbType.Int
            parameter.Value = GuarantorRelationshipId
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@guarantorAddress"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = GuarantorAddress
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@guarantorCity"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = GuarantorCity
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@guarantorStateId"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = GuarantorStateId
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@guarantorZip"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = GuarantorZip
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@insuranceID"
            parameter.SqlDbType = SqlDbType.Int
            parameter.Value = InsuranceId
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@insurancePlan"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = InsurancePlan
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@insuranceFirstname"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = InsuranceFirstname
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@insuranceNiddleName"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = InsuranceNiddleName
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@insuranceLastname"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = InsuranceLastname
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@insuranceGender"
            parameter.SqlDbType = SqlDbType.Char
            parameter.Value = InsuranceGender
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@insuranceDOB"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = InsuranceDOB
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@insuranceRelationshipId"
            parameter.SqlDbType = SqlDbType.Int
            parameter.Value = InsuranceRelationshipId
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@insuranceAddress"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = InsuranceAddress
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@insuranceCity"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = InsuranceCity
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@insuranceStateId"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = InsuranceStateId
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@insuranceZip"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = InsuranceZip
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@orderSpecimenCollect"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = PatientSpecimenCollect
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@orderID"
            parameter.SqlDbType = SqlDbType.Int
            parameter.Value = OrderId
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@testChain"
            parameter.SqlDbType = SqlDbType.VarChar
            parameter.Value = MedicalTestChain
            command.Parameters.Add(parameter)

            parameter = New SqlParameter
            parameter.ParameterName = "@outResult"
            parameter.SqlDbType = SqlDbType.Int
            parameter.Value = ParameterDirection.Output
            command.Parameters.Add(parameter)

            connection.Open()
            command.ExecuteNonQuery()
            Return command.Parameters("@outResult").Value
        Catch ex As Exception
            Return 0
            ex.Message.ToString()
        Finally
            connection.Close()
        End Try
    End Function
End Class
