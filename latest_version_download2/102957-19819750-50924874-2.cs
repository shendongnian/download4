    // method definition...
    T ExecuteInTryCatch<T>(Func<T> block)
    {
        try
        {
            return block();
        }
        catch (SomeException e)
        {
            // handle e
        }
    }
    // using the method...
    int three = ExecuteInTryCatch(() => { return 3; })
