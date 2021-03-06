    static class extentions
    {
        public static List<Variance> DetailedCompare<T>(this T val1, T val2)
        {
            List<Variance> variances = new List<Variance>();
            FieldInfo[] fi = val1.GetType().GetFields();
            foreach (FieldInfo f in fi)
            {
                Variance v = new Variance();
                v.Prop = p.Name;
                v.valA = f.GetValue(val1);
                v.valB = f.GetValue(val2);
                if (!v.valA.Equals(v.valB))
                    variances.Add(v);
            }
            return variances;
        }
    }
    class Variance
    {
        string _prop;
        public string Prop
        {
            get { return _prop; }
            set { _prop = value; }
        }
        object _valA;
        public object valA
        {
            get { return _valA; }
            set { _valA = value; }
        }
        object _valB;
        public object valB
        {
            get { return _valB; }
            set { _valB = value; }
        }
    }
