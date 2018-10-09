Imports System.Threading
Imports System.Threading.Tasks

Module Module1

    Sub Main()

        Const SPINVALUE = 20000000

        Dim innerIndex As Integer
        Dim outerIndex As Integer

        For i = 0 To 3
            innerIndex = 0
            For j = 0 To 3
                Thread.SpinWait(SPINVALUE)
                Console.WriteLine("iIndex:{0} ;oIndex:{1}",
                          innerIndex, outerIndex)
                innerIndex += 1
            Next
            outerIndex += 1
        Next
        Console.WriteLine("- - - - - - - - - - - - -")

        innerIndex = 0
        outerIndex = 0

        Parallel.For(0, 4,
                     Sub(i)
                         innerIndex = 0
                         Parallel.For(0, 4,
                                      Sub(j)
                                          Thread.SpinWait(SPINVALUE)
                                          Console.WriteLine("iIndex:{0} ;oIndex:{1}",
                                                    innerIndex, outerIndex)
                                          innerIndex += 1
                                      End Sub)
                         outerIndex += 1
                     End Sub)
        Console.ReadKey()

        innerIndex = 0
        outerIndex = 0

        Parallel.For(0, 4,
                     Sub(i)
                         innerIndex = 0
                         Parallel.For(0, 4,
                                      Sub(j)
                                          Dim outerIndexTemp = outerIndex
                                          Thread.SpinWait(SPINVALUE)
                                          Console.WriteLine("iIndex:{0} ;oIndex:{1}",
                                                    innerIndex, outerIndexTemp)
                                          innerIndex += 1
                                      End Sub)
                         outerIndex += 1
                     End Sub)
        Console.ReadKey()

    End Sub

End Module
