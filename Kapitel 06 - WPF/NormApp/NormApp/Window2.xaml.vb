Imports System
Imports System.Windows

Namespace NormApp
    Partial Public Class Window2
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub btnClicked(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
            Me.Close()
        End Sub
    End Class
End Namespace

