    using System.Windows.Forms;
    
    public class App
    {
        [STAThread]
        public static void Main()
        {
            var dlg = new OpenFileDialog())
            Application.Run(dlg);
            string fname = d.FileName;
            LongRunningProcess();
        }
    }
