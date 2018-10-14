Public NotInheritable Class DateCalcHelper

    ''' <summary>
    ''' Errechnet das Datum, das dem 1. des Monats entspricht, 
    ''' der sich aus dem angegebenen Datum ergibt.
    ''' </summary>
    ''' <param name="CurrentDate">Datum, dessen Monat für die Berechnung zugrunde gelegt wird.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FirstDayOfMonth(ByVal CurrentDate As Date) As Date
        Return New Date(CurrentDate.Year, CurrentDate.Month, 1)
    End Function

    ''' <summary>
    ''' Errechnet das Datum, das dem Letzen des Monats entspricht, 
    ''' der sich aus dem angegebenen Datum ergibt.
    ''' </summary>
    ''' <param name="CurrentDate">Datum, dessen Monat für die Berechnung zugrunde gelegt wird.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LastDayOfMonth(ByVal CurrentDate As Date) As Date
        Return New Date(CurrentDate.Year, CurrentDate.Month, 1).AddMonths(1).AddDays(-1)
    End Function

    ''' <summary>
    ''' Errechnet das Datum, das dem 1. des Jahres entspricht, 
    ''' das sich aus dem angegebenen Datum ergibt.
    ''' </summary>
    ''' <param name="CurrentDate">Datum, dessen Jahr für die Berechnung zugrunde gelegt wird.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FirstOfYear(ByVal CurrentDate As Date) As Date
        Return New Date(CurrentDate.Year, 1, 1)
    End Function

    ''' <summary>
    ''' Errechnet das Datum, das dem ersten Montag der ersten Woche des Monats entspricht, 
    ''' der sich aus dem angegebenen Datum ergibt.
    ''' </summary>
    ''' <param name="CurrentDate">Datum, dessen Woche für die Berechnung zugrunde gelegt wird.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function MondayOfFirstWeekOfMonth(ByVal CurrentDate As Date) As Date
        Dim locDate As Date = FirstDayOfMonth(CurrentDate)
        If Weekday(locDate) = DayOfWeek.Monday Then
            Return locDate
        End If
        Return locDate.AddDays(6 - Weekday(CurrentDate))
    End Function

    ''' <summary>
    ''' Errechnet das Datum, das dem Montag Woche entspricht, 
    ''' die sich aus dem angegebenen Datum ergibt.
    ''' </summary>
    ''' <param name="CurrentDate">Datum, dessen Woche für die Berechnung zugrunde gelegt wird.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function MondayOfWeek(ByVal CurrentDate As Date) As Date
        If Weekday(CurrentDate) = DayOfWeek.Monday Then
            Return CurrentDate
        Else
            Return CurrentDate.AddDays(-Weekday(CurrentDate) + 1)
        End If
    End Function

    ''' <summary>
    ''' Errechnet das Datum, das dem ersten Montag der zweiten Woche des Monats entspricht, 
    ''' der sich aus dem angegebenen Datum ergibt.
    ''' </summary>
    ''' <param name="CurrentDate">Datum, dessen Woche für die Berechnung zugrunde gelegt wird.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function MondayOfSecondWeekOfMonth(ByVal currentDate As Date) As Date
        Return MondayOfFirstWeekOfMonth(currentDate).AddDays(7)
    End Function

    ''' <summary>
    ''' Errechnet das Datum, das dem ersten Montag der letzten Woche des Monats entspricht, 
    ''' der sich aus dem angegebenen Datum ergibt.
    ''' </summary>
    ''' <param name="CurrentDate">Datum, dessen Woche für die Berechnung zugrunde gelegt wird.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function MondayOfLastWeekOfMonth(ByVal CurrentDate As Date) As Date
        Dim locDate As Date = FirstDayOfMonth(CurrentDate).AddDays(-1)
        If Weekday(locDate) = DayOfWeek.Monday Then
            Return locDate
        End If
        Return locDate.AddDays(-Weekday(CurrentDate) + 1)
    End Function

    ''' <summary>
    ''' Ergibt das Datum des nächsten Arbeitstages.
    ''' </summary>
    ''' <param name="CurrentDate">Datum der Berechnungsgrundlage</param>
    ''' <param name="WorkOnSaturdays">True, wenn Samstag Arbeitstag ist.</param>
    ''' <param name="WorkOnSundays">True, wenn Sonntag Arbeitstag ist.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function NextWorkday(ByVal CurrentDate As Date, ByVal WorkOnSaturdays As Boolean, ByVal WorkOnSundays As Boolean) As Date
        CurrentDate = CurrentDate.AddDays(1)
        If Weekday(CurrentDate) = DayOfWeek.Saturday And Not WorkOnSaturdays Then
            CurrentDate = CurrentDate.AddDays(1)
        End If
        If Weekday(CurrentDate) = DayOfWeek.Sunday And Not WorkOnSundays Then
            CurrentDate = CurrentDate.AddDays(1)
        End If
        Return CurrentDate
    End Function

    ''' <summary>
    ''' Ergibt das Datum des vorherigen Arbeitstages.
    ''' </summary>
    ''' <param name="CurrentDate">Datum der Berechnungsgrundlage</param>
    ''' <param name="WorkOnSaturdays">True, wenn Samstag Arbeitstag ist.</param>
    ''' <param name="WorkOnSundays">True, wenn Sonntag Arbeitstag ist.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PreviousWorkday(ByVal CurrentDate As Date, ByVal WorkOnSaturdays As Boolean, ByVal WorkOnSundays As Boolean) As Date
        CurrentDate = CurrentDate.AddDays(-1)
        If Weekday(CurrentDate) = DayOfWeek.Sunday And Not WorkOnSundays Then
            CurrentDate = CurrentDate.AddDays(-1)
        End If
        If Weekday(CurrentDate) = DayOfWeek.Saturday And Not WorkOnSaturdays Then
            CurrentDate = CurrentDate.AddDays(-1)
        End If
        Return CurrentDate
    End Function
End Class
