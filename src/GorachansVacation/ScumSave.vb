Friend Module ScumSave
    Friend Sub Handle(model As IWorldModel)
        System.IO.File.WriteAllText("scum.json", model.Save())
        AnsiConsole.MarkupLine(GameSavedMessage)
        OkPrompt()
    End Sub
End Module
