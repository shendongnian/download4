    public class mymodel{
    
    [Required(ErrorMessage="this field is required")]
    public int ID{get;set;}
    public IEnumerable<KeyValuePair<string, string>> _list{get;set}
    }
