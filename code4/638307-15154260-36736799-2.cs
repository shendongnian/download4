    public static class Extensions
    {
        public static T RemoveAndGet(this List<T> list, int index)
        {
            lock(list)
            {
                T value = list[index];
                list.RemoveAt(index);
                return value;
            }
        }
    }
