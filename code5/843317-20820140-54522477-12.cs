    public static void CheckAllPropertiesAreNotNull<T>(this T objectToInspect, params Expression<Func<T, object>>[] getters)
    {
        var defaultProperties = getters.Where(getter => getter.Compile()(objectToInspect).IsDefault());
        if (defaultProperties.Any())
        {
            var commaSeparatedPropertiesNames = string.Join(", ", defaultProperties.Select(GetName));
            Assert.Fail("expected properties not to be null: " + commaSeparatedPropertiesNames);
        }
    }
