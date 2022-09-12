Public Class frmMain
    Inherits System.Windows.Forms.Form

#Region " Vom Windows Form Designer generierter Code "


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
    Friend WithEvents AdAutoReportView As ActiveDev.ADAutoReportView
    Friend WithEvents btnAnzeigen As System.Windows.Forms.Button
    Friend WithEvents btnProgrammBeenden As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.AdAutoReportView = New ActiveDev.ADAutoReportView
        Me.btnAnzeigen = New System.Windows.Forms.Button
        Me.btnProgrammBeenden = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'AdAutoReportView
        '
        Me.AdAutoReportView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AdAutoReportView.FullRowSelect = True
        Me.AdAutoReportView.GridLines = True
        Me.AdAutoReportView.HideSelection = False
        Me.AdAutoReportView.List = Nothing
        Me.AdAutoReportView.Location = New System.Drawing.Point(8, 16)
        Me.AdAutoReportView.Name = "AdAutoReportView"
        Me.AdAutoReportView.Size = New System.Drawing.Size(408, 312)
        Me.AdAutoReportView.TabIndex = 0
        Me.AdAutoReportView.View = System.Windows.Forms.View.Details
        '
        'btnAnzeigen
        '
        Me.btnAnzeigen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAnzeigen.Location = New System.Drawing.Point(432, 16)
        Me.btnAnzeigen.Name = "btnAnzeigen"
        Me.btnAnzeigen.Size = New System.Drawing.Size(136, 32)
        Me.btnAnzeigen.TabIndex = 1
        Me.btnAnzeigen.Text = "Adressen anzeigen"
        '
        'btnProgrammBeenden
        '
        Me.btnProgrammBeenden.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnProgrammBeenden.Location = New System.Drawing.Point(432, 56)
        Me.btnProgrammBeenden.Name = "btnProgrammBeenden"
        Me.btnProgrammBeenden.Size = New System.Drawing.Size(136, 32)
        Me.btnProgrammBeenden.TabIndex = 2
        Me.btnProgrammBeenden.Text = "Programm beenden"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(576, 342)
        Me.Controls.Add(Me.btnProgrammBeenden)
        Me.Controls.Add(Me.btnAnzeigen)
        Me.Controls.Add(Me.AdAutoReportView)
        Me.Name = "frmMain"
        Me.Text = "ADAutoReportView-Demo"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private myAdressen As Adressen

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

    End Sub

    Private Sub btnAnzeigen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnzeigen.Click

        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzufügen
        myAdressen = Adresse.ZufallsAdressen(100)
        AdAutoReportView.List = myAdressen

    End Sub

    Private Sub btnProgrammBeenden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProgrammBeenden.Click
        Me.Dispose()
    End Sub

End Class
