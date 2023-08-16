Friend Module WorldInitializer
    Private ReadOnly MapSize As (columns As Integer, rows As Integer) = (2, 1)
    Private ReadOnly ApartmentLocation As (column As Integer, row As Integer) = (0, 0)
    Private ReadOnly KombiniLocation As (column As Integer, row As Integer) = (1, 0)
    Friend Sub Initialize(world As IWorld)
        Dim map = world.CreateMap(MapTypes.Vacation, MapSize, TerrainTypes.Empty)
        Dim apartmentCell As ICell = InitializeApartment(map)
        Dim kombiniCell As ICell = InitializeKombini(map)
        InitializeGorachan(world, apartmentCell)
    End Sub

    Private Function InitializeKombini(map As IMap) As ICell
        Dim cell = map.GetCell(KombiniLocation.column, KombiniLocation.row)
        cell.SetName("Kombini")
        cell.Metadata(Metadatas.MoveToText) = "Go to Kombini"
        cell.Flag(FlagTypes.Kombini) = True
        Return cell
    End Function

    Private Function InitializeApartment(map As IMap) As ICell
        Dim cell = map.GetCell(ApartmentLocation.column, ApartmentLocation.row)
        cell.SetName("Gorachan's Apartment")
        cell.Metadata(Metadatas.MoveToText) = "Return to Gorachan's Apartment"
        cell.Flag(FlagTypes.KnownLocation) = True
        Return cell
    End Function

    Private Sub InitializeGorachan(world As IWorld, cell As ICell)
        Dim gorachan = world.CreateCharacter(CharacterTypes.Gorachan, cell)
        gorachan.SetMetadata(Metadatas.Name, "Gorachan")
        gorachan.SetStatistic(StatisticTypes.MaximumStress, 100)
        gorachan.SetStatistic(StatisticTypes.Stress, 100)
        gorachan.SetStatistic(StatisticTypes.Day, 1)
        AddNap(world, gorachan)
        AddBalconyInspection(world, gorachan)
        gorachan.Cell.AddCharacter(gorachan)
        world.Avatar = gorachan
    End Sub

    Private Sub AddBalconyInspection(world As IWorld, character As ICharacter)
        Dim item = world.CreateItem(ItemTypes.InspectBalcony)
        item.SetMetadata(Metadatas.UsageText, "Inspect Balcony")
        item.SetFlag(FlagTypes.CanBeUsed, True)
        character.AddItem(item)
    End Sub

    Private Sub AddNap(world As IWorld, character As ICharacter)
        Dim item = world.CreateItem(ItemTypes.Nap)
        item.SetMetadata(Metadatas.UsageText, "Take a nap!")
        item.SetFlag(FlagTypes.CanBeUsed, True)
        character.AddItem(item)
    End Sub
End Module
