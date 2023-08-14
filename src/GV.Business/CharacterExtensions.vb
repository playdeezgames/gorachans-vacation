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
End Module
