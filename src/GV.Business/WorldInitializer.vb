Friend Module WorldInitializer
    Private ReadOnly VacationMapSize = (10, 1)
    Friend Sub Initialize(world As IWorld)
        Dim vacationMap = world.CreateMap(MapTypes.Vacation, VacationMapSize, TerrainTypes.Empty)
        Dim gorachan = world.CreateCharacter(CharacterTypes.Gorachan, vacationMap.GetCell(0, 0))
        gorachan.SetStatistic(StatisticTypes.MaximumStress, 100)
        gorachan.SetStatistic(StatisticTypes.Stress, 100)
        gorachan.Cell.AddCharacter(gorachan)
        world.Avatar = gorachan
    End Sub
End Module
