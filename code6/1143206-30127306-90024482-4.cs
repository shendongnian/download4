    public static int Countlist<T>(List<T> list)
    {
        int listcount = 0;
        for (int i = 0; i < list.Count; i++)
        {
            listcount++;
        }
        return listcount;
    }
