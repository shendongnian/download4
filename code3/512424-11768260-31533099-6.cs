        public delegate void AppendConsoleText(string text);
        public AppendConsoleText appendConsoleTextDelegate;
        private void Form1_Load(object sender, EventArgs e)
        {
            appendConsoleTextDelegate = new AppendConsoleText(textBox1_AppendConsoleText);
            using (ProcessLauncher launcher = new ProcessLauncher(this))
            {
                launcher.Start();
                launcher.SendInput("import sys;\n");
                launcher.SendInput("print \"Test.\";\n");
                launcher.SendInput("exit()\n");
            }
        }
        private void textBox1_AppendConsoleText(string text)
        {
            textBox1.AppendText(string.Format("{0}\r\n", text));
        }
