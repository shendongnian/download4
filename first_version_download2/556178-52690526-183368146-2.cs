    private const String CREATENEW = "Create new...";
    private List<String> measurementUnits; // Fill this up somehow.
    private String lastSelectedUnit;
    public MyForm()
    {
        this.InitializeComponent();
        // Fill up the 'measurementUnits' list somehow here.
        // ...
        // Add items to list
        RefreshMeasurementUnits();
    }
    public Boolean RefreshMeasurementUnits()
    {
        // Last selected actual item.
        String selectedItem = this.lastSelectedUnit;
        Int32 selected = -1;
        for (Int32 i = 0; i < this.measurementUnits.Count; i++)
        {
           String curItem = this.measurementUnits[i];
           if (selectedItem == curItem)
              selected = i;
           this.cmbMeasurementUnits.Items.Add(curItem);
        }
        this.cmbMeasurementUnits.Items.Add(CREATENEW);
        if (selected != -1)
            this.cmbMeasurementUnits.SelectedIndex = selected;
        // Returns true if an item was selected.
        return selected != -1;
    }
    private void cmbMeasurementUnits_SelectedIndexChanged(Object sender, EventArgs e)
    {
        // Detect if selected item is the last one.
        if (this.cmbMeasurementUnits.SelectedIndex < this.measurementUnits.Count)
        {
            // store last selected item
            this.lastSelectedUnit = this.cmbMeasurementUnits.SelectedItem as String;
            // Not optional: exit if the item is not the last one.
            return;
        }
        // Code to add new item here. Only executed if the item is the last one.
        // This should open a dialog that manipulates the contents of the
        // 'measurementUnits' list.
        // ...
        // Refresh the items list using the 'measurementUnits' list.
        Boolean hasSelection = RefreshMeasurementUnits();
        // if auto-reselect failed, ensure that the selected item is NOT the last one.
        if (!hasSelection)
        {
            if (measurementUnits.Count > 0)
                cmbMeasurementUnits.SelectedIndex = 0;
            else
                cmbMeasurementUnits.SelectedItem = null;
        }
    }
