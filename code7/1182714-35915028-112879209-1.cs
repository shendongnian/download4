      Add this to the CellEditEnd event:
            ((DataGrid)sender).Dispatcher.BeginInvoke((Action)delegate ()
            {
                try
                {
                    // Code
                }
                catch (InvalidOperationException) { }
                catch (Exception ex) { throw ex; }
            });
