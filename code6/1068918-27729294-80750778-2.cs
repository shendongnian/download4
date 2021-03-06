    public static IEnumerable<AttachLabel> GetAttachLabel()
    {
        Entities db = new Entities();
        return from item in db.tblAttachLabels select new AttachLabel()
        {
            ID = item.ID,
            Text = item.Text
        };
    }
