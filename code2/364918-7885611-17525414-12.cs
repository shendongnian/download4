        private void SelectionSource_SelectionChanged(
           object sender, RoutedEventArgs e)
        {
            var targetTextBox
                 = ((TextBox) sender).Tag as TextBox;
            if (targetTextBox != null)
            {
                targetTextBox.Tag = (TextBox) sender;
                var bndExp
                    = BindingOperations.GetBindingExpression(
                        targetTextBox, TextBox.TextProperty);
                if (bndExp != null)
                {
                    bndExp.UpdateTarget();
                }
            }
        }
