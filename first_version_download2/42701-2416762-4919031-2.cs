    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    public class Form1 : Form
    {
       [DllImport("user32.dll",CharSet=CharSet.Auto, CallingConvention=CallingConvention.StdCall)]
       public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);
    
       private const int MOUSEEVENTF_LEFTDOWN = 0x02;
       private const int MOUSEEVENTF_LEFTUP = 0x04;
       private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
       private const int MOUSEEVENTF_RIGHTUP = 0x10;
    
       public Form1()
       {
       }
    
       public void DoMouseClick()
       {
          //Call the imported function with the cursor's current position
          int X = Cursor.Position.X;
          int Y = Cursor.Position.Y;
          mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
       }
    
       //...other code needed for the application
    }
