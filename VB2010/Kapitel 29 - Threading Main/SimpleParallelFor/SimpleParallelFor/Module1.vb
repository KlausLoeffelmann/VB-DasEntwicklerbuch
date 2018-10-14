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

        Dim ctSource As New CancellationTokenSource()
        Dim cancelToken = ctSource.Token

        Try
            Parallel.For(1, 50, New ParallelOptions With {.CancellationToken = cancelToken},
                         Sub(i)
                             myList.Add(New ItemLogEntry With {.TickTime = sw.ElapsedMilliseconds,
                                                               .value = i,
                                                               .threadid = Thread.CurrentThread.ManagedThreadId})
                             'So tun, als würde was lange dauern, aber die
                             'großen Zahlen dauern sehr viel länger:
                             Console.Write(".")
                             Thread.SpinWait(i * 200000)

                             'bei 25 ist Feierabend!
                             If i = 25 Then
                                 ctSource.Cancel()
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
