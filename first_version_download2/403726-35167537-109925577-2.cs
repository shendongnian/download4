            List<List<List<string> > > arrayArrayList = new List<List<List<string>>>();
            List<List<string>> arrayList = new List<List<string>>();
            List<string> list = new List<string>();
            list.Add("Hello");
            list.Add("Hello1");
            list.Add("Hello2");
            var reqUsers = list;
            arrayList.Add(list);
            arrayArrayList.Add(arrayList);
            list = new List<string>();
            list.Add("bye");
            list.Add("bye1");
            list.Add("bye2");
            arrayList =  new List<List<string>>();
            arrayList.Add(list);
            arrayArrayList.Add(arrayList);
            var json = JsonConvert.SerializeObject(arrayArrayList);
