    [Test]
    public void FooPerformance_Bait()
    {
        Assert.That(Time(()=>fooer.Foo()), Is.LessThanOrEqualTo(TimeSpan.FromSeconds(0));
    }
