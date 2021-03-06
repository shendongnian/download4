    [Test]
    public void Constructor_Always_Succeeds()
    {
        var mockOfB = new Mock<B>();
        var mockOfA = mockOfB.As<A>();
        DateTime aTime = DateTime.Now;
        DateTime bTime = DateTime.Now.AddDays(-1);
        // only difference, these two lines are swapped
        mockOfB.SetupGet(p => p.DateCreated).Returns(bTime);
        mockOfA.SetupGet(p => p.DateCreated).Returns(aTime);
        B b = mockOfB.Object;
        A a = b;
        Assert.That(b.DateCreated, Is.EqualTo(bTime));
        Assert.That(a.DateCreated, Is.EqualTo(aTime));
    }
