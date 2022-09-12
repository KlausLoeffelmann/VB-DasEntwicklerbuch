Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms.Design

'WICHTIG: Wenn Sie einen ControlDesigner einfügen,
'müssen Sie den System.Windows.Forms.Design-Namespace einbinden,
'und System.Design.Dll als Verweis dem Projekt hinzufügen!
Public Class ADLabelExDesigner
    Inherits ControlDesigner

    'Muss überschrieben werden, damit bei einem Steuerelement mit fixer Größe in 
    'einer vertikeler Richtung tatsächlich nur ein vertikale Größenänderung möglich wird.
    'Die vertikalen Anfasspunkte sind dann ausgeblendet
    Public Overrides ReadOnly Property SelectionRules() As System.Windows.Forms.Design.SelectionRules
        Get
            Dim locThisComponent As Object
            Dim locSelectionRules As SelectionRules

            locThisComponent = Me.Component

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
