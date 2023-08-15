Imports System.Runtime.CompilerServices

Friend Module CellExtensions
    <Extension>
    Friend Function Name(cell As ICell) As String
        Return cell.Metadata(Metadatas.Name)
    End Function
    <Extension>
    Friend Function IsBackToWork(cell As ICell) As Boolean
        Return cell.Flag(FlagTypes.BackToWork)
    End Function
End Module
