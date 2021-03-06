    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace DesktopApp2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            char cforKeyDown = '\0';
            int _lastKeystroke = DateTime.Now.Millisecond;
            List<char> _barcode = new List<char>();
            bool UseKeyboard = false;
    
            private void Form1_Load(object sender, EventArgs e)
            {
                this.ActiveControl = InputBox;
                this.InputBox.KeyDown += new KeyEventHandler(Form1_KeyDown);
                this.InputBox.KeyUp += new KeyEventHandler(Form1_KeyUp);
            }
            private void Form1_KeyUp(object sender, KeyEventArgs e)
            {
                char NotALetter = '-';
    
                DebugBox.Items.Clear();
                DebugBox.Items.Add($"KeyEventArgs->KeyCode = {e.KeyCode.ToString()}");
                DebugBox.Items.Add($"KeyEventArgs->KeyData = {e.KeyData.ToString()}");
                DebugBox.Items.Add($"KeyEventArgs->KeyValue = {e.KeyValue.ToString()}");
                DebugBox.Items.Add($"KeyEventArgs->e.Shift = {e.Shift.ToString()}");
                DebugBox.Items.Add($"ToCharacter = {ToCharacter(e) ?? NotALetter}");
    
    
                char? ToCharacter(KeyEventArgs kea)
                {
                    if (kea.KeyCode < Keys.A) return null;
                    if (kea.KeyCode > Keys.Z) return null;
    
                    return kea.Shift
                        ? (char)(kea.KeyCode)
                        : char.ToLower((char)(kea.KeyCode));
                }
    
                // if keyboard input is allowed to read
                if (UseKeyboard && e.KeyData != Keys.Enter)
                {
                    MessageBox.Show(e.KeyData.ToString());
                }
    
                /* check if keydown and keyup is not different
                 * and keydown event is not fired again before the keyup event fired for the same key
                 * and keydown is not null
                 * Barcode never fired keydown event more than 1 time before the same key fired keyup event
                 * Barcode generally finishes all events (like keydown > keypress > keyup) of single key at a time, if two different keys are pressed then it is with keyboard
                 */
    
                if (cforKeyDown != (char)e.KeyCode || cforKeyDown == '\0')
                {
                    cforKeyDown = '\0';
                    _barcode.Clear();
                    return;
                }
    
                // getting the time difference between 2 keys
                int elapsed = (DateTime.Now.Millisecond - _lastKeystroke);
    
                /*
                 * Barcode scanner usually takes less than 17 milliseconds to read, increase this if neccessary of your barcode scanner is slower
                 * also assuming human can not type faster than 17 milliseconds
                 */
                // Bumped it up to 35[ms]
                if (elapsed > 1000)
                    _barcode.Clear();
    
                // Do not push in array if Enter/Return is pressed, since it is not any Character that need to be read
                if (e.KeyCode != Keys.Return)
                {
                    //_barcode.Add((char) e.KeyData);
                    _barcode.Add((char)e.KeyData);
                }
    
                OutputBox.Text = string.Concat(_barcode);
    
                // Barcode scanner hits Enter/Return after reading barcode
                if (e.KeyCode == Keys.Return && _barcode.Count > 0)
                {
                    string BarCodeData = new String(_barcode.ToArray());
    
                    if (!UseKeyboard)
                    {
                        //MessageBox.Show(String.Format("{0}", BarCodeData));
                        OutputBox.Text = String.Format("{0}", BarCodeData);
                    }
                    //_barcode.Clear();
                }
                // update the last key stroke time
                _lastKeystroke = DateTime.Now.Millisecond;
            }
    
            private void Form1_KeyDown(object sender, KeyEventArgs e)
            {
                //Debug.WriteLine("CS_Single_Label_Printer_KeyDown : " + (char)e.KeyCode);
                cforKeyDown = (char)e.KeyCode;
            }
        }
    }
