    static class EnumerableDuplicateExtensions
	{
		public static bool IsUnique<T>(this IEnumerable<T> that)
		{
			return that.All( new HashSet<T>().Add );
		}
	}
