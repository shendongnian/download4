    public class AnimaBehavior
    {
      public static readonly DependencyProperty ContentProperty = DependencyProperty.RegisterAttached(
            "Content", typeof(AnimaCollection), typeof(UserControl), new FrameworkPropertyMetadata(new AnimaCollection(), BehaviorPropertyChangedCallback));
    
      public static readonly DependencyProperty ContentProperty = DependencyProperty.RegisterAttached(
            "IsEnabled", typeof(bool), typeof(UserControl), new FrameworkPropertyMetadata(false, InitializeOnAttached));
      public static void SetContent(UIElement element, AnimaCollection value)
      {
        element.SetValue(ContentProperty, value);
      }
      public static AnimaCollection GetContent(UIElement element)
      {
        return (AnimaCollection) element.GetValue(ContentProperty);
      }
    
      private void InitializeOnAttached(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
        if (d is Button attachingElement)
        {
           // Use or store Button
        }
        // Or access AnimaCollection or subscribe to CollectionChanged of AnimaCollection 
        if (d is UIElement attachingElement)
        {
           // Or access AnimaCollection or subscribe to CollectionChanged of AnimaCollection 
           AnimaCollection contentCollection = AnimaBehavior.GetContent(attachingElement);
        }
      }
    }
