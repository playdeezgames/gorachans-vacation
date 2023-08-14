Public Class WorldModel
    Implements IWorldModel
    Private world As IWorld

    Public ReadOnly Property HasWorld As Boolean Implements IWorldModel.HasWorld
        Get
            Return world IsNot Nothing
        End Get
    End Property

    Public Sub StartWorld() Implements IWorldModel.StartWorld
        world = New World(New Data.WorldData)
        WorldInitializer.Initialize(world)
    End Sub

    Public Sub AbandonWorld() Implements IWorldModel.AbandonWorld
        world = Nothing
    End Sub

    Public Function UpdateStatus(outputter As Action(Of String)) As IReadOnlyDictionary(Of String, Func(Of Boolean)) Implements IWorldModel.UpdateStatus
        outputter("Yer playin' the game!")
        Return New Dictionary(Of String, Func(Of Boolean)) From
            {
                {"Cool story, bro!", Function() False}
            }
    End Function
End Class
