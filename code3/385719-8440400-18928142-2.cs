    class Data
    {
    private int var;
    
    public Data( int v ) { var = v; }
    
    public int Var
    {  
    get: return var;
    set: var = value;
    }
    
    Main( )
    {
    Data d = new Data( 10 );
    d.Var++;
    }
    }
