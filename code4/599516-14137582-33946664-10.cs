    Assert.That(typeof(DeriviedLeft).FindEqualTypeWith(typeof(DeriviedLeft)), Is.SameAs(typeof(DeriviedLeft)));
    Assert.That(typeof(DeriviedLeft).FindEqualTypeWith(typeof(SubDeriviedLeft)), Is.EqualTo(typeof(DeriviedLeft)));
    Assert.That(typeof(DeriviedLeft).FindEqualTypeWith(typeof(DeriviedRight)), Is.EqualTo(typeof(IDerivied)));
    Assert.That(typeof(DeriviedLeft).FindEqualTypeWith(typeof(object)), Is.Null);
    Assert.That(typeof(DeriviedLeft).FindEqualTypeWith(typeof(Another)), Is.Null);
    Assert.That(typeof(DeriviedLeft).FindEqualTypeWith(typeof(AnotherDisposable)), Is.EqualTo(typeof(IDisposable)));
    Assert.That(typeof(SubDeriviedLeft).FindEqualTypeWith(typeof(DeriviedRight)), Is.EqualTo(typeof(IDerivied)));
    Assert.That(typeof(SubDeriviedLeft).FindEqualTypeWith(typeof(SecondSubDeriviedLeft)), Is.EqualTo(typeof(DeriviedLeft)));
    Assert.That(typeof(SubDeriviedLeft).FindEqualTypeWith(typeof(ThirdSubDeriviedLeft)), Is.EqualTo(typeof(DeriviedLeft)));
    Assert.That(typeof(DeriviedRight).FindEqualTypeWith(typeof(DeriviedRight)), Is.EqualTo(typeof(DeriviedRight)));
    Assert.That(typeof(DeriviedRight).FindEqualTypeWith(typeof(DeriviedLeft)), Is.EqualTo(typeof(IDerivied)));
    Assert.That(typeof(object).FindEqualTypeWith(typeof(object)), Is.Null);
    Assert.That(typeof(object).FindEqualTypeWith(null), Is.Null);
    
    Assert.That(typeof(List<string>).FindEqualTypeWith(typeof(HashSet<string>)), Is.SameAs(typeof(ICollection<string>)));
    Assert.That(typeof(List<string>).FindEqualTypeWith(typeof(LinkedList<string>)), Is.SameAs(typeof(ICollection<string>)));
    Assert.That(typeof(string[]).FindEqualTypeWith(typeof(LinkedList<string>)), Is.SameAs(typeof(ICollection)));
    Assert.That(typeof(string[]).FindEqualTypeWith(typeof(string)), Is.SameAs(typeof(ICloneable)));
    Assert.That(typeof(int).FindEqualTypeWith(typeof(string)), Is.SameAs(typeof(IComparable)));
