﻿Friend Class PlayVideoGamesDescriptor
    Inherits ItemTypeDescriptor

    Friend Overrides Function CanUse(character As ICharacter, item As IItem) As Boolean
        Throw New NotImplementedException()
    End Function

    Friend Overrides Function Use(character As ICharacter, item As IItem) As Boolean
        Throw New NotImplementedException()
    End Function
End Class
