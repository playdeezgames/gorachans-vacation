Public Interface IWorldModel
    ReadOnly Property HasWorld As Boolean
    Sub StartWorld()
    Sub AbandonWorld()
    Function UpdateStatus(outputter As Action(Of String)) As IReadOnlyDictionary(Of String, Func(Of Boolean))
    Function Save() As String
End Interface
