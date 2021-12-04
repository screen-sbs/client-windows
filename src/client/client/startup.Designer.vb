<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class startup
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(startup))
        Me.notifyMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.menuTakeScreenshot = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuCaptureVideo = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuPasteText = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuLinkHistory = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.notifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.notifyMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'notifyMenu
        '
        Me.notifyMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuTakeScreenshot, Me.menuCaptureVideo, Me.menuPasteText, Me.ToolStripSeparator2, Me.menuLinkHistory, Me.menuSettings, Me.ToolStripSeparator1, Me.menuExit})
        Me.notifyMenu.Name = "notifyMenu"
        Me.notifyMenu.Size = New System.Drawing.Size(136, 148)
        '
        'menuTakeScreenshot
        '
        Me.menuTakeScreenshot.Image = CType(resources.GetObject("menuTakeScreenshot.Image"), System.Drawing.Image)
        Me.menuTakeScreenshot.Name = "menuTakeScreenshot"
        Me.menuTakeScreenshot.Size = New System.Drawing.Size(135, 22)
        Me.menuTakeScreenshot.Text = "Screenshot"
        '
        'menuCaptureVideo
        '
        Me.menuCaptureVideo.Image = CType(resources.GetObject("menuCaptureVideo.Image"), System.Drawing.Image)
        Me.menuCaptureVideo.Name = "menuCaptureVideo"
        Me.menuCaptureVideo.Size = New System.Drawing.Size(135, 22)
        Me.menuCaptureVideo.Text = "Video"
        '
        'menuPasteText
        '
        Me.menuPasteText.Image = CType(resources.GetObject("menuPasteText.Image"), System.Drawing.Image)
        Me.menuPasteText.Name = "menuPasteText"
        Me.menuPasteText.Size = New System.Drawing.Size(135, 22)
        Me.menuPasteText.Text = "Text"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(132, 6)
        '
        'menuLinkHistory
        '
        Me.menuLinkHistory.Image = CType(resources.GetObject("menuLinkHistory.Image"), System.Drawing.Image)
        Me.menuLinkHistory.Name = "menuLinkHistory"
        Me.menuLinkHistory.Size = New System.Drawing.Size(135, 22)
        Me.menuLinkHistory.Text = "Link history"
        '
        'menuSettings
        '
        Me.menuSettings.Image = CType(resources.GetObject("menuSettings.Image"), System.Drawing.Image)
        Me.menuSettings.Name = "menuSettings"
        Me.menuSettings.Size = New System.Drawing.Size(135, 22)
        Me.menuSettings.Text = "Settings"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(132, 6)
        '
        'menuExit
        '
        Me.menuExit.Image = CType(resources.GetObject("menuExit.Image"), System.Drawing.Image)
        Me.menuExit.Name = "menuExit"
        Me.menuExit.Size = New System.Drawing.Size(135, 22)
        Me.menuExit.Text = "Exit"
        '
        'notifyIcon
        '
        Me.notifyIcon.ContextMenuStrip = Me.notifyMenu
        Me.notifyIcon.Icon = CType(resources.GetObject("notifyIcon.Icon"), System.Drawing.Icon)
        Me.notifyIcon.Text = "screen.sbs"
        Me.notifyIcon.Visible = True
        '
        'startup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(200, 200)
        Me.Name = "startup"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "startup"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.notifyMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents notifyMenu As ContextMenuStrip
    Friend WithEvents menuTakeScreenshot As ToolStripMenuItem
    Friend WithEvents menuCaptureVideo As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents menuLinkHistory As ToolStripMenuItem
    Friend WithEvents menuSettings As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents menuExit As ToolStripMenuItem
    Friend WithEvents notifyIcon As NotifyIcon
    Friend WithEvents menuPasteText As ToolStripMenuItem
End Class
