Friend Module AbandonGame
    Friend Sub Handle(model As IWorldModel)
        If Confirm.Handle(ConfirmAbandonPrompt) Then
            model.AbandonWorld()
        End If
    End Sub
End Module
