            int[] intarr = { 1, 2, 3, 4, 5, 6 };
            char[] chrarr = { 'a', 'b', 'c', 'd', 'e' };
            ArrayList alist = new ArrayList();
            for (int j = 0; j < (chrarr.Length - 1); j++)
            {
                for (int i = 0; i < (intarr.Length - 1); i++)
                {
                    alist.Add(intarr[i] + "." + chrarr[j]);
                }
            }
              alist.Sort();
            foreach (string str in alist)
            {
                Console.WriteLine(str);
            }
