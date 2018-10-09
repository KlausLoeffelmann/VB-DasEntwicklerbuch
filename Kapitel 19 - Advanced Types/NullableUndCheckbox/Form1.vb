Public Class Form1

    Private myCheckBoxZustand As Boolean?

    'Das ginge auch:
    'Private myCheckBoxZustand? As Boolean

    'Und das auch:
    'Private myCheckBoxZustand As Nullable(Of Boolean)

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub

    Private Sub btnSpeichern_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSpeichern.Click
        If chkDemo.CheckState = CheckState.Indeterminate Then
            myCheckBoxZustand = Nothing
        Else
            myCheckBoxZustand = chkDemo.Checked
        End If
    End Sub

    Private Sub btnWiederherstellen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWiederherstellen.Click
        If Not myCheckBoxZustand.HasValue Then
            chkDemo.CheckState = CheckState.Indeterminate
        Else
            If myCheckBoxZustand.Value Then
                chkDemo.CheckState = CheckState.Checked
            Else
                chkDemo.CheckState = CheckState.Unchecked
            End If
        End If
    End Sub

    Public Sub BeCarefulWithNullableBooleanExpressions()

        Dim regularBoolean As Boolean = False
        If regularBoolean Then
            'In diesem Fall ist, wenn der Wert nicht wahr ist, ...
            'In this case, if value is not true ...
            Console.WriteLine("Wert ist wahr!")
        Else
            '... er notwendigerweise falsch.
            'value is necessarily false.
            Console.WriteLine("Wert ist falsch!")
        End If


        'Jetzt ist der Wert ein nullable-boolean, und kann auch Nothing sein.
        'Now, Value can be nullable boolean und therefore be nothing.
        Dim booleanNullable As Boolean? = Nothing

        If booleanNullable Then
            'Wenn also der Wert nicht wahr ist ...
            'So, if the value is not true, ...
            MessageBox.Show("Wert ist wahr!")
        Else
            '...dann muss er NICHT notwendigerweise falsch sein!
            'it doesn't need to be necessarily false!
            MessageBox.Show("Wert ist nicht unbedingt falsch!")
            If Not booleanNullable Then
                'Nur hier wissen wir, dass er falsch war.
                'Only here we know, it's false!
                MessageBox.Show("Wert ist mit Sicherheit falsch!")
            End If
        End If
    End Sub
End Class
