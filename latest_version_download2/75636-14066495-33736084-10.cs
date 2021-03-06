    namespace WpfApplication1
    {
       /// <summary>
       /// Interaction logic for Note.xaml
       /// </summary>
       public partial class Note : UserControl
       {
           public Note()
           {
               InitializeComponent();
           }
           
           public string Text
           {
               get { return block.Text; }
               set { block.Text = value; }
           }
           
           public new Brush Foreground
           {
               get { return block.Foreground; }
               set { block.Foreground = value; }
           }
           
           public new Brush Background
           {
               get { return myGrid.Background; }
               set { myGrid.Background = value; }
           }
       }
