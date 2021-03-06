    public static List<AdditionalPropertyType> SQLAddPropsStructured(DataTable dataTable, List<AdditionalPropertyType> currentadditionalproperties)
    {
        foreach (DataRow row in dataTable.Rows)
        {
            var tlprev = new AdditionalPropertyType
            {
                Name = row[0].ToString(),
                Value = row[1].ToString()
            };
            for (int i = 2; i <= 3; ++i) { //change this according to your need
                if (String.IsNullOrEmpty(row[i].ToString())){
                    currentadditionalproperties.Insert(0, tlprev);
                    continue;
                }
                var lnext = new AdditionalPropertyType
                {
                    Name = row[i].ToString()
                };
                var lnextlist = new List<AdditionalPropertyType>();
                lnextlist.Add(tlprev);
                lnext.AdditionalProperties = lnextlist;
                tlprev = lnext; //need to record this for the next loop or end of the case
            }
            currentadditionalproperties.Insert(0, tlprev);                                            
        }
        return currentadditionalproperties;
    }
