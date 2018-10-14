Option Explicit On 
Option Strict Off

Public Class frmSort
    Inherits System.Windows.Forms.Form

#Region " Vom Windows Form Designer generierter Code "

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzufügen

    End Sub

    ' Die Form überschreibt den Löschvorgang der Basisklasse, um Komponenten zu bereinigen.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Für Windows Form-Designer erforderlich
    Private components As System.ComponentModel.IContainer

    'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.Label1)
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(8, 8)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(289, 97)
        Me.Frame1.TabIndex = 2
        Me.Frame1.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(257, 40)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Liste wird sortiert. Bitte haben Sie einen Augenblick Geduld."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(8, 112)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(288, 24)
        Me.ProgressBar.TabIndex = 3
        '
        'frmSort
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(304, 150)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.Frame1)
        Me.Name = "frmSort"
        Me.Text = "Sortieren"
        Me.Frame1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Friend Function Sort(ByVal Items As ItemTypes) As ItemTypes

        Dim locTemp As ItemType
        Dim locFlag As Boolean
        Dim locCount As Integer

        Me.Show()
        Me.Refresh()

        ProgressBar.Minimum = 0
        ProgressBar.Maximum = Items.Count

        While Not locFlag
            locFlag = True

            For locCount = 0 To Items.Count - 2

                'Dreieckstausch
                If Items(locCount).Content > Items(locCount + 1).Content Then
                    locTemp = Items(locCount)
                    Items(locCount) = Items(locCount + 1)
                    Items(locCount + 1) = locTemp
                    locFlag = False
                    Exit For
                End If

                If ProgressBar.Value < locCount Then
                    ProgressBar.Value = locCount
                    ProgressBar.Refresh()
                End If

            Next

        End While

        Me.Dispose()
        Return Items

    End Function

End Class
