﻿Friend Module Confirm
    Friend Function Handle(text As String) As Boolean
        Dim prompt As New SelectionPrompt(Of String) With {.Title = text}
        prompt.AddChoices(NoText, YesText)
        Return AnsiConsole.Prompt(prompt) = YesText
    End Function
End Module
