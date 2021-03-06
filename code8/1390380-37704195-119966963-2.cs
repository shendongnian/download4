    public static int MaxSubstringLength(string s)
    {
        if (String.IsNullOrEmpty(s))
            return 0;
        int max = 0;
        int cur = 1;
        for (int i = 1; i < s.Length; ++i)
        {
            if (s[i] != s[i - 1])
            {
                max = cur > max ? cur : max;
                cur = 1;
            }
            else
            {
                ++cur;
            }
        }
        return cur > max ? cur : max; 
    }
