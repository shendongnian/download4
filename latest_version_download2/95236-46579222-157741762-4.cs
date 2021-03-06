    using System.ComponentModel;
    
    namespace AddInName
    {
        public partial class ThisAddIn
        {
            private BackgroundWorker checkSave_backgroundWorker = new BackgroundWorker();
            
            private void ThisAddIn_Startup(object sender, System.EventArgs e)
            {
                checkSave_backgroundWorker.DoWork += new DoWorkEventHandler(checkSave_backgroundWorker_DoWork);
            }
            // ...
            private void DoSave()
            {
                Globals.ThisAddIn.Application.ActivePresentation.SaveAs( saveAsWmvFileName, Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsWMV, Microsoft.Office.Core.MsoTriState.msoTrue );
                checkSave_backgroundWorker.RunWorkerAsync();
            }
            
            private void checkSave_backgroundWorker_DoWork( object sender, DoWorkEventArgs e )
            {
                bool isDone = false;
                do
                {
                    Thread.Sleep( 1000 );
                    if ( Globals.ThisAddIn.Application.ActivePresentation.CreateVideoStatus == Microsoft.Office.Interop.PowerPoint.PpMediaTaskStatus.ppMediaTaskStatusDone
                        || Globals.ThisAddIn.Application.ActivePresentation.CreateVideoStatus == Microsoft.Office.Interop.PowerPoint.PpMediaTaskStatus.ppMediaTaskStatusFailed
                        || Globals.ThisAddIn.Application.ActivePresentation.CreateVideoStatus == Microsoft.Office.Interop.PowerPoint.PpMediaTaskStatus.ppMediaTaskStatusNone )
                    {
                        isDone = true;
                    }
                } while ( !isDone );
                // Finish!
            }
        }
    }
