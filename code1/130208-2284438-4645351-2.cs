    FlowDocument doc = new FlowDocument();
    Paragraph par = new Paragraph();
    doc.Blocks.Add( par );
    Run r;
    r = new Run( "This is " );
    par.Inlines.Add( r );
    r = new Run( "bold" );
    r.FontWeight = FontWeights.Bold;
    par.Inlines.Add( r );
    r = new Run( " and this is " );
    par.Inlines.Add( r );
    r = new Run( "italic" );
    r.FontStyle = FontStyles.Italic;
    par.Inlines.Add( r );
    r = new Run( " text." );
    par.Inlines.Add( r );
