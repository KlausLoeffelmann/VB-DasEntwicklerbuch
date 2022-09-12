Option Strict Off
Option Explicit On
Module mdlMain
	
	Public Enum ContentTypeEnum
		Integer_Renamed = 0
		DateTime = 1
		String_Renamed = 2
		Error_Renamed = 3
	End Enum
	
	Public Structure ItemType
		Dim Nr As Short
		Dim Content As Object
		Dim CreatedAt As Date
	End Structure
	
	'UPGRADE_NOTE: ToString wurde aktualisiert auf ToString_Renamed. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
	Public Function ToString_Renamed(ByRef Item As ItemType) As String
		
		'UPGRADE_WARNING: Die Standardeigenschaft des Objekts Item.Content konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
		ToString_Renamed = CStr(Item.Nr) & ". " & vbTab & CStr(Item.Content) & vbTab & CStr(Item.CreatedAt)
		
	End Function
	
	'UPGRADE_NOTE: CType wurde aktualisiert auf CType_Renamed. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
	Public Function Parse(ByRef ItemText As String, ByRef CType_Renamed As ContentTypeEnum) As ItemType
		
		Dim Item() As String
		Dim itBack As ItemType
		
		Item = Split(ItemText, vbTab)
		itBack.Nr = CShort(Item(0))
		
		Select Case CType_Renamed
			
			Case ContentTypeEnum.Integer_Renamed
				'UPGRADE_WARNING: Die Standardeigenschaft des Objekts itBack.Content konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
				itBack.Content = CShort(Item(1))
				
			Case ContentTypeEnum.String_Renamed
				'UPGRADE_WARNING: Die Standardeigenschaft des Objekts itBack.Content konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
				itBack.Content = CStr(Item(1))
				
			Case ContentTypeEnum.DateTime
				'UPGRADE_WARNING: Die Standardeigenschaft des Objekts itBack.Content konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
				itBack.Content = CDate(Item(1))
				
		End Select
		
		itBack.CreatedAt = CDate(Item(2))
		
		'UPGRADE_WARNING: Die Standardeigenschaft des Objekts Parse konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
		Parse = itBack
		
	End Function
	
	Public Function GetListFromFile(ByRef Filename As String, ByRef BackType As ContentTypeEnum, Optional ByRef ShowErrorMessages As Object = Nothing) As ItemType()
		
		Dim i, ff, locAmountDataSets As Object
		Dim locItem As ItemType
		Dim locType As ContentTypeEnum
		Dim Item() As ItemType
		Dim locString As String
		Dim locShowErrors As Boolean
		
		On Error GoTo getlistfromfile_error
		
		
		'UPGRADE_NOTE: IsMissing() wurde in IsNothing() geändert. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1021"'
		If Not IsNothing(ShowErrorMessages) Then
			'UPGRADE_WARNING: Die Standardeigenschaft des Objekts ShowErrorMessages konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
			locShowErrors = CBool(ShowErrorMessages)
		Else
			locShowErrors = False
		End If
		
		'UPGRADE_WARNING: Die Standardeigenschaft des Objekts ff konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
		ff = FreeFile
		'UPGRADE_WARNING: Die Standardeigenschaft des Objekts ff konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
		FileOpen(ff, Filename, OpenMode.Input)
		'UPGRADE_WARNING: Die Standardeigenschaft des Objekts ff konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
		Input(ff, locAmountDataSets)
		'UPGRADE_WARNING: Die Standardeigenschaft des Objekts ff konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
		Input(ff, BackType)
		'UPGRADE_WARNING: Die untere Begrenzung des Arrays Item wurde von 1 in 0 geändert. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1033"'
		ReDim Item(locAmountDataSets)
		'UPGRADE_WARNING: Die Standardeigenschaft des Objekts locAmountDataSets konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
		For i = 1 To locAmountDataSets
			'UPGRADE_WARNING: Die Standardeigenschaft des Objekts ff konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
			locString = LineInput(ff)
			locItem.Nr = CShort(locString)
			
			'UPGRADE_WARNING: Die Standardeigenschaft des Objekts ff konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
			locString = LineInput(ff)
			
			Select Case BackType
				
				Case ContentTypeEnum.Integer_Renamed
					'UPGRADE_WARNING: Die Standardeigenschaft des Objekts locItem.Content konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
					locItem.Content = CShort(locString)
					
				Case ContentTypeEnum.String_Renamed
					'UPGRADE_WARNING: Die Standardeigenschaft des Objekts locItem.Content konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
					locItem.Content = CStr(locString)
					
				Case ContentTypeEnum.DateTime
					'UPGRADE_WARNING: Die Standardeigenschaft des Objekts locItem.Content konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
					locItem.Content = CDate(locString)
					
			End Select
			
			'UPGRADE_WARNING: Die Standardeigenschaft des Objekts ff konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
			locString = LineInput(ff)
			locItem.CreatedAt = CDate(locString)
			'UPGRADE_WARNING: Die Standardeigenschaft des Objekts i konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
			'UPGRADE_WARNING: Die Standardeigenschaft des Objekts Item(i) konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
			Item(i) = locItem
		Next i
		
		'UPGRADE_WARNING: Die Standardeigenschaft des Objekts ff konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
		FileClose(ff)
		GetListFromFile = VB6.CopyArray(Item)
		Exit Function
		
getlistfromfile_error: 
		
		MsgBox("Beim Laden der Datei" & vbCr & Filename & vbCr & "ist ein Fehler aufgetreten." & vbCr & "Bitte wiederholen Sie den Vorgang", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "Fehler beim Laden")
		BackType = ContentTypeEnum.Error_Renamed
		Exit Function
		
	End Function
	
	Public Function SaveListToFile(ByRef Filename As String, ByRef ItemType() As ItemType, ByRef DType As ContentTypeEnum, Optional ByRef ShowErrorMessages As Object = Nothing) As Boolean
		

End Module