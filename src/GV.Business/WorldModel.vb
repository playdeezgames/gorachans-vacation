Public Class WorldModel
    Implements IWorldModel

    Public ReadOnly Property HasWorld As Boolean Implements IWorldModel.HasWorld
        Get
            Return False
        End Get
    End Property
End Class
