    int x = 0;
    public void g()
    {
       bool greaterThan = f(() => x>2);
       bool lessThan = f(() => x<2);
    }
    public bool f(Predicate expression)
    {
       return expression();
    }
