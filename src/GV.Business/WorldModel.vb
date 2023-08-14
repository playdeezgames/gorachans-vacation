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
        Dim avatar = world.Avatar
        outputter(avatar.Cell.Name)
        outputter($"Name: {avatar.Name}")
        outputter($"Stress: {avatar.Stress}/{avatar.MaximumStress}")
        Dim result As New Dictionary(Of String, Func(Of Boolean))
        For Each item In avatar.Items
            If item.CanBeUsed AndAlso Not item.HasBeenUsedToday Then
                result(item.UsageText) = item.Use
            End If
        Next
        result("Next Day") = AddressOf NextDay
        Return result
    End Function

    Private Function NextDay() As Boolean
        Dim avatar = world.Avatar
        avatar.Move(1, 0)
        Return True
    End Function
End Class
