Friend Class MessageDataClient
    Inherits WorldDataClient
    Protected ReadOnly Property MessageId As Integer
    Protected ReadOnly Property MessageData As MessageData
        Get
            Return WorldData.Messages(MessageId)
        End Get
    End Property
    Public Sub New(worldData As WorldData, messageId As Integer)
        MyBase.New(worldData)
        Me.MessageId = messageId
    End Sub
End Class
