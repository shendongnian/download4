    static string Invoker()
    {
        string result;
        using (Animal a = new Animal())
        {
            result = a.Greeting();
            goto end;
            // a return here is like a "goto end"
            // done after invoking the Dispose()
            // while exiting the using block
        }
        // others things
        return;
        end:
          return result;
    }
