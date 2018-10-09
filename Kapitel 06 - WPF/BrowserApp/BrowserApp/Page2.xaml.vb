Imports System
Imports System.Windows
Imports System.Windows.Navigation

Namespace BrowserApp
    Partial Public Class Page2
        Inherits System.Windows.Controls.Page

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub OnClick(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
            NavigationService.GetNavigationService(Me).GoBack()
        End Sub
    End Class
End Namespace
