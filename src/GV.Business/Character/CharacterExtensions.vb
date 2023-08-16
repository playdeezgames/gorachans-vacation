Imports System.Runtime.CompilerServices

Friend Module CharacterExtensions
    <Extension>
    Friend Sub AddDurries(character As ICharacter, delta As Integer)
        character.SetDurries(character.DurryCount + delta)
    End Sub
    <Extension>
    Private Sub SetDurries(character As ICharacter, durries As Integer)
        character.SetStatistic(StatisticTypes.Durries, Math.Max(0, durries))
    End Sub
    <Extension>
    Friend Sub AddYen(character As ICharacter, delta As Integer)
        character.SetYen(character.Yen + delta)
    End Sub
    <Extension>
    Private Sub SetYen(character As ICharacter, yen As Integer)
        character.SetStatistic(StatisticTypes.Yen, Math.Max(yen, 0))
    End Sub
    <Extension>
    Friend Function Yen(character As ICharacter) As Integer
        '¥
        Return character.TryGetStatistic(StatisticTypes.Yen)
    End Function
    <Extension>
    Friend Function OtherCells(character As ICharacter) As IEnumerable(Of ICell)
        Return character.Map.Cells.Where(Function(x) x.Id <> character.Cell.Id)
    End Function
    <Extension>
    Friend Function DurryCount(character As ICharacter) As Integer
        Return character.TryGetStatistic(StatisticTypes.Durries)
    End Function
    <Extension>
    Private Function Withdrawal(character As ICharacter) As Integer
        Return character.TryGetStatistic(StatisticTypes.Withdrawal, 0)
    End Function
    <Extension>
    Private Sub SetWithdrawal(character As ICharacter, withdrawal As Integer)
        character.SetStatistic(StatisticTypes.Withdrawal, Math.Max(0, withdrawal))
    End Sub
    <Extension>
    Friend Sub AddWithdrawal(character As ICharacter, delta As Integer)
        character.SetWithdrawal(character.Withdrawal + delta)
    End Sub
    <Extension>
    Friend Sub Reset(character As ICharacter)
        If Not character.Flag(FlagTypes.InspectedBalcony) Then
            character.AddWithdrawal(1)
        End If
        character.Flag(FlagTypes.InspectedBalcony) = False
        character.AddStress(character.Withdrawal)
    End Sub
    <Extension>
    Friend Function Name(character As ICharacter) As String
        Return character.Metadata(Metadatas.Name)
    End Function
    <Extension>
    Friend Function Stress(character As ICharacter) As Integer
        Return character.Statistic(StatisticTypes.Stress)
    End Function
    <Extension>
    Friend Function MaximumStress(character As ICharacter) As Integer
        Return character.Statistic(StatisticTypes.MaximumStress)
    End Function
    <Extension>
    Friend Sub AddStress(character As ICharacter, delta As Integer)
        character.SetStress(character.Stress + delta)
    End Sub
    <Extension>
    Friend Function OverStress(character As ICharacter) As Integer
        Return character.TryGetStatistic(StatisticTypes.OverStress)
    End Function
    <Extension>
    Friend Sub AddOverStress(character As ICharacter, delta As Integer)
        character.SetOverStress(character.OverStress + delta)
    End Sub
    <Extension>
    Private Sub SetOverStress(character As ICharacter, overStress As Integer)
        character.SetStatistic(StatisticTypes.OverStress, overStress)
    End Sub
    <Extension>
    Private Sub SetStress(character As ICharacter, stress As Integer)
        Dim clampedStress = Math.Clamp(stress, 0, character.MaximumStress)
        If stress > clampedStress Then
            character.AddOverStress(stress - clampedStress)
        End If
        character.SetStatistic(StatisticTypes.Stress, clampedStress)
    End Sub
    <Extension>
    Friend Sub AddDay(character As ICharacter)
        character.SetStatistic(StatisticTypes.Day, character.Statistic(StatisticTypes.Day) + 1)
    End Sub
    <Extension>
    Friend Function Day(character As ICharacter) As Integer
        Return character.TryGetStatistic(StatisticTypes.Day)
    End Function
    <Extension>
    Friend Function IsBackToWork(character As ICharacter) As Boolean
        Return character.Statistic(StatisticTypes.Day) > 10
    End Function
End Module
