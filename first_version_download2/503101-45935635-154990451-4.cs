    ... 
    public Person() {
       var provider = IoC.Resolve<IReferenceDataProvider>();
       Statuses = provider.GetData(DataType.ClientStatus);
    }
    ...
