Friend Class InspectBalconyDescriptor
    Inherits ItemTypeDescriptor

    Friend Overrides Function Use(character As ICharacter, item As IItem) As Boolean
        character.Flag(FlagTypes.InspectedBalcony) = True
        character.World.CreateMessage().AddLine(0, $"{character.Name} inspects the balcony.")
        Return True
    End Function
End Class
