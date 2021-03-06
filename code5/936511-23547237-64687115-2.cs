    public class Main
    {
        public void CheckData()
        {
            try
            {
                ProgressBar.ShowProgressBar();
                //do data checking here
                ProgressBar.CloseForm();
            }   
            catch(Exception e)
            {
            }
       }
    }
    public partial class ProgressBar : Form
    {
        public static ProgressBar { get; private set; }
        public ProgressBar()
        {
            InitializeComponent();
            //DoWork();
        }
        static void ShowForm()
        {
            ProgressBar = new ProgressBar();
            Application.Run(ms_ProgressBar);
        }
        public static void CloseForm()
        {
             Invoke(new Action(Close));
             ProgressBar = null;
        }
        public static void ShowProgressBar()
        {
            // Make sure it is only launched once.
            if (ProgressBar != null)
               return;
            var ms_oThread = new Thread(new ThreadStart(ShowForm));
            ms_oThread.IsBackground = true;
            ms_oThread.SetApartmentState(ApartmentState.STA);
            ms_oThread.Start();
        }
    }
