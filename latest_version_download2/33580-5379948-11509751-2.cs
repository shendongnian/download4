    public static IEnumerable<T> MergeWithRatio<T>(this IEnumerable<T> source, IEnumerable<T> mergeSequence, int ratio)
    {
        int currentRatio  = 1;
        bool mergeSequenceIsEmpty = !mergeSequence.Any();
        using (var mergeEnumerator = mergeSequence.GetEnumerator())
        {
            foreach (var item in source)
            {
                yield return item;
                currentRatio++;
                if (currentRatio == ratio &&  !mergeSequenceIsEmpty)
                {
                    if (!mergeEnumerator.MoveNext())
                    {
                        mergeEnumerator.Reset();
                        mergeEnumerator.MoveNext();
                    }
                    yield return mergeEnumerator.Current;
                    currentRatio = 1;
                }
            }
        }
    }
