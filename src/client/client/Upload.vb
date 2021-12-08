Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Net
Imports System.Environment

Public Class Upload
    Public Shared Function FileAvailable(ByVal file As FileInfo) As Boolean
        Dim stream As FileStream = Nothing
        Try
            stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None)
            stream.Close()
        Catch ex As Exception
            If TypeOf ex Is IOException AndAlso IsFileLocked(ex) Then
                Return False
            End If
        End Try
        Return True
    End Function

    Private Shared Function IsFileLocked(exception As Exception) As Boolean
        Dim errorCode As Integer = Marshal.GetHRForException(exception) And ((1 << 16) - 1)
        Return errorCode = 32 OrElse errorCode = 33
    End Function


    Private Shared Sub doUpload(filePath As String, url As String)
        Do Until FileAvailable(New FileInfo(filePath))
            Thread.Sleep(100)
        Loop

        If My.Settings.saveLocally Then
            Try
                Dim ext = filePath.Substring(filePath.Length - 4)
                File.Copy(filePath, My.Settings.localPath + "\" + Now.ToString("yyyy-MM-dd_HH-mm-ss") + ext)
            Catch ex As Exception
            End Try
        End If

        Dim resS
        Try
            Dim res
            Using wc As New WebClient
                res = wc.UploadFile(My.Settings.uploadUrl + My.Settings.token, filePath)
            End Using

            resS = Text.Encoding.ASCII.GetString(res)

            If resS = "error" Then Throw New WebException
        Catch ex As WebException
            Try
                Dim statusCode = TryCast(ex.Response, HttpWebResponse).StatusCode
                If statusCode = 400 Then
                    MessageBox.Show("Uploaded file was empty. Check your paths or try running as admin")
                ElseIf statusCode = 401 Then
                    MessageBox.Show("Invalid upload token")
                ElseIf statusCode = 500 Then
                    MessageBox.Show("Server error while handling upload")
                Else
                    MessageBox.Show("Error while uploading")
                End If
            Catch ex2 As Exception
                MessageBox.Show("Error while uploading")
                resS = "error"
            End Try
            resS = "error"
        End Try

        If Not resS = "error" Then
            If My.Settings.copyLink Then Clipboard.SetText(resS)
            If My.Settings.playBeep Then Console.Beep()
            If My.Settings.openInBrowser Then Process.Start(resS)
            If My.Settings.maxLinks >= 1 Then
                Dim newLinks As String = resS + vbCrLf
                If File.Exists(GetFolderPath(SpecialFolder.ApplicationData) + "\screen.sbs\links.txt") Then
                    Dim links As String() = File.ReadAllLines(GetFolderPath(SpecialFolder.ApplicationData) + "\screen.sbs\links.txt")
                    Dim i As Integer = 1

                    For Each l As String In links
                        If l.StartsWith("https") Then
                            i += 1
                            If Not i > My.Settings.maxLinks - 1 Then
                                newLinks += l + vbCrLf
                            ElseIf i = My.Settings.maxLinks Then
                                newLinks += l
                            End If
                        End If
                    Next
                End If

                If Not Directory.Exists(GetFolderPath(SpecialFolder.ApplicationData) + "\screen.sbs\") Then
                    Try
                        Directory.CreateDirectory(GetFolderPath(SpecialFolder.ApplicationData) + "\screen.sbs\")
                    Catch ex As Exception
                    End Try
                End If
                Try
                    File.WriteAllText(GetFolderPath(SpecialFolder.ApplicationData) + "\screen.sbs\links.txt", newLinks)
                Catch ex As Exception
                End Try

                LinkList.updateLinks()
            End If
        End If
    End Sub

    Public Shared Function post(filePath As String)
        Dim uploadThread As New Thread(Sub() doUpload(filePath, My.Settings.uploadUrl))
        uploadThread.SetApartmentState(ApartmentState.STA)
        uploadThread.Start()

        Return uploadThread
    End Function
End Class
