    public static int ToInt(this Enum e)
    {
        return (int)e;
    }
    enum SomeEnum
    {
        Val1 = 1,
        Val2 = 2,
        Val3 = 3,
    }
    
    int intVal = SomeEnum.ToInt();
