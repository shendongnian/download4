    bool IsPatientExists = IsPatientAlreadyExists(txtPatientIC);
    if (!IsPatientExists)
    {
        using (CareGiverEntities dc = new CareGiverEntities())
        {
    	    dc.Contacts.Add(new Contact
            {
            	PatientName = txtPatientName.Text.Trim(),
                    PatientIc= txtPatientIC.Text.Trim(),
                    Quantity = txtQuantity.Text.Trim(),
                    MedicineTypeID = Convert.ToInt32(ddType.SelectedValue),
                    MedicineID = Convert.ToInt32(ddState.SelectedValue),
                    DatePrecribed= DateTime.Now
            });
            dc.SaveChanges();
            PopulateContacts();
        }
    } 
    private bool IsPatientAlreadyExists(string patientID)
    {
        using (CareGiverEntities dc = new CareGiverEntities())
        {
            dc.Contacts.Add(new Contact
            {
                return dc.Contacts.Any(x=> x.PatientIc == patientID);
            });        
        }
        return false;
    }
