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
            Dim actual = subject.UpdateStatus(Sub(x) counter += 1)
            counter.ShouldBeGreaterThan(0)
            actual.ShouldNotBeNull
            actual.ShouldNotBeEmpty
        End Sub
        <Fact>
        Sub save_game()
            Dim subject = CreateSubject()
            subject.StartWorld()
            subject.Save().ShouldNotBeNull
        End Sub
        <Fact>
        Sub load_game()
            Dim subject = CreateSubject()
            subject.Load("{}").ShouldBeTrue
            subject.HasWorld.ShouldBeTrue
        End Sub
    End Class
End Namespace

