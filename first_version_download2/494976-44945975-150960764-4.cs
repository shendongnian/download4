    private void Button_Click(object sender, RoutedEventArgs e)
    {
        ScrollToRight(txtImagesFolder);
        ScrollToRight(txtTextFolder);
    }
    private void ScrollToRight(TextBox textBox)
    {
        textBox.CaretIndex = textBox.Text.Length - 1;
        var rect = t1.GetRectFromCharacterIndex(textBox.CaretIndex);
        textBox.ScrollToHorizontalOffset(rect.Right);
    }
