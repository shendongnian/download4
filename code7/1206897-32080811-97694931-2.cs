    TextRange range = new TextRange(rt.Document.ContentStart, rt.Document.ContentEnd);
    MemoryStream stream = new MemoryStream();
    range.Save(stream, DataFormats.Xaml);
    string xamlText = Encoding.UTF8.GetString(stream.ToArray());
    return xamlText;
