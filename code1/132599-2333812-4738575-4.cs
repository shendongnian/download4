        public class Employee
        {
            public List<Test> test { get; set; }
            public Employee()
            {
                this.test.Add(new Test());
                this.test[0].Name = "Tom";
                this.test[0].age = 13;
            }
        }
