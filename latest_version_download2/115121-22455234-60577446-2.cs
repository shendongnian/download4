    public void CallOtherMethod(Action method)
    {
        string methodName = method.Method.Name;
        method.Invoke();
    }
     public void AnotherMethod(string foo, string bar)
    {
        // Do Something
    }
