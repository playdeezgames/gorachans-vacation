Namespace GV.Business.Tests
    Public Class WorldModel_should
        Private Function CreateSubject() As IWorldModel
            Return New WorldModel()
        End Function
        <Fact>
        Sub check_world_status()
            Dim subject = CreateSubject()
            subject.HasWorld.ShouldBeFalse()
        End Sub
        <Fact>
        Sub start_world()
            Dim subject = CreateSubject()
            subject.StartWorld()
            subject.HasWorld.ShouldBeTrue()
        End Sub
        <Fact>
        Sub abandon_world()
            Dim subject = CreateSubject()
            subject.StartWorld()
            subject.HasWorld.ShouldBeTrue()
            subject.AbandonWorld()
            subject.HasWorld.ShouldBeFalse()
        End Sub
        <Fact>
        Sub update_status()
            Dim subject = CreateSubject()
            Dim counter = 0
            subject.StartWorld()
            subject.UpdateStatus(Sub(x) counter += 1)
            counter.ShouldBeGreaterThan(0)
        End Sub
    End Class
End Namespace

