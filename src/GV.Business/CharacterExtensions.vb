Imports System.Runtime.CompilerServices

Friend Module CharacterExtensions
    <Extension>
    Function Name(character As ICharacter) As String
        Return character.Metadata(Metadatas.Name)
    End Function
    <Extension>
    Function Stress(character As ICharacter) As Integer
        Return character.Statistic(StatisticTypes.Stress)
    End Function
    <Extension>
    Function MaximumStress(character As ICharacter) As Integer
        Return character.Statistic(StatisticTypes.MaximumStress)
    End Function
    <Extension>
    Sub Move(character As ICharacter, deltaX As Integer, deltaY As Integer)
        Dim nextX = character.Cell.Column + deltaX
        Dim nextY = character.Cell.Row + deltaY
        Dim nextCell = character.Map.GetCell(nextX, nextY)
        character.Cell.RemoveCharacter(character)
        nextCell.AddCharacter(character)
        character.Cell = nextCell
    End Sub
End Module
