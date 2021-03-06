        public class Employee  
    {  
        public int EmployeeId { get; set; }  
        public string EmployeeFName { get; set; }  
        public string EmployeeLName { get; set; }  
        public string Address { get; set; }  
        public string City { get; set; }  
        public string State { get; set; }  
        public string Zip { get; set; }  
        public DateTime? DateOfJoining { get; set; }    
    }
	
	public class User  
    {  
        public int Userid { get; set; }  
        public string UserFName { get; set; }  
        public string UserLName { get; set; }  
        public string Address { get; set; }  
        public string City { get; set; }  
        public string State { get; set; }  
        public string Zip { get; set; }  
        public DateTime? DateOfJoining { get; set; }  
         
    }  
	
	Employee objEmployee = new Employee  
     {  
        EmployeeId = 1001,  
        EmployeeFName = "Manish",  
        EmployeeLName = "Kumar",  
        Address = "JAIPUR",  
        City = "JAIPUR",  
        State = "RAJASTHAN",  
        Zip = "302004",  
        DateOfJoining = DateTime.Now,  
     };  
  
