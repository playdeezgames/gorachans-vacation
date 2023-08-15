Friend Module Embark
    Friend Sub Handle(model As IWorldModel)
        model.StartWorld()
        Onward.Handle(model)
    End Sub

End Module
