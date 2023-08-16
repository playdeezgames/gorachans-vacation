Friend MustInherit Class ItemTypeDescriptor
    Friend MustOverride Function Use(character As ICharacter, item As IItem) As Boolean
    Friend MustOverride Function CanUse(character As ICharacter, item As IItem) As Boolean
End Class
