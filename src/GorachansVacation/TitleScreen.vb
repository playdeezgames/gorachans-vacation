Friend Module TitleScreen
    Friend Sub Handle(model As IWorldModel)
        Do
            AnsiConsole.Clear()
            Dim figlet As New FigletText(GameTitle) With {.Color = Color.Red, .Justification = Justify.Center}
            AnsiConsole.Write(figlet)
            Dim prompt As New SelectionPrompt(Of String) With {.Title = MainMenuTitle}
            If model.HasWorld Then
                prompt.AddChoice(OnwardText)
                prompt.AddChoice(AbandonGameText)
                prompt.AddChoice(ScumSaveText)
                prompt.AddChoice(SaveGameText)
            Else
                prompt.AddChoice(EmbarkText)
                prompt.AddChoice(ScumLoadText)
                prompt.AddChoice(LoadGameText)
            End If
            prompt.AddChoice(QuitText)
            Select Case AnsiConsole.Prompt(prompt)
                Case AbandonGameText
                    AbandonGame.Handle(model)
                Case SaveGameText
                    SaveGame.Handle(model)
                Case ScumSaveText
                    ScumSave.Handle(model)
                Case OnwardText
                    Onward.Handle(model)
                Case EmbarkText
                    Embark.Handle(model)
                Case ScumLoadText
                    ScumLoad.Handle(model)
                Case LoadGameText
                    LoadGame.Handle(model)
                Case QuitText
                    If Confirm.Handle(QuitPrompt) Then
                        Shame.Handle(model)
                        Exit Do
                    End If
            End Select
        Loop
    End Sub
End Module
