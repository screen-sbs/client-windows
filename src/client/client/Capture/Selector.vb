Public Class Selector

    Private Sub Selector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DoubleBuffered = True

        Opacity = 0.4
        FormBorderStyle = FormBorderStyle.None
        Size = New Point(2, 2)
        ShowInTaskbar = False
    End Sub
End Class
