Imports System

Module Program
    Sub Main(args As String())
        Console.Title = GameTitle
        AnsiConsole.Clear()
        Dim figlet As New FigletText(GameTitle) With {.Color = Color.Red, .Justification = Justify.Center}
        AnsiConsole.Write(figlet)
        Dim prompt As New SelectionPrompt(Of String) With {.Title = ""}
        prompt.AddChoice(QuitText)
        AnsiConsole.Prompt(prompt)
    End Sub
End Module
