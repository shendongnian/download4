    class ContactList
    {
    string firstName, lastName, eMail, ContactNo;
    //Properties (getters/setters for above attributes/fields
    }
    
    class ContactListHandler
    {
    public List<string> GetFirstNames(string[] contactsText)
    {
    List<string> stringList = new List<string>();
    foreach (string s in contactsText)
    {
    var x = contactsText.split(',');
    stringList.Add(x[0]);
    }
    return stringList;
    }
    //and other functions
    }
