Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms.Design

'WICHTIG: Wenn Sie einen ControlDesigner einf�gen,
'm�ssen Sie den System.Windows.Forms.Design-Namespace einbinden,
'und System.Design.Dll als Verweis dem Projekt hinzuf�gen!
Public Class ADLabelExDesigner
    Inherits ControlDesigner

    'Muss �berschrieben werden, damit bei einem Steuerelement mit fixer Gr��e in 
    'einer vertikeler Richtung tats�chlich nur ein vertikale Gr��en�nderung m�glich wird.
    'Die vertikalen Anfasspunkte sind dann ausgeblendet
    Public Overrides ReadOnly Property SelectionRules() As System.Windows.Forms.Design.SelectionRules
        Get
            Dim locThisComponent As Object
            Dim locSelectionRules As SelectionRules

            locThisComponent = Me.Component

            Try
                'In Abh�ngigkeit von ConsiderFixedSize (die sich beispielsweise durch Multiline �ndert) 
                If Convert.ToBoolean(TypeDescriptor.GetProperties(locThisComponent).Item("AutoHeight").GetValue(locThisComponent)) Then
                    'Nur vertikale Gr��enver�nderungen...
                    locSelectionRules = SelectionRules.Moveable Or SelectionRules.Visible Or SelectionRules.LeftSizeable Or SelectionRules.RightSizeable
                Else
                    '...oder komplette Gr��enver�nderungen erm�glichen
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
