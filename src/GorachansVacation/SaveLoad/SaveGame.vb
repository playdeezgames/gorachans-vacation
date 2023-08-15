Friend Module SaveGame
    Friend Sub Handle(model As IWorldModel)
        Dim saveGameName = AnsiConsole.Ask(Of String)(SaveGameNamePrompt, String.Empty)
        If Not String.IsNullOrWhiteSpace(saveGameName) Then
            DoSave(model, saveGameName)
        End If
    End Sub

    Friend Sub DoSave(model As IWorldModel, saveGameName As String)
        System.IO.File.WriteAllText(saveGameName, model.Save())
        AnsiConsole.MarkupLine(GameSavedMessage)
        OkPrompt()
    End Sub
End Module
