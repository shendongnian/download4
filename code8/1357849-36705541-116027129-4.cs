    public class OpenFlyoutAction: DependencyObject, IAction
    {
        public object Execute(object sender, object parameter)
        {
            FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
     
            return null;
        }
    }
