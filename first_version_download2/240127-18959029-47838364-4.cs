    public class CreateDepartmentViewModel : ViewModelBase
    {
    private IDepartmentService departmentService;
    public RelayCommand CreateDepartmentCommand { get; private set; }
    public CreateDepartmentViewModel(IDepartmentService DepartmentService)
    {
        departmentService = DepartmentService;
        this.CreateDepartmentCommand = new RelayCommand(CreateDepartment, CanExecute);
    }
    private Department _department = new Department();
    public Department Department
    {
        get
        {
            return _department;
        }
        set
        {
            if (_department == value)
            {
                return;
            }
            _department = value;
            RaisePropertyChanged("Department");
        }
    }
    private Boolean CanExecute()
    {
        return this.Department.IsValid();
    }
    private void CreateDepartment()
    {
        bool success = departmentService.SaveDepartment(_department);
    }
}
