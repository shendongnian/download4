    public static class DataTableToListHelper
        {      
        public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();
                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();
                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    list.Add(obj);
                }
                return list;
            }
            catch (Exception ex)
            {                
                return null;
            }
        }
    }
    DataTable dt = new DataTable();
    connection.Open();
    adapter.Fill(dt);
    connection.Close();
    var entityObjectList = dt.DataTableToList<YOURENTITY>();
