﻿Friend Module ItemTypes
    Friend Const Nap = "Nap"
    Friend Const PlayVideoGames = "PlayVideoGames"
    Friend Const InspectBalcony = "InspectBalcony"
    Friend Const BuyDurries = "BuyDurries"
    Private ReadOnly descriptors As IReadOnlyDictionary(Of String, ItemTypeDescriptor) =
        New Dictionary(Of String, ItemTypeDescriptor) From
        {
            {Nap, New NapDescriptor()},
            {PlayVideoGames, New PlayVideoGamesDescriptor()},
            {InspectBalcony, New InspectBalconyDescriptor()},
            {BuyDurries, New BuyDurriesDescriptor()}
        }
    Friend Function ToDescriptor(itemType As String) As ItemTypeDescriptor
        Return descriptors(itemType)
    End Function
End Module
