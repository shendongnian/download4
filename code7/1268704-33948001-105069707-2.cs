    public JsonResult GetEvents()
    {
        using (var db = new MyDatabaseEntities())
        {
            var events = from cevent in db.EventTables
                         select cevent;
            var rows = events.ToList().Select(cevent => new {
                             id = cevent.Id,
                             start = cevent.Start_Time.AddSeconds(1).ToString("yyyy-MM-ddTHH:mm:ssZ"),
                             end = cevent.End_Time.ToString("yyyy-MM-ddTHH:mm:ssZ")
                         }).ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }            
    }
