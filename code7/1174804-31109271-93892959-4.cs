    Any(x => x.Parent, typeof(int), m =>
    {
        m.IdType<int>();
        m.MetaType<int>();
        m.MetaValue(1, typeof(Parent1));
        m.MetaValue(2, typeof(Parent2));
     
        m.Columns(
          id => id.Name("SourceId"), 
          classRef => classRef.Name("SourceTable"));
    });
