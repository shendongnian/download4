    MemoryStream sr = null;
    ParserContext pc = null;
    string xaml = string.Empty;
    xaml = "<DataTemplate><StackPanel><TextBlock Text="{Binding Description"/><CheckBox IsChecked="{Binding IsSelected"/></StackPanel></DataTemplate>";
    sr = new MemoryStream(Encoding.ASCII.GetBytes(xaml));
    pc = new ParserContext();
    pc.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
    pc.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");
    DataTemplate datatemplate = (DataTemplate)XamlReader.Load(sr, pc);
    this.Resources.Add("dt", datatemplate);
