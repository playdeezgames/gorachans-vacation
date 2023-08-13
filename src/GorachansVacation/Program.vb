Module Program
    Sub Main(args As String())
        Console.Title = GameTitle
        Dim model As IWorldModel = New WorldModel
        TitleScreen.Handle(model)
    End Sub
End Module
