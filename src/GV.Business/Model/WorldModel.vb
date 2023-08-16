﻿Public Class WorldModel
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
        If world.HasMessages Then
            Return ShowMessage(outputter)
        End If
        Dim avatar = world.Avatar
        If avatar.IsBackToWork Then
            Return ShowBackToWork(outputter)
        End If
        Return ShowStatus(outputter)
    End Function

    Private Function ShowStatus(outputter As Action(Of String)) As IReadOnlyDictionary(Of String, Func(Of Boolean))
        Dim avatar = world.Avatar
        outputter($"Day: {avatar.Day}")
        outputter($"Location: {avatar.Cell.Name}")
        outputter($"Name: {avatar.Name}")
        outputter($"Stress: {avatar.Stress}/{avatar.MaximumStress}")
        Dim result As New Dictionary(Of String, Func(Of Boolean))
        For Each item In avatar.Items
            If item.CanBeUsed(avatar) AndAlso Not item.HasBeenUsedToday Then
                result(item.UsageText) = item.Use(avatar)
            End If
        Next
        For Each cell In avatar.OtherCells.Where(Function(x) x.IsKnownLocation)
            result(cell.MoveToText) = cell.MoveTo(avatar)
        Next
        result("Next Day") = AddressOf NextDay
        Return result
    End Function

    Private Function ShowBackToWork(outputter As Action(Of String)) As IReadOnlyDictionary(Of String, Func(Of Boolean))
        outputter("Back to work!")
        outputter($"Final stress level: {world.Avatar.Stress}")
        Return New Dictionary(Of String, Func(Of Boolean)) From
            {
                {"All done!", Function() False}
            }
    End Function

    Private Function ShowMessage(outputter As Action(Of String)) As IReadOnlyDictionary(Of String, Func(Of Boolean))
        For Each line In world.CurrentMessage.Lines
            outputter(line.Text)
        Next
        world.DismissMessage()
        Return New Dictionary(Of String, Func(Of Boolean)) From
            {
                {"Ok", Function() True}
            }
    End Function

    Public Function Save() As String Implements IWorldModel.Save
        Return world.SerializedData
    End Function

    Public Function Load(serializedData As String) As Boolean Implements IWorldModel.Load
        Try
            world = Persistence.World.Load(serializedData)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function NextDay() As Boolean
        Dim avatar = world.Avatar
        avatar.AddDay()
        avatar.Reset()
        For Each item In avatar.Items
            item.Reset()
        Next
        Return True
    End Function
End Class
