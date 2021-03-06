    class ViewModelLocator 
        { 
        static ViewModelLocator() 
        {         
        ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);          
        if (ViewModelBase.IsInDesignModeStatic) 
        {              
        SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();          
        }          
        else         
        {              
        SimpleIoc.Default.Register<IDataService, DataService>();          
        }          
        SimpleIoc.Default.Register<MainViewModel>();                  
        SimpleIoc.Default.Register<SecondViewModel>(); 
        }      
        
        
        public MainViewModel MainAsSingleton
        {  
        get  
        {      
        return ServiceLocator.Current.GetInstance<MainViewModel>();  
        } 
        } 
        public MainViewModel MainAsDiffrentInstanceEachTime
        {
        get  
        {      
        return ServiceLocator.Current.GetInstance<MainViewModel>(Guid.NewGuid().ToString());  
        } 
        }
