Imports System.Threading
Imports System.Threading.Tasks

Public Class frmSingleThreading

    Private Sub btnZählenStarten_Click(ByVal sender As System.Object,
                                       ByVal e As System.EventArgs) Handles btnZählenStarten.Click

        Dim sw = Stopwatch.StartNew

        Dim PrimesFound = 0
        Dim lastPrimeBefore = Integer.Parse(LastPrimeBeforeTextBox.Text)
        Dim globalCount As Integer

        'Das ganze auf nem neuen Task ablaufen lassen,
        'damit die UI nicht blockierend wird,
        'und Invoke direkt ausgeführt werden kann.

        Dim ctSource As New CancellationTokenSource()
        Dim cancelToken = ctSource.Token
        Dim primesToFInd = CInt(PrimesToFindUpDown.Value)

        Dim wTask = Task.Factory.StartNew(
            Sub()
                Do

                    Try
                        'Wir brauchen CancellationToken zum Abbrechen aller
                        'laufenden Schleifenblöcke, falls wir alle Primes haben UND
                        'legen die maximale Anzahl an parallel laufenden Schleifenblöcken
                        'fest, damit nicht zu viele Primes über das Ziel hinaus berechnet werden.
                        'Bei mehr Cores kann dieser Wert erhöht werden - die Wahrscheinlichkeit
                        'steigt dann aber auch, dass wir mehr Primes berechnen, als notwendig ist.
                        Parallel.For(0, lastPrimeBefore,
                        New ParallelOptions() With
                             {.MaxDegreeOfParallelism = 8,
                              .CancellationToken = cancelToken},
                         Sub(primeCount)

                             Dim numberToTest As Integer

                             'Der folgende Block ist ein kritischer Bereich.
                             'Mit SyncLock können die Threads nur nacheinander hier hinein.
                             'Auf diese Weise zählt jeder parallel laufende Schleifenkörper
                             'globalCount herauf und damit kann Schleifenkörper 1 zum Beispiel den
                             'Wert 1, der nächste den Wert 2, der nächste den Wert 3 etc. verarbeiten 
                             'unabhängig davon, was der Wert der eigentlichen Zählvariablen ist.
                             SyncLock Me
                                 globalCount += 1
                                 numberToTest = lastPrimeBefore - globalCount
                                 'Debug.Print(Thread.CurrentThread.ManagedThreadId.ToString("000: ") &
                                 '            globalCount.ToString)
                             End SyncLock

                             'Erstmal annehmen: die Zahl ist Prime.
                             Dim isPrime = True

                             'InfoLabel.Invoke(Sub()
                             '                     InfoLabel.Text = "Teste: " & numberToTest.ToString("#,##0")
                             '                 End Sub)

                             'Es gibt natürlich schnellere Primzahlen-Algorithmen,
                             'aber hier zum Testen SOLL es ja lange dauern! ;-)
                             For valueToTest = 2 To numberToTest - 1
                                 If (numberToTest / valueToTest) = (numberToTest \ valueToTest) Then
                                     'Doch nicht Prime,
                                     isPrime = False
                                     'verwerfen.
                                     Exit For
                                 End If
                             Next

                             'Alle laufenden Schleifenblöcke beenden,
                             'wenn die gewünschte Anzahl an Primes gefunden wurde.
                             'Kann aber dennoch sein, dass schon mehr als gewünscht
                             'berechnet wurden - dann ist das eben so.
                             If PrimesFound > primesToFInd Then
                                 ctSource.Cancel()
                             End If

                             'Prime gefunden --> in die ListBox
                             If isPrime Then
                                 PrimesListBox.Invoke(Sub()
                                                          PrimesListBox.Items.Add(numberToTest.ToString("#,##0"))
                                                      End Sub)

                                 PrimesFound += 1
                             End If
                         End Sub)
                    Catch ex As OperationCanceledException
                        Debug.Print("Exited For!")
                    End Try
                Loop Until PrimesFound > primesToFInd

                sw.Stop()
                InfoLabel.Invoke(Sub()
                                     InfoLabel.Text = "Dauer in Millisekunden: " & sw.ElapsedMilliseconds.ToString("#,##0")
                                 End Sub)

            End Sub)
    End Sub
End Class
