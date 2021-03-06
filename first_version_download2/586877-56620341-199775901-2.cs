csharp
public class Department
{
    private int _departmentId { get; set; }
    public string DepartmentName { get; set; }
    private ICollection<Employee> _employees { get; set; }
}
public class Employee
{
    private int _employeeId { get; set; }
    public Department Department;
}
and now in your `DbContext` class
csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Department>().HasKey("_departmentId");
    modelBuilder.Entity<Department>().Property<int>("_departmentId");
    modelBuilder.Entity<Department>(c =>
        c.HasMany(typeof(Employee), "_employees")
            .WithOne("Department")
    );
    modelBuilder.Entity<Employee>().HasKey("_employeeId");
    base.OnModelCreating(modelBuilder);
}
I have tried this code and it works.
