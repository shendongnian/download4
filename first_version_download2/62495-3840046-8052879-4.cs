    static void Main(string[] args)
    {
        Command = Enum.Parse(typeof(Commnads), args[0]);
        switch(Command)
        {
            case Commands.CommandOne: 
                //do something 
                break;
            case Commands.CommandTwo: 
                //do something else
                break;
            ...
            default:
                // default stuff
        }
    }
