    public sealed partial class MainPage : Page
    {
    
        public MainPage()
        {
            this.InitializeComponent();
    
            OutputNewValues(txtName.Text, tbxAge.Text, tbxDinner.Text);
        }
    
        private void OutputNewValues(string name, string age, string dinner)
        {
            string answer = "Hello, " + name + " you are " + age + " years old. " + dinner + " sounds yummy for dinner!";
            finalOutput.Text = answer;
        }
    }
