    public int getEmployeeID(string empName)
    {
        LinqToSqlDataContext database = new LinqToSqlDataContext();
        return database.Persons
           .Where(emp => emp.personName.Contains(empName))
           .Single().Id;
        //return the ID of the person which carries the textbox's name
    }
