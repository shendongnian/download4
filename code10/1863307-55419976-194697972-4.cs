    public void SomeMethod(SomeType someArgument)
    {
        if (someArgument == null)
            throw new ArgumentNullException(nameof(someArgument));
        //you will never get there if someArgument is null...
        var someThing = someArgument.SomeMember;
    }
