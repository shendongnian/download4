        private void worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;            
            siteUrl = SiteURLTextBox.Text;
            GroupListView.ItemsSource = null;
            try
            {
                using(SPSite site = new SPSite(siteUrl))
                {
                    SPWeb web = site.OpenWeb();
                    SPGroupCollection collGroups = web.SiteGroups;
                    if(GroupNames == null)
                        GroupNames = new List<string>();
                    int added = 0;
                    foreach(SPGroup oGroup in collGroups)
                    {
                        added++;
                        ListViewItem tmp = new ListViewItem() {
                            Content = oGroup.Name
                        };
                        worker.ReportProgress((added * 100)/collGroups.Count,tmp);
                    }
                }
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show("Unable to locate a SharePoint site at: " + siteUrl);
            }
        }
