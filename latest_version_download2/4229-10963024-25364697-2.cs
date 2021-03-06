        public static string ToStringNullSafe(this object obj)
        {
            return obj != null ? obj.ToString() : String.Empty;
        }
        public static bool Compare<T>(T a, T b)
        {
            int count = a.GetType().GetProperties().Count();
            string aa, bb;
            for (int i = 0; i < count; i++)
            {
                aa = a.GetType().GetProperties()[i].GetValue(a, null).ToStringNullSafe();
                bb = b.GetType().GetProperties()[i].GetValue(b, null).ToStringNullSafe();
                if (aa != bb)
                {
                    return false;
                }
            }
            return true;
        }
