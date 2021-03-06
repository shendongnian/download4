    [Test]
    public void Should_Update_Person_When_Name_Is_Correct()
    {
        // Arrange        
        var timeProviderMock = new Mock<ITimeProvider>();
        var time = DateTime.Now;
        timeProviderMock.Setup(tp => tp.GetCurrentTime()).Returns(time);
        var p = new Person(timeProviderMock.Object); // person is a real class
        // Act 
        p.Update("John", "Lennon");
        // Assert
        p.FirstName.Should().Be("John");
        p.LastName.Should().Be("Lennon");
        p.ModifiedDate.Should().Be(time); // verify that correct date was set
        timeProviderMock.VerifyAll();
    }
