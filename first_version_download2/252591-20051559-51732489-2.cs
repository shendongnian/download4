    protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
    {
          if (keyData == (Keys.Control | Keys.OemQuestion))
          {
                    //Code executes when CTRL + ? button are pressed.
                    //Change keys to your needs.
                    return true;
          }
          return base.ProcessCmdKey(ref msg, keyData);
    }
