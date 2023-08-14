Imports System.Runtime.CompilerServices

Friend Module ItemExtensions
    <Extension>
    Function HasBeenUsedToday(item As IItem) As Boolean
        Return item.Flag(FlagTypes.UsedToday)
    End Function
    <Extension>
    Function UsageText(item As IItem) As String
        Return item.Metadata(Metadatas.UsageText)
    End Function
    <Extension>
    Function Use(item As IItem) As Func(Of Boolean)
        Throw New NotImplementedException
    End Function
End Module
