Imports System.Security.Cryptography
Public NotInheritable Class Simple3Des
    Implements IDisposable
    'Store the 3DES Cryptographic service provider
    Private TripleDes As New TripleDESCryptoServiceProvider
    'Create bye array of specified length from the hash of the specified key.
    Private Function TruncateHash(ByVal Key As String, ByVal length As Integer) As Byte()
        Dim Sha1 As New SHA1CryptoServiceProvider
        'Hash the key
        Dim KeyBytes() As Byte = Text.Encoding.Unicode.GetBytes(Key)
        Dim Hash() As Byte = Sha1.ComputeHash(KeyBytes)
        'Truncate or pad the hash
        ReDim Preserve Hash(length - 1)
        Return Hash
    End Function
    Public Sub New(Ikey As String)
        'Add Constructor to initialize the 3DES cryptographic service provider
        'Key param -> controls the encryptData and decryptData methods.
        'Initialize the Crypto Provider
        TripleDes.Key = TruncateHash(Ikey, CInt(TripleDes.KeySize / 8))
        TripleDes.IV = TruncateHash(" ", CInt(TripleDes.BlockSize / 8))
    End Sub
    Public Function EncryptData(ByVal PlainText As String) As String
        Try
            'Function to Encrypt the String.
            'Convert the PlainText to Byte array
            Dim PlainTextBytes() As Byte = Text.Encoding.Unicode.GetBytes(PlainText)
            'Create the stream
            Dim MemStream As New IO.MemoryStream()
            'Create the Encoder to write the Stream.
            Dim EncStream As New CryptoStream(MemStream,
                                              TripleDes.CreateEncryptor,
                                              CryptoStreamMode.Write)
            'Use the CryptoStream to write the Byte Array to the stream.
            EncStream.Write(PlainTextBytes, 0, PlainTextBytes.Length)
            EncStream.FlushFinalBlock()
            'Convert the encrypted stream to printable String.
            Return Convert.ToBase64String(MemStream.ToArray)
        Catch ex As Exception
            Return ("Error Encrypting : " & ex.Message)
        End Try
    End Function
    Public Function DecryptData(ByVal EncryptedText As String) As String
        Try
            'Function to Decrypt the String.
            'Convert the Encrypted Text to Byte array
            Dim EncryptedBytes() As Byte = Convert.FromBase64String(EncryptedText)
            'Create the stream
            Dim MemStream As New IO.MemoryStream()
            'Create the Decoder to write the Stream.
            Dim DecStream As New CryptoStream(MemStream,
                                              TripleDes.CreateDecryptor,
                                              CryptoStreamMode.Write)
            'Use the CryptoStream to write the Byte Array to the stream.
            DecStream.Write(EncryptedBytes, 0, EncryptedBytes.Length)
            DecStream.FlushFinalBlock()
            'Convert the PlainText stream to a String.
            Return Text.Encoding.Unicode.GetString(MemStream.ToArray)
        Catch ex As Exception
            Return ("Error Decrypting : " & ex.Message)
        End Try
    End Function
    Public Sub Dispose() Implements IDisposable.Dispose
        TripleDes.Dispose()
    End Sub
End Class
