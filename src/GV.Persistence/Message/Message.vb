﻿Imports GV.Data

Friend Class Message
    Inherits MessageDataClient
    Implements IMessage

    Public Sub New(worldData As WorldData, messageId As Integer)
        MyBase.New(worldData, messageId)
    End Sub

    Public ReadOnly Property LineCount As Integer Implements IMessage.LineCount
        Get
            Return MessageData.Lines.Count
        End Get
    End Property

    Private ReadOnly Property ChoiceCount As Integer Implements IMessage.ChoiceCount
        Get
            Return MessageData.Choices.Count
        End Get
    End Property

    Public ReadOnly Property Lines As IEnumerable(Of IMessageLine) Implements IMessage.Lines
        Get
            Return Enumerable.Range(0, LineCount).Select(Function(x) New MessageLine(WorldData, MessageId, x))
        End Get
    End Property

    Public Property Sfx As String Implements IMessage.Sfx
        Get
            Return MessageData.Sfx
        End Get
        Set(value As String)
            MessageData.Sfx = value
        End Set
    End Property

    Public ReadOnly Property HasChoices As Boolean Implements IMessage.HasChoices
        Get
            Return MessageData.Choices.Any
        End Get
    End Property

    Public ReadOnly Property Choices As IEnumerable(Of IMessageChoice) Implements IMessage.Choices
        Get
            Return Enumerable.Range(0, ChoiceCount).Select(Function(x) New MessageChoice(WorldData, MessageId, x))
        End Get
    End Property

    Public ReadOnly Property Statistic(statisticType As String) As Integer Implements IStatisticsHolder.Statistic
        Get
            Return MessageData.Statistics(statisticType)
        End Get
    End Property

    Public Property Flag(flagType As String) As Boolean Implements IFlagHolder.Flag
        Get
            Return MessageData.Flags.Contains(flagType)
        End Get
        Set(value As Boolean)
            If value Then
                MessageData.Flags.Add(flagType)
            Else
                MessageData.Flags.Remove(flagType)
            End If
        End Set
    End Property

    Public Property Metadata(identifier As String) As String Implements IMetadataHolder.Metadata
        Get
            Return MessageData.Metadatas(identifier)
        End Get
        Set(value As String)
            MessageData.Metadatas(identifier) = value
        End Set
    End Property

    Public Function AddLine(hue As Integer, text As String) As IMessage Implements IMessage.AddLine
        MessageData.Lines.Add(New MessageLineData With
                              {
                                .Text = text,
                                .Hue = hue
                              })
        Return Me
    End Function

    Public Function SetSfx(sfx As String) As IMessage Implements IMessage.SetSfx
        Me.Sfx = sfx
        Return Me
    End Function

    Public Function AddChoice(
                             text As String,
                             effectType As String,
                             Optional initializer As Action(Of IMessageChoice) = Nothing) As IMessage Implements IMessage.AddChoice
        Dim id = MessageData.Choices.Count
        MessageData.Choices.Add(New MessageChoiceData With
            {
                .Text = text,
                .EffectType = effectType
            })
        initializer?.Invoke(Choice(id))
        Return Me
    End Function

    Public Function Choice(index As Integer) As IMessageChoice Implements IMessage.Choice
        Return New MessageChoice(WorldData, MessageId, index)
    End Function

    Public Sub RemoveStatistic(statisticType As String) Implements IStatisticsHolder.RemoveStatistic
        MessageData.Statistics.Remove(statisticType)
    End Sub

    Public Function HasStatistic(statisticType As String) As Boolean Implements IStatisticsHolder.HasStatistic
        Return MessageData.Statistics.ContainsKey(statisticType)
    End Function

    Public Function HasMetadata(identifier As String) As Boolean Implements IMetadataHolder.HasMetadata
        Return MessageData.Metadatas.ContainsKey(identifier)
    End Function

    Public Sub RemoveMetadata(identifier As String) Implements IMetadataHolder.RemoveMetadata
        MessageData.Metadatas.Remove(identifier)
    End Sub

    Public Function TryGetStatistic(statisticType As String, Optional defaultValue As Integer = 0) As Integer Implements IStatisticsHolder.TryGetStatistic
        Return If(HasStatistic(statisticType), Statistic(statisticType), defaultValue)
    End Function

    Public Sub SetStatistic(statisticType As String, value As Integer) Implements IStatisticsHolder.SetStatistic
        MessageData.Statistics(statisticType) = value
    End Sub

    Public Function AddStatistic(statisticType As String, delta As Integer) As Integer Implements IStatisticsHolder.AddStatistic
        SetStatistic(statisticType, Statistic(statisticType) + delta)
        Return Statistic(statisticType)
    End Function
End Class
