Imports System.Threading
Imports System.Threading.Tasks

Module Module1

    Private myThreadCount As Integer
    Private myList As System.Collections.Concurrent.ConcurrentBag(Of ItemLogEntry)

    Sub Main()

        CancelableVersion()
        Return

        myList = New System.Collections.Concurrent.ConcurrentBag(Of ItemLogEntry)
        Dim sw = Stopwatch.StartNew

        Parallel.For(1, 50, Sub(i)
                                myList.Add(New ItemLogEntry With {.TickTime = sw.ElapsedMilliseconds,
                                                                  .value = i,
                                                                  .threadid = Thread.CurrentThread.ManagedThreadId})
                                'So tun, als würde was lange dauern, aber die
                                'großen Zahlen dauern sehr viel länger:
                                Console.Write(".")
                                Thread.SpinWait(i * 200000)
                            End Sub)
        Console.WriteLine()
        Console.WriteLine("Nach Thread-ID sortiert:")
        Dim sortedById = From item In myList
                     Order By item.ThreadId, item.TickTime

        sortedById.ToList.ForEach(Sub(item)
                                      Console.WriteLine(item.ToString)
                                  End Sub)
        Console.WriteLine("Return")
        Console.ReadLine()

        Console.WriteLine()
        Console.WriteLine("Nach Dauer sortiert:")
        Dim sortedByTime = From item In myList
                     Order By item.TickTime

        sortedByTime.ToList.ForEach(Sub(item)
                                        Console.WriteLine(item.ToString)
                                    End Sub)
        Console.WriteLine("Return")
        Console.ReadLine()

    End Sub

    Public Structure ItemLogEntry
        Public TickTime As Long
        Public ThreadId As Long
        Public Value As Integer

        Public Overrides Function ToString() As String
            Return String.Format("ThreadId {0:0000}: @{1:000000} ms - Value:{2:000000}",
                                 ThreadId, TickTime, Value)
        End Function
    End Structure

    Sub CancelableVersion()

        myList = New System.Collections.Concurrent.ConcurrentBag(Of ItemLogEntry)
        Dim sw = Stopwatch.StartNew

        Try
            Parallel.For(1, 100,
                         Sub(i, parLoopState)
                             myList.Add(New ItemLogEntry With {.TickTime = sw.ElapsedMilliseconds,
                                                               .value = i,
                                                               .threadid = Thread.CurrentThread.ManagedThreadId})
                             'So tun, als würde was lange dauern, aber die
                             'großen Zahlen dauern sehr viel länger:
                             Console.Write(".")
                             Thread.SpinWait(i * 200000)

                             'bei 25 ist Feierabend!
                             If i = 25 Then
                                 Console.WriteLine("25 erreicht!")
                                 'Bis 25 werden auf jedenfall alle parallel laufende
                                 'Schleifen ausgeführt, vielleicht natürlich mehr,
                                 'wenn ein höherer Bereich schon parallel gestartet wurde.
                                 'Bis 25 sind aber alle Werte mit dabei.
                                 parLoopState.Break()
                                 'Würden Sie Stop() verwenden, könnte es sein, dass
                                 'der Bereich von 20-40 von einem und der von 
                                 '0-20 von einem anderen Task verarbeitet wurde.
                                 'Erreicht Task 2 die 25 und verwendet Stop,
                                 'ist Task 1 mit dem Zählen *BIS* 20 vielleicht
                                 'noch gar nicht fertig. Dann ist bei 25 auch
                                 'Feierabend, aber es fehlen vielleicht Werte.
                             End If
                         End Sub)
        Catch ex As Exception
            Console.WriteLine("Exited For!")
        End Try

        Console.WriteLine()
        Console.WriteLine("Nach Thread-ID sortiert:")
        Dim sortedById = From item In myList
                     Order By item.ThreadId, item.TickTime

        sortedById.ToList.ForEach(Sub(item)
                                      Console.WriteLine(item.ToString)
                                  End Sub)
        Console.WriteLine("Return")
        Console.ReadLine()

        Console.WriteLine()
        Console.WriteLine("Nach Dauer sortiert:")
        Dim sortedByTime = From item In myList
                     Order By item.TickTime

        sortedByTime.ToList.ForEach(Sub(item)
                                        Console.WriteLine(item.ToString)
                                    End Sub)
        Console.WriteLine("Return")
        Console.ReadLine()

    End Sub



End Module
