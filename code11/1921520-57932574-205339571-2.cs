	public static IEnumerable<TResult> FullOuterJoin<TA, TB, TKey, TResult>(
		this IEnumerable<TA> a,
		IEnumerable<TB> b,
		Func<TA, TKey> selectKeyA,
		Func<TB, TKey> selectKeyB,
		Func<TA, TB, TKey, TResult> projection,
		TA defaultA = default(TA),
		TB defaultB = default(TB),
		IEqualityComparer<TKey> cmp = null)
	{
		cmp = cmp ?? EqualityComparer<TKey>.Default;
		var alookup = a.ToLookup(selectKeyA, cmp);
		var blookup = b.ToLookup(selectKeyB, cmp);
		var keys = new HashSet<TKey>(alookup.Select(p => p.Key), cmp);
		keys.UnionWith(blookup.Select(p => p.Key));
		var join = from key in keys
				   from xa in alookup[key].DefaultIfEmpty(defaultA)
				   from xb in blookup[key].DefaultIfEmpty(defaultB)
				   select projection(xa, xb, key);
		return join;
	}
    IEnumerable<System.IO.FileInfo> filesA = dirA.GetFiles(".", System.IO.SearchOption.AllDirectories); 
    IEnumerable<System.IO.FileInfo> filesB = dirB.GetFiles(".", System.IO.SearchOption.AllDirectories); 
    var files = filesA.FullOuterJoin(
        filesB,
        f => $"{f.FullName.Replace(dirA.FullName, string.Empty)}",
        f => $"{f.FullName.Replace(dirB.FullName, string.Empty)}",
        (fa, fb, n) => new {fa, fb, n}
    );
    var filesOnlyInA = files.Where(p => p.fb == null);
    var filesOnlyInB = files.Where(p => p.fa == null);
    // Define IsMatch - the filenames already match, but consider other things too
    // In this example, I compare the filesizes, but you can define any comparison
    Func<FileInfo, FileInfo, bool> IsMatch = (a,b) => a.Length == b.Length;
    var matchingFiles = files.Where(p => p.fa != null && p.fb != null && IsMatch(p.fa, p.fb));
    var diffFiles = files.Where(p => p.fa != null && p.fb != null && !IsMatch(p.fa, p.fb));
    //   Iterate and copy/delete as appropriate
      
