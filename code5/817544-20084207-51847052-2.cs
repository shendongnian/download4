        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(JapanButton), new PropertyMetadata(OnTextChanged));
        private static void OnTextChanged(DependencyProperty d, DependencyPropertyChangedEventArgs e)
        {
            ButtonJapan.Text = Text;
        }
