Friend Module Onward
    Friend Sub Handle(model As IWorldModel)
        AnsiConsole.Clear()
        AnsiConsole.MarkupLine("Yer playin' the game!")
        Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Now What?[/]"}
        prompt.AddChoice(MainMenuText)
        Select Case AnsiConsole.Prompt(prompt)
            Case MainMenuText
                Return
        End Select
    End Sub
End Module
