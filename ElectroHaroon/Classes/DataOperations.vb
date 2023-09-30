Imports BaseLibrary
Imports ConfigurationLibrary_vb

Public Class DataOperations
    Inherits BaseExceptionsHandler
    Private operations As New ConnectionProtection(Application.ExecutablePath)
    Private ConnectionString As String
    Public Function GetEncryConStr() As String
        If operations.IsProtected Then
            operations.DecryptFile()
        End If
        Dim Cryp As New Simple3Des(My.Settings.K)
        ConnectionString =
            My.Settings.MainConn &
            IO.Path.Combine(Application.StartupPath, "DB", "electronics.accdb;") &
            My.Settings.RestConn &
            Cryp.DecryptData(My.Settings.DatabasePass) & ";"
        operations.EncryptFile()
        Return ConnectionString
    End Function
End Class
