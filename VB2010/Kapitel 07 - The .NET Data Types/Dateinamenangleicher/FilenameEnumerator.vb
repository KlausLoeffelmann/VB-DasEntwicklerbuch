Imports System.IO

Public Class FilenameEnumeratorItem
    Inherits ListViewItem

    Protected myFilename As FileInfo
    Protected myEpisodeNameFilter As Boolean

    Public Sub New(ByVal Filename As FileInfo, ByVal EpisodeNameFilter As Boolean)
        MyBase.new()
        myFilename = Filename
        myEpisodeNameFilter = EpisodeNameFilter
        Me.Text = myFilename.Name
        Me.SubItems.Add(NewFilename.Name)
        Me.SubItems.Add(myFilename.Directory.FullName)
    End Sub

    Public Property Filename() As FileInfo
        Get
            Return myFilename
        End Get
        Set(ByVal Value As FileInfo)
            myFilename = Value
        End Set
    End Property

    Public Overridable ReadOnly Property NewFilename() As FileInfo
        Get
            Dim locFilename As String = myFilename.Name
            Dim locParts As New ArrayList
            Dim blnCharTypesChanged As Boolean
            Dim locChar, locPrevChar As Char
            Dim locCurrentPart As String = ""
            Dim locNumberStartPart, locNumberEndPart As Integer
            Dim locProhibitFurtherCharTypeChanges As Boolean

            Dim locPräfix, locNumPart, locPostfix As String

            If Not myEpisodeNameFilter Then
                Return myFilename
            End If

            'Finden des Nummern-Parts und Ersetzen aller Unterstriche
            'durch Leerzeichen
            For count As Integer = 0 To locFilename.Length - 1
                locChar = locFilename.Chars(count)
                If locChar = "_"c Then locChar = " "c

                'Den Nummernpart des Dateinamens suchen
                If Not locProhibitFurtherCharTypeChanges Then
                    If Char.IsDigit(locChar) And Not blnCharTypesChanged Then
                        blnCharTypesChanged = True
                        'Falls "S" oder "s" davor stand, Buchstaben mit einbeziehen
                        If locPrevChar = "S"c Or locPrevChar = "s"c Then
                            locNumberStartPart = count - 1
                        Else
                            locNumberStartPart = count
                        End If
                    End If
                End If


                If Not locProhibitFurtherCharTypeChanges Then
                    'Wenn Nummernpart schon vorbei, und wieder ein Buchstabe...
                    If Char.IsLetter(locChar) And blnCharTypesChanged Then
                        If count < locFilename.Length - 2 Then
                            Dim locNextChar As Char = locFilename.Chars(count + 1)
                            '...aber nur wenn der Buchstabe kein Episodenkennzeichner ist...
                            If Not ((Char.IsLetter(locChar) And Char.IsDigit(locNextChar)) And _
                                (locChar = "E"c Or locChar = "e"c Or locChar = "x" Or locChar = "X")) Then
                                '...ist der Nummernpart vorbei und es folgt wieder Text
                                locNumberEndPart = count
                                locProhibitFurtherCharTypeChanges = True
                            End If
                        End If
                    End If
                End If
                locCurrentPart += locChar.ToString
                locPrevChar = locChar
            Next

            'Sonderfall: Dateiname endet mit Nummer
            If locNumberEndPart = 0 Then
                locNumberEndPart = locFilename.Length
            End If

            'Dateinamen auseinander bauen
            locPräfix = locCurrentPart.Substring(0, locNumberStartPart)
            locNumPart = locCurrentPart.Substring(locNumberStartPart, locNumberEndPart - locNumberStartPart)
            locPostfix = locCurrentPart.Substring(locNumberEndPart)

            'Alle denkbaren "Umbauten" im Dateinamen durchführen
            locPräfix = locPräfix.Replace("."c, " "c)
            locPräfix = locPräfix.Trim(New Char() {" "c, "-"c})
            locNumPart = locNumPart.Replace("."c, "")
            locNumPart = locNumPart.Replace("S"c, "")
            locNumPart = locNumPart.Replace("s"c, "")
            locNumPart = locNumPart.Replace("E"c, "x"c)
            locNumPart = locNumPart.Replace("e"c, "x"c)
            locNumPart = locNumPart.Replace("X"c, "x"c)
            locNumPart = locNumPart.Trim(New Char() {" "c, "-"c})
            locPostfix = locPostfix.Trim(New Char() {" "c, "-"c})

            'Und neuen Dateinamen zurückliefern
            Return New FileInfo(Filename.DirectoryName + "\" + locPräfix + " - " + locNumPart + " - " + locPostfix)
        End Get
    End Property

End Class

Public Class FilenameEnumerator
    Inherits ListView

    Protected myDirectory As DirectoryInfo
    Protected myEpisodeNameFilter As Boolean

    Public Sub New()
        MyBase.New()
        InitializeControl()
    End Sub

    Private Sub InitializeControl()
        Me.CheckBoxes = True
        Me.GridLines = True
        Me.View = System.Windows.Forms.View.Details
        Me.EpisodeNameFilter = True

        With Me.Columns
            .Add("Dateiname", -2, HorizontalAlignment.Left)
            .Add("Neuer Name", -2, HorizontalAlignment.Left)
            .Add("Pfad:", -2, HorizontalAlignment.Left)
        End With
    End Sub

    Protected Overridable Sub BuildItems()

        Items.Clear()
        If Directory Is Nothing Then
            Return
        End If

        'Keine Dateien im Designmode erzeugen,
        'damit kommt der Designer schlecht klar!
        If Me.DesignMode = True Then
            Exit Sub
        End If

        For Each locFI As FileInfo In Directory.GetFiles()
            Items.Add(New FilenameEnumeratorItem(locFI, EpisodeNameFilter))
        Next

    End Sub

    Public Property Directory() As DirectoryInfo
        Get
            Return myDirectory
        End Get
        Set(ByVal Value As DirectoryInfo)
            myDirectory = Value
            BuildItems()
            CheckAll()
        End Set
    End Property

    Public Overridable Sub CheckAll()
        For Each locFEI As FilenameEnumeratorItem In Items
            locFEI.Checked = True
        Next
    End Sub

    Public Overridable Sub UncheckAll()
        For Each locFEI As FilenameEnumeratorItem In Items
            locFEI.Checked = False
        Next
    End Sub

    Public Property EpisodeNameFilter() As Boolean
        Get
            Return myEpisodeNameFilter
        End Get
        Set(ByVal Value As Boolean)
            myEpisodeNameFilter = Value
            BuildItems()
            CheckAll()
        End Set
    End Property

End Class