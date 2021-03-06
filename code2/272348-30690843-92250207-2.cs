      private void webBrowser1_LoadCompleted(object sender, NavigationEventArgs e)
    {
        Object doc = webBrowser1.Document;
        this.Title = GetPropertyValue<string>(doc, "IHTMLDocument2_nameProp");
    }
    
    private T GetPropertyValue<T>(object obj, string propertyName)
    {
        Type objectType = obj.GetType(); 
        PropertyInfo propertyInfo = objectType.GetProperty(propertyName);
        Type propertyType = propertyInfo.PropertyType;
        if(propertyType == typeof(T))
        {
            object alue = (T)propertyInfo.GetValue(obj, null);   
            return value;
        }
        else
        {
            throw new Exception("Property " + propertyName + " is not of type " + T);
        }
    }
