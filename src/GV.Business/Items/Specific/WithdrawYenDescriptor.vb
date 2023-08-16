Friend Class WithdrawYenDescriptor
    Inherits ItemTypeDescriptor

    Friend Overrides Function Use(character As ICharacter, item As IItem) As Boolean
        character.AddYen(10000)
        character.AddStress(5)
        character.World.CreateMessage.AddLine(0, $"{character.Name} withdraws ¥10,000")
        Return True
    End Function

    Friend Overrides Function CanUse(character As ICharacter, item As IItem) As Boolean
        Return character.Cell.IsATM
    End Function
End Class
