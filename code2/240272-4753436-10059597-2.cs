    Assembly^ SampleAssembly;
    // Instantiate a target object.
    Int32 Integer1(0);
    Type^ Type1;
    // Set the Type instance to the target class type.
    Type1 = Integer1.GetType();
    // Instantiate an Assembly class to the assembly housing the Integer type.  
    SampleAssembly = Assembly::GetAssembly( Integer1.GetType() );
    // Gets the location of the assembly using file: protocol.
    Console::WriteLine( "CodeBase= {0}", SampleAssembly->CodeBase );
