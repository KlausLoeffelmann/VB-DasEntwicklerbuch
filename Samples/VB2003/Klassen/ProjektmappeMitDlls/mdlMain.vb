Imports 

Module mdlMain

    Sub Main()
        'So geht es nicht, da unvollst�ndige Referenz:
        'Dim myClass1 As New Class1(5)
        Dim myClass1 As New MeineDll.Class1(5)


    End Sub

End Module
