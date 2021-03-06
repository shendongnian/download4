    public IQueryable<Tbl_name> GetValueFromTable()
    {
        var selectedCode = Convert.ToInt32(RadioButtonList.SelectedValue);
        return dbo.Tbl_name.Where(q => q.Code == selectedCode)
            .OrderBy(c => c.Date_publication);
    }
