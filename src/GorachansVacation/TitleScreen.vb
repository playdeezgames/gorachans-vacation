Friend Module TitleScreen
    Friend Sub Handle()
        Do
            AnsiConsole.Clear()
            Dim figlet As New FigletText(GameTitle) With {.Color = Color.Red, .Justification = Justify.Center}
            AnsiConsole.Write(figlet)
            Dim prompt As New SelectionPrompt(Of String) With {.Title = ""}
            prompt.AddChoice(QuitText)
            Select Case AnsiConsole.Prompt(prompt)
                Case QuitText
                    If Confirm.Handle(QuitPrompt) Then
                        Shame.Handle()
                        Exit Do
                    End If
            End Select
        Loop
    End Sub
End Module
