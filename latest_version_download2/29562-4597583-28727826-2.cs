    // Create an enumeration of the distinct values of Prop1
    var propertyCollection = objectCollection.Select(o => o.Prop1).Distinct();
    // If the property collection has the same number of entries as the object
    // collection, then all properties are distinct. Otherwise there are some
    // duplicates.
    return propertyCollection.Count() == objectCollection.Count();
