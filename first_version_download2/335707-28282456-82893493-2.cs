    Button b = new Button();
    b.Content = "Table 1";
    Grid.SetColumn(b, 1);
    b.Click += button_Click;
    b.CommandParameter = 1;
    b.HorizontalAlignment = HorizontalAlignment.Left;
    b.Margin = new Thickness(34, 31, 0, 0);
    Grid.SetRowSpan(b, 2);
    b.VerticalAlignment = VerticalAlignment.Top;
    b.Width = 118;
    b.Height = 39;
