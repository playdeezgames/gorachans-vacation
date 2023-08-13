Namespace GV.Business.Tests
    Public Class WorldModel_should
        Private Function CreateSubject() As IWorldModel
            Return New WorldModel()
        End Function
        <Fact>
        Sub check_world_status()
            Dim subject = CreateSubject()
            subject.HasWorld.ShouldBe(False)
        End Sub
    End Class
End Namespace

