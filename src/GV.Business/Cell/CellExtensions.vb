Imports System.Runtime.CompilerServices

Friend Module CellExtensions
    <Extension>
    Friend Function HasBed(cell As ICell) As Boolean
        Return cell.Flag(FlagTypes.Bed)
    End Function
    <Extension>
    Friend Function HasBalcony(cell As ICell) As Boolean
        Return cell.Flag(FlagTypes.Balcony)
    End Function
    <Extension>
    Friend Function MoveToText(cell As ICell) As String
        Return cell.Metadata(Metadatas.MoveToText)
    End Function
    <Extension>
    Friend Function MoveTo(cell As ICell, character As ICharacter) As Func(Of Boolean)
        Return Function()
                   character.Cell.RemoveCharacter(character)
                   character.Cell = cell
                   cell.AddCharacter(character)
                   character.World.CreateMessage().AddLine(0, $"{character.Name} moves to {cell.Name}.")
                   Return True
               End Function
    End Function
    <Extension>
    Friend Function Name(cell As ICell) As String
        Return cell.Metadata(Metadatas.Name)
    End Function
    <Extension>
    Friend Sub SetName(cell As ICell, name As String)
        cell.Metadata(Metadatas.Name) = name
    End Sub
    <Extension>
    Friend Function IsKnownLocation(cell As ICell) As Boolean
        Return cell.Flag(FlagTypes.KnownLocation)
    End Function
End Module
