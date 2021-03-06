    XDocument document = XDocument.Load(@"XMLFile1.xml");
            List<Item> items = new List<Item>();
            var returnResult = (from r in document.Descendants("item")
                                select r).ToList();
            foreach (XElement xElement in returnResult)
            {
                Item item = new Item();
                item.Key = xElement.Element("key") != null ? xElement.Element("key").Value : "";
                item.Value = xElement.Element("value") != null ? xElement.Element("value").Value : "";
                items.Add(item);
            }
            //sort the list to get the one that have the rest to the end
            var sorted = (from s in items
                          orderby s.Value.Length ascending
                          select s).ToList();
            List<Item> finalList = new List<Item>();
            items.Clear();
            for (int i = 0; i < sorted.Count - 1; i++)
            {
                for (int j = 1; j < sorted.Count; j++)
                {
                    if (sorted[j].Value.Contains(sorted[i].Value) &&
                        sorted[j].Value.Length > sorted[i].Value.Length)
                    {
                        Item itm = new Item();
                        itm.Key = sorted[j].Key;
                        KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(sorted[i].Key,sorted[i].Value);
                        itm.Items.Add(kvp);
                        items.Add(itm);
                    }
                    else
                    {
                        if (!finalList.Contains(sorted[i]))
                            finalList.Add(sorted[i]);
                    }
                }
            }
    class Item
    {
        public List<Item> Items { get; set; }
        public string Key { get; set; }
        public string Value {get;set;}
        public Item()
        {
            Items = new List<Item>();
        }
    }
