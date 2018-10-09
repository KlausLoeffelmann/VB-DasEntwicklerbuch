Imports System.ComponentModel
Imports System.ComponentModel.Design

Public Class ThreadSafeTextWindowComponent
    Inherits Component

    Private myHostingForm As Form
    Private mySyncInvoker As ISynchronizeInvoke
    Private myOutputPane As TheTextForm
    Private myText As String = ""

    ''' <summary>
    ''' Internal use - don't use directly.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
     EditorBrowsable(EditorBrowsableState.Advanced),
     Browsable(False)>
    Public Overrides Property Site() As ISite
        <DebuggerHidden()>
        Get
            Return MyBase.Site
        End Get

        Set(ByVal value As ISite)
            MyBase.Site = value
            If value Is Nothing Then
                Return
            End If

            Dim host As IDesignerHost = TryCast(value.GetService(GetType(IDesignerHost)), IDesignerHost)
            If host IsNot Nothing Then
                Dim componentHost As IComponent = host.RootComponent
                If TypeOf componentHost Is Form Then
                    HostingForm = TryCast(componentHost, Form)
                End If
            End If
        End Set
    End Property

    ''' <summary>
    ''' Bestimmt oder ermittelt das Parent-Form, das dieser Komponente zugeordnet ist.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>HINWEIS: Diese Eigenschaft wird gesetzt, wenn Sie im Designer diese Komponente auf das Formular ziehen, 
    ''' und sie sollte anschließend nicht mehr geändert werden.</remarks>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
     EditorBrowsable(EditorBrowsableState.Advanced),
     Browsable(False)>
    Public Property HostingForm As Form
        Get
            Return myHostingForm
        End Get
        Set(ByVal value As Form)
            If value IsNot myHostingForm Then
                myHostingForm = value
                mySyncInvoker = DirectCast(myHostingForm, ISynchronizeInvoke)
            End If
        End Set
    End Property

    Friend ReadOnly Property OutputPane As TheTextForm
        Get
            If myOutputPane Is Nothing Then
                Dim outputPaneShower = Sub()
                                           myOutputPane = New TheTextForm
                                           AddHandler myOutputPane.FormClosing,
                                               Sub(Sender As Object, e As FormClosingEventArgs)
                                                   myOutputPane = Nothing
                                               End Sub
                                           myOutputPane.Show()
                                       End Sub

                If mySyncInvoker IsNot Nothing Then
                    If mySyncInvoker.InvokeRequired Then
                        mySyncInvoker.Invoke(outputPaneShower, {})
                    Else
                        outputPaneShower()
                    End If
                End If
            End If
            Return myOutputPane
        End Get
    End Property

    'Nutzt TSWrite; siehe dort.
    Public Sub TSWriteLine(ByVal Message As String)
        Message += vbNewLine
        TSWrite(Message)
    End Sub

    'Ausgabe ohne neue Zeile
    Public Sub TSWrite(ByVal Message As String)

        Dim outputDeL = Sub()
                            OutputPane.OutputTextBox.AppendText(Message)
                            OutputPane.OutputTextBox.SelectionStart = OutputPane.OutputTextBox.Text.Length - 1
                            OutputPane.OutputTextBox.ScrollToCaret()
                        End Sub

        'Wenn der UI-Thread TSWrite verwendet, dann darf der nicht gelockt werden,
        'anderenfalls kann innerhalb des Locks Invoke nicht mehr 
        'ausgeführt werden, denn der UI-Thread führt den ja aus.
        'Wenn der UI-Thread allerdings hier wartet...
        If Not Me.OutputPane.InvokeRequired Then
            outputDeL()
        Else
            Try
                Me.OutputPane.Invoke(outputDeL)
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
        End If
    End Sub
End Class

Friend Class TheTextForm
    Inherits Form

    Private myOutputTextBox As TextBox

    Sub New()
        MyBase.New()
        myOutputTextBox = New TextBox
        With myOutputTextBox
            .Dock = DockStyle.Fill
            .ReadOnly = True
            .ScrollBars = ScrollBars.Vertical
            .Multiline = True
        End With
        Me.Controls.Add(myOutputTextBox)
    End Sub

    Friend ReadOnly Property OutputTextBox As TextBox
        Get
            Return myOutputTextBox
        End Get
    End Property
End Class
