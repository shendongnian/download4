    public class SetupFocusAction : DependencyObject, IAction
    {
        public Control TargetObject
        {
            get { return (Control)GetValue(TargetObjectProperty); }
            set { SetValue(TargetObjectProperty, value); }
        }
        public static readonly DependencyProperty TargetObjectProperty =
            DependencyProperty.Register("TargetObject", typeof(Control), typeof(SetupFocusAction), new PropertyMetadata(0));
        public object Execute(object sender, object parameter)
        {
            return TargetObject?.Focus(FocusState.Programmatic);
        }
    }
