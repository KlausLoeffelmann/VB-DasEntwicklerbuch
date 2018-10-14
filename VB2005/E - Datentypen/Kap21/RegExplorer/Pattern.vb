Imports System.Xml.Serialization
Imports System.IO
Public Class Patterns
    Inherits System.Collections.ObjectModel.Collection(Of Pattern)

    ''' <summary>
    ''' Serialisiert die komplette Auflistung in eine XML-Datei.
    ''' </summary>
    ''' <param name="Filename">Dateiname der XML-Datei.</param>
    ''' <remarks></remarks>
    Sub SerializeToXML(ByVal Filename As String)
        Dim writer As New XmlSerializer(GetType(Patterns))
        Dim file As New StreamWriter(Filename)
        writer.Serialize(file, Me)
        'Wichtig, damit alles in der Datei steht -
        'auch das, was noch im internen file-Puffer steht!!!
        file.Flush()
        file.Close()
    End Sub

    ''' <summary>
    ''' Deserialisiert eine XML-Datei mit Pattern-Objekten und liefert die Collection zurück.
    ''' </summary>
    ''' <param name="Filename">Datei mit den serialisierten Objekten.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DeserializeFromFile(ByVal Filename As String) As Patterns
        Dim reader As New XmlSerializer(GetType(Patterns))
        Dim file As New StreamReader(Filename)

        'Das erpart uns eine Try/Finally-Verrenkung, da End Using
        'dafür sorgt, dass die Datei IMMER geschlossen wird...
        Using file
            Dim classData As Patterns
            classData = CType(reader.Deserialize(file), Patterns)

            '...auch noch dann, wenn Return bereits an dieser
            'Stelle aufgerufen wurde!
            Return classData

            'Hier also wird file geschlossen, auch wenn das Return
            'zuvor schon das Ende der Prozedur eingeleitet hat.
        End Using
    End Function
End Class

<Serializable()> _
Public Class Pattern

    Private mySearchPattern As String
    Private myReplacePattern As String
    Private myComment As String

    Sub New()
        MyBase.New()
    End Sub

    Sub New(ByVal SearchPattern As String, ByVal ReplacePattern As String, ByVal Comment As String)
        mySearchPattern = SearchPattern
        myReplacePattern = ReplacePattern
        myComment = Comment
    End Sub

    ''' <summary>
    ''' Das Suchmuster als Regular Expression.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SearchPattern() As String
        Get
            Return mySearchPattern
        End Get
        Set(ByVal Value As String)
            mySearchPattern = Value
        End Set
    End Property

    ''' <summary>
    ''' Das Ersetzungsmuster als Regular Expression.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ReplacePattern() As String
        Get
            Return myReplacePattern
        End Get
        Set(ByVal Value As String)
            myReplacePattern = Value
        End Set
    End Property

    ''' <summary>
    ''' Ein beschreibender Kommentar.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Comment() As String
        Get
            Return myComment
        End Get
        Set(ByVal Value As String)
            myComment = Value
        End Set
    End Property
End Class
