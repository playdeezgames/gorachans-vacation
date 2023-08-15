Imports System.Runtime.CompilerServices

Friend Module CellExtensions
    <Extension>
    Friend Function Name(cell As ICell) As String
        Return cell.Metadata(Metadatas.Name)
    End Function
End Module
