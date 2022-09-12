Imports ActiveDev

Public Class frmMain
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
    Friend WithEvents btnCallWizard As System.Windows.Forms.Button
    Friend WithEvents btnEndProgram As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnCallWizard = New System.Windows.Forms.Button
        Me.btnEndProgram = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnCallWizard
        '
        Me.btnCallWizard.Location = New System.Drawing.Point(72, 32)
        Me.btnCallWizard.Name = "btnCallWizard"
        Me.btnCallWizard.Size = New System.Drawing.Size(200, 40)
        Me.btnCallWizard.TabIndex = 0
        Me.btnCallWizard.Text = "Assistenten aufrufen"
        '
        'btnEndProgram
        '
        Me.btnEndProgram.Location = New System.Drawing.Point(76, 107)
        Me.btnEndProgram.Name = "btnEndProgram"
        Me.btnEndProgram.Size = New System.Drawing.Size(200, 40)
        Me.btnEndProgram.TabIndex = 1
        Me.btnEndProgram.Text = "Programm beenden"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(352, 190)
        Me.Controls.Add(Me.btnEndProgram)
        Me.Controls.Add(Me.btnCallWizard)
        Me.Name = "frmMain"
        Me.Text = "Assistenten-Demo"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnEndProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                    Handles btnEndProgram.Click
        Me.Dispose()
    End Sub

    Private Sub btnCallWizard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCallWizard.Click

        'ACHTUNG: Änderung in letzter Minute. Beim Aufruf des Assistenten übergeben Sie
        'das Formular, das den Assistenten einbindet, EBENFALLS. Dadurch wird die
        'Owner-Eigenschaft aller Assistentenfenster auf "Me" gesetzt, und das Fenster,
        'das den Assistenten aufruft, scheint beim Schritt-Wechsel nicht störend durch,
        'falls es *unter* dem Assistenten liegen sollte. Beachten Sie auch die Änderungen
        'in der Schnittstelle IADWiazrd und im Konstruktorcode von ADWizardHandler in der
        'Codedatei ADWizardHelperClasses!
        '                                                             ^^^^
        Dim locWizardHandler As New ADWizardHandler("Assistentendemo", Me, _
                                        New ADFormWizardTemplate, _
                                        New frmStep1, _
                                        New frmStep2)
        Dim locWR As WizardDialogResult = locWizardHandler.PerformWizard
        MessageBox.Show("Der Assistent hat '" + locWR.ToString + "' zurückgeliefert.")

    End Sub
End Class
