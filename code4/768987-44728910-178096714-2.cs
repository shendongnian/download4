    using(var textWriter = new StreamWriter(@"C:\mypath\myfile.csv"))
    {
        var writer = new CsvWriter(textWriter);
        writer.Configuration.Delimiter = ",";
        foreach (var item in list)
        {
            writer.WriteField( "a" );
            writer.WriteField( 2 );
            writer.WriteField( true );
            writer.NextRecord();
        }
    }
