    [Flags]
    public enum ABC {
       a = 1,
       b = 2,
       c = 4
    };
    public IEnumerable<ABC> Getselected (ABC flags)
    {
       var values = flags.ToString().Split(',');
       var enums = values.Select(x => (ABC)Enum.Parse(typeof(ABC), x.Trim()));
       return enums;
    }
    ABC temp= ABC.a | ABC.b;
    var list = getSelected (temp);
    foreach (var item in list)
    {
       Console.WriteLine(item.ToString() + " ID=" + (int)item);
    }
