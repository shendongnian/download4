    public IEnumerable<BaseClass> AllIsSelected(BaseClass root)
    {
        if (root.IsSelected)
        {
            yield return root;
        }
        var composite = root as DerivedOne;
        if (composite != null)
        {
            foreach (var v in composite.Children)
            {
                foreach (var x in AllIsSelected(v))
                {
                    yield return x;
                }
            }
        }
    }
