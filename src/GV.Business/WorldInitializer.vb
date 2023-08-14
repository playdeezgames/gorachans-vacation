Friend Module WorldInitializer
    Private ReadOnly VacationMapSize As (days As Integer, rows As Integer) = (10, 1)
    Friend Sub Initialize(world As IWorld)
        Dim vacationMap = world.CreateMap(MapTypes.Vacation, VacationMapSize, TerrainTypes.Empty)
        For Each day In Enumerable.Range(0, VacationMapSize.days)
            vacationMap.GetCell(day, 0).SetMetadata(Metadatas.Name, $"Day {day + 1}")
        Next
        InitializeGorachan(world, vacationMap)
    End Sub

    Private Sub InitializeGorachan(world As IWorld, vacationMap As IMap)
        Dim gorachan = world.CreateCharacter(CharacterTypes.Gorachan, vacationMap.GetCell(0, 0))
        gorachan.SetMetadata(Metadatas.Name, "Gorachan")
        gorachan.SetStatistic(StatisticTypes.MaximumStress, 100)
        gorachan.SetStatistic(StatisticTypes.Stress, 100)
        Dim item = world.CreateItem(ItemTypes.Nap)
        item.SetMetadata(Metadatas.UsageText, "Take a nap!")
        item.SetFlag(FlagTypes.CanBeUsed, True)
        gorachan.AddItem(item)
        gorachan.Cell.AddCharacter(gorachan)
        world.Avatar = gorachan
    End Sub
End Module
