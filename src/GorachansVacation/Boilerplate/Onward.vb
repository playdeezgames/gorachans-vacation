Friend Module Onward
    Friend Sub Handle(model As IWorldModel)
        Do
            AnsiConsole.Clear()
            Dim choices = model.UpdateStatus(Sub(x) AnsiConsole.MarkupLine(x))
            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Now What?[/]"}
            prompt.AddChoices(choices.Keys)
            prompt.AddChoice(MainMenuText)
            Dim answer = AnsiConsole.Prompt(prompt)
            Select Case answer
                Case MainMenuText
                    Return
                Case Else
                    If Not choices(answer)() Then
                        Exit Do
                    End If
            End Select
        Loop
    End Sub
End Module
