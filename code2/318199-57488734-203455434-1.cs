    //Call this function on form load.
    SetDoubleBuffered(tableLayoutPanel1);
    
    
    public static void SetDoubleBuffered(System.Windows.Forms.Control c)
            {
                if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                    return;
                System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance);
                aProp.SetValue(c, true, null);
            }
