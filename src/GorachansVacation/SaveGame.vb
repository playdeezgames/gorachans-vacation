Friend Module SaveGame
    Friend Sub Handle(model As IWorldModel)
        Dim saveGameName = AnsiConsole.Ask(Of String)(SaveGameNamePrompt, String.Empty)
        If Not String.IsNullOrWhiteSpace(saveGameName) Then
            System.IO.File.WriteAllText(saveGameName, model.Save())
            AnsiConsole.MarkupLine(GameSavedMessage)
            OkPrompt()
        End If
    End Sub
End Module
