Friend Module LoadGame
    Friend Sub Handle(model As IWorldModel)
        Dim saveGameName = AnsiConsole.Ask(Of String)(SaveGameNamePrompt, String.Empty)
        If Not String.IsNullOrWhiteSpace(saveGameName) Then
            DoLoad(model, saveGameName)
        End If
    End Sub

    Friend Sub DoLoad(model As IWorldModel, saveGameName As String)
        Try
            model.Load(System.IO.File.ReadAllText(saveGameName))
            AnsiConsole.MarkupLine(GameLoadedMessage)
            OkPrompt()
        Catch ex As Exception
            AnsiConsole.MarkupLine(LoadFailedMessage)
            OkPrompt()
        End Try
    End Sub
End Module
