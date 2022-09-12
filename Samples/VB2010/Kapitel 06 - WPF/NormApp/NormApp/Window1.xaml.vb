Imports System
Imports System.Windows

Namespace NormApp
    Partial Public Class Window1
        Inherits System.Windows.Window

        Public Sub New()
            InitializeComponent()
        End Sub


        Private Sub menuExit_Clicked(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
            Me.Close()
        End Sub

        Private Sub menuDiag_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
            Dim w As New Window2
            w.ShowDialog()
        End Sub
    End Class
End Namespace

