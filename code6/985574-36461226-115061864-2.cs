     static void Main(string[] args)
        {
            Dictionary<int, Employee> employeeMap = new Dictionary<int, Employee>();
            Employee ceo = null, firstEmployee = null, secondEmployee = null;
            /*//Sample input
             List<string> input = new List<string>();
             input.Add("employee 1 A");
             input.Add("employee 2 B");
             input.Add("employee 3 C");
             input.Add("employee 4 D");
             input.Add("employee 5 E");
             input.Add("employee 6 F");
             input.Add("employee 7 G");
             input.Add("employee 8 H");
             input.Add("employee 9 I");
             input.Add("employee 10 J");
             input.Add("employee 11 K");
             input.Add("employee 12 L");
             input.Add("employee 13 M");
             input.Add("report 1 2");
             input.Add("report 1 3");
             input.Add("report 2 4");
             input.Add("report 2 5");
             input.Add("report 2 6");
             input.Add("report 5 7");
             input.Add("report 5 8");
             input.Add("report 6 9");
             input.Add("report 6 10");
             input.Add("report 3 11");
             input.Add("report 3 12");
             input.Add("report 3 13");
             input.Add("params 1 9 13");*/
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                string[] tokens = line.Split();
                string type = tokens[0];
                if (type.Equals("employee"))
                {
                    int id = int.Parse(tokens[1]);
                    String name = tokens[2];
                    employeeMap.Add(id, new Employee(id, name));
                }
                else if (type.Equals("report"))
                {
                    Employee manager = employeeMap[int.Parse(tokens[1])];
                    Employee report = employeeMap[int.Parse(tokens[2])];
                    manager.addReport(report);
                }
                else if (type.Equals("params"))
                {
                    ceo = employeeMap[int.Parse(tokens[1])];
                    firstEmployee = employeeMap[int.Parse(tokens[2])];
                    secondEmployee = employeeMap[int.Parse(tokens[3])];
                }
                else
                {
                    // ignore comments and whitespace
                }
            }
            Employee result = closestCommonManager(ceo, firstEmployee, secondEmployee);
        } 
    public static Employee closestCommonManager(Employee ceo, Employee firstEmployee, Employee secondEmployee)
        {
            Stack<Employee> firstManagers = new Stack<Employee>();
            Stack<Employee> secondManagers = new Stack<Employee>();
            if (ceo.getReports().Count > 0)
            {
                searchManager(ceo, firstEmployee, firstManagers);
                searchManager(ceo, secondEmployee, secondManagers);
                if (firstManagers.Contains(secondEmployee))
                {
                    return secondEmployee; //closest manager as this is managing the first one
                }
                if (secondManagers.Contains(firstEmployee))
                {
                    return firstEmployee; //closest manager as this is managing the second one
                }
                //check for closest match
                //make them equal in length.
                while (firstManagers.Count > secondManagers.Count)
                {
                    firstManagers.Pop();
                }
                while (secondManagers.Count > firstManagers.Count)
                {
                    secondManagers.Pop();
                }
                int checkCount = firstManagers.Count;
                for (int i = 0; i < checkCount; i++)
                {
                    if (firstManagers.Peek().getId() == secondManagers.Peek().getId())
                    {
                        return firstManagers.Pop();
                    }
                    else
                    {
                        firstManagers.Pop();
                        secondManagers.Pop();
                    }
                }
            }
            return null;
        }
        private static bool searchManager(Employee manager, Employee emp, Stack<Employee> graph)
        {
            bool res = false;
            graph.Push(manager);
            foreach (Employee e in manager.getReports())
            {
                if (e.getId() == emp.getId())
                {
                    res = true;
                    break;
                }
                else
                {
                    if (e.getReports().Count > 0)
                    {
                        if (searchManager(e, emp, graph))
                        {
                            return true;
                        }
                        else
                        {
                            graph.Pop();
                        }
                    }
                }
            }
            return res;
        }
     public sealed class Employee
    {
        private readonly int id;
        private readonly string name;
        private readonly List<Employee> reports;
        public Employee(int id, string name)
        {
            this.id = id;
            this.name = name;
            this.reports = new List<Employee>();
        }
        /// <returns> 
        /// an integer ID for this employee, guaranteed to be unique.
        /// </returns> 
        public int getId()
        {
            return id;
        }
        /// <returns> 
        /// a String name for this employee, NOT guaranteed to be unique.
        /// </returns> 
        public string getName()
        {
            return name;
        }
        /// <returns> 
        /// a List of employees which report to this employee.  This list may be empty, but will
        /// never be null.
        /// </returns> 
        public IList<Employee> getReports()
        {
            return reports;
        }
        /// <summary> 
        /// Adds the provided employee as a report of this employee. 
        /// </summary> 
        public void addReport(Employee employee)
        {
            reports.Add(employee);
        }
    }
