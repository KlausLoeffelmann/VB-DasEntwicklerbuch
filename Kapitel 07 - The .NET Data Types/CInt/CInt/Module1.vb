Module Module1

    Private Const ELEMENTCOUNT As Integer = 100000000

    Sub Main()

        'Random-Values
        Dim values(ELEMENTCOUNT) As Double
        Dim intValues(values.Length) As Integer
        Dim r = New Random(Now.Millisecond)

        For c = 0 To ELEMENTCOUNT - 1
            'Random values bewtween 0 and 100000
            values(ELEMENTCOUNT) = r.NextDouble() * 100000
        Next

        Dim sw = Stopwatch.StartNew
        For c = 0 To values.Length - 1
            'intValues(c) = CInt(Int((values(c))))
            'intValues(c) = CIntEmu.IntConvert.CsCInt(values(c))
        Next
        sw.Stop()
        Console.WriteLine(sw.ElapsedMilliseconds.ToString)
        Console.ReadLine()
    End Sub

End Module

'Namespace CIntEmu
'{
'    Public Static Class IntConvert
'    {
'        public static int CsCInt(double value)
'        {
'            return (int)value;
'        }
'    }
'}
