    class RowEqualityComparer : IEqualityComparer<string[]>
    {
        public bool Equals(string[] first, string[] second)
        {
            // different legths - different rows
            if (first.Length != second.Length)
              return false;
            //we need to copy the arrays because Array.Sort 
            //will change the original rows
            var flist = first.ToList();
            flist.Sort();
            var slist = second.ToList();
            slist.Sort();
            //loop and compare one by one
            for (int i=0; i < flist.Count; i++)
            {
                if (flist[i]!=slist[i])
                  return false;
            }
            return true;
        }
    
        public int GetHashCode(string[] row)
        {
           //I have no idea what I'm doing, just some generic hash code calculation
           if (row.Length == 0)
             return 0;
           int hash = row[0].GetHashCode();
           for (int i = 1; i < row.Length; i++)
             hash ^= row[i].GetHashCode();
           return hash;
        }
    
    }
