    public static IEnumerable<IEnumerable<T>> QuickPerm<T>(this IEnumerable<T> set)
    {
        int N = set.Count();
        int[] a = new int[N];
        int[] p = new int[N];
        List<T> list = new List<T>(set);
        int i, j, tmp; // Upper Index i; Lower Index j
        for (i = 0; i < N; i++)
        {
            // initialize arrays; a[N] can be any type
            a[i] = i + 1; // a[i] value is not revealed and can be arbitrary
            p[i] = 0; // p[i] == i controls iteration and index boundaries for i
        }
        yield return list;
        i = 1; // setup first swap points to be 1 and 0 respectively (i & j)
        while (i < N)
        {
            if (p[i] < i)
            {
                j = i%2*p[i]; // IF i is odd then j = p[i] otherwise j = 0
                tmp = a[j]; // swap(a[j], a[i])
                a[j] = a[i];
                a[i] = tmp;
                //MAIN!
                var yieldRet = new T[N];
                for (int x = 0; x < N; x++)
                {
                    yieldRet[x] = list[a[x]-1];
                }
                yield return yieldRet;
                // MAIN!
                p[i]++; // increase index "weight" for i by one
                i = 1; // reset index i to 1 (assumed)
            }
            else
            {
                // otherwise p[i] == i
                p[i] = 0; // reset p[i] to zero
                i++; // set new index value for i (increase by one)
            } // if (p[i] < i)
        } // while(i < N)
    }
