Friend Class BuyDurriesDescriptor
    Inherits ItemTypeDescriptor
    Const Price = 600
    Const DurryCount = 20

    Friend Overrides Function Use(character As ICharacter, item As IItem) As Boolean
        If character.Yen < Price Then
            character.World.CreateMessage.
                AddLine(0, $"Durries cost ¥{Price}, and {character.Name} doesn't have enough.").
                AddLine(0, $"Maybe {character.Name} needs to visit an ATM.")
            Return True
        End If
        character.AddYen(-Price)
        character.AddDurries(DurryCount)
        character.World.CreateMessage.AddLine(0, $"{character.Name} pays ¥{Price}, and receives {DurryCount} durries.")
        Return True
    End Function

    Friend Overrides Function CanUse(character As ICharacter, item As IItem) As Boolean
        Return character.Cell.Flag(FlagTypes.SellsDurries)
    End Function
End Class
