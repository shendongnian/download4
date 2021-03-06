    class ChildItemEqualityComparer : IEqualityComparer<ChildItem>
    {
        public static readonly ChildItemEqualityComparer Instance =
            new ChildItemEqualityComparer();
        private ChildItemEqualityComparer() { }
        public bool Equals(ChildItem x, ChildItem y) =>
            String.Equals(x.ChildItemName, y.ChildItemName);
        public int GetHashCode(ChildItem childItem) =>
            childItem.ChildItemName?.GetHashCode() ?? 0;
    }
