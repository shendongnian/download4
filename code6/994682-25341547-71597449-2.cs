    public partial class ClassSelector : UserControl
    {
        public static readonly DependencyProperty CurrentValueProperty = DependencyProperty.Register("CurrentValue", typeof(ClassType),
            typeof(ClassSelector), new FrameworkPropertyMetadata()
                {
                    DefaultValue = ClassType.Type1,
                    BindsTwoWayByDefault = true,
                    PropertyChangedCallback = CurrentValueChanged,
                    DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                });
        private static void CurrentValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (ClassSelector)d;
            obj.cmbClassType.SelectedValue = e.NewValue;
        }
        public ClassType CurrentValue
        {
            get
            {
                return (ClassType)this.GetValue(CurrentValueProperty);
            }
            set
            {
                this.SetValue(CurrentValueProperty, value);
            }
        }
        public ClassSelector()
        {
            InitializeComponent();
            cmbClassType.ItemsSource = Enum.GetValues(typeof(ClassType));
            cmbClassType.SelectedValue = CurrentValue;
        }
    }
