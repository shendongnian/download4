    public Form1()
    {
      InitializeComponent();
      DataGridViewComboBoxColumn cc = new DataGridViewComboBoxColumn();
      cc.Name = "Combo";
      cc.Items.AddRange(new string[] { "Good night", "Good evening", "Good", "All Good", "I'm Good" });
      this.dataGridView1.Columns.Add(cc);
    }
    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
      if (e.Control is ComboBox)
      {
        ComboBox box = e.Control as ComboBox;
        box.DropDownStyle = ComboBoxStyle.DropDown;
        box.AutoCompleteSource = AutoCompleteSource.ListItems;
        box.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      }
    }
