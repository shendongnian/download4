    public static void CallQQ(object o)
    {
        var qq = o.GetType().GetMethod("QQ", Type.EmptyTypes, null);
        if (qq != null)
            qq.Invoke(o, new object[] { });
        else
            throw new InvalidOperationException("method not found");
    }
