Imports System.Threading
Imports System.Threading.Tasks

Module Module1

    Private myThreadcount As Integer
    Private myMaxThreads As Integer

    Sub Main()

        Dim Elements As New List(Of String) From {"Peter", "Ramona", "Lisa", "Sarika", "Jürgen",
                                                  "Ruprecht", "Marcus", "Andreas", "Gabriele",
                                                  "Silja", "Uta", "Oli", "Cate", "Arnold"}

        Dim sw = Stopwatch.StartNew
        myThreadcount = 0
        Parallel.ForEach(Elements,
                         New ParallelOptions With {.MaxDegreeOfParallelism = -1},
                         Sub(item As String)
                             Dim delta = sw.ElapsedMilliseconds
                             myThreadcount += 1
                             Dim myCurrentThread = myThreadcount
                             Try
                                 Thread.CurrentThread.Name = item & "-Thread"
                             Catch ex As Exception
                                 Console.WriteLine(Thread.CurrentThread.Name & " is reused for " & item)
                             End Try
                             If myMaxThreads < myThreadcount Then
                                 myMaxThreads = myThreadcount
                             End If
                             Console.WriteLine(myCurrentThread.ToString("00. ") &
                                               "Thread for " & item & " started!")

                             'Simulate Workload.
                             Thread.SpinWait(100000000)

                             'Simulate more Threading Workload.
                             Parallel.For(0, 50, Sub(i)
                                                     Console.Write(myCurrentThread.ToString("00 "))
                                                     Thread.Sleep(i * 20)
                                                 End Sub)
                             delta = sw.ElapsedMilliseconds - delta

                             Console.WriteLine("Thread " & myCurrentThread.ToString("00") &
                                               " for " & item & _
                                               " finished after " &
                                               sw.ElapsedMilliseconds.ToString("#,##0") & "ms " &
                                           "(Duration: " & delta.ToString("#,##0") & " ms")
                             myThreadcount -= 1
                         End Sub)

        Console.WriteLine("Maximal Running Threads: " & myMaxThreads.ToString)
        Console.ReadKey()
    End Sub

End Module
