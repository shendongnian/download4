    private static readonly MethodInfo setMethod = typeof(WhateverCIs).GetMember("Set")[0];
    public void Insert(object o)
    {
        var t = o.GetType();
    
        var set = setMethod.MakeGenericMethod(new[] { t });
        (set.Invoke(c) as WhateverSetReturns).Add(o);
    }
