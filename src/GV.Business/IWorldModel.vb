Public Interface IWorldModel
    ReadOnly Property HasWorld As Boolean
    Sub StartWorld()
    Sub AbandonWorld()
    Sub UpdateStatus(outputter As Action(Of String))
End Interface
