Friend Module WorldInitializer
    Private ReadOnly VacationMapSize = (10, 1)
    Friend Sub Initialize(world As IWorld)
        Dim vacationMap = world.CreateMap(MapTypes.Vacation, VacationMapSize, TerrainTypes.Empty)
        Dim gorachan = world.CreateCharacter(CharacterTypes.Gorachan, vacationMap.GetCell(0, 0))
        gorachan.Cell.AddCharacter(gorachan)
    End Sub
End Module
