Imports System.Runtime.CompilerServices

Friend Module CharacterExtensions
    <Extension>
    Private Function Withdrawal(character As ICharacter) As Integer
        Return character.TryGetStatistic(StatisticTypes.Withdrawal, 0)
    End Function
    <Extension>
    Private Sub SetWithdrawal(character As ICharacter, withdrawal As Integer)
        character.SetStatistic(StatisticTypes.Withdrawal, Math.Max(0, withdrawal))
    End Sub
    <Extension>
    Private Sub AddWithdrawal(character As ICharacter, delta As Integer)
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
    Friend Sub Move(character As ICharacter, deltaX As Integer, deltaY As Integer)
        Dim nextX = character.Cell.Column + deltaX
        Dim nextY = character.Cell.Row + deltaY
        Dim nextCell = character.Map.GetCell(nextX, nextY)
        character.Cell.RemoveCharacter(character)
        nextCell.AddCharacter(character)
        character.Cell = nextCell
    End Sub
    <Extension>
    Friend Sub AddStress(character As ICharacter, delta As Integer)
        character.SetStress(character.Stress + delta)
    End Sub
    <Extension>
    Private Sub SetStress(character As ICharacter, stress As Integer)
        character.SetStatistic(StatisticTypes.Stress, Math.Clamp(stress, 0, character.MaximumStress))
    End Sub
End Module
