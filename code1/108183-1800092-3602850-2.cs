    YourDataContext db = new YourDataContext();
    Table1 account = new Table1();
    db.Table1s.InsertOnSubmit(account);
    Table2 person = new Table2();
    db.Table2s.InsertOnSubmit(person);
    Table3 link = new Table3();
    link.Account = account;
    link.Person = person;
    db.Table3s.InsertOnSubmit(link);
    db.SubmitChanges();
