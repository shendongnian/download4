        class BrowsingUrl
        {
            private System.Windows.Forms.WebBrowser nBrowser;
            private System.Windows.Forms.Form theFormLayout1;
            //Just make nBrowser.ReadyState accessible 
            public bool IsLoaded
            {
                get { return nBrowser.ReadyState == WebBrowserReadyState.Complete; }
            }
            public BrowsingUrl(System.Windows.Forms.Form theFormLayout)
            {
                this.nBrowser = new System.Windows.Forms.WebBrowser();
                this.nBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
                this.nBrowser.Location = new System.Drawing.Point(0, 0);
                this.nBrowser.MinimumSize = new System.Drawing.Size(20, 20);
                this.nBrowser.Name = "webBrowser1";
                this.nBrowser.ScrollBarsEnabled = false;
                this.nBrowser.Size = new System.Drawing.Size(1300, 700);
                this.nBrowser.TabIndex = 0;
                this.theFormLayout1 = theFormLayout;
                this.theFormLayout1.Controls.Add(this.nBrowser);
                this.nBrowser.Navigate("https://stackoverflow.com");
                this.nBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.nBrowser_DocumentCompleted);
            }
            private void nBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                // do stuff
                // Alternatively you can set the value of IsLoaded here
            }
        }  
