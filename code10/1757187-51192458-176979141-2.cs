    //Here you have the grid
    Grid element = (UIElement)XamlReader.Parse(xaml, context);
    //Now try to get the button
    Button btn = element.FindName("BtnEditAc");
    if(btn != null)
    {
        btn.Click  += new RoutedEventHandler(Onb2Click);
    }
