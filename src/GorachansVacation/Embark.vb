Friend Module Embark
    Friend Sub Handle()
        AnsiConsole.Clear()
        AnsiConsole.WriteLine("TODO: Make game go here!")
        Dim prompt As New SelectionPrompt(Of String) With {.Title = ""}
        prompt.AddChoice(OkText)
        AnsiConsole.Prompt(prompt)
    End Sub
End Module
