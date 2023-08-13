Imports System

Module Program
    Sub Main(args As String())
        AnsiConsole.Clear()
        Dim prompt = New SelectionPrompt(Of String) With {.Title = "[aqua]Gorachan's Vacation IV: Just the Tip[/]"}
        prompt.AddChoice("Quit")
        AnsiConsole.Prompt(prompt)
    End Sub
End Module
