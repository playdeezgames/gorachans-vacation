﻿Friend Class Item
    Inherits ItemDataClient
    Implements IItem
    Public Sub New(worldData As WorldData, itemId As Integer)
        MyBase.New(worldData, itemId)
    End Sub
    Public ReadOnly Property Id As Integer Implements IItem.Id
        Get
            Return ItemId
        End Get
    End Property

    Public ReadOnly Property ItemType As String Implements IItem.ItemType
        Get
            Return ItemData.ItemType
        End Get
    End Property

    Public ReadOnly Property Statistic(statisticType As String) As Integer Implements IItem.Statistic
        Get
            Return ItemData.Statistics(statisticType)
        End Get
    End Property

    Public Property Flag(flagType As String) As Boolean Implements IFlagHolder.Flag
        Get
            Return ItemData.Flags.Contains(flagType)
        End Get
        Set(value As Boolean)
            If value Then
                ItemData.Flags.Add(flagType)
            Else
                ItemData.Flags.Remove(flagType)
            End If
        End Set
    End Property

    Public Property Metadata(identifier As String) As String Implements IMetadataHolder.Metadata
        Get
            Return ItemData.Metadatas(identifier)
        End Get
        Set(value As String)
            ItemData.Metadatas(identifier) = value
        End Set
    End Property

    Public ReadOnly Property World As IWorld Implements IItem.World
        Get
            Return New World(WorldData)
        End Get
    End Property

    Public Sub Recycle() Implements IItem.Recycle
        ItemData.Recycled = True
    End Sub

    Public Sub RemoveStatistic(statisticType As String) Implements IStatisticsHolder.RemoveStatistic
        ItemData.Statistics.Remove(statisticType)
    End Sub

    Public Sub RemoveMetadata(identifier As String) Implements IMetadataHolder.RemoveMetadata
        ItemData.Metadatas.Remove(identifier)
    End Sub

    Public Sub SetStatistic(statisticType As String, value As Integer) Implements IStatisticsHolder.SetStatistic
        ItemData.Statistics(statisticType) = value
    End Sub

    Public Function HasStatistic(statisticType As String) As Boolean Implements IStatisticsHolder.HasStatistic
        Return ItemData.Statistics.ContainsKey(statisticType)
    End Function

    Public Function HasMetadata(identifier As String) As Boolean Implements IMetadataHolder.HasMetadata
        Return ItemData.Metadatas.ContainsKey(identifier)
    End Function

    Public Function TryGetStatistic(statisticType As String, Optional defaultValue As Integer = 0) As Integer Implements IStatisticsHolder.TryGetStatistic
        Return If(HasStatistic(statisticType), Statistic(statisticType), defaultValue)
    End Function

    Public Function AddStatistic(statisticType As String, delta As Integer) As Integer Implements IStatisticsHolder.AddStatistic
        SetStatistic(statisticType, Statistic(statisticType) + delta)
        Return Statistic(statisticType)
    End Function
End Class
