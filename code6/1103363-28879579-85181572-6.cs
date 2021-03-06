    public void Main()
    {
      try
      {
        throw new Exception("Forced Exception");
      }
      catch (Exception ex) if (MethodThatThrowsAnException())
      {
        Console.WriteLine("Filtered handler 1");
      }
      catch (Exception ex) if (MethodThatThrowsAnException2())
      {
        Console.WriteLine("Filtered handler 2");
        Console.WriteLine(ex.GetType().Name);
      }
    }
    
    private bool MethodThatThrowsAnException()
    {
      throw new NotImplementedException();   
    }
    
    private bool MethodThatThrowsAnException2()
    {
      throw new NotSupportedException();   
    }
