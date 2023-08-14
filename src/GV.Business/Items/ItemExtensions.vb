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
    Function Use(item As IItem, character As ICharacter) As Func(Of Boolean)
        Return Function()
                   Return item.Descriptor.Use(character, item)
               End Function
    End Function
    <Extension>
    Function CanBeUsed(item As IItem) As Boolean
        Return item.Flag(FlagTypes.CanBeUsed)
    End Function
    <Extension>
    Function Descriptor(item As IItem) As ItemTypeDescriptor
        Return ItemTypes.ToDescriptor(item.ItemType)
    End Function
    <Extension>
    Friend Sub SetUsedToday(item As IItem, value As Boolean)
        item.Flag(FlagTypes.UsedToday) = value
    End Sub
    <Extension>
    Friend Sub Reset(item As IItem)
        If item.CanBeUsed Then
            item.SetUsedToday(False)
        End If
    End Sub
End Module
