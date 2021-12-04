Public Class frmBorder
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Const WS_EX_TRANSPARENT As Integer = &H20
            Dim params As CreateParams = MyBase.CreateParams
            params.ExStyle = params.ExStyle Or WS_EX_TRANSPARENT
            Return params
        End Get
    End Property
End Class