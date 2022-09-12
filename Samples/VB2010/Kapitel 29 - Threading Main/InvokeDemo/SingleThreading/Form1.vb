Imports System.Threading.Tasks

Public Class frmSingleThreading

    Private Sub StartCalculationButton_Click(ByVal sender As System.Object,
                                       ByVal e As System.EventArgs) Handles StartCalculationButton.Click

        Dim sw = Stopwatch.StartNew

        'Für die Threading-Version holen wir uns
        'den Wert des Steuerelements noch im UI-Thread,
        'dann brauchen wir später nicht zu deligieren.
        Dim primesToFind = PrimesToFindUpDown.Value
        Dim StartNumber = Integer.Parse(LastPrimeBeforeTextBox.Text)
        Dim leadingZeros = StartNumber.ToString.Length

        Dim PrimesFound = 0
        Dim calcPrimesTask =
            Task.Factory.StartNew(
                Sub()
                    For numberToTest = StartNumber To 2 Step -1
                        Dim isPrime = True

                        Dim labelUpdaterDel = Sub(numToTest As Integer)
                                                  InfoLabel.Text = "Teste: " & numToTest.ToString("#,##0")
                                                  InfoLabel.Refresh()
                                              End Sub

                        If Not InfoLabel.InvokeRequired Then
                            labelUpdaterDel(numberToTest)
                        Else
                            InfoLabel.Invoke(labelUpdaterDel, {numberToTest})
                        End If

                        For valueToTest = 2 To numberToTest - 1
                            If (numberToTest / valueToTest) = (numberToTest \ valueToTest) Then
                                isPrime = False
                                Exit For
                            End If
                        Next
                        If isPrime Then

                            Dim listBoxUpdater = Sub(numToTest As Integer)
                                                     PrimesListBox.Items.Add(numToTest.ToString(New String("0"c, leadingZeros)))
                                                     PrimesListBox.Refresh()
                                                 End Sub

                            If Not PrimesListBox.InvokeRequired Then
                                listBoxUpdater(numberToTest)
                            Else
                                PrimesListBox.Invoke(listBoxUpdater, {numberToTest})
                            End If

                            PrimesFound += 1
                            If PrimesFound = primesToFind Then
                                Exit For
                            End If
                        End If
                    Next

                    sw.Stop()
                    'Hier machen wir's jetzt direkt, ohne nachzufragen:
                    InfoLabel.Invoke(
                        Sub()
                            InfoLabel.Text = "Dauer in Millisekunden: " &
                                sw.ElapsedMilliseconds.ToString("#,##0")
                        End Sub)
                End Sub)
    End Sub
End Class
