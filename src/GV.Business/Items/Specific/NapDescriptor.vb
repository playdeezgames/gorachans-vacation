Friend Class NapDescriptor
    Inherits ItemTypeDescriptor

    Friend Overrides Function Use(character As ICharacter, item As IItem) As Boolean
        character.World.CreateMessage().AddLine(0, "You take a short nap.")
        character.AddStress(-10)
        item.SetUsedToday(True)
        Return True
    End Function

    Friend Overrides Function CanUse(character As ICharacter, item As IItem) As Boolean
        Return character.Cell.HasBed
    End Function
End Class
