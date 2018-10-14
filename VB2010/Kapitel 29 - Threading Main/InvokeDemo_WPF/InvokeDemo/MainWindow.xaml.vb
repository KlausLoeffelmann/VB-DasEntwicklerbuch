Imports System.Threading.Tasks

Class MainWindow

    Private Sub StartCalculationButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)

        Dim sw = Stopwatch.StartNew

        'Für die Threading-Version holen wir uns
        'den Wert des Steuerelements noch im UI-Thread,
        'dann brauchen wir später nicht zu deligieren.
        Try
            Dim primesToFind = CInt(PrimesToFindTextBox.Text)
            Dim LastPrimeBefore = Integer.Parse(LastPrimeBeforeTextBox.Text)

            Dim PrimesFound = 0
            Dim calcPrimesTask =
                Task.Factory.StartNew(
                    Sub()
                        For numberToTest = LastPrimeBefore To 1 Step -1
                            Dim isPrime = True

                            Dim labelUpdaterDel = Sub(numToTest As Integer)
                                                      InfoLabel.Text = "Teste: " & numToTest.ToString("#,##0")
                                                  End Sub

                            If InfoLabel.Dispatcher.CheckAccess() Then
                                labelUpdaterDel(numberToTest)
                            Else
                                InfoLabel.Dispatcher.Invoke(labelUpdaterDel, numberToTest)
                            End If

                            For valueToTest = 2 To numberToTest - 1
                                If (numberToTest / valueToTest) = (numberToTest \ valueToTest) Then
                                    isPrime = False
                                    Exit For
                                End If
                            Next
                            If isPrime Then

                                Dim listBoxUpdater = Sub(numToTest As Integer)
                                                         PrimesListBox.Items.Add(numToTest.ToString("#,##0"))
                                                     End Sub

                                If PrimesListBox.Dispatcher.CheckAccess() Then
                                    listBoxUpdater(numberToTest)
                                Else
                                    PrimesListBox.Dispatcher.Invoke(listBoxUpdater, numberToTest)
                                End If

                                PrimesFound += 1
                                If PrimesFound = primesToFind Then
                                    Exit For
                                End If
                            End If
                        Next

                        sw.Stop()
                        'Hier machen wir's jetzt direkt, ohne nachzufragen:
                        InfoLabel.Dispatcher.Invoke(
                            Sub()
                                InfoLabel.Text = "Dauer in Millisekunden: " &
                                    sw.ElapsedMilliseconds.ToString("#,##0")
                            End Sub)
                    End Sub)
        Catch
        End Try
    End Sub
End Class
