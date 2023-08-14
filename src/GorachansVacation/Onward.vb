Friend Module Onward
    Friend Sub Handle(model As IWorldModel)
        AnsiConsole.Clear()
        model.UpdateStatus(Sub(x) AnsiConsole.MarkupLine(x))
        Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Now What?[/]"}
        'Populate choices
        prompt.AddChoice(MainMenuText)
        Select Case AnsiConsole.Prompt(prompt)
            Case MainMenuText
                Return
        End Select
    End Sub
End Module
