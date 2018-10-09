Imports System
Imports System.Windows

Namespace Hallo

    Public Class Hallo
        Inherits System.Windows.Window

        <STAThread()> _
        Shared Sub main()
            Dim w As New Window With {.Title = "Hallo, Welt!", .Width = "200", .Height = "200"}
            w.Show()

            Dim app As New Application
            app.Run()
        End Sub

    End Class
End Namespace