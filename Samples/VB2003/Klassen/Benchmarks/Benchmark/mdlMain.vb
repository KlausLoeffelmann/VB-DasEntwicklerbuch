Option Explicit On 
Option Strict On

Imports VBElements
Imports CPPElements
Imports CSElements
Imports JSElements
Imports ActiveDev

Module mdlMain

    Const cAmountElements As Integer = 500000

    Sub Main()

        Dim locTimeGauge As New HighSpeedTimeGauge
        Dim locVBIntElements As VBIntElements
        Dim locVBStrElements As VBStrElements
        Dim locCPPIntElements As CPPIntElements
        Dim locCPPStrElements As CPPStrElements
        Dim locCSIntElements As CSIntElements
        Dim locCSStrElements As CSStrElements
        Dim locJSIntElements As JSIntElements
        Dim locJSStrElements As JSStrElements

        Console.WriteLine("Return drücken zum Beginnen der Benchmarks...")
        Console.ReadLine()

        'C++ - Integer-Elemente
        Console.WriteLine("Erzeugen von " & cAmountElements & " Integerelementen mit C++ - Klasse...")
        locTimeGauge.Start()
        locCPPIntElements = New CPPIntElements(cAmountElements)
        locTimeGauge.Stop()
        Console.WriteLine("Dauer: " & locTimeGauge.ToString())
        locTimeGauge.Reset()
        Console.WriteLine()
        Console.WriteLine("Sortieren von " & cAmountElements & " Integerelementen; C++ - Shell Sort...")
        locTimeGauge.Start()
        locCPPIntElements.ShellSort()
        locTimeGauge.Stop()
        Console.WriteLine("Dauer: " & locTimeGauge.ToString())

        'C++ - String-Elemente
        Console.WriteLine()
        Console.WriteLine("Erzeugen von " & cAmountElements & " Stringelementen mit C++ - Klasse...")
        locTimeGauge.Start()
        locCPPStrElements = New CPPStrElements(cAmountElements)
        locTimeGauge.Stop()
        Console.WriteLine("Dauer: " & locTimeGauge.ToString())
        locTimeGauge.Reset()
        Console.WriteLine()
        Console.WriteLine("Sortieren von " & cAmountElements & " Stringelementen; C++ - Shell Sort...")
        locTimeGauge.Start()
        locCPPStrElements.ShellSort()
        locTimeGauge.Stop()
        Console.WriteLine("Dauer: " & locTimeGauge.ToString())
        Console.WriteLine()

        'Visual Basic - Integer-Elemente
        Console.WriteLine("Erzeugen von " & cAmountElements & " Integerelementen mit Visual-Basic-Klasse...")
        locTimeGauge.Start()
        locVBIntElements = New VBIntElements(cAmountElements)
        locTimeGauge.Stop()
        Console.WriteLine("Dauer: " & locTimeGauge.ToString())
        locTimeGauge.Reset()
        Console.WriteLine()
        Console.WriteLine("Sortieren von " & cAmountElements & " Integerelementen; Visual-Basic-Shell-Sort...")
        locTimeGauge.Start()
        locVBIntElements.ShellSort()
        locTimeGauge.Stop()
        Console.WriteLine("Dauer: " & locTimeGauge.ToString())

        'Visual Basic - String elemente
        Console.WriteLine()
        Console.WriteLine("Erzeugen von " & cAmountElements & " Stringelementen mit Visual-Basic-Klasse...")
        locTimeGauge.Start()
        locVBStrElements = New VBStrElements(cAmountElements)
        locTimeGauge.Stop()
        Console.WriteLine("Dauer: " & locTimeGauge.ToString())
        locTimeGauge.Reset()
        Console.WriteLine()
        Console.WriteLine("Sortieren von " & cAmountElements & " Stringelementen; Visual-Basic-Shell-Sort...")
        locTimeGauge.Start()
        locVBStrElements.ShellSort()
        locTimeGauge.Stop()
        Console.WriteLine("Dauer: " & locTimeGauge.ToString())
        Console.WriteLine()

        'J# - Integer-Elemente
        Console.WriteLine("Erzeugen von " & cAmountElements & " Integerelementen mit J# - Klasse...")
        locTimeGauge.Start()
        locJSIntElements = New JSIntElements(cAmountElements)
        locTimeGauge.Stop()
        Console.WriteLine("Dauer: " & locTimeGauge.ToString())
        locTimeGauge.Reset()
        Console.WriteLine()
        Console.WriteLine("Sortieren von " & cAmountElements & " Integerelementen; J# - Shell Sort...")
        locTimeGauge.Start()
        locJSIntElements.ShellSort()
        locTimeGauge.Stop()
        Console.WriteLine("Dauer: " & locTimeGauge.ToString())

        'J# - String-Elemente
        Console.WriteLine()
        Console.WriteLine("Erzeugen von " & cAmountElements & " Stringelementen mit J# - Klasse...")
        locTimeGauge.Start()
        locJSStrElements = New JSStrElements(cAmountElements)
        locTimeGauge.Stop()
        Console.WriteLine("Dauer: " & locTimeGauge.ToString())
        locTimeGauge.Reset()
        Console.WriteLine()
        Console.WriteLine("Sortieren von " & cAmountElements & " Stringelementen; J# - Shell Sort...")
        locTimeGauge.Start()
        locJSStrElements.ShellSort()
        locTimeGauge.Stop()
        Console.WriteLine("Dauer: " & locTimeGauge.ToString())

        'C# - Integer-Elemente
        Console.WriteLine("Erzeugen von " & cAmountElements & " Integerelementen mit C# - Klasse...")
        locTimeGauge.Start()
        locCSIntElements = New CSIntElements(cAmountElements)
        locTimeGauge.Stop()
        Console.WriteLine("Dauer: " & locTimeGauge.ToString())
        locTimeGauge.Reset()
        Console.WriteLine()
        Console.WriteLine("Sortieren von " & cAmountElements & " Integerelementen; C# - Shell Sort...")
        locTimeGauge.Start()
        locCSIntElements.ShellSort()
        locTimeGauge.Stop()
        Console.WriteLine("Dauer: " & locTimeGauge.ToString())

        'C# - String-Elemente
        Console.WriteLine()
        Console.WriteLine("Erzeugen von " & cAmountElements & " Stringelementen mit C# - Klasse...")
        locTimeGauge.Start()
        locCSStrElements = New CSStrElements(cAmountElements)
        locTimeGauge.Stop()
        Console.WriteLine("Dauer: " & locTimeGauge.ToString())
        locTimeGauge.Reset()
        Console.WriteLine()
        Console.WriteLine("Sortieren von " & cAmountElements & " Stringelementen; C# - Shell Sort...")
        locTimeGauge.Start()
        locCSStrElements.ShellSort()
        locTimeGauge.Stop()
        Console.WriteLine("Dauer: " & locTimeGauge.ToString())

        'Damit der Bildschirm nicht verschwindet
        Console.WriteLine()
        Console.WriteLine("Return drücken zum Beenden des Programms...")
        Console.ReadLine()

    End Sub

End Module
