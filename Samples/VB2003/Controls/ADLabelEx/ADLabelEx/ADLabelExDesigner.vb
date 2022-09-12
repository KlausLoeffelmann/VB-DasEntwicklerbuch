Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms.Design

'################################################
'### ControlDesigner Pendant ####################
'################################################

'WICHTIG: Wenn Sie einen ControlDesigner einfügen,
'müssen Sie den System.Windows.Forms.Design-Namespace einbinden,
'und System.Design.Dll als Verweis dem Projekt hinzufügen!
Public Class ADLabelExDesigner
    Inherits ControlDesigner

    'Diese Eigenschaft müssen Sie erweitern, wenn Sie eigene Initialisierungen von
    'Eigenschaften vornehmen wollen. An dieser Stelle finden Sie den exakten Code von
    'ControlDesigner.OnSetComponentDefaults, der sich um die Initialisierung der 'Text'-Eigenschaft kümmert.
    'Anstelle der kompletten Implementierung reichte auch der Aufruf
    'von 'MyBase.OnSetComponentDefaults()'
    Public Overrides Sub OnSetComponentDefaults()

        'Das ist hier 'geklaut' von ControlDesigner...
        Dim locISite As ISite
        Dim locPropDescriptor As PropertyDescriptor

        'ISite abrufen
        locISite = Me.Component.Site
        If Not locISite Is Nothing Then
            'Text-Property vorhanden?
            locPropDescriptor = TypeDescriptor.GetProperties(Me.Component)("Text")
            If Not locPropDescriptor Is Nothing Then
                'Ja, dann die Text-Property setzen
                locPropDescriptor.SetValue(Me.Component, locISite.Name)
            End If

            'Back-Color vorhanden?
            locPropDescriptor = TypeDescriptor.GetProperties(Me.Component)("BackColor")
            If Not locPropDescriptor Is Nothing Then
                'Ja, dann die BackColor-Property setzen
                locPropDescriptor.SetValue(Me.Component, SystemColors.Control)
            End If
        End If
    End Sub

    'Muss überschrieben werden, damit bei einem Steuerelement mit fixer Größe in 
    'einer vertikeler Richtung tatsächlich nur ein vertikale Größenänderung möglich wird.
    'Die vertikalen Anfasspunkte sind dann ausgeblendet
    Public Overrides ReadOnly Property SelectionRules() As System.Windows.Forms.Design.SelectionRules
        Get
            Dim locTest As ControlDesigner

            Dim locThisComponent As Object
            Dim locSelectionRules As SelectionRules

            locThisComponent = Me.Component
            Debug.WriteLine("Designermessage: This Component is" & (locThisComponent Is Nothing).ToString)

            Try
                'In Abhängigkeit von ConsiderFixedSize (die sich beispielsweise durch Multiline ändert) 
                If Convert.ToBoolean(TypeDescriptor.GetProperties(locThisComponent).Item("AutoHeight").GetValue(locThisComponent)) Then
                    'Nur vertikale Größenveränderungen...
                    locSelectionRules = SelectionRules.Moveable Or SelectionRules.Visible Or SelectionRules.LeftSizeable Or SelectionRules.RightSizeable
                Else
                    '...oder komplette Größenveränderungen ermöglichen
                    locSelectionRules = SelectionRules.Moveable Or SelectionRules.Visible Or SelectionRules.AllSizeable
                End If
                Return locSelectionRules
            Catch ex As Exception
                Debug.WriteLine("Designermessage:" & ex.Message)
                Return MyBase.SelectionRules
            End Try
        End Get
    End Property
End Class
