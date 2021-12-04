Imports System.Environment

Public Class LinkList
    Private Shared linkList As New List(Of String)
    Private linkListLast As New List(Of String)

    Public Shared Sub updateLinks()
        Try
            If IO.File.Exists(GetFolderPath(SpecialFolder.ApplicationData) + "\screen.sbs\links.txt") Then
                Dim links As String = IO.File.ReadAllText(GetFolderPath(SpecialFolder.ApplicationData) + "\screen.sbs\links.txt")
                linkList = New List(Of String)
                For Each l As String In links.Split(vbCrLf)
                    linkList.Add(l)
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LinkList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        updateLinks()
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            If linkListLast.Count < linkList.Count Then
                linkListLast = linkList
                ListBox1.Items.Clear()
                For Each s As String In linkList
                    ListBox1.Items.Add(s)
                Next
            ElseIf Not linkList(linkList.Count - 1) = linkListLast(linkList.Count - 1) Then
                linkListLast = linkList
                ListBox1.Items.Clear()
                For Each s As String In linkList
                    ListBox1.Items.Add(s)
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
        Try
            Process.Start(ListBox1.SelectedItem.ToString.Replace(vbCr, "").Replace(vbLf, ""))
        Catch ex As Exception
        End Try
    End Sub
End Class