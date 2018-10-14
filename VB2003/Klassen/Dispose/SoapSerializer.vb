Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Soap

Public Enum SoapSerializerMode
    Close
    OpenForWriting
    OpenForReading
End Enum

Public Class SoapSerializer
    Implements IDisposable

    Protected myFilename As String
    Protected myFileStream As FileStream
    Protected mySoapFormatter As SoapFormatter
    Protected mySerializerMode As SoapSerializerMode
    Protected myDisposed As Boolean

    Sub New()
        mySoapFormatter = New SoapFormatter(Nothing, _
                        New StreamingContext(StreamingContextStates.File))
        mySerializerMode = SoapSerializerMode.Close
    End Sub

    Function OpenForWriting(ByVal Filename As String) As Boolean
        Return OpenForWriting(Filename, False)
    End Function

    Function OpenForWriting(ByVal Filename As String, ByVal OverwriteIfExist As Boolean) As Boolean

        Dim locFile As New FileInfo(Filename)

        If (Not OverwriteIfExist) And locFile.Exists Then
            Return True
        End If

        Try
            mySerializerMode = SoapSerializerMode.OpenForWriting
            myFileStream = New FileStream(Filename, FileMode.Create)
        Catch ex As Exception
            mySerializerMode = SoapSerializerMode.Close
        End Try

    End Function

    Function OpenForReading(ByVal Filename As String) As Boolean

        Dim locFile As New FileInfo(Filename)

        If Not locFile.Exists Then
            Return True
        End If

        Try
            mySerializerMode = SoapSerializerMode.OpenForReading
            myFileStream = New FileStream(Filename, FileMode.Open)
        Catch ex As Exception
            mySerializerMode = SoapSerializerMode.Close
        End Try

    End Function

    Sub SaveObject(ByVal Data As Object)

        'Serialisierung geht nur, wenn SoapSerializer
        'zum Schreiben geöffnet wurde
        If mySerializerMode <> SoapSerializerMode.OpenForWriting Then
            Dim Up As New IOException("SoapSerializer nicht zum Schreiben geöffnet!")
            Throw Up
        End If

        mySoapFormatter.Serialize(myFileStream, Data)

    End Sub

    Function LoadObject() As Object

        'Deserialisierung geht nur, wenn SoapSerializer
        'zum Schreiben geöffnet wurde
        If mySerializerMode <> SoapSerializerMode.OpenForReading Then
            Dim Up As New IOException("SoapSerializer nicht zum Lesen geöffnet!")
            Throw Up
        End If
        Return mySoapFormatter.Deserialize(myFileStream)

    End Function

    'Nur eine andere Form von Disposed
    Sub Close()
        Debug.WriteLine("Close() wurde aufgerufen!")
        Dispose()
    End Sub

    'Hier wird das Entsorgen delegiert
    Public Sub Dispose() Implements IDisposable.Dispose
        'Wir kümmern uns um die Entsorgung,
        'der Garbage Collector wird informiert,
        'dass er nichts mehr damit zu tun hat
        Debug.WriteLine("Dispose() wurde aufgerufen!")
        GC.SuppressFinalize(Me)
        Dispose(True)
    End Sub

    Public Sub Dispose(ByVal Disposing As Boolean)

        Debug.WriteLine("Dispose(Disposing) wurde aufgerufen...")
        'Falls der Aufruf nicht durch die GC kam
        If Disposing Then
            Debug.WriteLine("...kam von der Applikation")
            'prüfen, ob nicht schon entsorgt
            If myDisposed Then
                'Übergründlich geht nicht, dann --> Exception
                Dim up As New ObjectDisposedException("SoapSerializer")
                Throw up
            End If
        Else
            Debug.WriteLine("...kam vom Garbage Collector")
        End If


        'Nur beim Sch...reiben...
        If mySerializerMode = SoapSerializerMode.OpenForWriting Then
            '...abziehen nicht vergessen...
            myFileStream.Flush()
            Debug.WriteLine("FileStream geflushed!")
        End If
        '...und Hände waschen in jedem Fall ;-)
        myFileStream.Close()
        Debug.WriteLine("FileStream closed - Datei ist sicher!")
        mySerializerMode = SoapSerializerMode.Close

    End Sub

    Protected Overrides Sub Finalize()
        'Falls myFileStream schon durch den GC entsorgt wurde
        'könnte ein Fehler auftreten, den es abzufangen gilt
        Try
            Debug.WriteLine("Me.Finalize ruft Me.Dispose auf!")
            Dispose(False)
        Finally
            Debug.WriteLine("Base.Finalize aufrufen!")
            MyBase.Finalize()
        End Try
    End Sub

End Class
