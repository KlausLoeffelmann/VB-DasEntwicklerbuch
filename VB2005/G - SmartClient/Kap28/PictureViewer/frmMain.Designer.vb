<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnQuitProgram = New System.Windows.Forms.Button
        Me.btnSaveBitmap = New System.Windows.Forms.Button
        Me.pnlPicture = New System.Windows.Forms.Panel
        Me.picViewArea = New System.Windows.Forms.PictureBox
        Me.btnOpenBitmap = New PictureViewer.ButtonEx
        Me.btnNextBitmap = New PictureViewer.ButtonEx
        Me.pnlPicture.SuspendLayout()
        CType(Me.picViewArea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnQuitProgram
        '
        Me.btnQuitProgram.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnQuitProgram.Location = New System.Drawing.Point(468, 152)
        Me.btnQuitProgram.Name = "btnQuitProgram"
        Me.btnQuitProgram.Size = New System.Drawing.Size(124, 32)
        Me.btnQuitProgram.TabIndex = 7
        Me.btnQuitProgram.Text = "Programm be&enden"
        '
        'btnSaveBitmap
        '
        Me.btnSaveBitmap.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveBitmap.Location = New System.Drawing.Point(468, 50)
        Me.btnSaveBitmap.Name = "btnSaveBitmap"
        Me.btnSaveBitmap.Size = New System.Drawing.Size(123, 32)
        Me.btnSaveBitmap.TabIndex = 6
        Me.btnSaveBitmap.Text = "Grafik &speichern unter"
        '
        'pnlPicture
        '
        Me.pnlPicture.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPicture.AutoScroll = True
        Me.pnlPicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPicture.Controls.Add(Me.picViewArea)
        Me.pnlPicture.Location = New System.Drawing.Point(12, 12)
        Me.pnlPicture.Name = "pnlPicture"
        Me.pnlPicture.Size = New System.Drawing.Size(450, 400)
        Me.pnlPicture.TabIndex = 5
        '
        'picViewArea
        '
        Me.picViewArea.Location = New System.Drawing.Point(0, 0)
        Me.picViewArea.Name = "picViewArea"
        Me.picViewArea.Size = New System.Drawing.Size(360, 304)
        Me.picViewArea.TabIndex = 0
        Me.picViewArea.TabStop = False
        '
        'btnOpenBitmap
        '
        Me.btnOpenBitmap.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpenBitmap.Location = New System.Drawing.Point(468, 12)
        Me.btnOpenBitmap.Name = "btnOpenBitmap"
        Me.btnOpenBitmap.Size = New System.Drawing.Size(123, 32)
        Me.btnOpenBitmap.TabIndex = 8
        Me.btnOpenBitmap.Text = "Grafik öffnen"
        Me.btnOpenBitmap.UseVisualStyleBackColor = True
        '
        'btnNextBitmap
        '
        Me.btnNextBitmap.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNextBitmap.Location = New System.Drawing.Point(468, 88)
        Me.btnNextBitmap.Name = "btnNextBitmap"
        Me.btnNextBitmap.Size = New System.Drawing.Size(123, 32)
        Me.btnNextBitmap.TabIndex = 9
        Me.btnNextBitmap.Text = "Nächste Grafik"
        Me.btnNextBitmap.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(603, 454)
        Me.Controls.Add(Me.btnNextBitmap)
        Me.Controls.Add(Me.btnOpenBitmap)
        Me.Controls.Add(Me.btnQuitProgram)
        Me.Controls.Add(Me.btnSaveBitmap)
        Me.Controls.Add(Me.pnlPicture)
        Me.Name = "frmMain"
        Me.Text = "PictureViewer"
        Me.pnlPicture.ResumeLayout(False)
        CType(Me.picViewArea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnQuitProgram As System.Windows.Forms.Button
    Friend WithEvents btnSaveBitmap As System.Windows.Forms.Button
    Friend WithEvents pnlPicture As System.Windows.Forms.Panel
    Friend WithEvents picViewArea As System.Windows.Forms.PictureBox
    Friend WithEvents btnOpenBitmap As PictureViewer.ButtonEx
    Friend WithEvents btnNextBitmap As PictureViewer.ButtonEx

End Class
