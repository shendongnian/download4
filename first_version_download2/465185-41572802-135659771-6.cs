    var DLL = default(Assembly);
    DLL = Assembly.Load(String.Format("Oracle.DataAccess, Version={0}.{1}.*.*, Culture=neutral, PublicKeyToken=89b483f429c47342", 1, 112));
    var type = DLL.GetType("Oracle.DataAccess.Client.OracleConnection", true, false);
    using ( dynamic con = Activator.CreateInstance(type, connString) ) {
        con.Open();
        ...
     }
