    public class MyController: Controller
    {
        public JsonResult MyAction ()
        {
            var data = new List<object>();
            for (var j = 0; j < items.Count(); j++) 
            { 
                var temp = groups.Where(customfilter); 
                data.Add(temp);
            }
            return Json (data, JsonRequestBehavior.AllowGet);
        }
    }
