Friend Class InspectBalconyDescriptor
    Inherits ItemTypeDescriptor

    Friend Overrides Function Use(character As ICharacter, item As IItem) As Boolean
        If character.DurryCount < 1 Then
            character.World.CreateMessage().
                AddLine(0, $"{character.Name} has no durries.").
                AddLine(0, $"Mebbe {character.Name} should head to the Kombini to get some.")
            character.Map.Cells.Single(Function(x) x.Flag(FlagTypes.Kombini)).Flag(FlagTypes.KnownLocation) = True
            Return True
        End If
        If Not character.Flag(FlagTypes.InspectedBalcony) Then
            character.AddWithdrawal(-1)
        End If
        character.Flag(FlagTypes.InspectedBalcony) = True
        character.World.CreateMessage().AddLine(0, $"{character.Name} inspects the balcony.")
        Return True
    End Function
End Class
