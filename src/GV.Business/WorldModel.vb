Public Class WorldModel
    Implements IWorldModel
    Private world As IWorld

    Public ReadOnly Property HasWorld As Boolean Implements IWorldModel.HasWorld
        Get
            Return world IsNot Nothing
        End Get
    End Property

    Public Sub Start() Implements IWorldModel.Start
        world = New World(New Data.WorldData)
    End Sub
End Class
