Attribute VB_Name = "mdlMain"
Option Explicit
Option Base 1

Public Enum ContentTypeEnum
    [Integer] = 0
    DateTime = 1
    [String] = 2
    [Error] = 3
End Enum

Public Type ItemType
    Nr As Integer
    Content As Variant
    CreatedAt As Date
End Type

Public Function ToString(Item As ItemType) As String
    
    ToString = CStr(Item.Nr) + ". " + vbTab + CStr(Item.Content) + vbTab + CStr(Item.CreatedAt)

End Function

Public Function Parse(ItemText As String, CType As ContentTypeEnum) As ItemType

    Dim Item() As String
    Dim itBack As ItemType
    
    Item = Split(ItemText, vbTab)
    itBack.Nr = CInt(Item(0))
    
    Select Case CType
    
        Case ContentTypeEnum.Integer:
            itBack.Content = CInt(Item(1))
            
        Case ContentTypeEnum.String:
            itBack.Content = CStr(Item(1))
            
        Case ContentTypeEnum.DateTime:
            itBack.Content = CDate(Item(1))
    
    End Select
        
    itBack.CreatedAt = CDate(Item(2))
    
    Parse = itBack

End Function

Public Function GetListFromFile(Filename As String, BackType As ContentTypeEnum, Optional ShowErrorMessages As Variant) As ItemType()

    Dim ff, i, locAmountDataSets
    Dim locItem As ItemType
    Dim locType As ContentTypeEnum
    Dim locItems() As ItemType
    Dim locString As String
    Dim locShowErrors As Boolean

    On Local Error GoTo getlistfromfile_error

    If Not IsMissing(ShowErrorMessages) Then
        locShowErrors = CBool(ShowErrorMessages)
    Else
        locShowErrors = False
    End If

    ff = FreeFile
    Open Filename For Input As ff
        Input #ff, locAmountDataSets
        Input #ff, BackType
        ReDim locItems(locAmountDataSets)
        For i = 1 To locAmountDataSets
            Line Input #ff, locString
            locItem.Nr = CInt(locString)
            
            Line Input #ff, locString

            Select Case BackType

                Case ContentTypeEnum.Integer:
                    locItem.Content = CInt(locString)

                Case ContentTypeEnum.String:
                    locItem.Content = CStr(locString)

                Case ContentTypeEnum.DateTime:
                    locItem.Content = CDate(locString)

            End Select

            Line Input #ff, locString
            locItem.CreatedAt = CDate(locString)
            locItems(i) = locItem
        Next i

    Close ff
    GetListFromFile = locItems
    Exit Function
    
getlistfromfile_error:
    
    If locShowErrors Then
        MsgBox "Beim Laden der Datei" + vbCr + _
                Filename + vbCr + _
                "ist ein Fehler aufgetreten." + vbCr + _
                "Bitte wiederholen Sie den Vorgang", _
                vbOKOnly + vbExclamation, "Fehler beim Laden"
    End If
    
    BackType = ContentTypeEnum.Error
    Exit Function

End Function

Public Function SaveListToFile(Filename As String, ItemType() As ItemType, DType As ContentTypeEnum, Optional ShowErrorMessages As Variant) As Boolean

    Dim ff, i, locVar As Variant
    Dim locItem As ItemType
    Dim locType As ContentTypeEnum
    Dim locItems() As ItemType
    Dim locString As String
    Dim locShowErrors As Boolean

    On Local Error GoTo savelisttofile_error

    If Not IsMissing(ShowErrorMessages) Then
        locShowErrors = CBool(ShowErrorMessages)
    Else
        locShowErrors = False
    End If
    
    ff = FreeFile
    Open Filename For Output As ff
        Print #ff, UBound(ItemType) - LBound(ItemType)
        Print #ff, DType
        For i = LBound(ItemType) To UBound(ItemType)
            Print #ff, CStr(ItemType(i).Nr)
            Print #ff, CStr(ItemType(i).Content)
            Print #ff, CStr(ItemType(i).CreatedAt)
        Next i

    Close ff
    SaveListToFile = True
    Exit Function

savelisttofile_error:
    
    If locShowErrors Then
        MsgBox "Beim Schreiben der Datei" + vbCr + _
                Filename + vbCr + _
                "ist ein Fehler aufgetreten." + vbCr + _
                "Bitte wiederholen Sie den Vorgang", _
                vbOKOnly + vbExclamation, "Fehler beim Laden"
    End If
    Exit Function

End Function

