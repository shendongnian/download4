    static void Main(string[] args)
        {
            string[] ints = new string[] { "7778", "9875", "8347", "8", "83248" };
            string currentInt;
            int counter = 0;
            for (int intCnt = 0; intCnt < ints.Length; intCnt++)
            {
                currentInt = ints[intCnt];
                if (currentInt.Length == 4)
                {
                    char[] charArr = currentInt.Select(c => c).ToArray();
                    char[] charDistinct = charArr.Distinct().ToArray();
                    if (charDistinct.Length == 4)
                    {
                        counter++;
                    }
                }
            }
        }
