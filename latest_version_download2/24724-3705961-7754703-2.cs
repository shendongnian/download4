    public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
                                                TKey key, Func<TValue> valueCreator)
    {
        TValue value;
        if (!dictionary.TryGetValue(key, out value))
        {
            value = valueCreator();
            dictionary.Add(key, value);
        }
        return value;
    }
    public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
                                                TKey key) where TValue : new()
    {
       return dictionary.GetOrAdd(key, () => new TValue());
    }
