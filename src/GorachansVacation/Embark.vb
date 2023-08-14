Friend Module Embark
    Friend Sub Handle(model As IWorldModel)
        model.Start()
        Onward.Handle(model)
    End Sub

End Module
