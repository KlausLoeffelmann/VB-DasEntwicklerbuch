Public Class DataGridViewEx
    Inherits DataGridView

    'Verarbeitet Tasten, z. B. TAB, ESC, die EINGABETASTE und Pfeiltasten, 
    'die zum Steuern von Dialogfeldern verwendet werden.
    Protected Overrides Function ProcessDialogKey(ByVal keyData As Keys) As Boolean

        'Nur die Keycodes interessieren, Rest wird ausmaskiert.
        Dim key As Keys = (keyData And Keys.KeyCode)

        'Eingabe-Taste gedrückt?
        If key = Keys.Enter Then

            'Ja, dann in Cursor-rechts umleiten, wo
            'Eingabe-Taste nochmal gesondert behandelt wird.
            Return Me.ProcessRightKey(keyData)
        End If

        'Andere Keyes bleiben nicht betroffen
        Return MyBase.ProcessDialogKey(keyData)
    End Function

    'Die alte Cursor-Rechts-Funktion wird überschattet, damit die
    'Polymorphie dieser Funktion an dieser Stelle unterbrochen wird.
    Public Shadows Function ProcessRightKey(ByVal keyData As Keys) As Boolean

        'Nur die Keycodes interessieren, Rest wird ausmaskiert.
        Dim key As Keys = (keyData And Keys.KeyCode)

        'Wenn es sich um die umgeleitete Eingabe-Taste handelte...
        If key = Keys.Enter Then

            'Feststellen, ob sich der Cursor am Ende der letzten Spalte befand, ...
            If MyBase.CurrentCell.ColumnIndex = (MyBase.ColumnCount - 1) Then
                '...dann den Cursor nach vorn und eine Zeile nach unten verschieben.
                MyBase.CurrentCell = MyBase.Rows(MyBase.CurrentCell.RowIndex + 1).Cells(0)
                Return True
            End If
        End If
        'Bei allen anderen Position reicht es aus, 
        'das Standardverhalten von Cursor-rechts statt Eingabe zu verwenden.
        Return MyBase.ProcessRightKey(keyData)
    End Function

    'Verarbeitet Tasten, die zum Navigieren in der DataGridView verwendet werden.
    Protected Overrides Function ProcessDataGridViewKey(ByVal e As KeyEventArgs) As Boolean
        If e.KeyCode = Keys.Enter Then
            Return Me.ProcessRightKey(e.KeyData)
        End If
        Return MyBase.ProcessDataGridViewKey(e)
    End Function
End Class
