Imports System
Imports System.Windows.Navigation

Namespace BrowserApp
    Partial Public Class Page1
        Inherits System.Windows.Controls.Page

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub OnNext(ByVal sender As System.Object, _
                           ByVal e As System.Windows.RoutedEventArgs)
            NavigationService.GetNavigationService(Me).Navigate _
            (New Uri("Page2.xaml", UriKind.Relative))
        End Sub

        Private Sub OnForward(ByVal sender As System.Object, _
                              ByVal e As System.Windows.RoutedEventArgs)
            Dim nav As NavigationService
            nav = NavigationService.GetNavigationService(Me)

            ' Ist die Vorwärts-Navigation möglich?
            If nav.CanGoForward Then
                nav.GoForward()
            Else
                MessageBox.Show("Vorwärts geht es leider noch nicht!")
            End If

        End Sub
    End Class
End Namespace

