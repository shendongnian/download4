    public MainWindow()
    {
        InitializeComponent();
        List<Person> PLa = new List<Person>();
        List<Person> PLb = new List<Person>();
    
        PLa.Add(new Person { Age = 3, Name = "Jim"});
        PLa.Add(new Person { Age = 2, Name = "Jimmmy" });
        PLa.Add(new Person { Age = 1, Name = "Jim" });
    
        PLb.Add(new Person { Age = 1, Name = "Jim" });
        PLb.Add(new Person { Age = 3, Name = "Jim" });
        PLb.Add(new Person { Age = 2, Name = "Jimmmy" });
    
        System.Diagnostics.Debug.WriteLine(ListSameIgnoreOrder(PLa, PLb));
    
    }
    
    public bool ListSameIgnoreOrder(List<Person> PLa, List<Person> PLb)
    {
        if (PLa.Count != PLb.Count) return false;
        return Enumerable.SequenceEqual(PLa.OrderBy(s => s), PLb.OrderBy(s => s));
        //also test brute force
        //PLa.Sort();
        //PLb.Sort();
        //for (int i = 0; i < PLa.Count; i++)
        //{
        //    System.Diagnostics.Debug.WriteLine(
        //        PLa[i].Age.ToString() + " " + PLb[i].Age.ToString() + " " +
        //        PLa[i].Name + " " + PLb[i].Name);
        //    if (!PLa[i].Equals(PLb[i])) return false;
        //}
        //return true;
    }
    
    public class Person : object, IComparable
    {
        private int age = 0;
        private string name = string.Empty;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    
        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if (obj == null || !(obj is Person)) return false;
            Person f = (Person)obj;
            if (f.Age != this.Age) return false;
            return (string.Compare(f.name, this.name) == 0);
        }
    
        public override int GetHashCode()
        {
            return age ^ name.GetHashCode();
        }
    
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
    
            Person otherPerson = obj as Person;
            if (otherPerson != null)
            {
                if (otherPerson.Age > this.Age) return -1;
                if (otherPerson.Age < this.Age) return 1;
                // compare all properties like above
                return string.Compare(otherPerson.name, this.name);
            }
            else
                throw new ArgumentException("Object is not a Person");
        }
    }
