Imports System.Threading
Imports System.Threading.Tasks

Module Module1

    Private myThreadCount As Integer
    Private myList As System.Collections.Concurrent.ConcurrentBag(Of ItemLogEntry(Of String))

    Sub Main()

        CancelableVersion()
        'Return

        Dim Elements As New List(Of String) From {"Peter", "Ramona", "Lisa", "Sarika", "Jürgen",
                                          "Ruprecht", "Marcus", "Andreas", "Gabriele",
                                          "Silja", "Uta", "Oli", "Cate", "Arnold"}

        myList = New System.Collections.Concurrent.ConcurrentBag(Of ItemLogEntry(Of String))
        Dim sw = Stopwatch.StartNew
        Dim iterator As Integer
        Parallel.ForEach(Elements,
                         Sub(element As String)
                             iterator += 1
                             myList.Add(New ItemLogEntry(Of String)() With {.TickTime = sw.ElapsedMilliseconds,
                                                               .value = element,
                                                               .threadid = Thread.CurrentThread.ManagedThreadId})

                             'So tun, als würde was lange dauern, und je
                             'mehr Elemente da sind, desto länger dauert es.
                             Console.Write(".")
                             Thread.SpinWait(iterator * 2000000)
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

    Public Structure ItemLogEntry(Of vType)
        Public TickTime As Long
        Public ThreadId As Long
        Public Value As vType

        Public Overrides Function ToString() As String
            Return String.Format("ThreadId {0:0000}: @{1:000000} ms - Value:{2}",
                                 ThreadId, TickTime, Value)
        End Function
    End Structure

    Sub CancelableVersion()
        Dim Elements As New List(Of String) From {"Peter", "Ramona", "Lisa", "Sarika", "Jürgen",
                                          "Ruprecht", "Marcus", "Andreas", "Gabriele",
                                          "Silja", "Uta", "Oli", "Cate", "Arnold"}

        myList = New System.Collections.Concurrent.ConcurrentBag(Of ItemLogEntry(Of String))
        Dim sw = Stopwatch.StartNew
        Dim iterator As Integer

        Try
            Parallel.ForEach(Elements,
                    Sub(element As String, parLoopState As ParallelLoopState)
                        iterator += 1
                        myList.Add(New ItemLogEntry(Of String)() With {.TickTime = sw.ElapsedMilliseconds,
                                                          .value = element,
                                                          .threadid = Thread.CurrentThread.ManagedThreadId})

                        If element = "Jürgen" Then
                            'Stop bricht 
                            'alle laufenden
                            'Schleifenabschnitte ab.
                            parLoopState.Stop()
                        End If

                        'So tun, als würde was lange dauern, und je
                        'mehr Elemente da sind, desto länger dauert es.
                        Console.Write(".")
                        Thread.SpinWait(iterator * 2000000)
                    End Sub)
        Catch ex As OperationCanceledException
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
