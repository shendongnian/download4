      public List<SelectListItem> CustomerList {get; set}
      public string Customer {get; set}
    
      public SimpleViewModel(){
          CustomerList  = new List<SelectListItem>();
          Customer  = "USA"; //default value.
    }
