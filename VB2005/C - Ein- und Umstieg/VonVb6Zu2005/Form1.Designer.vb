<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.btnVbUndFrameworkTypen = New System.Windows.Forms.Button
        Me.btnVariablentypzeichen = New System.Windows.Forms.Button
        Me.btnStringsSindObjekte = New System.Windows.Forms.Button
        Me.btnDateiLesenDotNet = New System.Windows.Forms.Button
        Me.btnDateiLesenVB6Stil = New System.Windows.Forms.Button
        Me.btnTryCatchFinally = New System.Windows.Forms.Button
        Me.btnAndAlsoDemo = New System.Windows.Forms.Button
        Me.btnSchleifendemo = New System.Windows.Forms.Button
        Me.btnMultiplikationMitBitverschiebung = New System.Windows.Forms.Button
        Me.btnDemoEnde = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnVbUndFrameworkTypen
        '
        Me.btnVbUndFrameworkTypen.Location = New System.Drawing.Point(12, 12)
        Me.btnVbUndFrameworkTypen.Name = "btnVbUndFrameworkTypen"
        Me.btnVbUndFrameworkTypen.Size = New System.Drawing.Size(182, 40)
        Me.btnVbUndFrameworkTypen.TabIndex = 0
        Me.btnVbUndFrameworkTypen.Text = "Demo VB- und Framework-Typen"
        Me.btnVbUndFrameworkTypen.UseVisualStyleBackColor = True
        '
        'btnVariablentypzeichen
        '
        Me.btnVariablentypzeichen.Location = New System.Drawing.Point(12, 58)
        Me.btnVariablentypzeichen.Name = "btnVariablentypzeichen"
        Me.btnVariablentypzeichen.Size = New System.Drawing.Size(182, 40)
        Me.btnVariablentypzeichen.TabIndex = 1
        Me.btnVariablentypzeichen.Text = "Demo Variablentypzeichen"
        Me.btnVariablentypzeichen.UseVisualStyleBackColor = True
        '
        'btnStringsSindObjekte
        '
        Me.btnStringsSindObjekte.Location = New System.Drawing.Point(12, 104)
        Me.btnStringsSindObjekte.Name = "btnStringsSindObjekte"
        Me.btnStringsSindObjekte.Size = New System.Drawing.Size(182, 40)
        Me.btnStringsSindObjekte.TabIndex = 2
        Me.btnStringsSindObjekte.Text = "Strings sind Objekte"
        Me.btnStringsSindObjekte.UseVisualStyleBackColor = True
        '
        'btnDateiLesenDotNet
        '
        Me.btnDateiLesenDotNet.Location = New System.Drawing.Point(12, 196)
        Me.btnDateiLesenDotNet.Name = "btnDateiLesenDotNet"
        Me.btnDateiLesenDotNet.Size = New System.Drawing.Size(182, 40)
        Me.btnDateiLesenDotNet.TabIndex = 3
        Me.btnDateiLesenDotNet.Text = "Datei lesen mit Fehlerbehandlung .NET-Version (ordentlich!)"
        Me.btnDateiLesenDotNet.UseVisualStyleBackColor = True
        '
        'btnDateiLesenVB6Stil
        '
        Me.btnDateiLesenVB6Stil.Location = New System.Drawing.Point(12, 150)
        Me.btnDateiLesenVB6Stil.Name = "btnDateiLesenVB6Stil"
        Me.btnDateiLesenVB6Stil.Size = New System.Drawing.Size(182, 40)
        Me.btnDateiLesenVB6Stil.TabIndex = 4
        Me.btnDateiLesenVB6Stil.Text = "Datei lesen mit Fehlerbehandlung VB6-Stil (armselig!)"
        Me.btnDateiLesenVB6Stil.UseVisualStyleBackColor = True
        '
        'btnTryCatchFinally
        '
        Me.btnTryCatchFinally.Location = New System.Drawing.Point(225, 12)
        Me.btnTryCatchFinally.Name = "btnTryCatchFinally"
        Me.btnTryCatchFinally.Size = New System.Drawing.Size(182, 40)
        Me.btnTryCatchFinally.TabIndex = 5
        Me.btnTryCatchFinally.Text = "Try/Catch und Finally-Demo"
        Me.btnTryCatchFinally.UseVisualStyleBackColor = True
        '
        'btnAndAlsoDemo
        '
        Me.btnAndAlsoDemo.Location = New System.Drawing.Point(225, 58)
        Me.btnAndAlsoDemo.Name = "btnAndAlsoDemo"
        Me.btnAndAlsoDemo.Size = New System.Drawing.Size(182, 40)
        Me.btnAndAlsoDemo.TabIndex = 6
        Me.btnAndAlsoDemo.Text = "AndAlso-Demo"
        Me.btnAndAlsoDemo.UseVisualStyleBackColor = True
        '
        'btnSchleifendemo
        '
        Me.btnSchleifendemo.Location = New System.Drawing.Point(225, 104)
        Me.btnSchleifendemo.Name = "btnSchleifendemo"
        Me.btnSchleifendemo.Size = New System.Drawing.Size(182, 40)
        Me.btnSchleifendemo.TabIndex = 7
        Me.btnSchleifendemo.Text = "Direktdeklaration in Schleifen"
        Me.btnSchleifendemo.UseVisualStyleBackColor = True
        '
        'btnMultiplikationMitBitverschiebung
        '
        Me.btnMultiplikationMitBitverschiebung.Location = New System.Drawing.Point(225, 150)
        Me.btnMultiplikationMitBitverschiebung.Name = "btnMultiplikationMitBitverschiebung"
        Me.btnMultiplikationMitBitverschiebung.Size = New System.Drawing.Size(182, 40)
        Me.btnMultiplikationMitBitverschiebung.TabIndex = 8
        Me.btnMultiplikationMitBitverschiebung.Text = "Integermultiplikation mit Bitverschiebungen"
        Me.btnMultiplikationMitBitverschiebung.UseVisualStyleBackColor = True
        '
        'btnDemoEnde
        '
        Me.btnDemoEnde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDemoEnde.Location = New System.Drawing.Point(225, 196)
        Me.btnDemoEnde.Name = "btnDemoEnde"
        Me.btnDemoEnde.Size = New System.Drawing.Size(182, 40)
        Me.btnDemoEnde.TabIndex = 9
        Me.btnDemoEnde.Text = "Ende der Demo"
        Me.btnDemoEnde.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AcceptButton = Me.btnDemoEnde
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(423, 251)
        Me.Controls.Add(Me.btnDemoEnde)
        Me.Controls.Add(Me.btnMultiplikationMitBitverschiebung)
        Me.Controls.Add(Me.btnSchleifendemo)
        Me.Controls.Add(Me.btnAndAlsoDemo)
        Me.Controls.Add(Me.btnTryCatchFinally)
        Me.Controls.Add(Me.btnDateiLesenVB6Stil)
        Me.Controls.Add(Me.btnDateiLesenDotNet)
        Me.Controls.Add(Me.btnStringsSindObjekte)
        Me.Controls.Add(Me.btnVariablentypzeichen)
        Me.Controls.Add(Me.btnVbUndFrameworkTypen)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Form1"
        Me.Text = "Demos zum Umstig von VB6 auf VB.NET (2005)"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnVbUndFrameworkTypen As System.Windows.Forms.Button
    Friend WithEvents btnVariablentypzeichen As System.Windows.Forms.Button
    Friend WithEvents btnStringsSindObjekte As System.Windows.Forms.Button
    Friend WithEvents btnDateiLesenDotNet As System.Windows.Forms.Button
    Friend WithEvents btnDateiLesenVB6Stil As System.Windows.Forms.Button
    Friend WithEvents btnTryCatchFinally As System.Windows.Forms.Button
    Friend WithEvents btnAndAlsoDemo As System.Windows.Forms.Button
    Friend WithEvents btnSchleifendemo As System.Windows.Forms.Button
    Friend WithEvents btnMultiplikationMitBitverschiebung As System.Windows.Forms.Button
    Friend WithEvents btnDemoEnde As System.Windows.Forms.Button

End Class
