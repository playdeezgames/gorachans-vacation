Public Interface IItem
    Inherits IStatisticsHolder
    Inherits IFlagHolder
    Inherits IMetadataHolder
    ReadOnly Property Id As Integer
    ReadOnly Property ItemType As String
    Sub Recycle()
    ReadOnly Property World As IWorld
End Interface
