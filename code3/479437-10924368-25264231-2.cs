    List<ColorItem> solidColorBrushList = new List<ColorItem>();
    
    PropertyInfo[] colorProperties = typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
    foreach (PropertyInfo colorProperty in colorProperties)
    {
    	if (colorProperty.PropertyType == typeof(Color))
    	{
    		Color color = (Color)colorProperty.GetValue(null, null);
    		string colorName = colorPropertyName;
    		SolidColorBrush brush = new SolidColorBrush(color);
    		
    		ColorItem item = new ColorItem() { Brush = brush, Name = colorName };
    		solidColorBrushList.Add(item);
    	}
    }
