    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace YourProjectName
    {
    public class Employee
    {
        public string firstName;
        public string lastName;
        public string region;
        public Position position;
        public List<double> goals;
        public List<double> tests;
        public double correlation;
        public Employee supervisor;
        public String GetFirstName() { return firstName; }
        public String GetLastName() { return lastName; }
        public String GetRegion() { return region; }
        /*You can increase get method to connect your variables.*/
    }
  
     */*Above class like .net mvc model classes.*/*
        using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Linq;
        using System.Text;
        
        namespace YourProjectName
        {
        public partial class Form 
        {
            private List<Employee> employees{ get; set; }
        
            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                txtTitleBox.Text = comboBox1.SelectedItem.ToString();
            }
        
            public List<Employee> LoadCombobox()
            {
                    List<Employee> employees= new List<Employee>(); 
                    var employeeList = correlation.ComputeCorrelation();
                    var bSource = new BindingSource();
                    bSource.DataSource = employeeList;
                    employees.Add(bSource.DataSource);
                    return employees;
            }
        
            private void LoadYourCombobox_1(object sender, EventArgs e)
            {
              employees= LoadCombobox();
              foreach (Employee employee in employees)
                {
                    comboBox1.Items.Add(employees.GetFirstName());
                }
            }
        }
        }
