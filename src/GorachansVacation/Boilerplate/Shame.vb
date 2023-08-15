Friend Module Shame
    Friend Sub Handle(model As IWorldModel)
        AnsiConsole.Clear()
        Dim figlet As New FigletText(ShameText) With {.Color = Color.Red, .Justification = Justify.Center}
        AnsiConsole.Write(figlet)
        Task.Delay(3000).Wait()
    End Sub
End Module
